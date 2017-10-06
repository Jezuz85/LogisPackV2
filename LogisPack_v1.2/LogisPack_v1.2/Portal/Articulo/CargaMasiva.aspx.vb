﻿Imports CapaDatos

Public Class CargaMasiva
    Inherits System.Web.UI.Page

    Private bError As Boolean
    Private idCliente As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Form.Attributes.Add("enctype", "multipart/form-data")

        Manager_Usuario.ValidarMenu(Me, Master)

        If Manager_Usuario.ValidarAutenticado(User) Then

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
            Manager_Excel.CargaMasiva(fuExcel, "Articulos", ddlAlmacen.SelectedValue)
        End If

    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando se selecciona un cliente de la lista
    ''' </summary>
    Protected Sub ddlCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged

        If ddlCliente.SelectedValue = "" Then
            ddlAlmacen.Items.Clear()
        Else
            Listas.Almacen(ddlAlmacen, Convert.ToInt32(ddlCliente.SelectedValue))
        End If

    End Sub




End Class