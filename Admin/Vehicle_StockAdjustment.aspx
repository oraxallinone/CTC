<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Vehicle_StockAdjustment.aspx.cs" Inherits="Admin_Vehicle_StockAdjustment" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
        .style2
        {
            height: 47px;
        }
    </style>
    <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss06.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lbl_Header" runat="server" CssClass="Header1" Text="Present NET Stock Report"></asp:Label>
    <fieldset>
        <legend>
            <h5>
                Vehicle Stock Adjustment</h5>
        </legend>
        <table width="100%">
            <tr>
                <td colspan="8">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
            </tr>
            <tr>
                <td width="3%" class="style2">
                    &nbsp;
                </td>
                <td width="20%" class="style2">
                    Select Vehicle Type
                </td>
                <td width="2%" class="style2">
                    :
                </td>
                <td width="25%" class="style2">
                    <asp:DropDownList ID="ddl_VType" runat="server" AutoPostBack="True" CssClass="SmalldottedTextBox"
                        Height="26px" OnSelectedIndexChanged="ddl_VType_SelectedIndexChanged" Width="160px">
                        <asp:ListItem>...Select...</asp:ListItem>
                        <asp:ListItem>HCV</asp:ListItem>
                        <asp:ListItem>LCV</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td width="3%" class="style2">
                    &nbsp;
                </td>
                <td width="20%" class="style2">
                    Select Model Name
                </td>
                <td width="2%" class="style2">
                    :
                </td>
                <td width="25%" class="style2">
                    <asp:DropDownList ID="ddl_Modelname" runat="server" AutoPostBack="True" CssClass="SmalldottedTextBox"
                        Height="26px" Width="160px" 
                        onselectedindexchanged="ddl_Modelname_SelectedIndexChanged">
                       
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="3%" class="style1">
                    &nbsp;
                </td>
                <td width="20%" class="style1">
                    Enter Chessis No
                </td>
                <td width="2%" class="style1">
                    &nbsp;
                </td>
                <td width="25%" class="style1">
                    <asp:TextBox ID="txtchessisno" runat="server" Width="170px" 
                       ></asp:TextBox>
                    <asp:AutoCompleteExtender ID="txtchessisno_AutoCompleteExtender" runat="server" 
                       CompletionListCssClass="AutoExtender" 
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
                                                ServiceMethod="GetServiceCode" ServicePath="" 
                                                ShowOnlyCurrentWordInCompletionListItem="True" 
                        TargetControlID="txtchessisno">
                    </asp:AutoCompleteExtender>
                
                </td>
                <td width="3%" class="style1">
                    &nbsp;
                </td>
                <td width="20%" class="style1">
                    &nbsp;
                </td>
                <td width="2%" class="style1">
                    &nbsp;
                </td>
                <td width="25%" class="style1">
                    <asp:Button ID="btn_show" runat="server" CssClass="thinCupersulphate" 
                        Text="Show" onclick="btn_show_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="8">
                   
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                        Width="100%">
                        <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Vehicle Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblbillno" runat="server" Text='<%# Eval("billno") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vehicle Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblvechiletype" runat="server" Text='<%# Eval("vehicletype") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Model Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblmodelname" runat="server" Text='<%# Eval("modelname") %>'
                                   ToolTip='<%# Eval("mid") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Chessis NO">
                                <ItemTemplate>
                                    <asp:Label ID="lblchessisno" runat="server" Text='<%# Eval("chessisno") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Engine No ">
                                <ItemTemplate>
                                    <asp:Label ID="lblengineno" runat="server" Text='<%# Eval("engineno") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Rate">
                                <ItemTemplate>
                                    <asp:Label ID="lblrate" runat="server" Text='<%# Eval("rate") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Net Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtnetquantity" runat="server" Text='<%# Eval("quantity") %>'
                                    ToolTip='<%# Eval("quantity") %>' ReadOnly="True">
                                    </asp:TextBox>
                                  
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtn_edit" runat="server" onclick="imgbtn_edit_Click"  
                                        ToolTip='<%# Eval("chessisno") %>' ImageUrl="~/Admin/Icon/Edit.jpg" 
                                        Width="25px"/>
                                    <asp:ImageButton ID="imgbtn_save" runat="server" 
                                        ImageUrl="~/Admin/Icon/Save-icon.png" Visible="False" 
                                        ToolTip='<%# Eval("chessisno") %>' Width="20px" onclick="imgbtn_save_Click" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
                        <PagerStyle CssClass="pgr" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
