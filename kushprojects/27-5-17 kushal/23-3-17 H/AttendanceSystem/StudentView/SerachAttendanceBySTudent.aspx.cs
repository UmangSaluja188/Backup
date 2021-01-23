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

namespace AttendanceSystem.StudentView
{
    public partial class SerachAttendanceBySTudent : System.Web.UI.Page
    {
        static string cs2 = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs2);
       public  DataSet SearchSubjectds = new DataSet();
       public DataSet SelectStudentsds = new DataSet();
       public static int TotalAttendanceV, TotallactureV, TotalAppsentV, StudentId1,FinePerDay;
       public  int TotalStudentFine=0,FineCharge=5;
       public static float TotalLac, AttendLac;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Hello");
            if (!IsPostBack)
            {
                if (Session["StudentId"] != null)
                {
                    StudentId1 = Convert.ToInt32(Session["StudentId"]);
                    BindSubject();


                    if (SearchSubjectds.Tables[0].Rows.Count > 0)
                    {
                        SubjectNamePanel.Visible = true;
                        SubjectName.DataSource = SearchSubjectds;
                        SubjectName.DataTextField = "SubjectName";
                        SubjectName.DataValueField = "SubjectName";
                        SubjectName.DataBind();
                        SubjectName.Items.Insert(0, "Select Subject...");
                    }
                    else
                    {
                        Error.Visible = true;
                        Error.Text = "Invalid Student Id";
                    }


                    SqlDataAdapter SearchStudentDetails = new SqlDataAdapter("Select SubAllByStu.StudentId,SubjectDetails.SubjectId,SubjectDetails.SubjectName,SubjectDetails.SubjectId As TotalLactures, SubjectDetails.SubjectId As LeaveDays, SubjectDetails.SubjectId As AttendLactures,SubjectDetails.SubjectId As Appsent_Lactures, SubjectDetails.SubjectId As Fine,SubjectDetails.SubjectId As Total_Percentage From SubjectDetails Inner Join SubAllByStu On(SubAllByStu.SubjectId=SubjectDetails.SubjectId) Where SubAllByStu.StudentId='" + StudentId1 + "'", con);

                    SearchStudentDetails.Fill(SelectStudentsds);
                    GridView1.DataSource = SelectStudentsds;
                    GridView1.DataBind();
                    if (SelectStudentsds.Tables[0].Rows.Count > 0)
                    {
                        CheckTotalLac(0);
                        TotalAttendance(0);

                        CheckLeaveDays(0);
                        CheckTotalAppsent(0);
                        TotalFine(0);
                        Bindwithchart(0);
                    }
                   
                }
                else
                {
                    Response.Redirect("~/LogInFolder/StudentLogIn.aspx");
                }
            }
        }


        private void Bindwithchart(int value)
        {
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisX.Title ="Percentage";
            Chart1.ChartAreas["ChartArea1"].AxisY.Title = "Subject Name";
            Chart1.ChartAreas["ChartArea1"].Name = "Student Attendance Chart";
             Series ser = Chart1.Series["Series1"];
                int i = 0;
                float percentage;
            if (value == 0)
            {
               

                while (i < GridView1.Rows.Count)
                {
                    TotalLac = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
                    AttendLac = Convert.ToInt32(GridView1.Rows[i].Cells[6].Text);
                    percentage = (float)(AttendLac / TotalLac) * 100;
                   

                    if (percentage > 0)
                    {
                        GridView1.Rows[i].Cells[9].Text = ((int)percentage).ToString() + "%";
                        Chart1.Series["Series1"].Label = (int)percentage + "%";
                    }
                    else
                    {
                        GridView1.Rows[i].Cells[9].Text = (0).ToString() + "%";
                       
                    }
                   
                    
                    ser.Points.AddXY(GridView1.Rows[i].Cells[3].Text, percentage);
                    i++;
                }

            }
            else
            {
                   TotalLac = Convert.ToInt32(GridView1.Rows[0].Cells[4].Text);
                    AttendLac = Convert.ToInt32(GridView1.Rows[0].Cells[6].Text);
                    percentage = (float)(AttendLac / TotalLac) * 100;
                    Chart1.BackColor = System.Drawing.Color.LightPink;

                    if (percentage > 0)
                    {
                        GridView1.Rows[0].Cells[9].Text = ((int)percentage).ToString() + "%";
                        Chart1.Series["Series1"].Label = percentage + "%";

                    }
                    else
                    {
                        GridView1.Rows[0].Cells[9].Text = (0).ToString() + "%";
                    }

                    ser.Points.AddXY(GridView1.Rows[0].Cells[3].Text, percentage);

           
            }
        }

        private void CheckLeaveDays(int value)
        {
            if (value == 0)
            {
                int i = 0;
                while (i < SearchSubjectds.Tables[0].Rows.Count)
                {
                    SqlDataAdapter SelectTotalLeave = new SqlDataAdapter("Select Count(StudentAttendance.LeaveRequest) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubjectDetails.SubjectId='" + SearchSubjectds.Tables[0].Rows[i][0] + "'And SubAllByStu.StudentId='" + StudentId1 + "' And StudentAttendance.LeaveRequest='1'", con);
                    DataSet SelectTotalLeaveds = new DataSet();
                    SelectTotalLeave.Fill(SelectTotalLeaveds);
                    if (SelectTotalLeaveds.Tables[0].Rows.Count > 0)
                    {
                        GridView1.Rows[i].Cells[5].Text = SelectTotalLeaveds.Tables[0].Rows[0][0].ToString();
                    }
                    i++;
                }
            }
            else
            {
                SqlDataAdapter SelectTotalLeave = new SqlDataAdapter("Select Count(StudentAttendance.LeaveRequest) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubAllByStu.StudentId='" + StudentId1 + "' And StudentAttendance.LeaveRequest='1'  And SubjectDetails.SubjectName='"+SubjectName.SelectedItem.Text+"'", con);
                DataSet SelectTotalLeaveds = new DataSet();
                SelectTotalLeave.Fill(SelectTotalLeaveds);
                if (SelectTotalLeaveds.Tables[0].Rows.Count > 0)
                {
                    GridView1.Rows[0].Cells[5].Text = SelectTotalLeaveds.Tables[0].Rows[0][0].ToString();
                }
            }
        }

        private void BindSubject()
        {
            SqlDataAdapter SearchSubject = new SqlDataAdapter("Select SubjectDetails.SubjectId,SubjectDetails.SubjectName From SubjectDetails Inner Join SubAllByStu On(SubAllByStu.SubjectId=SubjectDetails.SubjectId) Where  SubAllByStu.StudentId='" + StudentId1 + "'", con);

            SearchSubject.Fill(SearchSubjectds);
           
        }

        private void TotalFine(int value)
        {
            SqlDataAdapter PerDayFineCharge = new SqlDataAdapter("Select FinePerDay From FineDetails  Inner Join StudentDetails On (StudentDetails.SemesterId=FineDetails.SemesterId)Where StudentDetails.StudentId='" + StudentId1 + "'", con);
            DataSet ds2 = new DataSet();
            PerDayFineCharge.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                FinePerDay = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
            }
            if (value == 0)
            {
                int i = 0;

                while (i < GridView1.Rows.Count)
                {
                    TotalAppsentV = Convert.ToInt32(GridView1.Rows[i].Cells[7].Text);

                    TotalStudentFine = TotalAppsentV * FinePerDay;
                    GridView1.Rows[i].Cells[8].Text = TotalStudentFine.ToString();
                    i++;

                }
            }
            else
            {
                TotalAppsentV = Convert.ToInt32(GridView1.Rows[0].Cells[7].Text);

                TotalStudentFine = TotalAppsentV * FineCharge;
                GridView1.Rows[0].Cells[8].Text = TotalStudentFine.ToString();
            }

        }

        
         private void CheckTotalAppsent(int value)
        {
            if (value == 0)
            {
                int i = 0;
                if (SelectStudentsds.Tables[0].Rows.Count > 0)
                {
                    while (i < SearchSubjectds.Tables[0].Rows.Count)
                    {

                        SqlDataAdapter ToAppLac = new SqlDataAdapter("Select Count(StudentAttendance.AttendanceStatus) From StudentAttendance Inner Join SubAllByStu On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)Where SubAllByStu.StudentId='" + Convert.ToInt32(SelectStudentsds.Tables[0].Rows[i][0]) + "'AND SubAllByStu.SubjectId='" + Convert.ToInt32(SearchSubjectds.Tables[0].Rows[i][0]) + "' AND StudentAttendance.AttendanceStatus='0' AND StudentAttendance.LeaveRequest='0' ", con);
                        DataSet ToAppLacds = new DataSet();
                        ToAppLac.Fill(ToAppLacds);
                        if (ToAppLacds.Tables[0].Rows.Count > 0)
                        {

                            GridView1.Rows[i].Cells[7].Text = ToAppLacds.Tables[0].Rows[0][0].ToString();
                        }
                        i++;
                    }
                }
            }
            else
            {
                  SqlDataAdapter ToAppLac = new SqlDataAdapter("Select Count(StudentAttendance.AttendanceStatus) From StudentAttendance Inner Join SubAllByStu On(SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo)Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId)Where SubAllByStu.StudentId='" +StudentId1 + "'AND SubjectDetails.SubjectName='"+SubjectName.SelectedItem.Text+"' AND StudentAttendance.AttendanceStatus='0' AND StudentAttendance.LeaveRequest='0' ", con);
                        DataSet ToAppLacds = new DataSet();
                        ToAppLac.Fill(ToAppLacds);
                        if (ToAppLacds.Tables[0].Rows.Count > 0)
                        {

                            GridView1.Rows[0].Cells[7].Text = ToAppLacds.Tables[0].Rows[0][0].ToString();
                        }
            }
        }       

        

        private void TotalAttendance(int value)
        {
            int i = 0, j = 0;
            if (value == 0)
            {
                while (i < SearchSubjectds.Tables[0].Rows.Count)
                {
                    SqlDataAdapter SelectTotalLac = new SqlDataAdapter("Select Count(StudentAttendance.Date) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubjectDetails.SubjectId='" + SearchSubjectds.Tables[0].Rows[i][0] + "'And SubAllByStu.StudentId='" + StudentId1 + "' And StudentAttendance.AttendanceStatus='1'", con);
                    DataSet SelectTotalLacds = new DataSet();
                    SelectTotalLac.Fill(SelectTotalLacds);
                    if (SelectTotalLacds.Tables[0].Rows.Count > 0)
                    {
                        TotalAttendanceV = Convert.ToInt32(SelectTotalLacds.Tables[0].Rows[0][0].ToString());
                        GridView1.Rows[i].Cells[6].Text = TotalAttendanceV.ToString();

                    }
                    i++;
                }
            }
            else
            {
                SqlDataAdapter SelectTotalLac = new SqlDataAdapter("Select Count(StudentAttendance.Date) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubjectDetails.SubjectName='"+SubjectName.SelectedItem.Text+"'And SubAllByStu.StudentId='" + StudentId1 + "' And StudentAttendance.AttendanceStatus='1'", con);
                DataSet SelectTotalLacds = new DataSet();
                SelectTotalLac.Fill(SelectTotalLacds);
                if (SelectTotalLacds.Tables[0].Rows.Count > 0)
                {
                    TotalAttendanceV = Convert.ToInt32(SelectTotalLacds.Tables[0].Rows[0][0].ToString());
                    GridView1.Rows[i].Cells[6].Text = TotalAttendanceV.ToString();

                }
            }
        }

        private void CheckTotalLac(int value)
        {
            int i = 0, j = 0;
            if (value == 0)
            {
                while (i < SearchSubjectds.Tables[0].Rows.Count)
                {
                    SqlDataAdapter SelectTotalLac = new SqlDataAdapter("Select Count(StudentAttendance.Date) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubjectDetails.SubjectId='" + SearchSubjectds.Tables[0].Rows[i][0] + "'And SubAllByStu.StudentId='" + StudentId1 + "'", con);
                    DataSet SelectTotalLacds = new DataSet();
                    SelectTotalLac.Fill(SelectTotalLacds);
                    if (SelectTotalLacds.Tables[0].Rows.Count > 0)
                    {
                        TotallactureV = Convert.ToInt32(SelectTotalLacds.Tables[0].Rows[0][0]);
                        GridView1.Rows[i].Cells[4].Text = TotallactureV.ToString();

                    }
                    i++;
                }
            }
            else
            {
                SqlDataAdapter SelectTotalLac = new SqlDataAdapter("Select Count(StudentAttendance.Date) From StudentAttendance Inner Join SubAllByStu On(StudentAttendance.SubjectAllocationNo=SubAllByStu.SubjectAllocationNo) Inner Join SubjectDetails On(SubjectDetails.SubjectId=SubAllByStu.SubjectId) Where SubjectDetails.SubjectName='" +SubjectName.SelectedItem.Text  + "'And SubAllByStu.StudentId='" + StudentId1 + "'", con);
                DataSet SelectTotalLacds = new DataSet();
                SelectTotalLac.Fill(SelectTotalLacds);
                if (SelectTotalLacds.Tables[0].Rows.Count > 0)
                {
                    TotallactureV = Convert.ToInt32(SelectTotalLacds.Tables[0].Rows[0][0]);
                    GridView1.Rows[i].Cells[4].Text = TotallactureV.ToString();

                }
            }
        }

        protected void SubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            SqlDataAdapter SearchStudentDetails = new SqlDataAdapter("Select SubAllByStu.StudentId,SubjectDetails.SubjectId,SubjectDetails.SubjectName,SubjectDetails.SubjectId As TotalLactures, SubjectDetails.SubjectId As LeaveDays, SubjectDetails.SubjectId As AttendLactures,SubjectDetails.SubjectId As Appsent_Lactures, SubjectDetails.SubjectId As Fine,SubjectDetails.SubjectId As TotalPercentage From SubjectDetails Inner Join SubAllByStu On(SubAllByStu.SubjectId=SubjectDetails.SubjectId) Where SubAllByStu.StudentId='" + StudentId1 + "' AND SubjectDetails.SubjectName='"+SubjectName.SelectedItem.Text+"'", con);

            SearchStudentDetails.Fill(SelectStudentsds);
            GridView1.DataSource = SelectStudentsds;

            GridView1.DataBind();
            if (SelectStudentsds.Tables[0].Rows.Count > 0)
            {
                CheckTotalLac(1);
                TotalAttendance(1);
                CheckLeaveDays(1);
                CheckTotalAppsent(1);
                TotalFine(1);
                Bindwithchart(1);
            }
        }

        protected void DetailsButton_Click(object sender, EventArgs e)
        {
           
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {

        }

    }
}