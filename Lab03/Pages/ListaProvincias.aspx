<%@ Page Title="Lista Provincias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaProvincias.aspx.cs" Inherits="Lab03._ListaProvincias" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Lista de provincias</h2>
        <div class="text-start mb-3">
            <asp:HyperLink ID="lnkCrearProvincia" runat="server" NavigateUrl="CrearProvincia.aspx" CssClass="btn btn-link">Crear provincia</asp:HyperLink>
        </div>
        <asp:GridView ID="GridViewProvincias" runat="server" CssClass="table table-bordered text-center" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="idProvincia" HeaderText="ID" />
                <asp:BoundField DataField="provincia" HeaderText="Provincia" />
                <asp:BoundField DataField="estado" HeaderText="Estado" />
                <asp:BoundField DataField="fechaCreacion" HeaderText="Fecha creación" DataFormatString="{0:dd/MM/yyyy}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
