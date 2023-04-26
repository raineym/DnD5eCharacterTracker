Public Class FormNewCampaign

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

    Private Sub FormNewCampaign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '[ Hide the form to make sure everything on the form loads before presenting it to the user. ]
            With Me
                .Hide()
                .Visible = False
            End With

            

            '[ Make controls look pretty on this form only. ]
            FormatControls()

            '[ Lastly, Add Event Handlers. ]
            AddHandler Me.ButtonNewCampaignCancel.Click, AddressOf CloseForm
            AddHandler Me.ButtonNewCampaignSave.Click, AddressOf SaveCampaign
            AddHandler Me.TextBoxNewCampaignName.TextChanged, AddressOf FormDirty
            AddHandler Me.TextBoxNewCampaignGamemaster.TextChanged, AddressOf FormDirty

        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            With Me
                '[ Display the form to the user. ]
                .Visible = True
                .Show()
            End With
            _IsDirty = False
            _IsLoaded = True
        End Try

    End Sub

#End Region

#Region " Common Form Procedures "

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CloseForm()

        Dim _DialogResult As System.Windows.Forms.DialogResult = Nothing

        Try
            If _IsDirty = True Then
                _DialogResult = System.Windows.Forms.MessageBox.Show("Do you want to save the changes to the campaign properties?", "Character Tracker Says ...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If _DialogResult = System.Windows.Forms.DialogResult.Yes Then
                    SaveCampaign()
                End If
            End If
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
            .Text = System.String.Format("{0}", "New Campaign")
            .BackColor = System.Drawing.Color.FromArgb(255, 255, 248)
            .ControlBox = True
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
            .FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            .Icon = New System.Drawing.Icon(System.String.Format("{0}\default.ico", System.Windows.Forms.Application.StartupPath))
            .MaximumSize = New System.Drawing.Size(600, 165)
            .MaximizeBox = False
            .MinimumSize = New System.Drawing.Size(600, 165)
            .MinimizeBox = False
            .Size = New System.Drawing.Size(600, 165)
            .SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            .ShowInTaskbar = False
            .Location = New System.Drawing.Point((_Screen.WorkingArea.Width - Me.Width) / 2, (_Screen.WorkingArea.Height - Me.Height) / 2)
        End With

        '[ LabelNewCampaignName ]
        With Me.LabelNewCampaignName
            .Text = System.String.Format("{0}", "Campaign Name:*")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ LabelNewCampaignGamemaster ]
        With Me.LabelNewCampaignGamemaster
            .Text = System.String.Format("{0}", "Gamemaster:")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ LabelNewCampaignGamemaster ]
        With Me.LabelNewCampaignRequired
            .Text = System.String.Format("{0}", "* Required Field")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 8.25, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleRight
        End With

        '[ TextBoxNewCampaignName ]
        With Me.TextBoxNewCampaignName
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With

        '[ TextBoxNewCampaignGamemaster]
        With Me.TextBoxNewCampaignGamemaster
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With

        '[ ButtonNewCampaignCancel ]
        With Me.ButtonNewCampaignCancel
            .Text = System.String.Format("{0}", "Cancel")
            .BackColor = System.Drawing.Color.White
            .Cursor = System.Windows.Forms.Cursors.Default
            .FlatStyle = System.Windows.Forms.FlatStyle.System
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Size = New System.Drawing.Size(75, 28)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ ButtonNewCampaignSave ]
        With Me.ButtonNewCampaignSave
            .Text = System.String.Format("{0}", "Save")
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
    Private Sub FormDirty()

        Try
            If _IsLoaded = True Then
                If _IsDirty = False Then _IsDirty = True
            End If
        Catch ex As Exception
            _IsDirty = True
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCampaign()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _CampaignID As System.Int32 = 0

        Try
            If String.IsNullOrEmpty(Me.TextBoxNewCampaignName.Text.ToString) Or Me.TextBoxNewCampaignName.Text.Length < 1 Then
                MessageBox.Show("Campaign Name cannot be left blank.", "Character Tracker Says ...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If _SQLiteConnect IsNot Nothing Then
                If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                    Using _SQLiteConnect
                        With _QueryString
                            .Clear()
                            .Append("INSERT INTO campaigns (uuid, name, gamemaster) VALUES (@uuid, @name, @gamemaster)")
                        End With
                        _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                        With _SQLiteCommand
                            '[ Add Parameter Values. ]
                            .Parameters.AddWithValue("@uuid", GenerateUUID)
                            .Parameters.AddWithValue("@name", Me.TextBoxNewCampaignName.Text.ToString)
                            .Parameters.AddWithValue("@gamemaster", Me.TextBoxNewCampaignGamemaster.Text.ToString)
                            '[ Execute INSERT or UPDATE query. ]
                            .ExecuteNonQuery()
                            '[ Clear Parameter Values. ]
                            If .Parameters.Count > 0 Then .Parameters.Clear()
                        End With
                        With _QueryString
                            .Clear()
                            .Append(System.String.Format("SELECT seq FROM sqlite_sequence WHERE name={0}campaigns{0}", Chr(34)))
                        End With
                        _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                        With _SQLiteCommand
                            '[ Add Parameter Values. ]
                            .Parameters.AddWithValue("@uuid", GenerateUUID)
                            .Parameters.AddWithValue("@name", Me.TextBoxNewCampaignName.Text.ToString)
                            .Parameters.AddWithValue("@gamemaster", Me.TextBoxNewCampaignGamemaster.Text.ToString)
                            '[ Execute INSERT or UPDATE query. ]
                            _CampaignID = .ExecuteScalar()
                            '[ Clear Parameter Values. ]
                            If .Parameters.Count > 0 Then .Parameters.Clear()
                        End With
                        _Campaign = New Dictionary(Of String, String)
                        _Campaign("id") = _CampaignID
                        _Campaign("name") = Me.TextBoxNewCampaignName.Text.ToString
                        _Campaign("gamemaster") = Me.TextBoxNewCampaignGamemaster.Text.ToString
                    End Using
                End If
            End If
            _IsDirty = False
            CloseForm()
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
            _IsDirty = True
        Finally
            If _QueryString IsNot Nothing Then
                _QueryString.Clear()
                _QueryString = Nothing
            End If
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

#End Region

#Region " Common Form Functions "



#End Region

End Class
