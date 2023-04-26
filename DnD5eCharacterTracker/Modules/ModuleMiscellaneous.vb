Module ModuleMiscellaneous

#Disable Warning BC42312

#Region " Miscellaneous Procedures and Functions "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Function CheckAppRunning() As System.Boolean

        Dim _IsAppRunning As System.Boolean = False
        Dim _AppProcesses() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName(My.Application.Info.ProductName)

        Try
            If _AppProcesses.Length > 0 Then _IsAppRunning = True
        Catch ex As Exception
            _IsAppRunning = False
        End Try

        Return _IsAppRunning

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetCommandLineArgs()

        Dim _ArgumentsCommandLine As System.String() = Nothing

        Try
            If _CommandLineArguments.Count > 0 Then
                _ArgumentsCommandLine = System.Environment.GetCommandLineArgs()
                For Each _Argument As String In _ArgumentsCommandLine
                    Select Case _Argument
                        Case Else
                            Exit Select
                    End Select
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(String.Format("Program: {1}{0}Form: {2}{0}Procedure/Function: {3}{0}{0}Error: {4}", vbNewLine, PROGRAMNAME, "modApplication", "GetCommandLineArgs", ex.Message))
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_OverrideBuild"></param>
    ''' <returns></returns>
    Public Function SetProgramBuild(Optional ByVal _OverrideBuild As System.Boolean = False) As System.String

        Dim _StringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            With _StringBuilder
                '[ Use Const PROGRAMBUILD if not empty and OverrideBuild flag is set to True. ]
                If Not String.IsNullOrEmpty(PROGRAMBUILD) And _OverrideBuild = True Then
                    .Append(PROGRAMBUILD)
                    Return .ToString()
                    Exit Function
                Else '[ Otherwise build version. ]
                    '[ Check Major version. Required. ]
                    If Not String.IsNullOrEmpty(PROGRAMBUILDMAJORVERSION) Then
                        .Append(PROGRAMBUILDMAJORVERSION)
                        '[ Check Minor version. Required. ]
                        If Not String.IsNullOrEmpty(PROGRAMBUILDMAJORVERSION) Then
                            .AppendFormat(".{0}", PROGRAMBUILDMINORVERSION)
                            '[ Check Patch version. Not Required]
                            If Not String.IsNullOrEmpty(PROGRAMBUILDPATCHVERSION) Then
                                .AppendFormat(".{0}", PROGRAMBUILDPATCHVERSION)
                            End If
                            '[ Check Pre-Release tag. Not required. ]
                            If Not String.IsNullOrEmpty(PROGRAMBUILDPRERELEASETAG) Then
                                .AppendFormat("{0}", PROGRAMBUILDPRERELEASETAG)
                                '[ Check Pre-Release version. Not required. ]
                                If Not String.IsNullOrEmpty(PROGRAMBUILDPRERELEASEVERSION) Then
                                    .AppendFormat("{0}", PROGRAMBUILDPRERELEASEVERSION)
                                End If
                            End If
                        Else '[ If Minor Version is not set, append 0 and return. ]
                            .Append(".0")
                        End If
                    Else '[ If Major Version is not set, return default. ]
                        .Append("0.0.0")
                    End If
                End If
            End With
        Catch ex As Exception
            _StringBuilder.Clear.Append("0.0.0")
        End Try

        Return _StringBuilder.ToString()

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Type"></param>
    ''' <param name="_Message"></param>
    ''' <param name="_ModuleName">The name of the form, class, or module containing the procedure that is causing the error. CAN USE System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString FOR THIS PARAMETER.</param>
    ''' <param name="_MethodName">The name of the procedure causing the error. CAN USE System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString FOR THIS PARAMETER.</param>
    ''' <remarks></remarks>
    Public Sub ShowMessage(ByVal _Type As System.String, ByVal _Message As System.String, Optional ByVal _ModuleName As System.String = Nothing, Optional ByVal _MethodName As System.String = Nothing)

        Try
            Select Case _Type
                Case "Error"
                    System.Windows.Forms.MessageBox.Show(String.Format("Program: {1}{0}Form: {2}{0}Procedure: {3}{0}{0}Error: {4}", vbNewLine, PROGRAMNAME, _ModuleName, _MethodName, _Message), PROGRAMNAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
                    Exit Select
                Case "Information"
                    System.Windows.Forms.MessageBox.Show(System.String.Format("{0}", _Message), PROGRAMNAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
                    Exit Select
                Case "Stop"
                    System.Windows.Forms.MessageBox.Show(System.String.Format("{0}", _Message), PROGRAMNAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop)
                    Exit Select
                Case "Warning"
                    System.Windows.Forms.MessageBox.Show(System.String.Format("{0}", _Message), PROGRAMNAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning)
                    Exit Select
                Case Else
                    System.Windows.Forms.MessageBox.Show(System.String.Format("{0}", _Message), PROGRAMNAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None)
                    Exit Select
            End Select
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(String.Format("Program: {1}{0}Form: {2}{0}Procedure: {3}{0}{0}Error: {4}", vbNewLine, PROGRAMNAME, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString, ex.Message), PROGRAMNAME, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " Code Snippets "

    ''' <summary>
    ''' Default Try ... Catch ... Finally ... Code
    ''' </summary>
    'Try
    '    
    'Catch ex As Exception
    '    ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
    'Finally
    '
    'End Try


    ''' <summary>
    ''' MS Access DB Connection Code
    ''' </summary>
    'Dim OleConnection As OleDbConnection = AccessConnection()
    'Dim OleCommand As OleDbCommand = Nothing
    'Dim OleReader As OleDbDataReader = Nothing
    'Dim QueryString As StringBuilder = New StringBuilder()
    'Dim [[SOMETHING]] As 
    '
    '    Try
    '        If OleConnection IsNot Nothing Then
    '            If OleConnection.State = ConnectionState.Open Then
    '                Using OleConnection
    '                    OleCommand = New OleDbCommand()
    '                    OleCommand.Connection = OleConnection
    '                    With QueryString
    '                        .Clear()
    '                    End With
    '                    With OleCommand
    '                       '.CommandType = CommandType.StoredProcedure
    '                       .CommandType = CommandType.Text
    '                       .CommandText = QueryString.ToString()
    '                       '[ Add Parameter Values. ]
    '                       .Parameters.AddWithValue("", "")
    '                       '[ Execute INSERT or UPDATE query. ]
    '                       .ExecuteNonQuery()
    '                       '[ Execute Single-Value SELECT query. ]
    '                       [[SOMETHING]] = .ExecuteScalar()
    '                       '[ Execute Multi-Value SELECT query. ]
    '                       OleReader = .ExecuteReader()
    '                    End With
    '                    If OleReader.HasRows = True Then
    '                        While OleReader.Read()
    '
    '                        End While
    '                    End If
    '                    OleReader.Close()
    '                End Using
    '            End If
    '            OleConnection.Close()
    '        End If
    '    Catch ex As Exception
    '        ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
    '    Finally
    '        If OleReader IsNot Nothing Then OleReader.Dispose()
    '        If OleCommand IsNot Nothing Then OleCommand.Dispose()
    '        If OleConnection IsNot Nothing Then OleConnection.Dispose()
    '    End Try


    ''' <summary>
    ''' Sybase DB Connection Code
    ''' </summary>
    'Dim OdbcConnect As OdbcConnection = SybaseConnection()
    'Dim OdbcCommand As OdbcCommand = Nothing
    'Dim OdbcReader As OdbcDataReader = Nothing
    'Dim QueryString As StringBuilder = New StringBuilder()
    'Dim [[SOMETHING]] As 
    '
    '    Try
    '        If OdbcConnect IsNot Nothing Then
    '            If OdbcConnect.State = ConnectionState.Open Then
    '                Using OdbcConnect
    '                    With QueryString
    '                        .Clear()
    '                    End With
    '                    OdbcCommand = New OdbcCommand(QueryString.ToString(), OdbcConnect)
    '                    With OdbcCommand
    '                       '[ Add Parameter Values. ]
    '                       .Parameters.AddWithValue("", "")
    '                       '[ Execute INSERT or UPDATE query. ]
    '                       .ExecuteNonQuery()
    '                       '[ Execute Single-Value SELECT query. ]
    '                       [[SOMETHING]] =  .ExecuteScalar()
    '                       '[ Execute Multi-Value SELECT query. ]
    '                       OdbcReader = .ExecuteReader()
    '                    End With
    '                    If OdbcReader.HasRows = True Then
    '                        While OdbcReader.Read()
    '
    '                        End While
    '                    End If
    '                    OdbcReader.Close()
    '                End Using
    '            End If
    '            OdbcConnect.Close()
    '        End If
    '    Catch ex As Exception
    '        ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
    '    Finally
    '        If OdbcReader IsNot Nothing Then OdbcReader.Dispose()
    '        If OdbcCommand IsNot Nothing Then OdbcCommand.Dispose()
    '        If OdbcConnect IsNot Nothing Then OdbcConnect.Dispose()
    '    End Try


    ''' <summary>
    ''' SQLite DB Connection Code
    ''' </summary>
    'Dim _SQLiteConnect As SQLiteConnection = SQLiteConnection()
    'Dim _SQLiteCommand As SQLiteCommand = Nothing
    'Dim _SQLiteReader As SQLiteDataReader = Nothing
    'Dim _SQLiteAdapter As SQLiteDataAdapter = Nothing
    'Dim _QueryString As StringBuilder = New StringBuilder()
    'Dim _[[SOMETHING]] As 
    '
    '    Try
    '        If _SQLiteConnect IsNot Nothing Then
    '            If _SQLiteConnect.State = ConnectionState.Open Then
    '                Using _SQLiteConnect
    '                    With _QueryString
    '                        .Clear()
    '                        .Append()
    '                        .AppendFormat()
    '                    End With
    '                    _SQLiteCommand = New SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
    '                    With _SQLiteCommand
    '                       '[ Add Parameter Values. ]
    '                       .Parameters.AddWithValue("", "")
    '                       '[ Execute INSERT or UPDATE query. ]
    '                       .ExecuteNonQuery()
    '                       '[ Execute Single-Value SELECT query. ]
    '                       [[SOMETHING]] = .ExecuteScalar()
    '                       '[ Execute Multi-Value SELECT query. ]
    '                       _SQLiteReader = .ExecuteReader()
    '                    End With
    '                    If _SQLiteReader IsNot Nothing Then
    '                       With _SQLiteReader
    '                          If .HasRows = True Then
    '                             While .Read()
    '                                '.Item("")
    '                             End While
    '                          End If
    '                          .Close()
    '                       End With
    '                    End If
    '                    With _SQLiteAdapter
    '                       .SelectCommand = _SQLiteCommand
    '                       '.Fill(InMemoryDataSet.Tables(""))
    '                    End With
    '                End Using
    '            End If
    '        End If
    '    Catch ex As Exception
    '        ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
    '    Finally
    '        If _SQLiteReader IsNot Nothing Then _SQLiteReader.Dispose()
    '        If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
    '        If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
    '    End Try



    ''' <summary>
    ''' MSSQL DB Connection Code (New)
    ''' </summary>
    'Dim _MSSqlConnection As SqlConnection = MSSqlServerConnection()
    'Dim _MSSqlReader As SqlDataReader = Nothing
    'Dim _QueryString As StringBuilder = New StringBuilder()
    'Dim _[[SOMETHING]] As Object

    '    Try
    '        Using _MSSqlConnection
    '            If _MSSqlConnection IsNot Nothing Then
    '                If _MSSqlConnection.State = ConnectionState.Open Then
    '                    '###  [ COPY FROM THIS LINE TO NEXT FOR MULTIPLE STATEMENTS ]  ###
    '                    With _QueryString
    '                        .Clear()
    '                        .Append()
    '                        .AppendFormat()
    '                    End With
    '                    Using _MSSqlCommand As New SqlCommand With {.Connection = _MSSqlConnection, .CommandType = CommandType.Text, .CommandText = _QueryString.ToString()}
    '                        If _MSSqlCommand IsNot Nothing Then
    '                            With _MSSqlCommand
    '                                '[ Add Parameter Values. ]
    '                                '.Parameters.AddWithValue("", "")
    '                                '[ Execute INSERT or UPDATE query. ]
    '                                '.ExecuteNonQuery()
    '                                '[ Execute Single-Value SELECT query. ]
    '                                '_[[SOMETHING]] = .ExecuteScalar()
    '                                '[ Execute Multi-Value SELECT query. ]
    '                                '_MSSqlReader = .ExecuteReader()
    '                            End With
    '                            If _MSSqlReader.HasRows = True Then
    '                                While _MSSqlReader.Read()
    '                                    
    '                                End While
    '                            End If
    '                            _MSSqlReader.Close()
    '                        End If
    '                    End Using
    '                    '###  [ END OF STATEMENT ]  ###
    '                End If
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
    '    Finally
    '        If _MSSqlReader IsNot Nothing Then _MSSqlReader.Dispose()
    '        If _MSSqlConnection IsNot Nothing Then _MSSqlConnection.Dispose()
    '    End Try




    ''' <summary>
    ''' MSSQL DB Connection Code (Old)
    ''' </summary>
    'Dim MSSqlConnection As SqlConnection = MSSqlServerConnection()
    'Dim MSSqlCommand As SqlCommand = Nothing
    'Dim MSSqlReader As SqlDataReader = Nothing
    'Dim QueryString As StringBuilder = New StringBuilder()
    'Dim [[SOMETHING]] As 
    '
    '    Try
    '        If MSSqlConnection IsNot Nothing Then
    '            If MSSqlConnection.State = ConnectionState.Open Then
    '                Using MSSqlConnection
    '                    MSSqlCommand = New SqlCommand()
    '                    MSSqlCommand.Connection = MSSqlConnection
    '                    With QueryString
    '                        .Clear()
    '                    End With
    '                    With MSSqlCommand
    '                       '.CommandType = CommandType.StoredProcedure
    '                       .CommandType = CommandType.Text
    '                       .CommandText = QueryString.ToString()
    '                    '[ Add Parameter Values. ]
    '                       .Parameters.AddWithValue("", "")
    '                       '[ Execute INSERT or UPDATE query. ]
    '                       .ExecuteNonQuery()
    '                       '[ Execute Single-Value SELECT query. ]
    '                       [[SOMETHING]] = .ExecuteScalar()
    '                       '[ Execute Multi-Value SELECT query. ]
    '                       MSSqlReader = .ExecuteReader()
    '                    End With
    '                    If MSSqlReader.HasRows = True Then
    '                        While MSSqlReader.Read()
    '
    '                        End While
    '                    End If
    '                    MSSqlReader.Close()
    '                End Using
    '            End If
    '            MSSqlConnection.Close()
    '        End If
    '    Catch ex As Exception
    '        ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
    '    Finally
    '        If MSSqlReader IsNot Nothing Then MSSqlReader.Dispose()
    '        If MSSqlCommand IsNot Nothing Then MSSqlCommand.Dispose()
    '        If MSSqlConnection IsNot Nothing Then MSSqlConnection.Dispose()
    '    End Try


    ''' <summary>
    ''' ShowMessage Error Code
    ''' </summary>
    'ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)


    ''' <summary>
    ''' DataTable Column Creation Code
    '''      .Name = Name of Column
    '''      .Type = Type of Column (0: String, 1: Int32, 2: Int64, 3: Decimal, 4: Boolean, 5: Date/Time, 6: TimeSpan)
    '''      .Key = If Column is PrimaryKey of DataTable. Default FALSE.
    '''      .AllowNull = If Column accepts NULL value. Default TRUE.
    ''' </summary>
    'With DataTableColumns
    '    If .Count > 0 Then .Clear()
    '    '[ Repeat below line for each column you wish to add. ]
    '    .Add(New DataTableColumn() With {.Name = "", .Type = 0, .Key = False, .AllowNull = True})
    'End With
    '[ Replace TABLENAME with name of new DataTable you are creating. Last parameter indicates whether to delete table if it already exists and recreate with no data. ]
    'AddDataTable(TABLENAME, DataTableColumns, True)


    ''' <summary>
    ''' Event Viewer Logging Code
    ''' </summary>
    '''      1) Uncomment the following line in FormMain's Load event.
    '''            CheckErrorLogging()
    '''      2) Add the following line anywhere you want to write an event to the Event Viewer. Remember to change the EventLogEntryType.
    '''            EventLog.WriteEntry(PROGRAMNAME, "Message", EventLogEntryType.Error)


#End Region

#Enable Warning BC42312

End Module
