<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchNoticeDetails.aspx.cs" Inherits="AttendanceSystem.Admin_View.ManageNotice.SearchNoticeDetails" MasterPageFile="~/Admin View/AdminMasterPage/Site1.Master" %>
<asp:Content ID="C1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="margin-top:7%">
    <h1>Search Notice Details</h1>
        <asp:HyperLink ID="Link1" runat="server" Text="Add New Notice" NavigateUrl="~/Admin View/ManageNotice/SendNotice.aspx"  ForeColor="Red" Font-Size="25px"></asp:HyperLink>
        <table>
            <tr>
                <td>
                Select Date
                </td>
                <td>
                    <asp:TextBox ID="SelectDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox></td><td><asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click"  CssClass="btn"/>
                </td>
            </tr>
        </table>
       
            <asp:GridView ID="AllNotice" runat="server" CssClass="table  table-bordered table-hover table-responsive table-condensed bg-warning text-warning" HeaderStyle-BackColor="#B69782" HeaderStyle-ForeColor="#ffffff" >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Deactivate" runat="server" OnClick="Deactivate_Click" Text="Deactivate" ForeColor="black"></asp:Button>
                        <asp:Button ID="Delete" runat="server" OnClick="Delete_Click" Text="Delete" ForeColor="Black"></asp:Button>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
              
    </div>
  
    </asp:Content>