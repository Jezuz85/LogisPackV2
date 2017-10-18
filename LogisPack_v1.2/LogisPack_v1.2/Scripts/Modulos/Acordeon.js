
function load_Acordeon()
{
    $(btn_acordeon_Index).click(function () {

        if ($(acordeon_Index).css('display') == "none") {
            $(img_btn_acordeon_Index).attr("src", icono_minimizar);
        }
        else {
            $(img_btn_acordeon_Index).attr("src", icono_maximizar);
        }
        SetstateAcordeon();
    });

}

function SetstateAcordeon() {
    var stateActual = $(Hidden_Acordeon_Index).val();

    if (stateActual == 'off') {
        stateActual = 'in';
        $(Hidden_Acordeon_Index).val(stateActual);
    }
    else if (stateActual == 'in') {
        stateActual = 'off';
        $(Hidden_Acordeon_Index).val(stateActual);
    }
    else {
        stateActual = 'off';
        $(Hidden_Acordeon_Index).val(stateActual);
    }
}

function SetstateAcordeonPostback() {
    var stateActual = $(Hidden_Acordeon_Index).val();

    if (stateActual == 'off') {
        $(acordeon_Index).removeClass('in');
    }
    else if (stateActual == 'in') {
        $(acordeon_Index).addClass('in');
    }

}