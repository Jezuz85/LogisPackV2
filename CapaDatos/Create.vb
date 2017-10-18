
Public Class Create




    ''' <summary>
    ''' Metodo que recibe un objeto Cliente y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Cliente(ByVal _nuevo As Cliente) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Cliente.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto Historico y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Historico(ByVal _nuevo As Historico) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Historico.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto Imagen y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Imagen(ByVal _nuevo As Imagen) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Imagen.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto Picking_Articulo y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Picking_Articulo(ByVal _nuevo As Picking_Articulo) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Picking_Articulo.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto Tipo Facturacion y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function TipoFacturacion(ByVal _nuevo As Tipo_Facturacion) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Tipo_Facturacion.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto Tipo Unidad y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function TipoUnidad(ByVal _nuevo As Tipo_Unidad) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            contexto.Tipo_Unidad.Add(_nuevo)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    ''' <summary>
    ''' Metodo que recibe un objeto Ubicacion y lo registra en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Ubicacion(ByVal _nuevo As Ubicacion) As Boolean

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
End Class
