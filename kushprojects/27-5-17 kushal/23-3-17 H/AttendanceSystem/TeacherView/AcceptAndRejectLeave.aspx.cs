using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem.TeacherView
{
    public partial class AcceptAndRejectLeave : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        protected void Page_Load(object sender, EventArgs e)
        {
            int TotalDays;
            Studentid.Text = Request.QueryString["StudentId"];
            LeaveStartingDate.Text = Request.QueryString["LeaveStartingDate"];
            LeaveEndinDate.Text = Request.QueryString["LeaveEndingDate"];
            TextBox4.Text = Request.QueryString["Reason"];
            
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Reject_Click(object sender, EventArgs e)
        {

            SqlDataAdapter AcceptLeave = new SqlDataAdapter("Update LeaveTable Set LeaveStatus='Reject'Where StudentId='" + Studentid.Text + "'And LeaveStartingDate='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "'", con);
            DataSet ds = new DataSet();
            AcceptLeave.Fill(ds);
            Server.Transfer("~/TeacherView/CheckLeaveDetails.aspx");
        
        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            SqlDataAdapter AcceptLeave = new SqlDataAdapter("Update LeaveTable Set LeaveStatus='Accept' Where StudentId='" + Studentid.Text + "'And LeaveStartingDate='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "' ", con);
            DataSet ds = new DataSet();
            AcceptLeave.Fill(ds);
            Server.Transfer("~/TeacherView/CheckLeaveDetails.aspx");
        }
    }
}