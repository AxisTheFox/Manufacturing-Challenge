using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Manufacturing_Challenge.AdminPages
{
    public partial class AddScenarios : System.Web.UI.Page
    {
        int userId;
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
            //Get all the stuff above and insert into db.
        }
    }
}