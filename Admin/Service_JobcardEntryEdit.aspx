<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Service_JobcardEntryEdit.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

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
    <script type="text/jscript">

        function validationfields1() {
            var v = 0;

            if (document.getElementById('ContentPlaceHolder1_txt_jcno').value == "") {
                alert("Jc  Number Should Not Be Blank..!!");

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
            if (document.getElementById('ContentPlaceHolder1_txt_time').value == "") {
                alert("Time Should Not Be Blank..!!");

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

            if (document.getElementById('ContentPlaceHolder1_txt_SQuantity').value == "") {
                alert("Quantity Should Not Be Blank..!!");

                return false;
            }
           
            if (document.getElementById('ContentPlaceHolder1_txt_SRate').value == "") {
                alert("Rate Should Not Be Blank..!!");

                return false;
            }
            if (document.getElementById('ContentPlaceHolder1_txt_SAmount').value == "") {
                alert("Amount Should Not Be Blank..!!");

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
                            Job Card Entry</h3>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" colspan="2">
                                J.C. No.</td>
                            <td style="width: 1%" colspan="2">
                                <strong>:</strong>
                            </td>
                            <td style="width: 30%" colspan="2">
                                <asp:TextBox ID="txt_jcno" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="100px" Enabled="False">1</asp:TextBox>
                                <asp:TextBox ID="txt_jcyear" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                    Width="100px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%" colspan="2">
                                &nbsp;</td>
                            <td style="width: 1%" colspan="2" align="left">
                                &nbsp;Date</td>
                            <td colspan="2" style=" position:relative">
                                <asp:TextBox ID="txt_date" runat="server" 
                                    CssClass="TextBoxGraiantDate" Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_date_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_date">
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
                            <td colspan="2">
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
                                <asp:DropDownList ID="ddl_Model" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px" 
                                   >
                                </asp:DropDownList>
                            </td>
                            <td colspan="2" class="style1">
                                </td>
                            <td class="style1" colspan="2" align="left">
                                &nbsp;Chasis No.</td>
                            <td colspan="2" class="style1">
                                <asp:TextBox ID="txt_chassisno" runat="server" CssClass="TextBoxGraiant"
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2" class="style1">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Km Covered</td>
                            <td class="ui-priority-primary" colspan="2">
                                :
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_kcovered" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2" align="left">
                                Key&nbsp; No.</td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_keyno" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Service Type</td>
                            <td colspan="2">
                                :</td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddl_servicetype" runat="server" CssClass="TextBoxGraiant" 
                                    Height="25px" Width="200px">
                                   <asp:ListItem>...Select...</asp:ListItem>
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
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">
                                &nbsp; </td>
                            <td colspan="2" align="left">
                                Sale Date</td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_saledate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_saledate_CalendarExtender" runat="server" 
                                    CssClass="red" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_saledate">
                                </asp:CalendarExtender>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Supervisor</td>
                            <td colspan="2">
                                :
                            </td>
                            <td colspan="2">
                                &nbsp;<asp:DropDownList ID="ddl_supervisor" runat="server" 
                                    CssClass="TextBoxGraiant" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2" align="left">
                                Technician</td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddl_technisian" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Delivery Date</td>
                            <td colspan="2">
                                :</td>
                            <td colspan="2" style=" position:relative">
                                <asp:TextBox ID="txt_deliverydate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="200px"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txt_deliverydate_MaskedEditExtender" runat="server" TargetControlID="txt_deliverydate"
MaskType="Date" Mask="99/99/9999" MessageValidatorTip="true">
</asp:MaskedEditExtender>
                              
                            
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2" align="left">
                                Time</td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_time" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="txt_time_MaskedEditExtender" runat="server" 
                                   MaskType="Time" Mask="99:99:99" MessageValidatorTip="true"
                                   AcceptAMPM="true"
                                    TargetControlID="txt_time">
                                </asp:MaskedEditExtender>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="14">
                                <table id="tbl_details" runat="server" 
                                    style="border-style: dashed; border-width: thin; border-color: #000000;">
                                    <tr bgcolor="#6fb3e0">
                                        <td class="ui-priority-primary">
                                            Service Code</td>
                                        <td class="ui-priority-primary">
                                            Description</td>
                                        <td class="ui-priority-primary">
                                            Quantity</td>
                                        <td class="ui-priority-primary">
                                            Rate</td>
                                        <td class="ui-priority-primary">
                                            Amount</td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2" style=" position:relative">
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
                                        <td class="style2">
                                            <asp:TextBox ID="txt_SDescription" runat="server" 
                                                CssClass="SmalldottedTextBox" Width="200px"></asp:TextBox>
                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="txt_SQuantity" runat="server" CssClass="SmalldottedTextBox" 
                                                onkeypress="return AllowNumbersOnly(this,event)" Width="100px"></asp:TextBox>
                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="txt_SRate" runat="server" CssClass="SmalldottedTextBox" 
                                                onkeypress="return AllowNumbersOnly(this,event)" Width="100px"></asp:TextBox>
                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="txt_SAmount" runat="server" CssClass="SmalldottedTextBox" 
                                                onkeypress="return AllowNumbersOnly(this,event)" Width="100px"></asp:TextBox>
                                        </td>
                                        <td class="style2">
                                            <asp:Button ID="btn_ServiceAdd0" runat="server" CssClass="VerySmallYellow" 
                                          OnClientClick="return validationfields(); "       Height="28px" onclick="btn_ServiceAdd_Click" Text="Add" Width="40px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="2">
                            </td>
                            <td class="style1" colspan="2">
                            </td>
                            <td class="style1" colspan="2">
                            </td>
                            <td class="style1" colspan="2">
                            </td>
                            <td class="style1" colspan="2">
                            </td>
                            <td class="style1" colspan="2">
                            </td>
                            <td class="style1" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="14">
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
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
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtn_edit" runat="server" 
                                                    ImageUrl="~/Admin/Images/edit-icon.png"
                                                     ToolTip='<%# Eval("JCS_Sino") %>' onclick="imgbtn_edit_Click" />
                                            </ItemTemplate>
                                            <ItemStyle Width="40px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtn_SDelete" runat="server" Height="20px" 
                                                    ImageUrl="~/Admin/Images/Delete_Icon.png" onclick="imgbtn_SDelete_Click" 
                                                    ToolTip='<%# Eval("JCS_Sino") %>' />
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
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Customer Name</td>
                            <td colspan="2">
                                :</td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddl_customer" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px" AutoPostBack="True" 
                                    onselectedindexchanged="ddl_customer_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Address</td>
                            <td colspan="2">
                                :</td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_address" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px" AutoPostBack="True"></asp:TextBox>
                               
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" width="10%">
                                Ph. (O).</td>
                            <td colspan="2" width="2%">
                                :</td>
                            <td colspan="2" width="25%">
                                <asp:TextBox ID="txt_phoneno" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px"></asp:TextBox>
                             
                                &nbsp;
                             
                            </td>
                            <td align="right" colspan="2" width="5%">
                                (R)</td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_phoneno0" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td align="right" colspan="2" width="5%">
                                (M)</td>
                            <td colspan="2">
                                <asp:TextBox ID="txt_phoneno1" runat="server" CssClass="TextBoxGraiant" 
                                    Width="200px"></asp:TextBox>
                            </td>
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
                            <td colspan="2">
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
                                 OnClientClick="return validationfields1();"    Height="26px" onclick="btn_Submit_Click" Text="Submit" Width="120px" />
                            </td>
                            <td align="right" colspan="2">
                                <asp:Button ID="btn_Cancel" runat="server" CssClass="VerySmallRed" 
                                    Height="26px" onclick="btn_Cancel_Click" Text="Cancel" Width="120px" />
                            </td>
                            <td colspan="2">
                                &nbsp;
                                <asp:Button ID="btnback" runat="server" CssClass="thinCupersulphate" 
                                    onclick="btnback_Click" Text="Back" />
                            </td>
                            <td colspan="2">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="12">
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
