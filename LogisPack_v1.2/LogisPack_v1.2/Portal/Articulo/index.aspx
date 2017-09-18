<%@ Page Title="Artículo" Language="vb" MasterPageFile="~/Site.Master"  AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="LogisPack_v1._2.index3" %>

<%@ Register Src="~/Portal/WebUserControl/Alert.ascx" TagPrefix="uca" TagName="ucAlert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:updatepanel id="updatePanelPrinicpal" runat="server">
        <ContentTemplate>

            <div id="titleContainer">
                <div class="MainContentTitle">
                    <div class="MainContentTitleText">
                        <ol class="breadcrumb">
                            <li><a href="../../Default.aspx">Menu Principal</a></li>
                            <li><a href="#">Artículo</a></li>
                        </ol>
                    </div>
                </div>
            </div>

            <div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">

                <div class="section">
                    <div id="sectionHeaderFiltros" class="sectionHeader">
                        <div class="sectionHeaderTitle">
                            Búsqueda
                        </div>
                        <div class="sectionHeaderButtons" data-toggle="collapse" data-target="#sectionContentFiltrosCabecera">
                            <img class="sectionHeaderButton" src="../../Content/images/minimize_16x16.png">
                        </div>
                    </div>

                    <!-- SECCIÓN FILTROS -->
                    <div id="sectionContentFiltrosCabecera" class="section_Content collapse in">
                        <div class="row_Content">

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtSearch" runat="server" placeholder="Ingrese el texto a buscar" MaxLength="200" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-block btn-default" />

                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-block btn-default" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="section">

                    <!-- Alert -->
                    <uca:ucAlert runat="server" ID="ucAlerta" />

                    <div class="sectionContent sectionGrid noPadding noMargin">
                        <div id="updGrid">

                            <asp:GridView ID="GridView1" class="grid gridSelectable gridSortable noPadding noMargin" runat="server"
                                AutoGenerateColumns="false" AllowPaging="true" PageSize="10"
                                OnRowCommand="GridView1_RowCommand"
                                OnRowDeleting="GridView1_RowDeleting"
                                OnRowEditing="GridView1_onRowEditing"
                                OnPageIndexChanging="GridView1_PageIndexChanging" EmptyDataText="No existen Registros">

                                <Columns>
                                    <asp:TemplateField HeaderText="Id Categoria" Visible="false" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:Label ID="id" runat="server" Text='<%# Eval("id_articulo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:Label ID="nombre" runat="server" Text='<%# Eval("nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:ButtonField CommandName="Edit" ButtonType="Image" Text="Editar"
                                        HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-default"></asp:ButtonField>
                                    <asp:ButtonField CommandName="Detalle" ButtonType="Image" Text="Detalle"
                                        HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-default"></asp:ButtonField>
                                    <asp:ButtonField CommandName="Delete" ButtonType="Image" Text="Eliminar"
                                        HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-default"></asp:ButtonField>

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-default" Text="Crear Nuevo" />
                    </div>
                </div>
            </div>

        </ContentTemplate>
        <Triggers></Triggers>
    </asp:updatepanel>

    <!-- Delete Modal -->
    <div id="DeleteModal"class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                    <h3><strong>Eliminar Registro</strong></h3>
                </div>

                <asp:updatepanel id="upDel" runat="server">
                    <ContentTemplate>
                        
                        <div class="modal-body form-group">
                            <asp:HiddenField id="hdfIDDel" runat="server"/>
                            
                            <div class="row">
                                <h4 class="text-center">¿Seguro desea eliminar este registro?</h4>
                            </div>
                        </div>
                        
                        <div class="modal-footer">
                            <div class="row">                                
                                <div class="col-md-4 col-md-offset-2">
                                    <asp:Button id="btnDelete" runat="server" Text="Eliminar" class="btn btn-block btn-info" 
                                        OnClick="EliminarRegistro"/>
                                </div>
                                
                                <div class="col-md-4">
                                    <button class="btn btn-block btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger Controlid="btnDelete" EventName="Click"/>
                    </Triggers>
                </asp:updatepanel>

            </div>
        </div>
    </div>

</asp:Content>