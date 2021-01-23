using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AttendanceSystem.TeacherView
{
    public partial class CheckLeaveDetails : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static int TeacherId;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TeacherId"] != null)
                {
                    TeacherId = Convert.ToInt32(Session["TeacherId"]);

                    int j = 0;
                    while (j < CourseName.Items.Count)
                    {
                        CourseName.Items.Clear();
                        j++;
                    }

                    SqlDataAdapter SelClass = new SqlDataAdapter("Select Distinct CourseDetails.CourseName, SemesterDetailsN.SemesterNo From CourseDetails Inner Join SemesterDetailsN On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Inner Join SubjectDetails On(SemesterDetailsN.SemesterId=SubjectDetails.SemesterId) Inner Join TeacherTimeTable On(TeacherTimeTable.SubjectId=SubjectDetails.SubjectId) Where TeacherTimeTable.TeacherId='"+TeacherId+"'", con);
                    DataSet ds = new DataSet();
                    SelClass.Fill(ds);
                    int i = 0;
                    while (i < ds.Tables[0].Rows.Count)
                    {
                        CourseName.Items.Add(ds.Tables[0].Rows[i][0] + " " + ds.Tables[0].Rows[i][1]);
                        i++;
                    }
                    CourseName.Items.Insert(0, "Select...");


                    SqlDataAdapter SelectLeaveStu = new SqlDataAdapter("Select LeaveTable.StudentId,StudentDetails.StudentName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,Convert(NVARCHAR(50),LeaveTable.LeaveStartingDate,103)as Leave_Starting_Date ,Convert(NVARCHAR(50),LeaveTable.LeaveEndingDate,103)as Leave_Ending_Date,LeaveTable.Reason From LeaveTable Inner Join StudentDetails On(LeaveTable.StudentId=StudentDetails.StudentId) Inner Join SemesterDetailsN On(SemesterDetailsN.SemesterId=StudentDetails.SemesterId)Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId)Where LeaveTable.TeacherId='" +TeacherId + "'And LeaveStartingDate='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "'", con);
                    DataSet ds1 = new DataSet();
                    SelectLeaveStu.Fill(ds1);
                    // Response.Write(Session["StartingDate"] = Convert.ToDateTime(ds.Tables[0].Rows[0][5]));
                    Gridview1.DataSource = ds1;
                    Gridview1.DataBind();

                }
                else
                {
                    Response.Redirect("~/LogInFolder/TeacherLogIn.aspx");
                }
            }
        }

        protected void CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
       
       
    }
}