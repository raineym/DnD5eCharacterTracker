<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ListViewCharacters = New System.Windows.Forms.ListView()
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip()
        Me.MenuStripMainItemFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemFileItemBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemFileItemRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemFileSeparator01 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStripMainItemFileItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemCampaign = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemCampaignsItemLoad = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemCampaignsItemClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemCampaignsSeparator01 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStripMainItemCampaignsItemProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemCampaignsSeparator02 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStripMainItemCampaignsItemNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemCampaignsItemRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemCharacter = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemCharacterItemAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemCharacterItemDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemCharacterSeparator01 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStripMainItemCharacterItemDuplicate = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemCharacterItemMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelCharactersHeader = New System.Windows.Forms.Label()
        Me.LabelCampaignHeader = New System.Windows.Forms.Label()
        Me.ButtonCharacterAdd = New System.Windows.Forms.Button()
        Me.ButtonCharacterDelete = New System.Windows.Forms.Button()
        Me.PanelCharacters = New System.Windows.Forms.Panel()
        Me.ContextMenuStripMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStripMainItemAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripMainItemDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripMainSeparator01 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuStripMainItemDuplicate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripMainItemMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemHelpItemGettingStarted = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemHelpItemWiki = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemHelpItemReleaseNotes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemHelpItemReportBug = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMainItemHelpSeparator01 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStripMainItemHelpItemAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripMain.SuspendLayout()
        Me.ContextMenuStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListViewCharacters
        '
        Me.ListViewCharacters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewCharacters.HideSelection = False
        Me.ListViewCharacters.Location = New System.Drawing.Point(12, 97)
        Me.ListViewCharacters.MultiSelect = False
        Me.ListViewCharacters.Name = "ListViewCharacters"
        Me.ListViewCharacters.OwnerDraw = True
        Me.ListViewCharacters.Size = New System.Drawing.Size(260, 620)
        Me.ListViewCharacters.TabIndex = 0
        Me.ListViewCharacters.TileSize = New System.Drawing.Size(256, 38)
        Me.ListViewCharacters.UseCompatibleStateImageBehavior = False
        Me.ListViewCharacters.View = System.Windows.Forms.View.Tile
        Me.ListViewCharacters.Visible = False
        '
        'MenuStripMain
        '
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuStripMainItemFile, Me.MenuStripMainItemCampaign, Me.MenuStripMainItemCharacter, Me.MenuStripMainItemHelp})
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Size = New System.Drawing.Size(1008, 24)
        Me.MenuStripMain.TabIndex = 1
        Me.MenuStripMain.Text = "MenuStripMain"
        '
        'MenuStripMainItemFile
        '
        Me.MenuStripMainItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuStripMainItemFileItemBackup, Me.MenuStripMainItemFileItemRestore, Me.MenuStripMainItemFileSeparator01, Me.MenuStripMainItemFileItemExit})
        Me.MenuStripMainItemFile.Name = "MenuStripMainItemFile"
        Me.MenuStripMainItemFile.Size = New System.Drawing.Size(37, 20)
        Me.MenuStripMainItemFile.Text = "File"
        '
        'MenuStripMainItemFileItemBackup
        '
        Me.MenuStripMainItemFileItemBackup.Name = "MenuStripMainItemFileItemBackup"
        Me.MenuStripMainItemFileItemBackup.Size = New System.Drawing.Size(180, 22)
        Me.MenuStripMainItemFileItemBackup.Text = "Backup Database"
        '
        'MenuStripMainItemFileItemRestore
        '
        Me.MenuStripMainItemFileItemRestore.Name = "MenuStripMainItemFileItemRestore"
        Me.MenuStripMainItemFileItemRestore.Size = New System.Drawing.Size(180, 22)
        Me.MenuStripMainItemFileItemRestore.Text = "Restore Database"
        '
        'MenuStripMainItemFileSeparator01
        '
        Me.MenuStripMainItemFileSeparator01.Name = "MenuStripMainItemFileSeparator01"
        Me.MenuStripMainItemFileSeparator01.Size = New System.Drawing.Size(177, 6)
        '
        'MenuStripMainItemFileItemExit
        '
        Me.MenuStripMainItemFileItemExit.Name = "MenuStripMainItemFileItemExit"
        Me.MenuStripMainItemFileItemExit.Size = New System.Drawing.Size(180, 22)
        Me.MenuStripMainItemFileItemExit.Text = "Exit"
        '
        'MenuStripMainItemCampaign
        '
        Me.MenuStripMainItemCampaign.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuStripMainItemCampaignsItemLoad, Me.MenuStripMainItemCampaignsItemClose, Me.MenuStripMainItemCampaignsSeparator01, Me.MenuStripMainItemCampaignsItemProperties, Me.MenuStripMainItemCampaignsSeparator02, Me.MenuStripMainItemCampaignsItemNew, Me.MenuStripMainItemCampaignsItemRemove})
        Me.MenuStripMainItemCampaign.Name = "MenuStripMainItemCampaign"
        Me.MenuStripMainItemCampaign.Size = New System.Drawing.Size(74, 20)
        Me.MenuStripMainItemCampaign.Text = "Campaign"
        '
        'MenuStripMainItemCampaignsItemLoad
        '
        Me.MenuStripMainItemCampaignsItemLoad.Name = "MenuStripMainItemCampaignsItemLoad"
        Me.MenuStripMainItemCampaignsItemLoad.Size = New System.Drawing.Size(185, 22)
        Me.MenuStripMainItemCampaignsItemLoad.Text = "Load Campaign"
        '
        'MenuStripMainItemCampaignsItemClose
        '
        Me.MenuStripMainItemCampaignsItemClose.Name = "MenuStripMainItemCampaignsItemClose"
        Me.MenuStripMainItemCampaignsItemClose.Size = New System.Drawing.Size(185, 22)
        Me.MenuStripMainItemCampaignsItemClose.Text = "Close Campaign"
        '
        'MenuStripMainItemCampaignsSeparator01
        '
        Me.MenuStripMainItemCampaignsSeparator01.Name = "MenuStripMainItemCampaignsSeparator01"
        Me.MenuStripMainItemCampaignsSeparator01.Size = New System.Drawing.Size(182, 6)
        '
        'MenuStripMainItemCampaignsItemProperties
        '
        Me.MenuStripMainItemCampaignsItemProperties.Name = "MenuStripMainItemCampaignsItemProperties"
        Me.MenuStripMainItemCampaignsItemProperties.Size = New System.Drawing.Size(185, 22)
        Me.MenuStripMainItemCampaignsItemProperties.Text = "Campaign Properties"
        '
        'MenuStripMainItemCampaignsSeparator02
        '
        Me.MenuStripMainItemCampaignsSeparator02.Name = "MenuStripMainItemCampaignsSeparator02"
        Me.MenuStripMainItemCampaignsSeparator02.Size = New System.Drawing.Size(182, 6)
        '
        'MenuStripMainItemCampaignsItemNew
        '
        Me.MenuStripMainItemCampaignsItemNew.Name = "MenuStripMainItemCampaignsItemNew"
        Me.MenuStripMainItemCampaignsItemNew.Size = New System.Drawing.Size(185, 22)
        Me.MenuStripMainItemCampaignsItemNew.Text = "New Campaign"
        '
        'MenuStripMainItemCampaignsItemRemove
        '
        Me.MenuStripMainItemCampaignsItemRemove.Name = "MenuStripMainItemCampaignsItemRemove"
        Me.MenuStripMainItemCampaignsItemRemove.Size = New System.Drawing.Size(185, 22)
        Me.MenuStripMainItemCampaignsItemRemove.Text = "Remove Campaign"
        '
        'MenuStripMainItemCharacter
        '
        Me.MenuStripMainItemCharacter.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuStripMainItemCharacterItemAdd, Me.MenuStripMainItemCharacterItemDelete, Me.MenuStripMainItemCharacterSeparator01, Me.MenuStripMainItemCharacterItemDuplicate, Me.MenuStripMainItemCharacterItemMove})
        Me.MenuStripMainItemCharacter.Name = "MenuStripMainItemCharacter"
        Me.MenuStripMainItemCharacter.Size = New System.Drawing.Size(70, 20)
        Me.MenuStripMainItemCharacter.Text = "Character"
        '
        'MenuStripMainItemCharacterItemAdd
        '
        Me.MenuStripMainItemCharacterItemAdd.Name = "MenuStripMainItemCharacterItemAdd"
        Me.MenuStripMainItemCharacterItemAdd.Size = New System.Drawing.Size(180, 22)
        Me.MenuStripMainItemCharacterItemAdd.Text = "Add Character"
        '
        'MenuStripMainItemCharacterItemDelete
        '
        Me.MenuStripMainItemCharacterItemDelete.Name = "MenuStripMainItemCharacterItemDelete"
        Me.MenuStripMainItemCharacterItemDelete.Size = New System.Drawing.Size(180, 22)
        Me.MenuStripMainItemCharacterItemDelete.Text = "Remove Character"
        '
        'MenuStripMainItemCharacterSeparator01
        '
        Me.MenuStripMainItemCharacterSeparator01.Name = "MenuStripMainItemCharacterSeparator01"
        Me.MenuStripMainItemCharacterSeparator01.Size = New System.Drawing.Size(177, 6)
        '
        'MenuStripMainItemCharacterItemDuplicate
        '
        Me.MenuStripMainItemCharacterItemDuplicate.Name = "MenuStripMainItemCharacterItemDuplicate"
        Me.MenuStripMainItemCharacterItemDuplicate.Size = New System.Drawing.Size(180, 22)
        Me.MenuStripMainItemCharacterItemDuplicate.Text = "Duplicate Character"
        '
        'MenuStripMainItemCharacterItemMove
        '
        Me.MenuStripMainItemCharacterItemMove.Name = "MenuStripMainItemCharacterItemMove"
        Me.MenuStripMainItemCharacterItemMove.Size = New System.Drawing.Size(180, 22)
        Me.MenuStripMainItemCharacterItemMove.Text = "Move Character"
        '
        'MenuStripMainItemHelp
        '
        Me.MenuStripMainItemHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuStripMainItemHelpItemGettingStarted, Me.MenuStripMainItemHelpItemWiki, Me.MenuStripMainItemHelpItemReleaseNotes, Me.MenuStripMainItemHelpItemReportBug, Me.MenuStripMainItemHelpSeparator01, Me.MenuStripMainItemHelpItemAbout})
        Me.MenuStripMainItemHelp.Name = "MenuStripMainItemHelp"
        Me.MenuStripMainItemHelp.Size = New System.Drawing.Size(44, 20)
        Me.MenuStripMainItemHelp.Text = "Help"
        '
        'LabelCharactersHeader
        '
        Me.LabelCharactersHeader.Location = New System.Drawing.Point(13, 70)
        Me.LabelCharactersHeader.Name = "LabelCharactersHeader"
        Me.LabelCharactersHeader.Size = New System.Drawing.Size(184, 24)
        Me.LabelCharactersHeader.TabIndex = 2
        Me.LabelCharactersHeader.Tag = "Characters: (0}"
        Me.LabelCharactersHeader.Text = "Characters: (0}"
        Me.LabelCharactersHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelCharactersHeader.Visible = False
        '
        'LabelCampaignHeader
        '
        Me.LabelCampaignHeader.Location = New System.Drawing.Point(13, 34)
        Me.LabelCampaignHeader.Name = "LabelCampaignHeader"
        Me.LabelCampaignHeader.Size = New System.Drawing.Size(983, 24)
        Me.LabelCampaignHeader.TabIndex = 3
        Me.LabelCampaignHeader.Tag = "Campaign: {0} | Gamemaster: {1}"
        Me.LabelCampaignHeader.Text = "Campaign: {0} | Gamemaster: {1}"
        Me.LabelCampaignHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LabelCampaignHeader.Visible = False
        '
        'ButtonCharacterAdd
        '
        Me.ButtonCharacterAdd.Location = New System.Drawing.Point(230, 75)
        Me.ButtonCharacterAdd.Name = "ButtonCharacterAdd"
        Me.ButtonCharacterAdd.Size = New System.Drawing.Size(20, 20)
        Me.ButtonCharacterAdd.TabIndex = 5
        Me.ButtonCharacterAdd.Text = "+"
        Me.ButtonCharacterAdd.UseVisualStyleBackColor = True
        '
        'ButtonCharacterDelete
        '
        Me.ButtonCharacterDelete.Location = New System.Drawing.Point(252, 75)
        Me.ButtonCharacterDelete.Name = "ButtonCharacterDelete"
        Me.ButtonCharacterDelete.Size = New System.Drawing.Size(20, 20)
        Me.ButtonCharacterDelete.TabIndex = 6
        Me.ButtonCharacterDelete.Text = "x"
        Me.ButtonCharacterDelete.UseVisualStyleBackColor = True
        '
        'PanelCharacters
        '
        Me.PanelCharacters.Location = New System.Drawing.Point(302, 97)
        Me.PanelCharacters.Name = "PanelCharacters"
        Me.PanelCharacters.Size = New System.Drawing.Size(694, 620)
        Me.PanelCharacters.TabIndex = 4
        Me.PanelCharacters.Visible = False
        '
        'ContextMenuStripMain
        '
        Me.ContextMenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuStripMainItemAdd, Me.ContextMenuStripMainItemDelete, Me.ContextMenuStripMainSeparator01, Me.ContextMenuStripMainItemDuplicate, Me.ContextMenuStripMainItemMove})
        Me.ContextMenuStripMain.Name = "ContextMenuStripMain"
        Me.ContextMenuStripMain.Size = New System.Drawing.Size(179, 98)
        '
        'ContextMenuStripMainItemAdd
        '
        Me.ContextMenuStripMainItemAdd.Name = "ContextMenuStripMainItemAdd"
        Me.ContextMenuStripMainItemAdd.Size = New System.Drawing.Size(178, 22)
        Me.ContextMenuStripMainItemAdd.Text = "Add Character"
        '
        'ContextMenuStripMainItemDelete
        '
        Me.ContextMenuStripMainItemDelete.Name = "ContextMenuStripMainItemDelete"
        Me.ContextMenuStripMainItemDelete.Size = New System.Drawing.Size(178, 22)
        Me.ContextMenuStripMainItemDelete.Text = "Remove Character"
        '
        'ContextMenuStripMainSeparator01
        '
        Me.ContextMenuStripMainSeparator01.Name = "ContextMenuStripMainSeparator01"
        Me.ContextMenuStripMainSeparator01.Size = New System.Drawing.Size(175, 6)
        '
        'ContextMenuStripMainItemDuplicate
        '
        Me.ContextMenuStripMainItemDuplicate.Name = "ContextMenuStripMainItemDuplicate"
        Me.ContextMenuStripMainItemDuplicate.Size = New System.Drawing.Size(178, 22)
        Me.ContextMenuStripMainItemDuplicate.Text = "Duplicate Character"
        '
        'ContextMenuStripMainItemMove
        '
        Me.ContextMenuStripMainItemMove.Name = "ContextMenuStripMainItemMove"
        Me.ContextMenuStripMainItemMove.Size = New System.Drawing.Size(178, 22)
        Me.ContextMenuStripMainItemMove.Text = "Move Character"
        '
        'MenuStripMainItemHelpItemGettingStarted
        '
        Me.MenuStripMainItemHelpItemGettingStarted.Name = "MenuStripMainItemHelpItemGettingStarted"
        Me.MenuStripMainItemHelpItemGettingStarted.Size = New System.Drawing.Size(180, 22)
        Me.MenuStripMainItemHelpItemGettingStarted.Text = "Getting Started"
        '
        'MenuStripMainItemHelpItemWiki
        '
        Me.MenuStripMainItemHelpItemWiki.Name = "MenuStripMainItemHelpItemWiki"
        Me.MenuStripMainItemHelpItemWiki.Size = New System.Drawing.Size(180, 22)
        Me.MenuStripMainItemHelpItemWiki.Text = "Wiki"
        '
        'MenuStripMainItemHelpItemReleaseNotes
        '
        Me.MenuStripMainItemHelpItemReleaseNotes.Name = "MenuStripMainItemHelpItemReleaseNotes"
        Me.MenuStripMainItemHelpItemReleaseNotes.Size = New System.Drawing.Size(180, 22)
        Me.MenuStripMainItemHelpItemReleaseNotes.Text = "Release Notes"
        '
        'MenuStripMainItemHelpItemReportBug
        '
        Me.MenuStripMainItemHelpItemReportBug.Name = "MenuStripMainItemHelpItemReportBug"
        Me.MenuStripMainItemHelpItemReportBug.Size = New System.Drawing.Size(180, 22)
        Me.MenuStripMainItemHelpItemReportBug.Text = "Report Bug"
        '
        'MenuStripMainItemHelpSeparator01
        '
        Me.MenuStripMainItemHelpSeparator01.Name = "MenuStripMainItemHelpSeparator01"
        Me.MenuStripMainItemHelpSeparator01.Size = New System.Drawing.Size(177, 6)
        '
        'MenuStripMainItemHelpItemAbout
        '
        Me.MenuStripMainItemHelpItemAbout.Name = "MenuStripMainItemHelpItemAbout"
        Me.MenuStripMainItemHelpItemAbout.Size = New System.Drawing.Size(180, 22)
        Me.MenuStripMainItemHelpItemAbout.Text = "About"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.ButtonCharacterDelete)
        Me.Controls.Add(Me.ButtonCharacterAdd)
        Me.Controls.Add(Me.PanelCharacters)
        Me.Controls.Add(Me.LabelCampaignHeader)
        Me.Controls.Add(Me.LabelCharactersHeader)
        Me.Controls.Add(Me.ListViewCharacters)
        Me.Controls.Add(Me.MenuStripMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.MainMenuStrip = Me.MenuStripMain
        Me.Name = "FormMain"
        Me.Text = "FormMain"
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        Me.ContextMenuStripMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListViewCharacters As ListView
    Friend WithEvents MenuStripMain As MenuStrip
    Friend WithEvents MenuStripMainItemCampaign As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemHelp As ToolStripMenuItem
    Friend WithEvents LabelCharactersHeader As Label
    Friend WithEvents LabelCampaignHeader As Label
    Friend WithEvents MenuStripMainItemCampaignsItemLoad As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemCampaignsItemClose As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemCampaignsSeparator01 As ToolStripSeparator
    Friend WithEvents MenuStripMainItemCampaignsItemProperties As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemCampaignsSeparator02 As ToolStripSeparator
    Friend WithEvents MenuStripMainItemCampaignsItemNew As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemCampaignsItemRemove As ToolStripMenuItem
    Friend WithEvents ButtonCharacterAdd As Button
    Friend WithEvents ButtonCharacterDelete As Button
    Friend WithEvents PanelCharacters As Panel
    Friend WithEvents ContextMenuStripMain As ContextMenuStrip
    Friend WithEvents ContextMenuStripMainItemAdd As ToolStripMenuItem
    Friend WithEvents ContextMenuStripMainItemDelete As ToolStripMenuItem
    Friend WithEvents ContextMenuStripMainSeparator01 As ToolStripSeparator
    Friend WithEvents ContextMenuStripMainItemDuplicate As ToolStripMenuItem
    Friend WithEvents ContextMenuStripMainItemMove As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemCharacter As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemCharacterItemAdd As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemCharacterItemDelete As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemCharacterSeparator01 As ToolStripSeparator
    Friend WithEvents MenuStripMainItemCharacterItemDuplicate As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemCharacterItemMove As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemFile As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemFileSeparator01 As ToolStripSeparator
    Friend WithEvents MenuStripMainItemFileItemBackup As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemFileItemRestore As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemFileItemExit As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemHelpItemGettingStarted As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemHelpItemWiki As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemHelpItemReleaseNotes As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemHelpItemReportBug As ToolStripMenuItem
    Friend WithEvents MenuStripMainItemHelpSeparator01 As ToolStripSeparator
    Friend WithEvents MenuStripMainItemHelpItemAbout As ToolStripMenuItem
End Class
