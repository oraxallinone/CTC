<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Vehicle_ReceiveTransferDetails.aspx.cs" Inherits="Report_ProjectExpensesDetailsCodeDatewise" %>

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
                            Vehicle Transfer Receive</h4>
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
                        <asp:CalendarExtender ID="txt_FromDate_CalendarExtender" runat="server" CssClass="orange"
                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_FromDate">
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
                        <asp:CalendarExtender ID="txt_ToDate_CalendarExtender" runat="server" CssClass="orange"
                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_ToDate">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        <asp:Button ID="btn_Show1" runat="server" CssClass="VerySmallGreen" 
                            Height="26px" OnClick="btn_Show_Click" Text="Show" Width="70px" />
                             </td>
                </tr>
                        <tr>
                            <td align="center" valign="top" colspan="7">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                        </tr>
                         <tr>
                             <td align="center" colspan="7" valign="top">
                                 &nbsp;</td>
                         </tr>
                        <tr>
                            <td align="center" valign="top" colspan="7">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                                    Width="100%" 
                                    CssClass="mGrid">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Billno">
                                            <ItemTemplate>
                                                <asp:Label ID="lblbillno" runat="server" Text='<%# Eval("Vpd_Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vehicle Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblvechiletype" runat="server" Text='<%# Eval("Mv_VehicleType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Model name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblmodelname" runat="server" Text='<%# Eval("mn") %>' 
                                                  ></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Chessis No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblchessisno" runat="server" 
                                                    text='<%# Eval("Vp_Chassisno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" width="100px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From Branch">
                                        <ItemTemplate>
                                          <asp:Label ID="lblfrombranch" runat="server" 
                                                    text='<%# Eval("St_FromBranch") %>'> </asp:Label>
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
                                      <asp:TemplateField HeaderText="Transfer Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltransferdt" runat="server" Text='<%# Eval("St_Transferdate","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                      
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
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
                                <asp:Button ID="btn_recive" runat="server" CssClass="VerySmallGreen" 
                                    Height="26px" OnClick="btn_recive_Click" Text="Receive" Width="70px" />
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

