Public Class FormMain

#Region " Constants "



#End Region

#Region " Variables "

    '[ For forms that are used as data entry. ]
    Private _IsDirty As System.Boolean = False
    '[ To check and see if OK to close form. ]
    Private _IsExitAvailable As System.Boolean = False

#End Region

#Region " Form And Control Procedures "

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '[ Hide the form to make sure everything on the form loads before presenting it to the user. ]
            With Me
                Me.Hide()
                Me.Visible = False
            End With

            UpdateDatabase()

            '[ Make controls look pretty. ]
            FormatControls()

            '[ Lastly, Add Event Handlers. ]
            AddHandler Me.MenuStripMainItemFileItemBackup.Click, AddressOf BackupDatabase
            AddHandler Me.MenuStripMainItemFileItemRestore.Click, AddressOf RestoreDatabase
            AddHandler Me.MenuStripMainItemFileItemExit.Click, AddressOf ExitApplication
            AddHandler Me.MenuStripMainItemCampaignsItemLoad.Click, AddressOf OpenLoadCampaignForm
            AddHandler Me.MenuStripMainItemCampaignsItemClose.Click, AddressOf CloseCampaign
            AddHandler Me.MenuStripMainItemCampaignsItemProperties.Click, AddressOf OpenCampaignPropertiesWindow
            AddHandler Me.MenuStripMainItemCampaignsItemNew.Click, AddressOf OpenNewCampaignWindow
            AddHandler Me.MenuStripMainItemCampaignsItemRemove.Click, AddressOf OpenRemoveCampaignForm
            AddHandler Me.MenuStripMainItemCharacterItemAdd.Click, AddressOf AddCharacter
            AddHandler Me.MenuStripMainItemCharacterItemDelete.Click, AddressOf DeleteCharacter
            AddHandler Me.MenuStripMainItemCharacterItemDuplicate.Click, AddressOf DuplicateCharacter
            AddHandler Me.MenuStripMainItemCharacterItemMove.Click, AddressOf OpenMoveCharacterWindow
            AddHandler Me.MenuStripMainItemHelpItemGettingStarted.Click, AddressOf GotoGettingStarted
            AddHandler Me.MenuStripMainItemHelpItemWiki.Click, AddressOf GotoWiki
            AddHandler Me.MenuStripMainItemHelpItemReleaseNotes.Click, AddressOf GotoReleaseNotes
            AddHandler Me.MenuStripMainItemHelpItemReportBug.Click, AddressOf GotoReportBug
            AddHandler Me.MenuStripMainItemHelpItemAbout.Click, AddressOf OpenAboutWindow
            AddHandler Me.ContextMenuStripMainItemAdd.Click, AddressOf AddCharacter
            AddHandler Me.ContextMenuStripMainItemDelete.Click, AddressOf DeleteCharacter
            AddHandler Me.ContextMenuStripMainItemDuplicate.Click, AddressOf DuplicateCharacter
            AddHandler Me.ContextMenuStripMainItemMove.Click, AddressOf OpenMoveCharacterWindow
            AddHandler Me.ButtonCharacterAdd.Click, AddressOf AddCharacter
            AddHandler Me.ButtonCharacterDelete.Click, AddressOf DeleteCharacter
            AddHandler Me.ListViewCharacters.SelectedIndexChanged, AddressOf LoadCharacterPanel

        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            With Me
                .Visible = True
                .Show()
            End With
            'CheckUpdates()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ListViewCharacters_DrawItem(ByVal sender As Object, ByVal e As DrawListViewItemEventArgs) Handles ListViewCharacters.DrawItem

        Dim _SF As New System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip)
        Dim _HeaderText As System.String = e.Item.SubItems(1).Text
        Dim _PlayerText As System.String = System.String.Format("Player: {0}", e.Item.SubItems(2).Text)
        Dim _DefaultTextColor As System.Drawing.Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(33, 33, 33))
        Dim _FadedTextColor As System.Drawing.Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(68, 68, 68))
        Dim _SelectedTextColor As System.Drawing.Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 255, 255))
        Dim _DefaultBackColor As System.Drawing.Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 255, 255))
        Dim _SelectedBackColor As System.Drawing.Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(37, 143, 192))
        Dim _StringSize As System.Drawing.SizeF = Nothing

        Try
            Me.ListViewCharacters.SuspendLayout()

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
                    .DrawString(_PlayerText, New System.Drawing.Font(e.Item.Font.FontFamily, 8.25, System.Drawing.FontStyle.Regular), _SelectedTextColor, e.Bounds.Left + 15, e.Bounds.Top + 17, _SF)
                Else
                    '.FillRectangle(_DefaultBackColor, e.Bounds)
                    .DrawString(_HeaderText, New System.Drawing.Font(e.Item.Font.FontFamily, 9.75, System.Drawing.FontStyle.Regular), _DefaultTextColor, e.Bounds.Left + 5, e.Bounds.Top, _SF)
                    .DrawString(_PlayerText, New System.Drawing.Font(e.Item.Font.FontFamily, 8.25, System.Drawing.FontStyle.Regular), _FadedTextColor, e.Bounds.Left + 15, e.Bounds.Top + 17, _SF)
                End If
                .DrawLine(_PenGrayColorFaint, 0, e.Bounds.Bottom, e.Bounds.Right, e.Bounds.Bottom)
            End With
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            Me.ListViewCharacters.ResumeLayout()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ContextMenuStripMain_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStripMain.Opening

        Try
            Me.ContextMenuStripMainItemAdd.Enabled = False
            Me.ContextMenuStripMainItemDelete.Enabled = False
            Me.ContextMenuStripMainItemDuplicate.Enabled = False
            Me.ContextMenuStripMainItemMove.Enabled = False
            If _Campaign IsNot Nothing Then '[ Campaign Loaded ]
                Me.ContextMenuStripMainItemAdd.Enabled = True
                If Me.ListViewCharacters.SelectedItems.Count > 0 Then
                    Me.ContextMenuStripMainItemDelete.Enabled = True
                    Me.ContextMenuStripMainItemDuplicate.Enabled = True
                    Me.ContextMenuStripMainItemMove.Enabled = True
                End If
            End If
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub MenuStripMainItemCampaigns_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles MenuStripMainItemCampaign.DropDownOpening

        Try
            Me.MenuStripMainItemCampaignsItemLoad.Enabled = False
            Me.MenuStripMainItemCampaignsItemClose.Enabled = False
            Me.MenuStripMainItemCampaignsSeparator01.Enabled = True
            Me.MenuStripMainItemCampaignsItemProperties.Enabled = False
            Me.MenuStripMainItemCampaignsSeparator02.Enabled = False
            Me.MenuStripMainItemCampaignsItemNew.Enabled = False
            Me.MenuStripMainItemCampaignsItemRemove.Enabled = False
            If _Campaign IsNot Nothing Then '[ Campaign Loaded ]
                Me.MenuStripMainItemCampaignsItemClose.Enabled = True
                Me.MenuStripMainItemCampaignsItemProperties.Enabled = True
                Me.MenuStripMainItemCampaignsSeparator02.Enabled = True
                Me.MenuStripMainItemCampaignsItemNew.Enabled = False
                Me.MenuStripMainItemCampaignsItemRemove.Enabled = False
            Else '[ Campaign Not Loaded ]
                Me.MenuStripMainItemCampaignsItemLoad.Enabled = True
                Me.MenuStripMainItemCampaignsItemNew.Enabled = True
                Me.MenuStripMainItemCampaignsItemRemove.Enabled = True
            End If
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub MenuStripMainItemCharacter_DropDownOpening(sender As Object, e As EventArgs) Handles MenuStripMainItemCharacter.DropDownOpening

        Try
            Me.MenuStripMainItemCharacterItemAdd.Enabled = False
            Me.MenuStripMainItemCharacterItemDelete.Enabled = False
            Me.MenuStripMainItemCharacterItemDuplicate.Enabled = False
            Me.MenuStripMainItemCharacterItemMove.Enabled = False
            If _Campaign IsNot Nothing Then '[ Campaign Loaded ]
                Me.MenuStripMainItemCharacterItemAdd.Enabled = True
                If Me.ListViewCharacters.SelectedItems.Count > 0 Then
                    Me.MenuStripMainItemCharacterItemDelete.Enabled = True
                    Me.MenuStripMainItemCharacterItemDuplicate.Enabled = True
                    Me.MenuStripMainItemCharacterItemMove.Enabled = True
                End If
            End If
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub MenuStripMainItemFile_DropDownOpening(sender As Object, e As EventArgs) Handles MenuStripMainItemFile.DropDownOpening

        Try
            Me.MenuStripMainItemFileItemBackup.Enabled = False
            Me.MenuStripMainItemFileItemRestore.Enabled = False
            If _Campaign Is Nothing Then '[ Campaign Not Loaded ]
                Me.MenuStripMainItemFileItemBackup.Enabled = True
                Me.MenuStripMainItemFileItemRestore.Enabled = True
            End If
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' Draws various shapes and text on form.
    ''' </summary>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim _FormatFont As System.Drawing.Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 26, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Dim _FormGraphics As System.Drawing.Graphics = Me.CreateGraphics()

        With _PenGrayColorFaded
            .Width = 1
        End With

        With _FormGraphics
            .SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
            .TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
            .CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver
            .CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.GammaCorrected
            .DrawLine(_PenGrayColorFaded, New System.Drawing.Point(-1, 24), New System.Drawing.Point(4096, 24))
        End With
        _FormGraphics.Dispose()

    End Sub

#End Region

#Region " Common Form Procedures "

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ExitApplication()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _SQLiteConnect IsNot Nothing Then
                If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                    Using _SQLiteConnect
                        With _QueryString
                            .Clear()
                            .Append("VACUUM")
                        End With
                        _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                        With _SQLiteCommand
                            '[ Execute INSERT or UPDATE query. ]
                            .ExecuteNonQuery()
                        End With
                    End Using
                End If
            End If
        Catch ex As Exception
            _IsDirty = False
            _IsExitAvailable = True
        Finally
            If _QueryString IsNot Nothing Then
                _QueryString.Clear()
                _QueryString = Nothing
            End If
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
            System.Windows.Forms.Application.Exit()
        End Try

    End Sub

    ''' <summary>
    ''' Loads images for the various controls on form.
    ''' </summary>
    Private Sub FormatControls()

        Dim _Screen = System.Windows.Forms.Screen.FromControl(Me)

        '[ Me ]
        With Me
            .Icon = New System.Drawing.Icon(System.String.Format("{0}\default.ico", System.Windows.Forms.Application.StartupPath))
            .Text = System.String.Format("{0}", PROGRAMNAME)
            .BackColor = System.Drawing.Color.FromArgb(255, 255, 248)
            .ControlBox = True
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
            .FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            .MaximumSize = New System.Drawing.Size(_Screen.WorkingArea.Width, _Screen.WorkingArea.Height)
            .MaximizeBox = True
            .MinimumSize = New System.Drawing.Size(1024, 768)
            .MinimizeBox = True
            .Size = New System.Drawing.Size(1024, 768)
            .SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            .StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            .Location = New System.Drawing.Point((_Screen.WorkingArea.Width - Me.Width) / 2, (_Screen.WorkingArea.Height - Me.Height) / 2)
        End With

        '[ MenuStripMain ]
        With Me.MenuStripMain
            .BackColor = System.Drawing.Color.FromArgb(255, 255, 248)
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
        End With

        '[ LabelCampaignHeader ]
        With Me.LabelCampaignHeader
            .Text = System.String.Format("{0}", "Campaign: ")
            '[ Remove Options That Are Not Needed/Supported In Control ]
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 12.0, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleRight
            .Visible = False
        End With

        '[ LabelCharactersHeader ]
        With Me.LabelCharactersHeader
            .Text = System.String.Format("{0}", "Characters")
            '[ Remove Options That Are Not Needed/Supported In Control ]
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 12.0, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Tag = "Characters: {0}"
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            .Visible = False
        End With

        '[ ButtonCharacterAdd ]
        With Me.ButtonCharacterAdd
            .Text = System.String.Empty
            .BackColor = Me.BackColor
            .FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 255, 240)
            .FlatAppearance.BorderSize = 0
            .FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(255, 255, 240)
            .FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 255, 240)
            .FlatStyle = System.Windows.Forms.FlatStyle.Flat
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Image = Base64ToImage(My.Resources.Add)
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            .Visible = False
        End With

        '[ ButtonCharacterDelete ]
        With Me.ButtonCharacterDelete
            .Text = System.String.Empty
            .BackColor = Me.BackColor
            .FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 255, 240)
            .FlatAppearance.BorderSize = 0
            .FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(255, 255, 240)
            .FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 255, 240)
            .FlatStyle = System.Windows.Forms.FlatStyle.Flat
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Image = Base64ToImage(My.Resources.Delete)
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            .Visible = False
        End With

        '[ ListViewCharacters ]
        With Me.ListViewCharacters
            .BackColor = System.Drawing.Color.White
            .ContextMenuStrip = ContextMenuStripMain
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .FullRowSelect = True
            .HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            .MultiSelect = False
            .OwnerDraw = True
            .ShowGroups = False
            .View = System.Windows.Forms.View.Tile
        End With

    End Sub

    ''' <summary>
    ''' Loads images for program into various ImageLists.
    ''' </summary>
    ''' <remarks>
    ''' Uncomment the lines of the images you are wanting to load into the ImageLists.
    ''' </remarks>
    Private Sub LoadImageLists()

        '_ImageList16 = LoadImagesToImageList(String.Format("{0}\Images", APPDEFAULTRESOURCEPATH), 16)
        '_ImageList20 = LoadImagesToImageList(String.Format("{0}\Images", APPDEFAULTRESOURCEPATH), 20)
        '_ImageList24 = LoadImagesToImageList(String.Format("{0}\Images", APPDEFAULTRESOURCEPATH), 24)
        '_ImageList32 = LoadImagesToImageList(String.Format("{0}\Images", APPDEFAULTRESOURCEPATH), 32)
        '_ImageList40 = LoadImagesToImageList(String.Format("{0}\Images", APPDEFAULTRESOURCEPATH), 40)
        '_ImageList48 = LoadImagesToImageList(String.Format("{0}\Images", APPDEFAULTRESOURCEPATH), 48)
        '_ImageList64 = LoadImagesToImageList(String.Format("{0}\Images", APPDEFAULTRESOURCEPATH), 64)
        '_ImageList96 = LoadImagesToImageList(String.Format("{0}\Images", APPDEFAULTRESOURCEPATH), 96)
        '_ImageList128 = LoadImagesToImageList(String.Format("{0}\Images", APPDEFAULTRESOURCEPATH), 128)

    End Sub

#End Region

#Region " Other Form Procedures "

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub AddCharacter()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _SQLiteReader As System.Data.SQLite.SQLiteDataReader = Nothing
        Dim _SQLiteAdapter As System.Data.SQLite.SQLiteDataAdapter = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _SQLiteConnect IsNot Nothing Then
                If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                    Using _SQLiteConnect
                        With _QueryString
                            .Clear()
                            .Append("INSERT INTO characters (uuid, campaignid) VALUES (@uuid, @cid)")
                        End With
                        _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                        With _SQLiteCommand
                            '[ Add Parameter Values. ]
                            .Parameters.AddWithValue("@uuid", GenerateUUID)
                            .Parameters.AddWithValue("@cid", _Campaign("id"))
                            '[ Execute INSERT or UPDATE query. ]
                            .ExecuteNonQuery()
                            '[ Clear Parameter Values. ]
                            If .Parameters.Count > 0 Then .Parameters.Clear()
                        End With
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
            If _SQLiteAdapter IsNot Nothing Then _SQLiteAdapter.Dispose()
            If _SQLiteReader IsNot Nothing Then _SQLiteReader.Dispose()
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
            LoadCampaign()
        End Try

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub BackupDatabase()

        Dim _Database As String = System.String.Format("{0}\data.db3", APPDEFAULTDATAPATH)
        Dim _DialogResult As System.Windows.Forms.DialogResult = Nothing
        Dim _FileName As String = System.String.Format("{0}\Backup\DataBackup_{1}.zip", APPDEFAULTDATAPATH, FormatDateTime(DateTime.Now.ToString, "MMddyyyyThhmmss"))

        Try
            If Not System.IO.Directory.Exists(System.String.Format("{0}\Backup", APPDEFAULTDATAPATH)) Then
                System.IO.Directory.CreateDirectory(System.String.Format("{0}\Backup", APPDEFAULTDATAPATH))
            End If
            Using _ZipFile As New Ionic.Zip.ZipFile()
                _ZipFile.AddFile(_Database, "")
                _ZipFile.Save(_FileName)
            End Using
            If System.IO.File.Exists(_FileName) Then
                System.Windows.Forms.MessageBox.Show("Backup Successful.", "Character Tracker Says ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                System.Windows.Forms.MessageBox.Show("Backup Unsuccessful.", "Character Tracker Says ...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CheckUpdates()

        Dim _SettingsPath As System.String = Path.Combine(APPDEFAULTDATAPATH, "settings.json")

        Try
            AutoUpdater.InstalledVersion = New Version("1.0.0")
            AutoUpdater.ShowSkipButton = True
            AutoUpdater.ShowRemindLaterButton = False
            AutoUpdater.OpenDownloadPage = True
            AutoUpdater.LetUserSelectRemindLater = True
            AutoUpdater.RemindLaterTimeSpan = RemindLaterFormat.Days
            AutoUpdater.RemindLaterAt = 7
            AutoUpdater.UpdateFormSize = New System.Drawing.Size(800, 600)
            AutoUpdater.PersistenceProvider = New JsonFilePersistenceProvider(_SettingsPath)
            AutoUpdater.Start("https:/crapmybrainsays.com/updates/DnD5eCharacterTracker.xml")
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally

        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CloseCampaign()

        Try
            If Me.LabelCampaignHeader.Visible = True Then Me.LabelCampaignHeader.Visible = False
            If Me.LabelCharactersHeader.Visible = True Then Me.LabelCharactersHeader.Visible = False
            If Me.ButtonCharacterAdd.Visible = True Then Me.ButtonCharacterAdd.Visible = False
            If Me.ButtonCharacterDelete.Visible = True Then Me.ButtonCharacterDelete.Visible = False
            With Me.PanelCharacters
                If .Visible = True Then .Visible = False
                If .Controls.Count > 0 Then .Controls.Clear()
            End With
            With Me.ListViewCharacters
                If .Visible = True Then .Visible = False
                If .Items.Count > 0 Then .Items.Clear()
                If .Groups.Count > 0 Then .Groups.Clear()
            End With
            _Campaign = Nothing
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub DeleteCharacter()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _SQLiteReader As System.Data.SQLite.SQLiteDataReader = Nothing
        Dim _SQLiteAdapter As System.Data.SQLite.SQLiteDataAdapter = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _DialogResult As System.Windows.Forms.DialogResult = Nothing
        Dim _SelectedCharacter As System.Int32 = 0

        Try
            If Me.ListViewCharacters.SelectedItems.Count > 0 Then
                _DialogResult = MessageBox.Show(System.String.Format("Are you sure you want To remove the character '{0}'?", Me.ListViewCharacters.SelectedItems(0).SubItems(1).Text.ToString), "Character Tracker Says ...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If _DialogResult = System.Windows.Forms.DialogResult.Yes Then
                    _SelectedCharacter = Convert.ToInt32(Me.ListViewCharacters.SelectedItems(0).SubItems(0).Text.ToString)
                    If _SQLiteConnect IsNot Nothing Then
                        If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                            Using _SQLiteConnect
                                With _QueryString
                                    .Clear()
                                    .Append("DELETE FROM characters WHERE id=@id")
                                End With
                                _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                                With _SQLiteCommand
                                    '[ Add Parameter Values. ]
                                    .Parameters.AddWithValue("@id", _SelectedCharacter)
                                    '[ Execute INSERT or UPDATE query. ]
                                    .ExecuteNonQuery()
                                    '[ Clear Parameter Values. ]
                                    If .Parameters.Count > 0 Then .Parameters.Clear()
                                End With
                            End Using
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            If _QueryString IsNot Nothing Then
                _QueryString.Clear()
                _QueryString = Nothing
            End If
            If _SQLiteAdapter IsNot Nothing Then _SQLiteAdapter.Dispose()
            If _SQLiteReader IsNot Nothing Then _SQLiteReader.Dispose()
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
            LoadCampaign()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub GotoGettingStarted()

        System.Diagnostics.Process.Start("https://github.com/raineym/DnD5eCharacterTracker/wiki/Getting-Started")

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub GotoReleaseNotes()

        System.Diagnostics.Process.Start("https://github.com/raineym/DnD5eCharacterTracker/wiki/Release-Notes")

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub GotoReportBug()

        System.Diagnostics.Process.Start("https://github.com/raineym/DnD5eCharacterTracker/issues")

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub GotoWiki()

        System.Diagnostics.Process.Start("https://github.com/raineym/DnD5eCharacterTracker/wiki")

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub DuplicateCharacter()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _SQLiteReader As System.Data.SQLite.SQLiteDataReader = Nothing
        Dim _SQLiteAdapter As System.Data.SQLite.SQLiteDataAdapter = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _SelectedCharacter As System.Int32 = 0
        Dim _DuplicatedCharacter As System.Int32 = 0

        Try
            If Me.ListViewCharacters.SelectedItems.Count > 0 Then
                _SelectedCharacter = Convert.ToInt32(Me.ListViewCharacters.SelectedItems(0).SubItems(0).Text.ToString)
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("CREATE TEMPORARY TABLE tmp AS SELECT * FROM characters WHERE id = @id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@id", _SelectedCharacter)
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                                '[ Clear Parameter Values. ]
                                If .Parameters.Count > 0 Then .Parameters.Clear()
                            End With
                            With _QueryString
                                .Clear()
                                .Append("UPDATE tmp SET id = NULL, datecreated=CURRENT_TIMESTAMP, datemodified=CURRENT_TIMESTAMP")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                            End With
                            With _QueryString
                                .Clear()
                                .Append("INSERT INTO characters SELECT * FROM tmp")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                            End With
                            With _QueryString
                                .Clear()
                                .Append("DROP TABLE tmp")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                            End With
                            With _QueryString
                                .Clear()
                                .Append(System.String.Format("SELECT seq FROM sqlite_sequence WHERE name={0}characters{0}", Chr(34)))
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Execute Single-Value SELECT query. ]
                                _DuplicatedCharacter = .ExecuteScalar()
                            End With
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET uuid=@uuid, name=name || ' [Duplicate]' WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@uuid", GenerateUUID.ToString)
                                .Parameters.AddWithValue("@id", _SelectedCharacter)
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                                '[ Clear Parameter Values. ]
                                If .Parameters.Count > 0 Then .Parameters.Clear()
                            End With
                        End Using
                    End If
                End If
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            If _QueryString IsNot Nothing Then
                _QueryString.Clear()
                _QueryString = Nothing
            End If
            If _SQLiteAdapter IsNot Nothing Then _SQLiteAdapter.Dispose()
            If _SQLiteReader IsNot Nothing Then _SQLiteReader.Dispose()
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
            LoadCampaign()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub LoadCampaign()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _SQLiteReader As System.Data.SQLite.SQLiteDataReader = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _ListViewItem As System.Windows.Forms.ListViewItem = Nothing
        Dim _CampaignName As System.String = System.String.Empty
        Dim _Characters As System.Int32 = 0
        Dim _TotalPartyLevel As System.Int32 = 0

        Try
            If Me.LabelCampaignHeader.Visible = False Then Me.LabelCampaignHeader.Visible = True
            If Me.LabelCharactersHeader.Visible = False Then Me.LabelCharactersHeader.Visible = True
            If Me.ButtonCharacterAdd.Visible = False Then Me.ButtonCharacterAdd.Visible = True
            If Me.ButtonCharacterDelete.Visible = False Then Me.ButtonCharacterDelete.Visible = True
            With Me.PanelCharacters
                If .Visible = False Then .Visible = True
                If .Controls.Count > 0 Then .Controls.Clear()
            End With
            With Me.ListViewCharacters
                If .Visible = False Then .Visible = True
                If .Items.Count > 0 Then .Items.Clear()
                If .Groups.Count > 0 Then .Groups.Clear()
            End With
            If _SQLiteConnect IsNot Nothing Then
                If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                    Using _SQLiteConnect
                        '[ Get character data for selected campaign. ]
                        With _QueryString
                            .Clear()
                            .Append("SELECT id, name, player FROM characters WHERE campaignid=@cid ORDER BY name DESC;")
                        End With
                        _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                        With _SQLiteCommand
                            '[ Add Parameter Values. ]
                            .Parameters.AddWithValue("@cid", _Campaign("id"))
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
                                        _ListViewItem.SubItems.AddRange(New String() { .Item("name"), .Item("player")})
                                        _ListViewItem.BackColor = IIf(_Characters Mod 2 <> 0, System.Drawing.Color.FromArgb(224, 224, 224), System.Drawing.Color.White)
                                        Me.ListViewCharacters.Items.Add(_ListViewItem)
                                        _Characters += 1
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
            Me.ListViewCharacters.TileSize = New System.Drawing.Size(256, 38)
            If Me.ListViewCharacters.Items.Count > 10 Then
                Me.ListViewCharacters.TileSize = New System.Drawing.Size(236, 38)
            End If
            Me.LabelCampaignHeader.Text = System.String.Format(Me.LabelCampaignHeader.Tag, _Campaign("name"), _Campaign("gamemaster"))
            Me.LabelCharactersHeader.Text = System.String.Format(Me.LabelCharactersHeader.Tag, _Characters.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub LoadCharacterPanel()

        Try
            If Me.ListViewCharacters.SelectedItems.Count > 0 Then
                If _Campaign.ContainsKey("character") Then
                    _Campaign("character") = Me.ListViewCharacters.SelectedItems(0).SubItems(0).Text
                Else
                    _Campaign.Add("character", Me.ListViewCharacters.SelectedItems(0).SubItems(0).Text)
                End If
                With Me.PanelCharacters
                    If .Controls.Count > 0 Then
                        For Each _Control As Control In .Controls
                            _Control.Dispose()
                        Next
                    End If
                    .Controls.Add(New UserControlCharacterProperties)
                End With
            End If
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub OpenAboutWindow()

        Dim _FormAbout As New FormAbout

        Try
            With _FormAbout
                .Tag = Nothing
                .ShowDialog()
            End With
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub OpenCampaignPropertiesWindow()

        Dim _FormCampaignProperties As New FormCampaignProperties

        Try
            With _FormCampaignProperties
                .Tag = Nothing
                .ShowDialog()
            End With
            Me.LabelCampaignHeader.Text = System.String.Format(Me.LabelCampaignHeader.Tag, _Campaign("name"), _Campaign("gamemaster"))
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub OpenLoadCampaignForm()

        Dim _FormLoadCampaign As New FormLoadCampaign

        Try
            With _FormLoadCampaign
                .Tag = Nothing
                .ShowDialog()
            End With
            If _Campaign IsNot Nothing Then LoadCampaign()
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub OpenMoveCharacterWindow()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _SQLiteReader As System.Data.SQLite.SQLiteDataReader = Nothing
        Dim _SQLiteAdapter As System.Data.SQLite.SQLiteDataAdapter = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _Campaigns As System.Int32 = 0
        Dim _FormMoveCharacter As New FormMoveCharacter

        Try
            If _SQLiteConnect IsNot Nothing Then
                If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                    Using _SQLiteConnect
                        With _QueryString
                            .Clear()
                            .Append("SELECT COUNT(*) AS count FROM campaigns WHERE id <> @id")
                        End With
                        _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                        With _SQLiteCommand
                            '[ Add Parameter Values. ]
                            .Parameters.AddWithValue("@id", _Campaign("id"))
                            '[ Execute Single-Value SELECT query. ]
                            _Campaigns = .ExecuteScalar()
                            '[ Clear Parameter Values. ]
                            If .Parameters.Count > 0 Then .Parameters.Clear()
                        End With
                    End Using
                End If
            End If
            If _Campaigns > 0 Then
                With _FormMoveCharacter
                    .Tag = Nothing
                    .ShowDialog()
                End With
                If _Campaign IsNot Nothing Then LoadCampaign()
            Else
                MessageBox.Show("There are no campaigns to move the selected character to.", "Character Tracker Says ...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub OpenNewCampaignWindow()

        Dim _FormNewCampaign As New FormNewCampaign

        Try
            With _FormNewCampaign
                .Tag = Nothing
                .ShowDialog()
            End With
            If _Campaign IsNot Nothing Then LoadCampaign()
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub OpenRemoveCampaignForm()

        Dim _FormRemoveCampaign As New FormRemoveCampaign

        Try
            With _FormRemoveCampaign
                .Tag = Nothing
                .ShowDialog()
            End With
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub RestoreDatabase()

        Dim _ZipEntry As Ionic.Zip.ZipEntry
        Dim _DialogResult As System.Windows.Forms.DialogResult = Nothing
        Dim _Database As String = System.String.Format("{0}\data.db3", APPDEFAULTDATAPATH)

        Try
            _DialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to restore the database? This will overwrite all data. This operation cannot be undone.", "Character Tracker Says ...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If _DialogResult = System.Windows.Forms.DialogResult.Yes Then
                Using _OpenFileDialog As New System.Windows.Forms.OpenFileDialog
                    With _OpenFileDialog
                        .AddExtension = False
                        .Filter = "Zip Files (*.zip)|*.zip|All Files (*.*)|*.*"
                        .FilterIndex = 0
                        .Multiselect = False
                        .RestoreDirectory = True
                        .SupportMultiDottedExtensions = True
                        .Title = "Choose Backup File"
                        If System.IO.Directory.Exists(System.String.Format("{0}\Backup", APPDEFAULTDATAPATH)) Then
                            .InitialDirectory = System.String.Format("{0}\Backup", APPDEFAULTDATAPATH)
                        Else
                            .InitialDirectory = System.Windows.Forms.Application.StartupPath
                        End If
                        If .ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            If System.IO.File.Exists(_Database) Then
                                My.Computer.FileSystem.RenameFile(_Database, "data.db3.old")
                            End If
                            Using _ZipFile As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(.FileName)
                                For Each _ZipEntry In _ZipFile
                                    _ZipEntry.Extract(APPDEFAULTDATAPATH, ExtractExistingFileAction.OverwriteSilently)
                                Next
                            End Using
                        End If
                    End With
                End Using
                If System.IO.File.Exists(_Database) Then
                    If System.IO.File.Exists(System.String.Format("{0}\data.db3.old", APPDEFAULTDATAPATH)) Then
                        My.Computer.FileSystem.DeleteFile(System.String.Format("{0}\data.db3.old", APPDEFAULTDATAPATH))
                    End If
                    System.Windows.Forms.MessageBox.Show("Restore Successful.", "Character Tracker Says ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    If System.IO.File.Exists(System.String.Format("{0}\data.db3.old", APPDEFAULTDATAPATH)) Then
                        My.Computer.FileSystem.RenameFile(System.String.Format("{0}\data.db3.old", APPDEFAULTDATAPATH), "data.db3")
                    End If
                    System.Windows.Forms.MessageBox.Show("Restore Unsuccessful.", "Character Tracker Says ...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            End If
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub UpdateDatabase()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _SQLiteReader As System.Data.SQLite.SQLiteDataReader = Nothing
        Dim _SQLiteAdapter As System.Data.SQLite.SQLiteDataAdapter = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _Version110 As System.Int32 = 0

        Try
            If _SQLiteConnect IsNot Nothing Then
                If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                    Using _SQLiteConnect
                        '[ Check For Version 1.1.0 of the database. ]
                        With _QueryString
                            .Clear()
                            .Append("SELECT count(*) AS VERSION110 FROM sqlite_master WHERE type='table' AND name='metadata'")
                        End With
                        _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                        With _SQLiteCommand
                            '[ Execute Single-Value SELECT query. ]
                            _Version110 = .ExecuteScalar()
                        End With
                        '[ Update database to Version 1.1.0. ]
                        If Convert.ToBoolean(_Version110) = False Then
                            With _QueryString
                                .Clear()
                                .Append("ALTER TABLE characters ADD COLUMN deathsavesuccess INTEGER NOT NULL DEFAULT 0")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                            End With
                            With _QueryString
                                .Clear()
                                .Append("ALTER TABLE characters ADD COLUMN deathsavefailure INTEGER NOT NULL DEFAULT 0")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                            End With
                            With _QueryString
                                .Clear()
                                .Append("CREATE TABLE metadata (version TEXT)")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                            End With
                            With _QueryString
                                .Clear()
                                .Append("UPDATE metadata SET version=@version")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@version", PROGRAMBUILD)
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                                '[ Clear Parameter Values. ]
                                If .Parameters.Count > 0 Then .Parameters.Clear()
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
            If _SQLiteAdapter IsNot Nothing Then _SQLiteAdapter.Dispose()
            If _SQLiteReader IsNot Nothing Then _SQLiteReader.Dispose()
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

#End Region

#Region " Common Form Functions "



#End Region

#Region " Structures "


#End Region

End Class