Module ModuleImages

#Disable Warning BC42312

#Region " Procedures and Function for Images and ImageLists "

    ''' <summary>
    ''' Loops through a specified folder structure and adds all images to an imagelist of a specific size.
    ''' </summary>
    ''' <param name="_ImagePath">Folder path of images to add to ImageList.</param>
    ''' <param name="_ImageSize">OPTIONAL: Size of the images in pixels. Default: 16.</param>
    ''' <param name="_ImageDepth">OPTIONAL: Color depth of images. Default: 32.</param>
    ''' <returns>ImageList containing images in folder.</returns>
    ''' <remarks></remarks>
    Public Function LoadImagesToImageList(ByVal _ImagePath As System.String, Optional ByVal _ImageSize As System.Int32 = 16, Optional ByVal _ImageDepth As System.Int32 = 32) As System.Windows.Forms.ImageList

        Dim _ImageList As System.Windows.Forms.ImageList = New System.Windows.Forms.ImageList()
        Dim _Images As System.String() = Nothing

        Try
            With _ImageList
                .ImageSize = New System.Drawing.Size(_ImageSize, _ImageSize)
                Select Case _ImageDepth
                    Case 4
                        .ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit
                        Exit Select
                    Case 8
                        .ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
                        Exit Select
                    Case 16
                        .ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
                        Exit Select
                    Case 24
                        .ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
                        Exit Select
                    Case 32
                        .ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
                        Exit Select
                    Case Else
                        .ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
                        Exit Select
                End Select
            End With
            If System.IO.Directory.Exists(_ImagePath) Then
                _Images = System.IO.Directory.GetFiles(_ImagePath)
                With _ImageList
                    For Each _Image As System.String In _Images
                        .Images.Add(System.IO.Path.GetFileNameWithoutExtension(_Image).ToString.Trim().Replace(" ", "_"), System.Drawing.Image.FromFile(_Image))
                    Next
                End With
            Else
                _ImageList = Nothing
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            If _ImageList.Images.Count = 0 Then _ImageList = Nothing
        End Try

        Return _ImageList

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Image"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImageToByteArray(ByVal _Image As System.Drawing.Image) As System.Byte()

        Dim _MemoryStream As System.IO.MemoryStream = New System.IO.MemoryStream

        Try
            _Image.Save(_MemoryStream, System.Drawing.Imaging.ImageFormat.Png)
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _MemoryStream.Flush()
        End Try

        Return _MemoryStream.ToArray()

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Byte"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ByteArrayToImage(ByVal _Byte As System.Byte()) As System.Drawing.Image

        Return System.Drawing.Image.FromStream(New System.IO.MemoryStream(_Byte))

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Image"></param>
    ''' <param name="_Format"></param>
    ''' <returns></returns>
    Public Function ImageToBase64(ByVal _Image As System.Drawing.Image, Optional ByVal _Format As System.Drawing.Imaging.ImageFormat = Nothing) As String

        Dim _Base64String As System.String = Nothing

        Try
            Using _MemoryStream As New System.IO.MemoryStream()
                If _Format IsNot Nothing Then
                    _Image.Save(_MemoryStream, _Format)
                Else
                    _Image.Save(_MemoryStream, System.Drawing.Imaging.ImageFormat.Png)
                End If
                _Base64String = System.Convert.ToBase64String(_MemoryStream.ToArray())
            End Using
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Base64String = Nothing
        End Try

        Return _Base64String


    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Base64String"></param>
    ''' <returns></returns>
    Public Function Base64ToImage(ByVal _Base64String As System.String) As System.Drawing.Image

        Dim _Byte As System.Byte() = Nothing
        Dim _Image As System.Drawing.Image = Nothing

        Try
            _Byte = System.Convert.FromBase64String(_Base64String)
            Using _MemoryStream As New System.IO.MemoryStream(_Byte, 0, _Byte.Length)
                With _MemoryStream
                    .Write(_Byte, 0, _Byte.Length)
                End With
                _Image = Image.FromStream(_MemoryStream, True)
            End Using
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _Image = Nothing
        End Try

        Return _Image

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Image"></param>
    ''' <param name="_NewSize"></param>
    ''' <param name="_PreserveAspectRatio"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ResizeImage(ByVal _Image As System.Drawing.Image, ByVal _NewSize As System.Drawing.Size, Optional ByVal _PreserveAspectRatio As System.Boolean = True) As System.Drawing.Image

        Dim _NewImage As System.Drawing.Image = Nothing
        Dim _NewWidth As System.Int32 = 0
        Dim _NewHeight As System.Int32 = 0
        Dim _OriginalWidth As System.Int32 = 0
        Dim _OriginalHeight As System.Int32 = 0
        Dim _PercentWidth As System.Single = 0.0
        Dim _PercentHeight As System.Single = 0.0
        Dim _Percent As System.Single = 0.0

        Try
            If _PreserveAspectRatio = True Then
                _OriginalWidth = _Image.Width
                _OriginalHeight = _Image.Height
                _PercentWidth = System.Convert.ToSingle(_NewSize.Width / _OriginalWidth)
                _PercentHeight = System.Convert.ToSingle(_NewSize.Height / _OriginalHeight)
                _Percent = If(_PercentHeight < _PercentWidth, _PercentHeight, _PercentWidth)
                _NewWidth = System.Convert.ToInt32(_OriginalWidth * _Percent)
                _NewHeight = System.Convert.ToInt32(_OriginalHeight * _Percent)
            Else
                _NewWidth = _NewSize.Width
                _NewHeight = _NewSize.Height
            End If
            _NewImage = New System.Drawing.Bitmap(_NewWidth, _NewHeight)
            Using _GraphicsHandle As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(_NewImage)
                _GraphicsHandle.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                _GraphicsHandle.DrawImage(_Image, 0, 0, _NewWidth, _NewHeight)
            End Using
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _NewImage = _Image
        End Try

        Return _NewImage

    End Function

#End Region

#Enable Warning BC42312

End Module
