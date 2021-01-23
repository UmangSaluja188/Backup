<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="link.aspx.cs" Inherits="AttendanceSystem.link" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  <center>  <div>
<h1>Admin View</h1>
      <table>
          <tr>
              <td><h2><asp:HyperLink ID="HyperLink0" runat="server" NavigateUrl="~/Manage Department/SearchDepartment.aspx">Manage Department Details</asp:HyperLink></h2></td>
               <td><h2><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ManageCourse/SearchCourseDetails.aspx">Manage Course Details</asp:HyperLink></h2></td>
              <td><h2><asp:HyperLink ID="HyperLinkl" runat="server" NavigateUrl="~/ManageSemester/SearchSemester.aspx">Manage Semester Details</asp:HyperLink></h2></td>
             

          </tr>
         
           <tr>
  
               <td><h2><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/ManageTeacher/SearchTeacherRecord.aspx">Manage Teacher Details</asp:HyperLink></h2></td>
              <td><h2><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/ManageTeacherTimeTable/SearchTimeTable.aspx">Manage Teacher Time Table Details</asp:HyperLink></h2></td>
              <td><h2><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/ManageHoliday/AddHoliday.aspx">Manage Holiday Details</asp:HyperLink></h2></td>

          </tr>
           <tr>
               <td><h2><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Manage Subject/SearchSubjectDetails.aspx">Manage Subject Details</asp:HyperLink></h2></td>
                          <td><h2><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/ManageStudent/SearchStudentDetails2.aspx">Manage Student Details</asp:HyperLink></h2></td>
          </tr>
      </table>
    </div>
  
        <br />
        <h1>
            Teacher View

        </h1>
        <table>
            <tr>
                <td>
                   <h2> <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/TeacherView/TakeAttend.aspx">Take Attendance</asp:HyperLink></h2>

                </td>
                <td>
              <h2> <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/TeacherView/SearchAttendance.aspx">Search Student Attendance And fine Details</asp:HyperLink></h2>

               </td>
            </tr>
            <tr>
          
                <td>
                  <h2> <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/ManageTeacher/SearchTeacherRecord.aspx"></asp:HyperLink></h2>

                </td>
                <td>
                    <h2> <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/ManageTeacherTimeTable/SearchTimeTable.aspx">Check Personal Time Table</asp:HyperLink></h2>

                </td>
            </tr>
        </table>

        <h1>
            Student View 
           
        </h1>
        <table>
            <tr>
                <td>
                    <h2><asp:HyperLink ID="link1" runat="server" NavigateUrl="~/StudentView/SerachAttendanceBySTudent.aspx">
                        Serach Attendance And Fine Details
                        </asp:HyperLink></h2>
                </td>
                  <td>
                    <h2><asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/StudentView/ViewPersonalDetails.aspx">
                        View Personal Details
                        </asp:HyperLink></h2>
                </td>
                </tr>
            <tr>
                  <td>
                    <h2><asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/StudentView/ViewTimeTable.aspx">
                        View Time Table
                        </asp:HyperLink></h2>
                </td>
                  <td>
                    <h2><asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/StudentView/TakeLeave.aspx">
                        Take Leave
                        </asp:HyperLink></h2>
                </td>
            </tr>
        </table>
          </center>
    </form>
</body>
</html>
