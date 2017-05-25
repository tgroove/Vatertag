<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTop10
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
        Me.components = New System.ComponentModel.Container()
        Me.tmrRangliste = New System.Windows.Forms.Timer(Me.components)
        Me.rtfRangliste = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'tmrRangliste
        '
        Me.tmrRangliste.Interval = 1000
        '
        'rtfRangliste
        '
        Me.rtfRangliste.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.rtfRangliste.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtfRangliste.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfRangliste.Location = New System.Drawing.Point(10, 10)
        Me.rtfRangliste.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.rtfRangliste.Name = "rtfRangliste"
        Me.rtfRangliste.ReadOnly = True
        Me.rtfRangliste.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtfRangliste.Size = New System.Drawing.Size(418, 224)
        Me.rtfRangliste.TabIndex = 0
        Me.rtfRangliste.Text = ""
        '
        'frmTop10
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 244)
        Me.Controls.Add(Me.rtfRangliste)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(454, 2000)
        Me.MinimizeBox = False
        Me.Name = "frmTop10"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Rangliste"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrRangliste As Timer
    Friend WithEvents rtfRangliste As RichTextBox
End Class
