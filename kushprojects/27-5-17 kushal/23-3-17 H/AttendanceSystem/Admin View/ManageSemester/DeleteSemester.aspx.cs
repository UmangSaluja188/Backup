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
    public partial class DeleteSemester : System.Web.UI.Page
    {

        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        string SemesterId;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Query String 
            if (!IsPostBack)
            {
                if (Session["AdminId"] == null)
                {

                    Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }
            try
            {
                SemesterId = Request.QueryString["SemesterId"];
                if (SemesterId != "")
                {
                    SearchTextBox.Text = SemesterId;
                }
            }
            catch (Exception err)
            {
                Error.Text = "Query String Portion" + err.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                //Delete Semester Details
            try
            {
                SqlDataAdapter DeleteSemester = new SqlDataAdapter("Delete SemesterDetailsN  where SemesterId='" + SearchTextBox.Text + "'", con);
                DataSet DSds = new DataSet();
                DeleteSemester.Fill(DSds);
                Response.Write("<script type=\"text/javascript\">" + "alert('Semester Record Are Successfully Deleted');" + "</script>");
                SearchTextBox.Text = "";
                Response.Redirect("~/Admin View/ManageSemester/SearchSemester.aspx");
            }
            catch (Exception err)
            {
                Error.Text = "Delete Semester Details Portion" + err.Message;
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin View/ManageSemester/SearchSemester.aspx");
        }
    }
}