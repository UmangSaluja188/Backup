using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace AttendanceSystem.Admin_View
{
    public partial class CheckAttendance : System.Web.UI.Page
    {
        public static int CourseIdValue = 0, SemesterIdValue = 0, Value = 0, SemesterNoValue = 0;
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public DataSet SearchSubjectds = new DataSet();
        public DataSet SelectStudentsds = new DataSet();
        public static int TotalAttendanceV, TotallactureV, TotalAppsentV, StudentId1, FinePerDay;
        public int TotalStudentFine = 0, FineCharge = 5;
        public static float TotalLac, AttendLac;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SqlDataAdapter SelDep = new SqlDataAdapter("Select NDepartmentName,NDepartmentId From NewDepartmentDetails", con);
                DataSet ds = new DataSet();
                SelDep.Fill(ds);
                Department.DataSource = ds;
                Department.DataTextField = "NDepartmentName";
                Department.DataValueField = "NDepartmentId";
                Department.DataBind();
                Department.Items.Insert(0, "Select Department...");
               
            }
        }

        protected void FilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (FilterBy.SelectedItem.Text == "Student Id")
            //{
            //    StudentIdPanel.Visible = true;
            //    StudentNamePanel.Visible = false;
            //}
            //else if (FilterBy.SelectedItem.Text == "Student Name")
            //{
            //    StudentNamePanel.Visible = true;
            //    StudentIdPanel.Visible = false;

            //}

        }
        
           

        

        protected void Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter SelectCourseName = new SqlDataAdapter("Select  CourseName,CourseId From CourseDetails Where NDepartmentId='"+Department.SelectedValue+"'", con);
            DataSet SCNds = new DataSet();
            SelectCourseName.Fill(SCNds);
            CourseName.DataSource = SCNds.Tables[0];
            CourseName.DataTextField = "CourseName";
            CourseName.DataValueField = "CourseId";
            CourseName.DataBind();
            CourseName.Items.Insert(0, "Select..");
          
           
            
            SemesterNo.Enabled = false;
            Subject.Enabled = false;

          
        }

        protected void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select SemesterNo,SemesterId From SemesterDetailsN Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Where CourseName='" + CourseName.SelectedItem.Text + "'", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            //SemesterIdValue = Convert.ToInt32(ds2.Tables[0].Rows[0]["SemesterId"]);
            SemesterNo.DataSource = ds2.Tables[0];
            SemesterNo.DataTextField = "SemesterNo";
            SemesterNo.DataValueField = "SemesterId";
            SemesterNo.DataBind();
           
            SemesterNo.Items.Insert(0, "Select Semester...");
            SemesterNo.Enabled = true;
            Subject.Enabled = false;
            

            SqlDataAdapter SearchStudentDetails = new SqlDataAdapter("Select SubAllByStu.StudentId,SubjectDetails.SubjectId,SubjectDetails.SubjectName,SubjectDetails.SubjectId As TotalLactures, SubjectDetails.SubjectId As LeaveDays, SubjectDetails.SubjectId As AttendLactures,SubjectDetails.SubjectId As Appsent_Lactures, SubjectDetails.SubjectId As Fine,SubjectDetails.SubjectId As Total_Percentage From SubjectDetails Inner Join SubAllByStu On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)Inner join SemesterDetailsN On(SemesterDetailsN.SemesterId=SubjectDetails.SemesterId) Inner Join CourseDetails On(CourseDetails.CourseId=SemesterDetailsN.CourseId) Where CourseDetails.CourseId='" + CourseName.SelectedValue + "'", con);
           
            SearchStudentDetails.Fill(SelectStudentsds);
            GridView1.DataSource = SelectStudentsds;
            GridView1.DataBind();
            if (SelectStudentsds.Tables[0].Rows.Count > 0)
            {
                CheckTotalLac(0);
                TotalAttendance(1);

                CheckLeaveDays(0);
                CheckTotalAppsent(0);
                TotalFine(0);
                TotalPercentage(0);
            }
             
        }

        protected void SemesterNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject();

            Response.Write(SemesterNo.SelectedValue);
            if (SearchSubjectds.Tables[0].Rows.Count > 0)
            {
               
                Subject.DataSource = SearchSubjectds;
                Subject.DataTextField = "SubjectName";
                Subject.DataValueField = "SubjectId";
                Subject.DataBind();
                Subject.Items.Insert(0, "Select Subject...");
                Subject.Enabled = true;    
                
            }
            SqlDataAdapter SearchStudentDetails = new SqlDataAdapter("Select SubAllByStu.StudentId,SubjectDetails.SubjectId,SubjectDetails.SubjectName,SubjectDetails.SubjectId As TotalLactures, SubjectDetails.SubjectId As LeaveDays, SubjectDetails.SubjectId As AttendLactures,SubjectDetails.SubjectId As Appsent_Lactures, SubjectDetails.SubjectId As Fine,SubjectDetails.SubjectId As Total_Percentage From SubjectDetails Inner Join SubAllByStu On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)Inner join SemesterDetailsN On(SemesterDetailsN.SemesterId=SubjectDetails.SemesterId) Inner Join CourseDetails On(CourseDetails.CourseId=SemesterDetailsN.CourseId) Where SemesterDetailsN.SemesterId='"+SemesterNo.SelectedValue+"'", con);

            SearchStudentDetails.Fill(SelectStudentsds);
            GridView1.DataSource = SelectStudentsds;
            GridView1.DataBind();
            if (SelectStudentsds.Tables[0].Rows.Count > 0)
            {
                CheckTotalLac(0);
                TotalAttendance(1);

                CheckLeaveDays(0);
                CheckTotalAppsent(0);
                TotalFine(0);
                TotalPercentage(0);
            }
        }

        private void TotalPercentage( int value)
        {
            float percentage = 0;
            int i = 0;
            if (value == 0)
            {


                while (i < GridView1.Rows.Count)
                {
                    TotalLac = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
                    AttendLac = Convert.ToInt32(GridView1.Rows[i].Cells[6].Text);
                    percentage = (float)(AttendLac / TotalLac) * 100;


                    if (percentage > 0)
                    {
                        GridView1.Rows[i].Cells[9].Text = ((int)percentage).ToString() + "%";
                       
                    }
                    else
                    {
                        GridView1.Rows[i].Cells[9].Text = (0).ToString() + "%";

                    }
   i++;
                }

            }
            else
            {
                TotalLac = Convert.ToInt32(GridView1.Rows[0].Cells[4].Text);
                AttendLac = Convert.ToInt32(GridView1.Rows[0].Cells[6].Text);
                percentage = (float)(AttendLac / TotalLac) * 100;
                

                if (percentage > 0)
                {
                    GridView1.Rows[0].Cells[9].Text = ((int)percentage).ToString() + "%";
                 

                }
                else
                {
                    GridView1.Rows[0].Cells[9].Text = (0).ToString() + "%";
                }

              

            }

        }
        private void CheckLeaveDays(int value)
        {
            if (value == 0)
            {
                int i = 0;
                while (i < GridView1.Rows.Count)
                {
                    SqlDataAdapter SelectTotalLeave = new SqlDataAdapter("Select Count(StudentAttendance.LeaveRequest) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubjectDetails.SubjectId='" + GridView1.Rows[i].Cells[2].Text+ "'And SubAllByStu.StudentId='" + GridView1.Rows[i].Cells[1].Text + "' And StudentAttendance.LeaveRequest='1'", con);
                    DataSet SelectTotalLeaveds = new DataSet();
                    SelectTotalLeave.Fill(SelectTotalLeaveds);
                    if (SelectTotalLeaveds.Tables[0].Rows.Count > 0)
                    {
                        GridView1.Rows[i].Cells[5].Text = SelectTotalLeaveds.Tables[0].Rows[0][0].ToString();
                    }
                    i++;
                }
            }
        //    else
        //    {
        //        SqlDataAdapter SelectTotalLeave = new SqlDataAdapter("Select Count(StudentAttendance.LeaveRequest) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubAllByStu.StudentId='" + StudentId1 + "' And StudentAttendance.LeaveRequest='1'  And SubjectDetails.SubjectName='" + SubjectName.SelectedItem.Text + "'", con);
        //        DataSet SelectTotalLeaveds = new DataSet();
        //        SelectTotalLeave.Fill(SelectTotalLeaveds);
        //        if (SelectTotalLeaveds.Tables[0].Rows.Count > 0)
        //        {
        //            GridView1.Rows[0].Cells[5].Text = SelectTotalLeaveds.Tables[0].Rows[0][0].ToString();
        //        }
        //    }
        }

        //private void BindSubject()
        //{
        //    SqlDataAdapter SearchSubject = new SqlDataAdapter("Select SubjectDetails.SubjectId,SubjectDetails.SubjectName From SubjectDetails Inner Join SubAllByStu On(SubAllByStu.SubjectId=SubjectDetails.SubjectId) Where  SubAllByStu.StudentId='" + StudentId1 + "'", con);

        //    SearchSubject.Fill(SearchSubjectds);

        //}

        private void TotalFine(int value)
        {
            SqlDataAdapter PerDayFineCharge = new SqlDataAdapter("Select FinePerDay From FineDetails  Inner Join StudentDetails On (StudentDetails.SemesterId=FineDetails.SemesterId)Where StudentDetails.StudentId='" +GridView1.Rows[0].Cells[1].Text+ "'", con);
            DataSet ds2 = new DataSet();
            PerDayFineCharge.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                FinePerDay = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
            }
            if (value == 0)
            {
                int i = 0;

                while (i < GridView1.Rows.Count)
                {
                    TotalAppsentV = Convert.ToInt32(GridView1.Rows[i].Cells[7].Text);

                    TotalStudentFine = TotalAppsentV * FinePerDay;
                    GridView1.Rows[i].Cells[8].Text = TotalStudentFine.ToString();
                    i++;

                }
            }
        //    else
        //    {
        //        TotalAppsentV = Convert.ToInt32(GridView1.Rows[0].Cells[7].Text);

        //        TotalStudentFine = TotalAppsentV * FineCharge;
        //        GridView1.Rows[0].Cells[8].Text = TotalStudentFine.ToString();
        //    }

        }


        private void CheckTotalAppsent(int value)
        {
            if (value == 0)
            {
                int i = 0;
               
                    while (i < GridView1.Rows.Count)
                    {

                        SqlDataAdapter ToAppLac = new SqlDataAdapter("Select Count(StudentAttendance.AttendanceStatus) From StudentAttendance Inner Join SubAllByStu On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)Where SubAllByStu.StudentId='" + GridView1.Rows[i].Cells[1].Text + "' AND SubAllByStu.SubjectId='" + GridView1.Rows[i].Cells[2].Text + "' AND StudentAttendance.AttendanceStatus='0' AND StudentAttendance.LeaveRequest='0' ", con);
                        DataSet ToAppLacds = new DataSet();
                        ToAppLac.Fill(ToAppLacds);
                        if (ToAppLacds.Tables[0].Rows.Count > 0)
                        {

                            GridView1.Rows[i].Cells[7].Text = ToAppLacds.Tables[0].Rows[0][0].ToString();
                        }
                        i++;
                    }
                
            }
            //else
            //{
            //    SqlDataAdapter ToAppLac = new SqlDataAdapter("Select Count(StudentAttendance.AttendanceStatus) From StudentAttendance Inner Join SubAllByStu On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId)Where SubAllByStu.StudentId='" + StudentId1 + "'AND SubjectDetails.SubjectName='" + SubjectName.SelectedItem.Text + "' AND StudentAttendance.AttendanceStatus='0' AND StudentAttendance.LeaveRequest='0' ", con);
            //    DataSet ToAppLacds = new DataSet();
            //    ToAppLac.Fill(ToAppLacds);
            //    if (ToAppLacds.Tables[0].Rows.Count > 0)
            //    {

            //        GridView1.Rows[0].Cells[7].Text = ToAppLacds.Tables[0].Rows[0][0].ToString();
            //    }
            //}
        }



        private void TotalAttendance(int value)
        {
            int i = 0, j = 0;
            if (value == 0)
            {
                while (i <GridView1.Rows.Count)
                {
                    SqlDataAdapter SelectTotalLac = new SqlDataAdapter("Select Count(StudentAttendance.Date) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubAllByStu.StudentId='" +GridView1.Rows[i].Cells[1].Text + "' And StudentAttendance.AttendanceStatus='1' AND SubAllByStu.SubjectId='"+Subject.SelectedValue+"'" , con);
                    DataSet SelectTotalLacds = new DataSet();
                    SelectTotalLac.Fill(SelectTotalLacds);
                    if (SelectTotalLacds.Tables[0].Rows.Count > 0)
                    {
                        TotalAttendanceV = Convert.ToInt32(SelectTotalLacds.Tables[0].Rows[0][0].ToString());
                        GridView1.Rows[i].Cells[6].Text = TotalAttendanceV.ToString();

                    }
                    i++;
                }
            }
            else if (value == 1)
            {
                while (i < GridView1.Rows.Count)
                {
                    SqlDataAdapter SelectTotalLac = new SqlDataAdapter("Select Count(StudentAttendance.Date) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubAllByStu.StudentId='" + GridView1.Rows[i].Cells[1].Text + "' And StudentAttendance.AttendanceStatus='1' AND SubAllByStu.SubjectId='" + GridView1.Rows[i].Cells[2].Text + "' ", con);
                    DataSet SelectTotalLacds = new DataSet();
                    SelectTotalLac.Fill(SelectTotalLacds);
                    if (SelectTotalLacds.Tables[0].Rows.Count > 0)
                    {
                        TotalAttendanceV = Convert.ToInt32(SelectTotalLacds.Tables[0].Rows[0][0].ToString());
                        GridView1.Rows[i].Cells[6].Text = TotalAttendanceV.ToString();

                    }
                    i++;
                }
            }
            //else
            //{
            //    SqlDataAdapter SelectTotalLac = new SqlDataAdapter("Select Count(StudentAttendance.Date) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubjectDetails.SubjectName='" + SubjectName.SelectedItem.Text + "'And SubAllByStu.StudentId='" + StudentId1 + "' And StudentAttendance.AttendanceStatus='1'", con);
            //    DataSet SelectTotalLacds = new DataSet();
            //    SelectTotalLac.Fill(SelectTotalLacds);
            //    if (SelectTotalLacds.Tables[0].Rows.Count > 0)
            //    {
            //        TotalAttendanceV = Convert.ToInt32(SelectTotalLacds.Tables[0].Rows[0][0].ToString());
            //        GridView1.Rows[i].Cells[6].Text = TotalAttendanceV.ToString();

            //    }
            //}
        }

        private void BindSubject()
        {
            SqlDataAdapter SearchSubject = new SqlDataAdapter("Select SubjectDetails.SubjectId,SubjectDetails.SubjectName From SubjectDetails  Where SubjectDetails.SemesterId='"+SemesterNo.SelectedValue+"'", con);
           
            SearchSubject.Fill(SearchSubjectds);

        }
        private void CheckTotalLac(int value)
        {
           
            int i = 0, j = 0;
            if (value == 0)
            {
                while (i < GridView1.Rows.Count)
                {

                    SqlDataAdapter SelectTotalLac = new SqlDataAdapter("Select Count(StudentAttendance.Date) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubjectDetails.SubjectId='" + GridView1.Rows[i].Cells[2].Text + "'And SubAllByStu.StudentId='" + GridView1.Rows[i].Cells[1].Text + "'", con);
                        DataSet SelectTotalLacds = new DataSet();
                        SelectTotalLac.Fill(SelectTotalLacds);

                    
                   
                    if (SelectTotalLacds.Tables[0].Rows.Count > 0)
                    {
                        TotallactureV = Convert.ToInt32(SelectTotalLacds.Tables[0].Rows[0][0]);
                        GridView1.Rows[i].Cells[4].Text = TotallactureV.ToString();

                    }
                    i++;
                }
            }
          

            else
            {
                //SqlDataAdapter SelectTotalLac = new SqlDataAdapter("Select Count(StudentAttendance.Date) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubjectDetails.SubjectName='" + SubjectName.SelectedItem.Text + "'And SubAllByStu.StudentId='" + StudentId1 + "'", con);
                //DataSet SelectTotalLacds = new DataSet();
                //SelectTotalLac.Fill(SelectTotalLacds);
                //if (SelectTotalLacds.Tables[0].Rows.Count > 0)
                //{
                //    TotallactureV = Convert.ToInt32(SelectTotalLacds.Tables[0].Rows[0][0]);
                //    GridView1.Rows[i].Cells[4].Text = TotallactureV.ToString();

                //}
            }
        }

        //protected void SubjectName_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    SqlDataAdapter SearchStudentDetails = new SqlDataAdapter("Select SubAllByStu.StudentId,SubjectDetails.SubjectId,SubjectDetails.SubjectName,SubjectDetails.SubjectId As TotalLactures, SubjectDetails.SubjectId As LeaveDays, SubjectDetails.SubjectId As AttendLactures,SubjectDetails.SubjectId As Appsent_Lactures, SubjectDetails.SubjectId As Fine,SubjectDetails.SubjectId As TotalPercentage From SubjectDetails Inner Join SubAllByStu On(SubAllByStu.SubjectId=SubjectDetails.SubjectId) Where SubAllByStu.StudentId='" + StudentId1 + "' AND SubjectDetails.SubjectName='" + SubjectName.SelectedItem.Text + "'", con);

        //    SearchStudentDetails.Fill(SelectStudentsds);
        //    GridView1.DataSource = SelectStudentsds;

        //    GridView1.DataBind();
        //    if (SelectStudentsds.Tables[0].Rows.Count > 0)
        //    {
        //        CheckTotalLac(1);
        //        TotalAttendance(1);
        //        CheckLeaveDays(1);
        //        CheckTotalAppsent(1);
        //        TotalFine(1);
        //        Bindwithchart(1);
        //    }
        //}

        //protected void DetailsButton_Click(object sender, EventArgs e)
        //{

        //}

        //protected void Chart1_Load(object sender, EventArgs e)
        //{

        //}

        protected void Subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter SearchStudentDetails = new SqlDataAdapter("Select SubAllByStu.StudentId,SubjectDetails.SubjectId,SubjectDetails.SubjectName,SubjectDetails.SubjectId As TotalLactures, SubjectDetails.SubjectId As LeaveDays, SubjectDetails.SubjectId As AttendLactures,SubjectDetails.SubjectId As Appsent_Lactures, SubjectDetails.SubjectId As Fine,SubjectDetails.SubjectId As Total_Percentage From SubjectDetails Inner Join SubAllByStu On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)Inner join SemesterDetailsN On(SemesterDetailsN.SemesterId=SubjectDetails.SemesterId) Inner Join CourseDetails On(CourseDetails.CourseId=SemesterDetailsN.CourseId) Where SubjectDetails.SubjectId='"+Subject.SelectedValue+"'", con);
            DataSet SelectStudentsds = new DataSet();
            SearchStudentDetails.Fill(SelectStudentsds);
            GridView1.DataSource = SelectStudentsds;
            GridView1.DataBind();
            if (SelectStudentsds.Tables[0].Rows.Count > 0)
            {
                CheckTotalLac(0);
                TotalAttendance(0);

                CheckLeaveDays(0);
                CheckTotalAppsent(0);
                TotalFine(0);
                TotalPercentage(0);
            }
        }
       
        protected void Search1_Click(object sender, EventArgs e)
        {

        }
        protected void SearchBSId_Click(object sender, EventArgs e)
        {

        }
//        protected void SearchBSId1_Click(object sender, EventArgs e)
//        {
           

//            SqlDataAdapter SelectAllStudents = new SqlDataAdapter("Select  StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,Count(StudentAttendance.AttendanceStatus) as TotalLactures,Count(StudentAttendance.AttendanceStatus) as AttendLactures,Count(StudentAttendance.AttendanceStatus) as Appsent_Days,Count(StudentAttendance.AttendanceStatus) as Leave_Days,Count(StudentAttendance.AttendanceStatus) as TotalFine,Count(StudentAttendance.AttendanceStatus) as Total_Percentage  " +
//"From StudentDetails Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId)" +
//" Inner Join SubjectDetails On(SubAllByStu.SubjectId=SubjectDetails.SubjectId)" +
//" Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId)" +
//"Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)" +
//" Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)   " +
//"Where CourseDetails.CourseName='" + CourseName.SelectedItem.Text + "'AND SemesterDetailsN.SemesterNo='" + SemesterNo.SelectedItem.Text + "'AND StudentAttendance.AttendanceStatus='1' AND SubjectDetails.SubjectName='" + SubjectNameValue + "'AND StudentDetails.StudentName='" + StudentName.Text + "' " +
//"Group By StudentDetails.StudentId,StudentDetails.StudentName,SubjectDetails.SubjectName,StudentAttendance.AttendanceStatus", con);

//            SelectAllStudents.Fill(SelectStudentsds);

//            GridView1.DataSource = SelectStudentsds;
//            GridView1.DataBind();
//            if (SelectStudentsds.Tables[0].Rows.Count > 0)
//            {

//                CheckTotalLac(0);
//                TotalAttendance(1);

//                CheckLeaveDays(0);
//                CheckTotalAppsent(0);
//                TotalFine(0);
//                TotalPercentage(0);
//            }
               
//        }
        protected void SearchByName1_Click(object sender, EventArgs e)
        {

        }
        protected void SearchBSId1_Click(object sender, EventArgs e)
        {

        }
        protected void SearchByName1_Click1(object sender, EventArgs e)
        {

        }
}
}