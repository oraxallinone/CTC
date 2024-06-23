<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="stockajustment_Report.aspx.cs" Inherits="Admin_stockajustment_Report" %>
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
    <script type="text/javascript">
        function AllowDecimalNumbersOnly(input, kbEvent) {
            var keyCode, keyChar;
            keyCode = kbEvent.keyCode;
            if (window.event)
                keyCode = kbEvent.keyCode; 	// IE
            else
                keyCode = kbEvent.which; 	//firefox		         
            if (keyCode == null) return true;
            // get character
            keyChar = String.fromCharCode(keyCode);
            var charSet = ".0123456789";
            // check valid chars
            if (charSet.indexOf(keyChar) != -1) return true;
            // control keys
            if (keyCode == null || keyCode == 0 || keyCode == 8 || keyCode == 9 || keyCode == 13 || keyCode == 27) return true;
            return false;
        }


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
   
       
      
   
<fieldset id="FS_IssuedBook" runat="server">
                    <legend>
                        <h4>
                            Sparepart Adjustment Report</h4>
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

                         <%--<tr>
                             <td style="width: 16%">
                               Part No</td>
                             <td style="width: 1%">
                                 &nbsp;</td>
                             <td style="width: 24%">
                                 <asp:TextBox ID="txt_partno" runat="server"></asp:TextBox></td>
                             <td style="width: 16%">
                               <asp:Button ID="Button1" runat="server" CssClass="VerySmallGreen" 
                            Height="26px" Text="Show" Width="70px" onclick="Button1_Click" /></td>
                             <td style="width: 1%">
                                 &nbsp;</td>
                             <td style="width: 24%">
                                 &nbsp;</td>
                             <td>
                                 &nbsp;</td>
                         </tr>--%>

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
        <br />
        <asp:Label ID="lbl_InvoiceType" runat="server" Font-Bold="True" 
            Font-Names="Cambria" Font-Size="16px">Sparepart Adjustment</asp:Label>
                                    
                                    </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                  <%--  From
                                    <asp:Label ID="lbl_from" runat="server"></asp:Label>
                                    &nbsp;To
                                    <asp:Label ID="lbl_to" runat="server"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                       Font-Names="Vani" Font-Size="12px" Width="100%" BorderColor="#44C767" 
                                        Font-Bold="True" ForeColor="Black">
                                        <Columns>
                                          <asp:TemplateField HeaderText="Sl. No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            </asp:TemplateField>
                                            

                                          
                                           <asp:TemplateField HeaderText="Part No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpartno" runat="server" Text='<%# Eval("Itm_Partno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Itm PartDescrption">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpartdescription" runat="server" 
                                                    Text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sale Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sale" runat="server" 
                                                    Text='<%# Eval("Ss_saleprice") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                      <%--  <asp:TemplateField HeaderText="Net Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnetquantity" runat="server" 
                                                    Text='<%# Eval("Ss_NetQuantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>--%>
                                        
                                               <asp:TemplateField HeaderText="AdJ Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="txt_adjustquntity"  runat="server"  Text='<%# Eval("SSA_Adjustquantity") %>'>></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            

                                            
                                               <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_date"  runat="server" Text='<%# Eval("Created_Date","{0:dd-MM-yyyy}") %>'> ></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            
                                             <%--<asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnedit" runat="server" 
                                                    ImageUrl="~/Admin/Icon/Edit.jpg"
                                                    ToolTip='<%# Eval("Itm_Partno") %>' Height="20px" 
                                                    onclick="imgbtnedit_Click"   />
                                                <asp:ImageButton ID="imgbtnupadte" runat="server" Height="20px" ToolTip='<%# Eval("Itm_Partno") %>'
                                                    ImageUrl="~/Admin/Images/UPDATE (1).png" onclick="imgbtnupadte_Click" 
                                                    Visible="False" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>--%>
                                        </Columns>
                                        <HeaderStyle Font-Names="Cambria" Font-Size="14px" Font-Bold="True" 
                                            BackColor="White" ForeColor="#CC0000" HorizontalAlign="Left" />
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
