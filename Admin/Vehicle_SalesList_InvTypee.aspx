﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Vehicle_SalesList_InvTypee.aspx.cs" Inherits="Report_ProjectExpensesDetailsCodeDatewise" %>

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
                            Vehicle Sale List Datewise</h4>
                    </legend>

                    <table width="100%">
                        <tr>
                            <td align="center" valign="top" colspan="2">
                            </td>
                        </tr>
                         <tr>
                    <td align="center" colspan="2" valign="top">
                        &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
                </tr>
                         <tr>
                             <td align="right" valign="top" width="50%">
                                 Inv Type :</td>
                             <td align="left" valign="top">
                                 <asp:DropDownList ID="ddl_invtype" runat="server" AutoPostBack="True" 
                                     onselectedindexchanged="ddl_invtype_SelectedIndexChanged" Width="200px">
                                     <asp:ListItem>...Select...</asp:ListItem>
                                     <asp:ListItem>Tax Invoice</asp:ListItem>
                                     <asp:ListItem>Retail Invoice</asp:ListItem>
                                 </asp:DropDownList>
                             </td>
                         </tr>
                         <tr>
                             <td align="center" colspan="2" valign="top">
                                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                     CssClass="mGrid" Font-Names="Cambria" Font-Size="12px" Width="100%">
                                     <Columns>
                                         <asp:TemplateField HeaderText="SlNo">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                             </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Invoice Type">
                                             <ItemTemplate>
                                                 <asp:Label ID="lblmsino" runat="server" Text='<%# Eval("Vs_InvType") %>'></asp:Label>
                                             </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Left" />
                                             <ItemStyle HorizontalAlign="Left" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Party Name">
                                             <ItemTemplate>
                                                 <asp:Label ID="lblpartyname" runat="server" Text='<%# Eval("Mc_Name") %>'></asp:Label>
                                             </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Left" />
                                             <ItemStyle HorizontalAlign="Left" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Bill date">
                                             <ItemTemplate>
                                                 <asp:Label ID="lbldate" runat="server" 
                                                     Text='<%# Eval("Vs_Billdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                             </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Left" />
                                             <ItemStyle HorizontalAlign="Left" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Address">
                                             <ItemTemplate>
                                                 <asp:Label ID="lblpartyaddress" runat="server" text='<%# Eval("Mc_Address") %>'></asp:Label>
                                             </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Left" />
                                             <ItemStyle HorizontalAlign="Left" width="20%" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Phoneno">
                                             <ItemTemplate>
                                                 <asp:Label ID="lblphone" runat="server" text='<%# Eval("Mc_Mobileno") %>'></asp:Label>
                                             </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Left" />
                                             <ItemStyle HorizontalAlign="Left" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="View">
                                             <ItemTemplate>
                                                 <asp:ImageButton ID="imgbtnview" runat="server" 
                                                     ImageUrl="~/Admin/Icon/view.png" onclick="imgbtnview_Click" 
                                                     ToolTip='<%# Eval("Vs_Billno") %>' Width="25px" />
                                             </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Left" />
                                         </asp:TemplateField>
                                      <%--   <asp:TemplateField HeaderText="Delete">
                                             <ItemTemplate>
                                                 <asp:ImageButton ID="imgbtndelete" runat="server" 
                                                     ImageUrl="~/Admin/Images/Delete_Icon.png" onclick="imgbtndelete_Click" 
                                                     ToolTip='<%# Eval("Vs_Billno") %>' Width="25px" />
                                             </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Left" />
                                         </asp:TemplateField>--%>
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
