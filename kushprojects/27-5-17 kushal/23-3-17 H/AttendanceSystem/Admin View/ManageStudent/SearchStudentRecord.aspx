<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchStudentRecord.aspx.cs" Inherits="AttendanceSystem.AdminPage.SearchStudentRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="AdminPageStylesheet/StudentDSe.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="maindiv">
       <h1>&nbsp;Searching Student Details</h1> </center>
            
                <table>
                    <tr>
                        <td>
                            Search By Name
                        </td>
                        <td>
                            Search By Roll No
                        </td>
                    </tr>
                    <tr>
                      <td>
                          <asp:TextBox ID="Name" runat="server" Height="32px" style="margin-left: 2px" Width="250px" stlyle="placholder:Roll No" ></asp:TextBox>

                        </td>
                        <td>
                            <asp:Button ID="Search" runat="server" Text="Search" Height="32px" OnClick="Search_Click" Width="110px"></asp:Button>
                        </td>
                        <td></td>
                        <td>
                             <asp:TextBox ID="RollNo" runat="server" Height="32px" Width="211px"></asp:TextBox>

                        </td>
                        <td><asp:Button ID="Search1" runat="server" Text="Search" Height="32px" Width="110px" OnClick="Search1_Click"></asp:Button></td>
                        </tr>
                </table>
                    
 
                    <asp:DataList ID="datalist1" runat="server">
                        <HeaderTemplate>
                             <table border="0" class="StudentDetails">
                                <tr>
                                    <th>Image</th> 
                                     <th>Roll No</th>
                                   <th>Name</th>
                                   <th>Father Name</th>
                                    <th>Mother Name</th>
                                    <th>Course Name</th>
                                    <th>Semester</th>
                                    <th>Contact No</th>
                                    <th>Address</th>
                                    <th>Age</th>
                                    <th>Date Of Birth</th>

                                    </tr>

                        </HeaderTemplate>
                        <ItemTemplate>
                         
                                <tr>
                                    
                                    <td><asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image") %>' Height="50px" /></td>
                                    <td><asp:Label  ID="RollNo" runat="server" Text='<%#Eval("StudentId") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Name" runat="server" Text='<%#Eval("StudentName") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="StudentFather" runat="server" Text='<%#Eval("StudentFather") %>'></asp:Label>
                                    </td>
                                    

                                    <td>
                                        <asp:Label ID="StudentMother" runat="server" Text='<%#Eval("StudentMother") %>'></asp:Label>
                                    </td>
                                    
                                    <td><asp:Label ID="Course" runat="server" Text='<%#Eval("CourseName") %>'></asp:Label></td>
                                    <td><asp:Label ID="Semester" runat="server" Text='<%#Eval("SemesterNo") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="ContactNo" runat="server" Text='<%#Eval("ContactNo") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Address" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                    </td>
                                    <td><asp:Label ID="Age" runat="server" Text='<%#Eval("Age") %>'></asp:Label></td>
                                    <td><asp:Label ID="DateOfBirth" runat="server" Text='<%#Eval("DateOfBirth") %>'></asp:Label></td>
                                    
                                </tr>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <h1>Hello</h1>
                        </EditItemTemplate>
                        <FooterTemplate>
                          </table>

                        </FooterTemplate>
                    </asp:DataList>
                    
                 
        &nbsp;&nbsp;    
        <asp:DataList ID="SelectedSubject2" runat="server">
            <HeaderTemplate>
                   <center>     <h1>Selected Subject Details</h1></center>

                <table border="1">
                    <tr>
                        <th>
                            Subject Name
                        </th>
                        <th>
                            Subject Opt/Comp
                        </th>
                        <th>
                            Subject Type
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                 
                    <td>
                        <asp:Label ID="SubjectName" runat="server" Text='<%#Eval("SubjectName") %>'></asp:Label>
                    </td>
                      <td>
                    <asp:Label ID="SubjectOC" runat="server" Text='<%#Eval("SubjectOptCom")%>'></asp:Label>
                    </td>
                
                    <td>
                    <asp:Label ID="SubjectType" runat="server" Text='<%#Eval("SubjectType") %>'></asp:Label>
                    </td>
                 
                  
                 
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>      
                     
    </div>
    </div>
    </form>
</body>
</html>
