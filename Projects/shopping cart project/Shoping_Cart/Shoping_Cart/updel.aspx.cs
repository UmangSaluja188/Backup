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
    public partial class updel : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\DELL\Documents\shoppingDB.mdf; Integrated Security = True; Connect Timeout = 30");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getId();
            }
        }
        public void getId()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from tbl_reg where Id=@Id", con);
                DataSet ds = new DataSet();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(ds);
                if(ds.Tables.Count>0)
                {
                    if(ds.Tables[0].Rows.Count>0)
                    {
                        DropDownList1.DataSource = ds;
                        DropDownList1.DataTextField = "Id";
                        DropDownList1.DataBind();
                    }
                }



            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}