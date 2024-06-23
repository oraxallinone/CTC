<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report_Spare_StockTransfer.aspx.cs" Inherits="Report_ProjectExpensesDetailsCodeDatewise" %>

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
    <style type="text/css">
        .style1
        {
            width: 1%;
        }
    </style>

      <link href="SmitaStYlE/Calender/red.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss06.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
                <fieldset id="FS_IssuedBook" runat="server">
                    <legend>
                        <h4>
                            Spare StockTransfer List</h4>
                    </legend>
                    <table width="100%">

                    <%--<tr>
                            <td style="width: 16%">
                                Finacila Year</td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td style="width: 24%; position:relative">
                                <asp:TextBox ID="txt_year" runat="server"  Width="130px"></asp:TextBox>
                                  <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="Getfyear" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_year">
                                            </asp:AutoCompleteExtender>
                               
                            </td>
                            <td style="width: 16%">
                               
                            </td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="width: 24%; position:relative">
                                
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>--%>
                        <tr>
                            <td style="width: 16%">
                                From Date
                            </td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td style="width: 24%; position:relative">
                                <asp:TextBox ID="txt_FromDate" runat="server" CssClass="TextBoxGraiantDate" Width="130px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_FromDate_CalendarExtender" runat="server" CssClass="orange"
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_FromDate">
                                </asp:CalendarExtender>
                            </td>
                            <td style="width: 16%">
                                To Date
                            </td>
                            <td class="style1">
                                :
                            </td>
                            <td style="width: 24%; position:relative">
                                <asp:TextBox ID="txt_ToDate" runat="server" CssClass="TextBoxGraiantDate" Width="130px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_ToDate_CalendarExtender" runat="server" CssClass="orange"
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
                                Voucher No</td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td style="width: 24%; position:relative">
                                <asp:TextBox ID="txt_voucher" runat="server"  Width="130px"></asp:TextBox>
                               
                            </td>
                            <td style="width: 16%">
                                
                            </td>
                            <td class="style1">
                              Finacial Year</td>
                            <td style="width: 24%; position:relative">
                                  <asp:TextBox ID="txt_year" runat="server"  Width="130px"></asp:TextBox>
                                   <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="Getfyear" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_year">
                                            </asp:AutoCompleteExtender>
                            </td>
                            <td>
                            <asp:Button ID="btn_view" runat="server" CssClass="VerySmallGreen" Height="26px"
                                    OnClick="btn_view_Click" Text="Show" Width="70px" />

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
                            <td class="style1">
                                &nbsp;</td>
                            <td style="width: 24%">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 16%">
                                Part No</td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td style="width: 24%; position:relative">
                                <asp:TextBox ID="TextBox1" runat="server"  Width="130px"></asp:TextBox>
                                 <asp:AutoCompleteExtender ID="txt_PartNo_AutoCompleteExtender" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetPartNo" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="TextBox1">
                                            </asp:AutoCompleteExtender>
                            </td>
                            <td style="width: 16%">
                                <asp:Button ID="Button1" runat="server" CssClass="VerySmallGreen" Height="26px"
                                    Text="Show" Width="70px" onclick="Button1_Click" />
                            </td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="width: 24%; position:relative">
                                
                            </td>
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
                                    Font-Names="Cambria" Font-Size="16px">Spare Stock Transfer</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr id="tr_frm" runat="server">
                            <td align="center" valign="top">
                                &nbsp; From
                                <asp:Label ID="lbl_from" runat="server"></asp:Label>
                                &nbsp;To
                                <asp:Label ID="lbl_to" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    Font-Names="Cambria" Font-Size="12px" Width="100%" ShowFooter="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Voucher No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblvno" runat="server" Text='<%# Eval("Voucher_No") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="60px" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item PartNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpartno" runat="server" Text='<%# Eval("Itm_Partno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Part Desc">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpartdesc" runat="server" Text='<%# Eval("Itm_PartDesc") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transfer Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltransferquantity" runat="server" Text='<%# Eval("St_TransferQuantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrate" runat="server" Text='<%# Eval("St_Rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <FooterTemplate>
                                                <asp:Label ID="flblttl" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblttl" runat="server" Text='<%# Eval("St_Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transfer Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl002" runat="server" 
                                                    Text='<%# Eval("St_Transferdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From Branch">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfrombranch" runat="server" Text='<%# Eval("St_FromBranch") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Branch">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltobranch" runat="server" Text='<%# Eval("St_ToBranch") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Names="Broadway" 
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
    <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
