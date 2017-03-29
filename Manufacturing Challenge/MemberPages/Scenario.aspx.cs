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
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            userId = (int)(Session["userID"]);

            if (!IsPostBack)
            {
                getScenario();
                getSolutions();
            }
        }

        public void getScenario()
        {
            conn.Open();
            string qry = "select * from [Scenario] where Station in (select CurrentStation from [User] where ID = " + userId + ")";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string scenarioText = rdr["PromptText"].ToString();
                scenarioId = int.Parse(rdr["id"].ToString());
                lblScenarioText.Text = scenarioText;
            }
            conn.Close();
        }

        public void getSolutions()
        {
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string answer = rblSolutions.SelectedValue;
            if (answer == "")
            {
                errorLabel.Text = "Make sure you choose a solution!";
                errorLabel.Visible = true;
            }
            else
            {
                goBackButton.Visible = true;
                btnSubmit.Visible = false;
                errorLabel.Visible = false;

                updateAsset("Money", answer);
                updateAsset("Products", answer);
                updateAsset("Parts", answer);
                updateAsset("Employees", answer);
                updateAsset("Customers", answer);
            }

            //shows User stats
            conn.Open();
            string qry = "select * from [User] where ID = " + userId;
            SqlCommand cmd = new SqlCommand(qry, conn);
            showGridView(cmd);
        }
        private void updateAsset(string field, string answer)
        {
            int newTotal = getCurrentAsset(field) + getImpactAsset(field, answer);
            lblScenarioText.Text = newTotal.ToString();
            conn.Open();
            string qry = "Update [User] set [Assets" + field + "] = " + newTotal.ToString() + " where (ID = " + userId + ")";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private int getCurrentAsset(string field)
        {
            conn.Open();
            string qry = "select Assets" + field + " from [User] where ID = " + userId;
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            int current = 0;
            while (rdr.Read())
            {
                current = int.Parse(rdr["Assets" + field].ToString());
            }
            rdr.Close();
            conn.Close();
            return current;
        }

        private int getImpactAsset(string field, string answer)
        {
            conn.Open();
            string qry = "select Impact" + field + " from [Solution] where ID = " + answer;
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            int impact = 0;
            while (rdr.Read())
            {
                impact = int.Parse(rdr["Impact" + field].ToString());
            }
            rdr.Close();
            conn.Close();
            return impact;
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

        public void showGridView(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gvDisplay.DataSource = dt;
            gvDisplay.DataBind();
        }
    }
}