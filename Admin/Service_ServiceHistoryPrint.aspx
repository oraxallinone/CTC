<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Service_ServiceHistoryPrint.aspx.cs" Inherits="Admin_Form21" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
  
<center>
    <table style="width:210mm;">

<tr>
<td align="center" 
        colspan="6" height="80px" dir="ltr">
        <h2>RASHMI MOTORS</h2>
    <asp:Label ID="lblbranchaddress" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblemail" runat="server"></asp:Label>
    ,<asp:Label ID="lblphno" runat="server"></asp:Label>
        <br />
        TIN No-<asp:Label ID="lbltinno" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="20px" 
            Text="VEHICLE HISTORY CARD"></asp:Label>
    </td>
</tr>
        <tr>
            <td align="left" 
                
                style="border-top-style: dotted; border-width: thin; border-color: #000000" 
                height="12px">
                PARTY NAME</td>
            <td align="left" 
                width="2%" 
                
                style="border-top-style: dotted; border-width: thin; border-color: #000000" 
                class="style1">
                :</td>
            <td align="left" 
                width="20%" 
                
                style="border-top-style: dotted; border-width: thin; border-color: #000000" 
                class="style1">
                <asp:Label ID="lblpartyname" runat="server"></asp:Label>
            </td>
            <td align="left" 
                style="border-top-style: dotted; border-width: thin; border-color: #000000" 
                width="20%" class="style1">
                MODEL</td>
            <td align="left" class="style1" 
                
                style="border-top-style: dotted; border-width: thin; border-color: #000000" 
                width="2%">
                :</td>
            <td align="left" 
                style="border-top-style: dotted; border-width: thin; border-color: #000000" 
                width="10%" class="style1">
                <asp:Label ID="lblmodel" runat="server" Width="250px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" width="10%" dir="ltr" height="12px">
                ADDRESS</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" width="20%">
                <asp:Label ID="lbladdress" runat="server"></asp:Label>
            </td>
            <td align="left">
                ENGINE . NO.</td>
            <td align="left">
                :</td>
            <td align="left" width="10%">
                <asp:Label ID="lblengno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" width="10%" height="12px">
                REG NO</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" class="style1" width="20%">
                <asp:Label ID="lblregno" runat="server"></asp:Label>
            </td>
            <td align="left" class="style1">
                CHASIS NO</td>
            <td align="left">
                :</td>
            <td align="left">
                <asp:Label ID="lblchessno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
            <td align="left" width="10%" height="20px">
                Date Of Sale</td>
            <td align="left" width="2%">
                :</td>
            <td align="left" width="20%">
                <asp:Label ID="lbldateofsale" runat="server"></asp:Label>
            </td>
            <td align="left" colspan="2">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr style="border-bottom-style: dashed; border-bottom-width: thin; border-bottom-color: #000000">
            <td align="left" width="10%" height="20px">
                &nbsp;</td>
            <td align="left" width="2%">
                &nbsp;</td>
            <td align="left" width="20%">
                &nbsp;</td>
            <td align="left" colspan="2">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" 
                width="100%" colspan="6" 
                style="font-size: medium; color: #000000; font-weight: bold;" 
                height="12px" valign="top">
                <asp:GridView ID="grd_spare" runat="server" AutoGenerateColumns="False" 
                    Font-Bold="True" Font-Size="10px" Width="100%">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:TemplateField HeaderText="SlNo">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job Date">
                            <ItemTemplate>
                                <asp:Label ID="lbljdate" runat="server" 
                                    Text='<%# Eval("JC_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="JobNumber">
                            <ItemTemplate>
                                <asp:Label ID="lbljno" runat="server" Text='<%# Eval("JC_No") %>' ToolTip='<%# Eval("userrank") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bill No">
                            <ItemTemplate>
                                <asp:Label ID="lblbillno" runat="server" Text='<%# Eval("billno") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kill Ms">
                            <ItemTemplate>
                                <asp:Label ID="lblkillms" runat="server" Text='<%# Eval("JC_Kmcovered") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part No">
                            <ItemTemplate>
                                <asp:Label ID="lblpartno" runat="server" Text='<%# Eval("Itm_Partno") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Description">
                            <ItemTemplate>
                                <asp:Label ID="lblprtdesc" runat="server" 
                                    Text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:TemplateField>
                       
                    </Columns>
                    <HeaderStyle Font-Size="12px" Font-Names="Vani" />
                    <PagerStyle CssClass="pgr" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
        <td colspan="6">
        </td>
        </tr>
        <tr>
        <td colspan="6" align="left">
            <strong style="font-size:16px;">Service Head</strong></td>
        </tr>
        <tr>
            <td align="left" 
                width="100%" colspan="6" 
                style="font-size: medium; color: #000000; font-weight: bold;" 
                height="12px" valign="top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    Font-Bold="True" Font-Size="10px" Width="100%">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:TemplateField HeaderText="SlNo">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sn" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                        </asp:TemplateField>
                       

                         <asp:TemplateField HeaderText="Jc Number">
                            <ItemTemplate>
                                <asp:Label ID="JC_No" runat="server" Text='<%# Eval("JC_No") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>


                          <asp:TemplateField HeaderText="Jc Year">
                            <ItemTemplate>
                                <asp:Label ID="JC_No" runat="server" Text='<%# Eval("Jc_year") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>

                        

                        <asp:TemplateField HeaderText="Service Head">
                            <ItemTemplate>
                                <asp:Label ID="JCS_Servicecode" runat="server" Text='<%# Eval("JCS_Servicecode") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Service Description">
                            <ItemTemplate>
                                <asp:Label ID="JCS_Description" runat="server" Text='<%# Eval("JCS_Description") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Service Amount">
                            <ItemTemplate>
                                <asp:Label ID="JCS_Amount" runat="server" Text='<%# Eval("JCS_Amount") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="JCS_Quantity" runat="server" Text='<%# Eval("JCS_Quantity") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="Created_Date" runat="server" Text='<%# Eval("Created_Date") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                       
                    </Columns>
                    <HeaderStyle Font-Size="12px" Font-Names="Vani" />
                    <PagerStyle CssClass="pgr" />
                </asp:GridView>
            </td>
        </tr>
</table>
</center>
  </asp:Panel>
  <center>
   <table width="210mm">
                        <tr>
                            <td align="left" valign="top" >
                                    &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" >
                                    &nbsp;</td>
                        </tr>
                     <%--   <tr>
                            <td align="left" valign="top" style="font-size: medium; font-weight: bold" >
                                    For Rashmi Motors</td>
                        </tr>--%>
                        <tr>
                            <td align="left" valign="top" style="font-size: medium; font-weight: bold" >
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
</center>
</asp:Content>

