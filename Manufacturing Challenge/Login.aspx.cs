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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (Email.Text != "" && Password.Text != "")
            {
                attemptLogin();
            }
        }

        private void attemptLogin()
        {
            try
            {
                LogInUser();
            }
            catch
            {
                ShowErrorText();
            }
        }

        private void LogInUser()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);
            string qry = "SELECT ID, Password FROM [User] WHERE Email=@e;";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@e", Email.Text);
            string passwordFromDatabase = "";
            int userId = 0;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                passwordFromDatabase = rdr["Password"].ToString();
                userId = Int32.Parse(rdr["ID"].ToString());
            }
            rdr.Close();
            conn.Close();
            string passwordFromUser = Password.Text;
            if (passwordFromUser.Equals(passwordFromDatabase))
            {
                Session["UserId"] = userId;
                Response.Redirect("Default.aspx");
            }
            else
            {
                LoginFailedMessage.Text = "The Email or password you entered doesn't match our records.";
            }
        }

        private void ShowErrorText()
        {
            LoginFailedMessage.Text = "Something went wrong, and we weren't able to log you in. Try again in a minute or so.";
        }
    }
}