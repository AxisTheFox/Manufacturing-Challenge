<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddScenario.aspx.cs" Inherits="Manufacturing_Challenge.AdminPages.AddScenarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Add New Scenario</p>
    <p>
        Station:
        <asp:DropDownList ID="stationDdl" runat="server">
            <asp:ListItem Value="0">StationName0</asp:ListItem>
            <asp:ListItem Value="1">StationName1</asp:ListItem>
            <asp:ListItem Value="2">etc</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Scenario Text: <asp:TextBox ID="scenarioTextBox" runat="server" Height="111px" Width="642px"></asp:TextBox>
    </p>
    <p>
        Solution 1:</p>
    <p>
        Solution Text:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
    </p>
</asp:Content>
