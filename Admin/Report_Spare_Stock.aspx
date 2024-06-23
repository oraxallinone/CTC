<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report_Spare_Stock.aspx.cs" Inherits="Report_ProjectExpensesDetailsCodeDatewise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
                <fieldset id="FS_IssuedBook" runat="server">
                    <legend>
                        <h4>
                            Total Stock&nbsp; List</h4>
                    </legend>
                    <table width="100%">
                        <tr>
                            <td style="width: 16%">
                                &nbsp;</td>
                            <td style="width: 1%">
                                &nbsp;</td>
                            <td style="width: 24%">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                            <td style="width: 16%">
                                &nbsp;</td>
                            <td style="width: 1%">
                                &nbsp;</td>
                            <td style="width: 24%">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 16%">
                                &nbsp;</td>
                            <td style="width: 1%">
                                &nbsp;</td>
                            <td style="width: 24%">
                                &nbsp;</td>
                            <td style="width: 16%">
                                &nbsp;</td>
                            <td style="width: 1%">
                                &nbsp;</td>
                            <td style="width: 24%">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
            <asp:Panel ID="Panel1" runat="server">
                    <table width="100%">
                        <tr>
                            <td align="center" valign="top">
                                <asp:Label ID="lbl_BillType" runat="server" Font-Bold="True" 
                                    Font-Names="Cambria" Font-Size="16px">RASHMI MOTORS</asp:Label>
                                <br />
                                <asp:Label ID="lbl_BranchAddress" runat="server" Font-Bold="False" 
                                    Font-Names="Cambria"></asp:Label>
                                ,<asp:Label ID="lbltin" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lbl_InvoiceType" runat="server" Font-Bold="True" 
                                    Font-Names="Cambria" Font-Size="16px">Spare Stock Report</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    Font-Names="Cambria" Font-Size="12px" Width="100%" ShowFooter="True" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Part No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpartno" runat="server" 
                                                    Text='<%# Eval("Itm_Partno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Itm PartDescrption">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpartdescription" runat="server" 
                                                    Text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Net qty">
                                             <FooterTemplate>
                                                 <asp:Label ID="lbl_fnetqty" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblnetquantity" runat="server" 
                                                    Text='<%# Eval("qty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Pur. Price">
                                             <FooterTemplate>
                                                 <asp:Label ID="lbl_fpurprice" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblrate1" runat="server" Text='<%# Eval("Itm_PurchasePrice") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Sale. Price">
                                             <FooterTemplate>
                                                 <asp:Label ID="lbl_fsaleprice" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblrate2" runat="server" Text='<%# Eval("Itm_SalePrice") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Amount">
                                             <FooterTemplate>
                                                 <asp:Label ID="lbl_ftotamnt" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblamount" runat="server" >0</asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sale Value">
                                             <FooterTemplate>
                                                 <asp:Label ID="lbl_flblsaleamnt" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblsaleamnt" runat="server" >0</asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Location">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl0043" runat="server" Text='<%# Eval("Itm_Selfno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField HeaderText="Tax">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltax" runat="server" Text='<%# Eval("Itm_VatPercent") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Tax Amount">
                                             <FooterTemplate>
                                                 <asp:Label ID="lbl_ftaxamnt" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbltaxamount" runat="server" >0</asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Amount">
                                             <FooterTemplate>
                                                 <asp:Label ID="lbl_fgamnt" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblamount0" runat="server" >0</asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>--%>
                                    </Columns>
                                    <HeaderStyle Font-Bold="True" Font-Italic="True" Font-Names="Cambria" 
                                        Font-Size="14px" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
                </fieldset>
            <table width="100%">
                <tr>
                    <td align="center" valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        <asp:Button ID="btnBookAdd" runat="server" CssClass="btn-info" Font-Bold="True" Font-Names="US"
                            OnClientClick="return PrintPanel()" Text="Print" />
                        <asp:Button ID="btn_excel" runat="server" CssClass="ThinRed" 
                            onclick="btn_excel_Click" Text="Download To Excel" />
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        &nbsp;
                    </td>
                </tr>
            </table>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
