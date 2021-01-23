<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewStu.aspx.cs" Inherits="AttendanceSystem.AdminPage.AddNewStu"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>
<asp:Content ID="c3" runat="server" ContentPlaceHolderID="head">
   
    <style type="text/css">
        .auto-style1 {
            width: 30px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="C1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container-fluid" style="margin-top:30px">
        <div>
        <asp:Label ID="Error1" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
        <h1 class="text-primary">Add New  Student<small> Details </small></h1>
<hr />
           <div class="pre-scrollable container-fluid" >
               <h2 class="text-danger">Basic <small>Information</small></h2>
        <table class="table-responsive" style="float:left">
            <tr>
                <td>
                   
                    Student Id</td>
                <td>

                    <asp:TextBox ID="RollNo" runat="server"  TextMode="Number"  CssClass="form-control"></asp:TextBox>

                </td>                              
            </tr>
            <tr>
                <td>
                    Roll No

                </td>
                <td>  
                    <asp:TextBox ID="RollNo1" runat="server"  TextMode="Number"  CssClass="form-control"></asp:TextBox>
                 </td>
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RollNo1"
                ErrorMessage="Value Required!" InitialValue="Select Course"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                <td>
                    <asp:CompareValidator ID="C5" runat="server" ControlToValidate="RollNo1" ErrorMessage="Invalid" Type="Integer" Operator="DataTypeCheck" >

                    </asp:CompareValidator>
                </td>

            </tr>

            <tr>
                <td>

                    Course</td>
                <td>
                 
                     <asp:DropDownList ID="Course" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Course_SelectedIndexChanged1" CssClass="form-control" >                 
                    </asp:DropDownList>
                </td>               
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Course"
                ErrorMessage="Value Required!" InitialValue="Select Course"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>

                    Semester</td>
                <td>

                    <asp:DropDownList ID="Semester" AutoPostBack="true" runat="server"  OnSelectedIndexChanged="Semester_SelectedIndexChanged1"  CssClass="form-control">
                    </asp:DropDownList>

                </td>
                
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Semester"
                ErrorMessage="Value Required!" InitialValue="Select Semester"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            </table>

            <table style="float:right">
             
            <tr>
                <td>
                     <asp:Image ID="Image1" runat="server"  CssClass="img-thumbnail img-responsive " Width="137px" Height="125px"/></td>
                <td>
              
                </td>
                </tr>
                       <tr>
              <td class="auto-style13"><asp:FileUpload ID="FileUpload1" runat="server" Height="36px" Width="230px" /></td>
             
            </tr>
                <tr>
              <td><asp:Button ID="Upload" runat="server" Text="Upload"  OnClick="Upload_Click"   CausesValidation="false"  CssClass="btn bg-danger text-danger" /></td>
          </tr>
              <tr>
                  <td></td>
              </tr>
            </table>
            <hr />
            <h2 class="text-danger">Personal <small>Information</small></h2>
            <table>
            <tr>
                <td>

                    Name</td>
                <td >

                    <asp:TextBox ID="Name" runat="server" CssClass="form-control"></asp:TextBox>

                </td>

                
                  <td class="auto-style1">
                      &nbsp;</td>
            </tr>
            <tr>
                <td>

                    FatherName</td>
                <td>

                    <asp:TextBox ID="FatherName" runat="server" CssClass="form-control"></asp:TextBox>

                </td>
                
                  <td class="auto-style1">
                      &nbsp;</td>
            </tr>
            <tr>
                <td>

                    Mother Names</td>
                <td>
                    
                 

                    <asp:TextBox ID="MotherName" runat="server" CssClass="form-control"></asp:TextBox>

                </td>
                 <td class="auto-style1">
                     &nbsp;</td>
            </tr>
            <tr>
                <td>

                    Gender</td>
                <td>

                    <asp:RadioButtonList ID="Gender" runat="server" RepeatDirection="Horizontal">
                    
                        <asp:ListItem Selected="True">Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:RadioButtonList>

                </td>
            </tr>

            
           
                </table>
               <table>
            
                    
                        <tr>
                    <td><b>Birth Date</b></td>
                  </tr>
                   <tr>
                   <td>
                        <table>
                            <tr>
                                <td>
                                     <asp:DropDownList ID="Year" runat="server" OnSelectedIndexChanged="Year_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>

                                </td>
                                <td>
                            <asp:Dropdownlist runat="server" ID="Month" Height="28px" CssClass="form-control" OnSelectedIndexChanged="Month_SelectedIndexChanged" AutoPostBack="true" >
                            <asp:ListItem>Select Month...</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                        </asp:Dropdownlist>

                                </td>
                                <td>
                          <asp:DropDownList ID="Day" runat="server" OnSelectedIndexChanged="Day_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                
                            </tr>
                            </table>
                    </td>
                </tr>
        
      </table>
<div class="container-fluid" >
              <h3  class="text-primary" >Subject Selection <small>Details</small></h3>
            
            <table style="margin-left:10px">
                <tr>
                    <td class="text-danger">
                      <pre class="text-danger">Compulsary Subject</pre> 
                    </td>
     <td></td>
                
                    <td style="text-align:center" class="text-danger"><pre class="text-danger">  Optional Subject</pre></td>

                </tr>
                 <tr>
                        <td>
                        <asp:CheckBoxList ID="CompulsarySubjectDetails" runat="server" >
                            
                        </asp:CheckBoxList>
                          
                    </td>
                     <td></td>
                    <td>
                        <asp:CheckBoxList ID="OptSubjectDetails" runat="server" >
                            
                        </asp:CheckBoxList>
                          
                    </td>
                           
                  
                         
                </tr>
            </table>
              
    </div>
             <hr />
              <h2 class="text-danger">Contact <small>Information</small></h2>

            <table>
                 <tr>
                <td>

                    Contact No</td>
                <td>

                    <asp:TextBox ID="ContactNo" runat="server"  CssClass="form-control" placeholder="Contact No." ></asp:TextBox>

                </td>
                <td><asp:RegularExpressionValidator ID="r1" runat="server" ValidationExpression="^[0-9]{10}$" ErrorMessage="!Invalid" ControlToValidate="ContactNo" Display="Dynamic"></asp:RegularExpressionValidator></td>
                <td><asp:RequiredFieldValidator ID="Cont" runat="server" ControlToValidate="ContactNo" ErrorMessage="*Required"></asp:RequiredFieldValidator></td>
                 
            </tr>
            
               <tr>
                     <td>
                         Select State
                     </td>
                     <td>
                         <asp:DropDownList ID="State" runat="server" AutoPostBack="true" OnSelectedIndexChanged="State_SelectedIndexChanged" CssClass="form-control">
                             
                         </asp:DropDownList>
                     </td>
                   <td>
                   <asp:Panel ID="StateName" runat="server" Visible="false">
                       <asp:TextBox ID="OtherState" runat="server" placeholder="Enter State Name" CssClass="form-control"></asp:TextBox>

                   </asp:Panel>
                       </td>
                 </tr>
                <tr>
                    <td>
                     Select  District
                    </td>
                    <asp:Panel ID="DistrictPanel" runat="server">
                    
                    <td><asp:DropDownList ID="District" runat="server" OnSelectedIndexChanged="District_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">                      
                        </asp:DropDownList></td>
                          </asp:Panel>
                     <td>
                       
                  <asp:Panel ID="Panel1" runat="server" Visible="false" >
                       <asp:TextBox ID="OthersDistrict" runat="server" placeholder="Enter District Name" CssClass="form-control" ></asp:TextBox>

                   </asp:Panel>
                       </td>
                
                 
                </tr>
               
                <tr>
                    <td>
                        Teh.
                    </td>
                    <td>
                       <asp:TextBox ID="Teh1" runat="server" Placeholder="Tehsil." CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>City/Village</td>
                    <td>
                        <asp:TextBox ID="CityVill" runat="server" placeholder="City/Village" CssClass="form-control" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        PinCode
                    </td>
                    <td><asp:TextBox ID="PinCode" runat="server" CssClass="form-control" placeholder="Pincode"></asp:TextBox></td>
                </tr>
              <tr>
                <td>

                    Email</td>
                <td>


                    <asp:TextBox ID="Email" runat="server" TextMode="Email" CssClass="form-control" placeholder="Email"></asp:TextBox>

                </td>
                
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Email"
                ErrorMessage="Value Required!"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>   
                   
                 
              
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" Height="60px" OnClick="Button2_Click" Text="Add" Width="163px" style="margin-left: 43px"   CssClass="btn bg-danger text-danger"/>
                </td>
                <td>
                     <asp:Button ID="Reset" runat="server" Height="60px" OnClick="Reset_Click" Text="Cancel" Width="163px" style="margin-left: 46px"  CausesValidation="false" CssClass="btn bg-danger text-danger"/>
                </td>
            </tr>
             
            </table>
          
            </div>
            
           

        </div>
    
  
        </div>
        <br />
        
</asp:Content>
