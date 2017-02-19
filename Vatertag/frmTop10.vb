Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Threading

Public Class frmTop10
    Private Sub tmrRangliste_Tick(sender As Object, e As EventArgs) Handles tmrRangliste.Tick

        Dim queryString As String
        Dim n As Integer
        Dim Erg As String
        Dim LastErg As String = ""
        Dim offset As Integer
        Dim Pos As Integer
        Dim rtf As String = "{\rtf1\ansi\deff0 {\fonttbl {\f0 Arial;}}"
        queryString = "SELECT ID, Name, Platzierung, Scheibe1, Scheibe2, Scheibe3, Scheibe4 " _
            & " FROM Kunden " _
            & " WHERE Scheibe1 > 0 " _
            & " ORDER BY Scheibe1 DESC, Scheibe2 DESC, Scheibe3 DESC, Scheibe4 DESC;"
        tmrRangliste.Enabled = False
        'Dim x = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Dropbox\Eigene Dateien\Vatertag.accdb; OLE DB Services=-1"


        If connectionString = "" Then Exit Sub
        'MsgBox(connectionString)

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)
            Try
                connection.Open()
                Dim dataReader As OleDbDataReader =
                    command.ExecuteReader()
                n = 0
                Do While dataReader.Read()
                    Erg = dataReader(3).ToString & "  " _
                        & dataReader(4).ToString & "  " _
                        & dataReader(5).ToString & "  " _
                        & dataReader(6).ToString
                    n = n + 1

                    If Erg = LastErg Then
                        offset = offset + 1
                    Else
                        offset = 0
                    End If
                    LastErg = Erg
                    Pos = n - offset
                    If Val(dataReader(2).ToString) <> Pos Then
                        UpdatePosition(Val(dataReader(0).ToString), Pos)
                    End If
                    rtf = rtf & " " & Pos & "  " & dataReader(1).ToString _
                        & "\tqr\tx4320\tab " _
                        & Erg & " \tab\par\pard "
                Loop
                dataReader.Close()
                connection.Close()
                tmrRangliste.Interval = 5000
            Catch ex As Exception
                tmrRangliste.Interval = tmrRangliste.Interval * 10
                MsgBox(ex.Message)
            End Try

            Console.ReadLine()
        End Using
        If rtfRangliste.Rtf <> rtf Then rtfRangliste.Rtf = rtf
        tmrRangliste.Enabled = True
    End Sub


    Private Sub frmTop10_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'e.Cancel = True
    End Sub


    Private Sub frmTop10_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        rtfRangliste.Height = Me.Height - 55
    End Sub

End Class