<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaAddressManage.aspx.cs" Inherits="PetCare.ManageMent.AreaAddressManage" %>

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
    <td>省 </td>
    <td> 
        <asp:TextBox ID="tbProvince" runat="server" Width="83px"></asp:TextBox></td>
    <td>市</td>
    <td> 
        <asp:TextBox ID="tbArea" runat="server" Width="107px"></asp:TextBox></td>
    <td>
        <asp:Button ID="BtnAdd" runat="server" Text="Add" onclick="BtnAdd_Click" /> </td>
    </tr>


    </table>

        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
