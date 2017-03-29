﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scenario.aspx.cs" Inherits="Manufacturing_Challenge.MemberPages.Scenario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblScenarioText" runat="server" Text="Scenario Here!"></asp:Label>
    <asp:RadioButtonList ID="rblSolutions" runat="server">
    </asp:RadioButtonList>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <asp:Label ID="errorLabel" runat="server" Text="error" Visible="False"></asp:Label>
    <asp:GridView ID="gvDisplay" runat="server">
    </asp:GridView>
    <asp:Button ID="goBackButton" runat="server" Text="Go back to board" OnClick="goBackButton_Click" Visible="False" />
</asp:Content>