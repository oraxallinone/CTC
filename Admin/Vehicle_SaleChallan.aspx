<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Vehicle_SaleChallan.aspx.cs" Inherits="Admin_Form21" %>

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
         .style3
         {
             height: 25px;
         }
     .style4
    {
        height: 22px;
    }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
  
<center>
    <table style="width:210mm;height:210mm">
<tr>
<td colspan="12" >
</td>
</tr>
<tr>
<td align="center"  style="color: #000000; font-weight: bold; font-size: x-large;" 
        colspan="12">
    &nbsp;</td>
</tr>
<tr>
<td align="center" style="color: #000000; font-weight: bold; font-size: large; text-decoration: underline;" 
        colspan="12">
    <br />
    DELIVERY CHALLAN</td>
</tr>

<tr>
<td align="left" style="color: #000000; font-weight: bold; font-size: medium" 
        colspan="12" class="style1">
    Bill No.<asp:Label ID="lblbillno" runat="server"></asp:Label></td>
</tr>

<tr>
<td align="left" style="font-size: small" colspan="12">
    &nbsp;</td>
</tr>
<tr>
<td align="left" style="font-size: medium; color: #000000; font-weight: bold;" 
        colspan="12" class="style4">
    Name of the Buyer:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_partyname0" runat="server" Font-Bold="True"></asp:Label>
    </td>
</tr>
<tr>
<td align="left" colspan="6" width="50%">
    <asp:Label ID="lblpermanentads1" runat="server" Font-Bold="True" 
        Font-Underline="True" Width="200px">PRESENTT ADDRESS</asp:Label>
    </td>
    <td align="center" colspan="6">
       
        &nbsp;</td>
</tr>
        <tr>
            <td align="left" colspan="6" width="50%">
                <asp:Label ID="lbladdress" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="3">
                Invoice No.</td>
            <td align="left" colspan="3">
                <span style="color: #000000; font-weight: bold;">
                <asp:Label ID="lbl_inv" runat="server"></asp:Label>
                </span></td>
        </tr>
        <tr>
            <td align="left" colspan="6" width="50%">
                <asp:Label ID="lblcity" runat="server"></asp:Label>
                ,
                <asp:Label ID="lblpinno" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="3">
                Date</td>
            <td align="left" colspan="3">
                <span style="color: #000000; font-weight: bold;">
                <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
                </span>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="12">
                &nbsp;</td>
        </tr>
<tr>
<td align="left" colspan="12">
    <asp:Label ID="lblphoneno" runat="server" Width="170px"></asp:Label>
    </td>
</tr>
<tr>
<td align="left" colspan="12">
    This vehicle is held under agreement of Hire Purchase/Lease/Hypothecation with
    <asp:Label ID="lbl_bnk" runat="server"></asp:Label>
    </td>
</tr>
<tr>
<td align="left" 
        
        style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
        colspan="12">
    VEHICLE DETAILS</td>
</tr>
        <tr>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                A.</td>
            <td align="left" style="font-size: medium;" width="15%">
                MAKE</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%" colspan="2">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="18%">
                <asp:Label ID="lblmakersname" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="15%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                A.</td>
            <td align="left" style="color: #000000; font-size: medium;" 
                width="25%" colspan="2">
                TOOL KIT</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;">
                <asp:Label ID="lbltoolkit" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                B.</td>
            <td align="left" style="font-size: medium;" width="15%">
                MODEL</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%" colspan="2">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="18%">
                <asp:Label ID="lblmodel" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="15%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                B.</td>
            <td align="left" style="color: #000000; font-size: medium;" 
                width="25%" colspan="2">
                STEPHNEY</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;">
                <asp:Label ID="lblstephini" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                C.</td>
            <td align="left" style="font-size: medium;" width="15%">
                CHASSIS NO</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%" colspan="2">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="18%">
                <asp:Label ID="lblchessisno" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="15%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                C.</td>
            <td align="left" style="color: #000000; font-size: medium;" 
                width="25%" colspan="2">
                FORM 20/21/22</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;">
                <asp:Label ID="lblform21" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                D.</td>
            <td align="left" style="font-size: medium;" width="15%">
                ENGINE NO</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%" colspan="2">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="18%">
                <asp:Label ID="lblengineno" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="15%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                D.</td>
            <td align="left" style="color: #000000; font-size: medium;" 
                width="25%" colspan="2">
                OWNER&#39;S MANUAL</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;">
                <asp:Label ID="lblownersmannual" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                E.</td>
            <td align="left" style="font-size: medium;" width="15%">
                BATTERY MAKE &amp; NO</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%" colspan="2">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="18%">
                <asp:Label ID="lblbmno" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="15%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                E.</td>
            <td align="left" style="color: #000000; font-size: medium;" 
                width="15%" colspan="2">
                BATTERY WARRANTY CARD:</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;">
                <asp:Label ID="lblbwc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                F.</td>
            <td align="left" style="font-size: medium;" width="15%">
                TYRE MAKE &amp; TYPE</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%" colspan="2">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="18%">
                <asp:Label ID="lblmtype" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="15%">
                &nbsp;</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="5%">
                F.</td>
            <td align="left" style="color: #000000; font-size: medium;" 
                width="15%" colspan="2">
                F.S.C BOOK</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; vehicle: ; font-size: medium; font-style: normal;">
                <asp:Label ID="lblfscbook" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="12" 
                
                
                
                style="border-width: thin; vehicle:; font-size: medium; font-style: normal; border-top-style: groove; border-top-color: #000000;">
                I/We confirm having received the above vehicle in perfect condition with tools 
                and accessories and supplied by the manufacturers to my/our entire satisfication 
                and I/We am/are taking delivery of the same on my/our own risk and 
                responsibility.I/We also confirm that I/We have not further claim on you 
                what-so-ever.</td>
        </tr>
        <tr>
            <td align="left" colspan="6">
                &nbsp;</td>
            <td align="right" colspan="6" style="font-weight: bold; font-size: medium; ">
                For M/S RASHMI MOTORS</td>
        </tr>
         <tr>
            <td align="left" colspan="6">
                &nbsp;</td>
            <td align="right" colspan="6" style="font-weight: bold; font-size: medium; ">
             </td>
        </tr>
        <tr>
            <td align="left" colspan="6" 
                
                
                style="font-weight: bold; font-size: medium; border-bottom-style: groove; border-bottom-width: thin; border-bottom-color: #000000;">
                CUSTOMERS&#39;S SIGNATURE</td>
            <td align="right" colspan="6" 
                
                
                style="font-weight: bold; font-size: medium; border-bottom-style: groove; border-bottom-width: thin; border-bottom-color: #000000;">
                AUTHORISED SIGNATORY</td>
        </tr>





<tr>
<td align="center" colspan="12" 
        style="font-weight: bold; text-decoration: underline; font-size: medium" >

    
    GATE PASS </tr>
        <tr>
            <td align="left" class="style1" colspan="12" 
                style="color: #000000; font-weight: bold; font-size: medium">
                Bill No.<asp:Label ID="lblbillno0" runat="server"></asp:Label>
                <span style="padding-left: 450px; color: #000000; font-weight: bold;">DATE:<asp:Label 
                    ID="lbldate0" runat="server" Text=""></asp:Label>
                </span>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="12">
                Vehicle Delivered in satisfactory condition to the Owner.</td>
        </tr>
        <tr>
            <td align="left" class="style1" colspan="12">
                <asp:Label ID="lbl_partyname1" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" width="10%">
                MODEL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="left" colspan="3">
                <asp:Label ID="lblmodel2" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="3">
                CHASSIS NO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="left" colspan="3">
                <asp:Label ID="lblchessisno2" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="3">
                ENGINE NO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="left" colspan="3">
                <asp:Label ID="lblengineno0" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="3">
                BATTERY MAKE &amp; NO&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="left" colspan="3">
                <asp:Label ID="lblbmno0" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="3">
                TYRE MAKE &amp; TYPE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="left" colspan="3">
                <asp:Label ID="lblmtype0" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" class="style3" colspan="3">
            </td>
            <td align="left" class="style3" colspan="3">
            </td>
            <td align="right" class="style3" colspan="6" 
                style="font-weight: bold; font-size: medium; color: #000000;">
                For M/S RASHMI MOTORS</td>
        </tr>
         <tr>
            <td align="left" class="style3" colspan="3">
            </td>
            <td align="left" class="style3" colspan="3">
            </td>
            <td align="right" class="style3" colspan="6" 
                style="font-weight: bold; font-size: medium; color: #000000; height:30px;">
               </td>
        </tr>
        <tr>
            <td align="left" colspan="6" 
                style="font-weight: bold; font-size: medium; border-bottom-style: groove; border-bottom-width: thin; border-bottom-color: #000000; color: #000000;">
                CUSTOMERS&#39;S SIGNATURE</td>
            <td align="right" colspan="6" 
                
                style="font-weight: bold; font-size: medium; border-bottom-style: groove; border-bottom-width: thin; border-bottom-color: #000000; color: #000000;">
                AUTHORISED SIGNATORY</td>
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

