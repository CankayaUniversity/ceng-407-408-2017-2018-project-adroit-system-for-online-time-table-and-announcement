<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAnnouncement.master" AutoEventWireup="true" CodeFile="AllAnnouncements.aspx.cs" Inherits="Announcements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div runat="server" style=" margin-left:200px; margin-top:auto; "  >
        
       <font color="white"> <font size="6">

          <marquee onmouseover="this.stop()" bgColor="#262626" border-colo
                   r="black" onmouseout="this.start()"  width="100%" height="300" direction="Up"
                   scrollamount="3" scrolldelay="60" loop="99999" font="white" >


            <asp:DataList ID="dtAnnouncemnets" runat="server">

                 <ItemTemplate>                       
                            <table  >
                                <tr>                                   
                                    <td align="right" style="color:#ffbe0a">
                                        <%# FindDate(Eval("PublishDate")) %>&nbsp-
                                    </td>&nbsp
                                    <td>
                                        <%#Eval("AnnContent") %>
                                    </td>
                                </tr>
                            </table>
                        
                    </ItemTemplate>

            </asp:DataList>
               
         </marquee>

        </font></font>
    </div>
</asp:Content>

