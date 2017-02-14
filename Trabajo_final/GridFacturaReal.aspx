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
                <th>IdFactura</th>
                <th>fechaEmision</th>
                <th>fechaMovimiento</th>
                <th>Tipo</th>
                <th>Monto</th>
                <th>Modo</th>
                <th>IdNota</th>
                <th>IdCheque</th>
                <th>Destiantario</th>
                <th>Originante</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var item in ListaMostrar) {%>
            <tr>
                <td><%= item.IdFactura %></td>
                <td><%= item.fechaEmision.ToString() %></td>
                <td><%= item.fechaMovimiento.ToString() %></td>
                <td><%= item.Tipo %></td>
                <td><%= item.Monto %></td>
                <td><%= item.Modo %></td>
                <td><%= item.IdNota %></td>
                <td><%= item.IdCheque %></td>
                <td><%= item.Destinatario %></td>
                <td><%= item.Originante %></td>
                <td>
                    <button class="btn btn-sm btn-warning glyphicon glyphicon-pencil"></button>
                </td>
            </tr>
            <% }%>
        </tbody>
    </table>
</asp:Content>
