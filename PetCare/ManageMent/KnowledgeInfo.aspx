<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KnowledgeInfo.aspx.cs" Inherits="PetCare.Interface.KnowledgeInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            width: 414px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table >
    <tr>
  
  
        <td>
            aa<asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        aa</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <tr>
        <td colspan='5'>
         <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="12pt"  BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            Height="404px" Width="806px">
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
        <td class="style3"> 第 
            <asp:DropDownList ID="ddPage" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            页</td>
        <td><asp:Button ID="Button3" runat="server" Text="分页检索" onclick="Button3_Click" />
        </tr>
        
        </table>
    </div>
    </form>
</body>
</html>
