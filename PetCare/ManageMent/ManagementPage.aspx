<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagementPage.aspx.cs" Inherits="PetCare.ManagementPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr><td>欢迎您：</td>
    <td>
        <asp:Label ID="LbUserName" runat="server" Text="游客"></asp:Label> </td>
    </tr>
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
    <tr>
    <td>
            <asp:LinkButton ID="KnowledgeUser" runat="server" PostBackUrl="~/Interface/KnowledgeInfo.aspx">PeopleKnowledge</asp:LinkButton>
    </td>
    <td>           <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/ManageMent/FocusManage.aspx">UserFocus</asp:LinkButton></td>
    <td>
   <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/ManageMent/KnowledgeComment.aspx">KnowledgeComment</asp:LinkButton>
    </td>
       <td>
           <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/html/index.html">HyperLink</asp:HyperLink>
    
    </td>

           <td>
           <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ManageMent/Index.aspx">NEWNEW</asp:HyperLink>
    </td>

    </tr>
    </table>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Interface/Register.aspx">注册用户</asp:LinkButton>
          <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/html/simple.html">发布日志</asp:HyperLink>
      <table>
      </table>
    </div>
    </form>
</body>
</html>
