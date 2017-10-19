
Imports System.Web.UI.WebControls

Public Class Mgr_Ubicacion

    Structure struct_Ubicacion
        Public nombre As String
        Public zona As String
        Public estante As String
        Public fila As String
        Public columna As String
        Public panel As String
        Public id_articulo As String
        Public referencia_ubicacion As String
    End Structure

    '------------------------Funciones de la clase Ubicacion
    ''' <summary>
    ''' Metodo que recibe un objeto Ubicacion y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Guardar(ByVal _nuevo As Ubicacion) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Ubicacion.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe un id de la Ubicacion y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Eliminar(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Try
            Dim _Eliminar As New Ubicacion With {
                .id_ubicacion = _id
            }
            contexto.Ubicacion.Attach(_Eliminar)
            contexto.Ubicacion.Remove(_Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe el objeto Tipo de Ubicacion a Actualizar y el contexto en que fue creado, devuelve true si fue
    ''' exitosa la actualización, en caso contrario devuelve false
    ''' </summary>
    Public Shared Function Editar(_Edit As Ubicacion, ByRef contexto As LogisPackEntities) As Boolean

        Try
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que devuelve una variable de tipo estructura con el cuerpo de la clase imagen
    ''' </summary>
    Public Shared Function Get_Struct() As struct_Ubicacion

        Dim _mistruct As struct_Ubicacion = Nothing
        Return _mistruct

    End Function

    ''' <summary>
    ''' Metodo que recibe un array de string y retorna un objeto imagen
    ''' </summary>
    Public Shared Function Crear_Objeto(_imagen As struct_Ubicacion) As Ubicacion

        Dim _Nuevo = New Ubicacion With
            {
            .zona = _imagen.zona,
            .estante = _imagen.estante,
            .fila = _imagen.fila,
            .columna = _imagen.columna,
            .panel = _imagen.panel,
            .referencia_ubicacion = _imagen.referencia_ubicacion,
            .id_articulo = _imagen.id_articulo
        }

        Return _Nuevo

    End Function

    Public Shared Function Get_Struct_Fila_Ubicacion(contadorControl As Integer, ByRef pTabla As Panel, id_articulo As String) As struct_Ubicacion

        Dim miTextbox As TextBox
        Dim zona As String = Nothing
        Dim estante As String = Nothing
        Dim fila As String = Nothing
        Dim columna As String = Nothing
        Dim panel As String = Nothing
        Dim referencia_ubicacion As String = Nothing

        miTextbox = CType(pTabla.FindControl(Val_Articulo.txtZona.ToString & contadorControl), TextBox)
        If miTextbox IsNot Nothing Then
            zona = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
        End If

        miTextbox = CType(pTabla.FindControl(Val_Articulo.txtEstante.ToString & contadorControl), TextBox)
        If miTextbox IsNot Nothing Then
            estante = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
        End If

        miTextbox = CType(pTabla.FindControl(Val_Articulo.txtFila.ToString & contadorControl), TextBox)
        If miTextbox IsNot Nothing Then
            fila = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
        End If

        miTextbox = CType(pTabla.FindControl(Val_Articulo.txtColumna.ToString & contadorControl), TextBox)
        If miTextbox IsNot Nothing Then
            Dim valor As String = miTextbox.Text.PadLeft(4, "0")
            columna = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text.PadLeft(4, "0"))
        End If

        miTextbox = CType(pTabla.FindControl(Val_Articulo.txtPanel.ToString & contadorControl), TextBox)
        If miTextbox IsNot Nothing Then
            panel = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
        End If

        miTextbox = CType(pTabla.FindControl(Val_Articulo.txtRefUbi.ToString & contadorControl), TextBox)
        If miTextbox IsNot Nothing Then
            referencia_ubicacion = If(miTextbox.Text = String.Empty, String.Empty, miTextbox.Text)
        End If

        If referencia_ubicacion IsNot Nothing Then

            If (zona <> String.Empty) Or
                (estante <> String.Empty) Or
                (columna <> String.Empty) Or
                (panel <> String.Empty) Or
                (referencia_ubicacion <> String.Empty) Then

#Region "creo la estructura ubicacion"
                Dim _miUbicacion = Get_Struct()
                _miUbicacion.zona = zona
                _miUbicacion.estante = estante
                _miUbicacion.fila = fila
                _miUbicacion.columna = columna
                _miUbicacion.panel = panel
                _miUbicacion.id_articulo = id_articulo
                _miUbicacion.referencia_ubicacion = referencia_ubicacion
#End Region

                Return _miUbicacion
            End If
        End If



    End Function

    '------------------------Funciones Getter
    ''' <summary>
    ''' Metodo que recibe un id del Artiuclo, y devuelve una lista de las ubicaciones asociadas al articulo
    ''' </summary>
    Public Shared Function Get_Ubicacion_list(id As Integer) As List(Of Ubicacion)
        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Ubicacion.Where(Function(model) model.id_articulo = id).ToList()
    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Artiuclo, y devuelve una la ubicaciones asociadas al articulo
    ''' </summary>
    Public Shared Function Get_Ubicacion(id As Integer) As Ubicacion
        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Ubicacion.Where(Function(model) model.id_ubicacion = id).SingleOrDefault()
    End Function

    ''' <summary>
    ''' Metodo que recibe un id de la ubicacion y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver la ubicacion a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo ubicacion si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Get_Ubicacion(id As Integer, ByRef contexto As LogisPackEntities) As Ubicacion

        Return contexto.Ubicacion.Where(Function(model) model.id_ubicacion = id).SingleOrDefault()

    End Function


End Class
