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
        .style1
        {
            width: 139px;
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
        Category</td>
    <td class="style1">
        <asp:DropDownList ID="ddlPetCategory" runat="server" AutoPostBack="True">
        </asp:DropDownList> </td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="查看" onclick="Button1_Click" />  </td>

    </tr>
    <tr>
            <td>
            <asp:Label ID="Label3" runat="server" Text="PageNumber"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="102px"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="PerPage"></asp:Label> </td>
        <td class="style1">
            <asp:TextBox ID="TextBox2" runat="server" Width="102px"></asp:TextBox></td>
       <td>
           <asp:Button ID="BtnSearch" runat="server" Text="查看" 
               onclick="BtnSearch_Click" Width="46px" />
           <asp:Button ID="BtnNull" runat="server" Text="清空" onclick="BtnNull_Click" /> 
               </td>
 
    </tr>
    <tr>
    <td colspan='9'>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="AdoptID" HeaderText="AdoptID" />
                <asp:BoundField DataField="AdoptTitle" HeaderText="AdoptTitle"/>
                <asp:BoundField DataField="UserName" HeaderText="UserName" />
                <asp:BoundField DataField="AdoptTime" HeaderText="AdoptTime" />
                <asp:BoundField DataField="LastEditTime" HeaderText="LastEditTime" />
                <asp:BoundField DataField="IP" HeaderText="IP" SortExpression="IP"/>
                <asp:BoundField DataField="IsAdopt" HeaderText="IsAdopt"/>
                <asp:CommandField HeaderText="选择" ShowSelectButton="True" />
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            </Columns>
             <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
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
    <tr>
    <td colspan=9>000000000000000000000000下面是评论相关的00000000000000000000000000000000000</td>
    </tr>
    <tr>
    <td>AdoptID</td>
    <td>  
        <asp:DropDownList ID="ddAdopt1" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </td>
    <td>User</td>
    <td>
        <asp:DropDownList ID="ddUser11" runat="server" AutoPostBack="True">
        </asp:DropDownList> </td>
    <td>评论 </td>
    <td> 
        <asp:TextBox ID="TextBoxComment" runat="server"></asp:TextBox> </td>
        <td>
            <asp:Button ID="BtnAddComment" runat="server" Text="添加评论" 
                onclick="BtnAddComment_Click" /> </td>
    </tr>
 

    <tr>
    <td>PageNumber</td>
    <td>
        <asp:TextBox ID="TextBoxPageNumber" runat="server"></asp:TextBox></td>
    
    <td>PerPage</td>
    <td>
        <asp:TextBox ID="TextBoxPerPage" runat="server"></asp:TextBox> </td>
        <td>AdoptID</td>
    <td> 
        <asp:DropDownList ID="ddAdopt" runat="server" AutoPostBack="True">
        </asp:DropDownList> </td>
    <td> 
        <asp:Button ID="BtnChekc" runat="server" Text="Search" 
            onclick="BtnChekc_Click" /></td>
    </tr>
    <tr >
    <td colspan="7">
        <asp:GridView ID="GridView2" runat="server" Width="625px">
        </asp:GridView></td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
