<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="~/Admin/Vehicle_Quotation.aspx.cs" Inherits="Admin_Master_MachineRegstration" %>


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

    <link href="SmitaStYlE/AutoCompleteExtenderCss01.css" rel="stylesheet" type="text/css" />
    <link href="SmitaStYlE/AutoCompleteExtenderCss02.css" rel="stylesheet" type="text/css" />
    <script src="SmitaStYlE/SumUsingJquery/jquery.min.js" type="text/javascript"></script>
    <script src="SmitaStYlE/SumUsingJquery/VehicleQuotation.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
    </style>
    
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
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Both">
          
    <div id="content" style="background-color: #FFFFFF; padding-left:15px; padding-right:10px;">
         <fieldset style="padding-right:20px;">
         <legend ><h4>Vehicle Quotation</h4></legend>

             <table style="width:100%;">
                 <tr>
                     <td width="20%" align="left">
                         SI.No</td>
                     <td width="2%">
                         :</td>
                     <td width="10%">
                         <asp:TextBox ID="txtsino" runat="server" CssClass="SmalldottedTextBox" TabIndex="1"
                             ReadOnly="True"></asp:TextBox>
                     </td>
                     <td width="20%">
                     </td>
                     <td width="10%">
                         Date</td>
                     <td width="16%" align="left">
                         <asp:TextBox ID="txtdate" runat="server" CssClass="SmalldottedTextBox" 
                             ReadOnly="True"></asp:TextBox>
                     </td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td width="20%" align="left" class="style2">
                         Party Name</td>
                     <td width="2%" class="style2">
                         :</td>
                     <td colspan="2" class="style2" style="position:relative">
                         <asp:TextBox ID="txtpartyname" runat="server" CssClass="SmalldottedTextBox" 
                             Width="270px" AutoPostBack="True" ontextchanged="txtpartyname_TextChanged"></asp:TextBox>
                         <asp:AutoCompleteExtender ID="txtpartyname_AutoCompleteExtender" runat="server" 
                          CompletionListCssClass="AutoExtender"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                   
                                   CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                    Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetTagNames" 
                                    ServicePath=""
                             TargetControlID="txtpartyname">
                         </asp:AutoCompleteExtender>
                          
                     </td>
                     <td width="10%" class="style2">
                         Ref No</td>
                     <td width="15%" class="style2">
                         <asp:TextBox ID="txt_referenceno" runat="server"></asp:TextBox>
                         </td>
                     <td class="style2">
                         </td>
                 </tr>
                 <tr>
                     <td width="20%" align="left" class="style1">
                         Address</td>
                     <td class="style1" width="2%">
                         :</td>
                     <td colspan="2" class="style1">
                         <asp:TextBox ID="txtaddress" runat="server" CssClass="SmalldottedTextBox" 
                             TextMode="MultiLine" Width="270px" Rows="4" ReadOnly="True"></asp:TextBox>
                     </td>
                     <td class="style1" width="10%">
                     </td>
                     <td class="style1" width="15%">
                     </td>
                     <td class="style1">
                         </td>
                 </tr>
                 <tr>
                     <td width="20%" align="left" class="style1">
                         Phone</td>
                     <td width="2%" class="style1">
                         :</td>
                     <td colspan="2" class="style1">
                         <asp:TextBox ID="txtphoneno" runat="server" CssClass="SmalldottedTextBox" 
                             onkeypress="return AllowNumbersOnly(this,event)" Width="270px" 
                             ReadOnly="True"></asp:TextBox>
                     </td>
                     <td width="10%" class="style1">
                         </td>
                     <td width="15%" class="style1">
                         </td>
                     <td class="style1">
                         </td>
                 </tr>
                 <tr>
                     <td colspan="7">
                         <table id="tbldetails" style="width:100%;border-style:dashed;border-width:thin;border-color:Black">
                       
                             <tr bgcolor="#6fb3e0">
                             <td>
                                     VehicleType</td>
                                 <td>
                                     Model</td>
                                 <td>
                                     <strong>Rate</strong>
                                 </td>
                                 <td>
                                     <strong>Quantity </strong>&nbsp;</td>
                                 <td>
                                     <strong>Amount</strong>
                                 </td>
                                  <td>
                                     <strong>Discount (%)</strong></td>
                                   <td>
                                       <strong>Discoun Amt</strong><td>
                                           <strong>NetAmount</strong>&nbsp;</td>
                                   <td>
                                     &nbsp;</td>
                                 <td>
                                     &nbsp;
                                 </td>
                             </tr>
                             <tr>
                              <td style="border-right-style: dotted; color: #000000;">
                                   <asp:DropDownList ID="ddl_VType" runat="server" AutoPostBack="True" 
                             CssClass="SmalldottedTextBox" Height="26px" 
                             onselectedindexchanged="ddl_VType_SelectedIndexChanged" Width="200px">
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
                                         onkeypress="return AllowNumbersOnly(this,event)" Height="25px" 
                                         Width="100px">0</asp:TextBox>
                                 </td>
                                 <td style="border-right-style: dotted">
                                     <asp:TextBox ID="txt_quantity" runat="server" CssClass="TextBoxGraiant" 
                                         onkeypress="return AllowNumbersOnly(this,event)" Height="25px" 
                                         Width="60px">0</asp:TextBox>
                                 </td>
                                 <td style="border-right-style: dotted">
                                     <asp:TextBox ID="txt_amount" runat="server" CssClass="TextBoxGraiant" 
                                        onkeypress="return AllowNumbersOnly(this,event)"  Height="25px" 
                                         Width="100px" Enabled="False">0</asp:TextBox>
                                 </td>
                                 
                               <td style="border-right-style: dotted">
                                     <asp:TextBox ID="txt_discount" runat="server" CssClass="TextBoxGraiant" 
                                        onkeypress="return AllowNumbersOnly(this,event)"  Height="25px" 
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
                                     <asp:Button ID="btnSBAdd" runat="server" CssClass="VerySmallYellow" 
                                         Height="28px" onclick="btnSBAdd_Click" Text="Add" Width="70px" />
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
                                         <asp:Label ID="lblvechiletype" runat="server" Text='<%# Eval("vehicletype") %>' 
                                             ></asp:Label>
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
                                 <asp:TemplateField HeaderText="Rate">
                                     <ItemTemplate>
                                         <asp:Label ID="lblrate" runat="server" Text='<%# Eval("rate") %>'></asp:Label>
                                     </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                     <ItemStyle HorizontalAlign="Left" Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Quantity">
                                     <ItemTemplate>
                                         <asp:Label ID="lblquantity" runat="server" Text='<%# Eval("quantity") %>'> </asp:Label>
                                     </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                     <ItemStyle HorizontalAlign="Left" Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Amount">
                                     <ItemTemplate>
                                         <asp:Label ID="lblamount" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                                     </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                     <ItemStyle HorizontalAlign="Left" Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Discount(%)">
                                  <ItemTemplate>
                                         <asp:Label ID="lbldiscount" runat="server" Text='<%# Eval("discount") %>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Left" Width="100px"  />
                                 </asp:TemplateField>
                                   <asp:TemplateField HeaderText="DiscountAmount">
                                  <ItemTemplate>
                                         <asp:Label ID="lbldiscountamount" runat="server" Text='<%# Eval("discountamount") %>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Left" Width="100px"  />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Net Amount">
                                  <ItemTemplate>
                                         <asp:Label ID="lblnetamount" runat="server" Text='<%# Eval("netquantity") %>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Left" Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Delete">
                                     <ItemTemplate>
                                         <asp:ImageButton ID="imgbtn_SBDelete" runat="server" 
                                             ImageUrl="~/Admin/Images/Delete_Icon.png" onclick="imgbtn_SBDelete_Click" 
                                             ToolTip='<%# Eval("sino") %>' Width="25px" />
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
                         <asp:Button ID="btn_assign" runat="server" CssClass="thinGreen" 
                             OnClick="btn_assign_Click" Text="Save" Width="150px" />
                     </td>
                 </tr>
                 <tr>
                     <td align="center" colspan="7">
                         &nbsp;</td>
                 </tr>
             </table>
            
</fieldset>
    </div>
      </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

