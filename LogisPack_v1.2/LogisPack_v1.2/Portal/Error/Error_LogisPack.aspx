<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Error_LogisPack.aspx.vb" Inherits="LogisPack_v1._2.Error_LogisPack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
	
	<div id="titleContainer">
		<div class="MainContentTitle">
			<div class="MainContentTitleText">
				<ol class="breadcrumb">
					<li><a href="../Default.aspx">Menu Principal</a></li>
					<li><a href="#">Error</a></li>
				</ol>
			</div>
		</div>
	</div>

	<div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">
		<div class="container">
			<div class="jumbotron">
				<h1><i class="fa fa-warning text-red"></i>Oops! Hubo un error inesperado!.</h1>
				<p>
					Lo sentimos! Ocurrió un error inesperado, ya se informó al administrador sobre el error sucedido,
					puede redirigirse al inicio por medio de este link : <a href="../../Default.aspx"  role="button">Inicio</a>
				</p>
			</div>
		</div>
	</div>

</asp:Content>
