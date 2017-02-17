<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfo
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rtbInfo = New System.Windows.Forms.RichTextBox()
        Me.rtbInfo2 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'rtbInfo
        '
        Me.rtbInfo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.rtbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbInfo.Location = New System.Drawing.Point(12, 12)
        Me.rtbInfo.Multiline = False
        Me.rtbInfo.Name = "rtbInfo"
        Me.rtbInfo.ReadOnly = True
        Me.rtbInfo.Size = New System.Drawing.Size(433, 45)
        Me.rtbInfo.TabIndex = 1
        Me.rtbInfo.Text = ""
        '
        'rtbInfo2
        '
        Me.rtbInfo2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.rtbInfo2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbInfo2.Location = New System.Drawing.Point(26, 63)
        Me.rtbInfo2.Multiline = False
        Me.rtbInfo2.Name = "rtbInfo2"
        Me.rtbInfo2.ReadOnly = True
        Me.rtbInfo2.Size = New System.Drawing.Size(419, 38)
        Me.rtbInfo2.TabIndex = 2
        Me.rtbInfo2.Text = ""
        '
        'frmInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 102)
        Me.Controls.Add(Me.rtbInfo2)
        Me.Controls.Add(Me.rtbInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmInfo"
        Me.ShowInTaskbar = False
        Me.Text = "Info"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbInfo As RichTextBox
    Friend WithEvents rtbInfo2 As RichTextBox
End Class
