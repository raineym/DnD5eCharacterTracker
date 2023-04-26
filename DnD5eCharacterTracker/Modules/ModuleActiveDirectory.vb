Module ModuleActiveDirectory

#Disable Warning BC42312

#Region " Procedures and Functions for Microsoft Active Directory "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_UserName"></param>
    ''' <param name="_LDAP"></param>
    ''' <param name="_Properties"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ADUserDetailsByUserName(ByVal _UserName As String, ByVal _LDAP As String, ByVal _Properties As List(Of String)) As DirectoryEntry

        Dim _DirectoryEntry As System.DirectoryServices.DirectoryEntry = Nothing
        Dim _ReturnedDirectoryEntry As System.DirectoryServices.DirectoryEntry = Nothing
        Dim _DirectorySearcher As System.DirectoryServices.DirectorySearcher = Nothing
        Dim _SearchResult As System.DirectoryServices.SearchResult = Nothing

        Try
            If Not String.IsNullOrEmpty(_UserName) Then
                _DirectoryEntry = New System.DirectoryServices.DirectoryEntry(_LDAP)
                _DirectorySearcher = New System.DirectoryServices.DirectorySearcher(_DirectoryEntry)
                With _DirectorySearcher
                    .Filter = String.Format("(&(objectClass=user)(samAccountName={0}))", UserName)
                    For Each Prop As String In _Properties
                        .PropertiesToLoad.Add(Prop)
                    Next
                End With
                _SearchResult = _DirectorySearcher.FindOne()
                If _SearchResult IsNot Nothing Then '[ return empty string if user isn't found. ]
                    _ReturnedDirectoryEntry = _SearchResult.GetDirectoryEntry()
                Else
                    _ReturnedDirectoryEntry = Nothing
                End If
            Else
                _ReturnedDirectoryEntry = Nothing
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _ReturnedDirectoryEntry = Nothing
        End Try

        Return _ReturnedDirectoryEntry

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_FirstName"></param>
    ''' <param name="_LastName"></param>
    ''' <param name="_LDAP"></param>
    ''' <param name="_Properties"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ADUserDetailsByGivenName(ByVal _FirstName As String, ByVal _LastName As String, ByVal _LDAP As String, ByVal _Properties As List(Of String)) As DirectoryEntry

        Dim _DirectoryEntry As System.DirectoryServices.DirectoryEntry = Nothing
        Dim _ReturnedDirectoryEntry As System.DirectoryServices.DirectoryEntry = Nothing
        Dim _DirectorySearcher As System.DirectoryServices.DirectorySearcher = Nothing
        Dim _SearchResult As System.DirectoryServices.SearchResult = Nothing

        Try
            If (Not String.IsNullOrEmpty(_FirstName)) AndAlso (Not String.IsNullOrEmpty(_LastName)) Then
                _DirectoryEntry = New DirectoryEntry(_LDAP)
                _DirectorySearcher = New System.DirectoryServices.DirectorySearcher(_DirectoryEntry)
                With _DirectorySearcher
                    .Filter = String.Format("(&(objectClass=user)(givenName={0})(sn={1}))", _FirstName, _LastName)
                    For Each Prop As String In _Properties
                        .PropertiesToLoad.Add(Prop)
                    Next
                End With
                _SearchResult = _DirectorySearcher.FindOne()
                If _SearchResult IsNot Nothing Then '[ return empty string if user isn't found. ]
                    _ReturnedDirectoryEntry = _SearchResult.GetDirectoryEntry()
                Else
                    _ReturnedDirectoryEntry = Nothing
                End If
            Else
                _ReturnedDirectoryEntry = Nothing
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _ReturnedDirectoryEntry = Nothing
        End Try

        Return _ReturnedDirectoryEntry

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_GroupName"></param>
    ''' <param name="_UserName"></param>
    ''' <param name="_LDAP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ADUserGroupMemberByUserName(ByVal _GroupName As String, ByVal _UserName As String, ByVal _LDAP As String) As Boolean

        Dim _DirectoryEntry As System.DirectoryServices.DirectoryEntry = Nothing
        Dim _DirectorySearcher As System.DirectoryServices.DirectorySearcher = Nothing
        Dim _SearchResult As System.DirectoryServices.SearchResult = Nothing
        Dim _IsInGroup As Boolean = False

        Try
            If Not String.IsNullOrEmpty(UserName) Then
                _DirectoryEntry = New DirectoryEntry(_LDAP)
                _DirectorySearcher = New System.DirectoryServices.DirectorySearcher(_DirectoryEntry)
                With _DirectorySearcher
                    .Filter = String.Format("(&(ObjectClass=Group)(CN={0}))", _GroupName)
                    .PropertiesToLoad.Add("Member")
                End With
                _SearchResult = _DirectorySearcher.FindOne()
                If _SearchResult IsNot Nothing Then
                    For Each User In _SearchResult.Properties("Member")
                        _IsInGroup = User.Equals(_UserName)
                    Next
                Else
                    _IsInGroup = False
                End If
            Else
                _IsInGroup = False
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _IsInGroup = False
        End Try

        Return _IsInGroup

    End Function

#End Region

#Enable Warning BC42312

End Module
