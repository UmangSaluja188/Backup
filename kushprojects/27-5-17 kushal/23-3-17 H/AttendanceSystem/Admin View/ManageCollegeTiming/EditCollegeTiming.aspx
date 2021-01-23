<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCollegeTiming.aspx.cs" Inherits="AttendanceSystem.Admin_View.ManageCollegeTiming.EditCollegeTiming" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>
        Edit College Timing
    </h1>
<table>
            <tr>
                <td>
                    College Open Time
                </td>
                <td>
                    <asp:TextBox ID="openTime" runat="server" TextMode="Time"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    College Close Time
                </td>
                <td>
                    <asp:TextBox ID="closingTime" runat="server" TextMode="Time"></asp:TextBox>

                </td>
                </tr>
    <tr>
                <td>
                    Lecture Duration
                </td>
                <td>
                   <asp:TextBox ID="lacDuration" runat="server" TextMode="Number" ></asp:TextBox>

                </td>
             </tr>
    <tr>
        <td>
        <asp:Button ID="Update" runat="server"  OnClick="Update_Click" Text="Update"/>
            </td>
        <td>
            <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click"  Text="Cancel"/>
        </td>
    </tr>
        </table>
    </div>
    </form>
</body>
</html>
