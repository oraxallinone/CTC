<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Spare_EstimatePrint.aspx.cs" Inherits="Admin_Vehicle_SalesInvoicePrint" %>

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

     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
  
<center>
    <table style="width:210mm;height:210mm; text-transform:uppercase;">
    <tr>
    <td align="center" height="80px" valign="top" colspan="2">
        <asp:Label ID="lbl_BillType" runat="server" Font-Bold="True" 
            Font-Names="Cambria" Font-Size="16px">Rashmi Motors</asp:Label>
        <br />
        <asp:Label ID="lbl_BranchAddress" runat="server" Font-Bold="False" 
            Font-Names="Cambria"></asp:Label>
        <br />
        <asp:Label ID="lbl_Estimation" runat="server" Font-Bold="True" 
            Font-Names="Cambria" Font-Size="16px">Estimation</asp:Label>
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
                <br />
                <asp:Label ID="lbl_Address" runat="server" Width="300px"></asp:Label>
                </td>
            <td align="left" valign="top">
                <table width="100%"  style="text-transform:uppercase;">
                    <tr>
                        <td width="40%" class="ui-priority-primary">
                            Estimate Date</td>
                        <td width="1%">
                            :</td>
                        <td>
                            <asp:Label ID="lbl_EstimateDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary" width="40%">
                            Estimate No.</td>
                        <td width="1%">
                            :</td>
                        <td>
                            <asp:Label ID="lbl_EstimateNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary">
                            Registration No</td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_RegdNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui-priority-primary">
                            Model</td>
                        <td>
                            :</td>
                        <td>
                            <asp:Label ID="lbl_ModelNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr >
            <td colspan="2" height="15px" valign="top" 
                style="border-top: thin solid; border-bottom: thin solid;text-transform:uppercase;" align="left">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  style="font-size:12px; font-family:Arial;"
                    ShowFooter="True" >
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
                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("Itm_Partno") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PartDescription">
                            <FooterTemplate>
                                <asp:Label ID="lbl_F1" runat="server" Font-Bold="True" Text="Total"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <FooterTemplate>
                                <asp:Label ID="lbl_F2" runat="server" Font-Bold="True"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("Ss_Quantity") %>'></asp:Label>
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
                        <asp:TemplateField HeaderText="Amount">
                            <FooterTemplate>
                                <asp:Label ID="lbl_F3" runat="server" Font-Bold="True"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%# Eval("Ss_Amount") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Discount">
                            <FooterTemplate>
                                <asp:Label ID="lbl_F4" runat="server" Font-Bold="True"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("Ss_Discount") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GST">
                            <ItemTemplate>
                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("Ss_Vat") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GSTAmount">
                            <FooterTemplate>
                                <asp:Label ID="lbl_F5" runat="server" Font-Bold="True"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label17" runat="server" Text='<%# Eval("Ss_TaxAmont") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <FooterTemplate>
                                <asp:Label ID="lbl_F6" runat="server" Font-Bold="True"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label18" runat="server" Text='<%# Eval("Ss_Total") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Bold="True" Font-Names="Cambria" />
                    <RowStyle VerticalAlign="Top" />
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td align="left" colspan="2" height="15px">
                <strong style="text-decoration: underline">Terms and Conditions:</strong></td>
        </tr>
        <tr>
            <td colspan="2" align="left" valign="top" height="250px" style="text-transform:uppercase;">
                1. This is a rough estimate of labour charges, parts &amp; consumables. During the 
                course of dismantalling/repair, additional parts/labour/consumable will be 
                charged extra.
                <br />
                2. Delivery of vehicle after repairs against full payment by Cash/DD only.
                <br />
                3. All labour rates / prices of spares are subjected to change without prior 
                notice and actual rates / prices prevailing at the time of delivery after repair 
                will be applicable.
                <br />
                4. All consumables such as petrol,diseal,kerosene etc. will be charged extra.
                <br />
                5. The company will charge its own labour/spare charges even if less amount is 
                passed by the insurance company.
                <br />
                6. If delivery of the vehicle is not taken within 14 days after repair, parking 
                charges will be charged. If work order is not given and vehicle is laying with 
                us, parking charges will be charged.
                <br />
                7. In case of dispute arising between the Company &amp; Customer the court of 
                Cuttack will have the jurisdiction.
                <br />
                <br />
                I accept the above terms &amp; conditions.</td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <strong>
                <br />
                <br />
                Signature of the customer with date
                </strong>
            </td>
            <td align="left" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="left" valign="top" style="text-transform:uppercase;">
            <strong style="text-decoration: underline">WORK ORDER:</strong>
                <br />
                I/We agree to get the vehicle repaired through RASHMI MOTORS.
                <br />
                I/We authorise you to start the work and change neccesary parts/undertake 
                repairs.If any additional work other than mentioned in this estimate is 
                required, you may undertake the same without anymore reference to us. I/We 
                accept the terms and conditions mentioned and understand that if the bills 
                remain unpaid over 15 days interest @2% per month will be charged.</td>
        </tr>
        <tr>
            <td align="left" colspan="2" valign="top">
                <br />
                <br />
                <em><strong>Signature of the customer<br />
                <br />
                Date :</strong></em></td>
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

