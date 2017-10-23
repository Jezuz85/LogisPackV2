Public Class Val_TipoUnidad

    Private Key As String

    Private Sub New(key As String)
        Me.Key = key
    End Sub
    Public Overrides Function ToString() As String
        Return Key
    End Function

    '------------------------------------------------------------------
    '------------------------NOMBRES DE LOS MODALES--------------------
    '------------------------------------------------------------------
    Public Shared ReadOnly AddModal As Val_TipoUnidad = New Val_TipoUnidad("AddModal")
    Public Shared ReadOnly EditModal As Val_TipoUnidad = New Val_TipoUnidad("EditModal")
    Public Shared ReadOnly DeleteModal As Val_TipoUnidad = New Val_TipoUnidad("DeleteModal")
    Public Shared ReadOnly AddModalScript As Val_TipoUnidad = New Val_TipoUnidad("AddModalScript")
    Public Shared ReadOnly EditModalScript As Val_TipoUnidad = New Val_TipoUnidad("EditModallScript")
    Public Shared ReadOnly DeleteModalScript As Val_TipoUnidad = New Val_TipoUnidad("DeleteModalScript")

End Class
