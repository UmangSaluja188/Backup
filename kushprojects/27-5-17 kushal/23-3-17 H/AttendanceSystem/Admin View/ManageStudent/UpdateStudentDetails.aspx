<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateStudentDetails.aspx.cs" Inherits="AttendanceSystem.AdminPage.UpdateStudentDetails"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>

<asp:Content ID="C1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<asp:Label ID="Error" runat="server"></asp:Label>
    <h1 class="text-primary"><asp:Label ID="Label1" runat="server">Update  Student<small> Details </small></asp:Label> </h1>
<hr />
           <div class="pre-scrollable container-fluid" >
               <h2 class="text-danger">Basic <small>Information</small></h2>
        <table class="table-responsive" style="float:left">
            <tr>
                <td>
                   
                    Student Id</td>
                <td>

                    <asp:TextBox ID="Roll" runat="server"  TextMode="Number"  CssClass="form-control"></asp:TextBox>

                </td>
                </tr>
               <tr>
                   <td>Roll No</td>
                   <td><asp:TextBox ID="TextBox1" runat="server"  CssClass="form-control"></asp:TextBox>

                   </td>

               </tr>
                
                 
        


            <tr>
                <td>

                    Course</td>
                <td>

                   
                     <asp:DropDownList ID="Course" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Course_SelectedIndexChanged" CssClass="form-control" >
                  
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

                    <asp:DropDownList ID="Semester" AutoPostBack="true" runat="server"  OnSelectedIndexChanged="Semester_SelectedIndexChanged"  CssClass="form-control">
                    </asp:DropDownList>

                </td>
                
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Semester"
                ErrorMessage="Value Required!" InitialValue="Select Semester"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            </table>
<hr />
            <table style="float:right">
             
            <tr>
                <td>
                     <asp:Image ID="Image" runat="server"  CssClass="img-thumbnail img-responsive " Width="137px" Height="125px"/></td>
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

                
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Name"
                ErrorMessage="Value Required!"   Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>

                    FatherName</td>
                <td>

                    <asp:TextBox ID="Father" runat="server" CssClass="form-control"></asp:TextBox>

                </td>
                
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Father"
                ErrorMessage="Value Required!"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>

                    Mother Names</td>
                <td>
                    
                 

                    <asp:TextBox ID="MotherName" runat="server" CssClass="form-control"></asp:TextBox>

                </td>
                 <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="MotherName"
                ErrorMessage="Value Required!"   Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
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

            
            <table>
            
                    
                        <tr>
                    <td><b>Birth Date</b></td>
                  </tr>
                   <tr>
                   <td>
                        <table>
                            <tr>
                                <td>Year</td><td>Month</td><td>Day</td>
                                </tr>
                            <tr>
                                <td>
                                     <asp:DropDownList ID="Year" runat="server" OnSelectedIndexChanged="Year_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>

                                </td>
                                <td>
                            <asp:Dropdownlist runat="server" ID="Month" Height="28px" CssClass="form-control" OnSelectedIndexChanged="Month_SelectedIndexChanged" AutoPostBack="true" >
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
                          <asp:DropDownList ID="Day" runat="server" OnSelectedIndexChanged="Day_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                </td>
                                
                            </tr>
                            </table>
                    </td>
                </tr>
        
      </table> 
      </table>

                 <hr />
              <h2 class="text-danger">Contact <small>Information</small></h2>

            <table>
                 <tr>
                <td>

                    Contact No</td>
                <td>

                    <asp:TextBox ID="ContactNo" runat="server"  CssClass="form-control" ></asp:TextBox>

                </td>
                <td><asp:RegularExpressionValidator ID="r1" runat="server" ValidationExpression="^[0-9]{10}$" ErrorMessage="!Invalid" ControlToValidate="ContactNo" Display="Dynamic"></asp:RegularExpressionValidator></td>
                
                 
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


                
                 
              <tr>
                <td>

                    Email</td>
                <td>


                    <asp:TextBox ID="Email" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>

                </td>
                
                  <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Email"
                ErrorMessage="Value Required!"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
            </tr>   
                   

</table>
                    <div>
                    <div style="float:none">
                        <h2 class="text-danger">Selected Subject<small>Details</small> </h2>
                        <table>
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                        </table>
                    </div>
                        </div>
                    <div>
                        <table >
                            <tr>
                                 <td>
                                    
                                        <asp:Button ID="Cancel" runat="server" Text="Reset" Height="48px" OnClick="Cancel_Click" Width="157px" CssClass="btn-danger text-danger"  CausesValidation="false" />
                                        </td>
                                <td>
                                    <asp:Button ID="Update" runat="server" Text="Update" Width="157px" Height="48px" OnClick="Update_Click"  CssClass="btn-danger text-danger" /></td>
                                   
                                </tr>
                                        </table>
                    </div>
        </div>
    <div style="height:100px">

    </div>
   </asp:Content>