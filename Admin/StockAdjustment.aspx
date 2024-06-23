<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="StockAdjustment.aspx.cs" Inherits="Admin_StockAdjustment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset id="FS_IssuedBook" runat="server">
                    <legend>
                        <h4>
                            Search Partnowise Stock&nbsp; </h4>
                    </legend>
                    <table width="100%">
                        <tr>
                            <td style="width: 16%">
                                &nbsp;</td>
                            <td style="width: 1%">
                                &nbsp;</td>
                            <td style="width: 24%">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                            <td style="width: 16%">
                                &nbsp;</td>
                            <td style="width: 1%">
                                &nbsp;</td>
                            <td style="width: 24%">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 16%">
                                &nbsp;</td>
                            <td style="width: 1%">
                                &nbsp;</td>
                            <td style="width: 24%">
                                &nbsp;</td>
                            <td style="width: 16%">
                                &nbsp;</td>
                            <td style="width: 1%">
                                &nbsp;</td>
                            <td style="width: 24%">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
            <asp:Panel ID="Panel1" runat="server">
                    <table width="100%">
                        <tr>
                            <td align="center" valign="top">
                                <asp:Label ID="lbl_BillType" runat="server" Font-Bold="True" 
                                    Font-Names="Cambria" Font-Size="16px">RASHMI MOTORS</asp:Label>
                                <br />
                                <asp:Label ID="lbl_BranchAddress" runat="server" Font-Bold="False" 
                                    Font-Names="Cambria"></asp:Label>
                                ,<asp:Label ID="lbltin" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lbl_InvoiceType" runat="server" Font-Bold="True" 
                                    Font-Names="Cambria" Font-Size="16px">Spare Stock Report</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" valign="top" style="position:relative">
                                Spare Part Name:<asp:TextBox ID="txt_PartNo" runat="server" 
                                    CssClass="SmalldottedTextBox" Width="200px" AutoPostBack="True" 
                                    ontextchanged="txt_PartNo_TextChanged"></asp:TextBox>
                                 <asp:AutoCompleteExtender ID="txt_PartNo_AutoCompleteExtender" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetPartNo" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_PartNo">
                                            </asp:AutoCompleteExtender>
                           </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                       Font-Names="Vani" Font-Size="12px" Width="100%" BorderColor="#44C767" 
                                        Font-Bold="True" ForeColor="Black">
                                        <Columns>
                                          <asp:TemplateField HeaderText="Sl. No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            </asp:TemplateField>
                                            

                                          
                                           <asp:TemplateField HeaderText="Part No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpartno" runat="server" Text='<%# Eval("Itm_Partno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Itm PartDescrption">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpartdescription" runat="server" 
                                                    Text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sale Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sale" runat="server" 
                                                    Text='<%# Eval("Itm_SalePrice") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Net Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnetquantity" runat="server" 
                                                    Text='<%# Eval("netquantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        
                                               <asp:TemplateField HeaderText="Add Quantity">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_adjustquntity"  runat="server" Width="90px"></asp:TextBox>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            
                                            
                                             <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnedit" runat="server" 
                                                    ImageUrl="~/Admin/Icon/Edit.jpg"
                                                    ToolTip='<%# Eval("Itm_Partno") %>' Height="20px" 
                                                    onclick="imgbtnedit_Click"   />
                                                <asp:ImageButton ID="imgbtnupadte" runat="server" Height="20px" ToolTip='<%# Eval("Itm_Partno") %>'
                                                    ImageUrl="~/Admin/Images/UPDATE (1).png" onclick="imgbtnupadte_Click" 
                                                    Visible="False" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle Font-Names="Cambria" Font-Size="14px" Font-Bold="True" 
                                            BackColor="White" ForeColor="#CC0000" HorizontalAlign="Left" />
                                    </asp:GridView>
                                </td>
                        </tr>
                    </table>
            </asp:Panel>
                </fieldset>

                <table width="100%">
                <tr>
                    <td align="center" valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        <asp:Button ID="btnBookAdd" runat="server" CssClass="btn-info" Font-Bold="True" Font-Names="US"
                            OnClientClick="return PrintPanel()" Text="Print" Visible="false" />
                        <asp:Button ID="btn_excel" runat="server" CssClass="ThinRed" 
                            Text="Download To Excel" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        &nbsp;
                    </td>
                </tr>
            </table>

</asp:Content>

