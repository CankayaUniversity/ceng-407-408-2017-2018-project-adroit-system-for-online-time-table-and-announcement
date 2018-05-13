<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmail.master" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="Inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div runat="server" style=" margin-left:200px; margin-top:auto; "  >
        <center>  <asp:Label ID="lblmes" runat="server" Text="Label" Visible="False" Font-Bold="True" Font-Italic="True" ForeColor="#242424" Font-Size="Large"></asp:Label></center>
        <asp:GridView ID="grdEmail" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#262626" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="#262626" Height="100%" width="100%"  Style="overflow-y: scroll; overflow:auto; " OnRowCancelingEdit="grdEmail_RowCancelingEdit" OnRowEditing="grdEmail_RowEditing" OnRowUpdating="grdEmail_RowUpdating"> <%--OnRowDataBound="OnRowDataBound--%>
            <Columns>
                <asp:TemplateField HeaderText="Id" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("MessageID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image">
                     <ItemTemplate>
                         <asp:Image ID="Messageimg" runat="server" imageURL='<%# Bind("PhotoUrl") %>' Height="90px" Width="90px" />
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
                <asp:TemplateField HeaderText="Content">
                    <ItemTemplate>
                        <asp:Label ID="lblKonu" runat="server" Text='<%# Bind("MessageContent") %>'></asp:Label>
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
                <asp:CommandField CancelText="Exit" EditText="Select" HeaderText="Operation" ShowEditButton="True" UpdateText="Reply">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbDelete" runat="server" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                 
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="#262626" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

    </div>
       <div style="margin-left:1295px">
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" BackColor="#262626" Font-Bold="True" ForeColor="White" Visible="False"  />
        </div>
       <div runat="server" style=" margin-left:200px; margin-top:auto; " >
           
        <asp:Label ID="lblmsg" runat="server" Text="Message To: " Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="12pt" Font-Underline="False" Visible="False" ForeColor="#262626"></asp:Label><asp:TextBox ID="txtReceiver" runat="server" BorderStyle="Solid" Enabled="False" Visible="False" Width="220px" BorderColor="#262626"></asp:TextBox>
           <br /><br />
           <asp:Label ID="lblsubject" runat="server" Text="Subject: " Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="12pt" Font-Underline="False" Visible="False" ForeColor="#262626"></asp:Label> &emsp; &nbsp; <asp:TextBox ID="txtSubject" runat="server" Visible="False" Width="220px"></asp:TextBox>
           <br /><br />
        <asp:TextBox ID="txtMail" runat="server" Height="53px" TextMode="MultiLine" Width="404px" Visible="False"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnSendEmail" runat="server" OnClick="btnSendEmail_Click" Text="Send" Visible="False" BackColor="#262626" Font-Bold="True" Font-Size="Medium" ForeColor="White" />
           <asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="#262626" Text="Label" Visible="false"></asp:Label>
    </div>
</asp:Content>

