
Imports System.Web.UI.WebControls

Public Class Utilidades_Grid

    ''' <summary>
    ''' Metodo para obtener el id de la fila de un Gridview
    ''' </summary>
    Public Shared Function Get_IdRow(ByRef GridView1 As GridView, e As GridViewCommandEventArgs, Optional ByVal control As String = "id") As String

        Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
        Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
        Return TryCast(gvrow.FindControl(control), Label).Text

    End Function

    Public Shared Function Get_IdRow_Editing(ByRef GridView1 As GridView, e As GridViewEditEventArgs, Optional ByVal control As String = "id") As String

        Dim RowIndex As Integer = Convert.ToInt32((e.NewEditIndex))
        Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
        Return TryCast(gvrow.FindControl(control), Label).Text

    End Function

    Public Shared Function Get_IdRow_Deleting(ByRef GridView1 As GridView, e As GridViewDeleteEventArgs, Optional ByVal control As String = "id") As String

        Dim RowIndex As Integer = Convert.ToInt32((e.RowIndex))
        Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
        Return TryCast(gvrow.FindControl(control), Label).Text

    End Function

End Class
