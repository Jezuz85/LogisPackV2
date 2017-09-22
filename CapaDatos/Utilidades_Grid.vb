﻿
Imports System.Web.UI
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

    Public Shared Sub SetArrowsGrid(ByRef GridView1 As GridView, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.Header Then
            For Each tc As TableCell In e.Row.Cells
                If tc.HasControls() Then

                    Dim lnk As LinkButton = Nothing

                    If TypeOf tc.Controls(0) Is LinkButton Then
                        lnk = CType(tc.Controls(0), LinkButton)
                    End If

                    If lnk IsNot Nothing AndAlso GridView1.Attributes("CurrentSortField") = lnk.CommandArgument Then
                        Dim image As New Image()

                        If GridView1.Attributes("CurrentSortDirection") = "ASC" Then
                            image.ImageUrl = "~/Content/images/arrow-orderasc.png"
                        Else
                            image.ImageUrl = "~/Content/images/arrow-orderdesc.png"
                        End If

                        tc.Controls.Add(New LiteralControl("&nbsp;"))
                        tc.Controls.Add(image)

                    End If



                End If

            Next

        End If
    End Sub

    Public Shared Sub sortGridView(ByRef GridView1 As GridView, ByVal e As GridViewSortEventArgs, ByRef _SortExpression As String,
                                   ByRef _SortDirection As String)

        Dim sortField = e.SortExpression
        Dim SortDirection = e.SortDirection

        If GridView1.Attributes("CurrentSortField") IsNot Nothing AndAlso
            GridView1.Attributes("CurrentSortDirection") IsNot Nothing Then

            If sortField = GridView1.Attributes("CurrentSortField") Then
                If GridView1.Attributes("CurrentSortDirection") = "ASC" Then
                    SortDirection = SortDirection.Descending
                Else
                    SortDirection = SortDirection.Ascending
                End If
            End If

            GridView1.Attributes("CurrentSortField") = sortField
            _SortExpression = sortField

            If SortDirection = SortDirection.Ascending Then
                GridView1.Attributes("CurrentSortDirection") = "ASC"
                _SortDirection = SortDirection.Ascending
            Else
                GridView1.Attributes("CurrentSortDirection") = "DESC"
                _SortDirection = SortDirection.Descending
            End If


        End If

    End Sub

End Class
