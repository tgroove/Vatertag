Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.OleDb


Module Vatertag
    Dim cs As String
    Dim MaxTlnrNr As Integer = 0

    Public Structure strucCounts
        Public Teilnehmer As Integer
        Public Scheiben As Integer
    End Structure

    Public Structure strucTeilnehmer
        Public Nr As Integer
        Public Name As String
        Public Scheiben As Integer
        Public Platzierung As Integer
        Public Aenderung As Date
        Public Scheibe1 As Integer
        Public Scheibe2 As Integer
        Public Scheibe3 As Integer
        Public Scheibe4 As Integer
    End Structure

    Public ScheibenPreis As Single
    Public Grundpreis As Single
    Public Veranstaltungsname As String
    Public mode As String

    Public Property connectionString As String
        Get
            connectionString = cs
        End Get
        Set(value As String)
            cs = value
        End Set
    End Property



    Public Sub PopulateList()
        Dim Teilnehmer() As String
        Dim n As Integer
        Dim done As Boolean = False
        Dim maxTlnrNr As Integer = 0
        Dim queryString As String =
            "SELECT * from Kunden;"
        ReDim Teilnehmer(1000)

        If (connectionString = "") Then Exit Sub


        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)
            'Console.WriteLine(GetTimeStamp() & " queryString: " & queryString)
            Dim dataReader As OleDbDataReader '= command.ExecuteReader()
            done = False
            Do
                Try
                    If connection.State = ConnectionState.Closed Then connection.Open()
                    dataReader = command.ExecuteReader()

                    Do While dataReader.Read()
                        Teilnehmer(n) = dataReader(0).ToString & "   " & dataReader(1).ToString
                        n = n + 1
                        '   Console.WriteLine(
                        '   vbTab & "{0}" & vbTab & "{1}" & vbTab & "{2}",
                        'dataReader(0), dataReader(1), dataReader(2))
                        If Val(dataReader(0).ToString) > maxTlnrNr Then maxTlnrNr = CInt(Val(dataReader(0).ToString))
                    Loop
                    SetMaxNr(maxTlnrNr)
                    'Debug.Print("Max TlnNr=" & maxTlnrNr)
                    dataReader.Close()
                    ReDim Preserve Teilnehmer(n - 1)
                    If n > 0 Then frmSuche.PopList(Teilnehmer)
                    done = True
                Catch ex As Exception
                    Console.WriteLine(GetTimeStamp() & " PopulateList failed: " & ex.Message)
                    If MsgBox(ex.Message, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then done = True
                End Try
            Loop Until done
            Console.ReadLine()

        End Using

    End Sub


    Public Function GetTeilnehmerData(Nr As Integer) As strucTeilnehmer
        Dim data As strucTeilnehmer
        Dim NoResults As Boolean = True
        Dim queryString As String =
            "SELECT * from Kunden WHERE ID=" & Nr & ";"
        Dim done As Boolean = False

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)
            Console.WriteLine(GetTimeStamp() & " queryString: " & queryString)
            Dim dataReader As OleDbDataReader '= command.ExecuteReader()

            Do
                Try
                    If connection.State = ConnectionState.Closed Then connection.Open()
                    dataReader = command.ExecuteReader()

                    Do While dataReader.Read()
                        'Teilnehmer(n) = dataReader(0).ToString & "   " & dataReader(1).ToString
                        'n = n + 1
                        'Console.WriteLine(
                        'vbTab & "{0}" & vbTab & "{1}" & vbTab & "{2}",
                        'dataReader(0), dataReader(1), dataReader(2))
                        data.Nr = CInt(Val(dataReader(0)))
                        data.Name = dataReader(1).ToString
                        data.Scheiben = CInt(Val(dataReader(2)))
                        data.Platzierung = CInt(Val(dataReader(3)))
                        data.Aenderung = CDate(dataReader(4))
                        data.Scheibe1 = CInt(Val(dataReader(5)))
                        data.Scheibe2 = CInt(Val(dataReader(6)))
                        data.Scheibe3 = CInt(Val(dataReader(7)))
                        data.Scheibe4 = CInt(Val(dataReader(8)))
                        GetTeilnehmerData = data
                        NoResults = False
                    Loop
                    dataReader.Close()
                    done = True
                    If NoResults Then
                        data.Nr = 0
                        Console.WriteLine("GetTeilnehmerData failed. No Results found for Nr " & Nr)
                    Else
                        Console.WriteLine(GetTimeStamp() & " GetTeilnehmerData: " _
                            & data.Nr & ", " _
                            & data.Name & ", " _
                            & "Scheiben: " & data.Scheiben & ", " _
                            & "Platzierung: " & data.Platzierung & ", " _
                            & "Änderung: " & data.Aenderung & ", " _
                            & "Ergebnisse: " & data.Scheibe1 & ", " _
                            & data.Scheibe2 & ", " _
                            & data.Scheibe3 & ", " _
                            & data.Scheibe4)
                    End If
                Catch ex As Exception
                    Console.WriteLine(GetTimeStamp() & " GetTeilnehmerData failed: " & ex.Message)
                    If MsgBox("Der Datensatz konnte nicht gelesen werden." & vbCrLf & ex.Message, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then done = True
                End Try
            Loop Until done
            Console.ReadLine()

        End Using

    End Function


    Public Function CalculateBetragByScheiben(ScheibenAlt As Integer, ScheibenNeu As Integer) As Single
        CalculateBetragByScheiben = CSng(IIf(ScheibenAlt = 0, Grundpreis, 0)) + ScheibenNeu * ScheibenPreis
    End Function

    Public Function CalculateScheibenByBetrag(ScheibenAlt As Integer, BetragNeu As Integer) As Single
        CalculateScheibenByBetrag = (BetragNeu - CSng(IIf(ScheibenAlt = 0, Grundpreis, 0))) / ScheibenPreis
    End Function

    Public Sub UpdatePosition(ID As Integer, Platzierung As Integer)
        Dim queryString As String
        Dim RecordsAffected As Integer
        Dim done As Boolean = False
        queryString = "UPDATE Kunden " _
                & " SET Platzierung=" & Platzierung _
                & " WHERE ID=" & ID & " ;"

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
                    Console.WriteLine(GetTimeStamp() & " UpdatePosition failed: " & ex.Message)
                    If MsgBox(ex.Message, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then done = True
                End Try
            Loop Until done
            Console.ReadLine()
        End Using

        If RecordsAffected <> 1 Then
            Console.Write("UpdatePosition failed. RecordsAffected = " & RecordsAffected)
            MsgBox("Datensatz konnte nicht aktualisiert werden", MsgBoxStyle.Critical)
        End If

    End Sub

    Public Function GetCounts() As strucCounts
        Dim AnzahlScheiben As Integer = 0
        Dim AnzahlTeilnehmer As Integer = 0
        Dim c As strucCounts
        Dim queryString As String =
            "SELECT Scheiben FROM Kunden WHERE Scheiben>0"
        Dim done As Boolean = False

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)
            Console.WriteLine(GetTimeStamp() & " queryString: " & queryString)
            Dim dataReader As OleDbDataReader '= command.ExecuteReader()

            done = False
            Do
                Try
                    If connection.State = ConnectionState.Closed Then connection.Open()
                    dataReader = command.ExecuteReader()

                    Do While dataReader.Read()
                        AnzahlScheiben = AnzahlScheiben + CInt(Val(dataReader(0).ToString))
                        AnzahlTeilnehmer = AnzahlTeilnehmer + 1
                    Loop
                    dataReader.Close()
                    done = True
                Catch ex As Exception
                    Console.Write("GetCounts failed: " & ex.Message)
                    If MsgBox(ex.Message, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then done = True
                End Try
            Loop Until done
        End Using
        Console.WriteLine(GetTimeStamp() _
                          & " Teilnehmer gesamt: " & AnzahlTeilnehmer & ", " _
                          & "Scheiben gesamt: " & AnzahlScheiben)
        c.Scheiben = AnzahlScheiben
        c.Teilnehmer = AnzahlTeilnehmer
        GetCounts = c
    End Function

    Public Sub SetMaxNr(Nr As Integer)
        MaxTlnrNr = Nr
    End Sub

    Public Function GetMaxNr() As Integer
        GetMaxNr = MaxTlnrNr
    End Function

    Public Function Width2(Number As String) As String
        If Number.Length < 2 Then Number = "  " & Number
        Width2 = Number
    End Function

    Public Sub GetSettingsFromDB()
        Dim queryString As String =
            "SELECT * from Einstellungen WHERE ID=1;"
        Dim done As Boolean = False

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)
            Console.WriteLine(GetTimeStamp() & " queryString: " & queryString)
            Dim dataReader As OleDbDataReader '= command.ExecuteReader()

            done = False
            Do
                Try
                    If connection.State = ConnectionState.Closed Then connection.Open()
                    dataReader = command.ExecuteReader()

                    Do While dataReader.Read()
                        'Teilnehmer(n) = dataReader(0).ToString & "   " & dataReader(1).ToString
                        'n = n + 1
                        '   Console.WriteLine(
                        '   vbTab & "{0}" & vbTab & "{1}" & vbTab & "{2}",
                        'dataReader(0), dataReader(1), dataReader(2))
                        Veranstaltungsname = dataReader(1).ToString
                        ScheibenPreis = Single.Parse(dataReader(2).ToString)
                        Grundpreis = Single.Parse(dataReader(3).ToString)
                    Loop
                    dataReader.Close()
                    done = True
                    Console.WriteLine(GetTimeStamp() _
                            & " GetSettingsFromDB: " _
                            & " Veranstaltungsname: " & Veranstaltungsname & ", " _
                            & " Scheibenpreis: " & ScheibenPreis & ", " _
                            & " Grundpreis: " & Grundpreis)

                Catch ex As Exception
                    Console.WriteLine(GetTimeStamp() & " GetSettingsFromDB failed: " & ex.Message)
                    If MsgBox("Der Einstellungs-Datensatz konnte nicht gelesen werden." & vbCrLf & ex.Message, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then done = True
                End Try
            Loop Until done
            Console.ReadLine()

        End Using


    End Sub

    Public Sub StoreSettingsInDB()
        Dim queryString As String
        Dim RecordsAffected As Integer
        Dim done As Boolean = False
        queryString = "UPDATE Einstellungen " _
                & " SET Veranstaltungsname='" & Veranstaltungsname & "' , " _
                & "  Scheibenpreis=" & ScheibenPreis.ToString.Replace(",", ".") & " , " _
                & "  Grundpreis=" & Grundpreis.ToString.Replace(",", ".") & " ;"

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)
            Console.WriteLine(GetTimeStamp() & " queryString: " & queryString)
            done = False
            Dim dataReader As OleDbDataReader '= command.ExecuteReader()
            Do
                Try
                    If connection.State = ConnectionState.Closed Then connection.Open()
                    dataReader = command.ExecuteReader()

                    RecordsAffected = dataReader.RecordsAffected
                    dataReader.Close()
                    done = True
                Catch ex As Exception
                    Console.WriteLine(GetTimeStamp() & " StoreSettingsDB failed: " & ex.Message)
                    If MsgBox(ex.Message, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then done = True
                End Try
            Loop Until done

            Console.ReadLine()
        End Using

        If RecordsAffected <> 1 Then
            Console.WriteLine(GetTimeStamp() & " StoreSettingsInDB failed. RecordsAffected = " & RecordsAffected)
            MsgBox("Einstellungs-Datensatz konnte nicht aktualisiert werden")
        End If

    End Sub


    Public Function GetTimeStamp() As String
        GetTimeStamp = Now.TimeOfDay.ToString
    End Function


    'Public Function ExtractResourceToDisk(ByVal ResourceName As String, ByVal FileToExtractTo As String) As Boolean

    '    Dim s As System.IO.Stream = System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(ResourceName)
    '    'Dim Exeassembly As System.Reflection.Assembly = Assembly.GetExecutingAssembly
    '    'Dim ResourceFile As New System.IO.FileStream(FileToExtractTo, IO.FileMode.Create)

    '    'Stream Res = assembly.GetManifestResourceStream(scope, resname);
    '    's = Exeassembly.GetManifestResourceStream(Mynamespace + "." + ResourceName)
    '    's = (System.Reflection.Assembly.GetExecutingAssemblyGetManifestResourceStream("count_down.Big Brovaz - Nu Flow.mp3"))
    '    Dim file As System.IO.FileStream = New System.IO.FileStream(FileToExtractTo, IO.FileMode.Create)
    '    Using (file)
    '        Dim buf(4096) As Byte
    '        Dim bytesRead As Integer = 0
    '        bytesRead = s.Read(buf, 0, buf.Length())
    '        While (bytesRead > 0)
    '            file.Write(buf, 0, bytesRead)
    '            bytesRead = s.Read(buf, 0, buf.Length())
    '        End While
    '    End Using

    '    file = Nothing
    '    ExtractResourceToDisk = True
    'End Function
End Module
