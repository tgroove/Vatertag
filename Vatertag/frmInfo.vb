Public Class frmInfo
    Dim letzteTlnrNr As Integer = 0
    Public Sub SetInfoText(txt As String, Optional update As Boolean = False)
        Dim a() As String = Split(txt)
        Dim n1, n2 As Integer
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
        If txt.LastIndexOf(" ") > 0 Then n1 = Val(txt.Substring(txt.LastIndexOf(" ")))
        If rtbInfo.Text.LastIndexOf(" ") > 0 Then n2 = val(rtbInfo.Text.Substring(rtbInfo.Text.LastIndexOf(" ")))
        Debug.Print(n1 & ", " & n2)
        If (rtbInfo.Rtf <> rtf) Then
            If (n1 = n2) _
              Or Trim(rtbInfo.Text).EndsWith(".") Then
                rtbInfo2.Rtf = ""
            Else
                rtbInfo2.Rtf = rtbInfo.Rtf.Replace("\fs50", "\fs30")
            End If
            rtbInfo.Rtf = rtf
        End If
    End Sub

End Class