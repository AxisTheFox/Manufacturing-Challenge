using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Manufacturing_Challenge.MemberPages
{
    public partial class Play : System.Web.UI.Page
    {
        int userId;
        string userFirstName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                userFirstName = Session["userFirstName"].ToString();
                userId = (int)Session["userId"];
                if (!IsPostBack)
                {
                    updateStation();
                }
            }
        }

        public void updateStation()
        {
            //get current station from user
            //if station = ""
            //next station = ""
            //We should use numbers instead of station names so that we can simply add 1 to update next station.
        }
        protected void btnAnswerScenario_Click(object sender, EventArgs e)
        {
            Server.Transfer("Scenario.aspx");
        }
    }
}