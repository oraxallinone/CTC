<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Vehicle_PrintQuotation.aspx.cs" Inherits="Admin_Form21" %>

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
         </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
  
<center>
    <table style="width:210mm;height:210mm">
<tr>
<td colspan="3" >
</td>
</tr>
<tr>
<td align="center"  style="color: #000000; font-weight: bold; font-size: x-large;" 
        colspan="3">
    QUOTATION CUM PROFORMA</td>
</tr>
<tr>
<td align="left" style="color: #000000; font-weight: bold; font-size: medium" 
        colspan="3">
        <div style="float:left;">
        Ref No&nbsp; :<asp:Label ID="lblqprint" runat="server" Font-Bold="True"></asp:Label>
    <br /> Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:Label ID="lblchalndate" runat="server" Font-Bold="True"></asp:Label>
        </div>
        <div style="float:right">
            Quotation No. &nbsp; :<asp:Label ID="lbl_quotation" runat="server" Font-Bold="True"></asp:Label>
        </div>
    
    </td>
</tr>
<tr>
<td align="left" style="color: #000000; font-weight: bold; font-size: medium" 
        colspan="3">
    To</td>
</tr>
<tr>
<td align="left" style="color: #000000; font-weight: bold; font-size: medium" 
        colspan="3">
    <asp:Label ID="lblname" runat="server" Font-Bold="True" Font-Size="20px"></asp:Label>
&nbsp;</td>
</tr>
        <tr>
            <td align="left" colspan="3" 
                style="color: #000000; font-weight: bold; font-size: medium">
                <asp:Label ID="lbladress" runat="server" Font-Bold="True" Font-Size="20px"></asp:Label>
                <asp:Label ID="lblphnno" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
<tr>
<td align="left" style="font-size: medium" colspan="3">
    Dear Sir,<br /> &nbsp;We are pleased to inform you that we will be in a position to 
    supply our ASHOK LEYLAND 3118IL-6100MM<br /> &nbsp;(240&quot;)WB CHASSIS as per your 
    requirements
    <br />
    <br />
    As required, we are furnishing below specification and price offer for Ashok 
    Leyland ASHOK LEYLAND 3118IL-6100MM (240&quot;)WB CHASSIS, Ex Showroom, Cuttack.<br /> </td>
</tr>
<tr>
<td align="left" style="border: thin groove #000000; font-size: small" colspan="3">
    <asp:Label ID="lbldescription" runat="server" Font-Size="15px"></asp:Label>
    </td>
</tr>
<tr>
<td align="left" style="font-size: medium; color: #000000; font-weight: bold;" 
        colspan="3">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        Font-Size="12px" ShowFooter="True" Width="100%">
        <AlternatingRowStyle CssClass="alt" />
        <Columns>
            <asp:TemplateField HeaderText="SlNo">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="40px" />
                <ItemStyle HorizontalAlign="Left" Width="40px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Vehicle Type">
                <ItemTemplate>
                    <asp:Label ID="lblvechiletype" runat="server" 
                        Text='<%# Eval("Mv_VehicleType") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Model name">
                <ItemTemplate>
                    <asp:Label ID="lblmodelname" runat="server" Text='<%# Eval("Mv_ModelName") %>' 
                        Width="200px"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rate">
                <ItemTemplate>
                    <asp:Label ID="lblrate" runat="server" Text='<%# Eval("Vql_Rate") %>' Font-Bold="True"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                <ItemStyle HorizontalAlign="Left" Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="lblquantity" runat="server" Text='<%# Eval("Vql_Quantity") %>' Font-Bold="True" > </asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                <ItemStyle HorizontalAlign="Left" Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount">
                <ItemTemplate>
                    <asp:Label ID="lblamount" runat="server" Text='<%# Eval("Vql_Amount") %>' Font-Bold="True"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                <ItemStyle HorizontalAlign="Left" Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount(%)">
                <ItemTemplate>
                    <asp:Label ID="lbldiscount" runat="server" Text='<%# Eval("Vql_discount") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DiscountAmount">
                <ItemTemplate>
                    <asp:Label ID="lbldiscountamount" runat="server" 
                        Text='<%# Eval("Vql_discountAmount") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Net Amount">
                <FooterTemplate>
                    <asp:Label ID="lbltotalnetamount" runat="server" ForeColor="Black"></asp:Label>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblnetamount" runat="server" Text='<%# Eval("Vql_netamount") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px" />
            </asp:TemplateField>
        </Columns>
        <PagerStyle CssClass="pgr" />
    </asp:GridView>
    </td>
</tr>
        <tr>
            <td align="right" colspan="3" 
                style="border: thin double #000000; font-size: medium; color: #000000; font-weight: bold;">
                &nbsp;
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="TOTAL :"></asp:Label>
                <asp:Label ID="lbltotalamount1" runat="server" Font-Bold="True"></asp:Label>
                <br />
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="Discount Amount:"></asp:Label>
                <asp:Label ID="lblsiscount1" runat="server" Font-Bold="True"></asp:Label>
                <br />
                
            </td>
        </tr>
        <tr>
            <td align="right" colspan="3" 
                style="border: thin double #000000; font-size: medium; color: #000000; font-weight: bold;">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="GRAND TOTAL"></asp:Label>
                <asp:Label ID="lblgtotal1" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" 
                style="font-size: medium; color: #000000; font-weight: bold;">
                Total Rupees:<asp:Label ID="lblInWords" runat="server" Font-Bold="True"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" 
                
                style="font-size: medium; color: #000000; font-weight: bold; text-decoration: underline;" 
                class="style1">
                Terms &amp; Conditons</td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="font-size: medium" class="style1">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="15px" 
                    Text="Price"></asp:Label>
                &nbsp;:Price quoted above is as per your requirements. Prices, taxes, duties etc are 
                subject to revision </td>
         
        </tr>
        <tr>
            <td align="left" style="font-size: medium" colspan="2" width="6%">
                &nbsp;</td>
            <td align="left" style="font-size: medium">
                and those ruling on the date of delivery will be applicable and payable.</td>
        </tr>
<tr>
<td align="left" 
        
        style="font-size: medium; " 
        colspan="3">
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="15px" 
        Text="Payment"></asp:Label>
    &nbsp;:100% payment to be made before delivery of vehicles. All payments are to be 
    made through DD&nbsp; </td>
</tr>
        <tr>
            <td align="left" width="9%">
                &nbsp;</td>
            <td align="left" colspan="2" style="font-size: medium; ">
                drawn in favour of Rashmi Motors, Payable at Cuttack</td>
        </tr>
        <tr>
            <td align="left" width="9%">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="15px" 
                    Text="Delivery"></asp:Label>
            </td>
            <td align="left" colspan="2" style="font-size: medium; ">
                We shall be in a position to supply the vehicle based on your schedule subject 
                to force major clause.
            </td>
        </tr>
        <tr>
            <td align="left" width="9%">
                &nbsp;</td>
            <td align="left" colspan="2" style="font-size: medium; ">
                The expected time of delivery of vehicles will be within 4 weeks from the date 
                of receipt of your order.</td>
        </tr>
<tr>
<td align="left" colspan="3" style="font-size: medium" >
    &nbsp;</td>
    
</tr>
        <tr>
            <td align="left" colspan="3" style="font-size: medium">
                Thanking you assuring you of our best services at all times</td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="font-size: medium">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="font-size: medium; font-weight: bold;">
                For Rashmi Motors</td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="font-size: medium">
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
                                <asp:Button ID="btnback" runat="server" CssClass="ThinRed" 
                                    onclick="btnback_Click" Text="Back" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                &nbsp;</td>
                        </tr>
                      
                    </table>
</center>
</asp:Content>

