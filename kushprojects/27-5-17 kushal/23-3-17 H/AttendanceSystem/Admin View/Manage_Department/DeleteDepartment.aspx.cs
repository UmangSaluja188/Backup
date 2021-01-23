using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace AttendanceSystem.Mamage_CRI
{
    public partial class DeleteDepartment : System.Web.UI.Page
    {
       static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static int DepartmentIdValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdminId"] != null)
                {
                    try
                    {
                        
                            DepartmentIdValue = Convert.ToInt32(Request.QueryString["DepartmentId"]);
                           
                                Search.Text = DepartmentIdValue.ToString();
                            
                        
                    }
                    catch (Exception err)
                    {
                        Error.Text = err.Message;
                    }
                }
                else
                {
                    Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                lll.Text = "Heee" + DepartmentIdValue;
                SqlDataAdapter DeleteDepartment = new SqlDataAdapter("Delete NewDepartmentDetails Where NDepartmentId like '" +DepartmentIdValue + "'", con);
                DataSet DDds = new DataSet();
                DeleteDepartment.Fill(DDds);
                Response.Write("<script type=\"text/Javascript\">" + "alert('Department Are Successfully Deleted')" + "</script>");
                Search.Text = "";
                Response.Redirect("~/Admin View/Manage_Department/SearchDepartment.aspx");
    }
          catch (Exception err)
            {
                Error.Text = err.Message;
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin View/Manage_Department/SearchDepartment.aspx");
        }
    }
}