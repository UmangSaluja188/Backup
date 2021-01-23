using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AttendanceSystem.ManageCourse
{
    public partial class UpdateCourse : System.Web.UI.Page
    {

        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        static public string CourseTypeValue,DepartmentNameValue;
        static public int DepartmentIdValue, DepartmentIdValue2,i=1,j=1,selectedindex=0,selectedindex2=0;
        public static string CourseIdValue;

        protected void Page_Load(object sender, EventArgs e)
        {

             if (!IsPostBack)
            {
                if (Session["AdminId"] != null)
                {
            //Query String Pass From Search Course Details
                    
                        try
                        {
                            CourseIdValue = Request.QueryString["CourseId"];
                        }
                        catch (Exception err)
                        {
                            Error.Text = "Query String Portion" + err.Message;
                        }
                    
            if (!IsPostBack)
            {
                //Select Department Name
                try
                {
                    SqlCommand com = new SqlCommand("Select * from NewDepartmentDetails", con);
                    con.Open();
                    SqlDataReader red = com.ExecuteReader();
                    Department.DataSource = red;
                    Department.DataTextField = "NDepartmentName";
                    Department.DataValueField = "NDepartmentName";
                    Department.DataBind();
                    con.Close();
                    Department.Items.Insert(0, "Select...");
                    enabledOrDisabled(true);
                    if (CourseIdValue != "")
                    {
                        UpdateCourseDetails();
                    }
                }
                catch (Exception err)
                {
                    Error.Text = "Select Department Name Portion" + err.Message;
                }
            }
                }
                else
                {
                    Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }
           
        }

        public void UpdateCourseDetails()
        {
            //Select All Course Details
            try
            {
                SqlDataAdapter SelectCourseDetails = new SqlDataAdapter("Select * From CourseDetails Where CourseId='" + CourseIdValue + "'", con);
                DataSet SCDds = new DataSet();
                SelectCourseDetails.Fill(SCDds);
                if (SCDds.Tables[0].Rows.Count != 0)
                {
                    Course.Text = Convert.ToString(SCDds.Tables[0].Rows[0][0]);
                    CourseName.Text = Convert.ToString(SCDds.Tables[0].Rows[0][1]);
                    DepartmentIdValue = Convert.ToInt32(SCDds.Tables[0].Rows[0][2]);
                    CourseDuration.Text = Convert.ToString(SCDds.Tables[0].Rows[0][3]);
                    CourseTypeValue = Convert.ToString(SCDds.Tables[0].Rows[0][4]);
                    TotalNoOfSemester.Text = Convert.ToString(SCDds.Tables[0].Rows[0][5]);

                    SqlDataAdapter SelectDepartmentName = new SqlDataAdapter("Select NDepartmentName From NewDepartmentDetails Where NDepartmentId='" + DepartmentIdValue + "'", con);
                    DataSet SDNds = new DataSet();
                    SelectDepartmentName.Fill(SDNds);
                    DepartmentNameValue = Convert.ToString(SDNds.Tables[0].Rows[0][0]);
                    int a=0,b=0;
                   while(a<Department.Items.Count)
                   {
                        if (Department.Items[a].Text == DepartmentNameValue)
                        {
                            selectedindex = a;
                            Response.Write("selectedindex" + selectedindex + "<br>");
                        }
                        a++;
                    }
                   l1.Text = CourseTypeValue.ToString();
                   while (b <CourseTypeN.Items.Count )
                   {
                       if (CourseTypeN.Items[b].Text == CourseTypeValue.Trim())
                       {
                           CourseTypeN.Items[b].Selected = true;
                           break;
                       }
                       b++;
                   }
                 


                    Department.SelectedIndex = selectedindex;
                   

                  
                }

            }
            catch (Exception err)
            {
                Error.Text = "Select All Course Details  Portion" + err.Message;
            }
        }
        private void enabledOrDisabled(bool p)
        {
            Course.Enabled = false;
            CourseName.Enabled = p;
            Department.Enabled = p;
            CourseDuration.Enabled = p;
            CourseTypeN.Enabled = p;
            TotalNoOfSemester.Enabled = p;
            UPDATE.Enabled = p;
            CANCEL.Enabled = p;
        }

          
        

        protected void UPDATE_Click(object sender, EventArgs e)
        {
            //Update Course Details
            try
            {
                SqlDataAdapter UpdateCourse = new SqlDataAdapter("Update CourseDetails Set CourseName='" + CourseName.Text + "',NDepartmentId='" + DepartmentIdValue + "',CourseDuration='" + CourseDuration.Text + "',CourseType='" + CourseTypeN.SelectedItem.Text + "',TotalNoOfSemester='" + TotalNoOfSemester.Text + "'Where CourseId='" + CourseIdValue + "'", con);
                DataSet UCDds = new DataSet();
                UpdateCourse.Fill(UCDds);
                //Response.Write("<script type=\"text/javascript\">" + "alert('Course Record Are Successfully Updated');" + "</script>");
                Response.Redirect("~/Admin View/ManageCourse/SearchCourseDetails.aspx");
            }
            catch (Exception err)
            {
                Error.Text = "Update Course Id Portion" + err.Message;
            }
        }

        private void reset()
        {
            Course.Text = "";
            CourseDuration.Text = "";
            TotalNoOfSemester.Text = "";
            CourseName.Text = "";
            Department.SelectedIndex = -1;
            CourseTypeN.SelectedIndex = -1;
            enabledOrDisabled(false);

        }

        protected void CANCEL_Click(object sender, EventArgs e)
        {
            UpdateCourseDetails();
        }

        protected void Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Department Id
            try
            {
                SqlDataAdapter SelectDepartmentId = new SqlDataAdapter("Select NDepartmentId From NewDepartmentDetails Where NDepartmentName='" + Department.SelectedItem.Text + "'", con);
                DataSet SDIds = new DataSet();
                SelectDepartmentId.Fill(SDIds);
                DepartmentIdValue = Convert.ToInt32(SDIds.Tables[0].Rows[0][0]);
            }
            catch (Exception err)
            {
                Error.Text = "Select Department Id Portion" + err.Message;
            }
        }
    }
}