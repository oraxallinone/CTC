<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="~/Admin/Vehicle_QuotationEdit.aspx.cs" Inherits="Admin_Master_MachineRegstration" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
    function AllowNumbersOnly(input, kbEvent) {
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

    <style type="text/css">
        .style1
        {
            height: 36px;
        }
        .style2
        {
            height: 23px;
        }
    </style>
    <script src="SmitaStYlE/SumUsingJquery/jquery.min.js" type="text/javascript"></script>
    <script src="SmitaStYlE/SumUsingJquery/VehicleQuotation.js" type="text/javascript"></script>
    
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div  style="background-color: #FFFFFF; padding-left:15px; padding-right:10px;">
         <fieldset style="padding-right:20px;">
         <legend ><h4>View Vehicle Quotation</h4></legend>

             <table style="width:100%;">
                 <tr>
                     <td width="20%" align="left">
                         SI.No</td>
                     <td width="2%">
                         :</td>
                     <td width="10%">
                         <asp:TextBox ID="txtsino" runat="server" CssClass="SmalldottedTextBox" 
                             Enabled="False"></asp:TextBox>
                     </td>
                     <td width="20%">
                     </td>
                     <td width="10%">
                     </td>
                     <td width="15%" align="right" valign="top">
                         &nbsp;</td>
                     <td valign="top">
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td width="20%" align="left">
                         Party Name</td>
                     <td width="2%">
                         :</td>
                     <td colspan="2">
                         <asp:TextBox ID="txtpartyname" runat="server" CssClass="SmalldottedTextBox" 
                             Width="270px"></asp:TextBox>

                     </td>
                     <td width="10%">
                         &nbsp;</td>
                     <td width="15%" align="right">
                         Date:</td>
                     <td>
                         <asp:TextBox ID="txtdate" runat="server" CssClass="SmalldottedTextBox" 
                             ReadOnly="True" Enabled="False"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td width="20%" align="left">
                         Address</td>
                     <td class="style1" width="2%">
                         :</td>
                     <td colspan="2">
                         <asp:TextBox ID="txtaddress" runat="server" CssClass="SmalldottedTextBox" 
                             TextMode="MultiLine" Width="270px" Rows="4"></asp:TextBox>
                     </td>
                     <td class="style1" width="10%">
                     </td>
                     <td width="15%" align="right">
                         Ref No</td>
                     <td class="style1">
                         <asp:TextBox ID="txt_refno" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td width="20%" align="left">
                         Phone</td>
                     <td width="2%">
                         :</td>
                     <td colspan="2">
                         <asp:TextBox ID="txtphoneno" runat="server" CssClass="SmalldottedTextBox" 
                             onkeypress="return AllowNumbersOnly(this,event)" Width="270px"></asp:TextBox>
                     </td>
                     <td width="10%">
                         &nbsp;</td>
                     <td width="15%">
                         <asp:Label ID="Label2" runat="server"></asp:Label>
                     </td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="7">
                         <table id="tbl_Product" runat="server" style="border-style: dashed; border-width: thin; border-color: #000000; width: 900px;">
                             <tr bgcolor="#6fb3e0">
                                 <td class="style2">
                                     VehicleType</td>
                                 <td class="style2">
                                     Model</td>
                                 <td>
                                     <strong>Rate</strong>&nbsp;</td>
                                 <td>
                                     <strong>Quantity </strong>
                                 &nbsp;</td>
                                 <td class="style2">
                                     <strong>Amount</strong>
                                     </td>
                                   <td class="style2">
                                     <strong>Discount (%)</strong></td>
                                 <td class="style2">
                                     <strong>Discoun Amt</strong></td>
                                 <td>
                                     <strong>NetAmount</strong>&nbsp;</td>
                                 <td class="style2">
                                     &nbsp;</td>
                                 <td class="style2">
                                     &nbsp;
                                 </td>
                             </tr>
                             <tr>
                                 <td style="border-right-style: dotted; color: #000000;">
                                     <asp:DropDownList ID="ddl_VType" runat="server" CssClass="SmalldottedTextBox" 
                                         Width="200px" AutoPostBack="True" 
                                         onselectedindexchanged="ddl_VType_SelectedIndexChanged" Height="26px">
                                         <asp:ListItem>...Select...</asp:ListItem>
                                         <asp:ListItem>HCV</asp:ListItem>
                                         <asp:ListItem>LCV</asp:ListItem>
                                     </asp:DropDownList>
                                 </td>
                                 <td style="border-right-style: dotted; color: #000000;">
                                     <asp:DropDownList ID="ddlmodel" runat="server" CssClass="SmalldottedTextBox" 
                                         Width="200px" AutoPostBack="True" 
                                         onselectedindexchanged="ddlmodel_SelectedIndexChanged">
                                     </asp:DropDownList>
                                 </td>
                                    <td style="border-right-style: dotted">
                                     <asp:TextBox ID="txt_rate" runat="server" CssClass="TextBoxGraiant" 
                                        onkeypress="return AllowNumbersOnly(this,event)"  Height="25px" Width="100px" 
                                            Enabled="False">0</asp:TextBox>
                                 </td>
                                 <td style="border-right-style: dotted">
                                     <asp:TextBox ID="txt_quantity" runat="server" CssClass="TextBoxGraiant" 
                                         onkeypress="return AllowNumbersOnly(this,event)" Height="25px" 
                                         Width="60px">0</asp:TextBox>
                                 </td>
                                    <td style="border-right-style: dotted">
                                     <asp:TextBox ID="txt_amount" runat="server" CssClass="TextBoxGraiant" 
                                        onkeypress="return AllowNumbersOnly(this,event)"  Height="25px" Width="100px" 
                                            Enabled="False">0</asp:TextBox>
                                 </td>
                                 <td style="border-right-style: dotted">
                                     <asp:TextBox ID="txt_discount" runat="server" CssClass="TextBoxGraiant" 
                                         onkeypress="return AllowNumbersOnly(this,event)" Height="25px" 
                                         Width="80px">0</asp:TextBox>
                                 </td>
                                 <td style="border-right-style: dotted">
                                     <asp:TextBox ID="txt_discountamount" runat="server" CssClass="TextBoxGraiant" 
                                        onkeypress="return AllowNumbersOnly(this,event)"  Height="25px" 
                                         Width="100px" Enabled="False">0</asp:TextBox>
                                 </td>
                               
                                 <td style="border-right-style: dotted">
                                     <asp:TextBox ID="txt_netamount" runat="server" CssClass="TextBoxGraiant" 
                                        onkeypress="return AllowNumbersOnly(this,event)"  Height="25px" 
                                         Width="100px">0</asp:TextBox>
                                 </td>
                               
                                 <td align="center">
                                     <asp:Button ID="btn_PDSave" runat="server" CssClass="thinCupersulphate" 
                                         Height="28px" Width="70px" onclick="btn_PDSave_Click1" Text="Save" 
                                          />
                                 </td>
                             </tr>
                         </table>
                     </td>
                 </tr>
                 <tr>
                 <td colspan="7">
                     &nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="7">
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
                                   <asp:TemplateField HeaderText="Vehicle Type">
                                     <ItemTemplate>
                                         <asp:Label ID="lblvechiletype" runat="server" Text='<%# Eval("Mv_VehicleType") %>' 
                                             ></asp:Label>
                                     </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" />
                                     <ItemStyle HorizontalAlign="Left" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Model name">
                                     <ItemTemplate>
                                         <asp:Label ID="lblmodelname" runat="server" Text='<%# Eval("Mv_ModelName") %>' 
                                             ToolTip='<%# Eval("Mv_Id") %>'></asp:Label>
                                     </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" />
                                     <ItemStyle HorizontalAlign="Left" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Rate">
                                     <ItemTemplate>
                                         <asp:Label ID="lblrate" runat="server" Text='<%# Eval("Vql_Rate") %>'></asp:Label>
                                     </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                     <ItemStyle HorizontalAlign="Left" Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Quantity">
                                     <ItemTemplate>
                                         <asp:Label ID="lblquantity" runat="server" Text='<%# Eval("Vql_Quantity") %>' > </asp:Label>
                                     </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                     <ItemStyle HorizontalAlign="Left" Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Amount">
                                     <ItemTemplate>
                                         <asp:Label ID="lblamount" runat="server" Text='<%# Eval("Vql_Amount") %>'></asp:Label>
                                     </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                     <ItemStyle HorizontalAlign="Left" Width="100px" />
                                 </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Discount">
                                  <ItemTemplate>
                                         <asp:Label ID="lbldiscount" runat="server" Text='<%# Eval("Vql_discount") %>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Left" Width="100px"  />
                                 </asp:TemplateField>
                                   <asp:TemplateField HeaderText="DiscountAmount">
                                  <ItemTemplate>
                                         <asp:Label ID="lbldiscountamount" runat="server" Text='<%# Eval("Vql_discountAmount") %>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Left" Width="100px"  />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Net Amount">
                                  <ItemTemplate>
                                         <asp:Label ID="lblnetamount" runat="server" Text='<%# Eval("Vql_netamount") %>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Left" Width="100px" />
                                 </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Edit">
                                     <ItemTemplate>
                                         <asp:ImageButton ID="imgbtn_Edit" runat="server" 
                                             ImageUrl="~/Admin/Icon/Edit.jpg" 
                                             ToolTip='<%# Eval("Vql_id") %>' Width="25px" onclick="imgbtn_Edit_Click" 
                                              />
                                              
                                     </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                     <ItemStyle HorizontalAlign="Center" Width="40px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Delete">
                                     <ItemTemplate>
                                         <asp:ImageButton ID="imgbtn_SBDelete" runat="server" 
                                             ImageUrl="~/Admin/Images/Delete_Icon.png" 
                                             ToolTip='<%# Eval("Vql_id") %>' Width="25px" 
                                             onclick="imgbtn_SBDelete_Click" />
                                              
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
                     <td colspan="7" align="center">
                         <asp:Button ID="btn_update" runat="server" CssClass="thinGreen" Text="Update" 
                             Width="100px" Visible="False" onclick="btn_update_Click" />
                         <asp:Button ID="btn_back" runat="server" CssClass="ThinRed" Text="Back" 
                             Width="100px" onclick="btn_back_Click" />
                     </td>
                 </tr>
                 <tr>
                     <td align="center" colspan="7">
                         &nbsp;</td>
                 </tr>
             </table>
            
</fieldset>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

