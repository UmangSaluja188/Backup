using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem.Admin_View.AdminMasterPage
{
    public partial class Site3 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignOut_Click(object sender, EventArgs e)
        {
            
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["AdminId"] = null;
            Response.Redirect("~/LogInFolder/LogInHomePage.aspx");
        }
    }
}