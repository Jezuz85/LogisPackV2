<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Crear.aspx.vb" Inherits="LogisPack_v1._2.Crear" %>

<%@ Register Src="~/Portal/WebUserControl/Alert.ascx" TagPrefix="uca" TagName="ucAlert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="upAdd_Articulo" runat="server">
        <ContentTemplate>

            <div id="titleContainer">
                <div class="MainContentTitle">
                    <div class="MainContentTitleText">
                        <ol class="breadcrumb">
                            <li><a href="../../Default.aspx">Menu Principal</a></li>
                            <li><a href="index.aspx">Artículos</a></li>
                            <li><a href="#">Crear Artículo</a></li>
                        </ol>
                    </div>
                </div>
            </div>

            <div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">
                <!-- Alert -->
                <uca:ucAlert runat="server" ID="ucAlerta" />

                <div class="row">
                    <div class="col-md-2">
                        <strong>Tipo de Artículo</strong><br />

                        <asp:DropDownList runat="server" ID="ddlTipoArticulo" data-toggle="tooltip"
                            data-placement="bottom" title="Seleccione el tipo de Artículo">
                            <asp:ListItem Text="Normal" Value="Normal"></asp:ListItem>
                            <asp:ListItem Text="Picking" Value="Picking"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-2">
                        <strong>Cliente:</strong><br />
                        <asp:DropDownList ID="ddlCliente" runat="server" data-toggle="tooltip"
                            data-placement="bottom" title="Seleccione el cliente" AutoPostBack="true">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
                            ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="ddlCliente" runat="server"
                            ValidationGroup="ValidationAdd" />
                    </div>

                    <div class="col-md-2">
                        <strong>Almacén</strong><br />
                        <asp:DropDownList ID="ddlAlmacen" runat="server" data-toggle="tooltip"
                            data-placement="bottom" title="Seleccione el almacén" AutoPostBack="true">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
                            ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="ddlAlmacen" runat="server"
                            ValidationGroup="ValidationAdd" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <asp:PlaceHolder runat="server" ID="phListaArticulos" Visible="false">

                            <hr />

                            <div class="col-md-6">
                                <strong>Lista de Articulos</strong>

                                <asp:TextBox ID="txtArticulos1" runat="server" Rows="5" TextMode="multiline" ReadOnly="true"></asp:TextBox>
                                <asp:TextBox ID="txtArticulos2" runat="server" Rows="5" TextMode="multiline" Visible="false"></asp:TextBox>

                                <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
                                    ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtArticulos1" runat="server"
                                    ValidationGroup="ValidationAdd" />

                            </div>

                            <div class="col-md-6">
                                <div class="col-md-6">
                                    <strong>Articulos</strong><br />
                                    <asp:DropDownList ID="ddlListaArticulos" runat="server" data-toggle="tooltip"
                                        data-placement="bottom" title="Seleccione el Artículo">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-6" onkeydown="return (event.keyCode!=13)">
                                    <strong>Unidades del Articulos</strong><br />
                                    <asp:TextBox ID="txtUnidad" runat="server" type="number" min="0" step="0.01"></asp:TextBox>

                                    <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
                                        ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtUnidad" runat="server"
                                        ValidationGroup="Val_AddArticulo" />
                                </div>

                                <div class="col-md-12">
                                    <br />
                                    <asp:Button ID="btnAddArticuloRow" runat="server" CssClass="btn btn-default" Text="Añadir Articulo"
                                        ValidationGroup="Val_AddArticulo" CausesValidation="true" />
                                    <asp:Button ID="btnReset" runat="server" CssClass="btn btn-default" Text="Eliminar Articulos" />
                                </div>
                            </div>


                        </asp:PlaceHolder>
                    </div>
                </div>

                <hr />

                <div class="row" onkeydown="return (event.keyCode!=13)">
                    <div class="col-md-3">
                        <strong>Código</strong><br />

                        <asp:TextBox runat="server" MaxLength="25" ID="txtCodigo"
                            data-toggle="tooltip" data-placement="bottom" title="Ingrese el codigo del articulo"></asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <strong>Nombre</strong><br />
                        <asp:TextBox runat="server" MaxLength="40" ID="txtNombre" data-toggle="tooltip"
                            data-placement="bottom" title="Ingrese el nombre del artículo"></asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <strong>Referencia picking</strong><br />
                        <asp:TextBox runat="server" MaxLength="25" ID="txtRefPick" data-toggle="tooltip"
                            data-placement="bottom" title="Ingrese la referencia picking del artículo"></asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <strong>Tipo de Unidad</strong><br />
                        <asp:DropDownList ID="ddlTipoUnidad" runat="server" data-toggle="tooltip"
                            data-placement="bottom" title="Seleccione el Tipo de Unidad">
                        </asp:DropDownList>
                    </div>
                </div>


                <br />

                <div class="row" onkeydown="return (event.keyCode!=13)">
                    <div class="col-md-12">
                        <h3><strong>Referencias Asociadas</strong></h3>
                    </div>

                    <div class="col-md-3">
                        <strong>Referencia 1</strong>
                        <asp:TextBox runat="server" MaxLength="25" ID="txtRef1" data-toggle="tooltip"
                            data-placement="bottom" title="Ingrese la referencia 1 del artículo"></asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <strong>Referencia 2</strong>
                        <asp:TextBox runat="server" MaxLength="25" ID="txtRef2" data-toggle="tooltip"
                            data-placement="bottom" title="Ingrese la referencia 2 del artículo"></asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <strong>Referencia 3</strong>
                        <asp:TextBox runat="server" MaxLength="25" ID="txtRef3" data-toggle="tooltip"
                            data-placement="bottom" title="Ingrese la referencia 3 del artículo"></asp:TextBox>
                    </div>
                </div>

                <hr />

                <div class="row" onkeydown="return (event.keyCode!=13)">

                    <div class="col-md-12">
                        <h3><strong>Ubicación</strong></h3>
                    </div>


                    <div class="col-md-12">
                        <table class="table table-condensed">
                            <tbody>
                                <tr class="bg-aqua color-palette">
                                    <th class="col-md-1 text-center">Zona</th>
                                    <th class="col-md-1 text-center">Estante</th>
                                    <th class="col-md-1 text-center">Fila</th>
                                    <th class="col-md-1 text-center">Columna</th>
                                    <th class="col-md-1 text-center">Panel</th>
                                    <th class="col-md-7 text-center">Referencia Ubicación</th>
                                </tr>

                                <asp:Panel ID="pTabla" runat="server">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtZona0" runat="server" MaxLength="4"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEstante0" runat="server" MaxLength="4"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFila0" runat="server" MaxLength="4"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtColumna0" runat="server" MaxLength="4"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPanel0" runat="server" MaxLength="4"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRefUbi0" runat="server" MaxLength="40"></asp:TextBox>
                                        </td>
                                    </tr>
                                </asp:Panel>
                            </tbody>
                        </table>

                        <div class="col-md-6">
                            <asp:Button ID="btnAddFilaUbicacion" runat="server" CssClass="btn btn-default" Text="Agregar Otra Ubicación" />
                            <asp:Button ID="btnEliminarFila" runat="server" CssClass="btn btn-default" Text="Eliminar Ubicación"
                                ValidationGroup="ValidationAddRow" />
                        </div>
                    </div>
                </div>

                <hr />

                <div class="row" onkeydown="return (event.keyCode!=13)">
                    <div class="col-md-2">
                        <strong>Peso (Kgs)</strong>
                        <asp:TextBox runat="server" min="0" max="9999,999" ID="txtPeso" data-toggle="tooltip" type="number"
                            step="0.001" data-placement="bottom" title="Ingrese el peso del artículo"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <strong>Alto(cm)</strong>
                        <asp:TextBox runat="server" min="0" max="9999,9" ID="txtAlto" data-toggle="tooltip" type="number"
                            step="0.1" data-placement="bottom" title="Ingrese la altura del artículo"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <strong>Largo (cm)</strong>
                        <asp:TextBox runat="server" min="0" max="9999,9" ID="txtLargo" data-toggle="tooltip" type="number"
                            step="0.1" data-placement="bottom" title="Ingrese el largo del artículo"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <strong>Ancho(cm)</strong>
                        <asp:TextBox runat="server" min="0" max="9999,9" ID="txtAncho" data-toggle="tooltip" type="number"
                            step="0.1" data-placement="bottom" title="Ingrese el ancho del artículo"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <strong>Coef. Volumétrico</strong>
                        <asp:TextBox runat="server" min="0" max="9999,9" ID="txtCoefVol" data-toggle="tooltip" type="number"
                            step="0.1" data-placement="bottom" title="Ingrese el coeficiente volumétrico del artículo"></asp:TextBox>
                    </div>

                </div>

                <hr />

                <div class="row" onkeydown="return (event.keyCode!=13)">
                    <div class="col-md-2">
                        <strong>Tipo de Facturación</strong><br />
                        <asp:DropDownList ID="ddlTipoFacturacion" runat="server" data-toggle="tooltip"
                            data-placement="bottom" title="Seleccione el Tipo de Facturación">
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-2">
                        <strong>Identificación</strong><br />

                        <asp:DropDownList runat="server" ID="ddlIdentificacion" data-toggle="tooltip"
                            data-placement="bottom" title="Seleccione el tipo de Artículo">
                            <asp:ListItem Text="CB" Value="CB"></asp:ListItem>
                            <asp:ListItem Text="RF" Value="RF"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-2">
                        <strong>Valor artículo</strong><br />
                        <asp:TextBox runat="server" min="0" ID="txtValArticulo" data-toggle="tooltip" type="number"
                            step="0.01" data-placement="bottom" title="Ingrese el valor del artículo"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <strong>Valor Asegurado</strong><br />
                        <asp:TextBox runat="server" ID="txtValAsegurado" type="number" step="0.01"
                            data-placement="bottom" title="Ingrese el valor asegurado"></asp:TextBox>
                    </div>
                </div>

                <hr />

                <div class="row">
                    <div class="col-md-6">
                        <strong>Observaciones Generales</strong>
                        <asp:TextBox runat="server" ID="txtObsGen" data-toggle="tooltip" Rows="3"
                            TextMode="multiline" data-placement="bottom" title="Ingrese las observaciones generales"></asp:TextBox>
                        <div id="count1">0</div>
                        <div id="alert1" class="hidden">Has alcanzado el limite!</div>

                    </div>

                    <div class="col-md-6">
                        <strong>Observaciones Artículo</strong>
                        <asp:TextBox runat="server" MaxLength="300" ID="txtObsArt" data-toggle="tooltip" Rows="3"
                            TextMode="multiline" data-placement="bottom" title="Ingrese las observaciones del artículo"></asp:TextBox>
                        <div id="count2">0</div>
                        <div id="alert2" class="hidden">Has alcanzado el limite!</div>
                    </div>

                </div>


                <hr />

                <div class="row" onkeydown="return (event.keyCode!=13)">
                    <div class="col-md-2">
                        <strong>Stock mínimo</strong>
                        <asp:TextBox runat="server" min="0" ID="txtStockMinimo" data-toggle="tooltip"
                            type="number" step="0.01" data-placement="bottom" title="Ingrese el stock mínimo del artículo"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <strong>Stock físico</strong>
                        <asp:TextBox runat="server" min="0" ID="txtStockFisico" data-toggle="tooltip" type="number"
                            step="0.01" data-placement="bottom" title="Ingrese el stock fisico del artículo"></asp:TextBox>
                    </div>
                </div>

                <hr />

                <div class="row">
                    <div class="col-md-3">
                        <strong>Imagenes</strong><br />
                        <br />

                        <asp:FileUpload runat="server" ID="fuImagenes" data-toggle="tooltip" data-placement="bottom" AllowMultiple="true"
                            class="multiple" title="Seleccione las imagenes del articulo" accept=".png,.jpg,.jpeg,.gif" />
                    </div>
                </div>

                <hr />

                <div class="row">
                    <div class="col-md-3">
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-default" Text="Guardar" ValidationGroup="ValidationAdd" />
                    </div>
                </div>

            </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGuardar" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
