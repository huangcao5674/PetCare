<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebKnowledgeManage.aspx.cs" Inherits="PetCare.ManageMent.WebKnowledgeManage" %>

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
        <asp:Label ID="Label1" runat="server" Text="UserID"></asp:Label></td>
    <td>
        <asp:Label ID="Label2" runat="server" Text="KnowledgeID"></asp:Label></td>
    <td>
        <asp:Label ID="Label3" runat="server" Text="AddressID"></asp:Label></td>
    <td>
        <asp:Label ID="Label4" runat="server" Text="PetCategoryID"></asp:Label></td>
    <td>
        <asp:Label ID="Label5" runat="server" Text="WeiBoID"></asp:Label></td>
    <td>
        <asp:Label ID="Label6" runat="server" Text="KnowledgeTitle"></asp:Label></td>
    </tr>
    <tr>
    <td>
        <asp:TextBox ID="TextBox1" runat="server" Width="95px"></asp:TextBox></td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" Width="92px"></asp:TextBox></td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server" Width="105px"></asp:TextBox></td>
    <td>
        <asp:TextBox ID="TextBox4" runat="server" Width="93px"></asp:TextBox></td>
    <td>
        <asp:TextBox ID="TextBox5" runat="server" Width="93px"></asp:TextBox></td>
    <td>
        <asp:TextBox ID="TextBox6" runat="server" Width="116px"></asp:TextBox></td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label7" runat="server" Text="KnowledgeTime"></asp:Label></td>
        <td>
            <asp:Label ID="Label8" runat="server" Text="PriorityScore"></asp:Label></td>
        <td>
            <asp:Label ID="Label9" runat="server" Text="IP"></asp:Label></td>
        <td>
            <asp:Label ID="Label10" runat="server" Text="FocusNum"></asp:Label></td>
        <td>
            <asp:Label ID="Label11" runat="server" Text="IsVisible"></asp:Label></td>
        <td></td>
    </tr>
     <tr>
    <td>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox></td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
