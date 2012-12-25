<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaAddressManage.aspx.cs" Inherits="PetCare.ManageMent.AreaAddressManage" %>

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
    <td>省 </td>
    <td> 
        <asp:TextBox ID="tbProvince" runat="server" Width="83px"></asp:TextBox></td>
    <td>市</td>
    <td> 
        <asp:TextBox ID="tbArea" runat="server" Width="107px"></asp:TextBox></td>
     
        <td>
          邮编
        </td>
        <td>
            <asp:TextBox ID="tbPostCode" runat="server" Width="119px"></asp:TextBox>
        </td>
        <td>
        <asp:Button ID="Button1" runat="server" Text="Add" onclick="BtnAdd_Click" /> </td>
    </tr>


    </table>

        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="12pt"  BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging" 
             >
                        <EmptyDataTemplate>
                            <asp:Label ID="Label1" runat="server" Text="AddressID"></asp:Label>
                           
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="White" ForeColor="#000066"  />
            <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBoxs" AutoPostBack="true"   runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField="AddressID" HeaderText="AddressID" />
                <asp:BoundField DataField="Province" HeaderText="Province" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="FatherID" HeaderText="FatherID" />
                <asp:BoundField DataField="IsVisible" HeaderText="IsVisible" />
            </Columns>
             <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerSettings PageButtonCount="6" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
          <asp:CheckBox ID="CheckBoxAll" runat="server" AutoPostBack="True" Font-Size="9pt"
                        Text="全选" oncheckedchanged="CheckBoxAll_CheckedChanged" />
            <asp:Button ID="BtnCancel" runat="server" Font-Size="12pt" Text="取消" 
            onclick="BtnCancel_Click"  />
            <asp:Button ID="BtnDelete" runat="server" Font-Size="12pt" Text="删除" 
            onclick="BtnDelete_Click" />
            <asp:Button ID="BtnEdit" runat="server" Font-Size="12pt" Text="编辑" onclick="BtnEdit_Click1" 
            />
            <table>
    <tr>
    <td>省 </td>
    <td> 
        <asp:TextBox ID="tbEditProvince" runat="server" Width="83px"></asp:TextBox></td>
    <td>市</td>
    <td> 
        <asp:TextBox ID="tbEditCity" runat="server" Width="107px"></asp:TextBox></td>
     
        <td>
          邮编
        </td>
        <td>
            <asp:TextBox ID="tbEditPostCode" runat="server" Width="99px"></asp:TextBox>
        </td>
 
        <td> 
            <asp:CheckBox ID="cbIsvisible" Text="Visible" runat="server" /></td>
        <td>
        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" /> </td>
    </tr>


    </table>

    </div>
    </form>
</body>
</html>
