<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ZViewUserDetails.aspx.cs" Inherits="Admin_ViewAssignedUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <div id="content" style="background-color: #FFFFFF">

        <fieldset>
            <legend>
                <h2>
                    View Users</h2>
            </legend>
    <table width="100%">
<tr>
<td >
                        <asp:GridView ID="grdType" runat="server" AutoGenerateColumns="False" 
                            Width="100%" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                            <AlternatingRowStyle CssClass="alt" />
                            <Columns>
                                <asp:TemplateField HeaderText="SlNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="40px"/>
                                    <ItemStyle HorizontalAlign="Center" Width="40px"/>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Branch Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblbranch" runat="server" CssClass="SmalldottedTextBox" Text='<%# Eval("Branch_Name") %>'  Width="100%" ReadOnly="true"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="80px"/>
                                    <ItemStyle HorizontalAlign="Left" Width="80px"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Type">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtUserType" runat="server" CssClass="SmalldottedTextBox" Text='<%# Eval("User_Type") %>'  Width="100%" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="80px"/>
                                    <ItemStyle HorizontalAlign="Left" Width="80px"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Name">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="SmalldottedTextBox" Text='<%# Eval("User_Name") %>' Width="100%" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="SmalldottedTextBox" Text='<%# Eval("Email_Id") %>' Width="100%" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"  Width="200px"/>
                                    <ItemStyle HorizontalAlign="Left"  Width="200px"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Id">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtUserId" runat="server" CssClass="SmalldottedTextBox" Text='<%# Eval("User_Id") %>' Width="100%" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="120px"/>
                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Password">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="SmalldottedTextBox" 
                                            Text='<%# Eval("Password") %>' Width="100%" ReadOnly="true" Visible="False" ></asp:TextBox>
                                        <asp:LinkButton ID="lnkbtn_ShowPwd" runat="server" 
                                            onclick="lnkbtn_ShowPwd_Click" ToolTip='<%# Eval("Sl_No") %>' Font-Bold="True" Font-Size="13px">Show Password</asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtn_HidePwd" runat="server" Visible="False" Text='<%# Eval("Password") %>'
                                            onclick="lnkbtn_HidePwd_Click"  CommandArgument='<%# Eval("Sl_No") %>'  ToolTip="Hide Password" Font-Bold="True" ForeColor="Black" Font-Size="14px"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="130px"/>
                                    <ItemStyle HorizontalAlign="Left" Width="130px"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnedit" runat="server" 
                                            ImageUrl="~/Admin/Icon/Edit.jpg" OnClick="imgbtnedit_Click"
                                            ToolTip='<%# Eval("Sl_No") %>' Height="20px" Width="30px"/>
                                        <asp:ImageButton ID="imgbtnview" runat="server" ImageUrl="~/Admin/Icon/view.png"
                                            OnClick="imgbtnview_Click" ToolTip='<%# Eval("Sl_No") %>' Visible="False"
                                           Width="30px" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="40px"/>
                                    <ItemStyle HorizontalAlign="Center" Width="40px"/>
                                </asp:TemplateField>
                             
                             
                            </Columns>
                            <HeaderStyle 
                                Font-Names="Cambria" Font-Size="12px" />
                            <PagerStyle CssClass="pgr" />
                        </asp:GridView>
                    </td>
</tr>
<tr>
<td>
    &nbsp;</td>
</tr>
</table>
</fieldset>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

