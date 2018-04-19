<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAnnouncement.master" AutoEventWireup="true" CodeFile="EditAnnouncements.aspx.cs" Inherits="EditAnnouncements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div runat="server" style=" margin-left:200px; margin-top:auto; "  >
        <asp:GridView ID="grdAnnouncement" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#262626" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="#262626" Height="100%" width="100%"  Style="overflow-y: scroll; overflow:auto; " OnRowCancelingEdit="grdAnnouncement_RowCancelingEdit" OnRowEditing="grdAnnouncement_RowEditing" OnRowUpdating="grdAnnouncement_RowUpdating"  OnRowDeleting="grdAnnouncement_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Id" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("AnnouncementID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Content">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtContent" runat="server" Text='<%# Bind("AnnContent") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblContent" runat="server" Text='<%# Bind("AnnContent") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Publish Date">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPub" runat="server" Text='<%# Bind("PublishDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPublish" runat="server" Text='<%# Bind("PublishDate") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
              
                <asp:TemplateField HeaderText="Exp Date">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtExp" runat="server" Text='<%# Bind("ExpDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExp" runat="server" Text='<%# Bind("ExpDate") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
        

                <asp:CommandField HeaderText="Operations" ShowDeleteButton="True" ShowEditButton="True" CancelText="Exit" DeleteText="Remove" EditText="Select" UpdateText="Update Announcement">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
        

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
</asp:Content>

