using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Security.Claims;
using System.Web;
using WebFormsTemplate.Models;

namespace WebFormsTemplate.Account
{
    public partial class RegisterExternalLogin : System.Web.UI.Page
    {
        protected string ProviderName
        {
            get { return (string)ViewState["ProviderName"] ?? String.Empty; }
            private set { ViewState["ProviderName"] = value; }
        }

        protected string ProviderAccountKey
        {
            get { return (string)ViewState["ProviderAccountKey"] ?? String.Empty; }
            private set { ViewState["ProviderAccountKey"] = value; }
        }

        protected void Page_Load()
        {
            // Process the result from an auth provider in the request
            ProviderName = OpenAuthProviders.GetProviderNameFromRequest(Request);
            if (String.IsNullOrEmpty(ProviderName))
            {
                Response.Redirect("~/Account/Login");
            }
            if (!IsPostBack)
            {
                IAuthenticationManager manager = new AuthenticationIdentityManager(new IdentityStore(new LibrarySystemDbContext())).Authentication;
                var auth = Context.GetOwinContext().Authentication;
                ClaimsIdentity id = manager.GetExternalIdentity(auth);
                IdentityResult result = manager.SignInExternalIdentity(auth, id);
                if (result.Success)
                {
                    OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else if (User.Identity.IsAuthenticated)
                {
                    result = manager.LinkExternalIdentity(id, User.Identity.GetUserId());
                    if (result.Success)
                    {
                        OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    }
                    else
                    {
                        AddErrors(result);
                        return;
                    }
                }
                else
                {
                    userName.Text = id.Name;
                }
            }
        }        
        
        protected void LogIn_Click(object sender, EventArgs e)
        {
            CreateAndLoginUser();
        }

        private void CreateAndLoginUser()
        {
            if (!IsValid)
            {
                return;
            }
            var user = new User(userName.Text);
            IAuthenticationManager manager = new AuthenticationIdentityManager(new IdentityStore(new LibrarySystemDbContext())).Authentication;
            IdentityResult result = manager.CreateAndSignInExternalUser(Context.GetOwinContext().Authentication, user);
            if (result.Success)
            {
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                AddErrors(result);
                return;
            }
        }

        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error);
            }
        }
    }
}