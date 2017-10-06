<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CargaMasiva.aspx.vb" Inherits="LogisPack_v1._2.CargaMasiva" %>

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
				<uca:ucalert runat="server" id="ucAlerta" />
				
				<div class="row">
					<div class="col-md-2">
						<strong>Cliente:</strong>
						<br />
						<asp:DropDownList ID="ddlCliente" runat="server" data-toggle="tooltip" data-placement="bottom" 
							title="Seleccione el cliente" AutoPostBack="true">
						</asp:DropDownList>
					</div>

					<div class="col-md-2">
						<strong>Almacén</strong>
						<br />
						<asp:DropDownList ID="ddlAlmacen" runat="server" data-toggle="tooltip" data-placement="bottom" 
							title="Seleccione el almacén">
						</asp:DropDownList>

						<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
							ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="ddlAlmacen" runat="server"
							ValidationGroup="ValidationAdd" />
					</div>
				</div>

				<br />

				<div class="row">

					<div class="col-md-6">
						<strong>Seleccione el archivo excel:</strong>
						<br /><br />
						<asp:FileUpload runat="server" ID="fuExcel" accept=".xls,.xlsx" ValidationGroup="ValidationAdd"/>

						<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" SetFocusOnError="true" Display="Dynamic"
							ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="fuExcel" runat="server"
							ValidationGroup="ValidationAdd" />
					</div>
				</div>

				<hr />

				<div class="row">
					<div class="col-md-12" align="right">
						<asp:Button ID="btnGuardar" runat="server" Text="Cargar" ValidationGroup="ValidationAdd" />
					</div>
				</div>

			</div>

		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="btnGuardar" />
		</Triggers>
	</asp:UpdatePanel>

</asp:Content>
