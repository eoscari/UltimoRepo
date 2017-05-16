<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Trabajo_final.Detalle" %>
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

    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section id="detalleForm">
                <h1>Detalle</h1>
                 <hr />
                <div class="form-horizontal jumbotron">
         
                  <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Labe1" CssClass="col-md-4 control-label">Fecha de emisión:</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="Labe1" CssClass="form-control" Enabled="false" />
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Labe2" CssClass="col-md-4 control-label">Fec. movimiento:</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="Labe2" CssClass="form-control" Enabled ="false"/>
                        </div>
                    </div>
                    
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Labe3" CssClass="col-md-4 control-label">Tipo:</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="Labe3" CssClass="form-control" Enabled="false" />
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Labe4" CssClass="col-md-4 control-label">Monto</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="Labe4" CssClass="form-control" Enabled ="false"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Labe5" CssClass="col-md-4 control-label">Moneda</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="Labe5" CssClass="form-control" Enabled="false"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Labe6" CssClass="col-md-4 control-label">Modo de pago</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="Labe6" CssClass="form-control" Enabled="false"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Labe7" CssClass="col-md-4 control-label">Num. de nota</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="Labe7" CssClass="form-control" Enabled="false"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Labe8" CssClass="col-md-4 control-label">Num. de cheque</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="Labe8" CssClass="form-control" Enabled="false"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Labe9" CssClass="col-md-4 control-label">Destinatario</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="Labe9" CssClass="form-control" Enabled="false"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Labe10" CssClass="col-md-4 control-label">Originante</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="Labe10" CssClass="form-control" Enabled="false"/>
                        </div>
                    </div>

                    
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <%--<asp:Button runat="server" OnClick="Alta" Text="Alta" CssClass="btn btn-default" />--%>
                          
                            
                        </div>
                    </div>
                </div>
              
            </section>
        </div>
    </div>
</asp:Content>