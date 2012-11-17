<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PetCare.WebForm1" %>

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
        <asp:LinkButton ID="User" runat="server" PostBackUrl="~/ManageMent/WebUserManage.aspx">用户管理</asp:LinkButton>
    </td>
    <td>
        <asp:LinkButton ID="AdoptPet" runat="server" PostBackUrl="~/ManageMent/WebAdoptManage.aspx">AdoptPet管理</asp:LinkButton></td>
    <td>
        <asp:LinkButton ID="KnowledgePet" runat="server" PostBackUrl="~/ManageMent/WebKnowledgeManage.aspx">KnowledgePet管理</asp:LinkButton>
    </td>
    <td>
        <asp:LinkButton ID="MissedPet" runat="server" PostBackUrl="~/ManageMent/WebMissedPetManage.aspx">MissedPet管理</asp:LinkButton>
    </td>
    </tr>
    </table>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" 
            style="height: 21px" />
    </div>
    </form>
</body>
</html>
