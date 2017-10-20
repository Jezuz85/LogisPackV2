function pageLoad(sender, args) {

    if (args.get_isPartialLoad()) {
        loadCustom();
    }
    else {
        loadCustom();
    }
}

function loadCustom()
{
    //Funciones para fecha en input
    $(function () {
        $(".date-picker").datepicker({
            dateFormat: 'dd/mm/yy'
        });

    });
    
}





