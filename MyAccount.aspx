<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MyAccount.aspx.vb" Inherits="MyAccount" %>

<%--Tyler Clark--%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Account</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Label ID="lbl1" runat="server" Font-Bold="True" Font-Size="Large" Text=""></asp:Label>
        <br />
        <asp:Label ID="lbl2" runat="server" Font-Bold="True" Font-Size="Large" Text=""></asp:Label>
        <br />
        <asp:Label ID="lbl3" runat="server" Font-Bold="True" Font-Size="Large" Text=""></asp:Label>
        <br />

        <tr>
            <td valign="top">
                <h2>Orders Made</h2>
                <asp:GridView ID="GridView1" AllowSorting="True" AllowPaging="True"
                    runat="server" DataSourceID="SqlDataSource1" DataKeyNames="ISBN, Quantity"
                    AutoGenerateColumns="False" Width="500px"
                    BackColor="White" 
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" style= "margin-right: 0px ">
                        <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ISBN" HeaderText="ISBN" ReadOnly="True"
                                    SortExpression="ISBN" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True"
                                    SortExpression="Quantity" />
                                    
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

        <asp:Button ID="backBtn" runat="server" Text="Go Back" />
        <br /><hr />
    </form>
</body>
</html>
