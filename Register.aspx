<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="Register" %>

<%--Tyler Clark--%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="3">
                    Register
                </th>
            </tr>
            <tr>
                <td>
                    <br />
                    Name
                </td>
                <td>
                    <br /> &nbsp
                    <asp:TextBox ID="txtName" runat="server" />
                </td>
                <td>
                    <br />
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtName"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    Password
                </td>
                <td>
                    <br /> &nbsp
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
                </td>
                <td>
                    <br />
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPass"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    Confirm Password 
                </td>
                <td>
                    <br /> &nbsp
                    <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password" />
                </td>
                <td>
                    <br />
                    <asp:CompareValidator ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPass"
                        ControlToValidate="txtConfirmPass" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <br />
                    <asp:Button ID="submitBtn" Text="Submit" runat="server" OnClick="RegisterUser" /> &nbsp
                    <asp:Button ID="returnBtn" runat="server" Text="Return" CausesValidation="false" />
                </td>
                <td>
                </td>
            </tr>
        </table>
        <asp:Label ID="Message" runat="server" Text=""></asp:Label>
        <br /><hr />
    </form>
</body>
</html>
