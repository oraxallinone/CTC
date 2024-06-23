﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Counter_BillCancel.aspx.cs" Inherits="Admin_Counter_BillCancel" %>


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
    <script src="js/SparePurchaseEntryCal.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            height: 25px;
        }
        .style2
        {
            height: 26px;
        }
    </style>


    <script type="text/jscript">

        function validationfields1() {
            var v = 0;

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

            //            if (document.getElementById('ContentPlaceHolder1_txt_tooltip').value == "") {
            //                alert("Enter Name Again..!!");

            //                return false;
            //            }


            if (document.getElementById('ContentPlaceHolder1_txt_returndate').value == "") {
                alert("Return date Should Not Be Blank..!!");

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
            document.getElementById('ContentPlaceHolder1_btn_Submit').style.visibility = "hidden";
        }






        function validationfields() {
            var v = 0;

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
            if (document.getElementById('ContentPlaceHolder1_txt_returndate').value == "") {
                alert("Return date Should Not Be Blank..!!");

                return false;
            }


            // document.getElementById('ContentPlaceHolder1_btn_Submit').style.visibility = "hidden";

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
                            Spare Sales Return</h3>
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
                            <td style="width: 20%">
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
                            <td>
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
                            <td align="left" valign="top">
                                <asp:TextBox ID="txt_BName" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px"  Width="200px"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="txt_BName_AutoCompleteExtender" runat="server" 
                                    CompletionListCssClass="autocomplete_completionListElement" 
                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" 
                                    CompletionListItemCssClass="autocomplete_listItem" DelimiterCharacters="" 
                                    EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                    ServiceMethod="GetTagCNames" ServicePath="" 
                                    ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_BName">
                                </asp:AutoCompleteExtender>
                            </td>
                            <td align="left" valign="top">
                                Sale Return Date</td>
                            <td align="left" valign="top">
                                <strong>:</strong></td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txt_returndate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Height="25px" Width="120px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_returndate_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_returndate">
                                </asp:CalendarExtender>
                            </td>
                            <td align="left" valign="top">
                                Invoice Type</td>
                            <td class="ui-priority-primary" align="left" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                               <asp:DropDownList ID="ddl_invtype" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="120px" 
                                   >
                                    <asp:ListItem Value="Spare_TaxSales">Tax Invoice</asp:ListItem>
                                    <asp:ListItem Value="Spare_RetailSales">Retail Invoice</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style1">
                              <asp:TextBox ID="txt_tooltip" runat="server" Visible="false"></asp:TextBox></td>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style1">
                                :</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style1">
                                GSTIN/SRIN No.
                            </td>
                            <td class="style1">
                                :
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="txt_BTinSrinNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               <asp:TextBox ID="txt_SS_ID" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                Width="15px" Enabled="False" Visible = "false" ></asp:TextBox>  &nbsp;
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
                        <%--<tr>
                            <td colspan="9">
                                <table class="skin-3" style="border-style: dashed; border-width: thin; border-color: #000000;
                                    width: 800px;">
                                    <tr bgcolor="#FF99FF">
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
                                                <strong>Avl. Qty</strong>
                                            </td>
                                              <td>
                                               <strong>Return.Qty</strong>
                                            </td>
                                        <td>
                                            <strong>Rate</strong>
                                        </td>
                                        <td>
                                            <strong>Amount</strong>
                                        </td>
                                        <td>
                                            <strong>Discount</strong>
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
                                        <td>
                                            <asp:TextBox ID="txt_PartNo" runat="server" CssClass="TextBoxGraiant" Width="150px"
                                    Enabled="false"    Height="25px" OnTextChanged="txt_PartNo_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txt_PartNo_AutoCompleteExtender" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetPartNo" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_PartNo">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartDesc" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                             Enabled="false"    Width="120px" OnTextChanged="txt_PartDesc_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txt_PartDesc_AutoCompleteExtender" runat="server" CompletionListCssClass="wordWheel listMain .box"
                                                CompletionListItemCssClass="wordWheel itemsMain" CompletionListHighlightedItemCssClass="wordWheel itemsSelected"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetPartDesc" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_PartDesc">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartQuantity" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                              Enabled="false"   Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Font-Bold="True" ></asp:TextBox>
                                        </td>
                                            <td>
                                                <asp:TextBox ID="txt_AvlQty" runat="server" CssClass="TextBoxGraiant" Width="80px"
                                                  Height="25px" Enabled="False" Font-Bold="True" ForeColor="#FF0066"></asp:TextBox>
                                            </td>
                                             <td>
                                            <asp:TextBox ID="txt_RetrnQty" runat="server" AutoPostBack="True" 
                                             CssClass="TextBoxGraiant" Font-Bold="True" ForeColor="#FF0066" Height="25px" 
                                                Width="70px" ontextchanged="txt_RetrnQty_TextChanged">0</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartRate" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                             Enabled="false"     Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartAmount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                  Enabled="false"       Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartDiscount" runat="server" CssClass="TextBoxGraiant"
                                              Enabled="false"    Height="25px" Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)">0</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartVat" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                          Enabled="false"        Width="60px" onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartTaxAmount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                          Enabled="false"        Width="70px" onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartTotal" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                           Enabled="false"       Width="70px" onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            
                                            <asp:Button ID="btn_addd" runat="server"  CssClass="VerySmallYellow" 
                                   OnClientClick="return validationfields();"         Width="40px" Height="28px" Text="Add" onclick="btn_addd_Click" />
                                            
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="9">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="mGrid">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <Columns>
                                         <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ss_ID" runat="server" Text='<%# Eval("Ss_Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                            <ItemStyle HorizontalAlign="Left" Width="20px" />
                                        </asp:TemplateField>
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

                                        <asp:TemplateField HeaderText="Catagory">
                                            <ItemTemplate>
                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("Itm_Category") %>' ></asp:Label>
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
                                        <asp:TemplateField HeaderText="GstAmount">
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

                                        <asp:TemplateField HeaderText="Year">
                                            <ItemTemplate>
                                                <asp:Label ID="Label20" runat="server" Text='<%# Eval("jc_year") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="Return">
                                                            <ItemTemplate>
                                                               
                                                                    <asp:Button ID="btn_return" runat="server" Text="Return" CssClass="ThinRed" 
                                                                    ToolTip='<%# Eval("Itm_Partno") %>' onclick="btn_return_Click"></asp:Button>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                        </asp:TemplateField>--%>

                                                     
                                       
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
                            <td colspan="4">
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
                            <td colspan="4">
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
                            <td colspan="4">
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
                            <td class="style1">
                                &nbsp;
                            </td>
                            <td class="style1">
                                &nbsp;
                            </td>
                            <td colspan="4" class="style1">
                                &nbsp;
                            </td>
                            <td class="style1">
                                Gst Amount
                            </td>
                            <td class="style1">
                                :
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="txt_AVatAmount" runat="server" CssClass="TextBoxGraiant" Width="160px"
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
                            <td colspan="4" class="style1">
                                &nbsp;
                            </td>
                            <td class="style1">
                                Total
                            </td>
                            <td class="style1">
                                :
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="txt_ATotal" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="160px" Enabled="False"  onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td colspan="4">
                                &nbsp;</td>
                            <td>
                                Packaging Amount</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_APackagingAmt" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td colspan="4">
                                &nbsp;</td>
                            <td>
                                Other Amount</td>
                            <td>
                                :</td>
                            <td>
                                <asp:TextBox ID="txt_AOtherAmt" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td colspan="4">
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
                            <td colspan="4">
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
                            <td class="style2">
                                &nbsp;
                            </td>
                            <td class="style2">
                                &nbsp;
                            </td>
                            <td colspan="4" class="style2">
                                <asp:Button ID="btn_Submit" runat="server" CssClass="VerySmallGreen" Height="26px"
                                OnClientClick="return validationfields1();"      Text="Submit" Width="120px" onclick="btn_Submit_Click" />
                            </td>
                            <td align="right" class="style2">
                                <%--<asp:Button ID="btn_Cancel" runat="server" CssClass="VerySmallRed" Height="26px"
                                    Text="Back" Width="120px" 
                                    PostBackUrl="~/Admin/Spare_SalesEntryList.aspx" 
                                    onclick="btn_Cancel_Click" />--%>
                            </td>
                            <td class="style2">
                                &nbsp;
                            </td>
                            <td class="style2">
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
