<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchDepartment.aspx.cs" Inherits="AttendanceSystem.Manage_Department.SearchDepartment"   MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   <div class="row">
       <div class="col-sm-12">
    <div class="container-fluid" style="margin-top:10%">
        <div class="row-content">
            <div class="col-sm">
                
            <div class="jumnptorn"><h1 class="text-muted">Department<small> Panel</small></h1></div>
       
            </div>
        </div>
        <div>
           <asp:Label ID="Error" runat="server"  ForeColor="#ff3300" Font-Size="50px"></asp:Label>
        
        <h3>
           <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#FF3300" NavigateUrl="~/Admin View/Manage_Department/AddDepartment.aspx">Add New Department</asp:HyperLink></h3>
   <div class="form-inline">
       <table class="form-group">
           <tr>
               <td>
                     Filter By 
                   </td>
               <td>
                   
                <asp:DropDownList ID="SelectOption" runat="server" OnSelectedIndexChanged="ShowAllDepartment_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control">
                   <asp:ListItem>All</asp:ListItem>
                   <asp:ListItem>Department Id</asp:ListItem>
                   <asp:ListItem>Department Name</asp:ListItem>
                </asp:DropDownList>
               </td>
             
            <asp:Panel ID="ByName" runat="server" Visible="False">
         
              <td>Select Department</td>
                <td><asp:DropDownList ID="SelectDepartmentName" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="SelectDepartmentName_SelectedIndexChanged"  CssClass="form-control">   </asp:DropDownList>
               </td>              
             </asp:Panel> 
             <asp:Panel ID="ById" runat="server" Visible="False">
            <td>
              Enter Department Id
            
             
                   <asp:TextBox ID="DepartmentId" runat="server" TextMode="SingleLine"  CssClass="form-control" placeholder="Department Id"></asp:TextBox>                   
                
                 <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" CssClass="btn"/>
                 
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="DepartmentId" Display="Dynamic"></asp:RequiredFieldValidator>
                     <asp:CompareValidator ID="Validator1" runat="server" ControlToValidate="DepartmentId" ErrorMessage="Invalid " ForeColor="#ff3300" Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                </td> 
             </asp:Panel> 
               </tr>
           </table>
        </div>
            <div class="pre-scrollable">
        <asp:GridView ID="ShowDepartmentDetails" runat="server" AllowPaging="True"  CssClass="table table-hover table-responsive table-condensed bg-warning text-warning" HeaderStyle-BackColor="#B69782" HeaderStyle-ForeColor="#ffffff">
            <Columns>
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFormatString="~/Admin View/Manage_Department/UpdateDepartment.aspx?DepartmentId={0}" DataNavigateUrlFields="NDepartmentId" />
                <asp:HyperLinkField  Text="Delete"  DataNavigateUrlFormatString="~/Admin View/Manage_Department/DeleteDepartment.aspx?DepartmentId={0}" DataNavigateUrlFields="NDepartmentId" />
            </Columns>
            <EmptyDataTemplate>
                <div style="width:500px;height:300px">
                <h1 style="padding:50px;color:red">
                        Searching Details are not present in the database.....
                </h1>
                    </div>
            </EmptyDataTemplate>
        </asp:GridView>    </div>
        </div>
    </div>
   </div>    
       </div>
</asp:Content>
