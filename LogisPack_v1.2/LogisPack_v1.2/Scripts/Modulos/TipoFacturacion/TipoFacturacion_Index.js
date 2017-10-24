
function pageLoad(sender, args) {

    if (args.get_isPartialLoad()) {
        load_TipoFacturacion();
        SetstateAcordeonPostback();
    }
    else {
        load_TipoFacturacion();
        SetstateAcordeon();
    }
}

function load_TipoFacturacion() {
    load_Acordeon();
    Autocomplete();
}