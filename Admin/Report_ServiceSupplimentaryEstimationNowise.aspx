<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Report_ServiceSupplimentaryEstimationNowise.aspx.cs" Inherits="Admin_ServiceEstimation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=Panel2.ClientID %>");
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
       
    </script>
  
<style type="text/css">
    .style1
    {
        height: 23px;
    }
</style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<%--    
<asp:Label ID="lbl_Header" runat="server" CssClass="Header1" Text="Job Estimation  Report">
</asp:Label>--%>
 <fieldset>
        <legend>
            <h5>
                Supplimentary
                Job Estimate Report</h5>
        </legend>
       <br /> 
        &nbsp;<center>
        <table style="width:210mm;">
        <tr>
        <td width="25%">
        </td>
        <td width="20%" align="right">
            Enter 
            Supplimentary Estimation No</td>
        <td width="3%">
            :</td>
        <td width="25%" align="left">
            <asp:TextBox ID="txt_estimationno" runat="server" Width="120px" 
                ></asp:TextBox>
        </td>
         <td width="2">
        </td>
        <td align="right">
            <asp:Button ID="btn_search" runat="server" CssClass="BigDualGreen" 
                Text="Search" onclick="btn_search_Click" Height="32px" />
        </td>
        </tr>
        
        </table>
            <asp:Panel ID="Panel2" runat="server">
          
        <table style="width:210mm;height:210mm; font-size: 12px;" >
        <tr id="tr1" runat="server">
        <td colspan="14" align="left">
            <br />
            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="RASHMI MOTORS"></asp:Label>
            <br />
            &nbsp;N.H-5, Manguli, Choudwar, Cuttack-754025
            <br />
            Odisha, Ph-0671-6606666<br /> &nbsp;<a 
                href="mailto:E-mail-rashmimotors.lcv@rashmigroups.com">E-mail-rashmimotors.lcv@rashmigroups.com</a><br /> </td>
           
        </tr>
        <tr id="tr2" runat="server">
        <td colspan="14" align="left">
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="RASHMI MOTORS"></asp:Label>
            <br />
            &nbsp;N.H-5, Phulnakhara, Cuttack
            <br />
            Odisha, Ph-9876543210<br /> &nbsp;<a 
                href="mailto:E-mail-rashmimotors.lcv@rashmigroups.com">E-mail-rashmimotors.lcv@rashmigroups.com</a><br /> </td>
           
        </tr>
        <tr id="tr3" runat="server">
        <td colspan="14" align="left">
            <br />
            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="RASHMI MOTORS"></asp:Label>
            <br />
            &nbsp;Berahampur
            <br />
            Odisha, Ph-<br /> &nbsp;<a 
                href="mailto:E-mail-rashmimotors.lcv@rashmigroups.com">E-mail-rashmimotors.lcv@rashmigroups.com</a><br /> </td>
           
        </tr>
        <tr id="tr4" runat="server">
        <td colspan="14" align="left">
            <br />
            <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="RASHMI MOTORS"></asp:Label>
            <br />
            &nbsp; AT-KATHAGADA,PO-BHUTUMUNDAI,PARADEEP,DIST-Jagatsinghpur
            <br />
            Odisha, Ph-<br /> &nbsp;<a 
                href="mailto:E-mail-rashmimotors.lcv@rashmigroups.com">E-mail-rashmimotors.lcv@rashmigroups.com</a><br /> </td>
           
        </tr>
            <tr>
                <td align="center" colspan="14" 
                    
                    style="font-weight: bold; color: #000000;" 
                    class="style1">
                   SUPPLIMENTARY ESTIMATE</td>
            </tr>
            <tr>
                <td colspan="2" 
                    style="border-top-width: thin; border-color: #000000; border-top-style: groove;" 
                    width="2%">
                    &nbsp;</td>
                <td colspan="3" 
                    style="border-top-width: thin; border-color: #000000; border-top-style: groove;" 
                    width="40%">
                    <asp:Label ID="lblname" runat="server"></asp:Label>
                </td>
                <td colspan="4" 
                    style="border-top-width: thin; border-color: #000000; border-top-style: groove;" 
                    width="5%">
                    &nbsp;</td>
                <td colspan="3" 
                    
                    style="border-top-width: thin; border-color: #000000; border-top-style: groove;" 
                    align="left">
                    ESTIMATE NO</td>
                <td colspan="2" 
                    
                    style="border-top-width: thin; border-color: #000000; border-top-style: groove;" 
                    align="left">
                    <asp:Label ID="lblestimationno" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" width="2%">
                    &nbsp;</td>
                <td colspan="3" width="40%">
                    <asp:Label ID="lbladdress" runat="server"></asp:Label>
                    <asp:Label ID="lblpinno" runat="server"></asp:Label>
                </td>
                <td colspan="4" width="5%">
                    &nbsp;</td>
                <td colspan="3" align="left">
                    DATE</td>
                <td colspan="2" align="left">
                    <asp:Label ID="lbldate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="2" width="2%">
                </td>
                <td colspan="3" width="40%">
                    <asp:Label ID="lblphoneno" runat="server"></asp:Label>
                </td>
                <td colspan="4" width="5%">
                </td>
                <td colspan="3">
                </td>
                <td class="style1" colspan="2">
                </td>
            </tr>
            <tr>
                <td width="2%" 
                    
                    style="border-top-style: dotted; border-top-width: medium; border-top-color: #000000; font-family: 'Bookman Old Style';">
                </td>
                <td width="15%" colspan="2" 
                    
                    style="border-top-style: dotted; border-top-width: medium; border-top-color: #000000; font-family: 'Bookman Old Style';">
                    REGN. NO</td>
                <td width="20%" align="left" 
                    
                    
                    style="border-top-style: dotted; border-top-width: medium; border-top-color: #000000; font-family: 'Bookman Old Style';">
                    <asp:Label ID="lblregno" runat="server"></asp:Label>
                </td>
                <td width="2%" colspan="2" 
                    
                    style="border-top-style: dotted; border-top-width: medium; border-top-color: #000000; font-family: 'Bookman Old Style';">
                </td>
                <td width="15%" 
                    
                    style="border-top-style: dotted; border-top-width: medium; border-top-color: #000000; font-family: 'Bookman Old Style';" 
                    colspan="2">
                    MODEL</td>
                <td width="20%" align="left" colspan="2" 
                    
                    
                    style="border-top-style: dotted; border-top-width: medium; border-top-color: #000000; font-family: 'Bookman Old Style';">
                    <asp:Label ID="lblmodelname" runat="server"></asp:Label>
                </td>
                <td width="2%" 
                    
                    style="border-top-style: dotted; border-top-width: medium; border-top-color: #000000; font-family: 'Bookman Old Style';">
                </td>
                <td width="15%" colspan="2" 
                    
                    style="border-top-style: dotted; border-top-width: medium; border-top-color: #000000; font-family: 'Bookman Old Style';">
                    DATE OF SALE</td>
                <td align="left" 
                    
                    
                    style="border-top-style: dotted; border-top-width: medium; border-top-color: #000000; font-family: 'Bookman Old Style';">
                    <asp:Label ID="lbldateofsale" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="font-family: 'Bookman Old Style';" 
                    width="2%">
                    &nbsp;</td>
                <td colspan="2" 
                    style="font-family: 'Bookman Old Style';" 
                    width="15%">
                    CHASIS NO</td>
                <td align="left" 
                    style="font-family: 'Bookman Old Style';" 
                    width="20%">
                    <asp:Label ID="lblchassisno" runat="server"></asp:Label>
                </td>
                <td colspan="2" 
                    style="font-family: 'Bookman Old Style';" 
                    width="2%">
                    &nbsp;</td>
                <td style="font-family: 'Bookman Old Style';" 
                    width="15%" colspan="2">
                    ENGINE NO</td>
                <td align="left" colspan="2" 
                    style="font-family: 'Bookman Old Style';" 
                    width="20%">
                    <asp:Label ID="lblengineno" runat="server"></asp:Label>
                </td>
                <td style="font-family: 'Bookman Old Style';" 
                    width="2%">
                    &nbsp;</td>
                <td colspan="2" 
                    style="font-family: 'Bookman Old Style';" 
                    width="15%">
                    KILOMETER</td>
                <td align="left" 
                    style="font-family: 'Bookman Old Style';">
                    <asp:Label ID="lblkilomtr" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="14" 
                    
                    
                    style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style'; font-size: large; color: #000000; font-weight: bold;">
                    Spare Details</td>
            </tr>
            <tr>
                <td colspan="14" 
                    
                    style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Cambria';">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        Width="100%" EmptyDataText="No SpareParts Taken" Font-Size="12px">
                        <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                            <asp:TemplateField HeaderText="SlNo">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Width="40px" />
                                <ItemStyle HorizontalAlign="Left" Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Part No">
                                <ItemTemplate>
                                    <asp:Label ID="lblbillno" runat="server" Text='<%# Eval("Itm_Partno") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Part Description">
                                <ItemTemplate >
                                    <asp:Label ID="lblvechiletype" runat="server" Text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="170px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblmodelname0" runat="server" Text='<%# Eval("Se_Quantity") %>' 
                                       ></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate">
                                <ItemTemplate>
                                    <asp:Label ID="lblchessisno" runat="server" Text='<%# Eval("Se_Rate") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblfrombranch" runat="server" Text='<%# Eval("Se_Amount") %>'> </asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Discount">
                                <ItemTemplate>
                                    <asp:Label ID="lbltobranch" runat="server" Text='<%# Eval("Se_Discount") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GST">
                                <ItemTemplate>
                                    <asp:Label ID="lblengno" runat="server" Text='<%# Eval("Se_Vat") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gst Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblcolor" runat="server" Text='<%# Eval("Se_TaxAmont") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label ID="lblkey" runat="server" Text='<%# Eval("Se_Total") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        
                        </Columns>
                        <PagerStyle CssClass="pgr" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="border-top-style: groove; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style'; font-size: large; color: #000000; font-weight: bold;" 
                    align="center" colspan="14">
                    Service&nbsp; Details</td>
            </tr>
            <tr>
                <td colspan="14" 
                    
                    style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style';">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                        Width="100%" EmptyDataText="No Service Taken" Font-Names="Cambria" 
                        Font-Size="12px">
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
                                    <asp:Label ID="Labels2" runat="server" Text='<%# Eval("Mh_ServiceCode") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Width="120px" />
                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="Labels3" runat="server" 
                                        Text='<%# Eval("Mh_ServiceHead") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="Labels4" runat="server" Text='<%# Eval("Se_Quantity") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate">
                                <ItemTemplate>
                                    <asp:Label ID="Labels5" runat="server" Text='<%# Eval("Se_Rate") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="Labels6" runat="server" Text='<%# Eval("Se_Amount") %>'></asp:Label>
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
                <td align="right" colspan="14" 
                    
                    style="font-family: 'Bookman Old Style';" 
                    class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" colspan="14" 
                    
                    style="border-width: medium; border-color: #000000; font-family: 'Bookman Old Style'; border-top-style: dotted;">
                    Service Gross Amount<asp:Label ID="lblgross" runat="server" 
                        Height="23px" Width="100px"></asp:Label>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style2" colspan="14" 
                    style="font-family: 'Bookman Old Style';">
                    Discount<asp:Label ID="lbldiscountpercent" runat="server" Font-Bold="True"></asp:Label>%
                    <asp:Label ID="lbldiscount" runat="server" Height="23px" Width="100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2" colspan="14" 
                    style="font-family: 'Bookman Old Style';">
                    Net Amount
                    <asp:Label ID="lblnetamount" runat="server" Height="23px" Width="100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="14" style="font-family: 'Bookman Old Style';">
                    Total Spare Amount&nbsp;&nbsp;
                    <asp:Label ID="lblspareamount" runat="server" Height="23px" Width="100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="14" style="font-family: 'Bookman Old Style';">
                    Total Labour Charge<asp:Label ID="lbllabourcharge" runat="server" Width="100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="14" style="font-family: 'Bookman Old Style';">
                    Discount<asp:Label ID="lbllbrdiscount" runat="server" Font-Bold="True"></asp:Label>
                    %
                    <asp:Label ID="lbldiscountamount" runat="server" Height="23px" Width="100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="14" style="font-family: 'Bookman Old Style';">
                    Charges After Discount<asp:Label ID="lbllabourchargeafterdiscount" runat="server" 
                        Width="100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="14" style="font-family: 'Bookman Old Style';">
                   Tax<asp:Label ID="lbldiscount1" runat="server" Font-Bold="True">18 %</asp:Label>
                    &nbsp;<asp:Label ID="lblstax" runat="server" Width="100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="14" style="font-family: 'Bookman Old Style';">
                  Gst
                    <asp:Label ID="lblvat" runat="server" Height="23px" Width="100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="7">
                    &nbsp;</td>
                <td align="right" colspan="7" 
                    style="border-width: thin; border-color: #000000; border-top-style: groove; font-family: 'Bookman Old Style';" 
                    width="30%">
                    Total<asp:Label ID="lbltotal" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="7" style="font-weight: bold; color: #000000">
                    FOR RASHMI MOTORS</td>
                <td align="right" colspan="7" width="30%" 
                    style="font-family: 'Bookman Old Style'">
                    OTHER CHARGES<asp:Label ID="lblothercharg" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="7" style="color: #000000; font-weight: bold">
                    Authorised Sigmatory</td>
                <td align="right" colspan="7" 
                    style="font-weight: bold; font-family: 'Bookman Old Style';" width="30%">
                    NET AMOUNT<asp:Label ID="lbltnetamount" runat="server" Font-Bold="True" 
                        Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" class="style1" colspan="14" 
                    style="font-weight: bold; text-decoration: underline">
                    Terms and Conditions:</td>
            </tr>
            <tr>
                <td align="left" class="style1" colspan="14">
                    1. This is a rough estimate of labour charges, parts &amp; consumables. During the 
                    course of dismantalling/repair, additional parts/labour/consumable will be 
                    charged extra.
                    <br />
                    2. Delivery of vehicle after repairs against full payment by Cash/DD only.
                    <br />
                    3. All labour rates / prices of spares are subjected to change without prior 
                    notice and actual rates / prices prevailing at the time of delivery after repair 
                    will be applicable.<br /> &nbsp;4. All consumables such as petrol,diseal,kerosene 
                    etc. will be charged extra.
                    <br />
                    5. The company will charge its own labour/spare charges even if less amount is 
                    passed by the insurance company
                    <br />
                    6. If delivery of the vehicle is not taken within 14 days after repair, parking 
                    charges will be charged. If work order is not given and veh
                    <br />
                    7. In case of dispute arising between the Company &amp; Customer the court of 
                    Cuttack will have the jurisdiction.</td>
            </tr>
            <tr>
                <td align="left" colspan="14">
                    I accept the above terms &amp; conditions</td>
            </tr>
            <tr>
                <td align="left" colspan="14">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" colspan="14" style="font-weight: bold; color: #000000">
                    Signature of the customer with date :</td>
            </tr>
            <tr>
                <td align="left" colspan="14" style="font-weight: bold; color: #000000">
                    WORK ORDER :</td>
            </tr>
            <tr>
                <td align="left" colspan="14">
                    I<asp:Label ID="Label4" runat="server" Font-Bold="True" Text="I/We"></asp:Label>
                    &nbsp;agree to get the vehicle repaired through
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="RASHMI MOTORS."></asp:Label>
                    <br />
                    &nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" Text="I/We"></asp:Label>
                    &nbsp;authorise you to start the work and change neccesary parts/undertake repairs.If 
                    any additional work other than mentioned in this estimate is required,
                    <br />
                    you may undertake the same without anymore reference to us. I/We accept the 
                    terms and conditions mentioned and understand that if the bills remain unpaid 
                    over 15 days interest @2% per month will be charged.</td>
            </tr>
            <tr>
                <td 
                    width="2%">
                    &nbsp;</td>
                <td colspan="2" 
                    width="15%">
                    &nbsp;</td>
                <td align="right" 
                    width="20%">
                    &nbsp;</td>
                <td colspan="2" 
                    width="2%">
                    &nbsp;</td>
                <td 
                    width="15%" colspan="2">
                    &nbsp;</td>
                <td align="right" colspan="2" 
                    width="20%">
                    &nbsp;</td>
                <td 
                    width="2%">
                    &nbsp;</td>
                <td colspan="2" 
                    width="15%">
                    &nbsp;</td>
                <td align="right">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="14" 
                    
                    style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style';" 
                    align="left">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Italic="True" 
                        Text="Signature of the customer"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="14" 
                    
                    style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style';" 
                    align="left">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Date:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style';" 
                    width="2%">
                    &nbsp;</td>
                <td colspan="2" 
                    style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style';" 
                    width="15%">
                    &nbsp;</td>
                <td align="right" 
                    style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style';" 
                    width="20%">
                    &nbsp;</td>
                <td colspan="2" 
                    style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style';" 
                    width="2%">
                    &nbsp;</td>
                <td style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style';" 
                    width="15%" colspan="2">
                    &nbsp;</td>
                <td align="right" colspan="2" 
                    style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style';" 
                    width="20%">
                    &nbsp;</td>
                <td style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style';" 
                    width="2%">
                    &nbsp;</td>
                <td colspan="2" 
                    style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style';" 
                    width="15%">
                    &nbsp;</td>
                <td align="right" 
                    style="border-top-style: dotted; border-top-width: thin; border-top-color: #000000; font-family: 'Bookman Old Style';">
                    &nbsp;</td>
            </tr>
        </table>
          </asp:Panel>
         </center>
      </fieldset>
         <table width="100%">
                        <tr>
                            <td align="center" valign="top">
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
</asp:Content>

