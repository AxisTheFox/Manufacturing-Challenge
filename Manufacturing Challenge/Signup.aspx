﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Manufacturing_Challenge.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>Sign up</h2>

    <i>* Indicates a required field. </i>
    
        <asp:Label ID="signupFailedMessage" runat="server" ForeColor="Red"></asp:Label>&nbsp;<p>*Email:<br />
        <asp:TextBox ID="emailTextBox" runat="server" TextMode="Email"></asp:TextBox></p>
    
    <p>*First name:<br />
        <asp:TextBox ID="firstNameTextBox" runat="server"></asp:TextBox>
    
        <p>*Last name:<br />
        <asp:TextBox ID="lastNameTextBox" runat="server"></asp:TextBox></p>
    
    <p>*Password:<br />
        <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox></p>
    
    <p>*Confirm password:<br />
        <asp:TextBox ID="confirmPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox></p>

    <p>Company:<br />
        <asp:TextBox ID="companyTextBox" runat="server"></asp:TextBox></p>
    
    <p>Position:<br />
        <asp:TextBox ID="positionTextBox" runat="server"></asp:TextBox></p>

    <p>Phone Number:<br />
        <asp:TextBox ID="phoneNumberTextBox" runat="server"></asp:TextBox></p>

    <p>City:<br />
        <asp:TextBox ID="cityTextBox" runat="server"></asp:TextBox></p>

    <p>State:<br />
        <asp:TextBox ID="stateTextBox" runat="server"></asp:TextBox></p>

    <p>Country:<br />
        <asp:TextBox ID="countryTextBox" runat="server"></asp:TextBox></p>
    
    <p>
        <asp:Button ID="signupButton" runat="server" Text="Sign Up!" OnClick="signupButton_Click" />&nbsp;</p>
</asp:Content>
