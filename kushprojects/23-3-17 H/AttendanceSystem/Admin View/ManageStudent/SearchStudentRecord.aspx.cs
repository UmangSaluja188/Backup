using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AttendanceSystem.AdminPage
{
    public partial class SearchStudentRecord : System.Web.UI.Page
    {
        static int RollNo1 = 0;
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Search_Click(object sender, EventArgs e)
        {
            if (Name.Text != "")
            {
                SqlDataAdapter SearchStudent = new SqlDataAdapter("Select StudentName From StudentDetails Where StudentName='" + Name.Text + "'", con);
                DataSet SSIDds = new DataSet();
                SearchStudent.Fill(SSIDds);
                if (SSIDds.Tables[0].Rows.Count > 0)
                {
                    SqlCommand com = new SqlCommand("Select StudentDetails.*,SemesterDetailsN.*,CourseDetails.CourseName  from StudentDetails INNER JOIN SemesterDetailsN ON (StudentDetails.SemesterID=SemesterDetailsN.SemesterId) INNER JOIN CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId)   where StudentDetails.StudentName like @ABC ", con);

                    com.Parameters.AddWithValue("@ABC", Name.Text);
                    con.Open();
                    SqlDataReader red = com.ExecuteReader();

                    datalist1.DataSource = red;

                    datalist1.DataBind();
                    con.Close();
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">" + "alert('Invalid Student Name');" + "</script>");
                    Name.Text = "";
                }

            }

        }

        protected void Search1_Click(object sender, EventArgs e)
        {
            if (RollNo.Text != "")
            {
                SqlDataAdapter SearchStudent = new SqlDataAdapter("Select StudentId From StudentDetails Where StudentId='" + RollNo.Text + "'", con);
                DataSet SSIDds = new DataSet();
                SearchStudent.Fill(SSIDds);
                if (SSIDds.Tables[0].Rows.Count > 0)
                {
                    SqlCommand com = new SqlCommand("Select StudentDetails.*,SemesterDetailsN.*,CourseDetails.CourseName  from StudentDetails INNER JOIN SemesterDetailsN ON (StudentDetails.SemesterID=SemesterDetailsN.SemesterId) INNER JOIN CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId)   where StudentDetails.StudentId like @ABC  ", con);
                    com.Parameters.AddWithValue("@ABC", RollNo.Text);
                    con.Open();
                    SqlDataReader red = com.ExecuteReader();

                    datalist1.DataSource = red;

                    datalist1.DataBind();
                    con.Close();
                    SqlCommand com2 = new SqlCommand("Select SubAllByStu.*,SubjectDetails.* from SubAllByStu INNER JOIN SubjectDetails ON(SubAllByStu.SubjectId=SubjectDetails.SubjectId) where SubAllByStu.StudentId like'" + RollNo.Text + "'", con);
                    con.Open();
                    SqlDataReader red2 = com2.ExecuteReader();

                    SelectedSubject2.DataSource = red2;

                    SelectedSubject2.DataBind();
                    con.Close();
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">" + "alert('Invalid Search Id');" + "</script>");
                    RollNo.Text = "";
                }
            }
        }
    }
}