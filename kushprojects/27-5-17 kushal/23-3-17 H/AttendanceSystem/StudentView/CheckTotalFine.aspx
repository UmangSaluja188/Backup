<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckTotalFine.aspx.cs" Inherits="AttendanceSystem.StudentView.CheckTotalFine" MasterPageFile="~/StudentView/Site1.Master" %>
<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
             <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/b1.png" Height="50px" Width="50px" PostBackUrl="~/StudentView/ViewTimeTable.aspx"  style="float:left" />
 <h1>Check Fine <small>Details</small></h1>
        <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered table-condensed table-hover table-responsive"  HeaderStyle-BackColor="#336699" HeaderStyle-ForeColor="White" ></asp:GridView>
    </div>
 
    <div class="container-fluid">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-4"></div>
               <div class="col-sm-4 bg-danger text-danger" style="height:120px;margin-top:50px;border:1px solid #F09C9C;">
                   <center><h3>Total Fine</h3>
                       <h4><asp:Label ID="TotalFine" runat="server"></asp:Label></h4>
                   </center>
                
                </div>
                  <div class="col-sm-4"></div>
               

            </div>
        </div>
    </div>
    </asp:Content>