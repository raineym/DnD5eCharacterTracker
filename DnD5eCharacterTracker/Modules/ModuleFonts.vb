Module ModuleFonts

#Disable Warning BC42312

#Region " Procedures and Functions For Fonts "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_FontName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsFontInstalled(ByVal _FontName As System.String) As System.Boolean

        Using TestFont As System.Drawing.Font = New System.Drawing.Font(_FontName, 10)
            Return Convert.ToBoolean(System.String.Compare(_FontName, TestFont.Name, System.StringComparison.InvariantCultureIgnoreCase) = 0)
        End Using

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_FontName"></param>
    ''' <param name="_DefaultFontName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetFontFamily(ByVal _FontName As String, Optional ByVal _DefaultFontName As String = "Microsoft Sans Serif") As System.Drawing.FontFamily

        Dim _FamilyFont As System.Drawing.FontFamily = Nothing

        Try
            For Each _Family As System.Drawing.FontFamily In System.Drawing.FontFamily.Families
                If IsFontInstalled(_Family.Name) = True Then
                    _FamilyFont = New System.Drawing.FontFamily(_FontName)
                    Exit For
                End If
            Next
            If _FamilyFont Is Nothing Then
                _FamilyFont = New System.Drawing.FontFamily(_DefaultFontName)
            End If
        Catch ex As Exception
            _FamilyFont = New System.Drawing.FontFamily(_DefaultFontName)
        End Try

        Return _FamilyFont

    End Function

#End Region

#Enable Warning BC42312

End Module
