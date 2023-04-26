Module ModuleColors

#Region " Constants "



#End Region

#Region " Variables "



#End Region

#Region " Procedures And Functions For Colors "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Red"></param>
    ''' <param name="_Green"></param>
    ''' <param name="_Blue"></param>
    ''' <returns></returns>
    Public Function RGBToHex(ByVal _Red As System.Int32, ByVal _Green As System.Int32, ByVal _Blue As System.Int32) As System.String

        Dim _Hex As System.String = System.String.Empty
        Dim _StringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _Chars As New System.Collections.Generic.List(Of System.Int32)
        Dim _CharOne As System.String = String.Empty
        Dim _CharTwo As System.String = String.Empty
        Dim _i As System.Int32 = 0

        Try
            '[ Add _Red, _Green, and _Blue to _Chars. ]
            _Chars.Add(_Red)
            _Chars.Add(_Green)
            _Chars.Add(_Blue)

            '[ Append # to _StringBuilder. ]
            _StringBuilder.Append("#")
            '[ Loop through _Chars. First divide by 16 (rounded down) and then get the Modulo (remainder).  ]
            For _i = 0 To _Chars.Count - 1 '[ Three colors: Red, Green, Blue. ]
                _CharOne = Math.Floor(_Chars.ElementAt(_i) / 16).ToString
                _CharTwo = Convert.ToString(_Chars.ElementAt(_i) Mod 16)
                '[   ]
                Select Case _CharOne
                    Case "10"
                        _StringBuilder.Append("A")
                        Exit Select
                    Case "11"
                        _StringBuilder.Append("B")
                        Exit Select
                    Case "12"
                        _StringBuilder.Append("C")
                        Exit Select
                    Case "13"
                        _StringBuilder.Append("D")
                        Exit Select
                    Case "14"
                        _StringBuilder.Append("E")
                        Exit Select
                    Case "15"
                        _StringBuilder.Append("F")
                        Exit Select
                    Case Else
                        _StringBuilder.Append(_CharOne)
                        Exit Select
                End Select
                '[   ]
                Select Case _CharTwo
                    Case "10"
                        _StringBuilder.Append("A")
                        Exit Select
                    Case "11"
                        _StringBuilder.Append("B")
                        Exit Select
                    Case "12"
                        _StringBuilder.Append("C")
                        Exit Select
                    Case "13"
                        _StringBuilder.Append("D")
                        Exit Select
                    Case "14"
                        _StringBuilder.Append("E")
                        Exit Select
                    Case "15"
                        _StringBuilder.Append("F")
                        Exit Select
                    Case Else
                        _StringBuilder.Append(_CharTwo)
                        Exit Select
                End Select
            Next
            _Hex = _StringBuilder.ToString()
        Catch ex As Exception
            _StringBuilder.Clear()
            _Hex = System.String.Empty
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _Hex

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Hex"></param>
    ''' <returns></returns>
    Public Function HexToRGB(ByVal _Hex As System.String) As System.Collections.Generic.Dictionary(Of System.String, System.Int32)

        Dim _RGB As System.Collections.Generic.Dictionary(Of System.String, System.Int32) = Nothing
        Dim _Regex As System.Text.RegularExpressions.Regex = Nothing
        Dim _Match As System.Text.RegularExpressions.Match = Nothing
        Dim _Chars As New System.Collections.Generic.List(Of System.Int32)
        Dim _Char As System.String = String.Empty
        Dim _i As System.Int32 = 0

        Try
            _Regex = New System.Text.RegularExpressions.Regex("#[0-9A-Fa-f]{6,}", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Singleline)
            _Match = _Regex.Match(_Hex)
            If (_Match.Success) Then '[ If _Hex is in the correct format. ]
                _Hex = Strings.Replace(_Hex, "#", System.String.Empty) '[ Strip the # at the beginning. ]
                '[ Loop through _Hex and convert any Hex numbers to their Decimal equivalent. Add them to _Chars. ]
                For _i = 0 To _Hex.Length - 1
                    Select Case _Hex(_i).ToString.ToUpper
                        Case "A"
                            _Chars.Add(10)
                            Exit Select
                        Case "B"
                            _Chars.Add(11)
                            Exit Select
                        Case "C"
                            _Chars.Add(12)
                            Exit Select
                        Case "D"
                            _Chars.Add(13)
                            Exit Select
                        Case "E"
                            _Chars.Add(14)
                            Exit Select
                        Case "F"
                            _Chars.Add(15)
                            Exit Select
                        Case Else
                            _Chars.Add(Convert.ToInt32(_Hex(_i).ToString.ToUpper))
                            Exit Select
                    End Select
                Next
                '[ Loop through _Chars by 2, and multiply the first number by 16 and add the second number to get the Decimal equivalent. ] 
                For _i = 0 To _Chars.Count - 1
                    Select Case _i
                        Case 0
                            _RGB.Add("R", Convert.ToInt32((_Chars(_i) * 16) + _Chars(_i + 1)))
                            Exit Select
                        Case 2
                            _RGB.Add("G", Convert.ToInt32((_Chars(_i) * 16) + _Chars(_i + 1)))
                            Exit Select
                        Case 4
                            _RGB.Add("B", Convert.ToInt32((_Chars(_i) * 16) + _Chars(_i + 1)))
                            Exit Select
                    End Select
                    _i += 2
                Next
            Else
                _RGB = Nothing
                Exit Try
            End If
        Catch ex As Exception
            _RGB = Nothing
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _RGB

    End Function

#End Region

#Region " Structures "



#End Region

End Module
