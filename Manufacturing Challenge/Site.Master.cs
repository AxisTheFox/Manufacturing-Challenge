using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Manufacturing_Challenge
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            adminLink.Visible = false;
            if (Session["userId"] != null)
            {
                playLink.Visible = true;
                if (playerIsAdmin((int)Session["userId"]))
                {
                    adminLink.Visible = true;
                }
            }
            else
            {
                adminLink.Visible = false;
                playLink.Visible = false;
            }
        }

        private Boolean playerIsAdmin(int userId)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);
            conn.Open();
            string qry = "select Admin from [User] where ID = " + userId;
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            Boolean admin = false;
            try
            {
                while (rdr.Read())
                {
                    admin = (Boolean)rdr["Admin"];
                }
            }
            catch { }
            rdr.Close();
            conn.Close();
            return admin;
        }
    }
}