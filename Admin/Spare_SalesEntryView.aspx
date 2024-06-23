﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Spare_SalesEntryView.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

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
                            Spare Sales Details</h3>
                    </legend>
                    <table style="width: 100%;">
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
                                Order No.</td>
                            <td align="left" valign="top">
                                <strong>:</strong>&nbsp;
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txt_BOrderNo" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="120px"></asp:TextBox>
                            </td>
                            <td align="left" valign="top">
                                Order Date</td>
                            <td align="left" valign="top">
                                <strong>:</strong></td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txt_BOrderDate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Height="25px" Width="120px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_BOrderDate_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_BOrderDate">
                                </asp:CalendarExtender>
                            </td>
                            <td align="left" valign="top">
                                Invoice Type</td>
                            <td class="ui-priority-primary" align="left" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                               <asp:DropDownList ID="ddl_invtype" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="120px">
                                    <asp:ListItem Value="Spare_TaxSales">Tax Invoice</asp:ListItem>
                                    <asp:ListItem Value="Spare_RetailSales">Retail Invoice</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                        </tr>
                        <tr>
                            <td>
                                Party Name</td>
                            <td>
                                <strong>:</strong></td>
                            <td>
                                <asp:TextBox ID="txt_BName" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px" ></asp:TextBox>
                                <asp:AutoCompleteExtender ID="txt_BName_AutoCompleteExtender" runat="server" 
                                        CompletionListCssClass="autocomplete_completionListElement" 
                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" 
                                        CompletionListItemCssClass="autocomplete_listItem" DelimiterCharacters="" 
                                        EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                        ServiceMethod="GetTagCNames" ServicePath="" 
                                        ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_BName">
                                </asp:AutoCompleteExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                GSTIN/SRIN No.
                            </td>
                            <td class="ui-priority-primary">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_BTinSrinNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="200px"></asp:TextBox>
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
                                Gst Amount
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
                            <td colspan="4">
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
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center" colspan="4">
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="btn_Cancel" runat="server" CssClass="VerySmallRed" Height="26px"
                                    Text="Back" Width="120px" 
                                    PostBackUrl="~/Admin/Spare_SalesEntryList.aspx" />
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