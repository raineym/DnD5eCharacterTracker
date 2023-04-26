<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMoveCharacter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListViewCampaigns = New System.Windows.Forms.ListView()
        Me.ListViewCampaignsColumnID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListViewCampaignsColumnName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListViewCampaignsColumnGamemaster = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonMoveCharacterSave = New System.Windows.Forms.Button()
        Me.ButtonMoveCharacterCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListViewCampaigns
        '
        Me.ListViewCampaigns.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ListViewCampaignsColumnID, Me.ListViewCampaignsColumnName, Me.ListViewCampaignsColumnGamemaster})
        Me.ListViewCampaigns.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewCampaigns.HideSelection = False
        Me.ListViewCampaigns.Location = New System.Drawing.Point(12, 12)
        Me.ListViewCampaigns.Name = "ListViewCampaigns"
        Me.ListViewCampaigns.OwnerDraw = True
        Me.ListViewCampaigns.Size = New System.Drawing.Size(260, 200)
        Me.ListViewCampaigns.TabIndex = 0
        Me.ListViewCampaigns.TileSize = New System.Drawing.Size(256, 38)
        Me.ListViewCampaigns.UseCompatibleStateImageBehavior = False
        Me.ListViewCampaigns.View = System.Windows.Forms.View.Tile
        '
        'ListViewCampaignsColumnID
        '
        Me.ListViewCampaignsColumnID.Text = "ID"
        Me.ListViewCampaignsColumnID.Width = 0
        '
        'ListViewCampaignsColumnName
        '
        Me.ListViewCampaignsColumnName.Text = "Name"
        '
        'ListViewCampaignsColumnGamemaster
        '
        Me.ListViewCampaignsColumnGamemaster.Text = "Gamemaster"
        '
        'ButtonMoveCharacterSave
        '
        Me.ButtonMoveCharacterSave.Location = New System.Drawing.Point(197, 223)
        Me.ButtonMoveCharacterSave.Name = "ButtonMoveCharacterSave"
        Me.ButtonMoveCharacterSave.Size = New System.Drawing.Size(75, 28)
        Me.ButtonMoveCharacterSave.TabIndex = 1
        Me.ButtonMoveCharacterSave.Text = "Button"
        Me.ButtonMoveCharacterSave.UseVisualStyleBackColor = True
        '
        'ButtonMoveCharacterCancel
        '
        Me.ButtonMoveCharacterCancel.Location = New System.Drawing.Point(116, 223)
        Me.ButtonMoveCharacterCancel.Name = "ButtonMoveCharacterCancel"
        Me.ButtonMoveCharacterCancel.Size = New System.Drawing.Size(75, 28)
        Me.ButtonMoveCharacterCancel.TabIndex = 2
        Me.ButtonMoveCharacterCancel.Text = "Button"
        Me.ButtonMoveCharacterCancel.UseVisualStyleBackColor = True
        '
        'FormMoveCharacter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.ButtonMoveCharacterCancel)
        Me.Controls.Add(Me.ButtonMoveCharacterSave)
        Me.Controls.Add(Me.ListViewCampaigns)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Name = "FormMoveCharacter"
        Me.ShowInTaskbar = False
        Me.Text = "FormMoveCharacter"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListViewCampaigns As ListView
    Friend WithEvents ListViewCampaignsColumnID As ColumnHeader
    Friend WithEvents ListViewCampaignsColumnName As ColumnHeader
    Friend WithEvents ButtonMoveCharacterSave As Button
    Friend WithEvents ButtonMoveCharacterCancel As Button
    Friend WithEvents ListViewCampaignsColumnGamemaster As ColumnHeader
End Class
