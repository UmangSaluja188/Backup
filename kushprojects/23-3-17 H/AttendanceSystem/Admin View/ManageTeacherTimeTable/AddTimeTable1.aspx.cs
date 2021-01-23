using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AttendanceSystem.ManageTeacherTimeTable
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static string TimeTableNo;

        public static int DepartmentIdValue, CourseIdValue, SemesterIdValue, SubjectIdValue, RoomNoN, SubjectId, SemesterNo,TeacherIdValue,value;
        public static string DepartmentName, CourseName, SubjectsName, DayName, Time, RoomTypeN, SelectedTimeValue, SelectedDayVale, SelectedRTValue;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            //Select Teacher Time Table
            if (!IsPostBack)
            {
                //if (Session["AdminId"] == null)
                //{

                //    Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                //}
            }

            try
            {
                if (!IsPostBack)
                {
                    int min1, min2, hours1, hours2, totalmin1, totalLacture, subtracthours, subtractmin, lacmin, lachours, totallacmin;
                    SqlDataAdapter SelectCollegeTiming = new SqlDataAdapter("Select * From CollegeTiming", con);
                    DataSet SCTds = new DataSet();
                    SelectCollegeTiming.Fill(SCTds);
                    string StartingTime, CloseingTime, periodDuration;
                    StartingTime = SCTds.Tables[0].Rows[3][0].ToString();
                    CloseingTime = SCTds.Tables[0].Rows[3][1].ToString();
                    periodDuration = SCTds.Tables[0].Rows[3][2].ToString();

                    DateTime Open = Convert.ToDateTime(StartingTime);
                    DateTime Close = Convert.ToDateTime(CloseingTime);
                    DateTime LacDur = Convert.ToDateTime(periodDuration);
                   
                    lachours = LacDur.Hour;
                    lacmin = LacDur.Minute;
                    totallacmin = (lachours * 60) + lacmin;
                    hours1 = Close.Hour;
                    min1 = Close.Minute;
                    Close.IsDaylightSavingTime();

                    hours2 = Open.Hour;
                    min2 = Open.Minute;
                    subtracthours = hours1 - hours2;
                    subtractmin = min1 - min2;
                    totalmin1 = (subtracthours * 60) + subtractmin;
                    l11.Text = totalmin1.ToString();
                    totalLacture = totalmin1 / totallacmin;
                    
                    Response.Write(totalLacture);
                    DateTime lacTime = new DateTime();
                    lacTime = Open;
                    int a = Open.Minute;
                    TimePeriod.Items.Insert(0, "Select Time...");
                    for (int i = 1; i <= totalLacture; i++)
                    {
                        TimePeriod.Items.Add(Open.AddMinutes(a).ToString("hh:mm:ss tt"));

                        a = a + totallacmin;


                    }
                  
                    //Select Department Name

                    SqlCommand com = new SqlCommand("Select * from NewDepartmentDetails", con);
                    con.Open();
                    SqlDataReader red = com.ExecuteReader();

                    Department.DataSource = red;
                    Department.DataTextField = "NDepartmentName";
                    Department.DataValueField = "NDepartmentName";
                    Department.DataBind();
                    Department.Items.Insert(0, "Select Department...");
                    Course.Items.Insert(0, "Select Course...");
                    Semester.Items.Insert(0, "Select Semester...");
                    Subjects.Items.Insert(0, "Select Subject...");
                    TimePeriod.Items.Insert(0, "Select Time...");

                    con.Close();

                    TimePeriod.Items[0].Enabled = false;

                    //Teacher Time Table In Edit Mode
                    if (Request.QueryString["mode"].ToString().ToLower() == "edit")
                    {
                        Head.Text = "Update Teacher Time Table";
                        AddPanel.Visible = false;
                        UpdatePanel.Visible = true;
                        TimeTableNo = Request.QueryString["TimeTableNo"];
                        Response.Write("Hello" + TimeTableNo);
                        SqlDataAdapter SearchDetails = new SqlDataAdapter("Select TeacherTimeTable.*,SubjectDetails.SubjectName,SemesterDetailsN.SemesterId,SemesterDetailsN.SemesterNo,CourseDetails.CourseId,CourseDetails.CourseName,NewDepartmentDetails.* From TeacherTimeTable Inner Join SubjectDetails On (TeacherTimeTable.SubjectId=SubjectDetails.SubjectId) inner Join SemesterDetailsN On (SubjectDetails.SemesterId=SemesterDetailsN.SemesterId) inner Join CourseDetails On (SemesterDetailsN.CourseId=CourseDetails.CourseId) Inner Join NewDepartmentDetails On (CourseDetails.NDepartmentId=NewDepartmentDetails.NDepartmentId) Where TeacherTimeTable.TimeTableNo='" + TimeTableNo + "'", con);
                        DataSet ds = new DataSet();
                        SearchDetails.Fill(ds);
                      
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TeacherIdValue = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                            SubjectId = Convert.ToInt32(ds.Tables[0].Rows[0][2]);
                            DayName = ds.Tables[0].Rows[0][3].ToString();
                            Time = ds.Tables[0].Rows[0][4].ToString();
                            RoomNoN = Convert.ToInt32(ds.Tables[0].Rows[0][5]);
                            RoomTypeN = ds.Tables[0].Rows[0][6].ToString();
                            SubjectsName = ds.Tables[0].Rows[0][7].ToString();
                            SemesterIdValue = Convert.ToInt32(ds.Tables[0].Rows[0][8]);
                            SemesterNo = Convert.ToInt32(ds.Tables[0].Rows[0][9]);
                            CourseIdValue = Convert.ToInt32(ds.Tables[0].Rows[0][10]);
                            CourseName = ds.Tables[0].Rows[0][11].ToString();
                            DepartmentIdValue = Convert.ToInt32(ds.Tables[0].Rows[0][12]);
                            DepartmentName = ds.Tables[0].Rows[0][13].ToString();


                            TeacherId.Text = TeacherIdValue.ToString();
                            RoomNo.Text = RoomNoN.ToString();




                            //Select Course Name
                            SqlDataAdapter SelectCourseName = new SqlDataAdapter("Select CourseName From CourseDetails Where NDepartmentId='" + DepartmentIdValue + "'", con);
                            DataSet SCNds = new DataSet();
                            SelectCourseName.Fill(SCNds);
                            Course.DataSource = SCNds;
                            Course.DataTextField = "CourseName";
                            Course.DataValueField = "CourseName";
                            Course.DataBind();
                          

                            //Select Semester No
                            SqlDataAdapter SelectSemesterNo = new SqlDataAdapter("Select SemesterNo From SemesterDetailsN Where CourseId='" + CourseIdValue + "'", con);
                            DataSet SSNds = new DataSet();
                            SelectSemesterNo.Fill(SSNds);
                            Semester.DataSource = SSNds;
                            Semester.DataTextField = "SemesterNo";
                            Semester.DataValueField = "SemesterNo";
                            Semester.DataBind();
                          

                            //Select Subject Name
                            SqlDataAdapter SelectSubjectName = new SqlDataAdapter("Select SubjectName From SubjectDetails Where SemesterId='" + SemesterIdValue + "'", con);
                            DataSet SSUBNds = new DataSet();
                            SelectSubjectName.Fill(SSUBNds);
                            Subjects.DataSource = SSUBNds;
                            Subjects.DataTextField = "SubjectName";
                            Subjects.DataValueField = "SubjectName";
                            Subjects.DataBind();
                          
                            int i = 0, j = 0, k = 0, l = 0, m = 0, SelectedIndex = 0;

                            //Select Department Name From DropdownList
                            foreach (ListItem item1 in Department.Items)
                            {
                                if (item1.Text.ToString().Trim() == DepartmentName)
                                {
                                    SelectedIndex = i;
                                }
                                i++;
                            }
                            Department.SelectedIndex = SelectedIndex;

                            //Select Course From DropdownList
                            foreach (ListItem item2 in Course.Items)
                            {
                                if (item2.Text.ToString().Trim() == CourseName)
                                {
                                    SelectedIndex = j;
                                }
                                j++;
                            }
                            Course.SelectedIndex = SelectedIndex;


                            //Select Semester No From DropdownList
                            foreach (ListItem item3 in Semester.Items)
                            {
                                if (item3.Text.ToString().Trim() == SemesterNo.ToString())
                                {
                                    SelectedIndex = k;
                                }
                                k++;
                            }
                            Semester.SelectedIndex = SelectedIndex;
                            //Select Subject Name From From DropdownList
                            foreach (ListItem item4 in Subjects.Items)
                            {
                                if (item4.Text.ToString().Trim() == SubjectsName.ToString())
                                {
                                    SelectedIndex = l;
                                }
                                l++;
                            }
                            Subjects.SelectedIndex = SelectedIndex;
                            l = 0;
                            //Select Day From DropdownList
                            foreach (ListItem item5 in Day.Items)
                            {
                                if (item5.Text.ToString().Trim() == DayName.ToString())
                                {
                                    SelectedIndex = l;
                                }
                                l++;
                            }
                            Day.SelectedIndex = SelectedIndex;
                            //Select Time From DropdownList
                            l = 0;
                            foreach (ListItem item6 in TimePeriod.Items)
                            {
                                if (item6.Text.ToString().Trim() == Time.ToString().Trim())
                                {
                                    SelectedIndex = l;
                                    Response.Write("HelloKaul");
                                }
                                l++;
                            }
                            TimePeriod.SelectedIndex = SelectedIndex;

                            l = 0;
                            //Select Room Type From DropdownList
                            foreach (ListItem item6 in RoomType.Items)
                            {
                                if (item6.Text.ToString().Trim() == RoomTypeN.ToString())
                                {
                                    SelectedIndex = l;
                                }
                                l++;
                            }
                            RoomType.SelectedIndex = SelectedIndex;
                        }

                    }

                    if (Request.QueryString["mode"] == "add")
                    {
                        AddPanel.Visible = true;
                        UpdatePanel.Visible = false;
                    }

                }
            }
            catch (Exception err)
            {
                Error.Text = "Search Teacher time table Details Portion "+err.Message;
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
          //Insert Teacher Time Table
            try
            {
                if (value == 1)
                {
                    SqlDataAdapter SelDupTimeTable = new SqlDataAdapter("Select *  From TeacherTimeTable  Where TeacherId='" + TeacherId.Text + "'AND Day='" + SelectedDayVale + "' AND Time='" + SelectedTimeValue + "'AND SubjectId='" + SubjectIdValue + "'", con);
                    DataSet ds = new DataSet();
                    SelDupTimeTable.Fill(ds);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SqlDataAdapter InsertValues = new SqlDataAdapter("Insert Into TeacherTimeTable(TeacherId,SubjectId,Day,RoomNo,RoomType,Time) Values ('" + TeacherId.Text + "','" + SubjectIdValue + "','" + SelectedDayVale + "','" + RoomNo.Text + "','" + SelectedRTValue + "','" + SelectedTimeValue + "')", con);
                        DataSet InsertDS = new DataSet();
                        InsertValues.Fill(InsertDS);
                        Response.Write("<script type=\"text/javascript\">" + "alert('The Record Are Successfull Insert');" + "</script>");

                        //reset();
                    }

                    else
                    {
                        Response.Write("<script type=\"text/javascript\">" + "alert('These Record are already present in the database');" + "</script>");

                    }

                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">" + "alert('Please Enter Valid Teacher Id');" + "</script>");
                }
            }
            catch (Exception err)
            {
                Error.Text = "Insert Teacher time table Details Portion " + err.Message;
            }
        }

        private void reset()
        {
            Department.SelectedIndex = 0;
            Course.SelectedIndex = 0;
            Semester.SelectedIndex = 0;
            Subjects.SelectedIndex = 0;
            Day.SelectedIndex = 0;
            TimePeriod.SelectedIndex = 0;
            RoomType.SelectedIndex = 0;
            RoomNo.Text = "";
            TeacherId.Text = "";
        }


        protected void Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Department id
            try
            {

                if (Department.SelectedIndex != 0)
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select NDepartmentId From NewDepartmentDetails Where NDepartmentName='" + Department.SelectedItem.Text + "'", con);
                    DataSet ds1 = new DataSet();
                    da.Fill(ds1, "Table(0)");
                    DepartmentIdValue = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);

                    if (Request.QueryString["mode"] == "add")
                    {
                        SqlDataAdapter da1 = new SqlDataAdapter("Select Distinct CourseName From CourseDetails Where NDepartmentId ='" + DepartmentIdValue + "' ", con);
                        da1.Fill(ds1, "Table(1)");
                        ds1.Tables[0].Merge(ds1.Tables[1]);
                        Course.DataSource = ds1.Tables[1];
                        Course.DataTextField = "CourseName";
                        Course.DataValueField = "CourseName";
                        Course.DataBind();
                        Course.Items.Insert(0, "Select Course");
                    }
                }
            }
            catch (Exception err)
            {
                Error.Text = "Select Department id Portion " + err.Message;
            }
        }
        protected void Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Semester id
            try
            {
                if (Semester.SelectedIndex != 0)
                {
                    SqlDataAdapter da3 = new SqlDataAdapter("Select SemesterId From SemesterDetailsN Where SemesterNo='" + Semester.SelectedItem.Text + "' AND CourseId='" + CourseIdValue + "'", con);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3, "Table(0)");
                    SemesterIdValue = Convert.ToInt32(ds3.Tables[0].Rows[0][0]);

                    if (Request.QueryString["mode"] == "add")
                    {
                        SqlDataAdapter da4 = new SqlDataAdapter("Select SubjectName From SubjectDetails Where SemesterId='" + SemesterIdValue + "'", con);
                        da4.Fill(ds3, "Table(1)");
                        ds3.Tables[0].Merge(ds3.Tables[1]);
                        Subjects.DataSource = ds3.Tables[1];
                        Subjects.DataTextField = "SubjectName";
                        Subjects.DataValueField = "SubjectName";
                        Subjects.DataBind();
                        Subjects.Items.Insert(0, "Select Subject");
                    }
                }
            }
            catch (Exception err)
            {
                Error.Text = "Select Semester id Portion " + err.Message;
            }
        }
        protected void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select Course id
            try
            {
                if (Course.SelectedIndex != 0)
                {
                    SqlDataAdapter SelectCourseId = new SqlDataAdapter("Select CourseId From CourseDetails Where CourseName='" + Course.SelectedItem.Text + "'", con);
                    DataSet SCIds = new DataSet();
                    SelectCourseId.Fill(SCIds);
                    CourseIdValue = Convert.ToInt32(SCIds.Tables[0].Rows[0][0]);

                    if (Request.QueryString["mode"] == "add")
                    {
                        SqlDataAdapter da2 = new SqlDataAdapter("Select SemesterNo,SemesterId From SemesterDetailsN Where CourseId='" + CourseIdValue + "'", con);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
//SemesterIdValue = Convert.ToInt32(ds2.Tables[0].Rows[0]["SemesterId"]);
                        Semester.DataSource = ds2.Tables[0];
                        Semester.DataTextField = "SemesterNo";
                        Semester.DataValueField = "SemesterNo";
                        Semester.DataBind();
                        Semester.Items.Insert(0, "Select Semester");
                    }
                }
            }
            catch (Exception err)
            {
                Error.Text = "Select Course id Portion " + err.Message;
            }
        }
        protected void Subjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select subject id
            try
            {
                if (Subjects.SelectedIndex != 0)
                {
                    SqlDataAdapter SubjectId = new SqlDataAdapter("Select SubjectId From SubjectDetails Where SubjectName='" + Subjects.SelectedItem.Text + "'AND SemesterId='" + SemesterIdValue + "'", con);
                    DataSet SIds = new DataSet();
                    SubjectId.Fill(SIds);
                    SubjectIdValue = Convert.ToInt32(SIds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception err)
            {
                Error.Text = "Select Subject Id Portion " + err.Message;
            }
        }

       

        protected void Update_Click(object sender, EventArgs e)
        {
            //Update Teacher Time Table
            try
            {
                Response.Write(TimeTableNo);
                SqlDataAdapter UpdateTeacherTimeTable = new SqlDataAdapter("Update TeacherTimeTable Set TeacherId='" + TeacherId.Text + "',SubjectId='" + SubjectIdValue + "',Day='" + SelectedDayVale + "',Time='" + SelectedTimeValue + "',RoomNo='" + RoomNo.Text + "',RoomType='" + SelectedRTValue + "' Where TimeTableNo='" + TimeTableNo + "'", con);
                DataSet UTTds = new DataSet();
                UpdateTeacherTimeTable.Fill(UTTds);
            }
            catch (Exception err)
            {
                Error.Text = "Update Teacher time table Details Portion " + err.Message;
            }
        }

        protected void Check_Click(object sender, EventArgs e)
        {
            //Check TeacherId Are Present In The Database Or Not
            try
            {
                SqlDataAdapter CheckTeacherArepresent = new SqlDataAdapter("Select TeacherId From TeacherDetails Where TeacherId='" + TeacherId.Text + "'", con);
                DataSet CTAPds = new DataSet();
                CheckTeacherArepresent.Fill(CTAPds);
                if (CTAPds.Tables[0].Rows.Count > 0)
                {
                    Label1.Text = "Valid";
                }
                else
                {
                    Label1.Text = "InValid";
                }
            }
            catch (Exception err)
            {
                Error.Text = "Check teacher id Portion " + err.Message;
            }
        }

        protected void Cencel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin View/ManageTeacherTimeTable/SearchTimeTable.aspx");
        }

        protected void Day_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Day.SelectedIndex > 0)
            {
                SelectedDayVale = Day.SelectedItem.Text;
            }
        }

        protected void RoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RoomType.SelectedIndex>0)
            {
                SelectedRTValue = RoomType.SelectedItem.Text;
            }
        }

        protected void TimePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TimePeriod.SelectedIndex > 0)
            {
                SelectedTimeValue = TimePeriod.Text;
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void TeacherId_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void TeacherId_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter CheckTeacherArepresent = new SqlDataAdapter("Select TeacherId From TeacherDetails Where TeacherId='" + TeacherId.Text + "'", con);
                DataSet CTAPds = new DataSet();
                CheckTeacherArepresent.Fill(CTAPds);
                //if (CTAPds.Tables[0].Rows.Count > 0)
                //{
                //    Label1.Text = "Valid";
                //}
                //else
                //{
                //    Label1.Text = "InValid";
                //}
            }
            catch (Exception err)
            {
                Error.Text = "Check teacher id Portion " + err.Message;
            }
        }



        protected void C1_ServerValidate(object source, ServerValidateEventArgs args)
        {        
            //SqlDataAdapter CheckTeacherArepresent = new SqlDataAdapter("Select TeacherId From TeacherDetails Where TeacherId='" + TeacherId.Text + "'", con);
            //DataSet CTAPds = new DataSet();
            //CheckTeacherArepresent.Fill(CTAPds);
            //if (CTAPds.Tables[0].Rows.Count > 0)
            //{
            //    args.IsValid = true;
            //}
            //else
            //{
            //    args.IsValid = false;
            //}
        }

        protected void TeacherId_TextChanged2(object sender, EventArgs e)
        {
            //Check TeacherId Are Present In The Database Or Not
            try
            {
                SqlDataAdapter CheckTeacherArepresent = new SqlDataAdapter("Select TeacherId From TeacherDetails Where TeacherId='" + TeacherId.Text + "'", con);
                DataSet CTAPds = new DataSet();
                CheckTeacherArepresent.Fill(CTAPds);
                if (CTAPds.Tables[0].Rows.Count > 0)
                {
                    Label1.Text = "Valid";
                    value = 1;
                }
                else
                {
                    value = 0;
                    Label1.Text = "InValid";
                }
            }
            catch (Exception err)
            {
                Error.Text = "Check teacher id Portion " + err.Message;
            }
        }
}
}