using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                AttemptSignup();
            else
                ShowEmptyFieldsMessage();
        }

        private bool NoEmptyFieldsExist()
        {
            return emailTextBox.Text != "" && firstNameTextBox.Text != "" && lastNameTextBox.Text != "" && passwordTextBox.Text != "" && confirmPasswordTextBox.Text != "";
        }

        private void AttemptSignup()
        {
            if (AccountWithEmailAlreadyExists())
                ShowAccountAlreadyExistsMessage();
            VerifyPasswordFieldsMatch();
            SubmitUserInformationToDatabase();
        }

        private void VerifyPasswordFieldsMatch()
        {
            if (!PasswordFieldsMatch())
                ShowPasswordMismatchMessage();
        }

        private bool PasswordFieldsMatch()
        {
            return passwordTextBox.Text.Equals(confirmPasswordTextBox.Text);
        }

        private bool AccountWithEmailAlreadyExists()
        {
            return EmailExistsInDatabase();
        }

        private bool EmailExistsInDatabase()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);
            // TODO: check database for emails that match the email input by the user.
            return false;
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

        private void ShowAccountAlreadyExistsMessage()
        {
            signupFailedMessage.Text = "There's already an account associated with this Email.";
        }
    }
}