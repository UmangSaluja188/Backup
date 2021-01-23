<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditFineDetails.aspx.cs" Inherits="AttendanceSystem.Admin_View.ManageFineDetails.EditFineDetails1"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>

<asp:Content ID="c2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1" >
    <div  class="container-fluid" style="margin-top:7%">
       <h1>Update Fine Details</h1>
        <table>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <tr>
                <td>
                    Select Department
                </td>
                <td>
                    <asp:DropDownList ID="Department" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Department_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Select Course
                </td>
                <td>
                    <asp:DropDownList ID="Course" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="Course_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Select Semester
                </td>
                <td>
                    <asp:DropDownList ID="Semester" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Semester_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>
                    Fine Per Day
                </td>
                <td>
                    <asp:TextBox ID="FinePerDay" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </td>
                 </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Update"  OnClick="Button1_Click"  CssClass="btn"/></td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Cancel"  OnClick="Button2_Click" CssClass="btn"/></td>
            </tr>
        </table>
    </div>
  </asp:Content>
