using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AttendanceSystem.ManageSemester
{
    public partial class ManageSemester : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        DataSet SSDds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Select Semester Details
            if (!IsPostBack)
            {
                if (Session["AdminId"] == null)
                {

                    //Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }
            try
            {
                SqlDataAdapter SelectSemesterDet = new SqlDataAdapter("Select SemesterDetailsN.SemesterId,CourseDetails.CourseName,SemesterDetailsN.SemesterNo as Semester,Convert(NVARCHAR(10),SemesterDetailsN.SemesterStartingDate,101)as SemesterStartingDate,Convert(NVARCHAR(10),SemesterDetailsN.SemesterEndingDate,101) as SemesterEndingDate,SemesterDetailsN.TotalNoOfSubjects From SemesterDetailsN Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId) ", con);
                SelectSemesterDet.Fill(SSDds);
                DisplaySemesterDetails(SSDds);
            }
            catch (Exception err)
            {
                Error.Text = "Select Semester Details "+err.Message;
            }
        }

        private void DisplaySemesterDetails(DataSet Source)
        {
            ShowSemesterDetails.DataSource = Source;
            ShowSemesterDetails.DataBind();
        }

        protected void SelectOption_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //Select Optional 
            try
            {
                if (SelectOption.SelectedItem.Text == "Semester Id")
                {

                    ByNo.Visible = false;
                    ById.Visible = true;
                    ByCourseName.Visible = false;


                }
                else if (SelectOption.SelectedItem.Text == "Semester No")
                {

                    ById.Visible = false;
                    ByCourseName.Visible = false;
                    ByNo.Visible = true;
                }
                else if (SelectOption.SelectedItem.Text == "Course Name")
                {
                    ById.Visible = false;
                    ByNo.Visible = false;
                    ByCourseName.Visible = true;
                    SqlDataAdapter SelectCourseName1 = new SqlDataAdapter("Select CourseName From CourseDetails", con);
                    DataSet SCNds = new DataSet();
                    SelectCourseName1.Fill(SCNds);
                    SelectCourseName.DataSource = SCNds;
                    SelectCourseName.DataTextField = "CourseName";
                    SelectCourseName.DataValueField = "CourseName";
                    SelectCourseName.DataBind();
                    SelectCourseName.Items.Insert(0, "Select..");
                    SelectCourseName.SelectedIndex = 0;
                    SelectSemesterNo1.SelectedIndex = 0;
                    SemesterId.Text = "";
                }

            }
            catch (Exception err)
            {
                Error.Text = "Select Option" + err.Message;
            }
        }

        protected void SelectSemesterNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Semester No
            try
            {
                if (SelectSemesterNo1.SelectedIndex != 0)
                {
                    SqlDataAdapter SelectSemesterNo = new SqlDataAdapter("Select CourseDetails.CourseName,SemesterDetailsN.SemesterId,Convert(NVARCHAR(10),SemesterDetailsN.SemesterStartingDate,101)as SemesterStartingDate,Convert(NVARCHAR(10),SemesterDetailsN.SemesterStartingDate,101)as SemesterStartingDate,SemesterDetailsN.SemesterEndingDate,101) as SemesterEndingDate,SemesterDetailsN.TotalNoOfSubjects From SemesterDetailsN Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Where SemesterNo='" + SelectSemesterNo1.SelectedItem.Text + "'", con);
                    DataSet SSNds = new DataSet();
                    SelectSemesterNo.Fill(SSNds);
                    DisplaySemesterDetails(SSNds);
                }
            }
            catch (Exception err)
            {
                Error.Text = "Select Semester No1 " + err.Message;
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //Select Semester No2
            try
            {
                SqlDataAdapter SelectSemesterNo = new SqlDataAdapter("Select CourseDetails.CourseName,SemesterDetailsN.SemesterId,SemesterDetailsN.SemesterNo,Convert(NVARCHAR(10),SemesterDetailsN.SemesterStartingDate,101)as SemesterStartingDate,SemesterDetailsN.SemesterEndingDate,101) as SemesterEndingDate,SemesterDetailsN.TotalNoOfSubjects From SemesterDetailsN Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Where SemesterDetailsN.SemesterId='" + SemesterId.Text + "'", con);
                DataSet SSNds = new DataSet();
                SelectSemesterNo.Fill(SSNds);
                DisplaySemesterDetails(SSNds);
            }
            catch (Exception err)
            {
                Error.Text = "Select Semester No2 " + err.Message;
            }
        }

        protected void SelectCourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Semester cDetails By Course Name
            try
            {
                if (SelectCourseName.SelectedIndex != 0)
                {
                    SqlDataAdapter SelectSemsterDetailsBCN = new SqlDataAdapter("Select CourseDetails.CourseName,SemesterDetailsN.SemesterId,SemesterDetailsN.SemesterNo,Convert(NVARCHAR(10),SemesterDetailsN.SemesterStartingDate,101)as SemesterStartingDateMM/dd/yyyy,SemesterDetailsN.SemesterEndingDate,101) as SemesterEndingDate,SemesterDetailsN.TotalNoOfSubjects From SemesterDetailsN Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Where CourseName='" + SelectCourseName.SelectedItem.Text + "'", con);
                    DataSet SSDBCNds = new DataSet();
                    SelectSemsterDetailsBCN.Fill(SSDBCNds);
                    DisplaySemesterDetails(SSDBCNds);
                }
            }
            catch (Exception err)
            {
                Error.Text = "Select Semester Details By Course Name Portion " + err.Message;
            }
        }

        protected void ShowSemesterDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}