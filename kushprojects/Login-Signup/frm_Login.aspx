<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_Login.aspx.cs" Inherits="ASP_ALL_In_1.Login_Signup.frm_Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body{
             background-color:azure;

        }
        #Panel1{
            background-color:green;
          
        }
        #Label1{
            font-size:22px;
            color:blanchedalmond;
            text-align:center;
            height:35px;

        }
        #Panel2{
              margin-left:350px;
        }
        #txtEmail,#txtPassword,#ddlUserType{
            height:25px;
            width:300px;
        }
        .label{
            font-size:22px;
            color:green;
            font-weight:bold;
        }
        #btnSubmit{
            width:150px;
            height:35px;
            background-color:green;
            color:white;
            font-size:22px;
        }
        tr{
            line-height:55px;
        }

        .logo{
            width:350px;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="35px">
                <asp:Label ID="Label1" runat="server" Text="B Group of Technology - Login"></asp:Label>
            </asp:Panel>
                <div class="logo">
            <img alt="" src="../images/login.png" />
                 </div>
            <div class="logintb">
            <asp:Panel ID="Panel2" runat="server">
                                  <table >
             <caption><h3 style="text-align:center;color:green; font-size:22px;">Login - Form&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="linkSignup" runat="server" OnClick="linkSignup_Click">Signup</asp:LinkButton>
                 </h3>  </caption>

                  <tr><td class="label">Email :</td>
                    <td><asp:TextBox ID="txtEmail" runat="server" /></td>
                </tr>
                                      <caption>
                                          <tr>
                                              <td class="label">Select User Type :</td>
                                              <td>
                                                  <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="True" Font-Bold="True" Height="35px" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                                                      <asp:ListItem>-------------Select User Type-------------</asp:ListItem>
                                                      <asp:ListItem>Admin</asp:ListItem>
                                                      <asp:ListItem>GUser</asp:ListItem>
                                                  </asp:DropDownList>
                                              </td>
                                          </tr>
                                      </caption>
                                      </tr>
                 <tr><td class="label">Password :</td>
                    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /></td>
                </tr>

                <tr align="center">
                    
                    <td colspan="2"><asp:Button ID="btnSubmit" Text="Login" runat="server" OnClick="btnSubmit_Click"/>
                        <br />
                        <asp:LinkButton ID="linkForgetPass" runat="server">Forget Password ?</asp:LinkButton>
                    </td>
                </tr>
            </table>


            </asp:Panel>
                </div>
        </div>
    </form>
</body>
</html>
