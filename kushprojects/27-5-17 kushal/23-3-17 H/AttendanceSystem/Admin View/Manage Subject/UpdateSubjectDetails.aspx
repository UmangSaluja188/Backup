<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateSubjectDetails.aspx.cs" Inherits="AttendanceSystem.Manage_Subject.UpdateDetails" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>
<asp:Content ID="C1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container-fluid" style="margin-top:30px">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
        <h1>Update Subject <small>Details</small> </h1>
       
        <table>
     <tr>
                <td class="auto-style1">
                    Subject Id</td>
                <td class="auto-style1">
                    <asp:TextBox ID="SubjectId" runat="server" TextMode="Number" Enabled="False" CssClass="form-control" placeholder="Subject Id"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Select Course
                </td>
                <td>
                    <asp:DropDownList ID="CourseName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CourseName_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Select Semester
                </td>
                <td>
                    <asp:DropDownList ID="SemesterNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SemesterNo_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Subject Name
                </td>
                <td>
                    <asp:TextBox ID="SubjectName" runat="server" CssClass="form-control" placeholder="Subject Name"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Subject Type
                </td>
                <td>
                    <asp:RadioButtonList ID="SubjectType" runat="server" RepeatDirection="Horizontal" CssClass="text-danger">
                        <asp:ListItem >Theortical</asp:ListItem>
                         <asp:ListItem>Practical</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Subject
                </td>
                <td class="auto-style2">
                    <asp:RadioButtonList ID="SubjectOC" runat="server" RepeatDirection="Horizontal" CssClass="text-danger">
                         <asp:ListItem>Optional</asp:ListItem>
                         <asp:ListItem >Compulsary</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" CssClass="btn" /></td>
                <td>
                    <asp:Button ID="Cancel" runat="server" Text="Reset" OnClick="CANCEL_Click" CssClass="btn" /></td>
            </tr>
        </table>
    </div>

  </asp:Content>