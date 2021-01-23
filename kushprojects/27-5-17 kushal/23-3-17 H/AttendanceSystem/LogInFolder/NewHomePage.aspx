<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewHomePage.aspx.cs" Inherits="AttendanceSystem.LogInFolder.NewHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .main {
        
        height:660px;
        color:#FF9E5B;
        font-family:"Times New Roman", Times, serif;
    
     
       
       font-family:Verdana;
       font-weight:bolder;
       padding:200px;

      
        }
         .main1{
         background-image:url('/Images/back4.jpg');
        background-size:100% 100%;

           
        }

        .LogIn {
        height:300px;
        width:650px;
        background-color:#FFCEA9;
        opacity:0.9;
       
        border-radius:10px;
        color:#828282;
        }
        
        .auto-style1 {
            width: 180px;
        }
        .LogInButton {
       height:80px;
       width:80px;
       border-radius:50%;
       background-color: #FF8E41;
       color:white;
      margin-top:15px;

        }
            .LogInButton:hover {
            background-color:white;
            color: #FF8E41;
            }
        .left {
        height:100%;
        width:80px;
        background-color:#FF9E5B;
        float:left;
        border-top-left-radius:10px;
        border-bottom-left-radius:10px;
        }
        .inner {
        

        }
    </style>
      <link  href="../Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<script  src="../Bootstrap/js/bootstrap.min.js"></script> 
      <script src="Scripts/JavaScript1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        
    <div class="main1" >
          <div>
               <nav class="navbar navbar-inverse navbar-fixed-top">
                   <div class="container bg-muted">
                       <div class="navbar-header" style="font-size:20px">
                         <a href="#" class="navbar navbar-brand">Student Attendance <small>System</small></a> 
                  
               </nav>

     
               </div>
    <div class="main">
     
   <center>  <div class="LogIn">
        <div class="left"></div>
      
       <div style="padding:40px">
           
         <h2>Log In</h2>
      
        <table>
             <tr>
                 <td class="auto-style1">
                     <asp:DropDownList ID="UserType" runat="server" CssClass="form-control" Width="206px" >
                         <asp:ListItem>User Type.</asp:ListItem>
                          <asp:ListItem>Admin</asp:ListItem>
                          <asp:ListItem>Student</asp:ListItem>
                          <asp:ListItem>Teacher</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td>
                  <asp:TextBox ID="UserId" runat="server" TextMode="Number" placeholder="UserId" Width="206px" CssClass="form-control glyphicon glyphicon-user"></asp:TextBox>
                 </td>
                                              <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="UserId" ErrorMessage="*Required" Display="Dynamic"></asp:RequiredFieldValidator></td>

             </tr>
            <tr>
                <asp:Panel  ID="PasswordPanel" runat="server">
                <td class="auto-style1">
                 <span><asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="Password" CssClass="form-control" Width="206px"></asp:TextBox></span>
 
                </td>
                    <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Password" ErrorMessage="*Required" Display="Dynamic" Width="206px"></asp:RequiredFieldValidator>
                   </td>
                     <td><asp:Label ID="Label1" runat="server"></asp:Label></td>
                    </asp:Panel>
                <asp:Panel ID="NewPassword" runat="server" Visible="false" >
                    <td>   
                        <span><asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" placeholder="New Password" CssClass="form-control" Width="206px"></asp:TextBox></span>
                       </td>
                 
                   
                    <td>
                         <span><asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password" placeholder="Confirm Password" CssClass="form-control" Width="206px"  style="margin-left:45px"></asp:TextBox></span>

                    </td>
               
               
                   <td> <asp:CompareValidator ID="Comp" runat="server" ControlToValidate="txtConfirmPass" ControlToCompare="txtNewPassword" ErrorMessage="Not Match" ></asp:CompareValidator></td>
                </asp:Panel>
            </tr>
            <asp:Panel ID="Validation" runat="server" Visible="false">
            <tr>
                 <td>
                       
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="*Required" Display="Dynamic" ></asp:RequiredFieldValidator>
                   </td>
                 <td>
                       
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPass" ErrorMessage="*Required" Display="Dynamic"></asp:RequiredFieldValidator>
                   </td>
                 
            </tr>
           </asp:Panel>
            
         </table>
            <asp:Button ID="LogIn" runat="server" Text="LogIn" OnClick="LogIn_Click" CssClass="LogInButton" />
            <asp:Button ID="LogIn2" runat="server" Text="LogIn2" OnClick="Button1_Click" CssClass="LogInButton"  Visible="false"/>
     </div>
      
    </center>
        </div>
        </div>
        
    </form>
</body>
</html>
