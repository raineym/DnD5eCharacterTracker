Public Class FormMoveCharacter

#Region " Constants "



#End Region

#Region " Variables "

    '[ For forms that are used as data entry. ]
    Private _IsDirty As System.Boolean = False
    '[ To check and see if OK to close form. ]
    Private _IsExitAvailable As System.Boolean = False
    '[ Used to load various settings before control events fire. ]
    Private _IsLoaded As Boolean = False

#End Region

#Region " Form And Control Procedures "

    Private Sub FormMoveCharacter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '[ Hide the form to make sure everything on the form loads before presenting it to the user. ]
            With Me
                .Hide()
                .Visible = False
            End With

            RefreshCampaigns()

            '[ Make controls look pretty on this form only. ]
            FormatControls()

            '[ Lastly, Add Event Handlers. ]
            AddHandler Me.ButtonMoveCharacterCancel.Click, AddressOf CloseForm
            AddHandler Me.ButtonMoveCharacterSave.Click, AddressOf LoadCampaign

        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            With Me
                '[ Display the form to the user. ]
                .Visible = True
                .Show()
            End With
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ListViewCampaigns_DrawItem(ByVal sender As Object, ByVal e As DrawListViewItemEventArgs) Handles ListViewCampaigns.DrawItem

        Dim _SF As New System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip)
        Dim _HeaderText As System.String = e.Item.SubItems(1).Text
        Dim _GamemasterText As System.String = System.String.Format("Gamemaster: {0}", e.Item.SubItems(2).Text)
        Dim _DefaultTextColor As System.Drawing.Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(33, 33, 33))
        Dim _FadedTextColor As System.Drawing.Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(68, 68, 68))
        Dim _SelectedTextColor As System.Drawing.Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 255, 255))
        Dim _DefaultBackColor As System.Drawing.Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 255, 255))
        Dim _SelectedBackColor As System.Drawing.Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(37, 143, 192))
        Dim _LineColor As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.Color.FromArgb(224, 224, 224), 1)
        Dim _StringSize As System.Drawing.SizeF = Nothing

        Try
            Me.ListViewCampaigns.SuspendLayout()

            With _SF
                .LineAlignment = System.Drawing.StringAlignment.Near
                .Alignment = System.Drawing.StringAlignment.Near
            End With

            If _HeaderText.Length > 64 Then
                _HeaderText = System.String.Format("{0} ...", _HeaderText.Substring(0, 60))
            End If

            With e.Graphics
                .CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver
                .CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.GammaCorrected

                e.DrawBackground()
                If e.Item.Selected Then
                    .FillRectangle(_SelectedBackColor, e.Bounds)
                    .DrawString(_HeaderText, New System.Drawing.Font(e.Item.Font.FontFamily, 9.75, System.Drawing.FontStyle.Regular), _SelectedTextColor, e.Bounds.Left + 5, e.Bounds.Top, _SF)
                    .DrawString(_GamemasterText, New System.Drawing.Font(e.Item.Font.FontFamily, 8.25, System.Drawing.FontStyle.Regular), _SelectedTextColor, e.Bounds.Left + 15, e.Bounds.Top + 17, _SF)
                Else
                    .FillRectangle(_DefaultBackColor, e.Bounds)
                    .DrawString(_HeaderText, New System.Drawing.Font(e.Item.Font.FontFamily, 9.75, System.Drawing.FontStyle.Regular), _DefaultTextColor, e.Bounds.Left + 5, e.Bounds.Top, _SF)
                    .DrawString(_GamemasterText, New System.Drawing.Font(e.Item.Font.FontFamily, 8.25, System.Drawing.FontStyle.Regular), _FadedTextColor, e.Bounds.Left + 15, e.Bounds.Top + 17, _SF)
                End If
                .DrawLine(_PenGrayColorFaint, 0, e.Bounds.Bottom, e.Bounds.Right, e.Bounds.Bottom)
            End With
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            Me.ListViewCampaigns.ResumeLayout()
        End Try

    End Sub

    ''' <summary>
    ''' Draws various shapes and text on form.
    ''' </summary>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim _Font As System.Drawing.Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 26, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Dim _FormGraphics As System.Drawing.Graphics = Me.CreateGraphics()

        With _FormGraphics
            .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            .CompositingMode = Drawing2D.CompositingMode.SourceOver
            .CompositingQuality = Drawing2D.CompositingQuality.GammaCorrected
            '.DrawString(PROGRAMNAME, _Font, _BrushBlackColor, New System.Drawing.Point(175, 46))
            '.FillRectangle(_BrushBlackColor, New System.Drawing.Rectangle(0, 0, 4096, 5))
            '.FillRectangle(_BrushBlackColor, New System.Drawing.Rectangle(0, 86, 4096, 25))
            '.FillRectangle(_BrushBlackColor, New System.Drawing.Rectangle(0, Me.Height - 89, 4096, 51))
        End With
        _FormGraphics.Dispose()

    End Sub

#End Region

#Region " Common Form Procedures "

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CloseForm()

        Try
            Me.Close()
        Catch ex As Exception
            Me.Close()
        End Try

    End Sub

    ''' <summary>
    ''' Loads images for the various controls on form.
    ''' </summary>
    Private Sub FormatControls()

        Dim _Screen = System.Windows.Forms.Screen.FromControl(Me)

        '[ Me ]
        With Me
            .Text = System.String.Format("{0}", "Load Campaign")
            .BackColor = System.Drawing.Color.FromArgb(255, 255, 248)
            .ControlBox = True
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
            .FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            .Icon = New System.Drawing.Icon(System.String.Format("{0}\default.ico", System.Windows.Forms.Application.StartupPath))
            .MaximumSize = New System.Drawing.Size(300, 300)
            .MaximizeBox = False
            .MinimumSize = New System.Drawing.Size(300, 300)
            .MinimizeBox = False
            .Size = New System.Drawing.Size(300, 300)
            .SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            .ShowInTaskbar = False
            .Location = New System.Drawing.Point((_Screen.WorkingArea.Width - Me.Width) / 2, (_Screen.WorkingArea.Height - Me.Height) / 2)
        End With

        '[ ListViewCampaigns ]
        With Me.ListViewCampaigns
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .FullRowSelect = True
            .HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            .MultiSelect = False
            .OwnerDraw = True
            .ShowGroups = False
            .View = System.Windows.Forms.View.Tile
        End With

        '[ ButtonMoveCharacterCancel ]
        With Me.ButtonMoveCharacterCancel
            .Text = System.String.Format("{0}", "Cancel")
            .BackColor = System.Drawing.Color.White
            .Cursor = System.Windows.Forms.Cursors.Default
            .FlatStyle = System.Windows.Forms.FlatStyle.System
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Size = New System.Drawing.Size(75, 28)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ ButtonMoveCharacterSave ]
        With Me.ButtonMoveCharacterSave
            .Text = System.String.Format("{0}", "Move")
            .BackColor = System.Drawing.Color.White
            .Cursor = System.Windows.Forms.Cursors.Default
            .FlatStyle = System.Windows.Forms.FlatStyle.System
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Size = New System.Drawing.Size(75, 28)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

    End Sub

#End Region

#Region " Other Form Procedures "

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub LoadCampaign()

        Dim _SelectedCampaign As System.Int32 = 0

        Try
            If Me.ListViewCampaigns.SelectedItems.Count > 0 Then
                _SelectedCampaign = Convert.ToInt32(Me.ListViewCampaigns.SelectedItems(0).SubItems(0).Text.ToString)
                If _Campaign IsNot Nothing Then
                    If Convert.ToInt32(_Campaign("id")).Equals(_SelectedCampaign) Then
                        MessageBox.Show("The selected campaign is already loaded.")
                        Exit Sub
                    End If
                Else
                    _Campaign = New System.Collections.Generic.Dictionary(Of String, String)
                    _Campaign.Add("id", Me.ListViewCampaigns.SelectedItems(0).SubItems(0).Text.ToString)
                    _Campaign.Add("name", Me.ListViewCampaigns.SelectedItems(0).SubItems(1).Text.ToString)
                    _Campaign.Add("gamemaster", Me.ListViewCampaigns.SelectedItems(0).SubItems(2).Text.ToString)
                End If
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            CloseForm()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub RefreshCampaigns()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _SQLiteReader As System.Data.SQLite.SQLiteDataReader = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _ListViewItem As System.Windows.Forms.ListViewItem = Nothing
        Dim _Campaigns As System.Int32 = 0

        Try
            With Me.ListViewCampaigns
                .Items.Clear()
                .Groups.Clear()
            End With
            If _SQLiteConnect IsNot Nothing Then
                If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                    Using _SQLiteConnect
                        With _QueryString
                            .Clear()
                            .Append("SELECT id, name, gamemaster FROM campaigns WHERE id <> @id ORDER BY name DESC;")
                        End With
                        _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                        With _SQLiteCommand
                            '[ Add Parameter Values. ]
                            .Parameters.AddWithValue("@id", _Campaign("id"))
                            '[ Execute Multi-Value SELECT query. ]
                            _SQLiteReader = .ExecuteReader()
                            '[ Clear Parameter Values. ]
                            If .Parameters.Count > 0 Then .Parameters.Clear()
                        End With
                        If _SQLiteReader IsNot Nothing Then
                            With _SQLiteReader
                                If .HasRows = True Then
                                    While .Read()
                                        _ListViewItem = New System.Windows.Forms.ListViewItem(.Item("id").ToString)
                                        _ListViewItem.SubItems.AddRange(New String() { .Item("name"), .Item("gamemaster")})
                                        _ListViewItem.BackColor = IIf(_Campaigns Mod 2 <> 0, System.Drawing.Color.FromArgb(224, 224, 224), System.Drawing.Color.White)
                                        Me.ListViewCampaigns.Items.Add(_ListViewItem)
                                        _Campaigns += 1
                                    End While
                                End If
                                .Close()
                            End With
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            If _QueryString IsNot Nothing Then
                _QueryString.Clear()
                _QueryString = Nothing
            End If
            If _SQLiteReader IsNot Nothing Then _SQLiteReader.Dispose()
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
            Me.ListViewCampaigns.TileSize = New System.Drawing.Size(256, 38)
            If Me.ListViewCampaigns.Items.Count > 4 Then
                Me.ListViewCampaigns.TileSize = New System.Drawing.Size(236, 38)
            End If
        End Try

    End Sub

#End Region

#Region " Common Form Functions "



#End Region

End Class
