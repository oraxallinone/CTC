<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Service_JobEstimateEntry.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

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
    <%--<script src="js/ServiceEstimateEntryCal.js" type="text/javascript"></script>--%>
     <script type="text/javascript">

         function sparedisc() {

             var totalspare = document.getElementById('ContentPlaceHolder1_txt_ATotalSpareAmount');
             var discountper = document.getElementById('ContentPlaceHolder1_txt_tdiscper');
             var discountamnt = document.getElementById('ContentPlaceHolder1_txt_tdiscamnt');
             var totalspareamount = document.getElementById('ContentPlaceHolder1_txt_ttotalAmount');
             var x = parseFloat(totalspare.value);
             var y = discountper.value;
             var z = y / 100;
             var b = parseFloat(x * z);
             document.getElementById('ContentPlaceHolder1_txt_tdiscamnt').value = b.toFixed(2);
             var amnt = document.getElementById('ContentPlaceHolder1_txt_tdiscamnt');
             var p = parseFloat(amnt.value);
             var q = parseFloat(x - p);
             document.getElementById('ContentPlaceHolder1_txt_ttotalAmount').value = q.toFixed(2);

             var totalspare = document.getElementById('ContentPlaceHolder1_txt_ttotalAmount');
             var laberafter = document.getElementById('ContentPlaceHolder1_txt_ALabourChargesAftDisc');
             var servicetax = document.getElementById('ContentPlaceHolder1_txt_AServiceTaxAmt');

             var other = document.getElementById('ContentPlaceHolder1_txt_AOtherAmount');
             var bill = document.getElementById('ContentPlaceHolder1_txt_ABillAmount');

             var totalspare1 = parseFloat(totalspare.value);
             var laberafter1 = parseFloat(laberafter.value);
             var servicetax1 = parseFloat(servicetax.value);

             var other1 = parseFloat(other.value);
             var bill1 = parseFloat(totalspare1 + laberafter1 + servicetax1 + other1);
             document.getElementById('ContentPlaceHolder1_txt_ABillAmount').value = bill1.toFixed(2);
         }


         function labourdisc() {

             var rate = document.getElementById('ContentPlaceHolder1_txt_ALabourCharges');
             var discount = document.getElementById('ContentPlaceHolder1_txt_ALabDiscountPer');
             var discountamnt = document.getElementById('ContentPlaceHolder1_txt_ALabDiscountAmount');
             var x = parseFloat(rate.value);
             var y = discount.value;
             var z = y / 100;
             var b = parseFloat(x * z);
             document.getElementById('ContentPlaceHolder1_txt_ALabDiscountAmount').value = b.toFixed(2);
             var amnt = document.getElementById('ContentPlaceHolder1_txt_ALabDiscountAmount');
             var p = parseFloat(amnt.value);
             var q = parseFloat(x - p);
             document.getElementById('ContentPlaceHolder1_txt_ALabourChargesAftDisc').value = q.toFixed(2);

             var totalspare = document.getElementById('ContentPlaceHolder1_txt_ttotalAmount');
             var laberafter = document.getElementById('ContentPlaceHolder1_txt_ALabourChargesAftDisc');
             var servicetax = document.getElementById('ContentPlaceHolder1_txt_AServiceTaxAmt');

             var other = document.getElementById('ContentPlaceHolder1_txt_AOtherAmount');
             var bill = document.getElementById('ContentPlaceHolder1_txt_ABillAmount');

             var totalspare1 = parseFloat(totalspare.value);
             var laberafter1 = parseFloat(laberafter.value);
             var servicetax1 = parseFloat(servicetax.value);

             var other1 = parseFloat(other.value);
             var bill1 = parseFloat(totalspare1 + laberafter1 + servicetax1 + other1);
             document.getElementById('ContentPlaceHolder1_txt_ABillAmount').value = bill1.toFixed(2);
         }

         function other() {


             var totalspare = document.getElementById('ContentPlaceHolder1_txt_ttotalAmount');
             var labrafterdisc = document.getElementById('ContentPlaceHolder1_txt_ALabourChargesAftDisc');
             var service = document.getElementById('ContentPlaceHolder1_txt_AServiceTaxAmt');
             var other = document.getElementById('ContentPlaceHolder1_txt_AOtherAmount');


             var totalspare1 = parseFloat(totalspare.value);
             var labrafterdisc1 = parseFloat(labrafterdisc.value);
             var service1 = parseFloat(service.value);
             var other1 = parseFloat(other.value);


             var bill1 = parseFloat(totalspare1 + other1 + labrafterdisc1 + service1);
             document.getElementById('ContentPlaceHolder1_txt_ABillAmount').value = bill1.toFixed(2);
         }
         function totalamnt() {


             var quant = document.getElementById('ContentPlaceHolder1_txt_SQuantity');
             var rate = document.getElementById('ContentPlaceHolder1_txt_SRate');
             var ttlamnt = document.getElementById('ContentPlaceHolder1_txt_SAmount');


             var quant1 = parseFloat(quant.value);
             var rate1 = parseFloat(rate.value);
             var ttl =quant1*rate1; 

             document.getElementById('ContentPlaceHolder1_txt_SAmount').value = ttl.toFixed(2);
         }
     </script>
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
                            Job Card Estimate Entry</h3>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%">
                                Estimate No</td>
                            <td style="width: 1%">
                                <strong>:</strong>
                            </td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txt_BEstimateNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="200px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%">
                                Estimate Date</td>
                            <td style="width: 1%">
                                <strong>:</strong>
                            </td>
                            <td style="position:relative">
                                <asp:TextBox ID="txt_BEstimateDate" runat="server" 
                                    CssClass="TextBoxGraiantDate" Height="25px" Width="150px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_BEstimateDate_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_BEstimateDate">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Name</td>
                            <td>
                                <strong>:</strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_BCustomer" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="250px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td class="ui-priority-primary">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Model</td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_BModel" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="250px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                Regd. No.
                            </td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_BRegdNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="150px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Chasis No.</td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_BChasisNo" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="150px"></asp:TextBox>
                            </td>
                            <td>
                                Engine No.</td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_BEngineNo" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="150px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sale Date
                            </td>
                            <td>
                                <strong>:</strong></td>
                            <td style="position:relative">
                                <asp:TextBox ID="txt_BSaleDate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Height="25px" Width="150px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_BSaleDate_CalendarExtender" runat="server" 
                                    CssClass="red" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_BSaleDate">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                Kilometer</td>
                            <td>
                                <strong>:</strong></td>
                            <td>
                                <asp:TextBox ID="txt_BKiloMeter" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="150px"></asp:TextBox>
                            </td>
                            <td>
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
                            <td>
                            </td>
                        </tr>
                        <%--<tr>
                            <td>
                                State Code
                            </td>
                            <td>
                                <strong>:</strong></td>
                            <td style="position:relative">
                                <asp:TextBox ID="txt_statecode" Text="21" runat="server" 
                                    Height="25px" Width="150px"></asp:TextBox>
                                
                            </td>
                            <td>
                                Place Of Supplier</td>
                            <td>
                                <strong>:</strong></td>
                            <td>
                                <asp:TextBox ID="txt_supp" runat="server"
                                    Height="25px" Width="150px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>--%>

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
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <table class="skin-3" style="border-style: dashed; border-width: thin; border-color: #000000;
                                    width: 800px;">
                                    <tr bgcolor="#6fb3e0">
                                        <td>
                                            <strong>Sl.No.</strong>
                                        </td>
                                        <td>
                                            <strong>PartNumber</strong>
                                        </td>
                                        <td>
                                            <strong>PartDescription</strong>
                                        </td>
                                        <td>
                                            <strong>Quantity</strong>
                                        </td>
                                        <td>
                                            <strong>Rate</strong>
                                        </td>
                                        <td>
                                            <strong>Amount</strong>
                                        </td>
                                        <td>
                                            <strong>Disc%</strong>
                                        </td>
                                        <td>
                                            <strong>Discount</strong>
                                        </td>
                                        <td>
                                            <strong>Gst</strong>
                                        </td>
                                        <td>
                                            <strong>TaxAmount</strong>
                                        </td>
                                        <td>
                                            <strong>Net Total</strong>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txt_PartSlNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="40px" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td style="position:relative">
                                            <asp:TextBox ID="txt_PartNo" runat="server" CssClass="TextBoxGraiant" Width="150px"
                                                Height="25px" OnTextChanged="txt_PartNo_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txt_PartNo_AutoCompleteExtender" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetPartNo" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_PartNo">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                        <td style="position:relative">
                                            <asp:TextBox ID="txt_PartDesc" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="150px" OnTextChanged="txt_PartDesc_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txt_PartDesc_AutoCompleteExtender" runat="server" CompletionListCssClass="wordWheel listMain .box"
                                                CompletionListItemCssClass="wordWheel itemsMain" CompletionListHighlightedItemCssClass="wordWheel itemsSelected"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetPartDesc" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_PartDesc">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartQuantity" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Font-Bold="True" ontextchanged="txt_PartQuantity_TextChanged" 
                                                AutoPostBack="True" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartRate" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartAmount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartDiscountper" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                ontextchanged="txt_disc_TextChanged" AutoPostBack="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartDiscount" runat="server" CssClass="TextBoxGraiant"
                                                Height="25px" Width="80px" 
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" ReadOnly="True">0</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartVat" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartTaxAmount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartTotal" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btn_PartAdd" runat="server" CssClass="VerySmallYellow" Height="28px"
                                                Text="Add" Width="40px" OnClick="btn_PartAdd_Click" />
                                        </td>
                                    </tr>
                                </table>
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
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="mGrid">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PartNumber">
                                            <ItemTemplate>
                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("Itm_Partno") %>' ></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PartDescription">
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("Ss_Quantity") %>' ></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label14" runat="server" Text='<%# Eval("Ss_Rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="Label13" runat="server" Text='<%# Eval("Ss_Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Disc %">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_discper" runat="server" Text='<%# Eval("Ss_DiscountPer") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Discount">
                                            <ItemTemplate>
                                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("Ss_Discount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gst">
                                            <ItemTemplate>
                                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("Ss_Vat") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TaxAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="Label17" runat="server" Text='<%# Eval("Ss_TaxAmont") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="Label18" runat="server" Text='<%# Eval("Ss_Total") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtn_PartDelete" runat="server" Height="18px" ImageUrl="~/Admin/Images/Delete_Icon.png"
                                                    ToolTip='<%# Eval("Itm_Partno") %>' OnClick="imgbtn_PartDelete_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="SL" Visible = "false">
                                            <ItemTemplate>
                                                 <asp:Label ID="lbl_SL_NO_Delete" runat="server" Text='<%# Eval("slno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" rowspan="11" valign="top">
                                <table class="skin-3" 
                                    style="border-style: dashed; border-width: thin; border-color: #000000;">
                                    <tr bgcolor="#6fb3e0">
                                        <td class="ui-priority-primary">
                                            Service Code</td>
                                        <td class="ui-priority-primary">
                                            Description</td>
                                        <td class="ui-priority-primary">
                                            Quantity</td>
                                        <td class="ui-priority-primary">
                                            Rate</td>
                                        <td class="ui-priority-primary">
                                            Amount</td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="position:relative">
                                            <asp:TextBox ID="txt_SCode" runat="server" AutoPostBack="True" 
                                                CssClass="SmalldottedTextBox" Width="120px" 
                                                ontextchanged="txt_SCode_TextChanged"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txt_SCode_AutoCompleteExtender" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetServiceCode" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_SCode">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                        <td style="position:relative">
                                            <asp:TextBox ID="txt_SDescription" runat="server" CssClass="SmalldottedTextBox" AutoPostBack="True"  
                                                Width="200px" ontextchanged="txt_SDescription_TextChanged"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txt_SDescription_AutoCompleteExtender" runat="server" 
                                            CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetServiceDesc" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_SDescription">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_SQuantity" runat="server" CssClass="SmalldottedTextBox"  onkeyup="totalamnt()"
                                                onkeypress="return AllowNumbersOnly(this,event)" Width="100px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_SRate" runat="server" CssClass="SmalldottedTextBox"  onkeyup="totalamnt()"
                                                onkeypress="return AllowNumbersOnly(this,event)" Width="100px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_SAmount" runat="server" CssClass="SmalldottedTextBox" 
                                                onkeypress="return AllowNumbersOnly(this,event)" Width="100px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_ServiceAdd" runat="server" CssClass="VerySmallYellow" 
                                                Height="28px" Text="Add" Width="40px" onclick="btn_ServiceAdd_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    CssClass="mGrid" Font-Names="Cambria" Font-Size="12px" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="Labels1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Service Code">
                                            <ItemTemplate>
                                                <asp:Label ID="Labels2" runat="server" Text='<%# Eval("Mh_ServiceCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="120px" />
                                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="Labels3" runat="server" Text='<%# Eval("Mh_ServiceHead") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="Labels4" runat="server" Text='<%# Eval("Se_Quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Labels5" runat="server" Text='<%# Eval("Se_Rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="Labels6" runat="server" Text='<%# Eval("Se_Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtn_SDelete" runat="server" Height="20px" 
                                                    ImageUrl="~/Admin/Images/Delete_Icon.png" 
                                                    ToolTip='<%# Eval("Mh_ServiceCode") %>' onclick="imgbtn_SDelete_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
                                </asp:GridView>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 15%">
                                Service Gross Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txt_AGrossAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Discount </td>
                            <td>
                                <asp:TextBox ID="txt_ASerDiscountAmount" runat="server" 
                                    CssClass="TextBoxGraiant" Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Net Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ANetAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Gst Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txt_AVatAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Total Amount</td>
                            <td>
                                <asp:TextBox ID="txt_ATotalSpareAmount" runat="server" 
                                    CssClass="TextBoxGraiant" Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Discount&nbsp;
                                <asp:TextBox ID="txt_tdiscper" runat="server" CssClass="TextBoxGraiant" onkeyup="sparedisc()" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="40px" >0</asp:TextBox>
                                &nbsp;%
                            </td>
                            <td>
                                <asp:TextBox ID="txt_tdiscamnt" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                               Total Spare Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ttotalAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px"  Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Labour Charges</td>
                            <td>
                                <asp:TextBox ID="txt_ALabourCharges" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Discount
                                <asp:TextBox ID="txt_ALabDiscountPer" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="40px" 
                                    ontextchanged="txt_ALabDiscountPer_TextChanged" AutoPostBack="True">0</asp:TextBox>
                                &nbsp;%</td>
                            <td>
                                <asp:TextBox ID="txt_ALabDiscountAmount" runat="server" 
                                    CssClass="TextBoxGraiant" Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Charges After Discount</td>
                            <td>
                                <asp:TextBox ID="txt_ALabourChargesAftDisc" runat="server" 
                                    CssClass="TextBoxGraiant" Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Tax
                                <asp:TextBox ID="txt_AServiceTaxPer" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="40px">18</asp:TextBox>
                                &nbsp;%</td>
                            <td>
                                <asp:TextBox ID="txt_AServiceTaxAmt" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                Other Charges</td>
                            <td>
                                <asp:TextBox ID="txt_AOtherAmount" runat="server" CssClass="TextBoxGraiant" onkeyup="other()"
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                Bill Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ABillAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                                </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center">
                                <asp:Button ID="btn_Submit" runat="server" CssClass="VerySmallGreen" Height="26px"
                                    Text="Submit" Width="120px" onclick="btn_Submit_Click" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btn_Cancel" runat="server" CssClass="VerySmallRed" Height="26px"
                                    Text="Cancel" Width="120px" onclick="btn_Cancel_Click" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
