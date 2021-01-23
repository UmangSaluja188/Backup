using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AttendanceSystem.AdminPage
{
   
    public partial class AddNewStu : System.Web.UI.Page
    {
        string value;
        int index1;
        static Int32 Total;
       static int StudentRollNo;
       static int RollNoValue;
       public static string path,BirthDate="";
       public static int courseIDValue = 0, TotalSemester = 0, SubjectID = 0, SemesterId = 0, SemesterIdForSbject = 0,SemesterNoValue,CourseIdValue,SemesterIdValue,SemesterNo,RollNoStart=0,Max=0,NewRollNoValue=100001;
       static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
       SqlConnection con = new SqlConnection(cs);    
      
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
            if (!IsPostBack)
            {
                
                if (Session["AdminId"] == null)
                {

                    Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
                int i, j;
              

                Semester.Enabled = false;
                RollNo.Enabled = false;
               
                string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
               
                    //Select Course name for Dropdownlist
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

                    try
                    {

                        SqlCommand com = new SqlCommand("Select  CourseName from CourseDetails", con);
                        con.Open();
                        SqlDataReader red = com.ExecuteReader();
                        Course.DataSource = red;
                        Course.DataTextField = "CourseName";

                        Course.DataValueField = "CourseName";
                        Course.DataBind();
                        con.Close();
                        Course.Items.Insert(0, "Select Course");
                        Semester.Items.Insert(0, "Select Semester");
                        addYear();
                       
                    }
                
                    catch (Exception err)
                    {
                        Error1.Text = "Course Name Portiuon " + err.Message;
                    }
                }
            
        }

        private void addYear()
        {
            DateTime CurrentDate = new DateTime();
            int TYear,MinYear,i;
            CurrentDate = Convert.ToDateTime(System.DateTime.Today.ToShortDateString());
            TYear = CurrentDate.Year;
            MinYear = TYear -17;
            i=MinYear-50;
            while (i <= MinYear)
            {
                Year.Items.Add(""+i);
                i++;
            }
          

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
         //Validator1.Type = ValidationDataType.Date;
         //   Validator1.MinimumValue = "20-5-2010";
         //Validator1.MaximumValue = "20-10-2016";
        }
        private void SelectSemesterId()
        {
            //Select Semester id 
            try
            {

                SqlDataAdapter SelectSemesterIdValue = new SqlDataAdapter("Select SemesterId From SemesterDetailsN Where SemesterNo='" + Semester.SelectedItem.Text + "' AND CourseId='" + CourseIdValue + "'", con);
                DataSet SSIDVds = new DataSet();
                SelectSemesterIdValue.Fill(SSIDVds);
                Response.Write("SelectedSemester No=" + Semester.SelectedItem.Text + " " + CourseIdValue);
                if (SSIDVds.Tables[0].Rows.Count > 0)
                {
                    SemesterIdValue = Convert.ToInt32(SSIDVds.Tables[0].Rows[0][0]);
                }
              

                SelectRollNo();
            }
            catch (Exception err)
            {
                //Error1.Text = "Select Semester Id Portiuon " + err.Message;
            }

            //Select Total Semester
            try
            {
                SqlCommand com3 = new SqlCommand("Select count(SemesterNo) from SemesterDetailsN where CourseId like '" + CourseIdValue + "'", con);
                con.Open();
                int NoOfSemester = (Int32)com3.ExecuteScalar();
            }
            catch (Exception err)
            {
                Error1.Text = "Select Total Semester Portiuon " + err.Message;
            }
            int a = 0;
           
            con.Close();
           
           
        }

        private void SelectRollNo()
        {
            //Select Roll No
            //try
            //{
            //    Response.Write(System.DateTime.Now.ToLongTimeString());
            //    SqlDataAdapter SelectStartingRollNo = new SqlDataAdapter("Select StartingRollNo From StartingRollNo Where SemesterId ='" + SemesterIdValue + "'", con);
            //    DataSet SSRNds = new DataSet();
            //    SelectStartingRollNo.Fill(SSRNds);

            //    if (SSRNds.Tables[0].Rows.Count > 0)
            //    {
            //        RollNoStart = Convert.ToInt32(SSRNds.Tables[0].Rows[0][0]);
            //        Response.Write("Start Roll No=" + RollNoStart);
            //    }
            //    Response.Write("Start Roll No=" + RollNoStart);
            //}
            //catch (Exception err)
            //{
            //    Error1.Text = "Select Roll No Portiuon " + err.Message;
            //}

            //Check Student Id
            try
            {
                SqlDataAdapter Check = new SqlDataAdapter("Select StudentId From StudentDetails Where SemesterId='" + SemesterIdValue + "'", con);
                DataSet CHds = new DataSet();
                Check.Fill(CHds);

                if (CHds.Tables[0].Rows.Count > 0)
                {

                    SqlDataAdapter GenerateRollNo = new SqlDataAdapter("Select Count(StudentId) From StudentDetails", con);
                    DataSet GRNds = new DataSet();
                    GenerateRollNo.Fill(GRNds);
                    if (GRNds.Tables[0].Rows.Count > 0)
                    {
                        Max = Convert.ToInt32(GRNds.Tables[0].Rows[0][0]);
                        NewRollNoValue += Max;                  
                    }                  
                }
                RollNo.Text =NewRollNoValue.ToString();              
            }
            catch (Exception err)
            {
                Error1.Text = "Check Student Id Portion " + err.Message;
            }
            
        }
        
        private void SelectSubject()
        {        
            //Select Compulsary Subject Name
            try
            {
                SqlCommand CompulsarySubject = new SqlCommand("Select SubjectName,SubjectOptCom from SubjectDetails where SemesterId like '" + SemesterIdValue + "' AND SubjectOptCom like 'Compulsary'", con);
                con.Open();
                SqlDataReader Compulsaryred = CompulsarySubject.ExecuteReader();

                CompulsarySubjectDetails.DataSource = Compulsaryred;
                CompulsarySubjectDetails.DataValueField = "SubjectOptCom";
                CompulsarySubjectDetails.DataTextField = "SubjectName";
                CompulsarySubjectDetails.DataBind();
                con.Close();
            }
            catch (Exception err)
            {
                Error1.Text = "Check Compulsary Subject Name Portiuon " + err.Message;
            }
            
            // Select Optionally Subject from the SubjectDetails
            try
            {
                SqlCommand OptionalSubject = new SqlCommand("Select SubjectName,SubjectOptCom from SubjectDetails where SemesterId like '" + SemesterIdValue + "' AND SubjectOptCom like 'Optional'", con);

                con.Open();
                SqlDataReader Optionalred = OptionalSubject.ExecuteReader();
                OptSubjectDetails.DataSource = Optionalred;
                OptSubjectDetails.DataValueField = "SubjectOptCom";
                OptSubjectDetails.DataTextField = "SubjectName";
                OptSubjectDetails.DataBind();
                con.Close();
            }
            catch (Exception err)
            {
                Error1.Text = "Select Optional Subject Name Portion " + err.Message;
            }
            

            // Select total Compulsary subject from SubjectsDetails for Disable the compulsary subject   
            try
            {
                SqlCommand TotalCompulsarySubject = new SqlCommand("Select COUNT(SubjectOptCom) from SubjectDetails where SemesterId like '" + SemesterIdValue + "' AND SubjectOptCom like 'Compulsary'", con);
                con.Open();

                Total = (Int32)TotalCompulsarySubject.ExecuteScalar();
                con.Close();

                for (int m = 0; m < Total; m++)
                {

                    CompulsarySubjectDetails.Items[0 + m].Selected = true;
                    CompulsarySubjectDetails.Items[0 + m].Enabled = false;

                }
            }
            catch (Exception err)
            {
                Error1.Text = "Select Totalk Compulsary Subject Portiuon " + err.Message;
            }
            
        }

        private void SelectCourseId()
        {
            //Select Coures Id
            try
            {
                SqlDataAdapter SelectCourseID = new SqlDataAdapter("Select CourseId,TotalNoOfSemester From CourseDetails Where CourseName='" + Course.SelectedItem.Text + "'", con);
                DataSet SCIDds = new DataSet();
                SelectCourseID.Fill(SCIDds);
                CourseIdValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][0]);

                Semester.Enabled = true;
                for (int i = 1; i <= SemesterNoValue; i++)
                {
                    Semester.Items.Remove("" + i);
                }
                SemesterNoValue = Convert.ToInt32(SCIDds.Tables[0].Rows[0][1]);

                for (int i = 1; i <= SemesterNoValue; i++)
                {
                    if (i % 2 != 0)
                    {
                        Semester.Items.Add("" + i);
                    }
                }
            }
            catch (Exception err)
            {
                Error1.Text = "Select Id Portiuon " + err.Message;
            }
            
            Response.Write("CourseIdValue=" + CourseIdValue + "<br>");
        }
       
        protected void Upload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles)
            {
                string str = Server.MapPath("~/Images/" + FileUpload1.FileName);
                    string filename=FileUpload1.FileName;
                    if (filename.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                        filename.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        filename.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                    {
                        FileUpload1.SaveAs(str);
                        path = "~/Images/" + FileUpload1.FileName;
                      
                        Image1.ImageUrl = path;
                    }

                
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string stateValues, districtValues;
            BirthDate += Month.SelectedItem.Text + "/" + Day.SelectedItem.Text +"/" + Year.SelectedItem.Text;
            
            int SubAllocatonStart = 1;
            //Insert Student Details

            SqlDataAdapter SelectDuplicate = new SqlDataAdapter("Select RollNo From StudentDetails Where RollNo='"+RollNo1.Text+"'",con);
            DataSet ds11 = new DataSet();
            SelectDuplicate.Fill(ds11);
            if (ds11.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script type=\"text/javascript\">" + "alert('Duplicate Value')" + "</script>");
               
            }
            else
            {
                SqlDataAdapter InsertStuDet = new SqlDataAdapter("Insert Into StudentDetails (StudentId,RollNo,StudentName,StudentFather,StudentMother,ContactNo,SemesterId,Image,DateOfBirth,Gender,Email) Values('" + RollNo.Text + "','" + RollNo1.Text + "','" + Name.Text + "','" + FatherName.Text + "','" + MotherName.Text + "','" + ContactNo.Text + "','" + SemesterIdValue + "','" + path + "','" +Convert.ToDateTime(BirthDate).ToString("yyyy/MM/dd") + "','" + Gender.SelectedItem.Text + "','" + Email.Text + "')", con);
                DataSet ds1 = new DataSet();
                InsertStuDet.Fill(ds1);
                if (State.SelectedItem.Text == "Other...")
                {
                    stateValues = OtherState.Text;
                }
                else
                {
                    stateValues = State.SelectedItem.Text;
                }
                if (District.SelectedItem.Text == "Other...")
                {
                    districtValues = OthersDistrict.Text;
                }
                else
                {
                    districtValues = District.SelectedItem.Text;
                }
                SqlDataAdapter InsertAddress = new SqlDataAdapter("Insert Into StudentAddress(StudentId,CityVillage,Teh,District,State,PinCode) Values('" + RollNo.Text + "','" + CityVill.Text + "','" + Teh1.Text + "','" + districtValues + "','" + stateValues + "','" + PinCode.Text + "')", con);
                DataSet ds10 = new DataSet();
                InsertAddress.Fill(ds10);

                Response.Write("<script type=\"text/javascript\">" + "alert('Details are successfully add')" + "</script>");

                //SqlCommand com = new SqlCommand("insert into StudentDetails (StudentId,StudentName,StudentFather,StudentMother,ContactNo,Image,Address,SemesterId,DateOfBirth,Gender,Email) Values(@RollNo,@Name,@FatherName,@MotherName,@ContactNo,@Image,@Address,@SemesterId,@DateOfBirth,@Gender,@Email) ", con);
                //    com.Parameters.AddWithValue("@RollNo", RollNo.Text);

                //    com.Parameters.AddWithValue("@Name", Name.Text);
                //    com.Parameters.AddWithValue("@FatherName", FatherName.Text);
                //    com.Parameters.AddWithValue("@MotherName", MotherName.Text);
                //    com.Parameters.AddWithValue("@ContactNo", ContactNo.Text);
                //    com.Parameters.AddWithValue("@SemesterId", SemesterIdValue);

                //    com.Parameters.AddWithValue("@Address", Address.Text);
                //    com.Parameters.AddWithValue("@Image", path);
                //    com.Parameters.AddWithValue("@DateOfBirth", DateOfBirth.Text);
                //    com.Parameters.AddWithValue("@Gender", Gender.SelectedItem.Text);
                //    com.Parameters.AddWithValue("@Email", Email.Text);

                //    con.Open();
                //    com.ExecuteNonQuery();
                //    con.Close();

                resetFunction();


                foreach (ListItem Item in OptSubjectDetails.Items)
                {
                    if (Item.Selected == true)
                    {

                        SqlCommand newCommand = new SqlCommand("Select SubjectId from SubjectDetails where SemesterId like'" + SemesterIdValue + "'AND SubjectName like @SelectedSubjectName ", con);
                        newCommand.Parameters.AddWithValue("SelectedSubjectName", Item.Text);
                        con.Open();
                        SqlDataReader red = newCommand.ExecuteReader();
                        if (red.Read())
                        {
                            SubjectID = red.GetInt32(0);

                        }
                        con.Close();
                        Error1.Text = RollNo.Text;
                        SqlCommand InsertIntoSubAllByStu = new SqlCommand("Insert into SubAllByStu (StudentID,SubjectId) Values (@StudentId,@SubjectId)", con);
                        con.Open();//
                        InsertIntoSubAllByStu.Parameters.AddWithValue("@StudentId",NewRollNoValue);
                        InsertIntoSubAllByStu.Parameters.AddWithValue("@SubjectId", SubjectID);
                        InsertIntoSubAllByStu.ExecuteNonQuery();
                        con.Close();

                    }
                }

                foreach (ListItem NewItem in CompulsarySubjectDetails.Items)
                {
                    if (NewItem.Selected == true)
                    {
                        SqlCommand newCommand = new SqlCommand("Select SubjectId from SubjectDetails where SemesterId like'" + SemesterIdValue + "'AND SubjectName like '" + NewItem.Text + "'", con);
                        con.Open();
                        SqlDataReader red = newCommand.ExecuteReader();
                        if (red.Read())
                        {
                            SubjectID = red.GetInt32(0);

                        }
                        con.Close();
                        SqlCommand InsertIntoSubAllByStu = new SqlCommand("Insert into SubAllByStu (StudentID,SubjectId) Values (@StudentId,@SubjectId)", con);
                        con.Open();
                        InsertIntoSubAllByStu.Parameters.AddWithValue("@StudentId", NewRollNoValue);
                        InsertIntoSubAllByStu.Parameters.AddWithValue("@SubjectId", SubjectID);
                        InsertIntoSubAllByStu.ExecuteNonQuery();
                        con.Close();
                    }

                }

                SqlDataAdapter CreateAccounct = new SqlDataAdapter("Insert Into LoginTable (LogInType,UserId,Password) Values('Student','" + NewRollNoValue + "','Password') ", con);
                DataSet ds = new DataSet();
                CreateAccounct.Fill(ds);
            }

        }
            

        
            


        protected void Reset_Click(object sender, EventArgs e)
        {
            
            resetFunction();
            Response.Redirect("../Admin View/ManageStudent/SearchStudentDetails2.aspx");
        }

        private void resetFunction()
        {
            RollNo.Text = "";
            RollNo1.Text = "";
            Name.Text = "";
            FatherName.Text = "";
            MotherName.Text = "";
            ContactNo.Text = "";          
            Email.Text = "";
            Day.SelectedIndex = 0;
            Month.SelectedIndex = 0;
            Year.SelectedIndex = 0;
            Course.SelectedIndex = 0;
            Semester.SelectedIndex = -1;
            State.SelectedIndex = 0;
            District.SelectedIndex = 0;
            Teh1.Text = "";
            CityVill.Text = "";
            PinCode.Text = "";
            Semester.Enabled = false;
            Image1.ImageUrl = "";
           
        }

       

        private void SelectSemester()
        {


           

            //Third Command Select Total SemesterNo the from the SemesterDetailosN for Disabeling 2 4 6 semester
            SqlCommand com3 = new SqlCommand("Select count(SemesterNo) from SemesterDetailsN where CourseId like '" + courseIDValue + "'", con);
            con.Open();
            int NoOfSemester = (Int32)com3.ExecuteScalar();
            int a = 0;
            while (a < NoOfSemester)
            {
                if (a % 2 != 0)
                {
                    Semester.Items[0 + a].Enabled = false;
                }
                a = a + 1;
            }

        }
        protected void Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
  
            
        }

        
        protected void Course_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (Course.SelectedIndex > 0)
            {

                SelectCourseId();
            }
        }

        protected void Semester_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (Semester.SelectedIndex > 0)
            {
                SelectSemesterId();
                SelectSubject();
            }
        }

        protected void Country_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }

        protected void State_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i, j;
            SqlDataAdapter SelDistrict = new SqlDataAdapter("Select Distinct District From AllAddress Where State='"+State.SelectedItem.Text+"'", con);
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

        protected void Teh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }





       
        protected void Year_TextChanged(object sender, EventArgs e)
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

            SelectDays();
           
        }

        private void SelectDays()
        {
            int Nmonth, Days, Year1, i = 1;
            Nmonth = Month.SelectedIndex;

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