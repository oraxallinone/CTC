<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Report_Service_JobCardRegister.aspx.cs" Inherits="Report_ProjectExpensesDetailsCodeDatewise" %>

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
  <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
   
       
      
   
<fieldset id="FS_IssuedBook" runat="server">
                    <legend>
                        <h4>
                            JobCard Register</h4>
                    </legend>

                    <table width="100%">
                         <tr>
                    <td style="width: 16%">
                        From Date
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%; position:relative">
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
                    <td style="width: 24%; position:relative">
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
                             <td style="width: 16%">
                                 &nbsp;</td>
                             <td style="width: 1%">
                                 &nbsp;</td>
                             <td style="width: 24%">
                                 &nbsp;</td>
                             <td style="width: 16%">
                                 &nbsp;</td>
                             <td style="width: 1%">
                                 &nbsp;</td>
                             <td style="width: 24%">
                                 &nbsp;</td>
                             <td>
                                 &nbsp;</td>
                         </tr>
                        </table>

                         <asp:Panel ID="Panel1" runat="server">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                </td>
                            </tr>
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
            Font-Names="Cambria" Font-Size="16px">JOB CARD REGISTER</asp:Label>
                                    
                                    </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    From
                                    <asp:Label ID="lbl_from" runat="server"></asp:Label>
                                    &nbsp;To
                                    <asp:Label ID="lbl_to" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                       Font-Names="Cambria" Font-Size="12px" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SlNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="JC Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbljcnumber" runat="server" text='<%# Eval("JC_No") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" width="10%" />
                                            </asp:TemplateField>








                                            <asp:TemplateField HeaderText="Job Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblestno" runat="server" 
                                                        Text='<%# Eval("JC_Date","{0:dd:MM:yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Service Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsertype" runat="server" text='<%# Eval("JC_ServiceType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" width="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Registration No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpartyname" runat="server" text='<%# Eval("JC_Regno") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" width="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Model Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblccode" runat="server" Text='<%# Eval("Mv_ModelName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Engineno">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblengno" runat="server" text='<%# Eval("JC_Engineno") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Mc_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobile" runat="server" text='<%# Eval("Mc_Mobileno") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle Font-Names="Cambria" Font-Size="14px" Font-Bold="True" 
                                            Font-Italic="True" Font-Strikeout="False" Font-Underline="False" />
                                    </asp:GridView>
                                </td>
                            </tr>
                    </table>
                         </asp:Panel>
                        </fieldset>
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
                                    onclick="btn_excel_Click" Text="Download To Excel" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                &nbsp;</td>
                        </tr>
                    </table>
                 <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
</asp:Content>

