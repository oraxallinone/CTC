<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Vehicle_SaleBill.aspx.cs" Inherits="Admin_Form21" %>

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
             text-decoration: underline;
         }
         </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
  
<center>
    <table style="width:210mm;height:210mm">
<tr>
<td colspan="10" >
</td>
</tr>
<tr>
<td align="center"  style="color: #000000; font-weight: bold; font-size: x-large;" 
        colspan="10">
    &nbsp;</td>
</tr>
<tr>
<td align="center" style="color: #000000; font-weight: bold; font-size: large; text-decoration: underline;" 
        colspan="10">
    <br />
    <asp:Label ID="lbltaxtype" runat="server" Font-Bold="True" Font-Size="20px"></asp:Label>
    </td>
</tr>

<tr>
<td align="left" style="color: #000000; font-weight: bold; font-size: medium" 
        colspan="10" class="style1">
    Bill No.<asp:Label ID="lblbillno" runat="server"></asp:Label></td>
</tr>

<tr>
<td align="left" style="font-size: small" colspan="10">
    &nbsp;</td>
</tr>
<tr>
<td align="left" style="font-size: medium; color: #000000; font-weight: bold;" 
        colspan="10">
    CUSTOMER NAME &amp; ADDRESS:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </td>
</tr>
<tr>
<td align="left" colspan="4" width="50%">
    <span style="color: #000000; font-weight: bold; text-align: center;">
    <asp:Label ID="lbldate3" runat="server" Font-Underline="True" 
        Text="PERMANENT ADDRESS "></asp:Label>
    </span>
    </td>
    <td align="center" colspan="6" style="font-weight: bold; color: #000000">
       
        &nbsp;</td>
</tr>
        <tr>
            <td align="left" colspan="4" width="50%">
                <asp:Label ID="lbl_partyname0" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td align="left" colspan="3" style="font-weight: bold; color: #000000">
                Invoice No. :</td>
            <td align="left" colspan="3" style="font-weight: bold; color: #000000">
                <span style="color: #000000; font-weight: bold;">
                <asp:Label ID="lbl_inv" runat="server"></asp:Label>
                </span></td>
        </tr>
        <tr>
            <td align="left" colspan="4" width="50%">
                <asp:Label ID="lbladdress" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="3">
                Date : 
            </td>
            <td align="left" colspan="3">
                <span style="color: #000000; font-weight: bold;">
                <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
                </span></td>
        </tr>
        <tr>
            <td align="left" colspan="4" width="50%">
                <asp:Label ID="lblcity" runat="server"></asp:Label>
                ,
                <asp:Label ID="lblpinno" runat="server"></asp:Label>
            </td>
            <td align="center" colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="4" width="50%">
                <asp:Label ID="lblphoneno" runat="server" Width="170px"></asp:Label>
            </td>
            <%--<td align="left" colspan="6" 
                style="color: #000000; font-weight: bold; font-size: medium">
                INVOICE NO&nbsp;&nbsp; :<asp:Label ID="lblinvoiceno" runat="server"></asp:Label>
            </td>--%>
        </tr>
        <tr>
            <td align="left" colspan="10">
                &nbsp;</td>
        </tr>
<tr>
<td align="left" colspan="10">
    This vehicle is held under agreement of Hire Purchase/Hypothecation with&nbsp;
    <asp:Label ID="lbl_bnk" runat="server"></asp:Label>
    </td>
</tr>
<tr>
<td align="left" 
        
        style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
        colspan="10" class="style2">
    VEHICLE DETAILS</td>
</tr>
        <tr>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle:; font-size: medium; font-style: normal; width: 20%;" 
                width="5%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="18%">
                &nbsp;</td>
            <td align="left" colspan="2" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="15%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%">
                &nbsp;</td>
            <td align="left" 
                
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle:; font-size: medium; font-style: normal; width: 20%;" 
                width="5%">
                MAKE</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle:; font-size: medium; font-style: normal; width: 33%;" 
                width="18%" colspan="3">
                <asp:Label ID="lblmakersname" runat="server"></asp:Label>
            </td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                &nbsp;</td>
            <td align="left" style="color: #000000; font-size: medium;" 
                width="25%" colspan="2">
                ENGINE NO</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;">
                <asp:Label ID="lblengineno1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal; width: 20%;" 
                width="5%">
                CHASSIS NO</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="18%">
                <asp:Label ID="lblchessisno0" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="15%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                &nbsp;</td>
            <td align="left" colspan="2" style="color: #000000; font-size: medium;" 
                width="25%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="10" width="100%">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Si No">
                            <ItemTemplate>
                                <asp:Label ID="lblsino" runat="server"  Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Model">
                           <ItemTemplate>
                                <asp:Label ID="lblmodel" runat="server"  Text='<%# Eval("modelname") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                         <ItemTemplate>
                                <asp:Label ID="lbldescrioption" runat="server"  Text='<%# Eval("specification") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="170px" />
                            </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Qty">
                         <ItemTemplate>
                                <asp:Label ID="lblquantity" runat="server"  Text='<%# Eval("quantity") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                         <ItemTemplate>
                                <asp:Label ID="lblamount" runat="server"  Text='<%# Eval("amount") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                &nbsp;</td>
            <td align="right" colspan="3" style="font-weight: bold; font-size: medium; ">
                DISCOUNT</td>
            <td align="right" colspan="3" style="font-weight: bold; font-size: medium; " 
                width="15%">
                <asp:Label ID="lbldiscount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                &nbsp;</td>
            <td align="right" colspan="3" style="font-weight: bold; font-size: medium; ">
                BEFORE TAX</td>
            <td align="right" colspan="3" style="font-weight: bold; font-size: medium; " 
                width="15%">
                <asp:Label ID="lblbtax" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                &nbsp;</td>
            <td align="right" colspan="3" style="font-weight: bold; font-size: medium; ">
                (+) VAT @ 13.50 %</td>
            <td align="right" colspan="3" style="font-weight: bold; font-size: medium; " 
                width="15%">
                <asp:Label ID="lblvat" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                &nbsp;</td>
            <td align="right" colspan="3" 
                style="border-width: thin; border-color: #000000; font-weight: bold; font-size: medium; border-top-style: groove;">
                INVOICE VALUE</td>
            <td align="right" colspan="3" 
                style="border-width: thin; border-color: #000000; font-weight: bold; font-size: medium; border-top-style: groove;" 
                width="15%">
                <asp:Label ID="lblinvoicevalue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" 
                style="color: #000000; font-weight: bold; font-size: medium">
                Amount in Words</td>
            <td align="right" colspan="6" style="font-weight: bold; font-size: medium; ">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                <asp:Label ID="lblinwords" runat="server" Font-Bold="True" Font-Size="15px"></asp:Label>
            </td>
            <td align="right" colspan="6" style="font-weight: bold; font-size: medium; ">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="4" 
                
                style="border-bottom-style: groove; border-bottom-width: thin; border-bottom-color: #000000; color: #000000; font-weight: bold; font-size: medium;">
                NET PAYABLE</td>
            <td align="center" colspan="6" 
                style="border-bottom-style: groove; border-bottom-width: thin; border-bottom-color: #000000;">
                <asp:Label ID="lblinvoicevalue0" runat="server" Enabled="False" 
                    Font-Bold="True" Font-Size="20px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                This Registration Certificate is Valid on the date of issue of this</td>
            <td align="left" colspan="6" style=" font-weight:normal; font-size:18px; " valign="top">&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:Label ID="lblinvoicetype" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" 
                
                style="color: #000000; font-weight: bold; font-size: medium; text-decoration: underline">
                TERMS &amp; CONDITIONS :</td>
            <td align="right" colspan="6" style="font-weight: bold; font-size: medium; ">
                E & O.E</td>
        </tr>
        <tr>
            <td align="left" colspan="10" 
                style="font-size: medium; ">
                1. Payments by Cheques/Demand Drafts may be in favour of RASHMI MOTORS, payable 
                at CUTTACK.<br /> 2. Only the courts of Cuttack shall have jurisdiction in any 
                proceeding relating to this contract.
                <br />
                3. Interest will be charged @ 20% P.A I payment are not received by us within 
                ___ days from the date of Invoice</td>
        </tr>
        <tr>
            <td align="right" colspan="10" 
                style="font-weight: bold; font-size: medium; color: #000000;">
                For M/S RASHMI MOTORS</td>
        </tr>
        <tr>
            <td align="right" colspan="10" 
                style="font-weight: bold; font-size: medium; color: #000000; height:30px">
                </td>
        </tr>
         
        <tr>
            <td align="left" colspan="4" 
                
                style="font-weight: bold; font-size: medium; border-bottom-style: groove; border-bottom-width: thin; border-bottom-color: #000000;">
                CUSTOMERS&#39;S SIGNATURE</td>
            <td align="right" colspan="6" 
                style="font-weight: bold; font-size: medium; border-bottom-style: groove; border-bottom-width: thin; border-bottom-color: #000000;">
                AUTHORISED SIGNATORY</td>
        </tr>
        <tr>
            <td align="center" colspan="10" style="font-weight: bold; color: #000000;">
                CHECKED BY</td>
        </tr>
        <tr>
            <td align="left" colspan="10">
                TIn-21041300795 : CST NO - CUC-11-1403, 21.08.1996 SERVICE TAX NO- 
                AAEFR2761BST001</td>
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
                                <asp:Button ID="btnback" runat="server" CssClass="btn-info" 
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

