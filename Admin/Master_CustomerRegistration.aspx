<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Master_CustomerRegistration.aspx.cs" Inherits="Admin_Master_MachineRegstration" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
    function AllowNumbersOnly(input, kbEvent) {
        var keyCode, keyChar;
        keyCode = kbEvent.keyCode;
        if (window.event)
            keyCode = kbEvent.keyCode; 	// IE
        else
            keyCode = kbEvent.which; 	//firefox		         
        if (keyCode == null) return true;
        // get character
        keyChar = String.fromCharCode(keyCode);
        var charSet = ".0123456789";
        // check valid chars
        if (charSet.indexOf(keyChar) != -1) return true;
        // control keys
        if (keyCode == null || keyCode == 0 || keyCode == 8 || keyCode == 9 || keyCode == 13 || keyCode == 27) return true;
        return false;
    }
</script>

    <style type="text/css">
        .style1
        {
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1"  DynamicLayout="true" runat="server">
     <ProgressTemplate>      
             <div class="modall">
        <div class="centerr">
            <img alt="progress" src="Images/processing.gif"/>
        </div>
    </div>             
            </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div id="content" style="background-color: #FFFFFF; padding-left:15px; padding-right:10px;">
         <fieldset style="padding-right:20px;">
         <legend ><h4>Customer Registration </h4></legend>
<table width="100%">
 
        
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" width="15%">
                Party Code </td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left" colspan="5">
                <asp:TextBox ID="txt_scode" runat="server" CssClass="SmalldottedTextBox" 
                    Width="270px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" width="15%">
                &nbsp;Party Name</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left" colspan="5">
                <asp:TextBox ID="txt_sname" runat="server" CssClass="SmalldottedTextBox" 
                    Width="270px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" width="15%">
                &nbsp;</td>
            <td align="left" width="1%">
                &nbsp;</td>
            <td align="left" colspan="2" width="120px">
                <asp:Label ID="lblpresentadress" runat="server" Text="PRESENT ADDRESS" 
                    Font-Bold="True" Font-Size="15px"></asp:Label>
            </td>
            <td align="center" colspan="3">
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                    oncheckedchanged="CheckBox1_CheckedChanged" /> 
                <asp:Label ID="lblpresentadress0" runat="server" Text="PERMANENT ADDRESS" 
                    Font-Bold="True" Font-Size="15px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" width="15%" valign="top">
                Address</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left" colspan="3">
                <asp:TextBox ID="txt_address" runat="server" 
                    CssClass="SmalldottedTextBox" Width="270px" Rows="4" TextMode="MultiLine"></asp:TextBox>
            
            </td>
            <td align="center" colspan="2" valign="top">
               Address <asp:TextBox ID="txt_address0" runat="server" CssClass="SmalldottedTextBox" 
                    Rows="4" TextMode="MultiLine" Width="270px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" valign="top" width="15%">
                City</td>
            <td align="left" width="1%">
                :</td>
            <td align="left" valign="top" colspan="3">
                <asp:TextBox ID="txt_city" runat="server" CssClass="SmalldottedTextBox" 
                    Width="120px"></asp:TextBox>
                Pin<asp:TextBox ID="txt_pin" runat="server" CssClass="SmalldottedTextBox" 
                    MaxLength="6" onkeypress="return AllowNumbersOnly(this,event)" Width="90px"></asp:TextBox>
            </td>
            <td align="center" colspan="2" valign="top">
                City<asp:TextBox ID="txt_city2" runat="server" CssClass="SmalldottedTextBox" 
                    Width="120px"></asp:TextBox>
                Pin<asp:TextBox ID="txt_pin3" runat="server" CssClass="SmalldottedTextBox" 
                    MaxLength="6" onkeypress="return AllowNumbersOnly(this,event)" Width="90px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" width="15%">
                Phone No</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left" colspan="5">
                <asp:TextBox ID="txt_phno" runat="server" CssClass="SmalldottedTextBox" MaxLength="10"
                    onkeypress="return AllowNumbersOnly(this,event)" Width="270px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" valign="top" width="15%" 
                 style="font-weight: bold; color: #000000">
                TIN/SRIN</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left" width="10%">
                <asp:TextBox ID="txt_tinno" runat="server" CssClass="SmalldottedTextBox" 
                    Width="120px"></asp:TextBox>
            </td>
            <td align="left" width="2%">
                &nbsp;</td>
            <td align="left" class="style1" colspan="2">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style1" width="20%">
                &nbsp;</td>
            <td align="left" class="style1" width="15%">
                &nbsp;</td>
            <td align="left" class="style1" width="1%">
                &nbsp;</td>
            <td align="left" class="style1" colspan="5">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td align="center" width="20%" colspan="8">
                <asp:Button ID="btn_assign" runat="server" CssClass="thinCupersulphate" 
                    onclick="btn_assign_Click" Text="Submit" />
                <asp:Button ID="btn_cancel" runat="server" CssClass="ThinRed" 
                    onclick="btn_cancel_Click" Text="Cancel" />
                <asp:Button ID="btn_update" runat="server" CssClass="VerySmallYellow" 
                    Text="Update" Visible="False" onclick="btn_update_Click" />
                <asp:Button ID="btn_back" runat="server" CssClass="VerySmallLiteBlue" 
                    onclick="btn_back_Click" Text="Back" Visible="False" />
            </td>
        </tr>
</table>
</fieldset>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

