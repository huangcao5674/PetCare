<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMissedPetManage.aspx.cs" Inherits="PetCare.ManageMent.WebMissedPetManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <style type="text/css">
        #TextArea1
        {
            width: 518px;
            height: 81px;
        }
        .style2
        {
            font-size: x-large;
            font-family: 华文彩云;
        }
        .style3
        {
            color: #003399;
            font-size: xx-large;
        }
        .style4
        {
            width: 82px;
        }
        .style5
        {
            width: 44px;
        }
        .style6
        {
            font-family: 黑体;
            font-size: 18pt;
            color: #333399;
        }
        </style>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table>
       <tr>
       <td colspan='10' style="color:Red;" class="style2">
           <strong><span class="style3">宠物丢失信息管理界面</span>
       </strong>
       </td>
       </tr>
       <tr><td class="style4"></td></tr>
       <tr><td  colspan='4' class="style6"><strong style="font-size: 16pt">发布新丢失内容</strong></td></tr>
    <tr>
     <td class="style4"> 
            <asp:Label ID="Label8" runat="server" Text="用户选择"></asp:Label></td>
        <td class="style5">
            <asp:DropDownList ID="ddlUser" runat="server">
            </asp:DropDownList> </td>
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
        <asp:Label ID="Label7" runat="server" Text="Title"></asp:Label> </td>
    <td>
        <asp:TextBox ID="tbTitle" runat="server" Width="105px"></asp:TextBox>
    </td>
    <td>&nbsp;</td>
    </tr>
    <tr>
    <td colspan="10"> 
       
        <asp:TextBox ID="tbContent" runat="server" Height="40px" TextMode="MultiLine" 
            Width="690px"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td><asp:Button ID="BtnAdd" runat="server" Text="发布新文章" onclick="BtnAdd_Click" 
            Width="76px" /></td>
    </tr>
    </table>


    <table>
    <tr>
    <td  colspan='4' class="style6"><strong style="font-size: 16pt">管理网站丢失内容</strong></td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>
    <tr>
    <td style="border: thin groove #008080"> 
        Address 
        <asp:DropDownList ID="ddlAddress" runat="server" AutoPostBack="True">
        </asp:DropDownList>  
    </td>
    <td style="border: thin groove #008080"> 
        Category <asp:DropDownList ID="ddlPetCategory" runat="server" AutoPostBack="True">
        </asp:DropDownList></td>
    <td style="border: thin groove #008080">
            <asp:Button ID="Button1" runat="server" Text="根据条件搜索" onclick="BtnSearch_Click" />  
         </td>
        <td>
            &nbsp;</td>

    </tr>
    <tr>
    <td colspan='9'>
         <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="12pt"  BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
             >            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxs" runat="server" AutoPostBack="true" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MissID" HeaderText="MissID" />
                 <asp:BoundField DataField="Province" HeaderText="Province" />
                 <asp:BoundField DataField="City" HeaderText="City" />
                 <asp:BoundField DataField="PetCategoryName" HeaderText="PetCategoryName" />
                <asp:BoundField DataField="MissTitle" HeaderText="MissTitle"/>
                <asp:BoundField DataField="UserName" HeaderText="UserName" />
                <asp:BoundField DataField="MissTime" HeaderText="MissTime" />
                <asp:BoundField DataField="LastEditTime" HeaderText="LastEditTime" />
                <asp:BoundField DataField="IP" HeaderText="IP" SortExpression="IP"/>
            </Columns>
        <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />

        </asp:GridView>
    </td>
    </tr>
    <tr> <td>
            第<asp:DropDownList ID="ddPages" runat="server" AutoPostBack="True">
            </asp:DropDownList> 页</td> 
             <td>
            <asp:Button ID="BtnLook" runat="server" Text="查看选定页" onclick="BtnLook_Click" 
                     Width="76px" />
            </td>
               <td>
           <asp:Button ID="BtnNull" runat="server" Text="清空数据信息" onclick="BtnNull_Click" /> 
               </td>
             </tr>
    </table>
    <table>
       <tr>
             <td> 
                 <asp:CheckBox ID="cb_SelectAll" Text="全选" runat="server" 
                     oncheckedchanged="cb_SelectAll_CheckedChanged" /> </td>
             <td> 
                 <asp:Button ID="BtnDelete" runat="server" Text="删除" onclick="BtnDelete_Click" /> </td>
             <td> 
                 <asp:Button ID="BtnEdit" runat="server" Text="编辑" onclick="BtnEdit_Click" /> </td>
             </tr>
                          <tr>
             <td>MissID<asp:TextBox ID="TextBox_MissID" runat="server"></asp:TextBox> </td>
             <td>UserID<asp:TextBox ID="TextBox_UserID" runat="server"></asp:TextBox> </td>
             <td>AddressID<asp:TextBox ID="TextBox_AddressID" runat="server"></asp:TextBox></td>
             <td>PetCategoryID<asp:TextBox ID="TextBox_PetCategoryID" runat="server"></asp:TextBox></td>
             <td>WeiBoID<asp:TextBox ID="TextBox_WeiBoID" runat="server"></asp:TextBox></td>
             
             </tr>
             <tr>
             <td>MissIDTitle<asp:TextBox ID="TextBox_MissIDTitle" runat="server"></asp:TextBox> </td>
             <td>MissIDTime<asp:TextBox ID="TextBox_MissIDTime" runat="server"></asp:TextBox> </td>
             <td> IP<asp:TextBox ID="TextBox_IP" runat="server"></asp:TextBox> </td>
             <td> PriorityScore<asp:TextBox ID="TextBox_PriorityScore" runat="server"></asp:TextBox> </td>
             <td> FocusNum<asp:TextBox ID="TextBox_FocusNum" runat="server"></asp:TextBox> </td>
             <td>  
                 <asp:CheckBox ID="cb_IsVisible" Text="IsVisible" runat="server" /></td>
             </tr>
             <tr>
             <td colspan='6'>MissIDInfo<asp:TextBox ID="TextBox_MissIDInfo" runat="server" Width="563px"></asp:TextBox> 
                 <asp:Button ID="Btn_Save" runat="server" Text="Save" onclick="Btn_Save_Click" /></td>
             </tr>
    </table>
    </div>
    </form>
</body>
</html>
