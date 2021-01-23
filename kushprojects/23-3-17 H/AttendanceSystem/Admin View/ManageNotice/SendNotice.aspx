﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendNotice.aspx.cs" Inherits="AttendanceSystem.Admin_View.ManageNotice.SendNotice" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   <div class="container-fluid" style="margin-top:7%">
     <div>
     
    <h1 class="text-primary" style="margin-left:50px;">Send Notice</h1>
        <table class="auto-style1">

            <tr>         
                <td class="auto-style1">
                    <asp:DropDownList ID="s1" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="s1_SelectedIndexChanged" CssClass="form-control" Width="302px">
                        <asp:ListItem>Send To...</asp:ListItem>
                        <asp:ListItem>Particular Student</asp:ListItem>
                        <asp:ListItem>Particular Class</asp:ListItem>
                        <asp:ListItem>All Student</asp:ListItem>

                    </asp:DropDownList>
                </td>
               <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ErrorMessage="*Required" ControlToValidate="s1" Display="Dynamic" InitialValue="Send To..."></asp:RequiredFieldValidator> </td>
                
            </tr>
            <asp:Panel ID="PStud" runat="server" Visible="false">
            <tr>

                
                <td>
                    <asp:TextBox ID="StudentId2" runat="server" placeholder="StudentId" CssClass="form-control"  OnTextChanged="StudentId2_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
                <td><asp:RequiredFieldValidator ID="r1" runat="server"  ErrorMessage="*Required" ControlToValidate="StudentId2" Display="Dynamic"></asp:RequiredFieldValidator> </td>
                
                <td><asp:Button ID="Check" runat="server" Text="Check" OnClick="Check_Click" CssClass="btn"/></td><td><asp:Label  ID="Label1" runat="server"></asp:Label></td>
</tr>
                 </asp:Panel>
            <asp:Panel ID="PClass" runat="server" Visible="false">
                <tr>
                    <td>
                        <asp:DropDownList ID="Department" runat="server" OnSelectedIndexChanged="Department_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ErrorMessage="*Required" InitialValue="Select Department..." ControlToValidate="Department" Display="Dynamic"></asp:RequiredFieldValidator> </td>
                
                    <td>
                        <asp:DropDownList ID="Course" runat="server"  OnSelectedIndexChanged="Course_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="*Required" ControlToValidate="Course" Display="Dynamic" InitialValue="Select Course..."></asp:RequiredFieldValidator> </td>
                
                    <td>
                        <asp:DropDownList ID="Semester" runat="server" OnSelectedIndexChanged="Semester_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ErrorMessage="*Required" ControlToValidate="Semester" Display="Dynamic" InitialValue="Select Semester..."></asp:RequiredFieldValidator> </td>
                
                    
                </tr>
            </asp:Panel>
                <tr>
                    <td style="text-align:center" class="auto-style1">
                        Title
                    </td>
                </tr>
                <tr>
                <td class="auto-style1">
                    <asp:TextBox ID="Title" runat="server" TextMode="MultiLine" CssClass="form-control" Width="302px"></asp:TextBox>
                </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ErrorMessage="*Required" ControlToValidate="Title" Display="Dynamic"></asp:RequiredFieldValidator> </td>
                
                    </tr>
             <tr>
                    <td style="text-align:center" class="auto-style1">
                        Notice
                    </td>
                </tr>
                <tr>
                <td class="auto-style1">
                    <asp:TextBox ID="Notice" runat="server" TextMode="MultiLine" CssClass="form-control" Height="68px" Width="300px" OnTextChanged="Notice_TextChanged"></asp:TextBox>
                </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  ErrorMessage="*Required" ControlToValidate="Notice" Display="Dynamic"></asp:RequiredFieldValidator> </td>
                
                    </tr>
           
        </table>
<asp:Button ID="Send" runat="server" Text="Send"  OnClick="Send_Click" CssClass="btn" Width="101px"  style="margin-left:50px;"/><asp:Button ID="Cancel" runat="server" Text="Cancel"  OnClick="Cancel_Click" CssClass="btn" Width="101px"/>

        <asp:Label ID="Lebel1" runat="server"></asp:Label>
    </div>
       </div>

   

</asp:Content>