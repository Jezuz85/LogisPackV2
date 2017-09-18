<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MsjModal.ascx.vb" Inherits="LogisPack_v1._2.MsjModal" %>


<div class="modal fade" id="Msjmodal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Cerrar</span></button>
                <h4 class="modal-title">
                    <label id="lblMsjTitle"></label>
                </h4>
            </div>

            <div class="modal-body">
                <div class="row">
                    <div class="col-md-1 col-xs-1">
                        <span id="icoModal" class="fa fa-times fa-2x text-danger"></span>
                    </div>

                    <div class="col-md-11 col-xs-11">
                        <label id="lblMsjModal"></label>
                    </div>

                </div>

                <div class="clearfix"></div>

            </div>

            <div class="modal-footer">
                <button id="btnRedirect" type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
            </div>

        </div>

    </div>

</div>