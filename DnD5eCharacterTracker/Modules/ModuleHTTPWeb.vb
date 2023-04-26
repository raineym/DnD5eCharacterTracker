Module ModuleHTTPWeb

#Disable Warning BC42312

#Region " Procedures and Functions For HTTP and Web "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_URL"></param>
    ''' <param name="_EncodeDecode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetHTML(ByVal _URL As System.String, Optional ByVal _EncodeDecode As System.Int32 = 0) As System.String

        Dim _HttpRequest As System.Net.HttpWebRequest = Nothing
        Dim _HttpStream As System.IO.Stream = Nothing
        Dim _HttpResponse As System.Net.WebResponse = Nothing
        Dim _Chunk As System.String = Nothing
        Dim _EncodedDecodedString As System.String = System.String.Empty

        Try
            _HttpRequest = System.Net.HttpWebRequest.Create(URLEncodeString(_URL))
            _HttpResponse = _HttpRequest.GetResponse()
            _HttpStream = _HttpResponse.GetResponseStream
            _Chunk = New System.IO.StreamReader(_HttpStream).ReadToEnd()
            _EncodedDecodedString = If(_EncodeDecode = 0, System.Net.WebUtility.HtmlEncode(_Chunk), System.Net.WebUtility.HtmlDecode(_Chunk))
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _EncodedDecodedString = String.Empty
        Finally
            If _HttpStream IsNot Nothing Then _HttpStream.Close()
            If _HttpResponse IsNot Nothing Then _HttpResponse.Close()
        End Try

        Return _EncodedDecodedString

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_URL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function URLEncodeString(ByVal _URL As System.String) As System.String

        Dim _EncodedString As System.String = System.String.Empty

        Try
            If Not System.String.IsNullOrEmpty(_URL) Then
                _EncodedString = System.Web.HttpUtility.UrlEncode(_URL, System.Text.Encoding.UTF8)
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _EncodedString = _URL
        End Try

        Return _EncodedString

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Markup"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StripHTML(ByVal _Markup As System.String) As System.String

        Dim _Start As System.Int32 = 0
        Dim _End As System.Int32 = 0
        Dim _Count As System.Int32 = 0
        Dim _StrippedString As System.String = System.String.Empty

        Try
            With _Markup
                While ((.IndexOf("<") > -1) AndAlso (.IndexOf(">") > -1) AndAlso (.IndexOf("<") < .IndexOf(">")))
                    _Start = .IndexOf("<")
                    _End = .IndexOf(">")
                    _Count = _End - _Start + 1
                    _Markup = .Remove(_Start, _Count)
                End While
                _StrippedString = .Replace(" ", " ").Replace(">", "").Replace(vbCr & vbLf, "").Trim()
            End With
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _StrippedString = String.Empty
        End Try

        Return _StrippedString

    End Function

#End Region

#Enable Warning BC42312

End Module
