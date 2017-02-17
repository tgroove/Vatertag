Public Class frmInfo
    Public Sub SetInfoText(txt As String)
        Dim a() As String = Split(txt)
        Dim rtf As String = "{\rtf1 \fs50 {\colortbl;\red110\green90\blue110;\red0\green0\blue0;} \b0\cf1"
        Dim i As Integer
        If Val(a(0)) > 0 Then
            a(0) = "{\b\cf2 " & a(0) & "}\b0\cf1 "
        End If
        a(UBound(a)) = "{\b\cf2 " & a(UBound(a)) & "}\b0\cf1"
        For i = 0 To UBound(a)
            rtf = rtf & a(i) & " "
        Next

        rtbInfo.Rtf = rtf
    End Sub

End Class