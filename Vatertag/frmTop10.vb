Imports System.IO
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Threading

Public Class frmTop10
    Private Sub tmrRangliste_Tick(sender As Object, e As EventArgs) Handles tmrRangliste.Tick
        Const FontSize = 100
        Dim queryString As String
        Static Dim n As Integer
        Dim Erg As String
        Dim LastErg As String = ""
        Dim offset As Integer
        Dim Pos As Integer
        Dim fieldcount As Integer = 0
        Dim Spaltentrenner1 As Integer
        Dim Spaltentrenner2 As Integer
        Dim FontSizeFactor As Single
        Dim done As Boolean = False
        Dim rtf As String = "{\rtf1\ansi\deff0 {\fonttbl {\f0 Arial;}}"

        Select Case n
            Case > 30
                '3 Spalten
                Spaltentrenner1 = n / 3 + 0.4
                Spaltentrenner2 = (n - Spaltentrenner1) / 2 + 0.4 + Spaltentrenner1
                FontSizeFactor = 0.8
            Case > 15
                '2 Spalten
                Spaltentrenner1 = n / 2 + 0.1
                Spaltentrenner2 = -1
                FontSizeFactor = 1
            Case Else
                '1 Spalte
                Spaltentrenner1 = -1
                Spaltentrenner2 = -1
                FontSizeFactor = 1.1
        End Select

        Dim html As String = "<!DOCTYPE html>" & vbCrLf _
          & "<html lang=""de"">" & vbCrLf _
          & "  <head>" & vbCrLf _
          & "  <meta charset=""utf-8"" /> " & vbCrLf _
          & "    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />" & vbCrLf _
          & "    <meta http-equiv=""refresh"" content=""5; URL=rangliste.html"">" & vbCrLf _
          & "    <title>Aktuelle Rangliste</title>" & vbCrLf _
          & "    <style>" & vbCrLf _
          & "      table {" & vbCrLf _
          & "        margin:          0px auto;" & vbCrLf _
          & "        font-family:     'Liberation Sans', Arial, Helvetica, sans-serif;" & vbCrLf _
          & "        font-size:       " & CInt(0.7 * FontSize) & "pt;" & vbCrLf _
          & "        border-collapse: collapse;" & vbCrLf _
          & "      }" & vbCrLf _
          & "      th, td {" & vbCrLf _
          & "        Padding-Top:    5px;" & vbCrLf _
          & "        Padding-Bottom: 5px;" & vbCrLf _
          & "        Padding-Left:   11px;" & vbCrLf _
          & "        Padding-Right:  11px;" & vbCrLf _
          & "        border-spacing: 0px; " & vbCrLf _
          & "        Font-family:    'Liberation Sans', Arial, Helvetica, sans-serif;" & vbCrLf _
          & "        font-size:      " & CInt(0.25 * FontSize * FontSizeFactor) & "pt;" & vbCrLf _
          & "        xText-align:    center;" & vbCrLf _
          & "      }" & vbCrLf _
          & "      td {" & vbCrLf _
          & "        border-top:     3px solid #000;" & vbCrLf _
          & "        border-bottom:  3px solid #000;" & vbCrLf _
          & "      }" & vbCrLf _
          & "    </style>" & vbCrLf _
          & "  </head>" & vbCrLf _
          & "  <body>" & vbCrLf _
          & "    <font face=""Helvetica"">" & vbCrLf _
          & "      <p><strong><div style=""font-size:" & CInt(0.6 * FontSize) & "pt;text-align:center"">Aktuelle Rangliste</div></strong></p>" & vbCrLf _
          & "      <table  border=""5"" bordercolor=WHITE>" & vbCrLf _
          & "        <tr>" & vbCrLf _
          & "          <td valign=""top"">" & vbCrLf _
          & "            <table>"

        '& "        <caption><strong><span style=""font-size:" & CInt(0.7 * FontSize) & "pt"">&nbsp;</span>Aktuelle Rangliste<span style=""font-size:" & CInt(0.7 * FontSize) & "pt"">&nbsp;</span></strong></caption>" & vbCrLf _

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
            'Console.WriteLine(GetTimeStamp() & "  queryString: " & queryString)
            Dim dataReader As OleDbDataReader '= command.ExecuteReader()

            done = False
            'Do
            Try
                If connection.State = ConnectionState.Closed Then connection.Open()
                dataReader = command.ExecuteReader()
                fieldcount = n
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
                      & Erg & " \par\pard "
                    html = html & vbCrLf _
                      & "              <tr>" _
                      & "<td align=""center"">" & Pos & " </td>" _
                      & "<td align=""left"">" & dataReader(1).ToString & "<span style=""font-size:" & CInt(0.2 * FontSize * FontSizeFactor) & "pt"">&nbsp;(" & dataReader(0) & ")</span></td>" _
                      & "<td>&nbsp;</td>" _
                      & "<td align=""center"">" & dataReader(3).ToString & " </td>" _
                      & "<td align=""center"">" & dataReader(4).ToString & " </td>" _
                      & "<td align=""center"">" & dataReader(5).ToString & " </td>" _
                      & "<td align=""center"">" & dataReader(6).ToString & " </td>" _
                      & " </tr>"
                    'If (fieldcount > 4) And (n = Int(fieldcount / 2 + 0.5)) Then
                    If (n = Spaltentrenner1) Or (n = Spaltentrenner2) Then
                        html = html & vbCrLf _
                              & "            </table>" & vbCrLf _
                              & "          </td>" & vbCrLf _
                              & "          <td>&nbsp;</td>" & vbCrLf _
                              & "          <td valign=""top"">" & vbCrLf _
                              & "            <table>"
                    End If
                Loop
                dataReader.Close()
                connection.Close()
                tmrRangliste.Interval = 5000
                done = True
            Catch ex As Exception
                tmrRangliste.Interval = tmrRangliste.Interval * 10
                Console.WriteLine(GetTimeStamp() & " queryString: " & queryString)
                Console.WriteLine(GetTimeStamp() & " Tick failed: ", ex.Message)

                'If MsgBox(ex.Message, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then done = True
            End Try
            'Loop Until done
            'Console.WriteLine("xxxxxx")
            Console.ReadLine()
        End Using
        If rtfRangliste.Rtf <> rtf Then rtfRangliste.Rtf = rtf
        html = html & vbCrLf _
          & "            </table>" & vbCrLf _
          & "          </td>" & vbCrLf _
          & "        </tr>" & vbCrLf _
          & "      </table>" & vbCrLf _
          & "    </font>" & vbCrLf _
          & "  </body>" & vbCrLf _
          & "</html>"
        tmrRangliste.Enabled = True
        'Debug.Print(html)
        My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(My.Settings.lastFile) & "\rangliste.html", html, False)
    End Sub


    Private Sub frmTop10_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub


    Private Sub frmTop10_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        'rtfRangliste.Height = Me.Height - 55
        Me.Width = 454
    End Sub

    Private Sub frmTop10_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmTop10_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles Me.ChangeUICues

    End Sub
End Class