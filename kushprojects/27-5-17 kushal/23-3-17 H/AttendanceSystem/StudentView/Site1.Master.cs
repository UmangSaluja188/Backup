using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace AttendanceSystem.StudentView
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public static int StudentId;
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StudentId"] == null)
            {
                Response.Redirect("~/LogInFolder/StudentLogIn.aspx");
            }
            StudentId = Convert.ToInt32(Session["StudentId"]);
            SqlDataAdapter SelStuDet = new SqlDataAdapter("Select StudentId,StudentName,Image From StudentDetails Where StudentId='" + StudentId + "'", con);

            DataSet ds = new DataSet();
            SelStuDet.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                SignOutimg.ImageUrl = ds.Tables[0].Rows[0][2].ToString();
                SideImg.ImageUrl = ds.Tables[0].Rows[0][2].ToString();
                StudentIdT.Text = "StudentId " + ds.Tables[0].Rows[0][0].ToString();
                StudentName.Text = "Student Name " + ds.Tables[0].Rows[0][1].ToString();
            }
            
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session["StudentId"] = null;
            Response.Redirect("~/LogInFolder/LogInHomePage.aspx");
        }
    }
}