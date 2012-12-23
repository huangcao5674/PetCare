<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebUserManage.aspx.cs" Inherits="PetCare.ManageMent.WebUserManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
     <tr>
     <td>用户信息管理</td>
     </tr>
     <tr>
     <td><asp:GridView ID="GridViewUsers" runat="server">
     </asp:GridView></td>
     </tr>
     <tr>
     <td> 
         <asp:Button ID="BtnDelete1" runat="server" Text="删除" onclick="BtnDelete1_Click" /> 
         <asp:Button ID="BtnEdit" runat="server" Text="编辑" onclick="BtnEdit_Click" />
         <asp:Button ID="BtnAdd" runat="server" Text="添加" onclick="BtnAdd_Click" />
         <asp:Button ID="BtnSearch" runat="server" Text="搜索" onclick="BtnSearch_Click" />
      </td>
     </tr>
     <tr>
     <td>
         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
     </tr>
    </table>
      <table>
      <tr>
     
      <td>UserName</td>
      <td>UserPass</td>
      <td>UserRealName</td>
      <td>UserAge</td>
      <td>UserSex</td>
      <td>UserAddress</td>
      <td>UserEmail</td>
      <td>UserPhoneNumber</td>
      <td>UserQQNum</td>
      <td>UserInfo</td>
      <td>ComplaintNum</td>
      </tr>
      <tr>
      <td class="style1">
          <asp:TextBox ID="tbUserName" runat="server" Width="76px"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserPass" runat="server" Width="74px"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserRealName" runat="server" Width="74px"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserAge" runat="server" Width="45px"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserSex" runat="server" Width="36px"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserAddress" runat="server" Width="99px"></asp:TextBox></td>
       <td>
           <asp:TextBox ID="tbUserEmail" runat="server" Width="62px"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserPhoneNumber" runat="server" Width="117px"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserQQNumber" runat="server" Width="101px"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserUserInfo" runat="server" Width="74px"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserComplaintNumber" runat="server" Width="95px"></asp:TextBox></td>
      </tr>
 <tr>
 <td> 
     <asp:Button ID="Btn" runat="server" Text="Add" onclick="Btn_Click" /> </td>
 </tr>
      </table>
      <table>
      <tr>
      <td>
          <asp:Button ID="BtnDelete" runat="server" Text="Delete" 
              onclick="BtnDelete_Click1" /> </td>
      <td> 
          <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
      </tr>
      </table>
    </div>
    </form>
</body>
</html>
