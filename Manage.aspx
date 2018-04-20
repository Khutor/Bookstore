<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Manage.aspx.vb" Inherits="_Manage" %>
<!DOCTYPE html>

<!-- Tyler Clark -->

<html>
<head id="Head1" runat="server">
    <title>Manage Data</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align:center">Data Management</h1>
        <table style="margin: 0 auto; width: 200px;">

            <%--Books--%>     
            <tr>
                <td valign="top">
                    <h2>Books</h2>
                    <asp:GridView ID="GridView3" AllowSorting="True" AllowPaging="True"
                        runat="server" DataSourceID="SqlDataSource5" DataKeyNames="ISBN"
                        AutoGenerateColumns="False" Width="500px"
                        OnRowDeleted="GridView3_RowDeleted" BackColor="White"
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" style= "margin-right: 0px ">
                            <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField  ShowDeleteButton="true"/>
                                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" ReadOnly="True"
                                        SortExpression="ISBN" />
                                    <asp:HyperLinkField HeaderText="Title" DataTextField="bTitle" 
                                        DataNavigateUrlFields="ISBN" DataNavigateUrlFormatString="~\Details.aspx?ISBN={0}"  />
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
 
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server"
                        SelectCommand  = "SELECT [ISBN], [bTitle] FROM [Books]"
                        DeleteCommand  = "DELETE FROM Books WHERE ISBN = @ISBN"
                        ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString1.ProviderName %>" >
                    </asp:SqlDataSource>
                    <br /><br />
                    <h2>Customers</h2>
                </td>
            </tr>

            <%--Customers--%>
            <tr>
                <td valign="top">
                    <asp:GridView ID="GridView1" AllowSorting="True" AllowPaging="True"
                        runat="server" DataSourceID="SqlDataSource1" DataKeyNames="CID"
                        AutoGenerateColumns="False" Width="500px"
                        OnRowDeleted="GridView1_RowDeleted" BackColor="White"
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" style= "margin-right: 0px ">
                            <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField  ShowDeleteButton="true"/>
                                    <asp:BoundField DataField="CID" HeaderText="CID" ReadOnly="True"
                                        SortExpression="CID" />
                                    <asp:HyperLinkField HeaderText="Name" DataTextField="cName" 
                                        DataNavigateUrlFields="CID" DataNavigateUrlFormatString="~\Details.aspx?CID={0}"  />
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
                        SelectCommand  = "SELECT [CID], [cName] FROM [Customers]"
                        DeleteCommand  = "DELETE FROM [Customers] WHERE CID = @CID"
                        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" >
                    </asp:SqlDataSource>
                    <br /><br />
                </td>
            </tr>
        </table> 
        <br />
        <p style="margin: 0 auto; width: 281px;" />
        <asp:Button ID="Button1" runat="server" Text="Go Home" />&nbsp;&nbsp;&nbsp; <asp:Button ID="Button2" runat="server" Text="Clear Database" />
        </p>
        <p style="margin: 0 auto; width: 200px;">        
        <asp:Label ID="MessageLabel" EnableViewState="False" runat="server" />
        <br /><hr />
        </p>
        <br />
    </form>
</body>
</html>