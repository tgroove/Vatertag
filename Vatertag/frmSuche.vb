﻿Option Explicit On
'Option Strict On

Imports System
Imports System.Data
Imports System.IO
Imports System.Data.OleDb



Public Class frmSuche
    Private PrintFromDataSet As Integer
    Private Ergebnis As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNeu.Click
        'Dim connStr, objConn
        '        Dim connectionString As String =
        '            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Dropbox\Eigene Dateien\Vatertag.accdb;"
        Dim queryString As String

        If connectionString = "" Then Exit Sub

        queryString = "SELECT ID FROM Kunden WHERE Name = '" & txtTName.Text & "';"
        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)
            Try
                connection.Open()
                Dim dataReader As OleDbDataReader =
                 command.ExecuteReader()
                Dim TlnNr As Integer
                If dataReader.HasRows Then

                    dataReader.Read()
                    TlnNr = dataReader(0)
                    If mode = "Verkauf" Then
                        frmVerkauf.FillData(TlnNr)
                        frmVerkauf.Show()
                        frmVerkauf.txtScheibenNeu.Focus()
                    Else
                        frmErgebnisse.FillData(TlnNr)
                        frmErgebnisse.Show()
                        frmErgebnisse.txtErgebnis.Focus()
                    End If
                    Exit Sub
                End If
                dataReader.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Console.ReadLine()
        End Using



        If txtTName.Text = "" Then Exit Sub

        'Neuen Kunden anlegen
        queryString = "INSERT INTO Kunden (Name, Aenderung) " _
            & "VALUES ('" & txtTName.Text & "', '" & Now() & "');"

        Using connection As New OleDbConnection(connectionString)
            Dim command2 As New OleDbCommand(queryString, connection)
            Try
                connection.Open()
                Dim dataReader2 As OleDbDataReader =
                 command2.ExecuteReader()
                If dataReader2.RecordsAffected <> 1 Then
                    MsgBox("Datensatz konnte nicht hinzugefügt werden")
                    dataReader2.Close()
                    Exit Sub
                End If
                dataReader2.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Console.ReadLine()
        End Using

        ' Neue ID ermitteln
        queryString = "SELECT COUNT(*) FROM Kunden;"
        Using connection As New OleDbConnection(connectionString)
            Dim command2 As New OleDbCommand(queryString, connection)
            Try
                connection.Open()
                Dim dataReader3 As OleDbDataReader =
                 command2.ExecuteReader()
                dataReader3.Read()
                Dim TlnNr As Integer
                TlnNr = dataReader3(0)
                SetMaxNr(TlnNr)
                frmInfo.SetInfoText("Scheiben für Nummer: " & TlnNr)
                frmVerkauf.FillData(TlnNr)
                frmVerkauf.Show()
                frmVerkauf.txtScheibenNeu.Focus()
                AddLog("Neuer Kunde """ & txtTName.Text & """ mit der Nummer " & dataReader3(0) & " hinzugefügt.")
                dataReader3.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Console.ReadLine()
        End Using
    End Sub

    Public Sub PopList(tlnr() As String)
        Dim Filter As String
        Dim n As Integer
        If txtTName.Text <> "" Then
            Filter = Trim(txtTName.Text)
        Else
            Filter = Trim(txtTNummer.Text)
        End If


        With lstTeilnehmer.Items
            .Clear()
            For n = 0 To UBound(tlnr)
                If Filter <> "" Then
                    If InStr(1, tlnr(n), Filter, CompareMethod.Text) > 0 Then .Add(tlnr(n))
                Else
                    .Add(tlnr(n))
                End If
            Next
        End With
    End Sub

    Private Sub mnuOpenDB_Click(sender As Object, e As EventArgs) Handles mnuOpenDB.Click
        Dim FileName As String = My.Settings.lastFile
        frmTop10.tmrRangliste.Enabled = False
        OpenFileDialog.CheckFileExists = True
        OpenFileDialog.InitialDirectory = FileName
        OpenFileDialog.FileName = Path.GetFileName(FileName)
        If OpenFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            FileName = OpenFileDialog.FileName
            frmTop10.tmrRangliste.Enabled = True
            If OpenFileDialog.FileName <> "" Then
                My.Settings.lastFile = FileName
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & FileName & "; OLE DB Services=-1"
                PopulateList()
                frmInfo.SetInfoText("Nächste neue Nummer: " & GetMaxNr() + 1)
                AddLog("Datenbank: " & FileName, False)
            End If
        End If

    End Sub

    Private Sub frmSuche_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScheibenPreis = My.Settings.ScheibenPreis
        Grundpreis = My.Settings.GrundPreis
        Dim filename As String = My.Settings.lastFile
        If My.Settings.Mode = "Verkauf" Then
            mode = "Verkauf"
        Else
            mode = "Auswertung"
        End If
        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filename & "; OLE DB Services=-1"
        connectionString = ""
        PopulateList()
        lblAenderung.Text = ""
        lblPlatzierung.Text = ""
        lblErgebnisse.Text = ""

        '        OpenFileDialog.ShowDialog()

        Dim desktopSize As Size
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize

        frmInfo.StartPosition = FormStartPosition.Manual
        frmInfo.Location = New Point(10, 10)
        If mode = "Verkauf" Then frmInfo.Show()
        frmInfo.SetInfoText("Keine Datenbank geladen.")

        frmTop10.StartPosition = FormStartPosition.Manual
        frmTop10.Location = New Point(desktopSize.Width - frmTop10.Width - 10, 10)
        frmTop10.Show()
        frmTop10.tmrRangliste.Enabled = True

    End Sub

    Private Sub txtTName_TextChanged(sender As Object, e As EventArgs) Handles txtTName.TextChanged
        txtTNummer.Text = ""
        PopulateList()
    End Sub

    Private Sub txtTNummer_TextChanged(sender As Object, e As EventArgs) Handles txtTNummer.TextChanged
        txtTName.Text = ""
        PopulateList()

    End Sub

    Private Sub txtTNummer_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTNummer.KeyDown
        If e.KeyData = Keys.Enter Then
            If lstTeilnehmer.Items.Count > 0 Then
                lstTeilnehmer.SetSelected(0, True)
                lstTeilnehmer.Focus()
            End If
        End If
    End Sub

    Private Sub txtTName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTName.KeyDown
        If e.KeyData = Keys.Enter Then
            If lstTeilnehmer.Items.Count > 0 Then
                lstTeilnehmer.SetSelected(0, True)
                lstTeilnehmer.Focus()
            Else
                btnNeu.Focus()
            End If
        End If
    End Sub

    Private Sub EinstellungenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EinstellungenToolStripMenuItem.Click
        frmEinstellungen.Show()
    End Sub

    Private Sub lstTeilnehmer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstTeilnehmer.SelectedIndexChanged
        Dim TlnDetails As strucTeilnehmer
        Dim TlnNr As Integer
        If lstTeilnehmer.SelectedItems.Count = 1 Then
            TlnNr = Val(Trim(lstTeilnehmer.SelectedItem.ToString.Substring(0, 3)))
            TlnDetails = GetTeilnehmerData(TlnNr)
            lblAenderung.Text = Format(TlnDetails.Aenderung, "hh:mm:ss")
            lblPlatzierung.Text = TlnDetails.Platzierung
            lblErgebnisse.Text = TlnDetails.Scheibe1 & "  " _
                & TlnDetails.Scheibe2 & "  " _
                & TlnDetails.Scheibe3 & "  " _
                & TlnDetails.Scheibe4
        Else
            lblAenderung.Text = ""
            lblPlatzierung.Text = ""
            lblErgebnisse.Text = ""
        End If

    End Sub

    Private Sub lstTeilnehmer_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstTeilnehmer.MouseDoubleClick
        Dim TlnNr As Integer
        If lstTeilnehmer.SelectedItems.Count = 1 Then
            TlnNr = Val(Trim(lstTeilnehmer.SelectedItem.ToString.Substring(0, 3)))
            If mode = "Verkauf" Then
                frmVerkauf.FillData(TlnNr)
                frmVerkauf.Show()
                frmVerkauf.txtScheibenNeu.Focus()
            Else
                frmErgebnisse.FillData(TlnNr)
                frmErgebnisse.Show()
                frmErgebnisse.txtErgebnis.Focus()
            End If

        End If
    End Sub

    Private Sub lstTeilnehmer_KeyDown(sender As Object, e As KeyEventArgs) Handles lstTeilnehmer.KeyDown
        Dim TlnNr As Integer
        If e.KeyData = Keys.Enter Then
            If lstTeilnehmer.SelectedItems.Count = 1 Then
                TlnNr = Val(Trim(lstTeilnehmer.SelectedItem.ToString.Substring(0, 3)))
                If mode = "Verkauf" Then
                    frmVerkauf.FillData(TlnNr)
                    frmVerkauf.Show()
                    frmVerkauf.txtScheibenNeu.Focus()
                Else
                    frmErgebnisse.FillData(TlnNr)
                    frmErgebnisse.Show()
                    frmErgebnisse.txtErgebnis.Focus()
                End If
            End If
        End If
    End Sub

    Public Sub Clear()
        txtTName.Text = ""
        txtTNummer.Text = ""
        PopulateList()
    End Sub


    Public Sub UpdateRTB(Text As String)
        rtbLog.Rtf = Text
    End Sub



    Private Sub lstTeilnehmer_Leave(sender As Object, e As EventArgs) Handles lstTeilnehmer.Leave
        'lblAenderung.Text = ""
        'lblPlatzierung.Text = ""
        'lblErgebnisse.Text = ""
        lstTeilnehmer.ClearSelected()
    End Sub

    Private Sub frmSuche_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmSuche_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Escape Then
            txtTName.Text = ""
            txtTNummer.Text = ""
            txtTNummer.Focus()
        End If
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintErgebnisse.PrintPage
        Dim fontHead As New Font("Arial", 36)
        Dim fontReg As New Font("Arial", 14)
        Dim fontNr As New Font("Arial", 10)

        Dim x As Integer
        Dim y As Integer
        Dim dy As Single
        Dim x2 As Integer
        Dim p1 As Point
        Dim p2 As Point

        Dim queryString As String
        Dim n As Integer
        Dim Erg As String

        Dim StrFormat As New StringFormat()
        Dim LastErg As String = ""
        Dim TellImage As Image = Image.FromFile("TELLCOMP.BMP")
        Dim rtf As String = "{\rtf1\ansi\deff0 {\fonttbl {\f0 Arial;}}"
        queryString = "SELECT ID, Name, Platzierung, Scheibe1, Scheibe2, Scheibe3, Scheibe4 " _
            & " FROM Kunden " _
            & " WHERE Scheiben>0 " _
            & " ORDER BY Scheibe1 DESC, Scheibe2 DESC, Scheibe3 DESC, Scheibe4 DESC ;"



        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)
            Dim stringSize As New SizeF
            Try
                connection.Open()
                Dim dataReader As OleDbDataReader =
                    command.ExecuteReader()

                n = 0
                x = 100
                x2 = 550
                If PrintFromDataSet = 1 Then
                    y = 0
                    StrFormat.Alignment = StringAlignment.Center
                    e.Graphics.DrawString("Vatertagschießen " & Format(Now(), "yyyy"), fontReg, Brushes.Black, x + 300, y + 0, StrFormat)
                    y = 50
                    e.Graphics.DrawString(Ergebnis, fontHead, Brushes.Black, x, y)
                    e.Graphics.DrawString("Stand: " & Format(Now(), "HH:mm"), fontReg, Brushes.Black, x, y + 60)
                    e.Graphics.DrawImage(TellImage, e.MarginBounds.Width - 50, 0, 150, 135)
                    y = y + 70
                Else
                    y = 1
                End If

                Do While dataReader.Read()
                    ''Erg = dataReader(3).ToString & "  " _
                    '    & dataReader(4).ToString & "  " _
                    '    & dataReader(5).ToString & "  " _
                    '    & dataReader(6).ToString
                    n = n + 1
                    If n >= PrintFromDataSet Then
                        y = y + 30
                        ' Platzierung
                        e.Graphics.DrawString(dataReader(2).ToString, fontReg, Brushes.Black, x, y)
                        ' Name
                        e.Graphics.DrawString(dataReader(1).ToString, fontReg, Brushes.Black, x + 40, y)

                        dy = e.Graphics.MeasureString("0", fontReg).Height - e.Graphics.MeasureString("0", fontNr).Height
                        stringSize = e.Graphics.MeasureString(dataReader(1).ToString, fontReg)
                        e.Graphics.DrawString("(" & dataReader(0).ToString & ")", fontNr, Brushes.Black, x + 40 + stringSize.Width, y + dy / 2 + 1)
                        ' Ergebnisse
                        e.Graphics.DrawString(dataReader(3).ToString, fontReg, Brushes.Black, x2, y)
                        e.Graphics.DrawString(dataReader(4).ToString, fontReg, Brushes.Black, x2 + 40, y)
                        e.Graphics.DrawString(dataReader(5).ToString, fontReg, Brushes.Black, x2 + 80, y)
                        e.Graphics.DrawString(dataReader(6).ToString, fontReg, Brushes.Black, x2 + 120, y)

                        p1.X = x
                        p1.Y = y + 25
                        p2.X = x2 + 150
                        p2.Y = p1.Y
                        e.Graphics.DrawLine(Pens.Black, p1, p2)
                        If y > e.MarginBounds.Bottom - 15 Then
                            e.HasMorePages = True
                            Exit Do
                        End If
                    End If
                Loop
                dataReader.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Using

        If e.HasMorePages = True Then
            PrintFromDataSet = n + 1
        Else
            PrintFromDataSet = 1
        End If
    End Sub

    Private Sub DruckenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim docName As String = "Ergebnisse"
        PrintErgebnisse.DocumentName = docName
        PrintFromDataSet = 1
        If vbYes = MsgBox("Handelt es sich um das Endergebnis?", vbQuestion + vbYesNo + vbDefaultButton2) Then
            Ergebnis = "Endergebnis"
        Else
            Ergebnis = "Zwischenergebnis"
        End If

        PrintErgebnisse.Print()

    End Sub

    Private Sub DruckvorschauToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DruckvorschauToolStripMenuItem.Click
        Dim docName As String = "Ergebnisse"
        PrintErgebnisse.DocumentName = docName
        PrintFromDataSet = 1
        If vbYes = MsgBox("Handelt es sich um das Endergebnis?", vbQuestion + vbYesNo + vbDefaultButton2) Then
            Ergebnis = "Endergebnis"
        Else
            Ergebnis = "Zwischenergebnis"
        End If
        PrintPreviewErgebnisse.WindowState = FormWindowState.Maximized
        PrintPreviewErgebnisse.ShowDialog()

    End Sub

    Private Sub PrintAbschluss_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintAbschluss.PrintPage
        Dim fontHead As New Font("Arial", 36)
        Dim fontReg As New Font("Arial", 14)
        Dim fontRegBold As New Font("Arial", 14, FontStyle.Bold)

        Dim x As Integer
        Dim y As Integer
        Dim x2 As Integer
        Dim p1 As Point
        Dim p2 As Point

        Dim queryString As String
        Dim n As Integer
        Dim c As strucCounts

        Dim StrFormat As New StringFormat()
        Dim LastErg As String = ""
        Dim TellImage As Image = Image.FromFile("TELLCOMP.BMP")
        Dim rtf As String = "{\rtf1\ansi\deff0 {\fonttbl {\f0 Arial;}}"
        queryString = "SELECT ID, Name, Platzierung, Scheiben" _
            & " FROM Kunden " _
            & " ORDER BY ID ASC;"

        c = GetCounts()
        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)
            Try
                connection.Open()
                Dim dataReader As OleDbDataReader =
                    command.ExecuteReader()

                n = 0
                x = 100
                x2 = 450
                If PrintFromDataSet = 1 Then
                    y = 0
                    StrFormat.Alignment = StringAlignment.Center
                    e.Graphics.DrawString("Vatertagschießen " & Format(Now(), "yyyy"), fontReg, Brushes.Black, x + 300, y + 0, StrFormat)
                    y = 50
                    e.Graphics.DrawString("Abschluss", fontHead, Brushes.Black, x, y)
                    e.Graphics.DrawString("Stand: " & Format(Now(), "dd.MM.yyyy  HH:mm:ss"), fontReg, Brushes.Black, x, y + 60)
                    e.Graphics.DrawImage(TellImage, e.MarginBounds.Width - 50, 0, 150, 135)
                    y = y + 120
                    e.Graphics.DrawString("Zahlende Teilnehmer:", fontRegBold, Brushes.Black, x, y)
                    e.Graphics.DrawString(c.Teilnehmer, fontReg, Brushes.Black, x + 210, y)
                    y = y + 25
                    e.Graphics.DrawString("Verkaufte Scheiben:", fontRegBold, Brushes.Black, x, y)
                    e.Graphics.DrawString(c.Scheiben, fontReg, Brushes.Black, x + 210, y)
                    y = y + 25
                    e.Graphics.DrawString("Einnahmen:", fontRegBold, Brushes.Black, x, y)
                    e.Graphics.DrawString(Format(c.Scheiben * ScheibenPreis + c.Teilnehmer * Grundpreis, "0.00 €"), fontReg, Brushes.Black, x + 210, y)
                    y = y + 50

                Else
                    y = 1
                End If

                Do While dataReader.Read()
                    n = n + 1
                    If n >= PrintFromDataSet Then
                        y = y + 30
                        ' ID
                        e.Graphics.DrawString(dataReader(0).ToString, fontReg, Brushes.Black, x, y)
                        ' Name
                        e.Graphics.DrawString(dataReader(1).ToString, fontReg, Brushes.Black, x + 40, y)
                        ' Ergebnisse
                        e.Graphics.DrawString("Scheiben: " & dataReader(3).ToString, fontReg, Brushes.Black, x2, y)
                        e.Graphics.DrawString(Format(
                            IIf(Val(dataReader(3).ToString) > 0,
                                CalculateBetragByScheiben(0, Val(dataReader(3).ToString)),
                                0), "0.00 €"), fontReg, Brushes.Black, x2 + 180, y)

                        p1.X = x
                        p1.Y = y + 25
                        p2.X = x2 + 250
                        p2.Y = p1.Y
                        e.Graphics.DrawLine(Pens.Black, p1, p2)
                        If y > e.MarginBounds.Bottom - 15 Then
                            e.HasMorePages = True
                            Exit Do
                        End If
                    End If
                Loop
                dataReader.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Using

        If e.HasMorePages = True Then
            PrintFromDataSet = n + 1
        Else
            PrintFromDataSet = 1
        End If

    End Sub

    Private Sub TagesabschlußToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TagesabschlußToolStripMenuItem.Click

        PrintAbschluss.DocumentName = "Tagesabschluss"
        PrintFromDataSet = 1

        PrintPreviewAbschluss.WindowState = FormWindowState.Maximized
        PrintPreviewAbschluss.ShowDialog()

    End Sub


    Private Sub NeueDatenbankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeueDatenbankToolStripMenuItem.Click
        Dim filename As String
        SaveFileDialog.FileName = "Vatertagschießen " & Format(Now(), "yyyy") & ".accdb"
        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            filename = SaveFileDialog.FileName

            'File.WriteAllBytes(filename, My.Resources.VatertagLeer)
            'File.WriteAllBytes(filename, My.Resources.VatertagLeer)
            Dim Assembly As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly
            Dim s As IO.Stream = Assembly.GetManifestResourceStream(Me.GetType, "VatertagLeer.accdb")

            Dim file As System.IO.FileStream = New System.IO.FileStream(filename, IO.FileMode.Create)
            Using (file)
                Dim buf(4096) As Byte
                Dim bytesRead As Integer = 0
                bytesRead = s.Read(buf, 0, buf.Length())
                While (bytesRead > 0)
                    file.Write(buf, 0, bytesRead)
                    bytesRead = s.Read(buf, 0, buf.Length())
                End While
            End Using

            file = Nothing

            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filename & "; OLE DB Services=-1"
            Dim queryString As String = "ALTER TABLE Kunden AUTO_INCREMENT = 1"
            queryString = "ALTER TABLE Kunden ALTER COLUMN ID COUNTER (1)"
            Using connection As New OleDbConnection(connectionString)
                Dim command2 As New OleDbCommand(queryString, connection)
                Try
                    connection.Open()
                    command2.ExecuteNonQuery()
                    AddLog("Neue Datenbank angelegt: '" & filename & "'", True)
                    lstTeilnehmer.Items.Clear()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End If
    End Sub

    Private Sub frmSuche_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'frmTop10.BringToFront()
        'frmInfo.BringToFront()
        'frmTop10.TopMost = False
        'frmInfo.TopMost = False
        'Me.BringToFront()
    End Sub

    Private Sub ToolFensterZurücksetzenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolFensterZurücksetzenToolStripMenuItem.Click
        frmInfo.StartPosition = FormStartPosition.Manual
        frmInfo.Location = New Point(10, 10)
        If mode = "Verkauf" Then
            frmInfo.Show()
            frmInfo.BringToFront()
            PopulateList()
        End If

        Dim desktopSize As Size
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize

        frmTop10.StartPosition = FormStartPosition.Manual
        frmTop10.Location = New Point(desktopSize.Width - frmTop10.Width - 10, 10)
        frmTop10.Show()
        frmTop10.BringToFront()

    End Sub
End Class