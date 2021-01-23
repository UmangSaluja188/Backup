<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAttendanceNew.aspx.cs" Inherits="AttendanceSystem.TeacherView.EditAttendanceNew" MasterPageFile="~/TeacherView/Site1.Master" %>

<asp:Content ID="C1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container-fluid" style="margin-top:4%">
               <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/b1.png" Height="50px" Width="50px" PostBackUrl="~/TeacherView/TeacherHomePage.aspx?Value=Today"  style="float:left;margin-top:10px" />
 <h1>Edit Student <small>Attendance</small></h1>
          <table>
            <tr>
                <td>
                        Select Course
                    </td>
                 <asp:Panel ID="Subject1" runat="server" >
                <td>
                   
                    Select Subject
                        
                </td>
                    </asp:Panel>
                 <asp:Panel ID="Date1" runat="server" >
                    <td> 
                        Select Date

                    </td>
                     </asp:Panel>
                 <asp:Panel ID="Time1" runat="server" >
                   <td>
                       Select Time
                   </td>
                     </asp:Panel>
                 <asp:Panel ID="F1" runat="server" >
                  <td>Filter By</td> </asp:Panel>
               
                    </tr>
            <tr>
                 <asp:Panel ID="Course2" runat="server">
                  <td>
                    <asp:DropDownList ID="CourseName" runat="server" OnSelectedIndexChanged="CourseName_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" ></asp:DropDownList>
                    </td>
                     </asp:Panel>
                 <asp:Panel ID="Subject2" runat="server" >
                <td>
                    
                    <asp:DropDownList ID="SubjectName" runat="server" OnSelectedIndexChanged="SubjectName_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">

                       
                </asp:DropDownList>
                        
           </td>
                </asp:Panel>
                 <asp:Panel ID="Date2" runat="server" >
             <td>

                 <asp:TextBox ID="Date" runat="server" TextMode="Date" OnTextChanged="Date_TextChanged" AutoPostBack="true" CssClass="form-control" ></asp:TextBox>
    </td>
                     </asp:Panel>
                 <asp:Panel ID="Time2" runat="server">
            <td>
                <asp:DropDownList ID="TimePeriod" runat="server"  OnSelectedIndexChanged="Time_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
            </td>
                     </asp:Panel>
                 <asp:Panel ID="F2" runat="server" >
                <td>
                    <asp:DropDownList ID="FilterBy" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="FilterBy_SelectedIndexChanged" Enabled="false" CssClass="form-control">
                        <asp:ListItem>Select..</asp:ListItem>
                        <asp:ListItem>Student Id</asp:ListItem>
                        <asp:ListItem>Student Name</asp:ListItem>
                    </asp:DropDownList>
                 </td>
       </asp:Panel>
   
                <asp:Panel ID="StudentIdPanel" runat="server"   Visible="false" >
                   
                <td>
                   <asp:TextBox ID="StudentId" runat="server" CssClass="form-control" Width="100px" placeholder="StudentId"></asp:TextBox><asp:Button ID="SearchBSId" runat="server" OnClick="SearchBSId_Click" Text="Search" CssClass="btn-info"  />
                </td>
                    <td></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="StudentId"></asp:RequiredFieldValidator></td>
                </asp:Panel>
                <asp:Panel ID="StudentNamePanel" runat="server" Visible="false"> 
                   
                
                <td>
                    <asp:TextBox ID="StudentName" runat="server" CssClass="form-control" Width="100px" placeholder="StudentName"></asp:TextBox><asp:Button ID="SearchByName" runat="server" OnClick="SearchByName_Click"  Text="Search" CssClass="btn-info"/>
                </td>
                    <td><asp:RequiredFieldValidator ID="R1" runat="server" ErrorMessage="*Required" ControlToValidate="StudentName"></asp:RequiredFieldValidator></td>
                </asp:Panel>
              
                 </tr>
        </table>
    </div>
        <div class="pre-scrollable" >
            <asp:ScriptManager ID="d1" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel12" runat="server">
             <ContentTemplate>
            <asp:GridView ID="GridView2" runat="server" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound1"  CssClass="table table-bordered table-condensed table-hover table-responsive" HeaderStyle-BackColor="#336699" HeaderStyle-ForeColor="White"  style="margin-top:0px">
 
            <Columns>
                
              <asp:TemplateField>
                  
                  <ItemTemplate>
                     <asp:CheckBox ID="CheckBox2" runat="server"  OnCheckedChanged="CheckBox2_CheckedChanged" AutoPostBack="true"  Text="Present"  CssClass="form-control" Height="40px" />
                   </ItemTemplate>
                 
              </asp:TemplateField>

            </Columns>
                <EmptyDataTemplate>
                <div style="width:500px;height:300px">
                <h1 style="padding:50px;color:red">
                        Searching Details are not present in the database.....
                </h1>
                    </div>
            </EmptyDataTemplate>
        </asp:GridView>



</div>


            
               
       </div>
 
          </div>
                  
        </ContentTemplate>     
            </asp:UpdatePanel>
  </asp:Content>
