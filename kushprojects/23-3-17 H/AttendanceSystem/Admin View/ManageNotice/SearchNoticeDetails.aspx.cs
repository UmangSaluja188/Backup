using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace AttendanceSystem.Admin_View.ManageNotice
{
    public partial class SearchNoticeDetails : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearNoticeDetails(0);
            }
        }

        private void SearNoticeDetails(int value)
        {
            DataSet ds = new DataSet();
            int i = 0;
            if (value == 0)
            {
                SqlDataAdapter selAllNotice = new SqlDataAdapter("Select NoticeId,Title,Date,NoticeStatus From NoticeDetails ", con);
               
                selAllNotice.Fill(ds);
            }
            else
            {
                SqlDataAdapter selAllNotice = new SqlDataAdapter("Select NoticeId,Title,Date,NoticeStatus From NoticeDetails Where Date='"+Convert.ToDateTime(SelectDate.Text).ToString("yyyy/MM/dd")+"' ", con);
                
                selAllNotice.Fill(ds);
            }
            AllNotice.DataSource = ds;
            AllNotice.DataBind();
            while (i < AllNotice.Rows.Count)
            {
                if (((bool)ds.Tables[0].Rows[i][3]) == false)
                {
                    AllNotice.Rows[i].Cells[4].Text = "Deactivate";
                    Color wrong = ColorTranslator.FromHtml("#FFC3C3");
                    AllNotice.Rows[i].BackColor = wrong;
                    AllNotice.Rows[i].ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    AllNotice.Rows[i].Cells[4].Text = "Activate";
                }
                i++;
            }
        }

        protected void Deactivate_Click(object sender, EventArgs e)
        {
            int index;
            GridViewRow row = (sender as Button).Parent.Parent as GridViewRow;
            index = row.RowIndex;
            SqlDataAdapter DeactivateNotice = new SqlDataAdapter("Update NoticeDetails Set NoticeStatus='0' Where NoticeId='"+AllNotice.Rows[index].Cells[1].Text+"'",con);
            DataSet ds = new DataSet();
            DeactivateNotice.Fill(ds);
            Color wrong = ColorTranslator.FromHtml("#FFC3C3");
            AllNotice.Rows[index].BackColor = wrong;
            AllNotice.Rows[index].ForeColor = System.Drawing.Color.White;
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            int index;
            GridViewRow row = (sender as Button).Parent.Parent as GridViewRow;
            index = row.RowIndex;
            SqlDataAdapter DeleteNotice = new SqlDataAdapter("Delete NoticeDetails Where NoticeId='" + AllNotice.Rows[index].Cells[1].Text + "'", con);
            DataSet ds = new DataSet();
            DeleteNotice.Fill(ds);
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            SearNoticeDetails(1);
        }
    }
}