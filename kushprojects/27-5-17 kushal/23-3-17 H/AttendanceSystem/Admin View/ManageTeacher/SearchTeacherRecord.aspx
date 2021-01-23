<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchTeacherRecord.aspx.cs" Inherits="AttendanceSystem.ManageTeacher.SearchTeacherRecord"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>

<asp:Content ID="c2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">            
    <div class="container" style="margin-top:5%">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
  <center>  <h1> <span class="label label-info">Teacher Details<small> Panel</small></span></h1></center>
        <h3>
            
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin View/ManageTeacher/AddNewTeacher.aspx">Add New Teacher</asp:HyperLink> </h3>
        <table>
            <tr>
                <asp:Panel ID="SDNPanel" runat="server" >
                <td>
                    Select Department
                </td>
                <td>
                    <asp:DropDownList ID="SelectDepartment" runat="server" OnSelectedIndexChanged="SelectDepartment_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control"></asp:DropDownList>
                </td>
                    </asp:Panel>
                  <asp:Panel ID="STNPanel" runat="server" Visible="False">
                <td>
                    Filter By
                </td>
                      <td> 
                <asp:DropDownList ID="SelectTeacher" runat="server" OnSelectedIndexChanged="SelectTeacher_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Teacher Name</asp:ListItem>
                    <asp:ListItem>Teacher Id</asp:ListItem>
                </asp:DropDownList>
                     </td>
                       </asp:Panel>
                <asp:Panel ID="STBNamePanel" runat="server" Visible="false">
                     <td >Teacher Name</td>
                        <td>
                           <asp:TextBox ID="EnterTeacherName" runat="server" CssClass="form-control" placeholder="Teacher Name"></asp:TextBox>
                       </td>
                       <td>
                           <asp:Button ID="Serach" runat="server" Text="Search"  OnClick="Serach_Click" CssClass="btn"/>
                       </td>
                    <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="EnterTeacherName"></asp:RequiredFieldValidator>
                  </td>
                    </asp:Panel>
                <asp:Panel  ID="STBIDPanel" runat="server" Visible="false">
                        <td >Teacher Id</td>
                        <td>
                           <asp:TextBox ID="EnterTId" runat="server"  CssClass="form-control" placeholder="Teacher Id"></asp:TextBox>

                       </td>
                    <td><asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="EnterTId" ErrorMessage="*Required" Display="Dynamic"></asp:RequiredFieldValidator></td>
                    <td><asp:CompareValidator ID="c1" runat="server" ControlToValidate="EnterTId" ErrorMessage="Invalid" Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator></td>
                       <td>
                           <asp:Button ID="Search2" runat="server" Text="Search" OnClick="Search2_Click1" CssClass="btn"/>
                       </td>
                    </asp:Panel>
            </tr>
        </table>
        </div>
    <div class="pre-scrollable container-fluid" >
        <asp:GridView ID="ShowTeacherDetails" runat="server" OnRowDataBound="ShowTeacherDetails_RowDataBound" CssClass="table table-hover table-responsive table-condensed bg-warning text-warning" HeaderStyle-BackColor="#B69782" HeaderStyle-ForeColor="#ffffff">
            <Columns>
                 <asp:HyperLinkField  DataNavigateUrlFormatString="~/Admin View/ManageTeacher/UpdateTeacher.aspx?TeacherId={0}&amp;mode=edit" Text="Edit"   DataNavigateUrlFields="TeacherId"/>
                <asp:HyperLinkField  DataNavigateUrlFormatString="~/Admin View/ManageTeacher/DeleteTeacherRecord.aspx?TeacherId={0}&amp;mode=delete" Text="Delete" DataNavigateUrlFields="TeacherId"/>
               <asp:HyperLinkField  DataNavigateUrlFormatString="~/Admin View/ManageTeacher/UpdateTeacher.aspx?TeacherId={0}&amp;mode=details"  Text="Details" DataNavigateUrlFields="TeacherId"/>
                <asp:ImageField   DataImageUrlField="Image" HeaderText="Image"  ControlStyle-Height="70px" ControlStyle-Width="70px">
                <ControlStyle Height="80px" Width="80px"></ControlStyle>
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
