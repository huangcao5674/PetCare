<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FocusManage.aspx.cs" Inherits="PetCare.ManageMent.FocusManage" %>

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
        <asp:DropDownList ID="dpUser" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </td>
    <td>
        <asp:Button ID="BtnCheck" runat="server" Text="Check" 
            onclick="BtnCheck_Click" Width="45px" />
            <asp:Button ID="BtnBack" runat="server" Text="Back" 
            Width="45px" onclick="BtnBack_Click" />
            </td>
    </tr>
    <tr>
    <td colspan="2"> 
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BorderStyle="Dotted">
            <Columns>
                <asp:BoundField DataField="articleTitle" HeaderText="文章标题" ReadOnly="True" 
                    SortExpression="articleTitle" />
                <asp:BoundField DataField="deployTime" HeaderText="发表时间" ReadOnly="True" 
                    SortExpression="deployTime" />
                <asp:BoundField DataField="aritcleInfo" HeaderText="文章内容" ReadOnly="True" 
                    SortExpression="aritcleInfo" />
            </Columns>
        </asp:GridView> </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
