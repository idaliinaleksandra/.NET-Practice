<%@ Page Title="Pelit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pelit.aspx.cs" Inherits="pelimaailma.Views.Pelit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PeliId" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="PeliId" HeaderText="PeliId" ReadOnly="True" SortExpression="PeliId" />
        <asp:BoundField DataField="Nimi" HeaderText="Nimi" SortExpression="Nimi" />
        <asp:BoundField DataField="Vuosi" HeaderText="Vuosi" SortExpression="Vuosi" />
        <asp:BoundField DataField="Alusta" HeaderText="Alusta" SortExpression="Alusta" />
        <asp:BoundField DataField="Hinta" HeaderText="Hinta" SortExpression="Hinta" />
    </Columns>
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#242121" />
</asp:GridView>  
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PelimaailmaConnectionString %>" SelectCommand="SELECT * FROM [Pelit]"></asp:SqlDataSource>
</asp:Content>