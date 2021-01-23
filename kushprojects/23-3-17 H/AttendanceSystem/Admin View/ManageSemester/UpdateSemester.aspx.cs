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
    public partial class UpdateSemester : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        static public int CourseIdValue, SemesterNoValue, SemesterNoValue2,CourseIdValue2,SemesterIDValue;
        public string CourseName2;
        static int selectedIndex1 = 0, selectedindex2 = 0;
        string SemesterIdValueNew;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Query String
            if (!IsPostBack)
            {
                if (Session["AdminId"] == null)
                {

                    //Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }
            try
            {
                SemesterIdValueNew = Request.QueryString["SemesterId"];
                if (!IsPostBack)
                {
                    enabledDisabled(true);
                    if (SemesterIdValueNew != "")
                    {
                        UpdateSemesterDetails();
                    }
                    CourseName.Items.Insert(0, "Select..");
                    SemesterNo.Items.Insert(0, "Select..");
                }
            }
            catch (Exception err)
            {
                Error.Text = "Query String "+err.Message;
            }
        }

       private void UpdateSemesterDetails()
       {
            //Search All Semester Details
           try
           {
               SqlDataAdapter SearchSemesterDetails = new SqlDataAdapter("Select SemesterId,SemesterNo,SemesterDuration,Convert(NVARCHAR(10),SemesterDetailsN.SemesterStartingDate,103),Convert(NVARCHAR(10),SemesterDetailsN.SemesterEndingDate,101),TotalNoOfSubjects,CourseId From SemesterDetailsN Where SemesterId='" + SemesterIdValueNew + "'", con);
               DataSet SSDetailsDds = new DataSet();
               SearchSemesterDetails.Fill(SSDetailsDds);
               if (SSDetailsDds.Tables[0].Rows.Count != 0)
               {
                   enabledDisabled(true);
                   SqlDataAdapter SelectCourseName = new SqlDataAdapter("Select CourseName From CourseDetails", con);
                   DataSet SCNds = new DataSet();
                   SelectCourseName.Fill(SCNds);
                   CourseName.DataSource = SCNds.Tables[0];
                   CourseName.DataTextField = "CourseName";
                   CourseName.DataValueField = "CourseName";
                   CourseName.DataBind();

                   SemesterId.Text = Convert.ToString(SSDetailsDds.Tables[0].Rows[0][0]);
                   SemesterDuration.Text = Convert.ToString(SSDetailsDds.Tables[0].Rows[0][2]);
                   SemesterStartingDate.Text = Convert.ToString(SSDetailsDds.Tables[0].Rows[0][3]);
                   SemesterEndingDate.Text = Convert.ToString(SSDetailsDds.Tables[0].Rows[0][4]);
                   TotalNoOfSubject.Text = Convert.ToString(SSDetailsDds.Tables[0].Rows[0][5]);
                   SemesterNoValue = Convert.ToInt32(SSDetailsDds.Tables[0].Rows[0][1]);

                   CourseIdValue = Convert.ToInt32(SSDetailsDds.Tables[0].Rows[0][6]);
                   Response.Write(CourseIdValue);
                   SqlDataAdapter SelectCourseNAndSN = new SqlDataAdapter("Select CourseName,TotalNoOfSemester From CourseDetails Where CourseId='" + CourseIdValue + "'", con);
                   DataSet SSNds = new DataSet();
                   SelectCourseNAndSN.Fill(SSNds);

                   CourseName2 = Convert.ToString(SSNds.Tables[0].Rows[0][0]);
                   Response.Write(CourseName2);
                   int value = 0, selectedindex = 0;
                   foreach (ListItem itemValue in CourseName.Items)
                   {
                       if (itemValue.Text == CourseName2)
                       {
                           selectedindex = value;
                       }
                       value++;
                   }
                   CourseName.SelectedIndex = selectedindex;
                   Response.Write(selectedindex2);
                   SemesterNoValue2 = Convert.ToInt32(SSNds.Tables[0].Rows[0][1]);
                   for (int i = 1; i <= SemesterNoValue2; i++)
                   {
                       SemesterNo.Items.Add("" + i);
                   }
                   int v = 0, selectedindex3 = 0;
                   foreach (ListItem itemsValue in SemesterNo.Items)
                   {
                       if (itemsValue.Text == SemesterNoValue.ToString())
                       {
                           selectedindex3 = v;
                       }
                       v++;

                   }
                   SemesterNo.SelectedIndex = selectedindex3;
               }
               else
               {
                   Response.Write("<script type\"=text/javascript\">" + "alert('Invalid Searching Id');" + "</script>");
               }
           }
           catch (Exception err)
           {
               Error.Text = "Search All Semester Details " + err.Message;
           }
            }

        private void reset()
        {
            SemesterId.Text = "";
            SemesterStartingDate.Text = "";
            SemesterEndingDate.Text = "";
            SemesterDuration.Text = "";
            TotalNoOfSubject.Text = "";
            CourseName.SelectedIndex = -1;
            SemesterNo.SelectedIndex = -1;
            for (int i = 1; i <= SemesterNoValue2; i++)
            {
                SemesterNo.Items.Remove("" + i);
            }

        }
        
        protected void UPDATE_Click(object sender, EventArgs e)
        {
            //Update Semester Details
            try
            {
                SqlDataAdapter UpdateSemester = new SqlDataAdapter("Update SemesterDetailsN Set SemesterNo='" + SemesterNo.SelectedItem.Text + "',SemesterDuration='" + SemesterDuration.Text + "',SemesterStartingDate='" + SemesterStartingDate.Text + "',SemesterEndingDate='" +SemesterEndingDate.Text + "',CourseId='" + CourseIdValue + "',TotalNoOfSubjects='" + TotalNoOfSubject.Text + "' Where SemesterId='" + SemesterId.Text + "'", con);
                DataSet USds = new DataSet();
                UpdateSemester.Fill(USds);
                Response.Write("<script type\"=text/javascript\">" + "alert('Semester Record Are Successfully Updated');" + "</script>");
                reset();
                enabledDisabled(false);
                Response.Redirect("~/Admin View/ManageSemester/SearchSemester.aspx");
            }
            catch (Exception err)
            {
                Error.Text = "Update Semester Details Portion " + err.Message;
            }
        }

        protected void CANCEL_Click(object sender, EventArgs e)
        {
            UpdateSemesterDetails();
            //Response.Redirect("~/Admin View/ManageSemester/SearchSemester.aspx");

        }

        protected void SemesterNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Course id
            try
            {
                SqlDataAdapter SelectCourseId = new SqlDataAdapter("Select CourseId From CourseDetails Where CourseName ='" + CourseName.SelectedItem.Text + "'", con);
                DataSet SCIDds = new DataSet();
                SelectCourseId.Fill(SCIDds);
                CourseIdValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][0]);
            }
            catch (Exception err)
            {
                Error.Text = "Select Coures id Portion " + err.Message;
            }
            
        }

        private void enabledDisabled(bool p)
        {
           
            SemesterNo.Enabled = p;
            CourseName .Enabled = p;
            SemesterDuration.Enabled = p;

            SemesterStartingDate.Enabled = p;

            SemesterEndingDate.Enabled = p;

            TotalNoOfSubject.Enabled = p;


        }
    }
}