using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsTemplate.Models;

namespace WebFormsTemplate.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Determine the sections to render
                ILoginManager manager = new IdentityManager(new IdentityStore(new LibrarySystemDbContext())).Logins;
                if (manager.HasLocalLogin(User.Identity.GetUserId())) 
                {
                    changePasswordHolder.Visible = true;
                }
                else 
                {
                    setPassword.Visible = true;
                    changePasswordHolder.Visible = false;
                }
                CanRemoveExternalLogins = manager.GetLogins(User.Identity.GetUserId()).Count() > 1;

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null) 
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                IPasswordManager manager = new IdentityManager(new IdentityStore(new LibrarySystemDbContext())).Passwords;
                IdentityResult result = manager.ChangePassword(User.Identity.GetUserName(), CurrentPassword.Text, NewPassword.Text);
                if (result.Success) 
                {
                    Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else 
                {
                    AddErrors(result);
                }
            }
        }

        protected void SetPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Create the local login info and link the local account to the user
                ILoginManager manager = new IdentityManager(new IdentityStore(new LibrarySystemDbContext())).Logins;
                IdentityResult result = manager.AddLocalLogin(User.Identity.GetUserId(), User.Identity.GetUserName(), password.Text);
                if (result.Success) 
                {
                    Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                }
                else 
                {
                    AddErrors(result);
                }
            }
        }

        public IEnumerable<IUserLogin> GetLogins()
        {
            ILoginManager manager = new IdentityManager(new IdentityStore(new LibrarySystemDbContext())).Logins;
            var accounts = manager.GetLogins(User.Identity.GetUserId());
            CanRemoveExternalLogins = accounts.Count() > 1;
            return accounts;
        }

        public void RemoveLogin(string loginProvider, string providerKey)
        {
            ILoginManager manager = new IdentityManager(new IdentityStore(new LibrarySystemDbContext())).Logins;
            var result = manager.RemoveLogin(User.Identity.GetUserId(), loginProvider, providerKey);
            var msg = result.Success
                ? "?m=RemoveLoginSuccess"
                : String.Empty;
            Response.Redirect("~/Account/Manage" + msg);
        }

        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error);
            }
        }
    }
}