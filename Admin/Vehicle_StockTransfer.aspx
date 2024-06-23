<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Vehicle_StockTransfer.aspx.cs" Inherits="Admin_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
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
                            Vehicle Stock Transfer</h3>
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
    Vehicle Type</td>
<td width="2%">
    :</td>
  <td align="left">
      <asp:DropDownList ID="ddl_VType" runat="server" AutoPostBack="True" 
          CssClass="SmalldottedTextBox" Height="26px" 
          onselectedindexchanged="ddl_VType_SelectedIndexChanged" Width="200px">
          <asp:ListItem>...Select...</asp:ListItem>
          <asp:ListItem>HCV</asp:ListItem>
          <asp:ListItem>LCV</asp:ListItem>
      </asp:DropDownList>
    </td>
<td width="25%">
    </td>
<td align="center">
    Model Name</td>
<td width="2%">
    :</td>
  <td width="25%" align="left">
      <asp:DropDownList ID="ddlmodelname" runat="server" 
          onselectedindexchanged="ddlmodelname_SelectedIndexChanged" Width="200px" 
          AutoPostBack="True">
      </asp:DropDownList>
    </td>
<td width="2%">
    &nbsp;</td>
</tr>


<tr>
<td width="25%" align="center">
    Chessis No</td>
<td width="2%">
    :</td>
  <td align="left">
      <asp:DropDownList ID="ddlchessisno" runat="server" 
          Width="200px" AutoPostBack="True" 
          onselectedindexchanged="ddlchessisno_SelectedIndexChanged" >
      </asp:DropDownList>

      
         </td>
<td width="2%">
    </td>
<td align="center">
    Date</td>
<td width="2%">
    :</td>
  <td align="left" valign="top">
                              <asp:TextBox ID="txt_transferdate" runat="server" CssClass="TextBoxGraiantDate" 
                                  Height="25px" Width="200px"></asp:TextBox>
                              <asp:CalendarExtender ID="txt_transferdate_CalendarExtender" runat="server" 
                                  Enabled="True" TargetControlID="txt_transferdate" CssClass="orange" 
                                  Format="dd/MM/yyyy">
                              </asp:CalendarExtender>
                              </td>
<td width="20%" class="style1">
    </td>
</tr>


    <tr>
        <td align="center" width="25%">
            <asp:Label ID="lbl_engineno" runat="server" Text="Engine No" Visible="False"></asp:Label>
        </td>
        <td width="2%">
            &nbsp;</td>
        <td align="left">
            <asp:Label ID="lblengineno" runat="server"></asp:Label>
        </td>
        <td width="2%">
            &nbsp;</td>
        <td align="center" width="25%">
            <asp:Label ID="Label2" runat="server" Text="Color" Visible="False"></asp:Label>
            </td>
        <td width="2%">
            &nbsp;</td>
        <td align="left" width="25%">
            <asp:Label ID="lblcolor" runat="server"></asp:Label>
        </td>
        <td width="20%">
            &nbsp;</td>
    </tr>


    <tr>
        <td align="center" width="25%">
            <asp:Label ID="Label3" runat="server" Text="Key No" Visible="False"></asp:Label>
        </td>
        <td width="2%">
            &nbsp;</td>
        <td align="left">
            <asp:Label ID="lblkeyno" runat="server"></asp:Label>
        </td>
        <td width="2%">
            &nbsp;</td>
        <td align="center" width="25%">
            <asp:Label ID="Label4" runat="server" Text="Rate" Visible="False"></asp:Label>
        </td>
        <td width="2%">
            &nbsp;</td>
        <td align="left" width="25%">
            <asp:Label ID="lblrate" runat="server"></asp:Label>
        </td>
        <td width="20%">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" width="25%">
            <asp:Label ID="Label5" runat="server" Text="Quantity" Visible="False"></asp:Label>
        </td>
        <td width="2%">
            &nbsp;</td>
        <td align="left">
            <asp:Label ID="lblquantity" runat="server"></asp:Label>
        </td>
        <td width="2%">
            &nbsp;</td>
        <td align="center" width="25%">
            <asp:Label ID="Label6" runat="server" Text="Amount" Visible="False"></asp:Label>
        </td>
        <td width="2%">
            &nbsp;</td>
        <td align="left" width="25%">
            <asp:Label ID="lblamount" runat="server"></asp:Label>
        </td>
        <td width="20%">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" width="25%">
            <asp:Label ID="Label7" runat="server" Text="Makers" Visible="False"></asp:Label>
        </td>
        <td width="2%">
            &nbsp;</td>
        <td align="left">
            <asp:Label ID="lblmakers" runat="server"></asp:Label>
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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CssClass="mGrid" Width="100%">
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:TemplateField HeaderText="SlNo">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Width="40px" />
                        <ItemStyle HorizontalAlign="Left" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Billno">
                      <ItemTemplate>
                            <asp:Label ID="lblbillno" runat="server" 
                                Text='<%# Eval("billno") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vehicle Type">
                        <ItemTemplate>
                            <asp:Label ID="lblvechiletype" runat="server" 
                                Text='<%# Eval("vehicletype") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Model name">
                        <ItemTemplate>
                            <asp:Label ID="lblmodelname" runat="server" Text='<%# Eval("modelname") %>' 
                                ToolTip='<%# Eval("mvalue") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chessis No">
                        <ItemTemplate>
                            <asp:Label ID="lblchessisno" runat="server" Text='<%# Eval("chessisno") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="From Branch">
                        <ItemTemplate>
                            <asp:Label ID="lblfrombranch" runat="server" Text='<%# Eval("frombranch") %>'> </asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="To Branch">
                        <ItemTemplate>
                            <asp:Label ID="lbltobranch" runat="server" Text='<%# Eval("tobranch") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="EngineNo">
                      <ItemTemplate>
                            <asp:Label ID="lblengno" runat="server" 
                                Text='<%# Eval("engine") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Colour">
                      <ItemTemplate>
                            <asp:Label ID="lblcolor" runat="server" 
                                Text='<%# Eval("color") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="KeyNo">
                      <ItemTemplate>
                            <asp:Label ID="lblkey" runat="server" 
                                Text='<%# Eval("keyno") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Rate">
                      <ItemTemplate>
                            <asp:Label ID="lblrate" runat="server" 
                                Text='<%# Eval("rate") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Quantity">
                      <ItemTemplate>
                            <asp:Label ID="lblquantity" runat="server" 
                                Text='<%# Eval("quantity") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Amount">
                      <ItemTemplate>
                            <asp:Label ID="lblamount" runat="server" 
                                Text='<%# Eval("amount") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Makers Name">
                      <ItemTemplate>
                            <asp:Label ID="lblmakers" runat="server" 
                                Text='<%# Eval("makersname") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtn_SBDelete" runat="server" 
                                ImageUrl="~/Admin/Images/Delete_Icon.png" onclick="imgbtn_SBDelete_Click" 
                                ToolTip='<%# Eval("chessisno") %>' Width="25px" />
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

