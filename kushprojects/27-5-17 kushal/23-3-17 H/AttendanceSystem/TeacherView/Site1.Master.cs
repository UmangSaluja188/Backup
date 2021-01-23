using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AttendanceSystem.TeacherView
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public static int TeacherId;
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static string value;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherId"] == null)
            {
                Response.Redirect("~/LogInFolder/TeacherLogIn.aspx");
            }

           
            TeacherId = Convert.ToInt32(Session["TeacherId"]);
            SqlDataAdapter SelStuDet = new SqlDataAdapter("Select TeacherId,TeacherName,Image From TeacherDetails Where TeacherId='" + TeacherId + "'", con);
            
            DataSet ds = new DataSet();
            SelStuDet.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                SignOutimg.ImageUrl = ds.Tables[0].Rows[0][2].ToString();
                SideImg.ImageUrl = ds.Tables[0].Rows[0][2].ToString();
                StudentIdT.Text = "Teacher Id" + ds.Tables[0].Rows[0][0].ToString();
                StudentName.Text = "Teacher Name " + ds.Tables[0].Rows[0][1].ToString();
            }
            
        }
    }
}