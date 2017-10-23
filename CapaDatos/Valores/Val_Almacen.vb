

Public Class Val_Almacen

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
    Public Shared ReadOnly AddModal As Val_Almacen = New Val_Almacen("AddModal")
    Public Shared ReadOnly AddModalScript As Val_Almacen = New Val_Almacen("AddModalScript")
    Public Shared ReadOnly EditModal As Val_Almacen = New Val_Almacen("EditModal")
    Public Shared ReadOnly EditModalScript As Val_Almacen = New Val_Almacen("EditModallScript")
    Public Shared ReadOnly DeleteModal As Val_Almacen = New Val_Almacen("DeleteModal")
    Public Shared ReadOnly DeleteModalScript As Val_Almacen = New Val_Almacen("DeleteModalScript")
    Public Shared ReadOnly ViewModal As Val_Almacen = New Val_Almacen("ViewModal")
    Public Shared ReadOnly ViewModalScript As Val_Almacen = New Val_Almacen("ViewModalScript")

    '------------------------------------------------------------------
    '------------------------FILTROS DE LA LISTA DEL CAMPO BUSCAR------
    '------------------------------------------------------------------
    Public Shared ReadOnly Filtro_Codigo As Val_Almacen = New Val_Almacen("Codigo")
    Public Shared ReadOnly Filtro_Nombre As Val_Almacen = New Val_Almacen("Nombre")
    Public Shared ReadOnly Filtro_Cliente As Val_Almacen = New Val_Almacen("Cliente")
    Public Shared ReadOnly Filtro_Coeficiente As Val_Almacen = New Val_Almacen("Coeficiente")

    '------------------------------------------------------------------
    '------------------------VALORES PARA PASAR AL DROPDOWNLIST--------
    '------------------------------------------------------------------
    Public Shared ReadOnly Id_Alm As Val_Almacen = New Val_Almacen("id_almacen")
    Public Shared ReadOnly Nom_Alm As Val_Almacen = New Val_Almacen("nombre")

    '------------------------------------------------------------------
    '------------------------FORMATO DE DECIMALES----------------------
    '------------------------------------------------------------------
    Public Shared ReadOnly Formato_2_decimales As Val_Almacen = New Val_Almacen("#.00")
    Public Shared ReadOnly Formato_3_decimales As Val_Almacen = New Val_Almacen("#.000")
    Public Shared ReadOnly Formato_5_decimales As Val_Almacen = New Val_Almacen("#.00000")

End Class
