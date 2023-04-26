Module ModuleErrorLogging

#Region " Constants "



#End Region

#Region " Variables "



#End Region

#Region " Procedures And Functions For Error Logging "


    Public Sub WriteToErrorLog(ByVal _Messages As System.Collections.Generic.List(Of System.String), Optional ByVal _File As System.String = Nothing)

        Dim _Log As System.String = If(_File Is Nothing, System.String.Format("{0}\ErrorLog.txt", APPBASEDATAPATH), _File)

        Try
            System.IO.File.AppendAllText(_Log, System.String.Format("{1}{0}[screen] {2}{0}[method] {3}{0}[error] {4}",
                                                                    vbTab,
                                                                    FormatDateTime(DateTime.UtcNow, "yyyy-MM-dd hh:mm:ss"),
                                                                    _Messages.ElementAt(0).ToString(),
                                                                    _Messages.ElementAt(1).ToString(),
                                                                    _Messages.ElementAt(2).ToString()))
        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " Procedures And Functions For ? "



#End Region

#Region " Structures "



#End Region

End Module
