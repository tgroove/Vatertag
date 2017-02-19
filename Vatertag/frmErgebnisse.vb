Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Threading

Public Class frmErgebnisse

    Private Structure strucErgebnisse
        Public Wert As Integer
        Public Neu As Boolean
    End Structure

    Private Ergebnisse(10) As strucErgebnisse

    Private AlteErgebnisse As String
    Private GelöschteErgebnisse As String


    Public Sub FillData(ID As Integer)
        Dim daten As strucTeilnehmer
        Dim i As Integer
        daten = GetTeilnehmerData(ID)
        lblNr.Text = daten.Nr
        lblName.Text = daten.Name
        Ergebnisse(0).Wert = daten.Scheibe1
        Ergebnisse(1).Wert = daten.Scheibe2
        Ergebnisse(2).Wert = daten.Scheibe3
        Ergebnisse(3).Wert = daten.Scheibe4
        Ergebnisse(4).Wert = 0
        Ergebnisse(5).Wert = 0
        Ergebnisse(6).Wert = 0
        Ergebnisse(7).Wert = 0
        For i = 0 To 9
            Ergebnisse(i).Neu = False
        Next

        AlteErgebnisse = Ergebnisse(0).Wert & ", " _
            & Ergebnisse(1).Wert & ", " _
            & Ergebnisse(2).Wert & ", " _
            & Ergebnisse(3).Wert
        GelöschteErgebnisse = ""
        UpdateWerte()

        'lblErg1.Text = daten.Scheibe1
        'lblErg2.Text = daten.Scheibe2
        'lblErg3.Text = daten.Scheibe3
        'lblErg4.Text = daten.Scheibe4
        'lblErg5.Text = ""
        'lblErg6.Text = ""
        'lblErg7.Text = ""
        'lblErg8.Text = ""
        'txtErgebnis.Text = ""

        'lblErg1.ForeColor = SystemColors.ControlText
        'lblErg2.ForeColor = SystemColors.ControlText
        'lblErg3.ForeColor = SystemColors.ControlText
        'lblErg4.ForeColor = SystemColors.ControlText
        'lblErg5.ForeColor = SystemColors.ControlText
        'lblErg6.ForeColor = SystemColors.ControlText
        'lblErg7.ForeColor = SystemColors.ControlText
        'lblErg8.ForeColor = SystemColors.ControlText

    End Sub

    Private Sub UpdateWerte()
        ErgebnisSort()
        lblErg1.Text = Ergebnisse(0).Wert
        lblErg2.Text = Ergebnisse(1).Wert
        lblErg3.Text = Ergebnisse(2).Wert
        lblErg4.Text = Ergebnisse(3).Wert
        lblErg5.Text = Ergebnisse(4).Wert
        lblErg6.Text = Ergebnisse(5).Wert
        lblErg7.Text = Ergebnisse(6).Wert
        lblErg8.Text = Ergebnisse(7).Wert
        txtErgebnis.Text = ""

        lblErg1.ForeColor = IIf(Ergebnisse(0).Neu, Color.Red, SystemColors.ControlText)
        lblErg2.ForeColor = IIf(Ergebnisse(1).Neu, Color.Red, SystemColors.ControlText)
        lblErg3.ForeColor = IIf(Ergebnisse(2).Neu, Color.Red, SystemColors.ControlText)
        lblErg4.ForeColor = IIf(Ergebnisse(3).Neu, Color.Red, SystemColors.ControlText)
        lblErg5.ForeColor = IIf(Ergebnisse(4).Neu, Color.Red, SystemColors.ControlText)
        lblErg6.ForeColor = IIf(Ergebnisse(5).Neu, Color.Red, SystemColors.ControlText)
        lblErg7.ForeColor = IIf(Ergebnisse(6).Neu, Color.Red, SystemColors.ControlText)
        lblErg8.ForeColor = IIf(Ergebnisse(7).Neu, Color.Red, SystemColors.ControlText)

    End Sub


    Private Sub ErgebnisSort()
        Dim vTemp As strucErgebnisse
        For j = UBound(Ergebnisse) - 1 To LBound(Ergebnisse) Step -1
            ' Alle links davon liegenden Zeichen auf richtige Sortierung 
            ' der jeweiligen Nachfolger überprüfen: 
            For i = LBound(Ergebnisse) To j
                ' Ist das aktuelle Element seinem Nachfolger gegenüber korrekt sortiert? 
                If Ergebnisse(i).Wert < Ergebnisse(i + 1).Wert Then
                    ' Element und seinen Nachfolger vertauschen. 
                    vTemp = Ergebnisse(i)
                    Ergebnisse(i) = Ergebnisse(i + 1)
                    Ergebnisse(i + 1) = vTemp
                End If
            Next i
        Next j
    End Sub

    Private Sub frmErgebnisse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtErgebnis_TextChanged(sender As Object, e As EventArgs) Handles txtErgebnis.TextChanged

    End Sub

    Private Sub txtErgebnis_KeyDown(sender As Object, e As KeyEventArgs) Handles txtErgebnis.KeyDown
        Select Case e.KeyData
            Case Keys.D0 To Keys.D9
            Case Keys.NumPad0 To Keys.NumPad9
            'Case Keys.Decimal, Keys.OemPeriod
            Case Keys.Delete, Keys.Back
            'Case Keys.Separator
            Case Keys.Enter, Keys.Return
                If txtErgebnis.Text = "" Then
                    cmdOK.Focus()
                Else
                    Ergebnisse(9).Wert = Val(txtErgebnis.Text)
                    Ergebnisse(9).Neu = True
                    UpdateWerte()
                End If
            Case Else
                e.Handled = True
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub cmdClr_Click(sender As Object, e As EventArgs) Handles cmdClr.Click
        FillData(Val(lblNr.Text))
        txtErgebnis.Focus()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim RecordsAffected As Integer
        Dim queryString As String
        Dim LogText As String
        Dim NeueErgebnisse As String = ""
        Dim i As Integer
        queryString = "UPDATE Kunden " _
                & " SET Scheibe1=" & Ergebnisse(0).Wert & ", " _
                & " Scheibe2=" & Ergebnisse(1).Wert & ", " _
                & " Scheibe3=" & Ergebnisse(2).Wert & ", " _
                & " Scheibe4=" & Ergebnisse(3).Wert & ", " _
                & " Aenderung='" & Now() & "' " _
                & " WHERE ID=" & lblNr.Text & ";"
        For i = 0 To 3
            If Ergebnisse(i).Neu Then NeueErgebnisse = NeueErgebnisse & Ergebnisse(i).Wert & ", "
        Next
        If GelöschteErgebnisse <> "" Then
            LogText = "Ergebnisse von """ & lblName.Text & """ (" & lblNr.Text & ") geändert auf " _
                & Ergebnisse(0).Wert & ", " _
                & Ergebnisse(1).Wert & ", " _
                & Ergebnisse(2).Wert & ", " _
                & Ergebnisse(3).Wert _
                & " (war: " & AlteErgebnisse & ")."

        ElseIf NeueErgebnisse <> "" Then
        LogText = "Ergebnisse von """ & lblName.Text & """ (" & lblNr.Text & ") hinzugefügt: " _
                & NeueErgebnisse.Remove(NeueErgebnisse.Length - 2) _
                & " (war: " & AlteErgebnisse & ")."
        Else
            LogText = "Keine neuen Ergebnisse für """ & lblName.Text & """ (" & lblNr.Text & ")."
        End If

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)
            Try
                connection.Open()
                Dim dataReader As OleDbDataReader =
                 command.ExecuteReader()
                RecordsAffected = dataReader.RecordsAffected
                dataReader.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Console.ReadLine()
        End Using

        If RecordsAffected <> 1 Then
            MsgBox("Datensatz konnte nicht geändert werden")
        Else
            AddLog(LogText, IIf(GelöschteErgebnisse <> "", True, False))
            frmSuche.Clear()
            Me.Hide()
        End If

        frmTop10.tmrRangliste.Interval = 250

    End Sub

    Private Sub lblErg1_Click(sender As Object, e As EventArgs) Handles lblErg1.Click

    End Sub

    Private Sub lblErg1_DoubleClick(sender As Object, e As EventArgs) Handles lblErg1.DoubleClick
        If vbYes = MsgBox("Ergebnis " & lblErg1.Text & " löschen?", vbQuestion + vbYesNo) Then
            GelöschteErgebnisse = lblErg1.Text & ", "
            Ergebnisse(0).Wert = 0
            UpdateWerte()
        End If
    End Sub
    Private Sub lblErg2_DoubleClick(sender As Object, e As EventArgs) Handles lblErg2.DoubleClick
        If vbYes = MsgBox("Ergebnis " & lblErg2.Text & " löschen?", vbQuestion + vbYesNo) Then
            GelöschteErgebnisse = lblErg2.Text & ", "
            Ergebnisse(1).Wert = 0
            UpdateWerte()
        End If
    End Sub
    Private Sub lblErg3_DoubleClick(sender As Object, e As EventArgs) Handles lblErg3.DoubleClick
        If vbYes = MsgBox("Ergebnis " & lblErg3.Text & " löschen?", vbQuestion + vbYesNo) Then
            GelöschteErgebnisse = lblErg3.Text & ", "
            Ergebnisse(2).Wert = 0
            UpdateWerte()
        End If
    End Sub
    Private Sub lblErg4_DoubleClick(sender As Object, e As EventArgs) Handles lblErg4.DoubleClick
        If vbYes = MsgBox("Ergebnis " & lblErg4.Text & " löschen?", vbQuestion + vbYesNo) Then
            GelöschteErgebnisse = lblErg4.Text & ", "
            Ergebnisse(3).Wert = 0
            UpdateWerte()
        End If
    End Sub
End Class