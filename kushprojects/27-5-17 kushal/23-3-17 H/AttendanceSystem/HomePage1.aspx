<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage1.aspx.cs" Inherits="AttendanceSystem.HomePage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<script  src="Bootstrap/js/bootstrap.min.js"></script> 
      <script src="Scripts/JavaScript1.js"></script>
    <style>
        .headerText {
         height:662px;
        color:white;
        font-family:"Times New Roman", Times, serif;
       background-color:#FF8E41;
       opacity:0.8;
       font-size:55px;
       font-family:Verdana;
       font-weight:bolder;
      
        }
       .main{
         background-image:url('/Images/back1.jpg');
            height: 638px;
        }
        .option {
        height:200px;
        width:150px;
        margin-left:50px;
        float:left;
        }
        .link {
        background-color:white;
        border-radius:50%;
        height:50px;
        width:50px;
        padding:10px;
        float:left;
        margin-left:20px
        }
        .LogIn {
            width:130px;
        height:45px;
        text-align:center;
        padding:5px;
        color:white;
        font-size:20px;
        background-color:#4E4E4E;
        border-radius:8px;
        margin-top:0px;
        
        }
            .LogIn:hover {
            background-color:white;
            color:black;
            }
    </style>
</head>
<body >
    <form id="form1" runat="server">
       <div>
               <nav class="navbar navbar-inverse navbar-fixed-top">
                   <div class="container bg-muted">
                       <div class="navbar-header" style="font-size:20px">
                         <a href="#" class="navbar navbar-brand">Student Attendance <small>System</small></a> 
                           <ul class="nav navbar-nav">
                               <li>
                                  <a href="#home"> Home</a>
                               </li>
                                <li>
                                  <a href="#Contact" target="a1"> Contact</a>
                                  
                               </li>
                                <li>
                                  <a href="#About"> About</a>
                                  
                               </li>
                                <li>
                                  
                                  
                               </li>
                                <li>
                                  
                                  
                               </li>
                              
                              </ul>
                           
                                
                           
                       
                  </div>
                        
                     <asp:LinkButton ID="Log" runat="server" Text="Log In" style="font-size:18px; color:white;margin-top:15px;float:right;margin-left:10px" ></asp:LinkButton>
                                 <span id="Span1" class="glyphicon glyphicon-log-in" style="font-size:25px;color:white;float:right;margin-left:30%;margin-top:15px">
                                     
                                  </span> 
                       </div>
                    
               </nav>

     
               </div>
    <div class="main" id="home">   
       <div class="headerText">
          <span style="font-size:45px;padding:50px"> <center>
             <div style="height:200px"></div>
                <h1><span style="font-size:66px" ><b>COLLEGE STUDENT ATTENDANCE SYSTEM</b></span></h1>
           </center>
              </span>
           <center><div><asp:Button ID="LinkPage" runat="server" Text="Log In"  CssClass="LogIn btn" /></div></center>
       </div>
     
   <div class="container-fluid" id="About" style="height:250px;text-align:center;background-color:#FF7E27;color:white">
       <div style="height:50px"></div>
        <center>  <h1 ><b>About The College Student Attendance</b></h1><br />
            Attendance Management System is software developed for daily student attendance inschools, <br />colleges and institutes. If facilitates to access the attendance information of aparticular student in a particular class.<br /> The information is sorted by the operators, whichwill be provided by the teacher for a particular class. <br />This system will also help inevaluating attendance eligibility criteria of a student.
   </div>
        <div style="background-color:#414141;height:60px;color:white;padding-top:5px">
        <center><div style="margin-left:565px" class="link"><asp:Image ID="facebook" runat="server" ImageUrl="~/Images/facebook-solid.png" Height="25px" /> </div>
            <div class="link"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/gmail (1).png" Height="25px" /> </div>
            <div class="link"><asp:Image ID="Image2" runat="server" ImageUrl="~/Images/twitter (1).png" Height="25px" /> </div>
        </center>
        </div> 
        <center> <div class="jumbotron" id="a1" >
           <h1>GET IN TUCH</h1>
            <div style="margin-top:30px;margin-bottom:40px;height:200px">
            <div class="option" style="margin-left:400px">
            <div style="height:80px;width:80px;border-radius:50%;background-color:#414141">
                <span class="glyphicon glyphicon-map-marker" style="height:50px;font-size:50px;color:white;padding:12px"></span>
            </div>
                <h3>Address</h3>
                <br />
                Citty Phagwara
                <br />
                State Punjab
                <br />
                Country India
                </div>
                <div class="option">
            <div style="height:80px;width:80px;border-radius:50%;background-color:#414141">
                <span class="glyphicon glyphicon-earphone" style="height:50px;font-size:50px;color:white;padding:12px"></span>
            </div>
                <h3>Phone</h3>
                <br />
                Citty Phagwara
                <br />
                State Punjab
                <br />
                Country India
                </div>
                <div class="option">
            <div style="height:80px;width:80px;border-radius:50%;background-color:#414141">
                <span class="glyphicon glyphicon-envelope" style="height:50px;font-size:50px;color:white;padding:12px"></span>
            </div>
                <h3>Email</h3>
                <br />
                Citty Phagwara
                <br />
                State Punjab
                <br />
                Country India
                </div>
                </div>
                
        </div>

       

        
     </center>
         <div  id="Contact" style="background-color:#414141;height:100px;color:white;padding-top:5px;clear:both;color:white">
             <center><h4>Application Developers</h4><h5>Kushaldeep Kaul & Jasvir Bains</h5></center>
         </div>
    </form>
</body>
</html>
