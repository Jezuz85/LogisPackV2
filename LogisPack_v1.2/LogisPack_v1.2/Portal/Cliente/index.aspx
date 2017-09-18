<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="index.aspx.vb" Inherits="LogisPack_v1._2.index5" %>

<%@ Register Src="~/Portal/WebUserControl/Alert.ascx" TagPrefix="uca" TagName="ucAlert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<asp:UpdatePanel ID="updatePanelPrinicpal" runat="server">
		<ContentTemplate>

			<div id="titleContainer">				
				<div class="MainContentTitle">
					<div class="MainContentTitleText">
						<ol class="breadcrumb">
							<li><a href="../../Default.aspx">Menu Principal</a></li>
							<li><a href="#">Clientes</a></li>
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
									<asp:TextBox ID="txtSearch" runat="server" placeholder="Ingrese el texto a buscar" maxlength="200" autocomplete="off"></asp:TextBox>
								</div>
								<div class="col-md-3">
									<asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-block btn-default"/>

								</div>
								<div class="col-md-3">
									<asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-block btn-default"/>
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

							<asp:GridView ID="GridView1" class="grid gridSelectable gridSortable noPadding noMargin"
								runat="server"
								AutoGenerateColumns="false"
								AllowPaging="true" PageSize="10"
								OnRowDeleting="GridView1_RowDeleting"
								OnRowEditing="GridView1_onRowEditing"
								OnPageIndexChanging="GridView1_PageIndexChanging" EmptyDataText="No existen Registros">

								<Columns>
									<asp:TemplateField HeaderText="Id Categoria" Visible="false" HeaderStyle-CssClass="text-center">
										<ItemTemplate>
											<asp:Label ID="id" runat="server" Text='<%# Eval("id_cliente") %>' />
										</ItemTemplate>
									</asp:TemplateField>

									<asp:TemplateField HeaderText="Código" HeaderStyle-CssClass="text-center">
										<ItemTemplate>
											<asp:Label ID="codigo" runat="server" Text='<%# Eval("codigo") %>' />
										</ItemTemplate>
									</asp:TemplateField>

									<asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="text-center">
										<ItemTemplate>
											<asp:Label ID="nombre" runat="server" Text='<%# Eval("nombre") %>' />
										</ItemTemplate>
									</asp:TemplateField>

									<asp:ButtonField HeaderText="Editar" CommandName="Edit" ButtonType="Image" Text="Editar"
										HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-default"></asp:ButtonField>

									<asp:ButtonField HeaderText="Eliminar" CommandName="Delete" ButtonType="Image" Text="Eliminar"
										HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-default"></asp:ButtonField>

								</Columns>
							</asp:GridView>
						</div>
					</div>


				</div>

				<div class="row">
					<div class="col-md-12">
						<asp:button  ID="btnRegistrar" runat="server" CssClass="btn btn-default" data-toggle="modal" 
							data-target="#AddModal" text="Crear Nuevo"/>
					</div>
				</div>

			</div>
			
		</ContentTemplate>
		<Triggers></Triggers>
	</asp:UpdatePanel>

	<!-- Add Modal -->
	<div id="AddModal" class="modal fade">
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
								<div class="col-md-8 col-md-offset-2">
									<h4><strong>Código</strong></h4>

									<asp:TextBox ID="txtCodigo_Add" MaxLength="10" runat="server" ClientIDMode="Static"
										 data-toggle="tooltip" data-placement="bottom"
										title="Ingrese el nombre del Almacén"></asp:TextBox>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="txtCodigo_Add" runat="server" ValidationGroup="Val_Add" />
								</div>
							</div>

							<div class="row">
								<div class="col-md-8 col-md-offset-2">
									<h4><strong>Nombre</strong></h4>

									<asp:TextBox ID="txtNombre_Add" MaxLength="50" runat="server" ClientIDMode="Static"
										 data-toggle="tooltip" data-placement="bottom"
										title="Ingrese el nombre del Almacén"></asp:TextBox>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="txtNombre_Add" runat="server" ValidationGroup="Val_Add" />
								</div>
							</div>
						</div>

						<div class="modal-footer">
							<div class="row">

								<div class="col-md-4 col-md-offset-4">
									<asp:Button ID="btnAdd" runat="server" Text="Registrar" class="btn btn-block btn-default"
										ValidationGroup="Val_Add" />
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
								<div class="col-md-8 col-md-offset-2">
									<h4><strong>Código</strong></h4>

									<asp:TextBox ID="txtCodigo_Edit" MaxLength="40" runat="server" ClientIDMode="Static"
										 data-toggle="tooltip" data-placement="bottom"
										title="Ingrese el nombre del Almacén"></asp:TextBox>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="txtCodigo_Edit" runat="server" ValidationGroup="VG_Edit" />
								</div>
							</div>


							<div class="row">
								<div class="col-md-8 col-md-offset-2">
									<h4><strong>Nombre</strong></h4>

									<asp:TextBox ID="txtNombre_Edit" MaxLength="40" runat="server" ClientIDMode="Static"
										 data-toggle="tooltip" data-placement="bottom"
										title="Ingrese el nombre del Almacén"></asp:TextBox>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="txtNombre_Edit" runat="server" ValidationGroup="VG_Edit" />
								</div>
							</div>
						</div>

						<div class="modal-footer">
							<div class="row">

								<div class="col-md-4 col-md-offset-4">
									<asp:Button ID="btnEdit" runat="server" Text="Editar" class="btn btn-block btn-default"
										ValidationGroup="VG_Edit" />
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
								<h4 class="text-center">¿Seguro desea eliminar este registro?</h4>
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