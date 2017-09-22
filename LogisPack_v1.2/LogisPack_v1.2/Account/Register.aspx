<%@ Page Title="Registrarse" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.vb" Inherits="LogisPack_v1._2.Register" %>

<%@ Import Namespace="LogisPack_v1._2" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <div id="titleContainer">
        <div class="MainContentTitle">
            <div class="MainContentTitleText">
                <ol class="breadcrumb">
                    <li><a href="../Default.aspx">Menu Principal</a></li>
                    <li><a href="#">Registrar Usuario</a></li>
                </ol>
            </div>
        </div>
    </div>


    <div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal">
            <h4>Crear una nueva cuenta</h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Correo electrónico</asp:Label>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                        CssClass="text-danger" ErrorMessage="El campo de correo electrónico es obligatorio." />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                        CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirmar contraseña</asp:Label>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="El campo de confirmación de contraseña es obligatorio." />
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="La contraseña y la contraseña de confirmación no coinciden." />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Rol</asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlRol" runat="server" data-toggle="tooltip" data-placement="bottom" title="Seleccione el rol"></asp:DropDownList>

                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRol" CssClass="text-danger" Display="Dynamic"
                        ErrorMessage="Debe Seleccionar un Rol." />

                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Cliente</asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlCliente" runat="server" data-toggle="tooltip" data-placement="bottom" title="Seleccione el rol"></asp:DropDownList>

                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCliente" CssClass="text-danger" Display="Dynamic"
                        ErrorMessage="Debe Seleccionar una empresa." />

                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registrarse" CssClass="btn btn-default" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
