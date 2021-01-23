<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ChangePassword.aspx.cs" Inherits="ASP_ALL_In_1.Login_Signup.frm_ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
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
        #txtNewPass,#txtOldPass{
            height:25px;
            width:300px;
        }
        .label{
            font-size:22px;
            color:green;
            font-weight:bold;
        }
        #btnChange{
            width:200px;
            height:35px;
            background-color:green;
            color:white;
            font-size:22px;
        }
        tr{
            line-height:55px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="35px">
                <asp:Label ID="Label1" runat="server" Text="B Group of Technology - Change Password"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                                  <table >
             <caption><h3 style="text-align:center;color:green; font-size:22px;">Change Password - Form&nbsp;&nbsp;&nbsp;&nbsp;
                 </h3>  </caption>

                  <tr><td class="label">Old Password :</td>
                    <td><asp:TextBox ID="txtOldPass" runat="server" TextMode="Password" /></td>
                </tr>
                 <tr><td class="label">New Password :</td>
                    <td><asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" /></td>
                </tr>

                <tr align="center">
                    
                    <td colspan="2"><asp:Button ID="btnChange" Text="Change Password" runat="server" OnClick="btnChange_Click"/>
                        <br />
                    </td>
                </tr>
            </table>


            </asp:Panel>
        </div>
    </form>
</body>
</html>
