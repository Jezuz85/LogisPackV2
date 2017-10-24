<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Fabricar.aspx.vb" Inherits="LogisPack_v1._2.Fabricar" %>

<%@ Register Src="~/Portal/WebUserControl/Alert.ascx" TagPrefix="uca" TagName="ucAlert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
	
	<asp:UpdatePanel ID="updatePanelPrinicpal" runat="server">

		<ContentTemplate>

			<div id="titleContainer">
				<div class="MainContentTitle">
					<div class="MainContentTitleText">
						<ol class="breadcrumb">
							<li><a href="../../Default.aspx">Menu Principal</a></li>
							<li><a href="index.aspx">Histórico de Transacciones</a></li>
							<li><a href="#">Fabricación Artículo Picking</a></li>
						</ol>
					</div>
				</div>
			</div>

			<div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">

				<!-- Alert -->
				<uca:ucAlert runat="server" ID="ucAlerta" />



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
