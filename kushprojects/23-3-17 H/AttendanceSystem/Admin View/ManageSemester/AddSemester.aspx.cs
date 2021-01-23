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
    public partial class AddSemester : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        static public int SemesterIdValue,CourseIdValue,TotalSemesterValue,SemesterNoValue;
        protected void Page_Load(object sender, EventArgs e)
        {

           
               //Select Semester Id
            if (!IsPostBack)
            {
                if (Session["AdminId"] == null)
                {

                    //Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }
            try
            {
                SqlDataAdapter SelectSemesterId = new SqlDataAdapter("Select Top 1(SemesterId) From SemesterDetailsN Order By SemesterId DESC ", con);
                DataSet SSIDds = new DataSet();
                SelectSemesterId.Fill(SSIDds);
                if (SSIDds.Tables[0].Rows.Count > 0)
                {
                    SemesterIdValue = Convert.ToInt32(SSIDds.Tables[0].Rows[0][0]) + 1;
                    SemesterId.Text = SemesterIdValue.ToString();
                }
                else
                {
                    SemesterIdValue = 301;
                    SemesterId.Text = SemesterIdValue.ToString();
                }
            }
            catch (Exception err)
            {
                Error.Text = "Select Semester Id Portion" + err.Message;
            }
             if (!IsPostBack)
             {
                 //Select Course Name
                 try
                 {
                     SqlDataAdapter SelectCourseName = new SqlDataAdapter("Select  CourseName From CourseDetails", con);
                     DataSet SCNds = new DataSet();
                     SelectCourseName.Fill(SCNds);
                     CourseName.DataSource = SCNds.Tables[0];
                     CourseName.DataTextField = "CourseName";
                     CourseName.DataValueField = "CourseName";
                     CourseName.DataBind();
                     CourseName.Items.Insert(0,"Select Course");
                     SemesterNo.Items.Insert(0, "Select Semester");
                     
                 }
                 catch (Exception err)
                 {
                     Error.Text = "Select Course Name Portion" + err.Message;
                 }
            }
            
        }

        private void SelectSemester()
        {
            //Select Semester No
            try
            {
                SqlDataAdapter SelectCourseID = new SqlDataAdapter("Select CourseId,TotalNoOfSemester From CourseDetails Where CourseName='" + CourseName.SelectedItem.Text + "'", con);
                DataSet SCIDds = new DataSet();
                SelectCourseID.Fill(SCIDds);
                CourseIdValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][0]);
                for (int i = 1; i <= SemesterNoValue; i++)
                {
                    SemesterNo.Items.Remove("" + i);
                }
                SemesterNoValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][1]);

                for (int i = 1; i <= SemesterNoValue; i++)
                {
                    SemesterNo.Items.Add("" + i);
                }
            }
            catch (Exception err)
            {
                Error.Text = "Select Semester No Portion" + err.Message;
            }
        }

        protected void ADD_Click(object sender, EventArgs e)
        {

                //Insert Semester Values
                try
                {
                    SqlDataAdapter CheckDuplicate = new SqlDataAdapter("Select * From SemesterDetailsN Where SemesterNo='" + SemesterNo.SelectedItem.Text + "'AND CourseId='" + CourseIdValue + "'", con);
                    DataSet ds=new DataSet();
                    CheckDuplicate.Fill(ds);
                    if(ds.Tables[0].Rows.Count==0)
                    {

                    SqlDataAdapter InsertSemesterValues = new SqlDataAdapter("Insert Into SemesterDetailsN (SemesterId,CourseId,SemesterNo,SemesterDuration,TotalNoOfSubjects,SemesterStartingDate,SemesterEndingDate) Values('" + SemesterIdValue + "','" + CourseIdValue + "','" + SemesterNo.SelectedItem.Text + "','" + SemesterDuration.Text + "','" + TotalNoOfSubject.Text + "','" + SemesterStartingDate.Text + "','" + SemesterEndingDate.Text + "')", con);
                    DataSet ISVds = new DataSet();
                    InsertSemesterValues.Fill(ISVds);
                    SemesterId.Text = (SemesterIdValue + 1).ToString();
                    Response.Write("<script type=\"text/javascript\">" + "alert('The Record Are Successfully Inserted');" + "</script>");

                    reset();
                    }
                    else
                    {
                         Response.Write("<script type=\"text/javascript\">" + "alert('These record are already present in the database');" + "</script>");

                    }

                }
                catch (Exception err)
                {
                    Error.Text = "Select Insert Semester Details Values Portion" + err.Message;
                }
            
        }

        private void reset()
        {
            SemesterDuration.Text = "";
            SemesterStartingDate.Text = "";
            SemesterEndingDate.Text = "";
            TotalNoOfSubject.Text = "";
            CourseName.SelectedIndex = -1;
            for (int i = 1; i <= SemesterIdValue; i++)
            {
                SemesterNo.Items.Remove("" + i);
            }

        }

        protected void CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectSemester();
        }

        protected void CANCEL_Click(object sender, EventArgs e)
        {
             reset();
             Response.Redirect("~/Admin View/ManageSemester/SearchSemester.aspx");
        }

        protected void Check_Click(object sender, EventArgs e)
        {
            int value=CheckDuplicate();
        }

        private int  CheckDuplicate()
        {
            SqlDataAdapter CheckDuplicateSemester = new SqlDataAdapter("Select SemesterId From SemesterDetailsN Where CourseId='" + CourseIdValue + "' AND SemesterNo='" + SemesterNo.SelectedItem.Text + "'", con);
            DataSet CheckDuplicateds = new DataSet();
            CheckDuplicateSemester.Fill(CheckDuplicateds);
            if (CheckDuplicateds.Tables[0].Rows.Count > 0)
            {
                Error.Text = "Selected Semester Details Are Already Present";
            }
            return 1;
        }

        protected void SemesterStartingDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SemesterEndingDate_TextChanged(object sender, EventArgs e)
        {
            int Duration;
            DateTime StartingDate1 = new DateTime();
            DateTime EndingDate1 = new DateTime();
            if (SemesterStartingDate.Text != "" && SemesterEndingDate.Text != "")
            {
                StartingDate1 = Convert.ToDateTime(SemesterStartingDate.Text);
                EndingDate1 = Convert.ToDateTime(SemesterEndingDate.Text);
                Duration = EndingDate1.Month- StartingDate1.Date.Month;
                SemesterDuration.Text = Duration.ToString();
            }
        }
    }
}