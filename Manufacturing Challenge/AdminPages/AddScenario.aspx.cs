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

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string scenarioId = (getMaxScenarioId() + 1).ToString();
            Label1.Text = scenarioId;
            insertScenario(stationDdl.SelectedValue, scenarioId, scenarioPromptTextBox.Text, scenarioResultsTextBox.Text);
            insertSolution(scenarioId, SolutionOneTextBox.Text, SolutionOneCorrectCheckBox.Checked, SolutionOneMoneyTextBox.Text, SolutionOneProductsTextBox.Text, SolutionOnePartsTextBox.Text, SolutionOneEmployeesTextBox.Text, SolutionOneCustomersTextBox.Text);
            insertSolution(scenarioId, SolutionTwoTextBox.Text, SolutionTwoCorrectCheckBox.Checked, SolutionTwoMoneyTextBox.Text, SolutionTwoProductsTextBox.Text, SolutionTwoPartsTextBox.Text, SolutionTwoEmployeesTextBox.Text, SolutionTwoCustomersTextBox.Text);
            insertSolution(scenarioId, SolutionThreeTextBox.Text, SolutionThreeCorrectCheckBox.Checked, SolutionThreeMoneyTextBox.Text, SolutionThreeProductsTextBox.Text, SolutionThreePartsTextBox.Text, SolutionThreeEmployeesTextBox.Text, SolutionThreeCustomersTextBox.Text);
            insertSolution(scenarioId, SolutionFourTextBox.Text, SolutionFourCorrectCheckBox.Checked, SolutionFourMoneyTextBox.Text, SolutionFourProductsTextBox.Text, SolutionFourPartsTextBox.Text, SolutionFourEmployeesTextBox.Text, SolutionFourCustomersTextBox.Text);
        }

        private void insertScenario(string station, string id, string promptText, string resultsText)
        {
            conn.Open();
            string qry = "INSERT INTO Scenario (Station, ID, PromptText, ResultsText) VALUES (@s, @i, @p, @r);";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@s", station);
            cmd.Parameters.AddWithValue("@i", id);
            cmd.Parameters.AddWithValue("@p", promptText);
            cmd.Parameters.AddWithValue("@r", resultsText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void insertSolution(string scenarioId, string text, Boolean correct, string impactMoney, string impactProducts, string impactParts, string impactEmployees, string impactCustomers)
        {
            conn.Open();
            string qry = "INSERT INTO Solution (scenarioID, text, correct, impactMoney, impactProducts, impactParts, impactEmployees, impactCustomers) VALUES(@i, @t, @c, @m, @pr, @pa, @e, @cu);";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@i", scenarioId);
            cmd.Parameters.AddWithValue("@t", text);
            cmd.Parameters.AddWithValue("@c", correct);
            cmd.Parameters.AddWithValue("@m", impactMoney);
            cmd.Parameters.AddWithValue("@pr", impactProducts);
            cmd.Parameters.AddWithValue("@pa", impactParts);
            cmd.Parameters.AddWithValue("@e", impactEmployees);
            cmd.Parameters.AddWithValue("@cu", impactCustomers);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private int getMaxScenarioId()
        {
            conn.Open();
            string qry = "select Max(ID) from Scenario";
            SqlCommand cmd = new SqlCommand(qry, conn);
            int maxId = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return maxId;
        }
    }
}