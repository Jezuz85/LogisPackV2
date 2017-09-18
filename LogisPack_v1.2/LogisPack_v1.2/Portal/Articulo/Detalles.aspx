<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Detalles.aspx.vb" Inherits="LogisPack_v1._2.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="titleContainer">
        <div class="MainContentTitle">
            <div class="MainContentTitleText">
                <ol class="breadcrumb">
                    <li><a href="../../Default.aspx">Menú Principal</a></li>
                    <li><a href="index.aspx">Artículos</a></li>
                    <li><a href="#">Crear Artículo</a></li>
                </ol>
            </div>
        </div>
    </div>

    <div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">
        <div class="row">

            <div class="col-md-6">
                <div class="col-md-6">
                    <h4><strong>Tipo de Artículo</strong></h4>
                    <asp:Label ID="lbTipoArticulo" runat="server"></asp:Label>
                </div>

                <div class="col-md-6">
                    <h4><strong>Almacén</strong></h4>
                    <asp:Label ID="lbAlmacen" runat="server"></asp:Label>
                </div>

                <div class="col-md-6">
                    <h4><strong>Stock Mínimo</strong></h4>
                    <asp:Label runat="server" ID="lbStockMinimo"></asp:Label>

                </div>

                <div class="col-md-6">
                    <h4><strong>Stock Físico</strong></h4>
                    <asp:Label runat="server" ID="lbStockFisico"></asp:Label>
                </div>

                <div class="col-md-12">
                    <asp:PlaceHolder runat="server" ID="phListaArticulos" Visible="false">
                        <h4><strong>Lista de Artículos</strong></h4>
                        <div class="col-md-12" style="overflow: auto; height: 300px;">
                            <asp:Panel ID="pArticulos" runat="server"></asp:Panel>
                        </div>
                    </asp:PlaceHolder>
                </div>
            </div>

            <div class="col-md-6">
                <h4><strong>Imágenes</strong></h4>
                <asp:Panel ID="pImagenes" runat="server"></asp:Panel>
            </div>

        </div>

        <hr />

        <div class="row">
            <div class="col-md-3">
                <h4><strong>Código</strong></h4>

                <asp:Label runat="server" ID="lbCodigo"></asp:Label>
            </div>

            <div class="col-md-3">
                <h4><strong>Nombre</strong></h4>
                <asp:Label runat="server" ID="lbNombre"></asp:Label>
            </div>

            <div class="col-md-3">
                <h4><strong>Referencia Picking</strong></h4>
                <asp:Label runat="server" ID="lbRefPick"></asp:Label>
            </div>

            <div class="col-md-3">
                <h4><strong>Tipo de Unidad</strong></h4>
                <asp:Label ID="lbTipoUnidad" runat="server"></asp:Label>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-12">
                <h3><strong>Referencias Asociadas</strong></h3>
            </div>

            <div class="col-md-3">
                <h4><strong>Referencia 1</strong></h4>
                <asp:Label runat="server" ID="lbRef1"></asp:Label>
            </div>

            <div class="col-md-3">
                <h4><strong>Referencia 2</strong></h4>
                <asp:Label runat="server" ID="lbRef2"></asp:Label>
            </div>

            <div class="col-md-3">
                <h4><strong>Referencia 3</strong></h4>
                <asp:Label runat="server" ID="lbRef3"></asp:Label>
            </div>
        </div>

        <hr />


        <div class="row">
            <div class="col-md-12">
                <h3><strong>Ubicación</strong></h3>
            </div>
            
            <div class="col-md-12">
                <asp:Panel ID="pTabla" runat="server"></asp:Panel>

            </div>

        </div>

        <hr />

        <div class="row">
            <div class="col-md-2">
                <h4><strong>Peso</strong></h4>
                <asp:Label runat="server" ID="lbPeso"></asp:Label>
            </div>

            <div class="col-md-2">
                <h4><strong>Alto</strong></h4>
                <asp:Label runat="server" ID="lbAlto"></asp:Label>
                cm(s)
            </div>

            <div class="col-md-2">
                <h4><strong>Largo</strong></h4>
                <asp:Label runat="server" ID="lbLargo"></asp:Label>
                cm(s)
            </div>

            <div class="col-md-2">
                <h4><strong>Ancho</strong></h4>
                <asp:Label runat="server" ID="lbAncho"></asp:Label>
                cm(s)
            </div>

            <div class="col-md-2">
                <h4><strong>M<sup>3</sup></strong></h4>
                <asp:Label runat="server" ID="lbCubicaje"></asp:Label>
                m<sup>3</sup>
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                <h4><strong>Coef. Volumétrico</strong></h4>
                <asp:Label runat="server" ID="lbCoefVol"></asp:Label>(m<sup>3</sup>)
            </div>

            <div class="col-md-3">
                <h4><strong>Peso Volumétrico</strong></h4>
                <asp:Label runat="server" ID="txtPesoVol"></asp:Label>
            </div>
        </div>

        <hr />

        <div class="row">
            <div class="col-md-3">
                <h4><strong>Tipo de Facturación</strong></h4>
                <asp:Label runat="server" ID="lbTipoFacturacion"></asp:Label>
            </div>

            <div class="col-md-2">
                <h4><strong>Identificación</strong></h4>
                <asp:Label runat="server" ID="lbIdentificacion"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                <h4><strong>Valor Artículo</strong></h4>
                <asp:Label runat="server" ID="lbValArticulo"></asp:Label>
            </div>

            <div class="col-md-3">
                <h4><strong>Valor Asegurado</strong></h4>
                <asp:Label runat="server" ID="txtValAsegurado"></asp:Label>
            </div>

            <div class="col-md-3">
                <h4><strong>Valoración Stock</strong></h4>
                <asp:Label runat="server" ID="lbValSotck"></asp:Label>
            </div>

            <div class="col-md-3">
                <h4><strong>Valoración Seguro</strong></h4>
                <asp:Label runat="server" ID="txtValSeguro"></asp:Label>
            </div>

        </div>

        <hr />

        <div class="row">
            <div class="col-md-6">
                <h4><strong>Observaciones Generales</strong></h4>
                <asp:Label runat="server" ID="txtObsGen"></asp:Label>
            </div>

            <div class="col-md-6">
                <h4><strong>Observaciones Artículo</strong></h4>
                <asp:Label runat="server" ID="txtObsArt"></asp:Label>
            </div>
        </div>
        <br />
        <br />
    </div>

</asp:Content>