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
        /*There is a SLIGHT possibility that a player could be presented with a scenario,
         then an admin DELETES that scenario and its associated solutions before the player
         picks a solution. This would break the game. All the data about the solutions
         should be saved AT LOAD TIME and called later. But that's hard.
         */
        int userId;
        int scenarioId;
        int station;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                userId = (int)Session["userId"];
                station = (int)Session["userStation"];
                if (!IsPostBack)
                {
                    getScenario();
                    getSolutions();
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        public void getScenario()
        {
            conn.Open();
            string qry = "select * from [Scenario] where Station = " + station;
            SqlCommand cmd = new SqlCommand(qry, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Random rng = new Random();
            var tableRow = dt.Rows[rng.Next(0, dt.Rows.Count)];
            scenarioTextLabel.Text = tableRow.Field<string>("PromptText");
            scenarioId = (int)tableRow.Field<Int64>("id");
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

            solutionsRbl.DataSource = dt;
            solutionsRbl.DataTextField = "Text";
            solutionsRbl.DataValueField = "ID";
            solutionsRbl.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string answer = solutionsRbl.SelectedValue;
            if (answer == "")
            {
                errorLabel.Text = "Make sure you choose a solution!";
                errorLabel.Visible = true;
            }
            else
            {
                goBackButton.Visible = true;
                submitButton.Visible = false;
                errorLabel.Visible = false;

                showResults();
                updateAsset("Money", answer);
                updateAsset("Products", answer);
                updateAsset("Parts", answer);
                updateAsset("Employees", answer);
                updateAsset("Customers", answer);
            }
        }

        private void showResults()
        {
            resultsLabel.Visible = true;
            //get results from user
            //label = results
        }

        private void updateAsset(string field, string answer)
        {
            int newTotal = getCurrentAsset(field) + getImpactAsset(field, answer);
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
            int nextStation = (station + 1) % 8;
            conn.Open();
            string qry = "Update [User] set [currentStation] = " + nextStation + " where (ID = " + userId + ")";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}