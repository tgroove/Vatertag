<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSuche
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSuche))
        Me.txtTNummer = New System.Windows.Forms.TextBox()
        Me.txtTName = New System.Windows.Forms.TextBox()
        Me.lstTeilnehmer = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolFensterZurücksetzenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDatei = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenDB = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeueDatenbankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DruckvorschauToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZwischenergebnisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EndergebnisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TagesabschlußToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EinstellungenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNeu = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.rtbLog = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAenderung = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblErgebnisse = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPlatzierung = New System.Windows.Forms.Label()
        Me.PrintErgebnisse = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewErgebnisse = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintAbschluss = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewAbschluss = New System.Windows.Forms.PrintPreviewDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTNummer
        '
        Me.txtTNummer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTNummer.Location = New System.Drawing.Point(39, 37)
        Me.txtTNummer.MaxLength = 3
        Me.txtTNummer.Name = "txtTNummer"
        Me.txtTNummer.Size = New System.Drawing.Size(40, 29)
        Me.txtTNummer.TabIndex = 0
        '
        'txtTName
        '
        Me.txtTName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTName.Location = New System.Drawing.Point(85, 37)
        Me.txtTName.MaxLength = 256
        Me.txtTName.Name = "txtTName"
        Me.txtTName.Size = New System.Drawing.Size(303, 29)
        Me.txtTName.TabIndex = 1
        '
        'lstTeilnehmer
        '
        Me.lstTeilnehmer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstTeilnehmer.FormattingEnabled = True
        Me.lstTeilnehmer.ItemHeight = 24
        Me.lstTeilnehmer.Location = New System.Drawing.Point(85, 72)
        Me.lstTeilnehmer.Name = "lstTeilnehmer"
        Me.lstTeilnehmer.Size = New System.Drawing.Size(244, 220)
        Me.lstTeilnehmer.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolFensterZurücksetzenToolStripMenuItem, Me.EinstellungenToolStripMenuItem, Me.mnuDatei})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(630, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolFensterZurücksetzenToolStripMenuItem
        '
        Me.ToolFensterZurücksetzenToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolFensterZurücksetzenToolStripMenuItem.Image = Global.Vatertag.My.Resources.Resources.WindowRefresh8
        Me.ToolFensterZurücksetzenToolStripMenuItem.Name = "ToolFensterZurücksetzenToolStripMenuItem"
        Me.ToolFensterZurücksetzenToolStripMenuItem.Size = New System.Drawing.Size(28, 20)
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.EinstellungenToolStripMenuItem.Image = Global.Vatertag.My.Resources.Resources.gear_32xLG
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(28, 20)
        Me.EinstellungenToolStripMenuItem.Visible = False
        '
        'mnuDatei
        '
        Me.mnuDatei.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpenDB, Me.NeueDatenbankToolStripMenuItem, Me.DruckvorschauToolStripMenuItem, Me.TagesabschlußToolStripMenuItem, Me.ToolStripMenuItem1, Me.EinstellungenToolStripMenuItem1, Me.BeendenToolStripMenuItem})
        Me.mnuDatei.Name = "mnuDatei"
        Me.mnuDatei.Size = New System.Drawing.Size(46, 20)
        Me.mnuDatei.Text = "&Datei"
        '
        'mnuOpenDB
        '
        Me.mnuOpenDB.Image = Global.Vatertag.My.Resources.Resources.folder_Open_16xLG
        Me.mnuOpenDB.Name = "mnuOpenDB"
        Me.mnuOpenDB.Size = New System.Drawing.Size(199, 22)
        Me.mnuOpenDB.Text = "&Datenbank öffnen"
        '
        'NeueDatenbankToolStripMenuItem
        '
        Me.NeueDatenbankToolStripMenuItem.Image = Global.Vatertag.My.Resources.Resources.NewFile_6276
        Me.NeueDatenbankToolStripMenuItem.Name = "NeueDatenbankToolStripMenuItem"
        Me.NeueDatenbankToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.NeueDatenbankToolStripMenuItem.Text = "&Neue Datenbank"
        '
        'DruckvorschauToolStripMenuItem
        '
        Me.DruckvorschauToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZwischenergebnisToolStripMenuItem, Me.EndergebnisToolStripMenuItem})
        Me.DruckvorschauToolStripMenuItem.Image = Global.Vatertag.My.Resources.Resources.printer_16xLG
        Me.DruckvorschauToolStripMenuItem.Name = "DruckvorschauToolStripMenuItem"
        Me.DruckvorschauToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.DruckvorschauToolStripMenuItem.Text = "&Ergebnisse drucken"
        '
        'ZwischenergebnisToolStripMenuItem
        '
        Me.ZwischenergebnisToolStripMenuItem.Image = Global.Vatertag.My.Resources.Resources.ListTime_16x
        Me.ZwischenergebnisToolStripMenuItem.Name = "ZwischenergebnisToolStripMenuItem"
        Me.ZwischenergebnisToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ZwischenergebnisToolStripMenuItem.Text = "&Zwischenergebnis"
        '
        'EndergebnisToolStripMenuItem
        '
        Me.EndergebnisToolStripMenuItem.Name = "EndergebnisToolStripMenuItem"
        Me.EndergebnisToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.EndergebnisToolStripMenuItem.Text = "&Endergebnis"
        '
        'TagesabschlußToolStripMenuItem
        '
        Me.TagesabschlußToolStripMenuItem.Image = Global.Vatertag.My.Resources.Resources.Calculator_16xLG
        Me.TagesabschlußToolStripMenuItem.Name = "TagesabschlußToolStripMenuItem"
        Me.TagesabschlußToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.TagesabschlußToolStripMenuItem.Text = "&Tagesabschluß drucken"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(196, 6)
        '
        'EinstellungenToolStripMenuItem1
        '
        Me.EinstellungenToolStripMenuItem1.Image = Global.Vatertag.My.Resources.Resources.gear_32xLG
        Me.EinstellungenToolStripMenuItem1.Name = "EinstellungenToolStripMenuItem1"
        Me.EinstellungenToolStripMenuItem1.Size = New System.Drawing.Size(199, 22)
        Me.EinstellungenToolStripMenuItem1.Text = "Ein&stellungen"
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.BeendenToolStripMenuItem.Text = "&Beenden"
        '
        'btnNeu
        '
        Me.btnNeu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNeu.Location = New System.Drawing.Point(335, 72)
        Me.btnNeu.Name = "btnNeu"
        Me.btnNeu.Size = New System.Drawing.Size(53, 220)
        Me.btnNeu.TabIndex = 4
        Me.btnNeu.Text = "Neu"
        Me.btnNeu.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.Filter = "Microsoft Access (*.accdb)|*.accdb"
        Me.OpenFileDialog.Title = "Datenbank öffnen"
        '
        'rtbLog
        '
        Me.rtbLog.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.rtbLog.Location = New System.Drawing.Point(0, 311)
        Me.rtbLog.Name = "rtbLog"
        Me.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtbLog.Size = New System.Drawing.Size(630, 73)
        Me.rtbLog.TabIndex = 5
        Me.rtbLog.Text = ""
        Me.rtbLog.WordWrap = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(417, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Letzte Änderung:"
        '
        'lblAenderung
        '
        Me.lblAenderung.AutoSize = True
        Me.lblAenderung.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAenderung.Location = New System.Drawing.Point(417, 118)
        Me.lblAenderung.Name = "lblAenderung"
        Me.lblAenderung.Size = New System.Drawing.Size(71, 20)
        Me.lblAenderung.TabIndex = 7
        Me.lblAenderung.Text = "23:23:12"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(420, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Ergebnisse:"
        '
        'lblErgebnisse
        '
        Me.lblErgebnisse.AutoSize = True
        Me.lblErgebnisse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErgebnisse.Location = New System.Drawing.Point(420, 169)
        Me.lblErgebnisse.Name = "lblErgebnisse"
        Me.lblErgebnisse.Size = New System.Drawing.Size(96, 20)
        Me.lblErgebnisse.TabIndex = 7
        Me.lblErgebnisse.Text = "23  44  12  0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(420, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Platzierung:"
        '
        'lblPlatzierung
        '
        Me.lblPlatzierung.AutoSize = True
        Me.lblPlatzierung.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlatzierung.Location = New System.Drawing.Point(420, 220)
        Me.lblPlatzierung.Name = "lblPlatzierung"
        Me.lblPlatzierung.Size = New System.Drawing.Size(18, 20)
        Me.lblPlatzierung.TabIndex = 7
        Me.lblPlatzierung.Text = "2"
        '
        'PrintErgebnisse
        '
        '
        'PrintPreviewErgebnisse
        '
        Me.PrintPreviewErgebnisse.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewErgebnisse.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewErgebnisse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PrintPreviewErgebnisse.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewErgebnisse.Document = Me.PrintErgebnisse
        Me.PrintPreviewErgebnisse.Enabled = True
        Me.PrintPreviewErgebnisse.Icon = CType(resources.GetObject("PrintPreviewErgebnisse.Icon"), System.Drawing.Icon)
        Me.PrintPreviewErgebnisse.MainMenuStrip = Me.MenuStrip1
        Me.PrintPreviewErgebnisse.Name = "PrintPreviewErgebnisse"
        Me.PrintPreviewErgebnisse.Visible = False
        '
        'PrintAbschluss
        '
        '
        'PrintPreviewAbschluss
        '
        Me.PrintPreviewAbschluss.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewAbschluss.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewAbschluss.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewAbschluss.Document = Me.PrintAbschluss
        Me.PrintPreviewAbschluss.Enabled = True
        Me.PrintPreviewAbschluss.Icon = CType(resources.GetObject("PrintPreviewAbschluss.Icon"), System.Drawing.Icon)
        Me.PrintPreviewAbschluss.Name = "PrintPreviewAbschluss"
        Me.PrintPreviewAbschluss.Visible = False
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.Filter = "Access|*.accdb"
        '
        'frmSuche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 387)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblPlatzierung)
        Me.Controls.Add(Me.lblErgebnisse)
        Me.Controls.Add(Me.lblAenderung)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rtbLog)
        Me.Controls.Add(Me.btnNeu)
        Me.Controls.Add(Me.lstTeilnehmer)
        Me.Controls.Add(Me.txtTName)
        Me.Controls.Add(Me.txtTNummer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmSuche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Teilnehmer"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTNummer As TextBox
    Friend WithEvents txtTName As TextBox
    Friend WithEvents lstTeilnehmer As ListBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuDatei As ToolStripMenuItem
    Friend WithEvents mnuOpenDB As ToolStripMenuItem
    Friend WithEvents btnNeu As Button
    Friend WithEvents EinstellungenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents rtbLog As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAenderung As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblErgebnisse As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblPlatzierung As Label
    Friend WithEvents PrintErgebnisse As Printing.PrintDocument
    Friend WithEvents PrintPreviewErgebnisse As PrintPreviewDialog
    Friend WithEvents DruckvorschauToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TagesabschlußToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintAbschluss As Printing.PrintDocument
    Friend WithEvents PrintPreviewAbschluss As PrintPreviewDialog
    Private WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents NeueDatenbankToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents ToolFensterZurücksetzenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents BeendenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZwischenergebnisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EndergebnisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EinstellungenToolStripMenuItem1 As ToolStripMenuItem
End Class
