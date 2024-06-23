<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Update_SalesPrice.aspx.cs" Inherits="Admin_Update_SalesPrice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="SmitaStYlE/Calender/red.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss06.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">




    <table width="100%">
        <tr>
            <td style="height:100px;" > &nbsp;</td>
        </tr>
        <tr>
            <td>
                Enter Part Number: <asp:TextBox ID="txt_Partnumber" runat="server" AutoPostBack="true" OnTextChanged="txt_Partnumber_TextChanged"></asp:TextBox>


                 <asp:AutoCompleteExtender ID="txt_PartNo_AutoCompleteExtender" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetPartNo" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txt_Partnumber">
                                            </asp:AutoCompleteExtender>










            </td>
            <td>
                <asp:TextBox ID="txt_saleprice" placeholder="Enter Sale Price" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btn_update" runat="server" Text="Update sale price In All Branch" OnClick="btn_update_Click"
                    OnClientClick="return confirm('Are you sure... you want to Update this Item?');" /> 
            </td>
        </tr>
        <tr>
            <td colspan="5"> &nbsp;</td>
        </tr>

        <tr>
            <td colspan="5">

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
                                        <asp:TemplateField HeaderText="Part NUmber">
                                            <ItemTemplate>
                                                <asp:Label ID="lbljcno" runat="server" Text='<%# Eval("Itm_Partno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        
                                          <asp:TemplateField HeaderText="Part Descrption">
                                            <ItemTemplate>
                                                <asp:Label ID="lblservicecode" runat="server" 
                                                    text='<%# Eval("Itm_PartDescrption") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Purchase Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldescription" runat="server" Text='<%# Eval("Itm_PurchasePrice") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                           
                                        <asp:TemplateField HeaderText="Sale Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldescription12" runat="server" Text='<%# Eval("Itm_SalePrice") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Branch Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblquantity212121" runat="server"  text='<%# Eval("Branch_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                       
                                        
                                        

                                   
                                       
                                    </Columns>
                                    <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
                                </asp:GridView>

            </td>
        </tr>
    </table>
     <hr />
    <div style="background-color:blue;height:10Px;width:100%">

    </div>

    <hr />

    <table width="100%">
        <tr>
            <td colspan="5">
               <h1>: : Update Description Branch Wise: :</h1> 
            </td>
        </tr>
        <tr>

            <td colspan="3">
                Enter partnumber : <asp:TextBox ID="txtpartnum2" runat="server" OnTextChanged="txtpartnum2_TextChanged"  AutoPostBack="true"></asp:TextBox>
                  <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetPartNo2" ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True"
                                                TargetControlID="txtpartnum2">
                                            </asp:AutoCompleteExtender>
            </td>
        </tr>

        <tr><td colspan="3">&nbsp</td></tr>


        <tr>
            <td colspan="2">
                Part Number:<asp:Label ID="lblpnumber" runat="server" ForeColor="Red"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                description: <asp:TextBox ID="partdestxt" runat="server" Width="400px" ></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                Branch:<asp:Label ID="lblBranch" runat="server"  ForeColor="Red"></asp:Label>
            </td>
            
            <td>
                <asp:Button ID="btnupdatedescription" runat="server" Text="Update Description" OnClick="btnupdatedescription_Click"  />
            </td>

        </tr>
    </table>























    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>



</asp:Content>

