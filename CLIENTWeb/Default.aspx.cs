using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLIENTWeb
{
    //*************************************
    //WEB SERVICES (Lab4)(ASP.NET)
    //CLIENT WEBPAGE (TO TEST WEB SERVICES)
    //Dean Jones
    //Jan.18, 2017
    //*************************************

    public partial class Default : System.Web.UI.Page
    {
        // PAGE LOAD
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                IsGridEmpty();          //test for customer info or message    
            }
        }

        // METHOD TO TEST IF RESULTS ARE EMPTY
        protected void IsGridEmpty()
        {
            // if the table is empty
            if (gvIncidents.Rows.Count == 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "There are no incidents for this customer";
            }
            else
            {
                lblMessage.Visible = false; //show label
                lblMessage.Text = "";
            }
        }

        // METHOD FOR PULLDOWN CHANGED EVENT
        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsGridEmpty();  //test for customer info or message   
        }
    }
}