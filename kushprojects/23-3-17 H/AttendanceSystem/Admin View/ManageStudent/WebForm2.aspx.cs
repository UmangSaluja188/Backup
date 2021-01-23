using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem.Admin_View.ManageStudent
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(System.DateTime.Now.ToLongTimeString());
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            Response.Write("<br>"+System.DateTime.Now.ToLongTimeString());

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<br>" + System.DateTime.Now.ToLongTimeString());

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<br>" + System.DateTime.Now.ToLongTimeString());

        }
    }
}