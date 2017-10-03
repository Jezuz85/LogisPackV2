
function load() {

    var URLActual = "" + window.location;

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

    function MostrarMsjModal(message, title, ccsclas) {
        var vIcoModal = document.getElementById("icoModal");
        vIcoModal.className = ccsclas;
        $('#lblMsjTitle').html(title);
        $('#lblMsjModal').html(message);
        $('#Msjmodal').modal('show');
    }

    if (URLActual.includes("Portal/Almacen/index")) {
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

}

