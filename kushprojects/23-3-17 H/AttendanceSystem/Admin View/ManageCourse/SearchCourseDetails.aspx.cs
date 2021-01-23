using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace AttendanceSystem.ManageCourse
{
    public partial class SearchCourseDetails : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        DataSet SCDds = new DataSet();
      
  
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Session["AdminId"] != null)
                {
            //Select Department Details 
                    try
                    {
                        
                            SqlDataAdapter SelectDepartmentDet = new SqlDataAdapter("Select NewDepartmentDetails.NDepartmentName as DepartmentName,CourseDetails.CourseId,CourseDetails.CourseName,CourseDetails.CourseType,CourseDetails.CourseDuration,CourseDetails.TotalNoOfSemester From CourseDetails Inner Join NewDepartmentDetails On (CourseDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId)", con);
                            SelectDepartmentDet.Fill(SCDds);
                            DisplayCourseD(SCDds);
                        
                    }
                    catch (Exception err)
                    {
                        Error.Text = "Select Department Details Page Load Portion" + err.Message;
                    }
                }
                else
                {
                    //Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            
        }
        private void DisplayCourseD(DataSet Source)
        {
            int i=0;
            ShowCourseDetails.DataSource = Source;
            ShowCourseDetails.DataBind();
            while (i < ShowCourseDetails.Rows.Count)
            {
                ShowCourseDetails.Rows[i].Cells[6].Text += " Years";
                i++;
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //Search Course By Department Name
            try
            {
                SqlDataAdapter SelectCourseByDepartmentName = new SqlDataAdapter("Select NewDepartmentDetails.NDepartmentName as DepartmentName,CourseDetails.CourseId,CourseDetails.CourseName,CourseDetails.CourseType,CourseDetails.CourseDuration,CourseDetails.TotalNoOfSemester From CourseDetails Inner Join NewDepartmentDetails On (CourseDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId) Where CourseDetails.CourseId='" + Course.Text + "'", con);
                DataSet SCBDNds = new DataSet();

                SelectCourseByDepartmentName.Fill(SCBDNds);
                DisplayCourseD(SCBDNds);
            }
            catch (Exception err)
            {
                Error.Text = "Select Course By Department name Portion" + err.Message;
            }
        }

        protected void SelectCoursetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Course By Name
            try
            {
                SqlDataAdapter SelectCourseByName = new SqlDataAdapter("Select NewDepartmentDetails.NDepartmentName as DepartmentName,CourseDetails.CourseId,CourseDetails.CourseName,CourseDetails.CourseType,CourseDetails.CourseDuration,CourseDetails.TotalNoOfSemester From CourseDetails Inner Join NewDepartmentDetails On (CourseDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId) Where CourseName='" + SelectCoursetName.SelectedItem.Text + "'", con);
                DataSet SCBNds = new DataSet();
                SelectCourseByName.Fill(SCBNds);
                DisplayCourseD(SCBNds);
            }
            catch (Exception err)
            {
                Error.Text = "Select Course By Name Portion" + err.Message;
            }
        }

        protected void SelectFilterOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Course.Text = "";
            if (SelectFilterOption.SelectedItem.Text == "Course Id")
            {
                ByName.Visible = false;
                ByDepartmentName.Visible = false;
                ById.Visible = true;
                
              
            }
            else if (SelectFilterOption.SelectedItem.Text == "Course Name")
            {
                ByDepartmentName.Visible = false;
                ById.Visible = false;
                ByName.Visible = true;
               // Select Course Name From Filter Option
                try
                {
                    SelectCoursetName.DataSource = SCDds;
                    SelectCoursetName.DataTextField = "CourseName";
                    SelectCoursetName.DataValueField = "CourseName";
                    SelectCoursetName.DataBind();
                    SelectCoursetName.Items.Insert(0, "select..");
                    SelectCoursetName.SelectedIndex = 0;
                }
                catch (Exception err)
                {
                    Error.Text = "Select CourseName From Filter Option Portion" + err.Message;
                }
                
            }
            else if (SelectFilterOption.SelectedItem.Text == "Department Name")
            {
                ById.Visible = false;
                ByName.Visible = false;
                ByDepartmentName.Visible = true;
                //Select Department Name From Filter Option
                try
                {
                    SqlDataAdapter SelectDepartmentName = new SqlDataAdapter("Select NDepartmentName From NewDepartmentDetails",con);
                    DataSet SelectDepartmentNameds = new DataSet();
                    SelectDepartmentName.Fill(SelectDepartmentNameds);
                    DepartmentName.DataSource = SelectDepartmentNameds;
                    DepartmentName.DataTextField = "NDepartmentName";
                    DepartmentName.DataValueField = "NDepartmentName";
                    DepartmentName.DataBind();
                    DepartmentName.Items.Insert(0, "Select..");
                }
                catch (Exception err)
                {
                    Error.Text = "Select Department Name From Filter Option Portion" + err.Message;
                }
            }
        }

        protected void DepartmentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Course By Department Name
            try
            {
                if (DepartmentName.SelectedIndex > 0)
                {
                    SqlDataAdapter SelectCourseByDepartmentName = new SqlDataAdapter("Select NewDepartmentDetails.NDepartmentName,CourseDetails.CourseId,CourseDetails.CourseName,CourseDetails.CourseType,CourseDetails.CourseDuration,CourseDetails.TotalNoOfSemester From CourseDetails Inner Join NewDepartmentDetails On (CourseDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId) Where NewDepartmentDetails.NDepartmentName='" + DepartmentName.SelectedItem.Text + "'", con);
                    DataSet SCBDNds = new DataSet();

                    SelectCourseByDepartmentName.Fill(SCBDNds);
                    DisplayCourseD(SCBDNds);
                }

                else
                {
                    SelectCoursetName.Visible = false;
                }
            }
            catch (Exception err)
            {
                Error.Text = "Select Course By Department Name Portion" + err.Message;
            }
        }
    }
}