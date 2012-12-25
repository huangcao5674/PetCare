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
     <td>
     <asp:GridView ID="GridViewUsers" runat="server" AllowSorting="True"
                        CellPadding="3" Font-Size="12pt"  BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
             AllowPaging="True" AutoGenerateColumns="False" 
             onpageindexchanging="GridViewUsers_PageIndexChanging"  >
             <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
         <Columns>
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:CheckBox ID="CheckBoxs" AutoPostBack="true" runat="server" />
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="UserID" HeaderText="UserID" />
             <asp:BoundField DataField="UserName" HeaderText="UserName" />
             <asp:BoundField DataField="UserRealName" HeaderText="UserRealName" />
             <asp:BoundField DataField="UserAge" HeaderText="UserAge" />
             <asp:BoundField DataField="UserSex" HeaderText="UserSex" />
             <asp:BoundField DataField="UserAddress" HeaderText="UserAddress" />
             <asp:BoundField DataField="UserEmail" HeaderText="UserEmail" />
             <asp:BoundField DataField="UserPhoneNumber" HeaderText="UserPhoneNumber" />
             <asp:BoundField DataField="UserQQNum" HeaderText="UserQQNum" />
             <asp:BoundField DataField="UserInfo" HeaderText="UserInfo" />
         </Columns>
           <HeaderStyle BackColor="#006699"  Font-Bold="True" ForeColor="White" />
     </asp:GridView>
     
     </td>
     </tr>
     <tr>
     <td> <asp:CheckBox ID="CheckBoxAll" runat="server" AutoPostBack="True" Font-Size="9pt"
                        Text="全选" oncheckedchanged="CheckBoxAll_CheckedChanged" />
            <asp:Button ID="BtnCancel" runat="server" Font-Size="12pt" Text="取消" 
            onclick="BtnCancel_Click"  />
            <asp:Button ID="Button1" runat="server" Font-Size="12pt" Text="删除" 
            onclick="BtnDelete_Click" />
            <asp:Button ID="BtnEdit" runat="server" Font-Size="12pt" Text="编辑" onclick="BtnEdit_Click1" 
            />
         <asp:Button ID="BtnSearch" runat="server" Text="搜索" Font-Size="12pt"  onclick="BtnSearch_Click" />
      </td>
     </tr>
     <tr>
     <td>
         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
     </tr>
    </table>
      <table>
      <tr >
     
      <td style="border: thin groove #FFFFFF;">UserName</td>
      <td style="border: thin groove #FFFFFF;">UserID</td>
      <td style="border: thin groove #FFFFFF;">UserRealName</td>
      <td style="border: thin groove #FFFFFF;">UserAge</td>
      <td style="border: thin groove #FFFFFF;">UserSex</td>
      <td style="border: thin groove #FFFFFF;">UserAddress</td>
 
      </tr>
      <tr>
      <td class="style1">
          <asp:TextBox ID="tbUserName" runat="server" Width="144px" BorderStyle="Dotted"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserId" runat="server" ReadOnly="true" Width="149px" BorderStyle="Dotted"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserRealName" runat="server" Width="147px" BorderStyle="Dotted"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserAge" runat="server" Width="145px" BorderStyle="Dotted"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserSex" runat="server" Width="147px" BorderStyle="Dotted"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserAddress" runat="server" Width="145px" BorderStyle="Dotted"></asp:TextBox></td>
          </tr>
          <tr>
               <td  style="border: thin groove #FFFFFF;">UserEmail</td>
      <td style="border: thin groove #FFFFFF;">UserPhoneNumber</td>
      <td style="border: thin groove #FFFFFF;">UserQQNum</td>
      <td style="border: thin groove #FFFFFF;">UserInfo</td>
      <td style="border: thin groove #FFFFFF;">ComplaintNum</td>
          </tr>
          <tr>
       <td>
           <asp:TextBox ID="tbUserEmail" runat="server" Width="145px" BorderStyle="Dotted"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserPhoneNumber" runat="server" Width="147px" BorderStyle="Dotted"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserQQNumber" runat="server" Width="144px" BorderStyle="Dotted"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserUserInfo" runat="server" Width="147px" BorderStyle="Dotted"></asp:TextBox></td>
      <td>
          <asp:TextBox ID="tbUserComplaintNumber" runat="server" Width="146px" BorderStyle="Dotted"></asp:TextBox></td>
      </tr>
      <tr>
        <td style="border: thin groove #FFFFFF;">IsUsed</td>
        <td style="border: thin groove #FFFFFF;">UserWeiBo</td>
        <td style="border: thin groove #FFFFFF;">Portrait</td>
        <td style="border: thin groove #FFFFFF;">UserLevel</td>
        <td style="border: thin groove #FFFFFF;">CreateTime</td>
        <td style="border: thin groove #FFFFFF;">ModifyTime</td>

      </tr>
      <tr>
        <td><asp:TextBox ID="tbIsUsed" runat="server" BorderStyle="Dotted"></asp:TextBox> </td>
        <td><asp:TextBox ID="tbUserWeiBo" runat="server" BorderStyle="Dotted"></asp:TextBox> </td>
        <td><asp:TextBox ID="tbPortrait" runat="server" BorderStyle="Dotted"></asp:TextBox></td>
        <td><asp:TextBox ID="tbUserLevel" runat="server" BorderStyle="Dotted"></asp:TextBox></td>
        <td><asp:TextBox ID="tbCreateTime" runat="server" BorderStyle="Dotted"></asp:TextBox></td>
        <td><asp:TextBox ID="tbModifyTime" runat="server" BorderStyle="Dotted"></asp:TextBox></td>
        
      </tr>
      <tr>
              <td style="border: thin groove #FFFFFF;">RoldID</td>
        <td style="border: thin groove #FFFFFF;">LastLoginTime</td>
        <td style="border: thin groove #FFFFFF;">LoginTimes</td>
      </tr>
      <tr>
      <td><asp:TextBox ID="tbRoldID" runat="server" BorderStyle="Dotted"></asp:TextBox></td>
        <td><asp:TextBox ID="tbLastLoginTime" runat="server" BorderStyle="Dotted"></asp:TextBox></td>
        <td><asp:TextBox ID="tbLoginTimes" runat="server" BorderStyle="Dotted"></asp:TextBox></td>
      </tr>
 <tr>
 <td> 
     <asp:Button ID="Btn" runat="server" Text="Add" onclick="Btn_Click" /> </td>
     <td><asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click" /></td>
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
