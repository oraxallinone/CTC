<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="JobCard_status.aspx.cs" Inherits="Admin_JobCard_status" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss06.css" rel="stylesheet" type="text/css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset id="FS_IssuedBook" runat="server">
                    <legend>
                        <h4>
                          Job Card Status Update</h4>
                    </legend>

                    <table width="100%">
                         <tr>
                    <td style="width: 16%">
                        Regd. No
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%">
                        <asp:TextBox ID="txt_regd" runat="server" CssClass="TextBoxGraiant" 
                            Width="130px"></asp:TextBox>
                        <asp:AutoCompleteExtender ID="txt_invoice_AutoCompleteExtender" runat="server" 
                                                CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="Getregd" ServicePath="" 
                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_regd">
                                            </asp:AutoCompleteExtender>
                    </td>

                     <td style="width: 16%">
                      
                    </td>
                    <td style="width: 1%">
                        :
                    </td>
                    <td style="width: 24%">
                       
                       
                    </td>
                    <td style="width: 16%">
                        <asp:Button ID="btn_Show" runat="server" CssClass="VerySmallGreen" 
                            Height="26px" OnClick="btn_Show_Click" Text="Show" Width="70px" />
                    </td>
                    <td style="width: 1%">
                        &nbsp;</td>
                    <td style="width: 24%">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                        <tr>
                            <td align="center" valign="top" colspan="7" class="style1">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                        </tr>
                         <tr>
                             <td align="center" colspan="7" valign="top">
                                 &nbsp;</td>
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
                                        <asp:TemplateField HeaderText="Job Card No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbljcno" runat="server" Text='<%# Eval("JC_No") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        
                                          <asp:TemplateField HeaderText="Regd. No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblregd" runat="server" 
                                                    text='<%# Eval("JC_Regno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" width="20%"/>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblidate" runat="server"  text='<%# Eval("JC_Date","{0:dd:MM:yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Engine No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblengineno" runat="server" Text='<%# Eval("JC_Engineno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmno" runat="server"  text='<%# Eval("Ms_Status") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                      <asp:TemplateField HeaderText="STATUS Update">
                                        <ItemTemplate>
                                   



                                            <asp:DropDownList  ID="drpstatus" runat="server" ToolTip='<%# Eval("JC_Regno") %>'   onselectedindexchanged="drpstatus_SelectedIndexChanged" AutoPostBack="true"       selectedValue='<%# Eval("Ms_Status") %>' >
                                          <asp:ListItem>OPEN</asp:ListItem>
                                          <asp:ListItem>CLOSE</asp:ListItem>
                                         
                                           
                                            </asp:DropDownList>
                                            
                                           
                                           
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" Width="50px"/>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="50px"/>
                                    </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
                                </asp:GridView>
                            </td>
                        </tr>
                        </table>
                        </fieldset>
</asp:Content>

