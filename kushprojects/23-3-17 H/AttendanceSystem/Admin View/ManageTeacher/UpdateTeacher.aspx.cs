using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AttendanceSystem.ManageTeacher
{
    public partial class UpdateTeacher : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        public static  int SelectedDepId;
        public static string SelectedDepname,TeacherIdValue,path,BirthDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Query String
            if (!IsPostBack)
            {
                if (Session["AdminId"] == null)
                {

                    //Response.Redirect("~/LogInFolder/AdminLogInPage.aspx");
                }
            }

          
                if (!IsPostBack)
                {
                    TeacherIdValue = Request.QueryString["TeacherId"];
                    Error.Text = TeacherIdValue.ToString();
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
                    UpdateTeacherDetails();
                    if (Request.QueryString["mode"].ToString().ToLower() == "details")
                    {
                        Label1.Text = "Teacher Details";
                        TeacherId.ReadOnly = true;
                        DepartmentName.Enabled = false;
                        TeacherName.ReadOnly = true;
                        ContactNo.ReadOnly = true;
                        Email.ReadOnly = true;
                        Experience.ReadOnly = true;
                        Specialization.ReadOnly = true;
                      
                        Qualification.ReadOnly = true;
                        Gender.Enabled = false;
                        Day.Enabled = false;
                        Month.Enabled = false;
                        Year.Enabled = false;
                        Update.Visible = false;
                        Button3.Visible = false;
                        Fileupload1.Visible = false;
                        Upload.Visible = false;
                        State.Enabled = false;
                        District.Enabled = false;
                        Teh1.ReadOnly = true;
                        CityVill.ReadOnly = true;
                        PinCode.ReadOnly = true;
                    }
                    else if (Request.QueryString["TeacherId"].ToString().ToLower() == "details")
                    {
                        Label1.Text = "Update Teacher Details";
                    }
                }
            
           
        }
        private void UpdateTeacherDetails()
        {
            //Search ALL Teacher Details
            try 
	        {	  
      
                enabledControl(true);
                int Day1, Month1, Year1;
                SqlCommand com = new SqlCommand("Select * from TeacherDetails Where TeacherDetails.TeacherId like'" + TeacherIdValue + "'", con);
                con.Open();
                SqlDataReader red = com.ExecuteReader();
                if (red.Read())
                {
                    TeacherId.Text = red[0].ToString(); ;
                    TeacherName.Text = red[1].ToString();

                    ContactNo.Text = red[2].ToString();
                    Email.Text = red[3].ToString();
                    Experience.Text = red[4].ToString();
                    Specialization.Text = red[5].ToString();
                    NImage.ImageUrl = red[6].ToString();
                    
                    SelectedDepId = Convert.ToInt32(red[7]);
                    Qualification.Text = red[8].ToString();
                  
                    path = red[6].ToString();
                    DateTime BD = new DateTime();
                    BD = Convert.ToDateTime(red[10].ToString());
                    Year1 = BD.Year;
                    Month1 = BD.Month;
                    Day1 = BD.Day;
                    foreach (ListItem items in Year.Items)
                    {
                        Error.Text = items.Text;
                        if (Year1.ToString() == items.Text)
                        {

                            items.Selected = true;
                            break;
                        }
                    }
                    Error.Text = Month1.ToString() + " hh" + Day1.ToString() + "kkk" + Year1.ToString();
                    foreach (ListItem items in Month.Items)
                    {
                        Error.Text = "Month " + Month1.ToString() + " Month " + items.Text;
                        if (Month1 == Convert.ToInt32(items.Text.ToString()))
                        {
                            items.Selected = true;
                            break;
                        }
                    }
                    SelectDays();
                    foreach (ListItem items in Day.Items)
                    {
                        if (Day1 == Convert.ToInt32(items.Text))
                        {
                            items.Selected = true;
                            break;
                        }
                    }
                    foreach (ListItem items in Gender.Items)
                    {
                        int i = 0;
                        if (items.Text == red.GetString(9).ToString())
                        {
                            items.Selected = true;
                            break;
                        }
                        i++;
                    }

                    con.Close();
                    SqlDataAdapter SelectAddressDetails = new SqlDataAdapter("Select * From TeacherAddress Where TeacherId='"+TeacherIdValue+"'",con);
                    DataSet ds3 = new DataSet();
                    SelectAddressDetails.Fill(ds3);
                    if (ds3.Tables[0].Rows.Count > 0)
                    {
                        foreach (ListItem items in State.Items)
                        {
                            int i = 0;
                            if (items.Text == ds3.Tables[0].Rows[0][2].ToString())
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
                            if (items.Text == ds3.Tables[0].Rows[0][3].ToString())
                            {
                                items.Selected = true;
                                break;
                            }
                            i++;
                        }
                        Teh1.Text = ds3.Tables[0].Rows[0][4].ToString();
                        CityVill.Text = ds3.Tables[0].Rows[0][5].ToString();
                        PinCode.Text = ds3.Tables[0].Rows[0][6].ToString();

                    }
                 


                    SqlCommand DisplayDepartment = new SqlCommand("Select Distinct NDepartmentName from NewDepartmentDetails ", con);
                    con.Open();
                    SqlDataReader red1 = DisplayDepartment.ExecuteReader();
                    DepartmentName.DataSource = red1;
                    DepartmentName.DataTextField = "NDepartmentName";
                    DepartmentName.DataValueField = "NDepartmentName";
                    DepartmentName.DataBind();
                    con.Close();

                    SqlCommand SelectedDepartmentName = new SqlCommand("Select NDepartmentName from NewDepartmentDetails where NDepartmentId like '" + SelectedDepId + "'", con);
                    con.Open();
                    SqlDataReader red2 = SelectedDepartmentName.ExecuteReader();
                    if (red2.Read())
                    {
                        SelectedDepname = red2[0].ToString();
                    }
                    foreach (ListItem items in DepartmentName.Items)
                    {
                        if (items.Text == SelectedDepname)
                        {
                            items.Selected = true;
                        }
                    }
                }
                else
                {
                    Response.Write("Invalid Id");
                }
            
                }
            catch (Exception err)
            {
                Error.Text = "Search  All Teacher Details " + err.Message;
            }
        }


           
      

        protected void Update_Click(object sender, EventArgs e)
        {
            //Update Teacher Details
            try
            {
                BirthDate += Month.SelectedItem.Text + "/" + Day.SelectedItem.Text + "/" + Year.SelectedItem.Text;
                Response.Write("click " + TeacherIdValue);
                Response.Write(TeacherName.Text);
                string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand com = new SqlCommand("Update TeacherDetails set TeacherName=@TTeacherName,ContactNo=@TContactNo,Email=@TEmail,Experience=@TExperience,Specialization=@TSpecialization,DateOfBirth=@DateOfBirth,Gender=@Gender,Qualification=@Qualification,Image=@Image Where TeacherId ='" + TeacherIdValue + "'", con);
                com.Parameters.AddWithValue("@TTeacherName", TeacherName.Text);
                com.Parameters.AddWithValue("@TContactNo", ContactNo.Text);
                com.Parameters.AddWithValue("@TEmail", Email.Text);
                com.Parameters.AddWithValue("@TExperience", Experience.Text);
                com.Parameters.AddWithValue("@TSpecialization", Specialization.Text);
                com.Parameters.AddWithValue("@Gender", Gender.SelectedItem.Text);

                com.Parameters.AddWithValue("@Qualification", Qualification.Text);
                com.Parameters.AddWithValue("@DateOfBirth", Convert.ToDateTime(Convert.ToDateTime(BirthDate).ToString("yyyy/MM/dd")));
                com.Parameters.AddWithValue("@Image", path);
                con.Open();
                com.ExecuteNonQuery();

                SqlDataAdapter UpdateAddress = new SqlDataAdapter("Update TeacherAddress Set State='"+State.SelectedItem.Text+"',District='"+District.SelectedItem.Text+"',Teh='"+Teh1.Text+"',CityVillage='"+CityVill.Text+"',PinCode='"+PinCode.Text+"' Where TeacherId='"+TeacherIdValue+"'",con);
                DataSet ds4 = new DataSet();
                UpdateAddress.Fill(ds4);

                reset();
                Response.Redirect("~/Admin View/ManageTeacher/SearchTeacherRecord.aspx");
            }
            catch (Exception err)
            {
                Error.Text = "Update Teacher Details Portion " + err.Message;
            }
           
        }

        private void enabledControl(bool value)
        {
            TeacherId.Enabled = value;
            TeacherName.Enabled = value;
            ContactNo.Enabled = value;
            Email.Enabled = value;
            Experience.Enabled = value;
            Specialization.Enabled = value;
         
            Upload.Enabled = value;
            DepartmentName.Enabled = value;
            Fileupload1.Enabled = value;
            
        }

        private void reset()
        {
            TeacherId.Text ="";
            TeacherName.Text = "";
            ContactNo.Text = "";
            ContactNo.Text = "";
            Email.Text = "";
            Experience.Text = "";
            Specialization.Text ="";
           
            NImage.ImageUrl = "";
            Qualification.Text = "";
            Gender.SelectedIndex = -1;
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            UpdateTeacherDetails();
           

        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (Fileupload1.HasFiles)
            {
                string str = Server.MapPath("~/Images/" + Fileupload1.FileName);
                string filename = Fileupload1.FileName;
                if (filename.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                    filename.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    filename.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    Fileupload1.SaveAs(str);
                    path = "~/Images/" + Fileupload1.FileName;

                    NImage.ImageUrl = path;

                }
            }
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
            SelectDistrict();
        }
        protected void State_SelectedIndexChanged(object sender, EventArgs e)
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
            Nmonth = Month.SelectedIndex + 1;
            Error.Text = Nmonth.ToString();
            Year1 = Convert.ToInt32(Year.SelectedItem.Text.Trim());
            Days = DateTime.DaysInMonth(Year1, Nmonth);
            while (i <= Days)
            {
                Day.Items.Add("" + i);
                i++;

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
    }
}