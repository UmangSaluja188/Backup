<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteStudentRecord.aspx.cs" Inherits="AttendanceSystem.AdminPage.DeleteStudentRecord" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>

<asp:Content ID="C3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div id="div1">
                <asp:Button ID="Link" runat="server"  PostBackUrl="~/link.aspx" Text="Back To Link Page" />

        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
    <div id="div2" class="mainDiv">
       <center> <br /><h2>Delete Student Record</h2></center>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
        <br />
       
       
       <table>
        <tr>
            <td class="auto-style1">
               Please Enter Student Roll No
            </td>
            <td class="auto-style2">
                 <asp:TextBox ID="TextBox1" runat="server" Height="28px" Width="187px"></asp:TextBox>
            </td>
        </tr>
   


    </table>
        <asp:Button ID="Delete" runat="server" Text="Delete" Height="40px" style="margin-left: 164px" Width="77px" OnClick="Delete_Click" />
        <asp:Button ID="DeleteAllData" runat="server" Text="DeleteAllStudent" OnClick="DeleteAllData_Click" />
         </div>
    </div>
   </asp:Content>
