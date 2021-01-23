using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AttendanceSystem.TeacherView
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static int TeacherId;
        public static string value;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherId"] == null)
            {
                
                Response.Redirect("~/LogInFolder/TeacherLogIn.aspx");
            }

            TeacherId = Convert.ToInt32(Session["TeacherId"]);
            value = Request.QueryString["Value"].ToString();
            
            if (value == "WeakTimeTable")
            {
                DayPanel.Visible = true;
            }
            string Day, Date;
            Day = System.DateTime.Today.ToString("dddd");
            Date = System.DateTime.Today.ToString("dd/MM/yyyy");
           
            Day1.Text = Day;
            Date1.Text = Date.ToString();
            SqlDataAdapter da = new SqlDataAdapter("Select Day,Time,SubjectDetails.SubjectName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,RoomNo From TeacherTimeTable Inner Join SubjectDetails On(TeacherTimeTable.SubjectId=SubjectDetails.SubjectId) Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Where Day='" + Day1 + "' AND TeacherId='" + TeacherId + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            TimeTable.DataSource = ds;
            TimeTable.DataBind();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = System.DateTime.Now.ToLongTimeString();
        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            Time.Text = System.DateTime.Now.ToLongTimeString();
        }

        protected void Timer2_Tick1(object sender, EventArgs e)
        {
            Time.Text = System.DateTime.Now.ToLongTimeString();
        }

        protected void Timer1_Tick1(object sender, EventArgs e)
        {

        }

        protected void Day_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Day2.SelectedIndex > 0)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select Day,Time,SubjectDetails.SubjectName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,RoomNo From TeacherTimeTable Inner Join SubjectDetails On(TeacherTimeTable.SubjectId=SubjectDetails.SubjectId) Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Where Day='" + Day2.SelectedItem.Text + "' AND TeacherId='" + TeacherId + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                TimeTable.DataSource = ds;
                TimeTable.DataBind();
            }
        }
    }
}