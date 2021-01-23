using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AttendanceSystem.Manage_Department
{
    public partial class SearchDepartment : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public DataSet SDDds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Session["AdminId"] == null)
                {
                    //Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }

                    try
                    {
                        
                            SqlDataAdapter SelectDepartmentDet = new SqlDataAdapter("Select * from NewDepartmentDetails", con);
                            SelectDepartmentDet.Fill(SDDds);
                            DisplayDD(SDDds);
                        
                    }
                    catch (Exception err)
                    {
                        Error.Text = err.Message;
                    }
               
            }

         

        private void DisplayDD(DataSet Source)
        {
            try
            {
                ShowDepartmentDetails.DataSource = Source;
                ShowDepartmentDetails.DataBind();
                if (ShowDepartmentDetails.Columns.Count > 0)
                {
                    ShowDepartmentDetails.HeaderRow.Cells[2].Text = "Department Id";
                    ShowDepartmentDetails.HeaderRow.Cells[3].Text = "Department Name";
                }
            }
            catch (Exception err)
            {
                Error.Text = err.Message;
            }
        }


        protected void ShowAllDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SelectOption.SelectedItem.Text == "Department Name")
                {
                    ByName.Visible = true;
                    ById.Visible = false;
                    if (SDDds.Tables[0].Rows.Count > 0)
                    {
                        SelectDepartmentName.DataSource = SDDds;
                        SelectDepartmentName.DataTextField = "NDepartmentName";
                        SelectDepartmentName.DataValueField = "NDepartmentName";
                        SelectDepartmentName.DataBind();
                        SelectDepartmentName.Items.Insert(0, "Select...");
                        SelectDepartmentName.SelectedIndex = 0;
                        DepartmentId.Text = "";
                    }
                }
                else if (SelectOption.SelectedItem.Text == "Department Id")
                {
                    ByName.Visible = false;
                    ById.Visible = true;

                }
            }
            catch (Exception err)
            {
                Error.Text = err.Message;
            }
        }

        protected void SelectDepartmentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter SelectDepartmentByName = new SqlDataAdapter("Select * from NewDepartmentDetails Where NDepartmentName='" + SelectDepartmentName.SelectedItem.Text + "'", con);
                DataSet SDBNds = new DataSet();
                SelectDepartmentByName.Fill(SDBNds);
                
                    DisplayDD(SDBNds);
                
            }
            catch (Exception err)
            
            {
                Error.Text = err.Message;
            }

        }

        protected void Search_Click(object sender, EventArgs e)
        {

            try
            {
                SqlDataAdapter SelectDepartmentByID = new SqlDataAdapter("Select * from NewDepartmentDetails Where NDepartmentId='" + DepartmentId.Text + "'", con);
                DataSet SDBIDds = new DataSet();
                SelectDepartmentByID.Fill(SDBIDds);
                DisplayDD(SDBIDds);
            }
            catch (Exception err)
            {
                Error.Text = err.Message;
            }
        }

       
    }
}