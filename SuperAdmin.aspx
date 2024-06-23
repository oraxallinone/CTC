<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SuperAdmin.aspx.cs" Inherits="Admin_SuperAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">


<body style="background-color: #CCCC00">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="padding-left: 20%; padding-top: 5%; padding-right: 20%; padding-bottom: 20%;">
                <center>
                    <table width="100%" bgcolor="#990000" style="border-style: dotted; border-width: thin;
                        border-color: #800000; background-image: url('Admin/Images/bgpng.png');">
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style3">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="25px" ForeColor="White"
                                    Text="Choose Branch"></asp:Label>
                                <span style="float: right">
                                    <asp:ImageButton ID="imgbtnlogout" runat="server" ImageUrl="~/Admin/Images/logout.png"
                                        OnClick="imgbtnlogout_Click" Width="50px" /></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" width="50%">
                                <asp:ImageButton ID="imgbtnctc" runat="server" ImageUrl="~/Admin/Images/CTC.png"
                                    Width="140px" OnClick="imgbtnctc_Click" />
                            </td>
                            <td align="center" width="50%">
                                <asp:ImageButton ID="imgbtnberhmpur" runat="server" ImageUrl="~/Admin/Images/BRHMPURH.png"
                                    Width="140px" OnClick="imgbtnberhmpur_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" width="50%">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="20px" ForeColor="White"
                                    Text="cuttack"></asp:Label>
                            </td>
                            <td align="center" width="50%">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="20px" ForeColor="White"
                                    Text="Berhampur"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" width="50%">
                                &nbsp;
                            </td>
                            <td align="center" width="50%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" width="50%">
                                <asp:ImageButton ID="imgbtnanugul" runat="server" ImageUrl="~/Admin/Images/ANUGUL.png"
                                    Width="150px" OnClick="imgbtnanugul_Click" />
                            </td>
                            <td align="center" width="50%">
                                <asp:ImageButton ID="hulnakhara" runat="server" ImageUrl="~/Admin/Images/PHULNAKHARA.png"
                                    Width="150px" OnClick="hulnakhara_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" width="50%">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="20px" ForeColor="White"
                                    Text="Paradeep"></asp:Label>
                            </td>
                            <td align="center" width="50%">
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="20px" ForeColor="White"
                                    Text="Phulnakhara"></asp:Label>
                            </td>
                        </tr>
                     
                        <tr>
                            <td align="center" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <div id="footer">
                        <div id="copyright">
                            <span style="float: left; padding-top: -100px">&copy; copyright 2014. <strong style="color: #006baf;">
                                Rashmi Motors</strong></span>
                        </div>
                        <div id="maintain">
                            <span style="float: right">Powered by: <a href="http://www.starsofttechnology.com"
                                target="_blank" style="color: #006baf; font-weight: bold;">StarSoft Technology</a></span></div>
                    </div>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
