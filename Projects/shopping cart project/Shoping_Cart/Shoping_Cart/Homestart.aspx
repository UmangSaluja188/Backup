<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homestart.aspx.cs" Inherits="Shoping_Cart.Homestart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body 
        {
            background-color:burlywood;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 800px;
            height: 400px;
            margin-right: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1 class="auto-style2"><strong>Shopping Cart</strong><p class="auto-style2">
    <img alt="" class="auto-style3" src="Image/1.jpg" /></p>
        <p class="auto-style2">
    &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">New User</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" >Log In</asp:LinkButton>
        </p>
    
    </form>
    
</body>
</html>
