<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Login.aspx.vb" Inherits="Login" %>  
  
<%--Tyler Clark--%>

<!DOCTYPE html>  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title>Login</title>  
    <style type="text/css">  
        .auto-style1 {  
            width: 100%;  
        }  
        .auto-style2 {
            width: 23px;
        }
    </style>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
      
        <table class="auto-style1">  
            <tr>  
                <td colspan="4" style="text-align: center; vertical-align: top">  
                   <h1>Login</h1>
                </td>  
            </tr>  
            <tr>  
                <td class="auto-style2"> </td>  
                <td style="text-align: center">  
                      
                </td>  
                <td style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Name:"></asp:Label>  
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:TextBox ID="userTxt" runat="server" Font-Size="X-Large"></asp:TextBox>  
                </td>  
            </tr>  
            <tr>  
                <td class="auto-style2"> </td>  
                <td style="text-align: center">  
                      
                </td>  
                <td style="text-align: center">
                    <asp:Label ID="Label5" runat="server" Font-Size="X-Large" Text="Password:       "></asp:Label>  
                    <asp:TextBox ID="passTxt" runat="server" Font-Size="X-Large" TextMode="Password"></asp:TextBox>  
                </td>  
            </tr>  
            <tr>  
                <td class="auto-style2"> </td>  
                <td> </td>  
                <td style="text-align: center">  
                    <asp:Button ID="Button1" runat="server" Font-Size="Large" Text="Login" />
                    &nbsp;
                    <asp:Button ID="Button2" runat="server" Font-Size="Large" Text="Register" />
                    
                </td>  
            </tr>  
            <tr>  
                <td class="auto-style2"> </td>  
                <td> </td>  
                <td style="text-align:center">  
                    <asp:Label ID="Label4" runat="server" Font-Size="Large"></asp:Label>  
                </td>  
            </tr>  
        </table>
        <br /><hr />
      
    </div>  
    </form>  
</body>  
</html>  