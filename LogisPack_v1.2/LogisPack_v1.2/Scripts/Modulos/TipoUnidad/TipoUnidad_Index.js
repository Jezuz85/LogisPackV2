
function pageLoad(sender, args) {

    if (args.get_isPartialLoad()) {
        load_TipoUnidad();
        SetstateAcordeonPostback();
    }
    else {
        load_TipoUnidad();
        SetstateAcordeon();
    }
}

function load_TipoUnidad() {
    load_Acordeon();
    Autocomplete();
}