using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Manufacturing_Challenge
{
    public partial class Login : System.Web.UI.Page
    {
        string hashedPasswordFromDatabase = "";
        string userFirstName = "";
        int userId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (NoEmptyFieldsExist())
            {
                AttemptLogin();
            }
            else
            {
                ShowEmptyFieldsMessage();
            }
        }

        private Boolean NoEmptyFieldsExist()
        {
            return Email.Text != "" && Password.Text != "";
        }

        private void AttemptLogin()
        {
            try
            {
                AttemptUserLogin();
            }
            catch
            {
                ShowLoginErrorMessage();
            }
        }

        private void AttemptUserLogin()
        {
            string hashedPasswordFromUser = hashUserPassword(Password.Text);
            ObtainPasswordFromDatabaseUsingEmail();
            if (hashedPasswordFromUser.Equals(hashedPasswordFromDatabase))
            {
                Session["userId"] = userId;
                Session["userFirstName"] = userFirstName;
                Response.Redirect("Default.aspx");
            }
            else
            {
                ShowInvalidLoginMessage();
            }
        }

        private string hashUserPassword(string passwordFromUser)
        {
            SHA1CryptoServiceProvider sha1Service = new SHA1CryptoServiceProvider();
            sha1Service.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passwordFromUser));
            byte[] result = sha1Service.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        private void ObtainPasswordFromDatabaseUsingEmail()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);
            string qry = "SELECT ID, Password, FirstName FROM [User] WHERE Email=@e;";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@e", Email.Text);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GetAccountDataFromReader(rdr);
            rdr.Close();
            conn.Close();
        }

        private void GetAccountDataFromReader(SqlDataReader rdr)
        {
            while (rdr.Read())
            {
                hashedPasswordFromDatabase = rdr["Password"].ToString();
                userId = Int32.Parse(rdr["ID"].ToString());
                userFirstName = rdr["FirstName"].ToString();
            }
        }

        private void ShowEmptyFieldsMessage()
        {
            LoginFailedMessage.Text = "We need your email and password to log you in.";
        }

        private void ShowInvalidLoginMessage()
        {
            LoginFailedMessage.Text = "The Email or password you entered doesn't match our records.";
        }

        private void ShowLoginErrorMessage()
        {
            LoginFailedMessage.Text = "Something went wrong, and we weren't able to log you in. Try again in a minute or so.";
        }
    }
}