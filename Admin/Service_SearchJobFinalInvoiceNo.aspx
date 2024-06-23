<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Service_SearchJobFinalInvoiceNo.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

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
    <script src="js/jquery-ui.min.js" type="text/javascript"></script><%--
   --%> <script src="js/ServiceEstimateEntryCal.js" type="text/javascript"></script>
    <script src="SmitaStYlE/SumUsingJquery/Service_PerformaInvoiceCal.js" type="text/javascript"></script>
    

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
                            Jobcard Final Invoice</h3>
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
                                    Height="25px" Width="200px" AutoPostBack="True" 
                                    onselectedindexchanged="ddl_invtype_SelectedIndexChanged">
                                    <asp:ListItem Value="Final_TaxSales">Tax Invoice</asp:ListItem>
                                    <asp:ListItem Value="Final_RetailSales">Retail Invoice</asp:ListItem>
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
                                    Height="25px" Width="200px" AutoPostBack="True" 
                                    ontextchanged="txt_jcno_TextChanged"></asp:TextBox>
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
                                    <asp:ListItem>PAID SERVICE</asp:ListItem>
                                    <asp:ListItem>FREE SERVICE</asp:ListItem>
                                    <asp:ListItem>WARRANTY</asp:ListItem>
                                    <asp:ListItem>AMC</asp:ListItem>
                                    <asp:ListItem>PDI</asp:ListItem>
                                    <asp:ListItem>1st FREE/8000</asp:ListItem>
                                    <asp:ListItem>2nd FRR/16000</asp:ListItem>
                                    <asp:ListItem>POST WARRANTY</asp:ListItem>
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
                                TIN/SRIN</td>
                            <td class="style6">
                                :</td>
                            <td class="style5">
                                <asp:TextBox ID="txt_tin" runat="server" CssClass="TextBoxGraiant" 
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
                                &nbsp;</td>
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
                                        <asp:TemplateField HeaderText="Discount">
                                            <ItemTemplate>
                                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("SE_Discount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vat">
                                            <ItemTemplate>
                                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("SE_Vat") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TaxAmount">
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
                            <td align="left" colspan="4" rowspan="17" valign="top">
                              
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
                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                <ItemStyle HorizontalAlign="Left" Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rate">
                <ItemTemplate>
                    <asp:Label ID="Labels5" runat="server" Text='<%# Eval("JCS_Rate") %>' ></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                <ItemStyle HorizontalAlign="Left" Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount">
                <FooterTemplate>
                    <asp:Label ID="lblgrandtotal" runat="server" Font-Bold="True"></asp:Label>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Labels6" runat="server" Text='<%# Eval("JCS_Amount") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                <ItemStyle HorizontalAlign="Left" Width="100px" />
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
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Discount
                                <asp:TextBox ID="txt_SDiscountPer" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="40px">0</asp:TextBox>
                                &nbsp;%</td>
                            <td>
                                <asp:TextBox ID="txt_SerDiscountAmount" runat="server" 
                                    CssClass="TextBoxGraiant" Height="25px" 
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
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="background-color: #c0c0ff">
                                Vat Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txt_SVatAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="background-color: #c0c0ff">
                                Total Spare Amount</td>
                            <td>
                                <asp:TextBox ID="txt_TotalSpareAmount" runat="server" 
                                    CssClass="TextBoxGraiant" Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px">0.00</asp:TextBox>
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
                                    Width="160px">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                </td>
                            <td class="style10">
                                Discount
                                <asp:TextBox ID="txt_LabDiscountPer" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="40px">0</asp:TextBox>
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
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Add Service Tax" 
                                    AutoPostBack="True" oncheckedchanged="CheckBox1_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Service Tax @<asp:TextBox ID="txt_ServiceTaxPer" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="30px" ReadOnly="True">12</asp:TextBox>
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
                            <td class="style4">
                                Edu.cess@<asp:TextBox ID="txt_edutaxpercent" runat="server" Width="30px" 
                                    ReadOnly="True">2</asp:TextBox>
                                % Of S.tax</td>
                            <td class="style4">
                                <asp:TextBox ID="txteducessamount" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px" Enabled="False">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <a href="mailto:Sr.Hr.Edu.Cess@Of">Sr.Hr.Edu.Cess@<asp:TextBox ID="txt_hredupercent" 
                                    runat="server" Width="30px" ReadOnly="True">1</asp:TextBox>
                                %Of</a> S.tax
                            </td>
                            <td>
                                <asp:TextBox ID="txtSrhr" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px" Enabled="False">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="background-color: #c0c0ff">
                                Service Tax Amount</td>
                            <td>
                                <asp:TextBox ID="txt_sertaxamount" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px" Enabled="False">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                </td>
                            <td class="style4" style="background-color: #c0c0ff">
                                Outside Service</td>
                            <td class="style4">
                                <asp:TextBox ID="txt_outsidecharge" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px" Enabled="False">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                </td>
                            <td style="background-color: #c0c0ff" class="style4">
                                Other Charges</td>
                            <td class="style4">
                                <asp:TextBox ID="txt_otherchrg" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px" 
                                   >0.00</asp:TextBox>
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="style4">
                            </td>
                            <td class="style4" style="background-color: #FFFF00">
                                &nbsp;Bill Amount</td>
                            <td class="style4">
                                <asp:TextBox ID="txt_BillAmount" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" 
                                    onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                    Width="160px">0.00</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                </td>
                            <td class="style9">
                                </td>
                            <td class="style9">
                                &nbsp;</td>
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
