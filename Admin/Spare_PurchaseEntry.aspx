﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Spare_PurchaseEntry.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

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
   <%-- <script src="js/SparePurchaseEntryCal.js" type="text/javascript"></script>--%>
    <script type="text/javascript">

        function other() {


            var totalspare = document.getElementById('ContentPlaceHolder1_txt_ATotal');
            var outside = document.getElementById('ContentPlaceHolder1_txt_APackagingAmt');
            var other = document.getElementById('ContentPlaceHolder1_txt_AOtherAmount');


            var totalspare1 = parseFloat(totalspare.value);
            var other1 = parseFloat(other.value);
            var outside1 = parseFloat(outside.value);

            var bill1 = parseFloat(totalspare1 + other1 + outside1);
            document.getElementById('ContentPlaceHolder1_txt_ABillAmount').value = bill1.toFixed(2);
        }
     </script>
      <script type="text/jscript">

          function validationfields1() {
              var v = 0;

              if (document.getElementById('ContentPlaceHolder1_txt_year').value == "") {
                  alert("Finacial Year Should Not Be Blank..!!");

                  return false;
              }

              if (document.getElementById('ContentPlaceHolder1_txt_BVoucherNo').value == "") {
                  alert("Voucher Number Should Not Be Blank..!!");

                  return false;
              }

              if (document.getElementById('ContentPlaceHolder1_ddl_BSuplier').selectedIndex == 0) {
                  alert("Select Supplier Name..!!");

                  return false;
              }
              if (document.getElementById('ContentPlaceHolder1_txt_BinvoiceNo').value == "") {
                  alert("Invoice Number Should Not Be Blank..!!");

                  return false;
              }

              if (document.getElementById('ContentPlaceHolder1_txt_BInvoiceDate').value == "") {
                  alert("Invoice Date Should Not Be Blank..!!");

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
              if (document.getElementById('ContentPlaceHolder1_txt_AOtherAmount').value == "") {
                  alert("Other Amount Should Not Be Blank..!!");

                  return false;
              }
              if (document.getElementById('ContentPlaceHolder1_txt_ABillAmount').value == "") {
                  alert("Bill Amount Should Not Be Blank..!!");

                  return false;
              }
              document.getElementById('ContentPlaceHolder1_btn_Submit').style.visibility = "hidden";
          }

          function validationfields() {
              var v = 0;



              if (document.getElementById('ContentPlaceHolder1_txt_BVoucherNo').value == "") {
                  alert("Voucher Number Should Not Be Blank..!!");
                  txt_date.Focus();
                  return false;
              }

              if (document.getElementById('ContentPlaceHolder1_ddl_BSuplier').selectedIndex == 0) {
                  alert("Select Supplier Name..!!");

                  return false;
              }
              if (document.getElementById('ContentPlaceHolder1_txt_BinvoiceNo').value == "") {
                  alert("Invoice Number Should Not Be Blank..!!");

                  return false;
              }

              if (document.getElementById('ContentPlaceHolder1_txt_BInvoiceDate').value == "") {
                  alert("Invoice Date Should Not Be Blank..!!");

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
                  alert("Rate Should Not Be Blank!!");

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
                  alert("vat Amount Should Not Be Blank..!!");

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

              document.getElementById('ContentPlaceHolder1_btn_PartAdd').style.visibility = "hidden";
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
                            Purchase Entry</h3>
                    </legend>
                    <table style="width: 100%;">
                    <tr>
                            <td style="width: 15%">
                             Finacial Year
                            </td>
                            <td style="width: 1%">
                                <strong>:</strong>
                            </td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txt_year" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="200px" ReadOnly="true" ></asp:TextBox>

                                    <%-- <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="Getyear" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_year">
                                            </asp:AutoCompleteExtender>--%>
                            </td>
                            <td style="width: 15%">
                          
                            </td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td>
                              
                            </td>
                        </tr>


                        <tr>
                            <td style="width: 15%">
                                Voucher No
                            </td>
                            <td style="width: 1%">
                                <strong>:</strong>
                            </td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txt_BVoucherNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="200px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%">
                                Invoice Number
                            </td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_BinvoiceNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Name Of Suplier
                            </td>
                            <td>
                                <strong>:</strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_BSuplier" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                Invoice Date
                            </td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td style="position:relative">
                                <asp:TextBox ID="txt_BInvoiceDate" runat="server" CssClass="TextBoxGraiantDate"
                                    Height="25px" Width="150px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_BInvoiceDate_CalendarExtender" runat="server" CssClass="orange"
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_BInvoiceDate">
                                </asp:CalendarExtender>
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
                                Recieving Date
                            </td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td style="position:relative">
                                <asp:TextBox ID="txt_BRcvDate" runat="server" CssClass="TextBoxGraiantDate" Width="150px"
                                    Height="25px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_BRcvDate_CalendarExtender" runat="server" CssClass="red"
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_BRcvDate">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Order No.
                            </td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_BOrderNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="150px"></asp:TextBox>
                            </td>
                            <td>
                                LR No.
                            </td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_BLrNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Order Date
                            </td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td style="position:relative">
                                <asp:TextBox ID="txt_BOrderDate" runat="server" CssClass="TextBoxGraiantDate" Height="25px"
                                    Width="150px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_BOrderDate_CalendarExtender" runat="server" CssClass="red"
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_BOrderDate">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                LR Date
                            </td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td style="position:relative">
                                <asp:TextBox ID="txt_BLrDate" runat="server" CssClass="TextBoxGraiantDate" Height="25px"
                                    Width="150px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_BLrDate_CalendarExtender" runat="server" CssClass="red"
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_BLrDate">
                                </asp:CalendarExtender>
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
                            <td colspan="6">
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
                                            <strong>Rate</strong>
                                        </td>
                                        <td>
                                            <strong>Quantity</strong>
                                        </td>
                                        
                                        <td>
                                            <strong>Amount</strong>
                                        </td>
                                         <td>
                                            <strong>Disc%</strong>
                                        </td>
                                        <td>
                                            <strong>Disc_Amount</strong>
                                        </td>
                                        <td>
                                            <strong>Gst</strong>
                                        </td>
                                        <td>
                                            <strong>GstAmount</strong>
                                        </td>
                                        <td>
                                            <strong>Total</strong>
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
                                            <asp:TextBox ID="txt_PartRate" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                AutoPostBack="True" ontextchanged="txt_PartRate_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartQuantity" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Font-Bold="True" AutoPostBack="True" 
                                                ontextchanged="txt_PartQuantity_TextChanged" ></asp:TextBox>
                                        </td>
                                        
                                        <td>
                                            <asp:TextBox ID="txt_PartAmount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                ReadOnly="True"></asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txt_PartDiscountper" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="60px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                 AutoPostBack="True" ontextchanged="txt_PartDiscountper_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartDiscount" runat="server" CssClass="TextBoxGraiant"
                                                Height="25px" Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)">0</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                                <asp:ListItem>NIL</asp:ListItem>
                                                <asp:ListItem>28</asp:ListItem>
                                                <asp:ListItem>18</asp:ListItem>
                                                <asp:ListItem>14.5</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartTaxAmount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartTotal" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btn_PartAdd" runat="server" CssClass="VerySmallYellow" Height="28px"
                                              OnClientClick="return validationfields();"  Text="Add" Width="40px" OnClick="btn_PartAdd_Click" />
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
                        </tr>
                        <tr>
                            <td colspan="6">
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
                                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("Itm_PartDescrption")  %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label14" runat="server" Text='<%# Eval("Ss_Rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("Ss_Quantity") %>' ></asp:Label>
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
                                        <asp:TemplateField HeaderText="Discount">
                                            <ItemTemplate>
                                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("Ss_Discount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GST">
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
                                Net Amount
                            </td>
                            <td>
                                :
                            </td>
                            <td>
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
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
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
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Packaging
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_APackagingAmt" runat="server" CssClass="TextBoxGraiant" Height="25px" onkeyup="other()"
                                    Width="160px"  onkeypress="return AllowDecimalNumbersOnly(this,event)">0</asp:TextBox>
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
                                Other
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_AOtherAmount" runat="server" CssClass="TextBoxGraiant" Height="25px" onkeyup="other()"
                                    Width="160px"  onkeypress="return AllowDecimalNumbersOnly(this,event)">0</asp:TextBox>
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
                                <asp:TextBox ID="txt_ABillAmount" runat="server" CssClass="TextBoxGraiant" Enabled="False"
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
                                   OnClientClick="return validationfields1();" Text="Submit" Width="120px" onclick="btn_Submit_Click" />
                            </td>
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
                            <td colspan="6">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
