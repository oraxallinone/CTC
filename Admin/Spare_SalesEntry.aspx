<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Spare_SalesEntry.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

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
<%--<script src="js/SparePurchaseEntryCal.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
       
        function other() {


            var totalspare = document.getElementById('ContentPlaceHolder1_txt_ATotal');
            var outside = document.getElementById('ContentPlaceHolder1_txt_APackagingAmt');
            var other = document.getElementById('ContentPlaceHolder1_txt_AOtherAmt');
           

            var totalspare1 = parseFloat(totalspare.value);
           
          
            var other1 = parseFloat(other.value);
            var outside1 = parseFloat(outside.value);
            var bill1 = parseFloat(totalspare1 + other1 + outside1);
            document.getElementById('ContentPlaceHolder1_txt_AFinalAmount').value = bill1.toFixed(2);
        }

        function validationfields() {
            var v = 0;
            if (document.getElementById('ContentPlaceHolder1_txt_BVoucherNo').value == "") {
                alert("Invoice Number Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_BDate').value == "") {
                alert("Bill Date Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_BName').value == "") {
                alert("Name Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_PartNo').value == "") {
                alert("Part Number Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_PartDesc').value == "") {
                alert("Part Description Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_PartQuantity').value == "") {
                alert("Quantity Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_PartRate').value == "") {
                alert("Rate Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_PartAmount').value == "") {
                alert("Amount Should Not Be Blank..!!");

                return false;
            }


            if (document.getElementById('ContentPlaceHolder1_txt_PartDiscount').value == "") {
                alert("Discount Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_PartVat').value == "") {
                alert("Vat Should Not Be Blank..!!");

                return false;
            }


            if (document.getElementById('ContentPlaceHolder1_txt_PartTaxAmount').value == "") {
                alert("Tax Amount Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_PartTotal').value == "") {
                alert("Total Should Not Be Blank..!!");

                return false;
            }
            //            if (document.getElementById('ContentPlaceHolder1_txt_returndate').value == "") {
            //                alert("Return date Should Not Be Blank..!!");

            //                return false;
            //            }
        }
           


        function btnSelete_Click() {

            if (document.getElementById('ContentPlaceHolder1_txt_fcyear').selectedIndex == 0) {
                alert("'Please Select Finacial Year ..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_BVoucherNo').value == "") {
                alert("Invoice Number Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_BDate').value == "") {
                alert("Invoice Date Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_BName').value == "") {
                alert("Name Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_AGrossAmount').value == "") {
                alert("Gross Amount Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_ADiscountAmount').value == "") {
                alert("Discount Amount Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_ANetAmount').value == "") {
                alert("Net Amount Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_AVatAmount').value == "") {
                alert("Vat Amount Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_ATotal').value == "") {
                alert("Total Amount Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_APackagingAmt').value == "") {
                alert("Packaging Amount Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_AOtherAmt').value == "") {
                alert("Other Amount Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_AFinalAmount').value == "") {
                alert("Final Amount Should Not Be Blank..!!");

                return false;
            }


            if (document.getElementById('ContentPlaceHolder1_submittedy').value == "") {
                alert("Please Enter your name..!!");

                document.getElementById('ContentPlaceHolder1_submittedy').focus();
                

                return false;
            }






            var strconfirm = confirm("Are you sure you want to Sale?");
            if (strconfirm == true) {
                document.getElementById('ContentPlaceHolder1_btn_Submit').style.visibility = "hidden";

                return true;
            }
            else {
                return false;
            }
        }
     </script>


    <style type="text/css">
        .style1
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
            <div id="content" style="background-color: #FFFFFF; padding-left: 15px; padding-right: 10px;">
                <fieldset style="padding-right: 20px;">
                    <legend>
                        <h3>
                            Spare Part Counter Sales</h3>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%">
                                Invoive No
                            </td>
                            <td style="width: 1%">
                                <strong>:</strong>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txt_BVoucherNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="120px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%">
                                Date</td>
                            <td style="width: 1%" class="ui-priority-primary">
                                :</td>
                            <td style="width: 20%; position:relative">
                                <asp:TextBox ID="txt_BDate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Height="25px" Width="120px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_BDate_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_BDate">
                                </asp:CalendarExtender>
                            </td>
                            <td style="width: 10%">
                                By</td>
                            <td style="width: 1%">
                                <strong>:</strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_BSaleBy" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="120px">
                                    <asp:ListItem>CREDIT</asp:ListItem>
                                    <asp:ListItem>CASH</asp:ListItem>
                                    <asp:ListItem>FOC</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sale Type</td>
                            <td>
                                <strong>:</strong></td>
                            <td>
                                <asp:DropDownList ID="ddl_BSaleType" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="120px">
                                    <asp:ListItem>DIRECT</asp:ListItem>
                                    <asp:ListItem>CHALLAN</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                Challan No</td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_BChalanNo0" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="120px"></asp:TextBox>
                            </td>
                            <td>
                                Challan Date</td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td style="position:relative">
                                <asp:TextBox ID="txt_BChallanDate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Height="25px" Width="120px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_BChallanDate_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_BChallanDate">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Party Name</td>
                            <td align="left" valign="top">
                                <strong>:</strong>&nbsp;
                            </td>
                            <td align="left" valign="top" style="position:relative">
                                <asp:TextBox ID="txt_BName" runat="server" AutoPostBack="True" 
                                    CssClass="TextBoxGraiant" Height="25px" ontextchanged="txt_BName_TextChanged" 
                                    Width="200px"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="txt_BName_AutoCompleteExtender" runat="server" 
                                    CompletionListCssClass="AutoExtender" 
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                    CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                    EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                    ServiceMethod="GetTagCNames" ServicePath="" 
                                    ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_BName">
                                </asp:AutoCompleteExtender>
                            </td>
                            <td align="left" valign="top">
                                GSTIN/UIN No.</td>
                            <td align="left" valign="top">
                                <strong>:</strong></td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txt_BTinSrinNo" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td align="left" valign="top">
                                Invoice Type</td>
                            <td class="ui-priority-primary" align="left" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                               <asp:DropDownList ID="ddl_invtype" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="120px" AutoPostBack="True" onselectedindexchanged="ddl_invtype_SelectedIndexChanged" Enabled="false">
                                    <asp:ListItem Value="Spare_TaxSales" Selected="True">Tax Invoice</asp:ListItem>
                                    <asp:ListItem Value="Spare_RetailSales">Retail Invoice</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                        </tr>
                        <tr>
                            <td>
                                Address</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txt_BAdress" runat="server" AutoPostBack="True" 
                                    CssClass="TextBoxGraiant" Height="25px" ontextchanged="txt_BName_TextChanged" 
                                    TextMode="MultiLine" Width="200px"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="txt_BAdress_AutoCompleteExtender" runat="server" 
                                    CompletionListCssClass="AutoExtender" 
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                    CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                    EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                    ServiceMethod="GetTagCNames" ServicePath="" 
                                    ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_BAdress">
                                </asp:AutoCompleteExtender>
                            </td>
                            <td>
                                Vehicle No.</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txt_BVehicleno" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td class="ui-priority-primary">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                </td>
                            <td>
                                &nbsp;</td>
                            <td>
                              
                                <asp:Button ID="btn_new" runat="server" CssClass="VerySmallGreen" 
                                     onclick="btn_new_Click" Text="New"  />
                            </td>
                            <td>
                            State Code
                               </td>
                            <td>
                                 </td>
                            <td>
                              <asp:TextBox ID="txt_statecode" runat="server" Text="21" CssClass="TextBoxGraiant" Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                </td>
                            <td class="ui-priority-primary">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                         <tr>
                            <td>
                                Finacial Year</td>
                            <td>

                             <asp:DropDownList ID="txt_fcyear" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px" Enabled="false"
                                   >
                                     <asp:ListItem value="Select">-Select-</asp:ListItem>
                                        <asp:ListItem Value="2017-18" >2017-18</asp:ListItem>
                                     <asp:ListItem Value="2016-17">2016-17</asp:ListItem>
                                  <asp:ListItem Value="2018-19" Selected="True">2018-19</asp:ListItem>
                                 
                                   <%-- <asp:ListItem Value="2018-19">2018-19</asp:ListItem>--%>
                                 <%--   <asp:ListItem>2019-20</asp:ListItem>--%>
                                </asp:DropDownList>
                             <%-- <asp:TextBox ID="txt_year" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px"></asp:TextBox>
                                     <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="Getyear" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_year">
                                            </asp:AutoCompleteExtender>--%>

                                
                                
                                </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                Place Of Supply</td>
                            <td>
                                </td>
                            <td>
                                <asp:TextBox ID="txt_place" runat="server" CssClass="TextBoxGraiant"  Height="25px" Width="200px" ></asp:TextBox></td>
                            <td>
                                submitted by </td>
                            <td class="ui-priority-primary">
                                :</td>
                            <td>
                                
                                <asp:TextBox ID="submittedy" runat="server" CssClass="TextBoxGraiant"  Height="25px" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
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
                            <td colspan="9">
                                <table class="skin-3" style="border-style: dashed; border-width: thin; border-color: #000000;
                                    width: 100%;">
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
                                            <strong>Category</strong>
                                        </td>
                                        <td>
                                            <strong>Qty</strong>
                                        </td>
                                            <td>
                                                <strong>Avl. Qty</strong>
                                            </td>
                                        <td>
                                            <strong>Rate</strong>
                                        </td>
                                        <td>
                                            <strong>Amount</strong>
                                        </td>
                                        <td>
                                            <strong>Discount%</strong>
                                        </td>
                                        <td>
                                            <strong>Disc Amount</strong>
                                        </td>
                                        <td>
                                            <strong>Gst</strong>
                                        </td>
                                        <td>
                                            <strong>TaxAmount</strong>
                                        </td>
                                        <td>

                                            <strong>Net Amount</strong>
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
                                        <td>
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
                                            <asp:TextBox ID="txt_category" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Font-Bold="True" AutoPostBack="True" 
                                                   ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartQuantity" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="40px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Font-Bold="True" AutoPostBack="True" 
                                                ontextchanged="txt_PartQuantity_TextChanged"  ></asp:TextBox>
                                        </td>
                                            <td>
                                                <asp:TextBox ID="txt_AvlQty" runat="server" CssClass="TextBoxGraiant" Width="50px"
                                                    Height="25px" Font-Bold="True" ForeColor="#FF0066" ReadOnly="True"></asp:TextBox>
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
                                            <asp:TextBox ID="txt_PartDiscountper" runat="server" CssClass="TextBoxGraiant"
                                                Height="25px" Width="50px" 
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                AutoPostBack="True" ontextchanged="txt_PartDiscountper_TextChanged" 
                                               >0</asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txt_PartDiscount" runat="server" CssClass="TextBoxGraiant"
                                                Height="25px" Width="80px" 
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" ReadOnly="True" 
                                                >0</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartVat" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
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
                                         OnClientClick="return validationfields();"       Text="Add" Width="40px" OnClick="btn_PartAdd_Click" />
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
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                               <asp:Label ID="lbl_gstvalue" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
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
                                        <asp:TemplateField HeaderText="Category">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcategory" runat="server" Text='<%# Eval("category") %>' ></asp:Label>
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
                                        <asp:TemplateField HeaderText="Disc%">
                                            <ItemTemplate>
                                                <asp:Label ID="Label151" runat="server" Text='<%# Eval("Ss_Discountper") %>'></asp:Label>
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
                                         <asp:TemplateField HeaderText="Gst%" >
                                            <ItemTemplate>
                                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("Ss_Vat") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SGst">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelSGst" runat="server" Text='<%# Eval("Ss_SGst") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CGst">
                                            <ItemTemplate>
                                                <asp:Label ID="Labelcgst" runat="server" Text='<%# Eval("Ss_CGst") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IGst" >
                                            <ItemTemplate>
                                                <asp:Label ID="Labeligst" runat="server" Text='<%# Eval("Ss_TaxAmont") %>'></asp:Label>
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
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
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
                               <span style="font-size:10px;"><%--Sparepart@5% --%> <asp:Label ID="lbls5" runat="server" Visible="False">0</asp:Label></span>
                                </td>
                            <td>
                                &nbsp;</td>
                            <td>
                              <span style="font-size:10px;"> <%--Sparepart@14.5%--%>  <asp:Label ID="lbls13" runat="server" Visible="False">0</asp:Label></span>
                            </td>
                            <td>
                                Gross Amount
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_AGrossAmount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="160px" Enabled="False"  onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
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
                              <span style="font-size:10px;"> <%--Lubricant@5%--%>  <asp:Label ID="lbll5" runat="server" Visible="False">0</asp:Label></span>
                                </td>
                            <td>
                                &nbsp;</td>
                            <td>
                              <span style="font-size:10px;"><%--Lubricant@14.5%--%> <asp:Label ID="lbll13" runat="server" Visible="False">0</asp:Label></span>
                            </td>
                            <td>
                                Discount Amount
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ADiscountAmount" runat="server" CssClass="TextBoxGraiant" Width="160px"
                                    Height="25px"  onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                &nbsp;
                            </td>
                            <td class="style1">
                                &nbsp;
                            </td>
                            <td class="style1">
                                &nbsp;
                            </td>
                            <td class="style1">
                               <span style="font-size:10px;"><%--vat@5% --%> <asp:Label ID="lblvat5" runat="server" Visible="False">0</asp:Label></span>
                            </td>
                            <td class="style1">
                                </td>
                            <td class="style1">
                                <span style="font-size:10px;"><%--vat@14.5%--%> <asp:Label ID="lblvat13" runat="server" Visible="False">0</asp:Label></span>
                                </td>
                            <td class="style1">
                                Net Amount
                            </td>
                            <td class="style1">
                                :
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="txt_ANetAmount" runat="server" CssClass="TextBoxGraiant" Enabled="False"
                                    Height="25px" Width="160px"  onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
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
                               <asp:Label ID="lbl_sparevale" runat="server" Visible="False"></asp:Label></td>
                            <td>
                               <asp:Label ID="lbl_lubvalue" runat="server" Visible="False"></asp:Label></td>
                            <td>
                                &nbsp;</td>
                            <td>
                                Tax Amount
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_AVatAmount" runat="server" CssClass="TextBoxGraiant" Width="160px"
                                    Height="25px"  onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp; <asp:Label ID="lbl_tax28final" runat="server" Visible="False">0</asp:Label>
                            </td>
                            <td>
                                &nbsp; <asp:Label ID="lbl_spate28final" runat="server" Visible="False">0</asp:Label>
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lbl_dic28final" runat="server" Visible="False">0</asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                Total
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ATotal" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="160px" Enabled="False"  onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp; <asp:Label ID="lbl_tax18final" runat="server" Visible="False">0</asp:Label></td>
                            <td>
                                &nbsp; <asp:Label ID="lbl_spate18final" runat="server" Visible="False">0</asp:Label></td>
                            <td>
                                &nbsp;<asp:Label ID="lbl_dic18final" runat="server" Visible="False">0</asp:Label></td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                Packaging Amount</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_APackagingAmt" runat="server" CssClass="TextBoxGraiant" onkeyup="other()"
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px" ontextchanged="txt_APackagingAmt_TextChanged">0</asp:TextBox>
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
                                Other Amount</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_AOtherAmt" runat="server" CssClass="TextBoxGraiant" onkeyup="other()"
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
                                &nbsp;</td>
                            <td>
                                Final Amount</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_AFinalAmount" runat="server" CssClass="TextBoxGraiant" 
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
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
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
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center">
                                <asp:Button ID="btn_Submit" runat="server" CssClass="VerySmallGreen" Height="26px"
                                    Text="Submit" Width="120px" onclick="btn_Submit_Click" Onclientclick="return btnSelete_Click();"/>
                            </td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="btn_Cancel" runat="server" CssClass="VerySmallRed" Height="26px"
                                    Text="Cancel" Width="120px" onclick="btn_Cancel_Click" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
