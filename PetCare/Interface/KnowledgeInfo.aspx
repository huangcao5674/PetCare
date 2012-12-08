<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KnowledgeInfo.aspx.cs" Inherits="PetCare.Interface.KnowledgeInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            width: 715px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table >
    <tr>

    <td class="style3">
        <asp:Button ID="Button3" runat="server" Text="分页检索" onclick="Button3_Click" />
        PageNumb:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        PerPage:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="根据用户检索" onclick="Button1_Click" />
        <asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Text="查看一篇文章评论" 
            onclick="Button4_Click" />
        文章列表<asp:DropDownList ID="ddAdoptList" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        PageNumb<asp:TextBox ID="TextBox4" runat="server" Width="85px"></asp:TextBox>
        PerPage<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <asp:GridView ID="GridView1"  runat="server" Width="900px" 
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="KnowledgeTitle" HeaderText="标题" ReadOnly="True" 
                    SortExpression="KnowledgeTitle" >
                <ControlStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="KnowledgeTime" HeaderText="时间" ReadOnly="True" 
                    SortExpression="KnowledgeTime" >
                <ControlStyle BorderWidth="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="IP" HeaderText="IP" ReadOnly="True" 
                    SortExpression="IP" >
                <ControlStyle BorderWidth="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="KnowledgeInfo" HeaderText="内容" ReadOnly="True"
                    SortExpression="KnowledgeInfo" >
                <ControlStyle BorderWidth="650px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
