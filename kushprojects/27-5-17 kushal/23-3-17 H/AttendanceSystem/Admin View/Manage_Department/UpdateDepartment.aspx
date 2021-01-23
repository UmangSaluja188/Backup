<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateDepartment.aspx.cs" Inherits="AttendanceSystem.Mamage_CRI.UpdateDepartment"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
    <div id="#div1" style="margin-top:15px">
    <div class="container-fluid">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="50px"></asp:Label>
        <h1>Update Department <small>Details</small></h1>        
        <table>
            <tr>
                <td>
                    Department Id
                </td>
                <td>
                    <asp:TextBox ID="DepartmentId" runat="server" CssClass="form-control" placeholder="Department Id"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Department Name
                </td>
                <td>
                    <asp:TextBox ID="DepartmentName" runat="server" OnTextChanged="DepartmentName_TextChanged" CssClass="form-control" placeholder="Department Name"></asp:TextBox><td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="DepartmentName"></asp:RequiredFieldValidator></td>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Button ID="ADD" runat="server" Text="Update" OnClick="Update_Click"  CssClass="btn" />
                </td>
                <td>
                    <asp:Button ID="Cancel" runat="server" Text="Reset" OnClick="Cancel_Click" CssClass="btn" />
                </td>
            </tr>
        </table>
    </div>
    </div>
    </div>
               
   </asp:Content>
