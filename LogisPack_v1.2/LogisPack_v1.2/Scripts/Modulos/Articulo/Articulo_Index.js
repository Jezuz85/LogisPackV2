function pageLoad(sender, args) {

    if (args.get_isPartialLoad())
    {
        load_Articulo();
        SetstateAcordeonPostback();
    }
    else
    {
        load_Articulo();
        SetstateAcordeon();
    }
}

function load_Articulo() {
    load_Acordeon();
    Autocomplete();
}