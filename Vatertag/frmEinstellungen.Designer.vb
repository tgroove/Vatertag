<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEinstellungen
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGrundPreis = New System.Windows.Forms.TextBox()
        Me.txtScheibenPreis = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoAuswertung = New System.Windows.Forms.RadioButton()
        Me.rdoVerkauf = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Jede Scheibe"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Grundkosten"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(42, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "5 Scheiben"
        '
        'txtGrundPreis
        '
        Me.txtGrundPreis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrundPreis.Location = New System.Drawing.Point(149, 65)
        Me.txtGrundPreis.Name = "txtGrundPreis"
        Me.txtGrundPreis.Size = New System.Drawing.Size(43, 22)
        Me.txtGrundPreis.TabIndex = 1
        Me.txtGrundPreis.Text = "1,00"
        Me.txtGrundPreis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtScheibenPreis
        '
        Me.txtScheibenPreis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScheibenPreis.Location = New System.Drawing.Point(149, 92)
        Me.txtScheibenPreis.Name = "txtScheibenPreis"
        Me.txtScheibenPreis.Size = New System.Drawing.Size(43, 22)
        Me.txtScheibenPreis.TabIndex = 1
        Me.txtScheibenPreis.Text = "1,00"
        Me.txtScheibenPreis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(149, 120)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(43, 22)
        Me.TextBox3.TabIndex = 1
        Me.TextBox3.Text = "1,00"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(263, 175)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoAuswertung)
        Me.GroupBox1.Controls.Add(Me.rdoVerkauf)
        Me.GroupBox1.Location = New System.Drawing.Point(236, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(140, 77)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Modus"
        '
        'rdoAuswertung
        '
        Me.rdoAuswertung.AutoSize = True
        Me.rdoAuswertung.Location = New System.Drawing.Point(21, 45)
        Me.rdoAuswertung.Name = "rdoAuswertung"
        Me.rdoAuswertung.Size = New System.Drawing.Size(81, 17)
        Me.rdoAuswertung.TabIndex = 0
        Me.rdoAuswertung.TabStop = True
        Me.rdoAuswertung.Text = "Auswertung"
        Me.rdoAuswertung.UseVisualStyleBackColor = True
        '
        'rdoVerkauf
        '
        Me.rdoVerkauf.AutoSize = True
        Me.rdoVerkauf.Location = New System.Drawing.Point(21, 19)
        Me.rdoVerkauf.Name = "rdoVerkauf"
        Me.rdoVerkauf.Size = New System.Drawing.Size(62, 17)
        Me.rdoVerkauf.TabIndex = 0
        Me.rdoVerkauf.TabStop = True
        Me.rdoVerkauf.Text = "Verkauf"
        Me.rdoVerkauf.UseVisualStyleBackColor = True
        '
        'frmEinstellungen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 219)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.txtScheibenPreis)
        Me.Controls.Add(Me.txtGrundPreis)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmEinstellungen"
        Me.Text = "Einstellungen"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtGrundPreis As TextBox
    Friend WithEvents txtScheibenPreis As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents btnOk As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdoAuswertung As RadioButton
    Friend WithEvents rdoVerkauf As RadioButton
End Class
