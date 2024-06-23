<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Service_JobFinalInvoice_List_InvoiceNo.aspx.cs" Inherits="Admin_Service_JobFinalInvoice_List_InvoiceNo" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
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
     <style type="text/css">
         .style1
         {
             height: 26px;
         }
     </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                            Job FinalInvoice Report&nbsp; List  Invoice No. Wise</h4>
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
                        <asp:TextBox ID="txt_invoice" runat="server" CssClass="TextBoxGraiant" 
                            Width="130px"></asp:TextBox>
                        <asp:AutoCompleteExtender ID="txt_invoice_AutoCompleteExtender" runat="server" 
                                                CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="GetInvoice" ServicePath="" 
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_invoice">
                                            </asp:AutoCompleteExtender>
                    </td>

                     <td style="width: 16%">
                        Finacial Year
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%">
                        <asp:TextBox ID="txt_year" runat="server"
                            Width="100px"></asp:TextBox>
                       
                    </td>
                    <td style="width: 16%">
                        <asp:Button ID="btn_Show" runat="server" CssClass="VerySmallGreen" 
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
                            <td align="center" valign="top" colspan="7" class="style1">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                        </tr>
                         <tr>
                             <td align="center" colspan="7" valign="top">
                                 &nbsp;</td>
                         </tr>
                                                  <tr>
                             <td align="center" colspan="7" valign="top">
                                 &nbsp;</td>
                         </tr>

                         <tr>
                    <td style="width: 16%">
                        JC No.
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%">
                        <asp:TextBox ID="txt_jcno" runat="server" CssClass="TextBoxGraiant"  Width="130px"></asp:TextBox>
                       <%-- <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                                CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="GetJcnoup" ServicePath="" 
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_jcno">
                                            </asp:AutoCompleteExtender>--%>
                    </td>

                     <td style="width: 16%">
                        Finacial Year
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%">
                        <asp:TextBox ID="TextBox2" runat="server"
                            Width="100px"></asp:TextBox>
                       
                    </td>
                    <td style="width: 16%">
                        <asp:Button ID="Button1" runat="server" CssClass="VerySmallGreen" 
                            Height="26px"  Text="Show" Width="70px" onclick="Button1_Click"  />
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
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    Width="100%" Font-Names="Cambria" Font-Size="12px" 
                                    CssClass="mGrid">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Job Card No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbljcno" runat="server" Text='<%# Eval("FI_JcNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        
                                          <asp:TemplateField HeaderText="Invoice No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblinvno" runat="server" 
                                                    text='<%# Eval("FI_InvoiceNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" width="20%"/>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Invoice Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblidate" runat="server"  text='<%# Eval("FI_InvoiceDate","{0:dd:MM:yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcname" runat="server" Text='<%# Eval("Mc_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Mobile No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmno" runat="server"  text='<%# Eval("Mc_Mobileno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Invoice Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltinno" runat="server"   text='<%# Eval("FIP_BillAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                          
                                        <asp:TemplateField HeaderText="Print" >
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnprint" runat="server" ToolTip='<%# Eval("FI_Sino") %>' CommandArgument='<%# Eval("FI_JcNo") %>'
                                                    ImageUrl="~/Admin/Images/file-print.png" Width="25px" 
                                                    onclick="imgbtnview_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                   
                                       <asp:TemplateField HeaderText="Print" Visible="false" >
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnprint1" runat="server"  ToolTip='<%# Eval("jc_year") %>'
                                                    Width="25px" />
                                                   
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
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
                  </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

