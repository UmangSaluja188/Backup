<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="TakeAttend.aspx.cs" Inherits="AttendanceSystem.TeacherView.TakeAttend" MasterPageFile="~/TeacherView/Site1.Master" %>
<asp:Content ID="c1" runat="server" ContentPlaceHolderID="head">
    <style>
        body {
            background-color:#F3F3F3;

        }
        .option {
            width:150px;
            height:100px;
            border:2px solid black;
            background-color:#57C3F6;
            border-radius:5px;
        }
        .Time {
            width:150px;
            height:100px;
            border:2px solid black;
            border-radius:48%;
            background-color:#A78BBE;
        }
        .CenterText {
            margin:50px;
            font-size:25px;
            margin-top:100px;
            color:white;

        }
        .lactTime {
            border:2px solid black;
            background-color:#57C3F6;
            height:70px;
            width:150px;
            font-size:25px;
            color:white;
        }
        #Option  div{
        height:100px;
        text-align:center;
       
        }
        
    </style>
    </asp:Content>
   <asp:Content ID="c2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

     

       <div class="container-fluid">


             <div class="container-fluid"><asp:Label ID="Error1" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label></div>
                   <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/b1.png" Height="50px" Width="50px" PostBackUrl="~/TeacherView/TeacherHomePage.aspx?Value=Today"  style="float:left;margin-top:10px" />
   <h1>Take  Student <small>Attendance</small></h1>

       <hr  style="height:3px"/>
             <div class="container-fluid" style="margin-top:3%">
                 
          <div class="row" id="Option" style="margin-top:20px">
             
               <div class="col-sm-2 bg-success text-success" style="border:1px solid #5B8634;margin-left:10px">
                 <center><span style="font-size:18px">Class</span></center>
                   <asp:Label ID="Class1" runat="server" Font-Size="17px"></asp:Label>
              </div>
               <div class="col-sm-2 bg-warning text-warning" style="border:1px solid #8E6541;margin-left:10px">
                  <span style="font-size:15px">Subject Name</span>
                   <br />
                   <asp:Label ID="Sub" runat="server" Font-Size="17px"></asp:Label>
              </div>
               <div class="col-sm-3 bg-primary" style="border:1px solid black;margin-left:10px">
                      <center><span style="font-size:22px">Time</span></center>

                     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <span style="margin-left:30px"><asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer> </span>  
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label ID="Time" runat="server"  Font-Size="17px"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>

              </div>
               <div class="col-sm-2 bg-warning  text-warning" style="border:1px solid #8E6541;margin-left:10px;">
                      <center><span style="font-size:18px">Date</span></center>
<asp:Label ID="Date" runat="server"></asp:Label>
              </div>
               <div class="col-sm-2 bg-success text-success" style="border:1px solid #5B8634;margin-left:10px">
                      <center><span style="font-size:18px">Day</span></center>
                   <asp:Label ID="Day" runat="server"></asp:Label>
              </div>
              

          </div>
      
         
            <asp:Label ID="Timeee" runat="server"></asp:Label>

         
          
                 </div>

       <div class="pre-scrollable" >

         <asp:UpdatePanel ID="UpdatePanel12" runat="server">
             <ContentTemplate>
            <asp:GridView ID="GridView2" runat="server" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound"  CssClass="table table-bordered table-condensed table-hover table-responsive" HeaderStyle-BackColor="#336699" HeaderStyle-ForeColor="White"  style="margin-top:0px">
 
            <Columns>
                
              <asp:TemplateField>
                  
                  <ItemTemplate>
                     <asp:CheckBox ID="CheckBox2" runat="server"  OnCheckedChanged="CheckBox1_CheckedChanged1" AutoPostBack="true"  Text="Present"  CssClass="form-control" Height="40px" />
                   </ItemTemplate>
                  <EditItemTemplate>
                       
                  </EditItemTemplate>
              </asp:TemplateField>

            </Columns>
               
        </asp:GridView>






            
               
       </div>
 
          </div>
                  
        </ContentTemplate>     
            
             </asp:UpdatePanel>  
          <asp:UpdatePanel ID="U2" runat="server">
              <ContentTemplate>
                    <div class="row" style="margin:35px">
          
                    <div class=" col-sm-3 bg-primary"  style="height:50px;text-align:center;font-size:18px;border-radius:8px">
                        <span>Total Students</span>
                        <br />
                        <span  ><asp:Label ID="TotalStudents" runat="server"></asp:Label></span>
                    </div>
                <div class="col-sm-1"></div>
                     <div  class=" col-sm-3 bg-primary"  style="height:50px;text-align:center;font-size:18px;border-radius:8px"><span> Total Lactures</span>
                         <br />
                         <span><asp:Label ID="TotalLactures" runat="server"></asp:Label></span>
                     </div>
               
                     <div class="col-sm-1"></div>
                     <div  class=" col-sm-3 bg-primary"  style="height:50px;text-align:center;font-size:17px;font-size:18px;border-radius:8px"><span>Head Count</span>
                         <br />
                         <span><asp:Label ID="HeadCount" runat="server"></asp:Label></span>
                     </div>
                        <asp:Label ID="l3" runat="server" Text="Hello"></asp:Label>
           </div>   
         </ContentTemplate>
          </asp:UpdatePanel>
           
        <asp:Label ID="Label4" runat="server"></asp:Label>
        
       <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox><asp:Button ID="Search" runat="server" OnClick=" Button1_Click"  Visible="false"/>
  
           

           
            </asp:Content>
