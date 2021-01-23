<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_Home.aspx.cs" Inherits="ASP_ALL_In_1.Login_Signup.frm_Home" %>

<%@ Register Src="~/Login-Signup/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User - Home Page</title>
    <style>
        body{
            background-color:azure;
        }
        table{
            width:450px;
            line-height:35px;
            background-color:lightblue;
        }
        tr,td{
            font-size:18px;
            font-weight:bold;
        }
        h1,linkLogout{
            background-color:black;
            color:white;
            margin:0px;
        }
         #btnChangePassword{
            width:250px;
            height:35px;
            background-color:green;
            color:white;
            font-size:22px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
               <div>
                   <uc1:Header runat="server" id="Header" />
       </div>

        <div>
            <hr />
            <center>
                <table>
                    <tr>
                        <td>
                            User ID:
                        </td>
                        <td>
<asp:Label ID="lblUserId" runat="server" Text="lblUserId"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            User Name:
                        </td>
                        <td>
<asp:Label ID="lblUserName" runat="server" Text="lblUserName"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            User Email:
                        </td>
                        <td>
<asp:Label ID="lblUserEmail" runat="server" Text="lblUserEmail"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            User DOB:
                        </td>
                        <td>
<asp:Label ID="lblUserDOB" runat="server" Text="lblUserDOB"></asp:Label>
                        </td>
                    </tr>
                </table>
            </center>
        </div>
        <div>
            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
        </div>
    </form>
</body>
</html>
