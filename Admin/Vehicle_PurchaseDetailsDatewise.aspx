<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Vehicle_PurchaseDetailsDatewise.aspx.cs" Inherits="Report_ProjectExpensesDetailsCodeDatewise" %>

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
                            Vehicle Purchase List Datewise</h4>
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
                                        <asp:TemplateField HeaderText="Invoice No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmsino" runat="server" Text='<%# Eval("Vp_Invoiceno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Supplier Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblccode" runat="server" Text='<%# Eval("Ms_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bill date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldate" runat="server" 
                                                    Text='<%# Eval("Vp_Billdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpartyname" runat="server" 
                                                    text='<%# Eval("Vp_Address") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" width="20%"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Phoneno">
                                            <ItemTemplate>
                                                <asp:Label ID="lblphone" runat="server"  text='<%# Eval("Vp_Phno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View" >
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnview" runat="server" ToolTip='<%# Eval("Vpd_Id") %>'
                                                    ImageUrl="~/Admin/Icon/view.png" Width="25px" onclick="imgbtnview_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnedit" runat="server" ToolTip='<%# Eval("Vpd_Id") %>'
                                                    ImageUrl="~/Admin/Icon/Edit.jpg" Width="25px" onclick="imgbtnedit_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" >
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtndelete" runat="server" ToolTip='<%# Eval("Vpd_Id") %>'
                                                    ImageUrl="~/Admin/Images/Delete_Icon.png" Width="25px" onclick="imgbtndelete_Click" 
                                                    />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
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

