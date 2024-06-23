<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Spare_SalesReturnPrint.aspx.cs" Inherits="Admin_Form21" %>

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
    <table style="width:210mm;">

<tr>
<td align="center" 
        colspan="6" height="80px" dir="ltr">
        <h2>RASHMI MOTORS</h2>
    <asp:Label ID="lblbranchaddress" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblemail" runat="server"></asp:Label>
    ,<asp:Label ID="lblphno" runat="server"></asp:Label>
        <br />
        GSTIN No-<asp:Label ID="lbltinno" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="20px" 
            Text="SALES RETURN"></asp:Label>
    </td>
</tr>
        <tr>
            <td align="left" 
                
                style="border-top-style: dotted; border-width: thin; border-color: #000000" 
                height="12px">
                PARTY NAME</td>
            <td align="left" 
                width="2%" 
                
                style="border-top-style: dotted; border-width: thin; border-color: #000000" 
                class="style1">
                :</td>
            <td align="left" 
                width="20%" 
                
                style="border-top-style: dotted; border-width: thin; border-color: #000000" 
                class="style1">
                <asp:Label ID="lblpartyname" runat="server"></asp:Label>
            </td>
            <td align="left" 
                style="border-top-style: dotted; border-width: thin; border-color: #000000" 
                width="20%" class="style1">
                RETURN SI.NO</td>
            <td align="left" class="style1" 
                
                style="border-top-style: dotted; border-width: thin; border-color: #000000" 
                width="2%">
                :</td>
            <td align="left" 
                style="border-top-style: dotted; border-width: thin; border-color: #000000" 
                width="10%" class="style1">
                <asp:Label ID="lblrsino" runat="server" Width="250px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" width="10%" dir="ltr" height="12px">
                ADDRESS</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" width="20%">
                <asp:Label ID="lbladdress" runat="server"></asp:Label>
            </td>
            <td align="left">
                RETURN . DATE</td>
            <td align="left">
                :</td>
            <td align="left" width="10%">
                <asp:Label ID="lblreturndate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" width="10%" class="style1">
                PHONE NO</td>
            <td align="left" width="2%" class="style1">
                :</td>
            <td align="left" class="style1" width="20%">
                <asp:Label ID="lblphnono" runat="server"></asp:Label>
            </td>
            <td align="left" class="style1">
                INVOICE NO</td>
            <td align="left" class="style1">
                :</td>
            <td align="left" class="style1">
                <asp:Label ID="lblinvno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
            <td align="left" width="10%" class="style2">
                DATE OF SALE</td>
            <td align="left" width="2%" class="style2">
                :</td>
            <td align="left" width="20%" class="style2">
                <asp:Label ID="lbldateofsale" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2" class="style2">
                &nbsp;</td>
            <td align="left" class="style2">
                &nbsp;</td>
        </tr>
        <tr style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
            <td align="left" width="10%" height="20px">
                &nbsp;</td>
            <td align="left" width="2%">
                &nbsp;</td>
            <td align="left" width="20%">
                &nbsp;</td>
            <td align="left" colspan="2">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" 
                width="100%" colspan="6" 
                style="font-size: medium; color: #000000; font-weight: bold;" 
                height="12px" valign="top">
                <asp:GridView ID="grd_spare" runat="server" AutoGenerateColumns="False" 
                    Font-Bold="True" Font-Size="10px" Width="100%">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:TemplateField HeaderText="SlNo">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part No">
                            <ItemTemplate>
                                <asp:Label ID="lblpartno" runat="server" 
                                    Text='<%# Eval("Itm_Partno") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Description">
                            <ItemTemplate>
                                <asp:Label ID="lblpdes" runat="server" Text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty ">
                            <ItemTemplate>
                                <asp:Label ID="lblqty" runat="server" Text='<%# Eval("Ss_Quantity") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rate">
                            <ItemTemplate>
                                <asp:Label ID="lblrate" runat="server" Text='<%# Eval("Ss_Rate") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount ">
                            <ItemTemplate>
                                <asp:Label ID="lblamount" runat="server" Text='<%# Eval("Ss_Amount") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Discount">
                            <ItemTemplate>
                                <asp:Label ID="lbldiscount" runat="server" 
                                    Text='<%# Eval("Ss_Discount") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gst">
                            <ItemTemplate>
                                <asp:Label ID="lblvat" runat="server" Text='<%# Eval("Ss_Vat") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Gst Amount">
                            <ItemTemplate>
                                <asp:Label ID="lbltaxamount" runat="server" Text='<%# Eval("Ss_TaxAmont") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Net Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblnetamount" runat="server" Text='<%# Eval("Ss_Total") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="12px" Font-Names="Vani" />
                    <PagerStyle CssClass="pgr" />
                </asp:GridView>
            </td>
        </tr>
        <%--<tr>
        <td colspan="6">
        </td>
        </tr>--%>
         <tr style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
            <td align="left" width="10%" class="style1">
                </td>
            <td align="left" width="2%" class="style1">
                </td>
            <td align="left" width="20%" class="style1">
                </td>
            <td align="left" colspan="2" class="style1">
                </td>
            <td align="left" class="style1">
                </td>
        </tr>
     <%--   <tr style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
            <td align="left" height="20px" 
                style="border-top-style: dashed; border-width: thin; border-color: #000000" 
                width="10%">
                &nbsp;</td>
            <td align="left" 
                style="border-top-style: dashed; border-width: thin; border-color: #000000" 
                width="2%">
                &nbsp;</td>
            <td align="left" 
                style="border-top-style: dashed; border-width: thin; border-color: #000000" 
                width="20%">
                &nbsp;</td>
            <td align="right" char="Gross Total : 563.87" 
                style="border-top-style: dashed; border-width: thin; border-color: #000000">
                Gross Total</td>
            <td align="left" 
                style="border-top-style: dashed; border-width: thin; border-color: #000000">
                :</td>
            <td align="left" 
                style="border-top-style: dashed; border-width: thin; border-color: #000000">
                <asp:Label ID="lblgrosstotal" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td align="left" width="10%" class="style2">
                </td>
            <td align="left" width="2%" class="style2">
                </td>
            <td align="left" width="20%" class="style2">
                </td>
            <td align="right" char="Gross Total : 563.87" class="style2">
                Discount</td>
            <td align="left" class="style2">
                :</td>
            <td align="left" class="style2">
                <asp:Label ID="lbldiscount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td align="left" height="20px" width="10%">
                &nbsp;</td>
            <td align="left" width="2%">
                &nbsp;</td>
            <td align="left" width="20%">
                &nbsp;</td>
            <td align="right" char="Gross Total : 563.87">
                Vat Amount</td>
            <td align="left">
                :</td>
            <td align="left">
                <asp:Label ID="lblvatamount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td align="left" height="20px" width="10%">
                &nbsp;</td>
            <td align="left" width="2%">
                &nbsp;</td>
            <td align="left" width="20%">
                &nbsp;</td>
            <td align="right" char="Gross Total : 563.87">
                P.F Charges</td>
            <td align="left">
                :</td>
            <td align="left">
                <asp:Label ID="lblpfcharge" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td align="left" height="20px" width="10%">
                &nbsp;</td>
            <td align="left" width="2%">
                &nbsp;</td>
            <td align="left" width="20%">
                &nbsp;</td>
            <td align="right" char="Gross Total : 563.87">
                Other Charges</td>
            <td align="left">
                :</td>
            <td align="left">
                <asp:Label ID="lblotherchrg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td align="left" height="20px" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000" 
                width="10%">
                &nbsp;</td>
            <td align="left" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000" 
                width="2%">
                &nbsp;</td>
            <td align="left" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000" 
                width="20%">
                &nbsp;</td>
            <td align="right" char="Gross Total : 563.87" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
                RETURN VALUE</td>
            <td align="left" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
                :</td>
            <td align="left" 
                style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
                <asp:Label ID="lblreturnvalue" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
            <td align="left" colspan="2" height="20px">
                &nbsp;</td>
            <td align="left" colspan="2" height="20px">
                &nbsp;</td>
            <td align="left" colspan="2" height="20px">
                <asp:Label ID="Label17" runat="server" Text="Total  : Rs."></asp:Label>
                &nbsp;&nbsp;
                <asp:Label ID="lblrupees" runat="server"></asp:Label>
            </td>
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

