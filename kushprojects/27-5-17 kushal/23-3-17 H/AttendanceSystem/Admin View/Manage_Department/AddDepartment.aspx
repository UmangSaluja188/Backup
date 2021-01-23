<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDepartment.aspx.cs" Inherits="AttendanceSystem.Mamage_CRI.AddDepartment"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="#div1">
    <div class="container" style="margin-top:20px;">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="50px"></asp:Label>
        <div class="jumnptorn"><h1 class="text-muted">Add<small> Department</small></h1></div>
        <table>
            <tr>
                <td>
                   <span class=" input-group-addon" id="sizing-addon1">Department Id</span> 
                </td>
                <td>
                    <asp:TextBox ID="DepartmentId" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                </td>
                 <td><asp:RequiredFieldValidator ControlToValidate="DepartmentId" ErrorMessage="*Required" ID="v1" runat="server" ForeColor="#ff3300" Display="Dynamic"></asp:RequiredFieldValidator> </td>
            </tr>
            <tr>
                <td class=" input-group-addon">
                    Department Name
                </td>
                <td>
                    <asp:TextBox ID="DepartmentName" runat="server" CssClass="form-control" placeholder="Department Name"></asp:TextBox>
                </td>
                <td><asp:RequiredFieldValidator ID="V2" ErrorMessage="*Required" ControlToValidate="DepartmentName" runat="server" ForeColor="#ff3300"  Display="Dynamic"></asp:RequiredFieldValidator><asp:CompareValidator ID="DataTypeCompare" runat="server" ControlToValidate="DepartmentName" Type="String" Operator="DataTypeCheck" ErrorMessage="Please Enter String Value" ForeColor="#ff3300"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ADD" runat="server" Text="ADD" OnClick="ADD_Click" Width="56px" CssClass="btn" />
                </td>
                <td>
                    <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" CssClass="btn" CausesValidation="false" />
                </td>
            </tr>
        </table>

    </div>
    </div>
   </asp:Content>
