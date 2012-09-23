<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackMain.aspx.cs" Inherits="PetCare.BackManage.BackMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="显示所有用户" />
                </td>
                <td>
                    &nbsp;</td>

            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="编号" SortExpression="ID" />
                            <asp:BoundField DataField="NAME" HeaderText="姓名" SortExpression="NAME" />
                            <asp:BoundField DataField="ID" HeaderText="编号" SortExpression="ID" />
                            <asp:BoundField DataField="ID" HeaderText="编号" SortExpression="ID" />
                            <asp:BoundField DataField="ID" HeaderText="编号" SortExpression="ID" />
                        </Columns>
 
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>

            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>

            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
