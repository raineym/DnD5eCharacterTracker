Imports System.Net.WebRequestMethods

Public Class FormAbout

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

    Private Sub FormAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '[ Hide the form to make sure everything on the form loads before presenting it to the user. ]
            With Me
                .Hide()
                .Visible = False
            End With

            '[ Make controls look pretty on this form only. ]
            FormatControls()

            '[ Lastly, Add Event Handlers. ]
            AddHandler Me.ButtonAboutClose.Click, AddressOf CloseForm

        Catch ex As Exception
            ShowMessage("Error", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name.ToString, System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString)
        Finally
            With me
                '[ Display the form to the user. ]
                .Visible = True
                .Show()
            End With
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
        Dim _Copyright As System.String = IIf(DateTime.Now.Year > COPYRIGHTYEAR, System.String.Format(" - {0}", DateTime.Now.Year), System.String.Empty)

        '[ Me ]
        With Me
            .Icon = New System.Drawing.Icon(String.Format("{0}\default.ico", System.Windows.Forms.Application.StartupPath))
            .Text = System.String.Format("About - {0}", PROGRAMNAME)
            .BackColor = System.Drawing.Color.White
            .ControlBox = True
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = System.Drawing.Color.FromArgb(33, 33, 33)
            .FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            .MaximumSize = New System.Drawing.Size(600, 710)
            .MaximizeBox = False
            .MinimumSize = New System.Drawing.Size(600, 710)
            .MinimizeBox = False
            .Size = New System.Drawing.Size(600, 710)
            .SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            .StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            .Location = New System.Drawing.Point((_Screen.WorkingArea.Width - Me.Width) / 2, (_Screen.WorkingArea.Height - Me.Height) / 2)
        End With

        '[ PictureBoxAboutLogo ]
        With Me.PictureBoxAboutLogo
            .BackColor = System.Drawing.Color.White
            .Image = Base64ToImage(My.Resources.Logo_256)
            .Size = New System.Drawing.Size(192, 192)
            .SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            .Location = New System.Drawing.Point((Me.Width - .Width) / 2, 45)
        End With

        '[ LabelAboutTitle ]
        With Me.LabelAboutTitle
            .Text = System.String.Format("{0}", PROGRAMNAME.Replace("&", "&&"))
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 11.25, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelAboutVersion ]
        With Me.LabelAboutVersion
            .Text = System.String.Format("v{0}", PROGRAMBUILD)
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 11.25, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LabelAboutCopyright ]
        With Me.LabelAboutCopyright
            .Text = System.String.Format("Copyright (c) {0}{1}", COPYRIGHTYEAR, _Copyright)
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        End With

        '[ LinkLabelAboutWebsitePersonal ]
        With Me.LinkLabelAboutWebsitePersonal
            .Text = System.String.Format("{0}", COMPANYNAMESHORT)
            .ActiveLinkColor = System.Drawing.Color.Blue
            .DisabledLinkColor = System.Drawing.Color.Gray
            .LinkColor = System.Drawing.Color.Blue
            .VisitedLinkColor = System.Drawing.Color.Blue
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            .Links.Add(0, COMPANYNAMESHORT.Length, "https://crapmybrainsays.com/")
            AddHandler .LinkClicked, AddressOf WebsitePersonalClicked
        End With

        '[ LinkLabelAboutWebsiteGithub ]
        With Me.LinkLabelAboutWebsiteGithub
            .Text = System.String.Format("{0}", "https://github.com/raineym/DnD5eCharacterTracker")
            .ActiveLinkColor = System.Drawing.Color.Blue
            .DisabledLinkColor = System.Drawing.Color.Gray
            .LinkColor = System.Drawing.Color.Blue
            .VisitedLinkColor = System.Drawing.Color.Blue
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            .Links.Add(0, .Text.Length, "https://github.com/raineym/DnD5eCharacterTracker")
            AddHandler .LinkClicked, AddressOf WebsiteGitHubClicked
        End With

        '[ LinkLabelAboutWebsiteAcknowledgements01 ]
        With Me.LinkLabelAboutWebsiteAcknowledgements01
            .Text = System.String.Format("{0}", "This software is released under the terms of the MIT License.")
            .ActiveLinkColor = System.Drawing.Color.Blue
            .DisabledLinkColor = System.Drawing.Color.Gray
            .LinkColor = System.Drawing.Color.Blue
            .VisitedLinkColor = System.Drawing.Color.Blue
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            .Links.Add(49, 11, "https://en.wikipedia.org/wiki/MIT_License")
            AddHandler .LinkClicked, AddressOf WebsiteMITLicenseClicked
        End With

        '[ LinkLabelAboutWebsiteAcknowledgements02 ]
        With Me.LinkLabelAboutWebsiteAcknowledgements02
            .Text = System.String.Format("{0}", "This software uses the System.Data.SQLite ADO.NET provider.")
            .ActiveLinkColor = System.Drawing.Color.Blue
            .DisabledLinkColor = System.Drawing.Color.Gray
            .LinkColor = System.Drawing.Color.Blue
            .VisitedLinkColor = System.Drawing.Color.Blue
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            .Links.Add(23, 18, "https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki")
            AddHandler .LinkClicked, AddressOf WebsiteSQLiteClicked
        End With

        '[ LinkLabelAboutWebsiteAcknowledgements03 ]
        With Me.LinkLabelAboutWebsiteAcknowledgements03
            .Text = System.String.Format("{0}", "This software uses the DotNetZip .NET class library.")
            .ActiveLinkColor = System.Drawing.Color.Blue
            .DisabledLinkColor = System.Drawing.Color.Gray
            .LinkColor = System.Drawing.Color.Blue
            .VisitedLinkColor = System.Drawing.Color.Blue
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            .Links.Add(23, 9, "https://github.com/DinoChiesa/DotNetZip")
            AddHandler .LinkClicked, AddressOf WebsiteDotNetZipClicked
        End With

        '[ LinkLabelAboutWebsiteAcknowledgements04 ]
        With Me.LinkLabelAboutWebsiteAcknowledgements04
            .Text = System.String.Format("{0}", "This software uses UI components from Syncfusion Essential Studio Enterprise Edition.")
            .ActiveLinkColor = System.Drawing.Color.Blue
            .DisabledLinkColor = System.Drawing.Color.Gray
            .LinkColor = System.Drawing.Color.Blue
            .VisitedLinkColor = System.Drawing.Color.Blue
            .BackColor = Me.BackColor
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            .Links.Add(38, 46, "https://www.syncfusion.com/")
            AddHandler .LinkClicked, AddressOf WebsiteSyncfusionClicked
        End With

        '[ ButtonAboutClose ]
        With Me.ButtonAboutClose
            .Text = System.String.Format("{0}", "Close")
            .BackColor = System.Drawing.Color.White
            .Cursor = System.Windows.Forms.Cursors.Default
            .FlatStyle = System.Windows.Forms.FlatStyle.System
            .Font = New System.Drawing.Font(SetFontFamily("Segoe UI", "Microsoft Sans Serif"), 9.75, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            .ForeColor = Me.ForeColor
            .Size = New System.Drawing.Size(75, 28)
            .TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            .Location = New System.Drawing.Point((Me.Width - .Width) / 2, 634)
        End With

    End Sub

#End Region

#Region " Other Form Procedures "

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub WebsiteDotNetZipClicked()

        System.Diagnostics.Process.Start("https://github.com/DinoChiesa/DotNetZip")

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub WebsiteGithubClicked()

        System.Diagnostics.Process.Start("https://github.com/raineym/DnD5eCharacterTracker")

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub WebsiteMITLicenseClicked()

        System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/MIT_License")

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub WebsitePersonalClicked()

        System.Diagnostics.Process.Start("https://crapmybrainsays.com/")

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub WebsiteSQLiteClicked()

        System.Diagnostics.Process.Start("https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki")

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub WebsiteSyncfusionClicked()

        System.Diagnostics.Process.Start("https://www.syncfusion.com/")

    End Sub

#End Region

#Region " Common Form Functions "



#End Region

End Class
