<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Insert.aspx.vb" Inherits="Insert" %>
<!DOCTYPE html>

<!-- Tyler Clark -->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Data Insertion</title>
    <style type="text/css">

        .label {
           display : inline;
           display : block;
           text-align: left;
        }

        .txtBox {
           display : inline;
           display : block;
           text-align: left;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        <h1>Insert Data</h1>
            <h2>Books</h2>
            <asp:label runat="server" CssClass="label">ISBN: </asp:label> 
            <asp:TextBox CssClass="txtBox" ID="ISBN" runat="server" Width="150px" />
            <asp:label runat="server" CssClass="label">Title: </asp:label> 
            <asp:TextBox CssClass="txtBox" ID="title" runat="server" Width="150px" />
            <asp:label runat="server" CssClass="label">Price:</asp:label>
            <asp:TextBox CssClass="txtBox" ID="price" runat="server" Width="50px" />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Insert Book" />
            &nbsp;
            <asp:Button ID="backBtn" runat="server" Text="Go Back" />

            <br />
            <asp:Label ID="Message" runat="server"></asp:Label>
            <br /><hr />

        </div>
    </form>
</body>
</html>
