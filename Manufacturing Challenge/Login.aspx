<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Manufacturing_Challenge.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/LoginStyle.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="login">
        <h2>
            Login</h2>

        <p>
            Email:
            <asp:TextBox ID="Email" runat="server"></asp:TextBox></p>

        <p>
            Password:
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></p>

        <p>
            <asp:CheckBox ID="RememberMe" runat="server" text="Remember Me" /></p>

        <p>
            <asp:Button ID="LoginButton" runat="server" Text="Login" /></p>

        <p>
            <asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="Your username or password is invalid. Please try again." Visible="False"></asp:Label></p>
    </div>
</asp:Content>
