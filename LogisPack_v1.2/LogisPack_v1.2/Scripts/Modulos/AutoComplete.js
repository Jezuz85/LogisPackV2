
function Autocomplete()
{
    $(txtSearch).autocomplete(
        {
            source: function (request, response) {
                $.ajax({
                    url: URL_WS_Autocomplete,
                    data: "{ 'prefixText': '" + request.term +
                    "','Filtro': '" + $(hdfFiltro).val() +
                    "','Cliente': '" + $(hdfCliente).val() + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.split('-')[0],
                                val: item.split('-')[1]
                            }
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (event, ui) {
                $(txtSearch).blur();
            },
            minLength: 1
        });
}