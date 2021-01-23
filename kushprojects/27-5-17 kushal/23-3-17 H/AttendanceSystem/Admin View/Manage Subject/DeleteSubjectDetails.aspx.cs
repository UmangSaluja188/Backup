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
    public partial class DeleteSubjectDetails : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        string SubjectIdNew;
        protected void Page_Load(object sender, EventArgs e)
        {   if (!IsPostBack)
            {
                if (Session["AdminId"] != null)
                {
                        SubjectIdNew = Request.QueryString["SubjectId"];
                        SearchTextbox.Text = SubjectIdNew;
                    
                }
                else
                {
                    Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {

                SqlDataAdapter SearchSubjectId = new SqlDataAdapter("Select SubjectId From SubjectDetails Where SubjectId='" + SearchTextbox.Text + "'", con);
                DataSet SSIDds = new DataSet();
                SearchSubjectId.Fill(SSIDds);
                if (SSIDds.Tables[0].Rows.Count > 0)
                {
                    SqlDataAdapter DeleteSubject = new SqlDataAdapter("Delete SubjectDetails Where SubjectId='" + SearchTextbox.Text + "'", con);
                    DataSet DSds = new DataSet();
                    DeleteSubject.Fill(DSds);

                    Response.Write("<script type=\"text/javascript\">" + "alert('Subject Details Are Successfully Deleted');" + "</script>");

                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">" + "alert('Invalid Search Id');" + "</script>");
                }
            
            SearchTextbox.Text = "";
            Response.Redirect("~/Admin View/Manage Subject/SearchSubjectDetails.aspx");

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin View/Manage Subject/SearchSubjectDetails.aspx");
        }
    }
}