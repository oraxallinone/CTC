<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ZLockUser.aspx.cs" Inherits="Admin_ViewAssignedUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <div id="content" style="background-color: #FFFFFF;padding-left:15px;">

        <fieldset style="width:95%; padding-left:15px;">
            <legend>
                <h3>
                    Lock Users</h3>
            </legend>
    <table width="100%">
<tr>
<td >
                        <asp:GridView ID="grdType" runat="server" AutoGenerateColumns="False" 
                            Width="100%" CssClass="mGrid" PagerStyle-CssClass="pgr" 
                            AlternatingRowStyle-CssClass="alt" BackColor="White" BorderColor="#CC9966" 
                            BorderStyle="None" BorderWidth="1px" CellPadding="4">
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
                                        <asp:TextBox ID="txtUserType" runat="server" CssClass="SmalldottedTextBox" Text='<%# Eval("User_Type") %>' Width="100%" ReadOnly="true"></asp:TextBox>
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
                                <asp:TemplateField HeaderText="Lock/Unlock">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imglock" runat="server" 
                                            ImageUrl="~/Admin/Images/lock.png" OnClick="imglock_Click"
                                            ToolTip='<%# Eval("Sl_No") %>' Height="30px" 
                                            CommandArgument='<%# Eval("Permission") %>' />
                                        <asp:ImageButton ID="imgonlock" runat="server" ImageUrl="~/Admin/Images/unlock.png"
                                            OnClick="imgonlock_Click" ToolTip='<%# Eval("Sl_No") %>' 
                                            CommandArgument='<%# Eval("Permission") %>' Visible="False"
                                            Height="30px" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="40px"/>
                                    <ItemStyle HorizontalAlign="Center" Width="40px"/>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                            <HeaderStyle 
                                Font-Names="Cambria" Font-Size="12px" BackColor="#990000" Font-Bold="True" 
                                ForeColor="#FFFFCC" />
                            <PagerStyle BackColor="#FFFFCC" CssClass="pgr" ForeColor="#330099" 
                                HorizontalAlign="Center" />
                            <RowStyle BackColor="White" ForeColor="#330099" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                            <SortedAscendingCellStyle BackColor="#FEFCEB" />
                            <SortedAscendingHeaderStyle BackColor="#AF0101" />
                            <SortedDescendingCellStyle BackColor="#F6F0C0" />
                            <SortedDescendingHeaderStyle BackColor="#7E0000" />
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

