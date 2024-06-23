<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Master_SupplierDetails.aspx.cs" Inherits="admin_EmployeeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
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
                            Supplier Details</h3>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td width="14%">
                                Search By
                            </td>
                            <td width="14%">
                                <asp:RadioButton ID="rbnName" runat="server" Text="Name" GroupName="a" />
                            </td>
                            <td width="14%">
                                <asp:RadioButton ID="rbnCode" runat="server" Text="Code" GroupName="a" />
                            </td>
                            <td width="14%">
                                <asp:RadioButton ID="rbnContact" runat="server" Text="Contact No." 
                                    GroupName="a" />
                            </td>
                            <td width="20%">
                                <asp:TextBox ID="txtInput" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                                <asp:Button ID="btnsearch" runat="server" CssClass="thinCupersulphate" 
                                    onclick="btnsearch_Click" Text="Search" />
                            </td>
                        </tr>
                        <tr>
                            <td width="14%">
                                &nbsp;
                            </td>
                            <td width="14%">
                                &nbsp;
                            </td>
                            <td width="14%">
                                &nbsp;
                            </td>
                            <td width="14%">
                                &nbsp;
                            </td>
                            <td width="20%">
                                &nbsp;</td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        </table>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    Width="100%" Font-Names="Cambria" Font-Size="12px" CssClass="mGrid">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Emp Code">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("empcode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Emp Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("empName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact No">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("empcontNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Available">
                                            <ItemTemplate>
                                                <asp:Label ID="lblavilable" runat="server" Tooltip='<%# Eval("empstatus") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnview" runat="server" Height="20px" 
                                                    ImageUrl="~/Admin/Icon/view.png"
                                                    ToolTip='<%# Eval("empid") %>' onclick="imgbtnview_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnedit" runat="server" 
                                                    ImageUrl="~/Admin/Icon/Edit.jpg"
                                                    ToolTip='<%# Eval("empid") %>' Height="20px" 
                                                    onclick="imgbtnedit_Click"   />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtndelete" runat="server"  ToolTip='<%# Eval("empid") %>'
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

