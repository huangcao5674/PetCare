<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMissedPetCommentManage.aspx.cs" Inherits="PetCare.ManageMent.WebMissedPetCommentManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
            color: #0000CC;
            font-family: 华文彩云;
        }
        .style2
        {
            color: #006666;
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <table>
                   <tr>
    <td colspan='7' class="style1"><strong>宠物丢失评论管理界面</strong></td>
    </tr>
        <tr>
    <td class="style3"></td>
    </tr>
    <tr>
    <td class="style2"  colspan='6'><strong>添加宠物丢失评论</strong></td>
    </tr>
    <tr>
     <td >宠物丢失文章名称</td>
    <td>  
        <asp:DropDownList ID="ddMissList" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </td>
    <td class="style4">评论用户选择</td>
    <td>
        <asp:DropDownList ID="ddUserList" runat="server" AutoPostBack="True">
        </asp:DropDownList> </td>
    <td class="style5" >评论信息 </td>
    <td> 
        <asp:TextBox ID="tbComment" runat="server"></asp:TextBox> </td>
        <td>
            <asp:Button ID="BtnAddComment" runat="server" Text="添加评论" 
                onclick="BtnAddComment_Click" /> </td>
    </tr>
    </tr>

    <tr>
    <td class="style3"></td>
    </tr>

    <tr>
    <td class="style3"></td>
    </tr>
    </table>

<table>
       <tr>
  <td colspan='6' class="style2"><strong>宠物知识评论管理</strong></td>
  </tr>
         <tr>
          <td class="style3">
        <asp:Button ID="BtnComment" runat="server" Text="查看一篇文章评论" onclick="BtnComment_Click" 
              /></td>
        <td>
        文章列表<asp:DropDownList ID="ddKnowledgeManageList" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        </td>
        <td class="style4">
            &nbsp;</td>
         </tr>

    <tr>
    <td colspan='7'></td></tr>
<tr>
<td colspan='8'>
<asp:GridView ID="GridView1" runat="server" AllowSorting="True"
                        CellPadding="3" Font-Size="12pt"  BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        Width="758px" AutoGenerateColumns="False">      
             <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox" runat="server" AutoPostBack="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MissTitle" HeaderText="MissTitle" />
                        <asp:BoundField DataField="MissTime" HeaderText="MissTime" />
                        <asp:BoundField DataField="UserName" HeaderText="UserName" 
                            SortExpression="UserName" />
                        <asp:BoundField DataField="CommentTime" HeaderText="CommentTime" 
                            SortExpression="CommentTime" />
                        <asp:BoundField DataField="CommentContent" HeaderText="CommentContent" />
                        <asp:BoundField DataField="CommentIP" HeaderText="CommentIP" 
                            SortExpression="CommentIP" />
                        <asp:BoundField DataField="CommentUserName" HeaderText="CommentUserName" 
                            SortExpression="CommentUserName" />
                    </Columns>
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
</td>
</tr>
        <tr>
        <td>第<asp:DropDownList ID="ddPages" runat="server">
            </asp:DropDownList>页</td>
        <td>
            <asp:Button ID="BtnView" runat="server" Text="查看" onclick="BtnView_Click" /></td>
        </tr>
    <tr>
        <td >
            <asp:CheckBox ID="CheckBoxAll" runat="server" AutoPostBack="True" Font-Size="9pt"
                        Text="全选" oncheckedchanged="CheckBoxAll_CheckedChanged1"   /></td>
        <td>
            <asp:Button ID="BtnCancel" runat="server" Font-Size="12pt" Text="取消" onclick="BtnCancel_Click1" 
              /></td>
        <td  >
            <asp:Button ID="BtnDelete" runat="server" Font-Size="12pt" Text="删除" onclick="BtnDelete_Click1" 
            /></td>
        <td>
               <asp:Button ID="BtnEdit" runat="server" Font-Size="12pt" Text="编辑" onclick="BtnEdit_Click"   
            /></td>
            </tr>
            </table>
              <table>
            <tr>
            <td> MissID</td>
            <td> 
                <asp:TextBox ID="tbMissID" runat="server"></asp:TextBox></td>
            <td> CommentID</td>
            <td> 
                <asp:TextBox ID="tbCommentID" runat="server"></asp:TextBox></td>
                <td>CommentTime </td>
                <td> 
                    <asp:TextBox ID="tbCommentTime" runat="server"></asp:TextBox></td>
            </tr>
            <tr> 
            <td>
            UserID
            </td>
            <td>
                <asp:TextBox ID="tbUserID" runat="server"></asp:TextBox>
            </td>
            <td>
            IP
            </td>
            <td>
                <asp:TextBox ID="tbIP" runat="server"></asp:TextBox> </td>
                <td>
                IsVisible
                </td>
                <td>
                    <asp:CheckBox ID="cbIsVisible" Text="Visible" runat="server" />
                </td>
            </tr>
            <tr>
            <td>Content</td>
            <td colspan='3'>
                <asp:TextBox ID="tbContent" runat="server" Width="374px"></asp:TextBox> </td>
            <td>
                <asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click" /> </td>
            </tr>
            
            
            </table>
    </div>
    </form>
</body>
</html>
