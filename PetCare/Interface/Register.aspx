<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PetCare.Interface.Register" %>

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
        <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
    <td>
        <asp:Label ID="Label3" runat="server" Text="密码"></asp:Label> </td>
    <td><input id="Password1" type="password" /></td>
    </tr>
     <tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="确认密码"></asp:Label></td>
    <td>
        <input id="Password2" type="password" /></td>
    </tr>
     <tr>
    <td>
        <asp:Label ID="Label4" runat="server" Text="性别"></asp:Label></td>
    <td>
        <asp:RadioButton ID="man" Text="男" runat="server" />
        <asp:RadioButton ID="woman" Text="女"  runat="server" />
        </td>
    </tr>
     <tr>
    <td>
        <asp:Label ID="Label5" runat="server" Text="年龄"></asp:Label></td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
    <td>
        <asp:Label ID="Label6" runat="server" Text="邮箱"></asp:Label></td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
    <td  align="right" >
        <asp:Button ID="Button1" runat="server" Text="注册" /></td>
        <td align="left"> 
            <asp:Button ID="Button2" runat="server" Text="返回" /></td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
