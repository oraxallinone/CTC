<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="Master_ServiceHead.aspx.cs" Inherits="Admin_CreateUser" %>

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
                            New Service Head</h3>
                    </legend>
                    <table width="100%">
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                Service Code</td>
                            <td align="left" width="1%">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox ID="txt_SCode" runat="server" CssClass="SmalldottedTextBox" 
                                    Width="250px"></asp:TextBox>
                            </td>
                            <td class="style1">
                                <strong>Service Head List</strong></td>
                        </tr>
                        <tr>
                            <td align="left" width="5%" height="25px">
                                &nbsp;</td>
                            <td align="left" width="20%" height="25px" valign="top">
                                Service Head</td>
                            <td align="left" width="1%" height="25px" valign="top">
                                <strong>:</strong>
                            </td>
                            <td align="left" width="30%" height="25px" valign="top">
                                <asp:TextBox ID="txt_SName" runat="server" CssClass="SmalldottedTextBox" 
                                     Width="250px"></asp:TextBox>
                            </td>
                            <td align="center" rowspan="5" valign="top">
                            <div style ="height:400px; overflow:auto;">
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
                                        <asp:TemplateField HeaderText="Service Code">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Mh_ServiceCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnedit" runat="server" Height="20px" 
                                                    ImageUrl="~/Admin/Icon/Edit.jpg" onclick="imgbtnedit_Click" 
                                                    ToolTip='<%# Eval("Mh_Id") %>' />
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
                            <td align="left" height="25px" width="5%">
                                &nbsp;</td>
                            <td align="left" height="25px" valign="top" width="20%">
                                Rate</td>
                            <td align="left" height="25px" valign="top" width="1%">
                                <strong>:</strong></td>
                            <td align="left" height="25px" valign="top" width="30%">
                                <asp:TextBox ID="txt_SRate" runat="server" CssClass="SmalldottedTextBox" 
                                    onkeypress="return AllowNumbersOnly(this,event)" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" height="25px" width="5%">
                                &nbsp;</td>
                            <td align="left" height="25px" valign="top" width="20%">
                                Sac Code</td>
                            <td align="left" height="25px" valign="top" width="1%">
                                &nbsp;</td>
                            <td align="left" height="25px" valign="top" width="30%">
                                 <asp:TextBox ID="txt_sac" runat="server" CssClass="SmalldottedTextBox" 
                                    Width="250px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" width="5%" height="25px">
                                &nbsp;</td>
                            <td align="right" width="20%" height="25px" valign="top">
                                &nbsp;</td>
                            <td align="left" width="1%" height="25px" valign="top">
                                &nbsp;</td>
                            <td align="left" width="30%" height="25px" valign="top">
                                <asp:Button ID="btn_submit" runat="server" CssClass="thinGreen" 
                                    onclick="btn_submit_Click" Text="Submit" />
                                <asp:Button ID="btn_cancel" runat="server" CssClass="ThinRed" 
                                    OnClick="btn_cancel_Click" Text="Cancel" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="5%">
                                &nbsp;</td>
                            <td align="left" width="20%">
                                &nbsp;
                            </td>
                            <td align="left" width="1%">
                                &nbsp;
                            </td>
                            <td align="left" width="30%">
                                &nbsp; </td>
                        </tr>
                        <tr>
                            <td align="right" width="5%" style="padding-right: 20px">
                                &nbsp;</td>
                            <td align="right" style="padding-right: 20px" width="20%">
                                &nbsp;</td>
                            <td align="left" colspan="2" style="padding-left: 20px" width="30%">
                                &nbsp;</td>
                            <td align="left" style="padding-left: 20px">
                                &nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
