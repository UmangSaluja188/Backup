using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem.LogInFolder
{
    public partial class AdminLogInPage : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con1 = new SqlConnection(cs);
        public static string UserIdV, PasswordV; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
          /* SqlCommand SelAdminIdAndPass = new SqlCommand("Select * From LoginTable Where UserId='" + Convert.ToInt32(UserId.Text) + "' AND Password='@PasswordP'", con1);
            SelAdminIdAndPass.Parameters.AddWithValue("@UserIdP",UserId.Text);
            SelAdminIdAndPass.Parameters.AddWithValue("@PasswordP",Password.Text);
            con1.Open();
            SqlDataReader red =SelAdminIdAndPass.ExecuteReader() ;        
            while(red.Read())
            {
                UserIdV = UserId.Text;
                PasswordV = Password.Text;
                Session["AdminId"]=UserIdV;
                Session["Password"]=PasswordV;
                Response.Redirect("../Admin View/AdminMasterPage/AdminHomePage.aspx");
            }
            con1.Close();
            */
            SqlDataAdapter SelectAdminIdPas = new SqlDataAdapter("Select * From LoginTable Where UserId='"+UserId.Text+"'AND Password='"+Password.Text+"' And LogInType='Admin'",con1);
            DataSet ds = new DataSet();
            SelectAdminIdPas.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Write(ds.Tables[0].Rows[0][3].ToString());
                UserIdV = UserId.Text;
                if (ds.Tables[0].Rows[0][3].ToString() == "Password")
                {
                    PasswordPanel.Visible = false;
                    NewPassword.Visible = true;

                }
                else
                {
                  
                    Session["AdminId"] = UserIdV;
                    Session["AdmPassword"] = PasswordV;
                    Response.Redirect("/Admin View/AdminMasterPage/AdminHomePage.aspx");
                }






            }
            else
            {
                Label1.Text = "!Invalid";
            }


        }

        protected void UserId_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter ChangePassword = new SqlDataAdapter("Update LoginTable Set Password='" + NewPass.Text + "' Where UserId='" + UserId.Text + "'", con1);
            DataSet ds2 = new DataSet();
            ChangePassword.Fill(ds2);
            PasswordV = NewPass.Text;
            Session["AdminId"] = UserIdV;

            Response.Redirect("/Admin View/AdminMasterPage/AdminHomePage.aspx");
        }
    }
}