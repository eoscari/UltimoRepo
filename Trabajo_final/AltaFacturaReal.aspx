<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaFacturaReal.aspx.cs" Inherits="Trabajo_final.ABMFacturaReal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <p class="text-success">
        <asp:Literal runat="server" ID="SuccessMessage" />
    </p>
    <div class="form-horizontal" role="form">
        <br />
        <h4 id="idlabelFactura">Nueva Factura.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />   
        <div class="form-group col-md-6">
            <asp:Label runat="server" AssociatedControlID="idlabelFactura" CssClass="col-md-2 control-label" ID="idlabelFactura">Núm de factura</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="idFactura" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="idFactura"
                    CssClass="text-danger" ErrorMessage="Se requiere el id de factura" />
            </div>
        </div>   
          
        <div class="form-group col-md-6">
            <asp:Label runat="server" AssociatedControlID="labelFechaEmi" CssClass="col-md-2 control-label" ID="labelFechaEmi">Fecha Emisión</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FechaEmision" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FechaEmision"
                    CssClass="text-danger" ErrorMessage="Se requiere fecha de emisión" />
            </div>
        </div>  
        <div class="form-group col-md-6">
            <asp:Label runat="server" AssociatedControlID="labelFechaMovimiento" CssClass="col-md-2 control-label" ID="labelFechaMovimiento">Fecha Movimiento</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FechaMovimiento" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FechaMovimiento"
                    CssClass="text-danger" ErrorMessage="Se requiere fecha de movimiento." />
            </div>
        </div> 
        <div class="form-group col-md-6">
            <asp:Label runat="server" AssociatedControlID="labelTipo" CssClass="col-md-2 control-label" ID="labelTipo">Tipo</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Tipo" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tipo"
                    CssClass="text-danger" ErrorMessage="Se requiere tipo de factura." />
            </div>
        </div> 
        <div class="form-group col-md-6">
            <asp:Label runat="server" AssociatedControlID="labelMonto" CssClass="col-md-2 control-label" ID="labelMonto">Monto</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Monto" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Monto"
                    CssClass="text-danger" ErrorMessage="Se requiere un monto." />
            </div>
        </div> 
        <div class="form-group col-md-6">
            <asp:Label runat="server" AssociatedControlID="labelMoneda" CssClass="col-md-2 control-label" ID="labelMoneda">Moneda</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Moneda" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Moneda"
                    CssClass="text-danger" ErrorMessage="Se requiere un tipo de moneda." />
            </div>
        </div>
        <div class="form-group col-md-6">
            <asp:Label runat="server" AssociatedControlID="labelModoPago" CssClass="col-md-2 control-label" ID="labelModoPago">Modo de pago</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ModoPago" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ModoPago"
                    CssClass="text-danger" ErrorMessage="Se requiere un modo de pago." />
            </div>
        </div>
        <div class="form-group col-md-6">
            <asp:Label runat="server" AssociatedControlID="idlabelNota" CssClass="col-md-2 control-label" ID="idlabelNota">Núm de nota</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Nota" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Nota"
                    CssClass="text-danger" ErrorMessage="Se requiere un número de nota." />
            </div>
        </div>
        <div class="form-group col-md-6">
            <asp:Label runat="server" AssociatedControlID="idlabelCheque" CssClass="col-md-2 control-label" ID="idlabelCheque">Núm de cheque</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Cheque" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Cheque"
                    CssClass="text-danger" ErrorMessage="Se requiere un número de cheque." />
            </div>
        </div>
        <div class="form-group col-md-6">
            <asp:Label runat="server" AssociatedControlID="labelDestinatario" CssClass="col-md-2 control-label" ID="labelDestinatario">Destinatario</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Destinatario" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Destinatario"
                    CssClass="text-danger" ErrorMessage="Se requiere un destinatario." />
            </div>
        </div>
        <div class="form-group col-md-6">
            <asp:Label runat="server" AssociatedControlID="labelOriginante" CssClass="col-md-2 control-label" ID="labelOriginante">Originante</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Originante" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Originante"
                    CssClass="text-danger" ErrorMessage="Se requiere un originante." />
            </div>
        </div>
        </div> 
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Alta" Text="Alta" CssClass="btn btn-success" /> 
            </div>
        </div>
</asp:Content>
