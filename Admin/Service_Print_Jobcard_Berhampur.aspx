<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Service_Print_Jobcard_Berhampur.aspx.cs" Inherits="Admin_Service_Print_Jobcard_Berhampur" %>

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
    <table style="width:210mm;height:210mm; text-transform:uppercase;">
<tr>
<td colspan="13" >
</td>
</tr>
<tr>
<td align="center"  style="color: #000000; font-weight: bold; font-size: x-large;" 
        colspan="13">
    RASHMI MOTORS</td>
</tr>
<tr>
<td align="center" 
        colspan="13">
    Authorised Main Dealer Of Ashok Leyland Ltd.</td>
</tr>
        <tr>
            <td align="center" colspan="13">
                Berhampur</td>
        </tr>
        <tr>
            <td align="center" colspan="13">
                E-mail : , Mob-</td>
        </tr>
        <tr>
            <td align="center" class="style1" colspan="13" 
                style="color: #000000; font-weight: bold; font-size: medium">
                JOB CARD</td>
        </tr>
        <tr>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="10%">
                DATE</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="20%">
                <asp:Label ID="lbldate" runat="server"></asp:Label>
            </td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="10%" colspan="2">
                TIME</td>
            <td align="left" colspan="2" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="20%">
                <asp:Label ID="lbltime" runat="server"></asp:Label>
            </td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="10%" colspan="2">
                JOB CARD NO</td>
            <td align="left" colspan="2" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="2%">
                :</td>
            <td align="left" 
                style="color: #000000; font-weight: bold; font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                <asp:Label ID="lbljobcardno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" width="20%">
                CUSTOMER NAME</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" colspan="6" width="30%">
                <asp:Label ID="lblcname" runat="server"></asp:Label>
            </td>
            <td align="left" width="15%" colspan="2">
            </td>
            <td align="left" colspan="2" width="2%">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="left" width="20%">
                ADDRESS</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" colspan="6" width="30%">
                <asp:Label ID="lbladdress" runat="server"></asp:Label>
            </td>
            <td align="left" width="15%" colspan="2">
                &nbsp;</td>
            <td align="left" colspan="2" width="2%">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" width="20%">
                TELEPHONE</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" colspan="6" width="30%">
                <asp:Label ID="lblmno" runat="server"></asp:Label>
            </td>
            <td align="left" width="15%" colspan="2">
                &nbsp;</td>
            <td align="left" colspan="2" width="2%">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" width="20%">
                MODEL</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" colspan="6" width="30%">
                <asp:Label ID="lblmodel" runat="server"></asp:Label>
            </td>
            <td align="left" width="15%" colspan="2">
                &nbsp;</td>
            <td align="left" colspan="2" width="2%">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" width="20%">
                CHASIS NO.</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" colspan="6" width="30%">
                <asp:Label ID="lblchessisno" runat="server"></asp:Label>
            </td>
            <td align="left" width="15%" colspan="2">
                DATE OF SALE</td>
            <td align="left" colspan="2" width="2%">
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
            <td align="left" colspan="6" width="30%">
                <asp:Label ID="lblkilomtr" runat="server"></asp:Label>
            </td>
            <td align="left" width="15%" colspan="2">
                REGN. NO.</td>
            <td align="left" colspan="2" width="2%">
                :</td>
            <td align="left">
                <asp:Label ID="lblregno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" width="20%">
                SERVICE</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" colspan="6" width="30%">
                <asp:Label ID="lblservice" runat="server"></asp:Label>
            </td>
            <td align="left" width="15%" colspan="2">
                ENGINE NO.</td>
            <td align="left" colspan="2" width="2%">
                :</td>
            <td align="left">
                <asp:Label ID="lblengno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" width="20%">
                SUPERVISOR NAME</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" colspan="6" width="30%">
                <asp:Label ID="lblsupervisorname" runat="server"></asp:Label>
            </td>
            <td align="left" width="15%" colspan="2">
                KEY NO.</td>
            <td align="left" colspan="2" width="2%">
                :</td>
            <td align="left">
                <asp:Label ID="lblkeyno" runat="server"></asp:Label>
            </td>
        </tr>
           <tr>
            <td align="left" width="20%">
                Repair Type</td>
            <td align="left" width="2%">
               :</td>
            <td align="left" colspan="6" width="30%">
                <asp:Label ID="lbl_repair" runat="server"></asp:Label></td>
            <td align="left" colspan="2" width="15%">
                hr. Meter</td>
            <td align="left" colspan="2" width="2%">
                &nbsp;</td>
            <td align="left">
                <asp:Label ID="lbl_hr" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td align="left" width="20%">
                Customer Complain</td>
            <td align="left" width="2%">
               :</td>
            <td align="left" colspan="6" width="30%">
            <pre>    <asp:Label ID="lbl_cuscomplain" runat="server"></asp:Label></pre></td>
            <td align="left" colspan="2" width="15%">
                &nbsp;</td>
            <td align="left" colspan="2" width="2%">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" width="20%">
                &nbsp;</td>
            <td align="left" width="2%">
                &nbsp;</td>
            <td align="left" colspan="6" width="30%">
                &nbsp;</td>
            <td align="left" colspan="2" width="15%">
                &nbsp;</td>
            <td align="left" colspan="2" width="2%">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
<tr>
<td align="left" style="font-size: medium; color: #000000; font-weight: bold;" 
        colspan="13">
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        Font-Size="12px" ShowFooter="True" Width="100%" 
        Font-Names="Cambria">
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
            <%--<asp:TemplateField HeaderText="Hsn Code">
                <ItemTemplate>
                    <asp:Label ID="lblhsn" runat="server" 
                        Text='00440181'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Width="120px" />
                <ItemStyle HorizontalAlign="Left" Width="120px" />
            </asp:TemplateField>--%>
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
        </Columns>
        <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
    </asp:GridView>
    </td>
</tr>
        <tr>
            <td align="right" colspan="13" 
                
                
                style="border: thin double #000000; font-size: medium; color: #000000; font-weight: bold;">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="GRAND TOTAL"></asp:Label>
                <asp:Label ID="lblgtotal1" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="13" 
                style="font-size: medium; color: #000000; font-weight: bold;" 
                class="style1">
                Total Rupees:<asp:Label ID="lblInWords" runat="server" Font-Bold="True"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" width="30%" class="style1">
                ESTIMATED DELIVERY DATE</td>
            <td align="left" colspan="3" 
                style="font-size: medium; color: #000000; font-weight: bold; " 
                class="style1">
                <asp:Label ID="lbldeliverydate" runat="server"></asp:Label>
            </td>
            <td align="center" colspan="2">
                &nbsp;</td>
            <td align="left" colspan="3" 
                style="font-size: medium; color: #000000; font-weight: bold; ">
                <asp:Label ID="lbldtime" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2" 
                
                style="font-size: medium; color: #000000; font-weight: bold; text-decoration: underline;" 
                class="style1">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="13" 
                
                
                style="font-size: medium; color: #000000; font-weight: bold; text-decoration: underline; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                DEMANDED REPAIR INSTRUCTIONS</td>
        </tr>
<tr>
<td align="left" 
        
        style="border-style: dotted; border-width: thin; border-color: #000000; font-size: medium; " 
        colspan="13">
    
    <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="UNDERTAKING :"></asp:Label>
    <br />
    
    I Hereby authorise RASHMI MOTORS to carry-out the above mentioned works on my vehicle as
per the shedule rates and agree to pay all the charges for labour, material and taxs in
case of warranty is not entertained. </td>
</tr>
<tr>
<td align="left" colspan="13" style="font-size: medium" >
    &nbsp;</td>
    
</tr>
        <tr>
            <td align="left" colspan="4" 
                
                style="font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="20%">
                Date :</td>
            <td align="left" colspan="5" 
                
                style="font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;" 
                width="30%">
                Customer&#39;s Signature</td>
            <td align="left" colspan="4" 
                style="font-size: medium; border-bottom-style: dotted; border-bottom-width: thin; border-bottom-color: #000000;">
                Supervisor&#39;s Signature</td>
        </tr>
        <tr>
            <td align="left" colspan="13" style="font-size: medium">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="13" style="font-size: medium; font-weight: bold;">
                For Rashmi Motors</td>
        </tr>
        <tr>
            <td align="left" colspan="13" style="font-size: medium">
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

