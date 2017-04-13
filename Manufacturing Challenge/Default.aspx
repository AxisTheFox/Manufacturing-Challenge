<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Manufacturing_Challenge.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <asp:Label ID="welcomeLabel" runat="server" Text="Welcome!"></asp:Label>
        <br />
        <br />
        <asp:Label ID="logoutLabel" runat="server" Text="All done for now?" Visible="false"></asp:Label>
        <br />
        <asp:Button ID="logoutButton" runat="server" Text="Logout" Visible="false" OnClick="logoutButton_Click"/>
        <br />
        <br />
        <asp:Label ID="loginLabel" runat="server" Text="Back for more? " Visible="false"></asp:Label>
        <asp:HyperLink ID="loginLink" runat="server" Text="Log in to continue!" NavigateUrl="~/Login.aspx" Visible="false"></asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="signupLabel" runat="server" Text="New here? " Visible="false"></asp:Label>
        <asp:HyperLink ID="signupLink" runat="server" Text="Sign up now!" NavigateUrl="~/Signup.aspx" Visible="false"></asp:HyperLink>
    </h2>
</asp:Content>
