<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSemester.aspx.cs" Inherits="AttendanceSystem.ManageSemester.AddSemester" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>

<asp:Content ID="C1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div>
        <asp:Label ID="Error" runat="server"  Font-Size="20px"></asp:Label>
    <h1>
        Add Semester Details
    </h1>
        <table>
             <tr>
                <td>
                    Semester Id
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="SemesterId" runat="server" TextMode="Number" Enabled="False"  CssClass="form-control"></asp:TextBox>
                </td>
                  
            </tr>
            <tr>
                <td>
                    Select Course
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="CourseName" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="CourseName_SelectedIndexChanged"  CssClass="form-control"></asp:DropDownList>
                </td>

                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CourseName"
                ErrorMessage="Value Required!" InitialValue="Select Course"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
           
            <tr>
                <td class="auto-style2">
                    Semester No
                </td>
                <td class="auto-style3">
                    <asp:DropDownList ID="SemesterNo" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </td>
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="SemesterNo"
                ErrorMessage="Value Required!" InitialValue="Select Semester"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
               
                
            </tr>
    
            <tr>
                <td class="auto-style2">
                    Semester Duration</td>
                <td class="auto-style3">
                    <asp:TextBox ID="SemesterDuration" runat="server" TextMode="Number" ReadOnly="true" CssClass="form-control" placeholder="Semester Duration"></asp:TextBox> Months
                </td>
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="SemesterDuration"
                ErrorMessage="Value Required!"   Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
    
             <tr>
                <td>
                    Semester Starting Date
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="SemesterStartingDate" runat="server" TextMode="Date" CssClass="form-control" placeholder="Semester Starting Date" ></asp:TextBox>
                </td>
                   <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="SemesterStartingDate"
                ErrorMessage="Value Required!"   Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>
                    Semester Ending Date
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="SemesterEndingDate" runat="server" TextMode="Date" OnTextChanged="SemesterEndingDate_TextChanged" AutoPostBack="true" CssClass="form-control" placeholder="Semester Ending Date"></asp:TextBox>
                </td>
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="SemesterEndingDate"
                ErrorMessage="Value Required!" Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>
                    Total No Of Subject
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TotalNoOfSubject" runat="server" TextMode="Number" CssClass="form-control" placeholder="Total No Of Subjects"></asp:TextBox>
                </td>
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TotalNoOfSubject"
                ErrorMessage="Value Required!"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ADD" runat="server" Text="ADD" OnClick="ADD_Click"  CssClass="btn"/>
                </td>
                <td>
                    <asp:Button ID="CANCEL" runat="server" Text="CANCEl" OnClick="CANCEL_Click"  CausesValidation="false" CssClass="btn"/>
                </td>
            </tr>
        </table>
    </div>
         </asp:Content>   