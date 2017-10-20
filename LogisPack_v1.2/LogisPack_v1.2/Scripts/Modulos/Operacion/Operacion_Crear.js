function pageLoad(sender, args) {

    if (args.get_isPartialLoad()) {
        load_OperacionCrear();
    }
    else {
        load_OperacionCrear();
    }
}

function load_OperacionCrear() {

    
    $('#btn').click(function () {
        $(txtFechaOperacion).focus();
    });


}