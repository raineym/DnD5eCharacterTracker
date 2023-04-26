Module ModuleMSSQL

#Disable Warning BC42312

#Region " Variables "

    ''' <summary>
    ''' Microsoft SQL Server database connection setup.
    ''' All parameters are required.
    ''' </summary>
    Public _MSSQLServerConnectionString As System.String = Nothing 'SetupMSSqlServerConnectionString("SERVER", "DATABASE", "USERNAME", "PASSWORD", TRUSTEDCONNECTION = TRUE/FALSE)

#End Region

#Region " Procedures and Function for Microsoft SQL Server "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_ConnectionString"></param>
    ''' <returns></returns>
    Public Function MSSqlServerConnection(Optional ByVal _ConnectionString As System.String = Nothing) As System.Data.SqlClient.SqlConnection

        Dim _MSSqlConnection As System.Data.SqlClient.SqlConnection = Nothing

        Try
            If _ConnectionString IsNot Nothing Then
                _MSSqlConnection = New System.Data.SqlClient.SqlConnection(_ConnectionString)
            Else
                _MSSqlConnection = New System.Data.SqlClient.SqlConnection(_MSSQLServerConnectionString)
            End If
            Do While _MSSqlConnection.State = System.Data.ConnectionState.Closed
                _MSSqlConnection.Open()
            Loop
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _MSSqlConnection = Nothing
        End Try

        Return _MSSqlConnection

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Server"></param>
    ''' <param name="_Database"></param>
    ''' <param name="_Username"></param>
    ''' <param name="_Password"></param>
    ''' <returns>Microsoft SQL Server connection string</returns>
    ''' <remarks></remarks>
    Public Function SetupMSSqlServerConnectionString(ByVal _Server As System.String, ByVal _Database As System.String, ByVal _Username As System.String, ByVal _Password As System.String, Optional ByVal _Trusted As System.Boolean = False) As System.String

        Dim _ConnectionString As String = String.Empty
        Dim _ConnectionStrings As System.Collections.Generic.List(Of System.String) = New System.Collections.Generic.List(Of System.String)(New System.String() {"Server={0}; Database={1}; Trusted_Connection={2}",
                                                                                                                                            "Server={0}; Database={1}; User Id={2}; Password={3}"})

        Try
            If _Trusted = True Then
                _ConnectionString = System.String.Format(_ConnectionStrings(0).ToString(), _Server, _Database, _Trusted)
            Else
                _ConnectionString = System.String.Format(_ConnectionStrings(1).ToString(), _Server, _Database, _Username, _Password)
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _ConnectionString = System.String.Empty
        End Try

        Return _ConnectionString

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_TableName"></param>
    ''' <returns></returns>
    Public Function ClearMSSqlTable(ByVal _TableName As System.String) As System.Boolean

        Dim _MSSqlConnection As System.Data.SqlClient.SqlConnection = MSSqlServerConnection()
        Dim _MSSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _IsTableClear As System.Boolean = True

        Try
            If _MSSqlConnection IsNot Nothing Then
                If _MSSqlConnection.State = System.Data.ConnectionState.Open Then
                    Using _MSSqlConnection
                        _MSSqlCommand = New System.Data.SqlClient.SqlCommand With {.Connection = _MSSqlConnection}
                        With _QueryString
                            .Clear()
                            .AppendFormat("Select CONVERT(bit, COUNT(*)) As IsTableClear FROM [dbo].[{0}];", _TableName)
                        End With
                        With _MSSqlCommand
                            .CommandType = System.Data.CommandType.Text
                            .CommandText = _QueryString.ToString()
                            '[ Execute INSERT or UPDATE query. ]
                            _IsTableClear = .ExecuteScalar()
                        End With
                        If _IsTableClear = False Then
                            With _QueryString
                                .Clear()
                                .AppendFormat("DELETE FROM [dbo].[{0}];", _TableName)
                            End With
                            With _MSSqlCommand
                                .CommandType = System.Data.CommandType.Text
                                .CommandText = _QueryString.ToString()
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                                _IsTableClear = True
                            End With
                        End If
                    End Using
                End If
                _MSSqlConnection.Close()
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            _QueryString.Clear()
            If _MSSqlCommand IsNot Nothing Then _MSSqlCommand.Dispose()
            If _MSSqlConnection IsNot Nothing Then _MSSqlConnection.Dispose()
        End Try

        Return _IsTableClear

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_DataTableName"></param>
    ''' <param name="_MsSQLDatabaseName"></param>
    ''' <param name="_MSSqlTableName"></param>
    ''' <returns></returns>
    Public Function CreateMSSqlTableFromDataTable(ByVal _DataTableName As String, ByVal _MsSQLDatabaseName As String, Optional ByVal _MSSqlTableName As String = Nothing) As Boolean

        Dim _MSSqlConnection As System.Data.SqlClient.SqlConnection = MSSqlServerConnection()
        Dim _MSSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _DataType As System.Type = Nothing
        Dim _MSSqlTableNameFinal As String = IIf(_MSSqlTableName IsNot Nothing, _MSSqlTableName, _DataTableName)
        Dim _DataTableExists As Boolean = False
        Dim _MSSqlTableExists As Boolean = False
        Dim _IsKey As Boolean = Nothing

        Try
            If _InMemoryDataSet.Tables.Contains(_DataTableName) Then _DataTableExists = True
            If _MSSqlConnection IsNot Nothing Then
                If _MSSqlConnection.State = System.Data.ConnectionState.Open Then
                    Using _MSSqlConnection
                        _MSSqlCommand = New System.Data.SqlClient.SqlCommand With {.Connection = _MSSqlConnection}
                        With _MSSqlCommand
                            .CommandText = Nothing
                            With _QueryString
                                .Clear()
                                .AppendFormat("Select CONVERT(bit, COUNT(*)) As MSSqlTableExists FROM OpsDashboard.INFORMATION_SCHEMA.TABLES WHERE TABLE_CATALOG = '{0}';", _MSSqlTableNameFinal)
                            End With
                            .CommandType = System.Data.CommandType.Text
                            .CommandText = _QueryString.ToString()
                            '[ Execute Single-Value SELECT query. ]
                            _MSSqlTableExists = System.Convert.ToBoolean(.ExecuteScalar())
                        End With
                        If (_DataTableExists = True) And (_MSSqlTableExists = False) Then
                            With _MSSqlCommand
                                .CommandText = Nothing
                                With _QueryString
                                    .Clear()
                                    .AppendFormat("CREATE TABLE [dbo].[{0}] (", _MSSqlTableNameFinal)
                                    For i As Integer = 0 To _InMemoryDataSet.Tables(_DataTableName).Columns.Count() - 1
                                        With _InMemoryDataSet.Tables(_DataTableName).Columns(i)
                                            _DataType = .DataType()
                                            _IsKey = .AutoIncrement
                                        End With
                                        Select Case _DataType
                                            Case System.Type.GetType("System.String")
                                                If i <> _InMemoryDataSet.Tables(_DataTableName).Columns.Count - 1 Then
                                                    .AppendFormat("{0} text,", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                Else
                                                    .AppendFormat("{0} text", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                End If
                                                Exit Select
                                            Case System.Type.GetType("System.Int32")
                                                If i <> _InMemoryDataSet.Tables(_DataTableName).Columns.Count - 1 Then
                                                    .AppendFormat("{0} int{1},", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName, IIf(_IsKey = True, " NOT NULL PRIMARY KEY", String.Empty))
                                                Else
                                                    .AppendFormat("{0} int{1}", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName, IIf(_IsKey = True, " NOT NULL PRIMARY KEY", String.Empty))
                                                End If
                                                Exit Select
                                            Case System.Type.GetType("System.Int64")
                                                If i <> _InMemoryDataSet.Tables(_DataTableName).Columns.Count - 1 Then
                                                    .AppendFormat("{0} bigint{1},", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName, IIf(_IsKey = True, " NOT NULL PRIMARY KEY", String.Empty))
                                                Else
                                                    .AppendFormat("{0} bigint{1}", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName, IIf(_IsKey = True, " NOT NULL PRIMARY KEY", String.Empty))
                                                End If
                                                Exit Select
                                            Case System.Type.GetType("System.Decimal")
                                                If i <> _InMemoryDataSet.Tables(_DataTableName).Columns.Count - 1 Then
                                                    .AppendFormat("{0} decimal,", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                Else
                                                    .AppendFormat("{0} decimal", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                End If
                                                Exit Select
                                            Case System.Type.GetType("System.Boolean")
                                                If i <> _InMemoryDataSet.Tables(_DataTableName).Columns.Count - 1 Then
                                                    .AppendFormat("{0} bit,", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                Else
                                                    .AppendFormat("{0} bit", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                End If
                                                Exit Select
                                            Case System.Type.GetType("System.DateTime")
                                                If i <> _InMemoryDataSet.Tables(_DataTableName).Columns.Count - 1 Then
                                                    .AppendFormat("{0} datetime,", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                Else
                                                    .AppendFormat("{0} datetime", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                End If
                                                Exit Select
                                            Case System.Type.GetType("System.TimeSpan")
                                                If i <> _InMemoryDataSet.Tables(_DataTableName).Columns.Count - 1 Then
                                                    .AppendFormat("{0} time,", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                Else
                                                    .AppendFormat("{0} time", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                End If
                                                Exit Select
                                            Case GetType(Byte())
                                                If i <> _InMemoryDataSet.Tables(_DataTableName).Columns.Count - 1 Then
                                                    .AppendFormat("{0} image,", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                Else
                                                    .AppendFormat("{0} image", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                End If
                                                Exit Select
                                            Case System.Type.GetType("System.Double")
                                                If i <> _InMemoryDataSet.Tables(_DataTableName).Columns.Count - 1 Then
                                                    .AppendFormat("{0} float,", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                Else
                                                    .AppendFormat("{0} float", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                End If
                                                Exit Select
                                            Case Else
                                                If i <> _InMemoryDataSet.Tables(_DataTableName).Columns.Count - 1 Then
                                                    .AppendFormat("{0} varchar(max),", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                Else
                                                    .AppendFormat("{0} varchar(max)", _InMemoryDataSet.Tables(_DataTableName).Columns(i).ColumnName)
                                                End If
                                                Exit Select
                                        End Select
                                    Next
                                    .Append(");")
                                End With
                                .CommandType = System.Data.CommandType.Text
                                .CommandText = _QueryString.ToString()
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                                With _MSSqlCommand
                                    .CommandText = Nothing
                                    With _QueryString
                                        .Clear()
                                        .AppendFormat("SELECT CONVERT(bit, COUNT(*)) As MSSqlTableExists FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'U');", _MSSqlTableNameFinal)
                                    End With
                                    .CommandType = System.Data.CommandType.Text
                                    .CommandText = _QueryString.ToString()
                                    '[ Execute Single-Value SELECT query. ]
                                    _MSSqlTableExists = System.Convert.ToBoolean(.ExecuteScalar())
                                End With
                            End With
                        Else
                            _MSSqlTableExists = False
                        End If
                    End Using
                End If
                _MSSqlConnection.Close()
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            If _MSSqlCommand IsNot Nothing Then _MSSqlCommand.Dispose()
            If _MSSqlConnection IsNot Nothing Then _MSSqlConnection.Dispose()
        End Try

        Return _MSSqlTableExists

    End Function

#End Region

#Enable Warning BC42312

End Module
