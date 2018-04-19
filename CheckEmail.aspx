<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckEmail.aspx.cs" Inherits="CheckEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email</title>
    <link rel="shortcut icon" href="images/icons/email.ico">

    <style>
.sidenav {
  height: 100%;
  width: 200px;
  position: fixed;
  z-index: 1;
  top: 0;
  left: 0;
  background-color: #111;
  overflow-x: hidden;
  padding-top: 20px;
}

/* Style the sidenav links and the dropdown button */
.sidenav a, .dropdown-btn {
  padding: 6px 8px 6px 16px;
  text-decoration: none;
  font-size: 20px;
  color: #818181;
  display: block;
  border: none;
  background: none;
  width:100%;
  text-align: left;
  cursor: pointer;
  outline: none;
}

/* On mouse-over */
.sidenav a:hover, .dropdown-btn:hover {
  color: #f1f1f1;
}

/* Main content */
.main {
  margin-left: 200px; /* Same as the width of the sidenav */
  font-size: 20px; /* Increased text to enable scrolling */
  padding: 0px 10px;
}

/* Add an active class to the active dropdown button */
.active {
  background-color: green;
  color: white;
}

/* Dropdown container (hidden by default). Optional: add a lighter background color and some left padding to change the design of the dropdown content */
.dropdown-container {
  display: none;
  background-color: #262626;
  padding-left: 8px;
}

/* Optional: Style the caret down icon */
.fa-caret-down {
  float: right;
  padding-right: 8px;
}
    </style>
</head>
<body runat="server" style="background-color:  #ffbe0a">
   
    <div class="sidenav">
        <center><asp:Image ID="Image1" runat="server" ImageUrl="images/logo.png" Height="113px" Width="117px"/></center>
    <br /><br /><br />
      <a id="A0" runat="server" href="#" onserverclick="Inbox" style="display:block">Inbox</a>
      <a id="A1" runat="server" href="#" onserverclick="SentMail" style="display:block">Sent Mail</a>
      <a id="A2" runat="server" href="#" onserverclick="Trash" style="display:block">Trash</a>
      <a id="A3" runat="server" href="https://webmail.cankaya.edu.tr/" style="display:block">Webmail</a>
    </div>

    <form runat="server" style=" margin-left:200px; margin-top:auto; "  >
        <asp:GridView ID="grdEmail" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="100%" width="100%"  Style="overflow-y: scroll; overflow:auto; ">

            <Columns>
                <asp:TemplateField HeaderText="Id" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("MessageID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Content">
                    <ItemTemplate>
                        <asp:Label ID="lblKonu" runat="server" Text='<%# Bind("MessageContent") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sender">
                    <ItemTemplate>
                        <asp:Label ID="lblSender" runat="server" Text='<%# Bind("SenderName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Receiver">
                    <ItemTemplate>
                        <asp:Label ID="lblReceiver" runat="server" Text='<%# Bind("ReceiverName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="lblTarih" runat="server" Text='<%# Bind("TimeSent") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Button" HeaderText="Operation" Text="Reply">

                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:ButtonField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbDelete" runat="server" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

        <div style="margin-left:1095px">
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"  />
        </div>
        
            
      
        

        <asp:Button ID="btnSendEmail" runat="server" Text="Button" OnClick="btnSendEmail_Click" />
        
            
      
        

    </form>

</body>
</html>
