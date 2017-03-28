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
                    //Do stuff? Like show board maybe?
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void btnAnswerScenario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Scenario.aspx");
        }
    }
}