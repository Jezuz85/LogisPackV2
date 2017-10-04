Imports System.Web.UI

Public Class Utilidades_Menu

    ''' <summary>
    ''' Metodo para cargar menu dependiendo del rol
    ''' </summary>
    Public Shared Sub CargarMenu(_Rol As String, _Master As MasterPage)

        If _Rol = Rol.Admin.ToString Then

            Dim _Control As Control = _Master.FindControl("dropbtn_Cliente")
            _Control.Visible = True

            _Control = _Master.FindControl("dropbtn_Almacen")
            _Control.Visible = True

            _Control = _Master.FindControl("dropbtn_Articulo")
            _Control.Visible = True

            _Control = _Master.FindControl("dropbtn_Operacion")
            _Control.Visible = True

            _Control = _Master.FindControl("dropbtn_TipoFacturacion")
            _Control.Visible = True

            _Control = _Master.FindControl("dropbtn_TipoUnidad")
            _Control.Visible = True

            _Control = _Master.FindControl("dropbtn_Inicio")
            _Control.Visible = True
        Else
            Dim _Control As Control = _Master.FindControl("dropbtn_Cliente")
            _Control.Visible = False

            _Control = _Master.FindControl("dropbtn_TipoFacturacion")
            _Control.Visible = False

            _Control = _Master.FindControl("dropbtn_TipoUnidad")
            _Control.Visible = False
        End If

    End Sub

    ''' <summary>
    ''' Metodo para ocultar menu dependiendo del rol
    ''' </summary>
    Public Shared Sub OcultarMenu(_Master As MasterPage)

        Dim _Control As Control = _Master.FindControl("dropbtn_Cliente")
        _Control.Visible = False

        _Control = _Master.FindControl("dropbtn_Almacen")
        _Control.Visible = False

        _Control = _Master.FindControl("dropbtn_Articulo")
        _Control.Visible = False

        _Control = _Master.FindControl("dropbtn_Operacion")
        _Control.Visible = False

        _Control = _Master.FindControl("dropbtn_TipoFacturacion")
        _Control.Visible = False

        _Control = _Master.FindControl("dropbtn_TipoUnidad")
        _Control.Visible = False

        _Control = _Master.FindControl("dropbtn_Inicio")
        _Control.Visible = False

    End Sub

End Class
