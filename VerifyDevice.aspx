<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerifyDevice.aspx.cs" Inherits="VerifyDevice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Verify The Device</title>
    <link rel="shortcut icon" href="images/icons/favicon_Verify.ico">
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
<body runat="server" style="background-color:  #818181">
   <form id="form1" runat="server">
    <div class="sidenav">
        <center><asp:Image ID="Image1" runat="server" ImageUrl="images/logo.png" Height="113px" Width="117px"/></center>
        <br /><br /><br />
         <a href="VerifyDevice.aspx">Verify the Device</a>
         <a href="AdminHomepage.aspx">Homepage</a>
      </div>
    
       <div runat="server" style=" margin-left:200px; margin-top:auto; width:700px;  height:600px; margin:150px auto 0px auto; ">
           <asp:Label ID="lblId" runat="server" Font-Bold="True" Text="Device Id: " Font-Size="X-Large"></asp:Label>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtId" runat="server" Height="20px" Width="150px"></asp:TextBox>
           <br /><br />
           <asp:Label ID="lblDevice" runat="server" Font-Bold="True" Text="Device Code: " Font-Size="X-Large"></asp:Label>
           <asp:TextBox ID="txtCode" runat="server" Height="20px" Width="200px"></asp:TextBox>
           <br /><br />
           <asp:Button ID="btnAdd" runat="server" Text="Verify" OnClick="btnAdd_Click"  BackColor="#262626" Font-Bold="True" Font-Size="Medium" ForeColor="White" />
           &nbsp;&nbsp; <asp:Label ID="lblmessage" runat="server" Text="Label" Visible="False" Font-Bold="True" ForeColor="#FFCC00"></asp:Label>
       </div>
   
    </form>   

</body>
</html>
