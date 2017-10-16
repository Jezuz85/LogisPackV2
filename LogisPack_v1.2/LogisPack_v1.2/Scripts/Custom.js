var URLActual = "" + window.location;

//Al cargarse la pagina se llaman estas funciones
window.onload = function () {
    load();
    SetstateAcordeon();
    if (URLActual.includes("Portal/Almacen/index")) { SetstateAcordeonArbol(); }
};

//Al realizarse un postback se llama a esta otra
var prm = Sys.WebForms.PageRequestManager.getInstance();
if (prm != null) {
    prm.add_endRequest(function (sender, e) {
        if (sender._postBackSettings.panelsToUpdate != null) {
            $(document).ready(function () {
                SetstateAcordeonPostback();
                load();
            });

        }
    });
};

function load() {

    //Funciones para Modulo Crear y Editar Articulo
    if (URLActual.includes("Portal/Articulo/Crear") || URLActual.includes("Portal/Articulo/Editar")) {

        //evento de observaciones de contador
        var txtObsGen = document.getElementById('MainContent_txtObsGen'),
            count1 = document.getElementById('count1'),
            aler1t = document.getElementById('alert1'),
            maxLength = 100;

        var txtObsArt = document.getElementById('MainContent_txtObsArt'),
            count2 = document.getElementById('count2'),
            alert2 = document.getElementById('alert2'),
            maxLength = 300;


        txtObsGen.addEventListener('input', function (e) {
            var value = e.target.value.replace(/\r?\n/g, '\r\n'),
                length = value.length;


            if (length >= maxLength) {
                if (length > maxLength) {
                    length = maxLength - 1;
                    e.target.value = value.slice(0, length);
                } else {
                    alert1.classList.remove('hidden');
                }
            } else {
                alert1.classList.add('hidden');
            }

            count1.textContent = length;

        }, false);
        txtObsArt.addEventListener('input', function (e) {
            var value = e.target.value.replace(/\r?\n/g, '\r\n'),
                length = value.length;


            if (length >= maxLength) {
                if (length > maxLength) {
                    length = maxLength - 1;
                    e.target.value = value.slice(0, length);
                } else {
                    alert2.classList.remove('hidden');
                }
            } else {
                alert2.classList.add('hidden');
            }

            count2.textContent = length;
        }, false);

        //Asignar evento de ceros a columna en la tabla Ubicacion
        var Zonas = [$('#MainContent_txtZona0')];
        var Estantes = [$('#MainContent_txtEstante0')];
        var Filas = [$('#MainContent_txtFila0')];
        var Columnas = [$('#MainContent_txtColumna0')];
        var Paneles = [$('#MainContent_txtPanel0')];

        for (var i = 1; i <= 50; i++) {
            Zonas.push($('#MainContent_txtZona' + i));
            Estantes.push($('#MainContent_txtEstante' + i));
            Filas.push($('#MainContent_txtFila' + i));
            Columnas.push($('#MainContent_txtColumna' + i));
            Paneles.push($('#MainContent_txtPanel' + i));
        }

        $.each(Zonas, function () {
            $(this).focusout(function () {
                var _valor = $(this).val();
                if (_valor.length > 0) {
                    $(this).val(_valor.padStart(4, "0"));
                }

            });
        });
        $.each(Estantes, function () {
            $(this).focusout(function () {
                var _valor = $(this).val();
                if (_valor.length > 0) {
                    $(this).val(_valor.padStart(4, "0"));
                }

            });
        });
        $.each(Filas, function () {
            $(this).focusout(function () {
                var _valor = $(this).val();
                if (_valor.length > 0) {
                    $(this).val(_valor.padStart(4, "0"));
                }

            });
        });
        $.each(Columnas, function () {
            $(this).focusout(function () {
                var _valor = $(this).val();
                if (_valor.length > 0) {
                    $(this).val(_valor.padStart(4, "0"));
                }

            });
        });
        $.each(Paneles, function () {
            $(this).focusout(function () {
                var _valor = $(this).val();
                if (_valor.length > 0) {
                    $(this).val(_valor.padStart(4, "0"));
                }

            });
        });

    }

    //Funciones para Modulo Editar Articulo
    if (URLActual.includes("Portal/Articulo/Editar")) {

        var Columnas = [$('#RemoveIma1')];


        for (var i = 1; i <= 50; i++) {
            Columnas.push($('#RemoveIma' + i));
        }
        $.each(Columnas, function () {
            $(this).click(function (event) {
                var res = this.id.replace("RemoveIma", "");

                if (confirm("Seguro desea Eliminar esta imagen, esta opcion no se puede deshacer!") == true) {
                    $("#Ima" + res).remove();
                    this.remove();
                }

            });
        });
    }

    //Funciones para Modulo index almacen
    if (URLActual.includes("Portal/Almacen/index"))
    {

        $("#sectionHeaderButtons1").click(function () {

            if ($('#CabeceraTree').css('display') == "none") {
                $("#sectionHeaderButton1").attr("src", "../../Content/images/minimize_16x16.png");
            }
            else {
                $("#sectionHeaderButton1").attr("src", "../../Content/images/maximize_16x16.png");
            }

        });

        $("#sectionHeaderButtons2").click(function () {

            if ($('#sectionContentFiltrosCabecera').css('display') == "none") {
                $("#sectionHeaderButton2").attr("src", "../../Content/images/minimize_16x16.png");
            }
            else {
                $("#sectionHeaderButton2").attr("src", "../../Content/images/maximize_16x16.png");
            }

        });

        //actualizo el estado del acordeon tree
        $("#sectionHeaderArbol").click(function (event) {
            SetstateAcordeonArbol();
        });

    }
    else {
        $(".sectionHeaderButtons").click(function () {

            if ($('#sectionContentFiltrosCabecera').css('display') == "none") {
                $("#sectionHeaderFiltros img").attr("src", "../../Content/images/minimize_16x16.png");
            }
            else {
                $("#sectionHeaderFiltros img").attr("src", "../../Content/images/maximize_16x16.png");
            }

        });


    }

    //Funciones para fecha en input
    $(function () {
        $(".date-picker").datepicker({
            dateFormat: 'dd/mm/yy'
        });

    });
    $('#btn').click(function () {
        $("#MainContent_txtFechaOperacion").focus();
    });

    //actualizo el estado del acordeon
    $("#sectionHeaderFiltros").click(function (event) {
        SetstateAcordeon();
    });

}

function SetstateAcordeon() {
    var stateActual = $('#MainContent_hfaccordion').val();

    if (stateActual == 'off') {
        stateActual = 'in';
        $('#MainContent_hfaccordion').val(stateActual);
    }
    else if (stateActual == 'in') {
        stateActual = 'off';
        $('#MainContent_hfaccordion').val(stateActual);
    }
    else {
        stateActual = 'off';
        $('#MainContent_hfaccordion').val(stateActual);
    }
}

function SetstateAcordeonArbol() {

    console.log("entro in");
    var stateActual2 = $('#MainContent_hfaccordion2').val();

    if (stateActual2 == 'off') {
        stateActual2 = 'in';
        $('#MainContent_hfaccordion2').val(stateActual2);
    }
    else if (stateActual2 == 'in') {
        stateActual2 = 'off';
        $('#MainContent_hfaccordion2').val(stateActual2);
    }
    else {
        stateActual2 = 'off';
        $('#MainContent_hfaccordion2').val(stateActual2);
    }
}

function SetstateAcordeonPostback() {
    var stateActual = $('#MainContent_hfaccordion').val();

    if (stateActual == 'off') {
        $('#sectionContentFiltrosCabecera').removeClass('in');
    }
    else if (stateActual == 'in') {
        $('#sectionContentFiltrosCabecera').addClass('in');
    }

    //acordeon del arbol
    if (URLActual.includes("Portal/Almacen/index"))
    {
        var stateActual2 = $('#MainContent_hfaccordion2').val();

        if (stateActual2 == 'off')
        {
            $('#CabeceraTree').removeClass('in');
        }
        else if (stateActual2 == 'in')
        {
            $('#CabeceraTree').addClass('in');
        }
    }
}
