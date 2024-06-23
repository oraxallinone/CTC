<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Spare_SalesEntryList_Invoice.aspx.cs" Inherits="Admin_Spare_SalesEntryList_Invoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss06.css" rel="stylesheet" type="text/css" />
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
                            Spare Counter Sales List</h4>
                    </legend>
                    <table width="100%">
                        <tr>
                            <td style="width: 16%">
                               Invoice No.
                            </td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td style="width: 24%">
                                <asp:TextBox ID="txt_invoice" runat="server" CssClass="TextBoxGraiant" Width="130px"></asp:TextBox>
                                 <asp:AutoCompleteExtender ID="txt_invoice_AutoCompleteExtender" runat="server" 
                                                CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="GetInvoice" ServicePath="" 
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_invoice">
                                            </asp:AutoCompleteExtender>
                            </td>
                            <td>Finacial Year</td>
                            <td><asp:TextBox ID="txt_year" runat="server" CssClass="TextBoxGraiant" Width="130px"></asp:TextBox>
                             <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="Getyear" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_year">
                                            </asp:AutoCompleteExtender>
                            
                            </td>
                            <td style="width: 16%">
                                &nbsp;<asp:Button ID="btn_Show" runat="server" CssClass="VerySmallGreen" 
                                    Height="26px" OnClick="btn_Show_Click" Text="Show" Width="70px" />
                            </td>
                            <td style="width: 1%">
                                &nbsp;</td>
                            <td style="width: 24%">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" valign="top" colspan="7">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="7" valign="top">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top" colspan="7">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                                    Font-Names="Cambria" Font-Size="12px" CssClass="mGrid" ShowFooter="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="50px"/>
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl001" runat="server" Text='<%# Eval("Sp_InvoiceNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl002" runat="server" Text='<%# Eval("Sp_InvoiceDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left"  Width="100px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl003" runat="server" Text='<%# Eval("Sp_Mc_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gross">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl004" runat="server" Text='<%# Eval("Sp_GrossAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"  Width="100px" />
                                            <ItemStyle HorizontalAlign="Left"  Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Discount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl005" runat="server" Text='<%# Eval("Sp_Discount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"  Width="100px" />
                                            <ItemStyle HorizontalAlign="Left"  Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gst">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl006" runat="server" Text='<%# Eval("Sp_VatAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"  Width="100px" />
                                            <ItemStyle HorizontalAlign="Left"  Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl007" runat="server" Text='<%# Eval("Sp_TotalAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"  Width="100px" />
                                            <ItemStyle HorizontalAlign="Left"  Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gr. Total">
                                             <FooterTemplate>
                                                 <asp:Label ID="lbl_fgamnt" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl008" runat="server" Text='<%# Eval("Sp_FinalAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"  Width="100px" />
                                            <ItemStyle HorizontalAlign="Left"  Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnview" runat="server" ToolTip='<%# Eval("Sp_Id") %>' ImageUrl="~/Admin/Icon/view.png"
                                                    Width="22px" OnClick="imgbtnview_Click" CommandArgument='<%# Eval("Sp_InvoiceNo") %>'/>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit" Visible="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnedit" runat="server" ToolTip='<%# Eval("Sp_Id") %>' ImageUrl="~/Admin/Icon/Edit.jpg"
                                                    Width="22px" OnClick="imgbtnedit_Click"  CommandArgument='<%# Eval("Sp_InvoiceNo") %>'/>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                       
                                <asp:TemplateField HeaderText="Print">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtn_print" runat="server" ImageUrl="~/Admin/Images/file-print.png"
                                            OnClick="imgbtn_print_Click" ToolTip='<%# Eval("Sp_Id") %>' 
                                            CommandArgument='<%# Eval("Sp_InvoiceNo") %>' Height="20px" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
                                </asp:GridView>
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
