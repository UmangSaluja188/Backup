<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCourse.aspx.cs" Inherits="AttendanceSystem.ManageCourse.AddCourse" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>


 <asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container-fluid" style="margin-top:20px">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
    <div id="#div2">
        <h1>
            Add New <small>Course</small>
        </h1>
        <table>
            <tr>
                <td>
                    Select Department
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="Department" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Department_SelectedIndexChanged"  CssClass="form-control"></asp:DropDownList>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Department"
                ErrorMessage="Value Required!" InitialValue="Select Department..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                
            </tr>
            <tr>
                <td class="auto-style2">
                    Course Id
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="Course" runat="server" TextMode="Number" Enabled="False" CssClass="form-control" ></asp:TextBox >
                    
                </td>            
            </tr>
             <tr>
                <td>
                    Course Name
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="CourseName" runat="server" CssClass="form-control" placeholder="Course Name"></asp:TextBox>
                </td>
                 <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="CourseName"
                ErrorMessage="Value Required!"  Display="Dynamic" ></asp:RequiredFieldValidator>
                 </td>
                
            </tr>
             <tr>
                <td>
                    Course Type
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="CourseTypeN" runat="server" CssClass="form-control">
                        <asp:ListItem>Select...</asp:ListItem>
                         <asp:ListItem>Graduation</asp:ListItem>
                       <asp:ListItem>Post Graduation</asp:ListItem>
                        <asp:ListItem>Diploma</asp:ListItem>
                    </asp:DropDownList>
                       

               
                </td>
                   <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CourseTypeN"
                ErrorMessage="Value Required!" InitialValue="Select..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
             <tr>
                <td>
                    Course Duration
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="CourseDuration" runat="server" TextMode="Number" CssClass="form-control" placeholder="Course Duration"  Display="Dynamic"></asp:TextBox> </td><td><span class="text-danger" > &nbsp;Years</span></td>
                    <td><asp:RangeValidator  ID="rt" runat="server" ControlToValidate="CourseDuration" MaximumValue="5" MinimumValue="1" ErrorMessage="Please Enter Value Between Range 1 to 5"  Display="Dynamic"></asp:RangeValidator></td>
                 <td>
                     
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CourseDuration"  Display="Dynamic" ErrorMessage="!Value Required"
              ></asp:RequiredFieldValidator>
                 </td>
               
            </tr>
             <tr>
                <td>
                    Total No Of Semester
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TotalNoOfSemester" runat="server" TextMode="Number" CssClass="form-control" placeholder="Total Semester"></asp:TextBox>
                </td>
                       
                    <td>  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TotalNoOfSemester" Display="Dynamic" ErrorMessage="!Value Required">
              </asp:RequiredFieldValidator>
                 </td>
                 <td><asp:RangeValidator  ID="RangeValidator1" runat="server" ControlToValidate="TotalNoOfSemester" MaximumValue="8" MinimumValue="1" ErrorMessage="Please Enter Value Between Range 1 to 8"  Display="Dynamic"></asp:RangeValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ADD" runat="server" Text="Add" OnClick="ADD_Click" CssClass="btn" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="CANCEL" runat="server" Text="Cancel" OnClick="CANCEL_Click"  CssClass="btn" CausesValidation="false"/>
                </td>
            </tr>
        </table>
    </div>
    </div>
</asp:Content>
