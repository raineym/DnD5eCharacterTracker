<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNewCampaign
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
        Me.LabelNewCampaignName = New System.Windows.Forms.Label()
        Me.LabelNewCampaignGamemaster = New System.Windows.Forms.Label()
        Me.ButtonNewCampaignCancel = New System.Windows.Forms.Button()
        Me.ButtonNewCampaignSave = New System.Windows.Forms.Button()
        Me.TextBoxNewCampaignName = New System.Windows.Forms.TextBox()
        Me.TextBoxNewCampaignGamemaster = New System.Windows.Forms.TextBox()
        Me.LabelNewCampaignRequired = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelNewCampaignName
        '
        Me.LabelNewCampaignName.Location = New System.Drawing.Point(13, 24)
        Me.LabelNewCampaignName.Name = "LabelNewCampaignName"
        Me.LabelNewCampaignName.Size = New System.Drawing.Size(150, 25)
        Me.LabelNewCampaignName.TabIndex = 0
        Me.LabelNewCampaignName.Text = "Label"
        Me.LabelNewCampaignName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelNewCampaignGamemaster
        '
        Me.LabelNewCampaignGamemaster.Location = New System.Drawing.Point(13, 56)
        Me.LabelNewCampaignGamemaster.Name = "LabelNewCampaignGamemaster"
        Me.LabelNewCampaignGamemaster.Size = New System.Drawing.Size(150, 25)
        Me.LabelNewCampaignGamemaster.TabIndex = 1
        Me.LabelNewCampaignGamemaster.Text = "Label"
        Me.LabelNewCampaignGamemaster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonNewCampaignCancel
        '
        Me.ButtonNewCampaignCancel.Location = New System.Drawing.Point(416, 90)
        Me.ButtonNewCampaignCancel.Name = "ButtonNewCampaignCancel"
        Me.ButtonNewCampaignCancel.Size = New System.Drawing.Size(75, 28)
        Me.ButtonNewCampaignCancel.TabIndex = 4
        Me.ButtonNewCampaignCancel.Text = "Button"
        Me.ButtonNewCampaignCancel.UseVisualStyleBackColor = True
        '
        'ButtonNewCampaignSave
        '
        Me.ButtonNewCampaignSave.Location = New System.Drawing.Point(497, 90)
        Me.ButtonNewCampaignSave.Name = "ButtonNewCampaignSave"
        Me.ButtonNewCampaignSave.Size = New System.Drawing.Size(75, 28)
        Me.ButtonNewCampaignSave.TabIndex = 3
        Me.ButtonNewCampaignSave.Text = "Button"
        Me.ButtonNewCampaignSave.UseVisualStyleBackColor = True
        '
        'TextBoxNewCampaignName
        '
        Me.TextBoxNewCampaignName.Location = New System.Drawing.Point(169, 25)
        Me.TextBoxNewCampaignName.Name = "TextBoxNewCampaignName"
        Me.TextBoxNewCampaignName.Size = New System.Drawing.Size(403, 25)
        Me.TextBoxNewCampaignName.TabIndex = 5
        '
        'TextBoxNewCampaignGamemaster
        '
        Me.TextBoxNewCampaignGamemaster.Location = New System.Drawing.Point(169, 56)
        Me.TextBoxNewCampaignGamemaster.Name = "TextBoxNewCampaignGamemaster"
        Me.TextBoxNewCampaignGamemaster.Size = New System.Drawing.Size(403, 25)
        Me.TextBoxNewCampaignGamemaster.TabIndex = 6
        '
        'LabelNewCampaignRequired
        '
        Me.LabelNewCampaignRequired.Location = New System.Drawing.Point(13, 93)
        Me.LabelNewCampaignRequired.Name = "LabelNewCampaignRequired"
        Me.LabelNewCampaignRequired.Size = New System.Drawing.Size(377, 25)
        Me.LabelNewCampaignRequired.TabIndex = 7
        Me.LabelNewCampaignRequired.Text = "Label"
        Me.LabelNewCampaignRequired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormNewCampaign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(584, 126)
        Me.Controls.Add(Me.LabelNewCampaignRequired)
        Me.Controls.Add(Me.TextBoxNewCampaignGamemaster)
        Me.Controls.Add(Me.TextBoxNewCampaignName)
        Me.Controls.Add(Me.ButtonNewCampaignCancel)
        Me.Controls.Add(Me.ButtonNewCampaignSave)
        Me.Controls.Add(Me.LabelNewCampaignGamemaster)
        Me.Controls.Add(Me.LabelNewCampaignName)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Name = "FormNewCampaign"
        Me.ShowInTaskbar = False
        Me.Text = "FormNewCampaign"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelNewCampaignName As Label
    Friend WithEvents LabelNewCampaignGamemaster As Label
    Friend WithEvents ButtonNewCampaignCancel As Button
    Friend WithEvents ButtonNewCampaignSave As Button
    Friend WithEvents TextBoxNewCampaignName As TextBox
    Friend WithEvents TextBoxNewCampaignGamemaster As TextBox
    Friend WithEvents LabelNewCampaignRequired As Label
End Class
