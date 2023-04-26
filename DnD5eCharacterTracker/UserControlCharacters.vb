Public Class UserControlCharacterProperties

#Region " Constants "



#End Region

#Region " Variables "

    '[ Used to load various settings before control events fire. ]
    Private _IsLoaded As Boolean = False

#End Region

#Region " Form And Control Procedures "

    Private Sub UserControlCharacterProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '[ Hide the form to make sure everything on the form loads before presenting it to the user. ]
            With Me
                .Hide()
                .Visible = False
            End With

            LoadCharacter()

            '[ Make controls look pretty on this form only. ]
            FormatControls()

            '[ Lastly, Add Event Handlers. ]
            AddHandler Me.TextBoxExtCharactersName.KeyUp, AddressOf SaveCharacterName
            AddHandler Me.TextBoxExtCharactersName.Leave, AddressOf SaveCharacterName
            AddHandler Me.TextBoxExtCharactersPlayer.KeyUp, AddressOf SavePlayerName
            AddHandler Me.TextBoxExtCharactersPlayer.Leave, AddressOf SavePlayerName
            AddHandler Me.TextBoxExtCharactersClass.KeyUp, AddressOf SaveCharacterClass
            AddHandler Me.TextBoxExtCharactersClass.Leave, AddressOf SaveCharacterClass
            AddHandler Me.TextBoxExtCharactersLevel.KeyUp, AddressOf SaveCharacterLevel
            AddHandler Me.TextBoxExtCharactersLevel.Leave, AddressOf SaveCharacterLevel
            AddHandler Me.TextBoxExtCharactersRace.KeyUp, AddressOf SaveCharacterRace
            AddHandler Me.TextBoxExtCharactersRace.Leave, AddressOf SaveCharacterRace
            AddHandler Me.TextBoxExtCharactersBackground.KeyUp, AddressOf SaveCharacterBackground
            AddHandler Me.TextBoxExtCharactersBackground.Leave, AddressOf SaveCharacterBackground
            AddHandler Me.TextBoxExtCharactersAlignment.KeyUp, AddressOf SaveCharacterAlignment
            AddHandler Me.TextBoxExtCharactersAlignment.Leave, AddressOf SaveCharacterAlignment
            AddHandler Me.TextBoxExtCharactersLanguages.KeyUp, AddressOf SaveCharacterLanguages
            AddHandler Me.TextBoxExtCharactersLanguages.Leave, AddressOf SaveCharacterLanguages
            AddHandler Me.NumericUpDownExtCharactersInitiative.ValueChanged, AddressOf SaveCharacterInitiative
            AddHandler Me.NumericUpDownExtCharactersAC.ValueChanged, AddressOf SaveCharacterAC
            AddHandler Me.NumericUpDownExtCharactersHitPointsMax.ValueChanged, AddressOf SaveCharacterHPMax
            AddHandler Me.NumericUpDownExtCharactersHitPointsCurrent.ValueChanged, AddressOf SaveCharacterHPCurrent
            AddHandler Me.NumericUpDownExtCharactersStrength.ValueChanged, AddressOf SaveCharacterStrength
            AddHandler Me.NumericUpDownExtCharactersDexterity.ValueChanged, AddressOf SaveCharacterDexterity
            AddHandler Me.NumericUpDownExtCharactersConstitution.ValueChanged, AddressOf SaveCharacterConstitution
            AddHandler Me.NumericUpDownExtCharactersIntelligence.ValueChanged, AddressOf SaveCharacterIntelligence
            AddHandler Me.NumericUpDownExtCharactersWisdom.ValueChanged, AddressOf SaveCharacterWisdom
            AddHandler Me.NumericUpDownExtCharactersCharisma.ValueChanged, AddressOf SaveCharacterCharisma
            AddHandler Me.NumericUpDownExtCharactersPerception.ValueChanged, AddressOf SaveCharacterPerception
            AddHandler Me.NumericUpDownExtCharactersInsight.ValueChanged, AddressOf SaveCharacterInsight
            AddHandler Me.NumericUpDownExtCharactersSpellSaveDC.ValueChanged, AddressOf SaveCharacterSpellSaveDC
            AddHandler Me.NumericUpDownExtCharactersSpeedWalk.ValueChanged, AddressOf SaveCharacterSpeedWalk
            AddHandler Me.NumericUpDownExtCharactersSpeedBurrow.ValueChanged, AddressOf SaveCharacterSpeedBurrow
            AddHandler Me.NumericUpDownExtCharactersSpeedClimb.ValueChanged, AddressOf SaveCharacterSpeedClimb
            AddHandler Me.NumericUpDownExtCharactersSpeedFly.ValueChanged, AddressOf SaveCharacterSpeedFly
            AddHandler Me.NumericUpDownExtCharactersSpeedSwim.ValueChanged, AddressOf SaveCharacterSpeedSwim
            AddHandler Me.ContextMenuStripCharactersPortraitItemChange.Click, AddressOf ChangePortrait
            AddHandler Me.ContextMenuStripCharactersPortraitItemReset.Click, AddressOf RemovePortrait

        Catch ex As Exception
            'ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            With Me
                '[ Display the form to the user. ]
                .Visible = True
                .Show()
            End With
            _IsLoaded = True
        End Try

    End Sub

#End Region

#Region " Common User Control Procedures "

    Private Sub FormatControls()

        '[ Me ]
        With Me
            .BackColor = System.Drawing.Color.FromArgb(255, 255, 248)
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
            .MaximumSize = New System.Drawing.Size(694, 620)
            .MinimumSize = New System.Drawing.Size(694, 620)
            .Size = New System.Drawing.Size(694, 620)
        End With

        '[ LabelCharactersName ]
        With Me.LabelCharactersName
            .Text = System.String.Format("{0}", "Character Name:")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ LabelCharactersPlayer ]
        With Me.LabelCharactersPlayer
            .Text = System.String.Format("{0}", "Player Name:")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ LabelCharactersClass ]
        With Me.LabelCharactersClass
            .Text = System.String.Format("{0}", "Class(es):")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ LabelCharactersLevel ]
        With Me.LabelCharactersLevel
            .Text = System.String.Format("{0}", "Level(s):")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ LabelCharactersRace ]
        With Me.LabelCharactersRace
            .Text = System.String.Format("{0}", "Race:")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ LabelCharactersBackground ]
        With Me.LabelCharactersBackground
            .Text = System.String.Format("{0}", "Background:")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ LabelCharactersAlignment ]
        With Me.LabelCharactersAlignment
            .Text = System.String.Format("{0}", "Alignment:")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ LabelCharactersInitiative ]
        With Me.LabelCharactersInitiative
            .Text = System.String.Format("{0}", "Initiative")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersAC ]
        With Me.LabelCharactersAC
            .Text = System.String.Format("{0}", "Armor Class")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersHitPoints ]
        With Me.LabelCharactersHitPoints
            .Text = System.String.Format("{0}", "Hit Points")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersHItPointsMax ]
        With Me.LabelCharactersHitPointsMax
            .Text = System.String.Format("{0}", "Maximum")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 6.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersJitPointsCurrent ]
        With Me.LabelCharactersHitPointsCurrent
            .Text = System.String.Format("{0}", "Initiative")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 6.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersStrength ]
        With Me.LabelCharactersStrength
            .Text = System.String.Format("{0}", "Strength")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersDexterity ]
        With Me.LabelCharactersDexterity
            .Text = System.String.Format("{0}", "Dexterity")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersConstitution ]
        With Me.LabelCharactersConstitution
            .Text = System.String.Format("{0}", "Constitution")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersIntelligence ]
        With Me.LabelCharactersIntelligence
            .Text = System.String.Format("{0}", "Intelligence")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersWisdom ]
        With Me.LabelCharactersWisdom
            .Text = System.String.Format("{0}", "Wisdom")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersCharisma ]
        With Me.LabelCharactersCharisma
            .Text = System.String.Format("{0}", "Charisma")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersPerception ]
        With Me.LabelCharactersPerception
            .Text = System.String.Format("{0}", "Passive Perception:")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ LabelCharactersInsight ]
        With Me.LabelCharactersInsight
            .Text = System.String.Format("{0}", "Passive Insight:")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ LabelCharactersSpellSaveDC ]
        With Me.LabelCharactersSpellSaveDC
            .Text = System.String.Format("{0}", "Spell Save DC:")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ LabelCharactersPortrait ]
        With Me.LabelCharactersPortrait
            .Text = System.String.Format("{0}", "Portrait or Insignia")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersSpeed ]
        With Me.LabelCharactersSpeed
            .Text = System.String.Format("{0}", "Speeds")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersSpeedWalk ]
        With Me.LabelCharactersSpeedWalk
            .Text = System.String.Format("{0}", "Walk")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 6.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersSpeedBurrow ]
        With Me.LabelCharactersSpeedBurrow
            .Text = System.String.Format("{0}", "Burrow")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 6.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersSpeedClimb ]
        With Me.LabelCharactersSpeedClimb
            .Text = System.String.Format("{0}", "Climb")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 6.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersSpeedFly ]
        With Me.LabelCharactersSpeedFly
            .Text = System.String.Format("{0}", "Fly")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 6.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersSpeedSwim ]
        With Me.LabelCharactersSpeedSwim
            .Text = System.String.Format("{0}", "Swim")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 6.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersLanguages ]
        With Me.LabelCharactersLanguages
            .Text = System.String.Format("{0}", "Languages")
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelCharactersUUID ]
        With Me.LabelCharactersUUID
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 8.25, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        End With

        '[ TextBoxExtCharactersName ]
        With Me.TextBoxExtCharactersName
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Colorful
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            .ThemeStyle.Font = .Font
            .ThemeStyle.ForeColor = Me.ForeColor
        End With

        '[ TextBoxExtCharactersPlayer ]
        With Me.TextBoxExtCharactersPlayer
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Colorful
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            .ThemeStyle.Font = .Font
            .ThemeStyle.ForeColor = Me.ForeColor
        End With

        '[ TextBoxExtCharactersClas ]
        With Me.TextBoxExtCharactersClass
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Colorful
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            .ThemeStyle.Font = .Font
            .ThemeStyle.ForeColor = Me.ForeColor
        End With

        '[ TextBoxExtCharactersLevel ]
        With Me.TextBoxExtCharactersLevel
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Colorful
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            .ThemeStyle.Font = .Font
            .ThemeStyle.ForeColor = Me.ForeColor
        End With

        '[ TextBoxExtCharactersRace ]
        With Me.TextBoxExtCharactersRace
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Colorful
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            .ThemeStyle.Font = .Font
            .ThemeStyle.ForeColor = Me.ForeColor
        End With

        '[ TextBoxExtCharactersBackground ]
        With Me.TextBoxExtCharactersBackground
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Colorful
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            .ThemeStyle.Font = .Font
            .ThemeStyle.ForeColor = Me.ForeColor
        End With

        '[ TextBoxExtCharactersAlignment]
        With Me.TextBoxExtCharactersAlignment
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Colorful
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            .ThemeStyle.Font = .Font
            .ThemeStyle.ForeColor = Me.ForeColor
        End With

        '[ TextBoxExtCharactersLanguages]
        With Me.TextBoxExtCharactersLanguages
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2016Colorful
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            .ThemeStyle.Font = .Font
            .ThemeStyle.ForeColor = Me.ForeColor
        End With

        '[ NumericUpDownExtCharactersInitiative ]
        With Me.NumericUpDownExtCharactersInitiative
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 20.25, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersAC ]
        With Me.NumericUpDownExtCharactersAC
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 20.25, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersHitPointsMax ]
        With Me.NumericUpDownExtCharactersHitPointsMax
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 20.25, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersHitPointsCurrent ]
        With Me.NumericUpDownExtCharactersHitPointsCurrent
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 20.25, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersStrength ]
        With Me.NumericUpDownExtCharactersStrength
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 15.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersDexterity ]
        With Me.NumericUpDownExtCharactersDexterity
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 15.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersConstitution ]
        With Me.NumericUpDownExtCharactersConstitution
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 15.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersIntelligence ]
        With Me.NumericUpDownExtCharactersIntelligence
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 15.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersWisdom ]
        With Me.NumericUpDownExtCharactersWisdom
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 15.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersCharisma ]
        With Me.NumericUpDownExtCharactersCharisma
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 15.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersPerception ]
        With Me.NumericUpDownExtCharactersPerception
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersInsight ]
        With Me.NumericUpDownExtCharactersInsight
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersSpellSaveDC ]
        With Me.NumericUpDownExtCharactersSpellSaveDC
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersSpeedWalk ]
        With Me.NumericUpDownExtCharactersSpeedWalk
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersSpeedBurrow ]
        With Me.NumericUpDownExtCharactersSpeedBurrow
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersSpeedClimb ]
        With Me.NumericUpDownExtCharactersSpeedClimb
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersSpeedFly ]
        With Me.NumericUpDownExtCharactersSpeedFly
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ NumericUpDownExtCharactersSpeedSwim ]
        With Me.NumericUpDownExtCharactersSpeedSwim
            .BackColor = System.Drawing.Color.White
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            .ThemesEnabled = True
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        End With

        '[ PictureBoxCharactersPortrait ]
        With Me.PictureBoxCharactersPortrait
            .BackColor = System.Drawing.Color.White
            .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            .ContextMenuStrip = ContextMenuStripCharactersPortrait
            .SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        End With

    End Sub

#End Region

#Region " Other User Control Procedures "

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CalculateModifiers()

        Dim _Strength As System.Int32
        Dim _Dexterity As System.Int32
        Dim _Constitution As System.Int32
        Dim _Intelligence As System.Int32
        Dim _Wisdom As System.Int32
        Dim _Charisma As System.Int32

        Try
            _Strength = Math.Floor((Me.NumericUpDownExtCharactersStrength.Value - 10) / 2)
            _Dexterity = Math.Floor((Me.NumericUpDownExtCharactersDexterity.Value - 10) / 2)
            _Constitution = Math.Floor((Me.NumericUpDownExtCharactersConstitution.Value - 10) / 2)
            _Intelligence = Math.Floor((Me.NumericUpDownExtCharactersIntelligence.Value - 10) / 2)
            _Wisdom = Math.Floor((Me.NumericUpDownExtCharactersWisdom.Value - 10) / 2)
            _Charisma = Math.Floor((Me.NumericUpDownExtCharactersCharisma.Value - 10) / 2)

            Me.LabelCharactersStrengthModifier.Text = System.String.Format("{0}{1}", IIf(_Strength > -1, "+", System.String.Empty), _Strength)
            Me.LabelCharactersDexterityModifier.Text = System.String.Format("{0}{1}", IIf(_Dexterity > -1, "+", System.String.Empty), _Dexterity)
            Me.LabelCharactersConstitutionModifier.Text = System.String.Format("{0}{1}", IIf(_Constitution > -1, "+", System.String.Empty), _Constitution)
            Me.LabelCharactersIntelligenceModifier.Text = System.String.Format("{0}{1}", IIf(_Intelligence > -1, "+", System.String.Empty), _Intelligence)
            Me.LabelCharactersWisdomModifier.Text = System.String.Format("{0}{1}", IIf(_Wisdom > -1, "+", System.String.Empty), _Wisdom)
            Me.LabelCharactersCharismaModifier.Text = System.String.Format("{0}{1}", IIf(_Charisma > -1, "+", System.String.Empty), _Charisma)
        Catch ex As System.Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ChangePortrait()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _SQLiteReader As System.Data.SQLite.SQLiteDataReader = Nothing
        Dim _SQLiteAdapter As System.Data.SQLite.SQLiteDataAdapter = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _NewPicture As System.String = String.Empty

        Try
            Using _OpenFileDialog As New System.Windows.Forms.OpenFileDialog
                With _OpenFileDialog
                    .AddExtension = False
                    .Filter = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders().Aggregate("All Files (*.*)|*.*", Function(s, c) $"{s}|{c.CodecName.Substring(8).Replace("Codec", "Files").Trim()} ({c.FilenameExtension})|{c.FilenameExtension}")
                    .FilterIndex = 0
                    .InitialDirectory = System.Windows.Forms.Application.StartupPath
                    .Multiselect = False
                    .RestoreDirectory = True
                    .SupportMultiDottedExtensions = True
                    .Title = "Choose Character Portrait or Insignia"
                    If .ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        _NewPicture = ImageToBase64(ResizeImage(CType(New System.Drawing.Bitmap(.FileName), System.Drawing.Image), New Size(322, 322), True))
                        If _SQLiteConnect IsNot Nothing Then
                            If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                                Using _SQLiteConnect
                                    With _QueryString
                                        .Clear()
                                        .Append("UPDATE characters SET portrait=@pic WHERE id=@id")
                                    End With
                                    _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                                    With _SQLiteCommand
                                        '[ Add Parameter Values. ]
                                        .Parameters.AddWithValue("@pic", _NewPicture)
                                        .Parameters.AddWithValue("@id", _Campaign("character"))
                                        '[ Execute INSERT or UPDATE query. ]
                                        .ExecuteNonQuery()
                                        '[ Clear Parameter Values. ]
                                        If .Parameters.Count > 0 Then .Parameters.Clear()
                                    End With
                                End Using
                            End If
                        End If
                        Me.PictureBoxCharactersPortrait.Image = Base64ToImage(_NewPicture)
                    End If
                End With
            End Using
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

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub LoadCharacter()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _SQLiteReader As System.Data.SQLite.SQLiteDataReader = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _SQLiteConnect IsNot Nothing Then
                If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                    Using _SQLiteConnect
                        With _QueryString
                            .Clear()
                            .Append("SELECT * FROM characters WHERE id=@id")
                        End With
                        _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                        With _SQLiteCommand
                            '[ Add Parameter Values. ]
                            .Parameters.AddWithValue("@id", _Campaign("character"))
                            '[ Execute Multi-Value SELECT query. ]
                            _SQLiteReader = .ExecuteReader()
                            '[ Clear Parameter Values. ]
                            If .Parameters.Count > 0 Then .Parameters.Clear()
                        End With
                        If _SQLiteReader IsNot Nothing Then
                            With _SQLiteReader
                                If .HasRows = True Then
                                    While .Read()
                                        Me.LabelCharactersUUID.Text = System.String.Format(Me.LabelCharactersUUID.Tag.ToString, .Item("uuid").ToString)
                                        Me.TextBoxExtCharactersName.Text = .Item("name").ToString
                                        Me.TextBoxExtCharactersPlayer.Text = .Item("player").ToString
                                        Me.TextBoxExtCharactersRace.Text = .Item("race").ToString
                                        Me.TextBoxExtCharactersClass.Text = .Item("class").ToString
                                        Me.TextBoxExtCharactersLevel.Text = .Item("level").ToString
                                        Me.TextBoxExtCharactersBackground.Text = .Item("background").ToString
                                        Me.TextBoxExtCharactersAlignment.Text = .Item("alignment").ToString
                                        Me.NumericUpDownExtCharactersInitiative.Value = System.Convert.ToInt32(.Item("initiative"))
                                        Me.NumericUpDownExtCharactersAC.Text = System.Convert.ToInt32(.Item("armorclass"))
                                        Me.NumericUpDownExtCharactersHitPointsMax.Text = System.Convert.ToInt32(.Item("hitpointsmax"))
                                        Me.NumericUpDownExtCharactersHitPointsCurrent.Text = System.Convert.ToInt32(.Item("hitpointscurrent"))
                                        Me.NumericUpDownExtCharactersStrength.Value = System.Convert.ToInt32(.Item("strength"))
                                        Me.NumericUpDownExtCharactersDexterity.Value = System.Convert.ToInt32(.Item("dexterity"))
                                        Me.NumericUpDownExtCharactersConstitution.Value = System.Convert.ToInt32(.Item("constitution"))
                                        Me.NumericUpDownExtCharactersIntelligence.Value = System.Convert.ToInt32(.Item("intelligence"))
                                        Me.NumericUpDownExtCharactersWisdom.Value = System.Convert.ToInt32(.Item("Wisdom"))
                                        Me.NumericUpDownExtCharactersCharisma.Value = System.Convert.ToInt32(.Item("charisma"))
                                        Me.NumericUpDownExtCharactersPerception.Value = System.Convert.ToInt32(.Item("perception"))
                                        Me.NumericUpDownExtCharactersInsight.Value = System.Convert.ToInt32(.Item("insight"))
                                        Me.NumericUpDownExtCharactersSpellSaveDC.Value = System.Convert.ToInt32(.Item("spellsavedc"))
                                        Me.NumericUpDownExtCharactersSpeedWalk.Value = System.Convert.ToInt32(.Item("speedwalk"))
                                        Me.NumericUpDownExtCharactersSpeedBurrow.Value = System.Convert.ToInt32(.Item("speedburrow"))
                                        Me.NumericUpDownExtCharactersSpeedClimb.Value = System.Convert.ToInt32(.Item("speedclimb"))
                                        Me.NumericUpDownExtCharactersSpeedFly.Value = System.Convert.ToInt32(.Item("speedfly"))
                                        Me.NumericUpDownExtCharactersSpeedSwim.Value = System.Convert.ToInt32(.Item("speedswim"))
                                        Me.TextBoxExtCharactersLanguages.Text = .Item("languages").ToString
                                        If .Item("portrait").ToString.Length > 0 Then
                                            Me.PictureBoxCharactersPortrait.Image = Base64ToImage(.Item("portrait").ToString)
                                        End If
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
            CalculateModifiers()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub RemovePortrait()

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
                            .Append("UPDATE characters SET portrait=NULL WHERE id=@id")
                        End With
                        _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                        With _SQLiteCommand
                            '[ Add Parameter Values. ]
                            .Parameters.AddWithValue("@id", _Campaign("character"))
                            '[ Execute INSERT or UPDATE query. ]
                            .ExecuteNonQuery()
                            '[ Clear Parameter Values. ]
                            If .Parameters.Count > 0 Then .Parameters.Clear()
                        End With
                    End Using
                End If
            End If
            Me.PictureBoxCharactersPortrait.Image = Nothing
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

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterAC()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET armorclass=@ac WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@ac", Me.NumericUpDownExtCharactersAC.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterAlignment()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET alignment=@align WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@align", Me.TextBoxExtCharactersAlignment.Text.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterBackground()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET background=@bkgnd WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@bkgnd", Me.TextBoxExtCharactersBackground.Text.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterCharisma()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET charisma=@cha WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@cha", Me.NumericUpDownExtCharactersCharisma.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
            CalculateModifiers()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterClass()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET class=@class WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@class", Me.TextBoxExtCharactersClass.Text.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterConstitution()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET constitution=@con WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@con", Me.NumericUpDownExtCharactersConstitution.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
            CalculateModifiers()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterDexterity()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET dexterity=@dex WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@dex", Me.NumericUpDownExtCharactersDexterity.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
            CalculateModifiers()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterHPCurrent()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET hitpointscurrent=@currenthp WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@currenthp", Me.NumericUpDownExtCharactersHitPointsCurrent.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterHPMax()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET hitpointsmax=@maxhp WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@maxhp", Me.NumericUpDownExtCharactersHitPointsMax.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterInitiative()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET initiative=@init WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@init", Me.NumericUpDownExtCharactersInitiative.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterInsight()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET insight=@insight WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@insight", Me.NumericUpDownExtCharactersInsight.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterIntelligence()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET intelligence=@int WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@", Me.NumericUpDownExtCharactersIntelligence.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
            CalculateModifiers()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterLanguages()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET languages=@lang WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@lang", Me.TextBoxExtCharactersLanguages.Text.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterLevel()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET level=@level WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@level", Me.TextBoxExtCharactersLevel.Text.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterName()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _ListViewItem As System.Windows.Forms.ListViewItem = Nothing

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET name=@name WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@name", Me.TextBoxExtCharactersName.Text.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                                '[ Clear Parameter Values. ]
                                If .Parameters.Count > 0 Then .Parameters.Clear()
                            End With
                        End Using
                    End If
                End If
                With FormMain.ListViewCharacters
                    .SelectedItems(0).SubItems(1).Text = Me.TextBoxExtCharactersName.Text.ToString
                    .Invalidate()
                End With
            End If

        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            If _QueryString IsNot Nothing Then
                _QueryString.Clear()
                _QueryString = Nothing
            End If
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterPerception()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET perception=@percept WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@percept", Me.NumericUpDownExtCharactersPerception.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterRace()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET race=@ace WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@race", Me.TextBoxExtCharactersRace.Text.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterSpellSaveDC()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET spellsavedc=@splsavedc WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@splsavedc", Me.NumericUpDownExtCharactersSpellSaveDC.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterSpeedBurrow()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET speedburrow=@burrow WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@burrow", Me.NumericUpDownExtCharactersSpeedBurrow.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterSpeedClimb()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET speedclimb=@climb WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@climb", Me.NumericUpDownExtCharactersSpeedClimb.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterSpeedFly()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET speedfly=@fly WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@fly", Me.NumericUpDownExtCharactersSpeedFly.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterSpeedSwim()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET speedswim=@swim WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@swim", Me.NumericUpDownExtCharactersSpeedSwim.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterSpeedWalk()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET speedwalk=@walk WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@walk", Me.NumericUpDownExtCharactersSpeedWalk.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterStrength()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET strength=@str WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@str", Me.NumericUpDownExtCharactersStrength.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
            CalculateModifiers()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SaveCharacterWisdom()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET wisdom=@wis WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@wis", Me.NumericUpDownExtCharactersWisdom.Value.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
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
            If _SQLiteCommand IsNot Nothing Then _SQLiteCommand.Dispose()
            If _SQLiteConnect IsNot Nothing Then _SQLiteConnect.Dispose()
            CalculateModifiers()
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub SavePlayerName()

        Dim _SQLiteConnect As System.Data.SQLite.SQLiteConnection = SQLiteConnection()
        Dim _SQLiteCommand As System.Data.SQLite.SQLiteCommand = Nothing
        Dim _QueryString As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim _ListViewItem As System.Windows.Forms.ListViewItem = Nothing

        Try
            If _IsLoaded = True Then
                If _SQLiteConnect IsNot Nothing Then
                    If _SQLiteConnect.State = System.Data.ConnectionState.Open Then
                        Using _SQLiteConnect
                            With _QueryString
                                .Clear()
                                .Append("UPDATE characters SET player=@player WHERE id=@id")
                            End With
                            _SQLiteCommand = New System.Data.SQLite.SQLiteCommand(_QueryString.ToString(), _SQLiteConnect)
                            With _SQLiteCommand
                                '[ Add Parameter Values. ]
                                .Parameters.AddWithValue("@player", Me.TextBoxExtCharactersPlayer.Text.ToString)
                                .Parameters.AddWithValue("@id", _Campaign("character"))
                                '[ Execute INSERT or UPDATE query. ]
                                .ExecuteNonQuery()
                                '[ Clear Parameter Values. ]
                                If .Parameters.Count > 0 Then .Parameters.Clear()
                            End With
                        End Using
                    End If
                End If
                With FormMain.ListViewCharacters
                    .SelectedItems(0).SubItems(2).Text = Me.TextBoxExtCharactersPlayer.Text.ToString
                    .Invalidate()
                End With
            End If
        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
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

#Region " User Control Functions "



#End Region

End Class
