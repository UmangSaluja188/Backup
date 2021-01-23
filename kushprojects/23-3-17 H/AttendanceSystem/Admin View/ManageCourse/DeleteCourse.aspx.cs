using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace AttendanceSystem.ManageCourse
{
    public partial class Delete : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        string CourseId;
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                if (Session["AdminId"] != null)
                {
            //Query String Pass From Search Details

            try
            {
                
                    CourseId = Request.QueryString["CourseId"];
                    if (CourseId != "")
                    {
                        SearchTextBox.Text = CourseId;
                    }
                
            }
            catch (Exception err)
            {
                Error.Text = err.Message;
            }
                }
                else
                {
                    //Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            // Delete Course
            try
            {
                if (SearchTextBox.Text != null)
                {
                    SqlDataAdapter SearchCourse = new SqlDataAdapter("Select CourseId From CourseDetails Where CourseId='" + SearchTextBox.Text + "'", con);
                    DataSet SCIDds = new DataSet();
                    SearchCourse.Fill(SCIDds);
                    if (SCIDds.Tables[0].Rows.Count > 0)
                    {
                        SqlDataAdapter DeleteCourse = new SqlDataAdapter("Delete CourseDetails Where CourseId='" + SearchTextBox.Text + "'", con);
                        DataSet DCds = new DataSet();
                        DeleteCourse.Fill(DCds);
                        Response.Write("<script type=\"text/javascript\">" + "alert('Selected Course Record Are Successfully Deleted');" + "</script>");
                        SearchTextBox.Text = "";
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">" + "alert('InValid CourseId');" + "</script>");

                    }
                    Response.Redirect("~/Admin View/ManageCourse/SearchCourseDetails.aspx");

                }
            }
            catch (Exception err)
            {
                Error.Text = "Delete Course Portion " + err.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManageCourse/SearchCourseDetails.aspx");
        }

       
    }
}