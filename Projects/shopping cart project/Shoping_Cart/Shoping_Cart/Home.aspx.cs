using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoping_Cart
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dl1.Items.Insert(0, "Select Item");
                pn1.Visible = false;
                pn3.Visible = false;
                pn4.Visible = false;
            }
            

        }

        protected void dl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dl1.SelectedItem.ToString().Equals("Mobile"))
            {
                pn1.Visible = true;
                pn3.Visible = false;
                pn4.Visible = false;
            }
            if (dl1.SelectedItem.ToString().Equals("Furniture"))
            {
                pn1.Visible = false;
                pn3.Visible = true;
                pn4.Visible = false;
            }
            if (dl1.SelectedItem.ToString().Equals("Television"))
            {
                pn1.Visible = false;
                pn3.Visible = false;
                pn4.Visible = true;
            }
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductDetails.aspx?id=mi");
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductDetails.aspx?id=go");
        }

        protected void btn4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductDetails.aspx?id=tv");
        }


    }
}