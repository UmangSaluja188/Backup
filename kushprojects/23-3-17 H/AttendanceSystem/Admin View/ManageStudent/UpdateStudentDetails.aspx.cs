using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace AttendanceSystem.AdminPage
{
    public partial class UpdateStudentDetails : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);  
        public string[] arr = new string[10];
        public static  int SemesterNoValue, i = 0,NewCourseIdValue=0,SemesterNewNo=0;
        public static int   CourseIdValue, SelectedSubject, courseIDValue, NSemesterId, PName = 0,SemId=0;
        public string SemesterN,courseN, PFather, PMother, PAddress, PDateOfBirth, PAge, PEmail, PImage, PCourse;
        public int PContactNo, PSemester;
        public static string path,BirthDate="";
        string StudentId;
        protected void Page_Load(object sender, EventArgs e)
        {
          //Query String
           
                StudentId = Request.QueryString["StudentId"];
                if (!IsPostBack)
                {
                    int i, j;
                    SqlDataAdapter SelState = new SqlDataAdapter("Select Distinct State From AllAddress", con);
                    DataSet ds = new DataSet();
                    SelState.Fill(ds);
                    State.DataSource = ds;
                    State.DataTextField = "State";
                    State.DataValueField = "State";
                    State.DataBind();
                    i = 0;
                    j = ds.Tables[0].Rows.Count;
                    State.Items.Insert(0, "Select State...");
                    State.Items.Insert(j + 1, "Others...");

                    addYear();
                   
                    USDetails();

                     enabledDisabled(true);
                   
                    if (Request.QueryString["mode"].ToString().ToLower() == "details")
                    {
                        
                        Label1.Text = "Student Details";
                        Roll.ReadOnly = true;
                        Name.ReadOnly = true;
                        Father.ReadOnly = true;
                        MotherName.ReadOnly = true;
                        Name.ReadOnly = true;
                        Course.Enabled = false;
                        Semester.Enabled = false;                   
                        Email.ReadOnly = true;
                        ContactNo.ReadOnly = true;
                        Gender.Enabled = false;
                        FileUpload1.Visible = false;
                        Upload.Visible = false;
                        Update.Visible = false;
                        Cancel.Visible = false;
                        CheckBoxList1.Enabled = false;
                        Day.Enabled = false;
                        Month.Enabled = false;
                        Year.Enabled = false;
                        State.Enabled = false;
                        District.Enabled = false;
                        Teh1.ReadOnly = true;
                        PinCode.ReadOnly = true;
                        CityVill.ReadOnly = true;
                        TextBox1.ReadOnly = true;

                    }
                }
            
          
        }
        private void addYear()
        {
            DateTime CurrentDate = new DateTime();
            int TYear, MinYear, i;
            CurrentDate = Convert.ToDateTime(System.DateTime.Today.ToShortDateString());
            TYear = CurrentDate.Year;
            MinYear = TYear - 17;
            i = MinYear - 50;
            while (i <= MinYear)
            {
                Year.Items.Add("" + i);
                i++;
            }


        }


        private void enabledDisabled(bool p)
        {
            Roll.Enabled = false;
            Name.Enabled = p;
            MotherName.Enabled =p;
            Father.Enabled = p;
            Day.Enabled = p;
            Month.Enabled = p;
            Year.Enabled = p;
            Course.Enabled = p;
            Semester.Enabled = p;
            FileUpload1.Enabled = p;
            ContactNo.Enabled = p;
         
            Gender.Enabled = p;
            Email.Enabled = p;
            Upload.Enabled = p;
            Update.Enabled = p;
            Cancel.Enabled = p;
          
        }
            private void USDetails()
            {
                //Search All detailos Of Selected Student
                int Day1, Month1, Year1,l=0,m=0,n=0;
                SqlDataAdapter SearchStudent = new SqlDataAdapter("Select StudentId From StudentDetails Where StudentId='" + StudentId + "'", con);
                    DataSet SSds = new DataSet();
                    SearchStudent.Fill(SSds);
                    if (SSds.Tables[0].Rows.Count > 0)
                    {

                        enabledDisabled(true);

                        SqlCommand SelectCourseName = new SqlCommand("Select CourseName from CourseDetails", con);
                        con.Open();
                        SqlDataReader red0 = SelectCourseName.ExecuteReader();
                        Course.DataSource = red0;
                        Course.DataTextField = "CourseName";
                        Course.DataValueField = "CourseName";
                        Course.DataBind();
                        con.Close();
                        Course.Items.Insert(0, "Select...");
                        Semester.Items.Insert(0, "Select...");
                         SqlDataAdapter SelectStudentDetails = new SqlDataAdapter("Select StudentDetails.*,StudentAddress.* from StudentDetails INNER JOIN StudentAddress ON(StudentDetails.StudentId=StudentAddress.StudentId)Where StudentDetails.StudentId like '"+StudentId+"'", con);
                         DataSet ds = new DataSet();
                         SelectStudentDetails.Fill(ds);
                         if(ds.Tables[0].Rows.Count>0)
                         {                          
                                Roll.Text = ds.Tables[0].Rows[0][0].ToString();                                                   
                                Name.Text =ds.Tables[0].Rows[0][1].ToString();                        
                                Father.Text =ds.Tables[0].Rows[0][2].ToString();                           
                                MotherName.Text = ds.Tables[0].Rows[0][3].ToString();                          
                                ContactNo.Text = ds.Tables[0].Rows[0][4].ToString();
                                path = ds.Tables[0].Rows[0][6].ToString();
                                Image.ImageUrl = path;
                                                                                     
                                Email.Text = ds.Tables[0].Rows[0][9].ToString();                 
                                foreach (ListItem items in Gender.Items)
                                {
                                    int i = 0;
                                    if (items.Text == ds.Tables[0].Rows[0][8].ToString())
                                    {
                                        items.Selected = true;
                                        break;
                                    }
                                    i++;
                                }
                            
                             TextBox1.Text=ds.Tables[0].Rows[0][10].ToString();

                             foreach (ListItem items in State.Items)
                             {
                                 int i = 0;
                                 if (items.Text == ds.Tables[0].Rows[0][16].ToString())
                                 {
                                     items.Selected = true;
                                     break;
                                 }
                                 i++;
                             }

                             SelectDistrict();
                             foreach (ListItem items in District.Items)
                             {
                                 int i = 0;
                                 if (items.Text == ds.Tables[0].Rows[0][15].ToString())
                                 {
                                     items.Selected = true;
                                     break;
                                 }
                                 i++;
                             }
                             DateTime BD = new DateTime();
                             BD = Convert.ToDateTime(ds.Tables[0].Rows[0][7].ToString());
                             Year1 = BD.Year;
                             Month1 = BD.Month;
                             Day1 = BD.Day;
                             foreach (ListItem items in Year.Items)
                             {
                                 Error.Text = items.Text;
                                 if (Year1.ToString() ==items.Text)
                                 {
                                   
                                     items.Selected = true;
                                     break;
                                 }
                             }
                             Error.Text = Month1.ToString() +" hh"+ Day1.ToString() +"kkk"+ Year1.ToString();
                             foreach (ListItem items in Month.Items)
                             {
                                 Error.Text = "Month " + Month1.ToString() + " Month " + items.Text;
                                 if (Month1 ==  Convert.ToInt32(items.Text.ToString()))
                                 {
                                     items.Selected = true;
                                     break;
                                 }
                             }
                             SelecDays();
                             foreach (ListItem items in Day.Items)
                             {
                                 if (Day1 == Convert.ToInt32(items.Text))
                                 {
                                     items.Selected = true;
                                     break;
                                 }
                             }
                             CityVill.Text = ds.Tables[0].Rows[0][13].ToString();
                             Teh1.Text = ds.Tables[0].Rows[0][14].ToString();
                             PinCode.Text = ds.Tables[0].Rows[0][17].ToString();

                        }
                        SemId = Convert.ToInt32(ds.Tables[0].Rows[0][5]);
                        con.Close();
                        SqlCommand SelectSemesterCourse = new SqlCommand("Select CourseDetails.*,SemesterDetailsN.* from CourseDetails Inner Join SemesterDetailsN On(CourseDetails.CourseId=SemesterDetailsN.CourseId) where SemesterId like'" + SemId + "'", con);
                        con.Open();
                        SqlDataReader red1 = SelectSemesterCourse.ExecuteReader();
                        if (red1.Read())
                        {
                            courseN = red1[1].ToString();
                            SemesterN = red1.GetString(7);
                        }
                        foreach (ListItem items in Course.Items)
                        {
                            if (items.Text == courseN)
                            {
                                items.Selected = true;
                                break;
                            }
                        }
                        con.Close();
                        SqlCommand SelectCourseId = new SqlCommand("Select CourseId From CourseDetails where CourseName like '" + Course.SelectedItem.Text + "'", con);
                        con.Open();
                        SqlDataReader red11 = SelectCourseId.ExecuteReader();
                        if (red11.Read())
                        {
                            NewCourseIdValue = red11.GetInt32(0);


                        }
                        con.Close();

                        SqlDataAdapter SelectCourseID = new SqlDataAdapter("Select CourseId,TotalNoOfSemester From CourseDetails Where CourseName='" + Course.SelectedItem.Text + "'", con);
                        DataSet SCIDds = new DataSet();
                        SelectCourseID.Fill(SCIDds);
                        CourseIdValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][0]);
                        SemesterNoValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][1]);

                        for (int i = 1; i <= SemesterNoValue; i++)
                        {
                            Semester.Items.Remove("" + i);
                        }

                        for (int i = 1; i <= SemesterNoValue; i++)
                        {
                            Semester.Items.Add("" + i);
                        }


                        Response.Write(SemId);
                        SqlDataAdapter SelectSemesterNo = new SqlDataAdapter("Select SemesterNo From SemesterDetailsN Where SemesterId='" + SemId + "'", con);
                        DataSet SSNds = new DataSet();
                        SelectSemesterNo.Fill(SSNds);
                        SemesterNewNo = Convert.ToInt32(SSNds.Tables[0].Rows[0][0]);
                        foreach (ListItem items in Semester.Items)
                        {
                            if (items.Text == SemesterNewNo.ToString())
                            {
                                items.Selected = true;
                                break;
                            }
                        }


                        SqlCommand SelectOptionalSub = new SqlCommand("Select * from SubjectDetails where SemesterId like'" + SemId + "'And SubjectOptCom like'Optional'", con);
                        con.Open();

                        SqlDataReader newRed = SelectOptionalSub.ExecuteReader();
                        CheckBoxList1.DataSource = newRed;
                        CheckBoxList1.DataValueField = "SubjectName";
                        CheckBoxList1.DataTextField = "SubjectName";
                        CheckBoxList1.DataBind();
                        con.Close();
                        SqlCommand com2 = new SqlCommand("Select SubAllByStu.*,SubjectDetails.* from SubAllByStu INNER JOIN SubjectDetails ON(SubAllByStu.SubjectId=SubjectDetails.SubjectId) where SubAllByStu.StudentId like'" + StudentId + "' AND SubjectDetails.SubjectOptCom like'O'", con);
                        con.Open();
                        SqlDataReader red3 = com2.ExecuteReader();

                        while (red3.Read())
                        {
                            arr[i] = red3.GetString(4);
                            i++;
                        }

                        foreach (ListItem NewItem in CheckBoxList1.Items)
                        {
                            for (int i = 0; i < arr.Length; i++)
                            {
                                if (NewItem.Text == arr[i])
                                {
                                    NewItem.Selected = true;
                                }
                            }
                        }

                        con.Close();
                        CheckBoxList1.Visible = true;
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">" + "alert('Invalid Search Id');" + "</script>");

                    }
            
        }

        protected void Search_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles)
            {
                string str = Server.MapPath("~/Images/" + FileUpload1.FileName);
                string filename = FileUpload1.FileName;
                if (filename.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                    filename.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    filename.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    FileUpload1.SaveAs(str);
                    path = "~/Images/" + FileUpload1.FileName;
                    Image.ImageUrl = path;
                }


            }
        }
   
    
    
    
 

        protected void Father_TextChanged(object sender, EventArgs e)
        {

        }
        
        protected void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write("Hello");
           
        }

        private void SelectSubject()
        {
            SqlDataAdapter SelectOptionalSubjects = new SqlDataAdapter("Select SubjectDetails.SubjectName From SubjectDetails  Inner Join SemesterDetailsN On(SubjectDetails.SemesterId=SemesterDetailsN.SemesterId) Inner Join CourseDetails On(SemesterDetailsN.CourseId=CourseDetails.CourseId) Where CourseDetails.CourseName='"+Course.SelectedItem.Text+"' AND SubjectDetails.SubjectOptCom='Optional' AND SemesterDetailsN.SemesterNo='"+Semester.SelectedItem.Text+"'", con);
            DataSet SelectOptionalSubjectsds = new DataSet();
            SelectOptionalSubjects.Fill(SelectOptionalSubjectsds);
            if (SelectOptionalSubjectsds.Tables[0].Rows.Count > 0)
            {
                CheckBoxList1.DataSource = SelectOptionalSubjectsds;
                CheckBoxList1.DataTextField = "SubjectName";
                CheckBoxList1.DataValueField = "SubjectName";
                CheckBoxList1.DataBind();
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            //Update Student Details
            BirthDate += Month.SelectedItem.Text +"/"+ Day.SelectedItem.Text + "/" + Year.SelectedItem.Text;
            Error.Text = BirthDate.ToString();
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand com = new SqlCommand("Select Distinct CourseId From CourseDetails where CourseName like @SelectedCourse", con);
                com.Parameters.AddWithValue("@SelectedCourse", Course.SelectedItem.Text);
                con.Open();
                SqlDataReader red = com.ExecuteReader();
                if (red.Read())
                {
                    courseIDValue = red.GetInt32(0);


                }
                con.Close();
                SqlCommand SelecteSemesterId = new SqlCommand("Select SemesterId from SemesterDetailsN where SemesterNo like @SemesterNo AND CourseId like '" + courseIDValue + "'", con);
                SelecteSemesterId.Parameters.AddWithValue("@SemesterNo", Semester.SelectedItem.Text);

                con.Open();
                SqlDataReader red2 = SelecteSemesterId.ExecuteReader();
                if (red2.Read())
                {
                    NSemesterId = red2.GetInt32(0);
                }
                con.Close();
                SqlCommand Ncom = new SqlCommand("Update StudentDetails Set StudentName= '" + Name.Text + "',StudentFather='" + Father.Text + "',StudentMother='" + MotherName.Text + "',DateOfBirth='" + Convert.ToDateTime(BirthDate).ToString("yyyy/MM/dd") + "',Email='" + Email.Text + "',Gender=@Gendervalue,ContactNo='" + ContactNo.Text + "',Image=@Photo,SemesterId='" + NSemesterId + "' where StudentId='" + StudentId + "'", con);
                Ncom.Parameters.AddWithValue("@Gendervalue", Gender.SelectedItem.Text);
                Ncom.Parameters.AddWithValue("@Photo",path);
                con.Open();
                Ncom.ExecuteNonQuery();
                con.Close();

              
            }
            catch (Exception err)
            {
                Error.Text = "Update Student Details Portiuon " + err.Message;
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            USDetails();
            

        }

        protected void Course_SelectedIndexChanged1(object sender, EventArgs e)
        {
            SelectSubject();
        }

        protected void Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectSubject();
        }
        protected void State_SelectedIndexChanged(object sender, EventArgs e)
        {

            SelectDistrict();
        }

        private void SelectDistrict()
        {
            int i, j;
            SqlDataAdapter SelDistrict = new SqlDataAdapter("Select Distinct District From AllAddress Where State='" + State.SelectedItem.Text + "'", con);
            DataSet ds = new DataSet();
            SelDistrict.Fill(ds);
            District.DataSource = ds;
            District.DataTextField = "District";
            District.DataValueField = "District";
            District.DataBind();
            i = 0;
            j = ds.Tables[0].Rows.Count;
            District.Items.Insert(0, "Select District...");
            District.Items.Insert(j + 1, "Others...");
            if (State.SelectedItem.Text == "Others...")
            {
                StateName.Visible = true;
                DistrictPanel.Visible = false;
                Panel1.Visible = true;

            }
            else
            {
                StateName.Visible = false;
                DistrictPanel.Visible = true;
                Panel1.Visible = false;
            }
        }
        protected void District_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Day_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Month_SelectedIndexChanged(object sender, EventArgs e)
        {

            SelecDays();

        }

        private void SelecDays()
        {
            int Nmonth, Days, Year1, i = 1;
            Nmonth = Month.SelectedIndex+1;
            Error.Text = Nmonth.ToString();
            Year1 = Convert.ToInt32(Year.SelectedItem.Text.Trim());
            Days = DateTime.DaysInMonth(Year1, Nmonth);
            while (i <= Days)
            {
                Day.Items.Add("" + i);
                i++;

            }
        }
}
}