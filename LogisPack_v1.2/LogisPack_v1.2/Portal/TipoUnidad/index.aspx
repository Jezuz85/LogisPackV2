<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="index.aspx.vb" Inherits="LogisPack_v1._2.index2" %>

<%@ Register Src="~/Portal/WebUserControl/Alert.ascx" TagPrefix="uca" TagName="ucAlert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<asp:UpdatePanel ID="updatePanelPrinicpal" runat="server">
		<ContentTemplate>
			<asp:HiddenField ID="hfaccordion" runat="server" />

			<div id="titleContainer">
				<div class="MainContentTitle">
					<div class="MainContentTitleText">
						<ol class="breadcrumb">
							<li><a href="../../Default.aspx">Menu Principal</a></li>
							<li><a href="#">Tipo de Unidad</a></li>
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
					<div id="sectionContentFiltrosCabecera" class="section_Content collapse">
						<div class="row_Content">
							<div class="row">
								<div class="col-md-1">
									<br />
									<label>Buscar</label>
								</div>

								<div class="col-md-2">
									<asp:DropDownList runat="server" ID="ddlBuscar">
										<asp:ListItem Text="Nombre" Value="Nombre"></asp:ListItem>
									</asp:DropDownList>
								</div>

								<div class="col-md-7">

									<asp:TextBox ID="txtSearch" runat="server" placeholder="Ingrese el texto a buscar"
										MaxLength="200" autocomplete="off"></asp:TextBox>
								</div>

								<div class="col-md-2">
									<asp:Button ID="btnBuscar" runat="server" Text="Buscar" />

									<asp:Button ID="btnReset" runat="server" Text="Reset" />
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
								runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="30"
								OnPageIndexChanging="GridView1_PageIndexChanging"
								EmptyDataText="No existen Registros"
								OnRowCreated="GridView1_RowCreated"
								OnRowCommand="GridView1_RowCommand"
								OnSorting="GridView1_OnSorting"
								AllowSorting="true"
								CurrentSortField="id"
								CurrentSortDirection="ASC">

								<Columns>
									<asp:TemplateField HeaderText="Id Categoria" Visible="false" HeaderStyle-CssClass="text-center">
										<ItemTemplate>
											<asp:Label ID="id" runat="server" Text='<%# Eval("id_tipo_unidad") %>' />
										</ItemTemplate>
									</asp:TemplateField>

									<asp:BoundField DataField="nombre"
										HeaderText="Nombre"
										SortExpression="nombre"></asp:BoundField>

									<asp:ButtonField HeaderText="Editar" CommandName="Editar"
										ButtonType="Image" ImageUrl="~/Content/images/edit.png"
										HeaderStyle-CssClass="text-center"
										ItemStyle-HorizontalAlign="Center"></asp:ButtonField>

									<asp:ButtonField HeaderText="Eliminar" CommandName="Eliminar"
										ButtonType="Image" ImageUrl="~/Content/images/baja.png"
										HeaderStyle-CssClass="text-center"
										ItemStyle-HorizontalAlign="Center"></asp:ButtonField>

								</Columns>
							</asp:GridView>

						</div>
					</div>
				</div>

				<div class="row">
					<div class="col-md-12" align="right">
						
						<asp:Button ID="btnRegistrar" runat="server" data-toggle="modal"
							data-target="#AddModal" Text="Nuevo"/>
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
					<button id="btnAddCerrar" type="button" class="close" data-dismiss="modal" aria-hidden="true"><img alt="X" src="../../Content/images/baja.png" /></button>
					<h3><strong>Agregar Registro</strong></h3>
				</div>

				<asp:UpdatePanel ID="up_Add" runat="server">
					<ContentTemplate>
						<div class="modal-body form-group">

							<div class="row">
								<div class="col-md-8 col-md-offset-2">
									<h4><strong>Nombre</strong></h4>

									<asp:TextBox ID="txtNombre" MaxLength="40" runat="server" ClientIDMode="Static"
										data-toggle="tooltip" data-placement="bottom"
										title="Ingrese el nombre del Almacén"></asp:TextBox>

									<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true"
										Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true"
										ControlToValidate="txtNombre" runat="server" ValidationGroup="ValidationAdd" />
								</div>
							</div>
						</div>

						<div class="modal-footer">
							<div class="row">

								<div class="col-md-4 col-md-offset-4">
									<asp:Button ID="btnAdd" runat="server" Text="Guardar" class="btn btn-block btn-default" ValidationGroup="ValidationAdd" />
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
	<div id="EditModal" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">

				<div class="modal-header">
					<button id="btnEditCerrar" type="button" class="close" data-dismiss="modal" aria-hidden="true"><img alt="X" src="../../Content/images/baja.png" /></button>
					<h3><strong>Editar Registro</strong></h3>
				</div>

				<asp:UpdatePanel ID="up_Edit" runat="server">
					<ContentTemplate>

						<div class="modal-body form-group">

							<asp:HiddenField ID="hdfEdit" runat="server" />

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
									<asp:Button ID="btnEdit" runat="server" Text="Editar" class="btn btn-block btn-default" ValidationGroup="VG_Edit" />
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
	<div id="DeleteModal" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">

				<div class="modal-header">
					<button type="button" class="close" data-dismiss="modal" aria-hidden="true"><img alt="X" src="../../Content/images/baja.png" /></button>
					<h3><strong>Eliminar Registro</strong></h3>
				</div>

				<asp:UpdatePanel ID="upDel" runat="server">
					<ContentTemplate>

						<div class="modal-body form-group">
							<asp:HiddenField ID="hdfIDDel" runat="server" />

							<div class="row">
								<h4 class="text-center">¿Desea eliminar este registro?</h4>
							</div>
						</div>

						<div class="modal-footer">
							<div class="row">
								<div class="col-md-2 col-md-offset-5">
									<asp:Button ID="btnDelete" runat="server" Text="Eliminar" OnClick="EliminarRegistro" />
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
