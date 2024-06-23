<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Spare_Return_SalesEntryList.aspx.cs" Inherits="admin_StockMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="SmitaStYlE/Calender/orange.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=Panel1.ClientID %>");
             var printWindow = window.open('', '_blank', 'height=600,width=920');
             printWindow.document.write('<html><head><title>Print Page</title>');
             printWindow.document.write('</head><body>');
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1"  DynamicLayout="true" runat="server">
     <ProgressTemplate>      
             <div class="modall">
        <div class="centerr">
            <img alt="progress" src="Images/processing.gif"/>
        </div>
    </div>             
            </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server">
                <fieldset id="FS_IssuedBook" runat="server">
                    <legend>
                        <h4>
                            Spare Return List</h4>
                    </legend>
            <table style="width: 100%;">
                <tr>
                    <td style="width: 16%">
                        From Date
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%">
                        <asp:TextBox ID="txt_FromDate" runat="server" CssClass="TextBoxGraiantDate" Width="160px"></asp:TextBox>
                        <asp:CalendarExtender ID="txt_FromDate_CalendarExtender" runat="server" CssClass="orange"
                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_FromDate">
                        </asp:CalendarExtender>
                    </td>
                    <td style="width: 16%">
                        To Date
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%">
                        <asp:TextBox ID="txt_ToDate" runat="server" CssClass="TextBoxGraiantDate" Width="160px"></asp:TextBox>
                        <asp:CalendarExtender ID="txt_ToDate_CalendarExtender" runat="server" CssClass="orange"
                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_ToDate">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        <asp:Button ID="btn_Show" runat="server" CssClass="VerySmallGreen" Height="26px"
                            OnClick="btn_Show_Click" Text="Show" Width="70px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="7">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            Width="100%" CssClass="mGrid" PagerStyle-CssClass="pgr" 
                            AlternatingRowStyle-CssClass="alt">
                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="Sl. No." >
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Invoice No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl001" runat="server" Text='<%# Eval("Sp_InvoiceNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Return Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl002" runat="server" Text='<%# Eval("Sales_ReturnDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Party Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl003" runat="server" Text='<%# Eval("Mc_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Part No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl004" runat="server" Text='<%# Eval("Itm_Partno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Part Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl005" runat="server" Text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl006" runat="server" Text='<%# Eval("Ss_Rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Return Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl007" runat="server" Text='<%# Eval("Ss_ReturnQuantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl008" runat="server" Text='<%# Eval("Ss_Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Discount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl009" runat="server" Text='<%# Eval("Ss_Discount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gst">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl010" runat="server" Text='<%# Eval("Ss_Vat") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Gst Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltax" runat="server" Text='<%# Eval("Ss_TaxAmont") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotal" runat="server" Text='<%# Eval("Ss_Total") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Print">
                                            <ItemTemplate>
                                               
                                                <asp:ImageButton ID="img_print" runat="server" Height="20px" ToolTip='<%# Eval("SP_id") %>'
                                                    ImageUrl="~/Admin/Images/file-print.png" onclick="img_print_Click" />
                                               
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                               
                            </Columns>
                            <HeaderStyle ForeColor="White" />
                            <PagerStyle CssClass="pgr" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <br />
                    </td>
                </tr>
            </table>
             </fieldset>
            </asp:Panel>
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
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
