<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report_Spare_NetStock.aspx.cs" Inherits="Report_ProjectExpensesDetailsCodeDatewise" %>

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
<fieldset id="FS_IssuedBook" runat="server">
                    <legend>
                        <h4>
                            Spare Stock Inventory Total Report</h4>
                    </legend>
                    <table width="100%">
                        <tr>
                            <td style="width: 16%">
                                From Date
                            </td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td style="width: 24%; position:relative">
                                <asp:TextBox ID="txt_FromDate" runat="server" CssClass="TextBoxGraiantDate" Width="130px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_FromDate_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_FromDate">
                                </asp:CalendarExtender>
                            </td>
                            <td style="width: 16%">
                                To Date
                            </td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td style="width: 24%; position:relative">
                                <asp:TextBox ID="txt_ToDate" runat="server" CssClass="TextBoxGraiantDate" Width="130px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_ToDate_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_ToDate">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Button ID="btn_Show1" runat="server" CssClass="VerySmallGreen" Height="26px"
                                    OnClick="btn_Show_Click" Text="Show" Width="70px" />
                            </td>
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
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                        </tr>
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
                                    Font-Names="Cambria" Font-Size="16px">SPARE STOCK DETAILS</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                &nbsp; From
                                <asp:Label ID="lbl_from" runat="server"></asp:Label>
                                &nbsp;To
                                <asp:Label ID="lbl_to" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <strong style="font-size:14px; font-weight:bold">Purchase Quantity</strong>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    Font-Names="Cambria" Font-Size="12px" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Catagory Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl001" runat="server" Text='<%# Eval("Itm_CategoryName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Part No.">
                                            <ItemTemplate>
                                                 
                                                    <asp:Label ID="lbl_ttl" runat="server" Text='<%# Eval("partno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl003" runat="server" Text='<%# Eval("descrip") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Net Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl0044" runat="server" Text='<%# Eval("netqty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Purchase Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl0041" runat="server" Text='<%# Eval("Itm_PurchasePrice") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Sale Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl0042" runat="server" Text='<%# Eval("saleprice") %>'></asp:Label>
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
                                        
                                        
                                    </Columns>
                                    <HeaderStyle Font-Bold="True" Font-Italic="True" Font-Names="Cambria" 
                                        Font-Size="14px" />
                                </asp:GridView>
                            </td>
                        </tr>
                         <tr>
                            <td align="left" valign="top">
                                
                            </td>
                        </tr>
                         <tr>
                            <td align="left" valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                &nbsp;</td>
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

</asp:Content>
