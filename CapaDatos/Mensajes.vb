Public Class Mensajes

    Private Key As String

    Private Sub New(key As String)
        Me.Key = key
    End Sub
    Public Overrides Function ToString() As String
        Return Key
    End Function

    Public Shared ReadOnly Registrar As Mensajes = New Mensajes("Registrar")
    Public Shared ReadOnly Editar As Mensajes = New Mensajes("Editar")
    Public Shared ReadOnly Eliminar As Mensajes = New Mensajes("Eliminar")
    Public Shared ReadOnly Detalles As Mensajes = New Mensajes("Detalles")
    Public Shared ReadOnly EliminarFila As Mensajes = New Mensajes("DelRow")

    Public Shared ReadOnly AddExito As Mensajes = New Mensajes("EXITO!!! Se Agregó el registro exitosamente")
    Public Shared ReadOnly AddFalla As Mensajes = New Mensajes("ERROR!!! No se pudo agregar el registro ")
    Public Shared ReadOnly EditExito As Mensajes = New Mensajes("EXITO!!! Se Actualizó el registro exitosamente")
    Public Shared ReadOnly EditFalla As Mensajes = New Mensajes("ERROR!!! No se pudo actualizar el registro ")
    Public Shared ReadOnly DeleteExito As Mensajes = New Mensajes("EXITO!!! Se Eliminó el registro exitosamente")
    Public Shared ReadOnly DeleteFalla As Mensajes = New Mensajes("ERROR!!! No se pudo eliminar el registro ")

    Public Shared ReadOnly Unidades_Stock As Mensajes = New Mensajes("Las unidades del Articulo no Deben superar al stock actual y deben ser mayor a cero")

End Class
