<%@ Page Title="Peli" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Peli.aspx.cs" Inherits="pelimaailma.Views.Peli" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="PeliId">
    <EditItemTemplate>
        PeliId:
        <asp:Label ID="PeliIdLabel1" runat="server" Text='<%# Eval("PeliId") %>' />
        <br />
        Nimi:
        <asp:TextBox ID="NimiTextBox" runat="server" Text='<%# Bind("Nimi") %>' />
        <br />
        Vuosi:
        <asp:TextBox ID="VuosiTextBox" runat="server" Text='<%# Bind("Vuosi") %>' />
        <br />
        Alusta:
        <asp:TextBox ID="AlustaTextBox" runat="server" Text='<%# Bind("Alusta") %>' />
        <br />
        Hinta:
        <asp:TextBox ID="HintaTextBox" runat="server" Text='<%# Bind("Hinta") %>' />
        <br />
        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
    </EditItemTemplate>
    <InsertItemTemplate>
        PeliId:
        <asp:TextBox ID="PeliIdTextBox" runat="server" Text='<%# Bind("PeliId") %>' />
        <br />
        Nimi:
        <asp:TextBox ID="NimiTextBox" runat="server" Text='<%# Bind("Nimi") %>' />
        <br />
        Vuosi:
        <asp:TextBox ID="VuosiTextBox" runat="server" Text='<%# Bind("Vuosi") %>' />
        <br />
        Alusta:
        <asp:TextBox ID="AlustaTextBox" runat="server" Text='<%# Bind("Alusta") %>' />
        <br />
        Hinta:
        <asp:TextBox ID="HintaTextBox" runat="server" Text='<%# Bind("Hinta") %>' />
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
    </InsertItemTemplate>
    <ItemTemplate>
        PeliId:
        <asp:Label ID="PeliIdLabel" runat="server" Text='<%# Eval("PeliId") %>' />
        <br />
        Nimi:
        <asp:Label ID="NimiLabel" runat="server" Text='<%# Bind("Nimi") %>' />
        <br />
        Vuosi:
        <asp:Label ID="VuosiLabel" runat="server" Text='<%# Bind("Vuosi") %>' />
        <br />
        Alusta:
        <asp:Label ID="AlustaLabel" runat="server" Text='<%# Bind("Alusta") %>' />
        <br />
        Hinta:
        <asp:Label ID="HintaLabel" runat="server" Text='<%# Bind("Hinta") %>' />
        <br />

    </ItemTemplate>
</asp:FormView>

    <asp:Label ID="Label1" runat="server" Text="Lukumäärä: "></asp:Label><asp:TextBox ID="TextBoxLukumaara" runat="server" OnTextChanged="TextBoxLukumaara_TextChanged"></asp:TextBox><br />

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PelimaailmaConnectionString %>" SelectCommand="SELECT * FROM [Pelit]"></asp:SqlDataSource>

<br />
    <asp:Button ID="ButtonTilaa" runat="server" Text="Tilaa" OnClick="ButtonTilaa_Click" />
    <br />
    <asp:Label ID="LabelOnnistuikoTilaus" runat="server" Text=""></asp:Label>
</asp:Content>
