Module ModuleJSON

#Disable Warning BC42312

#Region " Variables "

    'Public _JSON As Newtonsoft.Json.Linq.JObject = Nothing
    'Public _JSONPreferences As Newtonsoft.Json.Linq.JObject = Nothing

#End Region

#Region " Procedures and Functions for JSON "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_File"></param>
    ''' <returns>JSON Object</returns>
    ''' <remarks></remarks>
    'Public Function GetJSONFromFile(ByVal _File As System.String) As Newtonsoft.Json.Linq.JObject

    '    Dim _JObject As Newtonsoft.Json.Linq.JObject = Nothing

    '    Try
    '        Using _StringReader As New System.IO.StringReader(System.IO.File.ReadAllText(_File))
    '            _JObject = Newtonsoft.Json.Linq.JObject.Parse(_StringReader.ReadToEnd)
    '        End Using
    '    Catch ex As Exception
    '        ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
    '        _JObject = Nothing
    '    End Try

    '    Return _JObject

    'End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_String"></param>
    ''' <returns></returns>
    'Public Function GetJSONFromString(ByVal _String As System.String) As Newtonsoft.Json.Linq.JObject

    '    Dim _JObject As Newtonsoft.Json.Linq.JObject = Nothing

    '    Try
    '        _JObject = Newtonsoft.Json.Linq.JObject.Parse(_String)
    '    Catch ex As Exception
    '        ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
    '        _JObject = Nothing
    '    End Try

    '    Return _JObject

    'End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_File"></param>
    ''' <param name="_JObject"></param>
    'Public Sub SaveJSON(ByVal _File As System.String, Optional ByVal _JObject As Newtonsoft.Json.Linq.JObject = Nothing)

    '    Try
    '        System.IO.File.WriteAllText(_File, If(_JObject IsNot Nothing, _JObject.ToString(), _JSON.ToString))
    '    Catch ex As Exception
    '        ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
    '    End Try

    'End Sub

#End Region

#Enable Warning BC42312

End Module
