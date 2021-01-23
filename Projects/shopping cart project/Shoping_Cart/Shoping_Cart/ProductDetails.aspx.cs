using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoping_Cart
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strid = Request.QueryString["id"].ToString();
                if (strid.Equals("mi"))
                {
                    pnn1.Visible = true;
                    pnn3.Visible = false;
                    pnn4.Visible = false;
                }
                if (strid.Equals("go"))
                {
                    pnn1.Visible = false;
                    pnn3.Visible = true;
                    pnn4.Visible = false;
                }
                if (strid.Equals("tv"))
                {
                    pnn1.Visible = false;
                    pnn3.Visible = false;
                    pnn4.Visible = true;
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thankspage.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thankspage.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thankspage.aspx");
        }
    }
}