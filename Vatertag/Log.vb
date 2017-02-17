Module Log
    Private LogText As String
    Private LogLine() As String = {"\line", "\line", "\line", "\line", "\line"}

    Public Sub AddLog(LogEntry As String, Optional red As Boolean = False)
        If LogEntry = "" Then Exit Sub
        Dim n As Integer
        For n = 0 To 3
            LogLine(n) = LogLine(n + 1)
        Next
        LogEntry = LogEntry.Replace("\", "\\")
        LogLine(4) = IIf(red, "\cf2", "\cf1") & vbCrLf & LogEntry & "\line"
        LogText = "{\rtf1 Guten Tag! \line {\i Dies} ist \b{\i ein \i0 formatierter \b0Text}. \par \i0 Das \b0Ende. }"

        LogText = "{\rtf1\ansi\deff0 " _
            & "{\colortbl;\red0\green0\blue255;\red255\green0\blue0;}" _
            & LogLine(0) _
            & LogLine(1) _
            & LogLine(2) _
            & LogLine(3) _
            & LogLine(4) _
            & " }"
        frmSuche.UpdateRTB(LogText)
    End Sub
End Module
