<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebKnowledgeManage.aspx.cs" Inherits="PetCare.ManageMent.WebKnowledgeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 169px;
        }
        .style2
        {
            height: 16px;
        }
        .style3
        {
            height: 19px;
        }
        .style5
        {
            height: 16px;
            width: 111px;
        }
        .style6
        {
            height: 19px;
            width: 111px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="style1">
    <tr>
    <td class="style5">
        <asp:Label ID="Label1" runat="server" Text="UserID"></asp:Label></td>
 
    <td class="style2">
        <asp:Label ID="Label3" runat="server" Text="AddressID"></asp:Label></td>
    <td class="style2">
        <asp:Label ID="Label4" runat="server" Text="PetCategoryID"></asp:Label></td>
 
    <td class="style2">
        <asp:Label ID="Label6" runat="server" Text="KnowledgeTitle"></asp:Label></td>
    </tr>
    <tr>
    <td class="style6">
        <asp:DropDownList ID="dpUsers" runat="server" Height="16px" Width="112px" 
            AutoPostBack="True">
        </asp:DropDownList>
        </td>
 
    <td class="style3">
        <asp:DropDownList ID="dpAddress" runat="server" Height="16px" Width="87px" 
            AutoPostBack="True">
        </asp:DropDownList>
        </td>
    <td class="style3">
        <asp:DropDownList ID="dpCategory" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        </td>
    <td class="style3">
        <asp:TextBox ID="tbKnowLedgeTitle" runat="server" Width="146px"></asp:TextBox></td>
    </tr>

        <tr>
    <td colspan="4" class="style3">
        <asp:TextBox ID="tbContent" runat="server" Width="596px" Height="39px"></asp:TextBox></td>
    </tr>
        </table>
    <table>
    <tr>
    <td> 
        <asp:Button ID="BtnAdd" runat="server" Text="添加" onclick="BtnAdd_Click" 
            style="height: 21px" /> 
             <asp:Button ID="BtnBack" runat="server" Text="返回"  
            style="height: 21px" onclick="BtnBack_Click" /> 
             </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
