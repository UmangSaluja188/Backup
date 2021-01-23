<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInPage.aspx.cs" Inherits="AttendanceSystem.LogInFolder.LogInPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link href="../Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
    <script src="../Scripts/1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid" style="margin:200px;border:1px solid black">
    <h1>Helllo</h1>
        <table>
            <tr>
                <td><asp:TextBox ID="UserId" runat="server"></asp:TextBox></td>
                <td> <asp:TextBox  ID="Password" runat="server"></asp:TextBox></td>
            </tr>
        </table>

       
    </div>
    </form>
</body>
</html>
