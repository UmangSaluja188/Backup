using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AttendanceSystem.ManageTeacherTimeTable
{
    public partial class SearchTimeTable : System.Web.UI.Page
    {
        public static int CourseIdValue = 0, SemesterIdValue = 0, Value = 0, SemesterNoValue = 0;
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        DataSet STTds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["AdminId"] == null)
                {

                    //Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }

            if (!IsPostBack)
            {
                //Select All Course 
                try
                {
                    SqlDataAdapter SelectCourseName = new SqlDataAdapter("Select  CourseName From CourseDetails", con);
                    DataSet SCNds = new DataSet();
                    SelectCourseName.Fill(SCNds);
                    CourseName.DataSource = SCNds.Tables[0];
                    CourseName.DataTextField = "CourseName";
                    CourseName.DataValueField = "CourseName";
                    CourseName.DataBind();
                    CourseName.Items.Insert(0, "Select..");
                    SemesterNo.Items.Insert(0, "Select..");
                }
                catch (Exception err)
                {
                    Error.Text = "Search  All Course Portion " + err.Message;
                }

            }
        }



        protected void CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Course Id
            try
            {
                if (CourseName.SelectedIndex > 0)
                {
                    SqlDataAdapter SelectCourseId = new SqlDataAdapter("Select TotalNoOfSemester,CourseId From CourseDetails Where CourseName='" + CourseName.SelectedItem.Text + "'", con);
                    DataSet SCIDds = new DataSet();
                    SelectCourseId.Fill(SCIDds);
                    if (SCIDds.Tables[0].Rows.Count > 0)
                    {
                        CourseIdValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][1]);//1

                        Response.Write(CourseIdValue);
                        //Romove Pre Semester Details 3
                        for (int i = 1; i <= SemesterNoValue; i++)
                        {
                            SemesterNo.Items.Remove("" + i);
                        }


                        //Add New Selected Course Semester 4
                        SemesterNoValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][0]);//1
                        for (int i = 1; i <= SemesterNoValue; i++)
                        {
                            SemesterNo.Items.Add("" + i);
                        }

                        SelectSemesterPanel.Visible = true;
                    }
                }
            }
            catch (Exception err)
            {
                Error.Text = "Search  All Course Portion " + err.Message;
            }
        
        }
        protected void SemesterNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Semester Id 
            try
            {
                SqlDataAdapter SelectSemesterId = new SqlDataAdapter("Select SemesterId From SemesterDetailsN Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Where CourseDetails.CourseName='"+CourseName.SelectedItem.Text+" ' AND SemesterNo='" + SemesterNo.SelectedItem.Text + "'", con);
                DataSet SSIDds = new DataSet();
                SelectSemesterId.Fill(SSIDds);
                SemesterIdValue = Convert.ToInt32(SSIDds.Tables[0].Rows[0][0]);//2

                SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select TeacherTimeTable.TimeTableNo,TeacherTimeTable.Day,TeacherTimeTable.Time,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectName,TeacherDetails.TeacherName,TeacherTimeTable.RoomNo From SemesterDetailsN Inner Join SubjectDetails On SemesterDetailsN.SemesterId=SubjectDetails.Semesterid inner Join TeacherTimeTable On (SubjectDetails.SubjectId=TeacherTimeTable.SubjectId)inner join TeacherDetails On (TeacherTimeTable.Teacherid=TeacherDetails.TeacherId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)  Where SemesterDetailsN.SemesterId='" + SemesterIdValue + "'", con);
                SelectTimeTable.Fill(STTds);
                DisplayTimeTable(STTds);
                Day.Enabled = true;
            }
            catch (Exception err)
            {
                Error.Text = "Select TimeTable By Course Name Portion " + err.Message;
            }
        }




        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void FilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Filter By Option
            try
            {
                reset();
                if (FilterBy.SelectedIndex > 0)
                {

                    if (FilterBy.SelectedItem.Text == "Course Name")
                    {
                        SelectCoursePanel.Visible = true;
                        SelectSemesterPanel.Visible = false;
                        TeacherNamePanel.Visible = false;
                        TeacherIdPanel.Visible = false;


                    }
                    else if (FilterBy.SelectedItem.Text == "Teacher Name")
                    {
                        SelectCoursePanel.Visible = false;
                        SelectSemesterPanel.Visible = false;
                        TeacherNamePanel.Visible = true;
                        TeacherIdPanel.Visible = false;

                    }
                    else if (FilterBy.SelectedItem.Text == "Teacher Id")
                    {
                        SelectCoursePanel.Visible = false;
                        SelectSemesterPanel.Visible = false;
                        TeacherNamePanel.Visible = false;
                        TeacherIdPanel.Visible = true;

                    }
                }
            }
            catch (Exception err)
            {
                Error.Text = "Filter By Option Portion " + err.Message;
            }
        }

        private void reset()
        {
            CourseName.SelectedIndex = 0;
            SemesterNo.SelectedIndex = 0;
            TeacherName.Text = "";
            Day.SelectedIndex = 0;
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //Search Teacher Time Table By Teacher Name

            if (TeacherName.Text != "")
            {
                SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select TeacherTimeTable.TimeTableNo,TeacherTimeTable.Day,TeacherTimeTable.Time,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectName,TeacherDetails.TeacherId,TeacherDetails.TeacherName,TeacherTimeTable.RoomNo From SemesterDetailsN Inner Join SubjectDetails On SemesterDetailsN.SemesterId=SubjectDetails.Semesterid inner Join TeacherTimeTable On (SubjectDetails.SubjectId=TeacherTimeTable.SubjectId)inner join TeacherDetails On (TeacherTimeTable.Teacherid=TeacherDetails.TeacherId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)  Where TeacherDetails.TeacherName='" + TeacherName.Text + "'", con);
                SelectTimeTable.Fill(STTds);
                DisplayTimeTable(STTds);
                Day.Enabled = true;
            }
        }

        private void DisplayTimeTable(DataSet STTds)
        {
            GridView2.DataSource = STTds;
            GridView2.DataBind();
        }

        protected void Day_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write("hellogfggf");
            //Select Teacher Time Table Day vise
    try
            {
                if (Day.SelectedIndex > 0)
                {
                    if (FilterBy.SelectedItem.Text == "Course Name")
                    {
                        SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select TeacherTimeTable.TimeTableNo,TeacherTimeTable.Day,TeacherTimeTable.Time,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectName,TeacherDetails.TeacherId,TeacherDetails.TeacherName,TeacherTimeTable.RoomNo From SemesterDetailsN Inner Join SubjectDetails On SemesterDetailsN.SemesterId=SubjectDetails.Semesterid inner Join TeacherTimeTable On (SubjectDetails.SubjectId=TeacherTimeTable.SubjectId)inner join TeacherDetails On (TeacherTimeTable.Teacherid=TeacherDetails.TeacherId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)  Where TeacherTimeTable.Day='" + Day.Text + "' AND SemesterDetailsN.SemesterId='" + SemesterIdValue + "'", con);
                        SelectTimeTable.Fill(STTds);
                        DisplayTimeTable(STTds);
                    }
                    else if (FilterBy.SelectedItem.Text == "Teacher Name")
                    {

                        SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select TeacherTimeTable.TimeTableNo,TeacherTimeTable.Day,TeacherTimeTable.Time,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectName,TeacherDetails.TeacherId,TeacherDetails.TeacherName,TeacherTimeTable.RoomNo From SemesterDetailsN Inner Join SubjectDetails On SemesterDetailsN.SemesterId=SubjectDetails.Semesterid inner Join TeacherTimeTable On (SubjectDetails.SubjectId=TeacherTimeTable.SubjectId)inner join TeacherDetails On (TeacherTimeTable.Teacherid=TeacherDetails.TeacherId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)  Where TeacherTimeTable.Day='" + Day.Text + "' AND TeacherDetails.TeacherName='" + TeacherName.Text + "'", con);
                        SelectTimeTable.Fill(STTds);
                        DisplayTimeTable(STTds);
                    }
                    else if (FilterBy.SelectedItem.Text == "Teacher Id")
                    {
                        SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select TeacherTimeTable.Day,TeacherTimeTable.Time,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectName,TeacherDetails.TeacherId,TeacherDetails.TeacherId,TeacherDetails.TeacherName,TeacherTimeTable.RoomNo From SemesterDetailsN Inner Join SubjectDetails On SemesterDetailsN.SemesterId=SubjectDetails.Semesterid inner Join TeacherTimeTable On (SubjectDetails.SubjectId=TeacherTimeTable.SubjectId)inner join TeacherDetails On (TeacherTimeTable.Teacherid=TeacherDetails.TeacherId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)  Where TeacherTimeTable.Day='" + Day.Text + "' AND TeacherDetails.TeacherId='" + TeacherId.Text + "'", con);
                        SelectTimeTable.Fill(STTds);
                        DisplayTimeTable(STTds);
                    }

                }
                //Search Teacher Time Table regarding all weak
                else
                {
                    if (FilterBy.SelectedItem.Text == "Course Name")
                    {
                        SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select TeacherTimeTable.TimeTableNo,TeacherTimeTable.Day,TeacherTimeTable.Time,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectName,TeacherDetails.TeacherId,TeacherDetails.TeacherName,TeacherTimeTable.RoomNo From SemesterDetailsN Inner Join SubjectDetails On SemesterDetailsN.SemesterId=SubjectDetails.Semesterid inner Join TeacherTimeTable On (SubjectDetails.SubjectId=TeacherTimeTable.SubjectId)inner join TeacherDetails On (TeacherTimeTable.Teacherid=TeacherDetails.TeacherId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Where SemesterDetailsN.SemesterId='" + SemesterIdValue + "'", con);
                        SelectTimeTable.Fill(STTds);
                        DisplayTimeTable(STTds);
                    }
                    else if (FilterBy.SelectedItem.Text == "Teacher Name")
                    {

                        SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select TeacherTimeTable.TimeTableNo,TeacherTimeTable.Day,TeacherTimeTable.Time,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectName,TeacherDetails.TeacherId,TeacherDetails.TeacherName,TeacherTimeTable.RoomNo From SemesterDetailsN Inner Join SubjectDetails On SemesterDetailsN.SemesterId=SubjectDetails.Semesterid inner Join TeacherTimeTable On (SubjectDetails.SubjectId=TeacherTimeTable.SubjectId)inner join TeacherDetails On (TeacherTimeTable.Teacherid=TeacherDetails.TeacherId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Where TeacherDetails.TeacherName='" + TeacherName.Text + "'", con);
                        SelectTimeTable.Fill(STTds);
                        DisplayTimeTable(STTds);
                    }
                    else if (FilterBy.SelectedItem.Text == "Teacher Id")
                    {
                        SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select TeacherTimeTable.Day,TeacherTimeTable.Time,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectName,TeacherDetails.TeacherId,TeacherDetails.TeacherId,TeacherDetails.TeacherName,TeacherTimeTable.RoomNo From SemesterDetailsN Inner Join SubjectDetails On SemesterDetailsN.SemesterId=SubjectDetails.Semesterid inner Join TeacherTimeTable On (SubjectDetails.SubjectId=TeacherTimeTable.SubjectId)inner join TeacherDetails On (TeacherTimeTable.Teacherid=TeacherDetails.TeacherId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)  Where TeacherDetails.TeacherId='" + TeacherId.Text + "'", con);
                        SelectTimeTable.Fill(STTds);
                        DisplayTimeTable(STTds);
                    }
                }
            }
            catch (Exception err)
            {
                Error.Text = "Search  Teacher Time Table Day and Weak Vise Portion " + err.Message;
            }
            
        }

        protected void Search1_Click(object sender, EventArgs e)
        {
            //Search Teacher Time Table By Teacher id
            try
            {
                if (TeacherId.Text != "")
                {
                    SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select TeacherTimeTable.TimeTableNo,TeacherTimeTable.Day,TeacherTimeTable.Time,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectName,TeacherDetails.TeacherId,TeacherDetails.TeacherName,TeacherTimeTable.RoomNo From SemesterDetailsN Inner Join SubjectDetails On SemesterDetailsN.SemesterId=SubjectDetails.Semesterid inner Join TeacherTimeTable On (SubjectDetails.SubjectId=TeacherTimeTable.SubjectId)inner join TeacherDetails On (TeacherTimeTable.Teacherid=TeacherDetails.TeacherId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)  Where TeacherDetails.TeacherId='" + TeacherId.Text + "'", con);
                    SelectTimeTable.Fill(STTds);
                    DisplayTimeTable(STTds);
                    Day.Enabled = true;
                }
            }
            catch (Exception err)
            {
                Error.Text = "Search Teacher Time table By teacher id=" + err.Message;
            }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            }
}
}
