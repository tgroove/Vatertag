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
        Dim border As Integer = 3
        Dim Padding As Integer = 5
        Dim MaxAnzZeilen As Integer
        Dim FontSizeFactor As Single
        Dim done As Boolean = False
        Dim rtf As String = "{\rtf1\ansi\deff0 {\fonttbl {\f0 Arial;}}"

        Select Case n
            Case > 2 * 19
                '3 Spalten
                MaxAnzZeilen = 22
                Spaltentrenner1 = n / 3 + 0.4
                Spaltentrenner2 = (n - Spaltentrenner1) / 2 + 0.4 + Spaltentrenner1
                border = 2
                Padding = 5
                FontSizeFactor = 0.7
                If Spaltentrenner1 > MaxAnzZeilen Then
                    Spaltentrenner1 = MaxAnzZeilen
                    Spaltentrenner2 = MaxAnzZeilen * 2
                End If
            Case > 16
                '2 Spalten
                MaxAnzZeilen = 19
                Spaltentrenner1 = n / 2 + 0.1
                Spaltentrenner2 = 1000
                border = 3
                Padding = 4
                FontSizeFactor = 0.9
            Case Else
                '1 Spalte
                Spaltentrenner1 = 1000
                Spaltentrenner2 = 1000
                border = 3
                Padding = 5
                FontSizeFactor = 1
        End Select

        Dim ZeilenProSpalte = 15
        FontSizeFactor = 1.1
        border = 3
        Padding = 8

        Dim html As String
        Dim html_page1 As String = ""
        Dim html_page2 As String = ""
        Dim html_page(10) As String
        Dim page As Integer = 0
        Static p As Integer = 0
        Dim html_vor As String = "<!DOCTYPE html>" & vbCrLf _
          & "<html lang=""de"">" & vbCrLf _
          & "  <head>" & vbCrLf _
          & "    <meta charset=""utf-8"" /> " & vbCrLf _
          & "    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />" & vbCrLf _
          & "    <meta http-equiv=""refresh"" content=""5; URL=rl.htm"">" & vbCrLf _
          & "    <title>Aktuelle Rangliste</title>" & vbCrLf _
          & "    <style>" & vbCrLf _
          & "      table {" & vbCrLf _
          & "        margin:          0px auto;" & vbCrLf _
          & "        font-family:     'Liberation Sans', Arial, Helvetica, sans-serif;" & vbCrLf _
          & "        font-size:       " & CInt(0.7 * FontSize) & "pt;" & vbCrLf _
          & "        border-collapse: collapse;" & vbCrLf _
          & "      }" & vbCrLf _
          & "      th, td {" & vbCrLf _
          & "        Padding-Top:    " & Padding & "px;" & vbCrLf _
          & "        Padding-Bottom: " & Padding & "px;" & vbCrLf _
          & "        Padding-Left:   9px;" & vbCrLf _
          & "        Padding-Right:  9px;" & vbCrLf _
          & "        border-spacing: 0px; " & vbCrLf _
          & "        Font-family:    'Liberation Sans', Arial, Helvetica, sans-serif;" & vbCrLf _
          & "        font-size:      " & CInt(0.25 * FontSize * FontSizeFactor) & "pt;" & vbCrLf _
          & "        xText-align:    center;" & vbCrLf _
          & "      }" & vbCrLf _
          & "      td {" & vbCrLf _
          & "        border-top:     " & border & "px solid #000;" & vbCrLf _
          & "        border-bottom:  " & border & "px solid #000;" & vbCrLf _
          & "      }" & vbCrLf _
          & "    </style>" & vbCrLf _
          & "  </head>" & vbCrLf _
          & "  <body>" & vbCrLf _
          & "    <font face=""Helvetica"">" & vbCrLf _
          & "      <p><strong><div style=""font-size:" & CInt(0.6 * FontSize) & "pt;text-align:center"">Aktuelle Rangliste</div></strong></p>" & vbCrLf _
          & "      <table  border=""5"" bordercolor=WHITE>" & vbCrLf _
          & "        <tr>" & vbCrLf _
          & "          <td valign=""top"">" & vbCrLf _
          & "            <table>" & vbCrLf _
          & "              <col width=""90"">" & vbCrLf _
          & "              <col width=""600"">" & vbCrLf _
          & "              <col width=""60"">" & vbCrLf _
          & "              <col width=""60"">" & vbCrLf _
          & "              <col width=""60"">" & vbCrLf _
          & "              <col width=""60"">" & vbCrLf _
          & "              <col width=""60"">" & vbCrLf _

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
                    'If n <= 2 * ZeilenProSpalte Then
                    If (n Mod (2 * ZeilenProSpalte)) = 1 Then page = page + 1
                    html_page(page) = html_page(page) & vbCrLf _
                          & "              <tr>" _
                          & "<td align=""center"">" & Pos & " </td>" _
                          & "<td align=""left"">" & dataReader(1).ToString & "<span style=""font-size:" & CInt(0.2 * FontSize * FontSizeFactor) & "pt"">&nbsp;(" & dataReader(0) & ")</span></td>" _
                          & "<td align=""center"">" & dataReader(3).ToString & " </td>" _
                          & "<td align=""center"">" & dataReader(4).ToString & " </td>" _
                          & "<td align=""center"">" & dataReader(5).ToString & " </td>" _
                          & "<td align=""center"">" & dataReader(6).ToString & " </td>" _
                          & " </tr>"
                    'If (fieldcount > 4) And (n = Int(fieldcount / 2 + 0.5)) Then
                    'If (n = Spaltentrenner1) Or (n = Spaltentrenner2) Then
                    If (n Mod (2 * ZeilenProSpalte)) = ZeilenProSpalte Then
                        html_page(page) = html_page(page) & vbCrLf _
                              & "            </table>" & vbCrLf _
                              & "          </td>" & vbCrLf _
                              & "          <td>&nbsp;&nbsp;&nbsp;</td>" & vbCrLf _
                              & "          <td valign=""top"">" & vbCrLf _
                              & "            <table>" & vbCrLf _
                              & "              <col width=""90"">" & vbCrLf _
                              & "              <col width=""600"">" & vbCrLf _
                              & "              <col width=""60"">" & vbCrLf _
                              & "              <col width=""60"">" & vbCrLf _
                              & "              <col width=""60"">" & vbCrLf _
                              & "              <col width=""60"">" & vbCrLf _
                              & "              <col width=""60"">" & vbCrLf

                    End If
                    'Else
                    'html_page2 = html_page2 & vbCrLf _
                    '      & "              <tr>" _
                    '      & "<td align=""center"">" & Pos & " </td>" _
                    '      & "<td align=""left"">" & dataReader(1).ToString & "<span style=""font-size:" & CInt(0.2 * FontSize * FontSizeFactor) & "pt"">&nbsp;(" & dataReader(0) & ")</span></td>" _
                    '      & "<td align=""center"">" & dataReader(3).ToString & " </td>" _
                    '      & "<td align=""center"">" & dataReader(4).ToString & " </td>" _
                    '      & "<td align=""center"">" & dataReader(5).ToString & " </td>" _
                    '      & "<td align=""center"">" & dataReader(6).ToString & " </td>" _
                    '      & " </tr>"
                    '    'If (fieldcount > 4) And (n = Int(fieldcount / 2 + 0.5)) Then
                    '    'If (n = Spaltentrenner1 + 3 * Spaltentrenner1) Or (n = Spaltentrenner2 + 3 * Spaltentrenner1) Then
                    '    If (n Mod ZeilenProSpalte) = 0 Then
                    '        html_page2 = html_page2 & vbCrLf _
                    '          & "            </table>" & vbCrLf _
                    '          & "          </td>" & vbCrLf _
                    '          & "          <td>&nbsp;</td>" & vbCrLf _
                    '          & "          <td valign=""top"">" & vbCrLf _
                    '          & "            <table>"
                    '    End If

                    'End If
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
        Dim html_nach As String = vbCrLf _
          & "            </table>" & vbCrLf _
          & "          </td>" & vbCrLf _
          & "        </tr>" & vbCrLf _
          & "      </table>" & vbCrLf _
          & "    </font>" & vbCrLf _
          & "  </body>" & vbCrLf _
          & "</html>"
        tmrRangliste.Enabled = True
        'Debug.Print(html)

        'If page > 1 Then
        '    page = page + 1
        '    If page = 10000 Then page = 1
        '    If (page Mod 10) < 7 Then
        '        html = html_vor & html_page1 & html_nach
        '    Else
        '        html = html_vor & html_page2 & html_nach
        '    End If
        'Else
        '    html = html_vor & html_page1 & html_nach
        'End If
        p = p + 1
        If p > 10000 Then p = 0
        html = html_vor & html_page(((p \ 4) Mod (page)) + 1) & html_nach
        If mode = "Auswertung" Then
            My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(My.Settings.lastFile) & "\rl.htm", html, False)
        Else
            My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(My.Settings.lastFile) & "\rl_vk.htm", html, False)
        End If
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