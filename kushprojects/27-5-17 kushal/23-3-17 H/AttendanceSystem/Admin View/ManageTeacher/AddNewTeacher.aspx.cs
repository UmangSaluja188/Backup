using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem.ManageTeacher
{
    public partial class AddNewTeacher : System.Web.UI.Page
    {

        public static string path,BirthDate="";
        int DepartmentIdValue = 0;
        public static int TeacherIdValue;
       public  static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                if (Session["AdminId"] == null)
                {

                    //Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
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
            }

            TeacherId.Enabled = false;
           
            //Select Teacher Id
            try
            {
                SqlDataAdapter SelectTeacherId = new SqlDataAdapter("Select Top 1(TeacherId) From TeacherDetails Order By TeacherId DESC ", con);
                DataSet STIdds = new DataSet();
                SelectTeacherId.Fill(STIdds);
                if (STIdds.Tables[0].Rows.Count > 0)
                {
                    Response.Write("Hello");
                    TeacherIdValue = Convert.ToInt32(STIdds.Tables[0].Rows[0][0]) + 1;
                    TeacherId.Text = TeacherIdValue.ToString();
                }
                else
                {
                    Response.Write("Hello2");
                    TeacherIdValue = 701;
                    TeacherId.Text = TeacherIdValue.ToString();
                }
                con.Close();
            }
            catch (Exception err)
            {
                Error.Text = "Select Teacher Id Portion " + err.Message;
            }

            //Select Department DepartmentDetails
            try
            {
                if (!IsPostBack)
                {

                    SqlCommand com = new SqlCommand("Select * from NewDepartmentDetails", con);
                    con.Open();
                    SqlDataReader red = com.ExecuteReader();

                    DepartmentName.DataSource = red;
                    DepartmentName.DataTextField = "NDepartmentName";
                    DepartmentName.DataValueField = "NDepartmentName";

                    DepartmentName.DataBind();
                    DepartmentName.Items.Insert(0, "Select...");
                }

                con.Close();
            }
            catch (Exception err)
            {
                Error.Text = "Select Department Details Portion " + err.Message;
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


        protected void Add_Click(object sender, EventArgs e)
        {
            string stateValues, districtValues;
            //Select Department id
           
                Response.Write(TeacherIdValue);
                string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand com = new SqlCommand("Select NDepartmentId From NewDepartmentDetails where NDepartmentName like @DepartmentNameValue", con);
                com.Parameters.AddWithValue("@DepartmentNameValue", DepartmentName.SelectedItem.Text);
                con.Open();
                SqlDataReader red = com.ExecuteReader();
                if (red.Read())
                {
                    DepartmentIdValue = red.GetInt32(0);
                    Response.Write(DepartmentIdValue + "Department name=" + DepartmentName.SelectedItem.Text);
                }
                con.Close();
            

            //Insert Teacher Details

               
                BirthDate += Month.SelectedItem.Text + "/" + Day.SelectedItem.Text + "/" + Year.SelectedItem.Text;
            
                SqlCommand com2 = new SqlCommand("Insert Into TeacherDetails (TeacherId,TeacherName,ContactNo,Email,Experience,Specialization,Image,NDepartmentId,Gender,Qualification,DateOfBirth)Values ('" + TeacherIdValue + "',@TName,@TContactNo,@TEmail,@TExperience,@TSpecialization,@TImage,@NDepartmentId,@Gender,@Qualification,@DateOfBirth)", con);
                com2.Parameters.AddWithValue("@TTeacherId", TeacherIdValue);
                com2.Parameters.AddWithValue("@TName", TeacherName.Text);
                com2.Parameters.AddWithValue("@TContactNo", ContactNo.Text);
                com2.Parameters.AddWithValue("@TEmail", Email.Text);
                com2.Parameters.AddWithValue("@TExperience", Experience.Text);
                com2.Parameters.AddWithValue("@TSpecialization", Specialization.Text);
                com2.Parameters.AddWithValue("@TImage", Image.ImageUrl.ToString());
                com2.Parameters.AddWithValue("@NDepartmentId", DepartmentIdValue);
                com2.Parameters.AddWithValue("@DateOfBirth", Convert.ToDateTime(Convert.ToDateTime(BirthDate).ToString("yyyy/MM/dd"))); ;
                com2.Parameters.AddWithValue("@Gender", Gender.SelectedItem.Text);
                com2.Parameters.AddWithValue("@Qualification", Qualification.Text);
                con.Open();
                com2.ExecuteNonQuery();
                con.Close();
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
                SqlDataAdapter InsertAddress = new SqlDataAdapter("Insert Into TeacherAddress(TeacherId,CityVillage,Teh,District,State,PinCode) Values('" + TeacherIdValue + "','" + CityVill.Text + "','" + Teh1.Text + "','" + districtValues + "','" + stateValues + "','" + PinCode.Text + "')", con);
                DataSet ds10 = new DataSet();
                InsertAddress.Fill(ds10);
   

                SqlDataAdapter CreateAccounct = new SqlDataAdapter("Insert Into LoginTable (LogInType,UserId,Password) Values('Teacher','" + TeacherIdValue + "','Password') ", con);
                DataSet ds = new DataSet();
                CreateAccounct.Fill(ds);

               
               

                reset();
            }
            

            
           
           
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Fileupload1.HasFiles)
            {
                string str = Server.MapPath("~/Images/" + Fileupload1.FileName);
               string filename=Fileupload1.FileName;
                if(filename.EndsWith(".png", StringComparison.OrdinalIgnoreCase)||
                    filename.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)||
                    filename.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    Fileupload1.SaveAs(str);
                    path = "~/Images/" + Fileupload1.FileName;

                    Image.ImageUrl = path;
               
                }
            }
        }

        protected void DepartmentName_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            reset();
            Response.Redirect("../Admin View/ManageTeacher/SearchTeacherRecord.aspx");
        }

        private void reset()
        {
            TeacherId.Text = "";
            TeacherName.Text = "";
            ContactNo.Text = "";       
            Email.Text = "";
            Experience.Text = "";
        
            Specialization.Text = "";
            Image.ImageUrl = "";
            DepartmentName.SelectedIndex = -1;
            PinCode.Text = "";
            CityVill.Text = "";
            State.SelectedIndex = 0;
            District.SelectedIndex = 0;
            Teh1.Text = "";
            Month.SelectedIndex = 0;
            Day.SelectedIndex = 0;
            Year.SelectedIndex = 0;
            Qualification.Text = "";
            Gender.SelectedIndex = 0;
        }

       
     
        
        protected void State_SelectedIndexChanged2(object sender, EventArgs e)
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
            if (District.SelectedItem.Text == "Others...")
            {
                Panel1.Visible =true;

            }
            else
            {
                Panel1.Visible = false ;
            }
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