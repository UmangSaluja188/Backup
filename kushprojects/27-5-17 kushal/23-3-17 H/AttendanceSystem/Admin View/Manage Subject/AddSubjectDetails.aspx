<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSubjectDetails.aspx.cs" Inherits="AttendanceSystem.Manage_Subject.AddSubjectDetails" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>
    <asp:Content ID="C1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <div class="row"></div>
      
        <div class="col-sm-8"></div>
<div class="container-fluid" style="margin-top:20px">
    <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
    <h1>Add New <small> Subject</small></h1>
        <table class="form-group">
            <tr>
                <td class="auto-style1">
                    Subject Id</td>
                <td class="auto-style1">
                    <asp:TextBox ID="SubjectId" runat="server" TextMode="Number" Enabled="False" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Select Course
                </td>
                <td>
                    <asp:DropDownList ID="CourseName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CourseName_SelectedIndexChanged" ValidationGroup="A1"  CssClass="form-control" placeholder="Select Course">
                        <asp:ListItem Value="0">Hello</asp:ListItem>
                    </asp:DropDownList>
                 
                     </td>

                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="CourseName"
                ErrorMessage="Value Required!" InitialValue="Select Course..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>

            </tr>
            <tr>
                <td>
                    Select Semester
                </td>
                <td>
                    <asp:DropDownList ID="SemesterNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SemesterNo_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="SemesterNo"
                ErrorMessage="Value Required!" InitialValue="Select Semester..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>
                    Subject Name
                </td>
                <td>
                    <asp:TextBox ID="SubjectName" runat="server" CssClass="form-control" placeholder="Subject Name"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="SubjectName"
                ErrorMessage="Value Required!"   Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>
                    Subject Type
                </td>
                <td>
                    <asp:RadioButtonList ID="SubjectType" runat="server" RepeatDirection="Horizontal" CssClass="text-danger">
                        <asp:ListItem Selected="True">Theortical</asp:ListItem>
                         <asp:ListItem>Practical</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="SubjectType"
                ErrorMessage="Value Required!" InitialValue="Select Department..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>
                    Subject
                </td>
                <td>
                    <asp:RadioButtonList ID="SubjectOC" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="SubjectOC_SelectedIndexChanged" CssClass="text-danger">
                         <asp:ListItem>Optional</asp:ListItem>
                         <asp:ListItem Selected="True">Compulsary</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ADD" runat="server" Text="ADD" OnClick="ADD_Click" CssClass="btn" /></td>
                <td>
                    <asp:Button ID="CANCEL" runat="server" Text="CANCEL" OnClick="CANCEL_Click"  CssClass="btn"  CausesValidation="false" /></td>
            </tr>
        </table>
    </div>
  </asp:Content>