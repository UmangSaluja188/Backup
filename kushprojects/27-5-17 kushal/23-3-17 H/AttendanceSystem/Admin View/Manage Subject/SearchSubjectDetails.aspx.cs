using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AttendanceSystem.Manage_Subject
{
    public partial class SearchSubjectDetails : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        DataSet SSUBDds = new DataSet();
        public static int TotalNoOfSemester=0,SemesterIdValue=0,CourseIdValue=0,AdminId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdminId"] != null)
                {
                    
                        SqlDataAdapter SelectCourseName1 = new SqlDataAdapter("Select CourseName From CourseDetails", con);
                        DataSet SCNds = new DataSet();
                        SelectCourseName1.Fill(SCNds);
                        SelectCourse.DataSource = SCNds;
                        SelectCourse.DataTextField = "CourseName";
                        SelectCourse.DataValueField = "CourseName";
                        SelectCourse.DataBind();
                        SelectCourse.Items.Insert(0, "Select..");
                        SelectSemesterNo.Items.Insert(0, "Select...");

                        SqlDataAdapter SelectAllSubjectDetails = new SqlDataAdapter("Select CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectId,SubjectDetails.SubjectName,SubjectDetails.SubjectType,SubjectDetails.SubjectOptCom From SubjectDetails Inner Join SemesterDetailsN On (SemesterDetailsN.SemesterId=SubjectDetails.SemesterId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId)", con);
                        DataSet SASDds = new DataSet();
                        SelectAllSubjectDetails.Fill(SASDds);
                        DisplaySubjectDetais(SASDds);
                    

                }
                else
                {
                    Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }
           

        }

        private void DisplaySubjectDetais( DataSet Source)
        {
            ShowSubjectDetails.DataSource = Source;
            ShowSubjectDetails.DataBind();
        }

        

        protected void SelectCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectSubNP.Visible = false;
            if (SelectCourse.SelectedIndex > 0)
            {
            SqlDataAdapter SelectCourseID = new SqlDataAdapter("Select CourseId,TotalNoOfSemester From CourseDetails Where CourseName='" + SelectCourse.SelectedItem.Text + "'", con);
            DataSet SCIDds = new DataSet();
            SelectCourseID.Fill(SCIDds);
            //Main
           if (SCIDds.Tables[0].Rows.Count > 0)
            {
                CourseIdValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][0]);
            }
            SelectSNP.Visible = true;

           
                for (int i = 1; i <= TotalNoOfSemester; i++)
                {
                    SelectSemesterNo.Items.Remove("" + i);
                }
                TotalNoOfSemester = Convert.ToInt32(SCIDds.Tables[0].Rows[0][1]);

                
                for (int i = 1; i <= TotalNoOfSemester; i++)
                {
                    SelectSemesterNo.Items.Add("" + i);
                }

                SqlDataAdapter SelectAllSubjectDetails = new SqlDataAdapter("Select CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectId,SubjectDetails.SubjectName,SubjectDetails.SubjectType,SubjectDetails.SubjectOptCom From SubjectDetails Inner Join SemesterDetailsN On (SemesterDetailsN.SemesterId=SubjectDetails.SemesterId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Where CourseDetails.CourseName='" +SelectCourse.SelectedItem.Text + "'", con);
                DataSet SASDds = new DataSet();
                SelectAllSubjectDetails.Fill(SASDds);
                DisplaySubjectDetais(SASDds);
              
            }

        }

        protected void SelectSemesterNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectSemesterNo.SelectedIndex > 0)
            {
                SqlDataAdapter SelectSemesterIdValue = new SqlDataAdapter("Select SemesterId From SemesterDetailsN Where SemesterNo='" + SelectSemesterNo.SelectedItem.Text + "' AND CourseId='" + CourseIdValue + "'", con);
                DataSet SSIDVds = new DataSet();
                SelectSemesterIdValue.Fill(SSIDVds);
              //Main
                if (SSIDVds.Tables[0].Rows.Count > 0)
                {
                    SemesterIdValue = Convert.ToInt32(SSIDVds.Tables[0].Rows[0][0]);
                }

                SelectSubNP.Visible = true;
                SqlDataAdapter SelectSemesterSubjects = new SqlDataAdapter("Select SubjectName From SubjectDetails Where SemesterId='" + SemesterIdValue + "'", con);
                DataSet SSSds = new DataSet();
                SelectSemesterSubjects.Fill(SSSds);
                SelectSubjectName.DataSource = SSSds;
                SelectSubjectName.DataTextField = "SubjectName";
                SelectSubjectName.DataValueField = "SubjectName";
                SelectSubjectName.DataBind();
                SelectSubjectName.Items.Insert(0, "Select...");




                SqlDataAdapter SelectAllSubjectDetails = new SqlDataAdapter("Select CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectId,SubjectDetails.SubjectName,SubjectDetails.SubjectType,SubjectDetails.SubjectOptCom From SubjectDetails Inner Join SemesterDetailsN On (SemesterDetailsN.SemesterId=SubjectDetails.SemesterId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Where SemesterDetailsN.SemesterID='" + SemesterIdValue + "'", con);
                DataSet SASDds = new DataSet();
                SelectAllSubjectDetails.Fill(SASDds);
                DisplaySubjectDetais(SASDds);
            }
            else
            {
                SelectSubNP.Visible = false;

            }
        }

       

        protected void SelectSubjectName_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (SelectSubjectName.SelectedIndex > 0)
            {
                SqlDataAdapter SelectAllSubjectDetails = new SqlDataAdapter("Select CourseDetails.CourseName,SemesterDetailsN.SemesterNo,SubjectDetails.SubjectId,SubjectDetails.SubjectName,SubjectDetails.SubjectType,SubjectDetails.SubjectOptCom From SubjectDetails Inner Join SemesterDetailsN On (SemesterDetailsN.SemesterId=SubjectDetails.SemesterId) Inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Where SubjectDetails.SubjectName='" + SelectSubjectName.SelectedItem.Text + "' AND SemesterDetailsN.SemesterId='"+SemesterIdValue+"'", con);
                DataSet SASDds = new DataSet();
                SelectAllSubjectDetails.Fill(SASDds);
                DisplaySubjectDetais(SASDds);
            }
        }
    }
}