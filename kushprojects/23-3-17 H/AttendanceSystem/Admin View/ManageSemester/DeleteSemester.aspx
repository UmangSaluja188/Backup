<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteSemester.aspx.cs" Inherits="AttendanceSystem.ManageSemester.DeleteSemester" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div  style="margin-top:2%">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="50px"></asp:Label>
        <h1>Delete Semester Record</h1>
    <table>
        <tr>
            <td> Semester Id</td>
        <td>
            <asp:TextBox ID="SearchTextBox" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </td>
            </tr>
        <tr>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Delete" OnClick="Button1_Click"  CssClass="btn"/>
        </td>
            <td><asp:Button ID="Cancel" runat="server" Text="Cancel"  OnClick="Cancel_Click" CssClass="btn" /></td>
      </tr>
    </table>
    </div>

</asp:Content>
    