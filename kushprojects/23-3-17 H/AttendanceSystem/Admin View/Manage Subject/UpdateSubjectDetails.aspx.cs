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

    public partial class UpdateDetails : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static int SubjectIdValue, SemesterIdValue, CourseIdValue, SemesterNoValue;
        public static string SubjectNameValue, SubjectTypeValue, SubjectOCValue, CourseNameValue;
        public static int CourseIdValue1, SemesterNoValue1, SemesterIdValue1;
        public static string SubjectIdNew;
        protected void Page_Load(object sender, EventArgs e)
        {
               if (!IsPostBack)
            {
                if (Session["AdminId"] != null)
                {
            try
            {
               
                    SubjectIdNew = Request.QueryString["SubjectId"];
                    if (!IsPostBack)
                    {
                        DefaultValues();
                        EnabledOrDisabled(false);
                        if (SubjectIdNew != "")
                        {
                            UpdateSubjectDetails();
                        }
                        CourseName.Items.Insert(0, "Select...");
                        SemesterNo.Items.Insert(0, "Select...");

                    
                }
            }
            catch (Exception err)
            {
                Error.Text = "Page Load " + err.Message;
            }
                }
                else
                {
                   
                }
            }
        }

        private void DefaultValues()
        {
            //Select Course Name 
            try{
            SqlDataAdapter SelectCourseName = new SqlDataAdapter("Select Distinct CourseName From CourseDetails", con);
            DataSet SCNds = new DataSet();
            SelectCourseName.Fill(SCNds);
            CourseName.DataSource = SCNds.Tables[0];
            CourseName.DataTextField = "CourseName";
            CourseName.DataValueField = "CourseName";
            CourseName.DataBind();
            con.Close();
            }
            catch (Exception err)
            {
                Error.Text = "Select Course  Name Portion " + err.Message;
            }

            //Select Course Id and total Semester
            try
            {
                SqlDataAdapter SelectCourseID = new SqlDataAdapter("Select CourseId,TotalNoOfSemester From CourseDetails Where CourseName='" + CourseName.SelectedItem.Text + "'", con);
                DataSet SCIDds = new DataSet();
                SelectCourseID.Fill(SCIDds);
                CourseIdValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][0]);
                SemesterNoValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][1]);
                for (int i = 1; i <= SemesterNoValue; i++)
                {
                    SemesterNo.Items.Remove("" + i);
                }
                for (int i = 1; i <= SemesterNoValue; i++)
                {
                    SemesterNo.Items.Add("" + i);

                }
                SubjectId.Text = "";
                SubjectName.Text = "";
                SubjectType.SelectedIndex = 0;
                SubjectOC.SelectedIndex = 1;
            }
            
            catch (Exception err)
            {
                Error.Text = "Select Course Id And Total Semester Portion " + err.Message;
            }
        }

            private void UpdateSubjectDetails()
            {
             //Select All Subject Details
            int CSelctedIn = 0, SSelectedIn = 0, SubSelectIn = 0, SubOCSelectedIn = 0, i = 0, j = 0, k = 0, l = 0;
            try
            {
                SqlDataAdapter SearchSubject = new SqlDataAdapter("Select * From SubjectDetails Where SubjectId='" + SubjectIdNew + "'", con);
                DataSet SSDds = new DataSet();
                SearchSubject.Fill(SSDds);
                if (SSDds.Tables[0].Rows.Count > 0)
                {
                    EnabledOrDisabled(true);
                    SubjectIdValue = Convert.ToInt32(SSDds.Tables[0].Rows[0][0]);
                    SemesterIdValue = Convert.ToInt32(SSDds.Tables[0].Rows[0][2]);
                    SubjectNameValue = Convert.ToString(SSDds.Tables[0].Rows[0][1]);
                    SubjectTypeValue = Convert.ToString(SSDds.Tables[0].Rows[0][3]);
                    SubjectOCValue = Convert.ToString(SSDds.Tables[0].Rows[0][4]);

                    SqlDataAdapter SelectCourseId = new SqlDataAdapter("Select CourseId,SemesterNo From SemesterDetailsN Where SemesterId='" + SemesterIdValue + "'", con);
                    DataSet SCIds = new DataSet();
                    SelectCourseId.Fill(SCIds);
                    if (SCIds.Tables[0].Rows.Count > 0)
                    {
                        CourseIdValue = Convert.ToInt32(SCIds.Tables[0].Rows[0][0]);
                        SemesterNoValue = Convert.ToInt32(SCIds.Tables[0].Rows[0][1]);
                    }

                    SqlDataAdapter SelectCourseName = new SqlDataAdapter("Select CourseName From CourseDetails Where CourseId='" + CourseIdValue + "'", con);
                    DataSet SCNds = new DataSet();
                    SelectCourseName.Fill(SCNds);

                    if (SCNds.Tables[0].Rows.Count > 0)
                    {
                        CourseNameValue = Convert.ToString(SCNds.Tables[0].Rows[0][0]);
                    }
                    Response.Write("cOURSE nAME" + CourseNameValue);
                    SubjectId.Text = SubjectIdValue.ToString();
                    SubjectName.Text = SubjectNameValue;

                    foreach (ListItem items in CourseName.Items)
                    {
                        if (items.Text == CourseNameValue)
                        {
                            CSelctedIn = i;
                        }
                        i++;
                    }
                    foreach (ListItem items in SemesterNo.Items)
                    {
                        if (items.Text == SemesterNoValue.ToString())
                        {
                            SSelectedIn = j;
                        }
                        j++;
                    }
                    foreach (ListItem items in SubjectType.Items)
                    {
                        if (items.Text == SubjectTypeValue)
                        {
                            SubSelectIn = k;
                        }
                        k++;
                    }
                    foreach (ListItem items in SubjectOC.Items)
                    {
                        if (items.Text == SubjectOCValue)
                        {
                            SubOCSelectedIn = l;
                        }
                        l++;
                    }

                    CourseName.SelectedIndex = CSelctedIn;
                    SemesterNo.SelectedIndex = SSelectedIn;
                    SubjectType.SelectedIndex = SubSelectIn;
                    SubjectOC.SelectedIndex = SubOCSelectedIn;
                }
            
                }
            catch (Exception err)
            {
                Error.Text = "Select All Subject Details  Portion " + err.Message;
            }
        }

        protected void SemesterNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Semester Id
            try
            {
                SqlDataAdapter SelectSemesterId1 = new SqlDataAdapter("Select SemesterId From SemesterDetailsN Where SemesterNo='" + SemesterNo.SelectedItem.Text + "' AND CourseId='" + CourseIdValue + "'", con);
                DataSet SSIDds1 = new DataSet();
                SelectSemesterId1.Fill(SSIDds1);
                SemesterIdValue = Convert.ToInt32(SSIDds1.Tables[0].Rows[0][0]);
            }
            
            catch (Exception err)
            {
                Error.Text = "Select Semester Id Portion " + err.Message;
            }
        }

        protected void CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                SqlDataAdapter SelectCourseID = new SqlDataAdapter("Select CourseId,TotalNoOfSemester From CourseDetails Where CourseName='" + CourseName.SelectedItem.Text + "'", con);
                DataSet SCIDds = new DataSet();
                SelectCourseID.Fill(SCIDds);
                CourseIdValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][0]);

                SemesterNoValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][1]);
                for (int i = 1; i <= SemesterNoValue; i++)
                {
                    SemesterNo.Items.Remove("" + i);
                }
                for (int i = 1; i <= SemesterNoValue; i++)
                {
                    SemesterNo.Items.Add("" + i);

                }
            }
            
            catch (Exception err)
            {
                Error.Text = "Select Course Id Portion " + err.Message;
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            // Update Subject Details
            try
            {
                SqlDataAdapter UpdateSubject = new SqlDataAdapter("Update SubjectDetails Set SubjectName='" + SubjectName.Text + "',SemesterId='" + SemesterIdValue + "',SubjectType='" + SubjectType.SelectedItem.Text + "',SubjectOptCom='" + SubjectOC.SelectedItem.Text + "' Where SubjectId='" + SubjectIdValue + "'", con);
                DataSet UDSds = new DataSet();
                UpdateSubject.Fill(UDSds);

                Response.Write("<script type=\"text/javascript\">" + "alert('Updation are successfully perform');" + "</script>");

                EnabledOrDisabled(false);
                Response.Redirect("~/Admin View/Manage Subject/SearchSubjectDetails.aspx");
            }
            catch (Exception err)
            {
                Error.Text = "Update Subject Details " + err.Message;
            }
        }

        private void EnabledOrDisabled(bool p)
        {

            DefaultValues();
            CourseName.Enabled = p;
            SemesterNo.Enabled = p;
            SubjectName.Enabled = p;
            SubjectType.Enabled = p;
            SubjectOC.Enabled = p;
            Update.Enabled = p;
            Cancel.Enabled = p;

        }

        protected void CANCEL_Click(object sender, EventArgs e)
        {
            UpdateSubjectDetails();

        }
    }
}