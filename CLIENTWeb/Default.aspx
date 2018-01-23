<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CLIENTWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

    /*//*************************************
    //WEB SERVICES (Lab4)(ASP.NET)
    //WEB PAGE FOR CUSTOMER INCIDENTS (ASPX)
    //Dean Jones
    //Jan.17, 2017
    //**************************************/

    </style>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form2" runat="server">
        <header>
            SportsPro Inc.<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <img alt="sports.jpg" class="auto-style1" longdesc="sports.jpg" src="images/Sports.jpg" /></header>
        <div>
            <h1>Customer Incidents&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h1>
            <h4>Customer Name:</h4>
            &nbsp;<asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="CustomerID" Font-Size="Medium" Height="30px" Width="200px" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllCustomers" TypeName="CLIENTWeb.IncidentsServiceReference.IncidentsServiceClient"></asp:ObjectDataSource>
            <br />
            <h4>Incidents:</h4>
        </div>
        <asp:GridView ID="gvIncidents" runat="server" AutoGenerateColumns="False" CellPadding="6" CellSpacing="4" CssClass="gridview" DataSourceID="ObjectDataSource2" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" EnableViewState="False">
            <AlternatingRowStyle BackColor="White" BorderStyle="Solid" BorderWidth="1px" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
                <asp:BoundField DataField="DateClosed" HeaderText="DateClosed" SortExpression="DateClosed" />
                <asp:BoundField DataField="DateOpened" HeaderText="DateOpened" SortExpression="DateOpened" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="IncidentID" HeaderText="IncidentID" SortExpression="IncidentID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="ProductCode" HeaderText="ProductCode" SortExpression="ProductCode" />
                <asp:BoundField DataField="TechID" HeaderText="TechID" SortExpression="TechID" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" BorderStyle="Inset" BorderWidth="1px" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetCustomerIncidents" TypeName="CLIENTWeb.IncidentsServiceReference.IncidentsServiceClient">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCustomer" Name="customerID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    <br />
    <footer>
        Lab4 Web Services ASP.NET - Dean Jones - Jan.18, 2017</footer>
        <%--    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>--%>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </form>
    </body>
</html>
