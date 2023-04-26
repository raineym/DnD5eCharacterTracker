Module ModuleStrings

#Disable Warning BC42312

#Region " Procedure and Functions for Strings "

    ''' <summary>
    ''' Generates a tiny, secure, URL-friendly, unique string ID.
    ''' </summary>
    ''' <returns>21 character URL-friendly, unique string.</returns>
    ''' <remarks>It uses more symbols than UUID (A-Za-z0-9_-) and has the same number of unique options in just 21 symbols instead of 36.</remarks>
    'Public Function GenerateNanoID() As System.String

    '    Dim _String As System.String = System.String.Empty

    '    Try
    '        _String = Nanoid.Nanoid.Generate()
    '    Catch ex As Exception
    '        ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
    '        _String = System.String.Empty
    '    End Try

    '    Return _String

    'End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_ToLower"></param>
    ''' <returns></returns>
    Public Function GenerateUUID(Optional ByVal _ToLower As System.Boolean = True) As System.String

        Dim _String As System.String = System.String.Empty

        Try
            _String = If(_ToLower = False, System.Guid.NewGuid.ToString, System.Guid.NewGuid.ToString.ToLower)
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _String = System.String.Empty
        End Try

        Return _String

    End Function

    ''' <summary>
    ''' Generates a random string of characters specified by length.
    ''' </summary>
    ''' <param name="_Length">Length of string to generate</param>
    ''' <returns>Random string of characters</returns>
    ''' <remarks></remarks>
    Public Function GenerateRandomString(Optional ByVal _Length As System.Int32 = 8) As System.String

        Dim _AllowedCharacters() As System.Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_".ToCharArray()
        Dim _StringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim _String As System.String = System.String.Empty
        Dim _i As System.Int32 = 0

        Try
            For _i = 1 To _Length
                _StringBuilder.Append(_AllowedCharacters(GetRandomNumber(0, _AllowedCharacters.GetUpperBound(0))))
            Next
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            If _StringBuilder.Length > 0 Then _String = _StringBuilder.ToString()
        End Try

        Return _String

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_String"></param>
    ''' <param name="_Type"></param>
    ''' <returns></returns>
    Public Function HashString(ByVal _String As System.String, Optional ByVal _Type As System.Int32 = 1) As System.String

        Dim _Encoding As System.Text.UnicodeEncoding = New System.Text.UnicodeEncoding()
        Dim _MD5Hash As System.Security.Cryptography.MD5CryptoServiceProvider
        Dim _SHA1Hash As System.Security.Cryptography.SHA1Managed
        Dim _SHA256Hash As System.Security.Cryptography.SHA256Managed
        Dim _SHA384Hash As System.Security.Cryptography.SHA384Managed
        Dim _SHA512Hash As System.Security.Cryptography.SHA512Managed
        Dim _ByteStringToHash() As System.Byte = Nothing
        Dim _ByteHash() As System.Byte
        Dim _Byte As System.Byte = Nothing
        Dim _HashedString As System.String = System.String.Empty

        If Not String.IsNullOrEmpty(_String) Then
            Try
                _ByteStringToHash = _Encoding.GetBytes(_String)
                Select Case _Type
                    Case 1 '[ MD5 ]
                        _MD5Hash = New System.Security.Cryptography.MD5CryptoServiceProvider
                        _ByteHash = _MD5Hash.ComputeHash(_ByteStringToHash)
                    Case 2 '[ SHA1 ]
                        _SHA1Hash = New System.Security.Cryptography.SHA1Managed()
                        _ByteHash = _SHA1Hash.ComputeHash(_ByteStringToHash)
                    Case 3 '[ SHA256 ]
                        _SHA256Hash = New System.Security.Cryptography.SHA256Managed()
                        _ByteHash = _SHA256Hash.ComputeHash(_ByteStringToHash)
                    Case 4 '[ SHA384 ]
                        _SHA384Hash = New System.Security.Cryptography.SHA384Managed()
                        _ByteHash = _SHA384Hash.ComputeHash(_ByteStringToHash)
                    Case 5 '[ SHA512 ]
                        _SHA512Hash = New System.Security.Cryptography.SHA512Managed()
                        _ByteHash = _SHA512Hash.ComputeHash(_ByteStringToHash)
                    Case Else '[ MD5 ]
                        _MD5Hash = New System.Security.Cryptography.MD5CryptoServiceProvider
                        _ByteHash = _MD5Hash.ComputeHash(_ByteStringToHash)
                End Select
                For Each _Byte In _ByteHash
                    _HashedString += _Byte.ToString("x2")
                Next
            Catch ex As Exception
                ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
                _HashedString = System.String.Empty
            End Try
        Else
            _HashedString = System.String.Empty
        End If

        Return _HashedString

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_String"></param>
    ''' <param name="_Salt"></param>
    ''' <param name="_IsEncryption"></param>
    ''' <returns></returns>
    Public Function EncryptDecryptString(ByVal _String As System.String, ByVal _Salt As System.String, Optional ByVal _IsEncryption As System.Boolean = True) As System.String

        Dim _SaltData() As System.Char = _Salt.ToString.ToCharArray()
        Dim _SaltDataLength As System.Int64 = _SaltData.GetUpperBound(0)
        Dim _DataToHash(_SaltDataLength) As System.Byte
        Dim _Result As System.Byte() = Nothing
        Dim _Key(31) As System.Byte
        Dim _IV(15) As System.Byte
        Dim _EncryptedString As System.Byte() = Nothing
        Dim _UTF8Encoding As System.Text.UTF8Encoding = New System.Text.UTF8Encoding
        Dim _DeEncryptor As System.Security.Cryptography.ICryptoTransform = Nothing
        Dim _MemoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
        Dim _CryptoStream As System.Security.Cryptography.CryptoStream = Nothing
        Dim _i As System.Int32 = 0
        Dim _DeEncryptedString As System.String = Nothing

        Try
            For i = 0 To _SaltDataLength
                _DataToHash(i) = CByte(Asc(_SaltData(i)))
            Next

            Using SHA512 As New System.Security.Cryptography.SHA512Managed
                _Result = SHA512.ComputeHash(_DataToHash)
                For _i = 0 To 31
                    _Key(_i) = _Result(_i)
                Next
                For _i = 32 To 47
                    _IV(_i - 32) = _Result(_i)
                Next
            End Using

            Using _RijndaelManagedKey As New RijndaelManaged()
                _RijndaelManagedKey.Mode = System.Security.Cryptography.CipherMode.CBC
                If _IsEncryption = True Then
                    _DeEncryptor = _RijndaelManagedKey.CreateEncryptor(_Key, _IV)
                    _CryptoStream = New System.Security.Cryptography.CryptoStream(_MemoryStream, _DeEncryptor, System.Security.Cryptography.CryptoStreamMode.Write)
                    With _CryptoStream
                        .Write(_UTF8Encoding.GetBytes(_String), 0, _String.Length)
                        .FlushFinalBlock()
                    End With
                    _DeEncryptedString = Convert.ToBase64String(_MemoryStream.ToArray())
                Else
                    _EncryptedString = Convert.FromBase64String(_String)
                    _DeEncryptor = _RijndaelManagedKey.CreateDecryptor(_Key, _IV)
                    _CryptoStream = New System.Security.Cryptography.CryptoStream(_MemoryStream, _DeEncryptor, System.Security.Cryptography.CryptoStreamMode.Write)
                    With _CryptoStream
                        .Write(_EncryptedString, 0, _EncryptedString.Length)
                        .FlushFinalBlock()
                    End With
                    _DeEncryptedString = System.Text.Encoding.UTF8.GetString(_MemoryStream.ToArray)
                End If
            End Using
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _DeEncryptedString = _String
        Finally
            If _MemoryStream IsNot Nothing Then _MemoryStream.Close()
            If _CryptoStream IsNot Nothing Then _CryptoStream.Close()
        End Try

        Return _DeEncryptedString

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_String"></param>
    ''' <param name="_Delimiter"></param>
    ''' <param name="_Limit"></param>
    ''' <returns></returns>
    Public Function Explode(ByVal _String As System.String, ByVal _Delimiter As System.String, Optional ByVal _Limit As System.Int32 = -1) As System.String()

        Dim _StringExploded() As System.String = Nothing

        Try
            _StringExploded = Split(_String, _Delimiter, _Limit, Microsoft.VisualBasic.CompareMethod.Binary)
        Catch ex As Exception
            _StringExploded = Nothing
        End Try

        Return _StringExploded

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Strings"></param>
    ''' <param name="_Delimiter"></param>
    ''' <returns></returns>
    Public Function Implode(ByVal _Strings() As System.String, Optional ByVal _Delimiter As System.String = " ") As System.String

        Dim _StringImploded As System.String = String.Empty

        Try
            _StringImploded = String.Join(_Delimiter, _Strings)
        Catch ex As Exception
            _StringImploded = String.Empty
        End Try

        Return _StringImploded

    End Function






    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_String"></param>
    ''' <returns></returns>
    Public Function JumbleString(ByVal _String As System.String) As System.String

        Static _Random As New System.Random()
        Dim _StringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _Characters As New System.Collections.Generic.List(Of System.Char)(_String.ToLower.ToCharArray)
        Dim _i As System.Int64

        Try
            While _Characters.Count > 0
                _i = GetRandomNumber(0, _Characters.Count - 1)
                _StringBuilder.Append(_Characters(_i))
                _Characters.RemoveAt(_i)
            End While
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _StringBuilder.ToString()

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Number"></param>
    ''' <returns></returns>
    Public Function GetOrdinal(ByVal _Number As System.Int32) As System.String

        Dim _Ordinal As System.String = Nothing

        Try
            If _Number > 0 Then
                Select Case (_Number Mod 100)
                    Case 11 To 14
                        _Ordinal = System.String.Format("{0}th", _Number.ToString)
                        Exit Select
                    Case Else
                        _Ordinal = System.String.Empty
                End Select
                Select Case (_Number Mod 10)
                    Case 1
                        _Ordinal = System.String.Format("{0}st", _Number.ToString)
                        Exit Select
                    Case 2
                        _Ordinal = System.String.Format("{0}nd", _Number.ToString)
                        Exit Select
                    Case 3
                        _Ordinal = System.String.Format("{0}rd", _Number.ToString)
                        Exit Select
                    Case Else
                        _Ordinal = System.String.Format("{0}th", _Number.ToString)
                        Exit Select
                End Select
            Else
                _Ordinal = System.String.Format("{0}", _Number.ToString)
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _Ordinal

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Value"></param>
    ''' <returns></returns>
    Public Function ReformatTeraGigaMegaBytes(ByVal _Value As System.Int64) As System.String

        Dim _String As System.String = Nothing

        Try
            If Strings.Len(_Value.ToString) > 12 Then ' Reformat if TB
                _String = Strings.Format(_Value / 1024 / 1024 / 1024 / 1024, "##0.00 TB")
            ElseIf Strings.Len(_Value.ToString) > 9 Then ' Reformat if GB
                _String = Strings.Format(_Value / 1024 / 1024 / 1024, "###,##0.00 GB")
            ElseIf Strings.Len(_Value.ToString) > 6 Then  ' Reformat if MB
                _String = Strings.Format(_Value / 1024 / 1024, "###,###,##0.00 MB")
            ElseIf Strings.Len(_Value.ToString) > 3 Then  ' Reformat if KB
                _String = Strings.Format(_Value / 1024, "###,###,###,##0.00 KB")
            Else
                _String = Strings.Format(_Value, "###,###,###,###,##0.00 Bytes")
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _String = _Value.ToString
        End Try

        Return _String

    End Function

#End Region

#Enable Warning BC42312

End Module
