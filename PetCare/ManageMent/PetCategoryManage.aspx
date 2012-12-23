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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="petCaregoryID" HeaderText="PetCategoryID" >
                <HeaderStyle BorderStyle="Dotted" />
                <ItemStyle BorderStyle="Dotted" />
                </asp:BoundField>
                <asp:BoundField DataField="petCategoryName" HeaderText="PetCategoryName" >
                <HeaderStyle BorderStyle="Dotted" />
                <ItemStyle BorderStyle="Dotted" />
                </asp:BoundField>
                <asp:BoundField DataField="petCategoryInfo" HeaderText="PetCategoryInfo" >
                <HeaderStyle BorderStyle="Dotted" />
                <ItemStyle BorderStyle="Dotted" />
                </asp:BoundField>
                <asp:BoundField DataField="IsVisible" HeaderText="IsVisible" >
                <HeaderStyle BorderStyle="Dotted" />
                <ItemStyle BorderStyle="Dotted" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
