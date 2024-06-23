<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Master_ItemDetails.aspx.cs" Inherits="admin_EmployeeDetails" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <link href="SmitaStYlE/AutoCompleteExtenderCss01.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
    
            <div id="content" style="background-color: #FFFFFF">
              
                <fieldset>
                    <legend>
                        <h3>
                            Item List</h3>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td width="10%">
                                &nbsp;</td>
                            <td width="14%" align="right">
                                Type Part No. :</td>
                            <td width="20%" align="center" 
                                style="font-size: medium; color: #000000; font-weight: bold">
                                <asp:TextBox ID="txtInput" runat="server" Width="200px"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="txtInput_AutoCompleteExtender" runat="server" 
                                    CompletionListCssClass="autocomplete_completionListElement" 
                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" 
                                    CompletionListItemCssClass="autocomplete_listItem" DelimiterCharacters="" 
                                    Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetTagNames" 
                                    ServicePath="" TargetControlID="txtInput">
                                </asp:AutoCompleteExtender>
                            </td>
                            <td width="15%">
                                <asp:Button ID="btnsearch" runat="server" CssClass="thinCupersulphate" 
                                    onclick="btnsearch_Click" Text="Search" />
                           
                            </td>
                            <td>
                                &nbsp;
                                </td>
                        </tr>
                        <tr>
                            <td width="14%">
                                &nbsp;</td>
                            <td width="14%">
                                &nbsp;</td>
                            <td align="center" width="10%">
                                &nbsp;</td>
                            <td width="20%">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        </table>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                              PagerStyle-HorizontalAlign="Right"       Width="100%" Font-Names="Cambria" 
                                    Font-Size="12px" CssClass="mGrid" 
                                    AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging" 
                                    PageSize="250">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Code">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("itamcode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Part Number">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2p" runat="server" Text='<%# Eval("Pno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Category  Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("categoryname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Available">
                                            <ItemTemplate>
                                                <asp:Label ID="lblavilable" runat="server" Tooltip='<%# Eval("status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnview" runat="server" Height="20px" 
                                                    ImageUrl="~/Admin/Icon/view.png"
                                                    ToolTip='<%# Eval("itamcode") %>' onclick="imgbtnview_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnedit" runat="server" 
                                                    ImageUrl="~/Admin/Icon/Edit.jpg"
                                                    ToolTip='<%# Eval("itamcode") %>' Height="20px" 
                                                    onclick="imgbtnedit_Click"   />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtndelete" runat="server"  ToolTip='<%# Eval("itamcode") %>'
                                                    ImageUrl="~/Admin/Images/Delete_Icon.png" Width="25px" onclick="imgbtndelete_Click" 
                                                     />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
                                    <PagerSettings FirstPageText="First" LastPageText="Last" 
                                        Mode="NumericFirstLast" NextPageText="" Position="TopAndBottom" 
                                        PreviousPageText="" />
                                    <PagerStyle HorizontalAlign="Right" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>

                    </fieldset>
                    </div>



</ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

