using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Manufacturing_Challenge
{
    public partial class Login : System.Web.UI.Page
    {
        string passwordFromDatabase = "";
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
            string passwordFromUser = Password.Text;
            ObtainPasswordFromDatabaseUsingEmail();
            if (passwordFromUser.Equals(passwordFromDatabase))
            {
                Session["UserId"] = userId;
                Response.Redirect("Default.aspx");
            }
            else
            {
                ShowInvalidLoginMessage();
            }
        }

        private void ObtainPasswordFromDatabaseUsingEmail()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);
            string qry = "SELECT ID, Password FROM [User] WHERE Email=@e;";
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
                passwordFromDatabase = rdr["Password"].ToString();
                userId = Int32.Parse(rdr["ID"].ToString());
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