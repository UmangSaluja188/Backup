using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_ALL_In_1.Login_Signup
{
    public partial class frm_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();

            if (!IsPostBack)
            {
                getData();
                
            }
        }

        public void checkSession()
        {
            if (Session["userEmail"] == null)

            {
                //Response.Write("<script>alert('Session Timeout!')</script>");
                Response.Redirect("frm_Login.aspx");
            }
        }
        public void getData()
        {
            string str = Session["userEmail"].ToString();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dpkbh\Documents\WebAppDB.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Reg WHERE Email=@Email ", conn);
            cmd.Parameters.AddWithValue("Email", str);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conn.Close();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    lblUserId.Text = ds.Tables[0].Rows[0]["UId"].ToString();
                    lblUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                    lblUserEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    lblUserDOB.Text = ds.Tables[0].Rows[0]["DOB"].ToString();

                }
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_ChangePassword.aspx");
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("frm_Login.aspx");
        }
    }
}