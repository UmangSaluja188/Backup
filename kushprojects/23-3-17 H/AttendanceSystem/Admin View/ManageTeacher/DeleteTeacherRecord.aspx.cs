using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace AttendanceSystem.ManageTeacher
{
    public partial class DeleteTeacherRecord : System.Web.UI.Page
    {
       public  string TeacherIdValue;
       static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
       SqlConnection con = new SqlConnection(cs);
       protected void Page_Load(object sender, EventArgs e)
       {
           if (!IsPostBack)
           {
               if (Session["AdminId"] == null)
               {

                   //Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
               }
           }

           //Query String
           try
           {
               TeacherIdValue = Request.QueryString["TeacherId"];
               TextBox1.Text = TeacherIdValue;
           }
           catch (Exception err)
           {
               Error.Text = "Query String Portion " + err.Message;
           }
       }
        

        
         

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin View/ManageTeacher/SearchTeacherRecord.aspx");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            //Delete Teacher Details
            try
            {

                if (TeacherIdValue != "")
                {
                    TextBox1.Text = TeacherIdValue;
                    SqlCommand com = new SqlCommand("Delete TeacherDetails where TeacherId like'" + TeacherIdValue + "'", con);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script type=\"text/javascript\">" +
              "var abc=window.confirm('Are you sure');" +
                      "if(abc){" +
              "alert('Teacher Account are successfully deleted');" +
      "}" +
            "</script>");
                }
            }
            catch (Exception err)
            {
                Error.Text = "Delete Teacher Details Portion " + err.Message;
            }
            Response.Redirect("~/Admin View/ManageTeacher/SearchTeacherRecord.aspx");
        }
        }

        }
    
