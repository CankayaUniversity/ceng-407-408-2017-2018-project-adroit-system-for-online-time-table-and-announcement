<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAnnouncement.master" AutoEventWireup="true" CodeFile="PublishAnnouncement.aspx.cs" Inherits="PublishAnnouncement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div runat="server" style=" margin-left:200px; margin-top:auto; "  >
        <asp:Label ID="lblContent" runat="server" Text="Content: " Font-Bold="True" Font-Italic="False" ForeColor="#262626"></asp:Label>
        <br /><asp:TextBox ID="txtCont" runat="server" Height="52px" TextMode="MultiLine" Width="292px" BorderColor="Black" BorderStyle="None"></asp:TextBox>
        <br /><br />
        <asp:Label ID="lblExp" runat="server" Text="Expire Date:" Font-Bold="True" ForeColor="#262626"></asp:Label>
        <br />
        <asp:TextBox ID="txtExp" runat="server" TextMode="DateTimeLocal" Height="18px" Width="187px"></asp:TextBox>
        <br /> <br />
        <asp:Button ID="btnPublish" runat="server" Text="Publish" BackColor="#262626" Font-Bold="True" Font-Size="Medium" ForeColor="White" OnClick="btnPublish_Click"/>
         <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#262626" Text="Label" Visible="false"></asp:Label>
    </div>
</asp:Content>

