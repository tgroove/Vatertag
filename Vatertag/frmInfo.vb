Public Class frmInfo
    Public Sub SetInfoText(txt As String)
        Dim a() As String = Split(txt)
        Dim rtf As String = "{\rtf1 \fs50 {\colortbl;\red110\green90\blue110;\red0\green0\blue0;} \b0\cf1"
        Dim i As Integer
        If Val(a(0)) > 0 Then
            a(0) = "{\b\cf2 " & a(0) & "}\b0\cf1 "
        End If
        If Val(a(UBound(a))) > 0 Then
            a(UBound(a)) = "{\b\cf2 " & a(UBound(a)) & "}\b0\cf1"
        End If
        For i = 0 To UBound(a)
            rtf = rtf & a(i) & " "
        Next
        If rtbInfo.Rtf <> rtf Then
            rtbInfo2.Rtf = rtbInfo.Rtf.Replace("\fs50", "\fs30")
            rtbInfo.Rtf = rtf
        End If
    End Sub

End Class