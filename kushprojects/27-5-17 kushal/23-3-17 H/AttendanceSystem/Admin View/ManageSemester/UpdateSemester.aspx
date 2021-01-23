<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateSemester.aspx.cs" Inherits="AttendanceSystem.ManageSemester.UpdateSemester" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div><h1>Update Semester Details</h1>
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
        <div>
           
     <table>
             <tr>
                <td>
                    Semester Id
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="SemesterId" runat="server" TextMode="Number" Enabled="False" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Select Course
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="CourseName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CourseName_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
           
            <tr>
                <td class="auto-style2">
                    Semester No
                </td>
                <td class="auto-style3">
                    <asp:DropDownList ID="SemesterNo" runat="server" OnSelectedIndexChanged="SemesterNo_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control">
                    </asp:DropDownList>
                </td>
            </tr>
    
            <tr>
                <td class="auto-style2">
                    Semester Duration</td>
                <td class="auto-style3">
                    <asp:TextBox ID="SemesterDuration" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox></td><td> Months
                </td>
            </tr>
    
             <tr>
                <td>
                    Semester Starting Date
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="SemesterStartingDate" runat="server" CssClass="form-control" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Semester Ending Date
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="SemesterEndingDate" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Total No Of Subject
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TotalNoOfSubject" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ADD" runat="server" Text="UPDATE" OnClick="UPDATE_Click"  CssClass="btn"/>
                </td>
                <td>
                    <asp:Button ID="Reset" runat="server" Text="Reset" OnClick="CANCEL_Click" CssClass="btn" />
                </td>
            </tr>
        </table>
    </div>

</div></asp:Content>
