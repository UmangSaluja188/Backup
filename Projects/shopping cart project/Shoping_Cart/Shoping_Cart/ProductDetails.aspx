<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Shoping_Cart.ProductDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body 
        {
            background-color:burlywood;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnn1" runat="server"> 
                
                <asp:Image ID="img1" runat="server" ImageUrl="~/Image/Xiaomi-Redmi-Y1-Lite.jpg" Height="100px" Width="100px"/> </a>
                         <br/>   MI Y1 lite <br/>
                              Price: 7000 <br />                           
                        Wifi: Yes<br/>
                        Camera: 12mp
                <br/>
                Ram: 4GB<br /> Rom: 32GB<br />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Book Now</asp:LinkButton>
                <br/>
                 
            </asp:Panel>
            <asp:Panel ID="pnn3" runat="server"> 
                
                <asp:Image ID="img3" runat="server" ImageUrl="Image/godrej-steel-almirah-500x500.jpg" Height="100px" Width="100px"/>    </a>
                         <br/>   Godrage Almirah<br/> Price:40000<br /> Type: Wooden<br /> 
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Book Now</asp:LinkButton>
                <br/>
               
            </asp:Panel>
            <asp:Panel ID="pnn4" runat="server"> 
               
                <asp:Image ID="img4" runat="server" ImageUrl="Image/Large-940x620.jpg" Height="100px" Width="100px"/>    </a>
                         <br/>   LG TV<br /> Price: 35000<br /> Length: 25&quot;<br /> Width: 32&quot;<br />
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Book Now</asp:LinkButton>
                <br/>
                
            </asp:Panel>
        </div>
    </form>
</body>
</html>
