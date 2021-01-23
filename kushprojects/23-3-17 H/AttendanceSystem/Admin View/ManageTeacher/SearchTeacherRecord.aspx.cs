using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AttendanceSystem.ManageTeacher
{
    public partial class SearchTeacherRecord : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        DataSet STDds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
          
               
            if (!IsPostBack)
            {
                if (Session["AdminId"] == null)
                {

                    //Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }

            //Select Department Name
            try
            {
                
                if (!IsPostBack)
                {
                    SqlDataAdapter SelectDepartmentName = new SqlDataAdapter("Select * from NewDepartmentDetails", con);
                    DataSet SDNds = new DataSet();
                    SelectDepartmentName.Fill(SDNds);
                    SelectDepartment.DataSource = SDNds;
                    SelectDepartment.DataTextField = "NDepartmentName";
                    SelectDepartment.DataValueField = "NDepartmentName";
                    
                    SelectDepartment.DataBind();
                    SelectDepartment.Items.Insert(0, "Select..");
                    

                    //Show Teacher Details
                    DefaultValues();
                    if (STDds.Tables[0].Rows.Count > 0)
                    {

                        CombineYearText();
                    }

                }
            }

            catch (Exception err)
            {
               
            }
        }

        private void DefaultValues()
        {
            SqlDataAdapter ShowTeacherDetails1 = new SqlDataAdapter("Select TeacherDetails.Image,TeacherDetails.TeacherId,TeacherDetails.TeacherName, NewDepartmentDetails.NDepartmentName as DepartmentName,TeacherDetails.Experience From TeacherDetails Inner Join NewDepartmentDetails On (TeacherDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId)", con);
            ShowTeacherDetails1.Fill(STDds);
            DisplayTeacherDetails(STDds);
        }

        private void CombineYearText()
        {
            int i = 0;
            while (i < ShowTeacherDetails.Rows.Count)
            {
                ShowTeacherDetails.Rows[i].Cells[8].Text+=" Years";
                i++;
            }
        }

        protected void SelectDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Teacher Details By Department Name
            STBIDPanel.Visible = false;
            STBNamePanel.Visible = false;
            try
            {
                if (SelectDepartment.SelectedIndex > 0)
                {
                    SqlDataAdapter ShowTeacherDetails1 = new SqlDataAdapter("Select TeacherDetails.Image,TeacherDetails.TeacherId,TeacherDetails.TeacherName, NewDepartmentDetails.NDepartmentName as DepartmentName,TeacherDetails.Experience From TeacherDetails Inner Join NewDepartmentDetails On (TeacherDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId) Where NewDepartmentDetails.NDepartmentName='" + SelectDepartment.SelectedItem.Text + "'", con);
                    ShowTeacherDetails1.Fill(STDds);
                    DisplayTeacherDetails(STDds);
                    if (STDds.Tables[0].Rows.Count > 0)
                    {
                        CombineYearText();
                    }
                    STNPanel.Visible = true;
                }
                else
                {
                    STNPanel.Visible = false;

                }
            }
            catch (Exception err)
            {
                //Error.Text = "Select Department Name Portion " + err.Message;
            }
            
        }

        private void DisplayTeacherDetails(DataSet Source)
        {
            ShowTeacherDetails.DataSource = Source;
            ShowTeacherDetails.DataBind();
        }

        protected void SelectTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SelectTeacher.SelectedIndex > 0)
                {
                    string SelectedItem;

                    SelectedItem = SelectTeacher.SelectedItem.Text.Trim();
                    if (SelectedItem == "Teacher Name")
                    {
                        STBNamePanel.Visible = true;
                        STBIDPanel.Visible = false;
                    }
                    else if (SelectedItem == "Teacher Id")
                    {
                        STBIDPanel.Visible = true;
                        STBNamePanel.Visible = false;
                    }
                }
                DefaultValues();
            }
            catch (Exception err)
            {
            }
        }

        protected void Serach_Click(object sender, EventArgs e)
        {
            //Search Teacher Details By Teacher Name
            try
            {
                if (EnterTeacherName.Text != "")
                {
                    SqlDataAdapter ShowTeacherDetails1 = new SqlDataAdapter("Select TeacherDetails.Image,TeacherDetails.TeacherId,TeacherDetails.TeacherName, NewDepartmentDetails.NDepartmentName as DepartmentName,TeacherDetails.Experience From TeacherDetails Inner Join NewDepartmentDetails On (TeacherDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId) Where TeacherDetails.TeacherName='" + EnterTeacherName.Text + "'", con);
                    ShowTeacherDetails1.Fill(STDds);
                    DisplayTeacherDetails(STDds);
                    if (STDds.Tables[0].Rows.Count > 0)
                    {

                        CombineYearText();
                    }
                }
            }
            catch (Exception err)
            {
                //Error.Text = "Select Teacher Details Bt Teacher Name Portion " + err.Message;
            }
        }

        protected void Search2_Click(object sender, EventArgs e)
        {
            //Search Teacher Details By Teacher ID
           
                Response.Write("Helllo");
                    SqlDataAdapter ShowTeacherDetails1 = new SqlDataAdapter("Select TeacherDetails.Image,TeacherDetails.TeacherId,TeacherDetails.TeacherName, NewDepartmentDetails.NDepartmentName as DepartmentName,TeacherDetails.Experience From TeacherDetails Inner Join NewDepartmentDetails On (TeacherDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId) Where TeacherDetails.TeacherId='" + EnterTId.Text + "'", con);
                    ShowTeacherDetails1.Fill(STDds);
                    DisplayTeacherDetails(STDds);
                    if (STDds.Tables[0].Rows.Count > 0)
                    {
                        CombineYearText();
                    }
                    SelectDepartment.SelectedIndex = 0;
                    EnterTeacherName.Text = "";
                
           
        }

        protected void Search2_Click1(object sender, EventArgs e)
        {
            if (EnterTId.Text != "")
            {
                try
                {
                    Response.Write("Helllo");
                    SqlDataAdapter ShowTeacherDetails1 = new SqlDataAdapter("Select TeacherDetails.Image,TeacherDetails.TeacherId,TeacherDetails.TeacherName, NewDepartmentDetails.NDepartmentName as DepartmentName,TeacherDetails.Experience From TeacherDetails Inner Join NewDepartmentDetails On (TeacherDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId) Where TeacherDetails.TeacherId='" + EnterTId.Text + "'", con);
                    ShowTeacherDetails1.Fill(STDds);
                    DisplayTeacherDetails(STDds);
                    CombineYearText();
                    SelectDepartment.SelectedIndex = 0;
                    EnterTeacherName.Text = "";

                }
                catch (Exception err)
                {
                    //Error.Text = "Select Teacher Details Bt Teacher id Portion " + err.Message;
                }
            }
        }

        protected void ShowTeacherDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].Visible = false;
           
        }
    }
}
