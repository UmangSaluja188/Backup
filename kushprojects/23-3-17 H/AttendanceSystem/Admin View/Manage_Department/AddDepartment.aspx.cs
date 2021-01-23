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
    public partial class AddDepartment : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);

        public static int DepartmentIdValue;
        protected void Page_Load(object sender, EventArgs e)          
        {
            Error.Text = "";
            if (!IsPostBack)
            {
                if (Session["AdminId"] != null)
                {
            try
            {
               
                    SqlDataAdapter Check = new SqlDataAdapter("Select * from NewDepartmentDetails", con);
                    DataSet CHds = new DataSet();
                    Check.Fill(CHds);

                    if (CHds.Tables[0].Rows.Count > 0)
                    {
                        SqlDataAdapter SelectDepartmentId = new SqlDataAdapter("Select MAX(NDepartmentId) from NewDepartmentDetails", con);
                        DataSet SDIds = new DataSet();
                        SelectDepartmentId.Fill(SDIds);
                        DepartmentIdValue = Convert.ToInt32(SDIds.Tables[0].Rows[0][0]) + 1;
                        DepartmentId.Text = DepartmentIdValue.ToString();
                        DepartmentId.Text = DepartmentIdValue.ToString();
                    }
                    else
                    {
                        DepartmentIdValue = 101;
                        DepartmentId.Text = DepartmentIdValue.ToString();
                    }
                
            }
            catch (Exception err)
            {
                Error.Text = err.Message;
            }
                }
                else
                {
                    
                }
            }
            
        }

        private void DisplayRecord()
        {
           
        }

        private void reset()
        {
            DepartmentName.Text = "";
          
        }

        protected void ADD_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter SelectDuplicateDep = new SqlDataAdapter("Select * From NewDepartmentDetails Where NDepartmentName='"+DepartmentName.Text+"'",con);
                DataSet ds = new DataSet();
                SelectDuplicateDep.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    SqlDataAdapter InserIntoDepartment = new SqlDataAdapter("Insert into NewDepartmentDetails (NDepartmentId,NDepartmentName) Values('" + DepartmentId.Text + "','" + DepartmentName.Text + "')", con);
                    DataSet IIDds = new DataSet();
                    InserIntoDepartment.Fill(IIDds);
                    Response.Write("<script type=\"text/javascript\">" + "alert('The Record Are Successfull Insert');" + "</script>");

                    reset();
                    DepartmentIdValue = DepartmentIdValue + 1;
                    DepartmentId.Text = (DepartmentIdValue).ToString();
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">" + "alert('These record  are already present in the database');" + "</script>");

                }
             }
            catch (Exception err)
            {
                Error.Text = err.Message;
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Manage_Department/SearchDepartment.aspx");
        }
    }
}