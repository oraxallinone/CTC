<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Service_Jobcard_SearchRegnoOutServiceList.aspx.cs" Inherits="admin_EmployeeDetails" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <link href="SmitaStYlE/AutoCompleteExtenderCss01.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
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
                            JobCard Outside Service List</h3>
                    </legend>
                    <table style="width: 100%;">
                         <tr>
                            <td align="right" colspan="2">
                                Enter&nbsp;Vehicle&nbsp; Reg No. :</td>
                            <td width="20%" align="center" 
                                style="font-size: medium; color: #000000; position:relative;font-weight: bold">
                                <asp:TextBox ID="txtInput" runat="server" Width="200px"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="txtInput_AutoCompleteExtender" runat="server" 
                                    CompletionListCssClass="AutoExtender" 
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                    CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                    Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetPartNo" 
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
                                    Width="100%" Font-Names="Cambria" Font-Size="12px" CssClass="mGrid" 
                                    ShowFooter="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Jobcard No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbljcno" runat="server" Text='<%# Eval("JC_No") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="JobCard Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbljcdate" runat="server" Text='<%# Eval("JCO_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Party  Name">
                                        <ItemTemplate>
                                                <asp:Label ID="lblpartyname" runat="server" Text='<%# Eval("Ms_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Amount">
                                             <FooterTemplate>
                                                 <asp:Label ID="lbltotal" runat="server" Font-Bold="True" Font-Size="15px" 
                                                     ForeColor="Red"></asp:Label>
                                             </FooterTemplate>
                                            <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%# Eval("JCO_Amount") %>'></asp:Label>
                                             
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Service Details">
                                            <ItemTemplate>
                                            <asp:Label ID="lbldetails" runat="server"   Text='<%# Eval("JCO_ServiceDetails") %>'></asp:Label>
                                               
        
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtndelete" runat="server"  ToolTip='<%# Eval("JCO_Id") %>'
                                                    ImageUrl="~/Admin/Images/Delete_Icon.png" Width="25px" onclick="imgbtndelete_Click" 
                                                     />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
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

