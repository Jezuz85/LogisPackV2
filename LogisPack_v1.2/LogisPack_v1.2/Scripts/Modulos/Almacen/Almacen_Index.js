
function pageLoad(sender, args) {
    
    if (args.get_isPartialLoad())
    {
        load_Almacen();
        SetstateAcordeonPostback_Arbol();
        SetstateAcordeonPostback();
    }
    else
    {
        load_Almacen();
        SetstateAcordeonArbol();
        SetstateAcordeon();
    }
}

function load_Almacen()
{
    load_Acordeon();
    Autocomplete();

    $(btn_acordeon_Arbol).click(function () {

        if ($(acordeon_Arbol).css('display') == "none") {
            $(img_btn_acordeon_Arbol).attr("src", icono_minimizar);
        }
        else {
            $(img_btn_acordeon_Arbol).attr("src", icono_maximizar);
        }
        SetstateAcordeonArbol();
    });
}

function SetstateAcordeonArbol() {

    var stateActual = $(Hidden_Acordeon_Arbol).val();

    if (stateActual == 'off')
    {
        stateActual = 'in';
        $(Hidden_Acordeon_Arbol).val(stateActual);
    }
    else if (stateActual == 'in')
    {
        stateActual = 'off';
        $(Hidden_Acordeon_Arbol).val(stateActual);
    }
    else
    {
        stateActual = 'off';
        $(Hidden_Acordeon_Arbol).val(stateActual);
    }
}

function SetstateAcordeonPostback_Arbol()
{
    var stateActual = $(Hidden_Acordeon_Arbol).val();

    if (stateActual == 'off')
    {
        $(acordeon_Arbol).removeClass('in');
    }
    else if (stateActual == 'in')
    {
        $(acordeon_Arbol).addClass('in');
    }

}
