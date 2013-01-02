<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebAdoptCommentManage.aspx.cs" Inherits="PetCare.ManageMent.WebAdoptCommentManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
            font-family: 华文彩云;
            color: #0000FF;
        }
        .style2
        {
            font-size: x-large;
            font-family: 华文细黑;
            color: #006666;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
      <tr>
    <td colspan='7' class="style1"><strong>领养宠物评论管理界面</strong></td>
    </tr>
        <tr>
    <td></td>
    </tr>
    <tr>
    <td class="style2"  colspan='6'><strong>添加宠物领养评论</strong></td>
    </tr>
      <tr>
    <td>领养文章名称</td>
    <td>  
        <asp:DropDownList ID="ddAdopt1" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </td>
    <td>评论用户选择</td>
    <td>
        <asp:DropDownList ID="ddUser11" runat="server" AutoPostBack="True">
        </asp:DropDownList> </td>
    <td>评论信息 </td>
    <td> 
        <asp:TextBox ID="TextBoxComment" runat="server"></asp:TextBox> </td>
        <td>
            <asp:Button ID="BtnAddComment" runat="server" Text="添加评论" 
                onclick="BtnAddComment_Click" /> </td>
    </tr>
  <tr>
  <td></td>
  </tr>

    <tr>
  <td></td>
  </tr>

    <tr>
  <td colspan='6' class="style2"><strong>宠物领养评论信息</strong></td>
  </tr>

    <tr>
    <td>PageNumber</td>
    <td>
        <asp:TextBox ID="TextBoxPageNumber" runat="server"></asp:TextBox></td>
        <td>领养文章</td>
    <td> 
        <asp:DropDownList ID="ddAdopt" runat="server" AutoPostBack="True">
        </asp:DropDownList> </td>
    <td> 
        <asp:Button ID="BtnChekc" runat="server" Text="Search" 
            onclick="BtnChekc_Click" /></td>
    </tr>
    <tr >
    <td colspan="7">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True"
                        CellPadding="3" Font-Size="12pt"  BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" 
             >      
             <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AdoptTitle" HeaderText="AdoptTitle" />
                        <asp:BoundField DataField="AdoptTime" HeaderText="AdoptTime" />
                        <asp:BoundField DataField="PriorityScore" HeaderText="PriorityScore" />
                        <asp:BoundField DataField="PetCategoryName" HeaderText="PetCategoryName" />
                        <asp:BoundField DataField="City" HeaderText="City" />
                        <asp:BoundField DataField="CommentContent" HeaderText="CommentContent" />
                        <asp:BoundField DataField="CommentTime" HeaderText="CommentTime" />
                        <asp:BoundField DataField="CommentIP" HeaderText="CommentIP" />
                    </Columns>
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        </asp:GridView></td>
           </tr>
    </table>
        <asp:CheckBox ID="CheckBoxAll" runat="server" AutoPostBack="True" Font-Size="9pt"
                        Text="全选" oncheckedchanged="CheckBoxAll_CheckedChanged" />
            <asp:Button ID="BtnCancel" runat="server" Font-Size="12pt" Text="取消" 
            onclick="BtnCancel_Click"  />
            <asp:Button ID="BtnDelete" runat="server" Font-Size="12pt" Text="删除" 
            onclick="BtnDelete_Click" />
            <asp:Button ID="BtnEdit" runat="server" Font-Size="12pt" Text="编辑" onclick="BtnEdit_Click1" 
            />
 
    </div>
    </form>
</body>
</html>
