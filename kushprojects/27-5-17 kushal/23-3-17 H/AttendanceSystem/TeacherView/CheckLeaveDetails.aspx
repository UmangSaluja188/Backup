<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckLeaveDetails.aspx.cs" Inherits="AttendanceSystem.TeacherView.CheckLeaveDetails" MasterPageFile="~/TeacherView/Site1.Master" %>
<asp:Content ID="c2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">  
  <div class="container-fluid">

      <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/b1.png" Height="50px" Width="50px" PostBackUrl="~/TeacherView/TeacherHomePage.aspx?Value=Today"  style="float:left;margin-top:10px" />
  <h1>
       Today Leave <small>Request</small>
    </h1>
        <table>
            <tr>
                <td>
                  Select Class
                </td>
                <td>
                    <asp:DropDownList ID="CourseName" runat="server" CssClass="form-control" OnSelectedIndexChanged="CourseName_SelectedIndexChanged">

                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:GridView ID="Gridview1" runat="server"  CssClass="table table-bordered table-condensed table-hover table-responsive" HeaderStyle-BackColor="#336699" HeaderStyle-ForeColor="White">
            <Columns>
              <asp:HyperLinkField  DataNavigateUrlFormatString="~/TeacherView/AcceptAndRejectLeave.aspx?StudentId={0}&LeaveStartingDate={1}&LeaveEndingDate={2}&Reason={3}" DataNavigateUrlFields="StudentId,Leave_Starting_Date,Leave_Ending_Date,Reason" Text="Details" />
         
                 </Columns>
        </asp:GridView>
    </div>
  </asp:Content>
