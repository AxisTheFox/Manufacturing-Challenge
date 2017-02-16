<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Manufacturing_Challenge.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LoginView ID="LoginView" runat="server">
        <AnonymousTemplate>
            Log in, or sign up!
        </AnonymousTemplate>
        <LoggedInTemplate>
            Welcome back!
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
