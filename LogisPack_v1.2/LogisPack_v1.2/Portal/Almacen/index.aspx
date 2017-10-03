<%@ Page Title="ALmacén" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="index.aspx.vb" Inherits="LogisPack_v1._2.index" %>

<%@ Import Namespace="LogisPack_v1._2" %>

<%@ Register Src="~/Portal/WebUserControl/Alert.ascx" TagPrefix="uca" TagName="ucAlert" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
	<script>
		var prm = Sys.WebForms.PageRequestManager.getInstance();
		if (prm != null) {
			prm.add_endRequest(function (sender, e) {
				if (sender._postBackSettings.panelsToUpdate != null) {
					$(document).ready(function () {
						$find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=hdfCliente.ClientID %>").value + "|" +
                            $get("<%=hdfFiltro.ClientID %>").value);
                        
					});
				}
			});
		};

		$(document).ready(function () {
			$find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=hdfCliente.ClientID %>").value + "|" +
				$get("<%=hdfFiltro.ClientID %>").value);
		});

	</script>

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
			
			<asp:HiddenField ID="hdfCliente" runat="server" />
			<asp:HiddenField ID="hdfFiltro" runat="server" />

			<div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">

				<div class="section">
					<div class="sectionHeader">
						<div class="sectionHeaderTitle">
							Detalles Almacén
						</div>
						<div id="sectionHeaderButtons1" class="sectionHeaderButtons" data-toggle="collapse" data-target="#CabeceraTree">
							<img id="sectionHeaderButton1" class="sectionHeaderButton" src="../../Content/images/maximize_16x16.png">
						</div>
					</div>

					<!-- SECCIÓN FILTROS -->
					<div id="CabeceraTree" class="section_Content collapse">
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
						<div id="sectionHeaderButtons2" class="sectionHeaderButtons" data-toggle="collapse" data-target="#sectionContentFiltrosCabecera">
							<img id="sectionHeaderButton2" class="sectionHeaderButton" src="../../Content/images/minimize_16x16.png">
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
									<asp:DropDownList runat="server" ID="ddlBuscar"  AutoPostBack="true">
										<asp:ListItem Text="Código" Value="codigo"></asp:ListItem>
										<asp:ListItem Text="Cliente" Value="Cliente"></asp:ListItem>
										<asp:ListItem Text="Nombre" Value="Nombre"></asp:ListItem>
									</asp:DropDownList>
								</div>

								<div class="col-md-7">
									<asp:TextBox ID="txtSearch" runat="server" placeholder="Ingrese el texto a buscar"
										MaxLength="200" autocomplete="off" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
									
									<cc1:AutoCompleteExtender ServiceMethod="AutocompleteAlmacen" MinimumPrefixLength="1"
										CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
										TargetControlID="txtSearch" ID="AutoCompleteExtender1" runat="server"
										FirstRowSelected="false" CompletionListCssClass="completionList"
										ServicePath="~/Service/WebService1.asmx"  UseContextKey = "true"
										CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted">
									</cc1:AutoCompleteExtender>

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
							<asp:GridView ID="GridView1" class="grid gridSelectable gridSortable noPadding noMargin" runat="server"
								AutoGenerateColumns="false" AllowPaging="true" PageSize="30"
								OnRowCommand="GridView1_RowCommand"
								OnPageIndexChanging="GridView1_PageIndexChanging"
								EmptyDataText="No existen Registros"
								OnRowCreated="GridView1_RowCreated"
								OnSorting="GridView1_OnSorting"
								AllowSorting="true"
								CurrentSortField="id"
								CurrentSortDirection="ASC">

								<Columns>

									<asp:TemplateField Visible="false" HeaderStyle-CssClass="text-center">
										<ItemTemplate>
											<asp:Label ID="id" runat="server" Text='<%# Eval("id_almacen") %>' />
										</ItemTemplate>
									</asp:TemplateField>
									
									<asp:BoundField DataField="codigo"
										HeaderText="Código"
										SortExpression="codigo"></asp:BoundField>

									<asp:BoundField DataField="nombre"
										HeaderText="Nombre"
										SortExpression="Nombre"></asp:BoundField>

									<asp:BoundField DataField="cliente"
										HeaderText="Cliente"
										HeaderStyle-CssClass="text-center"
										SortExpression="Cliente"></asp:BoundField>

									<asp:BoundField DataField="coeficiente_volumetrico"
										HeaderText="Coeficiente Volumétrico"
										HeaderStyle-CssClass="text-center"
										SortExpression="Coeficiente"></asp:BoundField>

									<asp:ButtonField HeaderText="Editar" CommandName="Editar"
										ButtonType="Image" ImageUrl="~/Content/images/edit.png"
										HeaderStyle-CssClass="text-center"
										ItemStyle-HorizontalAlign="Center"></asp:ButtonField>

									<asp:ButtonField HeaderText="Detalles" CommandName="Detalles"
										ButtonType="Image" ImageUrl="~/Content/images/vermas.png"
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
								<div class="col-md-2 col-md-offset-2">
									<h4><strong>Cliente</strong></h4>
								</div>
								<div class="col-md-6">
									<asp:DropDownList ID="ddlClienteAdd" runat="server" data-toggle="tooltip"
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
									<asp:Button ID="btnAdd" runat="server" Text="Guardar" class="btn btn-block btn-default"
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
								<div class="col-md-2 col-md-offset-2">
									<h4><strong>Cliente</strong></h4>
								</div>
								<div class="col-md-6">
									<asp:DropDownList ID="ddlClienteEdit" runat="server" data-toggle="tooltip"
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
	<div id="ViewModal" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">

				<div class="modal-header">
					<button id="btnViewCerrar" type="button" class="close" data-dismiss="modal" aria-hidden="true"><img alt="X" src="../../Content/images/baja.png" /></button>
					<h3><strong>Ver Registro</strong></h3>
				</div>

				<asp:UpdatePanel ID="UpdatePanel2" runat="server">
					<ContentTemplate>
						<div class="modal-body form-group">
							<asp:HiddenField ID="hdfView" runat="server" />

							<div class="row">
								<div class="col-md-2 col-md-offset-2">
									<h3><strong>Código</strong></h3>
								</div>
								<div class="col-md-6">
									<h4>
										<asp:Label ID="lbViewCodigo" runat="server" ClientIDMode="Static"></asp:Label>
									</h4>

								</div>
							</div>

							<div class="row">
								<div class="col-md-2 col-md-offset-2">
									<h3><strong>Nombre</strong></h3>
								</div>
								<div class="col-md-6">
									<h4>
										<asp:Label ID="lbViewNombre" runat="server" ClientIDMode="Static"></asp:Label>
									</h4>
								</div>
							</div>

							<div class="row">
								<div class="col-md-5 col-md-offset-2">
									<h3><strong>Coeficiente volumétrico</strong></h3>
								</div>
								<div class="col-md-3">
									<h4>
										<asp:Label ID="lbViewCoefVol" runat="server" ClientIDMode="Static"></asp:Label>
									</h4>
								</div>
							</div>

							<div class="row">
								<div class="col-md-2 col-md-offset-2">
									<h3><strong>Cliente</strong></h3>
								</div>
								<div class="col-md-6">
									<h4>
										<asp:Label ID="lbViewCliente" runat="server" ClientIDMode="Static"></asp:Label>

									</h4>
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
								<h4 class="text-center"><strong>¿Desea eliminar este registro?</strong></h4>
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
