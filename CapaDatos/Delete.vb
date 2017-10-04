
Imports System.Data.Entity

Public Class Delete

    ''' <summary>
    ''' Metodo que recibe un id del Almacen y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Almacen(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Try
            Dim Eliminar As New Almacen With {
                .id_almacen = _id
            }
            contexto.Almacen.Attach(Eliminar)
            contexto.Almacen.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Articulo(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Try
            Dim Eliminar As New Articulo With {
                .id_articulo = _id
            }
            contexto.Articulo.Attach(Eliminar)
            contexto.Articulo.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Cliente y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Cliente(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Try
            Dim Eliminar As New Cliente With {
                .id_cliente = _id
            }
            contexto.Cliente.Attach(Eliminar)
            contexto.Cliente.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Tipo de Facturacion y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function TipoFacturacion(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Try
            Dim Eliminar As New Tipo_Facturacion With {
                .id_tipo_facturacion = _id
            }
            contexto.Tipo_Facturacion.Attach(Eliminar)
            contexto.Tipo_Facturacion.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Tipo de Unidad y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function TipoUnidad(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Try
            Dim Eliminar As New Tipo_Unidad With {
                .id_tipo_unidad = _id
            }
            contexto.Tipo_Unidad.Attach(Eliminar)
            contexto.Tipo_Unidad.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe un id de la Ubicacion y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Ubicacion(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Try
            Dim Eliminar As New Ubicacion With {
                .id_ubicacion = _id
            }
            contexto.Ubicacion.Attach(Eliminar)
            contexto.Ubicacion.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Picking_Articulo y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Picking_Articulo(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Try
            Dim Eliminar As New Picking_Articulo With {
                .id_picking_articulo = _id
            }
            contexto.Picking_Articulo.Attach(Eliminar)
            contexto.Picking_Articulo.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' Metodo que recibe un id de la Imagen y lo elimina en Base de datos, devuelve True si fue exitoso, de lo contrario False
    ''' </summary>
    Public Shared Function Imagen(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Try
            Dim Eliminar As New Imagen With {
                .id_imagen = _id
            }
            contexto.Imagen.Attach(Eliminar)
            contexto.Imagen.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

End Class
