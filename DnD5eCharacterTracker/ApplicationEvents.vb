Imports System.IO
Imports System.Reflection

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub Form1_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf LoadDLLFromPath
        End Sub

        Private Function LoadDLLFromPath(ByVal sender As Object, ByVal args As System.ResolveEventArgs) As System.Reflection.Assembly

            Dim resourceName As String = New AssemblyName(args.Name).Name & ".dll"
            Dim DLLPaths as String() = {String.Format("{0}\Lib", Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location))}

            For Each DLLPath As String in DLLPaths
                If Directory.Exists(DLLPath) Then
                    If File.Exists(String.Format("{0}\{1}", DLLPath, resourceName)) Then
                        Return System.Reflection.Assembly.LoadFrom(String.Format("{0}\{1}", DLLPath, resourceName))
                        Exit For
                    End If
                End If
            Next

        End Function

    End Class
End Namespace
