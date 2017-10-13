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
                    <strong>Tipo de Artículo</strong>
                    <br />
                    <asp:Label ID="lbTipoArticulo" runat="server"></asp:Label>
                </div>

                <div class="col-md-6">
                    <strong>Almacén</strong>
                    <br />
                    <asp:Label ID="lbAlmacen" runat="server"></asp:Label>
                </div>

                <br />
                <br />
                <br />

                <div class="col-md-6">
                    <strong>Stock Mínimo</strong>
                    <br />
                    <asp:Label runat="server" ID="lbStockMinimo"></asp:Label>

                </div>

                <div class="col-md-6">
                    <strong>Stock Físico</strong>
                    <br />
                    <asp:Label runat="server" ID="lbStockFisico"></asp:Label>
                </div>


                <br />

                <div class="col-md-12">
                    <asp:PlaceHolder runat="server" ID="phListaArticulos" Visible="false">
                        <h4><strong>Lista de Artículos</strong></h4>
                        <div class="col-md-12" style="overflow: auto; height: 100%;">
                            <asp:Panel ID="pArticulos" runat="server"></asp:Panel>
                        </div>
                    </asp:PlaceHolder>
                </div>
            </div>

            <div class="col-md-6" align="center">
                <strong>Imágenes</strong>
                <asp:Panel ID="pImagenes" runat="server"></asp:Panel>
            </div>

        </div>

        <hr />

        <div class="row">
            <div class="col-md-3">
                <strong>Código</strong>
                <br />
                <asp:Label runat="server" ID="lbCodigo"></asp:Label>
            </div>

            <div class="col-md-3">
                <strong>Nombre</strong>
                <br />
                <asp:Label runat="server" ID="lbNombre"></asp:Label>
            </div>

            <div class="col-md-3">
                <strong>Referencia Picking</strong>
                <br />
                <asp:Label runat="server" ID="lbRefPick"></asp:Label>
            </div>

            <div class="col-md-3">
                <strong>Tipo de Unidad</strong>
                <br />
                <asp:Label ID="lbTipoUnidad" runat="server"></asp:Label>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-12">
                <h3><strong>Referencias Asociadas</strong></h3>
            </div>

            <div class="col-md-3">
                <strong>Referencia 1</strong>
                <br />
                <asp:Label runat="server" ID="lbRef1"></asp:Label>
            </div>

            <div class="col-md-3">
                <strong>Referencia 2</strong>
                <br />
                <asp:Label runat="server" ID="lbRef2"></asp:Label>
            </div>

            <div class="col-md-3">
                <strong>Referencia 3</strong>
                <br />
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
                <strong>Peso (Kgs)</strong>
                <br />
                <asp:Label runat="server" ID="lbPeso"></asp:Label>
            </div>

            <div class="col-md-2">
                <strong>Alto(cm)</strong>
                <br />
                <asp:Label runat="server" ID="lbAlto"></asp:Label>
                cm(s)
           
            </div>

            <div class="col-md-2">
                <strong>Largo (cm)</strong>
                <br />
                <asp:Label runat="server" ID="lbLargo"></asp:Label>
                cm(s)
           
            </div>

            <div class="col-md-2">
                <strong>Ancho(cm)</strong>
                <br />
                <asp:Label runat="server" ID="lbAncho"></asp:Label>
                cm(s)
           
            </div>

            <div class="col-md-2">
                <strong>M<sup>3</sup></strong>
                <br />
                <asp:Label runat="server" ID="lbCubicaje"></asp:Label>
                m<sup>3</sup>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-3">
                <strong>Coef. Volumétrico</strong>
                <br />
                <asp:Label runat="server" ID="lbCoefVol"></asp:Label>

            </div>

            <div class="col-md-3">
                <strong>Peso Volumétrico</strong>
                <br />
                <asp:Label runat="server" ID="lbPesoVol"></asp:Label>
            </div>
        </div>

        <hr />

        <div class="row">
            <div class="col-md-3">
                <strong>Tipo de Facturación</strong>
                <br />
                <asp:Label runat="server" ID="lbTipoFacturacion"></asp:Label>
            </div>

            <div class="col-md-2">
                <strong>Identificación</strong>
                <br />
                <asp:Label runat="server" ID="lbIdentificacion"></asp:Label>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-3">
                <strong>Valor Artículo</strong>
                <br />
                <asp:Label runat="server" ID="lbValArticulo"></asp:Label>
            </div>

            <div class="col-md-3">
                <strong>Valor Asegurado</strong>
                <br />
                <asp:Label runat="server" ID="lbValAsegurado"></asp:Label>
            </div>

            <div class="col-md-3">
                <strong>Valoración Stock</strong>
                <br />
                <asp:Label runat="server" ID="lbValStock"></asp:Label>
            </div>

            <div class="col-md-3">
                <strong>Valoración Seguro</strong>
                <br />
                <asp:Label runat="server" ID="lbValSeguro"></asp:Label>
            </div>

        </div>

        <hr />

        <div class="row">
            <div class="col-md-6">
                <strong>Observaciones Generales</strong>
                <asp:Label runat="server" ID="lbObsGen"></asp:Label>
            </div>

            <div class="col-md-6">
                <strong>Observaciones Artículo</strong>
                <asp:Label runat="server" ID="lbObsArt"></asp:Label>
            </div>
        </div>

        <br />
        <br />
    </div>

</asp:Content>
