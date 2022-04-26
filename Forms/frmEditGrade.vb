Public Class frmEditGrade
    Public CurrentGrade As Integer

    Private Sub btnGrade1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade1.Click
        SetCurrentGrade(1, True)
        CurrentGrade = 1
    End Sub
    Private Sub btnGrade2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade2.Click
        SetCurrentGrade(2, True)
        CurrentGrade = 2
    End Sub
    Private Sub btnGrade3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade3.Click
        SetCurrentGrade(3, True)
        CurrentGrade = 3
    End Sub
    Private Sub btnGrade4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade4.Click
        SetCurrentGrade(4, True)
        CurrentGrade = 4
    End Sub
    Private Sub btnGrade5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade5.Click
        SetCurrentGrade(5, True)
        CurrentGrade = 5
    End Sub
    Private Sub btnGrade6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade6.Click
        SetCurrentGrade(6, True)
        CurrentGrade = 6
    End Sub
    Private Sub btnGrade7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade7.Click
        SetCurrentGrade(7, True)
        CurrentGrade = 7
    End Sub
    Private Sub btnGrade8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade8.Click
        SetCurrentGrade(8, True)
        CurrentGrade = 8
    End Sub

    Public Sub SetCurrentGrade(ByVal iGrade As Integer, Optional ByVal WasManuallySelected As Boolean = False)
        CurrentGrade = iGrade
        Me.Close()
    End Sub

    Private Sub frmEditGrade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()

    End Sub
End Class