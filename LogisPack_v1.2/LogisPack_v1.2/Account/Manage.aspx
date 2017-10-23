<%@ Page Title="Administrar cuenta" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Manage.aspx.vb" Inherits="LogisPack_v1._2.Manage" %>

<%@ Import Namespace="LogisPack_v1._2" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <div id="titleContainer">
        <div class="MainContentTitle">
            <div class="MainContentTitleText">
                <ol class="breadcrumb">
                    <li><a href="../../Default.aspx">Menu Principal</a></li>
                    <li><a href="#"><%: Title %>.</a></li>
                </ol>
            </div>
        </div>
    </div>

    <div id="pageBodyContainer" class="MainContentWrapper" style="width: 96%;">
        <div>
            <asp:PlaceHolder runat="server" ID="SuccessMessagePlaceHolder" Visible="false" ViewStateMode="Disabled">
                <p class="text-success"><%: SuccessMessage %></p>
            </asp:PlaceHolder>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="form-horizontal">
                    <h4>Cambiar la configuración de la cuenta</h4>
                    <hr />
                    <dl class="dl-horizontal">
                        <dt>Contraseña:</dt>
                        <dd>
                            <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="Click para gestionar la contraseña" Visible="false" ID="ChangePassword" runat="server" />
                            <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server" />
                        </dd>
                    </dl>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
