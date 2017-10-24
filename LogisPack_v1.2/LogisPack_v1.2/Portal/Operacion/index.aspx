<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="index.aspx.vb" Inherits="LogisPack_v1._2.index4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<asp:UpdatePanel ID="updatePanelPrinicpal" runat="server">
		<ContentTemplate>

			<asp:HiddenField ID="hfaccordion" runat="server" />
			<asp:HiddenField ID="hdfFiltro" runat="server" />
			<asp:HiddenField ID="hdfCliente" runat="server" />

			<div id="titleContainer">
				<div class="MainContentTitle">
					<div class="MainContentTitleText">
						<ol class="breadcrumb">
							<li><a href="../../Default.aspx">Menu Principal</a></li>
							<li><a href="#">Histórico de Transacciones</a></li>
						</ol>
					</div>
				</div>
			</div>

			<div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">
				
				<div class="row">
					<div class="col-md-2">
						<strong>Cliente</strong>
						<asp:DropDownList runat="server" ID="ddlCliente"  AutoPostBack="true"/>
					</div>
					<div class="col-md-2">
						<strong>Almacén</strong>
						<asp:DropDownList runat="server" ID="ddlAlmacen"  AutoPostBack="true"/>
					</div>

					<div class="col-md-2">
						<strong>Artículo</strong>
						<asp:DropDownList runat="server" ID="ddlArticulo"  AutoPostBack="true"/>
					</div>
				</div>

				<br />

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
									<asp:DropDownList runat="server" ID="ddlBuscar" AutoPostBack="true"></asp:DropDownList>
								</div>

								<div class="col-md-7">
									<asp:TextBox ID="txtSearch" runat="server" 
										placeholder="Ingrese el texto a buscar"
										MaxLength="200" AutoPostBack="true"></asp:TextBox>
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
					<div class="sectionContent sectionGrid noPadding noMargin">
						<div id="updGrid">
							<asp:GridView ID="GridView1" class="grid gridSelectable gridSortable noPadding noMargin"
								runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="30"
								OnPageIndexChanging="GridView1_PageIndexChanging"
								EmptyDataText="No existen Registros"
								OnRowCreated="GridView1_RowCreated"
								OnSorting="GridView1_OnSorting"
								AllowSorting="true"
								CurrentSortField="id"
								CurrentSortDirection="ASC">

								<Columns>
									<asp:TemplateField HeaderText="Id" Visible="false" HeaderStyle-CssClass="text-center">
										<ItemTemplate>
											<asp:Label ID="id" runat="server" Text='<%# Eval("id_historico") %>' />
										</ItemTemplate>
									</asp:TemplateField>

									<asp:BoundField DataField="fecha_transaccion"
										HeaderText="Fecha Transaccion"
										SortExpression="fecha_transaccion"
										DataFormatString="{0:dd-M-yyyy}"></asp:BoundField>

									<asp:BoundField DataField="articulo"
										HeaderText="Artículo"
										SortExpression="articulo"></asp:BoundField>

									<asp:BoundField DataField="tipo_transaccion"
										HeaderText="Tipo Transaccion"
										SortExpression="tipo_transaccion"></asp:BoundField>

									<asp:BoundField DataField="cantidad_transaccion"
										HeaderText="Cantidad"
										SortExpression="cantidad_transaccion"></asp:BoundField>

									<asp:BoundField DataField="referencia_ubicacion"
										HeaderText="Referencia Ubicación"
										SortExpression="referencia_ubicacion"></asp:BoundField>

									<asp:TemplateField HeaderText="Ver" HeaderStyle-CssClass="text-center">
										<ItemTemplate>
											<asp:HyperLink runat="server" NavigateUrl='<%# Eval("documento_transaccion") %>' Target="_blank">
												<img alt="X" src="../../Content/images/vermas.png" />
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateField>

								</Columns>
							</asp:GridView>
						</div>
					</div>
				</div>

				<div class="row">
					<div class="col-md-12" align="right">
						<asp:Button ID="btnGuardar" runat="server" Text="Nuevo" />
					</div>
				</div>

				<hr />

				<div class="row">
					<div class="col-md-3">
						<div class="col-md-6">
							<br />
							<strong>Total Entrada</strong>
						</div>
						<div class="col-md-6">
							<asp:TextBox ID="txtTotalEntrada" runat="server" ReadOnly="true"></asp:TextBox>
						</div>
					</div>

					<div class="col-md-3">
						<div class="col-md-6">
							<br />
							<strong>Total Salida</strong>
						</div>
						<div class="col-md-6">
							<asp:TextBox ID="txtTotalSalida" runat="server" ReadOnly="true"></asp:TextBox>
						</div>
					</div>

					<div class="col-md-3">
						<div class="col-md-6">
							<br />
							<strong>Stock Físico</strong>
						</div>
						<div class="col-md-6">
							<asp:TextBox ID="txtStockFisico" runat="server" ReadOnly="true"></asp:TextBox>
						</div>
					</div>

					<div class="col-md-3">
						<div class="col-md-6">
							<br />
							<strong>Stock Mínimo</strong>
						</div>
						<div class="col-md-6">
							<asp:TextBox ID="txtStockMinimo" runat="server" ReadOnly="true"></asp:TextBox>
						</div>
					</div>
				</div>

			</div>

		</ContentTemplate>

		<Triggers></Triggers>
	</asp:UpdatePanel>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
	<%: Scripts.Render("~/bundles/Operacion_Index") %>
</asp:Content>