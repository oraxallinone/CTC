<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Service_Job_EstimationEntryEdit.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

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
    <script src="SmitaStYlE/Accodianeffect.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {


            $("li").click(function () {
                $(this).toggleClass("active");
                $(this).next("div").stop('true', 'true').slideToggle("slow");
            });
        });
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
            <asp:Panel ID="Panel1" runat="server">
                <div id="content" style="background-color: #FFFFFF; padding-left: 15px; padding-right: 10px;">
                    <fieldset style="padding-right: 20px;">
                        <legend>
                            <h3>
                                <asp:Label ID="Label19" runat="server"></asp:Label>
                            </h3>
                        </legend>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 15%">
                                    Estimate No
                                </td>
                                <td style="width: 1%">
                                    <strong>:</strong>
                                </td>
                                <td style="width: 30%">
                                    <asp:TextBox ID="txt_BEstimateNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="200px" Enabled="False"></asp:TextBox>
                                </td>
                                <td style="width: 15%">
                                    Estimate Date
                                </td>
                                <td style="width: 1%">
                                    <strong>:</strong>
                                </td>
                                <td style=" position:relative">
                                    <asp:TextBox ID="txt_BEstimateDate" runat="server" CssClass="TextBoxGraiantDate"
                                        Height="25px" Width="150px"></asp:TextBox>
                                    <asp:CalendarExtender ID="txt_BEstimateDate_CalendarExtender" runat="server" CssClass="orange"
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_BEstimateDate">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td>
                                    <strong>:</strong>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_BCustomer" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="250px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="ui-priority-primary">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Model
                                </td>
                                <td class="ui-priority-primary">
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_BModel" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="250px">
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
                                    Chasis No.
                                </td>
                                <td class="ui-priority-primary">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_BChasisNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    Engine No.
                                </td>
                                <td class="ui-priority-primary">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_BEngineNo" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Sale Date
                                </td>
                                <td>
                                    <strong>:</strong>
                                </td>
                                <td style=" position:relative">
                                    <asp:TextBox ID="txt_BSaleDate" runat="server" CssClass="TextBoxGraiantDate" Height="25px"
                                        Width="150px"></asp:TextBox>
                                    <asp:CalendarExtender ID="txt_BSaleDate_CalendarExtender" runat="server" CssClass="red"
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_BSaleDate">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    Kilometer
                                </td>
                                <td>
                                    <strong>:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_BKiloMeter" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="150px"></asp:TextBox>
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
                            <tr>
                                <td align="center" colspan="7">
                                    <asp:Label ID="lblspare" runat="server" Font-Bold="False" Font-Size="18px" 
                                        Font-Underline="True" Text="SpareParts"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <table id="tbl_spareparts" runat="server" style="border-style: dashed; border-width: thin;
                                        border-color: #000000; width: 800px;">
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
                                                <strong>Discount</strong>
                                            </td>
                                            <td>
                                                <strong>GST</strong>
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
                                            <td style=" position:relative">
                                                <asp:TextBox ID="txt_PartNo" runat="server" CssClass="TextBoxGraiant" Width="150px"
                                                    Height="25px" OnTextChanged="txt_PartNo_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                <asp:AutoCompleteExtender ID="txt_PartNo_AutoCompleteExtender" runat="server" CompletionListCssClass="AutoExtender"
                                                    CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                    DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                    ServiceMethod="GetPartNo" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                    TargetControlID="txt_PartNo">
                                                </asp:AutoCompleteExtender>
                                            </td>
                                            <td style=" position:relative">
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
                                                    Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_PartRate" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                    Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_PartAmount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                    Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_PartDiscount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                    Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_PartVat" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                                    Width="80px" onkeypress="return AllowDecimalNumbersOnly(this,event)"></asp:TextBox>
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
                                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("Se_Quantity") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("Se_Rate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("Se_Amount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Discount">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("Se_Discount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="GST">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("Se_Vat") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="GST Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("Se_TaxAmont") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("Se_Total") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtn_edit" runat="server" Height="18px" ImageUrl="~/Admin/Images/edit-icon.png"
                                                        ToolTip='<%# Eval("Sp_Id") %>' onclick="imgbtn_edit_Click"  />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtn_PartDelete" runat="server" Height="18px" ImageUrl="~/Admin/Images/Delete_Icon.png"
                                                        ToolTip='<%# Eval("Sp_Id") %>' OnClick="imgbtn_PartDelete_Click" />
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
                                <td align="center" colspan="7">
                                    <asp:Label ID="lblspare0" runat="server" Font-Bold="True" Font-Size="18px" 
                                        Font-Underline="True" Text="Service"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="4" rowspan="11" valign="top">
                                    <table id="tbl_service" runat="server" style="border-style: dashed; border-width: thin;
                                        border-color: #000000;">
                                        <tr bgcolor="#6fb3e0">
                                            <td class="ui-priority-primary">
                                                Service Code
                                            </td>
                                            <td class="ui-priority-primary">
                                                Description
                                            </td>
                                            <td class="ui-priority-primary">
                                                Quantity
                                            </td>
                                            <td class="ui-priority-primary">
                                                Rate
                                            </td>
                                            <td class="ui-priority-primary">
                                                Amount
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style=" position:relative">
                                                <asp:TextBox ID="txt_SCode" runat="server" CssClass="SmalldottedTextBox"
                                                    Width="120px" ontextchanged="txt_SCode_TextChanged1" AutoPostBack="True" ></asp:TextBox>
                                           <asp:AutoCompleteExtender ID="txt_SCode_AutoCompleteExtender" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetServiceCode" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_SCode">
                                            </asp:AutoCompleteExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_SDescription" runat="server" CssClass="SmalldottedTextBox" Width="200px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_SQuantity" runat="server" CssClass="SmalldottedTextBox" onkeypress="return AllowNumbersOnly(this,event)"
                                                    Width="100px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_SRate" runat="server" CssClass="SmalldottedTextBox" onkeypress="return AllowNumbersOnly(this,event)"
                                                    Width="100px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_SAmount" runat="server" CssClass="SmalldottedTextBox" onkeypress="return AllowNumbersOnly(this,event)"
                                                    Width="100px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="btn_ServiceAdd" runat="server" CssClass="VerySmallYellow" Height="28px"
                                                    Text="Add" Width="40px" OnClick="btn_ServiceAdd_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                        Font-Names="Cambria" Font-Size="12px" Width="100%">
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
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtn_SEdit" runat="server" Height="20px" ImageUrl="~/Admin/Images/edit-icon.png"
                                                        ToolTip='<%# Eval("Ss_Id") %>' OnClick="imgbtn_SEdit_Click"  />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtn_SDelete" runat="server" Height="20px" ImageUrl="~/Admin/Images/Delete_Icon.png"
                                                        ToolTip='<%# Eval("Ss_Id") %>' onclick="imgbtn_SDelete_Click1"  />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
                                    </asp:GridView>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="width: 15%">
                                    Service Gross Amount
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_AGrossAmount" runat="server" CssClass="TextBoxGraiant" Enabled="False"
                                        Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Discount
                                    <asp:TextBox ID="txt_ASerDiscountPer" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="40px">0</asp:TextBox>
                                    &nbsp;%
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ASerDiscountAmount" runat="server" CssClass="TextBoxGraiant"
                                        Enabled="False" Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)"
                                        Width="160px">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Net Amount
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ANetAmount" runat="server" CssClass="TextBoxGraiant" Enabled="False"
                                        Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Gst Amount
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_AVatAmount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Total Spare Amount
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ATotalSpareAmount" runat="server" CssClass="TextBoxGraiant"
                                        Enabled="False" Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)"
                                        Width="160px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Labour Charges
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ALabourCharges" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Discount
                                    <asp:TextBox ID="txt_ALabDiscountPer" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="40px">0</asp:TextBox>
                                    &nbsp;%
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ALabDiscountAmount" runat="server" CssClass="TextBoxGraiant"
                                        Enabled="False" Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)"
                                        Width="160px">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Charges After Discount
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ALabourChargesAftDisc" runat="server" CssClass="TextBoxGraiant"
                                        Enabled="False" Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)"
                                        Width="160px">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Tax
                                    <asp:TextBox ID="txt_AServiceTaxPer" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="40px">18</asp:TextBox>
                                    &nbsp;%
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_AServiceTaxAmt" runat="server" CssClass="TextBoxGraiant" Enabled="False"
                                        Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Other Charges
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_AOtherAmount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Bill Amount
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ABillAmount" runat="server" CssClass="TextBoxGraiant" Enabled="False"
                                        Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px"></asp:TextBox>
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
                                <td align="center">
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
                                <td align="center" colspan="7">
                                    &nbsp; &nbsp;<asp:Button ID="btn_back" runat="server" CssClass="VerySmallLiteBlue" 
                                        Height="26px"  Text="Back" Width="100px" onclick="btn_back_Click1" />
&nbsp;<asp:Button ID="btn_Submit" runat="server" CssClass="VerySmallGreen" Height="26px" OnClick="btn_Submit_Click" 
                                        Text="Submit" Width="100px" />
                                    <asp:Button ID="btn_Cancel" runat="server" CssClass="VerySmallRed" 
                                        Height="26px"  Text="Cancel" Width="100px" />
                                    &nbsp;
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
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
            </asp:Panel>
            <table width="100%">
                <tr>
                    <td align="center" valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        <asp:Button ID="btnprint" runat="server" CssClass="btn-info" Font-Bold="True" Font-Names="US"
                            OnClientClick="return PrintPanel()" Text="Print" />
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
