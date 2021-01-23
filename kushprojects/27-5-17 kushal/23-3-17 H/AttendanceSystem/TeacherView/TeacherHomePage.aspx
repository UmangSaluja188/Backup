<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherView/Site1.Master" AutoEventWireup="true" CodeFile="TeacherHomePage.aspx.cs" Inherits="AttendanceSystem.TeacherView.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #option div {
        height:120px ;
       
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin-top:2%">

        <div class="row">
            <div class="col-sm-12" id="option">
               <h2 class="text-primary"> <span class="glyphicon glyphicon-dashboard" ></span>Teacher <small>DashBoard</small></h2>
                <hr />
                <div class="container-fluid" style="margin-top:5%">
               
                 <div class="col-sm-3 bg-info text-info" style="  border:1px solid #2EB8D1">
                    <span class="glyphicon glyphicon-calendar" style="font-size:40px;margin-top:5px"></span><span style="font-size:25px">Day</span> 
                     <br />
                     <asp:Label ID="Day1" runat="server" Font-Size="20px"></asp:Label> 
                </div>
                 <div class="col-sm-1">

                </div>
                   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <span style="margin-left:30px"><asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer> </span>  

                 <div class="col-sm-3 bg-primary">
                     <span class="glyphicon glyphicon-calendar" style="font-size:40px;margin-top:5px"></span><span style="font-size:25px"> Time</span> <br />
       
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label ID="Time" runat="server"   Font-Size="20px"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
                </div>
                 <div class="col-sm-1">

                </div>
                 <div class="col-sm-3 bg-success text-success"   style="border:1px solid #5B8634;margin-top:0px;">
                     <span class="glyphicon glyphicon-calendar" style="font-size:40px"></span><span style="font-size:25px;margin-top:5px"> Date</span><br />
                     <asp:Label ID="Date1" runat="server"  Font-Size="20px"></asp:Label>  
                </div>
                    </div>
            </div>
        </div>
       
        </div>
   <div style="margin-top:25%;margin-left:10px">
     <hr />
          <h3 class="text-primary"> <span class="glyphicon glyphicon-dashboard " ></span>Today Time <small>Table</small></h3>
       <hr />
       <asp:Panel  ID="DayPanel" runat="server" Visible="false">
       <table>
           <tr>
               <td>
                  <span><b class="text-danger">Select Day</b></span> 
               </td>
               <td>
                   <asp:DropDownList ID="Day2" runat="server" OnSelectedIndexChanged="Day_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                       <asp:ListItem>Select Day...</asp:ListItem>
                           <asp:ListItem>Monday</asp:ListItem>
                            <asp:ListItem>Tuesday</asp:ListItem>
                            <asp:ListItem>Wednesday</asp:ListItem>
                            <asp:ListItem>Thursday</asp:ListItem>
                            <asp:ListItem>Friday</asp:ListItem>
                            <asp:ListItem>Saturday</asp:ListItem>   
                   </asp:DropDownList>
               </td>
           </tr>
       </table>
           </asp:Panel>
        <div class="container-fluid" style="margin-top:5%">
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-10" >
                    <asp:GridView ID="TimeTable" runat="server" CssClass="table table-bordered table-condensed table-hover table-responsive" HeaderStyle-BackColor="#336699" HeaderStyle-ForeColor="White">
                        <EmptyDataTemplate>
                            <div style="width:500px;height:300px">
                <h1 style="padding:50px;color:red">
                        Searching Details are not present..
                </h1>
                    </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                 <div class="col-sm-1"></div>
            </div>
    </div>
       </div>
</asp:Content>
