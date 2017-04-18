<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scenario.aspx.cs" Inherits="Manufacturing_Challenge.MemberPages.Scenario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="scenarioTextLabel" runat="server" Text="Scenario Here!"></asp:Label>
    <asp:RadioButtonList ID="solutionsRbl" runat="server">
    </asp:RadioButtonList>
    <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <asp:Label ID="errorLabel" runat="server" Text="Error Here!" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="resultsLabel" runat="server" Text="Results Here!" Visible="False"></asp:Label>
    <br />
    <asp:Button ID="goBackButton" runat="server" Text="Go back to board" OnClick="goBackButton_Click" Visible="False" />
</asp:Content>
