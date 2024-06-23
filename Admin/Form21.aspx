<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Form21.aspx.cs" Inherits="Admin_Form21" %>

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
             height: 22px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
  
<center>
    <table style="width:210mm;height:210mm">
<tr>
<td colspan="4" >
</td>
</tr>
<tr>
<td align="center"  style="color: #000000; font-weight: bold; font-size: x-large;" 
        colspan="4">
    FORM 21</td>
</tr>
<tr>
<td align="center" style="color: #000000; font-weight: bold; font-size: medium" 
        colspan="4">
    [ See Rule 47 (a) and 47 (d) ]
    <br />
    SALE CERTIFICATE</td>
</tr>
<tr>
<td align="left" style="color: #000000; font-weight: bold; font-size: medium" 
        class="style2" colspan="4">
    To</td>
</tr>
<tr>
<td align="left" style="color: #000000; font-weight: bold; font-size: medium" 
        colspan="4">
    The R.T.O., Cuttack 
    <span style="padding-left:300px; color: #000000; font-weight: bold;">
        <asp:Label ID="lbltcno" runat="server"></asp:Label>
    
    </span></td>
</tr>
<tr>
<td align="left" style="font-size: small" colspan="4">
    (To be issued by Manufacturer/Dealer or Officer of Defence Department in case of 
    Military sanctioned vehicle for presentation along with the application for 
    registration of motor vehicle)</td>
</tr>
<tr>
<td align="left" style="font-size: small" colspan="4">
    &nbsp;</td>
</tr>
<tr>
<td align="left" style="font-size: small" colspan="4">
    Certified that one&nbsp;
    <asp:Label ID="lbl_modelname" runat="server" Font-Bold="True"></asp:Label>
&nbsp;  has been delivered by us to&nbsp;
    <asp:Label ID="lbl_partyname" runat="server" Font-Bold="True"></asp:Label>
    &nbsp;  on dt 
    <asp:Label ID="lbl_billdate" runat="server" Font-Bold="True"></asp:Label>
    </td>
</tr>
<tr>
<td align="left" style="font-size: medium; color: #000000; font-weight: bold;" 
        colspan="4" class="style2">
    Name of the Buyer:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_partyname0" runat="server" Font-Bold="True"></asp:Label>
    </td>
</tr>
<tr>
<td align="left" colspan="2" width="50%">
    &nbsp;</td>
    <td align="center" colspan="2">
       
        &nbsp;</td>
</tr>
        <tr>
            <td align="left" colspan="2" width="50%">
                <asp:Label ID="lblpermanentads1" runat="server" Font-Bold="True" 
                    Font-Underline="True">PRESENT ADDRESS </asp:Label>
            </td>
            <td align="center" colspan="2">
                <asp:Label ID="lblpermanentads0" runat="server" Font-Bold="True" 
                    Font-Underline="True">PERMANENT ADDRESS</asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" width="50%">
                <asp:Label ID="lbladdress" runat="server"></asp:Label>
            </td>
            <td align="center" colspan="2">
                <asp:Label ID="lblpermanentads" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" width="50%">
                <asp:Label ID="lblcity" runat="server"></asp:Label>
                ,
                <asp:Label ID="lblpinno" runat="server"></asp:Label>
            </td>
            <td align="center" colspan="2">
                <asp:Label ID="lblpcity" runat="server"></asp:Label>
                ,<asp:Label ID="lblppin" runat="server"></asp:Label>
            </td>
        </tr>
        
<tr>
<td align="left" colspan="4">
    <asp:Label ID="lblphoneno" runat="server" Width="170px"></asp:Label>
    </td>
</tr>
        <tr>
            <td align="left" colspan="4">
                <asp:Label ID="Label1" runat="server" Text="Bill No:"></asp:Label>
                <asp:Label ID="lblbillno" runat="server"></asp:Label>
            </td>
        </tr>
<tr>
<td align="left" colspan="4">
    This vehicle is held under agreement of Hire Purchase/Lease/Hypothecation with
    <asp:Label ID="lblhyp" runat="server"></asp:Label>
    </td>
</tr>
<tr>
<td align="left" 
        style="color: #000000; font-weight: bold; " colspan="4">
    &nbsp;</td>
</tr>
<tr>
<td align="left" 
        style="color: #000000; font-weight: bold; " colspan="4">
    The details of the vehicle are given below
 </td>

</tr>
<tr>
<td width="10%" >
    1.</td>
    
<td width="40%" >
    The Class of Vehicle</td>
    
<td width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lblvehicletype" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td class="style1" width="10%" >
    2.</td>
    
<td class="style1" width="40%" >
    Maker&#39;s Name</td>
    
<td class="style1" width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lblmakersname" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" >
    3.</td>
    
<td width="40%" >
    Chasis No.</td>
    
<td width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lblchessisno" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" class="style1" >
    4.</td>
    
<td width="40%" >
    Engine No.</td>
    
<td width="10%" class="style1" >
    :</td>
    
<td class="style1" >
    <asp:Label ID="lblengineno" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" >
    5.</td>
    
<td width="40%" >
    Horse Power Or C.C</td>
    
<td width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lblhorsepwr" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" >
    6.</td>
    
<td width="40%" >
    Fuel Used</td>
    
<td width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lblfuelused" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" class="style1" >
    7.</td>
    
<td width="40%" class="style1" >
    No Of Cylinder</td>
    
<td width="10%" class="style1" >
    :</td>
    
<td class="style1" >
    <asp:Label ID="lblnocylinders" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" >
    8.</td>
    
<td width="40%" >
    Maf. Date</td>
    
<td width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lblmfdate" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" >
    9.</td>
    
<td width="40%" >
    Seating Capacity</td>
    
<td width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lblseatcapacity" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" class="style1" >
    10</td>
    
<td width="40%" class="style1" >
    Unladen Weight</td>
    
<td width="10%" class="style1" >
    :</td>
    
<td class="style1" >
    <asp:Label ID="lblunldnweight" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td align="left" colspan="4" >
  <span style="padding-right:20px"> 11.</span> Maximum axel weight &amp; number &amp; Description of tyres in case of transport</td>
    
</tr>
<tr>
<td width="10%" align="center" >
    a)</td>
    
<td width="40%" >
    Front Axle</td>
    
<td width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lblfrontaxel" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" align="center" >
    b)</td>
    
<td width="40%" >
    Rear Axle</td>
    
<td width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lblrareexcel" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" align="center" class="style1" >
    c)</td>
    
<td width="40%" class="style1" >
    Any Other Axle</td>
    
<td width="10%" class="style1" >
    :</td>
    
<td class="style1" >
    <asp:Label ID="lblanyotherexcel" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" align="center" >
    d)</td>
    
<td width="40%" >
    Tendem Axle</td>
    
<td width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lbltendemexcel" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" align="left" >
    12.</td>
    
<td width="40%" >
    Colour of vehicle at</td>
    
<td width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lblcolour" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" align="left" >
    13.</td>
    
<td width="40%" >
    Gross Vehicle Weight</td>
    
<td width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lblgrossvehicleweight" runat="server"></asp:Label>
    </td>
    
</tr>
<tr>
<td width="10%" align="left" >
    14.</td>
    
<td width="40%" >
    Type Of Body</td>
    
<td width="10%" >
    :</td>
    
<td >
    <asp:Label ID="lbltypeofbody" runat="server"></asp:Label>
    </td>
    
</tr>
        <tr>
            <td align="left" width="10%">
                &nbsp;</td>
            <td width="40%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
<tr>
<td align="left" colspan="4" >

    
</tr>
        <tr>
            <td align="right" colspan="4" style="font-size: medium; font-weight: bold">
                For M/S RASHMI MOTORS</td>
        </tr>
        <tr>
            <td align="right" colspan="4" style="font-size: medium; font-weight: bold; height:30px">
               </td>
        </tr>
        <tr>
            <td align="right" colspan="4" style="font-size: medium; font-weight: bold">
                Authorised Signatory</td>
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

