<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Reviews.aspx.vb" Inherits="Reviews" %>

<%--Tyler Clark--%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Reviews</title>
</head>
<body>
    <form id="form1" runat="server">
            <tr>
                <td valign="top">
                    <h2>Reviews</h2>
                    <asp:GridView ID="GridView1" AllowSorting="True" AllowPaging="True"
                        runat="server" DataSourceID="SqlDataSource1" DataKeyNames="ISBN, CID, rRate, rComment"
                        AutoGenerateColumns="False" Width="500px"
                        BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" style= "margin-right: 0px ">
                            <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" ReadOnly="True"
                                        SortExpression="ISBN" />
                                    <asp:BoundField DataField="CID" HeaderText="CID" ReadOnly="True"
                                        SortExpression="CID" />
                                    <asp:BoundField DataField="rRate" HeaderText="Rating" ReadOnly="True"
                                        SortExpression="rRate" />
                                    <asp:BoundField DataField="rComment" HeaderText="Comment" ReadOnly="True"
                                        SortExpression="rComment" />
                                    
                                </Columns>
                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
 
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString1.ProviderName %>" >
                    </asp:SqlDataSource>
                    <br /><br />
                </td>
            </tr>
        <asp:Label ID="Label1" runat="server" Text="Submit Review?"></asp:Label>
        <br />
        <asp:RadioButton GroupName="yesno" ID="yesRad" runat="server" Text="Yes" AutoPostBack="true" /><asp:RadioButton GroupName="yesno" ID="noRad" runat="server" Text ="No" AutoPostBack="True"/>
        <br /><br />
        <asp:Label ID="ratingTxt" runat="server" Text="Rating:"></asp:Label>
        <asp:RadioButtonList ID="ratingList" runat="server" Visible="False" AutoPostBack="true">
            <asp:ListItem Text='1 <img src="Resources/1star.gif"  />' Value="1" Selected="True" />
            <asp:ListItem Text='2 <img src="Resources/2star.gif"  />' Value="2"/>
            <asp:ListItem Text='3 <img src="Resources/3star.gif"  />' Value="3"/>
            <asp:ListItem Text='4 <img src="Resources/4star.gif"  />' Value="4"/>
            <asp:ListItem Text='5 <img src="Resources/5star.gif"  />' Value="5"/>
        </asp:RadioButtonList>
        <asp:Label ID="commentTxt" runat="server" Text="Comment:"></asp:Label>
        <br />
        <asp:TextBox ID="commentBox" TextMode="MultiLine" runat="server" Visible="false" Width="400px" Height="125px"></asp:TextBox>
        <br />

        <asp:Label ID="Message" runat="server"></asp:Label>

        <br /><br />

        <asp:Button ID="reviewBtn" runat="server" Text="Submit Review" AutoPostBack="True" /> &nbsp
        <asp:Button ID="backBtn" runat="server" Text="Go Back"/>
        <br /><hr />
        
    </form>
</body>
</html>
