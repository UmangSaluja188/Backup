<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewTimeTable.aspx.cs" Inherits="AttendanceSystem.StudentView.ViewTimeTable" MasterPageFile="~/StudentView/Site1.Master" %>
<asp:Content ID="c2" runat="server" ContentPlaceHolderID="head">
      <style>
        #opt div {
      width:22%;
      margin:8px;
      height:100px

             }

    </style>
</asp:Content>
<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   
    
     <div class="container-fluid">
               <h3 class="text-primary"> <span class="glyphicon glyphicon-dashboard" ></span>Student<small> DashBoard</small></h3>
        <hr />
    <div class="row" id="opt" style="margin-top:10px">
        <div class="col-sm-2 bg-success text-success" style=" border:1px solid #5B8634;">

            <center><span style="font-size:20px;text-align:center">Total Lactures</span></center>
             <center><h3><asp:Label ID="TotalLac" runat="server"></asp:Label></h3></center>
        </div>
 
        <div class="col-sm-2 bg-warning text-warning" style="border:1px solid #8E6541">
             <center><span style="font-size:20px;text-align:center">Attend Lactures</span></center>
             <center><h3><asp:Label ID="Attend" runat="server"></asp:Label></h3></center>
        </div>
  
        <div class="col-sm-2 bg-danger text-danger" style="border:1px solid #F09C9C;">
 <center> <span style="font-size:20px;text-align:center">Percentage</span></center>
            <center> <h3> <asp:Label ID="Percentage" runat="server"></asp:Label></h3></center>

        </div>
        <div class="col-sm-2 bg-info text-info" style="border:1px solid #2EB8D1">
           <center><span style="font-size:20px;text-align:center">Total Fine</span></center>
           <center> <h3><asp:Label ID="Fine" runat="server"></asp:Label></h3> </center>
        </div>
    </div>
      
        <hr />
         <asp:Label ID="NoticeBoard1" runat="server" CssClass="bg-info text-danger"  style="height:25px;font-size:15px;padding:5px;border:0.1px solid skyblue;border-radius:2px"></asp:Label>
         <asp:Label ID="Error" runat="server" ></asp:Label>
    <div class="container-fluid" >
                       <h3 class="text-primary"> <span class="glyphicon glyphicon-calendar" ></span>Today Time<small>Table</small></h3>
          <table>
            <tr>
                 <asp:Panel ID="Panel1" runat="server" Visible="false">
                <td>
                 <span class="text-danger" style="font-size:18px">Select Day</span> 
                </td>
                <td>
                 
                    
                     <asp:DropDownList ID="Day" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Day_SelectedIndexChanged" CssClass="form-control" >
                           <asp:ListItem>Select Day...</asp:ListItem>
                           <asp:ListItem>Monday</asp:ListItem>
                            <asp:ListItem>Tuesday</asp:ListItem>
                            <asp:ListItem>Wednesday</asp:ListItem>
                            <asp:ListItem>Thursday</asp:ListItem>
                            <asp:ListItem>Friday</asp:ListItem>
                            <asp:ListItem>Saturday</asp:ListItem>   
                           </asp:DropDownList>
                    
                </td>
                        </asp:Panel>
            </tr>
        </table>
        <div class="pre-scrollable">
        <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered table-condensed table-hover table-responsive  text-info"  HeaderStyle-BackColor="#336699" HeaderStyle-ForeColor="White" >

        </asp:GridView>
            </div>
    </div>



    </div>
        </div>
    
    
    
     

  </asp:Content>
