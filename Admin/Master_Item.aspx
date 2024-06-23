<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="~/Admin/Master_Item.aspx.cs" Inherits="Admin_Master_MachineRegstration" %>


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
         <legend ><h4>Item Master </h4></legend>
<table width="100%">
 
        
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" width="15%">
                VehicleType</td>
            <td align="left" width="1%">
                &nbsp;</td>
            <td align="left" colspan="4">
                <asp:DropDownList ID="ddl_VType" runat="server" CssClass="dottedTextBox" 
                    Height="26px" Width="270px">
                    <asp:ListItem>..Select...</asp:ListItem>
                    <asp:ListItem>HCV</asp:ListItem>
                    <asp:ListItem>LCV</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" width="15%">
                Category</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left" colspan="4">
                <asp:DropDownList ID="ddlcategory" runat="server" Width="270px">
                    <asp:ListItem>Spareparts</asp:ListItem>
                    <asp:ListItem>Accessories</asp:ListItem>
                    <asp:ListItem>Lubricants</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" width="15%">
                Part No</td>
            <td align="left" width="1%">
                :</td>
            <td align="left" colspan="4">
                <asp:TextBox ID="txt_partno" runat="server" CssClass="SmalldottedTextBox" 
                    Width="270px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" width="15%" valign="top">
                Part Description</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left" colspan="4">
                <asp:TextBox ID="txt_description" runat="server" 
                    CssClass="SmalldottedTextBox" Width="270px" Rows="4" TextMode="MultiLine"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" valign="top" width="15%">
                Unit</td>
            <td align="left" width="1%">
                &nbsp;</td>
            <td align="left" colspan="4">
                <asp:TextBox ID="txt_unit" runat="server" CssClass="SmalldottedTextBox" 
                     Width="270px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" valign="top" width="15%">
                Purchase Price</td>
            <td align="left" width="1%">
                :</td>
            <td align="left" colspan="4">
                <asp:TextBox ID="txt_purchaseprice" runat="server" CssClass="SmalldottedTextBox" 
                   onkeypress="return AllowNumbersOnly(this,event)" Width="270px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" valign="top" width="15%">
                HSN Code</td>
            <td align="left" width="1%">
                :</td>
            <td align="left" colspan="4">
                <asp:TextBox ID="txt_hsn" runat="server" CssClass="SmalldottedTextBox" 
                   Width="270px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" valign="top" width="15%">
                Sale Price</td>
            <td align="left" width="1%">
                ::</td>
            <td align="left" width="10%">
                <asp:TextBox ID="txt_salesprice" runat="server" CssClass="SmalldottedTextBox" 
                    onkeypress="return AllowNumbersOnly(this,event)" Width="120px"></asp:TextBox>
            </td>
            <td align="left" width="2%">
                GST(%)</td>
            <td align="left" width="1%">
                :</td>
            <td align="left">
               
                <asp:DropDownList ID="ddl_vat" runat="server"  Width="90px">
                <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                  <asp:ListItem>18</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" width="15%">
                Self No</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left" colspan="4">
              
                <asp:TextBox ID="txt_selfno" runat="server" CssClass="SmalldottedTextBox" 
                    Width="270px"></asp:TextBox>
              
            </td>
        </tr>
         <tr>
            <td align="right" width="20%">
                &nbsp;</td>
            <td align="right" valign="top" width="15%" 
                 style="font-weight: bold; color: #000000">
                Alternate Part</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left" width="10%">
                <asp:TextBox ID="txt_alternatepart" runat="server" CssClass="SmalldottedTextBox" 
                    Width="120px"></asp:TextBox>
            </td>
            <td align="left" width="2%">
                Op Stock</td>
            <td align="left" width="1%">
                <strong>:</strong></td>
            <td align="left">
                <asp:TextBox ID="txt_stock" runat="server" CssClass="SmalldottedTextBox" 
                    Width="90px"  onkeypress="return AllowNumbersOnly(this,event)">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" width="20%">
                &nbsp;</td>
            <td align="left" class="style1" width="15%">
                &nbsp;</td>
            <td align="left" class="style1" width="1%">
                &nbsp;</td>
            <td align="left" class="style1" colspan="4">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td align="center" width="20%" colspan="7">
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

