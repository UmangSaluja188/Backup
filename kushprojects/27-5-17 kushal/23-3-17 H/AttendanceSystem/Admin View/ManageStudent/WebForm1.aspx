<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AttendanceSystem.ManageStudent.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function Onload() {
            alert("Name Boby Bangar Father Name=Bittu Fail");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        PSEB 5th Class Result<br />
    
    </div>
        <div style="margin:400px">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="Onload()" />
            </div>
    </form>
</body>
</html>
