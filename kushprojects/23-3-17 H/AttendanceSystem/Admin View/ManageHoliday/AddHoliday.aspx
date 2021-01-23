<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHoliday.aspx.cs" Inherits="AttendanceSystem.ManageHoliday.AddHoliday"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>


    <asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
    <div>
        <h1>Add Holiday Details</h1>
        <table>
            <tr>
                <td class="auto-style1">
                 Holiday No</td>
                 <td><asp:TextBox ID="HolidayN" runat="server" Width="78px"></asp:TextBox>                </td>



                
            </tr>
            <tr>
                <td class="auto-style1">
                    Holiday Type
                </td>
                <td>
                    <asp:DropDownList ID="HolidayType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="HolidayType_SelectedIndexChanged" style="margin-left: 0px">
                        <asp:ListItem>Select..</asp:ListItem>
                         <asp:ListItem>Half Day</asp:ListItem>
                         <asp:ListItem>Full Day</asp:ListItem>
                         <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <asp:Panel ID="MultiHolidaysPanel" runat="server" Visible="false">
                <tr>
                <td>
                    Holiday Date
                </td>
                
            
                  <td>
                    From
               
               <asp:TextBox ID="From" runat="server" TextMode="Date"></asp:TextBox></td> 
          <td>To
                
                    <asp:TextBox ID="To" runat="server" TextMode="Date"></asp:TextBox>
                </td>
                  </tr>
            </asp:Panel>
            <asp:Panel ID="HalfHolidayPanel" runat="server" Visible="false">
                <tr>
                    <td>
                       Holiday Date
                    
                 </td>
               
                
                <td>
                    <asp:TextBox ID="HalfHolidayDate" runat="server"></asp:TextBox>
                </td>
                <td>
                    Time
                
               
                    <asp:TextBox ID="Time" runat="server" TextMode="Time"></asp:TextBox>

                </td>
                </tr>
            </asp:Panel>   
            <asp:Panel ID="FullDayHolidayPanel" runat="server" Visible="false">
                <tr>
                    <td>
                        Date
                    </td>
                    <td>
                        <asp:TextBox ID="FullHolidayDate" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
            </asp:Panel>        
             <tr>
                <td class="auto-style1">
                    Event
                </td>
                <td>
                    <asp:TextBox ID="Event" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click"  /></td>
            
            <td>
                <asp:Button ID="Cancel" runat="server" Text="Cancel"  OnClick="Cancel_Click"/>
            </td>
                </tr>
        </table>

       
    </div>
    </div>
   
        <asp:Button ID="Link" runat="server"  PostBackUrl="~/link.aspx" Text="Back To Link Page" />

</asp:Content>
