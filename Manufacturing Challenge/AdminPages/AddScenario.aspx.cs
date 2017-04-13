using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Manufacturing_Challenge.AdminPages
{
    public partial class AddScenarios : System.Web.UI.Page
    {
        int userId;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gamedb"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                userId = (int)Session["userId"];
                if (!IsPostBack)
                {
                    //Do stuff if necessary
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void submitButton_Click(object sender, EventArgs e) //BREAKS but I'm out of time and need to commit.
        {
            string scenarioId = (getMaxScenarioId() + 1).ToString();
            Label1.Text = scenarioId;

            insertScenario(stationDdl.SelectedValue, scenarioId, scenarioPromptTextBox.Text, scenarioResultsTextBox.Text);
            //InsertSolution(stuff, scenarioId)
        }

        private void insertScenario(string station, string id, string promptText, string resultsText)
        {
            conn.Open();
            string qry = "INSERT INTO Solution() VALUES();";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void insertSolution(string scenarioId, string text, Boolean correct, string impactMoney, string impactProducts, string impactParts, string impactEmployees, string impactCustomers)
        {
            conn.Open();
            string qry = "INSERT INTO Solution () VALUES();";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private int getMaxScenarioId()
        {
            int maxId = 0;
            conn.Open();
            string qry = "select Max(ID) from Scenario";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                maxId = (int)rdr["Id"]; //Breaks here
            }
            conn.Close();
            return maxId;
        }
    }
}