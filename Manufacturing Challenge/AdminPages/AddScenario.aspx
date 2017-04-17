<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddScenario.aspx.cs" Inherits="Manufacturing_Challenge.AdminPages.AddScenarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Add New Scenario
    </p>
    <p>
        Station:
        <asp:DropDownList ID="stationDdl" runat="server">
            <asp:ListItem Value="0">StationName0</asp:ListItem>
            <asp:ListItem Value="1">StationName1</asp:ListItem>
            <asp:ListItem Value="2">etc</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Scenario Prompt:
        <asp:TextBox ID="scenarioPromptTextBox" runat="server" Height="100px" Width="500px" MaxLength="300" TextMode="MultiLine" onKeyUp="javascript:Check(this, 300);" onChange="javascript:Check(this, 300);"></asp:TextBox>
        &nbsp;300 characters max
    </p>
    <p>
        Scenario Results:
        <asp:TextBox ID="scenarioResultsTextBox" runat="server" Height="100px" Width="500px" MaxLength="300" TextMode="MultiLine" onKeyUp="javascript:Check(this, 300);" onChange="javascript:Check(this, 300);"></asp:TextBox>
        &nbsp;300 characters max
    </p>
    <p>
        &nbsp;&nbsp;
    </p>
    <p>
        Solution 1:
    </p>
    <p>
        Solution Text:
        <asp:TextBox ID="SolutionOneTextBox" runat="server" MaxLength="300" Height="100px" Width="500px" TextMode="MultiLine" onKeyUp="javascript:Check(this, 300);" onChange="javascript:Check(this, 300);"></asp:TextBox>
        &nbsp;300 characters max
    </p>

    Correct Solution:
        <asp:CheckBox ID="SolutionOneCorrectCheckBox" runat="server" />
    <p>
        Impact on Player&#39;s Money:
        <asp:TextBox ID="SolutionOneMoneyTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Products:&nbsp;
        <asp:TextBox ID="SolutionOneProductsTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Parts:
        <asp:TextBox ID="SolutionOnePartsTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Employees:
        <asp:TextBox ID="SolutionOneEmployeesTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Customers:
        <asp:TextBox ID="SolutionOneCustomersTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        Solution 2:
    </p>
    <p>
        Solution Text:
        <asp:TextBox ID="SolutionTwoTextBox" runat="server" MaxLength="300" Height="100px" Width="500px" TextMode="MultiLine" onKeyUp="javascript:Check(this, 300);" onChange="javascript:Check(this, 300);"></asp:TextBox>
        &nbsp;300 characters max
    </p>

    Correct Solution:
        <asp:CheckBox ID="SolutionTwoCorrectCheckBox" runat="server" />
    <p>
        Impact on Player&#39;s Money:
        <asp:TextBox ID="SolutionTwoMoneyTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Products:&nbsp;
        <asp:TextBox ID="SolutionTwoProductsTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Parts:
        <asp:TextBox ID="SolutionTwoPartsTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Employees:
        <asp:TextBox ID="SolutionTwoEmployeesTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Customers:
        <asp:TextBox ID="SolutionTwoCustomersTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        Solution 3:
    </p>
    <p>
        Solution Text:
        <asp:TextBox ID="SolutionThreeTextBox" runat="server" MaxLength="300" Height="100px" Width="500px" TextMode="MultiLine" onKeyUp="javascript:Check(this, 300);" onChange="javascript:Check(this, 300);"></asp:TextBox>
        &nbsp;300 characters max
    </p>

    Correct Solution:
        <asp:CheckBox ID="SolutionThreeCorrectCheckBox" runat="server" />
    <p>
        Impact on Player&#39;s Money:
        <asp:TextBox ID="SolutionThreeMoneyTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Products:&nbsp;
        <asp:TextBox ID="SolutionThreeProductsTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Parts:
        <asp:TextBox ID="SolutionThreePartsTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Employees:
        <asp:TextBox ID="SolutionThreeEmployeesTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Customers:
        <asp:TextBox ID="SolutionThreeCustomersTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        Solution 4:
    </p>
    <p>
        Solution Text:
        <asp:TextBox ID="SolutionFourTextBox" runat="server" MaxLength="300" Height="100px" Width="500px" TextMode="MultiLine" onKeyUp="javascript:Check(this, 300);" onChange="javascript:Check(this, 300);"></asp:TextBox>
        &nbsp;300 characters max
    </p>

    Correct Solution:
        <asp:CheckBox ID="SolutionFourCorrectCheckBox" runat="server" />
    <p>
        Impact on Player&#39;s Money:
        <asp:TextBox ID="SolutionFourMoneyTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Products:&nbsp;
        <asp:TextBox ID="SolutionFourProductsTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Parts:
        <asp:TextBox ID="SolutionFourPartsTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Employees:
        <asp:TextBox ID="SolutionFourEmployeesTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Impact on Player&#39;s Customers:
        <asp:TextBox ID="SolutionFourCustomersTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <script type="text/javascript">
        function Check(textBox, maxLength) {
            if (textBox.value.length > maxLength) {
                alert("Max characters allowed in this text box is " + maxLength);
                textBox.value = textBox.value.substr(0, maxLength);
            }
        }
    </script>
</asp:Content>
