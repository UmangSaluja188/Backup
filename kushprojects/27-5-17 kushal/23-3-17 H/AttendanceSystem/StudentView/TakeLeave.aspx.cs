using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace AttendanceSystem.StudentView
{
    public partial class TakeLeave : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static   string StartingTime, CloseingTime, periodDuration;
        public static int StudentId1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["StudentId"] != null)
                {
                    StudentId1 = Convert.ToInt32(Session["StudentId"]);
                    int min1, min2, hours1, hours2, totalmin1, totalLacture, subtracthours, subtractmin, lacmin, lachours, totallacmin;
                    SqlDataAdapter SelectCollegeTiming = new SqlDataAdapter("Select * From CollegeTiming", con);
                    DataSet SCTds = new DataSet();
                    SelectCollegeTiming.Fill(SCTds);

                    StartingTime = SCTds.Tables[0].Rows[3][0].ToString();
                    CloseingTime = SCTds.Tables[0].Rows[3][1].ToString();
                    periodDuration = SCTds.Tables[0].Rows[3][2].ToString();

                    DateTime Open = Convert.ToDateTime(StartingTime);
                    DateTime Close = Convert.ToDateTime(CloseingTime);
                    DateTime LacDur = Convert.ToDateTime(periodDuration);
                    lachours = LacDur.Hour;
                    lacmin = LacDur.Minute;
                    totallacmin = (lachours * 60) + lacmin;
                    hours1 = Close.Hour;
                    min1 = Close.Minute;
                    Close.IsDaylightSavingTime();

                    hours2 = Open.Hour;
                    min2 = Open.Minute;
                    subtracthours = hours1 - hours2;
                    subtractmin = min1 - min2;
                    totalmin1 = (subtracthours * 60) + subtractmin;
                    totalLacture = totalmin1 / totallacmin;
                    Response.Write(totalLacture);
                    DateTime lacTime = new DateTime();
                    lacTime = Open;
                    int a = Open.Minute;
                    StartingTime1.Items.Insert(0, "Select Time");
                    EndingTime1.Items.Insert(0, "Select Time");
                    for (int i = 1; i <= totalLacture; i++)
                    {
                        StartingTime1.Items.Add(Open.AddMinutes(a).ToString("hh:mm:ss tt"));
                        EndingTime1.Items.Add(Open.AddMinutes(a).ToString("hh:mm:ss tt"));
                        a = a + totallacmin;


                    }
                    int LasValue = EndingTime1.Items.Count;
                    StartingTime1.SelectedIndex = 1;
                    EndingTime1.SelectedIndex = LasValue - 1;

                }
                else
                {
                    //Response.Redirect("~/LogInFolder/StudentLogIn.aspx");
                }
                DefaultValues();
            }
        }

        private void DefaultValues()
        {
            SqlDataAdapter SelectSemeStartEndDate = new SqlDataAdapter("Select SemesterDetailsN.SemesterStartingDate,SemesterDetailsN.SemesterEndingDate From SemesterDetailsN Inner Join StudentDetails On(SemesterDetailsN.SemesterId=StudentDetails.SemesterId)Where StudentDetails.StudentId='" + StudentId1 + "' ", con);
            DataSet ds1 = new DataSet();
            SelectSemeStartEndDate.Fill(ds1);
            From.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0][0]).Date.ToString("dd/MM/yyyy");
            To.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0][1]).Date.ToString("dd/MM/yyyy");
            Response.Write(ds1.Tables[0].Rows[0][0].ToString());
            Cal.SelectedDate = Convert.ToDateTime(From.Text);
            Cal.VisibleDate = Convert.ToDateTime(From.Text);
            Calendar1.SelectedDate = Convert.ToDateTime(To.Text);
            Calendar1.VisibleDate = Convert.ToDateTime(To.Text);
        }

        protected void Leavetype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Search_Click(object sender, EventArgs e)
        {
           
        }

        protected void Cal_SelectionChanged(object sender, EventArgs e)
        {
            From.Text = Cal.SelectedDate.ToString("dd/MM/yyyy");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            To.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            DateTime StartingT = Convert.ToDateTime(Cal.SelectedDate.ToString("yyyy/MM/dd"));
            DateTime EndingT = Convert.ToDateTime(Calendar1.SelectedDate.ToString("yyyy/MM/dd"));
            DateTime StartingTimeValue = Convert.ToDateTime(StartingTime1.SelectedItem.Text);
            DateTime EndingTimeValue = Convert.ToDateTime(EndingTime1.SelectedItem.Text);
            SqlDataAdapter SelectTeacherId = new SqlDataAdapter("Select Distinct TeacherTimeTable.TeacherId From TeacherTimeTable Inner Join SubjectDetails On(TeacherTimeTable.SubjectId=SubjectDetails.SubjectId) Inner Join SubAllByStu On(SubAllByStu.SubjectId=SubjectDetails.SubjectId) Where SubAllByStu.StudentId='" + StudentId1 + "' AND TeacherTimeTable.Time>='" + Convert.ToDateTime(StartingTime1.Text).ToShortTimeString() + "' AND TeacherTimeTable.Time<='" + Convert.ToDateTime(EndingTime1.Text).ToLongTimeString() + "'", con);
            DataSet ds = new DataSet();
            SelectTeacherId.Fill(ds);
            
            int i = 0;
            while (i < ds.Tables[0].Rows.Count)
            {
                SqlDataAdapter InsertLeaveDetails = new SqlDataAdapter("Insert Into LeaveTable (StudentId,LeaveStartingDate,LeaveEndingDate,StartingTime,EndingTime,TeacherId,Reason,LeaveStatus)Values('" + StudentId1+ "','" + StartingT + "','" + EndingT + "','" + StartingTimeValue + "','" + EndingTimeValue + "','" + ds.Tables[0].Rows[i][0] + "','''" + Reason.Text + "','Reject')", con);
                DataSet ds2 = new DataSet();
                InsertLeaveDetails.Fill(ds2);
                i++;
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            SqlDataAdapter delete = new SqlDataAdapter("Delete TeacherTimeTable", con);
            DataSet ds = new DataSet();
            delete.Fill(ds);
        }
    }
}