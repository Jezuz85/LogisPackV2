
Public Class Val_Cliente

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
    Public Shared ReadOnly AddModal As Val_Cliente = New Val_Cliente("AddModal")
    Public Shared ReadOnly EditModal As Val_Cliente = New Val_Cliente("EditModal")
    Public Shared ReadOnly DeleteModal As Val_Cliente = New Val_Cliente("DeleteModal")
    Public Shared ReadOnly AddModalScript As Val_Cliente = New Val_Cliente("AddModalScript")
    Public Shared ReadOnly EditModalScript As Val_Cliente = New Val_Cliente("EditModallScript")
    Public Shared ReadOnly DeleteModalScript As Val_Cliente = New Val_Cliente("DeleteModalScript")

    '------------------------------------------------------------------
    '------------------------FILTROS DE LA LISTA DEL CAMPO BUSCAR------
    '------------------------------------------------------------------
    Public Shared ReadOnly Filtro_Codigo As Val_Cliente = New Val_Cliente("Código")
    Public Shared ReadOnly Filtro_Nombre As Val_Cliente = New Val_Cliente("Nombre")

End Class
