<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Alert.ascx.vb" Inherits="LogisPack_v1._2.Alert" %>

<asp:PlaceHolder ID="AlertExito" runat="server" Visible="false">
    <div class="alert alert-success fade in">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <asp:Label ID="lbAlertMsjExito" runat="server" Text="Label"></asp:Label>
    </div>

</asp:PlaceHolder>

<asp:PlaceHolder ID="AlertFalla" runat="server" Visible="false">
    <div class="alert alert-danger fade in">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <asp:Label ID="lbAlertMsjFalla" runat="server" Text="Label"></asp:Label>
    </div>
</asp:PlaceHolder>
