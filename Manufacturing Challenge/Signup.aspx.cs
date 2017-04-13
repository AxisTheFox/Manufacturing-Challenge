using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Manufacturing_Challenge
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
                Response.Redirect("/Default.aspx");
        }

        protected void signupButton_Click(object sender, EventArgs e)
        {
            if (NoEmptyFieldsExist())
            {
                AttemptSignup();
            }
            else
            {
                ShowEmptyFieldsMessage();
            }
        }

        private Boolean NoEmptyFieldsExist()
        {
            return emailTextBox.Text != "" && firstNameTextBox.Text != "" && lastNameTextBox.Text != "" && passwordTextBox.Text != "" && confirmPasswordTextBox.Text != "";
        }

        private void AttemptSignup()
        {
            VerifyPasswordFieldsMatch();
            SubmitUserInformationToDatabase();
        }

        private void VerifyPasswordFieldsMatch()
        {
            if (!PasswordFieldsMatch())
            {
                ShowPasswordMismatchMessage();
            }
        }

        private bool PasswordFieldsMatch()
        {
            return passwordTextBox.Text.Equals(confirmPasswordTextBox.Text);
        }

        private void SubmitUserInformationToDatabase()
        {

        }

        private void ShowEmptyFieldsMessage()
        {
            signupFailedMessage.Text = "You left out some information we need to create your account.";
        }

        private void ShowPasswordMismatchMessage()
        {
            signupFailedMessage.Text = "The password and confirmation password you entered do not match.";
        }
    }
}