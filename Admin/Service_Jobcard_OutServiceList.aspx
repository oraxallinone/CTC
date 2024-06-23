<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Service_Jobcard_OutServiceList.aspx.cs" Inherits="admin_EmployeeDetails" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <link href="SmitaStYlE/AutoCompleteExtenderCss01.css" rel="stylesheet" type="text/css" />
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
                            JobCard Outside Service List</h3>
                    </legend>
                    <table style="width: 100%;">
                    <tr>
                            <td style="width: 16%">
                                From Date
                            </td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td style="width: 24%">
                                <asp:TextBox ID="txt_formdate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="130px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_formdate_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_formdate" 
                                    CssClass="orange">
                                </asp:CalendarExtender>
                            </td>
                            <td style="width: 16%">
                                To Date
                            </td>
                            <td style="width: 1%">
                                :
                            </td>
                            <td style="width: 24%; position:relative">
                                <asp:TextBox ID="txt_todate" runat="server" CssClass="TextBoxGraiantDate" 
                                    Width="130px"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_todate_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txt_todate"  CssClass="orange">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" CssClass="VerySmallGreen" Height="26px"
                                    OnClick="btn_Show_Click" Text="Show" Width="70px" />
                            </td>
                        </tr>
                        <tr>
                            <td width="14%">
                                &nbsp;</td>
                            <td width="14%">
                                &nbsp;</td>
                            <td align="center" width="10%">
                                &nbsp;</td>
                            <td width="20%">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        </table>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="3">
                                <%--<asp:ScriptManager ID="ScriptManager2" runat="server">
                                </asp:ScriptManager>--%>
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
                                        <asp:TemplateField HeaderText="Jobcard No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbljcno" runat="server" Text='<%# Eval("JC_No") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="JobCard Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbljcdate" runat="server" Text='<%# Eval("JCO_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Party  Name">
                                        <ItemTemplate>
                                                <asp:Label ID="lblpartyname" runat="server" Text='<%# Eval("Ms_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtamount" runat="server" Text='<%# Eval("JCO_Amount") %>' ReadOnly="True"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Service Details">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtservicedetails" runat="server" Text='<%# Eval("JCO_ServiceDetails") %>' TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
        
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                       
                                     
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnedit" runat="server" 
                                                    ImageUrl="~/Admin/Icon/Edit.jpg"
                                                    ToolTip='<%# Eval("JCO_Id") %>' Height="20px" 
                                                    onclick="imgbtnedit_Click"   />
                                                     <asp:ImageButton ID="imgbtnview" runat="server" Height="20px" 
                                                    ImageUrl="~/Admin/Icon/view.png"
                                                    ToolTip='<%# Eval("JCO_Id") %>' onclick="imgbtnview_Click" Visible="False" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtndelete" runat="server"  ToolTip='<%# Eval("JCO_Id") %>'
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

