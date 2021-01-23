<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentLogIn.aspx.cs" Inherits="AttendanceSystem.LogInFolder.StudentLogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
    <style>
        .outerdiv {
        height:450px;
        width:350px;
        border:2px solid black;
        border-radius:15px;
        margin-top:100px;
        background-color:#343434;
        }
        .innerDiv {
            margin: 100px;
            height: 300px;
            width: 250px;
            border: 1px solid black;
            margin: 50px;
            background-color: #EAEAEA;
            margin-top: 75px;
            border-radius:8px;
        }
        .Ima {
       
        border-radius:50%;
        }
        .TextBoxBorder {
        border:0.3px solid black;
        border-radius:4px;
       
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <center><div class="outerdiv">
<div class="innerDiv">
<div style="background-color:#E46868;height:90px;border-top-left-radius:8px;border-top-right-radius:8px">
    
<div><asp:Image ID="Img1" runat="server" height="85px" Width="85px" ImageUrl="~/Images/Student.jpg"  CssClass="Ima" />
    </div>

    <div style="margin-top:30px">
        
       <table>
            <tr>
                <td>
                    <asp:TextBox ID="UserId" runat="server" Height="30px" OnTextChanged="UserId_TextChanged" Width="200px" CssClass="TextBoxBorder"  placeholder="Student Id" ></asp:TextBox>
                </td>
                <td><asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="UserId" ErrorMessage="*Required" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>
             <asp:Panel ID="PasswordPanel" runat="server" >
             <tr>
              

                <td>
                    <asp:TextBox ID="Password" runat="server"  TextMode="Password" Height="30px" OnTextChanged="Password_TextChanged" style="margin-bottom: 2px" Width="200px" CssClass="TextBoxBorder"  placeholder="Password" ></asp:TextBox>
                </td>
                   <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Password" ErrorMessage="*Required" Display="Dynamic"></asp:RequiredFieldValidator>
                   </td>
                 <td><asp:Label ID="Label1" runat="server"></asp:Label></td>
            </tr>
            <tr>

                <td>
                    <asp:Button ID="LogIn" runat="server" OnClick="LogIn_Click"  Text="Log In" Width="204px" Height="35px" BackColor="#E46868" ForeColor="White" CssClass="TextBoxBorder"/>
                </td>
            </tr>
          </asp:Panel>
            <asp:Panel ID="NewPassword" runat="server" Visible="false">
                <tr>
                    <td>
                       <asp:TextBox ID="NewPass" runat="server"  TextMode="Password" Height="30px" style="margin-bottom: 2px" Width="200px" CssClass="TextBoxBorder" placeholder="New Password"  ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NewPass" ErrorMessage="*Required" Display="Dynamic"></asp:RequiredFieldValidator>

                    </td>
                     <td>
                   </td>
                </tr>
                <tr>
                    <td>
                       <asp:TextBox ID="ConfPass" runat="server"  TextMode="Password" Height="30px" style="margin-bottom: 2px" Width="200px" CssClass="TextBoxBorder"  placeholder="Confirm Password" ></asp:TextBox>
                    </td>
                     <td>
                         <asp:CompareValidator ID="c2" runat="server" ControlToValidate="ConfPass" ControlToCompare="NewPass" Type="String" Operator="Equal" ErrorMessage="Not Match"></asp:CompareValidator>
                   </td>
                    <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfPass" ErrorMessage="*Required" Display="Dynamic"></asp:RequiredFieldValidator>

                    </td>
                    <td></td>
                </tr>

                <tr>

                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  Text="Log In" Width="204px" Height="35px" BackColor="#E46868" ForeColor="White" CssClass="TextBoxBorder"/>
                </td>
            </tr>
            </asp:Panel>
             
        </table>

    </div></div>
</div>
    </div>
        </center>
    </form>
</body>
</html>
