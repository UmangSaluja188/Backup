using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AttendanceSystem
{
    public partial class AttendanceDetails : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public DataSet SelectStudentsds = new DataSet();
        public static int StudentId = 0, TotalLac, FinePerDay;
        public int TotalFin, TotalFine = 0;
        public static string SubjectName;
        public DateTime StartingDate = new DateTime();
        public DateTime EndingDate = new DateTime();
        public static string Month, Day, Year;
        public static int StartingMonthNo, EndingMonthNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Select Semester Starting Time


            if (!IsPostBack)
            {
                Default();

            }

        }

        private void Default()
        {
            StudentId = Convert.ToInt32(Request.QueryString["StudentId"]);
            SubjectName = Request.QueryString["SubjectName"].ToString();
            TotalLac = Convert.ToInt32(Request.QueryString["AttendLactures"]);
            SqlDataAdapter SelectAllStudents = new SqlDataAdapter("Select  StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentAttendance.Day,StudentAttendance.Time,Convert(NVARCHAR(10),StudentAttendance.Date,103) As Date,StudentAttendance.AttendanceStatus,StudentAttendance.AttendanceStatus AS Fine, StudentAttendance.AttendanceId " +
"From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
" Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
" Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
"Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)" +
" Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)" +
"Where StudentDetails.StudentId='" + StudentId + "'AND SubjectDetails.SubjectName='" + SubjectName + "' ", con);

            SelectAllStudents.Fill(SelectStudentsds);
            GridView1.DataSource = SelectStudentsds;
            GridView1.DataBind();
            CheckTotalFine();
           
            TotalLacAnfFine();
        }
        private void TotalLacAnfFine()
        {
            int i = 0;
            Label1.Text = "  Total " + TotalLac.ToString();
            while (i < GridView1.Rows.Count)
            {

                TotalFine += Convert.ToInt32(GridView1.Rows[i].Cells[7].Text);
                i++;
            }
            Label2.Text = " Total " + TotalFine;
        }

       
        protected void Search2_Click(object sender, EventArgs e)
        {
            string FromDate, ToDate, check;
            DateTime From1 = new DateTime();
            DateTime To1 = new DateTime();

            From1 = Convert.ToDateTime(From.Text);

            FromDate = From1.Date.ToString("yyyy/MM/dd");


            //Response.Write(Selected);
            check = To.Text;
            if (!string.IsNullOrWhiteSpace(this.To.Text))
            {
                To1 = Convert.ToDateTime(To.Text);
                ToDate = To1.Date.ToString("yyyy/MM/dd");
                Response.Write("HELLO" + FromDate);
                SqlDataAdapter SelectAllStudents = new SqlDataAdapter("Select  StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentAttendance.Day,StudentAttendance.Time,Convert(NVARCHAR(10),StudentAttendance.Date,103) As Date,StudentAttendance.AttendanceStatus ,StudentAttendance.AttendanceStatus AS Fine,StudentAttendance.AttendanceId " +
   "From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
   " Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
   " Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
   "Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)" +
   " Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)" +
   "Where StudentDetails.StudentId='" + StudentId + "'AND SubjectDetails.SubjectName='" + SubjectName + "'AND StudentAttendance.Date>='" + DateTime.Parse(FromDate) + "'AND StudentAttendance.Date<='" + DateTime.Parse(ToDate) + "' ", con);



                SelectAllStudents.Fill(SelectStudentsds);
                GridView1.DataSource = SelectStudentsds;
                GridView1.DataBind();
                CheckTotalFine();
                TotalLacAnfFine();
            }

            else
            {

                Response.Write("abc" + StudentId + SubjectName);
                SqlDataAdapter SelectAllStudents = new SqlDataAdapter("Select  StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentAttendance.Day,StudentAttendance.Time,Convert(NVARCHAR(10),StudentAttendance.Date,103)As Date,StudentAttendance.AttendanceStatus ,StudentAttendance.AttendanceStatus AS Fine,StudentAttendance.AttendanceId " +
   "From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
   " Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
   " Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
   "Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)" +
   " Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)" +
   "Where StudentDetails.StudentId='" + StudentId + "'AND SubjectDetails.SubjectName='" + SubjectName + "'AND StudentAttendance.Date='" + DateTime.Parse(From.Text) + "' ", con);



                SelectAllStudents.Fill(SelectStudentsds);
                //Selected = SelectStudentsds.Tables[0].Rows[0][5].ToString();

                GridView1.DataSource = SelectStudentsds;
                GridView1.DataBind();

            }

        }

        private void CheckTotalFine()
        {

            int i = 0;
            SqlDataAdapter PerDayFineCharge = new SqlDataAdapter("Select FinePerDay From FineDetails  Inner Join StudentDetails On (StudentDetails.SemesterId=FineDetails.SemesterId)Where StudentDetails.StudentId='" + StudentId + "'", con);
            DataSet ds2 = new DataSet();
            PerDayFineCharge.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                FinePerDay = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
            }
            while (i < SelectStudentsds.Tables[0].Rows.Count)
            {
                SqlDataAdapter TotalFine = new SqlDataAdapter("Select AttendanceStatus From StudentAttendance  Where AttendanceId='" + SelectStudentsds.Tables[0].Rows[i][8] + "' AND StudentAttendance.AttendanceStatus='0' AND StudentAttendance.LeaveRequest='0'", con);
                DataSet ToFineds = new DataSet();
                TotalFine.Fill(ToFineds);
                //  TotalFine.SelectCommand.Parameters.AddWithValue("@Date", Convert.ToDateTime(SelectStudentsds.Tables[0].Rows[0][5]).ToString("MM/dd/yyyy"));

                if (ToFineds.Tables[0].Rows.Count > 0)
                {

                    GridView1.Rows[i].Cells[7].Text = (FinePerDay).ToString();
                }
                else
                {
                    GridView1.Rows[i].Cells[7].Text = (0).ToString();
                }
                SqlDataAdapter LeaveStu = new SqlDataAdapter("Select AttendanceStatus,LeaveRequest From StudentAttendance  Where AttendanceId='" + SelectStudentsds.Tables[0].Rows[i][8] + "' AND StudentAttendance.AttendanceStatus='0' AND StudentAttendance.LeaveRequest='1'", con);
                DataSet Leaveds = new DataSet();
                LeaveStu.Fill(Leaveds);
                if (Leaveds.Tables[0].Rows.Count > 0)
                {
                    GridView1.Rows[i].Cells[6].Text = "Leave";
                }
                i++;
               

            }

        }

        protected void DayNamePanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DayNamePane.SelectedItem.Text == "Day")
            {
                Panel1.Visible = true;
                MonthNamePanel.Visible = false;
                Date.Visible = false;

            }
            else if (DayNamePane.SelectedItem.Text == "Month")
            {
                int i = 0;
                while (MonthName.Items.Count > 0)
                {
                    MonthName.Items.Clear();
                }
                Panel1.Visible = false;
                MonthNamePanel.Visible = true;
                Date.Visible = false;
                SqlDataAdapter SelectSemesterStartingTime = new SqlDataAdapter("Select SemesterDetailsN.SemesterStartingDate,SemesterDetailsN.SemesterEndingDate From SemesterDetailsN Inner Join StudentDetails On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId) Where StudentDetails.StudentId='" + StudentId + "'", con);
                DataSet SelSemStartEnd = new DataSet();
                SelectSemesterStartingTime.Fill(SelSemStartEnd);
                StartingDate = Convert.ToDateTime(SelSemStartEnd.Tables[0].Rows[0][0].ToString());
                EndingDate = Convert.ToDateTime(SelSemStartEnd.Tables[0].Rows[0][1].ToString());
                StartingMonthNo = StartingDate.Month;
                EndingMonthNo = EndingDate.Month;
                Response.Write(StartingMonthNo + " " + EndingMonthNo + " ");
                while (StartingMonthNo <= EndingMonthNo)
                {
                    Month = StartingDate.ToString("MMM");
                    MonthName.Items.Add(Month);
                    StartingDate = StartingDate.AddMonths(1);
                    StartingMonthNo++;
                }
                MonthName.Items.Insert(0, "Select...");
                Day = StartingDate.Day.ToString();

            }
            else if (DayNamePane.SelectedItem.Text == "Date")
            {
                Panel1.Visible = false;
                MonthNamePanel.Visible = false;
                Date.Visible = true;
            }
            Default();
        }
        protected void DayName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DayName.SelectedIndex > 0)
            {
                SqlDataAdapter SelectAllStudents = new SqlDataAdapter("Select  StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentAttendance.Day,StudentAttendance.Time,Convert(NVARCHAR(10),StudentAttendance.Date,103)As Date,StudentAttendance.AttendanceStatus,StudentAttendance.AttendanceStatus AS Fine,StudentAttendance.AttendanceId " +
    "From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
    " Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
    " Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
    "Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)" +
    " Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)" +
    "Where StudentDetails.StudentId='" + StudentId + "'AND SubjectDetails.SubjectName='" + SubjectName + "'AND StudentAttendance.Day='" + DayName.SelectedItem.Text + "' ", con);

                SelectAllStudents.Fill(SelectStudentsds);
                GridView1.DataSource = SelectStudentsds;
                GridView1.DataBind();
                CheckTotalFine();
                TotalLacAnfFine();

            }
        }

        protected void MonthName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            switch (MonthName.SelectedItem.Text)
            {
                case "Jan":
                    {
                        i = 1;
                        break;
                    }

                case "Feb":
                    {
                        i = 2;
                        break;
                    }

                case "Mar":
                    {
                        i = 3;
                        break;
                    }

                case "Apr":
                    {
                        i = 4;
                        break;
                    }

                case "May":
                    {
                        i = 5;
                        break;
                    }
                case "Jun":
                    {
                        i = 6;
                        break;
                    }
                case "Jul":
                    {
                        i = 7;
                        break;
                    }
                case "Aug":
                    {
                        i = 8;
                        break;
                    }
                case "Sep":
                    {
                        i = 9;
                        break;
                    }
                case "Oct":
                    {
                        i = 10;
                        break;
                    }
                case "Nov":
                    {
                        i = 11;
                        break;
                    }
                case "Dec":
                    {
                        i = 12;
                        break;
                    }

            }
            if (MonthName.SelectedIndex > 0)
            {
                SqlDataAdapter SelectAllStudents = new SqlDataAdapter("Select  StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentAttendance.Day,StudentAttendance.Time,Convert(NVARCHAR(10),StudentAttendance.Date,103) As Date,StudentAttendance.AttendanceStatus,StudentAttendance.AttendanceStatus AS Fine,StudentAttendance.AttendanceId " +
"From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
" Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
" Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
"Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)" +
" Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)" +
"Where StudentDetails.StudentId='" + StudentId + "'AND SubjectDetails.SubjectName='" + SubjectName + "'AND StudentAttendance.Month='" + MonthName.SelectedItem.Text + "' ", con);

                SelectAllStudents.Fill(SelectStudentsds);
                GridView1.DataSource = SelectStudentsds;
                GridView1.DataBind();
                CheckTotalFine();
                TotalLacAnfFine();

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[8].Visible = false;
        }
    }
}