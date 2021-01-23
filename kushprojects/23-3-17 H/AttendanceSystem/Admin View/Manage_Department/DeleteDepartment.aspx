<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteDepartment.aspx.cs" Inherits="AttendanceSystem.Mamage_CRI.DeleteDepartment" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="c1" runat="server">
    <div>
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="50px"></asp:Label>

        <h1>Delete  Department <small>Details</small></h1>
    
       
               <label for="Search" class="form-control">Department Id</label> <asp:TextBox ID="Search" runat="server" CssClass="form-control" placeholder="Department Id" Enabled="false"></asp:TextBox>
                <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" CssClass="btn" />            
                <asp:Button ID="Cancel" runat="server" Text="Cancel"  OnClick="Cancel_Click"  CssClass="btn"/>
            <asp:Label ID="lll" runat="server"></asp:Label>
    </div>
            

    </asp:Content>