<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateTeacher.aspx.cs" Inherits="AttendanceSystem.ManageTeacher.UpdateTeacher"  MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master"%>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="pre-scrollable container-fluid  " style="margin-top:3%;height:800px">
       <div>
    <asp:Label ID="Error" runat="server" ForeColor="#ff3300" Font-Size="30px"></asp:Label>
        <div id="div2" style="width:100%">
            <div id="div3" style="width:100%" >
                <center><asp:Label ID="Label1" runat="server" CssClass="text-info"><h1 >Update Teacher <small>Details</small> </h1> </asp:Label>
                    
                </center>
                <h2 class="text-danger">Basic <small>Information</small></h2>
                <table>
                    <tr>
                        <td>
                            Teacher Id
                        </td>
                        <td>
                            <asp:TextBox ID="TeacherId" runat="server"  CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Department Name
                        </td>
                        <td>
                            <asp:DropDownList ID="DepartmentName" runat="server"   CssClass="form-control"></asp:DropDownList>
                        </td>
                               <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DepartmentName"
                ErrorMessage="Value Required!" InitialValue="Select..."  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                    </tr>
                </table>
            </div>
            <div></div>
        </div>
        <div>
            <div id="div6" style="width:65%;float:left">
                <h2 class="text-danger">Personal <small>Information</small></h2>
                <table>
                    <tr>
                        <td>
                            Teacher Name
                        </td>
                        <td>
                            <asp:TextBox ID="TeacherName" runat="server"  CssClass="form-control"></asp:TextBox>
                        </td>
                             <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TeacherName"
                ErrorMessage="Value Required!"   Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            Gender</td>
                        <td class="auto-style5">
                            <asp:RadioButtonList ID="Gender" runat="server">
                                <asp:ListItem>Male</asp:ListItem>
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
                        <td>
                            <asp:TextBox ID="Experience" runat="server"  TextMode="Number"   CssClass="form-control"></asp:TextBox></td><td>Years
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
                            <asp:TextBox ID="Specialization" runat="server"   CssClass="form-control"></asp:TextBox>
                        </td>
                           <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Specialization"
                ErrorMessage="Value Required!"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                    </tr>
                     <tr>
                        <td>
                            Qualification
                        </td>
                        <td>
                            <asp:TextBox ID="Qualification" runat="server"  CssClass="form-control"></asp:TextBox>
                        </td>
                            <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Qualification"
                ErrorMessage="Value Required!"  Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                    </tr>
                </table>
            </div>
            <div id="div7" style="width:30%;float:left; margin-left: 10px;">
                <asp:Image ID="NImage" runat="server" ImageUrl="" Height="150px" Width="200px" CssClass="img-responsive img-thumbnail "  />
                <asp:FileUpload ID="Fileupload1" runat="server" Height="21px" style="margin-left: 53px" Width="88px"  CssClass="form-control"/>
                <asp:Button ID="Upload" runat="server" Text="Upload" Height="33px" style="margin-top: 0px; margin-left: 8px;" Width="165px" CssClass="form-control" OnClick="Upload_Click" />
            </div>
            </div>
    <div id="div8">
        <div id="div9" style="width:70%">
        <h2 class="text-danger">Contact <small>Information</small></h2>
            <table>
                <tr>
                    <td class="auto-style1">
                        Contact No
                    </td>
                    <td>
                        <asp:TextBox ID="ContactNo" runat="server" TextMode="Number"  CssClass="form-control"></asp:TextBox>
                    </td>
                   <td><asp:RegularExpressionValidator ID="r1" runat="server" ValidationExpression="^[0-9]{10}$" ErrorMessage="!Invalid" ControlToValidate="ContactNo" Display="Dynamic"></asp:RegularExpressionValidator></td>
                     <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ContactNo"
                ErrorMessage="Value Required!" Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        Email
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="Email" runat="server" TextMode="Email"  CssClass="form-control"></asp:TextBox>
                    </td>
                      <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Email"
                ErrorMessage="Value Required!"   Display="Dynamic"></asp:RequiredFieldValidator>
                 </td>
                </tr>
               <tr>
                     <td>
                         Select State
                     </td>
                     <td>
                        <asp:DropDownList ID="State" runat="server" AutoPostBack="true" OnSelectedIndexChanged="State_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>                                     
                        
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

            </table>
        </div>
        <div id="div10">

            <asp:Button ID="Update" runat="server" Height="37px" style="margin-left: 57px; margin-top: 13px" Text="Update" Width="136px" OnClick="Update_Click" CssClass="btn" />
            <asp:Button ID="Button3" runat="server" Height="37px" style="margin-left: 124px" Text="CENCEL" Width="136px" OnClick="Button3_Click"  CssClass="btn" CausesValidation="false"/>

        </div>
    </div>
    </div>
    </div>
 </asp:Content>
    
 