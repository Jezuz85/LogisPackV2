Public Class Mensajes

    Private Key As String

    Private Sub New(key As String)
        Me.Key = key
    End Sub
    Public Overrides Function ToString() As String
        Return Key
    End Function

    '---------------Comandos gridview
    Public Shared ReadOnly Registrar As Mensajes = New Mensajes("Registrar")
    Public Shared ReadOnly Editar As Mensajes = New Mensajes("Editar")
    Public Shared ReadOnly Eliminar As Mensajes = New Mensajes("Eliminar")
    Public Shared ReadOnly Detalles As Mensajes = New Mensajes("Detalles")
    Public Shared ReadOnly EliminarFila As Mensajes = New Mensajes("DelRow")

    '---------------Mensajes de alert para CRUD
    Public Shared ReadOnly AddExito As Mensajes = New Mensajes("EXITO!!! Se Agregó el registro exitosamente")
    Public Shared ReadOnly AddFalla As Mensajes = New Mensajes("ERROR!!! No se pudo agregar el registro ")
    Public Shared ReadOnly EditExito As Mensajes = New Mensajes("EXITO!!! Se Actualizó el registro exitosamente")
    Public Shared ReadOnly EditFalla As Mensajes = New Mensajes("ERROR!!! No se pudo actualizar el registro ")
    Public Shared ReadOnly DeleteExito As Mensajes = New Mensajes("EXITO!!! Se Eliminó el registro exitosamente")
    Public Shared ReadOnly DeleteFalla As Mensajes = New Mensajes("ERROR!!! No se pudo eliminar el registro ")

    '---------------Mensajes valdiacion de modulo Operacion
    Public Shared ReadOnly Unidades_Stock As Mensajes = New Mensajes("Las unidades del Articulo no Deben superar al stock actual y deben ser mayor a cero")

    '---------------Mensajes valdiacion de modulo Carga Masiva
    Public Shared ReadOnly CargaExito As Mensajes = New Mensajes("Se cargo el archivo excel satisfactoriamente")
    Public Shared ReadOnly CargaFalla As Mensajes = New Mensajes("No se cargo el archivo excel: ")
    Public Shared ReadOnly NoExiste_TipoFacturacion As Mensajes = New Mensajes("Error! No existe el <strong>Tipo de Facturacion</strong> en la fila: ")
    Public Shared ReadOnly NoExiste_TipoUnidad As Mensajes = New Mensajes("Error! No existe el  <strong>Tipo de Unidad</strong> en la fila: ")
    Public Shared ReadOnly NoExiste_Identificacion As Mensajes = New Mensajes("Error! El campo <strong>Identificación</strong> solo permite Valores (CB o RF) en la fila: ")
    Public Shared ReadOnly Longitud As Mensajes = New Mensajes("Error! Se superó el limite de caracteteres para el campo ")
    Public Shared ReadOnly SoloNumero As Mensajes = New Mensajes("Error! Solo es permitidos valores numericos para el campo ")

End Class
