Public Class frmEditWeight

    Public Property EnteredWeight As Single

    Private Sub frmGetManualWeight_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.TopMost = True
        Me.CenterToParent()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        EnteredWeight = -1
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        ' See if a numeric value was entered.
        If IsNumeric(txtWeight.Text) Then
            If Single.TryParse(txtWeight.Text, EnteredWeight) Then
                Me.Close()
            Else
                MsgBox("Invalid numeric value entered.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Manual Weight")
            End If
        Else
            MsgBox("Invalid numeric value entered.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Manual Weight")
        End If
    End Sub

    Private Sub btnGrade0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrade0.Click
        txtWeight.Focus()
        SendKeys.Send("0")
    End Sub
    Private Sub btnGrade1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrade1.Click
        txtWeight.Focus()
        SendKeys.Send("1")
    End Sub
    Private Sub btnGrade2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrade2.Click
        txtWeight.Focus()
        SendKeys.Send("2")
    End Sub
    Private Sub btnGrade3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrade3.Click
        txtWeight.Focus()
        SendKeys.Send("3")
    End Sub
    Private Sub btnGrade4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrade4.Click
        txtWeight.Focus()
        SendKeys.Send("4")
    End Sub
    Private Sub btnGrade5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrade5.Click
        txtWeight.Focus()
        SendKeys.Send("5")
    End Sub
    Private Sub btnGrade6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrade6.Click
        txtWeight.Focus()
        SendKeys.Send("6")
    End Sub
    Private Sub btnGrade7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrade7.Click
        txtWeight.Focus()
        SendKeys.Send("7")
    End Sub
    Private Sub btnGrade8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrade8.Click
        txtWeight.Focus()
        SendKeys.Send("8")
    End Sub
    Private Sub btnGrade9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrade9.Click
        txtWeight.Focus()
        SendKeys.Send("9")
    End Sub
    Private Sub btnPeriod_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPeriod.Click
        txtWeight.Focus()
        SendKeys.Send(".")
    End Sub
End Class