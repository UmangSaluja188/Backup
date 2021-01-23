<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAttendanceDetails.aspx.cs" Inherits="AttendanceSystem.TeacherView.StudentAttendanceDetails" MasterPageFile="~/TeacherView/Site1.Master" %>

<asp:Content ID="c1" runat ="server" ContentPlaceHolderID="ContentPlaceHolder1" >
    <div class="container-fluid">
               <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/b1.png" Height="50px" Width="50px" PostBackUrl="~/TeacherView/SearchAttendance.aspx"  style="float:left;margin-top:10px" />

    <h1 class="text-primary">Complete Attendance<small> Details</small>  </h1>
        <table>
            <tr>
                <asp:Panel ID="FilterBy" runat="server">
                    <td>
                        Filter By
                    </td>
                    <td>
                        <asp:DropDownList ID="DayNamePane" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DayNamePanel_SelectedIndexChanged" CssClass="form-control">
                            <asp:ListItem>Select..</asp:ListItem>
                            <asp:ListItem>Day</asp:ListItem>
                            <asp:ListItem>Month</asp:ListItem>
                            <asp:ListItem>Date</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </asp:Panel>
                 <asp:Panel ID="Panel1" runat="server" >
                    <td>
                       Select Day
                    </td>
                    <td>
                        <asp:DropDownList ID="DayName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DayName_SelectedIndexChanged" CssClass="form-control">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Monday</asp:ListItem>
                            <asp:ListItem>Tuesday</asp:ListItem>
                            <asp:ListItem>Wednesday</asp:ListItem>
                            <asp:ListItem>Thursday</asp:ListItem>
                            <asp:ListItem>Friday</asp:ListItem>
                            <asp:ListItem>Saturday</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                     <td></td>
                </asp:Panel>
                 <asp:Panel ID="MonthNamePanel" runat="server" Visible="false">
                    <td>
                        Select Month
                    </td>
                    <td>
                        <asp:DropDownList ID="MonthName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="MonthName_SelectedIndexChanged" CssClass="form-control">

                        </asp:DropDownList>
                    </td>
                </asp:Panel>
                 <asp:Panel ID="Date" runat="server" Visible="false">
                    <td>
                        From
                    </td>
                    <td>
                        <asp:TextBox ID="From" runat="server"  TextMode="Date" CssClass="form-control"/>
                   </td>
                        <td>
                            To
                        </td>
                     
                    <td>
                        <asp:TextBox ID="To" runat="server"  TextMode="Date" CssClass="form-control"></asp:TextBox><asp:Button ID="Search2" runat="server" Text="Search" OnClick="Search2_Click" CssClass="btn"/>
                   </td>
                </asp:Panel>
            </tr>
        </table>
    </div>
        <asp:GridView ID="GridView1" runat="server"  OnRowDataBound="GridView1_RowDataBound"  CssClass="table table-bordered table-condensed table-hover table-responsive" HeaderStyle-BackColor="#336699" HeaderStyle-ForeColor="White">
        </asp:GridView>
       
                                         <asp:Label ID="Label2" runat="server" BackColor="#FF3300" BorderColor="#FF3300" ForeColor="White" Height="35px" Width="80px" style="float:right" CssClass="btn"></asp:Label>

                                        <asp:Label ID="Label1" runat="server" BackColor="#0066CC" BorderColor="#FF3300" ForeColor="White" Height="35px" Width="80px" style="float:right" CssClass="btn"></asp:Label>
                                    
                                  
        <asp:Chart ID="Chart1" runat="server">
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
   </asp:Content>