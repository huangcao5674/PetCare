<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FocusManage.aspx.cs" Inherits="PetCare.ManageMent.FocusManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td>
        <asp:DropDownList ID="dpUser" runat="server">
        </asp:DropDownList>
    </td>
    <td>
        <asp:Button ID="BtnCheck" runat="server" Text="Check" 
            onclick="BtnCheck_Click" /></td>
    </tr>
    <tr>
    <td colspan="2"> 
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView> </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
