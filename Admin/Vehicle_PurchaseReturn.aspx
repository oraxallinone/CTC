<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Vehicle_PurchaseReturn.aspx.cs" Inherits="Admin_Spare_PurchaseEntry" %>

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

         <%--How to use Function in a button
         <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick = "return PrintPanel();" />--%>
    </script>
    <link href="SmitaStYlE/Calender/red.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss06.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="js/SparePurchaseEntryCal.js" type="text/javascript"></script>
    <script src="SmitaStYlE/SumUsingJquery/VehiclePurchaseEntry.js" type="text/javascript"></script>
    <script src="SmitaStYlE/SumUsingJquery/jquery.min.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            height: 28px;
        }
        .style2
        {
            height: 46px;
        }
        .style3
        {
            height: 23px;
        }
        .style4
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
            <div id="content" style="background-color: #FFFFFF; padding-left: 15px; padding-right: 10px;
                width: 100%">
                <fieldset style="padding-right: 20px;">
                    <legend>
                        <h3>
                            Vehicle Purchase Return</h3>
                    </legend>
                    <div style="width: 100%" align="center">
                        <table width="100%">
                            <tr>
                                <td width="45%" align="right">
                                    SI. No.
                                </td>
                                <td width="2%">
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txt_billno" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="200px" AutoPostBack="True" OnTextChanged="txt_billno_TextChanged" onkeypress="return AllowDecimalNumbersOnly(this,event)" ></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                        <table width="100%">
                            <tr>
                                <td style="width: 15%">
                                    &nbsp;
                                </td>
                                <td style="width: 1%">
                                    &nbsp;
                                </td>
                                <td style="width: 30%">
                                    &nbsp;
                                </td>
                                <td style="width: 15%">
                                    &nbsp;
                                </td>
                                <td style="width: 1%">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 15%">
                                    Si. No
                                </td>
                                <td style="width: 1%">
                                    <strong>:</strong>
                                </td>
                                <td style="width: 30%">
                                    <asp:TextBox ID="txt_sino" runat="server" CssClass="TextBoxGraiant" Enabled="False"
                                        Height="25px" Width="200px"></asp:TextBox>
                                </td>
                                <td style="width: 15%">
                                    Bill Date&nbsp;
                                </td>
                                <td style="width: 1%">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_billdate" runat="server" CssClass="TextBoxGraiantDate" Height="25px"
                                        Width="150px"></asp:TextBox>
                                    <asp:CalendarExtender ID="txt_billdate_CalendarExtender" runat="server" CssClass="orange"
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_billdate">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Inv No
                                </td>
                                <td>
                                    <strong>:</strong>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_invoiceno" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;Inv Date
                                </td>
                                <td class="ui-priority-primary">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_invoicedate" runat="server" CssClass="TextBoxGraiantDate" Height="25px"
                                        Width="150px"></asp:TextBox>
                                    <asp:CalendarExtender ID="txt_invoicedate_CalendarExtender" runat="server" CssClass="red"
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_invoicedate">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Supplier
                                </td>
                                <td class="style3">
                                    &nbsp;
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="ddl_supplier" runat="server" Width="200px" 
                                       >
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;Return Date</td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txt_returndate" runat="server" CssClass="TextBoxGraiantDate" 
                                        Height="25px" Width="150px"></asp:TextBox>
                                    <asp:CalendarExtender ID="txt_returndate_CalendarExtender" runat="server" 
                                        CssClass="red" Enabled="True" Format="dd/MM/yyyy" 
                                        TargetControlID="txt_returndate">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Address
                                </td>
                                <td class="ui-priority-primary">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_address" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="200px" Rows="4" TextMode="MultiLine" Enabled="False" ReadOnly="True"></asp:TextBox>
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
                            </tr>
                            <tr>
                                <td>
                                    Phone No
                                </td>
                                <td class="ui-priority-primary">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_phoneno" runat="server" CssClass="SmalldottedTextBox" onkeypress="return AllowNumbersOnly(this,event)"
                                        ReadOnly="True" Width="200px" Enabled="False"></asp:TextBox>
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
                            </tr>
                            <tr>
                                <td colspan="6" style="border-bottom-style: groove; border-bottom-width: medium;
                                    border-bottom-color: #000000">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                </td>
                            </tr>
                        </table>
                    <%--    <table id="tbl_PurchaseDetails" width="100%" runat="server">
                            <tr>
                                <td>
                                    Vehicle Type
                                </td>
                                <td class="ui-priority-primary">
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_VType" runat="server" AutoPostBack="True" CssClass="SmalldottedTextBox"
                                        Height="26px" OnSelectedIndexChanged="ddl_VType_SelectedIndexChanged" Width="200px">
                                        <asp:ListItem>...Select...</asp:ListItem>
                                        <asp:ListItem>HCV</asp:ListItem>
                                        <asp:ListItem>LCV</asp:ListItem>
                                    </asp:DropDownList>
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
                                    Model
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_model" runat="server" AutoPostBack="True" CausesValidation="True"
                                        OnSelectedIndexChanged="ddl_model_SelectedIndexChanged" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Makers
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_makers" runat="server" CssClass="TextBoxGraiant" Enabled="False"
                                        Height="25px" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Chassis No
                                </td>
                                <td class="ui-priority-primary">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_chessisno" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    Engine No
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_engineno" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Color
                                </td>
                                <td class="ui-priority-primary">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_color" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    Key No
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_keyno" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Rate&nbsp;
                                </td>
                                <td>
                                    :&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_rate" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="200px">0</asp:TextBox>
                                </td>
                                <td>
                                    &nbsp; Quantity
                                </td>
                                <td>
                                    &nbsp;:
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_quantity" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="200px">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Amount
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_amount" runat="server" CssClass="TextBoxGraiant" onkeypress="return AllowDecimalNumbersOnly(this,event)"
                                        ReadOnly="false" Width="200px">0</asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td valign="bottom">
                                    <asp:Button ID="btn_add" runat="server" CssClass="thinCupersulphate" Height="26px"
                                        OnClick="btn_add_Click" Text="Save" Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" style="border-bottom-style: groove; border-bottom-width: medium;
                                    border-bottom-color: #000000">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                </td>
                            </tr>
                        </table>--%>
                        <table width="100%">
                            <tr>
                                <td colspan="6">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                        Width="100%">
                                        <AlternatingRowStyle CssClass="alt" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="SlNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="40px" />
                                                <ItemStyle HorizontalAlign="Left" Width="40px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vehicle Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblvechiletype" runat="server" Text='<%# Eval("Mv_VehicleType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Model Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmodelname" runat="server" Text='<%# Eval("Mv_ModelName") %>' ToolTip='<%# Eval("Mv_Id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="150px" />
                                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Makers Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmakersname" runat="server" Text='<%# Eval("Mv_Makers") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="150px" />
                                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Chassis No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblchassisno" runat="server" Text='<%# Eval("Vp_Chassisno") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Engine No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblengineno" runat="server" Text='<%# Eval("Vp_Engineno") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Color">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcolor" runat="server" Text='<%# Eval("Vp_Color") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Key No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblkeyno" runat="server" Text='<%# Eval("Vp_Keyno") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblrate" runat="server" Text='<%# Eval("Vp_Rate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblquantity" runat="server" Text='<%# Eval("Vp_Quantity") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamount" runat="server" Text='<%# Eval("Vp_Amount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Return">
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_return" runat="server" CssClass="ThinRed" OnClick="btn_return_Click"
                                                      ToolTip='<%# Eval("Vp_Id") %>' Text="Return" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pgr" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    &nbsp;
                                    <asp:ScriptManager ID="ScriptManager2" runat="server">
                                    </asp:ScriptManager>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="50%">
                                    &nbsp;
                                </td>
                                <td>
                                    Gross Amount
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_AGrossAmount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px" 
                                        Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lbldiscount" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td class="style2">
                                    Discount Amount
                                </td>
                                <td class="style2">
                                    :
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txt_ADiscountAmount" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        onkeypress="return AllowDecimalNumbersOnly(this,event)" Width="160px" 
                                        Enabled="False">0</asp:TextBox>
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
                                    Vat%<asp:TextBox ID="txtvat" runat="server" Width="40%" onkeypress="return AllowDecimalNumbersOnly(this,event)"
                                        CssClass="SmalldottedTextBox" Enabled="False">0</asp:TextBox>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_vatamount" runat="server" CssClass="TextBoxGraiant" Enabled="False"
                                        Height="25px" Width="160px" onkeypress="return AllowDecimalNumbersOnly(this,event)">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    Cst%<asp:TextBox ID="txtcst" runat="server" Width="40%" onkeypress="return AllowDecimalNumbersOnly(this,event)"
                                        CssClass="SmalldottedTextBox" Enabled="False">0</asp:TextBox>
                                </td>
                                <td class="style1">
                                    :
                                </td>
                                <td class="style1">
                                    <asp:TextBox ID="txt_cstamount" runat="server" CssClass="TextBoxGraiant" Width="160px"
                                        Height="25px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                        Enabled="False">0</asp:TextBox>
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
                                    Add Other
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_other" runat="server" CssClass="TextBoxGraiant" Height="25px"
                                        Width="160px" onkeypress="return AllowDecimalNumbersOnly(this,event)" 
                                        Enabled="False">0</asp:TextBox>
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
                                    <asp:TextBox ID="txt_billamount" runat="server" CssClass="TextBoxGraiant" Enabled="False"
                                        Height="25px" Width="160px" onkeypress="return AllowDecimalNumbersOnly(this,event)"
                                        ReadOnly="True">0</asp:TextBox>
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
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_update" runat="server" CssClass="thinGreen" OnClick="btn_update_Click"
                                        Text="Update" Width="100px" Visible="False" />
                                    &nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                  <%--  <table width="100%">
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
                    </table>--%>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
