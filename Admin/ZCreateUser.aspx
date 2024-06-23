<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ZCreateUser.aspx.cs" Inherits="Admin_CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
    function ValidateEmail(x) {
        var EmailExp = /^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$/;
        if (x.value.match(EmailExp)) {
            return true;
        }

        else {
            alert("Invalid Mail ID");
            x.value = "";
            x.focus();
            return false;
        }
      
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <div id="content" style="background-color: #FFFFFF; padding-left:15px; padding-right:10px;">
         <fieldset style="padding-right:20px;">
         <legend ><h3>Create User</h3></legend>
<table width="100%">
 
        
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="left" width="20%">
                Select Branch</td>
            <td align="left" width="1%">
                &nbsp;</td>
            <td align="left">
                <asp:DropDownList ID="ddl_branch" runat="server" Height="26px" Width="170px" 
                    CssClass="dottedTextBox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="left" width="20%">
                &nbsp;User Type</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddl_usertype" runat="server" CssClass="dottedTextBox" 
                    Height="26px" Width="170px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="left" width="20%">
                User Name</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left">
                <asp:TextBox ID="txt_userName" runat="server" CssClass="dottedTextBox" 
                    Width="170px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="left" width="20%">
                &nbsp;Email Id</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left">
                <asp:TextBox ID="txt_emailId" runat="server" CssClass="dottedTextBox" 
                    Width="170px" onchange = "ValidateEmail(this)"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="left" width="20%">
                &nbsp;User Id</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left">
                <asp:TextBox ID="txt_userId" runat="server" CssClass="dottedTextBox" 
                    Width="170px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="left" width="20%">
                Password</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left">
                <asp:TextBox ID="txt_pwd" runat="server" TextMode="Password" 
                    Width="170px" CssClass="dottedTextBox" 
                    AutoPostBack="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%" class="style1">
                </td>
            <td align="left" width="20%" class="style1">
                Confirm Password </td>
            <td align="left" width="1%" class="style1">
                <strong>:</strong></td>
            <td align="left" class="style1">
                <asp:TextBox ID="txt_conpwd" runat="server" TextMode="Password" 
                    Width="170px" CssClass="dottedTextBox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" width="20%">
                &nbsp;</td>
            <td align="left" class="style1" width="20%">
                &nbsp;</td>
            <td align="left" class="style1" width="1%">
                &nbsp;</td>
            <td align="left" class="style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="rowwidth" width="20%">
                &nbsp;</td>
            <td align="right" width="20%" style="padding-right:20px">
                <asp:Button ID="btn_assign" runat="server" CssClass="thinGreen" 
                    onclick="btn_assign_Click" Text="Create" />
            </td>
            <td align="left" colspan="2" style="padding-left:20px">
                <asp:Button ID="btn_cancel" runat="server" CssClass="ThinRed" 
                    onclick="btn_cancel_Click" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
</table>
</fieldset>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

