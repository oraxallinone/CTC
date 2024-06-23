<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Spare_Return_SalesEntrySearch.aspx.cs" Inherits="admin_StockMaster" %>

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
      <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss06.css" rel="stylesheet" type="text/css" />
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
                    <td>
                        Enter Billno</td>
                    <td class="style2">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txt_bilno" runat="server" CssClass="dottedTextBox" 
                            Width="160px" AutoPostBack="True" ontextchanged="txt_bilno_TextChanged"></asp:TextBox>
                         <asp:AutoCompleteExtender ID="txt_bilno_AutoCompleteExtender" runat="server" 
                                                CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="GetServiceCode" ServicePath="" 
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_bilno">
                                            </asp:AutoCompleteExtender>
                    
                       
                    </td>
                    <td>
                        Enter Customer Name</td>
                    <td class="style2">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtpartyname" runat="server" CssClass="dottedTextBox" 
                            Width="200px" AutoPostBack="True" ></asp:TextBox>
                      
                       
                      
                        <asp:AutoCompleteExtender ID="txtpartyname_AutoCompleteExtender" runat="server" 
                            CompletionListCssClass="AutoExtender" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList" 
                            Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetTagNames"  
                            TargetControlID="txtpartyname">
                        </asp:AutoCompleteExtender>
                      
                    </td>
                    <td class="style4">
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
                        &nbsp;</td>
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
