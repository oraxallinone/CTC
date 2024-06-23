<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report_VehicleNetStock.aspx.cs" Inherits="admin_StockDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
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
         <div style="text-align:center;">
    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick = "return PrintPanel();" />
    </div>--%>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

            <asp:Panel ID="Panel1" runat="server">
    <asp:Label ID="lbl_Header" runat="server" CssClass="Header1" Text="Present NET Stock Report"></asp:Label>
    <br />
    <fieldset>
        <legend>
            <h5>
               Vehicle Net Stock Details</h5>
        </legend>
        <table style="width: 100%; vertical-align: top;">
        <tr style="vertical-align: top;">
        <td colspan="3" align="center"  vertical-align: top;">
            <asp:Label ID="lbl_BillType" runat="server" Font-Bold="True" 
                Font-Names="Cambria" Font-Size="16px">RASHMI MOTORS</asp:Label>
            <br />
            <asp:Label ID="lbl_BranchAddress" runat="server" Font-Bold="False" 
                Font-Names="Cambria"></asp:Label>
            ,<asp:Label ID="lbltin" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbl_InvoiceType" runat="server" Font-Bold="True" 
                Font-Names="Cambria" Font-Size="16px">Vehicle Net Stock </asp:Label>
        </td>
        </tr>
            <tr style="vertical-align: top;">
                <td colspan="3" align="right" style="height: 250px; vertical-align: top;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                        Width="100%">
                        <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Invoice No.">
                                <ItemTemplate>
                                    <asp:Label ID="Label301" runat="server" Text='<%# Eval("Vp_Invoiceno") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Invoice Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label302" runat="server" Text='<%# Eval("Vp_InvoiceDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vehicle Type">
                                <ItemTemplate>
                                    <asp:Label ID="Label30" runat="server" Text='<%# Eval("Mv_VehicleType") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Model Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label31" runat="server" Text='<%# Eval("modelname") %>' ToolTip='<%# Eval("model") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Chassis No.">
                                <ItemTemplate>
                                    <asp:Label ID="Label32" runat="server" Text='<%# Eval("Vp_Chassisno") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Enginee No.">
                                <ItemTemplate>
                                    <asp:Label ID="Label33" runat="server" Text='<%# Eval("Vp_Engineno") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Net Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="Label34" runat="server" Text='<%# Eval("Vp_NetQuantity") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="Label35" runat="server" Text='<%# Eval("Vp_Amount") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                           
                        </Columns>
                        <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
                        <PagerStyle CssClass="pgr" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
    
    </asp:Panel>
    <div style="text-align:center;">
    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick = "return PrintPanel();" />
        <asp:Button ID="btnexcel" runat="server" BackColor="#33CCFF" 
            onclick="btnexcel_Click" Text="Excel Print" />
    </div>
</asp:Content>
