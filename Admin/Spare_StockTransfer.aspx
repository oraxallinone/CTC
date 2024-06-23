<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Spare_StockTransfer.aspx.cs" Inherits="Admin_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss06.css" rel="stylesheet" type="text/css" />
     <link href="SmitaStYlE/Calender/red.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
   
   
 <fieldset style="padding-right: 20px;">
                    <legend>
                        <h3>
                            Spare Stock Transfer</h3>
                    </legend>
<table width="100%">
<tr>
<td width="25%" align="center">
    From Branch</td>
<td width="2%" class="style2">
    :</td>
  <td align="left">
      <asp:DropDownList ID="ddlfrombranch" runat="server" Width="200px" 
        >
     
      </asp:DropDownList>
    </td>
<td width="2%">
    &nbsp;</td>
<td align="center" width="15%">
    To Branch</td>
<td width="2%">
    :</td>
  <td  align="left">
      <asp:DropDownList ID="ddltobranch" runat="server" Width="200px">
      </asp:DropDownList>
    </td>
<td width="20%">
    &nbsp;</td>
</tr>


<tr>
<td  align="center">
    Part Number</td>
<td width="2%">
    :</td>
  <td align="left" style="position:relative;">
      <asp:TextBox ID="txt_PartNo" runat="server" AutoPostBack="True" 
          CssClass="dottedTextBox" Height="25px" OnTextChanged="txt_PartNo_TextChanged" 
          Width="200px"></asp:TextBox>
      <asp:AutoCompleteExtender ID="txt_PartNo_AutoCompleteExtender" runat="server" 
          CompletionListCssClass="AutoExtender" 
          CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
          CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
          EnableCaching="False" Enabled="True" MinimumPrefixLength="1" 
          ServiceMethod="GetPartNo" ServicePath="" 
          ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txt_PartNo">
      </asp:AutoCompleteExtender>
    </td>
<td width="25%">
    </td>
<td align="center">
    Part Description</td>
<td width="2%">
    :</td>
  <td width="25%" align="left">
      <asp:Label ID="lblpartdescription" runat="server"></asp:Label>
    </td>
<td width="2%">
    &nbsp;</td>
</tr>


    <tr>
        <td align="center" width="25%">
            Avl &nbsp; Quantity
        </td>
        <td width="2%">
            :</td>
        <td align="left">
            <asp:Label ID="lblquantity" runat="server"></asp:Label>
        </td>
        <td width="2%">
            &nbsp;</td>
        <td align="center" width="25%">
            Transfer Quantity</td>
        <td width="2%">
            &nbsp;</td>
        <td align="left" width="25%">
            <asp:TextBox ID="txttransferquantity" runat="server" Width="50px" 
               CssClass="dottedTextBox" AutoPostBack="True" >0</asp:TextBox>
        </td>
        <td width="20%">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" width="25%">
            Transfer Date</td>
        <td width="2%">
            :</td>
        <td align="left" style="position:relative;">
            <asp:TextBox ID="txtdate" runat="server" CssClass="TextBoxGraiantDate" 
                Width="200px"></asp:TextBox>
          
            <asp:CalendarExtender ID="txtdate_CalendarExtender" runat="server" 
                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtdate" CssClass="orange">
            </asp:CalendarExtender>
          
        </td>
        <td width="2%">
            &nbsp;</td>
        <td align="center" width="25%">
            &nbsp;</td>
        <td width="2%">
            &nbsp;</td>
        <td align="left" width="25%">
            &nbsp;</td>
        <td width="20%">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" width="25%">
            &nbsp;</td>
        <td class="style1" width="2%">
        </td>
        <td align="left" class="style1">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </td>
        <td width="2%">
        </td>
        <td align="right" width="25%">
            <asp:Button ID="btn_Show" runat="server" CssClass="VerySmallGreen" 
                Height="26px" OnClick="btn_Show_Click" Text="ADD" Width="70px" />
        </td>
        <td width="2%">
        </td>
        <td align="right" width="25%">
            &nbsp;</td>
        <td width="20%">
        </td>
    </tr>


    <tr>
        <td align="right" colspan="8">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                CssClass="mGrid">
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:TemplateField HeaderText="SlNo">
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Width="40px" />
                        <ItemStyle HorizontalAlign="Left" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PartNumber">
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("partno") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Width="150px" />
                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PartDescription">
                        <ItemTemplate>
                            <asp:Label ID="Label12" runat="server" Text='<%# Eval("partdescr") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Width="150px" />
                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Width="80px" />
                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                    </asp:TemplateField>
                 
                 
                 
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtn_PartDelete" runat="server" Height="18px" 
                                ImageUrl="~/Admin/Images/Delete_Icon.png" OnClick="imgbtn_PartDelete_Click" 
                                ToolTip='<%# Eval("partno") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="40px" />
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="pgr" />
            </asp:GridView>
        </td>
    </tr>


    <tr>
        <td align="center" colspan="7">
            <asp:Button ID="btn_Save" runat="server" CssClass="thinGreen" 
                OnClick="btn_assign_Click" Text="Save" Width="150px" />
        </td>
        <td width="2%">
            &nbsp;</td>
    </tr>


</table>
    </fieldset>
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

