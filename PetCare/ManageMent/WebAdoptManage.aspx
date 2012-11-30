<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebAdoptManage.aspx.cs" Inherits="PetCare.ManageMent.WebAdoptManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1
        {
            width: 518px;
            height: 81px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td> 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
    <td>
        <asp:DropDownList ID="ddlAddress" runat="server" AutoPostBack="True">
        </asp:DropDownList>  
    </td>
    <td> 
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
    <td>
        <asp:DropDownList ID="ddlPetCategory" runat="server" AutoPostBack="True">
        </asp:DropDownList> </td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label> </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
       <td>
           <asp:Button ID="BtnSearch" runat="server" Text="Search" 
               onclick="BtnSearch_Click" /></td>
    </tr>
    <tr>
    <td colspan='9'>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="AdoptID" HeaderText="AdoptID" />
                <asp:BoundField DataField="AdoptTitle" HeaderText="AdoptTitle">
                <ControlStyle BorderStyle="Dotted" />
                </asp:BoundField>
                <asp:BoundField DataField="AdoptTime" HeaderText="AdoptTime" 
                    SortExpression="AdoptTime">
                <ItemStyle BorderStyle="Dotted" />
                </asp:BoundField>
                <asp:BoundField DataField="LastEditTime" HeaderText="LastEditTime" 
                    SortExpression="LastEditTime">
                <ControlStyle BorderStyle="Dotted" />
                </asp:BoundField>
                <asp:BoundField DataField="IP" HeaderText="IP" SortExpression="IP">
                <ControlStyle BorderStyle="Dashed" />
                </asp:BoundField>
                <asp:BoundField DataField="IsAdopt" HeaderText="IsAdopt" 
                    SortExpression="IsAdopt" />
                <asp:TemplateField>
                  <ItemTemplate>
                  <asp:HyperLink runat="server" Text="View Adopt"></asp:HyperLink>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </td>
    </tr>
    </table>
    <table>
    <tr>
    <td> 
        <asp:Label ID="Label5" runat="server" Text="Address"></asp:Label></td>
    <td>
        <asp:DropDownList ID="ddlAddressAdd" runat="server" AutoPostBack="True">
        </asp:DropDownList>  </td>
    <td> 
        <asp:Label ID="Label6" runat="server" Text="Category"></asp:Label></td>
    <td>
        <asp:DropDownList ID="ddlCategoryAdd" runat="server" AutoPostBack="True">
        </asp:DropDownList> </td>
        <td> 
            <asp:Label ID="Label8" runat="server" Text="用户"></asp:Label></td>
        <td>
            <asp:DropDownList ID="ddlUser" runat="server">
            </asp:DropDownList> </td>
    <td>
        <asp:Label ID="Label7" runat="server" Text="Title"></asp:Label> </td>
    <td>
        <asp:TextBox ID="tbTitle" runat="server" Width="105px"></asp:TextBox>
    </td>
    <td><asp:CheckBox ID="CheckBox1" runat="server" Text="IsAdopt" /> </td>
    <td> 
        <asp:Button ID="BtnAdd" runat="server" Text="Add" onclick="BtnAdd_Click" /></td>
    </tr>
    <tr>
    <td colspan="7"> 
       
        <asp:TextBox ID="tbContent" runat="server" Height="40px" TextMode="MultiLine" 
            Width="495px"></asp:TextBox>
       
        </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
