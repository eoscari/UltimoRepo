<%@ Page Title="Lista de Facturas Reales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridFacturaReal.aspx.cs" Inherits="Trabajo_final.GridFacturareal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelError" runat="server" class="alert alert-danger alert-dismissable" Visible="False">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">×</span>
        </button>
            <asp:Label ID="lblMessageError" runat="server" Text=""></asp:Label>
    </asp:Panel>
    <asp:Panel ID="InfoPanel" runat="server" class="alert alert-success alert-dismissable" Visible="False">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">×</span>
        </button>
            <asp:Label ID="lblMessageSuccess" runat="server" Text=""></asp:Label>
    </asp:Panel>
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
                <td><label><%= item.IdFactura %></label></td>
                <td><%= item.fechaEmision.ToString("dd/MM/yyyy") %></td>
                <td><%= item.fechaMovimiento.ToString("dd/MM/yyyy") %></td>
                <td><%= item.Tipo %></td>
                <td><%= item.Monto %></td>
                <td><%= item.Modo %></td>
                <td><%= item.IdNota %></td>
                <td><%= item.IdCheque %></td>
                <td><%= item.Destinatario %></td>
                <td><%= item.Originante %></td>
                <td>
                                      
                <a href="Detalle?IdFactura=<%= item.IdFactura %>"><button type="button" title="Detalle" class="btn btn-sm btn-success glyphicon glyphicon-list-alt"></button></a>
                <a href="Editar?IdFactura=<%= item.IdFactura %>"><button type="button" title="Editar" class="btn btn-sm btn-warning glyphicon glyphicon-pencil"></button></a>
                <a href="GridFacturaReal?IdFactura=<%= item.IdFactura %>"><button type="button" title="Eliminar" class="btn btn-sm btn-danger glyphicon glyphicon-trash"></button></a>
                    
                        <%--<asp:Button runat="server" OnClick="Editar" Title="Editar" CssClass="btn btn-sm btn-warning glyphicon glyphicon-pencil" ID="btnModificar" />
                    <asp:Button runat="server" OnClick="Eliminar" Title="Eliminar" CssClass="btn btn-sm btn-danger glyphicon glyphicon-trash" ID="btnEliminar" />  --%>              
                        
                </td>
            </tr>
            <% }%>
        </tbody>
    </table>
</asp:Content>
