<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Report_DailySalesReport1.aspx.cs" Inherits="Admin_Report_DailySalesReport1" %>


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
                           Daily Sales Report<asp:ScriptManager 
                                ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                        </h4>
                    </legend>
                 
                    
                    <table width="100%">
                         <tr>
                            <td align="center" valign="top" style="position:relative">
                                From Date :
                                <asp:TextBox ID="txt_FromDate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="130px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_FromDate_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_FromDate">
                                </asp:CalendarExtender>
                                To Date :
                                <asp:TextBox ID="txt_ToDate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="130px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_ToDate_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_ToDate">
                                </asp:CalendarExtender>
                                <asp:Button ID="btn_Show1" runat="server" CssClass="VerySmallGreen" 
                                    Height="26px" OnClick="btn_Show_Click" Text="Show" Width="70px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 16%">
                        Finacial Year:
                   
                   
                        <asp:TextBox ID="txt_year" runat="server"
                            Width="100px"></asp:TextBox>
                                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="Getyear" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_year">
                                            </asp:AutoCompleteExtender>
                    </td>
                        </tr>
                        
                    </table>
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="100%">
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
                                    Font-Names="Cambria" Font-Size="16px"> Daily Sales Report</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                &nbsp;</td>
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
                                          <asp:TemplateField HeaderText="Invoice No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblinvoice" runat="server" 
                                                    Text='<%# Eval("DR_InvoiceNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Party Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcname" runat="server" 
                                                    Text='<%# Eval("Mc_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldate" runat="server" Text='<%# Eval("DR_IDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Inv. Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblinvoicetype" runat="server" 
                                                    Text='<%# Eval("DR_InvType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Inv. Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblinvstatus" runat="server" 
                                                    Text='<%# Eval("DR_InvStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Inv. Mode">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="lblinvmode" runat="server" 
                                                    Text='<%# Eval("Dr_InvMode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Job Card No">
                                         
                                            <ItemTemplate>
                                                <asp:Label ID="lbljcno" runat="server" 
                                                    Text='<%# Eval("JC_No") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Spare 14.5%">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_fspare135" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblspare135" runat="server" 
                                                    Text='<%# Eval("Dr_Spare13_5") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Spare 5%">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_fspare5" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblspare5" runat="server" 
                                                    Text='<%# Eval("Dr_Spare5") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Lub 14.5%">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_flub135" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbllub135" runat="server" 
                                                    Text='<%# Eval("Dr_Lub13_5") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Lub 5%">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_flub5" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbllub5" runat="server" 
                                                    Text='<%# Eval("Dr_Lub5") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dis.14.5%">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_fdis135" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbldis135" runat="server" 
                                                    Text='<%# Eval("Dr_DiscountAmount3_5") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dis. 5%">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_fdiscount" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbldiscount" runat="server" 
                                                    Text='<%# Eval("Dr_DiscountAmount5") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Output 14.5%">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_foutput135" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbloutput135" runat="server" 
                                                    Text='<%# Eval("Dr_Output13_5") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Output 5%">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_foutput5" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbloutput5" runat="server" 
                                                    Text='<%# Eval("Dr_Output5") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Other Charges" Visible="true">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_fotherchrges" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblotherchrges" runat="server" Text='<%# Eval("Dr_OtherCharges") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Labour Charges">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_flabourcharges" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbllabourcharges" runat="server" Text='<%# Eval("Dr_Labourcharges") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="90px" />
                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Dis.Labour Charges">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_fdiscountlbrcharge" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbldiscountlbrcharge" runat="server" Text='<%# Eval("Dr_DisLabourcharges") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="90px" />
                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Net Labour Charges">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_fnetlbrchrg" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblnetlbrchrg" runat="server" Text='<%# Eval("Dr_NetLabourcharges") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="90px" />
                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Service Tax 14%">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_fservtax12" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblservtax12" runat="server" Text='<%# Eval("Dr_Servtaxx12") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="90px" />
                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                        </asp:TemplateField>
                                         <%-- <asp:TemplateField HeaderText="Ecess 0%">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_fecess2" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblecess2" runat="server" Text='<%# Eval("Dr_Ecess2") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Scess 0%">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_fscess1" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblscess1" runat="server" Text='<%# Eval("Dr_Scess1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>--%>
                                          <asp:TemplateField HeaderText="Round Off" >
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_froundoff" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblroundoff" runat="server" Text='<%# Eval("Dr_Roundoff") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="90px" />
                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Outside Job">
                                           <FooterTemplate>
                                                 <asp:Label ID="lbl_foutsidejob" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbloutsidejob" runat="server" Text='<%# Eval("Dr_Outsidejob") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="90px" />
                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Return Total">
                                             <FooterTemplate>
                                                 <asp:Label ID="lbl_Returnamnt" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblReturntotal" runat="server" Text='<%# Eval("ReturmAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="90px" />
                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Invoice Total">
                                             <FooterTemplate>
                                                 <asp:Label ID="lbl_fgamnt" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblinvoicetotal" runat="server" Text='<%# Eval("Dr_InvoiceTotal") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="90px" />
                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Font-Bold="True" Font-Italic="True" Font-Names="Cambria" 
                                        Font-Size="14px" BackColor="#FF6600" ForeColor="White" />
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

