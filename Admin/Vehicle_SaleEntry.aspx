<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Vehicle_SaleEntry.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

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
     <script type="text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=Panel1.ClientID %>");
             var printWindow = window.open('', '_blank', 'height=600,width=920');
             printWindow.document.write('<html><head><title>Print Page</title>');
             printWindow.document.write('</head><body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return false;
         }

       
    </script>
    <script src="SmitaStYlE/Accodianeffect.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {


            $("li").click(function () {
                $(this).toggleClass("active");
                $(this).next("div").stop('true', 'true').slideToggle("slow");
            });
        });
    </script>
    <link href="SmitaStYlE/Calender/red.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss06.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="js/SparePurchaseEntryCal.js" type="text/javascript"></script>
     <script src="SmitaStYlE/SumUsingJquery/VehicleSale.js" type="text/javascript"></script>
    <script src="SmitaStYlE/SumUsingJquery/jquery.min.js" type="text/javascript"></script>
    
<style type="text/css">
    .style2
    {
        height: 25px;
    }
    .style3
    {
        font-weight: bold;
        height: 25px;
    }
    .style4
    {
        height: 26px;
    }
</style>
    
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
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Both">
            
            <div id="content" style="background-color: #FFFFFF; padding-left: 15px; padding-right: 10px;">
                <fieldset style="padding-right: 20px;">
                    <legend>
                        <h3>
                            Vehicle Sale Entry</h3>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%">
                                Bill&nbsp; No
                            </td>
                            <td style="width: 1%">
                                <strong>:</strong>
                            </td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txt_billno" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="200px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%">
                                Invoice Type
                            </td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_invtype" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px" AutoPostBack="True" 
                                    onselectedindexchanged="ddl_invtype_SelectedIndexChanged">
                                  
                                    <asp:ListItem Value="Vehicle_RetailSales">Retail Invoice</asp:ListItem>
                                      <asp:ListItem Value="Vehicle_TaxSales">Tax Invoice</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Party Name</td>
                            <td>
                                <strong>:</strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_partyname" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddl_partyname_SelectedIndexChanged" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;Bill Date
                            </td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_billdate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Height="25px" Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_billdate_CalendarExtender" runat="server" 
                                    CssClass="red" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_billdate">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Son/Daughter</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_sdname" runat="server" CssClass="SmalldottedTextBox" 
                                    onkeypress="return AllowNumbersOnly(this,event)" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                Tin No</td>
                            <td class="ui-priority-primary">
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txt_tinno" runat="server" CssClass="SmalldottedTextBox" 
                                    onkeypress="return AllowNumbersOnly(this,event)" Width="200px" 
                                    AutoPostBack="false" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Address</td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_address" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="200px" Rows="4" TextMode="MultiLine" Enabled="False" 
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>
                                D.O</td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_do" runat="server" CssClass="SmalldottedTextBox" 
                                    onkeypress="return AllowNumbersOnly(this,event)" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                Phone No</td>
                            <td class="style3">
                                :
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="txt_phoneno" runat="server" CssClass="SmalldottedTextBox" 
                                    onkeypress="return AllowNumbersOnly(this,event)" ReadOnly="True" 
                                    Width="200px" Enabled="False"></asp:TextBox>
                            </td>
                            <td class="style2">
                                HYP</td>
                            <td class="style3">
                                :</td>
                            <td class="style2">
                                <asp:TextBox ID="txt_hyp" runat="server" CssClass="SmalldottedTextBox" 
                                    onkeypress="return AllowNumbersOnly(this,event)" Width="200px"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td colspan="6" 
                                style="border-bottom-style: groove; border-bottom-width: medium; border-bottom-color: #000000">
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                        </tr>
                         <tr>
                            <td>
                                VehicleType</td>
                            <td class="ui-priority-primary">
                                &nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddl_VType" runat="server" AutoPostBack="True" 
                                    CssClass="SmalldottedTextBox" Height="26px" 
                                    onselectedindexchanged="ddl_VType_SelectedIndexChanged" Width="200px">
                                    <asp:ListItem>...Select...</asp:ListItem>
                                    <asp:ListItem>HCV</asp:ListItem>
                                    <asp:ListItem>LCV</asp:ListItem>
                                </asp:DropDownList>
                             </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Select Lcv Type" Visible="False"></asp:Label>
                             </td>
                            <td class="ui-priority-primary">
                                &nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddl_lcvtype" runat="server" AutoPostBack="True" 
                                    CssClass="SmalldottedTextBox" Height="26px" 
                                    Width="200px" 
                                    Visible="False" onselectedindexchanged="ddl_lcvtype_SelectedIndexChanged">
                                    <asp:ListItem>...Select...</asp:ListItem>
                                    <asp:ListItem>Commercial</asp:ListItem>
                                    <asp:ListItem>Passenger</asp:ListItem>
                                </asp:DropDownList>
                             </td>
                        </tr>
                        <tr>
                            <td>
                                T.C NO</td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_tcno" runat="server" BorderStyle="None" 
                                    CssClass="SmalldottedTextBox" Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" ReadOnly="True" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                Model
                            </td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                <asp:DropDownList ID="ddl_model" runat="server" AutoPostBack="True" 
                                    CausesValidation="True" onselectedindexchanged="ddl_model_SelectedIndexChanged" 
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Category</td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_category" runat="server" CssClass="SmalldottedTextBox" 
                                    Enabled="False" Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                Makers</td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_makers" runat="server" CssClass="SmalldottedTextBox" 
                                    Enabled="False" Height="25px" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Chassis No</td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                <asp:DropDownList ID="ddl_chessisno" runat="server" AutoPostBack="True" 
                                    CssClass="SmalldottedTextBox" Height="26px" 
                                     Width="200px" onselectedindexchanged="ddl_chessisno_SelectedIndexChanged">
                                  
                                </asp:DropDownList>
                            </td>
                            <td>
                                Engine No</td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_engineno" runat="server" CssClass="SmalldottedTextBox" 
                                    Height="25px" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Color</td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_color" runat="server" CssClass="SmalldottedTextBox" 
                                    Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                Key No</td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_keyno" runat="server" CssClass="SmalldottedTextBox" 
                                    Height="25px" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Battery Details</td>
                            <td>
                                :&nbsp; </td>
                            <td>
                                <asp:TextBox ID="txt_batterydetails" runat="server" CssClass="SmalldottedTextBox" 
                                    Height="25px"  
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;Horse Power</td>
                            <td>
                                &nbsp;:
                            </td>
                            <td>
                                <asp:TextBox ID="txt_horsepwr" runat="server" CssClass="SmalldottedTextBox" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fuel Used</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_fuelused" runat="server" CssClass="TextBoxGraiant" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" ReadOnly="false" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                No Cylinders</td>
                            <td>
                                :</td>
                            <td valign="bottom">
                                <asp:TextBox ID="txt_nocylinder" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                              <td>
                                  Maf Date</td>
                              <td>
                                  ;</td>
                              <td>
                                  <asp:TextBox ID="txt_mfdate" runat="server" CssClass="TextBoxGraiantDate" style="position:relative"
                                      Height="25px" Width="200px"></asp:TextBox>
                                  <asp:CalendarExtender ID="txt_mfdate_CalendarExtender" runat="server" 
                                      CssClass="red" Enabled="True" Format="MM/yyyy" 
                                      TargetControlID="txt_mfdate">
                                  </asp:CalendarExtender>
                              </td>
                              <td>
                                  Unladen Weight</td>
                              <td>
                                  :</td>
                              <td valign="bottom">
                                  <asp:TextBox ID="txt_uldnweight" runat="server" CssClass="SmalldottedTextBox" 
                                      Enabled="False" onkeypress="return AllowNumbersOnly(this,event)" 
                                      ReadOnly="True" Width="200px"></asp:TextBox>
                              </td>
                        </tr>
                        <tr>
                            <td>
                                Seat</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_Seat" runat="server" CssClass="SmalldottedTextBox" 
                                    Enabled="False" onkeypress="return AllowNumbersOnly(this,event)" 
                                    ReadOnly="True" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                Body Type</td>
                            <td>
                                :</td>
                            <td valign="bottom">
                                <asp:TextBox ID="txt_Bodytype" runat="server" CssClass="SmalldottedTextBox" 
                                    onkeypress="return AllowNumbersOnly(this,event)" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Gross Weight</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_grossweight" runat="server" CssClass="SmalldottedTextBox" 
                                    onkeypress="return AllowNumbersOnly(this,event)" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                Tyre Make</td>
                            <td>
                                :</td>
                            <td valign="bottom">
                                <asp:TextBox ID="txt_tyremake" runat="server" CssClass="SmalldottedTextBox" 
                                    onkeypress="return AllowNumbersOnly(this,event)" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Trade Mark No
                            </td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_trademarkno" runat="server" CssClass="SmalldottedTextBox" 
                                    onkeypress="return AllowNumbersOnly(this,event)" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                Tool Kit</td>
                            <td>
                                :</td>
                            <td valign="bottom">
                                <asp:DropDownList ID="ddl_toolkit" runat="server" AutoPostBack="True" 
                                    Width="200px">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Form 20/21/22</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_form" runat="server" CssClass="SmalldottedTextBox" 
                                    onkeypress="return AllowNumbersOnly(this,event)" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                Stephney</td>
                            <td>
                                :</td>
                            <td valign="bottom">
                                <asp:DropDownList ID="ddl_stepeny" runat="server" AutoPostBack="True" 
                                    Width="200px">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                Owner&#39;s Manual</td>
                            <td class="style2">
                                :</td>
                            <td class="style2">
                                <asp:DropDownList ID="ddl_owner" runat="server" AutoPostBack="True" 
                                     Width="200px">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style2" width="20%">
                                Battery Waranty Book</td>
                            <td class="style2">
                                :</td>
                            <td class="style2" valign="bottom">
                                <asp:DropDownList ID="ddl_baterywarenty" runat="server" AutoPostBack="True" 
                                    Width="200px">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                F.S. C Book</td>
                            <td>
                                :</td>
                            <td>
                                <asp:DropDownList ID="ddl_fscbook" runat="server" AutoPostBack="True" 
                                    Width="200px">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="20%">
                                Insurance</td>
                            <td>
                                :</td>
                            <td valign="bottom">
                                <asp:DropDownList ID="ddl_insurance" runat="server" AutoPostBack="True" 
                                    Width="200px">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Insurance Company</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_insurancecompany" runat="server" 
                                    CssClass="SmalldottedTextBox" onkeypress="return AllowNumbersOnly(this,event)" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td width="20%">
                                Rate</td>
                            <td>
                                :</td>
                            <td valign="bottom">
                                <asp:TextBox ID="txt_rate" runat="server" CssClass="SmalldottedTextBox" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="200px" >0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Quantity</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_Quantity" runat="server" CssClass="SmalldottedTextBox" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="200px" AutoPostBack="True" ontextchanged="txt_Quantity_TextChanged" 
                                    ReadOnly="True">1</asp:TextBox>
                            </td>
                            <td width="20%">
                                Amount</td>
                            <td>
                                :</td>
                            <td valign="bottom">
                                <asp:TextBox ID="txt_amount" runat="server" CssClass="SmalldottedTextBox" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="200px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Available Quantity</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_AvailQuantity" runat="server" 
                                    CssClass="SmalldottedTextBox" Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" ReadOnly="True" 
                                    Width="200px">0</asp:TextBox>
                            </td>
                            <td width="20%">
                                &nbsp;</td>
                            <td>
                                :</td>
                            <td valign="bottom">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6" 
                                style="border-bottom-style: groove; border-bottom-width: medium; border-bottom-color: #000000">
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                            <td>
                                Gross Amount
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_GrossAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Discount Amount
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_DiscountAmount" runat="server" CssClass="TextBoxGraiant" Width="160px"
                                    Height="25px"  onkeypress="return AllowDecimalNumbersOnly(this,event)">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Vat%<asp:TextBox ID="txtvat" runat="server" Width="40%" 
                                 onkeypress="return AllowDecimalNumbersOnly(this,event)"   CssClass="SmalldottedTextBox">14.5</asp:TextBox>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_vatamount" runat="server" CssClass="TextBoxGraiant" Enabled="False"
                                    Height="25px" Width="160px"  
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Add Other</td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_other" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="160px"  
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Bill Amount
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_billamount" runat="server" CssClass="TextBoxGraiant" Enabled="False"
                                    Height="25px" Width="160px"  
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;
                            </td>
                            <td class="style4">
                                &nbsp;
                            </td>
                            <td align="center" class="style4">
                                <asp:Button ID="btn_Submit" runat="server" CssClass="VerySmallGreen" Height="26px"
                                    Text="Submit" Width="120px" onclick="btn_Submit_Click" />
                            </td>
                            <td align="right" class="style4">
                                <asp:Button ID="btn_Cancel" runat="server" CssClass="VerySmallRed" Height="26px"
                                    Text="Cancel" Width="120px" />
                            </td>
                            <td class="style4">
                                &nbsp;
                            </td>
                            <td class="style4">
                                &nbsp;
                                <asp:Button ID="btn_update" runat="server" CssClass="VerySmallGreen" 
                                    Height="26px"  Text="Update" Width="120px" onclick="btn_update_Click" 
                                    Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
         
            </asp:Panel>
              <table width="100%">
                        <tr>
                            <td align="center" valign="top">
                                    &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <asp:Button ID="btnBookAdd" runat="server" CssClass="btn-info" Font-Bold="True" 
                                    Font-Names="US" OnClientClick="return PrintPanel()" Text="Print" 
                                    Visible="False" />
                                <asp:Button ID="btn_back" runat="server" BackColor="#0066FF" 
                                   Font-Bold="True" Font-Names="US" 
                                    Text="Back" Visible="False" ForeColor="White" onclick="btn_back_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                &nbsp;</td>
                        </tr>
                    </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
