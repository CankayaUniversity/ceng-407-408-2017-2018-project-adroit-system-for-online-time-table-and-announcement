<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs"  Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <style>

.button {
  padding: 15px 25px;
  font-size: 20px;
  text-align: center;
  cursor: pointer;
  outline: none;
  color: #fff;
  background-color: #ffbe0a;
  border: none;
  border-radius: 15px;
  box-shadow: 0 9px #ffbe0a;
  height:50px;
  width:120px;
  font-family: sans-serif;
}

.button:hover {background-color: #ffbe0a}

.button:active {
  background-color: #ffbe0a;
  box-shadow: 0 5px #ffbe0a;
  transform: translateY(4px);
}

input.largerCheckbox
{
width: 30px;
height: 30px;
}
</style>
    <title>Login</title>
	<meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
        
        <meta name="viewport" content="width=device-width, initial-scale=1.0"> 
        <meta name="description" content="Fullscreen Background Image Slideshow with CSS3 - A Css-only fullscreen background image slideshow" />
        <meta name="keywords" content="css3, css-only, fullscreen, background, slideshow, images, content" />
        <meta name="author" content="Codrops" />
        <link rel="shortcut icon" href="../favicon.ico"> 
        <link rel="stylesheet" type="text/css" href="css/demo.css" />
        <link rel="stylesheet" type="text/css" href="css/style3.css" />
    
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon_loginn.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
<!--===============================================================================================-->
    <script type="text/javascript" src="js/modernizr.custom.86080.js"></script>
  
</head>
<body style="overflow: hidden;">
	<ul class="cb-slideshow">
            <li><span>Image 01</span><div></div></li>
            <li><span>Image 02</span><div></div></li>
            <li><span>Image 03</span><div></div></li>
            <li><span>Image 04</span><div></div></li>
            <li><span>Image 05</span><div></div></li>
            <li><span>Image 06</span><div></div></li>
        </ul>
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 p-t-30 p-b-50">
				<span class="login100-form-title p-b-41">
					Account Login
				</span>
				<form class="login100-form validate-form p-b-33 p-t-5"  runat="server">

					<div class="wrap-input100 validate-input" data-validate = "Enter username">
                        <%--<input class="input100" type="text" name="username" placeholder="User name">--%>
                        <asp:TextBox ID="txtUsername" CssClass="input100" placeholder="Email Address" autofocus="" runat="server"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe82a;"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate="Enter password">
                        <%--<input class="input100" type="password" name="pass" placeholder="Password">--%>
                         <asp:TextBox ID="txtPassword" CssClass="input100" placeholder="Password" runat="server" TextMode="Password" style="left: 0px; top: 0px" ></asp:TextBox> 
						<span class="focus-input100" data-placeholder="&#xe80f;"> </span>
                    </div>

                    <div  class="wrap-input100 validate-input" data-validate="Enter password" style="text-align: center" >
                        <asp:Label ID="lblRememberMe" runat="server" Text="Remember Me!" font-famil="Ubuntu-Regular" style="text-align:center"></asp:Label> <br />
                        <asp:CheckBox ID="cbRememberMe" runat="server" class="largerCheckbox" />
                       
                        <span class="focus-input100" ></span>
                    </div>
                    
                    <br /> <center> <asp:RegularExpressionValidator ID="revUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Wrong E-Mail type!" Font-Size="Medium" ForeColor="Black" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="login" Font-Bold="True" Font-Italic="True" ></asp:RegularExpressionValidator></center>
					<%--<br />	<center><asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter your E-mail!" Font-Size="Medium" ForeColor="Black" ValidationGroup="login" Font-Bold="True" Font-Italic="True"></asp:RequiredFieldValidator></center>
                    <br />  <center><asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter your password!" Font-Size="Medium" ForeColor="Black" ValidationGroup="login" Font-Bold="True" Font-Italic="True" ></asp:RequiredFieldValidator ></center>--%>
					
                    <div >

                       <center><asp:Button ID="btnLogin" class="button" runat="server" Text="Login"  Font-Bold="True" OnClick="btnLogin_Click" ValidationGroup="login" style="text-align:center" /></center>											
					    <br /><center><asp:Label ID="lblMessage" runat="server" Text="Label" Visible="False"></asp:Label>		</center>				                  	
					</div>
                    

				</form>
			</div>
		</div>
	</div>
	

	<div id="dropDownSelect1"></div>
	
<!--===============================================================================================-->
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>

</body>
</html>
