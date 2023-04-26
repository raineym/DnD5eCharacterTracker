Module ModuleSQLite

#Disable Warning BC42312

#Region " Variables "

    ''' <summary>
    ''' SQLite database connection setup.
    ''' Parameter PASSWORD is optional. May be removed if database does not require a password to open.
    ''' </summary>
    Public _SQLiteConnectionString As System.String = SetupSQLiteConnectionString(System.String.Format("{0}\data.db3", APPDEFAULTDATAPATH))

#End Region

#Region " Procedures and Functions for SQLite Connections "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_ConnectionString"></param>
    ''' <returns></returns>
    Public Function SQLiteConnection(Optional ByVal _ConnectionString As System.String = Nothing) As System.Data.SQLite.SQLiteConnection

        Dim _SQLiteConnection As System.Data.SQLite.SQLiteConnection = Nothing

        Try
            If _ConnectionString IsNot Nothing Then
                _SQLiteConnection = New System.Data.SQLite.SQLiteConnection(_ConnectionString)
            Else
                _SQLiteConnection = New System.Data.SQLite.SQLiteConnection(_SQLiteConnectionString)
            End If
            Do While _SQLiteConnection.State = System.Data.ConnectionState.Closed
                _SQLiteConnection.Open()
            Loop
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _SQLiteConnection = Nothing
        End Try

        Return _SQLiteConnection

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_Password"></param>
    ''' <returns></returns>
    Public Function SetupSQLiteConnectionString(ByVal _Path As System.String, Optional ByVal _Password As System.String = Nothing) As System.String

        Dim _ConnectionString As System.String = String.Empty
        Dim _ConnectionStringBuilder As System.Text.StringBuilder = Nothing

        Try
            _ConnectionStringBuilder = New System.Text.StringBuilder()
            With _ConnectionStringBuilder
                .Append(String.Format("Data Source={0};", _Path))
                If _Password IsNot Nothing Then
                    _ConnectionStringBuilder.Append(String.Format("Password={0};", "Password"))
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
    ''' <param name="_SQLiteTableName"></param>
    ''' <param name="_Parameters"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FillDataTableFromSQLiteTable(ByVal _DataTableName As String, ByVal _SQLiteTableName As String, Optional ByVal _Parameters As Hashtable = Nothing) As Boolean

        Dim _SQLiteConnection As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _SQLiteAdapter As System.Data.SQLite.SQLiteDataAdapter = Nothing
        Dim _DataTableExists As Boolean = False
        Dim _SQLiteTableExists As Boolean = False
        Dim _DataTableFilled As Boolean = False

        Try
            If _InMemoryDataSet.Tables.Contains(_DataTableName) Then _DataTableExists = True
            If SQLiteConnection() IsNot Nothing Then
                If SQLiteConnection.State = ConnectionState.Open Then
                    Using SQLiteConnection()
                        _SQLiteCommand = New SQLiteCommand(String.Format("SELECT COUNT(*) AS SQLiteTableExists FROM sqlite_master WHERE type='table' AND name='{0}';", _SQLiteTableName), _SQLiteConnection)
                        _SQLiteTableExists = Convert.ToBoolean(_SQLiteCommand.ExecuteScalar())
                        If (_DataTableExists = True) AndAlso (_SQLiteTableExists = True) Then
                            With _InMemoryDataSet.Tables(_DataTableName)
                                If .Rows.Count > 0 Then
                                    .Clear()
                                    .Columns(0).AutoIncrement = True
                                    .Columns(0).AutoIncrementStep = -1
                                    .Columns(0).AutoIncrementSeed = -1
                                    .Columns(0).AutoIncrementStep = 1
                                    .Columns(0).AutoIncrementSeed = 1
                                End If
                            End With
                            _SQLiteCommand = New SQLiteCommand(String.Format("SELECT * FROM {0};", _SQLiteTableName), _SQLiteConnection)
                            '[ Add Parameter Values. ]
                            With _SQLiteCommand
                                If _Parameters IsNot Nothing Then
                                    For Each Parameter In _Parameters
                                        .Parameters.AddWithValue(Parameter.Key, Parameter.Value)
                                    Next
                                End If
                            End With
                            _SQLiteAdapter = New SQLiteDataAdapter(_SQLiteCommand)
                            _SQLiteAdapter.Fill(_InMemoryDataSet, _DataTableName)
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
            If _SQLiteAdapter IsNot Nothing Then _SQLiteAdapter.Dispose()
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnection IsNot Nothing Then _SQLiteConnection.Dispose()
        End Try

        Return _DataTableFilled

    End Function

#End Region

#Enable Warning BC42312

End Module
