<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchTimeTable.aspx.cs" Inherits="AttendanceSystem.ManageTeacherTimeTable.SearchTimeTable" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>

<asp:Content ID="C1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="container-fluid" style="margin-top:4%">
        <asp:Label ID="Error" runat="server"  Font-Size="30px"></asp:Label>
   <h1>Teacher Time Table <small>Panel</small></h1>
        <h3>
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#FF3300"  NavigateUrl="~/Admin View/ManageTeacherTimeTable/AddTimeTable1.aspx?mode=add" >Add New Teacher Time Table Details</asp:HyperLink></h3> 
        <asp:Label ID="Information" runat="server"></asp:Label>
       <div class="row">
           <div class="col-sm-12">
         <table>
            <tr>
                <td>
                    Filter By
                </td>
                <td>
                    <asp:DropDownList ID="FilterBy" runat="server" OnSelectedIndexChanged="FilterBy_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                        <asp:ListItem>Select..</asp:ListItem>
                        <asp:ListItem>Teacher Name</asp:ListItem>
                        <asp:ListItem>Teacher Id</asp:ListItem>
                        <asp:ListItem>Course Name</asp:ListItem>
                    </asp:DropDownList>
                </td>
            <<asp:Panel ID="SelectCoursePanel" runat="server" Visible="False">
                <td>
                    Select Course Name
                </td>
                <td>
                    <asp:DropDownList ID="CourseName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CourseName_SelectedIndexChanged" CssClass="form-control" >

                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="v1" runat="server" ControlToValidate="CourseName" SetFocusOnError="true" ErrorMessage="Please Select" InitialValue="0" ></asp:RequiredFieldValidator>
                </td>
                </asp:Panel>
                <td></td>
                <asp:Panel ID="SelectSemesterPanel" runat="server" Visible="False">
                <td>
                    Select Semester No
                </td>
                <td>
                    <asp:DropDownList ID="SemesterNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SemesterNo_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
                </asp:Panel>
                 <asp:Panel ID="TeacherNamePanel" runat="server" Visible="False">
                     <td>
                         Enter Teacher Name
                     </td>
                     <td>
                         <asp:TextBox ID="TeacherName" runat="server" CssClass="form-control"></asp:TextBox>
                     </td>
                     <td>
                         <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click"  CssClass="btn" CausesValidation="false" />
                     </td>
                     <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="TeacherName" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:CompareValidator ID="Validator1" runat="server" ControlToValidate="TeacherName" ErrorMessage="Invalid " ForeColor="#ff3300" Type="String" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                  </td>
                 </asp:Panel>
                 <asp:Panel ID="TeacherIdPanel" runat="server" Visible="False">
                     <td>
                         Enter Teacher ID
                     </td>
                     <td>
                         <asp:TextBox ID="TeacherId" runat="server" CssClass="form-control"></asp:TextBox>
                     </td>
                     <td>
                         <asp:Button ID="Search1" runat="server" Text="Search"  OnClick="Search1_Click" CssClass="btn"/>
                     </td>
                     <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="TeacherId"></asp:RequiredFieldValidator>
                     <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TeacherId" ErrorMessage="Invalid " ForeColor="#ff3300" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
                  </td>
                 </asp:Panel>


            </tr>
            </table>
       </div>
           </div>
        <div class="row">
           <div class="col-sm-3" style="float:right">
                  <span>Day </span> <asp:DropDownList ID="Day" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="Day_SelectedIndexChanged" CssClass="form-control" placeholder="Select Day">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>Monday</asp:ListItem>
                        <asp:ListItem>Tuesday</asp:ListItem>
                        <asp:ListItem>Wednesday</asp:ListItem>
                        <asp:ListItem>Thursday</asp:ListItem>
                        <asp:ListItem>Friday</asp:ListItem>
                        <asp:ListItem>Saturday</asp:ListItem>
                        </asp:DropDownList>

             </div>
           </div>
        </div>
   
    <div class="pre-scrollable">
        <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" PageSize="50" AllowPaging="True" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" OnPageIndexChanging="GridView2_PageIndexChanging"  CssClass="table table-bordered table-condensed table-hover table-responsive bg-warning text-warning" HeaderStyle-BackColor="#B69782" HeaderStyle-ForeColor="#ffffff" >
            <Columns>
                <asp:HyperLinkField  DataNavigateUrlFormatString="~/Admin View/ManageTeacherTimeTable/AddTimeTable1.aspx?TimeTableNo={0}&amp;mode=edit" Text="Edit"   DataNavigateUrlFields="TimeTableNo"  ItemStyle-CssClass="btn"/>            
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