<%@ Page Title="Mensaje" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ResultadoDeCrearProvincia.aspx.cs" Inherits="Lab03.Pages.ResultadoDeCrearProvincia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-3">Se ha completado el proceso</h2>
        <p class="text-center">Se ha creado una nueva provincia en la base de datos.</p>
        <div class="text-center mt-4">
            <asp:Button ID="btnRegresar" runat="server" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />
        </div>
    </div>
</asp:Content>
