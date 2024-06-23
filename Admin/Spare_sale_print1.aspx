<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Spare_sale_print1.aspx.cs" Inherits="Admin_Spare_sale_print1" %>


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

     <style type="text/css">
         .style1
         {
             font-family: "Courier New", Courier, monospace;
         }
         .style2
         {
             font-family: "Times New Roman", Times, serif;
         }
         .style3
         {
             font-family: "Agency FB";
         }
         .style5
         {
             font-size: medium;
         }
     </style>

     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
  
<center>
    <table style="width:210mm;height:210mm; text-transform:uppercase;">
    <tr>
    <td align="center" height="80px" valign="top" colspan="2" style="border-bottom: thin dashed;">
        <asp:Label ID="lbl_BillType" runat="server" Font-Bold="True" 
            Font-Names="Cambria" Font-Size="16px">Rashmi Motors</asp:Label>
        <br /><asp:Label ID="Label2" runat="server" Font-Bold="True" 
            Font-Names="Cambria" Font-Size="12px"> Authorised Main Dealer Of Ashok Leyland Ltd.</asp:Label>
        <br />
        <asp:Label ID="lbl_BranchAddress" runat="server" Font-Bold="False" 
            Font-Names="Cambria"></asp:Label>
        <br />
        <asp:Label ID="lbl_brmail" runat="server" Font-Bold="False" 
            Font-Names="Cambria" style="text-transform:lowercase;"></asp:Label>
        <br />
        GSTIN No-<asp:Label ID="lbltinno" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lbl_InvoiceType" runat="server" Font-Bold="True" 
            Font-Names="Cambria" Font-Size="16px">INVOICE</asp:Label>
            <br />
             <asp:Label ID="lblsaleby" runat="server" Font-Bold="True" 
            Font-Names="Cambria" Font-Size="16px"></asp:Label>
        </td>
    </tr>
        <tr>
            <td align="left" valign="top" height="20PX" colspan="2">
                <strong style="text-decoration: underline">CUSTOMER NAME</strong></td>
        </tr>
        <tr>
            <td width="60%" align="left" valign="top" height="60px">
                <asp:Label ID="lbl_Name" runat="server" Font-Bold="True" Font-Names="Cambria"></asp:Label>
                <br />
                <asp:Label ID="lbl_Address" runat="server" Width="300px"></asp:Label>
                <br />
                <asp:Label ID="lbl_TinNo" runat="server"></asp:Label>
                <br />

                STATE CODE:<asp:Label ID="lbl_statecode" runat="server"></asp:Label><br />
               
                </td>
            <td align="left" valign="top">
                <table width="100%">
                    <tr>
                        <td class="ui-priority-primary" width="40%">
                            Bill No.</td>
                        <td width="1%">
                            :</td>
                        <td>
                            <asp:Label ID="lbl_BillNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary">
                            Bill Date</td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_BillDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary">
                            Vehicle No.</td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_vehicle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary">
                            Place Of Supply.</td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_supplace" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr >
            <td colspan="2" valign="top"  align="left">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  style="font-size:12px; font-family:Arial;" >
                    <Columns>
                        <asp:TemplateField HeaderText="SL.No">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part No & Desc.">
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("Itm_Partno") %>'></asp:Label><br />
                                  <asp:Label ID="Label12" runat="server" Text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Part Description">
                            <ItemTemplate>
                              
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="HSN">
                            <ItemTemplate>
                                <asp:Label ID="lblhsn" runat="server" Text='<%# Eval("hsncode") %>'></asp:Label>
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

                        
                        <asp:TemplateField HeaderText="MRP">
                            <ItemTemplate>
                                <asp:Label ID="Labelmrp" runat="server" Text='<%# Eval("Itm_SalePrice") %>'></asp:Label>
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
                        

                        
                        <asp:TemplateField HeaderText="Disc%">
                            <ItemTemplate>
                                <asp:Label ID="Label151" runat="server" Text='<%# Eval("Ss_Discountper") %>'></asp:Label>
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

                        <asp:TemplateField HeaderText="TaxableAmount">
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%# Eval("Ss_Amount") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="SGst">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelSGst" runat="server" Text='<%# Eval("Ss_SGst") %>'></asp:Label>
                                                <asp:Label ID="lbl_vatsgst" runat="server" Text='<%# Eval("Ss_SGstP") %>'></asp:Label>
                                                <asp:Label ID="Label4" runat="server" Text='%'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CGst">
                                            <ItemTemplate>
                                                <asp:Label ID="Labelcgst" runat="server" Text='<%# Eval("Ss_CGst") %>'></asp:Label>
                                                 <asp:Label ID="lbl_vatcgst" runat="server" Text='<%# Eval("Ss_CGstP") %>'></asp:Label>
                                                <asp:Label ID="Label5" runat="server" Text='%'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IGst">
                                            <ItemTemplate>
                                                <asp:Label ID="Labeligst" runat="server" Text='<%# Eval("Ss_IGst") %>'></asp:Label>
                                                 <asp:Label ID="lbl_vatigst" runat="server" Text='<%# Eval("Itm_VatPercent") %>'></asp:Label>
                                                <asp:Label ID="Label6" runat="server" Text='%'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tax Amount">
                            <ItemTemplate>
                                <asp:Label ID="Label17" runat="server" Text='<%# Eval("Ss_TaxAmont") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="85px" />
                            <ItemStyle HorizontalAlign="Left" Width="85px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Net Amount">
                            <ItemTemplate>
                                <asp:Label ID="Label18" runat="server" Text='<%# Eval("Ss_Total") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="85px" />
                            <ItemStyle HorizontalAlign="Left" Width="85px" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Bold="True" Font-Names="Cambria" />
                    <RowStyle VerticalAlign="Top" />
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td align="left" style="border-bottom: thin dashed; border-top: thin dashed;">
                <strong style="font-variant:small-caps;">Amount in Text:<br />
                <asp:Label ID="lbl_AmountInText" runat="server"></asp:Label>
                </strong></td>
            <td align="right" valign="top" 
                style="border-bottom: thin dashed; border-top: thin dashed;">
                <table width="80%">
                    <tr>
                        <td class="ui-priority-primary" width="55%" align="left">
                            Gross Total</td>
                        <td width="1%" align="left">
                            :</td>
                        <td align="left">
                            <asp:Label ID="lbl_GrossAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary" align="left">
                            Discount</td>
                        <td align="left">
                            :</td>
                        <td align="left">
                            <asp:Label ID="lbl_DiscountAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary" align="left">
                            Net Amount</td>
                        <td align="left">
                            :</td>
                        <td align="left">
                            <asp:Label ID="lbl_net" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary" align="left">
                            Tax Amount</td>
                        <td align="left">
                            :</td>
                        <td align="left">
                            <asp:Label ID="lbl_VatAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary" align="left">
                            P.F Charges</td>
                        <td align="left">
                            :</td>
                        <td align="left">
                            <asp:Label ID="lbl_PfAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary" align="left">
                            Other Charges</td>
                        <td align="left">
                            :</td>
                        <td align="left">
                            <asp:Label ID="lbl_OtherCharges" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary" align="left">
                            BILL AMOUNT</td>
                        <td align="left">
                            :</td>
                        <td align="left">
                            <asp:Label ID="lbl_BillAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        
            <td align="left" class="style5" valign="bottom">
                <strong class="style3">
                    <asp:Label ID="Label1" runat="server" Text="This is to certify that invoice amount is given free of cost as per company 
                advice" Visible="False"></asp:Label></strong>
                <br />
<br />
<br />

                <strong class="style3">Customer&#39;s Signature</strong></td>
            <td align="center" class="style5">
                <span class="style2"><strong class="style3">FOR RASHMI MOTORS</strong></span><strong><br class="style3" />
                <br />
                <br />
                <br />
                </strong><span class="style2"><strong class="style3">Authorised Signatory</strong></span></td>
        </tr>
        <tr>
            <td align="left" colspan="2" height="15px" style="border-bottom: thin dashed; border-top: thin dashed;">
                <strong style="text-decoration: underline">Terms and Conditions:<br /> </strong>
                1. Goods once sold will not be taken back.<br /> 2. Only the counters of CUTTACK 
                shall have jurisidiction in any proceeding relating to this control.<br /> 3. 
                I/We hereby certify that my/our registration Certificate under the Gst Act s in 
                force on the date on which the sale of the goods specified in this bill/cash.<br /> </td>
        </tr>
        <tr>
            <td colspan="2" align="center" valign="top" height="10px" class="style5">
                <strong class="style1">SATISFICATION NOTE/GATE PASS</strong></td>
        </tr>
        <tr>
            <td align="left" valign="top" height="75px">
                <table width="100%">
                    <tr>
                        <td class="ui-priority-primary" width="40%">
                            Bill No.</td>
                        <td width="1%">
                            :</td>
                        <td>
                            <asp:Label ID="lbl_BillNo0" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary" valign="top">
                            Mr./Mrs</td>
                        <td valign="top">
                            :</td>
                        <td valign="top">
                            <asp:Label ID="lbl_Name0" runat="server" Font-Bold="True" Font-Names="Cambria"></asp:Label>
                            <asp:Label ID="lbl_Address0" runat="server" Width="300px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top">
                <table width="100%">
                    <tr>
                        <td class="ui-priority-primary" width="40%">
                            Bill Date</td>
                        <td width="1%">
                            :</td>
                        <td>
                            <asp:Label ID="lbl_BillDate0" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary">
                            Bill Amount</td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_BillAmount0" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        
            <td align="left" class="style5" valign="bottom" style="border-bottom: thin dashed; margin-top:-20px;">
           

<br />

                <strong class="style3">Customer&#39;s Signature</strong></td>
            <td align="center" class="style5" style="border-bottom: thin dashed; ">
                <span class="style2"><strong class="style3">FOR RASHMI MOTORS</strong></span><strong><br class="style3" />
              

                <br />
                </strong><span class="style2"><strong class="style3">Authorised Signatory</strong></span></td>
        </tr>
        <tr>
            <td align="left" colspan="2" valign="top" height="40px">
                1. I/We Have received the vehicle from workshop
                <br />
                2. I/We accept all above terms &amp; conditions.</td>
        </tr>
    </table>
    </center>
    </asp:Panel>
      <center>
   <table width="210mm">
                        <tr>
                            <td align="center" valign="top" >
                                    &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <asp:Button ID="btnBookAdd" runat="server" CssClass="btn-info" Font-Bold="True" 
                                    Font-Names="US" OnClientClick="return PrintPanel()" Text="Print" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                &nbsp;</td>
                        </tr>
                      
                    </table>
</center>
</asp:Content>

