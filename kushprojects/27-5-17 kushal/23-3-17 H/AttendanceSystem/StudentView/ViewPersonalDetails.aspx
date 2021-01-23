<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPersonalDetails.aspx.cs" Inherits="AttendanceSystem.StudentView.ViewPersonalDetails" MasterPageFile="~/StudentView/Site1.Master"%>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container-fluid">  
      
   <div class="pre-scrollable" >
               <h2 class="text-primary">
                  <center>  
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/b1.png" Height="50px" Width="50px" PostBackUrl="~/StudentView/ViewTimeTable.aspx"  style="float:left" />
      
                      View Student <small>Details</small></center>
                   </h2>
               

                 <div class="Maindiv">
                <div>
                    <hr /
                     <h3 class="text-danger">Basic <small>Information</small></h3>
                    <div>
                        <table style="width: 380px">
                            <tr>
                                <td class="auto-style5"><span class="form-control">Roll No</span>
                          </td>
                                <td>
                                    <asp:Label ID="Roll" runat="server"   CssClass="form-control"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td class="auto-style5"><span class="form-control">Roll No</span>
                          </td>
                                <td>
                                    <asp:Label ID="RollNo" runat="server"   CssClass="form-control"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6"><span class="form-control">Course</span>                          

                          </td>
                              <td>   <asp:Label ID="Course" runat="server" CssClass="form-control"></asp:Label>  <asp:Label ID="Sem" runat="server"></asp:Label>       </td> 
                            </tr>
                           
                        </table>
                    </div>
                   
                    <div>
                        <hr />
                         <h3 class="text-danger">Personal <small>Information</small></h3>
                        <div style="float:left; width:70% ">
                            <table  style="width: 350px;float:left">
                                <tr>
                                    <td class="auto-style3"><span class="form-control">Name</span>
                          </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="Name" runat="server"   CssClass="form-control"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style3"><span class="form-control">Father Name</span>
                          </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="Father" runat="server" CssClass="form-control" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style3"><span class="form-control">Mother Name</span>
                          </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="MotherName" runat="server" CssClass="form-control" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style3"><span class="form-control">Gender</span>
                          </td>
                                    <td class="auto-style2">
                                       
                                  <asp:Label ID="Gender" runat="server" CssClass="form-control"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><span class="form-control">Date Of Birth</span>
                          </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="DateOfBirth" runat="server"    CssClass="form-control"></asp:Label>
                                    </td>
                                </tr>
                       
                            </table>
                        </div>
                        <div style="width:20%;margin-left:30px;float:left">
                            
                            <asp:Image ID="Image1" runat="server"  ImageUrl=""  AlternateText="Please Select Image" Height="196px" Width="126px" CssClass="img-thumbnail img-responsive img-rounded"/>
                           
                             </div>
                    </div>
               
               
                  
                    <div>
                        <hr />
                              <h3 class="text-danger">Contact <small>Information</small></h3>

                        <table  style="width: 350px">
                            <tr>
                                <td ><span class="form-control">Contact No</span>
                      </td>
                                <td>
                                        <asp:Label ID="ContactNo" runat="server"   style="margin-left: 0px"  CssClass="form-control"></asp:Label>
                                        </td>
                            </tr>
                            <tr>
                                <td ><span class="form-control">Email</span>
                      </td>
                                <td>
                                    <asp:Label ID="Email" runat="server" style="margin-left: 0px"  CssClass="form-control"></asp:Label>
                                </td>
                            </tr>
                         <tr>
                             <td>
                                 State
                             </td>
                             <td>
                                 <asp:Label ID="State" runat="server"></asp:Label>
                                </td>
                             </tr>
                            <tr>
                             
                             <td>
                                 <span>District</span>

                             </td>
                             <td><asp:Label ID="District" runat="server"></asp:Label></td>
                         </tr>
                            <tr>
                                <td>
                                    <span>Teh.</span>
                                </td>
                                <td><asp:Label ID="Teh" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <span>City/Village</span>
                                </td>
                                <td>
                                    <asp:Label ID="City" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Pincode</span>
                                </td>
                                <td>
                                    <asp:Label ID="PinCode" runat="server"></asp:Label>
                                </td>
                            </tr>

                        </table>
                    </div>
                        <div></div>
                        </div>
                    <div>
                    <div >
                                                <h3 class="text-danger">Selected Subject <small>Information</small></h3>

                        <table> 
                            <tr>
                                <td>
                                  
                                    <asp:CheckBoxList ID="SelectedSubject" runat="server" CssClass="checkbox-inline"  Enabled="false"></asp:CheckBoxList>
                                </td>
                            </tr>
                        </table>
                    </div>
                        </div>
                    <div>
                       </div>
                    </div>
      </div>
        </div>
   </asp:Content>
      