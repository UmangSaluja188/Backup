using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace AttendanceSystem.TeacherView
{
    public partial class EditAttendanceNew : System.Web.UI.Page
    { 
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static string TeacherIdValue;
        DataSet ds1 = new DataSet();
        public static string SubjectNameValue;
        public static int CourseNameSelectedInd,SubjectIdValue;
        public static float TotalLac = 0, AttendLac = 0;
         public DataSet SelectStudentsds = new DataSet();
         public static  int TeacherId,FinePerDay;
        public  static  DataSet ds2 = new DataSet();
       public DataSet SSTUds = new DataSet();
       Color wrong = ColorTranslator.FromHtml("#FFC3C3");
       Color right = ColorTranslator.FromHtml("#D0FCD0");
      
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = 0;
           
            if (!IsPostBack)
            {

                CourseName.Items.Clear();
                int min1, min2, hours1, hours2, totalmin1, totalLacture, subtracthours, subtractmin, lacmin, lachours, totallacmin;
                SqlDataAdapter SelectCollegeTiming = new SqlDataAdapter("Select * From CollegeTiming", con);
                DataSet SCTds = new DataSet();
                SelectCollegeTiming.Fill(SCTds);
                string StartingTime, CloseingTime, periodDuration;
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
                TimePeriod.Items.Insert(0, "Select Time...");
                for (int j = 1; j <= totalLacture; j++)
                {
                    TimePeriod.Items.Add(Open.AddMinutes(a).ToString("hh:mm:ss tt"));

                    a = a + totallacmin;


                }
                TeacherId = Convert.ToInt32(Session["TeacherId"]);
                CourseName.Items.Clear();
                BindCourse();
                CourseName.Items.Insert(0, "Select Course...");
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    while (i < ds2.Tables[0].Rows.Count)
                    {
                        CourseName.Items.Add(ds2.Tables[0].Rows[i][0] + "  " + ds2.Tables[0].Rows[i][1]);
                        i++;
                    }

                }

                // TeacherIdValue = Session["TeacherId"].ToString();

                SubjectName.Items.Insert(0, "Select Subject...");




            }
        }

        private void SearchSubject()
        {

        }

        private void BindCourse()
        {
            SqlDataAdapter SelCourseName = new SqlDataAdapter("Select Distinct CourseDetails.CourseName,SemesterDetailsN.SemesterNo From CourseDetails Inner Join SemesterDetailsN On(CourseDetails.CourseId=SemesterDetailsN.CourseId)Inner Join SubjectDetails On(SemesterDetailsN.SemesterId=SubjectDetails.SemesterId) Inner Join TeacherTimeTable On(SubjectDetails.SubjectId=TeacherTimeTable.SubjectId) Where TeacherTimeTable.TeacherId='" + TeacherId + "'", con);

            SelCourseName.Fill(ds2);
        }

        /* protected void Filter_SelectedIndexChanged(object sender, EventArgs e)
         {
             Response.Write("Hello");
             //Select Oprtion Filter By Student Id
 /*          else if(Filter.SelectedItem.Text=="Course Name")
             {
               
             }
        
             }*/

        protected void SelectSubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter SelCourseName = new SqlDataAdapter("Select Distinct SubjectDetails.SubjectName,SubjectDetails.SubjectId From CourseDetails Inner Join SemesterDetailsN On(CourseDetails.CourseId=SemesterDetailsN.CourseId)Inner Join SubjectDetails On(SemesterDetailsN.SemesterId=SubjectDetails.SemesterId) Inner Join TeacherTimeTable On(SubjectDetails.SubjectId=TeacherTimeTable.SubjectId) Where TeacherTimeTable.TeacherId='" + TeacherId + "'", con);
            DataSet ds3 = new DataSet();
            SelCourseName.Fill(ds3);

            if (ds3.Tables[0].Rows.Count > 0)
            {
                SubjectName.DataSource = ds3;
                SubjectName.DataTextField = "SubjectName";
                SubjectName.DataValueField = "SubjectId";
                SubjectName.DataBind();
                SubjectName.Items.Insert(0, "Select Subject...");

            }
            SubjectName.SelectedIndex = 0;
            Date.Text = "";
            TimePeriod.SelectedIndex = 0;
            FilterBy.Enabled = false;
           
        }

      
        protected void SearchBSId_Click(object sender, EventArgs e)
        {
            SelectStudentAttendance(3);
        }

        protected void SearchByName_Click(object sender, EventArgs e)
        {
            SelectStudentAttendance(4);
        }

        protected void SubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {

         
            Date.Text = "";
            TimePeriod.SelectedIndex = 0;
            FilterBy.Enabled = false;
            SelectStudentAttendance(0);
           
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
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
                       

                    }
                    catch (Exception err)
                    {
                       
                    }
                    CheckBoxValue = 1;
                }
                else
                {
                    GridView2.Rows[GridRowIndex].BackColor = wrong;
                    GridView2.Rows[GridRowIndex].ForeColor = System.Drawing.Color.White;
                    value2 = int.Parse(GridView2.Rows[GridRowIndex].Cells[5].Text);
                    value2 = value2 - 1;
                    GridView2.Rows[GridRowIndex].Cells[5].Text = value2.ToString();
                    CheckBoxValue = 0;


                    //.Rows[0].CssClass=
                }





                // BindWithGridView();


                SqlDataAdapter UpdateAttendance = new SqlDataAdapter("Update StudentAttendance Set AttendanceStatus='" + CheckBoxValue + "'Where SubjectAllocationNo='" + GridView2.Rows[GridRowIndex].Cells[1].Text + "' AND Date='" + Date.Text+ "' AND Time='" + TimePeriod.SelectedItem.Text + "'", con);
                DataSet UpdateAttendds = new DataSet();
                UpdateAttendance.Fill(UpdateAttendds);

                
            }
            catch (Exception err)
            {
                Response.Write("Checked Or UnChecked Student Attendance Portion" + err.Message);
            }
           
        }

        protected void Time_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectStudentAttendance(2);
            FilterBy.Enabled = true;
        }

        private void SelectStudentAttendance(int value)
        {
            int p = 0;
         
            SubjectIdValue = Convert.ToInt32(SubjectName.SelectedValue);
            if (value == 0)
            {
                SqlDataAdapter SelectStudent = new SqlDataAdapter("Select SubAllByStu.SubjectAllocationNo, StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentDetails.StudentId as AttendLactures,StudentAttendance.AttendanceStatus,Convert(Nvarchar(50),StudentAttendance.Date,103)as Date  " +
    "From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
    "Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)"+
    " Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
    " Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
    "Where  SubAllByStu.SubjectId='" + SubjectIdValue + "'", con);
                SelectStudent.Fill(SSTUds);
            }
            else if (value == 1)
            {
                SqlDataAdapter SelectStudent = new SqlDataAdapter("Select SubAllByStu.SubjectAllocationNo, StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentDetails.StudentId as AttendLactures,StudentAttendance.AttendanceStatus,Convert(Nvarchar(50),StudentAttendance.Date,103)as Date  " +
    "From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
    "Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)" +
    " Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
    " Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
    "Where  SubAllByStu.SubjectId='" + SubjectIdValue + "' AND StudentAttendance.Date='"+Date.Text+"'", con);
                SelectStudent.Fill(SSTUds);
            }
            else if (value == 2)
            {
                SqlDataAdapter SelectStudent = new SqlDataAdapter("Select SubAllByStu.SubjectAllocationNo, StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentDetails.StudentId as AttendLactures ,StudentAttendance.AttendanceStatus,Convert(Nvarchar(50),StudentAttendance.Date,103)as Date  " +
    "From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
     "Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)" +
    " Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
    " Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
    "Where  SubAllByStu.SubjectId='" + SubjectIdValue + "' AND StudentAttendance.Date='"+Date.Text+"' AND StudentAttendance.Time='"+TimePeriod.SelectedItem.Text+"'", con);
                SelectStudent.Fill(SSTUds);
            }
            else if (value == 3)
            {
                SqlDataAdapter SelectStudent = new SqlDataAdapter("Select SubAllByStu.SubjectAllocationNo, StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentDetails.StudentId as AttendLactures ,StudentAttendance.AttendanceStatus,Convert(Nvarchar(50),StudentAttendance.Date,103)as Date  " +
    "From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
     "Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)" +
    " Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
    " Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
    "Where  SubAllByStu.SubjectId='" + SubjectIdValue + "' AND StudentAttendance.Date='" + Date.Text + "' AND StudentAttendance.Time='" + TimePeriod.SelectedItem.Text + "' AND StudentDetails.StudentId='"+StudentId.Text+"'", con);
                SelectStudent.Fill(SSTUds);
            }
            else if (value == 4)
            {
                SqlDataAdapter SelectStudent = new SqlDataAdapter("Select SubAllByStu.SubjectAllocationNo, StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentDetails.StudentId as AttendLactures ,StudentAttendance.AttendanceStatus,Convert(Nvarchar(50),StudentAttendance.Date,103)as Date  " +
    "From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
     "Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)" +
    " Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
    " Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
    "Where  SubAllByStu.SubjectId='" + SubjectIdValue + "' AND StudentAttendance.Date='" + Date.Text + "' AND StudentAttendance.Time='" + TimePeriod.SelectedItem.Text + "' AND StudentDetails.StudentName='"+StudentName.Text+"'", con);
                SelectStudent.Fill(SSTUds);
            }
            //Search All STudents Whose Select the Subject
            
            GridView2.DataSource = SSTUds;
            GridView2.DataBind();

            

            if (SSTUds.Tables[0].Rows.Count > 0)
            {
                while (p < SSTUds.Tables[0].Rows.Count)
                {
                    bool Value1 = (bool)SSTUds.Tables[0].Rows[p][5];
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
                    p++;
                }
            }
            p = 0;
            while (p < GridView2.Rows.Count)
            {
                SqlDataAdapter SelectStuTotLac = new SqlDataAdapter("Select Count(StudentAttendance.AttendanceStatus) From StudentAttendance Where SubjectAllocationNo='" + GridView2.Rows[p].Cells[1].Text.ToString() + "' AND StudentAttendance.AttendanceStatus='1'", con);
                SelectStuTotLac.SelectCommand.Parameters.AddWithValue("@AttendanceStatus", '1');
                DataSet SelStuTo = new DataSet();
                SelectStuTotLac.Fill(SelStuTo);

                if (SelStuTo.Tables[0].Rows.Count > 0)
                {
                    Response.Write(SelStuTo.Tables[0].Rows.Count);
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
                p++;
            }
          
        }

        protected void FilterBy_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (FilterBy.SelectedItem.Text == "Student Id")
            {
                StudentIdPanel.Visible = true;
                StudentNamePanel.Visible = false;
            }
            else if (FilterBy.SelectedItem.Text == "Student Name")
            {
                StudentNamePanel.Visible = true;
                StudentIdPanel.Visible = false;

            }
        }

        protected void Date_TextChanged(object sender, EventArgs e)
        {
            TimePeriod.SelectedIndex = 0;
            FilterBy.Enabled = false;
            SelectStudentAttendance(1);
        }

        protected void GridView2_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[6].Visible = false;
            }
            catch (Exception err)
            {

            }

        }

        protected void FilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilterBy.SelectedItem.Text == "Student Id")
            {
                StudentIdPanel.Visible = true;
                StudentNamePanel.Visible = false;
            }
            else if (FilterBy.SelectedItem.Text == "Student Name")
            {
                StudentNamePanel.Visible = true;
                StudentIdPanel.Visible = false;

            }
        }
    }
}