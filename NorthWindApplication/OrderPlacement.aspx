<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderPlacement.aspx.cs" Inherits="NorthWindApplication.OrderPlacement" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified" style="height: 170px">
        <tr>
            <td style="width: 255px; height: 32px">Select Product</td>
            <td style="height: 32px; width: 410px;">
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True">
                </asp:GridView>
                <asp:Button ID="Button4" runat="server" Text="Previous" />
                <asp:Button ID="Button3" runat="server" Text="Next" OnClick="Button3_Click" />
            </td>
            <td style="height: 32px">
                &nbsp;</td>
            <td style="height: 32px"></td>
        </tr>
        <tr>
            <td style="width: 255px">Enter Quantity</td>
            <td style="width: 410px">
                <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 255px; height: 20px">Enter Customer ID</td>
            <td style="height: 20px; width: 410px;">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 255px; height: 20px">Enter Employee ID</td>
            <td style="height: 20px; width: 410px;">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                </asp:GridView>
                <asp:Button ID="Button6" runat="server" Text="Previous" />
                <asp:Button ID="Button5" runat="server" Text="Next" OnClick="Button5_Click" />
            </td>
            <td style="height: 20px">
                &nbsp;</td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 255px">&nbsp;</td>
            <td style="width: 410px">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Place Order" Width="131px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 255px">&nbsp;</td>
            <td style="width: 410px">&nbsp;</td>
            <td>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back to Home" Width="131px" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
