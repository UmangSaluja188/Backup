using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace AttendanceSystem.AdminPage
{
    public partial class DeleteStudentRecord : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static int StudentId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdminId"] == null)
                {

                    Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }
            StudentId = Convert.ToInt32(Request.QueryString["StudentId"]);
            TextBox1.Text = StudentId.ToString();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            //Delete Student Details
            try
            {
                SqlCommand com = new SqlCommand("Delete StudentDetails Where StudentId='"+StudentId+"'", con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                Response.Write("<script type=\"text/javascript\">" +
            "var abc=window.confirm('Are you sure');" +
                    "if(abc){" +
            "alert('Student Account are successfully deleted');" +
    "}" +
          "</script>");
                Response.Redirect("~/Admin View/ManageStudent/SearchStudentDetails2.aspx");
            }
            catch (Exception err)
            {
                Error.Text = "Delete Student Details Portiuon " + err.Message;
            }
            
        }

        protected void DeleteAllData_Click(object sender, EventArgs e)
        {
            //Delete All Data
            try
            {
                SqlDataAdapter DeleteAllData = new SqlDataAdapter("Truncate Table StudentDetails", con);
                DataSet DADds = new DataSet();
                DeleteAllData.Fill(DADds);
            }
            catch (Exception err)
            {
                Error.Text = "Check All Data Portiuon " + err.Message;
            }
            
        }

        
       
    }
}