using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace AttendanceSystem.Admin_View.ManageCollegeTiming
{
    public partial class EditCollegeTiming : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataAdapter SelectCollegeTiming = new SqlDataAdapter("Select * From CollegeTiming", con);
                DataSet ds = new DataSet();
                SelectCollegeTiming.Fill(ds);
                openTime.Text = ds.Tables[0].Rows[3][0].ToString();
                closingTime.Text = ds.Tables[0].Rows[3][1].ToString();
                lacDuration.Text = ds.Tables[0].Rows[3][2].ToString();
                DateTime d = new DateTime();
                d = Convert.ToDateTime(Convert.ToDateTime(ds.Tables[0].Rows[3][2].ToString()).ToShortTimeString());
                Response.Write(d);
                TimeSpan t = new TimeSpan();
               ;
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            SqlDataAdapter UpdateTime = new SqlDataAdapter("Update CollegeTiming set CollegeOpenTime='"+Convert.ToDateTime(Convert.ToDateTime(openTime.Text).ToShortTimeString())+"',CollegeCloseTime='"+Convert.ToDateTime(Convert.ToDateTime(closingTime.Text).ToShortTimeString())+"',LactureTime='"+Convert.ToDateTime(Convert.ToDateTime(lacDuration.Text).ToShortTimeString())+"'",con);
            DataSet uds = new DataSet();
            UpdateTime.Fill(uds);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}