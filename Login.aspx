<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="sj1_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <script type="text/javascript">
        var rev = "fwd";
        function titlebar(val) {
            var msg = "Welcome To AutoMobile Enterprises";
            var res = " ";
            var speed = 100;
            var pos = val;

            msg = "|--- " + msg + " ---|";
            var le = msg.length;
            if (rev == "fwd") {
                if (pos < le) {
                    pos = pos + 1;
                    scroll = msg.substr(0, pos);
                    document.title = scroll;
                    timer = window.setTimeout("titlebar(" + pos + ")", speed);
                }
                else {
                    rev = "bwd";
                    timer = window.setTimeout("titlebar(" + pos + ")", speed);
                }
            }
            else {
                if (pos > 0) {
                    pos = pos - 1;
                    var ale = le - pos;
                    scrol = msg.substr(ale, le);
                    document.title = scrol;
                    timer = window.setTimeout("titlebar(" + pos + ")", speed);
                }
                else {
                    rev = "fwd";
                    timer = window.setTimeout("titlebar(" + pos + ")", speed);
                }
            }
        }

        titlebar(0);
    </script>

    <link rel="shortcut icon" href="Admin/Images/icon.png" />
    <link href="Style/style.css" rel="stylesheet" type="text/css" />
</head>


<body>
    <form id="form1" runat="server">
        <h2>Welcome To AutoMobile Enterprises
        </h2>
        <div>
            <h1>Log In Panel</h1>
            <div class="inset">
                <p>
                    <label for="email">USER ID</label>
                    <asp:TextBox ID="txt_UserId" runat="server" CssClass="email" Font-Bold="True" Font-Names="Cambria" ForeColor="White"></asp:TextBox>
                </p>

                <p>
                    <label for="password">PASSWORD</label>
                    <asp:TextBox ID="txt_Password" runat="server" CssClass="password" Font-Bold="True" Font-Names="Cambria" ForeColor="White" TextMode="Password"></asp:TextBox>
                </p>
                <p>
                </p>
            </div>

            <p class="p-container">
                <asp:Button ID="btn_Login" runat="server" Text="Log in" CssClass="go" OnClick="btn_Login_Click" />
            </p>
        </div>
    </form>

    <br />
    <br />
    <br />
    <br />
    <div id="footer">
        <div id="copyright">&copy; copyright 2014. <strong style="color: #006baf;">AutoMobile Enterprises</strong></div>
        <div id="maintain">
            Powered by: <a href="http://www.starsofttechnology.com/" target="_blank" style="color: #006baf; font-weight: bold;">StarsoftTechnology</a>
        </div>
    </div>

</body>
</html>
