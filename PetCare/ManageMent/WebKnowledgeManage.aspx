<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebKnowledgeManage.aspx.cs" Inherits="PetCare.ManageMent.WebKnowledgeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <style type="text/css">

        .style3
        {
            color: #003399;
            font-size: xx-large;
        }
        .style4
        {
            color: #003399;
            font-size: xx-large;
            font-family: 华文彩云;
        }
        .style5
        {
            color: #333399;
        }
        .style6
        {
            width: 246px;
        }
        .style7
        {
            width: 134px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table >
    <tr>
    <td colspan='5'><strong><span class="style4">宠物知识信息管理界面</span>
       </strong>
        </td>
    </tr>
    <tr>
    <td></td>
    </tr>
      <tr>
    <td colspan='5' class="style5"><strong style="font-size: 16pt">发布新宠物知识</strong></td>
    </tr>
    <tr>
    <td class="style5">
        <asp:Label ID="Label1" runat="server" Text="用户选择"></asp:Label></td>
 
    <td class="style2">
        <asp:Label ID="Label3" runat="server" Text="Address选择"></asp:Label></td>
    <td class="style2">
        <asp:Label ID="Label4" runat="server" Text="PetCategory选择"></asp:Label></td>
 
    <td class="style2">
        <asp:Label ID="Label6" runat="server" Text="KnowledgeTitle"></asp:Label></td>
    </tr>
    <tr>
    <td class="style6">
        <asp:DropDownList ID="dpUsers" runat="server" 
            AutoPostBack="True">
        </asp:DropDownList>
        </td>
 
    <td class="style3">
        <asp:DropDownList ID="dpAddress" runat="server"  
            AutoPostBack="True">
        </asp:DropDownList>
        </td>
    <td class="style3">
        <asp:DropDownList ID="dpCategory" runat="server" AutoPostBack="True" >
        </asp:DropDownList>
        </td>
    <td class="style3">
        <asp:TextBox ID="tbKnowLedgeTitle" runat="server" Width="146px"></asp:TextBox></td>
    </tr>

        <tr>
    <td colspan="4" class="style3">
        <asp:TextBox ID="tbContent" runat="server" Width="596px" Height="39px"></asp:TextBox></td>
    </tr>
    <tr>
    <td> 
        <asp:Button ID="BtnAdd" runat="server" Text="添加" onclick="BtnAdd_Click" 
            style="height: 21px" /> 
             </td>
    </tr>
    </table>
    <table>
    <tr>
    <td colspan='5' class="style5"><strong style="font-size: 16pt">
    管理网站领养内容</strong>
    </td>
    </tr>
    <tr>
    <td style="border: thin groove #008080"> 
        Address 
        <asp:DropDownList ID="ddlAddress" runat="server" AutoPostBack="True">
        </asp:DropDownList>  
    </td>
    <td style="border: thin groove #008080"> 
        Category <asp:DropDownList ID="ddlPetCategory" runat="server" AutoPostBack="True">
        </asp:DropDownList></td>
        <td>
        <asp:Button ID="BtnSearch" runat="server" Text="根据条件搜索" onclick="BtnSearch_Click" />
        </td>


    </tr>
    <tr>
    <td colspan='7'>
     <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="12pt"  BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" >
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="UserName" />
                            <asp:BoundField DataField="KnowledgeID" HeaderText="KnowledgeID" />
                            <asp:BoundField DataField="PetCategoryName" HeaderText="PetCategoryName" />
                            <asp:BoundField DataField="City" HeaderText="City" />
                            <asp:BoundField DataField="KnowledgeTitle" HeaderText="KnowledgeTitle" />
                            <asp:BoundField DataField="KnowledgeTime" HeaderText="KnowledgeTime" />
                            <asp:BoundField DataField="CommentCount" HeaderText="CommentCount" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066"  />


                        <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerSettings PageButtonCount="8" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </td>
    </tr>

     <tr>
        <td class="style7" > 第 
            <asp:DropDownList ID="ddPage" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            页</td>
        <td><asp:Button ID="BtnCheckData" runat="server" Text="分页检索" 
                onclick="BtnCheckData_Click"/></td>
        </tr>

    </table>

    </div>
    </form>
</body>
</html>
