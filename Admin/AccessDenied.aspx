<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AccessDenied.aspx.cs" Inherits="Restaurant_AccessDenied" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div style="text-align:center; vertical-align:top;">
    <asp:Image ID="Image1" runat="server" 
        ImageUrl="~/Admin/Images/permission.jpg" Width="100%" />
</div>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

