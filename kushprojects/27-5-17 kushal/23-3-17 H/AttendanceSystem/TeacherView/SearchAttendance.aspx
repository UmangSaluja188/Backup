<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchAttendance.aspx.cs" Inherits="AttendanceSystem.TeacherView.SearchAttendance" Debug="false" MasterPageFile="~/TeacherView/Site1.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
      <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/b1.png" Height="50px" Width="50px" PostBackUrl="~/TeacherView/TeacherHomePage.aspx?Value=Today"  style="float:left;margin-top:10px" />

    <h1 class="text-danger">
        Student Attendance Details <small> Panel</small>

    </h1>
       
        <table>
            <tr>
                <td>
                        Select Course
                    </td>
                <td>
                    Select Subject
                </td>
                    
                    <td> 
                        Filter By

                    </td><td></td>
                   
                    </tr>
            <tr>
                  <td>
                    <asp:DropDownList ID="CourseName" runat="server" OnSelectedIndexChanged="CourseName_SelectedIndexChanged1" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                    </td>
                <td>
                    
                    <asp:DropDownList ID="SubjectName" runat="server" OnSelectedIndexChanged="SubjectName_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">

                       
                </asp:DropDownList>
                        
           </td>
                
              
   <asp:Label ID="l" runat="server"></asp:Label>
    <td> <asp:DropDownList ID="FilterBy" runat="server" OnSelectedIndexChanged="FilterBy_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
              <asp:ListItem>Select..</asp:ListItem>
              <asp:ListItem >Student Id</asp:ListItem>
              <asp:ListItem>Student Name</asp:ListItem>
        </asp:DropDownList></td>
         
    
                <asp:Panel ID="StudentIdPanel" runat="server"   Visible="false" >
                    <td>
                    Student Id
                </td>
                <td>
                   <asp:TextBox ID="StudentId" runat="server" CssClass="form-control"></asp:TextBox><asp:Button ID="SearchBSId" runat="server" OnClick="SearchBSId_Click" Text="Search" CssClass="btn-info"  />
                </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="StudentId"></asp:RequiredFieldValidator></td>
                </asp:Panel>
                <asp:Panel ID="StudentNamePanel" runat="server" Visible="false"> <td>
                    Student Name
                </td>
                <td>
                    <asp:TextBox ID="StudentName" runat="server" CssClass="form-control"></asp:TextBox><asp:Button ID="SearchByName" runat="server" OnClick="SearchByName_Click"  Text="Search" CssClass="btn-info"/>
                </td>
                    <td><asp:RequiredFieldValidator ID="R1" runat="server" ErrorMessage="*Required" ControlToValidate="StudentName"></asp:RequiredFieldValidator></td>
                </asp:Panel>
              
                 </tr>
        </table>
        <div class="container-fluid pre-scrollable">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         
                                       <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered table-condensed table-hover table-responsive" HeaderStyle-BackColor="#336699" HeaderStyle-ForeColor="White">
            <Columns>
              <asp:HyperLinkField  DataNavigateUrlFormatString="~/TeacherView/StudentAttendanceDetails.aspx?TeacherId={0}&SubjectName={1}&AttendLactures={2}&TotalFine={3}" Text="Details" DataNavigateUrlFields="StudentId,SubjectName,AttendLactures,TotalFine" />
            
            </Columns>
            <EmptyDataTemplate>
                       <div style="width:500px;height:300px">
                <h1 style="padding:50px;color:red">
                        Searching Details are not present..
                </h1>
                    </div>
            </EmptyDataTemplate>
        </asp:GridView>
                            

 </ContentTemplate>
                        </asp:UpdatePanel>
            </div>
    </div>
  </asp:Content>