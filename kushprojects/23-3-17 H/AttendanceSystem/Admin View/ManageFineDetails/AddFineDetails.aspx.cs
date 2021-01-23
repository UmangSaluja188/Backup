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
    public partial class AddFineDetails : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static  int SemesterId;
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
               
                SqlDataAdapter SelDep = new SqlDataAdapter("Select NDepartmentName From NewDepartmentDetails",con);
                DataSet ds = new DataSet();
                SelDep.Fill(ds);
                Department.DataSource=ds;
                Department.DataTextField = "NDepartmentName";
                Department.DataValueField = "NDepartmentName";
                Department.DataBind();
                Department.Items.Insert(0, "Select Department...");
                Course.Items.Insert(0, "Select Course...");
                Semester.Items.Insert(0, "Select Semester...");

            }
        }

        protected void Department_SelectedIndexChanged(object sender, EventArgs e)
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
            SqlDataAdapter da2 = new SqlDataAdapter("Select SemesterNo,SemesterId From SemesterDetailsN Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Where CourseName='" + Course.SelectedItem.Text + "'", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            //SemesterIdValue = Convert.ToInt32(ds2.Tables[0].Rows[0]["SemesterId"]);
            Semester.DataSource = ds2.Tables[0];
            Semester.DataTextField = "SemesterNo";
            Semester.DataValueField = "SemesterNo";
            Semester.DataBind();
            Semester.Items.Insert(0, "Select Semester...");
        }

        protected void Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter SelSemId=new SqlDataAdapter("Select SemesterId From SemesterDetailsN Where SemesterNo='"+Semester.SelectedValue+"'And CourseId='"+Course.SelectedValue+"'",con);
            DataSet ds1=new DataSet();
            SelSemId.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                SemesterId = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
            }
      }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter SelDup = new SqlDataAdapter("Select * From FineDetails Where SemesterId='"+SemesterId+"'",con);
            DataSet ds3 = new DataSet();
            SelDup.Fill(ds3);
            if (ds3.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script type=\"text/javascript\">" + "alert('Please Do Not Insert Dupliocate Value');" + "</script>");
            }
            else
            {
                SqlDataAdapter InsertFinbeDetails = new SqlDataAdapter("Insert Into FineDetails (SemesterId,FinePerDay) Values('" + SemesterId + "','" + FinePerDay.Text + "') ", con);
                DataSet ds2 = new DataSet();
                InsertFinbeDetails.Fill(ds2);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin View/ManageFineDetails/SearchFineDetails.aspx");
        }
    }
}