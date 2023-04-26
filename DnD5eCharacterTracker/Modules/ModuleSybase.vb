Module ModuleSybase

#Disable Warning BC42312

#Region " Variables "

    ''' <summary>
    ''' IBM Sybase database connection setup.
    ''' All parameters are required.
    ''' </summary>
    Public _SybaseConnectionString As System.String = Nothing 'SetupSybaseConnectionString("DSN", "DBNAME", "SERVERNAME", "SERVERPORT", "USERNAME", "PASSWORD")

#End Region

#Region " Procedures and Functions for Sybase Connections "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_ConnectionString"></param>
    ''' <returns></returns>
    Public Function SybaseConnection(Optional ByVal _ConnectionString As System.String = Nothing) As System.Data.Odbc.OdbcConnection

        Dim _OdbcConnection As System.Data.Odbc.OdbcConnection = Nothing

        Try
            If _ConnectionString IsNot Nothing Then
                _OdbcConnection = New System.Data.Odbc.OdbcConnection(_ConnectionString)
            Else
                _OdbcConnection = New System.Data.Odbc.OdbcConnection(_SybaseConnectionString)
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
    ''' <param name="_DSN"></param>
    ''' <param name="_Database"></param>
    ''' <param name="_Server"></param>
    ''' <param name="_ServerPort"></param>
    ''' <param name="_Username"></param>
    ''' <param name="_Password"></param>
    ''' <returns>Sybase connection string.</returns>
    Public Function SetupSybaseConnectionString(ByVal _DSN As System.String, ByVal _Database As System.String, ByVal _Server As System.String, ByVal _ServerPort As System.Int32, ByVal _Username As System.String, ByVal _Password As System.String)

        Dim _ConnectionString As System.String = System.String.Empty

        Try
            _ConnectionString = String.Format("DSN={0};database={1};server={2};port={3};uid={4};pwd={5};", _DSN, _Database, _Server, _ServerPort.ToString(), _Username, _Password)
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _ConnectionString = System.String.Empty
        End Try

        Return _ConnectionString

    End Function

#End Region

#Enable Warning BC42312

End Module
