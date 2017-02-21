using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Manufacturing_Challenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["userFirstName"] != null)
            {
                setWelcomeLabel();
                showLogoutOption();
            }
            else
            {
                showLoggedOutContent();
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }

        private void setWelcomeLabel()
        {
            string firstNameOfUser = Session["userFirstName"].ToString();
            welcomeLabel.Text = "Welcome back, " + firstNameOfUser + "!";
        }

        private void showLogoutOption()
        {
            logoutLabel.Visible = true;
            logoutButton.Visible = true;
        }

        private void showLoggedOutContent()
        {
            loginLabel.Visible = true;
            loginLink.Visible = true;
            signupLabel.Visible = true;
            signupLink.Visible = true;
        }
    }
}