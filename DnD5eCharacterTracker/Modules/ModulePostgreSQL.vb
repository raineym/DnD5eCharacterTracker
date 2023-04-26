Module ModulePostgreSQL

#Disable Warning BC42312

#Region " Variables "

    ''' <summary>
    ''' PostgreSQL Server database connection setup.
    ''' Parameter READONLY is optional. Boolean. Default is FALSE.
    ''' </summary>
    Public _PostgreSQLConnectionString As System.String = Nothing 'SetupPostgreSQLServerConnectionString("DBNAME", "SERVERNAME", "SERVERPORT", "USERNAME", "PASSWORD", "READONLY")

#End Region

#Region " Procedures and Function for PostgreSQL Server "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_ConnectionString"></param>
    ''' <returns></returns>
    Public Function PostgreSQLConnection(Optional ByVal _ConnectionString As System.String = Nothing) As System.Data.Odbc.OdbcConnection

        Dim _OdbcConnection As System.Data.Odbc.OdbcConnection = Nothing

        Try
            If _ConnectionString IsNot Nothing Then
                _OdbcConnection = New System.Data.Odbc.OdbcConnection(_ConnectionString)
            Else
                _OdbcConnection = New System.Data.Odbc.OdbcConnection(_PostgreSQLConnectionString)
            End If
            Do While _OdbcConnection.State = System.Data.ConnectionState.Closed
                _OdbcConnection.Open()
            Loop
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _OdbcConnection = Nothing
        End Try

        Return _OdbcConnection

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Database"></param>
    ''' <param name="_Server"></param>
    ''' <param name="_ServerPort"></param>
    ''' <param name="_Username"></param>
    ''' <param name="_Password"></param>
    ''' <returns></returns>
    Public Function SetupPostgreSQLServerConnectionString(ByVal _Database As System.String, ByVal _Server As System.String, ByVal _ServerPort As System.Int64, ByVal _Username As System.String, ByVal _Password As System.String, Optional ByVal _ReadOnly As System.Boolean = False) As System.String

        Dim _ConnectionString As System.String = System.String.Empty

        Try
            _ConnectionString = System.String.Format("Driver={0};database={1};server={2};port={3};sslmode=enable;readonly={6};protocol=7.4;Uid={4};pwd={5};", "{PostgreSQL ANSI}", _Database, _Server, _ServerPort.ToString(), _Username, _Password, If(_ReadOnly = True, "1", "0"))
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _ConnectionString = System.String.Empty
        End Try

        Return _ConnectionString

    End Function

#End Region

#Enable Warning BC42312

End Module
