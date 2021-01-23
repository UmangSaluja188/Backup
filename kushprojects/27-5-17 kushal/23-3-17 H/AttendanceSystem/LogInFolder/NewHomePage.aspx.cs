using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace AttendanceSystem.LogInFolder
{
    public partial class NewHomePage : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con1 = new SqlConnection(cs);
        public static string UserIdV, PasswordV; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LogIn_Click(object sender, EventArgs e)
        {

            if (UserType.SelectedIndex > 0)
            {
                SqlDataAdapter SelectAdminIdPas = new SqlDataAdapter("Select * From LoginTable Where UserId='" + UserId.Text + "'AND Password='" + Password.Text + "' And LogInType='" + UserType.SelectedItem.Text + "'", con1);
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
                        LogIn.Visible = false;
                        LogIn2.Visible = true;
                        Validation.Visible = true;

                    }
                    else
                    {
                        if (UserType.SelectedIndex == 1)
                        {
                            Session["AdminId"] = UserIdV;
                            Response.Redirect("~/Admin View/AdminMasterPage/AdminHomePage.aspx");
                        }
                        else if (UserType.SelectedIndex == 2)
                        {
                            Session["StudentId"] = UserIdV;
                            Response.Redirect("~/StudentView/ViewTimeTable.aspx");
                        }
                        else if (UserType.SelectedIndex == 3)
                        {
                            Session["TeacherId"] = UserIdV;
                            Response.Redirect("~/TeacherView/TeacherHomePage.aspx?Value=Today");
                        }
                        
                       
                    }


                }
                else
                {
                    Label1.Text = "!Invalid";
                }

            }
        }
         
protected void Button1_Click(object sender, EventArgs e)
{
    SqlDataAdapter ChangePassword = new SqlDataAdapter("Update LoginTable Set Password='" + txtNewPassword.Text + "' Where UserId='" + UserId.Text + "'", con1);
    DataSet ds2 = new DataSet();
    ChangePassword.Fill(ds2);
    PasswordV = txtNewPassword.Text;
    if (UserType.SelectedIndex == 1)
    {
        Session["AdminId"] = UserIdV;
    }
    else if (UserType.SelectedIndex == 2)
    {
        Session["StudentId"] = UserIdV;
    }
    else if (UserType.SelectedIndex == 3)
    {
        Session["TeacherId"] = UserIdV;
    }
    
    Response.Redirect("/Admin View/AdminMasterPage/AdminHomePage.aspx");
}
}
}