<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SerachAttendanceBySTudent.aspx.cs" Inherits="AttendanceSystem.StudentView.SerachAttendanceBySTudent" MasterPageFile="~/StudentView/Site1.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div style="margin-top:10px">
       
      <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/b1.png" Height="50px" Width="50px" PostBackUrl="~/StudentView/ViewTimeTable.aspx"  style="float:left" />
  <h1>View Attendance</h1>
        <table>
            <tr>
                
                <td>
                  <asp:Label ID="Error" runat="server" Visible="false"></asp:Label>
                </td>
            <asp:Panel ID="SubjectNamePanel" runat="server" Visible="false">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <td>
                        Select Subject Name
                    </td>
                    <td>
                        <asp:DropDownList ID="SubjectName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SubjectName_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                    </td>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </asp:Panel> T
                 </tr>
        </table>
       <div class="pre-scrollable">
       <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered table-condensed table-hover table-responsive"  HeaderStyle-BackColor="#336699" HeaderStyle-ForeColor="White">
           <Columns>
              <asp:HyperLinkField  DataNavigateUrlFormatString="~/StudentView/SearchDetAtte.aspx?StudentId={0}&SubjectName={1}" DataNavigateUrlFields="StudentId,SubjectName" Text="Details" />
        
                     </Columns>
       </asp:GridView>
           </div>
    </div>
    <hr />
    <div class="container-fluid">
      <center>  <h2 class="text-primary"><span class="glyphicon glyphicon-stats"></span> Attendance <small>Chart</small></h2></center>
        <asp:Chart ID="Chart1" runat="server" Width="740px" OnLoad="Chart1_Load" CssClass="bg-warning" Height="259px" >
            <Series>
                <asp:Series Name="Series1" ChartType="StackedBar"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                
            </ChartAreas>
        </asp:Chart>
        </div>
    </asp:Content>