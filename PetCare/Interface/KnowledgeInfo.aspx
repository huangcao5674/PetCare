<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KnowledgeInfo.aspx.cs" Inherits="PetCare.Interface.KnowledgeInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 364px;
            width: 715px;
        }
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
        <asp:Button ID="Button3" runat="server" Text="Button" onclick="Button3_Click" />
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
        <tr>
    <td class="style1">
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns=false>
                    <Columns>
                <asp:BoundField DataField="KnowledgeTitle" HeaderText="标题" ReadOnly="True" 
                    SortExpression="KnowledgeTitle" />
                <asp:BoundField DataField="KnowledgeTime" HeaderText="时间" ReadOnly="True" 
                    SortExpression="KnowledgeTime" />
                <asp:BoundField DataField="IP" HeaderText="IP" ReadOnly="True" 
                    SortExpression="IP" />
                <asp:BoundField DataField="KnowledgeInfo" HeaderText="内容" ReadOnly="True"
                    SortExpression="KnowledgeInfo" />
            </Columns>
        </asp:GridView>
        </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
