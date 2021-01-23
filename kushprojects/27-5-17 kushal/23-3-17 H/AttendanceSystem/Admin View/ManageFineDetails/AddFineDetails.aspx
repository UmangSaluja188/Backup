<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFineDetails.aspx.cs" Inherits="AttendanceSystem.Admin_View.ManageFineDetails.AddFineDetails"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>

<asp:Content  ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="container-fluid" style="margin-top:7%">
            <h1>Add Fine Details</h1>
        <table>
            <tr>
                <td>
                    Select Department
                </td>
                <td>
                    <asp:DropDownList ID="Department" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Department_SelectedIndexChanged" placeholder="Select Department..." CssClass="form-control"></asp:DropDownList>
                </td>
                <td><asp:RequiredFieldValidator ID="r1" runat="server" ErrorMessage="*Required" InitialValue="Select Department..." ControlToValidate="Department" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    Select Course
                </td>
                <td>
                    <asp:DropDownList ID="Course" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="Course_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
                  <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" InitialValue="Select Course..." ControlToValidate="Course" Display="Dynamic"></asp:RequiredFieldValidator></td>

            </tr>
            <tr>
                <td>
                    Select Semester
                </td>
                <td>
                    <asp:DropDownList ID="Semester" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Semester_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
                   <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" InitialValue="Select Semester..." ControlToValidate="Semester" Display="Dynamic"></asp:RequiredFieldValidator></td>

            </tr>
             <tr>
                <td>
                    Fine Per Day
                </td>
                <td>
                    <asp:TextBox ID="FinePerDay" runat="server" TextMode="Number"  placeholder="FinePerDay" CssClass="form-control"></asp:TextBox>
                    </td>
                 <td>
                     <asp:RequiredFieldValidator ID="r4" runat="server" ErrorMessage="*Required" ControlToValidate="FinePerDay"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="r7" runat="server" ErrorMessage="Please Enter Value Between Range 0 to 500" ControlToValidate="FinePerDay" MaximumValue="500" MinimumValue="0" Display="Dynamic" Type="Integer"></asp:RangeValidator>
                 </td>
                 </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Save"  OnClick="Button1_Click" CssClass="btn"/></td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click"  CssClass="btn"/></td>
            </tr>
        </table>
    </div>
    
</asp:Content>