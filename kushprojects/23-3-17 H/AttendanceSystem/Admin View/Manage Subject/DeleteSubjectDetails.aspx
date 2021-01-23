<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteSubjectDetails.aspx.cs" Inherits="AttendanceSystem.Manage_Subject.DeleteSubjectDetails" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>
<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container-fluid" style="margin-top:20px">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="50px"></asp:Label>
    <h1>Delete Subject <small>Details</small></h1>
       
                     <label for="SearchTextbox"  class="form-control">Student Id</label> 
                    <asp:TextBox ID="SearchTextbox" runat="server" Width="141px" CssClass="form-control"  placeholder="Subject Id" ReadOnly="true"></asp:TextBox>             
            
                  <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" CssClass="btn" />
                <asp:Button ID="Cancel" runat="server" Text="Cancel"  OnClick="Cancel_Click" CssClass="btn" />          
          
                    
    </div>              
    </asp:Content>