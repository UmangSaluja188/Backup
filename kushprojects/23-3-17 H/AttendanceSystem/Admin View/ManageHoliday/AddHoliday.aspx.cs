using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AttendanceSystem.ManageHoliday
{
    public partial class AddHoliday : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (HolidayType.SelectedItem.Text == "Full Day")
            {
                
                SqlDataAdapter InsertHolidayDetails = new SqlDataAdapter("Insert Into HolidaysDetails (HolidayType,HolidayDate,Event) Values('" + HolidayType.SelectedItem.Text + "','" + DateTime.Parse(FullHolidayDate.Text) + "','" + Event.Text + "')", con);
                DataSet InsertHolidayds = new DataSet();
                InsertHolidayDetails.Fill(InsertHolidayds);

            }
            else  if (HolidayType.SelectedItem.Text == "Half Day")
            {
                SqlDataAdapter InsertHolidayDetails = new SqlDataAdapter("Insert Into HolidaysDetails (HolidayType,HolidayDate,Event,Time) Values('" + HolidayType.SelectedItem.Text + "','" + DateTime.Parse(FullHolidayDate.Text) + "','" + Event.Text + "','"+Time.Text+"')", con);
                DataSet InsertHolidayds = new DataSet();
                InsertHolidayDetails.Fill(InsertHolidayds);

            }
            else if (HolidayType.SelectedItem.Text == "Other")
            {
                Response.Write("hvhgh");
                DateTime To1 = new DateTime();
                DateTime From1 = new DateTime();
                To1 = Convert.ToDateTime(To.Text);
                From1 = Convert.ToDateTime(From.Text);
                while (From1.Date <= To1.Date)
                {
                    SqlDataAdapter InsertMultiple = new SqlDataAdapter("Insert Into HolidaysDetails (HolidayType,HolidayDate,Event,Time) Values('" + HolidayType.SelectedItem.Text + "','" + DateTime.Parse(From1.Date.ToString("yyyy/MM/dd")) + "','" + Event.Text + "','" + Time.Text + "')", con);
                    DataSet ds = new DataSet();
                    InsertMultiple.Fill(ds);
                    From1 = From1.AddDays(1);

                }
                
                                  
            }
                
        }


        protected void Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void HolidayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(HolidayType.SelectedItem.Text=="Half Day")
            {
                HalfHolidayPanel.Visible = true;
                FullDayHolidayPanel.Visible = false;
                MultiHolidaysPanel.Visible = false;
            }
            else if (HolidayType.SelectedItem.Text == "Full Day")
            {
                HalfHolidayPanel.Visible = false;
                FullDayHolidayPanel.Visible = true;
                MultiHolidaysPanel.Visible = false;
            }
            else if (HolidayType.SelectedItem.Text == "Other")
            {
                HalfHolidayPanel.Visible = false;
                FullDayHolidayPanel.Visible = false;
                MultiHolidaysPanel.Visible = true;
            }
        }
    }
}