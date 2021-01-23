<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchStudentDetails2.aspx.cs" Inherits="AttendanceSystem.ManageStudent.SearchStudentDetails2" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>

<asp:Content ID="c2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container-fluid" style="margin-top:20px">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
            </div>
    <h1>Student Details <small> Panel</small></h1>
        <h3>
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#FF3300" NavigateUrl="~/Admin View/ManageStudent/AddNewStu.aspx">Add New Student</asp:HyperLink></h3>
        <table>
            <tr>
                
                    <td>
                        Filter By
                    </td>
                    <td>
                        <asp:DropDownList ID="FilterBy" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="FilterBy_SelectedIndexChanged" CssClass="form-control">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Department Name</asp:ListItem>
                            <asp:ListItem>Course Name</asp:ListItem>
                            <asp:ListItem>Student Id</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                
                <asp:Panel ID="SelectDepPanel" runat="server" Visible="False">
                <td>
                    Select Department
                </td>
                <td>
                    <asp:DropDownList ID="SelectDepartment" runat="server" OnSelectedIndexChanged="SelectDepartment_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>

                </td>
                    </asp:Panel>
                <asp:Panel ID="SelectCourPanel"  runat="server" Visible="False">
                <td>
                    Select Course
                </td>
                <td> <asp:DropDownList ID="SelectCourse" runat="server" OnSelectedIndexChanged="SelectCourse_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList></td>
                 </asp:Panel>
                 <asp:Panel ID="SelectSemPanel" runat="server" Visible="False">
                    <td>
                    Select Semester
                </td>
                     <td>
                    <asp:DropDownList ID="SelectSemN" runat="server" OnSelectedIndexChanged="SelecSemester_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                </td>
                 </asp:Panel>
                 <asp:Panel ID="EnterStudentId" runat="server" Visible="False">
                   
                     <td>
                         <asp:TextBox ID="StudentId" runat="server" CssClass="form-control" placeHolder="Student Id"></asp:TextBox>
                </td>
                     <td>
                         <asp:Button ID="Search" runat="server" Text="Search"  OnClick="Search_Click" CssClass="btn"/>
                     </td>
                     <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="StudentId" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:CompareValidator ID="Validator1" runat="server" ControlToValidate="StudentId" ErrorMessage="Invalid " ForeColor="#ff3300" Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                  </td>
                 </asp:Panel>
                  </tr>
        </table>
        <table style="float:right">
            <tr>
               
                <td>
                    <asp:TextBox ID="StudentName" runat="server" CssClass="form-control" placeholder="Student Name"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Search1" runat="server" Text="Search"  OnClick="Search1_Click" CssClass="btn"/>

                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="StudentId"  ValidationGroup="v1" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="StudentId" ErrorMessage="Invalid " ForeColor="#ff3300" Type="String" Operator="DataTypeCheck" ValidationGroup="v1" Display="Dynamic"></asp:CompareValidator>
                  </td>
            </tr>
        </table>
        </div>
        <div>
        <asp:GridView ID="ShoStudentDetails" runat="server" OnRowDataBound="ShoStudentDetails_RowDataBound" CssClass="table table-hover table-responsive table-condensed bg-warning text-warning" HeaderStyle-BackColor="#B69782" HeaderStyle-ForeColor="#ffffff">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFormatString="~/Admin View/ManageStudent/UpdateStudentDetails.aspx?StudentId={0}&amp;mode=edit" Text="Edit"   DataNavigateUrlFields="StudentId" />
                <asp:HyperLinkField DataNavigateUrlFormatString="~/Admin View/ManageStudent/DeleteStudentRecord.aspx?StudentId={0}&amp;mode=delete" Text="Delete"  DataNavigateUrlFields="StudentId"/>
                <asp:HyperLinkField DataNavigateUrlFormatString="~/Admin View/ManageStudent/UpdateStudentDetails.aspx?StudentId={0}&amp;mode=details" Text="Details"  DataNavigateUrlFields="StudentId"/>
                <asp:ImageField DataImageUrlField="Image" HeaderText="Image" ControlStyle-Height="60px" ControlStyle-Width="60px">
<ControlStyle Height="60px" Width="60px"></ControlStyle>
                </asp:ImageField>
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
