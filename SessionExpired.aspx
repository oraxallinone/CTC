<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionExpired.aspx.cs" Inherits="SessionExpired" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type='text/javascript'>
            var msg = "|---Welcome To Rashmi Motors Private Ltd ---|";
            msg = msg; pos = 0;
            function scrollTitle() {
                document.title = msg.substring(pos, msg.length) + msg.substring(0, pos); pos++;
                if (pos > msg.length) pos = 0
                window.setTimeout("scrollTitle()", 200);
            }
            scrollTitle();
    </script>
    <link rel="shortcut icon"  href="Admin/Images/icon.png" type="image/png"/>
</head>
<body>
    <form id="form1" runat="server">
  
    <center>
    <div  style="text-align:center;vertical-align:middle; height:100%">
    <a href="Login.aspx">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Admin/Images/session.png" 
            Height="92%" /></a>
    </div>
    </center>
    
    </form>
</body>
</html>
