Module ModuleWindowsSecurity

#Disable Warning BC42312

#Region " Procedures and Functions for Windows Security "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetWindowsCurrentUser() As System.String

        Dim _WindowsIdentity As System.Security.Principal.WindowsIdentity
        Dim _UserName As System.String = System.String.Empty

        Try
            _WindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
            If _WindowsIdentity IsNot Nothing Then _UserName = _WindowsIdentity.Name
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _UserName = String.Empty
        End Try

        Return _UserName

    End Function

#End Region

#Enable Warning BC42312

End Module
