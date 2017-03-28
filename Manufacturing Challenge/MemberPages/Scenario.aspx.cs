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
    public partial class Scenario : System.Web.UI.Page
    {
        int userId;
        Int64 scenarioId;
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = (int)(Session["userID"]);

            if (!IsPostBack)
            {
                getScenario();
                getSolutions();
            }
        }

        public void getSolutions()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);
            conn.Open();
            string qry = "select * from [solution] where ScenarioId = " + scenarioId;
            SqlCommand cmd = new SqlCommand(qry, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            rblSolutions.DataSource = dt;
            rblSolutions.DataTextField = "Text";
            rblSolutions.DataValueField = "ID";
            rblSolutions.DataBind();
        }

        public void getScenario()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);
            conn.Open();
            string qry = "select * from [Scenario] where Station in (select CurrentStation from [User] where ID = " + userId + ")";
            SqlCommand cmd = new SqlCommand(qry, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            Random rng = new Random();
            var tableRow = dt.Rows[rng.Next(0, dt.Rows.Count)];
            string scenarioText = tableRow.Field<string>("PromptText");
            scenarioId = tableRow.Field<Int64>("id");
            lblScenarioText.Text = scenarioText;

            conn.Close();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            goBackButton.Visible = true;
            btnSubmit.Visible = false;

            string answer = rblSolutions.SelectedValue;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);
            conn.Open();
            string qry = "select * from [Solution] where ID = " + answer;
            SqlCommand cmd = new SqlCommand(qry, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gvDisplay.DataSource = dt;
            gvDisplay.DataBind();

            pushAssetChanges(dt);
        }

        private void pushAssetChanges(DataTable dt)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);
            conn.Open();
            string qry = "Update Users set assetMoney";
        }

        protected void goBackButton_Click(object sender, EventArgs e)
        {
            updateStation();
            Response.Redirect("Play.aspx");
        }

        public void updateStation()
        {
            //get current station from user
            //if station = ""
            //next station = ""
            //We should use numbers instead of station names so that we can simply add 1 to update next station.
        }
    }
}