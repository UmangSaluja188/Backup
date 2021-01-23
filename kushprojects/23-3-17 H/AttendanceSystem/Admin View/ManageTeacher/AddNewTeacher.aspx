<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewTeacher.aspx.cs" Inherits="AttendanceSystem.ManageTeacher.AddNewTeacher" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <h1 >Add New Teacher <small> Details</small></h1>
    <div class="container-fluid pre-scrollable" style="margin-top:5%" >
     <div class="row" >
     <div>
        <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
        <div >
            <div id="div3" style="width:100%"  >
                <div>
                <h3 class="text-danger">Basic <small>Information</small></h3>
                <table>
                    <tr>
                        <td>
                            Teacher Id
                        </td>
                        <td>
                            <asp:TextBox ID="TeacherId" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Department Name
                        </td>
                        <td>
                            <asp:DropDownList ID="DepartmentName" runat="server" OnSelectedIndexChanged="DepartmentName_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control"></asp:DropDownList>
                        </td>
                         <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DepartmentName"
                ErrorMessage="Value Required!" InitialValue="Select..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>

                    </tr>
                </table>
            </div>
            <div id="div4"></div>
        </div>
        <div id="div5">
            <div id="div6" style="width:65%;float:left">
                <h3 class="text-danger">Personal<small>Information</small> </h3>
                <table>
                    <tr>
                        <td >
                            Teacher Name
                        </td>
                        <td>
                            <asp:TextBox ID="TeacherName" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                         <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TeacherName"
                ErrorMessage="Value Required!"   Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                    </tr>
                    <tr>
                        <td>
                            Gender</td>
                        <td>
                            <asp:RadioButtonList ID="Gender" runat="server">
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

                    <tr>
                        <td>
                            Experience
                        </td>
                        <td class="auto-style5">
                            <asp:TextBox ID="Experience" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </td>
                        <td>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Experience"
                ErrorMessage="Value Required!"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                  
                    </tr>
                    <tr>
                        <td>
                            Specialization
                        </td>
                        <td>
                            <asp:TextBox ID="Specialization" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>

                         <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Specialization"
                ErrorMessage="Value Required!"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                    </tr>
                    <tr>
                        <td>
                            Qualification</td>
                        <td>
                            <asp:TextBox ID="Qualification" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>

                         <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Qualification"
                ErrorMessage="Value Required!"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                    </tr>
                    <tr>
                        <td>
                           </td>
                        <td>
                          </td>
                    </tr>
                </table>
            </div>
            <div id="div7" style="width:30%;float:left">
                <asp:Image ID="Image" runat="server" ImageUrl=" " Height="200px" Width="150px" CssClass="img-thumbnail img-responsive"  />
                <asp:FileUpload ID="Fileupload1" runat="server" Height="21px" style="margin-left: 53px" Width="88px" />

                <asp:Button ID="Button1" runat="server" Text="Upload" Height="33px" style="margin-bottom: 10px; margin-left: 8px;" Width="165px" OnClick="Button1_Click"  CausesValidation="false"/>
                
            </div>
            </div>
    <div id="div8">
        <div id="div9" style="width:70%">
        <h3 class="text-danger">Address/Contact <small>Information</small></h3>
            <table>
                            
                  <tr>
                     <td>
                         Select State
                     </td>
                     <td>
                        <asp:DropDownList ID="State" runat="server" AutoPostBack="true" OnSelectedIndexChanged="State_SelectedIndexChanged2" CssClass="form-control"></asp:DropDownList>                                     
                        
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
                    
                    <td><asp:DropDownList ID="District" runat="server" CssClass="form-control" OnSelectedIndexChanged="District_SelectedIndexChanged" AutoPostBack="true">                      
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
                    <td class="auto-style1">
                        Contact No
                    </td>
                    <td>
                        <asp:TextBox ID="ContactNo" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </td>
                                    <td><asp:RegularExpressionValidator ID="r1" runat="server" ValidationExpression="^[0-9]{10}$" ErrorMessage="!Invalid" ControlToValidate="ContactNo" Display="Dynamic"></asp:RegularExpressionValidator></td>

                     <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ContactNo"
                ErrorMessage="Value Required!" Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                </tr>

                <tr>
                    <td>
                        Email
                    </td>
                    <td>
                        <asp:TextBox ID="Email" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                    </td>

                     <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Email"
                ErrorMessage="Value Required!"   Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                </tr>
               
                <tr>
                    <td>
                          <asp:Button ID="Add" runat="server" OnClick="Add_Click" Text="ADD"  CssClass="btn-Danger" /></td>
                    <td></td>
                    <td></td>
                   
                     
                         <td><asp:Button ID="Cancel" runat="server" Text="CENCEL"  OnClick="Cancel_Click"  CssClass="btn-Danger" CausesValidation="false"/>
                    </td>
                </tr>
            </table>
        </div>
      
        </div>
          

      
    </div>
    </div></div>
      </div>
  </asp:Content>
