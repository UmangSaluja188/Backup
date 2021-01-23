<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchSemester.aspx.cs" Inherits="AttendanceSystem.ManageSemester.ManageSemester" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>
<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
    <h1>Search Semester</h1>
           <h3>
            <asp:HyperLink ID="AddnewSemester" runat="server" ForeColor="#FF3300" NavigateUrl="~/Admin View/ManageSemester/AddSemester.aspx"> New Semester</asp:HyperLink></h3>
    <table>

        <tr>
            <td>
                Filter By
            </td>
            <td>
                <asp:DropDownList ID="SelectOption" runat="server"  OnSelectedIndexChanged="SelectOption_SelectedIndexChanged" CssClass="form-control"
                     AutoPostBack="True">
                   <asp:ListItem>All</asp:ListItem>
                   <asp:ListItem>Semester Id</asp:ListItem>
                   <asp:ListItem>Semester No</asp:ListItem>
                  <asp:ListItem>Course Name</asp:ListItem>

                  

                </asp:DropDownList>
            </td>
            <td>

            </td>
            <asp:Panel ID="ByNo" runat="server" Visible="False">
            <td>
                Select Semester No
            </td>
                <td>
                    <asp:DropDownList ID="SelectSemesterNo1" runat="server" AutoPostBack="True"   OnSelectedIndexChanged="SelectSemesterNo_SelectedIndexChanged" CssClass="form-control">
                        <asp:ListItem>Select...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>


                    </asp:DropDownList>
                </td>
             </asp:Panel> 
             <asp:Panel ID="ById" runat="server" Visible="False">
            <td>
                Enter Semester Id
            </td>
                <td>
                   <asp:TextBox ID="SemesterId" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>                   
                </td>
                 <td><asp:Button ID="Search" runat="server" Text="Search"  OnClick="Search_Click" CssClass="btn"/></td>
                 <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="SemesterId"></asp:RequiredFieldValidator>
                     <asp:CompareValidator ID="Validator1" runat="server" ControlToValidate="SemesterId" ErrorMessage="Invalid " ForeColor="#ff3300" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
                  </td>
             </asp:Panel> 
                <asp:Panel ID="ByCourseName" runat="server" Visible="False">
            <td>
               Select Course Name
            </td>
                <td>
                    <asp:DropDownList ID="SelectCourseName" runat="server" OnSelectedIndexChanged="SelectCourseName_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control" ></asp:DropDownList>                </td>
                 
             </asp:Panel> 
        </tr>
    </table>
        <div class="pre-scrollable">
        <asp:GridView ID="ShowSemesterDetails" runat="server"  OnSelectedIndexChanged="ShowSemesterDetails_SelectedIndexChanged" AllowPaging="True" HorizontalAlign="Center"  CssClass="table table-hover table-responsive table-condensed bg-warning text-warning" HeaderStyle-BackColor="#B69782" HeaderStyle-ForeColor="#ffffff" PageSize="100">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFormatString ="~/Admin View/ManageSemester/UpdateSemester.aspx?SemesterId={0}" Text="Edit"  DataNavigateUrlFields="SemesterId"/>
                <asp:HyperLinkField DataNavigateUrlFormatString ="~/Admin View/ManageSemester/DeleteSemester.aspx?SemesterId={0}" Text="Delete"  DataNavigateUrlFields="SemesterId"/>
            </Columns>
            <EmptyDataTemplate>
               <h1> Searching details are not present.....</h1>
            </EmptyDataTemplate>
        </asp:GridView>
            </div>
    </div>

  </asp:Content>