<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Service_JobProformaInvoice.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

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
   
    <style type="text/css">
        .style1
        {
            width: 15%;
            height: 25px;
        }
        .style2
        {
            width: 1%;
            height: 25px;
        }
        .style3
        {
            width: 30%;
            height: 25px;
        }
        .style4
        {
            height: 25px;
        }
        .style5
        {
            height: 46px;
        }
        .style6
        {
            font-weight: bold;
            height: 46px;
        }
        .style7
        {
            height: 24px;
        }
        .style8
        {
            font-weight: bold;
            height: 24px;
        }
    .style9
    {
        height: 23px;
    }
        .style10
        {
            height: 27px;
        }
    </style>
    <script type="text/javascript">
        function sparedisc() {

            var totalspare = document.getElementById('ContentPlaceHolder1_txt_StotalAmount');
            var p = parseFloat(totalspare.value);
            var q = parseFloat(x - p);
            document.getElementById('ContentPlaceHolder1_txt_TotalSpareAmount').value = q.toFixed(2);

            var nowsparee = document.getElementById('ContentPlaceHolder1_txt_TotalSpareAmount');
            var nowvatamnt = document.getElementById('ContentPlaceHolder1_txt_SVatAmount');
            var nowsprr = parseFloat(nowsparee.value);
            var nowvv = parseFloat(nowvatamnt.value);
            var nowtttl = parseFloat(nowsprr + nowvv);
            document.getElementById('ContentPlaceHolder1_txt_ttotalAmount').value = (nowtttl).toFixed(2);


            var totalspare = document.getElementById('ContentPlaceHolder1_txt_ttotalAmount');
            var laberafter = document.getElementById('ContentPlaceHolder1_txt_LabourChargesAftDisc');
            var srvper = document.getElementById('ContentPlaceHolder1_txt_ServiceTaxPer');
            var eduper = document.getElementById('ContentPlaceHolder1_txt_edutaxpercent');
            var hreduper = document.getElementById('ContentPlaceHolder1_txt_hredupercent');
            var ab = laberafter.value;
            var a2 = srvper.value;
            var b2 = a2 / 100;
            var c2 = parseFloat(ab * b2);
            document.getElementById('ContentPlaceHolder1_txt_ServiceTaxAmt').value = (c2).toFixed(2);

            var a3 = eduper.value;
            var b3 = a3 / 100;
            var c3 = parseFloat(c2 * b3);
            document.getElementById('ContentPlaceHolder1_txteducessamount').value = (c3).toFixed(2);

            var a4 = hreduper.value;
            var b4 = a4 / 100;
            var c4 = parseFloat(c2 * b4);
            document.getElementById('ContentPlaceHolder1_txtSrhr').value = (c4).toFixed(2);
            document.getElementById('ContentPlaceHolder1_txt_sertaxamount').value = Math.round(c2 + c3 + c4).toFixed(2);

            var servicetax = document.getElementById('ContentPlaceHolder1_txt_sertaxamount');
            var outside = document.getElementById('ContentPlaceHolder1_txt_outsidecharge');
            var other = document.getElementById('ContentPlaceHolder1_txt_otherchrg');
            var bill = document.getElementById('ContentPlaceHolder1_txt_BillAmount');

            var totalspare1 = parseFloat(totalspare.value);
            var laberafter1 = parseFloat(laberafter.value);
            var servicetax1 = parseFloat(servicetax.value);
            var outside1 = parseFloat(outside.value);
            var other1 = parseFloat(other.value);
            var bill1 = parseFloat(totalspare1 + laberafter1 + servicetax1 + outside1 + other1);
            document.getElementById('ContentPlaceHolder1_txt_BillAmount').value = Math.round(bill1).toFixed(2);
        }


        function labourdisc() {

            var rate = document.getElementById('ContentPlaceHolder1_txt_LabourCharges');
            var discount = document.getElementById('ContentPlaceHolder1_txt_LabDiscountPer');
            var discountamnt = document.getElementById('ContentPlaceHolder1_txt_LabDiscountAmount');
            var x = parseFloat(rate.value);
            var y = discount.value;
            var z = y / 100;
            var b = parseFloat(x * z);
            document.getElementById('ContentPlaceHolder1_txt_LabDiscountAmount').value = b.toFixed(2);
            var amnt = document.getElementById('ContentPlaceHolder1_txt_LabDiscountAmount');
            var p = parseFloat(amnt.value);
            var q = parseFloat(x - p);
            document.getElementById('ContentPlaceHolder1_txt_LabourChargesAftDisc').value = q.toFixed(2);

            var tt2 = document.getElementById('ContentPlaceHolder1_txt_ttotalAmount');
            var tt3 = document.getElementById('ContentPlaceHolder1_txt_LubricantttotalAmount');
            var bb2 = parseFloat(tt2.value);
            var bb3 = parseFloat(tt3.value);

            var totalspare = parseFloat(bb2 + bb3);
            var laberafter = document.getElementById('ContentPlaceHolder1_txt_LabourChargesAftDisc');

            var srvper = document.getElementById('ContentPlaceHolder1_txt_ServiceTaxPer');

            var ab = laberafter.value;
            var a2 = srvper.value;
            var b2 = a2 / 100;
            var c2 = parseFloat(ab * b2);
            document.getElementById('ContentPlaceHolder1_txt_ServiceTaxAmt').value = (c2).toFixed(2);


            var servicetax = document.getElementById('ContentPlaceHolder1_txt_ServiceTaxAmt');
            var bill = document.getElementById('ContentPlaceHolder1_txt_BillAmount');

            var totalspare1 = parseFloat(totalspare);
            var laberafter1 = parseFloat(laberafter.value);
            var servicetax1 = parseFloat(servicetax.value);
            var bill1 = parseFloat(totalspare1 + laberafter1 + servicetax1);
            document.getElementById('ContentPlaceHolder1_txt_BillAmount').value = Math.round(bill1).toFixed(2);
        }

     function other() {

        
         var totalspare = document.getElementById('ContentPlaceHolder1_txt_TotalSpareAmount');
         var laberafter = document.getElementById('ContentPlaceHolder1_txt_LabourChargesAftDisc');
         var servicetax = document.getElementById('ContentPlaceHolder1_txt_sertaxamount');
         var outside = document.getElementById('ContentPlaceHolder1_txt_outsidecharge');
         var other = document.getElementById('ContentPlaceHolder1_txt_otherchrg');
         var bill = document.getElementById('ContentPlaceHolder1_txt_BillAmount');

         var totalspare1 = parseFloat(totalspare.value);
         var laberafter1 = parseFloat(laberafter.value);
         var servicetax1 = parseFloat(servicetax.value);
         var other1 = parseFloat(other.value);
         var outside1 = parseFloat(outside.value);
         var bill1 = parseFloat(totalspare1 + laberafter1 + servicetax1 + other1 + outside1);
         document.getElementById('ContentPlaceHolder1_txt_BillAmount').value = bill1.toFixed(2);
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
                            Jobcard Proforma Invoice</h3>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td class="style1">
                                Si No</td>
                            <td class="style2">
                                <strong>:</strong>
                            </td>
                            <td class="style3">
                                <asp:TextBox ID="txt_serialno" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="200px" Enabled="False"></asp:TextBox>
                            </td>
                            <td class="style1">
                                Inv No</td>
                            <td class="style2">
                                <strong>:</strong>
                            </td>
                            <td class="style4">
                                <asp:TextBox ID="txt_invno" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td class="style4">
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                :Inv Date</td>
                            <td class="style7">
                                :</td>
                            <td class="style7">
                                <asp:TextBox ID="txt_invdate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Height="25px" Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_invdate_CalendarExtender" runat="server" 
                                    CssClass="red" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_invdate">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                Tax Type</td>
                            <td class="style8">
                                :</td>
                            <td class="style7">
                                <asp:DropDownList ID="ddl_invtype" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px" AutoPostBack="True"  Enabled="false"
                                    onselectedindexchanged="ddl_invtype_SelectedIndexChanged">
                                    <asp:ListItem Value="Spare_TaxSales" Selected="True">Tax Invoice</asp:ListItem>
                                    <asp:ListItem Value="Spare_RetailSales">Retail Invoice</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style7">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                J.C No</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_jcno" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="50px" AutoPostBack="True" 
                                    ontextchanged="txt_jcno_TextChanged"></asp:TextBox>

                             Fin.Year   <asp:TextBox ID="txt_jcyear" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="100px" 
                                    ></asp:TextBox>
                            </td>
                            <td>
                                Payment Type</td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                <asp:DropDownList ID="ddl_paymenttype" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px">
                                    <asp:ListItem>Cash</asp:ListItem>
                                    <asp:ListItem>Credit</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Service Type</td>
                            <td>
                                :</td>
                            <td>
                                <asp:DropDownList ID="ddl_servicetype" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px">
                                     <asp:ListItem>...Select...</asp:ListItem>
                                                 <asp:ListItem>NONE</asp:ListItem>
                                    <asp:ListItem>PAID SERVICE</asp:ListItem>
                                   
                                    <asp:ListItem>FREE SERVICE</asp:ListItem>
                                    <asp:ListItem>WARRANTY</asp:ListItem>
                                    <asp:ListItem>AMC</asp:ListItem>
                                    <asp:ListItem>PDI</asp:ListItem>
                                    <asp:ListItem>1st FREE/5000</asp:ListItem>
                                    <asp:ListItem>2nd FREE/10000</asp:ListItem>
                                    <asp:ListItem>3rd FREE/20000</asp:ListItem>
                                    <asp:ListItem>4th FREE/30000</asp:ListItem>
                                    <asp:ListItem>Extended Warrenty</asp:ListItem>
                                    <asp:ListItem>POST WARRANTY</asp:ListItem>
                                    <asp:ListItem>Accident</asp:ListItem>
                                   <asp:ListItem>50th HR.</asp:ListItem>
                                      <asp:ListItem>Wheel Alignment</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                Regd. No.
                            </td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_RegdNo" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                Customer Name</td>
                            <td class="style5">
                                <strong>:</strong>
                            </td>
                            <td class="style5">
                                <asp:DropDownList ID="ddl_customer" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px" Enabled="False" 
                                    >
                                </asp:DropDownList>
                            </td>
                            <td>
                                GSTIN/UIN</td>
                            <td class="style6">
                                :</td>
                            <td class="style5">
                                <asp:TextBox ID="txt_tin" Text="21AAEFR2761B1ZT" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td class="style5">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Model</td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_model" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                Address</td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_address" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Rows="4" TextMode="MultiLine" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Mob No.</td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_mobno" runat="server" CssClass="TextBoxGraiant" 
                                 onkeypress="return AllowDecimalNumbersOnly(this,event)" Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                &nbsp;
                            </td>
                            <td class="style9">
                                &nbsp;
                            </td>
                            <td class="style9">
                                &nbsp;
                            </td>
                            <td class="style9">
                                &nbsp;
                            </td>
                            <td class="style9">
                                &nbsp;
                            </td>
                            <td class="style9">
                                </td>
                            <td class="style9">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="7">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    CssClass="mGrid">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Part Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Itmcode" runat="server" Text='<%# Eval("Itm_code") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PartNumber">
                                            <ItemTemplate>
                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("Itm_Partno") %>'></asp:Label>
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
                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("SE_Quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label14" runat="server" Text='<%# Eval("SE_Rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="Label13" runat="server" Text='<%# Eval("SE_Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Disc %">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_discper" runat="server" Text='<%# Eval("SE_DiscountPer") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Discount">
                                            <ItemTemplate>
                                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("SE_Discount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gst">
                                            <ItemTemplate>
                                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("SE_Vat") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GstAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="Label17" runat="server" Text='<%# Eval("SE_Taxamount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="Label18" runat="server" Text='<%# Eval("SE_Total") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                     
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" rowspan="15" valign="top">
                               <table class="skin-3" id="tbl_service" runat="server"
                                    style="border-style: dashed; border-width: thin; border-color: #000000;">
                                    <tr bgcolor="#6fb3e0">
                                        <td class="ui-priority-primary">
                                            Service Code</td>
                                        <td class="ui-priority-primary">
                                            Description</td>
                                            <td class="ui-priority-primary">
                                            Ltype</td>
                                        <td class="ui-priority-primary">
                                            Quantity</td>
                                        <td class="ui-priority-primary">
                                            Rate</td>
                                            <td class="ui-priority-primary">
                                            Dis%</td>
                                            <td class="ui-priority-primary">
                                            DisAmt.</td>
                                        <td class="ui-priority-primary">
                                            Amount</td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2" style="position:relative">
                                            <asp:TextBox ID="txt_SCode" runat="server" AutoPostBack="True" 
                                                CssClass="SmalldottedTextBox" ontextchanged="txt_SCode_TextChanged" 
                                                Width="120px"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txt_SCode_AutoCompleteExtender" runat="server" 
                                                CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="GetServiceCode" ServicePath="" 
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_SCode">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                        <td class="style2" style="position:relative">
                                            <asp:TextBox ID="txt_SDescription" runat="server" CssClass="SmalldottedTextBox" 
                                                Width="100px" AutoPostBack="True" 
                                                ontextchanged="txt_SDescription_TextChanged"></asp:TextBox>
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
                                        <asp:DropDownList ID="drp_labtype" runat="server" CssClass="TextBoxGraiant" 
                                    Width="100px" AutoPostBack="True" 
                                                onselectedindexchanged="drp_labtype_SelectedIndexChanged">

                                    <asp:ListItem>...Select...</asp:ListItem>
                                    <asp:ListItem>PAID</asp:ListItem>
                                 <asp:ListItem>WARRANTY</asp:ListItem>
                                    <asp:ListItem>AMC</asp:ListItem>
                                    <asp:ListItem>FOC</asp:ListItem>

                                   
                                 
                                    
                                </asp:DropDownList>
                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="txt_SQuantity" runat="server" CssClass="SmalldottedTextBox" 
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="80px" 
                                                AutoPostBack="True" ontextchanged="txt_SQuantity_TextChanged"></asp:TextBox>
                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="txt_SRate" runat="server" CssClass="SmalldottedTextBox" 
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="80px" 
                                                AutoPostBack="True" ontextchanged="txt_SRate_TextChanged"></asp:TextBox>
                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="txt_disc" runat="server" CssClass="SmalldottedTextBox" 
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="50px" 
                                                AutoPostBack="True" ontextchanged="txt_disc_TextChanged">0</asp:TextBox>
                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="txt_discamu" ReadOnly="true" runat="server" CssClass="SmalldottedTextBox" 
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="50px">0</asp:TextBox>
                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="txt_SAmount" runat="server" CssClass="SmalldottedTextBox" 
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" Enabled="false" Width="80px"></asp:TextBox>
                                        </td>
                                        <td class="style2">
                                            <asp:Button ID="btn_ServiceAdd" runat="server" CssClass="VerySmallYellow" 
                                                Height="28px" onclick="btn_ServiceAdd_Click" Text="Add" Width="40px" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                              <br />
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    CssClass="mGrid" Font-Names="Cambria" Font-Size="12px" Width="100%" 
                                    ShowFooter="True">
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
                    <asp:Label ID="Labels2" runat="server" 
                        Text='<%# Eval("JCS_Servicecode") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="120px" />
                <ItemStyle HorizontalAlign="Left" Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="Labels3" runat="server" Text='<%# Eval("JCS_Description") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="Labels4" runat="server" Text='<%# Eval("JCS_Quantity") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="50px" />
                <ItemStyle HorizontalAlign="Left" Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rate">
                <ItemTemplate>
                    <asp:Label ID="Labels5" runat="server" Text='<%# Eval("JCS_Rate") %>' ></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                <ItemStyle HorizontalAlign="Left" Width="80px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Dis%">
                <ItemTemplate>
                    <asp:Label ID="Labels55" runat="server" Text='<%# Eval("JCS_Disper") %>' ></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="50px" />
                <ItemStyle HorizontalAlign="Left" Width="50px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="DisAmt.">
                <ItemTemplate>
                    <asp:Label ID="Labels56" runat="server" Text='<%# Eval("JCS_DisAmu") %>' ></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="50px" />
                <ItemStyle HorizontalAlign="Left" Width="50px" />
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Amount">
                <FooterTemplate>
                    <asp:Label ID="lblgrandtotal" runat="server" Font-Bold="True"></asp:Label>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="Labels6" runat="server" ReadOnly="True" style="border:0px" 
                        Text='<%# Eval("JCS_Amount") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                <ItemStyle HorizontalAlign="Left" Width="80px" />
            </asp:TemplateField>
                                      
                                        <asp:TemplateField HeaderText="Save">
                                            <FooterTemplate>
                                                <asp:Label ID="lbledit" runat="server" Font-Bold="True"></asp:Label>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" Height="20px" 
                                                    ImageUrl="~/Admin/Images/edit-icon.png" onclick="ImageButton1_Click" 
                                                    ToolTip='<%# Eval("JCS_Sino") %>' />
                                                <asp:ImageButton ID="ImageButton2" runat="server" Height="20px" 
                                                    ImageUrl="~/Admin/Images/UPDATE (1).png" onclick="ImageButton2_Click" 
                                                    ToolTip='<%# Eval("JCS_Sino") %>' Visible="False" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="img_del" runat="server" Height="20px" 
                                                    ImageUrl="~/Admin/Images/Delete_Icon.png" onclick="img_del_Click" 
                                                    ToolTip='<%# Eval("JCS_Sino") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                      
                                    </Columns>
                                    <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
                                </asp:GridView>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 15%">
                                Gross Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txt_SGrossAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px" 
                                    ReadOnly="True">0.00</asp:TextBox>
                            </td>
                        </tr>
                           <tr>
                            <td>
                                &nbsp;</td>
                            <td style="background-color: #c0c0ff">
                               Lubricant Gross Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txt_lubricantGross" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px"  Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Discount@&nbsp;
                                <asp:TextBox ID="txt_tdiscper" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                     Width="40px" AutoPostBack="True" ontextchanged="txt_tdiscper_TextChanged">0</asp:TextBox>
                                &nbsp;% </td>
                            <td>
                                <asp:TextBox ID="txt_SerDiscountAmount" runat="server" 
                                    CssClass="TextBoxGraiant" Height="25px"  onkeyup="sparedisc()"
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr >
                            <td >
                                &nbsp;</td>
                            <td style="background-color: #c0c0ff">
                                Total</td>
                            <td >
                                <asp:TextBox ID="txt_StotalAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0.00</asp:TextBox>
                            </td>
                        </tr>
                       
                        <tr >
                            <td >
                                &nbsp;</td>
                            <td style="background-color: #c0c0ff">
                                Total Lubricant</td>
                            <td >
                                <asp:TextBox ID="txt_LubtotalAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="background-color: #c0c0ff">
                               Spare Gst Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txt_SVatAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px" Enabled="False">0.00</asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="background-color: #c0c0ff">
                               Lubricant Gst Amount
                            </td>
                            <td>
                               <asp:TextBox ID="txt_LubricantVatAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px" Enabled="False">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="background-color: #c0c0ff">
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
                            <td style="background-color: #c0c0ff">
                               Total Lubricant Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txt_LubricantttotalAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px"  Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Labour Charges</td>
                            <td>
                                <asp:TextBox ID="txt_LabourCharges" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px" Enabled="False">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                </td>
                            <td class="style10">
                                Discount@
                                <asp:TextBox ID="txt_LabDiscountPer" runat="server" CssClass="TextBoxGraiant" onkeyup="labourdisc()"
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="40px" ontextchanged="txt_LabDiscountPer_TextChanged" >0</asp:TextBox>
                                &nbsp;%</td>
                            <td class="style10">
                                <asp:TextBox ID="txt_LabDiscountAmount" runat="server" 
                                    CssClass="TextBoxGraiant" Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="background-color: #c0c0ff">
                                Labour After Discount</td>
                            <td>
                                <asp:TextBox ID="txt_LabourChargesAftDisc" runat="server" 
                                    CssClass="TextBoxGraiant" Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                </td>
                            <td colspan="2" class="style9">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Add Tax" 
                                    AutoPostBack="True" oncheckedchanged="CheckBox1_CheckedChanged" 
                                    Checked="True" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                            Tax @<asp:TextBox ID="txt_ServiceTaxPer" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="30px" ReadOnly="True">18</asp:TextBox>
                                &nbsp;%</td>
                            <td>
                                <asp:TextBox ID="txt_ServiceTaxAmt" runat="server" CssClass="TextBoxGraiant" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px" Enabled="False" 
                                   >0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                       
                            <td class="style4">
                                </td>
                            <td style="background-color: #FFFF00" class="style4">
                                &nbsp;Bill Amount</td>
                            <td class="style4">
                                <asp:TextBox ID="txt_BillAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                </td>
                            <td class="style9">
                                </td>
                            <td class="style9">
                                </td>
                        </tr>
                        <tr>
                           
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
                                &nbsp;</td>
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
