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
    public partial class AddCourse : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public int CourseIdValue,TotalSemester;
        static public int Dept;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdminId"] != null)
                {
                    //Select Department
                    try
                    {
                        SqlCommand com = new SqlCommand("Select * from NewDepartmentDetails", con);
                        con.Open();
                        SqlDataReader red = com.ExecuteReader();
                        Department.DataSource = red;
                        Department.DataTextField = "NDepartmentName";
                        Department.DataValueField = "NDepartmentName";
                        Department.DataBind();
                        Department.Items.Insert(0, "Select Department...");

                        con.Close();
                    }
                    catch (Exception err)
                    {
                        Error.Text = "Select Department Portion" + err.Message;
                    }
                }
                else
                {
                    //Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }

                //Select Course Id

                SelectCourseId();


            }
               
        }

        private void SelectCourseId()
        {
            try
            {
                SqlDataAdapter SelectCourseId = new SqlDataAdapter("Select Top 1(CourseId) from CourseDetails Order By CourseId DESC", con);
                DataSet SCIds = new DataSet();
                SelectCourseId.Fill(SCIds);
                if (SCIds.Tables[0].Rows.Count != 0)
                {
                    CourseIdValue = Convert.ToInt32(SCIds.Tables[0].Rows[0][0]) + 1;
                    Course.Text = CourseIdValue.ToString();

                }
                else
                {
                    CourseIdValue = 201;
                    Course.Text = CourseIdValue.ToString();
                }
            }
            catch (Exception err)
            {
                Error.Text = "Select Course Id Portion" + err.Message;
            }
        }
        protected void CourseDuration_TextChanged(object sender, EventArgs e)
        {
            
           // TotalSemester = Convert.ToInt32(CourseDuration.Text) * 2;
            //TotalNoOfSemester.Text = TotalSemester.ToString();
        }

        protected void ADD_Click(object sender, EventArgs e)
        {
            //Insert Course Details

            try
            {
                SqlDataAdapter SelectDupSub = new SqlDataAdapter("Select * From CourseDetails Where CourseName='" + CourseName.Text + "'AND NDepartmentId='" + Dept + "'", con);
                DataSet ds = new DataSet();
                SelectDupSub.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    SqlDataAdapter InsertCourse = new SqlDataAdapter("Insert into CourseDetails (CourseId,CourseName,NDepartmentId,CourseDuration,CourseType,TotalNoOfSemester) Values ('" + Course.Text + "','" + CourseName.Text + "','" + Dept + "','" + CourseDuration.Text + "','" + CourseTypeN.SelectedItem.Text + "','" + TotalNoOfSemester.Text + "')", con);
                    DataSet ICds = new DataSet();
                    InsertCourse.Fill(ICds);
                    Response.Write("<script type=\"text/javascript\">" + "alert('The Record Are Successfull Insert');" + "</script>");
                   
                    reset();
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">" + "alert('These record are already present in the database');" + "</script>");

                }
            }
           

            catch (Exception err)
            {
                Error.Text = "Insert Course Details Portion" + err.Message;
            }
        }

        private void reset()
        {
            Department.SelectedIndex = -1;
            CourseName.Text = "";
            CourseDuration.Text = "";
            TotalNoOfSemester.Text = "";
            CourseTypeN.SelectedIndex = -1;
            SelectCourseId();
            
        }


        protected void Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectDepartmenTId();
        }

        private void SelectDepartmenTId()
        {
            //Select Department Id
            try
            {
                SqlDataAdapter SelectDepartmentId = new SqlDataAdapter("Select NDepartmentId From NewDepartmentDetails Where NDepartmentName ='" + Department.SelectedItem.Text + "'", con);
                DataSet SDIds = new DataSet();
                SelectDepartmentId.Fill(SDIds);
                if (SDIds.Tables[0].Rows.Count > 0)
                {
                    Dept = Convert.ToInt32(SDIds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception err)
            {
                Error.Text = "Select Department Id Portion" + err.Message;
            }
        }

        protected void CANCEL_Click(object sender, EventArgs e)
        {
            reset();
            Response.Redirect("../ManageCourse/SearchCourseDetails.aspx");
        }
    }
}