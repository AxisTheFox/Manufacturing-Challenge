﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Manufacturing_Challenge.AdminPages
{
    public partial class Admin : System.Web.UI.Page
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

        protected void lookAtUsersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LookAtUsers.aspx");
        }
        protected void addScenarioButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddScenario.aspx");
        }
        protected void deleteScenarioButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteScenario.aspx");
        }
    }
}