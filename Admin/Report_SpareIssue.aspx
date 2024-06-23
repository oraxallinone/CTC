<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Report_SpareIssue.aspx.cs" Inherits="Admin_Report_SpareIssue" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                            Spare Issue Report</h4>
                    </legend>

                    <table width="100%">
                         <tr>
                    <td style="width: 16%">
                        From Date
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%">
                        <asp:TextBox ID="txt_FromDate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="130px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_FromDate_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_FromDate">
                                </asp:CalendarExtender>
                    </td>

                     <td style="width: 16%">
                       To Date
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%">
                         <asp:TextBox ID="txt_ToDate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="130px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_ToDate_CalendarExtender" runat="server" 
                                    CssClass="orange" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txt_ToDate">
                                </asp:CalendarExtender>
                       
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
                    <td style="width: 16%">
                        JC No.
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%">
                        <asp:TextBox ID="txt_jcno" runat="server" CssClass="TextBoxGraiant" 
                            Width="130px"></asp:TextBox>
                      <%--  <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                                CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="Getjcno" ServicePath="" 
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_jcno">
                                            </asp:AutoCompleteExtender>--%>
                    </td>

                     <td style="width: 16%">
                        Spare Type
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%">
                       <asp:DropDownList ID="drp_sparetype" runat="server">
                       <asp:ListItem>foc</asp:ListItem>
                       <asp:ListItem>warranty</asp:ListItem>
                       <asp:ListItem>paid</asp:ListItem>

                       </asp:DropDownList>
                       
                    </td>
                    <td style="width: 16%">
                        <asp:Button ID="Button1" runat="server" CssClass="VerySmallGreen" 
                            Height="26px"  Text="Show" Width="70px" onclick="Button1_Click" />
                    </td>
                    <td style="width: 1%">
                        &nbsp;</td>
                    <td style="width: 24%">
                        &nbsp;</td>
                    <td>
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
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBoxGraiant" 
                            Width="130px"></asp:TextBox>
                      <%--  <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                                                CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="Getjcno" ServicePath="" 
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="TextBox1">
                                            </asp:AutoCompleteExtender>--%>
                    </td>

                     <td style="width: 16%">
                       
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%">
                      
                       
                    </td>
                    <td style="width: 16%">
                        <asp:Button ID="Button2" runat="server" CssClass="VerySmallGreen" 
                            Height="26px"  Text="Show" Width="70px" onclick="Button2_Click"  />
                    </td>
                    <td style="width: 1%">
                        &nbsp;</td>
                    <td style="width: 24%">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>

                  <tr>
                             <td align="center" colspan="7" valign="top">
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
                                                <asp:Label ID="lbljcno" runat="server" Text='<%# Eval("JC_No") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        
                                          <asp:TemplateField HeaderText="Spare Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsparetype" runat="server" 
                                                    text='<%# Eval("SE_Sparetype") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Itm Desc.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldesc" runat="server" 
                                                    text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Itm Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblitmname" runat="server" Text='<%# Eval("Itm_Partno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrate" runat="server"  text='<%# Eval("SE_Rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblqty" runat="server"   text='<%# Eval("SE_Quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblqty" runat="server"   text='<%# Eval("SE_Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Disc Per">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldiscper" runat="server"   text='<%# Eval("SE_DiscountPer") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Disc Amt.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldiscamt" runat="server"   text='<%# Eval("SE_Discount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Tax %">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltaxper" runat="server"   text='<%# Eval("SE_Vat") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tax Amt.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltaxamt" runat="server"   text='<%# Eval("SE_Taxamount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotal" runat="server"   text='<%# Eval("SE_Total") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="User">
                                            <ItemTemplate>
                                                <asp:Label ID="lbluser" runat="server"  text='<%# Eval("Created_By") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DateTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldatetime" runat="server"  text='<%# Eval("Created_Date") %>'></asp:Label>
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

