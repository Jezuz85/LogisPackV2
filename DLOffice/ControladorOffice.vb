Public Class ControladorOffice
#Region "Declaraciones"
    ''' <summary>
    ''' Enumeración sobre el tipo de formato de las integraciones
    ''' </summary>
    Public Enum EnTipoFormatoIntegra As Short
        Excel = 1
        Access = 2
    End Enum
#End Region


    ''' <summary>
    ''' Devuelve una lista de los nombres de las hojas excel o tablas access del archivo. En el de Excel contienen "$" al final
    ''' </summary>
    ''' <param name="Fichero">Path hacia el fichero a comprobar</param>
    ''' <param name="Cual">Enumeracion sobre el Tipo de formato del fichero a integrar. Puede ser Excel o Access</param>
    ''' <returns>Lista de los nombres de las tablas que contiene el fichero Fichero</returns>
    Public Shared Function ObtenerNombreHojasExcelOTablasAccess(ByVal Fichero As String, ByVal Cual As EnTipoFormatoIntegra) As List(Of String)
        Dim Respuesta As New List(Of String)
        Dim cn As System.Data.OleDb.OleDbConnection = Nothing

        Try
            Respuesta.Clear()
            Dim dataTable As Data.DataTable
            Dim restrictions(-1) As Object
            Dim CadenaConexion As String = ""
            Select Case Cual
                Case EnTipoFormatoIntegra.Access
                    CadenaConexion = "provider=Microsoft.Jet.OLEDB.4.0;" & "data source=" & Fichero
                Case EnTipoFormatoIntegra.Excel
                    Try
                        CadenaConexion = Carga_CadenaConexionExcel(Fichero)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Information, My.Resources.MSG_Imposible_abrir_Excel_Solo_Titulo)
                        Return Respuesta
                    End Try
            End Select
            Dim i As Integer
            '
            cn = New System.Data.OleDb.OleDbConnection(CadenaConexion)
            If cn Is Nothing Then
                cn = New Data.OleDb.OleDbConnection(CadenaConexion)
            End If
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            '
            dataTable = cn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, restrictions)
            i = dataTable.Rows.Count - 1
            If i > -1 Then
                For i = 0 To dataTable.Rows.Count - 1
                    If dataTable.Rows(i).Item("TABLE_TYPE").ToString.ToUpper = "TABLE".ToUpper Then
                        Select Case Cual
                            Case EnTipoFormatoIntegra.Access
                                Respuesta.Add(dataTable.Rows(i).Item("TABLE_NAME").ToString)
                            Case EnTipoFormatoIntegra.Excel
                                Dim NombreHoja As String = dataTable.Rows(i).Item("TABLE_NAME").ToString
                                'Cuando los nombres de tabla vienen con espacios vienen tambien entre comillas simples
                                'que hemos de eliminar para que el resto de operaciones con la hoja funcionen correctamente
                                If NombreHoja.StartsWith("'") AndAlso NombreHoja.EndsWith("'") Then
                                    NombreHoja = NombreHoja.TrimStart("'".ToCharArray)
                                    NombreHoja = NombreHoja.TrimEnd("'".ToCharArray)
                                End If
                                Respuesta.Add(NombreHoja)
                        End Select
                    End If
                Next
            End If
            Return Respuesta
        Catch ex As Exception
            Throw
        Finally
            If Not cn Is Nothing AndAlso cn.State <> ConnectionState.Closed Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
    End Function
 


#Region "Excel nativo"

    ''' <summary>
    ''' Plantilla para crear los criterios al obtener datos de un archivo excel. El nombre de la hoja ha de terminar con "$"
    ''' </summary>
    Private Shared _PlantillaCriterioExcel As String = "SELECT * FROM [{0:NombreHoja}]"

    ''' <summary>
    ''' Rellena un DataTable a partir de la primera hoja de un Excel. Devuelve: Un DataTable con el contenido de la primera hoja o Nothing si la hoja no tiene filas de datos
    ''' </summary>
    ''' <param name="RutaExcel">Ruta del archivo excel a procesar</param>
    ''' <param name="NombreTabla">Nombre del DataTable resultante o "" para usar el nombre de la hoja</param> 
    ''' <returns>Un DataTable con el contenido de la primera hoja o Nothing si la hoja no tiene filas de datos</returns>
    Public Shared Function RellenarDTExcel(ByVal RutaExcel As String, ByVal NombreTabla As String) As DataTable
        Dim LstNombreHoja As List(Of String) = ObtenerNombreHojasExcelOTablasAccess(RutaExcel, EnTipoFormatoIntegra.Excel)

        If String.IsNullOrWhiteSpace(NombreTabla) Then
            NombreTabla = LstNombreHoja(0)
        End If

        Return RellenarDTExcel(RutaExcel, String.Format(_PlantillaCriterioExcel, LstNombreHoja(0)), NombreTabla)
    End Function

    ''' <summary>
    ''' Rellena un DataTable a partir de la hoja Excel que aparece en el Criterio. Devuelve: Un DataTable que contiene las filas de la hoja Excel o Nothing si la hoja no tiene filas de datos
    ''' </summary>
    ''' <param name="RutaExcel">Ruta del archivo Excel</param>
    ''' <param name="Criterio">Criterio de seleccion de filas y hoja (ej: "SELECT * FROM [hoja1$]")</param>
    ''' <param name="NombreTabla">Nombre que se dara al DataTable resultante en el DataSet</param>
    ''' <returns>Un DataTable que contiene las filas de la hoja Excel o Nothing si la hoja no tiene filas de datos</returns>
    Public Shared Function RellenarDTExcel(ByVal RutaExcel As String, ByVal Criterio As String, ByVal NombreTabla As String) As DataTable
        Dim MiConexion As OleDb.OleDbConnection = Nothing
        Dim Dt As DataTable = Nothing

        Try
            Dim CadenaConexion As String = Carga_CadenaConexionExcel(RutaExcel)

            MiConexion = New OleDb.OleDbConnection(CadenaConexion)

            Dt = RellenarDTExcel(MiConexion, Criterio, NombreTabla)
        Catch ex As Exception
            Throw
        Finally
            If MiConexion IsNot Nothing AndAlso MiConexion.State <> ConnectionState.Closed Then
                MiConexion.Close()
                MiConexion.Dispose()
            End If
        End Try

        Return Dt
    End Function

    ''' <summary>
    ''' Rellena un DataSet a partir de todas las hojas de un fichero Excel. Devuelve: Un DataSet con las filas del archivo Excel o Nothing si las hojas no tienen filas de datos
    ''' </summary>
    ''' <param name="RutaExcel">Ruta del archivo Excel</param>
    ''' <returns>Un DataSet con las filas del archivo Excel o Nothing si las hojas no tienen filas de datos</returns>
    Public Shared Function RellenarDSExcel(ByVal RutaExcel As String) As DataSet
        Dim DS As DataSet = Nothing
        Dim MiConexion As OleDb.OleDbConnection = Nothing

        Try
            Dim LstNombreHoja As List(Of String) = ObtenerNombreHojasExcelOTablasAccess(RutaExcel, EnTipoFormatoIntegra.Excel)
            Dim CadenaConexion As String = Carga_CadenaConexionExcel(RutaExcel)
            Dim Dt As DataTable = Nothing

            MiConexion = New OleDb.OleDbConnection(CadenaConexion)

            For Each NombreHoja As String In LstNombreHoja
                Dt = RellenarDTExcel(MiConexion, String.Format(_PlantillaCriterioExcel, NombreHoja), NombreHoja)
                If Dt IsNot Nothing Then
                    If DS Is Nothing Then
                        DS = New DataSet
                    End If
                    DS.Tables.Add(Dt)
                End If
            Next
        Catch ex As Exception
            Throw
        Finally
            If MiConexion IsNot Nothing AndAlso MiConexion.State <> ConnectionState.Closed Then
                MiConexion.Close()
                MiConexion.Dispose()
            End If
        End Try

        Return DS
    End Function

    ''' <summary>
    ''' Rellena un DataSet a partir de la hoja Excel que aparece en el Criterio. Devuelve: Un DataSet que contiene las filas de la hoja Excel o Nothing si la hoja no tiene filas de datos
    ''' </summary>
    ''' <param name="RutaExcel">Ruta del archivo Excel</param>
    ''' <param name="Criterio">Criterio de seleccion de filas y hoja (ej: "SELECT * FROM [hoja1$]")</param>
    ''' <param name="NombreTabla">Nombre que se dara al DataTable resultante en el DataSet</param>
    ''' <returns>Un DataSet que contiene las filas de la hoja Excel o Nothing si la hoja no tiene filas de datos</returns>
    ''' <remarks>NOTA: Asume que la funcion "Carga_CadenaConexionExcel" usa el parametro "HDR" con valor "NO".</remarks>
    Public Shared Function RellenarDSExcel(ByVal RutaExcel As String, Criterio As String, NombreTabla As String) As DataSet
        Dim Ds As DataSet = Nothing

        Dim Dt As DataTable = RellenarDTExcel(RutaExcel, Criterio, NombreTabla)
        If Dt IsNot Nothing Then
            If Ds Is Nothing Then
                Ds = New DataSet
            End If

            Ds.Tables.Add(Dt)
        End If

        Return Ds
    End Function

    ''' <summary>
    ''' Devuelve la cadena de conexion mas apropiada para abrir el fichero excel introducido
    ''' </summary>
    ''' <param name="Fichero">Ruta del archivo Excel</param>
    ''' <returns>Devuelve la cadena de conexion mas apropiada para abrir el fichero excel introducido</returns>
    ''' <remarks>Las extensiones de fichero excel soportadas son: xls, xlsx, xlsb, xlsm</remarks>
    Public Shared Function Carga_CadenaConexionExcel(ByVal Fichero As String) As String
        Dim cn As System.Data.OleDb.OleDbConnection
        Dim CadenaConexion As String = ""
        Dim ru As New System.IO.FileInfo(Fichero)
        Dim asCn() As String = {}
        Dim sErrorMsg As String = String.Empty

        'NOTA: esto solventa el problema cuando devolvia a Nothing el valor de una celda que tenia datos. Se debia a que al leer el excel inspecciona las
        '8 primeras filas para determinar qué tipo de datos contiene la columna. Si las 8 primeras filas contenian un numero y la 9 tenia texto ésta última
        'se devolvia a Nothing porque el tipo de datos no coincidia con las 8 prmieras filas (que eran numericas)
        'Parametros:
        'HDR=NO: Indica que no tenemos cabecera (aunque si que tengamos, forma parte del hack). Por si acaso no funciona en algun parametro de los que vienen
        '   a continuacion indicamos que no queremos usar la primera fila como cabceras con lo que al examinar las filas para determinar el tipo de dato la primera
        '   ya es de texto y aunque las siguientes 7 filas sean numericas el tipo de dato ya seria String e importaria todas las filas correctamente.
        '   Esto implica que al cargar el excel en el DataTable tenemos que hacer un proceso extra para renombrar las columnas del DataTable y eliminar la primera
        '   fila que en realidad contiene los nombres de columna.
        'IMEX=1: Indica que las columnas tienen tipos de datos diferentes
        'TypeGuessRows=0: Indica que escanee todas las filas y no solo las 8 primeras
        'ImportMixedTypes=Text: Indica que ha de importar las celdas como texto
        'http://stackoverflow.com/questions/3232281/oledb-mixed-excel-datatypes-missing-data

        'IMPORTANTE: Si cambiamos el parametro "HDR" a "YES" hemos de tener en cuenta que la funcion "RellenarDTExcel" asume que "HDR=NO" y habra que modificar la funcion
        '"RellenarDTExcel" para que funcione correctamente

        'Establecemos todas las posibles cadenas de conexion dependiendo del tipo de Excel a abrir
        Select Case ru.Extension.Trim.ToLower
            Case ".xls"
                asCn = {"Provider=Microsoft.Jet.Oledb.4.0; Data source= " & Fichero & ";Extended properties=""Excel 8.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text""",
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & Fichero & ";Extended properties=""Excel 8.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text""",
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & Fichero & ";Extended Properties=""Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text""",
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & Fichero & ";Extended Properties=""Excel 12.0 Xml;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text"""}
            Case ".xlsx"
                asCn = {"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & Fichero & ";Extended Properties=""Excel 12.0 Xml;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text"""}
            Case ".xlsb"
                asCn = {"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & Fichero & ";Extended Properties=""Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text"""}
            Case ".xlsm"
                asCn = {"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & Fichero & ";Extended Properties=""Excel 12.0 Macro;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text"""}
        End Select

        'Probamos todas las cadenas de conexion hasta que una funciona
        For ii As Byte = 0 To asCn.GetUpperBound(0)
            Try
                CadenaConexion = asCn(ii)
                cn = New OleDb.OleDbConnection(CadenaConexion)
                If cn Is Nothing Then 'Por si acaso lo volvemos a intentar, a veces a la primera no se hacia correctamente
                    cn = New OleDb.OleDbConnection(CadenaConexion)
                End If
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                    cn.Close()
                    cn.Dispose()
                End If
                'La cadena de conexion ha funcionado, no hace falta iterar por el resto de cadenas de conexion
                Exit For
            Catch ex As Exception
                'Grabamos el error para poder determinar si algunas cadenas de conexion no funcionan y porque
                'ControladorEventLog.WriteEntry(ex)

                'Si estamos en la ultima iteracion del bucle, al salir del bucle y al ser la cadena = "", se mostrara el error.
                'Se mostrara el error cuando ya hayamos iterado por todas las cadenas de conexion
                CadenaConexion = ""

                If sErrorMsg.Length > 0 Then
                    sErrorMsg &= " "
                End If
                sErrorMsg = ex.Message
            End Try
        Next

        'Si finalmente no hemos encontrado una cadena de conexion que funcione lo mas problable es que no este instalado el driver necesario para procesar el archivo
        If (CadenaConexion.Length = 0) Then
            If sErrorMsg.Length > 0 Then
                sErrorMsg = My.Resources.MSG_Imposible_Abrir_Excel_Solo_Titulo & ". (" & sErrorMsg & ")"
            Else
                sErrorMsg = My.Resources.MSG_Imposible_Abrir_Excel_Solo_Titulo
            End If
            Throw New Exception(sErrorMsg)
        End If

        Return CadenaConexion
    End Function

    ''' <summary>
    ''' Rellena un DataTable a partir de la hoja Excel que aparece en el Criterio. Devuelve: Un DataSet que contiene las filas de la hoja Excel o Nothing si la hoja no tiene filas de datos
    ''' </summary>
    ''' <param name="Cn">Conexion activa con la hoja excel</param>
    ''' <param name="Criterio">Criterio de seleccion de filas y hoja (ej: "SELECT * FROM [hoja1$]")</param>
    ''' <param name="NombreTabla">Nombre que se dara al DataTable resultante en el DataSet</param>
    ''' <returns>Un DataTable que contiene las filas de la hoja Excel o Nothing si la hoja no tiene filas de datos</returns>
    ''' <remarks>NOTA: Asume que la funcion "Carga_CadenaConexionExcel" usa el parametro "HDR" con valor "NO".</remarks>
    Private Shared Function RellenarDTExcel(ByRef Cn As OleDb.OleDbConnection, ByVal Criterio As String, ByVal NombreTabla As String) As DataTable
        Dim Da As OleDb.OleDbDataAdapter = Nothing
        Dim Dt As DataTable = Nothing

        Try
            Dim LstNombreCampo As New List(Of String)
            Criterio = ParsearCriterioExcel(Criterio, LstNombreCampo)

            Da = New OleDb.OleDbDataAdapter(Criterio, Cn)
            Dt = New DataTable
            Da.Fill(Dt)
            Da.Dispose()

            If EsHojaVaciaExcel(Dt) Then
                Return Nothing
            End If

            If NombreTabla.EndsWith("$") Then
                NombreTabla = NombreTabla.TrimEnd("$".ToCharArray)
            End If
            Dt.TableName = NombreTabla

            'Al usar en la cadena de conexion HDR=NO; no usara la primera fila como header sino como una fila. Hay que usar esa primera fila para nombrar las columnas
            'de forma que se pueda usar el DataTable de forma transparente, usanso el nombre de las columnas.
            'Cogemos el nombre de las cabeceras de la primera fila y las ponemos como nombre de columna a la table.
            Dim rowDel As DataRow = Dt.Rows(0)
            For ii As Integer = 0 To Dt.Columns.Count - 1
                'TODO: que hacemos en este caso? Esto se da cuando no se detecta correctamente el numero de
                'columnas, por ejemplo, cuando no hay nada en la celda
                If rowDel(ii) Is Convert.DBNull Then
                    ' - Hemos salir? Si. Las columnas "fantasma" tendran nombre "F[X]" que OleDbAdapter asigna automaticamente
                    ' - Saltar esta columna? No, porque el numero columnas del formato y del excel a importar no coincidiria y mostraria un mensaje conforme el formato
                    '   no coincide. Ademas este caso no podria darse porque las columnas que contienen datos deben tener el titulo de columna
                    ' - Darle un nombre generico a la columna? En realidad es lo mismo que salir. 
                    Exit For
                End If

                'Por si hay columnas que tienen el mismo nombre. Ej: si dos columnas se llaman "Poblacion" la primera columna conservara ese nombre la segunda se
                'llamara "Poblacion0" y asi sucesivamente
                Dim Contador As String = ""
                Dim NombreColumna As String = rowDel(ii).ToString
                While Dt.Columns.Contains(NombreColumna & Contador)
                    If Contador = "" Then
                        Contador = 0
                    Else
                        Contador = CType(Contador, Integer) + 1
                    End If
                End While
                Dt.Columns(ii).ColumnName = NombreColumna & Contador
            Next

            'Borramos las primera fila porque contiene los nombres de las columnas y no son datos a procesar
            Dt.Rows.Remove(rowDel)

            'Tenemos en cuenta las columnas que se han pasado en el Criterio, borramos aquellas que no se han solicitado
            If LstNombreCampo.Count > 0 AndAlso LstNombreCampo(0) <> "*" Then
                For ii As Integer = Dt.Columns.Count - 1 To 0 Step -1
                    If Not LstNombreCampo.Contains(Dt.Columns(ii).ColumnName.ToUpper) Then 'Los nombres de campo de la lista estan en mayusculas
                        Dt.Columns.Remove(Dt.Columns(ii))
                    End If
                Next
            End If

        Catch ex As Exception
            Throw
        Finally
            If Da IsNot Nothing Then
                Da.Dispose()
            End If
        End Try

        Return Dt
    End Function

    ''' <summary>
    ''' Parsea el Criterio para que podamos usarlo al abrir un Excel al que se le indica que no contiene cabeceras ("HDR=NO"), aunque realmente las tendremos en la primera fila.
    ''' Siempre incluye todos los campo "*", esto es porque al indicarle que no tiene cabeceras el Adaptador no entiende como lo ha de hacer si se especifican campos concretos y da
    ''' un error.
    ''' Le suma 1 al numero del TOP (si lo tiene) dado que la primera fila de datos contendra las cabeceras. Si hiceramos un TOP 1 sin sumarle uno solo obtendriamos las cabeceras
    ''' lo que resularia en un DataTable vacio.
    ''' Compatible con los siguientes criterios: SELECT [Campo 1], [Campo N] FROM [NombreTabla] y SELECT TOP [Campo 1], [Campo N] FROM [NombreTabla].
    ''' Admite "*" en vez de los campos y nombres de campo con espacios.
    ''' </summary>
    ''' <param name="Criterio">Criterio a parsear</param>
    ''' <param name="LstNombreCampoOut">Lista de salida que contendra los nombres campos EN MAYUSCULAS (lo demos usar para eliminar las columnas de un DataTable que no es esten en esta lista)</param>
    ''' <returns>Cadena con el Criteio parseado EN MAYUSCULAS</returns>
    ''' <remarks>NOTA: Asume que la funcion "Carga_CadenaConexionExcel" usa el parametro "HDR" con valor "NO".</remarks>
    Private Shared Function ParsearCriterioExcel(ByVal Criterio As String, ByRef LstNombreCampoOut As List(Of String)) As String
        Dim Retorno As String = String.Empty
        Dim IdxCampo As Integer = 0
        Dim CriterioUpper As String = Criterio.ToUpper

        'Eliminamos los espacios que puedan haber de mas tanto al princio, en medio o al final
        'Ojo que esto es incompatible si queremos extraer nombres de campo que contengan espacios (usar la funcion "ExtraerCamposDeCriterioExcel" que tiene en cuenta los nombres
        'de campo con espacios)
        Dim ArCriterio As String() = CriterioUpper.Split({" "}, StringSplitOptions.RemoveEmptyEntries)

        'Comprobamos si el nombre de tabla tiene espacios. Despues de "FROM" solo tiene que haber un elemento mas en la lista (que seria el nombre de la tabla). Si hay mas
        'elementos quiere decir que el nombre de la tabla tiene espeacios. Hemos de juntar los partes de nombre de la tabla en el siguiente elemento despues del "FROM" y eliminar
        'los elementos del array que sobran
        Dim idxFROM As Integer = Array.IndexOf(ArCriterio, "FROM")
        If (ArCriterio.GetUpperBound(0) - idxFROM > 1) Then
            Dim NombreTablaTemp As String = String.Empty
            For ii As Integer = idxFROM + 1 To ArCriterio.GetUpperBound(0)
                NombreTablaTemp &= ArCriterio(ii) & " "
            Next

            'Cuando el nombre de tabla tiene espacios contiene "'" (comilla simple) al principio y al final). Debemos eliminarlas
            ArCriterio(idxFROM + 1) = NombreTablaTemp.Replace("'", "").Trim
            Array.Resize(ArCriterio, idxFROM + 2)
        End If

        'Comprobamos si tiene TOP
        If Array.IndexOf(ArCriterio, "TOP") > -1 Then
            'ArCriterio: (0): SELECT; (1): TOP; (2): Numero de TOP; (3): Campo1; (N): CampoN; (N+1): FROM; (Ultimo): Nombre tabla
            Dim iNumeroTop As Integer = CInt(ArCriterio(2)) + 1
            Retorno = "SELECT TOP " & iNumeroTop & " * "
        Else
            'ArCritrio: (0): SELECT; (1): Campo1; (N): CampoN; (N+1): FROM; (Ultimo): Nombre tabla
            Retorno = "SELECT * "
        End If

        'Comprobamos si el nombre de tabla tiene "[", "]" y "$" o "`"
        Dim NombreTabla As String = ArCriterio(ArCriterio.GetUpperBound(0)) 'La tabla esta en ultima posicion
        If (NombreTabla.StartsWith("[") AndAlso NombreTabla.EndsWith("$]")) OrElse (NombreTabla.StartsWith("`") AndAlso NombreTabla.EndsWith("$`")) Then
            'Tiene el formato correcto
        Else
            'No tiene el formato correcto
            'Limpiamos el nombre de tabla
            NombreTabla = NombreTabla.Replace("[", "").Replace("]", "")
            NombreTabla = NombreTabla.Replace("`", "")
            NombreTabla = NombreTabla.Replace("$", "")
            'Aplicacmos el formato correcto
            NombreTabla = "[" & NombreTabla & "$]"
        End If

        Retorno &= "FROM " & NombreTabla

        If LstNombreCampoOut IsNot Nothing Then
            LstNombreCampoOut = ExtraerCamposDeCriterioExcel(Criterio)
        End If

        Return Retorno
    End Function

    ''' <summary>
    ''' Extrae los campos de un Criterio excel. Tiene en cuenta que los nombres de campo puedan contener espacios. 
    ''' Compatible con los siguientes criterios: SELECT [Campo 1], [Campo N] FROM [NombreTabla] y SELECT TOP [Campo 1], [Campo N] FROM [NombreTabla].
    ''' Admite "*" en vez de los campos y nombres de campo con espacios.
    ''' </summary>
    ''' <param name="Criterio">Criterio a analizar</param>
    ''' <returns>Un lista con los nombres de los campos EN MAYUSCULAS</returns>
    Private Shared Function ExtraerCamposDeCriterioExcel(ByVal Criterio As String) As List(Of String)
        Dim CriterioUpper As String = Criterio.ToUpper

        'Eliminamos espacios duplicados
        While CriterioUpper.Contains("  ")
            CriterioUpper = CriterioUpper.Replace("  ", " ")
        End While

        'Eliminamos del FROM hacia adelante
        Dim IdxCar As Integer = CriterioUpper.IndexOf(" FROM ")
        CriterioUpper = CriterioUpper.Remove(IdxCar)

        'Eliminamos SELECT
        CriterioUpper = CriterioUpper.Replace("SELECT ", "")

        If CriterioUpper.Contains("TOP ") Then
            'Eliminamos TOP
            CriterioUpper = CriterioUpper.Replace("TOP ", "")

            'Buscamos el primer espacio (que estara despues del numero del TOP)
            IdxCar = CriterioUpper.IndexOf(" ")
            CriterioUpper = CriterioUpper.Substring(IdxCar + 1)
        End If

        'Ahora solo tenemos los campos separados por ","
        Dim ArCampo() As String = CriterioUpper.Split(",")
        Dim LstCampo As New List(Of String)
        For Each Campo As String In ArCampo
            Campo = Campo.Trim

            'Eliminamos los "[]" que contienen el nombre campo
            If Campo.Contains("[") Then
                Campo = Campo.Substring(1, Campo.Length - 2)
            End If

            If Campo.Length > 0 Then
                LstCampo.Add(Campo)
            End If
        Next

        Return LstCampo
    End Function

    ''' <summary>
    ''' Indica si un DataTable que representa una hoja esta vacio.
    ''' </summary>
    ''' <param name="Dt">DataTable a procesar</param>
    ''' <returns>TRUE si la hoja esta vacia</returns>
    ''' <remarks>NOTA: Asume que la funcion "Carga_CadenaConexionExcel" usa el parametro "HDR" con valor "NO".</remarks>
    Private Shared Function EsHojaVaciaExcel(ByVal Dt As DataTable) As Boolean
        If Dt.Rows.Count = 0 Then
            Return True
        End If

        'Si queremos tener en cuenta si solo tiene filas de datos, hay que tener en cuenta que la primera fila contiene las cabeceras
        'Como se asume que las cabceras forman parte de los datos (ver remarks) hemos de comparar con 1 y no con 0
        'If Dt.Rows.Count = 1 Then
        'Return True
        'End If

        'Por algun motivo cuando una hoja esta vacia viene con una columna "F1" y filas vacias (2 para xls, 1 para xlsx)...
        If Dt.Columns.Count = 1 AndAlso Dt.Columns(0).ColumnName.EndsWith("F1") AndAlso Dt.Rows.Count < 3 Then
            'Comprobamos si todas las filas son Null
            For Each DR As DataRow In Dt.Rows
                If Not DR.IsNull(0) Then
                    'No es  un null, quiere decir que la hoja no esta vacia
                    Exit For
                End If
            Next

            Return True
        End If

        Return False
    End Function

#End Region
End Class
