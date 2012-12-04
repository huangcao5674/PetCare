<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KnowledgeComment.aspx.cs" Inherits="PetCare.ManageMent.KnowledgeComment" %>

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
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
         </asp:DropDownList>
     </td>
     <td>
         <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" 
             Width="42px" />
                      <asp:Button ID="Button2" runat="server" Text="Back"  
             Width="42px" onclick="Button2_Click" />
     </td>
 
     </tr>
     <tr>
     <td colspan="2">
         <asp:GridView ID="GridView1" runat="server">
         </asp:GridView> </td>
     </tr>
     <tr>
     <td>评论内容</td>
     <td>
         <asp:TextBox ID="tb_Conetent" runat="server"></asp:TextBox> </td>
     </tr>
     <tr>
     <td>评论用户</td>
     <td>
         <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
         </asp:DropDownList>
         </td>
     </tr>
      <tr>
      <td>
          <asp:Button ID="Button3" runat="server" Text="Add" onclick="Button3_Click" /> </td>
      </tr>
     </table>
    </div>
    </form>
</body>
</html>
