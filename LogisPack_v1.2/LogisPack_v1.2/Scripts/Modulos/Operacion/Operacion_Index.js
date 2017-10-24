
function pageLoad(sender, args) {

    if (args.get_isPartialLoad()) {
        load_Operacion();
        SetstateAcordeonPostback();
    }
    else {
        load_Operacion();
        SetstateAcordeon();
    }
}

function load_Operacion() {
    load_Acordeon();
    Autocomplete();
}