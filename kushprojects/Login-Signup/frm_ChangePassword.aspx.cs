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
    public partial class frm_ChangePassword : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
        }
        public void checkSession()
        {
            if (Session["userEmail"] == null)

            {
                //Response.Write("<script>alert('Session Timeout!')</script>");
                Response.Redirect("frm_Login.aspx");
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dpkbh\Documents\WebAppDB.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlCommand cmdsel = new SqlCommand("SELECT * FROM tbl_Reg WHERE Email=@Email AND Password=@OldPassword", conn);
            cmdsel.Parameters.AddWithValue("Email", Session["userEmail"]);
            cmdsel.Parameters.AddWithValue("OldPassword", txtOldPass.Text);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmdsel);
            da.Fill(ds);

            if(ds.Tables.Count>0)
            {
                if(ds.Tables[0].Rows.Count>0)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE tbl_Reg SET Password=@NewPassword WHERE  Email=@Email", conn);


                    cmd.Parameters.AddWithValue("Email", Session["userEmail"]);
                    cmd.Parameters.AddWithValue("NewPassword", txtNewPass.Text);


                    cmd.ExecuteNonQuery();

                    conn.Close();

                    Response.Write("<script>alert('Password Change Sucessfully!!')</script>");
                    Response.Redirect("frm_Login.aspx");


                }
                else
                {
                    Response.Write("<script> alert('Check Old Password!!') </script>");

                }

            }
            else
            {
                Response.Write("<script> alert('NO Record Found!!') </script>");

            }


        }

    }
}