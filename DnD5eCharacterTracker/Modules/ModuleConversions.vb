Module ModuleConversions

#Region " Constants "



#End Region

#Region " Variables "



#End Region

#Region " Procedures And Functions For Conversions "




    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_ASCIIString"></param>
    ''' <param name="_Delimiter"></param>
    ''' <returns></returns>
    Public Function ASCIIToHex(ByVal _ASCIIString As System.String, Optional ByVal _Delimiter As System.String = "") As System.String

        Dim _StringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim _Bytes() As System.Byte
        Dim _i As System.Int32 = Nothing

        Try
            If _ASCIIString.Length > 0 Then
                _Bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(_ASCIIString)
                For _i = 0 To _Bytes.Length - 1
                    If _i < _Bytes.Length - 1 Then
                        _StringBuilder.AppendFormat("{0}{1}", _Bytes(_i).ToString("x"), _Delimiter)
                    Else
                        _StringBuilder.Append(_Bytes(_i).ToString("x"))
                    End If
                Next
            Else
                _StringBuilder.Clear()
            End If
        Catch ex As Exception
            _StringBuilder.Clear()
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _StringBuilder.ToString()

    End Function

    ''' <summary>
    ''' Function to convert a binary number to a decimal.
    ''' </summary>
    ''' <param name="_BinaryString">Binary string to be converted.</param>
    ''' <returns>64-bit unsigned integer.</returns>
    Public Function BinaryToDecimal(ByVal _BinaryString As System.String) As System.Int64

        Dim _Decimal As System.Int64 = 0
        Dim _Length As System.Int32 = Strings.Len(_BinaryString)
        Dim _Temp As System.Int32 = Nothing
        Dim _i As System.Int32 = Nothing

        Try
            For _i = 1 To _Length
                _Temp = Convert.ToInt64((Strings.Mid(_BinaryString, _Length, 1)))
                _Length = _Length - 1
                If _Temp <> "0" Then
                    _Decimal += (2 ^ (_i - 1))
                End If
            Next
        Catch ex As Exception
            _Decimal = 0
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _Decimal

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Number"></param>
    ''' <param name="_BaseFrom"></param>
    ''' <param name="_BaseTo"></param>
    ''' <returns></returns>
    Private Function ConvertBaseToBase(ByVal _Number As System.Int64, ByVal _BaseFrom As System.Int32, ByVal _BaseTo As System.Int32) As System.String

        Dim _Decimal As System.Int64 = 0
        Dim _NumberReversed As System.String = Strings.StrReverse(_Number.ToString)
        Dim _Length As System.Int32 = Strings.Len(_NumberReversed)
        Dim _Temp As System.Int32 = 0
        Dim _i As System.Int32 = 0
        Dim _StringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim _Modulo As System.Decimal = 0

        Try
            '[ First, convert _Number from _BaseFrom to Decimal (Base 10). ]
            For _i = 0 To _Length - 1 Step 1
                _Temp = Convert.ToInt64((Strings.Mid(_NumberReversed, _i + 1, 1)))
                _Decimal += _Temp * (_BaseFrom ^ _i)
            Next
            '[ Last, convert _Decimal (Base 10) to _BaseTo. ]
            Do
                _Modulo = (_Decimal Mod _BaseTo)
                _StringBuilder.Insert(0, _Modulo)
                _Decimal = Math.Floor((_Decimal / _BaseTo))
            Loop While _Decimal <> 0
        Catch ex As Exception
            _StringBuilder.Clear.Append("0")
        End Try

        Return _StringBuilder.ToString()

    End Function





    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Number"></param>
    ''' <param name="_Base"></param>
    ''' <returns></returns>
    Private Function ConvertBaseToDecimal(ByVal _Number As System.Int64, ByVal _Base As System.Int32) As System.Int64

        Dim _Decimal As System.Int64 = 0
        Dim _NumberReversed As System.String = Strings.StrReverse(_Number.ToString)
        Dim _Length As System.Int32 = Strings.Len(_NumberReversed)
        Dim _Temp As System.Int32 = 0
        Dim _i As System.Int32 = 0

        Try
            For _i = 0 To _Length - 1 Step 1
                _Temp = Convert.ToInt64((Strings.Mid(_NumberReversed, _i + 1, 1)))
                _Decimal += _Temp * (_Base ^ _i)
            Next
        Catch ex As Exception
            _Decimal = 0
        End Try

        Return _Decimal

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Number"></param>
    ''' <param name="_Base"></param>
    ''' <returns></returns>
    Private Function ConvertDecimaltoBase(ByVal _Number As System.Int64, ByVal _Base As System.Int32) As System.Int64

        Dim _StringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim _Modulo As System.Decimal = 0
        Dim _Digit As System.Int64 = _Number

        Try
            Do
                _Modulo = (_Digit Mod _Base)
                _StringBuilder.Insert(0, _Modulo)
                _Digit = Math.Floor((_Digit / _Base))
            Loop While _Digit <> 0
        Catch ex As Exception
            _StringBuilder.Clear()
        End Try

        Return If(_StringBuilder.Length > 0, Convert.ToInt64(_StringBuilder.ToString()), 0)

    End Function

    ''' <summary>
    ''' Function to convert a decimal to a binary number.
    ''' </summary>
    ''' <param name="_Decimal">64-bit unsigned integer to be converted.</param>
    ''' <returns>Binary string.</returns>
    Public Function DecimalToBinary(ByVal _Decimal As System.Int64) As System.String

        Dim _StringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim _Modulo As System.Decimal = 0
        Dim _Digit As System.Int64 = _Decimal

        Try
            Do
                _Modulo = (_Digit Mod 2)
                _StringBuilder.Insert(0, _Modulo)
                _Digit = Convert.ToInt64(_Digit - _Modulo)
            Loop While _Digit <> 0
        Catch ex As Exception
            _StringBuilder.Clear()
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return If(_StringBuilder.Length > 0, _StringBuilder.ToString(), System.String.Empty)

    End Function

    ''' <summary>
    ''' Function to convert a decimal to a hexidecimal number.
    ''' </summary>
    ''' <param name="_Decimal">64-bit unsigned integer to be converted.</param>
    ''' <returns>Hexidecimal string.</returns>
    Public Function DecimalToHex(ByVal _Decimal As System.Int64) As System.String

        Dim _Hex As System.String = System.String.Empty

        Try
            _Hex = _Decimal.ToString("x")
        Catch ex As Exception
            _Hex = System.String.Empty
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _Hex

    End Function

    ''' <summary>
    ''' Function to convert a decimal to an octal number.
    ''' </summary>
    ''' <param name="_Decimal">64-bit unsigned integer to be converted.</param>
    ''' <returns>Octal string.</returns>
    Public Function DecimalToOctal(ByVal _Decimal As System.Int64) As System.String

        Dim _Octal As System.String = System.String.Empty

        Try
            _Octal = System.Convert.ToString(_Decimal, 8)
        Catch ex As Exception
            _Octal = System.String.Empty
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _Octal

    End Function

    ''' <summary>
    ''' Function to convert a hexidecimal string to ASCII-encoded text.
    ''' </summary>
    ''' <param name="_HexString">Hexidecimal string to be converted.</param>
    ''' <returns>ASCII-encoded text string.</returns>
    Public Function HexToASCII(ByVal _HexString As System.String, Optional ByVal _Delimiter As System.String = "") As System.String

        Dim _StringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim _i As System.Int32 = Nothing

        Try
            _HexString = _HexString.ToUpper.Replace("#", System.String.Empty).Replace("&H", System.String.Empty).Replace(_Delimiter, System.String.Empty)
            For _i = 0 To _HexString.Length - 1 Step 2
                _StringBuilder.Append(Strings.ChrW(Convert.ToInt32(System.String.Format("&H{0}", _HexString.Substring(_i, 2).ToUpper))))
            Next
        Catch ex As Exception
            _StringBuilder.Clear()
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _StringBuilder.ToString()

    End Function

    ''' <summary>
    ''' Function to convert a hexidecimal number to a decimal.
    ''' </summary>
    ''' <param name="_HexString">Hexidecimal string to be converted.</param>
    ''' <returns>64-bit unsigned integer.</returns>
    Public Function HexToDecimal(ByVal _HexString As System.String) As System.Int64

        Dim _Decimal As System.Int64 = 0

        Try
            _HexString = _HexString.ToUpper.Replace("#", System.String.Empty).Replace("&H", System.String.Empty)
            _Decimal = Convert.ToInt64(_HexString, 16)
        Catch formatex As FormatException
            _Decimal = 0
            ShowMessage("Error", formatex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Catch ex As Exception
            _Decimal = 0
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _Decimal

    End Function

    ''' <summary>
    ''' Function to convert an octal number to a decimal.
    ''' </summary>
    ''' <param name="_OctalString">Octal string to be converted.</param>
    ''' <returns>64-bit unsigned integer.</returns>
    Public Function OctalToDecimal(ByVal _OctalString As System.String) As System.Int64

        Dim _Decimal As System.Int64 = 0

        Try
            '_OctalString = _HexString.ToUpper.Replace("#", System.String.Empty).Replace("&H", System.String.Empty)
            _Decimal = Convert.ToInt64(_OctalString, 8)
        Catch formatex As FormatException
            _Decimal = 0
            ShowMessage("Error", formatex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Catch ex As Exception
            _Decimal = 0
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

        Return _Decimal

    End Function

#End Region

#Region " Structures "



#End Region

End Module
