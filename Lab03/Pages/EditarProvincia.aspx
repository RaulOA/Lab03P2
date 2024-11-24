<%@ Page Title="Editar Provincia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarProvincia.aspx.cs" Inherits="Lab03.EditarProvincia" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex justify-content-center align-items-center" style="min-height: 100vh;">
        <div class="text-center">
            <h2 class="mb-4">Editar Provincia</h2>
            <div class="mb-3">
                <label for="txtID" class="form-label">ID</label>
                <asp:TextBox ID="txtID" Enabled="false" runat="server" CssClass="form-control" Style="width: 300px; margin: 0 auto;" />
            </div>
            <div class="mb-3">
                <label for="txtProvincia" class="form-label">Provincia</label>
                <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" Style="width: 300px; margin: 0 auto;" />
            </div>
            <div>
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary mx-2" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger mx-2" Text="Eliminar" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary mx-2" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>


</asp:Content>
