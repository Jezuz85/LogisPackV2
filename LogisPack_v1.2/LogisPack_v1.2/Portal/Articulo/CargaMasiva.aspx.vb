﻿Imports CapaDatos

Public Class CargaMasiva
    Inherits System.Web.UI.Page

    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Form.Attributes.Add("enctype", "multipart/form-data")

        If Manager_Usuario.ValidarAutenticado(User) Then
            Manager_Usuario.ValidarMenu(Me, Master)

            idCliente = Getter.Cliente_Usuario(Manager_Usuario.GetUserId(User))

            If Not IsPostBack Then
                CargarListas()
            Else

            End If
        Else
            Response.Redirect(Paginas.Login.ToString)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que llena los Dropdownlits con datos de la Base de Datos
    ''' </summary>
    Private Sub CargarListas()
        Listas.Cliente(ddlCliente, idCliente)
    End Sub

    '--------------------------------------------------EVENTOS---------------------------------------------

    ''' <summary>
    ''' Metodo que se ejecuta para cargar los articulo en la base de datos
    ''' </summary>
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Page.IsValid Then

            Dim resultadoCarga = Manager_Excel.CargaMasiva(fuExcel, "Articulos", ddlAlmacen.SelectedValue)

            If resultadoCarga(0).Equals(Val_General.CargaExito.ToString) Then
                Modal.MostrarMensajeAlerta(_updatePpal, True, resultadoCarga(0))
            Else
                phErrors.Visible = True

                Modal.MostrarMensajeAlerta(_updatePpal, False, Val_General.CargaFalla.ToString & "" & fuExcel.FileName)
                ControlesDinamicos.CrearLiteral("<ul class='list-group'>", pListaErrores)
                For Each itemErrores In resultadoCarga
                    ControlesDinamicos.CrearLiteral("<li class='list-group-item'>" & itemErrores & "</li>", pListaErrores)
                Next
                ControlesDinamicos.CrearLiteral("</ul>", pListaErrores)

            End If

        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un cliente de la lista
    ''' </summary>
    Protected Sub ddlCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged

        If ddlCliente.SelectedValue = String.Empty Then
            ddlAlmacen.Items.Clear()
        Else
            Mgr_Almacen.Llenar_Lista(ddlAlmacen, Convert.ToInt32(ddlCliente.SelectedValue))
        End If

    End Sub




End Class