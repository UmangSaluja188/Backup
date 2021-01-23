<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInHomePage.aspx.cs" Inherits="AttendanceSystem.LogInFolder.LogInHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .LogInOption {
        height:200px;
        width:150px;
        border:1px solid black;
        border-radius:50%;
        margin-left:30px;

        }
        .Image {
        height:200px;
        width:150px;
        border-radius:50%;

        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       <center> <table style="margin-top:200px">
            <tr>
                <td>

                    <div class="LogInOption">
                        <asp:ImageButton ID="TeacherLoginIm" runat="server" ImageUrl="~/Images/Teacher.jpg"  CssClass="Image" PostBackUrl="~/LogInFolder/TeacherLogIn.aspx" />
                    </div>
                </td>
                <td>
                    <div class="LogInOption">
                          <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/Images/admin.jpg"  CssClass="Image" PostBackUrl="~/LogInFolder/AdminLogInPage.aspx"/>
                    </div>
                </td>
                <td>
                    <div class="LogInOption">
                          <asp:ImageButton ID="Image2" runat="server" ImageUrl="~/Images/Student.jpg"  CssClass="Image"  PostBackUrl="~/LogInFolder/StudentLogIn.aspx"/>
                    </div>
                </td>
            </tr>
        </table>
           </center>
    </div>
    </form>
</body>
</html>
