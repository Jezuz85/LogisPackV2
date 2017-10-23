Public Class Val_General

    Private Key As String

    Private Sub New(key As String)
        Me.Key = key
    End Sub
    Public Overrides Function ToString() As String
        Return Key
    End Function

    '------------------------------------------------------------------
    '------------------------COMANDOS PARA UN GRIDVIEW-----------------
    '------------------------------------------------------------------
    Public Shared ReadOnly Registrar As Val_General = New Val_General("Registrar")
    Public Shared ReadOnly Editar As Val_General = New Val_General("Editar")
    Public Shared ReadOnly Eliminar As Val_General = New Val_General("Eliminar")
    Public Shared ReadOnly Detalles As Val_General = New Val_General("Detalles")
    Public Shared ReadOnly EliminarFila As Val_General = New Val_General("DelRow")

    '--------------------------------------------------------------------------------------
    '------------------------MENSAJES DE ALERT PARA LA GESTION DE TABLAS-------------------
    '--------------------------------------------------------------------------------------
    Public Shared ReadOnly AddExito As Val_General = New Val_General("EXITO!!! Se Agregó el registro exitosamente")
    Public Shared ReadOnly AddFalla As Val_General = New Val_General("ERROR!!! No se pudo agregar el registro ")
    Public Shared ReadOnly EditExito As Val_General = New Val_General("EXITO!!! Se Actualizó el registro exitosamente")
    Public Shared ReadOnly EditFalla As Val_General = New Val_General("ERROR!!! No se pudo actualizar el registro ")
    Public Shared ReadOnly DeleteExito As Val_General = New Val_General("EXITO!!! Se Eliminó el registro exitosamente")
    Public Shared ReadOnly DeleteFalla As Val_General = New Val_General("ERROR!!! No se pudo eliminar el registro ")

    '--------------------------------------------------------------------------------------
    '------------------------MENSAJES DE VALDIACIÓN DEL MODULO OPERACIÓN-------------------
    '--------------------------------------------------------------------------------------
    Public Shared ReadOnly Unidades_Stock As Val_General = New Val_General("Las unidades del Articulo no Deben superar al stock actual y deben ser mayor a cero")

    '--------------------------------------------------------------------------------------
    '------------------------MENSAJES DE VALDIACIÓN DEL MODULO CARGA MASIVA----------------
    '--------------------------------------------------------------------------------------
    Public Shared ReadOnly CargaExito As Val_General = New Val_General("Se cargo el archivo excel satisfactoriamente")
    Public Shared ReadOnly CargaFalla As Val_General = New Val_General("No se cargo el archivo excel: ")
    Public Shared ReadOnly NoExiste_TipoFacturacion As Val_General = New Val_General("Error! No existe el <strong>Tipo de Facturacion</strong> en la fila: ")
    Public Shared ReadOnly NoExiste_TipoUnidad As Val_General = New Val_General("Error! No existe el  <strong>Tipo de Unidad</strong> en la fila: ")
    Public Shared ReadOnly NoExiste_Identificacion As Val_General = New Val_General("Error! El campo <strong>Identificación</strong> solo permite Valores (CB o RF) en la fila: ")
    Public Shared ReadOnly Longitud As Val_General = New Val_General("Error! Se superó el limite de caracteteres para el campo ")
    Public Shared ReadOnly SoloNumero As Val_General = New Val_General("Error! Solo es permitidos valores numericos para el campo ")

    '--------------------------------------------------------------------------------------
    '------------------------VALORES GENERALES PARA TODA LA APLICAICION--------------------
    '--------------------------------------------------------------------------------------
    Public Shared ReadOnly filtroBusqueda As Val_General = New Val_General("filtroBusqueda")
    Public Shared ReadOnly textoBusqueda As Val_General = New Val_General("textoBusqueda")
    Public Shared ReadOnly SortExpression As Val_General = New Val_General("SortExpression")
    Public Shared ReadOnly GridViewSortDirection As Val_General = New Val_General("GridViewSortDirection")
    Public Shared ReadOnly Lista_Seleccione As Val_General = New Val_General("Seleccione...")

End Class
