<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AcceptAndRejectLeave.aspx.cs" Inherits="AttendanceSystem.TeacherView.AcceptAndRejectLeave"  MasterPageFile="~/TeacherView/Site1.Master"%>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container-fluid">

    <h1>
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/b1.png" Height="50px" Width="50px" PostBackUrl="~/TeacherView/CheckLeaveDetails.aspx"  style="float:left" />
 Leave <small>Status</small>
    </h1>
        <div>
           <div>
               <table>
                   <tr>
                       <td>Student Id</td>

                       <td><asp:TextBox ID="Studentid" runat="server"  Width="100%" CssClass="form-control" Height="27px" ReadOnly="true"></asp:TextBox></td>
                   </tr>
                     <tr>
                       <td>Leave Starting Date</td>
                       <td><asp:TextBox ID="LeaveStartingDate" runat="server"  Width="100%" OnTextChanged="TextBox2_TextChanged" CssClass="form-control"  Height="27px" ReadOnly="true"></asp:TextBox></td>
                   </tr>
                     <tr>
                       <td class="auto-style1">Leave Ending Date</td>
                       <td><asp:TextBox ID="LeaveEndinDate" runat="server"  Width="100%" CssClass="form-control"  Height="27px" ReadOnly="true"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td class="auto-style1">Total Days</td>
                       <td><asp:TextBox ID="Days" runat="server"  Width="100%" OnTextChanged="TextBox2_TextChanged"  CssClass="form-control"  Height="27px" ReadOnly="true"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td class="auto-style1">
                           Reason
                       </td>
                       <td>
                           <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" Height="42px"  CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                       </td>
                   </tr>
               </table>
           </div>
           <asp:Button ID="Accept" runat="server" Text="Accept"  BackColor="#00B4B4" ForeColor="White" Height="46px" OnClick="Accept_Click" Width="128px" CssClass="btn"/> <asp:Button ID="Reject" runat="server" Text="Reject" Height="46px" OnClick="Reject_Click" style="margin-left: 65px" Width="128px"  BackColor="#00B4B4" ForeColor="#ffffff"  CssClass="btn"/>
        </div>
           
    </div>
    </asp:Content>
