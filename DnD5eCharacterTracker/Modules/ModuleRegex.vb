Module ModuleRegex

#Region " Constants "



#End Region

#Region " Variables "



#End Region

#Region " Procedures And Functions For Regular Expressions "

    ''' <summary>
    ''' Determines whether provided email address is properly formatted.
    ''' </summary>
    ''' <param name="_Email"></param>
    ''' <returns></returns>
    Public Function IsValidEmailFormat(ByVal _Email As System.String) As System.Boolean

        Dim _Result As System.Boolean = False
        Dim _Pattern As String = "^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.(([0-9]{1,3})|([a-zA-Z]{2,3})|(aero|coop|info|museum|name))$"
        Dim _Match As System.Text.RegularExpressions.Match = Nothing

        Try
            If Not String.IsNullOrEmpty(_Email) Then
                _Match = System.Text.RegularExpressions.Regex.Match(_Email, _Pattern)
                _Result = _Match.Success
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Result = False
        End Try

        Return _Result

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_String"></param>
    ''' <param name="_Expression"></param>
    ''' <returns></returns>
    Public Function RegexParseString(ByVal _String As System.String, ByVal _Expression As System.String) As System.Collections.ArrayList

        Dim _Regex As System.Text.RegularExpressions.Regex = Nothing
        Dim _Match As System.Text.RegularExpressions.Match = Nothing
        Dim _ArrayList As System.Collections.ArrayList = Nothing
        Dim _i As System.Int32 = 0

        Try
            _Regex = New System.Text.RegularExpressions.Regex(_Expression, System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Singleline)
            _Match = _Regex.Match(_String)
            If (_Match.Success) Then
                _ArrayList = New System.Collections.ArrayList
                '[ Skips 0 because _Regex.Match(0) is original string. ]
                For _i = 1 To _Match.Groups.Count - 1
                    _ArrayList.Add(_Match.Groups(_i).ToString)
                Next
            End If
        Catch ex As Exception
            _ArrayList = Nothing
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _ArrayList

    End Function

#End Region

#Region " Structures "



#End Region

End Module
