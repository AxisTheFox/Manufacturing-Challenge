using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            else if (passwordFieldsMatch())
            {
                SubmitUserInformationToDatabase();
                Response.Redirect("Default.aspx");
            }
        }

        private bool passwordFieldsMatch()
        {
            if (!PasswordFieldsMatch())
            {
                ShowPasswordMismatchMessage();
                return false;
            }
            else
            {
                return true;
            }
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
            string hashedPassword = hashUserPassword();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);
            string qry = "INSERT INTO [User] (Email, FirstName, LastName, Password, Company, Position, PhoneNumber, City, State, Country, AssetsMoney, AssetsProducts, AssetsParts, AssetsEmployees, AssetsCustomers, CurrentStation, Admin) VALUES (@email, @fname, @lname, @pass, @co, @pos, @phone, @city, @state, @country, 0, 0, 0, 0, 0, 0, 0)";
            SqlCommand cmd = new SqlCommand(qry, conn);
            addParametersToSqlCommand(hashedPassword, cmd);
            conn.Open();
            int result = 0;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                if (result != 1)
                    ShowSignupErrorMessage();
            }
            conn.Close();
        }

        private string hashUserPassword()
        {
            SHA1CryptoServiceProvider sha1Service = new SHA1CryptoServiceProvider();
            sha1Service.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passwordTextBox.Text));
            byte[] result = sha1Service.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        private void addParametersToSqlCommand(string hashedPassword, SqlCommand cmd)
        {
            parameterizeRequiredFields(hashedPassword, cmd);
            parameterizeOptionalFields(cmd);
        }

        private void parameterizeRequiredFields(string hashedPassword, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@email", emailTextBox.Text);
            cmd.Parameters.AddWithValue("@fname", firstNameTextBox.Text);
            cmd.Parameters.AddWithValue("@lname", lastNameTextBox.Text);
            cmd.Parameters.AddWithValue("@pass", hashedPassword);
        }

        private void parameterizeOptionalFields(SqlCommand cmd)
        {
            TextBox[] optionalFields = { companyTextBox, positionTextBox, phoneNumberTextBox, cityTextBox, stateTextBox, countryTextBox };
            string[] optionalFieldParameters = { "@co", "@pos", "@phone", "@city", "@state", "@country" };
            cmd.Parameters.AddWithValue("@co", companyTextBox.Text);
            cmd.Parameters.AddWithValue("@pos", positionTextBox.Text);
            cmd.Parameters.AddWithValue("@phone", phoneNumberTextBox.Text);
            cmd.Parameters.AddWithValue("@city", cityTextBox.Text);
            cmd.Parameters.AddWithValue("@state", stateTextBox.Text);
            cmd.Parameters.AddWithValue("@country", countryTextBox.Text);
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

        private void ShowSignupErrorMessage()
        {
            signupFailedMessage.Text = "Something went wrong while creating your account. Try again in a minute.";
        }
    }
}