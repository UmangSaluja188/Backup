using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem
{
    public partial class HomePage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LogIn_Click(object sender, EventArgs e)
        {
          
        }
        protected void Log_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LogInFolder/NewHomePage.aspx");
        }
}
}