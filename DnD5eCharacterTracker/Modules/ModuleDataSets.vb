Module ModuleDataSets

#Disable Warning BC42312

#Region " Variables "

    ''' <summary>
    ''' In-Memory DataSet setup.
    ''' See 'Code Snippets' region in ModuleApplication for sample code of how to add columns to in-memory DataTable.
    ''' </summary>
    Public _InMemoryDataSet As System.Data.DataSet = New System.Data.DataSet()
    '[ Sets up a collection to store DataTable column information to add to DataTable. Must be cleared before setting up columns for each table. ]
    Public _DataTableColumns As New Microsoft.VisualBasic.Collection()

#End Region

#Region " Procedures And Functions For In-Memory DataSets "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_TableName"></param>
    ''' <param name="_TableColumns"></param>
    ''' <param name="_ForceAdd"></param>
    ''' <returns></returns>
    Public Function AddDataTable(ByVal _TableName As String, ByVal _TableColumns As Collection, Optional ByVal _ForceAdd As Boolean = False) As Boolean

        Dim _DataTable As System.Data.DataTable = Nothing
        Dim _TableExists As Boolean = False

        Try
            If _ForceAdd = True Then
                If _InMemoryDataSet.Tables.Contains(_TableName) Then
                    _InMemoryDataSet.Tables.Remove(_TableName)
                End If
            End If
            If _InMemoryDataSet.Tables.Contains(_TableName) Then
                With _InMemoryDataSet.Tables(_TableName)
                    If .Rows.Count > 0 Then
                        .Clear()
                        .Columns(0).AutoIncrement = True
                        .Columns(0).AutoIncrementStep = -1
                        .Columns(0).AutoIncrementSeed = -1
                        .Columns(0).AutoIncrementStep = 1
                        .Columns(0).AutoIncrementSeed = 1
                    End If
                End With
                _TableExists = True
            Else
                _DataTable = SetupDataTable(_TableName, _TableColumns)
                If _DataTable IsNot Nothing Then
                    _InMemoryDataSet.Tables.Add(_DataTable)
                    If _InMemoryDataSet.Tables.Contains(_TableName) Then
                        _TableExists = True
                    Else
                        _TableExists = False
                    End If
                Else
                    _TableExists = False
                End If
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _TableExists = False
        End Try

        Return _TableExists

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_TableName"></param>
    ''' <param name="_TableColumns"></param>
    ''' <returns></returns>
    Public Function SetupDataTable(ByVal _TableName As String, ByVal _TableColumns As Microsoft.VisualBasic.Collection) As System.Data.DataTable

        Dim _DataTable As System.Data.DataTable = Nothing
        Dim _DataColumn As System.Data.DataColumn = Nothing
        Dim _DataColumnKey(1) As System.Data.DataColumn

        Try
            _DataTable = New System.Data.DataTable(_TableName)
            With _DataTable
                For Each _TableColumn As DataTableColumn In _TableColumns
                    _DataColumn = New System.Data.DataColumn(_TableColumn.Name)
                    If _TableColumn.Key = True Then
                        With _DataColumn
                            .AutoIncrement = True
                            .AutoIncrementSeed = 1
                            .AutoIncrementStep = 1
                        End With
                        _DataColumnKey(0) = _DataColumn
                    End If
                    Select Case _TableColumn.Type
                        Case 0 '[ String ]
                            _DataColumn.DataType = System.Type.GetType("System.String")
                            Exit Select
                        Case 1 '[ Int32 ]
                            _DataColumn.DataType = System.Type.GetType("System.Int32")
                            Exit Select
                        Case 2 '[ Int64 ]
                            _DataColumn.DataType = System.Type.GetType("System.Int64")
                            Exit Select
                        Case 3 '[ Decimal]
                            _DataColumn.DataType = System.Type.GetType("System.Decimal")
                            Exit Select
                        Case 4 '[ Double ]
                            _DataColumn.DataType = System.Type.GetType("System.Double")
                            Exit Select
                        Case 5 '[ Boolean ]
                            _DataColumn.DataType = System.Type.GetType("System.Boolean")
                            Exit Select
                        Case 6 '[ Date/Time ]
                            _DataColumn.DataType = System.Type.GetType("System.DateTime")
                            Exit Select
                        Case 7 '[ Time Span ]
                            _DataColumn.DataType = System.Type.GetType("System.TimeSpan")
                            Exit Select
                        Case 8 '[ Byte Array ]
                            _DataColumn.DataType = GetType(Byte())
                            Exit Select
                        Case Else '[ Default to String ]
                            _DataColumn.DataType = System.Type.GetType("System.String")
                            Exit Select
                    End Select
                    _DataColumn.AllowDBNull = _TableColumn.AllowNull
                    .Columns.Add(_DataColumn)
                Next
                .PrimaryKey = _DataColumnKey
            End With
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _DataTable = Nothing
        End Try

        Return _DataTable

    End Function

    ''' <summary>
    ''' Returns a single datarow from the specified datatable that corresponds to the search string. ]
    ''' </summary>
    ''' <param name="_DataTableName">The name of the datatable.</param>
    ''' <param name="_SearchString">The search string in which to find the datatable row. Essentially the WHERE clause of a standard SQL query.</param>
    ''' <param name="_SortString">The sort string in which to order the datatable rows. Essentially the SORT clause of a standard SQL query.</param>
    ''' <returns>Datarow that corresponds to the given SearchString and optional SortString.</returns>
    ''' <remarks></remarks>
    Public Function GetSingleDataTableRow(ByVal _DataTableName As String, ByVal _SearchString As String, Optional ByVal _SortString As String = Nothing) As System.Data.DataRow

        Dim _FoundRows As System.Data.DataRow()
        Dim _FoundRow As System.Data.DataRow = Nothing

        Try
            _FoundRows = _InMemoryDataSet.Tables(_DataTableName).Select(_SearchString)
            If _FoundRows.Length > 0 Then _FoundRow = _FoundRows(0)
        Catch Ex As Exception
            ShowMessage("Error", Ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _FoundRow = Nothing
        End Try

        Return _FoundRow

    End Function

    ''' <summary>
    ''' Returns a single value, AS AN OBJECT, from the specified datatable datarow that corresponds to the search string. ]
    ''' </summary>
    ''' <param name="_DataTableName">The name of the datatable.</param>
    ''' <param name="_TableColumn">The name of the datatable column of the value being returned.</param>
    ''' <param name="_SearchString">The search string in which to find the datatable row. Essentially the WHERE clause of a standard SQL query.</param>
    ''' <returns>Value from datarow column that corresponds to the given column name.</returns>
    ''' <remarks></remarks>
    Public Function GetSingleDataTableRowValue(ByVal _DataTableName As String, ByVal _TableColumn As String, ByVal _SearchString As String) As System.Object

        Dim _FoundRows As System.Data.DataRow()
        Dim _Object As System.Object = Nothing

        Try
            If _InMemoryDataSet.Tables(_DataTableName).Columns.Contains(_TableColumn) Then
                _FoundRows = _InMemoryDataSet.Tables(_DataTableName).Select(_SearchString)
                If _FoundRows.Length > 0 Then
                    _Object = _FoundRows(0).Item(_TableColumn)
                Else
                    _Object = Nothing
                End If
            Else
                _Object = Nothing
            End If
        Catch Ex As Exception
            ShowMessage("Error", Ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Object = Nothing
        End Try

        Return _Object

    End Function

    ''' <summary>
    ''' Returns multiple datarows from the specified datatable that corresponds to the search string. ]
    ''' </summary>
    ''' <param name="_DataTableName">The name of the datatable.</param>
    ''' <param name="_SearchString">The search string in which to find the datatable rows. Essentially the WHERE clause of a standard SQL query.</param>
    ''' <param name="_SortString">The sort string in which to order the datatable rows. Essentially the SORT clause of a standard SQL query.</param>
    ''' <returns>Datarows that corresponds to the given SearchString and optional SortString.</returns>
    ''' <remarks></remarks>
    Public Function GetMultipleDataTableRows(ByVal _DataTableName As String, ByVal _SearchString As String, Optional ByVal _SortString As String = Nothing) As System.Data.DataRow()

        Dim _FoundRows As System.Data.DataRow()

        Try
            If _SortString IsNot Nothing Then
                _FoundRows = _InMemoryDataSet.Tables(_DataTableName).Select(_SearchString, _SortString)
            Else
                _FoundRows = _InMemoryDataSet.Tables(_DataTableName).Select(_SearchString)
            End If
        Catch Ex As Exception
            ShowMessage("Error", Ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _FoundRows = Nothing
        End Try

        Return _FoundRows

    End Function

#End Region

#Enable Warning BC42312

End Module
