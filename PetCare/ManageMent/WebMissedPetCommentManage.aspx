<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMissedPetCommentManage.aspx.cs" Inherits="PetCare.ManageMent.WebMissedPetCommentManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<asp:GridView ID="GridView1" runat="server" AllowSorting="True"
                        CellPadding="3" Font-Size="12pt"  BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">      
             <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
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
    </div>
    </form>
</body>
</html>
