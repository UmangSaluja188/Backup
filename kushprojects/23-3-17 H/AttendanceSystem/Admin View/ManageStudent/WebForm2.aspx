<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="AttendanceSystem.Admin_View.ManageStudent.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<bodyx
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="f1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
           <ContentTemplate>
                            <asp:Button ID="b1" runat="server" Text="BBBB" OnClick="b1_Click" /> 

           </ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="b1" EventName="Click" />
</Triggers>
        </asp:UpdatePanel>
           
    </div>
    </form>
</body>
</html>
