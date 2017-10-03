<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Crear.aspx.vb" Inherits="LogisPack_v1._2.Crear1" %>

<%@ Register Src="~/Portal/WebUserControl/Alert.ascx" TagPrefix="uca" TagName="ucAlert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="updatePanelPrinicpal" runat="server">

        <ContentTemplate>

            <div id="titleContainer">
                <div class="MainContentTitle">
                    <div class="MainContentTitleText">
                        <ol class="breadcrumb">
                            <li><a href="../../Default.aspx">Menu Principal</a></li>
                            <li><a href="index.aspx">Histórico de Transacciones</a></li>
                            <li><a href="#">Entrada-Salida de Artículos</a></li>
                        </ol>
                    </div>
                </div>
            </div>

            <div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">

                <!-- Alert -->
                <uca:ucAlert runat="server" ID="ucAlerta" />

                <div class="row">

                    <div class="col-md-3">
                        <strong>Cliente:</strong><br />
                        <asp:DropDownList ID="ddlCliente" runat="server" data-toggle="tooltip"
                            data-placement="bottom" title="Seleccione el cliente" AutoPostBack="true">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
                            ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="ddlCliente" runat="server"
                            ValidationGroup="ValidationAdd" />
                    </div>

                    <div class="col-md-3">
                        <strong>Almacén</strong><br />
                        <asp:DropDownList ID="ddlAlmacen" runat="server" data-toggle="tooltip"
                            data-placement="bottom" title="Seleccione el almacén" AutoPostBack="true">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
                            ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="ddlAlmacen" runat="server"
                            ValidationGroup="ValidationAdd" />
                    </div>

                    <div class="col-md-3">
                        <strong>Tipo de Operación</strong><br />

                        <asp:DropDownList runat="server" ID="ddlTipoOperacion" data-toggle="tooltip"
                            data-placement="bottom" title="Seleccione el tipo de Operación" AutoPostBack="true">
                            <asp:ListItem Text="Entrada" Value="Ent"></asp:ListItem>
                            <asp:ListItem Text="Salida" Value="Sal"></asp:ListItem>
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
                            ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="ddlTipoOperacion" runat="server"
                            ValidationGroup="ValidationAdd" />
                    </div>

                    <div class="col-md-3">
                        <strong>Fecha de Transacción</strong><br />

                        <asp:TextBox runat="server" type="date" ID="txtFechaOperacion" data-toggle="tooltip"
                            data-placement="bottom" title="Ingrese la fecha de la operación"></asp:TextBox>

                        <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
                            ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtFechaOperacion" runat="server"
                            ValidationGroup="ValidationAdd" />
                    </div>
                </div>

                <div class="row">

                    <div class="col-md-3">
                        <h4><strong>Documento Transacción</strong></h4>

                        <asp:FileUpload runat="server" ID="fuDocumento" data-toggle="tooltip" data-placement="bottom"
                            title="Seleccione el documento de la transaccion" />

                    </div>

                    <div class="col-md-3">
                        <h4><strong>Lista de Articulos</strong></h4>

                    </div>

                    <div class="col-md-3">
                        <h4><strong>Lista de Articulos</strong></h4>
                        <asp:DropDownList ID="ddlListaArticulos" runat="server" AutoPostBack="true"></asp:DropDownList>

                        <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
                            ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="ddlListaArticulos" runat="server"
                            ValidationGroup="ValidationAdd" />
                    </div>

                    <div class="col-md-3">
                        <h4><strong>Stock Fisico del Articulo</strong></h4>

                        <asp:Label ID="lbStockFisico" runat="server" Text="-"></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-3">
                        <h4><strong>Referencia</strong></h4>
                        <asp:TextBox runat="server" MaxLength="25" ID="txtRef" data-toggle="tooltip"
                            data-placement="bottom" title="Ingrese la referencia de la operacion"></asp:TextBox>

                        <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
                            ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtRef" runat="server"
                            ValidationGroup="ValidationAdd" />
                    </div>

                    <div class="col-md-3">
                        <h4><strong>Cantidad de la Transacción</strong></h4>

                        <asp:TextBox runat="server" type="number" min="0" ID="txtCantidad" data-toggle="tooltip"
                            data-placement="bottom" title="Ingrese la cantidad del articulo" AutoPostBack="true"></asp:TextBox>

                        <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
                            ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtCantidad" runat="server"
                            ValidationGroup="ValidationAdd" />

                    </div>
                </div>


                <div class="row">
                    <div class="col-md-12" align="right">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="ValidationAdd" />
                    </div>
                </div>

            </div>

        </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="btnGuardar" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
