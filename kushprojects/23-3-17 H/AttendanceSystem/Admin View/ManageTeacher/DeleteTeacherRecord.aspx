<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteTeacherRecord.aspx.cs" Inherits="AttendanceSystem.ManageTeacher.DeleteTeacherRecord"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">


    <div id="div1"  class="container-fluid" style="margin-top:2%">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
    <div id="div2" class="mainDiv">
       <center> <br /><h2  class="text-info">Delete Teacher <small>Record</small></h2></center>
    <br />
        <br />
       
       
      
           <label for="TextBox1" class="form-control">Teacher Id</label>            
             <asp:TextBox ID="TextBox1" runat="server" Height="28px" Width="187px" CssClass="form-control" placeholder="Teacher Id" ReadOnly="true"></asp:TextBox>
            
                <asp:Button ID="Delete" runat="server" Text="Delete" Height="40px"  OnClick="Delete_Click" CssClass="btn" />
            
                 <asp:Button ID="Cancel" runat="server" Text="Cancel" Height="40px"  OnClick="Cancel_Click"  CssClass="btn"/>

           
        
    </div>
    </div>
   
 </asp:Content>
