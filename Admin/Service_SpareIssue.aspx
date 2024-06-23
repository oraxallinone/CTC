<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Service_SpareIssue.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

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
   <%-- <script src="js/ServiceEstimateEntryCal.js" type="text/javascript"></script>--%>
    <%--<script src="js/SparePurchaseEntryCal.js" type="text/javascript"></script>--%>
    <script type="text/jscript">

        function validationfields1() {
            var v = 0;

//            if (document.getElementById('ContentPlaceHolder1_txt_jcno').value == "") {
//                alert("Voucher Number Should Not Be Blank..!!");

//                return false;
//            }

//            if (document.getElementById('ContentPlaceHolder1_txt_date').value == "") {
//                alert("Date  Should Not Be Blank..!!");

//                return false;
//            }
//            if (document.getElementById('ContentPlaceHolder1_txt_regdno').value == "") {
//                alert("Regd No  Should Not Be Blank..!!");

//                return false;
//            }

//            if (document.getElementById('ContentPlaceHolder1_txt_engineno').value == "") {
//                alert("Engine No  Should Not Be Blank..!!");

//                return false;
//            }

//            if (document.getElementById('ContentPlaceHolder1_ddl_Model').selectedIndex == 0) {
//                alert("Please Select Model Name ..!!");

//                return false;
//            }
//            if (document.getElementById('ContentPlaceHolder1_txt_kcovered').value == "") {
//                alert("Km. Covered  Should Not Be Blank ..!!");

//                return false;
//            }

//            if (document.getElementById('ContentPlaceHolder1_ddl_servicetype').selectedIndex == 0) {
//                alert("Please Select Service Type ..!!");

//                return false;
//            }
//            if (document.getElementById('ContentPlaceHolder1_ddl_supervisor').selectedIndex == 0) {
//                alert("Please Select Superviser Name ..!!");

//                return false;
//            }

//            if (document.getElementById('ContentPlaceHolder1_ddl_technisian').selectedIndex == 0) {
//                alert("Please Select Technician Name ..!!");

//                return false;
//            }

//            if (document.getElementById('ContentPlaceHolder1_ddl_customer').selectedIndex == 0) {
//                alert("Please Select Customer Name ..!!");

//                return false;
//            }
//            if (document.getElementById('ContentPlaceHolder1_txt_address').value == "") {
//                alert("Address Should Not Be Blank..!!");

//                return false;
//            }

//            if (document.getElementById('ContentPlaceHolder1_txt_phoneno').value == "") {
//                alert("Phone No Should Not Be Blank..!!");

//                return false;
            //            }

           
            if (document.getElementById('ContentPlaceHolder1_txt_sino').value == "") {
                alert("Serial Number Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_date').value == "") {
                alert("Date  Should Not Be Blank..!!");
                txt_date.Focus();
                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_jcno').value == "") {
                alert("Job Card Number Should Not Be Blank..!! ");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_jcdate').value == "") {
                alert(" Date Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_regdno').value == "") {
                alert("Reg No Should Not Be Blank ..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_engineno').value == "") {
                alert("Eng No Should Not Be Blank ..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_modelname').value == "") {
                alert("Model No Should Not Be Blank!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_name').value == "") {
                alert("Name Should Not Be Blank!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_address').value == "") {
                alert("Address  Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_ddl_technisian').selectedIndex == 0) {
                alert("Please Select Technisian Name ..!!");

                return false;
            }
            document.getElementById('ContentPlaceHolder1_btn_Submit').style.visibility = "hidden";
        }






        function validationfields() {
            var v = 0;

          

            if (document.getElementById('ContentPlaceHolder1_txt_date').value == "") {
                alert("Date  Should Not Be Blank..!!");
                txt_date.Focus();
                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_sino').value == "") {
                alert("Serial Number Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_jcno').value == "") {
                alert("Job Card Number Should Not Be Blank..!! ");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_jcdate').value== "") {
                alert(" Date Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_regdno').value == "") {
                alert("Reg No Should Not Be Blank ..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_engineno').value == "") {
                alert("Eng No Should Not Be Blank ..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_modelname').value == "") {
                alert("Model No Should Not Be Blank!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_name').value == "") {
                alert("Name Should Not Be Blank!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_txt_address').value== "") {
                alert("Address  Should Not Be Blank..!!");

                return false;
            }

            if (document.getElementById('ContentPlaceHolder1_ddl_technisian').selectedIndex == 0) {
                alert("Please Select Technisian Name ..!!");

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
                alert("Quantity Should Not Be Blank..!!");

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
            if (document.getElementById('ContentPlaceHolder1_txt_PartVat').value == "0.00") {
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
            if (document.getElementById('ContentPlaceHolder1_ddlsparetype').selectedIndex == 0) {
                alert("Please Select Spare Type.!!");

                return false;
            }

          
            // document.getElementById('ContentPlaceHolder1_btn_Submit').style.visibility = "hidden";

        }
    
    </script>

    <style type="text/css">
        .style1
        {
            height: 23px;
        }
        .style2
        {
            font-weight: bold;
            height: 23px;
        }
        .style4
        {
            width: 15%;
            height: 25px;
        }
        .style5
        {
            width: 1%;
            height: 25px;
        }
        .style6
        {
            width: 30%;
            height: 25px;
        }
        .style7
        {
            height: 25px;
        }
    </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1"  DynamicLayout="true" runat="server">
     <ProgressTemplate>      
             <div class="modall">
        <div class="centerr">
            <img alt="progress" src="Images/processing.gif"/>
        </div>
    </div>             
            </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <div id="content" style="background-color: #FFFFFF; padding-left: 15px; padding-right: 10px;">
                <fieldset style="padding-right: 20px;">
                    <legend>
                        <h3>
                            Spare Issue</h3>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td class="style4">
                                SI NO</td>
                            <td class="style5">
                                :</td>
                            <td class="style6">
                                <asp:TextBox ID="txt_sino" runat="server" CssClass="TextBoxGraiant" 
                                    Enabled="False" Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td class="style4">
                                </td>
                            <td align="left" class="style5">
                                Date</td>
                            <td class="style7">
                                <asp:TextBox ID="txt_date" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_date_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_date">
                                </asp:CalendarExtender>
                            </td>
                            <td colspan="2" class="style7">
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 15%">
                                J.C. No.</td>
                            <td style="width: 1%">
                                <strong>:</strong>
                            </td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txt_jcno" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="100px" AutoPostBack="True" 
                                    ontextchanged="txt_jcno_TextChanged"></asp:TextBox>
                                <asp:TextBox ID="txt_jcyear" runat="server" 
                               AutoPostBack="true"     Width="100px" ontextchanged="txt_jcyear_TextChanged"></asp:TextBox>
                            </td>
                            <td style="width: 15%">
                                &nbsp;</td>
                            <td align="left" style="width: 1%">
                                &nbsp;Job Date</td>
                            <td>
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
                            <td>
                                Regd No</td>
                            <td>
                                <strong>:</strong>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_regdno" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                .</td>
                            <td align="left">
                                Engine No</td>
                            <td>
                                <asp:TextBox ID="txt_engineno" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                Model</td>
                            <td class="style2">
                                :
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="txt_modelname" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px"></asp:TextBox>
                            </td>
                            <td class="style1">
                                </td>
                            <td class="style1" align="left">
                                Chasis No.</td>
                            <td class="style1">
                                <asp:TextBox ID="txt_chassisno" runat="server" CssClass="TextBoxGraiant"
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2" class="style1">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Name</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txt_name" runat="server" ReadOnly="True" Width="200px" 
                                    CssClass="TextBoxGraiant"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td align="left">
                                Phone No</td>
                            <td>
                                <asp:TextBox ID="txt_mob" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Address</td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_address" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Rows="4" TextMode="MultiLine" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td align="left">
                                Technician</td>
                            <td>
                                <asp:DropDownList ID="ddl_technisian" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
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
                                            <strong>Spare Type</strong>
                                        </td>
                                        <td>
                                            <strong>PartDescription</strong>
                                        </td>
                                        <td>
                                            <strong>Qty</strong>
                                        </td>
                                        <td>
                                            <strong>Avl.Qty</strong>
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
                                            <strong>Gst Amnt</strong>
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
                                            <asp:DropDownList ID="ddlsparetype" runat="server" CssClass="TextBoxGraiant" 
                                                Width="120px" AutoPostBack="True" 
                                                onselectedindexchanged="ddlsparetype_SelectedIndexChanged">
                                    <asp:ListItem>...Select...</asp:ListItem>
                                    <asp:ListItem>Paid</asp:ListItem>
                                    <asp:ListItem>WARRANTY</asp:ListItem>
                                     <asp:ListItem>FOC</asp:ListItem>
                                   
                                </asp:DropDownList>
                                          
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartDesc" runat="server" AutoPostBack="True" 
                                                CssClass="TextBoxGraiant" Height="25px" 
                                               Width="150px"></asp:TextBox>
                                          
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartQuantity" runat="server" CssClass="TextBoxGraiant" 
                                                Font-Bold="True" Height="25px" 
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="50px" 
                                                AutoPostBack="True" ontextchanged="txt_PartQuantity_TextChanged"></asp:TextBox>
                                        </td>
                                          <td>
                                            <asp:TextBox ID="txt_AvlQty" runat="server" CssClass="TextBoxGraiant" 
                                                Font-Bold="True" Height="25px" 
                                                onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="50px" 
                                                  ForeColor="Red" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartRate" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartAmount" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartDiscountper" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="60px" AutoPostBack="True" 
                                                ontextchanged="txt_PartDiscountper_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartDiscount" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="70px">0</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartVat" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartTaxAmount" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="70px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_PartTotal" runat="server" CssClass="TextBoxGraiant" 
                                                Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                                Width="80px"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btn_PartAdd" runat="server" CssClass="VerySmallYellow" 
                                                Height="28px" OnClientClick="return validationfields(); " OnClick="btn_PartAdd_Click" Text="Add" Width="40px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
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
                                         <asp:TemplateField HeaderText="Spare Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsparetype" runat="server" Text='<%# Eval("sparetype") %>'></asp:Label>
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
                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("Ss_Quantity") %>'></asp:Label>
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
                                         <asp:TemplateField HeaderText="Gst%" >
                                            <ItemTemplate>
                                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("Ss_Vat") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Gst Amount">
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
                                                <asp:ImageButton ID="imgbtn_PartDelete" runat="server" Height="18px" 
                                                    ImageUrl="~/Admin/Images/Delete_Icon.png" OnClick="imgbtn_PartDelete_Click" 
                                                    ToolTip='<%# Eval("Itm_Partno") %>' />
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

                                        <asp:TemplateField HeaderText="flag" Visible = "false">
                                            <ItemTemplate>
                                                 <asp:Label ID="lbl_flag" runat="server" Text='<%# Eval("cat_flag") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="key" Visible = "false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_key" runat="server" Text='<%# Eval("key") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>


                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:Label ID="lbl_cat" runat="server" Visible="false"></asp:Label></td>
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
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td colspan="2">
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
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="center" colspan="3" 
                                style="font-weight: bold; text-decoration: underline">
                                SPARE ISSUE DETAILS</td>
                            <td>
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                                    CssClass="mGrid" Width="100%">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <asp:Label ID="Label19" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Year">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_fyear" runat="server" Text='<%# Eval("Jc_year") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Part Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Itmcode0" runat="server" Text='<%# Eval("Itm_code") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PartNumber">
                                            <ItemTemplate>
                                                <asp:Label ID="Label20" runat="server" Text='<%# Eval("Itm_Partno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PartDescription">
                                            <ItemTemplate>
                                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="Label22" runat="server" Text='<%# Eval("qnty") %>' 
                                                    ToolTip='<%#Eval("SE_ReturnQuantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label23" runat="server" Text='<%# Eval("SE_Rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="Label24" runat="server" Text='<%# Eval("SE_Amount") %>'></asp:Label>
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
                                                <asp:Label ID="Label25" runat="server" Text='<%# Eval("SE_Discount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gst">
                                            <ItemTemplate>
                                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("SE_Vat") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GstAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="Label27" runat="server" Text='<%# Eval("SE_Taxamount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="Label28" runat="server" Text='<%# Eval("SE_Total") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                      
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </td>
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
                                <asp:Button ID="btn_Submit" runat="server" CssClass="VerySmallGreen" 
                                    Height="26px" OnClientClick="return validationfields1();" onclick="btn_Submit_Click" Text="Submit" Width="120px" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btn_Cancel" runat="server" CssClass="VerySmallRed" 
                                    Height="26px" onclick="btn_Cancel_Click" Text="Cancel" Width="120px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
