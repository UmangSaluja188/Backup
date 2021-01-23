using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem.StudentView
{
    public partial class ViewPersonalDetails : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static int StudentId1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["StudentId"] != null)
                {
                    StudentId1 = Convert.ToInt32(Session["StudentId"]);
                    SqlDataAdapter SelectStuds = new SqlDataAdapter("Select *,SemesterDetailsN.SemesterNo,CourseDetails.CourseName,StudentAddress.* From StudentDetails Inner Join SemesterDetailsN On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join StudentAddress On(StudentDetails.StudentId=StudentAddress.StudentId) Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Where StudentDetails.StudentId='" + StudentId1 + "' ", con);
                    DataSet ds = new DataSet();
                    SelectStuds.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Roll.Text = ds.Tables[0].Rows[0][0].ToString();
                        Name.Text = ds.Tables[0].Rows[0][1].ToString();
                        Father.Text = ds.Tables[0].Rows[0][2].ToString();
                        MotherName.Text = ds.Tables[0].Rows[0][3].ToString();
                        ContactNo.Text = ds.Tables[0].Rows[0][4].ToString();
                        RollNo.Text = ds.Tables[0].Rows[0][10].ToString();
                        Image1.ImageUrl = ds.Tables[0].Rows[0][6].ToString();
                        DateOfBirth.Text = Convert.ToDateTime(ds.Tables[0].Rows[0][7].ToString()).ToString("dd/MM/yyyy");
                        Gender.Text = ds.Tables[0].Rows[0][8].ToString();
                        Email.Text = ds.Tables[0].Rows[0][9].ToString();
                        Course.Text = ds.Tables[0].Rows[0][16].ToString()+ ds.Tables[0].Rows[0][12].ToString();
                        State.Text = ds.Tables[0].Rows[0][23].ToString();
                        District.Text = ds.Tables[0].Rows[0][22].ToString();
                        Teh.Text = ds.Tables[0].Rows[0][21].ToString();
                        City.Text = ds.Tables[0].Rows[0][20].ToString();
                        PinCode.Text = ds.Tables[0].Rows[0][24].ToString();
                    }
                    SqlDataAdapter SelSub = new SqlDataAdapter("Select SubjectDetails.SubjectName From SubjectDetails Inner Join SubAllByStu On(SubAllByStu.SubjectId=SubjectDetails.SubjectId) Inner Join StudentDetails On(SubAllByStu.StudentId=StudentDetails.StudentId)Where SubAllByStu.StudentId='" + StudentId1+ "'", con);
                    DataSet selSubds = new DataSet();
                    SelSub.Fill(selSubds);
                    if (selSubds.Tables[0].Rows.Count > 0)
                    {
                        SelectedSubject.DataSource = selSubds;
                        SelectedSubject.DataTextField = "SubjectName";
                        SelectedSubject.DataValueField = "SubjectName";
                        SelectedSubject.DataBind();

                    }
                }
                else
                {
                    Response.Redirect("~/LogInFolder/StudentLogIn.aspx");
                }
            }
           
        }

       
   
        

        

        
    }
}