<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchCourseDetails.aspx.cs" Inherits="AttendanceSystem.ManageCourse.SearchCourseDetails" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container-fluid" style="margin-top:30px">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
    <h1>Course Details <small>Panel</small></h1>
            
        <h3>
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#FF3300" NavigateUrl="~/Admin View/ManageCourse/AddCourse.aspx">Add New Course</asp:HyperLink></h3>
        <table>
            <tr>
                <td>
                    Filter By
                </td>
                <td>
                    <asp:DropDownList ID="SelectFilterOption" runat="server" OnSelectedIndexChanged="SelectFilterOption_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>Course Name</asp:ListItem>
                        <asp:ListItem>Course Id</asp:ListItem>
                       <asp:ListItem>Department Name</asp:ListItem>


                    </asp:DropDownList>
                    </td>
                    <asp:Panel ID="ByName" runat="server" Visible="False">
            <td>
                Select Course Name
            </td>
                <td>
                    <asp:Label ID="l1" runat="server"></asp:Label>
                    <asp:DropDownList ID="SelectCoursetName" runat="server" AutoPostBack="True"   OnSelectedIndexChanged="SelectCoursetName_SelectedIndexChanged" CssClass="form-control">

                    </asp:DropDownList>
                </td>
             </asp:Panel> 
             <asp:Panel ID="ById" runat="server" Visible="False">
            <td>
                Enter Course Id
            </td>
                <td>
                   <asp:TextBox ID="Course" runat="server" TextMode="SingleLine" CssClass="form-control" placeholder="Course Name"></asp:TextBox>                   
                </td>
                 <td><asp:Button ID="Search" runat="server" Text="Search"  OnClick="Search_Click" CssClass="btn"/></td>
                 <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="Course" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:CompareValidator ID="Validator1" runat="server" ControlToValidate="Course" ErrorMessage="Invalid " ForeColor="#ff3300" Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                  </td>
             </asp:Panel> 
                
             <asp:Panel ID="ByDepartmentName" runat="server" Visible="False">
            <td>
                Select Department
            </td>
                <td>
                    <asp:DropDownList ID="DepartmentName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DepartmentName_SelectedIndexChanged" CssClass="form-control">

                    </asp:DropDownList>

                </td>
                 <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DepartmentName"
                ErrorMessage="Value Required!" InitialValue="Select.."></asp:RequiredFieldValidator>
                 </td>
             </asp:Panel> 
              
            </tr>
        </table>
        <asp:GridView ID="ShowCourseDetails" runat="server"  CssClass="table table-hover table-responsive table-condensed bg-warning text-warning" HeaderStyle-BackColor="#B69782" HeaderStyle-ForeColor="#ffffff">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFormatString="~/Admin View/ManageCourse/UpdateCourse.aspx?CourseId={0}" Text="Edit" DataNavigateUrlFields="CourseId" />
               
                <asp:HyperLinkField DataNavigateUrlFormatString ="~/Admin View/ManageCourse/DeleteCourse.aspx?CourseId={0}" Text="Delete" DataNavigateUrlFields="CourseId"/>
            </Columns>
                        <EmptyDataTemplate>
                <div style="width:500px;height:300px">
                <h1 style="padding:50px;color:red">
                        Searching Details are not present in the database.....
                </h1>
                    </div>
            </EmptyDataTemplate>
            
        </asp:GridView>
    </div>
               
</asp:Content>
