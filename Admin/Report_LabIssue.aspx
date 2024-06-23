<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Report_LabIssue.aspx.cs" Inherits="Admin_Report_LabIssue" %>

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
                            Height="26px"  Text="Show" Width="70px" onclick="btn_Show_Click"  />
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
                       <asp:ListItem>PAID</asp:ListItem>
                                 <asp:ListItem>WARRANTY</asp:ListItem>
                                    <asp:ListItem>AMC</asp:ListItem>

                       </asp:DropDownList>
                       
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
                             <td align="center" colspan="7" valign="top">
                                 &nbsp;</td>
             `           </tr>

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
                    <%--    <asp:AutoCompleteExtender ID="AutoComplet%Extender2" runat="server" 
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
                                        
                                          <asp:TemplateField HeaderText="Service Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblservicecode" runat="server" 
                                                    text='<%# Eval("JCS_Servicecode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                           
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldescription" runat="server" Text='<%# Eval("JCS_Description") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblquantity" runat="server"  text='<%# Eval("JCS_Quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrate" runat="server"   text='<%# Eval("JCS_Rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamt" runat="server"   text='<%# Eval("JCS_Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Spare Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsparetype" runat="server"   text='<%# Eval("JCS_SpareType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Created By">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcreateedby" runat="server"   text='<%# Eval("Created_By") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Created Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcreateeddate" runat="server"   text='<%# Eval("Created_Date") %>'></asp:Label>
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
                                    <asp:Button ID="btn_excel" runat="server" CssClass="ThinRed" 
                            Text="Download To Excel" onclick="btn_excel_Click1" />
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


