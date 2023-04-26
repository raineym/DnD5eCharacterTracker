Module ModuleDateTime

#Disable Warning BC42312

#Region " Procedures and Functions for Date and Time "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_UnixTimestamp"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDateTimeFromTimestamp(ByVal _UnixTimestamp As System.String) As System.DateTime

        Dim _DateTime As System.DateTime

        Try
            If _UnixTimestamp Is Nothing Or String.IsNullOrEmpty(_UnixTimestamp) Then
                _DateTime = New System.DateTime(1970, 1, 1, 0, 0, 0, 0)
            Else
                _DateTime = New System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(System.Convert.ToInt64(_UnixTimestamp))
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _DateTime = Nothing
        End Try

        Return _DateTime

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Function GetJulianDate() As System.String

        Dim _JulianDate As System.String = System.String.Empty
        Dim _JulianCalendar As System.Globalization.JulianCalendar = New System.Globalization.JulianCalendar

        Try
            _JulianDate = _JulianCalendar.GetDayOfYear(DateTime.Now).ToString()
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _JulianDate = System.String.Empty
        End Try

        Return _JulianDate

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_TimeDate"></param>
    ''' <returns></returns>
    Public Function GetTimestampFromDateTime(ByVal _TimeDate As System.DateTime) As String

        Dim _Timestamp As String = String.Empty

        Try
            If _TimeDate = System.DateTime.MinValue Then
                _Timestamp = System.Convert.ToInt64((_TimeDate - New System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString()
            Else
                _Timestamp = System.Convert.ToInt64((System.DateTime.Now - New System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString()
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Timestamp = Convert.ToInt64((System.DateTime.Now - New System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString()
        End Try

        Return _Timestamp

    End Function

    ''' <summary>
    ''' For TimeFormat format strings, see https://msdn.microsoft.com/en-us/library/microsoft.visualbasic.strings.format(v=vs.110).aspx.
    '''    Morocco Standard Time - GMT Casablanca
    '''    GMT Standard Time: (GMT) Greenwich Mean Time - Dublin, Edinburgh, Lisbon, London
    '''    Greenwich Standard Time: (GMT) Monrovia, Reykjavik
    '''    W. Europe Standard Time: (GMT+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna
    '''    Central Europe Standard Time: (GMT+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague
    '''    Romance Standard Time: (GMT+01:00) Brussels, Copenhagen, Madrid, Paris
    '''    Central European Standard Time: (GMT+01:00) Sarajevo, Skopje, Warsaw, Zagreb
    '''    W. Central Africa Standard Time: (GMT+01:00) West Central Africa
    '''    Jordan Standard Time: (GMT+02:00) Amman
    '''    GTB Standard Time: (GMT+02:00) Athens, Bucharest, Istanbul
    '''    Middle East Standard Time: (GMT+02:00) Beirut
    '''    Egypt Standard Time: (GMT+02:00) Cairo
    '''    South Africa Standard Time: (GMT+02:00) Harare, Pretoria
    '''    FLE Standard Time: (GMT+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius
    '''    Israel Standard Time: (GMT+02:00) Jerusalem
    '''    E. Europe Standard Time: (GMT+02:00) Minsk
    '''    Namibia Standard Time: (GMT+02:00) Windhoek
    '''    Arabic Standard Time: (GMT+03:00) Baghdad
    '''    Arab Standard Time: (GMT+03:00) Kuwait, Riyadh
    '''    Russian Standard Time: (GMT+03:00) Moscow, St. Petersburg, Volgograd
    '''    E. Africa Standard Time: (GMT+03:00) Nairobi
    '''    Georgian Standard Time: (GMT+03:00) Tbilisi
    '''    Iran Standard Time: (GMT+03:30) Tehran
    '''    Arabian Standard Time: (GMT+04:00) Abu Dhabi, Muscat
    '''    Azerbaijan Standard Time: (GMT+04:00) Baku
    '''    Mauritius Standard Time: (GMT+04:00) Port Louis
    '''    Caucasus Standard Time: (GMT+04:00) Yerevan
    '''    Afghanistan Standard Time: (GMT+04:30) Kabul
    '''    Ekaterinburg Standard Time: (GMT+05:00) Ekaterinburg
    '''    Pakistan Standard Time: (GMT+05:00) Islamabad, Karachi
    '''    West Asia Standard Time: (GMT+05:00) Tashkent
    '''    India Standard Time: (GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi
    '''    Sri Lanka Standard Time: (GMT+05:30) Sri Jayawardenepura
    '''    Nepal Standard Time: (GMT+05:45) Kathmandu
    '''    N. Central Asia Standard Time: (GMT+06:00) Almaty, Novosibirsk
    '''    Central Asia Standard Time: (GMT+06:00) Astana, Dhaka
    '''    Myanmar Standard Time: (GMT+06:30) Yangon (Rangoon)
    '''    SE Asia Standard Time: (GMT+07:00) Bangkok, Hanoi, Jakarta
    '''    North Asia Standard Time: (GMT+07:00) Krasnoyarsk
    '''    China Standard Time: (GMT+08:00) Beijing, Chongqing, Hong Kong, Urumqi
    '''    North Asia East Standard Time: (GMT+08:00) Irkutsk, Ulaan Bataar
    '''    Singapore Standard Time: (GMT+08:00) Kuala Lumpur, Singapore
    '''    W. Australia Standard Time: (GMT+08:00) Perth
    '''    Taipei Standard Time: (GMT+08:00) Taipei
    '''    Tokyo Standard Time: (GMT+09:00) Osaka, Sapporo, Tokyo
    '''    Korea Standard Time: (GMT+09:00) Seoul
    '''    Yakutsk Standard Time: (GMT+09:00) Yakutsk
    '''    Cen. Australia Standard Time: (GMT+09:30) Adelaide
    '''    AUS Central Standard Time: (GMT+09:30) Darwin
    '''    E. Australia Standard Time: (GMT+10:00) Brisbane
    '''    AUS Eastern Standard Time: (GMT+10:00) Canberra, Melbourne, Sydney
    '''    West Pacific Standard Time: (GMT+10:00) Guam, Port Moresby
    '''    Tasmania Standard Time: (GMT+10:00) Hobart
    '''    Vladivostok Standard Time: (GMT+10:00) Vladivostok
    '''    Central Pacific Standard Time: (GMT+11:00) Magadan, Solomon Is., New Caledonia
    '''    New Zealand Standard Time: (GMT+12:00) Auckland, Wellington
    '''    Fiji Standard Time: (GMT+12:00) Fiji, Kamchatka, Marshall Is.
    '''    Tonga Standard Time: (GMT+13:00) Nuku'alofa
    '''    Azores Standard Time: (GMT-01:00) Azores
    '''    Cape Verde Standard Time: (GMT-01:00) Cape Verde Is.
    '''    Mid-Atlantic Standard Time: (GMT-02:00) Mid-Atlantic
    '''    E. South America Standard Time: (GMT-03:00) Brasilia
    '''    Argentina Standard Time: (GMT-03:00) Buenos Aires
    '''    SA Eastern Standard Time: (GMT-03:00) Georgetown
    '''    Greenland Standard Time: (GMT-03:00) Greenland
    '''    Montevideo Standard Time: (GMT-03:00) Montevideo
    '''    Newfoundland Standard Time: (GMT-03:30) Newfoundland
    '''    Atlantic Standard Time: (GMT-04:00) Atlantic Time (Canada)
    '''    SA Western Standard Time: (GMT-04:00) La Paz
    '''    Central Brazilian Standard Time: (GMT-04:00) Manaus
    '''    Pacific SA Standard Time: (GMT-04:00) Santiago
    '''    Venezuela Standard Time: (GMT-04:30) Caracas
    '''    SA Pacific Standard Time: (GMT-05:00) Bogota, Lima, Quito, Rio Branco
    '''    Eastern Standard Time: (GMT-05:00) Eastern Time (US & Canada)
    '''    US Eastern Standard Time: (GMT-05:00) Indiana (East)
    '''    Central America Standard Time: (GMT-06:00) Central America
    '''    Central Standard Time: (GMT-06:00) Central Time (US & Canada)
    '''    Central Standard Time (Mexico): (GMT-06:00) Guadalajara, Mexico City, Monterrey
    '''    Canada Central Standard Time: (GMT-06:00) Saskatchewan
    '''    US Mountain Standard Time: (GMT-07:00) Arizona
    '''    Mountain Standard Time (Mexico): (GMT-07:00) Chihuahua, La Paz, Mazatlan
    '''    Mountain Standard Time: (GMT-07:00) Mountain Time (US & Canada)
    '''    Pacific Standard Time: (GMT-08:00) Pacific Time (US & Canada)
    '''    Pacific Standard Time (Mexico): (GMT-08:00) Tijuana, Baja California
    '''    Alaskan Standard Time: (GMT-09:00) Alaska
    '''    Hawaiian Standard Time: (GMT-10:00) Hawaii
    '''    Samoa Standard Time: (GMT-11:00) Midway Island, Samoa
    '''    Dateline Standard Time: (GMT-12:00) International Date Line West 
    ''' </summary>
    ''' <param name="_TimeString"></param>
    ''' <param name="_TimeZone">OPTIONAL: Name of Time Zone to convert to. Defaults to GMT Standard Time for TimeZone.</param>
    ''' <param name="_TimeFormat">OPTIONAL: String format to convert time to. Defaults to M/d/yyyy h:mm:ss tt</param>
    ''' <returns></returns>
    Public Function ConvertTime(ByVal _TimeString As System.String, Optional ByVal _TimeZone As System.String = "GMT Standard Time", Optional ByVal _TimeFormat As System.String = "M/d/yyyy h:mm:ss tt") As System.String

        Dim _ConvertedTime As String = System.String.Empty
        Dim _TimeZoneInformation As System.TimeZoneInfo

        Try
            If System.String.IsNullOrEmpty(_TimeString) Then
                _ConvertedTime = System.String.Empty
            Else
                _TimeZoneInformation = System.TimeZoneInfo.FindSystemTimeZoneById(_TimeZone)
                _ConvertedTime = System.TimeZoneInfo.ConvertTime(System.Convert.ToDateTime(TimeString), _TimeZoneInformation).ToString
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _ConvertedTime = System.String.Empty
        End Try

        Return _ConvertedTime

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_TimeString"></param>
    ''' <param name="_TimeFormat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FormatDateTime(ByVal _TimeString As System.String, Optional ByVal _TimeFormat As System.String = "M/d/yyyy h:mm:ss tt", Optional _UTC As System.Boolean = False) As System.String

        Dim _ConvertedTime As System.String = System.String.Empty

        Try
            If System.String.IsNullOrEmpty(_TimeString) Then
                _ConvertedTime = System.String.Empty
            Else
                _ConvertedTime = Format(If(_UTC = True, System.Convert.ToDateTime(_TimeString).ToUniversalTime, System.Convert.ToDateTime(_TimeString)), _TimeFormat)
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _ConvertedTime = System.String.Empty
        End Try

        Return _ConvertedTime

    End Function

#End Region

#Enable Warning BC42312

End Module
