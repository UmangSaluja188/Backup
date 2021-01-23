<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddTimeTable1.aspx.cs" Inherits="AttendanceSystem.ManageTeacherTimeTable.WebForm1" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>
<asp:Content ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="C2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="container-fluid" style="margin-top:4%">
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
        <h1><asp:Label ID="Head" runat="server">Add Teacher Time Table</asp:Label>
             <small>Details</small></h1>
        <asp:Label ID="l11" runat="server"></asp:Label>
        <table>
            <tr>
                <td>
                    Select Department</td>
                <td>
                    <asp:DropDownList ID="Department" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Department_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
                   <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Department"
                ErrorMessage="Value Required!" InitialValue="Select Department..."  Display="Dynamic" ></asp:RequiredFieldValidator>
                 </td>

            </tr>
            <tr>
                <td>

                </td>
            </tr>
           
            <tr>
                <td>
                    Course 
                </td>
                <td>
                    <asp:DropDownList ID="Course" runat="server"  OnSelectedIndexChanged="Course_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control"></asp:DropDownList>
                </td>
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Course"
                ErrorMessage="Value Required!" InitialValue="Select Course..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>

            </tr>
            <tr>
                <td>Semester</td>
                <td>
                    <asp:DropDownList ID="Semester" runat="server" OnSelectedIndexChanged="Semester_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control"></asp:DropDownList></td>
                   <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Semester"
                ErrorMessage="Value Required!" InitialValue="Select Semester..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>

            </tr>
             <tr>
                <td>
                    Subjects
                </td>
                <td>
                    <asp:DropDownList ID="Subjects" runat="server" OnSelectedIndexChanged="Subjects_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>

                    <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Subjects"
                ErrorMessage="Value Required!" InitialValue="Select Subject..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>

            </tr>
             <tr>
                <td>
                    TeacherId
                </td>
                <td class="auto-style1">
                   <asp:TextBox ID="TeacherId" runat="server"  TextMode="Number"  CssClass="form-control" placeholder="Teacher Id"></asp:TextBox>

                </td>
                    <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TeacherId"
                ErrorMessage="Value Required!"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                   <td>
                       <asp:CustomValidator ID="C1" runat="server" ControlToValidate="TeacherId" ErrorMessage="NInvalid" OnServerValidate="C1_ServerValidate" ValidationGroup="a1"></asp:CustomValidator>
                   </td>      
                   <td>  <asp:Label ID="Label1" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Day
                </td>
                <td>
                    <asp:DropDownList ID="Day" runat="server" OnSelectedIndexChanged="Day_SelectedIndexChanged" CssClass="form-control">
                        <asp:ListItem>Select Day...</asp:ListItem>
                        <asp:ListItem>Monday</asp:ListItem>
                        <asp:ListItem>Tuesday</asp:ListItem>
                        <asp:ListItem>Wednesday</asp:ListItem>
                        <asp:ListItem>Thursday</asp:ListItem>
                        <asp:ListItem>Friday</asp:ListItem>
                        <asp:ListItem>Saturday</asp:ListItem>
                    



                    </asp:DropDownList>


                </td>
                   <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Day"
                ErrorMessage="Value Required!" InitialValue="Select Day..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>

            </tr>
            <tr>
                <td>
                     Time
                </td>
                <td>
                    <asp:DropDownList ID="TimePeriod" runat="server" OnSelectedIndexChanged="TimePeriod_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                       

                    </asp:DropDownList>
                </td>

                   <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TimePeriod"
                ErrorMessage="Value Required!" InitialValue="Select Time..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>

            </tr>
             <tr>
                <td>
                    Room Type 
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="RoomType" runat="server"  OnSelectedIndexChanged="RoomType_SelectedIndexChanged" CssClass="form-control">
                       <asp:ListItem>Select Room Type...</asp:ListItem>
                        <asp:ListItem>Lab</asp:ListItem>
                         <asp:ListItem>Room</asp:ListItem>

                    </asp:DropDownList>
                </td>
                    <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="RoomType"
                ErrorMessage="Value Required!" InitialValue="Select Room Type..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>

            </tr>
             <tr>
                <td>
                    Room No 
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="RoomNo" runat="server" TextMode="Number" CssClass="form-control" placeholder="Room No"></asp:TextBox>
                </td>

                    <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="RoomNo"
                ErrorMessage="Value Required!"   Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>

            </tr>
            <tr><asp:Panel ID="AddPanel" runat="server" Visible="False">
                <td class="auto-style2">
                    <asp:Button ID="Add" runat="server" Text="Add" OnClick="Add_Click" Width="101px" CssClass="btn" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Cencel" runat="server" Text="Cencel" style="margin-left: 16px" Width="95px"  OnClick="Cencel_Click" CssClass="form-control"/>
                </td>
                </asp:Panel>

                <asp:Panel ID="UpdatePanel" runat="server" Visible="False">
                <td class="auto-style2">
                    <asp:Button ID="Update" runat="server" Text="Update"  OnClick="Update_Click" Width="101px" CssClass="btn"   />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Cancel" runat="server" Text="Cencel" style="margin-left: 16px" Width="95px" OnClick="Cancel_Click" CssClass="btn" />
                </td>
                </asp:Panel>
            </tr>
            
        </table>

        </div>
    </asp:Content>
   