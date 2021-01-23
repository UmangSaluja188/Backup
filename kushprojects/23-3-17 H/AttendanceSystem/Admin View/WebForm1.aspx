<%@ Page Title="" Language="C#" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AttendanceSystem.Admin_View.AdminMasterPage.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="AdminMasterPage/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-3.2.0.js" type="text/javascript"></script>
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
    <script src="AdminMasterPage/Bootstrap/js/bootstrap.min.js"></script>
       <script type="text/javascript">
           $(document).ready(function () {
               $(".div3").click(function () {
                   $(".div4").slideToggle(2000);
                  
               });
               $(".div5").click(function () {
                   $(".div6").slideToggle(2000);

               });

           });
    </script>
    <style>
        .ALLOpt 
 {
    width:180px;  
    height:130px;
    border:1px solid black;
    border-radius:8px;
    margin:15px;
    float:left;
   
}
    .Image1{
        border:0.5px solid black;
        border-radius:4px;
        height:100px
    }
.NEw {
        border:0.5px solid black;
        border-radius:4px;
        margin-top: 20px;
    margin-right: 1px;
}
 .showc {
        height:40px;
        width:70%;
        background-color:#33CCFF;
        color:white;
        }
 .div3{
background-color:#414141;
float:left;
margin:10px;
border:1px solid white;
border-radius:8px;
width:70%;
color:white;
position:relative;

}
     
  .div4 {
            display:none;
            height:300px; width:90%;
           margin-left:100px;        
      position:absolute;
      margin-top:10px;

        
        }   div5 {
            background-color:#414141;
float:left;
margin:10px;
border:1px solid white;
border-radius:8px;
width:70%;
color:white;

        }
       
        .div6 {
             display:none;
            height:200px; width:70%;
            margin:0px;
            padding:0px;
      position:relative;

        }

        .auto-style1 {
            height: 34px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
   <div style="background-color:#EAEAEA;color:#414141"> <h1 style="margin-top:15px">Admin DashBoard</h1></div>
    <div style="min-height:600px;margin-left:20px">
               <a href="ManageTeacher/SearchTeacherRecord.aspx" >     
               <div class="ALLOpt" style="background-color:#33CCFF;border-radius:8px">
                   <center> <asp:Image ID="Im1" runat="server" ImageUrl="~/Images/T2.png" Height="36px" Width="51px" style="margin-top: 25px" CssClass="NEw"  />
                  <h3 style="color:white;margin-top:0px">Manage Teacher Details</h3> </center></div></a> 
              <a href="ManageStudent/SearchStudentDetails2.aspx">
          <div class="ALLOpt" style="background-color:#33CC6F;border-radius:8px">
                    <center><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ST1.png" Height="33px" Width="50px" style="margin-top: 25px" CssClass="NEw" />
                         <h3 style="color:white;margin-top:0px">Manage Student Details</h3>
                    </center>
                </div>
                  </a>
         <a href="Manage Department/SearchDepartment.aspx" >   
                <div class="ALLOpt" style="background-color:#A72158;border-radius:8px"">
                   <center> <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/D2.png"  CssClass="NEw" Height="38px" Width="50px"/>
                        <h3 style="color:white;margin-top:0px">Manage Dept. Details</h3>
                   </center>
                </div> 
              </a>
              <a href="ManageCourse/SearchCourseDetails.aspx" >             
                <div class="ALLOpt" style="background-color:#CC3434;border-radius:8px"">
                   <center> <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/C1.png" Height="38px" Width="50px" CssClass="NEw" />
                        <h3 style="color:white;margin-top:0px">Manage Course Details</h3>
                   </center>
                </div>
                   </a>
                   <a href="ManageStudent/ManageSemester/SearchSemester.aspx" >   
                <div class="ALLOpt" style="background-color:#662DE7;border-radius:8px">
                    <center><asp:Image ID="Image4" runat="server"  ImageUrl="~/Images/SE1.png" Height="38px" Width="50px"  CssClass="NEw"/>
                         <h3 style="color:white;margin-top:0px">Manage Semester Details</h3>
                    </center>
                </div>
                        </a>
                <a href="Manage Subject/SearchSubjectDetails.aspx">   
                <div class="ALLOpt" style="background-color:#F38D27;border-radius:8px"">
                   <center> <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/SU2.png" Height="38px" Width="48px" CssClass="NEw"/>
                        <h3 style="color:white;margin-top:0px">Manage Subject Details</h3>
                   </center>
                </div>    
                     </a>
                     <a href="ManageTeacherTimeTable/SearchTimeTable.aspx" >           
                <div class="ALLOpt" style="background-color:#E166C3;border-radius:8px"">
               <center> <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/TT1.png"  ImageAlign="Middle" Height="43px" Width="50px" CssClass="NEw"/> 
                    <h3 style="color:white;margin-top:0px">Manage Teacher Time Table</h3>
               </center>   
                </div>
                          </a>
                          <a href="ManageHoliday/AddHoliday.aspx" >   
                   <div class="ALLOpt" style="background-color:#F5C208;border-radius:8px"">
                   <center> <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/H1.png" Height="38px" Width="50px"  CssClass="NEw"/>
                        <h3 style="color:white;margin-top:0px">Manage Holiday Details</h3>
                   </center>
                </div>
                               </a>
      <center><div  class="div3">
          
          <table style="height: 38px; width: 186px">
              <tr>
                  <td class="auto-style1"><h3 style="width: 128px; height: 21px">View calender</h3></td>
                  <td class="auto-style1"> <img src="../Images/arrow.png"  style="float:right; width: 47px; height: 32px; margin-top: 3px; margin-bottom: 0px;"/></td>

              </tr>
              </table>
          
       
             
         <div class="div4">
          <asp:Calendar ID="c1" runat="server"></asp:Calendar>
       </div>
          </div>
          <div>

          </div>
        </center>
      </div>
      
    </div>


     
</asp:Content>
