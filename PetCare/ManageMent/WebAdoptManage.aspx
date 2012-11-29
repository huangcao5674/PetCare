<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebAdoptManage.aspx.cs" Inherits="PetCare.ManageMent.WebAdoptManage" %>

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
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
    <td>
        <asp:DropDownList ID="ddlAddress" runat="server">
        </asp:DropDownList>  
    </td>
    <td> 
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
    <td>
        <asp:DropDownList ID="ddlPetCategory" runat="server">
        </asp:DropDownList> </td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label> </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
       <td>
           <asp:Button ID="Button1" runat="server" Text="Button" /></td>
    </tr>
    <tr>
    <td colspan='9'>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
