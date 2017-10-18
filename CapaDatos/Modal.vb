Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class Modal

    ''' <summary>
    ''' Metodo que recibe el nombre del modal a abrir, el nombre del script a registrar, y abre el modal
    ''' </summary>
    Public Shared Sub AbrirModal(nombreModal As String, nombreScript As String, _page As Page)
        ScriptManager.RegisterStartupScript(_page, GetType(Page), nombreScript, "$('#" & nombreModal & "').modal('show');", True)
    End Sub

    ''' <summary>
    ''' Metodo que recibe el nombre del modal a cerrar, el nombre del script a registrar, y cierra el modal
    ''' </summary>
    Public Shared Sub CerrarModal(nombreModal As String, nombreScript As String, _page As Page)
        ScriptManager.RegisterStartupScript(_page, GetType(Page), nombreScript, "$('#" & nombreModal & "').modal('hide');", True)
    End Sub

    ''' <summary>
    ''' Metodo que recibe el updatepanel donde esta el Alert, el valor booleano de la operacion, y el tipo de 
    ''' operacion para mostrar el alerta
    ''' </summary>
    Public Shared Sub MostrarAlerta(_Master As UpdatePanel, bError As Boolean, tipoOperacion As String)

        Dim mensaje As String = String.Empty

        Dim _UserControl As UserControl = CType(_Master.FindControl("ucAlerta"), UserControl)
        If _UserControl IsNot Nothing Then
            Dim _PlaceHolder As PlaceHolder
            Dim _LabelExito As Label
            Dim _LabelFalla As Label

            If bError Then

                If tipoOperacion = Val_General.Registrar.ToString Then
                    mensaje = Val_General.AddExito.ToString
                ElseIf tipoOperacion = Val_General.Editar.ToString Then
                    mensaje = Val_General.EditExito.ToString
                ElseIf tipoOperacion = Val_General.Eliminar.ToString Then
                    mensaje = Val_General.DeleteExito.ToString
                End If

                _PlaceHolder = CType(_UserControl.FindControl("AlertExito"), PlaceHolder)
                _LabelExito = CType(_UserControl.FindControl("lbAlertMsjExito"), Label)
                _LabelExito.Text = mensaje & " a las " & DateTime.Now.ToString("HH:mm:ss")
            Else
                If tipoOperacion = Val_General.Registrar.ToString Then
                    mensaje = Val_General.AddFalla.ToString
                ElseIf tipoOperacion = Val_General.Editar.ToString Then
                    mensaje = Val_General.EditFalla.ToString
                ElseIf tipoOperacion = Val_General.Eliminar.ToString Then
                    mensaje = Val_General.DeleteFalla.ToString
                End If

                _PlaceHolder = CType(_UserControl.FindControl("AlertFalla"), PlaceHolder)
                _LabelFalla = CType(_UserControl.FindControl("lbAlertMsjFalla"), Label)
                _LabelFalla.Text = mensaje & " a las " & DateTime.Now.ToString("HH:mm:ss")
            End If

            _PlaceHolder.Visible = True
            _PlaceHolder.Focus()

        End If

    End Sub

    ''' <summary>
    ''' Metodo que oculta el updatepanel de Alerta
    ''' </summary>
    Public Shared Sub OcultarAlerta(_Master As UpdatePanel)

        Dim _UserControl As UserControl = CType(_Master.FindControl("ucAlerta"), UserControl)

        If _UserControl IsNot Nothing Then

            Dim _PlaceHolder As PlaceHolder
            _PlaceHolder = CType(_UserControl.FindControl("AlertExito"), PlaceHolder)
            _PlaceHolder.Visible = False
            _PlaceHolder = CType(_UserControl.FindControl("AlertFalla"), PlaceHolder)
            _PlaceHolder.Visible = False

        End If

    End Sub

    ''' <summary>
    ''' Metodo que recibe el updatepanel donde esta el Alert, el valor booleano de la operacion, 
    ''' y el mensaje para mostrar en el alerta
    ''' </summary>
    Public Shared Sub MostrarMensajeAlerta(_Master As UpdatePanel, bError As Boolean, Mensaje As String)

        Dim _UserControl As UserControl = CType(_Master.FindControl("ucAlerta"), UserControl)
        If _UserControl IsNot Nothing Then

            Dim _PlaceHolder As PlaceHolder
            Dim _LabelExito As Label
            Dim _LabelFalla As Label

            If bError Then

                _PlaceHolder = CType(_UserControl.FindControl("AlertExito"), PlaceHolder)
                _LabelExito = CType(_UserControl.FindControl("lbAlertMsjExito"), Label)
                _LabelExito.Text = Mensaje
            Else
                _PlaceHolder = CType(_UserControl.FindControl("AlertFalla"), PlaceHolder)
                _LabelFalla = CType(_UserControl.FindControl("lbAlertMsjFalla"), Label)
                _LabelFalla.Text = Mensaje
            End If

            _PlaceHolder.Visible = True
            _PlaceHolder.Focus()

        End If

    End Sub

End Class
