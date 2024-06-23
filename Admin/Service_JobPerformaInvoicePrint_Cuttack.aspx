<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Service_JobPerformaInvoicePrint_Cuttack.aspx.cs" Inherits="Admin_Service_JobPerformaInvoicePrint_Cuttack" %>

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
             height: 23px;
         }
         .style2
         {
             height: 25px;
         }
         .style3
         {
             height: 22px;
         }
         </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="Panel1" runat="server">
  
<center>
    <table style="width:210mm;height:210mm;  font-size:12px;text-transform:uppercase;">
<tr>
<td colspan="9" >
</td>
</tr>
<tr>
<td align="center"  style="color: #000000;  font-size:12px; font-weight: bold; font-size: x-large;" 
        colspan="9">
    RASHMI MOTORS</td>
</tr>
<tr>
<td align="center" 
        colspan="9">
    Authorised Main Dealer Of Ashok Leyland Ltd.</td>
</tr>
        <tr>
            <td align="center" colspan="9">
                N.H-5, Manguli, Cuttack</td>
        </tr>
        <tr>
            <td align="center" colspan="9" style="text-transform:lowercase;">
                E-mail : rashmimotors.lcv@rashmigroups.com , PH No- 06712393575</td>
        </tr>
        <tr>
            <td align="center" colspan="9" style="font-size: medium; color: #000000">
                GSTIN No-<asp:Label ID="lbltinno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="9" 
                
                style="font-size: medium; color: #000000; font-weight: bold; border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000;">
                PERFORMA INVOICE</td>
        </tr>
        <tr>
            <td align="center" class="style1" colspan="9" 
                style="color: #000000; font-weight: bold; font-size: medium">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" 
                width="10%">
                PARTY NAME</td>
            <td align="left" 
                width="2%">
                :</td>
            <td align="left" 
                width="20%">
                <asp:Label ID="lblpartyname" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2">
                &nbsp;</td>
            <td align="left" 
                width="10%" colspan="2">
                BILL NO</td>
            <td align="left" 
                width="2%">
                :</td>
            <td align="left">
                <asp:Label ID="lblbillno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" width="10%" class="style1">
                ADDRESS</td>
            <td align="left" width="2%" class="style1">
                :</td>
            <td align="left" width="20%" class="style1">
                <asp:Label ID="lbladdress" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2">
                </td>
            <td align="left" colspan="2" width="10%" class="style1">
                DATE</td>
            <td align="left" width="2%" class="style1">
                :</td>
            <td align="left" class="style1">
                <asp:Label ID="lbldate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="10%">
                PHONE NO</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="20%">
                <asp:Label ID="lblphnno" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2" 
                
                style="border-bottom: thin dotted #000000; color: #000000; font-weight: bold; font-size: medium; width: 30%;">
                &nbsp;</td>
            <td align="left" colspan="2" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="10%">
                TIME</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: 12px; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                <asp:Label ID="lbltime" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="10%">
                JOB CARD NO</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="20%">
                <asp:Label ID="lbljcardno" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2" 
                
                style="border-bottom: thin dotted #000000; color: #000000; font-weight: bold; font-size: medium; width: 30%;">
                &nbsp;</td>
            <td align="left" colspan="2" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="10%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="2%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" width="20%" class="style1">
                REGN NO</td>
            <td align="left" width="2%" class="style1">
                :</td>
            <td align="left" colspan="3" width="30%" class="style1">
                <asp:Label ID="lblregno" runat="server"></asp:Label>
            </td>
            <td align="left" width="15%" colspan="2" class="style1">
                MODEL</td>
            <td align="left" width="2%" class="style1">
                :</td>
            <td align="left" class="style1">
                <asp:Label ID="lblmodel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" width="20%">
                CHASIS NO.</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" colspan="3" width="30%">
                <asp:Label ID="lblchessisno" runat="server"></asp:Label>
            </td>
            <td align="left" width="15%" colspan="2">
                DATE OF SALE</td>
            <td align="left" width="2%">
                :</td>
            <td align="left">
                <asp:Label ID="lbldateofsale" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" width="20%">
                KILLOMETER</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" colspan="3" width="30%">
                <asp:Label ID="lblkilomtr" runat="server"></asp:Label>
            </td>
            <td align="left" width="15%" colspan="2">
                ENGINE . NO.</td>
            <td align="left" width="2%">
                :</td>
            <td align="left">
                <asp:Label ID="lblengno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" width="20%">
                &nbsp;</td>
            <td align="left" width="2%">
                &nbsp;</td>
            <td align="center" colspan="3" width="30%" 
                style="font-size: medium; color: #000000; font-weight: bold;">
                SPARE DETAILS</td>
            <td align="left" colspan="2" width="15%">
                &nbsp;</td>
            <td align="left" width="2%">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
<td align="left"  
        colspan="9">
    <asp:GridView ID="grd_spare" runat="server" AutoGenerateColumns="False" 
        style="font-size:12px; font-family:Arial;">
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
                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("Itm_Partno") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="Qty">
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("SE_Quantity") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="40px" />
                <ItemStyle HorizontalAlign="Left" Width="40px" />
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
                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("SE_Amount") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                <ItemStyle HorizontalAlign="Left" Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Disc%">
                <ItemTemplate>
                    <asp:Label ID="lbl_discper" runat="server" Text='<%# Eval("SE_DiscountPer") %>'></asp:Label>
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
        </Columns>
        <HeaderStyle Font-Bold="True" Font-Size="12px" ForeColor="Black" />
        <PagerStyle CssClass="pgr" />
    </asp:GridView>
    </td>
</tr>
        <tr>
            <td align="center" colspan="9" 
                style="font-size: medium; color: #000000; font-weight: bold;" 
                class="style1">
                SERVICE DETAILS</td>
        </tr>
        <tr>
            <td align="left" class="style1" colspan="9" >
                <asp:GridView ID="grd_service" runat="server" AutoGenerateColumns="False" 
                    style="font-size:12px; font-family:Arial;" ShowFooter="True" Width="100%">
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
                                <asp:Label ID="Labels2" runat="server" Text='<%# Eval("JCS_Servicecode") %>'></asp:Label>
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
                                <asp:Label ID="Labels5" runat="server" Text='<%# Eval("JCS_Rate") %>'></asp:Label>
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
        </tr>
        <tr>
        <td colspan="9">
        
        <table style="width:100%; font-size:12px;">
        
        <tr>
            <td align="right" colspan="4" >
                &nbsp;</td>
            
            <td align="left" colspan="2" width="22%">
                Spare Gross Amount
            </td>
            <td align="right" colspan="2" width="15%">
                <asp:Label ID="lblgrossamount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                &nbsp;</td>
            <td align="left" colspan="2" >
               Lubricant Gross Amount
                </td>
            <td align="right" colspan="2" >
              <asp:Label ID="lbl_lubgrossamount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                &nbsp;</td>
            <td align="left" colspan="2" 
                
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
                Discount@<asp:Label ID="lbl_tdiscper" runat="server" Font-Bold="True"></asp:Label>
                % </td>
            <td align="right" colspan="2" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
                <asp:Label ID="lbldiscountamount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                &nbsp;</td>
            <td align="left" colspan="2" style="font-weight: bold">
                Total Spare</td>
            <td align="right" colspan="2">
                <asp:Label ID="lbltotal" runat="server"></asp:Label>
            </td>
        </tr>
       
        <tr>
            <td align="right" colspan="4">
                &nbsp;</td>
            <td align="left" colspan="2" style="font-weight: bold">
                Total Lubricant</td>
            <td align="right" colspan="2">
               <asp:Label ID="lbl_lubttl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr> 
        <td align="right" colspan="4" >
                &nbsp;</td>
            <td align="left" colspan="2" class="style3" >
                Spare Gst Amount
            </td>
            <td align="right" colspan="2" class="style3">
                <asp:Label ID="lblvatamount" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr> 
        <td align="right"  colspan="4">
                &nbsp;</td>
            <td align="left" colspan="2" class="style3" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
                Lubricant Gst Amount
            </td>
            <td align="right" colspan="2" class="style3" style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
                <asp:Label ID="lbl_lubvatamount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td align="right" colspan="4">
                &nbsp;</td>
            <td align="left" colspan="2" class="style1">
                Total Spare Amount</td>
            <td align="right" colspan="2" class="style1">
                <asp:Label ID="lbl_Gspareamount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td align="right" colspan="4">
                &nbsp;</td>
            <td align="left" colspan="2" class="style1">
                Total Lubricant Amount</td>
            <td align="right" colspan="2" class="style1">
                 <asp:Label ID="lbl_lubGspareamount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                &nbsp;</td>
            <td align="left" colspan="2">
                Labour Charges</td>
            <td align="right" colspan="2">
                <asp:Label ID="lbllabourcharges" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                &nbsp;</td>
            <td align="left" colspan="2" 
                
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
                Discount@<asp:Label ID="lbldpercent" runat="server" Font-Bold="True"></asp:Label>
                %
            </td>
            <td align="right" colspan="2" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
                <asp:Label ID="lblldiscamount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                &nbsp;</td>
            <td align="left" colspan="2" style="font-weight: bold">
                Labour After Discount</td>
            <td align="right" colspan="2">
                <asp:Label ID="lblafdamount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                &nbsp;</td>
            <td align="left" colspan="2">
                Gst On Service  @<asp:Label ID="lblservtaxp" runat="server" Text="18"></asp:Label>
                &nbsp;%</td>
            <td align="right" colspan="2">
                <asp:Label ID="lblsevtaxamnt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" colspan="4">
            </td>
            <td align="left" class="style1" colspan="2" style="font-weight: bold">
                Total Labour Amount</td>
            <td align="right" class="style1" colspan="2">
                <asp:Label ID="lblservicetaxamount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                &nbsp;</td>
            <td align="left" colspan="2" style="font-weight: bold">
                Bill Amount</td>
            <td align="right" colspan="2">
                <asp:Label ID="lblbillamount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style1" colspan="8" 
                style="font-size: 13px; color: #000000; font-weight: bold;">
                Total Rupees:<asp:Label ID="lblInWords" runat="server" Font-Bold="True"></asp:Label>
                <br />
            </td>
        </tr>
        
        </table>

        </td>
        </tr>
        <tr>
            <td align="left" colspan="9" 
                
                style="font-size: medium; color: #000000; font-weight: bold; text-decoration: underline; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                class="style2">
                TERMS &amp; CONDITIONS :</td>
        </tr>
        <tr>
            <td align="left" colspan="9">
                
                1.We offer no credit and appreciate payment along with order.<br />
                2.Price rulling at the time of delivery would be applicable..</td>
        </tr>
        <tr>
            <td align="right" colspan="9" style="font-size: small; font-weight: bold;">
                FOR RASHMI MOTORS</td>
        </tr>
<tr>
<td align="left" 
        
        style="font-size: medium; " 
        colspan="9">
    
    &nbsp;</td>
</tr>
<tr>
<td align="left" colspan="4" 
        style="font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
        width="20%" >
    Customer&#39;s Signature</td>
    
    <td align="right" colspan="5" 
        style="font-size: 14px; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
        Authorised Signatory</td>
    
</tr>
        <tr>
            <td align="left" colspan="9" 
                
                style="font-size: medium; ">
                DATE:</td>
        </tr>
        <tr>
            <td align="left" colspan="9" style="font-size: medium; ">
                &nbsp;</td>
        </tr>
</table>
</center>
  </asp:Panel>
  <center>
   <table width="210mm">
                        <tr>
                            <td align="left" valign="top" >
                                    &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" >
                                    &nbsp;</td>
                        </tr>
                     <%--   <tr>
                            <td align="left" valign="top" style="font-size: medium; font-weight: bold" >
                                    For Rashmi Motors</td>
                        </tr>--%>
                        <tr>
                            <td align="left" valign="top" style="font-size: medium; font-weight: bold" >
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

