<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Spare_EstimateEntryList.aspx.cs" Inherits="Report_ProjectExpensesDetailsCodeDatewise" %>

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

   
            <asp:Panel ID="Panel1" runat="server">
                <fieldset id="FS_IssuedBook" runat="server">
                    <legend>
                        <h4>
                            Spare Estimate Entry List</h4>
                    </legend>
                    <table width="100%">
                        <tr>
                            <td style="width: 16%">
                                From Date
                            </td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td style="width: 24%; position:relative;">
                                <asp:TextBox ID="txt_FromDate" runat="server" CssClass="TextBoxGraiantDate" Width="130px"></asp:TextBox>
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
                            <td style="width: 24%; position:relative;">
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
                            <td align="center" valign="top" colspan="7">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="7" valign="top">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top" colspan="7">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                                    Font-Names="Cambria" Font-Size="12px" CssClass="mGrid">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="50px"/>
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Estimate No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl001" runat="server" Text='<%# Eval("Sp_EstimationNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl002" runat="server" Text='<%# Eval("Sp_EstimationDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left"  Width="100px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl003" runat="server" Text='<%# Eval("Sp_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gross">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl004" runat="server" Text='<%# Eval("Sp_GrossAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"  Width="100px" />
                                            <ItemStyle HorizontalAlign="Left"  Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Discount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl005" runat="server" Text='<%# Eval("Sp_Discount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"  Width="100px" />
                                            <ItemStyle HorizontalAlign="Left"  Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GST AMU">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl006" runat="server" Text='<%# Eval("Sp_VatAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"  Width="100px" />
                                            <ItemStyle HorizontalAlign="Left"  Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl007" runat="server" Text='<%# Eval("Sp_TotalAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"  Width="100px" />
                                            <ItemStyle HorizontalAlign="Left"  Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnview" runat="server" ToolTip='<%# Eval("Sp_Id") %>' ImageUrl="~/Admin/Icon/view.png"
                                                    Width="22px" OnClick="imgbtnview_Click" CommandArgument='<%# Eval("Sp_EstimationNo") %>'/>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnedit" runat="server" ToolTip='<%# Eval("Sp_Id") %>' ImageUrl="~/Admin/Icon/Edit.jpg"
                                                    Width="22px" OnClick="imgbtnedit_Click"  CommandArgument='<%# Eval("Sp_EstimationNo") %>'/>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtndelete" runat="server" ToolTip='<%# Eval("Sp_Id") %>' CommandArgument='<%# Eval("Sp_EstimationNo") %>'
                                                    ImageUrl="~/Admin/Images/Delete_Icon.png" Width="22px" OnClick="imgbtndelete_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="Print">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtn_print" runat="server" ImageUrl="~/Admin/Images/file-print.png"
                                            OnClick="imgbtn_print_Click" ToolTip='<%# Eval("Sp_Id") %>' 
                                            CommandArgument='<%# Eval("Sp_EstimationNo") %>' Height="20px" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
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
       
</asp:Content>
