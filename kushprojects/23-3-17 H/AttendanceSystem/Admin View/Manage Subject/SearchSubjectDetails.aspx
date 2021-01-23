<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchSubjectDetails.aspx.cs" Inherits="AttendanceSystem.Manage_Subject.SearchSubjectDetails"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container-fluid" style="margin-top:20px">
        <asp:Label ID="Error1" runat="server" ForeColor="#ff3300" Font-Size="50px"></asp:Label>
    <h1>Subject Details <small>Panel</small></h1>
        <h3>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin View/Manage Subject/AddSubjectDetails.aspx" ForeColor="#FF3300">Add New Subjects</asp:HyperLink></h3>
        <table>
            <tr><asp:Panel ID="SelectCNP" runat="server" >
                <td>
                   Select Course Name
                </td>
                <td>
                    <asp:DropDownList ID="SelectCourse" runat="server" OnSelectedIndexChanged="SelectCourse_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                </td>
                </asp:Panel>
                <asp:Panel ID="SelectSNP" runat="server" Visible="False">
                <td>
                   Select Semester No
                </td>
                <td>
                    <asp:DropDownList ID="SelectSemesterNo" runat="server" OnSelectedIndexChanged="SelectSemesterNo_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                </td>
                </asp:Panel>
                 <asp:Panel ID="SelectSubNP" runat="server" Visible="False">
                <td>
                   Select Subject Name
                </td>
                <td>
                    <asp:DropDownList ID="SelectSubjectName" runat="server" OnSelectedIndexChanged="SelectSubjectName_SelectedIndexChanged1" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                </td>
                </asp:Panel>
            </tr>
        </table>
        <div class="pre-scrollable">
        <asp:GridView ID="ShowSubjectDetails" runat="server" CssClass="table table-hover table-responsive table-condensed bg-warning text-warning" HeaderStyle-BackColor="#B69782" HeaderStyle-ForeColor="#ffffff">
            <Columns>
                <asp:HyperLinkField  DataNavigateUrlFormatString="~/Admin View/Manage Subject/UpdateSubjectDetails.aspx?SubjectId={0}" Text="Edit" DataNavigateUrlFields="SubjectId" />
                <asp:HyperLinkField DataNavigateUrlFormatString="~/Admin View/Manage Subject/DeleteSubjectDetails.aspx?SubjectId={0}" Text="Delete" DataNavigateUrlFields="SubjectId" />
            </Columns>
        </asp:GridView>
    </div>
        </div>
              
    
  </asp:Content>