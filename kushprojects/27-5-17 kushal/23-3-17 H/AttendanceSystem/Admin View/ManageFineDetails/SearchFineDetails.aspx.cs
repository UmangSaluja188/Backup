using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace AttendanceSystem.Admin_View.ManageFineDetails
{
    public partial class EditFineDetails : System.Web.UI.Page
    {
        static string cs2 = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con1 = new SqlConnection(cs2);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Write("deded");
                SqlDataAdapter SelDep = new SqlDataAdapter("Select NDepartmentName From NewDepartmentDetails",con1);
                DataSet ds = new DataSet();
                SelDep.Fill(ds);
                Department.DataSource=ds;
                Department.DataTextField = "NDepartmentName";
                Department.DataValueField = "NDepartmentName";
                Department.DataBind();
                Department.Items.Insert(0, "Select Department...");
                SqlDataAdapter ShowFine = new SqlDataAdapter("Select  FineDetails.FineId,NewDepartmentDetails.NDepartmentName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,FinePerDay as FineChargePerDay From NewDepartmentDetails Inner Join CourseDetails On(NewDepartmentDetails.NDepartmentId=CourseDetails.NDepartmentId) Inner Join SemesterDetailsN On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Inner Join FineDetails On(SemesterDetailsN.SemesterId=FineDetails.SemesterId)", con1);
                DataSet ds3 = new DataSet();
                ShowFine.Fill(ds3);
                Fine.DataSource = ds3;
                Fine.DataBind();


            }
        }

        protected void Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Department.SelectedIndex > 0)
            {
                SqlDataAdapter ShowFine = new SqlDataAdapter("Select  FineDetails.FineId,NewDepartmentDetails.NDepartmentName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,FinePerDay as FineChargePerDay From NewDepartmentDetails Inner Join CourseDetails On(NewDepartmentDetails.NDepartmentId=CourseDetails.NDepartmentId) Inner Join SemesterDetailsN On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Inner Join FineDetails On(SemesterDetailsN.SemesterId=FineDetails.SemesterId) Where NewDepartmentDetails.NDepartmentName='" + Department.SelectedItem.Text + "'", con1);
                DataSet ds3 = new DataSet();
                ShowFine.Fill(ds3);
                Fine.DataSource = ds3;
                Fine.DataBind();
                SqlDataAdapter SelDep = new SqlDataAdapter("Select CourseDetails.CourseName From CourseDetails Inner Join NewDepartmentDetails On (CourseDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId) Where NewDepartmentDetails.NDepartmentName='" + Department.SelectedItem.Text + "'", con1);
                DataSet ds = new DataSet();
                SelDep.Fill(ds);
                Course.DataSource = ds;
                Course.DataTextField = "CourseName";
                Course.DataValueField = "CourseName";
                Course.DataBind();
                Course.Items.Insert(0, "Select Course...");
            }
        }

        protected void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Course.SelectedIndex > 0)
            {
                SqlDataAdapter ShowFine = new SqlDataAdapter("Select  FineDetails.FineId,NewDepartmentDetails.NDepartmentName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,FinePerDay as FineChargePerDay From NewDepartmentDetails Inner Join CourseDetails On(NewDepartmentDetails.NDepartmentId=CourseDetails.NDepartmentId) Inner Join SemesterDetailsN On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Inner Join FineDetails On(SemesterDetailsN.SemesterId=FineDetails.SemesterId) Where NewDepartmentDetails.NDepartmentName='" + Department.SelectedItem.Text + "' AND CourseDetails.CourseName='"+Course.SelectedItem.Text+"'", con1);
                DataSet ds3 = new DataSet();
                ShowFine.Fill(ds3);
                Fine.DataSource = ds3;
                Fine.DataBind();
                SqlDataAdapter da2 = new SqlDataAdapter("Select SemesterNo,SemesterId From SemesterDetailsN Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Where CourseName='" + Course.SelectedItem.Text + "'", con1);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                //SemesterIdValue = Convert.ToInt32(ds2.Tables[0].Rows[0]["SemesterId"]);
                Semester.DataSource = ds2.Tables[0];
                Semester.DataTextField = "SemesterNo";
                Semester.DataValueField = "SemesterNo";
                Semester.DataBind();
                Semester.Items.Insert(0, "Select Semester");
            }
        }

        protected void Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter ShowFine = new SqlDataAdapter("Select  FineDetails.FineId,NewDepartmentDetails.NDepartmentName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,FinePerDay as FineChargePerDay From NewDepartmentDetails Inner Join CourseDetails On(NewDepartmentDetails.NDepartmentId=CourseDetails.NDepartmentId) Inner Join SemesterDetailsN On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Inner Join FineDetails On(SemesterDetailsN.SemesterId=FineDetails.SemesterId) Where NewDepartmentDetails.NDepartmentName='" + Department.SelectedItem.Text + "' AND CourseDetails.CourseName='" + Course.SelectedItem.Text + "' AND SemesterDetailsN.SemesterNo='"+Semester.SelectedItem.Text+"'", con1);
            DataSet ds3 = new DataSet();
            ShowFine.Fill(ds3);
            Fine.DataSource = ds3;
            Fine.DataBind();
        }
    }
}