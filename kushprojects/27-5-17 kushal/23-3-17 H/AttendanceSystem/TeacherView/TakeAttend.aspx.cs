using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace AttendanceSystem.TeacherView
{
    public partial class TakeAttend : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        DateTime CurrentTime = new DateTime();
        DateTime FirstTime = new DateTime();
        DateTime SecondTime = new DateTime();
        DateTime SelectedTime = new DateTime();
        public DataSet SSTUds = new DataSet();
       
        DataTable dt = new DataTable();
        public DataSet ds1 = new DataSet();

        string PrevTime,NextTime,Current,CurrentDate;
        public static string  CurrentDay,CurrentTime1;
        public static int StudentIdValue,SubjectIdValue,TeacherId;
        public  static int HeadCount1 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TeacherId"] != null)
                {
                    TeacherId = Convert.ToInt32(Session["TeacherId"]);
                    //Color wrong = ColorTranslator.FromHtml("#FFC3C3");
                    //Color right = ColorTranslator.FromHtml("#D0FCD0");
                    SqlDataAdapter CheckHoliday = new SqlDataAdapter("Select Event From HolidaysDetails Where HolidayDate=@SelectDate", con);
                    CheckHoliday.SelectCommand.Parameters.AddWithValue("@SelectDate", System.DateTime.Now.Date.ToString("MM/dd/yyyy"));
                    DataSet CheckHolids = new DataSet();
                    CheckHoliday.Fill(CheckHolids);
                    CurrentDate = System.DateTime.Today.Date.ToString("dd/MM/yyyy");
                    //CurrentDay = System.DateTime.Today.ToString("dddd");
                    CurrentDay = "Monday";
                    CurrentTime1 = "09:00:00 AM";
                    GridView2.Columns[0].HeaderText = "Attendance Status";


                    Button1_Click(Search, EventArgs.Empty);
                    int i = 0, j = 0;

                    while (i < GridView2.Rows.Count)
                    {
                        SqlDataAdapter SelectPresentStu = new SqlDataAdapter("Select SubjectAllocationNo From StudentAttendance Where Date='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "' AND Time='" + CurrentTime1 + "' AND SubjectAllocationNo='" + GridView2.Rows[i].Cells[1].Text + "' AND AttendanceStatus='1'", con);
                        DataSet ds13 = new DataSet();
                        SelectPresentStu.Fill(ds13);
                        if (ds13.Tables[0].Rows.Count > 0)
                        {
                            j = j + 1;
                            //GridView2.Rows[i].BackColor = right;
                            //GridView2.Rows[i].ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            //GridView2.Rows[i].BackColor = wrong;
                            //GridView2.Rows[i].ForeColor = System.Drawing.Color.White;
                        }
                        i++;
                    }
                    HeadCount1 = j;
                    HeadCount.Text = HeadCount1.ToString();
                }
            }
            else
            {
                
            }
          
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Color wrong = ColorTranslator.FromHtml("#FFC3C3");
            Color right = ColorTranslator.FromHtml("#D0FCD0");
            SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select TeacherTimeTable.Day,TeacherTimeTable.Time,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectName,SubjectDetails.SubjectId,TeacherDetails.TeacherId,TeacherDetails.TeacherName,TeacherTimeTable.RoomNo From SemesterDetailsN Inner Join SubjectDetails On SemesterDetailsN.SemesterId=SubjectDetails.Semesterid inner Join TeacherTimeTable On (SubjectDetails.SubjectId=TeacherTimeTable.SubjectId)inner join TeacherDetails On (TeacherTimeTable.Teacherid=TeacherDetails.TeacherId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)  Where TeacherDetails.TeacherId='701' AND TeacherTimeTable.Time='" + CurrentTime1.ToString().Trim() + "' AND  TeacherTimeTable.Day='" + CurrentDay.ToString().Trim() + "'", con);
            //SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select Teacherid From TeacherTimeTable Where Teacherid='" + TextBox1.Text + "' AND Day='" + CurrentDay + "' AND Time='" + CurrentTime1 + "' ", con);
            DataSet ds = new DataSet();
            SelectTimeTable.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Class1.Text = "<br>" + ds.Tables[0].Rows[0][2] + " " + ds.Tables[0].Rows[0][3];
                Sub.Text = "<br>" + ds.Tables[0].Rows[0][4];
                Date.Text = "<br>" + CurrentDate;
                Day.Text = "<br>" + CurrentDay;
                SubjectIdValue = Convert.ToInt32(ds.Tables[0].Rows[0][5]);
                // GridView2.DataSource = ds;
                // GridView2.DataBind();
                //Current = System.DateTime.Now.ToLongTimeString();
                CurrentTime = Convert.ToDateTime(Current);
                // Response.Write(CurrentTime);


                int i = 0;
                var value = 0;


                value = ds.Tables[0].Rows.Count;
                while (i < value)
                {
                    FirstTime = Convert.ToDateTime(ds.Tables[0].Rows[i][1].ToString());
                    if (i < value - 1)
                    {
                        SecondTime = Convert.ToDateTime(ds.Tables[0].Rows[i + 1][1]);
                        if (CurrentTime.TimeOfDay > FirstTime.TimeOfDay && CurrentTime.TimeOfDay < SecondTime.TimeOfDay)
                        {
                            SelectedTime = FirstTime;
                            // Response.Write("SelectedTime " + SelectedTime.TimeOfDay);
                        }


                    }
                    i++;
                }

                var TotalStudent = 0;
                BindWithGridView();

                if (SSTUds.Tables[0].Rows.Count > 0)
                {
                }


                int j = 0;

                DataSet SDRds = new DataSet();
                while (j < SSTUds.Tables[0].Rows.Count)
                {
                    //label1.Text = "TotalStu"+j+SSTUds.Tables[0].Rows[j][0];
                    SqlDataAdapter SelectDuplicateRow = new SqlDataAdapter("Select SubjectAllocationNo,AttendanceId,AttendanceStatus From StudentAttendance Where Date='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "' AND Time='" + CurrentTime1 + "' AND SubjectAllocationNo='" + SSTUds.Tables[0].Rows[j][0] + "'", con);

                    SelectDuplicateRow.Fill(SDRds);

                    var c = 0;
                    c = SDRds.Tables[0].Rows.Count;
                    if (SDRds.Tables[0].Rows.Count != 0)
                    {
                        //label1.Text = "If TotalStu" + j + SSTUds.Tables[0].Rows[j][0];
                        TotalLac(Convert.ToInt32(SSTUds.Tables[0].Rows[1][0]),0);


                    }
                    else
                    {
                        //label1.Text = "Else TotalStu" + j + SSTUds.Tables[0].Rows[j][0];
                        TotalLac(Convert.ToInt32(SSTUds.Tables[0].Rows[1][0]),1);
                        SqlDataAdapter InsertAttendance = new SqlDataAdapter("Insert Into StudentAttendance (SubjectAllocationNo,Date,Day,Time,AttendanceStatus,Month,LeaveRequest)Values('" + Convert.ToInt32(SSTUds.Tables[0].Rows[j][0]) + "','" + System.DateTime.Today.ToString("yyyy/MM/dd") + "','" + CurrentDay + "','" + CurrentTime1 + "','0','" + System.DateTime.Today.ToString("MMM") + "','0')", con);
                        DataSet IAds = new DataSet();
                        InsertAttendance.Fill(IAds);
                    }
                    j++;
                }

                SqlDataAdapter SelectLeaveStu = new SqlDataAdapter("Select LeaveTable.StudentId,SubAllByStu.SubjectAllocationNo  " +
               "From LeaveTable  Inner Join SubAllByStu On(LeaveTable.StudentId=SubAllByStu.StudentId)" +
                "Where  SubAllByStu.SubjectId='" + SubjectIdValue + "' AND LeaveTable.TeacherId='701'AND LeaveStatus='Accept' AND LeaveStartingDate<='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "'AND LeaveEndingDate>='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "'", con);
                DataSet ds1 = new DataSet();
                SelectLeaveStu.Fill(ds1);
                int n = 0;
                while (n < ds1.Tables[0].Rows.Count)
                {
                    SqlDataAdapter UpdateAttendance = new SqlDataAdapter("Update StudentAttendance Set LeaveRequest='1' Where SubjectAllocationNo='" + ds1.Tables[0].Rows[n][1] + "' AND Date='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "' AND Day='" + CurrentDay + "'AND Time='" + CurrentTime1 + "' ", con);
                    DataSet UpdateAttendds = new DataSet();
                    UpdateAttendance.Fill(UpdateAttendds);
                    n++;
                }

                GridView2.DataSource = SSTUds;
                GridView2.DataBind();



                int p = 0;
                //label1.Text = GridView2.Rows.Count.ToString();

                while (p < GridView2.Rows.Count)
                {

                    SqlDataAdapter SelectStuTotLac = new SqlDataAdapter("Select Count(StudentAttendance.AttendanceStatus) From StudentAttendance Where SubjectAllocationNo='" + GridView2.Rows[p].Cells[1].Text.ToString() + "' AND StudentAttendance.AttendanceStatus='1'", con);
                    SelectStuTotLac.SelectCommand.Parameters.AddWithValue("@AttendanceStatus", '1');
                    DataSet SelStuTo = new DataSet();
                    SelectStuTotLac.Fill(SelStuTo);

                    if (SelStuTo.Tables[0].Rows.Count > 0)
                    {
                       
                        if (SelStuTo.Tables[0].Rows.Count == 0)
                        {
                            if (Convert.ToInt32(SelStuTo.Tables[0].Rows[0][0]) == 0)
                            {
                                GridView2.Rows[p].Cells[5].Text = (0).ToString();

                            }
                            else
                            {
                                GridView2.Rows[p].Cells[5].Text = (1).ToString();
                            }
                        }
                        else
                        {
                            GridView2.Rows[p].Cells[5].Text = SelStuTo.Tables[0].Rows[0][0].ToString();
                        }

                    }
                   
                    if (SDRds.Tables[0].Rows.Count > 0)
                    {
                        bool Value1 = (bool)SDRds.Tables[0].Rows[p][2];
                        if (Value1 == true)
                        {
                            CheckBox c1 = (CheckBox)GridView2.Rows[p].Cells[0].FindControl("CheckBox2");
                            c1.Checked = true;
                            GridView2.Rows[p].BackColor = right;
                            GridView2.Rows[p].ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            GridView2.Rows[p].BackColor = wrong;
                            GridView2.Rows[p].ForeColor = System.Drawing.Color.White;
                        }
                    }

                    p++;
                }





            }

        }









        private void TotalLac(int SubjectAlNo,int value)
        {
            int SubjectTotallac;
            SqlDataAdapter ToLac = new SqlDataAdapter("Select Count(Date) From StudentAttendance Where SubjectAllocationNo='" + SubjectAlNo + "' ", con);
            DataSet ToLacds = new DataSet();
            ToLac.Fill(ToLacds);
            if (ToLacds.Tables[0].Rows.Count > 0)
            {
                if (value == 0)
                {
                    SubjectTotallac = Convert.ToInt32(ToLacds.Tables[0].Rows[0][0]);

                }
                else
                {
                    SubjectTotallac = Convert.ToInt32(ToLacds.Tables[0].Rows[0][0]);

                }
                TotalLactures.Text = SubjectTotallac.ToString();
            }

        }


        private void BindWithGridView()
        {
            int j = 0, TotalStu=0;
            try
            {
                //SqlDataAdapter SelectStudent = new SqlDataAdapter("Select StudentDetails.StudentId,StudentDetails.StudentName COUT(AttendanceStatus) From StudentDetails Inner Join SubAllByStu On(SubAllByStu.StudentId=StudentDetails.StudentId) Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo) Where SubAllByStu.SubjectId='"+SubjectIdValue+"' AND StudentAttendance.AttendanceStatus='1' ", con);
                SqlDataAdapter SelectStudent = new SqlDataAdapter("Select SubAllByStu.SubjectAllocationNo, StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentDetails.StudentId as AttendLactures  " +
    "From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
    " Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
    " Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
    "Where  SubAllByStu.SubjectId='" + SubjectIdValue + "'", con);
                //Search All STudents Whose Select the Subject
                SelectStudent.Fill(SSTUds);
                //label1.Text = "hhh" + SSTUds.Tables[0].Rows[8][0].ToString();





                TotalStu = SSTUds.Tables[0].Rows.Count;
                TotalStudents.Text = TotalStu.ToString();

            }
            catch (Exception err)
            {
                Error1.Text = "Search Student Whose" + err.Message;
            }
        }




        protected void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged1(object sender, EventArgs e)
        {
            
            Color wrong = ColorTranslator.FromHtml("#FFC3C3");
            Color right = ColorTranslator.FromHtml("#D0FCD0");
            //Checked And UnChecked Student Attendance
            int GridRowIndex, CheckBoxValue;
            try
            {
                GridViewRow row = (sender as CheckBox).Parent.Parent as GridViewRow;
                GridRowIndex = row.RowIndex;
                CheckBox cs = sender as CheckBox;
                int value2;
                if (cs.Checked == true)
                {
                    GridView2.Rows[GridRowIndex].BackColor = right;
                    GridView2.Rows[GridRowIndex].ForeColor = System.Drawing.Color.Black;
                    try
                    {
                        value2 = int.Parse(GridView2.Rows[GridRowIndex].Cells[5].Text);
                        value2 = value2 + 1;
                        GridView2.Rows[GridRowIndex].Cells[5].Text = value2.ToString();
                        HeadCount1 =HeadCount1+1;
                        HeadCount.Text = HeadCount1.ToString();
                       
                    }
                    catch (Exception err)
                    {
                        Error1.Text = "Error" + err.Message;
                    }
                    CheckBoxValue = 1;
                }
                else
                {
                    GridView2.Rows[GridRowIndex].BackColor =wrong;
                    GridView2.Rows[GridRowIndex].ForeColor = System.Drawing.Color.White;
                    value2 = int.Parse(GridView2.Rows[GridRowIndex].Cells[5].Text);
                    value2 = value2 - 1;
                    GridView2.Rows[GridRowIndex].Cells[5].Text = value2.ToString();
                    CheckBoxValue = 0;
                    HeadCount1=HeadCount1-1;
                    HeadCount.Text = HeadCount1.ToString();
                   
                    //.Rows[0].CssClass=
                }


               
               

                // BindWithGridView();
                BindWithGridView();
              
                SqlDataAdapter UpdateAttendance = new SqlDataAdapter("Update StudentAttendance Set AttendanceStatus='" + CheckBoxValue + "'Where SubjectAllocationNo='" + SSTUds.Tables[0].Rows[GridRowIndex][0] + "' AND Date='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "' AND Day='"+CurrentDay+"' AND Time='"+CurrentTime1+"'", con);
                DataSet UpdateAttendds = new DataSet();
                UpdateAttendance.Fill(UpdateAttendds);

            }
            catch (Exception err)
            {
                Response.Write("Checked Or UnChecked Student Attendance Portion" + err.Message);
            }

        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            SqlDataAdapter Delete = new SqlDataAdapter("Delete From StudentAttendance ", con);
            DataSet ds = new DataSet();
            Delete.Fill(ds);

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
            SqlDataAdapter SelectLeaveStu = new SqlDataAdapter("Select LeaveTable.StudentId   " +
"From LeaveTable  Inner Join SubAllByStu On(LeaveTable.StudentId=SubAllByStu.StudentId)" +
"Where  SubAllByStu.SubjectId='" + SubjectIdValue + "' AND LeaveTable.TeacherId='" + TeacherId + "'AND LeaveStatus='Accept' AND LeaveStartingDate<='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "'AND LeaveEndingDate>='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "'", con);
            DataSet ds1 = new DataSet();
            SelectLeaveStu.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                
            }
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                if (e.Row.Cells[2].Text == ds1.Tables[0].Rows[i][0].ToString())
                {
                    e.Row.BackColor = System.Drawing.Color.LightSkyBlue;
                    e.Row.ForeColor = System.Drawing.Color.White;
                    CheckBox c = (CheckBox)e.Row.Cells[0].FindControl("CheckBox2");
                    c.Enabled = false;



                    //

                }
                i++;
            }
            // e.Row.BackColor = System.Drawing.Color.Black;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["TeacherId"] = TextBox1.Text;
            Response.Redirect("~/TeacherView/SearchAttendance.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = System.DateTime.Now.ToLongTimeString();
        }

        protected void Leave_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TeacherView/CheckLeaveDetails.aspx");
        }

        protected void c_Click(object sender, EventArgs e)
        {
            Label4.Text = System.DateTime.Now.ToLongTimeString();
        }


    }
}