Module ModuleNumbers

#Disable Warning BC42312

#Region " Procedures and Functions for Numbers "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Birthdate"></param>
    ''' <param name="_AsOf">OPTIONAL: Date and time either in the past or in the future.</param>
    ''' <returns></returns>
    Public Function GetAge(ByVal _Birthdate As System.DateTime, Optional ByVal _AsOf As System.DateTime = #1/1/1700#) As System.Int32

        Dim _Months As System.Int32 = 0
        Dim _Years As System.Int32 = 0
        Dim _DayOfBirth As System.Int64 = 0
        Dim _AsOfDay As System.Int64 = 0
        Dim _BirthMonth As System.Int32 = 0
        Dim _AsOfMonth As System.Int32 = 0

        Try
            If _AsOf = "#1/1/1700#" Then _AsOf = DateTime.Now
            _DayOfBirth = DatePart(Microsoft.VisualBasic.DateInterval.Day, _Birthdate)
            _AsOfDay = DatePart(Microsoft.VisualBasic.DateInterval.Day, _AsOf)
            _BirthMonth = DatePart(Microsoft.VisualBasic.DateInterval.Month, _Birthdate)
            _AsOfMonth = DatePart(Microsoft.VisualBasic.DateInterval.Month, _AsOf)
            _Months = DateDiff(Microsoft.VisualBasic.DateInterval.Month, _Birthdate, _AsOf)
            _Years = Math.Floor(_Months / 12)
            If _BirthMonth = _AsOfMonth Then
                If _AsOfDay < _DayOfBirth Then
                    _Years = _Years - 1
                End If
            End If
        Catch ex As Exception
            _Years = 0
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _Years

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Minimum"></param>
    ''' <param name="_Maximum"></param>
    ''' <returns></returns>
    ''' <remarks>By making Generator static, we preserve the same instance (i.e., do not create new instances with the same seed over and over)between calls.</remarks>
    Public Function GetRandomNumber(ByVal _Minimum As System.Int64, ByVal _Maximum As System.Int64) As System.Int64

        Static _Generator As System.Random = New System.Random()
        Return System.Convert.ToInt64(_Generator.Next(_Minimum, _Maximum))

    End Function

#End Region

#Enable Warning BC42312

End Module
