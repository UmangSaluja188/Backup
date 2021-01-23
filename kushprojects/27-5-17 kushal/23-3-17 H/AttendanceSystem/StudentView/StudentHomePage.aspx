<%@ Page Title="" Language="C#" MasterPageFile="~/StudentView/Site1.Master" AutoEventWireup="true" CodeBehind="StudentHomePage.aspx.cs" Inherits="AttendanceSystem.StudentView.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #opt div {
      width:22%;
      margin:8px;
      height:100px

             }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
               <h3 class="text-primary"> <span class="glyphicon glyphicon-dashboard" ></span>Student<small>DashBoard</small></h3>
        <hr />
    <div class="row" id="opt" style="margin-top:10px">
        <div class="col-sm-2 bg-success text-success" style=" border:1px solid #5B8634;">

            <center><span style="font-size:18px;text-align:center">Total Lactures</span></center>
             <asp:Label ID="TotalLac" runat="server"></asp:Label>
        </div>
 
        <div class="col-sm-2 bg-warning text-warning" style="border:1px solid #8E6541">
             <center><span style="font-size:18px;text-align:center">Attend Lactures</span></center>
             <asp:Label ID="Attend" runat="server"></asp:Label>
        </div>
  
        <div class="col-sm-2 bg-danger text-danger" style="border:1px solid #F09C9C;">
 <center> <span style="font-size:18px;text-align:center">Percentage</span></center>
             <asp:Label ID="Percentage" runat="server"></asp:Label>

        </div>
        <div class="col-sm-2 bg-info text-info" style="border:1px solid #2EB8D1">
            <center> <span style="font-size:18px;text-align:center">Total File</span></center>
             <asp:Label ID="Fine" runat="server"></asp:Label>
        </div>
    </div>
      
        <hr />
    <div class="container-fluid" >
     <h3 class="text-primary"> <span class="glyphicon glyphicon-calendar" ></span>Today Time<small>Table</small></h3>

    </div>
        </div>
    
</asp:Content>
