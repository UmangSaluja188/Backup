 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckAttendance.aspx.cs" Inherits="AttendanceSystem.Admin_View.CheckAttendance" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>
<asp:Content ID="C1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div style="margin-top:7%">
        <h1 class="text-primary">View Student Attendance <small>Details</small></h1>
        <table>
            <tr>
                <td>
                    Select Department
                </td>
                <td>
                    <asp:DropDownList ID="Department" runat="server" OnSelectedIndexChanged="Department_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">

                    </asp:DropDownList>
                </td>
                <td>
                    Select Course
                </td>
                <td>
                    <asp:DropDownList ID="CourseName" runat="server" OnSelectedIndexChanged="Course_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">

                    </asp:DropDownList>
                </td>
                <td>
                    Select Semester
                </td>
                <td>
                    <asp:DropDownList ID="SemesterNo" runat="server" OnSelectedIndexChanged="SemesterNo_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">

                    </asp:DropDownList>
                </td>
                 <td>
                    Select Subject
                </td>
                <td>
                    <asp:DropDownList  ID="Subject" runat="server" OnSelectedIndexChanged="Subject_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" >

                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:Panel ID="p1" runat="server" Visible="false">
       <table>
           <tr>
               <td>
                   Filter By
               </td>
               <td>
                   <asp:DropDownList ID="FilterBy" runat="server"  AutoPostBack="true"></asp:DropDownList>
               </td>
                 <asp:Panel ID="StudentIdPanel" runat="server"  >
                    <td>
                    Student Id
                </td>
                <td>
                   <asp:TextBox ID="StudentId" runat="server" CssClass="form-control"></asp:TextBox><asp:Button ID="SearchBSId1" runat="server" OnClick="SearchBSId1_Click" Text="Search" CssClass="btn-info"  />
                </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="StudentId"></asp:RequiredFieldValidator></td>
                </asp:Panel>
                <asp:Panel ID="StudentNamePanel" runat="server"> <td>
                    Student Name
                </td>
                <td>
                    <asp:TextBox ID="StudentName" runat="server" CssClass="form-control"></asp:TextBox><asp:Button ID="SearchByName1" runat="server" OnClick="SearchByName1_Click1" Text="Search" CssClass="btn-info"/>
                </td>
                    <td><asp:RequiredFieldValidator ID="R1" runat="server" ErrorMessage="*Required" ControlToValidate="StudentName"></asp:RequiredFieldValidator></td>
                </asp:Panel>
              
                 </tr>
        </table>
            </asp:Panel>
    <div class="pre-scrollable">
       <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered table-condensed table-hover table-responsive"  HeaderStyle-BackColor="#336699" HeaderStyle-ForeColor="White">
           <Columns>
              <asp:HyperLinkField  DataNavigateUrlFormatString="~/Admin View/AttendanceDetails.aspx?StudentId={0}&SubjectName={1}" DataNavigateUrlFields="StudentId,SubjectName" Text="Details" />
        
                     </Columns>
       </asp:GridView>
           </div>
    </div>
    <hr />
   </asp:Content>
