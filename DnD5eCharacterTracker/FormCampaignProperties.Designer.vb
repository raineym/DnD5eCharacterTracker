<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCampaignProperties
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
        Me.LabelCampaignPropertiesName = New System.Windows.Forms.Label()
        Me.LabelCampaignPropertiesGamemaster = New System.Windows.Forms.Label()
        Me.ButtonCampaignPropertiesCancel = New System.Windows.Forms.Button()
        Me.ButtonCampaignPropertiesSave = New System.Windows.Forms.Button()
        Me.TextBoxCampaignPropertiesName = New System.Windows.Forms.TextBox()
        Me.TextBoxCampaignPropertiesGamemaster = New System.Windows.Forms.TextBox()
        Me.LabelCampaignPropertiesRequired = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelCampaignPropertiesName
        '
        Me.LabelCampaignPropertiesName.Location = New System.Drawing.Point(13, 24)
        Me.LabelCampaignPropertiesName.Name = "LabelCampaignPropertiesName"
        Me.LabelCampaignPropertiesName.Size = New System.Drawing.Size(150, 25)
        Me.LabelCampaignPropertiesName.TabIndex = 0
        Me.LabelCampaignPropertiesName.Text = "Label"
        Me.LabelCampaignPropertiesName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCampaignPropertiesGamemaster
        '
        Me.LabelCampaignPropertiesGamemaster.Location = New System.Drawing.Point(13, 56)
        Me.LabelCampaignPropertiesGamemaster.Name = "LabelCampaignPropertiesGamemaster"
        Me.LabelCampaignPropertiesGamemaster.Size = New System.Drawing.Size(150, 25)
        Me.LabelCampaignPropertiesGamemaster.TabIndex = 1
        Me.LabelCampaignPropertiesGamemaster.Text = "Label"
        Me.LabelCampaignPropertiesGamemaster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonCampaignPropertiesCancel
        '
        Me.ButtonCampaignPropertiesCancel.Location = New System.Drawing.Point(416, 90)
        Me.ButtonCampaignPropertiesCancel.Name = "ButtonCampaignPropertiesCancel"
        Me.ButtonCampaignPropertiesCancel.Size = New System.Drawing.Size(75, 28)
        Me.ButtonCampaignPropertiesCancel.TabIndex = 4
        Me.ButtonCampaignPropertiesCancel.Text = "Button"
        Me.ButtonCampaignPropertiesCancel.UseVisualStyleBackColor = True
        '
        'ButtonCampaignPropertiesSave
        '
        Me.ButtonCampaignPropertiesSave.Location = New System.Drawing.Point(497, 90)
        Me.ButtonCampaignPropertiesSave.Name = "ButtonCampaignPropertiesSave"
        Me.ButtonCampaignPropertiesSave.Size = New System.Drawing.Size(75, 28)
        Me.ButtonCampaignPropertiesSave.TabIndex = 3
        Me.ButtonCampaignPropertiesSave.Text = "Button"
        Me.ButtonCampaignPropertiesSave.UseVisualStyleBackColor = True
        '
        'TextBoxCampaignPropertiesName
        '
        Me.TextBoxCampaignPropertiesName.Location = New System.Drawing.Point(169, 25)
        Me.TextBoxCampaignPropertiesName.Name = "TextBoxCampaignPropertiesName"
        Me.TextBoxCampaignPropertiesName.Size = New System.Drawing.Size(403, 25)
        Me.TextBoxCampaignPropertiesName.TabIndex = 5
        '
        'TextBoxCampaignPropertiesGamemaster
        '
        Me.TextBoxCampaignPropertiesGamemaster.Location = New System.Drawing.Point(169, 56)
        Me.TextBoxCampaignPropertiesGamemaster.Name = "TextBoxCampaignPropertiesGamemaster"
        Me.TextBoxCampaignPropertiesGamemaster.Size = New System.Drawing.Size(403, 25)
        Me.TextBoxCampaignPropertiesGamemaster.TabIndex = 6
        '
        'LabelCampaignPropertiesRequired
        '
        Me.LabelCampaignPropertiesRequired.Location = New System.Drawing.Point(13, 93)
        Me.LabelCampaignPropertiesRequired.Name = "LabelCampaignPropertiesRequired"
        Me.LabelCampaignPropertiesRequired.Size = New System.Drawing.Size(377, 25)
        Me.LabelCampaignPropertiesRequired.TabIndex = 7
        Me.LabelCampaignPropertiesRequired.Text = "Label"
        Me.LabelCampaignPropertiesRequired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormCampaignProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(584, 126)
        Me.Controls.Add(Me.LabelCampaignPropertiesRequired)
        Me.Controls.Add(Me.TextBoxCampaignPropertiesGamemaster)
        Me.Controls.Add(Me.TextBoxCampaignPropertiesName)
        Me.Controls.Add(Me.ButtonCampaignPropertiesCancel)
        Me.Controls.Add(Me.ButtonCampaignPropertiesSave)
        Me.Controls.Add(Me.LabelCampaignPropertiesGamemaster)
        Me.Controls.Add(Me.LabelCampaignPropertiesName)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Name = "FormCampaignProperties"
        Me.ShowInTaskbar = False
        Me.Text = "FormCampaignProperties"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelCampaignPropertiesName As Label
    Friend WithEvents LabelCampaignPropertiesGamemaster As Label
    Friend WithEvents ButtonCampaignPropertiesCancel As Button
    Friend WithEvents ButtonCampaignPropertiesSave As Button
    Friend WithEvents TextBoxCampaignPropertiesName As TextBox
    Friend WithEvents TextBoxCampaignPropertiesGamemaster As TextBox
    Friend WithEvents LabelCampaignPropertiesRequired As Label
End Class
