using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace AttendanceSystem.ManageStudent
{
    public partial class SearchStudentDetails2 : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        DataSet SStuDds = new DataSet();
        public static int CourseIdValue = 0, TotalNoOfSemester = 0;
        public static int value = 0;
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
                

                //Select Student details
                try
                {

                    DefaultValues();
                    SelectDepartment.Items.Insert(0, "Select...");
                }
                catch (Exception err)
                {
                    //Error.Text = "Select Student Details Portiuon " + err.Message;
                }
            

            }
        }

        private void DefaultValues()
        {
            SqlDataAdapter SelectStudentDetails = new SqlDataAdapter("Select StudentDetails.Image,StudentDetails.StudentId,StudentDetails.StudentName,NewDepartmentDetails.NDepartmentName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,StudentDetails.Gender From StudentDetails Inner Join SemesterDetailsN On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join CourseDetails On (CourseDetails.CourseId=SemesterDetailsN.CourseId) Inner Join NewDepartmentDetails On (NewDepartmentDetails.NDepartmentId=CourseDetails.NDepartmentId) ", con);
            SelectStudentDetails.Fill(SStuDds);

            DisplayStuDetails(SStuDds);
        }

        protected void SelectCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Course Id
            try
            {
                if (SelectCourse.SelectedIndex > 0)
                {
                    
                    SqlDataAdapter SelectCourseID = new SqlDataAdapter("Select CourseId,TotalNoOfSemester From CourseDetails Where CourseName='" + SelectCourse.SelectedItem.Text + "'", con);
                    DataSet SCIDds = new DataSet();
                   
                    SelectCourseID.Fill(SCIDds);
                  
                    CourseIdValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][0]);
                    SelectSemPanel.Visible = true;
                    for (int i = 0; i <= TotalNoOfSemester; i++)
                    {
                        if (i == 0)
                        {
                            SelectSemN.Items.Remove("Select..");
                        }
                        else
                        {
                            SelectSemN.Items.Remove("" + i);
                        }
                    }
                    TotalNoOfSemester = Convert.ToInt32(SCIDds.Tables[0].Rows[0][1]);
                  
                    for (int i = 0; i <= TotalNoOfSemester; i++)
                    {
                        if (i == 0)
                        {
                            SelectSemN.Items.Insert(0, "Select..");
                        }
                        else
                        {
                            SelectSemN.Items.Add("" + i);
                        }
                    }
               
                    SqlDataAdapter SelectStudentDetails = new SqlDataAdapter("Select StudentDetails.Image,StudentDetails.StudentId,StudentDetails.StudentName,NewDepartmentDetails.NDepartmentName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,StudentDetails.Gender From StudentDetails Inner Join SemesterDetailsN On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join CourseDetails On (CourseDetails.CourseId=SemesterDetailsN.CourseId) Inner Join NewDepartmentDetails On (NewDepartmentDetails.NDepartmentId=CourseDetails.NDepartmentId) Where CourseDetails.CourseName='" + SelectCourse.SelectedItem.Text + "' ", con);
                    SelectStudentDetails.Fill(SStuDds);
                    DisplayStuDetails(SStuDds);

                }
                else
                {
                    SelectSemPanel.Visible = false;

                }
            }
            catch (Exception err)
            {
                //Error.Text = "Select Course Id  Portiuon " + err.Message;
            }
        }

        protected void SelectDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Student Details By Department Name

            try
            {
                if (SelectDepartment.SelectedIndex > 0)
                {
                    SqlDataAdapter SelectStudentDetails = new SqlDataAdapter("Select StudentDetails.Image,StudentDetails.StudentId,StudentDetails.StudentName,NewDepartmentDetails.NDepartmentName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,StudentDetails.Gender From StudentDetails Inner Join SemesterDetailsN On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join CourseDetails On (CourseDetails.CourseId=SemesterDetailsN.CourseId) Inner Join NewDepartmentDetails On (NewDepartmentDetails.NDepartmentId=CourseDetails.NDepartmentId) Where NewDepartmentDetails.NDepartmentName='" + SelectDepartment.SelectedItem.Text + "'  ", con);
                    SelectStudentDetails.Fill(SStuDds);
                    DisplayStuDetails(SStuDds);
                    if (SStuDds.Tables[0].Rows.Count > 0)
                    {
                        value = 0;
                    }
                    else
                    {
                        value = 1;
                    }
                }
            }
            catch (Exception err)
            {

            }
            
            
        }

        protected void SelecSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Student Details By Semester No
            try
            {
                if (SelectSemN.SelectedIndex > 0)
                {

                    SqlDataAdapter SelectStudentDetails = new SqlDataAdapter("Select StudentDetails.Image,StudentDetails.StudentId,StudentDetails.StudentName,NewDepartmentDetails.NDepartmentName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,StudentDetails.Gender From StudentDetails Inner Join SemesterDetailsN On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join CourseDetails On (CourseDetails.CourseId=SemesterDetailsN.CourseId) Inner Join NewDepartmentDetails On (NewDepartmentDetails.NDepartmentId=CourseDetails.NDepartmentId) Where SemesterDetailsN.SemesterNo='" + SelectSemN.SelectedItem.Text + "' And CourseDetails.CourseId='" + CourseIdValue + "' ", con);
                    SelectStudentDetails.Fill(SStuDds);
                    DisplayStuDetails(SStuDds);
                }
            }
            catch (Exception err)
            {
                //Error.Text = "Student Details By Semester No Portiuon " + err.Message;
            }
           
        }

        protected void FilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (FilterBy.SelectedItem.Text == "Course Name")
                {

                    SelectDepPanel.Visible = false;
                    SelectSemPanel.Visible = false;
                    SelectCourPanel.Visible = true;
                    EnterStudentId.Visible = false;
                    StudentId.Text = "";
                    StudentName.Text = "";
                    // Filter By Course Name
                    try
                    {
                        SqlDataAdapter SelectCourseDet = new SqlDataAdapter("Select CourseName From CourseDetails", con);
                        DataSet SCDetails = new DataSet();
                        SelectCourseDet.Fill(SCDetails);
                        SelectCourse.DataSource = SCDetails;
                        SelectCourse.DataTextField = "CourseName";
                        SelectCourse.DataValueField = "CourseName";

                        SelectCourse.DataBind();
                        SelectCourse.Items.Insert(0, "Select...");
                        SelectCourse.SelectedIndex = 0;
                    }
                    catch (Exception err)
                    {
                        //Error.Text = "Filter By Course Name Portiuon " + err.Message;
                    }

                }
                else if (FilterBy.SelectedItem.Text == "Department Name")
                {
                    SelectDepPanel.Visible = true;
                    SelectSemPanel.Visible = false;
                    SelectCourPanel.Visible = false;
                    EnterStudentId.Visible = false;
                    //Filter By Department Name
                    try
                    {
                        SqlDataAdapter SelectDepartmentDet = new SqlDataAdapter("Select NDepartmentName From NewDepartmentDetails", con);
                        DataSet SDDetails = new DataSet();
                        SelectDepartmentDet.Fill(SDDetails);
                        SelectDepartment.DataSource = SDDetails;
                        SelectDepartment.DataTextField = "NDepartmentName";
                        SelectDepartment.DataValueField = "NDepartmentName";
                        SelectDepartment.DataBind();
                        SelectDepartment.Items.Insert(0, "Select...");

                    }
                    catch (Exception err)
                    {
                        //Error.Text = "Filter By department Name Portiuon " + err.Message;
                    }


                }
                else if (FilterBy.SelectedItem.Text == "Student Id")
                {
                    EnterStudentId.Visible = true;
                    SelectDepPanel.Visible = false;
                    SelectSemPanel.Visible = false;
                    SelectCourPanel.Visible = false;
                }

                DefaultValues();
            }
            catch (Exception err)
            {
            }
        }
        private void DisplayStuDetails(DataSet Source)
        {
            ShoStudentDetails.DataSource = Source;
            ShoStudentDetails.DataBind();
           
        }

        protected void Search1_Click(object sender, EventArgs e)
        {
            //Search Student Details By Student Name 
            try
            {

                if (StudentName.Text != "")
                {
                    SqlDataAdapter SelectStudentDetails = new SqlDataAdapter("Select StudentDetails.Image,StudentDetails.StudentId,StudentDetails.StudentName,NewDepartmentDetails.NDepartmentName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,StudentDetails.Gender From StudentDetails Inner Join SemesterDetailsN On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join CourseDetails On (CourseDetails.CourseId=SemesterDetailsN.CourseId) Inner Join NewDepartmentDetails On (NewDepartmentDetails.NDepartmentId=CourseDetails.NDepartmentId) Where StudentDetails.StudentName='" + StudentName.Text + "' ", con);
                    SelectStudentDetails.Fill(SStuDds);
                    DisplayStuDetails(SStuDds);
                }
            }
            catch (Exception err)
            {
                //Error.Text = "Search  Student Details By Student Name Portiuon " + err.Message;
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            // Search Student Details By Student Id
            try
            {
                if (StudentId.Text != "")
                {
                    SqlDataAdapter SelectStudentDetails = new SqlDataAdapter("Select StudentDetails.Image,StudentDetails.StudentId,StudentDetails.StudentName,NewDepartmentDetails.NDepartmentName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,StudentDetails.Gender From StudentDetails Inner Join SemesterDetailsN On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join CourseDetails On (CourseDetails.CourseId=SemesterDetailsN.CourseId) Inner Join NewDepartmentDetails On (NewDepartmentDetails.NDepartmentId=CourseDetails.NDepartmentId) Where  StudentDetails.StudentId='" + StudentId.Text + "' ", con);
                    SelectStudentDetails.Fill(SStuDds);
                    DisplayStuDetails(SStuDds);
                }
            }
            catch (Exception err)
            {
                //Error.Text = "Student Details By department Id Portiuon " + err.Message;
            }
        }

        protected void SelectCourse_SelectedIndexChanged1(object sender, EventArgs e)
        {
        }

        protected void ShoStudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
              e.Row.Cells[4].Visible = false;
            
           
        }
    }
}