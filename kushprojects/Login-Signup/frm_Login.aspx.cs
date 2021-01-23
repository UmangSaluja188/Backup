using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace ASP_ALL_In_1.Login_Signup
{
    public partial class frm_Login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dpkbh\Documents\WebAppDB.mdf;Integrated Security=True;Connect Timeout=30");

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Reg WHERE Email=@Email AND Password=@Password AND UserType=@UserType", conn);
            conn.Open();

            cmd.Parameters.AddWithValue("Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("UserType", ddlUserType.SelectedItem.Value);

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conn.Close();

            if (ds.Tables.Count>0)
            {
                if(ds.Tables[0].Rows.Count>0)
                {
                    if(ddlUserType.SelectedItem.Text=="Admin")
                    {
                        Session["userEmail"] = txtEmail.Text;
                        Response.Redirect("~/Login-Signup/Admin/frm_AdminHome.aspx");

                    }

                    if (ddlUserType.SelectedItem.Text == "GUser")
                    {
                        Session["userEmail"] = txtEmail.Text;
                        Response.Redirect("frm_Home.aspx");

                    }

                }
                else
                {
                    Response.Write("<script> alert('Invalid UserName!!') </script>");

                }
            }
            else
            {
                Response.Write("<script> alert('No Record Found!!') </script>");

            }


        }

        protected void linkSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_Signup.aspx");
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}