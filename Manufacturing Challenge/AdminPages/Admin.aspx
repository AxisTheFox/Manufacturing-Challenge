<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Manufacturing_Challenge.AdminPages.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        This is an admin page. You probably shouldn't be here.
    </p>
    <p>
        <asp:Button ID="lookAtUsersButton" runat="server" Text="Look at Users" OnClick="lookAtUsersButton_Click" />
    </p>
    <p>
        <asp:Button ID="addScenarioButton" runat="server" Text="Add a new Scenario" OnClick="addScenarioButton_Click" />
    </p>
    <p>
        <asp:Button ID="deleteScenarioButton" runat="server" Text="Delete an old Scenario" OnClick="deleteScenarioButton_Click" />
    </p>
</asp:Content>
