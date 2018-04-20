<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BookDetails.aspx.vb" Inherits="BookDetails" %>

<%--Tyler Clark--%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl1" runat="server" Font-Bold="True" Font-Size="Large" Text=""></asp:Label>
            <br /> <br />
            <asp:Label ID="lbl2" runat="server" Font-Bold="True" Font-Size="Large" Text=""></asp:Label>
            <br /><br />
            <asp:Label ID="rateLbl" runat="server" Font-Bold="True" Text="Rating: "></asp:Label>
            <asp:HyperLink ID="rateLink" runat="server" NavigateUrl="~/Reviews.aspx?"></asp:HyperLink>&nbsp;
            <asp:Label ID="totalLbl" runat="server" Font-Bold="True" Text="(Total Ratings: "></asp:Label>
            <br /><br />
            <asp:Label ID="lbl4" runat="server" Font-Bold="True" Font-Size="Large" Text=""></asp:Label>
            <br /><br />
            <asp:Button ID="Button1" runat="server" Text="Go Back"/> 
            <br /><hr />
        </div>
    </form>
</body>
</html>
