<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TakeLeave.aspx.cs" Inherits="AttendanceSystem.StudentView.TakeLeave" MasterPageFile="~/StudentView/Site1.Master" %>
<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
         
    <div class="container-fluid" >

        <div>
    <h1 class="text-primary">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/b1.png" Height="50px" Width="50px" PostBackUrl="~/StudentView/ViewTimeTable.aspx"  style="float:left" />
    Take <small>Leave </small>
    </h1>
           
        <div>
       <div>
   
        <table class="text-danger">
            <tr>
               <td>&nbsp;&nbsp;&nbsp;&nbsp; Leave Starting Date
               
                       <asp:TextBox ID="From" runat="server" placeholder="Select Leave Starting Date" CssClass="form-control"></asp:TextBox>
                </td>
                
                <td>&nbsp;&nbsp;&nbsp;&nbsp; Leave Ending Date
                
                     <asp:TextBox ID="To" runat="server" placeholder="Select Leave Ending Date"  CssClass="form-control"></asp:TextBox>
                </td>

            </tr>

            <tr>
                
                <td><asp:Calendar ID="Cal" runat="server" OnSelectionChanged="Cal_SelectionChanged" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="250px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333"  />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                    <TodayDayStyle BackColor="#CCCC99" />
                    </asp:Calendar></td>   
             
                <td><asp:Calendar ID="Calendar1" runat="server" style="margin-left: 19px" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="250px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                    <TodayDayStyle BackColor="#CCCC99" />
                    </asp:Calendar></td>    
     </tr>
            <tr>
                
                <td>
                    Startig Time <asp:DropDownList ID="StartingTime1" runat="server" CssClass="form-control"></asp:DropDownList>

                </td>
                         
                <td>
                    Ending Time   <asp:DropDownList ID="EndingTime1" runat="server" CssClass="form-control"></asp:DropDownList>

                </td>
            </tr>
            </table>
                  
                
                 <span>  Reason  <asp:TextBox ID="Reason" runat="server" TextMode="MultiLine" Width="475px" Height="57px" CssClass="form-control"></asp:TextBox></span>
                

            
            
                    <br />
                

            
            
                    <asp:Button ID="Send" runat="server"  Text="Send Leave Application" Width="234px" OnClick="Send_Click" style="margin-left:170px" CssClass="btn"/>
             

        
           <br />
           <br />
             

        
           </div>
    </div>
              
 
 
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
</asp:Content>
