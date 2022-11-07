<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentTable.aspx.cs" Inherits="WebRole1.StudentTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: x-large;
        }
        .style2
        {
            font-size: x-large;
            width: 273px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="style1">
            <strong>СПИСОК СТУДЕНТІВ:</strong>

        </div>
        <br />
        <br />

        <table style="width:76%;">
            <tr>
                <td class="style2">
                    <asp:Label ID="Label3" runat="server" Text="№ студентського білету:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Num" runat="server" Width="171px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="Прізвище:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Fam" runat="server" Width="171px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;Ім'я:
                </td>
                <td>
                    <asp:TextBox ID="Im" runat="server" Width="171px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    По-батькові:</td>
                <td>
                    <asp:TextBox ID="Ot" runat="server" Width="171px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Факультет:
                </td>
                <td>
                    <asp:TextBox ID="Fak" runat="server" Width="171px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                     Форма навчання:</td>
                <td>
                    <asp:TextBox ID="Forma" runat="server" Width="171px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Button ID="AddStud" runat="server" onclick="Button1_Click"  Text="Додати студента" />
                </td>
                <td class="style2">
                    <asp:Button ID="btnChange" runat="server" onclick="btnChange_Click"  Text="Змінити" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Lb_Status" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
        </table>

        <asp:GridView   ID="StudentGV" runat="server" CellPadding="4" 
                        ForeColor="#333333" GridLines="None" onrowdeleting="StudentGV_RowDeleting" 
                        onselectedindexchanged="StudentGV_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="Змінити"  ShowSelectButton="True" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
            </Columns>

            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>


    </form>
</body>
</html>
