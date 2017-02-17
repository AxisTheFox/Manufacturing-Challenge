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
            try
            {
                SqlConnection conn = Connect();
                SqlCommand cmd = CreateSqlCommand("Select ID from User where Email=@e and Password=@p", conn);
                cmd.Parameters.AddWithValue("@e", Email.Text);
                cmd.Parameters.AddWithValue("@p", Password.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
            }
            catch
            {
                LoginFailedMessage.Text = "Something went wrong, and we weren't able to log you in. Try again in a minute.";
                LoginFailedMessage.Visible = true;
            }
        }

        public SqlConnection Connect()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);
        }

        public SqlCommand CreateSqlCommand(string qry, SqlConnection conn)
        {
            return new SqlCommand(qry, conn);
        }
    }
}