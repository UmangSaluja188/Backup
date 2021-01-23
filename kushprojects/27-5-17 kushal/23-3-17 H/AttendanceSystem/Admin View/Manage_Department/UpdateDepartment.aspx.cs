using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AttendanceSystem.Mamage_CRI
{
    public partial class UpdateDepartment : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static string DepartmentIdValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdminId"] != null)
                {

                    
                        DepartmentIdValue = Request.QueryString["DepartmentId"];
                        if (!IsPostBack)
                        {
                            if (DepartmentIdValue != "")
                            {
                                UpdateDepartmentDetails();
                            }

                        }
                        else
                        {
                            Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                        }

                    
                }
            }
        }

         private void UpdateDepartmentDetails()
        {
            
            SqlDataAdapter SearchDepartment = new SqlDataAdapter("Select * From NewDepartmentDetails Where NDepartmentId like'"+DepartmentIdValue+"'",con);
            DataSet SDds = new DataSet();
            SearchDepartment.Fill(SDds);
            if (SDds.Tables[0].Rows.Count != 0)
            {


                DepartmentId.Text = Convert.ToString(SDds.Tables[0].Rows[0][0]);
                DepartmentName.Text = Convert.ToString(SDds.Tables[0].Rows[0][1]);
                DepartmentId.Enabled = false;

            }
            else
            {
                Response.Write("<script type\"=text/javascript\">"+"alert('Invalid DepartmentId')"+"</script>");
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            
            SqlDataAdapter UpdateDepartment = new SqlDataAdapter("Update NewDepartmentDetails Set NDepartmentName='"+DepartmentName.Text+"' Where NDepartmentId='"+DepartmentIdValue+"'",con);
            DataSet UDds = new DataSet();
            UpdateDepartment.Fill(UDds);
            Response.Write("<script type=\"text/javascript\">"+
                "alert('Department Record Are Successfully Updated');"+"</script>");

            //Response.Redirect("~/Admin View/Manage_Department/SearchDepartment.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            UpdateDepartmentDetails();
            //Response.Redirect("~/Admin View/Manage_Department/SearchDepartment.aspx");
        }

        

        protected void DepartmentName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}