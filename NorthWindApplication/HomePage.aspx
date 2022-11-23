<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="NorthWindApplication.HomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <table class="nav-justified" style="width: 75%; height: 199px; margin-top: 13px">
    <tr>
        <td draggable="false" style="height: 20px; width: 276px">
            <asp:Label ID="Label1" runat="server" Text="Customer ID"></asp:Label>
        </td>
        <td style="height: 20px; "></td>
        <td style="height: 20px; width: 151px">
            <asp:TextBox ID="TEXT_ID" runat="server" Width="228px"></asp:TextBox>
        </td>
        <td style="height: 20px">&nbsp;</td>
    </tr>
    <tr>
        <td style="height: 20px; width: 276px">
            <asp:Label ID="Label6" runat="server" Text="Company Name"></asp:Label>
        </td>
        <td style="height: 20px"></td>
        <td style="height: 20px; width: 151px">
            <asp:TextBox ID="TEXT_NAME" runat="server" Width="228px"></asp:TextBox>
        </td>
        <td style="height: 20px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" Width="73px" />
            <asp:Button ID="Button10" runat="server" Text="Submit" Visible="False" Width="73px" OnClick="Button10_Click" />
        </td>
    </tr>
    <tr>
        <td style="height: 20px; width: 276px">
            <asp:Label ID="Label7" runat="server" Text="Customer Name"></asp:Label>
        </td>
        <td style="height: 20px; "></td>
        <td style="height: 20px; width: 151px">
            <asp:TextBox ID="TEXT_NAME_2" runat="server" Width="228px"></asp:TextBox>
        </td>
        <td style="height: 20px">
            <asp:Button ID="Button2" runat="server" Text="Update" Width="73px" OnClick="Button2_Click" />
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="height: 22px; width: 276px">
            <asp:Label ID="Label4" runat="server" Text="Contact Title"></asp:Label>
        </td>
        <td style="height: 22px; "></td>
        <td style="height: 22px; width: 151px">
            <asp:TextBox ID="TEXT_TITLE" runat="server" Width="228px"></asp:TextBox>
        </td>
        <td style="height: 22px">
            <asp:Button ID="Button3" runat="server" Text="Delete" Width="73px" OnClick="Button3_Click" />
        </td>
    </tr>
    <tr>
        <td style="width: 276px; height: 12px">
            <asp:Label ID="Label5" runat="server" Text="Address"></asp:Label>
        </td>
        <td style="height: 12px"></td>
        <td style="width: 151px; height: 12px">
            <asp:TextBox ID="TEXT_ADDRESS" runat="server" Width="228px"></asp:TextBox>
        </td>
        <td style="height: 12px">&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 276px; height: 12px">
            <asp:Label ID="Label2" runat="server" Text="OrderDetails"></asp:Label>
        </td>
        <td style="height: 12px"></td>
        <td style="width: 151px; height: 12px">
            <asp:TextBox ID="TextBox1" runat="server" Width="228px" ReadOnly="True"></asp:TextBox>
        </td>
        <td style="height: 12px">
            &nbsp;</td>
    </tr>
     <tr>
        <td style="width: 276px; height: 12px">
                <asp:GridView ID="GridView1" runat="server" Width="309px" DataKeyNames="OrderID" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <PagerSettings Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous" />
            </asp:GridView>
         </td>
        <td style="height: 12px">&nbsp;</td>
        <td style="width: 151px; height: 12px">
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" style="height: 26px" Text="First" Width="85px" />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Last" Width="85px" />
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Next" Width="85px" />
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Previous" Width="85px" />
         </td>
        <td style="height: 12px">
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Order Placement" />
            <asp:HiddenField ID="HiddenField" runat="server"></asp:HiddenField>
         </td>
    </tr>
</table>

    

</asp:Content>
