Module ModuleFilesFolders

#Disable Warning BC42312

#Region " Procedures and Functions for Files and Folders "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_FolderPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateFolder(ByVal _FolderPath As System.String) As System.Boolean

        Dim _FolderExists As System.Boolean = False

        Try
            If Not System.IO.Directory.Exists(_FolderPath) Then
                System.IO.Directory.CreateDirectory(_FolderPath)
                If System.IO.Directory.Exists(_FolderPath) Then
                    _FolderExists = True
                Else
                    _FolderExists = False
                End If
            Else
                _FolderExists = True
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _FolderExists = False
        End Try

        Return _FolderExists

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_DrivePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConvertToUNCPath(ByVal _DrivePath As System.String) As System.String

        Dim _ConnectionOptions As System.Management.ConnectionOptions = Nothing
        Dim _ManagementScope As System.Management.ManagementScope = Nothing
        Dim _ManagementObjectSearcher As System.Management.ManagementObjectSearcher = Nothing
        Dim _ManagementObjectCollection As System.Management.ManagementObjectCollection = Nothing
        Dim _ManagementObject As System.Management.ManagementObject = Nothing

        Dim _SplitPath() As System.String = Strings.Split(_DrivePath, "\")
        Dim _ProviderName As String = System.String.Empty
        Dim _UNCPath As System.String = System.String.Empty

        Try
            _ConnectionOptions = New System.Management.ConnectionOptions
            With _ConnectionOptions
                .Impersonation = System.Management.ImpersonationLevel.Impersonate
                .Authentication = System.Management.AuthenticationLevel.Packet
            End With
            _ManagementScope = New System.Management.ManagementScope("\\.\root\cimv2", _ConnectionOptions)
            _ManagementScope.Connect()
            If _ManagementScope.IsConnected = False Then
                _UNCPath = _DrivePath
                Exit Try
            End If
            _ManagementObjectSearcher = New System.Management.ManagementObjectSearcher(System.String.Format("SELECT * FROM Win32_LogicalDisk WHERE DriveType=4 AND DeviceID='{0}'", _SplitPath(0)))
            _ManagementObjectCollection = _ManagementObjectSearcher.Get
            If _ManagementObjectCollection.Count > 0 Then
                For Each _ManagementObject In _ManagementObjectCollection
                    _ProviderName = _ManagementObject.GetPropertyValue("ProviderName").ToString
                Next
                If _ProviderName.Substring(2, 9).ToLower = "localhost" Then
                    _UNCPath = _DrivePath
                    Exit Try
                Else
                    _UNCPath = String.Format("{0}", _ProviderName)
                    For i = 1 To _SplitPath.GetUpperBound(0) Step 1
                        _UNCPath = String.Format("{0}\{1}", _UNCPath, _SplitPath(i))
                    Next
                    Exit Try
                End If
            Else
                _UNCPath = _DrivePath
                Exit Try
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _UNCPath = Nothing
        End Try

        Return _UNCPath

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateMD5StringFromFile(ByVal _Filename As System.String) As System.String

        Dim _MD5 As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create
        Dim _ByteHash As System.Byte()
        Dim _StringBuilder As System.Text.StringBuilder = New StringBuilder()

        Try
            Using _FileStream As New System.IO.FileStream(_Filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read)
                _ByteHash = _MD5.ComputeHash(_FileStream)
            End Using
            If _ByteHash.Length > 0 Then
                For Each _Byte As System.Byte In _ByteHash
                    _StringBuilder.Append(_Byte.ToString("X2"))
                Next
            Else
                _StringBuilder.Clear()
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _StringBuilder.ToString.ToLower()

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_FileName"></param>
    ''' <returns></returns>
    Public Function DeleteFile(ByVal _FileName As System.String) As System.Boolean

        Dim _FileExists As System.Boolean = False

        Try
            If Not System.IO.File.Exists(_FileName) Then
                _FileExists = True
            Else
                System.IO.File.Delete(_FileName)
                If Not System.IO.File.Exists(_FileName) Then
                    _FileExists = True
                Else
                    _FileExists = False
                End If
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _FileExists = False
        End Try

        Return _FileExists

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Path"></param>
    ''' <param name="_Keep"></param>
    ''' <param name="_Pattern"></param>
    Public Sub DeleteOldestFiles(ByVal _Path As System.String, ByVal _Keep As System.Int32, Optional _Pattern As System.String = "*.*")

        Dim _Folder As System.IO.DirectoryInfo = Nothing
        Dim _Files As System.Linq.IOrderedEnumerable(Of System.IO.FileInfo)
        Dim _File As System.Object = Nothing

        Try
            _Folder = New System.IO.DirectoryInfo(_Path)
            _Files = _Folder.GetFiles(_Pattern).OrderByDescending(Function(fi) fi.CreationTime)
            For Each _File In _Files.Skip(_Keep)
                _File.Delete()
            Next
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try
    End Sub

#End Region

#Enable Warning BC42312

End Module
