<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BookListing.aspx.vb" Inherits="BookListing" %>

<%--Tyler Clark--%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Listing</title>
    <style type="text/css">  
        .welcomeLabel {
            float:left
        }
        .accntLink {
            float:right
        }
    </style>  
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label CssClass="welcomeLabel" ID="welcomelbl" runat="server"></asp:Label>
            <asp:HyperLink CssClass="accntLink" ID="accntLink" runat="server" NavigateUrl="MyAccount.aspx?CID={0}">My Account</asp:HyperLink>
        </div>
        <br />
        <div>
            <asp:HyperLink CssClass="accntLink" ID="logoutLink" runat="server" NavigateUrl="~/Login.aspx">Logout</asp:HyperLink>
        </div>
        
        <br /><br />
        Search By:
        <br />
        <asp:DropDownList ID="searchSelect" runat="server" AutoPostBack="True">
            <asp:ListItem Selected="True">--Select--</asp:ListItem>
            <asp:ListItem>Rating</asp:ListItem>
            <asp:ListItem>Price</asp:ListItem>
        </asp:DropDownList>
        <br />

        <asp:RadioButtonList ID="ratingList" runat="server" Visible="False" AutoPostBack="true">
            <asp:ListItem Text='0 <img src="Resources/0star.gif"  />' Value="0"/>
            <asp:ListItem Text='1 <img src="Resources/1star.gif"  />' Value="1"/>
            <asp:ListItem Text='2 <img src="Resources/2star.gif"  />' Value="2"/>
            <asp:ListItem Text='3 <img src="Resources/3star.gif"  />' Value="3"/>
            <asp:ListItem Text='4 <img src="Resources/4star.gif"  />' Value="4"/>
            <asp:ListItem Text='5 <img src="Resources/5star.gif"  />' Value="5"/>
        </asp:RadioButtonList>

        <asp:RadioButtonList ID="priceList" runat="server" Visible="False" AutoPostBack="true">
            <asp:ListItem Value="10">$10.00</asp:ListItem>
            <asp:ListItem Value="20">$20.00</asp:ListItem>
            <asp:ListItem Value="30">$30.00</asp:ListItem>
            <asp:ListItem Value="40">$40.00</asp:ListItem>
            <asp:ListItem Value="50">$50.00</asp:ListItem>
            <asp:ListItem Value="0">$ ∞</asp:ListItem>
        </asp:RadioButtonList>

        <br />
        Search Results:
        <asp:Repeater ID="searchResult" runat="server">
            <HeaderTemplate>
                <table border="1">
                <tr bgcolor="#F7F7DE">
                    <th>Select</th><th>ISBN</th><th>Title</th><th>Price</th><th>Quantity</th>
                </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr style="text-align:center; " bgcolor="#F7F7DE">
                    <td style="width:50px;"><asp:CheckBox ID="CheckBox1" runat="server" /></td>
                    <td style="width:150px;"><asp:Label id="ISBN" runat="server"></asp:Label></td>
                    <td style="width:150px;"><asp:HyperLink ID="bTitle" runat="server" NavigateUrl='<%# Eval("ISBN", "~/BookDetails.aspx?ISBN={0}") %>'></asp:HyperLink></td>
                    <td style="width:150px;"><asp:Label id="bPrice" runat="server"></asp:Label></td>
                    <td style="width:75px;"><asp:TextBox ID="Quantity" runat="server" Width="25px">0</asp:TextBox></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate></table></FooterTemplate> 
        </asp:Repeater>

        <br />
        <asp:Button ID="orderBtn" runat="server" Text="Order Checked Books" Visible="false"/>
        <br />
        <asp:Label ID="msgLbl" runat="server"></asp:Label>
        <br /><hr />
    </form>
</body>
</html>
