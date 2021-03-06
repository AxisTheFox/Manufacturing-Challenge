﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Play.aspx.cs" Inherits="Manufacturing_Challenge.MemberPages.Play" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Page for the main game.</h2>
    <asp:Panel ID="Panel1" runat="server">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow HorizontalAlign="NotSet">
                <asp:TableCell ID="station0"><img src="/images/station0.png"/></asp:TableCell>
                <asp:TableCell ID="station1"><img src="/images/station1.png"/></asp:TableCell>
                <asp:TableCell ID="station2"><img src="/images/station2.png"/></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="station7"><img src="/images/station7.png"/></asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell ID="station3"><img src="/images/station3.png"/></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="station6"><img src="/images/station6.png"/></asp:TableCell>
                <asp:TableCell ID="station5"><img src="/images/station5.png"/></asp:TableCell>
                <asp:TableCell ID="station4"><img src="/images/station4.png"/></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <p>
        <asp:Button ID="btnAnswerScenario" runat="server" Text="Answer Scenario" OnClick="btnAnswerScenario_Click" />
    </p>
    <p>
        <asp:GridView ID="assetsGridView" runat="server" AutoGenerateColumns="False" DataSourceID="selectAssetsSQLDS" Style="margin-bottom: 0px">
            <Columns>
                <asp:BoundField DataField="AssetsMoney" HeaderText="Money" SortExpression="AssetsMoney" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="AssetsProducts" HeaderText="Products" SortExpression="AssetsProducts" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="AssetsParts" HeaderText="Parts" SortExpression="AssetsParts" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="AssetsEmployees" HeaderText="Employees" SortExpression="AssetsEmployees" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="AssetsCustomers" HeaderText="Customers" SortExpression="AssetsCustomers" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="selectAssetsSQLDS" runat="server" ConnectionString="<%$ ConnectionStrings:DB_110395_gamedbConnectionString %>" SelectCommand="SELECT [AssetsMoney], [AssetsProducts], [AssetsParts], [AssetsEmployees], [AssetsCustomers] FROM [User] WHERE ([ID] = @userId)">
            <SelectParameters>
                <asp:SessionParameter Name="userId" SessionField="userId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
