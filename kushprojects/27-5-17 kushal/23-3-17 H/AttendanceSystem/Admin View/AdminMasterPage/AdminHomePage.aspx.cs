using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace AttendanceSystem.Admin_View.AdminMasterPage
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        protected void Page_Load(object sender, EventArgs e)
        {
            Series ser = Chart1.Series["Series1"];
            float TotalStu, TodayPresentStu,Totalpercentage,TotalDepStu,TotalDepPer,TotalDepPercentage;
            SqlDataAdapter SeleTotalStu = new SqlDataAdapter("Select Count(StudentId) From StudentDetails",con);
            DataSet ds = new DataSet();
            SeleTotalStu.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                totalStudents.Text = ds.Tables[0].Rows[0][0].ToString();
            }


            SqlDataAdapter PresentStu = new SqlDataAdapter("Select Count(AttendanceStatus) From StudentAttendance Where Date ='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "' AND AttendanceStatus='1'", con);
            DataSet ds1 = new DataSet();
            PresentStu.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Present.Text = ds1.Tables[0].Rows[0][0].ToString();
            }

            TotalStu =(float)(Convert.ToInt32(ds.Tables[0].Rows[0][0]));
            TodayPresentStu = (float)(Convert.ToInt32(ds1.Tables[0].Rows[0][0]));
            if (TotalStu == 0)
            {
                Percentage.Text = (0).ToString() + "%"; ;
            }
            else
            {
                Totalpercentage = (TodayPresentStu / TotalStu) * 100;
                Percentage.Text = ((int)Totalpercentage).ToString() + "%";
            }

            SqlDataAdapter LeaveStu = new SqlDataAdapter("Select Count(AttendanceStatus) From StudentAttendance Where Date ='" + System.DateTime.Today.ToString("yyyy/MM/dd") + "' AND AttendanceStatus='0' AND LeaveRequest='1'", con);
            DataSet ds2 = new DataSet();
            LeaveStu.Fill(ds2);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Leave.Text = ds2.Tables[0].Rows[0][0].ToString();
            }


            SqlDataAdapter AllDepartmentAttend = new SqlDataAdapter("Select NDepartmentId,NDepartmentName From NewDepartmentDetails",con);
            DataSet Depds = new DataSet();
            AllDepartmentAttend.Fill(Depds);
            int i = 0;
            if (Depds.Tables[0].Rows.Count > 0)
            {
                Chart1.ChartAreas["ChartArea1"].AxisX.MinorTickMark.Enabled = false;
                Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Enabled = false;
                Chart1.ChartAreas["ChartArea1"].AxisY.MajorTickMark.Enabled = false;

                Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                Chart1.ChartAreas["ChartArea1"].AxisX.LineWidth = 0;
                Chart1.ChartAreas["ChartArea1"].AxisY.LineWidth = 0;
                Chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;
                Chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor =System.Drawing.Color.Red;
                Chart1.ChartAreas["ChartArea1"].AxisX.Title = "Department Name";

                
                while (i < Depds.Tables[0].Rows.Count)
                {

                    SqlDataAdapter SelDepAttend = new SqlDataAdapter("Select Count(StudentDetails.StudentId) From StudentDetails Inner Join SemesterDetailsN On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Inner Join NewDepartmentDetails On(CourseDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId) Where NewDepartmentDetails.NDepartmentId='" + Convert.ToInt32(Depds.Tables[0].Rows[i][0]) + "'", con);
                    DataSet SelDepAttds = new DataSet();
                    SelDepAttend.Fill(SelDepAttds);
                   

                    SqlDataAdapter DepPreStu = new SqlDataAdapter("Select Count(StudentDetails.StudentId) From StudentDetails Inner Join SemesterDetailsN On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Inner Join NewDepartmentDetails On(CourseDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId) Inner Join SubAllByStu On(StudentDetails.StudentId=SubAllByStu.StudentId) Inner Join StudentAttendance On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo) Where NewDepartmentDetails.NDepartmentId='" + Convert.ToInt32(Depds.Tables[0].Rows[i][0]) + "' AND StudentAttendance.AttendanceStatus='1' AND StudentAttendance.Date='"+System.DateTime.Today.ToString("yyyy/MM/dd")+"'", con);
                    DataSet DepPreStuds = new DataSet();
                    DepPreStu.Fill(DepPreStuds);
                   

                    if (SelDepAttds.Tables[0].Rows.Count > 0)
                    {
                         TotalDepStu = (float)Convert.ToInt32((SelDepAttds.Tables[0].Rows[0][0]));
                          TotalDepPer=(float)Convert.ToInt32(DepPreStuds.Tables[0].Rows[0][0]);
                        TotalDepPercentage=(TotalDepPer/TotalDepStu)*100;
                      
                        ser.Points.AddXY(Depds.Tables[0].Rows[i][1],TotalDepPercentage);

                        if (TotalDepPercentage > 0)
                        {
                            Chart1.Series["Series1"].Label = TotalDepPercentage + "%";
                        }



                    }
                    i++;
                }
            }
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {

        }
    }
}