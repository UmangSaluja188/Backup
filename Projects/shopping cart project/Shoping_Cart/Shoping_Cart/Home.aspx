<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Shoping_Cart.Home" %>

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
            <center>
            <table border="0">
                <tr>
                    <td> Select Category </td>
                    <td colspan="3"> <asp:DropDownList ID="dl1" runat="server" OnSelectedIndexChanged="dl1_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>Mobile</asp:ListItem>
                        <asp:ListItem>Furniture</asp:ListItem>
                        <asp:ListItem>Television</asp:ListItem>
                        </asp:DropDownList> 

                    </td>
                </tr>
                <tr>
                    <td> 
                        <asp:Panel ID="pn1" runat="server">
                            <asp:Image ID="img1" runat="server" ImageUrl="~/Image/Xiaomi-Redmi-Y1-Lite.jpg" Height="100px" Width="100px"/> 
                           <br/> MI:Y1 lite <br/>
                              Price:7000;
                             <asp:LinkButton ID="btn1" runat="server" Text="View Detail" OnClick="btn1_Click">  </asp:LinkButton>
                        </asp:Panel>
                    </td>
          
                    <td>
                        <asp:Panel ID="pn3" runat="server"> 
                            <asp:Image ID="img3" runat="server" ImageUrl="~/Image/godrej-steel-almirah-500x500.jpg" Height="100px" Width="100px"/> 
                           <br/>  Almirah: Gordrage<br/> Price:40000;
                            <asp:LinkButton ID="btn3" runat="server" Text="View Detail" OnClick="btn3_Click">  </asp:LinkButton>
                        </asp:Panel>
                    </td>
                  </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pn4" runat="server"> 
                            <asp:Image ID="img4" runat="server" ImageUrl="~/Image/Large-940x620.jpg" Height="100px" Width="100px"/> 
                            <br/> LED: LG<br/>
                             Price: 35000;
                            <asp:LinkButton ID="btn4" runat="server" Text="View Detail" OnClick="btn4_Click">  </asp:LinkButton>
                        </asp:Panel>
                    </td>
                </tr>
            </table>       
            </center>
        </div>
    </form>
    
</body>
</html>