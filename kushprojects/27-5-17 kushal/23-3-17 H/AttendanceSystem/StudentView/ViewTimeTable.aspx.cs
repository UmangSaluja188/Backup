using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem.StudentView
{
    public partial class ViewTimeTable : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static  int StudentId1,FinePerDay,SemesterId;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "TimeTable")
            {
                Panel1.Visible = true;
            }
            DateTime Start=new DateTime();
            DateTime End=new DateTime();
            float percentage1;
            Response.Write("Hello");
            if(!IsPostBack)
            {
              
                if(Session["StudentId"]!=null)
                {
                 

                   StudentId1 = Convert.ToInt32(Session["StudentId"]);
                    //Select SemesterId Filed
                   try
                   {
                       SqlDataAdapter SelSemId = new SqlDataAdapter("Select SemesterId From StudentDetails Where StudentId='" + StudentId1 + "'", con);
                       DataSet ds10 = new DataSet();
                       SelSemId.Fill(ds10);
                       if (ds10.Tables[0].Rows.Count > 0)
                       {
                           SemesterId = Convert.ToInt32(ds10.Tables[0].Rows[0][0]);
                       }
                   }
                   catch (Exception err)
                   {
                       Error.Text = "Select Semester Id  Field Dataset ds10";
                   }

                    // Check Notice
                   try
                   {
                       SqlDataAdapter CheckNotice = new SqlDataAdapter("Select Title,Message,Date From NoticeDetails Where (NoticeStatus='1' AND SemesterId='0' AND StudentId='0') OR (NoticeStatus='1' AND NoticeDetails.StudentId='" + StudentId1 + "' OR NoticeDetails.SemesterId='" + SemesterId + "') ", con);
                       DataSet ds9 = new DataSet();
                       CheckNotice.Fill(ds9);
                       if (ds9.Tables[0].Rows.Count <= 0)
                       {
                           NoticeBoard1.Visible = false;
                       }
                       int i = 0;
                       string s="";
                       while(i<ds9.Tables[0].Rows.Count)                 
                       {
                           s += "<b style=font-size:15px>Notice(" + i + ")" + "</b>" + "<b>Title</b>" +" :"+ ds9.Tables[0].Rows[i][0].ToString() +" <span style=font-size:14px>[Message:"+ ds9.Tables[0].Rows[i][1].ToString() +"<span style='font-size:11px'>  Sending Date"+ds9.Tables[0].Rows[i][2].ToString() +"</span>"+ "  ] </span>"; 
                           NoticeBoard1.Text = "<marquee>"+s+"</marquee>";
                           i++;
                       }
                   }
                   catch (Exception err)
                   {
                       Error.Text = "Check Notice Field Dataset ds9";
                   }
                 

                    SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select TeacherTimeTable.Day,TeacherTimeTable.Time,TeachertimeTable.SubjectId,SubjectDetails.SubjectName,TeacherDetails.TeacherName,TeacherTimeTable.RoomNo From TeacherTimeTable Inner Join SubjectDetails On(SubjectDetails.SubjectId=TeacherTimeTable.SubjectId) Inner Join TeacherDetails On (TeacherTimeTable.TeacherId=TeacherDetails.TeacherId) Inner join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join StudentDetails On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId) Where StudentDetails.StudentId='"+StudentId1+"' And TeacherTimeTable.Day='" + System.DateTime.Today.ToString("dddd") + "'", con);
                    DataSet ds = new DataSet();
                    SelectTimeTable.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();


                  //Semester Starting And Ending Date
                    try
                    {
                        SqlDataAdapter SemStaAndEnd = new SqlDataAdapter("Select SemesterDetailsN.SemesterStartingDate,SemesterDetailsN.SemesterEndingDate From SemesterDetailsN Inner Join StudentDetails  On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId )Where StudentDetails.StudentId='" + StudentId1 + "'", con);
                        DataSet ds2 = new DataSet();
                        SemStaAndEnd.Fill(ds2);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            Start = Convert.ToDateTime(ds2.Tables[0].Rows[0][0]);
                            End = Convert.ToDateTime(ds2.Tables[0].Rows[0][1]);
                        }
                    }
                    catch (Exception err)
                    {
                        Error.Text = "Semester Starting And Ending Date Field Dataset ds2";
                    }

                    //Total Lac ds2
                    SqlDataAdapter SelTotalLac = new SqlDataAdapter("Select Count(StudentAttendance.AttendanceStatus) From StudentAttendance Inner Join SubAllByStu On (SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo) Where SubAllByStu.StudentId='" + StudentId1 + "'", con);
                        DataSet ds1 = new DataSet();
                        SelTotalLac.Fill(ds1);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            TotalLac.Text = ds1.Tables[0].Rows[0][0].ToString();
                        }
                    
                    
                    

                    //Attend Lac

                    SqlDataAdapter SelTotalAttend = new SqlDataAdapter("Select Count(StudentAttendance.AttendanceStatus) From StudentAttendance Inner Join SubAllByStu On (SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo) Where SubAllByStu.StudentId='" + StudentId1 + "' AND StudentAttendance.AttendanceStatus='1'", con);
                    DataSet ds3 = new DataSet();
                    float totlac,Attend1,Totalpercent;

                    SelTotalAttend.Fill(ds3);
                    Attend.Text = ds3.Tables[0].Rows[0][0].ToString();

                    Attend1= (float)(Convert.ToInt32(ds3.Tables[0].Rows[0][0]));
                    totlac=(float)(Convert.ToInt32(ds1.Tables[0].Rows[0][0]));
                    if (totlac == 0)
                    {
                        Totalpercent = 0;
                    }
                    else
                    {
                        Totalpercent = ((Attend1 / totlac) * 100);
                    }
                    Percentage.Text=((int)Totalpercent).ToString()+"%";


                    //Total Fine

                    SqlDataAdapter SelectTotalLac = new SqlDataAdapter("Select Count(StudentAttendance.AttendanceStatus) From StudentAttendance Inner Join SubAllByStu On (SubAllByStu.SubjectAllocationNo=StudentAttendance.SubjectAllocationNo) Where SubAllByStu.StudentId='" + StudentId1 + "' AND StudentAttendance.AttendanceStatus='0' AND StudentAttendance.LeaveRequest='0' ", con);
                    DataSet ds4 = new DataSet();
                    SelectTotalLac.Fill(ds4);

                    SqlDataAdapter PerDayFineCharge = new SqlDataAdapter("Select FinePerDay From FineDetails  Inner Join StudentDetails On (StudentDetails.SemesterId=FineDetails.SemesterId)Where StudentDetails.StudentId='" + StudentId1 + "'", con);
                    DataSet ds6 = new DataSet();
                    PerDayFineCharge.Fill(ds6);
                    if (ds6.Tables[0].Rows.Count > 0)
                    {
                        FinePerDay = Convert.ToInt32(ds6.Tables[0].Rows[0][0]);
                    }
                    Fine.Text = "Rs."+(Convert.ToInt32((ds4.Tables[0].Rows[0][0])) * FinePerDay).ToString();


                }
                else
                {
                    Response.Redirect("~/LogInFolder/StudentLogIn.aspx");
                }
            }
        }
        protected void Day_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (Day.SelectedIndex > 0)
            {
                SqlDataAdapter SelectTimeTable = new SqlDataAdapter("Select TeacherTimeTable.Day,TeacherTimeTable.Time,TeachertimeTable.SubjectId,SubjectDetails.SubjectName,TeacherDetails.TeacherName,TeacherTimeTable.RoomNo From TeacherTimeTable Inner Join SubjectDetails On(SubjectDetails.SubjectId=TeacherTimeTable.SubjectId) Inner Join TeacherDetails On (TeacherTimeTable.TeacherId=TeacherDetails.TeacherId) Inner join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join StudentDetails On(StudentDetails.SemesterId=SemesterDetailsN.SemesterId) Where StudentDetails.StudentId='"+StudentId1+"' AND TeachertimeTable.Day='" + Day.SelectedItem.Text + "'", con);
                DataSet ds = new DataSet();
                SelectTimeTable.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
        
    }
}