function pageLoad(sender, args) {

    if (args.get_isPartialLoad())
    {
        load_Articulo();
        SetstateAcordeonPostback_Arbol();
        SetstateAcordeonPostback();
    }
    else
    {
        load_Articulo();
        SetstateAcordeonArbol();
        SetstateAcordeon();
    }
}

function load_Articulo() {
    load_Acordeon();
}