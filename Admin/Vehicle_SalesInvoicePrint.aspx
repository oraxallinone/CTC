<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Vehicle_SalesInvoicePrint.aspx.cs" Inherits="Admin_Vehicle_SalesInvoicePrint" %>

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
     </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
  
<center>
    <table style="width:210mm;height:210mm">
    <tr>
    <td align="center" height="80px" valign="top" colspan="2">
        <asp:Label ID="lbl_BillType" runat="server" Font-Bold="True" 
            Font-Names="Cambria" Font-Size="16px">INVOICE</asp:Label>
        </td>
    </tr>
        <tr>
            <td align="left" valign="top" height="20PX" colspan="2">
                <strong style="text-decoration: underline">CUSTOMER NAME</strong></td>
        </tr>
        <tr>
            <td width="60%" align="left" valign="top" height="100px">
                <asp:Label ID="lbl_Name" runat="server" Font-Bold="True" Font-Names="Cambria"></asp:Label>
                <br />
                <asp:Label ID="lbl_Address" runat="server" Width="300px"></asp:Label>
                <br />
                <asp:Label ID="lbl_TinNo" runat="server"></asp:Label>
                <br />
                <br />
                <strong style="font-family: 'Courier New', Courier, monospace; font-size: 12px">
                Hypothecated to
                <asp:Label ID="lbl_hyp" runat="server"></asp:Label>
                </strong></td>
            <td align="left" valign="top">
                <table width="100%">
                    <tr>
                        <td width="40%" class="ui-priority-primary">
                            Invoice No.</td>
                        <td width="1%">
                            :</td>
                        <td>
                            <asp:Label ID="lbl_InvoiceNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary">
                            Date</td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_InvoiceDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr >
            <td colspan="2" height="15px" valign="top" style="border-top: thin solid; border-bottom: thin solid;">
                <table width="100%">
                <tr>
                <td align="left" width="55%">
                
                    <strong>PARTICULARS</strong></td>
                    <td align="left" width="15%">
                        <strong>QTY</strong></td>
                    <td align="center">
                        <strong>AMOUNT</strong></td>
                </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td colspan="2" height="60px" valign="top">
                <table width="100%">
                    <tr>
                        <td align="left" width="55%">
                            <asp:Label ID="lbl_Particulars" runat="server"></asp:Label>
                        </td>
                        <td align="left" width="15%">
                            <asp:Label ID="lbl_Qty" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lbl_Amount" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" height="15px">
                <strong style="text-decoration: underline">VEHICLE DETAILS:</strong></td>
        </tr>
        <tr>
            <td colspan="2" align="left" valign="top" height="250px">
                <table width="100%" 
                    style="font-family: Cambria; font-size: 10px; text-transform: uppercase; color: #000000; font-weight: bolder;">
                <tr>
                <td width="15%">
                
                    MAKE</td>
                    <td width="1%">
                        :</td>
                    <td width="30%">
                        <asp:Label ID="lbl_Make" runat="server"></asp:Label>
                    </td>
                    <td width="15%">
                        ENGINE NO</td>
                    <td width="1%">
                        :</td>
                    <td>
                        <asp:Label ID="lbl_EngineNo" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr>
                        <td>
                            MODEL</td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_Model" runat="server"></asp:Label>
                        </td>
                        <td>
                            BATTERY MAKE &amp; NO</td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_BatteryNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            CHASSIS NO</td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_ChasisNo" runat="server"></asp:Label>
                        </td>
                        <td>
                            TYRE MAKE &amp; TYPE</td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_Type" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td height="40px">
                &nbsp;</td>
            <td align="left" valign="top">
                <table width="100%">
                    <tr>
                        <td class="ui-priority-primary" width="40%">
                            Before Tax
                        </td>
                        <td width="1%">
                            :</td>
                        <td>
                            <asp:Label ID="lbl_BeforeTax" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary">
                            Vat %
                            <asp:Label ID="lbl_vatPer" runat="server"></asp:Label>
                        </td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_TaxAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr >
                        <td class="ui-priority-primary" style="border-bottom: thin; border-bottom-style: dotted;">
                            Other Charges</td>
                        <td style="border-bottom: thin; border-bottom-style: dotted;">
                            :</td>
                        <td style="border-bottom: thin; border-bottom-style: dotted;">
                            <asp:Label ID="lbl_OtherCharges" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary">
                            Bill Amount</td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_BillAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <strong style="font-variant:small-caps;">Amount in Text:<br />
                <asp:Label ID="lbl_AmountInText" runat="server"></asp:Label>
                </strong>
            </td>
            <td align="left" valign="top">
                &nbsp;</td>
        </tr>
        <tr >
            <td align="left" valign="top" style="border-bottom: thin; border-bottom-style: solid;">
                <strong>NET PAYABLE</strong></td>
            <td align="left" valign="top" style="border-bottom: thin; border-bottom-style: solid;">
                <asp:Label ID="lbl_NetPaybleAmount" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left" valign="top">
                <span class="style1">This Registration Certificate is Valid on the date of issue 
                of this RETAIL INVOICE </span>
                <br class="style1" />
                <span class="style1">TERMS &amp; CONDITIONS : </span>
                <br class="style1" />
                <span class="style1">1. Payments by Cheques/Demand Drafts may be in favour of RASHMI MOTORS, payable 
                at CUTTACK.<br /> 2. Only the courts of Cuttack shall have jurisdiction in any 
                proceeding relating to this contract.
                <br />
                3. Interest will be charged @ 20% P.A I payment are not received by us within 
                ___ days from the date of Invoice</span></td>
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

