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
    public partial class Signup: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\DELL\Documents\shoppingDB.mdf; Integrated Security = True; Connect Timeout = 30");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_reg(name,email,contactno,password,address)values(@name,@email,@contactno,@password,@address)", con);
            cmd.Parameters.AddWithValue("name", TextBox1.Text);
            cmd.Parameters.AddWithValue("email", TextBox2.Text);
            cmd.Parameters.AddWithValue("contactno", TextBox3.Text);
            cmd.Parameters.AddWithValue("password", TextBox4.Text);
            cmd.Parameters.AddWithValue("address", TextBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Login.aspx");
            
        }
    }
}