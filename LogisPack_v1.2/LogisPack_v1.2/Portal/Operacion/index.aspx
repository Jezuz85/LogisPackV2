<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="index.aspx.vb" Inherits="LogisPack_v1._2.index4" %>

<%@ Register Src="~/Portal/WebUserControl/Alert.ascx" TagPrefix="uca" TagName="ucAlert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<asp:updatepanel id="updatePanelPrinicpal" runat="server">
		<ContentTemplate>

			<div id="titleContainer">
				<div class="MainContentTitle">
					<div class="MainContentTitleText">
						<ol class="breadcrumb">
							<li><a href="../../Default.aspx">Menu Principal</a></li>
							<li><a href="#">Entrada/Salida de Artículos</a></li>
						</ol>
					</div>
				</div>
			</div>

			<div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">

				<div class="row">

					<div class="col-md-3">
						<h4>Tipo de Operación</h4>

						<asp:DropDownList runat="server" ID="ddlTipoOperacion" data-toggle="tooltip"
							data-placement="bottom" title="Seleccione el tipo de Operación">
							<asp:ListItem Text="Entrada" Value="Ent"></asp:ListItem>
							<asp:ListItem Text="Salida" Value="Sal"></asp:ListItem>
						</asp:DropDownList>

						<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
							ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="ddlTipoOperacion" runat="server"
							ValidationGroup="ValidationAdd" />
					</div>

					<div class="col-md-3">
						<h4>Fecha de Operación</h4>

						<asp:TextBox runat="server" type="date" ID="txtFechaOperacion" data-toggle="tooltip"
							data-placement="bottom" title="Ingrese la fecha de la operación"></asp:TextBox>

						<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
							ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtFechaOperacion" runat="server"
							ValidationGroup="ValidationAdd" />
					</div>

					<div class="col-md-3">
						<h4>Referencia</h4>
						<asp:TextBox runat="server" MaxLength="25" ID="txtRef" data-toggle="tooltip"
							data-placement="bottom" title="Ingrese la referencia de la operacion"></asp:TextBox>

						<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
							ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtRef" runat="server"
							ValidationGroup="ValidationAdd" />
					</div>

					<div class="col-md-3">
						<h4>Cantidad de la operacion</h4>

						<asp:TextBox runat="server" type="number" min="0" ID="txtCantidad" data-toggle="tooltip"
							data-placement="bottom" title="Ingrese la cantidad del articulo"></asp:TextBox>

						<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
							ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtCantidad" runat="server"
							ValidationGroup="ValidationAdd" />

					</div>

				</div>

				<div class="row">

					<div class="col-md-3">
						<h4>Lista de Articulos</h4>
						<asp:DropDownList ID="ddlListaArticulos" runat="server" data-toggle="tooltip"
							data-placement="bottom" title="Seleccione el Artículo">
						</asp:DropDownList>

						<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
							ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="ddlListaArticulos" runat="server"
							ValidationGroup="ValidationAdd" />
					</div>

					<div class="col-md-3">
						<h4>Documento Transacción</h4>

						<asp:FileUpload runat="server" ID="fuDocumento" data-toggle="tooltip" data-placement="bottom"
							title="Seleccione el documento de la transaccion" />

						<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
							ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="fuDocumento" runat="server"
							ValidationGroup="ValidationAdd" />
					</div>


				</div>

				<hr />

				<div class="row">
					<div class="col-md-3">
						<asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-default" Text="Guardar"
							ValidationGroup="ValidationAdd" />
					</div>
				</div>
			</div>

		
		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger Controlid="btnGuardar"/></Triggers>
	</asp:updatepanel>
	
</asp:Content>
