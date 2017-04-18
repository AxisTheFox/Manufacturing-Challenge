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
            if (NoRequiredFieldsAreEmpty())
                AttemptSignup();
            else
                ShowEmptyRequiredFieldsMessage();
        }

        private bool NoRequiredFieldsAreEmpty()
        {
            return emailTextBox.Text != "" && firstNameTextBox.Text != "" && lastNameTextBox.Text != "" && passwordTextBox.Text != "" && confirmPasswordTextBox.Text != "";
        }

        private void AttemptSignup()
        {
            if (AccountWithEmailAlreadyExists())
                ShowAccountAlreadyExistsMessage();
            else
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
            return EmailAlreadyExistsInDatabase();
        }

        private bool EmailAlreadyExistsInDatabase()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);
            string qry = "SELECT 'True' FROM [User] WHERE Email=@e";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("e", emailTextBox.Text);
            conn.Open();
            object queryReturnValue = cmd.ExecuteScalar();
            conn.Close();
            return queryReturnValue != null;
        }

        private void SubmitUserInformationToDatabase()
        {

        }

        private void ShowEmptyRequiredFieldsMessage()
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