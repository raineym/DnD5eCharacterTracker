Module ModuleMicrosoftAccess

#Disable Warning BC42312

#Region " Variables "


    ''' <summary>
    ''' Microsoft Access database connection setup.
    ''' Parameter PASSWORD is optional. May be removed if database does not require a password to open.
    ''' </summary>
    Public _AccessConnectionString As System.String = Nothing 'SetupAccessConnectionString("PATH/TO/DATABASE", "PASSWORD")

#End Region

#Region " Procedures and Functions for Microsoft Access Connections "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_ConnectionString"></param>
    ''' <returns></returns>
    Public Function AccessConnection(Optional ByVal _ConnectionString As System.String = Nothing) As System.Data.OleDb.OleDbConnection

        Dim _OleConnection As System.Data.OleDb.OleDbConnection = Nothing

        Try
            If _ConnectionString IsNot Nothing Then
                _OleConnection = New System.Data.OleDb.OleDbConnection(_ConnectionString)
            Else
                _OleConnection = New System.Data.OleDb.OleDbConnection(_AccessConnectionString)
            End If
            Do While _OleConnection.State = System.Data.ConnectionState.Closed
                _OleConnection.Open()
            Loop
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _OleConnection = Nothing
        End Try

        Return _OleConnection

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_Password"></param>
    ''' <returns>Microsoft Access connection string</returns>
    ''' <remarks></remarks>
    Public Function SetupAccessConnectionString(ByVal _Path As System.String, Optional ByVal _Password As System.String = Nothing) As System.String

        Dim _ConnectionString As System.String = System.String.Empty
        Dim _ConnectionStringBuilder As System.Text.StringBuilder = Nothing

        Try
            _ConnectionStringBuilder = New System.Text.StringBuilder()
            With _ConnectionStringBuilder
                .Append(String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", _Path))
                If _Password IsNot Nothing Then
                    .Append(String.Format("Jet OLEDB:Database Password={0};", "Password"))
                End If
                _ConnectionString = .ToString()
            End With
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _ConnectionString = String.Empty
        Finally
            _ConnectionStringBuilder.Clear()
        End Try

        Return _ConnectionString

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_DataTableName"></param>
    ''' <param name="_AccessTableName"></param>
    ''' <param name="_Parameters"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FillDataTableFromAccessDatabase(ByVal _DataTableName As String, ByVal _AccessTableName As String, Optional ByVal _Parameters As System.Collections.Hashtable = Nothing) As Boolean

        Dim _OleConnection As System.Data.OleDb.OleDbConnection = AccessConnection()
        Dim _OleCommand As System.Data.OleDb.OleDbCommand = Nothing
        Dim _OleSchema As System.Data.DataTable = Nothing
        Dim _OleAdapter As System.Data.OleDb.OleDbDataAdapter = Nothing
        Dim _DataTableExists As Boolean = False
        Dim _AccessTableExists As Boolean = False
        Dim _DataTableFilled As Boolean = False

        Try
            If _InMemoryDataSet.Tables.Contains(_DataTableName) Then _DataTableExists = True
            If _OleConnection IsNot Nothing Then
                If _OleConnection.State = System.Data.ConnectionState.Open Then
                    Using _OleConnection
                        _OleSchema = _OleConnection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, _AccessTableName, "TABLE"})
                        If _OleSchema.Rows.Count > 0 Then _AccessTableExists = True
                        If (_DataTableExists = True) AndAlso (_AccessTableExists = True) Then
                            _OleCommand = New System.Data.OleDb.OleDbCommand()
                            _OleCommand.Connection = _OleConnection
                            '[ Add Parameter Values. ]
                            With _OleCommand
                                .CommandType = System.Data.CommandType.Text
                                .CommandText = String.Format("SELECT * FROM {0};", _AccessTableName)
                                If _Parameters IsNot Nothing Then
                                    For Each Parameter In _Parameters
                                        .Parameters.AddWithValue(Parameter.Key, Parameter.Value)
                                    Next
                                End If
                            End With
                            _OleAdapter = New System.Data.OleDb.OleDbDataAdapter(_OleCommand)
                            _OleAdapter.Fill(_InMemoryDataSet, _DataTableName)
                            _InMemoryDataSet.AcceptChanges()
                        End If
                    End Using
                End If
            End If
            If _InMemoryDataSet.Tables(_DataTableName).Rows.Count > 0 Then _DataTableFilled = True
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _DataTableFilled = False
        Finally
            If _OleAdapter IsNot Nothing Then _OleAdapter.Dispose()
            If _OleCommand IsNot Nothing Then _OleCommand.Dispose()
            If _OleConnection IsNot Nothing Then _OleConnection.Dispose()
        End Try

        Return _DataTableFilled

    End Function

#End Region

#Enable Warning BC42312

End Module
