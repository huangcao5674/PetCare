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
    <form id="form1" runat="server" ondblclick="return form1_ondblclick()">
    <div>
    <table>
    <tr>
    <td>当前用户</td>
    <td>
        <asp:Label ID="Label1" runat="server"  ></asp:Label>
    </td>
    <td>
    <asp:Button ID="BtnLogOff" runat="server" Text="登出" onclick="BtnLogOff_Click" />
    </td>
    </tr>
    <tr>
    <td> 
        Address</td>
    <td>
        <asp:DropDownList ID="ddlAddress" runat="server" AutoPostBack="True">
        </asp:DropDownList>  
    </td>
    <td> 
        Category <asp:DropDownList ID="ddlPetCategory" runat="server" AutoPostBack="True">
        </asp:DropDownList></td>
    <td>
        <asp:CheckBox ID="ckIsAdopt" Text="IsAdopt" runat="server" />
         </td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="查看" onclick="Button1_Click" />  </td>

    </tr>
    <tr>
            <td>
            <asp:DropDownList ID="ddPages" runat="server" AutoPostBack="True">
            </asp:DropDownList>  </td>
        <td>
            <asp:Button ID="BtnLook" runat="server" Text="查看" onclick="BtnLook_Click" />
            </td>
       <td>
           <asp:Button ID="BtnNull" runat="server" Text="清空" onclick="BtnNull_Click" /> 
               </td>
 
    </tr>
    <tr>
    <td colspan='9'>
         <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="12pt"  BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
             >            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AdoptID" HeaderText="AdoptID" />
                 <asp:BoundField DataField="Province" HeaderText="Province" />
                 <asp:BoundField DataField="City" HeaderText="City" />
                 <asp:BoundField DataField="PetCategoryName" HeaderText="PetCategoryName" />
                <asp:BoundField DataField="AdoptTitle" HeaderText="AdoptTitle"/>
                <asp:BoundField DataField="UserName" HeaderText="UserName" />
                <asp:BoundField DataField="AdoptTime" HeaderText="AdoptTime" />
                <asp:BoundField DataField="LastEditTime" HeaderText="LastEditTime" />
                <asp:BoundField DataField="IP" HeaderText="IP" SortExpression="IP"/>
                <asp:BoundField DataField="IsAdopt" HeaderText="IsAdopt"/>
            </Columns>
        <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />

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
