Public Class Val_TipoFacturacion

    Private Key As String

    Private Sub New(key As String)
        Me.Key = key
    End Sub
    Public Overrides Function ToString() As String
        Return Key
    End Function

    Public Shared ReadOnly AddModal As Val_TipoFacturacion = New Val_TipoFacturacion("AddModal")
    Public Shared ReadOnly EditModal As Val_TipoFacturacion = New Val_TipoFacturacion("EditModal")
    Public Shared ReadOnly DeleteModal As Val_TipoFacturacion = New Val_TipoFacturacion("DeleteModal")
    Public Shared ReadOnly AddModalScript As Val_TipoFacturacion = New Val_TipoFacturacion("AddModalScript")
    Public Shared ReadOnly EditModalScript As Val_TipoFacturacion = New Val_TipoFacturacion("EditModallScript")
    Public Shared ReadOnly DeleteModalScript As Val_TipoFacturacion = New Val_TipoFacturacion("DeleteModalScript")

End Class
