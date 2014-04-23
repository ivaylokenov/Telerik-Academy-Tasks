using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebFormsTemplate.Models;

namespace WebFormsTemplate.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                IAuthenticationManager manager = new AuthenticationIdentityManager(new IdentityStore(new LibrarySystemDbContext())).Authentication;
                IdentityResult result = manager.CheckPasswordAndSignIn(Context.GetOwinContext().Authentication, UserName.Text, Password.Text, RememberMe.Checked);
                if (result.Success)
                {
                    OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    FailureText.Text = result.Errors.FirstOrDefault();
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}