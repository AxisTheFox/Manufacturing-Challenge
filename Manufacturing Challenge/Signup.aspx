<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Manufacturing_Challenge.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>Sign up</h2>

    <i>* Indicates a required field.</i>
    
    <p>*Email:<br />
        <asp:TextBox ID="emailTextBox" runat="server" TextMode="Email"></asp:TextBox></p>
    
    <p>*First name:<br />
        <asp:TextBox ID="firstNameTextBox" runat="server"></asp:TextBox>
    
        <p>*Last name:<br />
        <asp:TextBox ID="lastNameTextBox" runat="server"></asp:TextBox></p>
    
    <p>*Password:<br />
        <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox></p>
    
    <p>*Confirm password:<br />
        <asp:TextBox ID="confirmPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox></p>
    
    <p>
        <asp:Button ID="signupButton" runat="server" Text="Sign Up!" OnClick="signupButton_Click" /></p>
    
    <p>
        <asp:Label ID="signupFailedMessage" runat="server" ForeColor="Red"></asp:Label></p>

</asp:Content>
