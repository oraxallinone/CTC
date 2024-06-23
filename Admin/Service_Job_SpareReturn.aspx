<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Service_Job_SpareReturn.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

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
<%-- <script src="js/ServiceEstimateEntryCal.js" type="text/javascript"></script>--%>
    <script src="js/JobcardSpareReturn.js" type="text/javascript"></script>
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
        <div style="text-align:center;">
             Finacial Year  <asp:TextBox ID="TextBox2" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="100px" 
                                  
                                    ></asp:TextBox>
                                   Enter Jobcard No:<asp:TextBox ID="TextBox1" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="150px" AutoPostBack="True" 
                                    ontextchanged="txt_jcno_TextChanged" 
                                    ></asp:TextBox>
                         
        </div>
            <asp:Panel ID="Panel1" runat="server">
                <div id="content" style="background-color: #FFFFFF; padding-left: 15px; padding-right: 10px;">
                    <fieldset style="padding-right: 20px;">
                        <legend>
                            <h5>
                                <asp:Label ID="Label19" runat="server"></asp:Label>
                            </h5>
                        </legend>
                        <table id="tbl_details" style="width: 100%;">
                        <tr>
                            <td style="width: 15%" colspan="2">
                                SI NO</td>
                            <td style="width: 1%" colspan="2">
                                :</td>
                            <td style="width: 30%" colspan="2">
                                <asp:TextBox ID="txt_sino" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" Width="200px" 
                                    ></asp:TextBox>
                            </td>
                            <td style="width: 15%" colspan="2">
                                &nbsp;</td>
                            <td style="width: 1%" colspan="2" align="left">
                                Date</td>
                            <td colspan="4" style=" position:relative">
                                <asp:TextBox ID="txt_date" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_date_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_date">
                                </asp:CalendarExtender>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 15%">
                                J.C. No.</td>
                            <td colspan="2" style="width: 1%">
                                <strong>:</strong>
                            </td>
                            <td colspan="2" style="width: 30%">
                                <asp:TextBox ID="txt_jcno" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="100px" ontextchanged="txt_jcno_TextChanged" 
                                    ></asp:TextBox>
                                <asp:TextBox ID="txt_jcyear" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="100px"  
                                    ></asp:TextBox>
                            </td>
                            <td colspan="2" style="width: 15%">
                                &nbsp;</td>
                            <td align="left" colspan="2" style="width: 1%">
                                &nbsp;Job Date</td>
                            <td colspan="4" style=" position:relative">
                                <asp:TextBox ID="txt_jcdate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_jcdate_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_jcdate">
                                </asp:CalendarExtender>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Regd No</td>
                            <td colspan="2">
                                <strong>:</strong>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_regdno" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                .</td>
                            <td colspan="2" align="left">
                                Engine No</td>
                            <td colspan="4">
                                <asp:TextBox ID="txt_engineno" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style1">
                                Model</td>
                            <td class="style2" colspan="2">
                                :
                            </td>
                            <td colspan="2" class="style1">
                                <asp:TextBox ID="txt_modelname" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2" class="style1">
                                </td>
                            <td class="style1" colspan="2" align="left">
                                &nbsp;Chasis No.</td>
                            <td colspan="4" class="style1">
                                <asp:TextBox ID="txt_chassisno" runat="server" CssClass="TextBoxGraiant"
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2" class="style1">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style3">
                                :Spare Type</td>
                            <td colspan="2" class="style3">
                                :</td>
                            <td colspan="2" class="style3">
                                <asp:DropDownList ID="ddl_servicetype" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px">
                                    <asp:ListItem>...Select...</asp:ListItem>
                                    <asp:ListItem>NON WARRANTY</asp:ListItem>
                                    <asp:ListItem>WARRANTY</asp:ListItem>
                                   
                                </asp:DropDownList>
                            </td>
                            <td colspan="2" class="style3">
                            </td>
                            <td colspan="2" align="left" class="style3">
                                Name</td>
                            <td colspan="4" class="style3">
                                <asp:TextBox ID="txt_name" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2" class="style3">
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Address</td>
                            <td colspan="2">
                                :
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_address" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Rows="4" TextMode="MultiLine" Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2" align="left">
                                Technician</td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddl_technisian" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                            <tr>
                                <td colspan="2">
                                    Return Date</td>
                                <td colspan="2">
                                    :</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txt_returndate" runat="server" CssClass="TextBoxGraiantDate" 
                                        Width="200px"></asp:TextBox>
                                    <asp:CalendarExtender ID="txt_returndate_CalendarExtender" runat="server" 
                                        CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                        TargetControlID="txt_returndate">
                                    </asp:CalendarExtender>
                                </td>
                                <td colspan="2">
                                    &nbsp;</td>
                                <td align="left" colspan="2">
                                    &nbsp;</td>
                                <td colspan="4">
                                    &nbsp;</td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                        <tr>
                            <td colspan="16">
                                <table id="tbl_spareparts"  runat="server" style="border-style: dashed; border-width: thin; border-color: #000000;
                                   width: 800px;">
                                    <tr bgcolor="#6fb3e0">
                                        <td>
                                            <strong>Sl.No.</strong>
                                        </td>
                                          <td>
                                            <strong>PartID</strong>
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
                                            <strong>Return Quantity</strong>
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
                                            <asp:TextBox ID="txt_PartSlNo" runat="server" CssClass="TextBoxGraiant" 
                                                Enabled="False" Height="25px" Width="40px"></asp:TextBox>
                                             
                                        </td>
                                         <td style=" position:relative">
                                            <asp:TextBox ID="txt_partid" runat="server" Enabled="False" CssClass="TextBoxGraiant" 
                                                 Height="25px" Width="100px" AutoPostBack="True" 
                                                 ontextchanged="txt_partid_TextChanged"></asp:TextBox>
                                                 <asp:AutoCompleteExtender ID="txt_partid_AutoCompleteExtender1" runat="server" 
                                                CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="GetPartId" ServicePath=""   
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_partid">
                                            </asp:AutoCompleteExtender> 
                                        </td>
                                        <td style=" position:relative">
                                            <asp:TextBox ID="txt_PartNo" runat="server" Enabled="False" AutoPostBack="True" 
                                                CssClass="TextBoxGraiant" Height="25px" OnTextChanged="txt_PartNo_TextChanged" 
                                                Width="120px"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="txt_PartNo_AutoCompleteExtender" runat="server" 
                                                CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="GetPartNo" ServicePath="" 
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_PartNo">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartDesc" Enabled="False" runat="server" 
                                                CssClass="TextBoxGraiant" Height="25px" 
                                               Width="150px" ></asp:TextBox>
                                          
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartQuantity" Enabled="False" runat="server" CssClass="TextBoxGraiant" 
                                                Font-Bold="True" Height="25px" 
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="80px" 
                                               ></asp:TextBox>
                                        </td>
                                          <td>
                                            <asp:TextBox ID="txt_returnquantity" runat="server" CssClass="TextBoxGraiant" 
                                                Font-Bold="True" Height="25px" 
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="80px" 
                                                  AutoPostBack="True" ontextchanged="txt_returnquantity_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartRate" Enabled="False" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartAmount" Enabled="False" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartDiscount" Enabled="False" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="60px">0</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartVat" Enabled="False" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartTaxAmount" Enabled="False" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartTotal" Enabled="False" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="80px"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btn_PartAdd" runat="server" CssClass="VerySmallYellow" 
                                                Height="28px" OnClick="btn_PartAdd_Click" Text="Update" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="16">
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
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
                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("qnty") %>' ToolTip='<%#Eval("SE_ReturnQuantity") %>'></asp:Label>
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
                                          <asp:TemplateField HeaderText="Return">
                                            <ItemTemplate>
                                                <asp:Button ID="imgbtn_returnt" runat="server" Text="Return" CssClass="ThinRed" ToolTip='<%# Eval("SE_Id")%>'
                                                    onclick="imgbtn_returnt_Click" />
                                               
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
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                <asp:Label ID="Label22" runat="server"></asp:Label>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td align="left" style="color: #000000; font-weight: bold; font-size: medium">
                                &nbsp;</td>
                            <td align="right" style="color: #000000; font-weight: bold; font-size: medium">
                                Total:</td>
                            <td align="left" style="color: #000000; font-weight: bold; font-size: medium">
                                <asp:Label ID="Label20" runat="server"></asp:Label>
                            </td>
                            <td align="left" style="color: #000000; font-weight: bold; font-size: medium">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="4">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="btn_Submit" runat="server" CssClass="VerySmallGreen" 
                                    Height="26px" onclick="btn_Submit_Click" Text="Submit" Width="120px" 
                                    Visible="False" />
                                <asp:Button ID="btn_back" runat="server" CssClass="VerySmallGreen" 
                                    Height="26px"  Text="Back" Width="120px" onclick="btn_back_Click2" 
                                    Visible="False" />
                            </td>
                            <td align="right" colspan="2">
                                <asp:Button ID="btn_Cancel" runat="server" CssClass="VerySmallRed" 
                                    Height="26px" onclick="btn_Cancel_Click" Text="Cancel" Width="120px" 
                                    Visible="False" />
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td colspan="4">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="14">
                                &nbsp;
                            </td>
                            <td colspan="2">
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
                        <asp:Label ID="Label21" runat="server"></asp:Label>
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
