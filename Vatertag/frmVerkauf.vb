Option Explicit On
'Option Strict On

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Threading

Public Class frmVerkauf
    Private locked As Boolean = False

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub frmVerkauf_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub FillData(Nr As Integer)
        Dim data As strucTeilnehmer

        data = GetTeilnehmerData(Nr)
        lblNr.Text = data.Nr
        txtName.Text = data.Name
        txtName.Tag = data.Name
        txtScheibenAlt.Text = data.Scheiben
        txtScheibenAlt.Tag = data.Scheiben
        txtScheibenNeu.Text = ""
        txtScheibenNeu.Enabled = True
        txtBetragNeu.Enabled = True
        cmdTotal.Text = "Total"
        lblRest.Text = ""

    End Sub

    Private Sub txtScheibenNeu_TextChanged(sender As Object, e As EventArgs) Handles txtScheibenNeu.TextChanged
        If Not (locked) Then
            locked = True
            txtBetragNeu.Text = Format(CalculateBetragByScheiben(Val(txtScheibenAlt.Text), Val(txtScheibenNeu.Text)), "0.00")
            locked = False
        End If
        If (Val(txtScheibenNeu.Text) > 0) Then
            frmInfo.SetInfoText(txtScheibenNeu.Text & " Scheiben für Nummer: " & lblNr.Text)
        Else
            frmInfo.SetInfoText("Scheiben für Nummer: " & lblNr.Text)
        End If
    End Sub

    Private Sub txtBetragNeu_TextChanged(sender As Object, e As EventArgs) Handles txtBetragNeu.TextChanged
        If Not (locked) Then
            locked = True
            Dim Scheiben As Single = CalculateScheibenByBetrag(Val(txtScheibenAlt.Text), Val(txtBetragNeu.Text))
            txtScheibenNeu.Text = Fix(Scheiben)
            locked = False
            If Fix(Scheiben) <> Scheiben Then
                Dim Betrag As Single = CalculateBetragByScheiben(Val(txtScheibenAlt.Text), Fix(Scheiben))
                lblRest.Text = Format(Betrag, "0.00") & "€" & vbLf & "Rest " & Format(Val(txtBetragNeu.Text) - Betrag, "0.00") & "€"
            Else
                lblRest.Text = ""
            End If

        End If

    End Sub



    Private Sub txtScheibenNeu_KeyDown(sender As Object, e As KeyEventArgs) Handles txtScheibenNeu.KeyDown
        If e.KeyData = Keys.Enter Then cmdTotal.Focus()
    End Sub

    Private Sub txtBetragNeu_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBetragNeu.KeyDown
        If e.KeyData = Keys.Enter Then cmdTotal.Focus()
    End Sub

    Private Sub txtBetragNeu_LostFocus(sender As Object, e As EventArgs) Handles txtBetragNeu.LostFocus
        If Not (locked) Then
            locked = True
            txtBetragNeu.Text = Format(Val(txtBetragNeu.Text), "0.00")
            locked = False
        End If
    End Sub

    Private Sub txtScheibenAlt_TextChanged(sender As Object, e As EventArgs) Handles txtScheibenAlt.TextChanged
        If txtScheibenAlt.Text <> txtScheibenAlt.Tag Then
            txtScheibenNeu.Text = ""
            txtScheibenNeu.Enabled = False
            txtBetragNeu.Text = ""
            txtBetragNeu.Enabled = False
            cmdTotal.Text = "OK"
        Else
            txtScheibenNeu.Enabled = True
            txtBetragNeu.Enabled = True
            cmdTotal.Text = "Total"
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        If txtName.Text <> txtName.Tag Then
            txtScheibenNeu.Text = ""
            txtScheibenNeu.Enabled = False
            txtBetragNeu.Text = ""
            txtBetragNeu.Enabled = False
            cmdTotal.Text = "OK"
        Else
            txtScheibenNeu.Enabled = True
            txtBetragNeu.Enabled = True
            cmdTotal.Text = "Total"
        End If
    End Sub

    Private Sub cmdTotal_Click(sender As Object, e As EventArgs) Handles cmdTotal.Click
        Dim queryString As String
        Dim RecordsAffected As Integer
        Dim LogText As String = ""

        If sender.Text = "Total" Then
            queryString = "UPDATE Kunden " _
                & " SET Scheiben=" & (Val(txtScheibenNeu.Text) + Val(txtScheibenAlt.Text)).ToString _
                & " WHERE ID=" & lblNr.Text & " ;"
            LogText = txtScheibenNeu.Text & " Scheiben an Kunden """ & txtName.Text & """ (" & lblNr.Text & ") verkauft " _
                & "(vorher " & txtScheibenAlt.Text _
                & ", jetzt zusammen " & (Val(txtScheibenNeu.Text) + Val(txtScheibenAlt.Text)).ToString & " Scheiben)."
        Else
            queryString = "UPDATE Kunden " _
                & " SET Name='" & txtName.Text & "', " _
                & " Scheiben=" & Val(txtScheibenAlt.Text).ToString _
                & " WHERE ID=" & lblNr.Text & ";"
            If txtName.Text <> txtName.Tag And txtScheibenAlt.Text <> txtScheibenAlt.Tag Then
                LogText = "Name von """ & txtName.Tag & """ (" & lblNr.Text & ") auf """ & txtName.Text & """ geändert," _
                    & " sowie gekaufte Scheiben von " & txtScheibenAlt.Tag & " auf " & txtScheibenAlt.Text & "."
            ElseIf txtName.Text <> txtName.Tag Then
                LogText = "Name von """ & txtName.Tag & """ (" & lblNr.Text & ") auf """ & txtName.Text & """ geändert."
            ElseIf txtScheibenAlt.Text <> txtScheibenAlt.Tag Then
                LogText = "Bei Kunde """ & txtName.Tag & """ (" & lblNr.Text & ") die gekauften Scheiben von " & txtScheibenAlt.Tag & " auf " & txtScheibenAlt.Text & " geändert."
            End If
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
            AddLog(LogText, IIf(sender.Text = "OK", True, False))
            frmSuche.Clear()
            frmInfo.SetInfoText("Nächste neue Nummer: " & GetMaxNr() + 1)
            frmSuche.Enabled = True
            Me.Hide()
        End If
    End Sub



    Private Sub lblNr_TextChanged(sender As Object, e As EventArgs) Handles lblNr.TextChanged
        frmInfo.SetInfoText("Scheiben für Nummer: " & lblNr.Text)
    End Sub

    Private Sub frmVerkauf_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        frmSuche.Enabled = False
    End Sub

    Private Sub frmVerkauf_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmSuche.Enabled = True
    End Sub
End Class