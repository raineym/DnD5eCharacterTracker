Module ModuleRegistry

#Disable Warning BC42312

#Region " Procedures and Functions for Windows Registry "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <param name="_IsEdit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRegistryKey(ByVal _Path As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False, Optional ByVal _IsEdit As System.Boolean = False) As Microsoft.Win32.RegistryKey

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing

        Try
            If _IsLocalMachine = True Then
                If System.Environment.Is64BitOperatingSystem = True Then
                    _RegistryKey = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64)
                Else
                    _RegistryKey = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry32)
                End If
                _RegistryKey = _RegistryKey.OpenSubKey(_Path, _IsEdit)
            Else
                _RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(_Path, _IsEdit)
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _RegistryKey = Nothing
        End Try

        Return _RegistryKey

    End Function


    Public Function CreateRegistryKey(ByVal _Path As System.String, Optional ByVal _Values As System.Collections.Generic.List(Of RegKey) = Nothing, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Boolean

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _Success As System.Boolean = False

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine)
            If _RegistryKey Is Nothing Then '[ Registry key doesn't exist. ]
                If _IsLocalMachine = True Then
                    If System.Environment.Is64BitOperatingSystem = True Then
                        _RegistryKey = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64)
                    Else
                        _RegistryKey = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry32)
                    End If
                    _RegistryKey.CreateSubKey(_Path, Microsoft.Win32.RegistryKeyPermissionCheck.Default, Microsoft.Win32.RegistryOptions.None)
                Else
                    _RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(_Path, Microsoft.Win32.RegistryKeyPermissionCheck.Default, Microsoft.Win32.RegistryOptions.None)
                End If
                _Success = CheckRegistryKeyExists(_Path, _IsLocalMachine)
            Else '[ Registry key already exists. ]
                _Success = True
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Success = False
        Finally
            If (_Success = True) AndAlso (_Values IsNot Nothing) Then
                CreateRegistryKeyValues(_Path, _Values, _IsLocalMachine)
            End If
        End Try

        Return _Success

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_Values"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function CreateRegistryKeyValues(ByVal _Path As System.String, ByVal _Values As System.Collections.Generic.List(Of RegKey), Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Boolean

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyExists As System.Boolean = False
        Dim _Success As System.Boolean = False

        Try
            _RegistryKeyExists = CheckRegistryKeyExists(_Path, _IsLocalMachine)
            If (_RegistryKeyExists = True) AndAlso (_Values IsNot Nothing) Then
                For Each _Value As RegKey In _Values
                    Select Case _Value.Kind
                        Case Microsoft.Win32.RegistryValueKind.String
                            SetRegistryKeyStringValue(_Path, _Value.Name.ToString, _Value.RegistryValueString.ToString, _Value.LocalMachine)
                            If GetRegistryKeyStringValue(_Path, _Value.Name.ToString, _Value.LocalMachine) = _Value.RegistryValueString.ToString Then _Success = True
                            Exit Select
                        Case Microsoft.Win32.RegistryValueKind.ExpandString
                            SetRegistryKeyExpandStringValue(_Path, _Value.Name.ToString, _Value.RegistryValueExpandString.ToString, _Value.LocalMachine)
                            If GetRegistryKeyExpandStringValue(_Path, _Value.Name.ToString, _Value.LocalMachine) = _Value.RegistryValueExpandString.ToString Then _Success = True
                            Exit Select
                        Case Microsoft.Win32.RegistryValueKind.MultiString
                            SetRegistryKeyMultiStringValue(_Path, _Value.Name.ToString, _Value.RegistryValueMultiString, _Value.LocalMachine)
                            If _Value.RegistryValueMultiString.SequenceEqual(GetRegistryKeyMultiStringValue(_Path, _Value.Name.ToString, _Value.LocalMachine)) = True Then _Success = True
                            Exit Select
                        Case Microsoft.Win32.RegistryValueKind.Binary
                            SetRegistryKeyBinaryValue(_Path, _Value.Name.ToString, _Value.RegistryValueBinary, _Value.LocalMachine)
                            If _Value.RegistryValueBinary.SequenceEqual(GetRegistryKeyBinaryValue(_Path, _Value.Name.ToString, _Value.LocalMachine)) = True Then _Success = True
                            Exit Select
                        Case Microsoft.Win32.RegistryValueKind.DWord
                            SetRegistryKeyDWordValue(_Path, _Value.Name.ToString, _Value.RegistryValueDWord, _Value.LocalMachine)
                            If GetRegistryKeyDWordValue(_Path, _Value.Name.ToString, _Value.LocalMachine) = _Value.RegistryValueDWord Then _Success = True
                            Exit Select
                        Case Microsoft.Win32.RegistryValueKind.QWord
                            SetRegistryKeyQWordValue(_Path, _Value.Name.ToString, _Value.RegistryValueQWord, _Value.LocalMachine)
                            If GetRegistryKeyQWordValue(_Path, _Value.Name.ToString, _Value.LocalMachine) = _Value.RegistryValueQWord Then _Success = True
                            Exit Select
                    End Select
                Next
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Success = False
        End Try

        Return _Success

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function CheckRegistryKeyExists(ByVal _Path As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Boolean

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyExists As System.Boolean = False

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine)
            If _RegistryKey IsNot Nothing Then _RegistryKeyExists = True
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _RegistryKeyExists = False
        End Try

        Return _RegistryKeyExists

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_Value"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function CheckRegistryKeyValueExists(ByVal _Path As System.String, ByVal _Value As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Boolean

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueExists As System.Boolean = False

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                For Each _RegistryKeyValueName As String In _RegistryKeyValueNames
                    If _RegistryKeyValueName = _Value Then
                        _RegistryKeyValueExists = True
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _RegistryKeyValueExists = False
        End Try

        Return _RegistryKeyValueExists

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RegistryKeyValueCount(ByVal _Path As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Int64

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyValueCount As System.Int64 = 0

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine)
            If _RegistryKey IsNot Nothing Then _RegistryKeyValueCount = _RegistryKey.ValueCount
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _RegistryKeyValueCount = 0
        End Try

        Return _RegistryKeyValueCount

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_SubKey"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function GetRegistryKeyStringValue(ByVal _Path As System.String, ByVal _SubKey As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.String

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyValueObject As System.Object = Nothing
        Dim _RegistryKeyValueKind As RegistryValueKind = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueName As String = String.Empty
        Dim _RegistryKeyValue As System.String = Nothing

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                For Each _RegistryKeyValueName In _RegistryKeyValueNames
                    If _RegistryKeyValueName = _SubKey Then
                        _RegistryKeyValueKind = _RegistryKey.GetValueKind(_SubKey)
                        If _RegistryKeyValueKind = Microsoft.Win32.RegistryValueKind.String Then
                            _RegistryKeyValueObject = _RegistryKey.GetValue(_SubKey, Nothing)
                            If _RegistryKeyValueObject IsNot Nothing Then
                                _RegistryKeyValue = _RegistryKey.GetValue(_SubKey).ToString
                            End If
                        End If
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _RegistryKeyValue = Nothing
        End Try

        Return _RegistryKeyValue

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_SubKey"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function GetRegistryKeyMultiStringValue(ByVal _Path As String, ByVal _SubKey As String, Optional ByVal _IsLocalMachine As Boolean = False) As String()

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyValueObject As System.Object = Nothing
        Dim _RegistryKeyValueKind As Microsoft.Win32.RegistryValueKind = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueName As System.String = String.Empty
        Dim _RegistryKeyValue() As System.String = Nothing

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                If _RegistryKeyValueNames.Count > 0 Then
                    For Each _RegistryKeyValueName In _RegistryKeyValueNames
                        If _RegistryKeyValueName = _SubKey Then
                            _RegistryKeyValueKind = _RegistryKey.GetValueKind(_SubKey)
                            If _RegistryKeyValueKind = Microsoft.Win32.RegistryValueKind.MultiString Then
                                _RegistryKeyValueObject = _RegistryKey.GetValue(_SubKey, Nothing)
                                If _RegistryKeyValueObject IsNot Nothing Then
                                    _RegistryKeyValue = DirectCast(_RegistryKey.GetValue(_SubKey), String())
                                End If
                            End If
                            Exit For
                        End If
                    Next
                Else
                    _RegistryKeyValue = Nothing
                End If
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _RegistryKeyValue = Nothing
        End Try

        Return _RegistryKeyValue

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_SubKey"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function GetRegistryKeyExpandStringValue(ByVal _Path As System.String, ByVal _SubKey As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.String

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyValueObject As System.Object = Nothing
        Dim _RegistryKeyValueKind As Microsoft.Win32.RegistryValueKind = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueName As System.String = String.Empty
        Dim _RegistryKeyValue As System.String = Nothing

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                For Each _RegistryKeyValueName In _RegistryKeyValueNames
                    If _RegistryKeyValueName = _SubKey Then
                        _RegistryKeyValueKind = _RegistryKey.GetValueKind(_SubKey)
                        If _RegistryKeyValueKind = Microsoft.Win32.RegistryValueKind.ExpandString Then
                            _RegistryKeyValueObject = _RegistryKey.GetValue(_SubKey, Nothing)
                            If _RegistryKeyValueObject IsNot Nothing Then
                                _RegistryKeyValue = _RegistryKey.GetValue(_SubKey).ToString
                            End If
                        End If
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _RegistryKeyValue = Nothing
        End Try

        Return _RegistryKeyValue

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_SubKey"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function GetRegistryKeyBinaryValue(ByVal _Path As System.String, ByVal _SubKey As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Byte()

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyValueObject As System.Object = Nothing
        Dim _RegistryKeyValueKind As Microsoft.Win32.RegistryValueKind = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueName As System.String = String.Empty
        Dim _RegistryKeyValue As System.Byte() = Nothing

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                For Each _RegistryKeyValueName In _RegistryKeyValueNames
                    If _RegistryKeyValueName = _SubKey Then
                        _RegistryKeyValueKind = _RegistryKey.GetValueKind(_SubKey)
                        If _RegistryKeyValueKind = Microsoft.Win32.RegistryValueKind.Binary Then
                            _RegistryKeyValueObject = _RegistryKey.GetValue(_SubKey, Nothing)
                            If _RegistryKeyValueObject IsNot Nothing Then
                                _RegistryKeyValue = DirectCast(_RegistryKey.GetValue(_SubKey), Byte())
                            End If
                        End If
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _RegistryKeyValue = Nothing
        End Try

        Return _RegistryKeyValue

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_SubKey"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function GetRegistryKeyDWordValue(ByVal _Path As System.String, ByVal _SubKey As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Int32

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyValueObject As System.Object = Nothing
        Dim _RegistryKeyValueKind As Microsoft.Win32.RegistryValueKind = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueName As System.String = String.Empty
        Dim _RegistryKeyValue As System.Int32 = Nothing

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                For Each _RegistryKeyValueName In _RegistryKeyValueNames
                    If _RegistryKeyValueName = _SubKey Then
                        _RegistryKeyValueKind = _RegistryKey.GetValueKind(_SubKey)
                        If _RegistryKeyValueKind = Microsoft.Win32.RegistryValueKind.DWord Then
                            _RegistryKeyValueObject = _RegistryKey.GetValue(_SubKey, Nothing)
                            If _RegistryKeyValueObject IsNot Nothing Then
                                _RegistryKeyValue = System.Convert.ToInt32(_RegistryKey.GetValue(_SubKey))
                            End If
                        End If
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _RegistryKeyValue = Nothing
        End Try

        Return _RegistryKeyValue

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_SubKey"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function GetRegistryKeyQWordValue(ByVal _Path As String, ByVal _SubKey As String, Optional ByVal _IsLocalMachine As Boolean = False) As System.Int64

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyValueObject As System.Object = Nothing
        Dim _RegistryKeyValueKind As Microsoft.Win32.RegistryValueKind = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueName As System.String = String.Empty
        Dim _RegistryKeyValue As System.Int64 = Nothing

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                For Each _RegistryKeyValueName In _RegistryKeyValueNames
                    If _RegistryKeyValueName = _SubKey Then
                        _RegistryKeyValueKind = _RegistryKey.GetValueKind(_SubKey)
                        If _RegistryKeyValueKind = Microsoft.Win32.RegistryValueKind.QWord Then
                            _RegistryKeyValueObject = _RegistryKey.GetValue(_SubKey, Nothing)
                            If _RegistryKeyValueObject IsNot Nothing Then
                                _RegistryKeyValue = Convert.ToInt64(_RegistryKey.GetValue(_SubKey))
                            End If
                        End If
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _RegistryKeyValue = Nothing
        End Try

        Return _RegistryKeyValue

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_SubKey"></param>
    ''' <param name="_Value"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function SetRegistryKeyStringValue(ByVal _Path As System.String, ByVal _SubKey As System.String, ByVal _Value As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Boolean

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyExists As System.Boolean = False
        Dim _RegistryKeyValueKind As Microsoft.Win32.RegistryValueKind = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueName As System.String = String.Empty
        Dim _Success As System.Boolean = False

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine, True)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                If _RegistryKeyValueNames.Count > 0 Then
                    For Each _RegistryKeyValueName In _RegistryKeyValueNames
                        If _RegistryKeyValueName = _SubKey Then
                            _RegistryKeyExists = True
                            _RegistryKeyValueKind = _RegistryKey.GetValueKind(_SubKey)
                            If _RegistryKeyValueKind = Microsoft.Win32.RegistryValueKind.String Then
                                _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                            End If
                        End If
                    Next
                Else
                    _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                End If
                If _RegistryKeyExists = False Then _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                If GetRegistryKeyStringValue(_Path, _SubKey, _IsLocalMachine) = _Value Then _Success = True
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Success = False
        End Try

        Return _Success

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_SubKey"></param>
    ''' <param name="_Value"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function SetRegistryKeyMultiStringValue(ByVal _Path As System.String, ByVal _SubKey As System.String, ByVal _Value() As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Boolean

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyExists As System.Boolean = False
        Dim _RegistryKeyValueKind As Microsoft.Win32.RegistryValueKind = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueName As System.String = String.Empty
        Dim _Success As System.Boolean = False

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine, True)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                If _RegistryKeyValueNames.Count > 0 Then
                    For Each _RegistryKeyValueName In _RegistryKeyValueNames
                        If _RegistryKeyValueName = _SubKey Then
                            _RegistryKeyExists = True
                            _RegistryKeyValueKind = _RegistryKey.GetValueKind(_SubKey)
                            If _RegistryKeyValueKind = Microsoft.Win32.RegistryValueKind.MultiString Then
                                _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.MultiString)
                            End If
                        End If
                    Next
                Else
                    _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                End If
                If _RegistryKeyExists = False Then _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                If _Value.SequenceEqual(GetRegistryKeyMultiStringValue(_Path, _SubKey, _IsLocalMachine)) = True Then _Success = True
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Success = False
        End Try

        Return _Success

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_SubKey"></param>
    ''' <param name="_Value"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function SetRegistryKeyExpandStringValue(ByVal _Path As System.String, ByVal _SubKey As System.String, ByVal _Value As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Boolean

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyExists As System.Boolean = False
        Dim _RegistryKeyValueKind As Microsoft.Win32.RegistryValueKind = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueName As System.String = String.Empty
        Dim _Success As System.Boolean = False

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine, True)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                If _RegistryKeyValueNames.Count > 0 Then
                    For Each _RegistryKeyValueName In _RegistryKeyValueNames
                        If _RegistryKeyValueName = _SubKey Then
                            _RegistryKeyExists = True
                            _RegistryKeyValueKind = _RegistryKey.GetValueKind(_SubKey)
                            If _RegistryKeyValueKind = Microsoft.Win32.RegistryValueKind.String Then
                                _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.ExpandString)
                            End If
                        End If
                    Next
                Else
                    _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                End If
                If _RegistryKeyExists = False Then _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                If GetRegistryKeyExpandStringValue(_Path, _SubKey, _IsLocalMachine) = _Value Then _Success = True
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Success = False
        End Try

        Return _Success

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_SubKey"></param>
    ''' <param name="_Value"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function SetRegistryKeyBinaryValue(ByVal _Path As System.String, ByVal _SubKey As System.String, ByVal _Value As System.Byte(), Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Boolean

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyExists As System.Boolean = False
        Dim _RegistryKeyValueKind As Microsoft.Win32.RegistryValueKind = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueName As System.String = String.Empty
        Dim _Success As System.Boolean = False

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine, True)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                If _RegistryKeyValueNames.Count > 0 Then
                    For Each _RegistryKeyValueName In _RegistryKeyValueNames
                        If _RegistryKeyValueName = _SubKey Then
                            _RegistryKeyExists = True
                            _RegistryKeyValueKind = _RegistryKey.GetValueKind(_SubKey)
                            If _RegistryKeyValueKind = Microsoft.Win32.RegistryValueKind.Binary Then
                                _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.Binary)
                            End If
                        End If
                    Next
                Else
                    _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                End If
                If _RegistryKeyExists = False Then _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                If _Value.SequenceEqual(GetRegistryKeyBinaryValue(_Path, _SubKey, _IsLocalMachine)) = True Then _Success = True
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Success = False
        End Try

        Return _Success

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_SubKey"></param>
    ''' <param name="_Value"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function SetRegistryKeyDWordValue(ByVal _Path As System.String, ByVal _SubKey As System.String, ByVal _Value As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Boolean

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyExists As System.Boolean = False
        Dim _RegistryKeyValueKind As Microsoft.Win32.RegistryValueKind = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueName As System.String = String.Empty
        Dim _Success As System.Boolean = False

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine, True)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                If _RegistryKeyValueNames.Count > 0 Then
                    For Each _RegistryKeyValueName In _RegistryKeyValueNames
                        If _RegistryKeyValueName = _SubKey Then
                            _RegistryKeyExists = True
                            _RegistryKeyValueKind = _RegistryKey.GetValueKind(_SubKey)
                            If _RegistryKeyValueKind = Microsoft.Win32.RegistryValueKind.DWord Then
                                _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.DWord)
                            End If
                        End If
                    Next
                Else
                    _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                End If
                If _RegistryKeyExists = False Then _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                If GetRegistryKeyDWordValue(_Path, _SubKey, _IsLocalMachine) = _Value Then _Success = True
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Success = False
        End Try

        Return _Success

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_SubKey"></param>
    ''' <param name="_Value"></param>
    ''' <param name="_IsLocalMachine"></param>
    ''' <returns></returns>
    Public Function SetRegistryKeyQWordValue(ByVal _Path As System.String, ByVal _SubKey As System.String, ByVal _Value As System.String, Optional ByVal _IsLocalMachine As System.Boolean = False) As System.Boolean

        Dim _RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim _RegistryKeyExists As System.Boolean = False
        Dim _RegistryKeyValueKind As Microsoft.Win32.RegistryValueKind = Nothing
        Dim _RegistryKeyValueNames As System.String() = Nothing
        Dim _RegistryKeyValueName As System.String = String.Empty
        Dim _Success As System.Boolean = False

        Try
            _RegistryKey = GetRegistryKey(_Path, _IsLocalMachine, True)
            If _RegistryKey IsNot Nothing Then
                _RegistryKeyValueNames = _RegistryKey.GetValueNames()
                If _RegistryKeyValueNames.Count > 0 Then
                    For Each _RegistryKeyValueName In _RegistryKeyValueNames
                        If _RegistryKeyValueName = _SubKey Then
                            _RegistryKeyExists = True
                            _RegistryKeyValueKind = _RegistryKey.GetValueKind(_SubKey)
                            If _RegistryKeyValueKind = Microsoft.Win32.RegistryValueKind.QWord Then
                                _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.QWord)
                            End If
                        End If
                    Next
                Else
                    _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                End If
                If _RegistryKeyExists = False Then _RegistryKey.SetValue(_SubKey, _Value, Microsoft.Win32.RegistryValueKind.String)
                If GetRegistryKeyQWordValue(_Path, _SubKey, _IsLocalMachine) = _Value Then _Success = True
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Success = False
        End Try

        Return _Success

    End Function

#End Region

#Enable Warning BC42312

End Module
