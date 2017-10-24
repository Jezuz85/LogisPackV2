
function pageLoad(sender, args) {

    if (args.get_isPartialLoad())
    {
        load_Cliente();
        SetstateAcordeonPostback();
    }
    else
    {
        load_Cliente();
        SetstateAcordeon();
    }
}

function load_Cliente()
{
    load_Acordeon();
    Autocomplete();
}