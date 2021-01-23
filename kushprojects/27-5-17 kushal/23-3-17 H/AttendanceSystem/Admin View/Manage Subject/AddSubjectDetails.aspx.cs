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
    public partial class AddSubjectDetails : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static int CourseIdValue,SemesterNoValue,SubjectIdValue,SemesterIdValue=0,SemesterIdValue2;
        public static string SubjectTypeValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            Error.Text = "";
            //Select Subject Id
            if (!IsPostBack)
            {
                if (Session["AdminId"] != null)
                {
                   
                        try
                        {
                                SqlDataAdapter SelectSubjectId = new SqlDataAdapter("Select Top 1(SubjectId) From SubjectDetails Order By SubjectId DESC ", con);
                                DataSet SSIDds = new DataSet();
                                SelectSubjectId.Fill(SSIDds);
                                if (SSIDds.Tables[0].Rows.Count > 0)
                                {
                                    SubjectIdValue = Convert.ToInt32(SSIDds.Tables[0].Rows[0][0]) + 1;
                                    SubjectId.Text = SubjectIdValue.ToString();
                                }
                                else
                                {
                                    SubjectIdValue = 501;
                                    SubjectId.Text = SubjectIdValue.ToString();
                                }
                            }
                        

                        catch (Exception err)
                        {
                            Error.Text = "Select Subject Id Portion" + err.Message;
                        }

                        //Select Course Name
                        try
                        {
                           
                            
                                if (!IsPostBack)
                                {
                                    SqlDataAdapter SelectCourseName = new SqlDataAdapter("Select CourseName From CourseDetails", con);
                                    DataSet SCNds = new DataSet();
                                    SelectCourseName.Fill(SCNds);
                                    CourseName.DataSource = SCNds.Tables[0];
                                    CourseName.DataTextField = "CourseName";
                                    CourseName.DataValueField = "CourseName";
                                    CourseName.DataBind();
                                    CourseName.Items.Insert(0, "Select Course...");
                                    SemesterNo.Items.Insert(0, "Select Semester...");

                                
                            }
                        }
                        catch (Exception err)
                        {
                            Error.Text = "Select Course Name Portion " + err.Message;
                        }
                        SubjectTypeValue = "Optional";
                    }
                    else
                    {
                        Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                    }
                }
            }
            
        

        private void SelectCourseId()
        {
            //Select Course Id
            try
            {

            SqlDataAdapter SelectCourseID = new SqlDataAdapter("Select CourseId,TotalNoOfSemester From CourseDetails Where CourseName='" + CourseName.SelectedItem.Text + "'", con);
            DataSet SCIDds = new DataSet();
            SelectCourseID.Fill(SCIDds);
            CourseIdValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][0]);
            SemesterNoValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][1]);
            SelectSemesterId();
            }
            catch (Exception err)
            {
                Error.Text = "Select Course Id Portion " + err.Message;
            }
        }

        private void SelectSemesterId()
        {
            for (int i = 1; i <= SemesterNoValue; i++)
            {
                SemesterNo.Items.Remove("" + i);
            }
        
            for (int i = 1; i <= SemesterNoValue; i++)
            {
                SemesterNo.Items.Add("" + i);
            }
           
        }

        private void Select()
        {
          try
            {
                SqlDataAdapter SelectSemesterIdValue = new SqlDataAdapter("Select SemesterId From SemesterDetailsN Where SemesterNo='" + SemesterNo.SelectedItem.Text + "' AND CourseId='" + CourseIdValue + "'", con);
                DataSet SSIDVds = new DataSet();
                SelectSemesterIdValue.Fill(SSIDVds);
               
                    SemesterIdValue2 = Convert.ToInt32(SSIDVds.Tables[0].Rows[0][0]);
                    Response.Write("Hello" + SemesterIdValue2);
                

                Response.Write("Selected Semester No=" + SemesterNo.SelectedItem.Text + " " + CourseIdValue);
            }
            catch (Exception err)
            {
                Error.Text ="Semester Id Portion"+ err.Message;
            }
            
        }
       

       

        protected void SemesterNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Select();
        }

        protected void CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SelectCourseId();

        }

        protected void ADD_Click(object sender, EventArgs e)
        {
            Response.Write("Insert SemesterIdValue=" + SemesterIdValue2);
             //Isert New Subject 
            SqlDataAdapter SelectDupSub = new SqlDataAdapter("Select * From SubjectDetails Where SubjectName='"+SubjectName.Text+"'AND SemesterId='"+SemesterIdValue2+"'",con);
            DataSet ds = new DataSet();
            SelectDupSub.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                try
                {
                    SqlDataAdapter InsertSubject = new SqlDataAdapter("Insert Into SubjectDetails (SubjectId,SemesterId,SubjectName,SubjectType,SubjectOptCom) Values('" + SubjectId.Text + "','" + SemesterIdValue2 + "','" + SubjectName.Text + "','" + SubjectType.SelectedItem.Text + "','" + SubjectOC.SelectedItem.Text + "')", con);
                    DataSet ISds = new DataSet();
                    InsertSubject.Fill(ISds);
                    reset();
                    SubjectId.Text = (SubjectIdValue + 1).ToString();
                    Response.Write("<script type=\"text/javascript\">" + "alert('The Record Are Successfully Inserted');" + "</script>");
                    Response.Redirect("~/Admin View/Manage Subject/SearchSubjectDetails.aspx");
                }
                catch (Exception err)
                {
                    Error.Text = "Select Course Id Portion " + err.Message;
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">" + "alert('These record are already present in the Database');" + "</script>");
            }
         
        }

        protected void CANCEL_Click(object sender, EventArgs e)
        {
            reset();
            Response.Redirect("~/Admin View/Manage Subject/SearchSubjectDetails.aspx");
        }

        private void reset()
        {
            CourseName.SelectedIndex = 0;
            SemesterNo.SelectedIndex = 0;
            SubjectName.Text = "";
            SubjectType.SelectedIndex = 1;
            SubjectOC.SelectedIndex = 1;
        }
        
        protected void SubjectOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubjectTypeValue = SubjectOC.SelectedItem.Text;
        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (CourseName.SelectedIndex >= 0)
            {
                args.IsValid = true;
            }
        }
}
}