Module ModuleNetworking

#Disable Warning BC42312
#Disable Warning BC42306

#Region " Procedures and Functions For Networking "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Function InternetAvailable() As System.Boolean

        Dim _HttpWebRequest As System.Net.HttpWebRequest = Nothing
        Dim _HttpWebResponse As System.Net.HttpWebResponse = Nothing
        Dim _Internet As System.Boolean = False

        Try
            _HttpWebRequest = DirectCast(System.Net.HttpWebRequest.Create("http://www.google.com"), System.Net.HttpWebRequest)
            With _HttpWebRequest
                _HttpWebResponse = DirectCast(.GetResponse(), System.Net.HttpWebResponse)
                .Abort()
            End With
            If _HttpWebResponse.StatusCode = System.Net.HttpStatusCode.OK Then _Internet = True
        Catch HttpWebError As System.Net.WebException
            _Internet = False
        Catch ex As Exception
            _Internet = False
        End Try

        Return _Internet

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_State"></param>
    ''' <returns>Boolean whether any network connection is available.</returns>
    ''' <remarks></remarks>
    Public Sub NetworkAvailable(ByVal _State As System.Object)

        Try
            _IsNetworkAvailable = System.Convert.ToBoolean(_State.IsAvailable)
        Catch ex As Exception
            _IsNetworkAvailable = False
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_ComputerName"></param>
    ''' <returns></returns>
    Public Function PingComputer(ByVal _ComputerName As System.String) As System.Boolean

        Dim _ConnectionOptions As New System.Management.ConnectionOptions
        Dim _ManagementScope As System.Management.ManagementScope = Nothing
        Dim _ManagementObjectSearcher As System.Management.ManagementObjectSearcher = Nothing
        Dim _ManagementObjectCollection As System.Management.ManagementObjectCollection = Nothing
        Dim _ManagementObject As System.Management.ManagementObject = Nothing
        Dim _IsReachable As System.Boolean = False

        Try
            With _ConnectionOptions
                .Impersonation = System.Management.ImpersonationLevel.Impersonate
                .Authentication = System.Management.AuthenticationLevel.Packet
            End With
            '[ Connect to WMI namespace. ]
            _ManagementScope = New System.Management.ManagementScope("\\.\root\cimv2", _ConnectionOptions)
            _ManagementScope.Connect()
            If _ManagementScope.IsConnected = False Then
                _IsReachable = False
                Exit Try
            End If
            _ManagementObjectSearcher = New System.Management.ManagementObjectSearcher(_ManagementScope.Path.ToString, String.Format("SELECT * FROM Win32_PingStatus WHERE Address = '{0}'", _ComputerName))
            '[ Execute the query. ]
            _ManagementObjectCollection = _ManagementObjectSearcher.Get
            For Each _ManagementObject In _ManagementObjectCollection
                If _ManagementObject.Properties.Item("StatusCode").IsLocal = True Then
                    If IsDBNull(_ManagementObject.GetPropertyValue("StatusCode")) Or Convert.ToInt64(_ManagementObject.GetPropertyValue("StatusCode")) <> 0 Then
                        _IsReachable = False
                    Else
                        _IsReachable = True
                    End If
                Else
                    _IsReachable = False
                End If
            Next
        Catch ex As Exception
            _IsReachable = False
        End Try

        Return _IsReachable

    End Function

#End Region

#Enable Warning BC42306
#Enable Warning BC42312

End Module
