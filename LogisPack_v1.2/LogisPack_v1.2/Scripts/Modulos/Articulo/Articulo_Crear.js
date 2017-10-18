function pageLoad(sender, args) {

    if (args.get_isPartialLoad()) {
        load_ArticuloCrear();
    }
    else {
        load_ArticuloCrear();
    }
}

function load_ArticuloCrear()
{

    //evento de observaciones de contador
    var txtObsGen = document.getElementById(txtObsGen),
        count1 = document.getElementById(txtcount1),
        aler1t = document.getElementById(txtalert1),
        maxLength = 100;

    var txtObsArt = document.getElementById(txtObsArt),
        count2 = document.getElementById(txtcount2),
        alert2 = document.getElementById(txtalert2),
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
    var Zonas = txtZonas+'0';
    var Estantes = txtEstantes + '0';
    var Filas = txtFilas + '0';
    var Columnas = txtColumnas + '0';
    var Paneles = txtPaneles + '0';

    for (var i = 1; i <= 50; i++) {
        Zonas.push($(txtZonas + i));
        Estantes.push($(txtEstantes + i));
        Filas.push($(txtFilas + i));
        Columnas.push($(txtColumnas + i));
        Paneles.push($(txtPaneles + i));
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