<%@ Page Title="Lista de Facturas Reales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridFacturaReal.aspx.cs" Inherits="Trabajo_final.GridFacturareal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <p class="text-success">
        <asp:Literal runat="server" ID="SuccessMessage" />
    </p>
    <h3><%: Title %></h3>
    <hr />
    <table class="table table-hover">  
        <thead>      
            <tr>
                <th>#</th>
                <th>Emision</th>
                <th>Movimiento</th>
                <th>Tipo</th>
                <th>Monto</th>
                <th>Modo</th>
                <th>IdNota</th>
                <th>IdCheque</th>
                <th>Destiantario</th>
                <th>Originante</th>
                <th>Opciones</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var item in ListaMostrar) {%>
            <tr>
                <td>
                    <asp:Label ID="idFactura" runat="server" CommandName="Eliminar" CommandArgument='<%= item.IdFactura %>' />
                </td>
                <td><%= item.fechaEmision.ToString("dd/MM/yyyy") %>
                    <asp:Label ID="Label1" runat="server" TabIndex="1" />
                </td>
                <td><%= item.fechaMovimiento.ToString("dd/MM/yyyy") %></td>
                <td><%= item.Tipo %></td>
                <td><%= item.Monto %></td>
                <td><%= item.Modo %></td>
                <td><%= item.IdNota %></td>
                <td><%= item.IdCheque %></td>
                <td><%= item.Destinatario %></td>
                <td><%= item.Originante %></td>
                <td>
                    <asp:Button runat="server" OnClick="Detalle" Title="Detalle" CssClass="btn btn-sm btn-success glyphicon glyphicon-list-alt" ID="btnSuccess" />
                    <asp:Button runat="server" OnClick="Editar" Title="Editar" CssClass="btn btn-sm btn-warning glyphicon glyphicon-pencil" ID="btnModificar" />
                    <asp:Button runat="server" OnClick="Eliminar" Title="Eliminar" CssClass="btn btn-sm btn-danger glyphicon glyphicon-trash" ID="btnEliminar" />                
                </td>
            </tr>
            <% }%>
        </tbody>
    </table>
</asp:Content>
