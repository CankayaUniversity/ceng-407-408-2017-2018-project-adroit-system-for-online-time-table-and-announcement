<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   	<title>Edit Timetable</title>
    <link rel="shortcut icon" href="images/icons/timetable.ico">
	<link rel="stylesheet" type="text/css" href="http://www.jeasyui.com/easyui/themes/default/easyui.css">
	<link rel="stylesheet" type="text/css" href="http://www.jeasyui.com/easyui/themes/icon.css">
	<link rel="stylesheet" type="text/css" href="http://www.jeasyui.com/easyui/demo/demo.css">
	<script type="text/javascript" src="http://code.jquery.com/jquery-1.6.1.min.js"></script>
	<script type="text/javascript" src="http://www.jeasyui.com/easyui/jquery.easyui.min.js"></script>
    <style type="text/css">
		.left{
			width:600px;
			float:left;
		}
		.left table{
			background:#E0ECFF;
		}
		.left td{
			background:#ffbe0a;
		}
		.right{
			float:right;
			width:570px;
		}
		.right table{
			background:#444;
			width:100%;
		}
		.right td{
			background:#ffbe0a;
			color:#444;
			text-align:center;
			padding:2px;
		}
		.right td{
			background:#ffbe0a;
		}
		.right td.drop{
			background:#ffbe0a;
			width:100px;
		}
		.right td.over{
			background:#FBEC88;
		}
		.item{
			text-align:center;
			border:1px solid #499B33;
			background:#fafafa;
			color:#444;
			width:100px;
		}
		.assigned{
			border:1px solid #BC2A4D;
		}
		.trash{
			background-color:red;
		}
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
    
	    .auto-style1 {
            width: 100%;
        }
    
	    .auto-style2 {
            height: 15px;
        }
    
	</style>
	
</head>
<body style= "width:600px;  height:600px; margin:100px auto 0px auto; background-color:  #ffbe0a; overflow: hidden; " >
      <form runat="server" >
         <div class="left" >
			<center>
                <table>
                      &nbsp;&nbsp;
                    <tr>				            
                            <td ><asp:DropDownList ID="ddlDay" runat="server" OnSelectedIndexChanged="ddlDay_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                            <td ><asp:DropDownList ID="ddlTime" runat="server" ></asp:DropDownList></td>
                            <td ><asp:DropDownList ID="ddlExtras" runat="server"  ></asp:DropDownList></td>
                            <td ><asp:Button ID="btn_Save" runat="server" Text="Add" OnClick="btn_Save_Click" BackColor="#B3B3B3" Font-Bold="True" ForeColor="#242424"></asp:Button></td>
                            <td ><asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" BackColor="#B3B3B3" Font-Bold="True" Font-Italic="False" ForeColor="#242424"></asp:Button></td>
                            <td ><asp:Label ID="lblmessage" runat="server" Text="Label" Visible="False" Font-Bold="True" Font-Italic="True" ForeColor="#242424"></asp:Label></td>
                    </tr>                   
			    </table>
			</center>
		 </div>
       </form>
    <br /><br /> <br /><br /> <br /><br />
   <asp:DataList ID="dtTimetable" runat="server" class="right" > 
    <ItemTemplate >   
              
     <table id="dataTable" class="auto-style1" >
         <tr>
             <td class="blank"></td>
			 <td ><b>Monday</b></td>
			 <td ><b>Tuesday</b></td>
			 <td ><b>Wednesday</b></td>
			 <td ><b>Thursday</b></td>
			 <td ><b>Friday</b></td>
         </tr>
         <tr>
             <td >
                 <asp:Label ID="Label1" runat="server" Text="09:20"></asp:Label>               
              </td>
                <td  >
                    <asp:Label ID="lblm9" runat="server" Text='<%# FindM9()%>'></asp:Label> <%--monday--%>
                </td>   
                <td >
                    <asp:Label ID="Label2" runat="server" Text='<%# FindTu9()%>'></asp:Label>
                </td> 
                <td >
                    <asp:Label ID="Label3" runat="server" Text='<%# FindW9()%>'></asp:Label> 
                </td> 
                <td >
                    <asp:Label ID="Label4" runat="server" Text='<%# FindTh9()%>'></asp:Label> 
                </td > 
                <td >
                    <asp:Label ID="Label5" runat="server" Text='<%# FindF9()%>'></asp:Label>      
                </td> 
         </tr>
         <tr>
             <td >
                 <asp:Label ID="Label6" runat="server" Text="10:20"></asp:Label>               
              </td>
                <td  >
                    <asp:Label ID="Label7" runat="server" Text='<%# FindM10()%>'></asp:Label> <%--monday--%>
                </td>   
                <td >
                    <asp:Label ID="Label8" runat="server" Text='<%# FindTu10()%>'></asp:Label>
                </td> 
                <td >
                    <asp:Label ID="Label9" runat="server" Text='<%# FindW10()%>'></asp:Label> 
                </td> 
                <td >
                    <asp:Label ID="Label10" runat="server" Text='<%# FindTh10()%>'></asp:Label> 
                </td > 
                <td >
                    <asp:Label ID="Label11" runat="server" Text='<%# FindF10()%>'></asp:Label>      
                </td>
         </tr>
         <tr>
              <td >
                 <asp:Label ID="Label12" runat="server" Text="11:20"></asp:Label>               
              </td>
                <td  >
                    <asp:Label ID="Label13" runat="server" Text='<%# FindM11()%>'></asp:Label> <%--monday--%>
                </td>   
                <td >
                    <asp:Label ID="Label14" runat="server" Text='<%# FindTu11()%>'></asp:Label>
                </td> 
                <td >
                    <asp:Label ID="Label15" runat="server" Text='<%# FindW11()%>'></asp:Label> 
                </td> 
                <td >
                    <asp:Label ID="Label16" runat="server" Text='<%# FindTh11()%>'></asp:Label> 
                </td > 
                <td >
                    <asp:Label ID="Label17" runat="server" Text='<%# FindF11()%>'></asp:Label>      
                </td>
         </tr>
         <tr>
             <td >
                 <asp:Label ID="Label18" runat="server" Text="12:20"></asp:Label>               
              </td>
                <td  >
                    <asp:Label ID="Label19" runat="server" Text='<%# FindM12()%>'></asp:Label> <%--monday--%>
                </td>   
                <td >
                    <asp:Label ID="Label20" runat="server" Text='<%# FindTu12()%>'></asp:Label>
                </td> 
                <td >
                    <asp:Label ID="Label21" runat="server" Text='<%# FindW12()%>'></asp:Label> 
                </td> 
                <td >
                    <asp:Label ID="Label22" runat="server" Text='<%# FindTh12()%>'></asp:Label> 
                </td > 
                <td >
                    <asp:Label ID="Label23" runat="server" Text='<%# FindF12()%>'></asp:Label>      
                </td>
         </tr>
         <tr>
             <td >
                 <asp:Label ID="Label24" runat="server" Text="13:20"></asp:Label>               
              </td>
                <td  >
                    <asp:Label ID="Label25" runat="server" Text='<%# FindM13()%>'></asp:Label> <%--monday--%>
                </td>   
                <td >
                    <asp:Label ID="Label26" runat="server" Text='<%# FindTu13()%>'></asp:Label>
                </td> 
                <td >
                    <asp:Label ID="Label27" runat="server" Text='<%# FindW13()%>'></asp:Label> 
                </td> 
                <td >
                    <asp:Label ID="Label28" runat="server" Text='<%# FindTh13()%>'></asp:Label> 
                </td > 
                <td >
                    <asp:Label ID="Label29" runat="server" Text='<%# FindF13()%>'></asp:Label>      
                </td>
         </tr>
         <tr>
             <td >
                 <asp:Label ID="Label30" runat="server" Text="14:20"></asp:Label>               
              </td>
                <td  >
                    <asp:Label ID="Label31" runat="server" Text='<%# FindM14()%>'></asp:Label> <%--monday--%>
                </td>   
                <td >
                    <asp:Label ID="Label32" runat="server" Text='<%# FindTu14()%>'></asp:Label>
                </td> 
                <td >
                    <asp:Label ID="Label33" runat="server" Text='<%# FindW14()%>'></asp:Label> 
                </td> 
                <td >
                    <asp:Label ID="Label34" runat="server" Text='<%# FindTh14()%>'></asp:Label> 
                </td > 
                <td >
                    <asp:Label ID="Label35" runat="server" Text='<%# FindF14()%>'></asp:Label>      
                </td>
         </tr>
         <tr>
             <td >
                 <asp:Label ID="Label36" runat="server" Text="15:20"></asp:Label>               
              </td>
                <td  >
                    <asp:Label ID="Label37" runat="server" Text='<%# FindM15()%>'></asp:Label> <%--monday--%>
                </td>   
                <td >
                    <asp:Label ID="Label38" runat="server" Text='<%# FindTu15()%>'></asp:Label>
                </td> 
                <td >
                    <asp:Label ID="Label39" runat="server" Text='<%# FindW15()%>'></asp:Label> 
                </td> 
                <td >
                    <asp:Label ID="Label40" runat="server" Text='<%# FindTh15()%>'></asp:Label> 
                </td > 
                <td >
                    <asp:Label ID="Label41" runat="server" Text='<%# FindF15()%>'></asp:Label>      
                </td>
         </tr>
         <tr>
             <td >
                 <asp:Label ID="Label42" runat="server" Text="16:20"></asp:Label>               
              </td>
                <td  >
                    <asp:Label ID="Label43" runat="server" Text='<%# FindM16()%>'></asp:Label> <%--monday--%>
                </td>   
                <td >
                    <asp:Label ID="Label44" runat="server" Text='<%# FindTu16()%>'></asp:Label>
                </td> 
                <td >
                    <asp:Label ID="Label45" runat="server" Text='<%# FindW16()%>'></asp:Label> 
                </td> 
                <td >
                    <asp:Label ID="Label46" runat="server" Text='<%# FindTh16()%>'></asp:Label> 
                </td > 
                <td >
                    <asp:Label ID="Label47" runat="server" Text='<%# FindF16()%>'></asp:Label>      
                </td>
         </tr>
     </table>
 
        </ItemTemplate>
    </asp:DataList>  
     <div class="sidenav">
        <center><asp:Image ID="Image1" runat="server" ImageUrl="images/logo.png" Height="113px" Width="117px"/></center>
        <br /><br /><br />
         <a href="Edit.aspx">Edit Timetable</a>
         <a href="TeacherHomepage.aspx">Homepage</a>
     </div>
	
</body>
</html>