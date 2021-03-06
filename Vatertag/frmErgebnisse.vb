﻿Imports System
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
        Dim res As String
        daten = GetTeilnehmerData(ID)
        Console.WriteLine("FillData " & daten.Nr & ", " & daten.Scheibe1 & ", " & daten.Scheibe2 & ", " & daten.Scheibe3 & ", " & daten.Scheibe4)
        res = CheckData(ID, daten.Nr & ": " & daten.Scheibe1 & ";" & daten.Scheibe2 & ";" & daten.Scheibe3 & ";" & daten.Scheibe4)
        If res <> "OK" And res <> "New" Then
            MsgBox("Konsistenz-Fehler", MsgBoxStyle.Critical, "Vatertagsschießen")
        End If
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
        Ergebnisse(8).Wert = 0
        Ergebnisse(9).Wert = 0
        For i = 0 To 9
            Ergebnisse(i).Neu = False
        Next

        AlteErgebnisse = Ergebnisse(0).Wert & ", " _
            & Ergebnisse(1).Wert & ", " _
            & Ergebnisse(2).Wert & ", " _
            & Ergebnisse(3).Wert
        GelöschteErgebnisse = ""
        UpdateWerte()

        Console.WriteLine(GetTimeStamp() _
                          & " Nr: " & daten.Nr & "," _
                          & " Name: """ & daten.Name & """, " _
                          & " Scheiben: " & daten.Scheibe1 _
                          & ", " & daten.Scheibe2 _
                          & ", " & daten.Scheibe3 _
                          & ", " & daten.Scheibe4)


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
        Console.Write("Sort1:" & Ergebnisse(0).ToString & ", " &
                      Ergebnisse(1).ToString & ", " &
                      Ergebnisse(2).ToString & ", " &
                      Ergebnisse(3).ToString & ", " &
                      Ergebnisse(4).ToString & ", " &
                      Ergebnisse(5).ToString & ", " &
                      Ergebnisse(6).ToString & ", " &
                      Ergebnisse(7).ToString & ", " &
                      Ergebnisse(8).ToString & ", " &
                      Ergebnisse(9).ToString)
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
        Console.Write("Sort2:" & Ergebnisse(0).ToString & ", " &
                      Ergebnisse(1).ToString & ", " &
                      Ergebnisse(2).ToString & ", " &
                      Ergebnisse(3).ToString & ", " &
                      Ergebnisse(4).ToString & ", " &
                      Ergebnisse(5).ToString & ", " &
                      Ergebnisse(6).ToString & ", " &
                      Ergebnisse(7).ToString & ", " &
                      Ergebnisse(8).ToString & ", " &
                      Ergebnisse(9).ToString)
    End Sub

    Private Sub frmErgebnisse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolTip.SetToolTip(Me.lblErg1, "Doppelklick löscht Ergebnis")
        ToolTip.SetToolTip(Me.lblErg2, "Doppelklick löscht Ergebnis")
        ToolTip.SetToolTip(Me.lblErg3, "Doppelklick löscht Ergebnis")
        ToolTip.SetToolTip(Me.lblErg4, "Doppelklick löscht Ergebnis")
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
                    Uebernehmen()
                    'cmdOK.Focus()
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
        If lblNr.Text = 0 Then MsgBox("lblNr.Text ist 0", MsgBoxStyle.Critical)
        FillData(Val(lblNr.Text))
        txtErgebnis.Focus()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Uebernehmen()
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

    Private Sub frmErgebnisse_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
            frmSuche.Clear()
        End If
    End Sub

    Private Sub txtErgebnis_TextChanged(sender As Object, e As EventArgs) Handles txtErgebnis.TextChanged

    End Sub

    Private Sub Uebernehmen()
        Dim RecordsAffected As Integer
        Dim queryString As String
        Dim LogText As String
        Dim NeueErgebnisse As String = ""
        Dim i As Integer
        Dim done As Boolean = False
        Dim res As String
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
            Console.WriteLine(GetTimeStamp() & " queryString: " & queryString)
            Dim dataReader As OleDbDataReader '= command.ExecuteReader()

            done = False
            Do
                Try
                    If connection.State = ConnectionState.Closed Then connection.Open()
                    dataReader = command.ExecuteReader()

                    RecordsAffected = dataReader.RecordsAffected
                    dataReader.Close()
                    done = True
                Catch ex As Exception
                    Console.WriteLine(GetTimeStamp() & " cmdOK failed: " & ex.Message)
                    If MsgBox(ex.Message, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then done = True
                End Try
            Loop Until done

            Console.ReadLine()
        End Using

        If RecordsAffected <> 1 Then
            Console.WriteLine(GetTimeStamp() & " cmdOK failed. RecordsAffected = " & RecordsAffected)
            MsgBox("Datensatz konnte nicht geändert werden")
        Else
            res = CheckData(Val(lblNr.Text), Val(lblNr.Text) & ": " & Ergebnisse(0).Wert & ";" & Ergebnisse(1).Wert & ";" & Ergebnisse(2).Wert & ";" & Ergebnisse(3).Wert, True)
            If res <> "Update" And res <> "OK" Then
                MsgBox("Konsistenz-Fehler", MsgBoxStyle.Critical, "Vatertagsschießen")
            End If
            AddLog(LogText, IIf(GelöschteErgebnisse <> "", True, False))
            frmSuche.Clear()
            Me.Hide()
        End If

        frmTop10.tmrRangliste.Interval = 250

    End Sub
End Class