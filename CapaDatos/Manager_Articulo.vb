Imports System.Globalization
Imports System.Text
Imports System.Web.UI.WebControls

Public Class Manager_Articulo

    ''' <summary>
    ''' Metodo que se ejecuta cuando se oprime el boton de añadir articulo al artiulo picking
    ''' </summary>
    Public Shared Sub Añadir_ArticuloLista(txt1 As TextBox, ddl1 As DropDownList, txt2 As TextBox, txt3 As TextBox, btn1 As Button)

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim unidadesSolicitadas As Double = Double.Parse(txt1.Text, CultureInfo.InvariantCulture)
        Dim _IdArticulo As Integer = Convert.ToInt32(ddl1.SelectedValue)
        Dim Listarticulo = contexto.Articulo.Where(Function(model) model.id_articulo = _IdArticulo).SingleOrDefault()

        Dim textoArt1 = txt2.Text
        Dim textoArt2 = txt3.Text

        Dim textArea1 As New StringBuilder
        textArea1.AppendLine("Articulo: " & ddl1.SelectedItem.Text + " Unidades=" + txt1.Text)
        txt2.Text = textoArt1 & textArea1.ToString()


        Dim textArea2 As New StringBuilder
        textArea2.AppendLine(ddl1.SelectedValue + "-" + txt1.Text)
        txt3.Text = textoArt2 & textArea2.ToString()


        ddl1.Items.Remove(ddl1.Items.FindByValue(ddl1.SelectedValue))

        If ddl1.Items.Count = 0 Then
            btn1.Visible = False
        End If

    End Sub

    ''' <summary>
    ''' Metodo que consulta el Coeficiente Volumetrico del almacen y lo asigna al articulo a crear al 
    ''' cargar la pagina
    ''' </summary>
    Public Shared Sub CargarCoefVol(idAlmacen As Integer, ByRef txt1 As TextBox)
        Dim _Almacen = Getter.Almacen(idAlmacen)
        txt1.Text = _Almacen.coeficiente_volumetrico.ToString().Replace(",", ".")
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un cliente de la lista
    ''' </summary>
    Public Shared Sub CambiarCliente(ddl1 As DropDownList, txt1 As TextBox, ddl2 As DropDownList)
        If ddl1.SelectedValue = "" Then
            txt1.Text = String.Empty
            ddl2.Items.Clear()
        Else
            Listas.Almacen(ddl2, Convert.ToInt32(ddl1.SelectedValue))
        End If
    End Sub

    ''' <summary>
    ''' Metodo que crea la tabla ubicacion, para añadir o eliminar filas, para agregar ubicaciones al articulo
    ''' </summary>
    Public Shared Function crearCamposListaUbicacion(valor As Integer, pTabla As Panel) As Integer
        Dim ContFilas As Integer = 0

        If valor < 0 Then
            ContFilas = 0
        Else
            ContFilas = valor
        End If

        For i As Integer = 1 To ContFilas

            ControlesDinamicos.CrearLiteral("<tr><td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtZona" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtEstante" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtFila" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtColumna" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtPanel" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtRefUbi" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td></tr>", pTabla)


        Next

        Return Convert.ToString(ContFilas)
    End Function

    ''' <summary>
    ''' Metodo que se ejecuta cuando se oprime el boton de Resetear, elimina los aritculos y reestablece la 
    ''' lista de Articulo
    ''' </summary>
    Public Shared Sub Reset_ArticuloLista(btn1 As Button, ddl1 As DropDownList, ddl2 As DropDownList,
        txt1 As TextBox, txt2 As TextBox)

        btn1.Visible = True
        Listas.Articulo(ddl1, Convert.ToInt32(ddl2.SelectedValue))
        txt1.Text = String.Empty
        txt2.Text = String.Empty
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un almacen, y se fija el valor del coeficiente volumetrico
    ''' al articulo dependiendo del valor que tenga el coeficiente del almacen
    ''' </summary>
    Public Shared Sub SetCoefVolumétrico(ByRef ddl1 As DropDownList, ByRef txt1 As TextBox, ByRef ph1 As PlaceHolder,
        ByRef ddl2 As DropDownList)

        If ddl1.SelectedValue = "" Then
            txt1.Text = String.Empty
            ph1.Visible = False
        Else

            If ddl2.SelectedValue = "Picking" Then
                ph1.Visible = True
            Else
                ph1.Visible = False
            End If

            CargarCoefVol(Convert.ToInt32(ddl1.SelectedValue), txt1)
        End If

    End Sub

    Public Shared Function LlenarCeros(valor As String) As String
        Return valor.PadLeft(4, "0"c)
    End Function


    '------------------------CALCULOS---------------------------------
    ''' <summary>
    ''' Metodo que calcula Valoracion Stock 
    ''' </summary>
    Public Shared Function Calcular_ValoracionStock(_StockFisico As Double, _ValArticulo As Double) As Double

        Return (_ValArticulo * _StockFisico).ToString("#.00000")

    End Function

    ''' <summary>
    ''' Metodo que calcula Valoracion Seguro
    ''' </summary>
    Public Shared Function Calcular_ValoracionSeguro(_ValAsegurado As Double, _StockFisico As Double) As Double

        Return (_ValAsegurado * _StockFisico).ToString("#.000")

    End Function

    ''' <summary>
    ''' Metodo que calcula Peso Volumetrico
    ''' </summary>
    Public Shared Function Calcular_PesoVolumetrico(_Alto As Double, _Ancho As Double, _Largo As Double, _CoefVol As Double) As Double

        Return ((_Alto * _Ancho * _Largo * _CoefVol) / 1000000).ToString("#.00000")

    End Function

    ''' <summary>
    ''' Metodo que calcula M3
    ''' </summary>
    Public Shared Function CalcularM3(_Alto As Double, _Ancho As Double, _Largo As Double) As Double

        Return ((_Alto * _Ancho * _Largo) / 1000000).ToString("#.00000")

    End Function



End Class
