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
    public partial class SearchAttendance : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static string TeacherIdValue;
        DataSet ds1 = new DataSet();
        public static string SubjectNameValue;
        public static int CourseNameSelectedInd;
        public static float TotalLac = 0, AttendLac = 0;
         public DataSet SelectStudentsds = new DataSet();
         public static  int TeacherId,FinePerDay;
        public  static  DataSet ds2 = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = 0,j=0;
           
            if (!IsPostBack)
            {
               
                TeacherId = Convert.ToInt32(Session["TeacherId"]);
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
        protected void SearchBSId_Click(object sender, EventArgs e)
        {
          
                SqlDataAdapter SelectCourse = new SqlDataAdapter("Select SubjectDetails.SubjectName,SemesterDetailsN.SemesterNo,CourseDetails.CourseName From SubjectDetails " +
                      "Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId) " +
                      "Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Where SubjectDetails.SubjectName='" + SubjectNameValue + "'", con);
               
            DataSet ds1 = new DataSet();
            SelectCourse.Fill(ds1);

//    
            SqlDataAdapter SelectAllStudents = new SqlDataAdapter("Select  StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,Count(StudentAttendance.AttendanceStatus) as TotalLactures,Count(StudentAttendance.AttendanceStatus) as AttendLactures,Count(StudentAttendance.AttendanceStatus) as Appsent_Days,Count(StudentAttendance.AttendanceStatus) as Leave_Days,Count(StudentAttendance.AttendanceStatus) as TotalFine,Count(StudentAttendance.AttendanceStatus) as Total_Percentage  " +
"From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
" Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
" Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
"Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)" +
" Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)   " +
"Where CourseDetails.CourseName='" + ds2.Tables[0].Rows[CourseNameSelectedInd][0].ToString() + "'AND SemesterDetailsN.SemesterNo='" + ds2.Tables[0].Rows[CourseNameSelectedInd][1].ToString() + "'AND StudentAttendance.AttendanceStatus='1' AND StudentDetails.StudentId='"+StudentId.Text+"'" +
"Group By StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentAttendance.AttendanceStatus", con);
          
            SelectAllStudents.Fill(SelectStudentsds);
           
                GridView1.DataSource = SelectStudentsds;
                GridView1.DataBind();
                if (SelectStudentsds.Tables[0].Rows.Count > 0)
                {
                CheckTotalLac();
                CheckTotalFine();
                CheckTotalLeaveDays();
                CheckTotalAppsent();
                CheckTotalPesentage();


            }
        }

        protected void SubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SubjectNameValue = SubjectName.SelectedItem.Text;

            SqlDataAdapter SelectAllStudents = new SqlDataAdapter("Select  StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,Count(StudentAttendance.AttendanceStatus) as TotalLactures ,Count(StudentAttendance.AttendanceStatus) as AttendLactures,Count(StudentAttendance.AttendanceStatus) as Appsent_Days ,Count(StudentAttendance.AttendanceStatus) as Leave_Days,Count(StudentAttendance.AttendanceStatus) as TotalFine,Count(StudentAttendance.AttendanceStatus) as Total_Percentage  " +
                "From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
                " Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
                " Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
                "Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)" +
                " Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)   " +
                "Where SubjectDetails.SubjectName='" + SubjectName.SelectedItem.Text + "'AND StudentAttendance.AttendanceStatus='1'" +
                "Group By StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentAttendance.AttendanceStatus", con);


            SelectAllStudents.Fill(SelectStudentsds);
           
                GridView1.DataSource = SelectStudentsds;
                GridView1.DataBind();
                if (SelectStudentsds.Tables[0].Rows.Count > 0)
                {
                CheckTotalLac();
                CheckTotalFine();
                CheckTotalLeaveDays();
                CheckTotalAppsent();
                CheckTotalPesentage();
            }
            int i = 0;
           
           /* CourseName.DataSource = ds1;
            CourseName.DataTextField = "CourseName";
            CourseName.DataValueField = "CourseName";
            CourseName.DataBind();*/
           
           
        }

        private void CheckTotalPesentage()
        {
            int i = 0;
            float percentage=0;
            while(i<GridView1.Rows.Count)
            {
                TotalLac=Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
                AttendLac = Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);
                percentage = (float)(AttendLac / TotalLac) * 100;
                GridView1.Rows[i].Cells[9].Text = ((int)percentage).ToString() + "%";
                i++;
            }
            

           
        }

        private void CheckTotalLeaveDays()
        {
            int j=0,TotalLeaveDays;
            if (SelectStudentsds.Tables[0].Rows.Count > 0)
            {
                while (j < SelectStudentsds.Tables[0].Rows.Count)
                {
                    SqlDataAdapter TotalLeave = new SqlDataAdapter("Select Count(LeaveRequest) From StudentAttendance Inner Join SubAllByStu On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)Where SubAllByStu.StudentId='" + SelectStudentsds.Tables[0].Rows[j][0] + "' AND StudentAttendance.LeaveRequest='1'", con);
                    DataSet TotalLeaveds = new DataSet();
                    TotalLeave.Fill(TotalLeaveds);
                    
                    if (TotalLeaveds.Tables[0].Rows.Count > 0)
                    {

                        TotalLeaveDays = Convert.ToInt32(TotalLeaveds.Tables[0].Rows[0][0]);
                            GridView1.Rows[j].Cells[7].Text = TotalLeaveDays.ToString();
                     }
                        j++;
                    }

                }
            }
        

        private void CheckTotalFine()
        {
            int i=0,TotalFineDetails;
            SqlDataAdapter PerDayFineCharge = new SqlDataAdapter("Select FinePerDay From FineDetails  Inner Join StudentDetails On (StudentDetails.SemesterId=FineDetails.SemesterId)Where StudentDetails.StudentId='" +GridView1.Rows[0].Cells[1].Text+ "'", con);
            DataSet ds2 = new DataSet();
            PerDayFineCharge.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                FinePerDay = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
            }
            if (SelectStudentsds.Tables[0].Rows.Count > 0)
            {
                while (i < SelectStudentsds.Tables[0].Rows.Count)
                {
                    SqlDataAdapter TotalFine = new SqlDataAdapter("Select Count(Date) From StudentAttendance Inner Join SubAllByStu On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)Where SubAllByStu.StudentId='" + SelectStudentsds.Tables[0].Rows[i][0] + "' AND StudentAttendance.AttendanceStatus='0' AND StudentAttendance.LeaveRequest='0' ", con);
                    DataSet ToFineds = new DataSet();
                    TotalFine.Fill(ToFineds);
                    TotalFineDetails = Convert.ToInt32(ToFineds.Tables[0].Rows[0][0]);
                    TotalFineDetails = TotalFineDetails * FinePerDay;
                    if (ToFineds.Tables[0].Rows.Count > 0)
                    {

                        GridView1.Rows[i].Cells[8].Text = (TotalFineDetails).ToString();
                    }
                    i++;
                }
            }
        }

        private void CheckTotalLac()
        {
            int i=0;
            if (SelectStudentsds.Tables[0].Rows.Count > 0)
            {
                while (i < SelectStudentsds.Tables[0].Rows.Count)
                {
                    SqlDataAdapter ToLac = new SqlDataAdapter("Select Count(StudentAttendance.Date) From StudentAttendance Inner Join SubAllByStu On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)Where SubAllByStu.StudentId='" + Convert.ToInt32(SelectStudentsds.Tables[0].Rows[0][0]) + "' ", con);
                    DataSet ToLacds = new DataSet();
                    ToLac.Fill(ToLacds);
                    if (ToLacds.Tables[0].Rows.Count > 0)
                    {
                        GridView1.Rows[i].Cells[4].Text = ToLacds.Tables[0].Rows[0][0].ToString();
                    }
                    i++;
                }
            }
        }

        protected void CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            
        }

        protected void CourseName_SelectedIndexChanged1(object sender, EventArgs e)
        {
             CourseNameSelectedInd = CourseName.SelectedIndex - 1;
           
            BindCourse();
            if(ds2.Tables[0].Rows.Count>0)
            {
                l.Text = ds2.Tables[0].Rows[0][0].ToString();
            }
            if (CourseNameSelectedInd >= 0)
            {

                SqlDataAdapter SelectAllStudents = new SqlDataAdapter("Select  StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,Count(StudentAttendance.AttendanceStatus) as TotalLactures,Count(StudentAttendance.AttendanceStatus) as AttendLactures ,Count(StudentAttendance.AttendanceStatus) as Appsent_Days,Count(StudentAttendance.AttendanceStatus) as Leave_Days,Count(StudentAttendance.AttendanceStatus) as TotalFine,Count(StudentAttendance.AttendanceStatus) as Total_Percentage " +
       "From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
       " Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
       " Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
       "Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)" +
       " Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)   " +
       "Where CourseDetails.CourseName='" + ds2.Tables[0].Rows[CourseNameSelectedInd][0].ToString() + "'AND SemesterDetailsN.SemesterNo='" + ds2.Tables[0].Rows[CourseNameSelectedInd][1].ToString() + "'AND StudentAttendance.AttendanceStatus='1'" +
       "Group By StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentAttendance.AttendanceStatus", con);

                SelectAllStudents.Fill(SelectStudentsds);
               
                    GridView1.DataSource = SelectStudentsds;
                    GridView1.DataBind();
                    if (SelectStudentsds.Tables[0].Rows.Count > 0)
                    {
                    CheckTotalLac();
                    CheckTotalAppsent();
                    CheckTotalFine();
                    CheckTotalLeaveDays();
                    CheckTotalPesentage();
                }

                SqlDataAdapter SelCourseName = new SqlDataAdapter("Select Distinct SubjectDetails.SubjectName From CourseDetails Inner Join SemesterDetailsN On(CourseDetails.CourseId=SemesterDetailsN.CourseId)Inner Join SubjectDetails On(SemesterDetailsN.SemesterId=SubjectDetails.SemesterId) Inner Join TeacherTimeTable On(SubjectDetails.SubjectId=TeacherTimeTable.SubjectId) Where TeacherTimeTable.TeacherId='" + TeacherId + "'", con);
                DataSet ds3 = new DataSet();
                SelCourseName.Fill(ds3);
              
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    SubjectName.DataSource = ds3;
                    SubjectName.DataTextField = "SubjectName";
                    SubjectName.DataValueField = "SubjectName";
                    SubjectName.DataBind();
                    SubjectName.Items.Insert(0,"Select Subject...");
                }
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

        protected void SearchByName_Click(object sender, EventArgs e)
        {
            SqlDataAdapter SelectCourse = new SqlDataAdapter("Select SubjectDetails.SubjectName,SemesterDetailsN.SemesterNo,CourseDetails.CourseName From SubjectDetails " +
                   "Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId) " +
                   "Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Where SubjectDetails.SubjectName='" + SubjectNameValue + "'", con);
            DataSet ds1 = new DataSet();
            SelectCourse.Fill(ds1);

            SqlDataAdapter SelectAllStudents = new SqlDataAdapter("Select  StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,Count(StudentAttendance.AttendanceStatus) as TotalLactures,Count(StudentAttendance.AttendanceStatus) as AttendLactures,Count(StudentAttendance.AttendanceStatus) as Appsent_Days,Count(StudentAttendance.AttendanceStatus) as Leave_Days,Count(StudentAttendance.AttendanceStatus) as TotalFine,Count(StudentAttendance.AttendanceStatus) as Total_Percentage  " +
"From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
" Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
" Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
"Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)" +
" Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)   " +
"Where CourseDetails.CourseName='" + ds1.Tables[0].Rows[CourseNameSelectedInd][2].ToString() + "'AND SemesterDetailsN.SemesterNo='" + ds1.Tables[0].Rows[CourseNameSelectedInd][1].ToString() + "'AND StudentAttendance.AttendanceStatus='1' AND SubjectDetails.SubjectName='" + SubjectNameValue + "'AND StudentDetails.StudentName='" + StudentName.Text + "' " +
"Group By StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentAttendance.AttendanceStatus", con);
          
            SelectAllStudents.Fill(SelectStudentsds);
           
                GridView1.DataSource = SelectStudentsds;
                GridView1.DataBind();
                if (SelectStudentsds.Tables[0].Rows.Count > 0)
                {
                CheckTotalLac();
                CheckTotalFine();
                CheckTotalLeaveDays();
                CheckTotalAppsent();
                CheckTotalPesentage();
            }
        }

        private void CheckTotalAppsent()
        {
            int i = 0;
            if (SelectStudentsds.Tables[0].Rows.Count > 0)
            {
                while (i < SelectStudentsds.Tables[0].Rows.Count)
                {
                    SqlDataAdapter ToAppLac = new SqlDataAdapter("Select Count(StudentAttendance.AttendanceStatus) From StudentAttendance Inner Join SubAllByStu On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)Where SubAllByStu.StudentId='" + Convert.ToInt32(SelectStudentsds.Tables[0].Rows[i][0]) + "' AND StudentAttendance.AttendanceStatus='0' AND LeaveRequest='0' ", con);
                    DataSet ToAppLacds = new DataSet();
                    ToAppLac.Fill(ToAppLacds);
                    if (ToAppLacds.Tables[0].Rows.Count > 0)
                    {
                        GridView1.Rows[i].Cells[6].Text = ToAppLacds.Tables[0].Rows[0][0].ToString();
                    }
                    i++;
                }
            }
        }

        
        }
}
    