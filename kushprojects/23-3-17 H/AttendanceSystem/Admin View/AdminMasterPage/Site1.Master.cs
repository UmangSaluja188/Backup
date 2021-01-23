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
            
        }

        protected void SignOut_Click1(object sender, EventArgs e)
        {

        }

        protected void SignOut2_Click(object sender, EventArgs e)
        {

        }

        protected void S1_Click(object sender, EventArgs e)
        {
            Session["AdminId"] = null;
            Session["Password"] = null;
            Response.Redirect("~/LogInFolder/NewHomePage.aspx");
        }
    }
}