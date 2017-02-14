<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMCuenta.aspx.cs" Inherits="Trabajo_final.ABMCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-success">
        <asp:Literal runat="server" ID="SuccessMessage" />
    </p>

    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMassage" />
    </p>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                 <hr />
                <div class="form-horizontal">
         
                  <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="FondoDolar" CssClass="col-md-2 control-label">Fondo en Dolar</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="FondoDolar" CssClass="form-control" placeholder="Si no Tiene Fondo Ingrese 0" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FondoDolar"
                                CssClass="text-danger" ErrorMessage="Ingrese fondo de Dolar." />
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="FondoPeso" CssClass="col-md-2 control-label">Fondo en Pesos</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="FondoPeso" CssClass="form-control" PlaceHolder="Si no tiene fondo ingrese 0"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FondoPeso"
                                CssClass="text-danger" ErrorMessage="Ingrese un fondo." />
                        </div>
                    </div>
                    
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Cuenta" CssClass="col-md-2 control-label">Cantidad de Dinero en la Cuenta</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Cuenta" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Cuenta"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ChequesCo" CssClass="col-md-2 control-label">Cheques Cobrados</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="ChequesCo" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ChequesCo"
                                CssClass="text-danger" ErrorMessage="Ingrese valores." />
                        </div>
                    </div>

                    
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="Alta" Text="Alta" CssClass="btn btn-default" />
                          
                            
                        </div>
                    </div>
                </div>
              
            </section>
        </div>
    </div>
</asp:Content>
