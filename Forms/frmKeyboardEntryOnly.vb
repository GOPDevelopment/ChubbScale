Public Class frmKeyboardEntryOnly
    Public Property KeyboardEntry As String
    Public Event EntrySelected()

    Private Sub frmKeyboard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TopMost = True

        txtProductCode.Text = ""
        btnCancel.Enabled = True


    End Sub

    Private Sub keyboardcontrol1_UserKeyPressed(ByVal sender As Object, ByVal e As KeyboardClassLibrary.KeyboardEventArgs) Handles keyboardcontrol1.UserKeyPressed
        txtProductCode.Focus()
        SendKeys.Send(e.KeyboardKeyPressed)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtProductCode.Text = ""
        KeyboardEntry = ""
        Me.Close()
    End Sub
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        'KeyboardEntry = CheckString(txtProductCode.Text)
        KeyboardEntry = txtProductCode.Text
        Me.Close()
    End Sub


End Class