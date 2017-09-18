﻿<%@ Page Title="ALmacén" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="index.aspx.vb" Inherits="LogisPack_v1._2.index" %>

<%@ Import Namespace="LogisPack_v1._2" %>

<%@ Register Src="~/Portal/WebUserControl/Alert.ascx" TagPrefix="uca" TagName="ucAlert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<asp:UpdatePanel ID="updatePanelPrinicpal" runat="server">
		<ContentTemplate>

			<div id="titleContainer">
				<div class="MainContentTitle">
					<div class="MainContentTitleText">
						<ol class="breadcrumb">
							<li><a href="../../Default.aspx">Menu Principal</a></li>
							<li><a href="#">Almacén</a></li>
						</ol>
					</div>
				</div>
			</div>

			<div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">

				<div class="section">
					<div class="sectionHeader">
						<div class="sectionHeaderTitle">
							Detalles Almacén
						</div>
						<div class="sectionHeaderButtons" data-toggle="collapse" data-target="#CabeceraTree">
							<img class="sectionHeaderButton" src="../../Content/images/minimize_16x16.png">
						</div>
					</div>

					<!-- SECCIÓN FILTROS -->
					<div id="CabeceraTree" class="section_Content collapse in">
						<div class="row_Content">
								<h3><strong>Cliente Asociado:</strong></h3>

								<div class="col-md-4">
									<h4><strong>Código Cliente:</strong></h4>
									<asp:Label ID="CodCliente" runat="server" Text="---"></asp:Label>
								</div>
								<div class="col-md-8">
									<h4><strong>Nombre del Cliente Asociado:</strong></h4>
									<asp:Label ID="NomCliente" runat="server" Text="Nombre del Cliente"></asp:Label>
								</div>

								<div class="col-md-4">
									<h4><strong>Código del Almacén:</strong></h4>
									<asp:Label ID="CodAlmacen" runat="server" Text="---"></asp:Label>
								</div>
								<div class="col-md-4">
									<h4><strong>Nombre del Álmacén:</strong></h4>
									<asp:Label ID="txtNomAlmacen" runat="server" Text="---"></asp:Label>
								</div>
								<div class="col-md-4">
									<h4><strong>Coeficiente volumétrico:</strong></h4>
									<asp:Label ID="CoefVol" runat="server" Text="---"></asp:Label>

								</div>

								<div class="col-md-6" style="overflow: auto; width: 100%; height: 200px;">
									<h4><strong>Almacenes Existentes:</strong></h4>

									<asp:TreeView ID="MyTreeView" runat="server" ImageSet="BulletedList" NodeIndent="15" class="well">
										<HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
										<NodeStyle Font-Names="Tahoma" Font-Size="12pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="0px"
											VerticalPadding="2px"></NodeStyle>
										<ParentNodeStyle Font-Bold="False" />
										<SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
									</asp:TreeView>
								</div>
						</div>
					</div>
				</div>

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
								OnPageIndexChanging="GridView1_PageIndexChanging"
								EmptyDataText="No existen Registros">

								<Columns>
									<asp:TemplateField HeaderText="Id Categoria" Visible="false" HeaderStyle-CssClass="text-center">
										<ItemTemplate>
											<asp:Label ID="id" runat="server" Text='<%# Eval("id_almacen") %>' />
										</ItemTemplate>
									</asp:TemplateField>

									<asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="text-center">
										<ItemTemplate>
											<asp:Label ID="nombre" runat="server" Text='<%# Eval("nombre") %>' />
										</ItemTemplate>
									</asp:TemplateField>

									<asp:TemplateField HeaderText="Id Cliente" HeaderStyle-CssClass="text-center">
										<ItemTemplate>
											<asp:Label ID="id_cliente" runat="server" Text='<%# Eval("id_cliente") %>' />
										</ItemTemplate>
									</asp:TemplateField>

									<asp:TemplateField HeaderText="coeficiente_volumetrico" HeaderStyle-CssClass="text-center">
										<ItemTemplate>
											<asp:Label ID="coeficiente_volumetrico" runat="server" Text='<%# Eval("coeficiente_volumetrico") %>' />
										</ItemTemplate>
									</asp:TemplateField>

									<asp:ButtonField CommandName="Edit" ButtonType="Image" Text="Editar"
										HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center"
										ControlStyle-CssClass="btn btn-default"></asp:ButtonField>

									<asp:ButtonField CommandName="View" ButtonType="Image" Text="Detalles"
										HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center"
										ControlStyle-CssClass="btn btn-default"></asp:ButtonField>

									<asp:ButtonField CommandName="Delete" ButtonType="Image" Text="Eliminar"
										HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center"
										ControlStyle-CssClass="btn btn-default"></asp:ButtonField>

								</Columns>
							</asp:GridView>
						</div>
					</div>
				</div>

				<div class="row">
					<div class="col-md-12">
						<asp:ImageButton AlternateText="Registrar" ID="btnCrear" runat="server" CssClass="btn btn-default" data-toggle="modal" data-target="#AddModal" />
					</div>
				</div>
			</div>

		</ContentTemplate>
		<Triggers></Triggers>
	</asp:UpdatePanel>


	<!-- Add Modal -->
	<div id="AddModal"class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">

				<div class="modal-header">
					<button id="btnAddCerrar" type="button" class="close" data-dismiss="modal" aria-hidden="true">Cerrar</button>
					<h3><strong>Agregar Registro</strong></h3>
				</div>

				<asp:UpdatePanel ID="up_Add" runat="server">
					<ContentTemplate>
						<div class="modal-body form-group">
							
							<div class="row">
								<div class="col-md-2 col-md-offset-2">
									<h4><strong>Cliente</strong></h4>
								</div>
								<div class="col-md-6">
									<asp:DropDownList ID="ddlClienteAdd" runat="server"  data-toggle="tooltip"
										data-placement="bottom" title="Seleccione el cliente" AutoPostBack="true">
									</asp:DropDownList>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="ddlClienteAdd" runat="server" ValidationGroup="ValidationAdd" />
								</div>
							</div>

							<div class="row">
								<div class="col-md-2 col-md-offset-2">
									<strong>Código</strong>
								</div>
								<div class="col-md-6">

									<asp:TextBox ID="txtCodigo" MaxLength="15" runat="server" ClientIDMode="Static"
										data-toggle="tooltip" data-placement="bottom"
										title="Ingrese el nombre del Almacén"></asp:TextBox>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="txtCodigo" runat="server" ValidationGroup="ValidationAdd" />
								</div>
							</div>

							<div class="row">
								<div class="col-md-2 col-md-offset-2">
									<h4><strong>Nombre</strong></h4>
								</div>
								<div class="col-md-6">

									<asp:TextBox ID="txtNombre" MaxLength="40" runat="server" ClientIDMode="Static"
										 data-toggle="tooltip" data-placement="bottom"
										title="Ingrese el nombre del Almacén"></asp:TextBox>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="txtNombre" runat="server" ValidationGroup="ValidationAdd" />
								</div>
							</div>

							<div class="row">
								<div class="col-md-4 col-md-offset-2">
									<h4><strong>Coeficiente volumétrico</strong></h4>
								</div>
								<div class="col-md-4">
									<asp:TextBox ID="txtCoefVol" runat="server" ClientIDMode="Static" type="number" step="0.1"
										data-toggle="tooltip" data-placement="bottom"
										title="Ingrese la descripción de la categoria"></asp:TextBox>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="txtCoefVol" runat="server" ValidationGroup="ValidationAdd" />
								</div>
							</div>

						</div>

						<div class="modal-footer">
							<div class="row">
								<div class="col-md-4 col-md-offset-4">
									<asp:Button ID="btnAdd" runat="server" Text="Registrar" class="btn btn-block btn-default" 
										ValidationGroup="ValidationAdd" />
								</div>
							</div>
						</div>
					</ContentTemplate>
					<Triggers>
						<asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
					</Triggers>
				</asp:UpdatePanel>
			</div>
		</div>
	</div>

	<!-- Edit Modal -->
	<div id="EditModal"class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">

				<div class="modal-header">
					<button id="btnEditCerrar" type="button" class="close" data-dismiss="modal" aria-hidden="true">Cerrar</button>
					<h3><strong>Editar Registro</strong></h3>
				</div>

				<asp:UpdatePanel ID="up_Edit" runat="server">
					<ContentTemplate>
						<div class="modal-body form-group">
							<asp:HiddenField ID="hdfEdit" runat="server" />
							
							<div class="row">
								<div class="col-md-2 col-md-offset-2">
									<h4><strong>Cliente</strong></h4>
								</div>
								<div class="col-md-6">
									<asp:DropDownList ID="ddlClienteEdit" runat="server"  data-toggle="tooltip"
										data-placement="bottom" title="Seleccione el cliente" AutoPostBack="true">
									</asp:DropDownList>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="ddlClienteEdit" runat="server" ValidationGroup="ValidationEdit" />
								</div>
							</div>

							<div class="row">
								<div class="col-md-2 col-md-offset-2">
									<h4><strong>Código</strong></h4>
								</div>
								<div class="col-md-6">
									<asp:TextBox ID="txtEditCodigo" MaxLength="15" runat="server" ClientIDMode="Static"
										 data-toggle="tooltip" data-placement="bottom"
										title="Ingrese el nombre del Almacén"></asp:TextBox>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="txtEditCodigo" runat="server" ValidationGroup="ValidationEdit" />
								</div>
							</div>

							<div class="row">
								<div class="col-md-2 col-md-offset-2">
									<h4><strong>Nombre</strong></h4>
								</div>
								<div class="col-md-6">

									<asp:TextBox ID="txtEditNombre" MaxLength="40" runat="server" ClientIDMode="Static"
										 data-toggle="tooltip" data-placement="bottom"
										title="Ingrese el nombre del Almacén"></asp:TextBox>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="txtEditNombre" runat="server" ValidationGroup="ValidationEdit" />
								</div>
							</div>

							<div class="row">
								<div class="col-md-4 col-md-offset-2">
									<h4><strong>Coeficiente volumétrico</strong></h4>
								</div>
								<div class="col-md-4">

									<asp:TextBox ID="txtEditCoefVol" runat="server" ClientIDMode="Static" type="number" step="0.1"
										 data-toggle="tooltip" data-placement="bottom"
										title="Ingrese la descripción de la categoria"></asp:TextBox>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="txtEditCoefVol" runat="server" ValidationGroup="ValidationEdit" />
								</div>
							</div>
						</div>

						<div class="modal-footer">
							<div class="row">

								<div class="col-md-4 col-md-offset-4">
									<asp:Button ID="btnEdit" runat="server" Text="Editar" class="btn btn-block btn-default" ValidationGroup="ValidationEdit" />
								</div>
							</div>
						</div>
					</ContentTemplate>
					<Triggers>
						<asp:AsyncPostBackTrigger ControlID="btnEdit" EventName="Click" />
					</Triggers>
				</asp:UpdatePanel>
			</div>
		</div>
	</div>

	<!-- View Modal -->
	<div id="ViewModal"class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">

				<div class="modal-header">
					<button id="btnViewCerrar" type="button" class="close" data-dismiss="modal" aria-hidden="true">Cerrar</button>
					<h3><strong>Ver Registro</strong></h3>
				</div>

				<asp:UpdatePanel ID="UpdatePanel2" runat="server">
					<ContentTemplate>
						<div class="modal-body form-group">
							<asp:HiddenField ID="hdfView" runat="server" />

							<div class="row">
								<div class="col-md-8 col-md-offset-2">
									<h4><strong>Código</strong></h4>
									<asp:Label ID="lbViewCodigo" runat="server" ClientIDMode="Static"></asp:Label>
								</div>
							</div>

							<div class="row">
								<div class="col-md-8 col-md-offset-2">
									<h4><strong>Nombre</strong></h4>
									<asp:Label ID="lbViewNombre" runat="server" ClientIDMode="Static"></asp:Label>
								</div>
							</div>

							<div class="row">
								<div class="col-md-8 col-md-offset-2">
									<h4><strong>Coeficiente volumétrico</strong></h4>
									<asp:Label ID="lbViewCoefVol" runat="server" ClientIDMode="Static"></asp:Label>
								</div>
							</div>

							<div class="row">
								<div class="col-md-8 col-md-offset-2">
									<h4><strong>Cliente</strong></h4>
									<asp:Label ID="lbViewCliente" runat="server" ClientIDMode="Static"></asp:Label>
								</div>
							</div>
						</div>

					</ContentTemplate>
					<Triggers></Triggers>
				</asp:UpdatePanel>
			</div>
		</div>
	</div>

	<!-- Delete Modal -->
	<div id="DeleteModal"class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">

				<div class="modal-header">
					<button type="button" class="close" data-dismiss="modal" aria-hidden="true">Cerrar</button>
					<h3><strong>Eliminar Registro</strong></h3>
				</div>

				<asp:UpdatePanel ID="upDel" runat="server">
					<ContentTemplate>

						<div class="modal-body form-group">
							<asp:HiddenField ID="hdfIDDel" runat="server" />

							<div class="row">
								<h4 class="text-center"><strong>¿Seguro desea eliminar este registro?</strong></h4>
							</div>
						</div>

						<div class="modal-footer">
							<div class="row">
								<div class="col-md-4 col-md-offset-2">
									<asp:Button ID="btnDelete" runat="server" Text="Eliminar" class="btn btn-block btn-info"
										OnClick="EliminarRegistro" />
								</div>

								<div class="col-md-4">
									<button class="btn btn-block btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
								</div>
							</div>
						</div>
					</ContentTemplate>
					<Triggers>
						<asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
					</Triggers>
				</asp:UpdatePanel>

			</div>
		</div>
	</div>

</asp:Content>
