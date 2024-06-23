<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Part_Tracking.aspx.cs" Inherits="Admin_Part_Tracking" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss06.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<table>
<tr style="height:8%;">
<td>Part Number</td>
<td>
<asp:TextBox ID="txt_part" runat="server" Width="150px" AutoPostBack="True" 
        ontextchanged="txt_part_TextChanged"></asp:TextBox>

       <asp:AutoCompleteExtender ID="txt_PartNo_AutoCompleteExtender" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetPartNo" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_part">
                                            </asp:AutoCompleteExtender>
</td>
<td colspan="2"></td>
</tr>
<tr style="height:1%;">
<td colspan="4"></td>

</tr>
 
<tr style="height:35%;">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
<td>
<div style="height:400px;overflow:scroll">
<asp:Label ID="lbl_per" Text="Purchase" runat="server"></asp:Label>
<asp:GridView ID="grd_pent" runat="server" AutoGenerateColumns="False" 
                          ShowFooter="true"  Width="100%"   BorderColor="#2778BF" 
        BorderStyle="Solid" border="1"
                            BorderWidth="2px" CellPadding="10" ForeColor="Black" GridLines="None" 
                            Height="80px" >
                            <Columns>
                              
                                <asp:TemplateField HeaderText="Date">
                            
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date" runat="server" Text='<%# Eval("Created_Date","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                               
                                   <asp:TemplateField HeaderText="V No">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_vno" runat="server" Text='<%# Eval("Sp_VoucherNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>


                                 <asp:TemplateField HeaderText="Qty">
                                  <FooterTemplate>
                                <asp:Label ID="lbl_ftwpentry" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                      </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_qty" runat="server" Text='<%# Eval("Ss_Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor= "White" Font-Bold="True" ForeColor="Black" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
</div>
                        </td>
                   
                   <td>
                   <div style="height:400px;overflow:scroll">
                         <asp:Label ID="Label5" Text="Service Issue Return" runat="server"></asp:Label>
<asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                         ShowFooter="true"    Width="50px"   BorderColor="#2778BF" BorderStyle="Solid" border="1"
                            BorderWidth="2px" CellPadding="10" ForeColor="Black" GridLines="None" 
                            Height="80px" >
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No.">
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date4" runat="server" Text='<%# Eval("SE_ReturnDate","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                               
                                   <asp:TemplateField HeaderText="Jc No">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_jno4" runat="server" Text='<%# Eval("JC_No") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>


                                 <asp:TemplateField HeaderText="Ret Qty">
                                  <FooterTemplate>
                                <asp:Label ID="lbl_ftwpseretry" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                      </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_ret4" runat="server" Text='<%# Eval("SR_returnquantity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor= "#2778BF" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        </div>
                        </td>


                        <td>
                        <div style="height:400px;overflow:scroll">
                         <asp:Label ID="Label1" Text="Counter Sale Return" runat="server"></asp:Label>
<asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                         ShowFooter="true"    Width="50px"   BorderColor="#2778BF" BorderStyle="Solid" border="1"
                            BorderWidth="2px" CellPadding="10" ForeColor="Black" GridLines="None" 
                            Height="80px" >
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No.">
                                    <ItemTemplate>
                                        <asp:Label ID="Label144" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date5" runat="server" Text='<%# Eval("Created_Date","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                               
                                   <asp:TemplateField HeaderText="Inv No">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_inv4" runat="server" Text='<%# Eval("Sp_InvoiceNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>


                                 <asp:TemplateField HeaderText="Ret Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_ret5" runat="server" Text='<%# Eval("Ss_ReturnQuantity") %>'></asp:Label>
                                    </ItemTemplate>
                                      <FooterTemplate>
                                <asp:Label ID="lbl_ftwpcounterslae1etry" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                      </FooterTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor= "#2778BF" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        </div>
                        </td>
    <td>
                        <div style="height:400px;overflow:scroll">
                         <asp:Label ID="Label8" Text="Purchase Return" runat="server"></asp:Label>
<asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" 
                         ShowFooter="true"    Width="50px"   BorderColor="#2778BF" BorderStyle="Solid" border="1"
                            BorderWidth="2px" CellPadding="10" ForeColor="Black" GridLines="None" 
                            Height="80px" >
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No.">
                                    <ItemTemplate>
                                        <asp:Label ID="Label144" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_datespr" runat="server" Text='<%# Eval("Purchase_ReturnDate","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                               

                                 <asp:TemplateField HeaderText="Ret Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_retspr" runat="server" Text='<%# Eval("Ss_Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                      <FooterTemplate>
                                <asp:Label ID="lbl_ftwpcounterslae1etryspr" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                      </FooterTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor= "#2778BF" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        </div>
                        </td>

     <td>
                        <div style="height:400px;overflow:scroll">
                         <asp:Label ID="Label9" Text="Stock In Transfer" runat="server"></asp:Label>
<asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="False" 
                         ShowFooter="true"    Width="50px"   BorderColor="#2778BF" BorderStyle="Solid" border="1"
                            BorderWidth="2px" CellPadding="10" ForeColor="Black" GridLines="None" 
                            Height="80px" >
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No.">
                                    <ItemTemplate>
                                        <asp:Label ID="Label144" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_datesin" runat="server" Text='<%# Eval("St_Transferdate","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                               

                                 <asp:TemplateField HeaderText="Ret Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_retsindsf" runat="server" Text='<%# Eval("St_TransferQuantity") %>'></asp:Label>
                                    </ItemTemplate>
                                      <FooterTemplate>
                                <asp:Label ID="lbl_ftwpcounterslae1etrysin" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                      </FooterTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="From Branch">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_frombrninda" runat="server" Text='<%# Eval("St_FromBranch") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor= "#2778BF" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        </div>
                        </td>

                        </tr>
                        <tr style="height:43%;">

                        <td>
                        <div style="height:400px;overflow:scroll">
                        <asp:Label ID="Label2" Text="Stock Out Transfer" runat="server"></asp:Label>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        ShowFooter="true"     Width="50px"   BorderColor="#2778BF" BorderStyle="Solid" border="1"
                            BorderWidth="2px" CellPadding="10" ForeColor="Black" GridLines="None" 
                            Height="80px" >
                            <Columns>
                              
                                
                                
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date1" runat="server" Text='<%# Eval("St_Transferdate","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                               
                                   <asp:TemplateField HeaderText="V No">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_vno1" runat="server" Text='<%# Eval("Voucher_No") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Branch">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_branch1" runat="server" Text='<%# Eval("St_ToBranch") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_qty1" runat="server" Text='<%# Eval("St_TransferQuantity") %>'></asp:Label>
                                    </ItemTemplate>
                                      <FooterTemplate>
                                <asp:Label ID="lbl_ftwpTransfer" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                      </FooterTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor= "White" Font-Bold="True" ForeColor="Black" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        </div>
                        </td>

                        <td>
                        <div style="height:400px;overflow:scroll">
                         <asp:Label ID="Label3" Text="Counter Sale" runat="server"></asp:Label>
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                           ShowFooter="true"  Width="50px"   BorderColor="#2778BF" BorderStyle="Solid" border="1"
                            BorderWidth="2px" CellPadding="10" ForeColor="Black" GridLines="None" 
                            Height="80px" >
                            <Columns>
                              
                                
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date2" runat="server" Text='<%# Eval("Created_Date","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                               
                                   <asp:TemplateField HeaderText="Invoice No">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_vno2" runat="server" Text='<%# Eval("Sp_InvoiceNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>


                                 <asp:TemplateField HeaderText="Qty">
                                 <FooterTemplate>
                                <asp:Label ID="lbl_ftwpcounterSaleetry" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                      </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_qty2" runat="server" Text='<%# Eval("Ss_Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor= "White" Font-Bold="True" ForeColor="Black" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        </div>
                        </td>

                        <td>
                        <div style="height:400px;overflow:scroll">
                         <asp:Label ID="Label4" Text="Spare Issue" runat="server" ></asp:Label>
<asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                        ShowFooter="true"     Width="50px"   BorderColor="#2778BF" BorderStyle="Solid" border="1"
                            BorderWidth="2px" CellPadding="10" ForeColor="Black" GridLines="None" 
                             >
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No.">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                    <ItemStyle HorizontalAlign="Left" Width="50px"/>
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date3" runat="server" Text='<%# Eval("Created_Date","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                               
                                   <asp:TemplateField HeaderText="JC No">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_jcno11" runat="server" Text='<%# Eval("JC_No") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>

                              
                                 <asp:TemplateField HeaderText="Qty">
                                 <FooterTemplate>
                                <asp:Label ID="lbl_ftwpIssueetry" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                      </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_qty11" runat="server" Text='<%# Eval("SE_Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor= "#2778BF" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        </div>
                        </td>







                            <td>
                        <div style="height:400px;overflow:scroll">
                         <asp:Label ID="Label6" Text="Stock Adjustment" runat="server" ></asp:Label>
<asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                        ShowFooter="true"     Width="50px"   BorderColor="#2778BF" BorderStyle="Solid" border="1"
                            BorderWidth="2px" CellPadding="10" ForeColor="Black" GridLines="None" 
                             >
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No.">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                    <ItemStyle HorizontalAlign="Left" Width="50px"/>
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_datestockadj" runat="server" Text='<%# Eval("Created_Date","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                               
                                 <asp:TemplateField HeaderText="Qty">
                                 <FooterTemplate>
                                <asp:Label ID="lbl_ftwpIssueetrystockadj" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                      </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_qty11stockadj" runat="server" Text='<%# Eval("SSA_Adjustquantity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor= "#2778BF" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        </div>
                        </td>
                             <td>
                        <div style="height:400px;overflow:scroll">
                         <asp:Label ID="Label7" Text="Open Stock" runat="server" ></asp:Label>
<asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
                        ShowFooter="true"     Width="50px"   BorderColor="#2778BF" BorderStyle="Solid" border="1"
                            BorderWidth="2px" CellPadding="10" ForeColor="Black" GridLines="None" 
                             >
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No.">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                    <ItemStyle HorizontalAlign="Left" Width="50px"/>
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_dateos" runat="server" Text='<%# Eval("Created_Date","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                               
                                 <asp:TemplateField HeaderText="Qty">
                                 <FooterTemplate>
                                <asp:Label ID="lbl_ftwpIssueetryos" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                                      </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_qty11stockadj" runat="server" Text='<%# Eval("Ss_Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor= "#2778BF" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        </div>
                        </td>

                        

                        <%--<td>
                        <div style="height:400px;overflow:scroll">
                         <asp:Label ID="Label6" Text="Purchase Return" runat="server"></asp:Label>
<asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                            Width="50px"   BorderColor="#2778BF" BorderStyle="Solid" border="1"
                            BorderWidth="2px" CellPadding="10" ForeColor="Black" GridLines="None" 
                            Height="80px" >
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No.">
                                    <ItemTemplate>
                                        <asp:Label ID="Label154" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_date6" runat="server" Text='<%# Eval("Created_Date","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                               
                                   <asp:TemplateField HeaderText="Inv No">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_inv6" runat="server" Text='<%# Eval("Sp_InvoiceNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>


                                 <asp:TemplateField HeaderText="Ret Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_ret6" runat="server" Text='<%# Eval("Ss_ReturnQuantity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor= "#2778BF" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        </div>
                        </td>--%>
</tr>

</table>
<table>

<tr>
<td>Purchase</td>
<td>:</td>
<td><asp:Label ID="lbl_pshow" runat="server"></asp:Label></td>


</tr>

<tr>
<td>Service Isuue Return</td>
<td>:</td>
<td><asp:Label ID="lbl_serissret" runat="server"></asp:Label></td>


</tr>



<tr>
<td>Counter Sale Return</td>
<td>:</td>
<td><asp:Label ID="lbl_cousealret" runat="server"></asp:Label></td>


</tr>

<tr>
<td>STOCK OUT TRANSFER</td>
<td>:</td>
<td><asp:Label ID="lbl_stocktrans" runat="server"></asp:Label></td>


</tr>

<tr>
<td>COUNTER SALE</td>
<td>:</td>
<td><asp:Label ID="lbl_countersale" runat="server"></asp:Label></td>


</tr>

<tr>
<td>SPARE ISSUE</td>
<td>:</td>
<td><asp:Label ID="lbl_spareissue" runat="server"></asp:Label></td>


</tr>

<%--<tr>
<td>Stock Adj</td>
<td>:</td>
<td><asp:Label ID="lbl_stockadj" runat="server"></asp:Label></td>


</tr>--%>

<tr>
<td>Available Stock</td>
<td>:</td>
<td><asp:Label ID="lbl_stock" runat="server"></asp:Label></td>


</tr>

</table>
</div>
</asp:Content>

