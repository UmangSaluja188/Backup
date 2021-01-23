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
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    getData();
                }
        }

        public void getData()
        {
               
                SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\DELL\Documents\shoppingDB.mdf; Integrated Security = True; Connect Timeout = 30");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tbl_reg where email=@email", con);
                cmd.Parameters.AddWithValue("email", Session["email"].ToString());
                DataSet ds = new DataSet();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {  
                        Label1.Text = ds.Tables[0].Rows[0]["name"].ToString();
                        Label2.Text = ds.Tables[0].Rows[0]["email"].ToString();
                        Label3.Text = ds.Tables[0].Rows[0]["contactno"].ToString();
                        Label4.Text = ds.Tables[0].Rows[0]["address"].ToString();

                }
                }
            }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
    }
