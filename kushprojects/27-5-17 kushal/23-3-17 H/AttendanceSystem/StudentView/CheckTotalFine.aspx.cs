using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AttendanceSystem.StudentView
{
    public partial class CheckTotalFine : System.Web.UI.Page
    {
        public static int StudentId,FinePerDay;
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public DataSet SelectStudentsds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)

        {
            StudentId = Convert.ToInt32(Session["StudentId"]);
              SqlDataAdapter SearchStudentDetails = new SqlDataAdapter("Select SubAllByStu.StudentId,SubjectDetails.SubjectId,SubjectDetails.SubjectName,SubjectDetails.SubjectId As Fine  From SubjectDetails Inner Join SubAllByStu On(SubAllByStu.SubjectId=SubjectDetails.SubjectId) Where SubAllByStu.StudentId='" + StudentId + "'", con);
                  
                    SearchStudentDetails.Fill(SelectStudentsds);
                    GridView1.DataSource = SelectStudentsds;
                    GridView1.DataBind();
                    if (SelectStudentsds.Tables[0].Rows.Count > 0)
                    {
                        CheckTotalAppsent(0);
                        TotalFineN();
                    }
        }

        private void TotalFineN()
        {
            SqlDataAdapter PerDayFineCharge = new SqlDataAdapter("Select FinePerDay From FineDetails  Inner Join StudentDetails On (StudentDetails.SemesterId=FineDetails.SemesterId)Where StudentDetails.StudentId='"+StudentId+"'",con);
            DataSet ds2 = new DataSet();
            PerDayFineCharge.Fill(ds2);
            if(ds2.Tables[0].Rows.Count>0)
            {
                FinePerDay = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
            }
            int i = 0, TotalFineValue = 0;
            while (i < GridView1.Rows.Count)
            {
                TotalFineValue = TotalFineValue+Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                i++;
            }
            TotalFine.Text = TotalFineValue.ToString();
        }

        private void CheckTotalAppsent(int value)
        {
            if (value == 0)
            {
                int i = 0;
                if (SelectStudentsds.Tables[0].Rows.Count > 0)
                {
                    while (i < SelectStudentsds.Tables[0].Rows.Count)
                    {

                        SqlDataAdapter ToAppLac = new SqlDataAdapter("Select Count(StudentAttendance.AttendanceStatus) From StudentAttendance Inner Join SubAllByStu On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)Where SubAllByStu.StudentId='" + Convert.ToInt32(SelectStudentsds.Tables[0].Rows[i][0]) + "'AND SubAllByStu.SubjectId='" + Convert.ToInt32(SelectStudentsds.Tables[0].Rows[i][1]) + "' AND StudentAttendance.AttendanceStatus='0' AND StudentAttendance.LeaveRequest='0' ", con);
                        DataSet ToAppLacds = new DataSet();
                        ToAppLac.Fill(ToAppLacds);
                        if (ToAppLacds.Tables[0].Rows.Count > 0)
                        {

                            GridView1.Rows[i].Cells[3].Text = ((Convert.ToInt32(ToAppLacds.Tables[0].Rows[0][0]))*FinePerDay).ToString();
                        }
                        i++;
                    }
                 
                }
            }
        }
    }
}