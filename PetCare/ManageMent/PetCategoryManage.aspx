<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PetCategoryManage.aspx.cs" Inherits="PetCare.ManageMent.PetCategoryManage" %>

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
       <td>欢迎：</td>
       <td>
           <asp:Label ID="LabelUserName" runat="server" Text=""></asp:Label> </td>
    </tr>
    <tr>
    <td> PetCategoryID</td>
      <td>
          <asp:TextBox ID="tbPetCategoryID" runat="server" Width="97px"></asp:TextBox> </td>
       <td>PetCategoryName</td>
       <td>
           <asp:TextBox ID="tbCategoryName" runat="server" Width="106px"></asp:TextBox></td>
            <td>PetCategoryInfo</td>
            <td>
                <asp:TextBox ID="tbCategoryInfo" runat="server" Width="101px"></asp:TextBox>
           </td>
           <td>
               <asp:Button ID="BtnAdd" runat="server" Text="BtnAdd" onclick="BtnAdd_Click" /> </td>
    </tr>
    </table>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="12pt"  BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging"  
             >
                        <FooterStyle BackColor="White" ForeColor="#000066"  />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxs" AutoPostBack="true"   runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="petCategoryID" HeaderText="PetCategoryID" >
                </asp:BoundField>
                <asp:BoundField DataField="petCategoryName" HeaderText="PetCategoryName" >
                </asp:BoundField>
                <asp:BoundField DataField="petCategoryInfo" HeaderText="PetCategoryInfo" >
                </asp:BoundField>
                <asp:BoundField DataField="IsVisible" HeaderText="IsVisible" >
                </asp:BoundField>
            </Columns>
             <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerSettings PageButtonCount="8" />
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
    <td>PetCategoryID</td>
    <td> 
        <asp:TextBox ID="tbEditPetCategoryID" runat="server" Width="83px"></asp:TextBox></td>
    <td>PetCategoryName</td>
    <td> 
        <asp:TextBox ID="tbEditPetCategoryName" runat="server" Width="107px"></asp:TextBox></td>
     
        <td>
          PetCategoryInfo
        </td>
        <td>
            <asp:TextBox ID="tbEditPetCategoryInfo" runat="server" Width="99px"></asp:TextBox>
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
