Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class Util_UpdatePanel

    ''' <summary>
    ''' Metodo para limpiar todos los controles existentes en un UpdatePanel
    ''' </summary>
    Public Shared Sub LimpiarControles(_UpdatePanel As UpdatePanel)

        For Each _control As Control In _UpdatePanel.ContentTemplateContainer.Controls

            If _control IsNot Nothing Then
                If _control.GetType() Is GetType(TextBox) Then
                    CType(_control, TextBox).Text = Nothing
                ElseIf _control.GetType() Is GetType(CheckBox) Then
                    CType(_control, CheckBox).Checked = False
                ElseIf _control.GetType() Is GetType(ListBox) Then
                    CType(_control, ListBox).Items.Clear()
                ElseIf _control.GetType() Is GetType(RadioButton) Then
                    CType(_control, RadioButton).Checked = False
                End If
            End If

        Next

    End Sub

    ''' <summary>
    ''' Metodo que obtiene el control que realizo el postback
    ''' </summary>
    Public Shared Function ObtenerControl_PostBack(page As Page) As Control

        Dim ctrl As Control = Nothing
        Dim ctrlName As String = page.Request.Params.Get("__EVENTTARGET")
        If Not String.IsNullOrEmpty(ctrlName) Then
            ctrl = page.FindControl(ctrlName)
        End If
        Return ctrl
    End Function

    ''' <summary>
    ''' Metodo que se ejecuta al realizar una operacion, se vacia los controles y se muestra el alerta
    ''' </summary>
    Public Shared Sub CerrarOperacion(_modal As String, bError As Boolean, _page As Page,
                _updatePpal As UpdatePanel, Optional ByRef _update As UpdatePanel = Nothing)

        If _update IsNot Nothing Then
            LimpiarControles(_update)
        End If

        Util_Modal.CerrarModal(_modal & "Modal", _modal & "Script", _page)
        Util_Modal.MostrarAlerta(_updatePpal, bError, _modal)
    End Sub
End Class
