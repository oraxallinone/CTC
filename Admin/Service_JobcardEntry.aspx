<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Service_JobcardEntry.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">




    <script type="text/javascript" src="js/libs/jquery-2.0.2.min.js"></script>

    <script type="text/javascript">
        
        $(document).ready(function () {
           
            debugger;

           $("body").on("change", "#ContentPlaceHolder1_txt_SCode", function () {
            //$("#ContentPlaceHolder1_txt_SCode").live('change', function () {
                var scode = $('#ContentPlaceHolder1_txt_SCode').val();
                var sdate = '{partno: "' + scode + '" }'

                $.ajax({
                    type: "POST",
                    url: "Service_JobcardEntry.aspx/GetAllitems",
                    data: sdate,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var value = data.d[0];
                        $('#<%= txt_SCode.ClientID %>').val(value.Itm_code);
                        $('#<%= txt_SDescription.ClientID %>').val(value.Itm_PartDescrption);
                        $('#<%= txt_SRate.ClientID %>').val(value.Mh_ServiceRate);
                    },
                    error: function (data) {
                        alert("fail");
                    }
                });
            });






            //dec wise search
            $("body").on("change", "#ContentPlaceHolder1_txt_SDescription", function () {
                var sdesc = $('#ContentPlaceHolder1_txt_SDescription').val();
                var sdescData = '{partdesc: "' + sdesc + '" }'

                $.ajax({
                    type: "POST",
                    url: "Service_JobcardEntry.aspx/GetAllitemsbyDesc",
                    data: sdescData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var value = data.d[0];
                        $('#<%= txt_SCode.ClientID %>').val(value.Itm_code);
                        $('#<%= txt_SDescription.ClientID %>').val(value.Itm_PartDescrption);
                        $('#<%= txt_SRate.ClientID %>').val(value.Mh_ServiceRate);
                    },
                    error: function (data) {
                        alert("fail");
                    }
                });
             });





        });
    </script>




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


    <%--  <script src="js/ServiceEstimateEntryCal.js" type="text/javascript"></script>
    --%>


    <script type="text/jscript">

        function validationfields1() {
            var v = 0;


            if (document.getElementById('ContentPlaceHolder1_txt_jcno').value == "") {
                alert("Voucher Number Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_date').value == "") {
                alert("Date  Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_regdno').value == "") {
                alert("Regd No  Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_engineno').value == "") {
                alert("Engine No  Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_ddl_Model').selectedIndex == 0) {
                alert("'Please Select Model Name ..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_kcovered').value == "") {
                alert("'Km. Covered  Should Not Be Blank ..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_ddl_servicetype').selectedIndex == 0) {
                alert("'Please Select Service Type ..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_ddl_supervisor').selectedIndex == 0) {
                alert("'Please Select Superviser Name ..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_ddl_technisian').selectedIndex == 0) {
                alert("'Please Select Technician Name ..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_ddl_customer').selectedIndex == 0) {
                alert("'Please Select Customer Name ..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_address').value == "") {
                alert("Address Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_phoneno').value == "") {
                alert("Phone No Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_supplay').value == "") {
                alert("Place Of Supply Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_complain').value == "") {
                alert("Customer Complain Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_drp_state').selectedIndex == 0) {
                alert("'Please Select State Code ..!!");

                return false;
            }
            document.getElementById('ContentPlaceHolder1_btn_Submit').style.visibility = "hidden";
        }






        function validationfields() {
            var v = 0;

            if (document.getElementById('ContentPlaceHolder1_txt_jcno').value == "") {
                alert("Voucher Number Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_date').value == "") {
                alert("Date  Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_regdno').value == "") {
                alert("Regd No  Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_engineno').value == "") {
                alert("Engine No  Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_ddl_Model').selectedIndex == 0) {
                alert("'Please Select Model Name ..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_kcovered').value == "") {
                alert("'Km. Covered  Should Not Be Blank ..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_ddl_servicetype').selectedIndex == 0) {
                alert("'Please Select Service Type ..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_ddl_supervisor').selectedIndex == 0) {
                alert("'Please Select Superviser Name ..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_ddl_technisian').selectedIndex == 0) {
                alert("'Please Select Technician Name ..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_ddl_customer').selectedIndex == 0) {
                alert("'Please Select Customer Name ..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_address').value == "") {
                alert("Address Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_phoneno').value == "") {
                alert("Phone No Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_drp_state').selectedIndex == 0) {
                alert("'Please Select State Code ..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_SCode').value == "") {
                alert("Service Code Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_SDescription').value == "") {
                alert("Description Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_drp_labtype').selectedIndex == 0) {
                alert("'Please Select Labour Type ..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_SQuantity').value == "") {
                alert("Quantity Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_SQuantity').value == "0") {
                alert("Quantity Should Not Be zero..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_SRate').value == "") {
                alert("Rate Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_SRate').value == "0") {
                alert("Rate Should Not Be Zero..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_SRate').value == "0.00") {
                alert("Rate Should Not Be zero..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_SAmount').value == "") {
                alert("Amount Should Not Be Blank..!!");

                return false;
            }

            // document.getElementById('ContentPlaceHolder1_btn_ServiceAdd0').style.visibility = "hidden";

        }

    </script>


    <style type="text/css">
        .style1 {
            height: 23px;
        }

        .style2 {
            font-weight: bold;
            height: 23px;
        }
    </style>
    <style type="text/css">
        .timepicker span table tbody tr td input {
            height: 20px !important;
            width: 20px !important;
        }
    </style>


































</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DynamicLayout="true" runat="server">
        <ProgressTemplate>
            <div class="modall">
                <div class="centerr">

                    <img alt="progress" src="Images/processing.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

       
        <ContentTemplate >
           
            

            <div id="content" style="background-color: #FFFFFF; padding-left: 15px; padding-right: 10px;">
                <fieldset style="padding-right: 20px;">
                    <legend>
                        <h3>Job Card Entry</h3>
                    </legend>
                    <table style="width: 100%;">

                        <tr>
                            <td colspan="2">Finacial Year</td>
                            <td colspan="2">:</td>
                            <td colspan="2" style="position: relative">
                                <asp:DropDownList ID="txt_jcyear" runat="server" CssClass="TextBoxGraiant"
                                    Height="25px" Width="200px" AutoPostBack="true"
                                    OnSelectedIndexChanged="txt_jcyear_SelectedIndexChanged">
                                    <asp:ListItem Value="">-Select-</asp:ListItem>
                                    <asp:ListItem Value="2018-19">2018-19</asp:ListItem>
                                    <%--<asp:ListItem Value="2017-18">2017-18</asp:ListItem>
                                    <asp:ListItem Value="2016-17">2016-17</asp:ListItem>--%>
                                    <%--  <asp:ListItem Value="2018-19">2018-19</asp:ListItem>--%>
                                    <%--   <asp:ListItem>2019-20</asp:ListItem>--%>
                                </asp:DropDownList>
                                <%--  <asp:TextBox ID="txt_jcyear" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                   AutoPostBack="True"   Width="100px" ontextchanged="txt_jcyear_TextChanged"  ></asp:TextBox>
                                   <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                                CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="Getfinacial" ServicePath="" 
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_jcyear">
                                            </asp:AutoCompleteExtender>--%>
                            </td>
                            <td colspan="2" style="width: 2%;">&nbsp;</td>
                            <td colspan="2" style="width: 15%;"></td>
                            <td colspan="2"></td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">Engine No</td>
                            <td colspan="2">:</td>
                            <td colspan="2" style="position: relative">
                                <asp:TextBox ID="txt_engineno" runat="server"
                                    CssClass="TextBoxGraiant" OnTextChanged="txt_engineno_TextChanged"
                                    Width="200px" AutoPostBack="True"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="txt_engineno_AutoCompleteExtender" runat="server"
                                    CompletionListCssClass="AutoExtender"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters=""
                                    EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                    ServiceMethod="Getengineno" ServicePath=""
                                    TargetControlID="txt_engineno">
                                </asp:AutoCompleteExtender>
                            </td>
                            <td colspan="2" style="width: 2%;">&nbsp;</td>
                            <td colspan="2" style="width: 15%;">Customer Name</td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddl_customer" runat="server" AutoPostBack="True"
                                    CssClass="TextBoxGraiant"
                                    OnSelectedIndexChanged="ddl_customer_SelectedIndexChanged" Width="200px">
                                </asp:DropDownList>

                            </td>
                            <td colspan="2">&nbsp;</td>
                        </tr>

                        <tr>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2" style="position: relative"></td>
                            <td colspan="2" style="width: 2%;">&nbsp;</td>
                            <td colspan="2" style="width: 15%;"></td>
                            <td colspan="2">
                                <asp:Button ID="btn_new" runat="server" CssClass="VerySmallGreen"
                                    OnClick="btn_new_Click" Text="New" />

                                <asp:Button ID="btn_refresh" runat="server" CssClass="VerySmallGreen"
                                    OnClick="btn_refresh_Click" Text="Refresh" />
                            </td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">Chasis No.</td>
                            <td colspan="2">:</td>
                            <td colspan="2" style="position: relative">
                                <asp:TextBox ID="txt_chassisno" runat="server"
                                    CssClass="TextBoxGraiant" OnTextChanged="txt_chassisno_TextChanged"
                                    Style="position: relative" Width="200px" AutoPostBack="True"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="txt_chassisno_AutoCompleteExtender"
                                    runat="server" CompletionListCssClass="AutoExtender"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters=""
                                    EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                    ServiceMethod="Getchasisno" ServicePath=""
                                    TargetControlID="txt_chassisno">
                                </asp:AutoCompleteExtender>

                            </td>
                            <td colspan="2" style="width: 2%;">&nbsp;</td>
                            <td colspan="2">Address</td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_address" runat="server" CssClass="TextBoxGraiant"
                                    TextMode="MultiLine" Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" width="10%">Regd No</td>
                            <td colspan="2" width="2%">&nbsp;</td>
                            <td colspan="2" width="25%" style="position: relative">

                                <asp:TextBox ID="txt_regdno" runat="server" CssClass="TextBoxGraiant"
                                    Height="25px" Width="200px" AutoPostBack="True"
                                    OnTextChanged="txt_regdno_TextChanged"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="txt_regdno_AutoCompleteExtender"
                                    runat="server" CompletionListCssClass="AutoExtender"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters=""
                                    EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                    ServiceMethod="Getregisno" ServicePath=""
                                    TargetControlID="txt_regdno">
                                </asp:AutoCompleteExtender>
                            </td>
                            <td align="right" colspan="2" style="width: 2%;">&nbsp;</td>
                            <td colspan="2">Ph. (O).</td>
                            <td align="right" colspan="2" width="5%">
                                <asp:TextBox ID="txt_phoneno" runat="server" CssClass="TextBoxGraiant"
                                    MaxLength="10" onkeypress="return AllowDecimalNumbersOnly(this,event)"
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" width="10%">&nbsp;</td>
                            <td colspan="2" width="2%">&nbsp;</td>
                            <td colspan="2" width="25%">&nbsp;</td>
                            <td align="right" colspan="2" style="width: 2%;">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td align="right" colspan="2" width="5%">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 15%" colspan="2">J.C. No.</td>
                            <td style="width: 1%" colspan="2">
                                <strong>:</strong>
                            </td>
                            <td style="width: 30%" colspan="2">
                                <asp:TextBox ID="txt_jcno" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="80px" Enabled="False"></asp:TextBox>

                            </td>
                            <td colspan="2" style="width: 2%;">&nbsp;</td>
                            <td style="width: 1%" colspan="2" align="left">&nbsp;Date</td>
                            <td colspan="2" style="position: relative">
                                <asp:TextBox ID="txt_date" runat="server"
                                    CssClass="TextBoxGraiantDate" Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_date_CalendarExtender" runat="server"
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy"
                                    TargetControlID="txt_date"></asp:CalendarExtender>
                            </td>
                            <td colspan="1"></td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">
                                <strong>:</strong>
                            </td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2" style="width: 2%;">&nbsp;</td>
                            <td colspan="2" align="left">Sale Date</td>
                            <td colspan="2" style="position: relative">
                                <asp:TextBox ID="txt_saledate" runat="server" CssClass="TextBoxGraiantDate"
                                    Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_saledate_CalendarExtender" runat="server"
                                    CssClass="red" Enabled="True" Format="dd/MM/yyyy"
                                    TargetControlID="txt_saledate"></asp:CalendarExtender>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style1">Model</td>
                            <td class="style2" colspan="2">:
                            </td>
                            <td colspan="2" class="style1">
                                <asp:DropDownList ID="ddl_Model" runat="server" CssClass="TextBoxGraiant"
                                    Height="25px" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2"></td>
                            <td class="style1" colspan="2" align="left">Key&nbsp; No.</td>
                            <td colspan="2" class="style1" style="position: relative">
                                <asp:TextBox ID="txt_keyno" runat="server" CssClass="TextBoxGraiant"
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2" class="style1"></td>
                        </tr>
                        <tr>
                            <td colspan="2">Km Covered</td>
                            <td class="ui-priority-primary" colspan="2">:
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_kcovered" runat="server" CssClass="TextBoxGraiant"
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2" align="left">Technician</td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddl_technisian" runat="server" CssClass="TextBoxGraiant"
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="2">Repair Type</td>
                            <td class="ui-priority-primary" colspan="2">:
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddl_repair" runat="server" CssClass="TextBoxGraiant"
                                    Width="200px">

                                    <asp:ListItem>...Select...</asp:ListItem>
                                    <asp:ListItem>PAID SERVICE</asp:ListItem>
                                    <asp:ListItem>FREE SERVICE</asp:ListItem>
                                    <asp:ListItem>WARRANTY</asp:ListItem>
                                    <asp:ListItem>AMC</asp:ListItem>
                                    <asp:ListItem>PDI</asp:ListItem>
                                    <asp:ListItem>Extended Warrenty</asp:ListItem>
                                    <asp:ListItem>POST WARRANTY</asp:ListItem>
                                    <asp:ListItem>Accident</asp:ListItem>
                                    <asp:ListItem>Break Down</asp:ListItem>

                                </asp:DropDownList>
                            </td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2" align="left">Hr. Mtr.</td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_hrmet" runat="server" CssClass="TextBoxGraiant"
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="2">Service Type</td>
                            <td colspan="2">:</td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddl_servicetype" runat="server" CssClass="TextBoxGraiant"
                                    Height="25px" Width="200px">
                                    <asp:ListItem>...Select...</asp:ListItem>
                                    <asp:ListItem>NONE</asp:ListItem>
                                    <asp:ListItem>1st FREE/5000</asp:ListItem>
                                    <asp:ListItem>2nd FREE/10000</asp:ListItem>
                                    <asp:ListItem>3rd FREE/20000</asp:ListItem>
                                    <asp:ListItem>4th FREE/30000</asp:ListItem>
                                    <asp:ListItem>50th HR.</asp:ListItem>
                                    <asp:ListItem>Wheel Alignment</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">&nbsp; </td>
                            <td colspan="2" align="left">Time</td>
                            <td colspan="2" style="position: relative">
                                <div class="timepicker">
                                    <MKB:TimeSelector ID="TimeSelector1" runat="server">
                                    </MKB:TimeSelector>
                                </div>
                                <%--<asp:Timer ID="Timer1" runat="server">
                                </asp:Timer>--%>
                                <%--<asp:MaskedEditExtender ID="txt_time_MaskedEditExtender" runat="server" 
                                    AcceptAMPM="true" Mask="99:99:99" MaskType="Time" MessageValidatorTip="true" 
                                    TargetControlID="txt_time">
                                </asp:MaskedEditExtender>--%>
                            </td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">Supervisor</td>
                            <td colspan="2">:
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddl_supervisor" runat="server"
                                    CssClass="TextBoxGraiant" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2" align="left">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="2">Delivery Date</td>
                            <td colspan="2">:</td>
                            <td colspan="2" style="position: relative">
                                <asp:TextBox ID="txt_deliverydate" runat="server" CssClass="TextBoxGraiantDate"
                                    Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_deliverydate_CalendarExtender" runat="server"
                                    CssClass="red" Enabled="True" Format="dd/MM/yyyy"
                                    TargetControlID="txt_deliverydate"></asp:CalendarExtender>
                                <%--<asp:MaskedEditExtender ID="txt_deliverydate_MaskedEditExtender" runat="server" TargetControlID="txt_deliverydate"
MaskType="Date" Mask="99/99/9999" MessageValidatorTip="true">
</asp:MaskedEditExtender>--%>
                                <%-- <asp:MaskedEditExtender ID="txt_BSaleDate1_MaskedEditExtender" runat="server" 
                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                    TargetControlID="txt_BSaleDate1">
                                </asp:MaskedEditExtender>--%>
                            
                            </td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2" align="left">State Code</td>
                            <td colspan="2" style="position: relative">
                                <asp:DropDownList ID="drp_state" runat="server" CssClass="TextBoxGraiant"
                                    Height="25px" Width="200px">
                                    <asp:ListItem>...Select...</asp:ListItem>

                                    <asp:ListItem Value='1'>Jammu & Kashmir</asp:ListItem>
                                    <asp:ListItem Value='2'>Himachal Pradesh</asp:ListItem>
                                    <asp:ListItem Value='3'>Punjab</asp:ListItem>
                                    <asp:ListItem Value='4'>Chandigarh</asp:ListItem>
                                    <asp:ListItem Value='5'>Uttranchal</asp:ListItem>
                                    <asp:ListItem Value='6'>Haryana</asp:ListItem>
                                    <asp:ListItem Value='7'>Delhi</asp:ListItem>
                                    <asp:ListItem Value='8'>Rajasthan</asp:ListItem>
                                    <asp:ListItem Value='9'>Uttar Pradesh</asp:ListItem>

                                    <asp:ListItem Value='10'>Bihar</asp:ListItem>
                                    <asp:ListItem Value='11'>Sikkim</asp:ListItem>
                                    <asp:ListItem Value='12'>Arunachal Pradesh</asp:ListItem>
                                    <asp:ListItem Value='13'>Nagaland</asp:ListItem>
                                    <asp:ListItem Value='14'>Manipur</asp:ListItem>
                                    <asp:ListItem Value='15'>Mizoram</asp:ListItem>
                                    <asp:ListItem Value='16'>Tripura</asp:ListItem>
                                    <asp:ListItem Value='17'>Meghalaya</asp:ListItem>
                                    <asp:ListItem Value='18'>Assam</asp:ListItem>

                                    <asp:ListItem Value='19'>West Bengal</asp:ListItem>
                                    <asp:ListItem Value='20'>Jharkhand</asp:ListItem>
                                    <asp:ListItem Value='21' Selected="True">Odisha</asp:ListItem>
                                    <asp:ListItem Value='22'>Chhattisgarh</asp:ListItem>
                                    <asp:ListItem Value='23'>Madhya Pradesh</asp:ListItem>
                                    <asp:ListItem Value='24'>Gujarat</asp:ListItem>
                                    <asp:ListItem Value='25'>Daman & Diu</asp:ListItem>
                                    <asp:ListItem Value='26'>Dadra & Nagar Haveli</asp:ListItem>
                                    <asp:ListItem Value='27'>Maharashtra</asp:ListItem>
                                    <asp:ListItem Value='28'>Andhra Pradesh </asp:ListItem>
                                    <asp:ListItem Value='29'>Karnataka</asp:ListItem>
                                    <asp:ListItem Value='30'>Goa</asp:ListItem>
                                    <asp:ListItem Value='31'>Lakshdweep</asp:ListItem>
                                    <asp:ListItem Value='32'>Kerala</asp:ListItem>
                                    <asp:ListItem Value='33'>Tamil Nadu</asp:ListItem>
                                    <asp:ListItem Value='34'>Pondicherry</asp:ListItem>
                                    <asp:ListItem Value='35'>Andaman and Nicobar Islands</asp:ListItem>

                                    <asp:ListItem Value='36'>Telangana</asp:ListItem>



                                    <%-- <asp:ListItem Value='37'>Andhra Pradesh (New)</asp:ListItem>--%>
                                </asp:DropDownList>
                                <%--   <asp:TextBox ID="txt_statecode" runat="server" Text="21" Width="150px"></asp:TextBox>--%></td>
                            <td colspan="2">&nbsp;</td>
                        </tr>

                        <tr>
                            <td colspan="2">Place Of Supplay</td>
                            <td class="ui-priority-primary" colspan="2">:
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_supplay" runat="server" CssClass="TextBoxGraiant"
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2" align="left"></td>
                            <td colspan="2"></td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>

                            <td colspan="2">Customer Complain</td>
                            <td class="ui-priority-primary" colspan="2">:
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_complain" TextMode="MultiLine" runat="server" CssClass="TextBoxGraiant"
                                    Width="200px" Height="80px"></asp:TextBox>
                            </td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2" align="left"></td>
                            <td colspan="2"></td>
                            <td colspan="2"></td>
                        </tr>

                        <tr>
                            <td colspan="10">&nbsp</td>
                        </tr>
                        <tr>
                            <td colspan="10">&nbsp</td>
                        </tr>


                        <tr>
                            <td colspan="14">
                                <table class="skin-3"
                                    style="border-style: dashed; border-width: thin; border-color: #000000;">
                                    <tr bgcolor="#6fb3e0">
                                        <td class="ui-priority-primary">Service Code</td>
                                        <td class="ui-priority-primary">Description</td>
                                        <td class="ui-priority-primary">Type</td>
                                        <td class="ui-priority-primary">Quantity</td>
                                        <td class="ui-priority-primary">Rate</td>
                                        <td class="ui-priority-primary">Amount</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="style2" style="position: relative">
                                            <asp:TextBox ID="txt_SCode" runat="server"
                                                CssClass="SmalldottedTextBox"
                                                Width="120px" ></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txt_SCode_AutoCompleteExtender" runat="server"
                                                CompletionListCssClass="AutoExtender"
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters=""
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetServiceCode" ServicePath=""
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_SCode">
                                            </asp:AutoCompleteExtender>


































                                        </td>

                                        <td class="style2" style="position: relative">
                                            <asp:TextBox ID="txt_SDescription" runat="server"
                                                CssClass="SmalldottedTextBox" Width="200px"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txt_SDescription_AutoCompleteExtender"
                                                runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters=""
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetServiceDesc" ServicePath=""
                                                ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_SDescription">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drp_labtype" runat="server" CssClass="TextBoxGraiant"
                                                Width="100px" AutoPostBack="True"
                                                OnSelectedIndexChanged="drp_labtype_SelectedIndexChanged1">

                                                <asp:ListItem Text="...Select...">...Select...</asp:ListItem>
                                                <asp:ListItem Text="PAID">PAID</asp:ListItem>
                                                <asp:ListItem Text="WARRANTY">WARRANTY</asp:ListItem>
                                                <asp:ListItem Text="AMC">AMC</asp:ListItem>
                                                <asp:ListItem Text="FOC">FOC</asp:ListItem>



                                            </asp:DropDownList>

                                            <%--  --%>


                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="txt_SQuantity" runat="server" CssClass="SmalldottedTextBox"
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="100px"
                                                AutoPostBack="True" OnTextChanged="txt_SQuantity_TextChanged"></asp:TextBox>
                                            <%----%>
                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="txt_SRate" runat="server" CssClass="SmalldottedTextBox"
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="100px"
                                                AutoPostBack="True" OnTextChanged="txt_SRate_TextChanged"></asp:TextBox>
                                            <%-- --%>
                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="txt_SAmount" runat="server" CssClass="SmalldottedTextBox"
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" Enabled="false" Width="100px"></asp:TextBox>
                                        </td>
                                        <td class="style2">
                                            <asp:Button ID="btn_ServiceAdd0" runat="server" CssClass="VerySmallYellow"
                                                OnClientClick="return validationfields();" Height="28px" OnClick="btn_ServiceAdd_Click" Text="Add" Width="40px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>



























                        <tr>
                            <td class="style1" colspan="2"></td>
                            <td class="style1" colspan="2"></td>
                            <td class="style1" colspan="2"></td>
                            <td class="style1" colspan="2"></td>
                            <td class="style1" colspan="2"></td>
                            <td class="style1" colspan="2"></td>
                            <td class="style1" colspan="2"></td>
                            <td class="style1" colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="14">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
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
                                        <asp:TemplateField HeaderText="LType">
                                            <ItemTemplate>
                                                <asp:Label ID="labelltype" runat="server" Text='<%# Eval("Mh_ServiceType") %>'></asp:Label>
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
                                            <FooterTemplate>
                                                <asp:Label ID="lblgrandtotal" runat="server" Font-Bold="True"></asp:Label>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Labels6" runat="server" Text='<%# Eval("Se_Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="key" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_key" runat="server" Text='<%# Eval("key") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtn_SDelete" runat="server" Height="20px"
                                                    ImageUrl="~/Admin/Images/Delete_Icon.png" OnClick="imgbtn_SDelete_Click"
                                                    ToolTip='<%# Eval("Mh_ServiceCode") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">
                                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                        </tr>

                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;
                            </td>
                            <td colspan="2">&nbsp;
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="btn_Submit" runat="server" CssClass="VerySmallGreen"
                                    Height="26px" OnClientClick="return validationfields1();" OnClick="btn_Submit_Click" Text="Submit" Width="120px" />
                            </td>
                            <td align="right" colspan="2">
                                <asp:Button ID="btn_Cancel" runat="server" CssClass="VerySmallRed"
                                    Height="26px" OnClick="btn_Cancel_Click" Text="Cancel" Width="120px" />
                            </td>
                            <td colspan="2">&nbsp;
                            </td>
                            <td colspan="2">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="12">&nbsp;
                            </td>
                            <td colspan="2"></td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
   
</asp:Content>
