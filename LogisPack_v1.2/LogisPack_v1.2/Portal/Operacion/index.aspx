<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="index.aspx.vb" Inherits="LogisPack_v1._2.index4" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
	<%: Scripts.Render("~/bundles/MisScripts") %>
	
	<script>
		var prm = Sys.WebForms.PageRequestManager.getInstance();
		if (prm != null) {
			prm.add_endRequest(function (sender, e) {
				if (sender._postBackSettings.panelsToUpdate != null) {
					$(document).ready(function () {
						$find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=hdfCliente.ClientID %>").value);
					});
				}
			});
		};

		$(document).ready(function () {
			$find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=hdfCliente.ClientID %>").value);
		});

	</script>

	<asp:UpdatePanel ID="updatePanelPrinicpal" runat="server">

		<ContentTemplate>

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

			<asp:HiddenField ID="hdfCliente" runat="server" />

			<div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">

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
					<div id="sectionContentFiltrosCabecera" class="section_Content collapse in">
						<div class="row_Content">
							<div class="row">
								<div class="col-md-1">
									<br />
									<label>Buscar</label>
								</div>

								<div class="col-md-2">
									<asp:DropDownList runat="server" ID="ddlBuscar">
										<asp:ListItem Text="articulo" Value="articulo"></asp:ListItem>
									</asp:DropDownList>
								</div>

								<div class="col-md-7">
									<asp:TextBox ID="txtSearch" runat="server" placeholder="Ingrese el texto a buscar"
										MaxLength="200" autocomplete="off" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>


									<cc1:AutoCompleteExtender ServiceMethod="Autocomplete" MinimumPrefixLength="1"
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
							<strong>Total Entrada</strong></div>
						<div class="col-md-6">
							<asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox></div>
					</div>
					<div class="col-md-3">
						<div class="col-md-6">
							<br />
							<strong>Total Salida</strong></div>
						<div class="col-md-6">
							<asp:TextBox ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox></div>
					</div>
					<div class="col-md-3">
						<div class="col-md-6">
							<br />
							<strong>Stock Físico</strong></div>
						<div class="col-md-6">
							<asp:TextBox ID="TextBox3" runat="server" ReadOnly="true"></asp:TextBox></div>
					</div>
					<div class="col-md-3">
						<div class="col-md-6">
							<br />
							<strong>Stock Mínimo</strong></div>
						<div class="col-md-6">
							<asp:TextBox ID="TextBox4" runat="server" ReadOnly="true"></asp:TextBox></div>
					</div>
				</div>

			</div>

		</ContentTemplate>
		<Triggers></Triggers>
	</asp:UpdatePanel>


</asp:Content>
