<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchFineDetails.aspx.cs" Inherits="AttendanceSystem.Admin_View.ManageFineDetails.EditFineDetails"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
          <h1>Fine Details</h1>
         <h3><asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#FF3300" NavigateUrl="~/Admin View/ManageFineDetails/AddFineDetails.aspx">Add New Fine Details</asp:HyperLink></h3>

    <div>
        <table>
            <tr>
                <td>
                    Select Department
                </td>
                <td>
                    <asp:DropDownList ID="Department" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Department_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
                <td>
                    Select Course
                </td>
                <td>
                    <asp:DropDownList ID="Course" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Course_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
                <td>
                    Select Semester
                </td>
                <td>
                    <asp:DropDownList ID="Semester" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Semester_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
        <asp:GridView ID="Fine" runat="server" CssClass="table  table-bordered table-hover table-responsive table-condensed bg-warning text-warning" HeaderStyle-BackColor="#B69782" HeaderStyle-ForeColor="#ffffff">
            <Columns>
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFormatString="~/Admin View/ManageFineDetails/EditFineDetails.aspx?FineId={0}" DataNavigateUrlFields="FineId" ItemStyle-CssClass="btn" />
            </Columns>
        </asp:GridView>
  
   </asp:Content>
