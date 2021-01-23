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
    public partial class EditFineDetails1 : System.Web.UI.Page
    {
       

        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static int SemesterId,FineId;
        public static string DepartmentName, CourseName, SemesterNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataAdapter SelDep = new SqlDataAdapter("Select NDepartmentId,NDepartmentName From NewDepartmentDetails", con);
                DataSet ds = new DataSet();
                SelDep.Fill(ds);
                Department.DataSource = ds;
                Department.DataTextField = "NDepartmentName";
                Department.DataValueField = "NDepartmentId";
                Department.DataBind();
                Department.Items.Insert(0, "Select Department...");
                EditDetails();  
                
            }
        }

        private void EditDetails()
        {
            
                FineId = Convert.ToInt32(Request.QueryString["FineId"]);
              
                SqlDataAdapter ShowFine = new SqlDataAdapter("Select NewDepartmentDetails.NDepartmentName,CourseDetails.CourseName,SemesterDetailsN.SemesterNo,FinePerDay as FineChargePerDay From NewDepartmentDetails Inner Join CourseDetails On(NewDepartmentDetails.NDepartmentId=CourseDetails.NDepartmentId) Inner Join SemesterDetailsN On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Inner Join FineDetails On(SemesterDetailsN.SemesterId=FineDetails.SemesterId) Where FineDetails.FineId='" + FineId + "'", con);
                DataSet ds3 = new DataSet();
                ShowFine.Fill(ds3);

                if (ds3.Tables[0].Rows.Count > 0)
                {
                    DepartmentName = ds3.Tables[0].Rows[0][0].ToString();
                    CourseName = ds3.Tables[0].Rows[0][1].ToString();
                    SemesterNo = ds3.Tables[0].Rows[0][2].ToString();

                    FinePerDay.Text = ds3.Tables[0].Rows[0][3].ToString();
                }

               

                int i = 0, j = 0, k = 0;
                while (i < Department.Items.Count)
                {
                    if (Department.Items[i].Text == DepartmentName)
                    {
                        Department.Items[i].Selected = true;
                        break;
                    }
                    i++;
                }
                SelectCourse();
                while (j < Course.Items.Count)
                {
                    if (Course.Items[j].Text == CourseName)
                    {
                        Course.Items[j].Selected = true;
                        break;
                    }
                    j++;
                }
                SelectSemester();
                while (k < Semester.Items.Count)
                {
                    if (Semester.Items[k].Text == SemesterNo)
                    {
                        Semester.Items[k].Selected = true;
                        break;
                    }
                    k++;
                }
                SqlDataAdapter SelSemId = new SqlDataAdapter("Select SemesterId From SemesterDetailsN Where SemesterNo='" + Semester.SelectedValue + "'And CourseId='" + Course.SelectedValue + "'", con);
                DataSet ds1 = new DataSet();
                SelSemId.Fill(ds1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    SemesterId = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
                }
            
        }

        protected void Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCourse();
        }

        private void SelectCourse()
        {
            SqlDataAdapter SelDep = new SqlDataAdapter("Select CourseDetails.CourseName,CourseDetails.CourseId From CourseDetails Inner Join NewDepartmentDetails On (CourseDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId) Where NewDepartmentDetails.NDepartmentName='" + Department.SelectedItem.Text + "'", con);
            DataSet ds = new DataSet();
            SelDep.Fill(ds);
            Course.DataSource = ds;
            Course.DataTextField = "CourseName";
            Course.DataValueField = "CourseId";
            Course.DataBind();
            Course.Items.Insert(0, "Select Course...");
        }

        protected void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectSemester();
        }

        private void SelectSemester()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select SemesterNo,SemesterId From SemesterDetailsN Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Where CourseName='" + Course.SelectedItem.Text + "'", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            //SemesterIdValue = Convert.ToInt32(ds2.Tables[0].Rows[0]["SemesterId"]);
            Semester.DataSource = ds2.Tables[0];
            Semester.DataTextField = "SemesterNo";
            Semester.DataValueField = "SemesterNo";
            Semester.DataBind();
            Semester.Items.Insert(0, "Select Semester");
        }

        protected void Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter SelSemId = new SqlDataAdapter("Select SemesterId From SemesterDetailsN Where SemesterNo='" + Semester.SelectedValue + "'And CourseId='" + Course.SelectedValue + "'", con);
            DataSet ds1 = new DataSet();
            SelSemId.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                SemesterId = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter UpdateRecord = new SqlDataAdapter("Update FineDetails Set FineDetails.SemesterId='"+SemesterId+"',FinePerDay='"+FinePerDay.Text+"' Where FineId='"+FineId+"'",con);
            DataSet ds4 = new DataSet();
            UpdateRecord.Fill(ds4);     
            Response.Write("<script type=\"text/javascript\">"+"alert('Record Are Successfully Updated');"+"</script>");
            Response.Redirect("~/Admin View/ManageFineDetails/SearchFineDetails.aspx");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EditDetails();
        }
    }
}