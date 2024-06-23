<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Service_JobcardOutsideService.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function AllowDecimalNumbersOnly(input, kbEvent) {
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
    <link href="SmitaStYlE/Calender/red.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss06.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="js/ServiceEstimateEntryCal.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            
            <div id="content" style="background-color: #FFFFFF; padding-left: 15px; padding-right: 10px;">
                <fieldset style="padding-right: 20px;">
                    <legend>
                        <h3>
                            Job Card Outside&nbsp; Service</h3>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2" width="20%">
                                Si No</td>
                            <td style="width: 1%" colspan="2">
                                :</td>
                            <td style="width: 30%" colspan="2">
                                <asp:TextBox ID="txt_sino" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2" align="left">
                                Jc Date</td>
                            <td colspan="2" width="1%">
                                :</td>
                            <td colspan="2" style=" position:relative">
                                <asp:TextBox ID="txt_jcdate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_jcdate_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_jcdate">
                                </asp:CalendarExtender>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                J.C. No.</td>
                            <td colspan="2" style="width: 1%">
                                <strong>:</strong>
                            </td>
                            <td colspan="2" style="width: 30%">
                                <asp:TextBox ID="txt_jcno" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px" AutoPostBack="True" ontextchanged="txt_jcno_TextChanged1" 
                                   ></asp:TextBox>
                            </td>
                            <td colspan="2" align="left">
                                Inv Date</td>
                            <td align="left" colspan="2" width="1%">
                                :</td>
                            <td colspan="2" style=" position:relative">
                                <asp:TextBox ID="txt_Invdate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_Invdate_CalendarExtender" runat="server" 
                                    CssClass="red" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_Invdate">
                                </asp:CalendarExtender>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Inv No</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_Invno" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px" 
                                   ></asp:TextBox>
                            </td>
                            <td colspan="2" align="left">
                                Engine No</td>
                            <td colspan="2" align="left" width="1%">
                                :</td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_engineno" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Regd No</td>
                            <td colspan="2">
                                <strong>:</strong>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_regdno" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2" align="left">
                                Chasis No</td>
                            <td align="left" colspan="2" width="1%">
                                :</td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_chassisno" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Model</td>
                            <td class="style2" colspan="2">
                                :
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_modelname" runat="server" Width="200px" 
                                    CssClass="TextBoxGraiant"></asp:TextBox>
                            </td>
                            <td colspan="2" align="left">
                                Party Name</td>
                            <td colspan="2" align="left" width="1%">
                                :</td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddl_partyname" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2" class="style1">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Amount</td>
                            <td colspan="2" class="style3">
                                :</td>
                            <td colspan="2" class="style3">
                                <asp:TextBox ID="txt_amount" runat="server" Width="200px" 
                                  CssClass="TextBoxGraiant"  onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                            </td>
                            <td colspan="2" align="left">
                                &nbsp; Date</td>
                            <td colspan="2" align="left" width="1%">
                                :</td>
                            <td colspan="2" class="style3" style=" position:relative">
                                <asp:TextBox ID="txt_date" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_date_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_date">
                                </asp:CalendarExtender>
                            </td>
                            <td colspan="2" class="style3">
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="20%">
                                Service Details</td>
                            <td colspan="2">
                                :</td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_servicedetails" runat="server" Rows="4" 
                                    TextMode="MultiLine" Width="200px" CssClass="TextBoxGraiant"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td align="left" colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="14">
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="14">
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="btn_Submit" runat="server" CssClass="VerySmallGreen" 
                                    Height="26px" onclick="btn_Submit_Click" Text="Submit" Width="120px" />
                            </td>
                            <td align="right" colspan="2">
                                <asp:Button ID="btn_Cancel" runat="server" CssClass="VerySmallRed" 
                                    Height="26px" onclick="btn_Cancel_Click" Text="Cancel" Width="120px" />
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="12">
                                &nbsp;
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
