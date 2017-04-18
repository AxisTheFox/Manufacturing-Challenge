using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Manufacturing_Challenge.MemberPages
{
    public partial class Play : System.Web.UI.Page
    {
        int userId;
        int userStation;
        string userFirstName;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                userFirstName = Session["userFirstName"].ToString();
                userId = (int)Session["userId"];
                userStation = getStation(userId);
                if (!IsPostBack)
                {
                    //Do stuff? Like show board maybe?
                    showAssets();
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        private int getStation(int userId)
        {
            int station = 0;
            conn.Open();
            string qry = "select CurrentStation from [User] where ID = " + userId;
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                station = (int)rdr["CurrentStation"];
                Session["userStation"] = station;
            }
            conn.Close();
            return station;
        }

        private void showAssets()
        {
            /*conn.Open();
            string qry = "select assetsMoney, assetsProducts, assetsParts, assetsEmployees, assetsCustomers from [User] where ID = " + userId;
            SqlCommand cmd = new SqlCommand(qry, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            assetsGridView.DataSource = dt;
            assetsGridView.DataBind();*/
        }

        protected void btnAnswerScenario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Scenario.aspx");
        }
    }
}