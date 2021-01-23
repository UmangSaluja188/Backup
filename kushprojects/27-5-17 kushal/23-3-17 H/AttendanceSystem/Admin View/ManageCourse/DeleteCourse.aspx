<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCourse.aspx.cs" Inherits="AttendanceSystem.ManageCourse.Delete"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container-fluid" style="margin-top:20px">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
    <h1>
        Delete Course <small>Details</small>
    </h1>
       
                    <label for="SearchTextbox"  class="form-control">Course Id</label> 

                    <asp:TextBox ID="SearchTextBox" runat="server" CssClass="form-control" placeholder="Course Id" Enabled="false" ></asp:TextBox>
             
                    <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="Delete_Click"  CssClass="btn"/>
                    <asp:Button ID="Button1" runat="server"  PostBackUrl="~/Admin View/ManageCourse/SearchCourseDetails.aspx" Text="Cancel" CssClass="btn" />
             
    </div>

   </asp:Content>