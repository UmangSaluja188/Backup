using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Shoping_Cart
{
    public partial class Login: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\DELL\Documents\shoppingDB.mdf; Integrated Security = True; Connect Timeout = 30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_reg where email=@email and password=@password", con);
            cmd.Parameters.AddWithValue("email", TextBox1.Text);
            cmd.Parameters.AddWithValue("password", TextBox2.Text);
            DataSet ds = new DataSet();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(ds);
            con.Close();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["email"] = TextBox1.Text;
                    Response.Redirect("View.aspx");
                }
                else
                {
                    Label1.Text = "Wrong email or password";
                }
            }
        }
    }
}