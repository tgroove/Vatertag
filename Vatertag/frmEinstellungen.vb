Public Class frmEinstellungen
    Private Sub frmEinstellungen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtGrundPreis.Text = Format(Grundpreis, "0.00")
        txtScheibenPreis.Text = Format(ScheibenPreis, "0.00")
        If mode = "Verkauf" Then
            rdoVerkauf.Checked = True
        Else
            rdoAuswertung.Checked = True
        End If
        btnOk.Enabled = False
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Grundpreis = txtGrundPreis.Text
        My.Settings.GrundPreis = Grundpreis
        ScheibenPreis = txtScheibenPreis.Text
        My.Settings.ScheibenPreis = ScheibenPreis
        If rdoVerkauf.Checked Then
            mode = "Verkauf"
            My.Settings.Mode = mode
            frmInfo.Show()
        Else
            mode = "Auswertung"
            My.Settings.Mode = mode
            frmInfo.Hide()

        End If
        My.Settings.Save()
        Me.Close()

    End Sub



    Private Sub txtGrundPreis_LostFocus(sender As Object, e As EventArgs) Handles txtGrundPreis.LostFocus
        txtGrundPreis.Text = Format(Val(txtGrundPreis.Text.Replace(",", ".")), "0.00")
    End Sub



    Private Sub txtScheibenPreis_LostFocus(sender As Object, e As EventArgs) Handles txtScheibenPreis.LostFocus
        txtScheibenPreis.Text = Format(Val(txtScheibenPreis.Text.Replace(",", ".")), "0.00")
    End Sub

    Private Sub txtScheibenPreis_KeyDown(sender As Object, e As KeyEventArgs) Handles txtScheibenPreis.KeyDown
        Select Case e.KeyData
            Case Keys.D0 To Keys.D9
            Case Keys.NumPad0 To Keys.NumPad9
            Case Keys.Decimal, Keys.OemPeriod
            Case Keys.Delete, Keys.Back
            Case Keys.Separator
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtGrundPreis_TextChanged(sender As Object, e As EventArgs) Handles txtGrundPreis.TextChanged

    End Sub

    Private Sub frmEinstellungen_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.L Then
            If Control.ModifierKeys = Keys.Shift + Keys.Control Then
                Me.btnOk.Enabled = Not (Me.btnOk.Enabled)
            End If
        End If
    End Sub


End Class