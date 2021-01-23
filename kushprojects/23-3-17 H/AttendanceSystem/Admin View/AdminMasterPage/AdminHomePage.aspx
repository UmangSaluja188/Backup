<%@ Page Title="" Language="C#" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" AutoEventWireup="true"  CodeBehind="AdminHomePage.aspx.cs" Inherits="AttendanceSystem.Admin_View.AdminMasterPage.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       #option1{
       height:120px;
           top:35px;
           left: -15px;
           border:1px solid #2EB8D1
       }
          #option2{
       height:120px;
           
           left: -15px;
            top:35px;
             border:1px solid #8E6541;
       }
             #option3{
       height:120px;
         
           left: -15px;
            top:35px;
            border:1px solid #5B8634;
       }
                #option4{
       height:120px;
          
           left: -15px;
           top:35px
       }
                .glyphicon {
    font-size: 40px;
    text-align:center;
   
    margin-top:10px;
}
       
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin-top:30px">
       <h2 ><span class="glyphicon glyphicon-dashboard " style="font-size:30px" ></span>Admin <small>DashBoard</small></h2>
       
        <hr  style="height:3px;width:90%"/>
        <div class="row-content" >
            <div class="col-sm-2 bg-info text-info" id="option1" >
              <center> <span class="glyphicon glyphicon-user"></span>
                <h5 style="font-size:15px">Total Students</h5>
                
                <asp:Label ID="totalStudents" runat="server"></asp:Label>
                  </center>
            </div>
             <div class="col-sm-1">
               
            </div>
            <div class="col-sm-2 bg-warning text-warning" id="option2">
                <center> 
                <span class="glyphicon glyphicon-user"></span>
                <h5 style="font-size:15px">Present Students</h5>
                <asp:Label ID="Present" runat="server"></asp:Label>
                    </center>
            </div>
             <div class="col-sm-1">
              
            </div>
              <div class="col-sm-2 bg-success text-success" id="option3">
                  <center> 
                    <span class="glyphicon glyphicon-user"></span>
                <h5 style="font-size:15px">Percentage</h5>
                <asp:Label ID="Percentage" runat="server"></asp:Label>
                      </center>
               </div>
              <div class="col-sm-1">
              
            </div>
             <div class="  col-sm-2 bg-primary text-primary" id="option4">
                  <center> 
                  <span class="glyphicon glyphicon-user"></span>
                <h5 style="font-size:15px">Leave  </h5>
                <asp:Label ID="Leave" runat="server"></asp:Label>
                      </center>
            </div>
             
            
                        </div>
         </div>
    <div class="row-content"  style="margin-top:8%;margin-left:0px">
         <hr  style="height:2px;width:90%"/>
      <h2 class="text-primary"><span class="glyphicon glyphicon-stats"></span> Attendance <small>Charts</small></h2><br />
        <div class="col-sm-8" style="height:auto">
           <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Width="730px" >
            <Series>
                <asp:Series Name="Series1" ChartType="StackedBar" ></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
                    </div>
           
        
        
           
        </div>
        <div class="col-sm-2 "></div>
          
          
       

</asp:Content>
