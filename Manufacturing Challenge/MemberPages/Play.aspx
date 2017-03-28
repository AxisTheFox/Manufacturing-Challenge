<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Play.aspx.cs" Inherits="Manufacturing_Challenge.MemberPages.Play" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Page for the main game.</h2>
    <p>
        <asp:Button ID="btnAnswerScenario" runat="server" Text="Answer Scenario" OnClick="btnAnswerScenario_Click" />
    </p>
</asp:Content>
