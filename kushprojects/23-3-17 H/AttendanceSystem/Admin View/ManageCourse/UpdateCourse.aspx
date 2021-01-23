<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCourse.aspx.cs" Inherits="AttendanceSystem.ManageCourse.UpdateCourse" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container-fluid" style="margin-top:30px">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
    <h1>
        Update Course <small> Details</small>
    </h1>    
        <asp:Label ID="l1" runat="server"></asp:Label>
        <table>
            <tr>
                <td>
                    Select Department
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="Department" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Department_SelectedIndexChanged" CssClass="form-control" ></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Course Id
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="Course" runat="server" TextMode="Number" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Course Name
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="CourseName" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Course Type
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="CourseTypeN" runat="server" CssClass="form-control">
                         <asp:ListItem>Select..</asp:ListItem>
                         <asp:ListItem>Graduation</asp:ListItem>
                       <asp:ListItem>Post Graduation</asp:ListItem>
                        <asp:ListItem>Diploma</asp:ListItem>
                    </asp:DropDownList>
                       

               
                </td>
                 <td>
                     <asp:RequiredFieldValidator ID="r1" runat="server" InitialValue="Select.." ControlToValidate="CourseTypeN" ErrorMessage="*Required"></asp:RequiredFieldValidator>
                 </td>
            </tr>
             <tr>
                <td>
                    Course Duration
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="CourseDuration" runat="server" TextMode="Number" CssClass="form-control"  placeholder="Course Duration" ></asp:TextBox>
                </td>
                 <td><span>Years</span></td>
            </tr>
             <tr>
                <td>
                    Total No Of Semester
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TotalNoOfSemester" runat="server" TextMode="Number" CssClass="form-control" placeholder="Total Semester"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="UPDATE" runat="server" Text="UPDATE" OnClick="UPDATE_Click"  CssClass="btn"/>
                </td>
                <td class="auto-style1">
                    <asp:Button ID="CANCEL" runat="server" Text="Reset" OnClick="CANCEL_Click"  CssClass="btn"/>
                </td>
            </tr>
        </table>
    </div>

   </asp:Content>
