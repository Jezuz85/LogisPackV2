Imports System.Drawing
Imports System.Web.UI.WebControls

Public Class ControlesDinamicos

    ''' <summary>
    ''' Metodo que crea dinamicamente un literal y lo añade a un panel enviado por parametro
    ''' </summary>
    Public Shared Sub CrearLiteral(etiqueta As String, _panel As Panel)
        Dim miLiteral As New Literal()
        miLiteral.Text = etiqueta
        _panel.Controls.Add(miLiteral)

    End Sub

    ''' <summary>
    ''' Metodo que crea dinamicamente un RequiredFieldValidator y lo añade a un panel enviado por parametro
    ''' </summary>
    Public Shared Sub CrearRequiredFieldValidator(_miControl As String, _panel As Panel, _ValidationGroup As String)
        Dim miRequiredFieldValidator As RequiredFieldValidator
        miRequiredFieldValidator = New RequiredFieldValidator()
        miRequiredFieldValidator.ErrorMessage = "<p>Campo Obligatorio!</p>"
        miRequiredFieldValidator.SetFocusOnError = True
        miRequiredFieldValidator.Display = ValidatorDisplay.Dynamic
        miRequiredFieldValidator.ForeColor = ColorTranslator.FromHtml("#B50128")
        miRequiredFieldValidator.Font.Size = 10
        miRequiredFieldValidator.Font.Bold = True
        miRequiredFieldValidator.ControlToValidate = _miControl
        miRequiredFieldValidator.ValidationGroup = _ValidationGroup
        _panel.Controls.Add(miRequiredFieldValidator)

    End Sub

    ''' <summary>
    ''' Metodo que crea dinamicamente un TextBox y lo añade a un panel enviado por parametro
    ''' </summary>
    Public Shared Sub CrearTextbox(ByVal id As String, _panel As Panel, _TextBoxMode As TextBoxMode, Optional ByVal _TextType As String = "text")
        Dim miTextBox As TextBox
        miTextBox = New TextBox()
        miTextBox.ID = id
        miTextBox.TextMode = _TextBoxMode
        If _TextBoxMode = TextBoxMode.MultiLine Then
            miTextBox.Rows = 3

        End If
        miTextBox.Attributes.Add("type", _TextType)
        _panel.Controls.Add(miTextBox)

    End Sub

    ''' <summary>
    ''' Metodo que crea dinamicamente un DropDownList y lo añade a un panel enviado por parametro
    ''' </summary>
    Public Shared Function CrearDropDownList(id As String, _panel As Panel, _DropDownList As DropDownList) As DropDownList

        _DropDownList.ID = id
        _panel.Controls.Add(_DropDownList)

        Return _DropDownList
    End Function

    ''' <summary>
    ''' Metodo que crea dinamicamente un Hyperlink y lo añade a un panel enviado por parametro
    ''' </summary>
    Public Shared Sub CrearHyperLink(ByVal id As String, _panel As Panel, _Texto As String, _ruta As String)

        Dim miHyperLink As HyperLink
        miHyperLink = New HyperLink()
        miHyperLink.ID = id
        miHyperLink.Text = _Texto
        miHyperLink.NavigateUrl += _ruta
        miHyperLink.Target = "_blank"

        _panel.Controls.Add(miHyperLink)
    End Sub

End Class
