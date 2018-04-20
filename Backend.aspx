<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Backend.aspx.vb" Inherits="Backend" %>

<%--Tyler Clark--%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Backend</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center"">
            <h1>Welcome to the Backend</h1>
            <asp:Button ID="manageBtn" runat="server" Text="View Database" />
            &nbsp;
            <asp:Button ID="insertBtn" runat="server" Text="Insert Books" />
            &nbsp;
            <asp:Button ID="homeBtn" runat="server" Text="Back to Website" />
        </div>
    </form>
</body>
</html>
