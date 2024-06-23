<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Service_ServiceHistory.aspx.cs" Inherits="Report_ProjectExpensesDetailsCodeDatewise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
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
         .style2
         {
             height: 23px;
         }
         </style>
     <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss06.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
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
                            Service History</h4>
                    </legend>

                    <table width="100%">
                         <tr>
                    <td align="right" valign="top" width="20%" style="position:relative">
                        Enter Enginee No</td>
                             <td align="left" valign="top" style="position:relative">
                                 <asp:TextBox ID="txtnginee" runat="server"></asp:TextBox>
                                 <asp:AutoCompleteExtender ID="txtnginee_AutoCompleteExtender" runat="server" 
                                     CompletionListCssClass="AutoExtender" 
                                     CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                     CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                     EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                     ServiceMethod="GetEnginee" ServicePath="" 
                                     ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txtnginee">
                                 </asp:AutoCompleteExtender>
                             </td>
                             <td align="left" style="width: 12%" valign="top" width="25%">
                                 <asp:Button ID="btn_Showengn" runat="server" CssClass="VerySmallGreen" 
                                     Height="26px" OnClick="btn_Showengn_Click" Text="Show" Width="70px" />
                             </td>
                             <td align="right" style="width: 12%" valign="top" width="25%">
                                 Enter Vehicle No</td>
                             <td align="left" valign="top" width="25%" style="position:relative">
                                 <asp:TextBox ID="txtregst" runat="server"></asp:TextBox>
                                 <asp:AutoCompleteExtender ID="txtregst_AutoCompleteExtender" runat="server" 
                                    CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="GetServiceCode" ServicePath="" 
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txtregst">
                                 </asp:AutoCompleteExtender>
                                   
                             </td>
                             <td align="left" valign="top">
                                 <asp:Button ID="btn_Show2" runat="server" CssClass="VerySmallGreen" 
                                     Height="26px" OnClick="btn_Show_Click" Text="Show" Width="70px" />
                             </td>
                </tr>
                         <tr>
                             <td align="center" colspan="6" valign="top" class="style1">
                                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                                 </asp:ScriptManager>
                             </td>
                         </tr>
                         <tr>
                             <td align="center" colspan="6" valign="top">
                                 &nbsp;</td>
                         </tr>
                        <tr>
                            <td align="center" valign="top" colspan="6">
                                &nbsp;</td>
                        </tr>
                        </table>
                        </fieldset>
                         </asp:Panel>
                    <table width="100%">
                        <tr>
                            <td align="center" valign="top">
                            <asp:Panel ID="display" runat="server">
                                    <table style="width: 100%;" runat="server" id="tbldetails">
                                        <tr>
                                            <td align="right" width="50%">
                                                Owner Name</td>
                                            <td align="left" width="2%">
                                                :</td>
                                            <td align="left">
                                                <asp:Label ID="lblownername" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style2">
                                                Model No</td>
                                            <td align="left" class="style2">
                                                :</td>
                                            <td align="left" class="style2">
                                                <asp:Label ID="lblmodelno" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Chasssis No</td>
                                            <td align="left">
                                                :</td>
                                            <td align="left">
                                                <asp:Label ID="lblchessisno" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Engine No</td>
                                            <td align="left">
                                                :</td>
                                            <td align="left">
                                                <asp:Label ID="lblengineno" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <asp:Button ID="btn_show" runat="server" CssClass="btn-info" Font-Bold="True" 
                                    Font-Names="US" Text="Show Details" 
                                    onclick="btn_show_Click" />
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

