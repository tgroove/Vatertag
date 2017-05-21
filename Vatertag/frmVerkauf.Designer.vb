<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVerkauf
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
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cmdTotal = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtScheibenAlt = New System.Windows.Forms.TextBox()
        Me.lblNr = New System.Windows.Forms.Label()
        Me.txtScheibenNeu = New System.Windows.Forms.TextBox()
        Me.txtBetragNeu = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRest = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(105, 38)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(302, 29)
        Me.txtName.TabIndex = 0
        Me.txtName.TabStop = False
        Me.txtName.Text = "Max Mustermann"
        '
        'cmdTotal
        '
        Me.cmdTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTotal.Location = New System.Drawing.Point(331, 99)
        Me.cmdTotal.Name = "cmdTotal"
        Me.cmdTotal.Size = New System.Drawing.Size(148, 131)
        Me.cmdTotal.TabIndex = 3
        Me.cmdTotal.Text = "Total"
        Me.cmdTotal.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(129, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Scheiben"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(224, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Betrag"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label3.Location = New System.Drawing.Point(44, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Bereits gekauft:"
        '
        'txtScheibenAlt
        '
        Me.txtScheibenAlt.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtScheibenAlt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtScheibenAlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScheibenAlt.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txtScheibenAlt.Location = New System.Drawing.Point(152, 150)
        Me.txtScheibenAlt.Name = "txtScheibenAlt"
        Me.txtScheibenAlt.Size = New System.Drawing.Size(29, 15)
        Me.txtScheibenAlt.TabIndex = 4
        Me.txtScheibenAlt.TabStop = False
        Me.txtScheibenAlt.Text = "2"
        Me.txtScheibenAlt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNr
        '
        Me.lblNr.AutoSize = True
        Me.lblNr.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNr.Location = New System.Drawing.Point(65, 40)
        Me.lblNr.Name = "lblNr"
        Me.lblNr.Size = New System.Drawing.Size(34, 25)
        Me.lblNr.TabIndex = 5
        Me.lblNr.Text = "xx"
        Me.lblNr.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtScheibenNeu
        '
        Me.txtScheibenNeu.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScheibenNeu.Location = New System.Drawing.Point(150, 171)
        Me.txtScheibenNeu.Name = "txtScheibenNeu"
        Me.txtScheibenNeu.Size = New System.Drawing.Size(44, 31)
        Me.txtScheibenNeu.TabIndex = 1
        Me.txtScheibenNeu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBetragNeu
        '
        Me.txtBetragNeu.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBetragNeu.Location = New System.Drawing.Point(228, 171)
        Me.txtBetragNeu.Name = "txtBetragNeu"
        Me.txtBetragNeu.Size = New System.Drawing.Size(64, 31)
        Me.txtBetragNeu.TabIndex = 2
        Me.txtBetragNeu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(63, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 24)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Kaufen:"
        '
        'lblRest
        '
        Me.lblRest.AutoSize = True
        Me.lblRest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRest.ForeColor = System.Drawing.Color.Red
        Me.lblRest.Location = New System.Drawing.Point(203, 205)
        Me.lblRest.Name = "lblRest"
        Me.lblRest.Size = New System.Drawing.Size(57, 20)
        Me.lblRest.TabIndex = 6
        Me.lblRest.Text = "Label5"
        Me.lblRest.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmVerkauf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 259)
        Me.Controls.Add(Me.lblRest)
        Me.Controls.Add(Me.txtBetragNeu)
        Me.Controls.Add(Me.txtScheibenNeu)
        Me.Controls.Add(Me.lblNr)
        Me.Controls.Add(Me.txtScheibenAlt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdTotal)
        Me.Controls.Add(Me.txtName)
        Me.KeyPreview = True
        Me.Name = "frmVerkauf"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verkauf"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents cmdTotal As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtScheibenAlt As TextBox
    Friend WithEvents lblNr As Label
    Friend WithEvents txtScheibenNeu As TextBox
    Friend WithEvents txtBetragNeu As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblRest As Label
End Class
