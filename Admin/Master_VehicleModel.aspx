<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Master_VehicleModel.aspx.cs" Inherits="Admin_CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <div id="content" style="background-color: #FFFFFF; padding-left: 15px; padding-right: 10px;">
                <fieldset style="padding-right: 20px;">
                    <legend>
                        <h3>
                            Vehicle Model</h3>
                    </legend>
                    <table width="100%">
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Vehicle Type
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:DropDownList ID="ddl_VType" runat="server" Height="26px" Width="250px" 
                                    CssClass="SmalldottedTextBox">
                                    <asp:ListItem>HCV</asp:ListItem>
                                    <asp:ListItem>LCV</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style1">
                                <strong>Vehicle List</strong></td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Category
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_category" runat="server" CssClass="SmalldottedTextBox" 
                                    Width="250px"></asp:TextBox>
                            </td>
                            <td align="center"  rowspan="16" valign="top">
                            <div style ="width:100%; overflow:auto;">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    CssClass="mGrid" Font-Names="Cambria" Font-Size="12px" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="40px"/>
                                            <ItemStyle HorizontalAlign="Center" Width="40px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Model Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Mv_ModelName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnedit" runat="server" Height="20px" 
                                                    ImageUrl="~/Admin/Icon/Edit.jpg" onclick="imgbtnedit_Click" 
                                                    ToolTip='<%# Eval("Mv_Id") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="40px"/>
                                            <ItemStyle HorizontalAlign="Center" Width="40px"/>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Font-Names="Cambria" Font-Size="12px" />
                                </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Model Name
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_ModelName" runat="server" CssClass="SmalldottedTextBox" 
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%" valign="top">
                                &nbsp;</td>
                            <td align="left" valign="top" width="20%">
                                Specification
                            </td>
                            <td align="left" width="1%" valign="top">
                                <strong>:</strong>
                            </td>
                            <td align="left" valign="top" width="30%">
                                <asp:TextBox ID="txt_Specification" runat="server" CssClass="dropup" Width="250px"
                                    onchange="ValidateEmail(this)" Rows="2" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Makers
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:DropDownList ID="ddl_VMaker" runat="server" CssClass="SmalldottedTextBox" Height="26px"
                                    Width="250px">
                                    <asp:ListItem>ASHOK LEYLAND LIMITED</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                H.Power
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_HPower" runat="server" AutoPostBack="false" CssClass="SmalldottedTextBox"
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Fronl Axel
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_FrontAxel" runat="server" AutoPostBack="false" CssClass="SmalldottedTextBox"
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Rear Axel
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_RearAxel" runat="server" AutoPostBack="false" CssClass="SmalldottedTextBox"
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Other Axel
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_OtherAxel" runat="server" AutoPostBack="false" CssClass="SmalldottedTextBox"
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Tandem Axel
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_TandemAxel" runat="server" AutoPostBack="false" CssClass="SmalldottedTextBox"
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Fuel Used
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:DropDownList ID="ddl_FuelUsed" runat="server" 
                                    CssClass="SmalldottedTextBox" Height="26px"
                                    Width="250px">
                                    <asp:ListItem>DIESEL</asp:ListItem>
                                    <asp:ListItem>PETROL</asp:ListItem>
                                    <asp:ListItem>GAS</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Cylinders
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_Cylinders" runat="server" AutoPostBack="false" CssClass="SmalldottedTextBox"
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Seat Capacity
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_SeatCapacity" runat="server" AutoPostBack="false" CssClass="SmalldottedTextBox"
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Unladed Weight
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_UnladedWeight" runat="server" AutoPostBack="false" CssClass="SmalldottedTextBox"
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Gross Weight
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_GrossWeight" runat="server" AutoPostBack="false" CssClass="SmalldottedTextBox"
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Description</td>
                            <td align="left" width="1%">
                                :</td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_vehicledescription" runat="server" AutoPostBack="false" 
                                    Rows="3" TextMode="MultiLine" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Mrp / Rate
                            </td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_MrpRate" runat="server" AutoPostBack="false" CssClass="SmalldottedTextBox"
                                   onkeypress="return AllowNumbersOnly(this,event)"  Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="5%" style="padding-right: 20px">
                                &nbsp;</td>
                            <td align="right" style="padding-right: 20px" width="20%">
                                <asp:Button ID="btn_submit" runat="server" CssClass="thinGreen" 
                                    onclick="btn_submit_Click" Text="Submit" />
                            </td>
                            <td align="left" colspan="2" style="padding-left: 20px" width="30%">
                                <asp:Button ID="btn_cancel" runat="server" CssClass="ThinRed" OnClick="btn_cancel_Click"
                                    Text="Cancel" />
                            </td>
                            <td align="left" style="padding-left: 20px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" style="padding-right: 20px" width="5%">
                                &nbsp;</td>
                            <td align="right" style="padding-right: 20px" width="20%">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2" style="padding-left: 20px" width="30%">
                                &nbsp;
                            </td>
                            <td align="left" style="padding-left: 20px">
                                &nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
