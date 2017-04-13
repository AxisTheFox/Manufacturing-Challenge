<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Manufacturing_Challenge.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Sign up</h2>
    <p>Email:<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>
    <p>First name:<br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <p>Last name:<br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></p>
    <p>Password:<br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></p>
    <p>Confirm password:<br />
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    </p>
</asp:Content>
