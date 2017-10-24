function pageLoad(sender, args) {

    if (args.get_isPartialLoad()) {
        load_OperacionCrear();
    }
    else {
        load_OperacionCrear();
    }
}

function load_OperacionCrear()
{
    //Funciones para fecha en input
    $(function () {
        $(".date-picker").datepicker({
            dateFormat: 'dd/mm/yy'
        });

    });

    $('#btn').click(function ()
    {
        $(txtFechaOperacion).focus();
    });
}