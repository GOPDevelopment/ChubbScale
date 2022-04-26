Public Class frmEditTareWithPresets

    Public CurrentTare As String = ""
    Private ProductCode As String = ""
    Private currentField As String = ""

    Private Sub frmEditTare_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        StartEditor()
    End Sub

    Public Sub StartEditor()
        lblProduct.Text = "Select Product"

        ' Get product code
        Dim frmKeyboard As New frmKeyboard
        'frmProd.SetMode("TARE")
        frmKeyboard.ShowDialog()
        If frmKeyboard.ChosenProductCode = "" Then
            frmKeyboard.Close()
            frmKeyboard.Dispose()
            Me.Close()
        End If

        'lblProduct.Text = frmProd.ChosenProductCode & "/" & frmProd.ChosenProductDescription
        'ProductCode = frmProd.ChosenProductCode

        'txtBoxTare.Text = frmProd.ChosenTare
        'txtItemCount.Text = frmProd.ChosenItemCountPerBox
        'txtItemTare.Text = frmProd.ChosenItemTareEach

        frmKeyboard.Close()
        frmKeyboard.Dispose()

        currentField = "BoxTare"
        txtBoxTare.SelectAll()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtBoxTare_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBoxTare.GotFocus
        currentField = "BoxTare"
    End Sub

    Private Sub txtItemCount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemCount.GotFocus
        currentField = "ItemCount"
    End Sub

    Private Sub txtItemTare_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemTare.GotFocus
        currentField = "ItemTare"
    End Sub

    Private Sub txtBoxTare_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBoxTare.MouseClick
        txtBoxTare.SelectAll()
        currentField = "BoxTare"
    End Sub

    Private Sub txtItemCount_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtItemCount.MouseClick
        txtItemCount.SelectAll()
        currentField = "ItemCount"
    End Sub

    Private Sub txtItemTare_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtItemTare.MouseClick
        txtItemTare.SelectAll()
        currentField = "ItemTare"
    End Sub

    Sub SendCharacter(ByVal szChar As String)
        Select Case currentField
            Case "BoxTare"
                txtBoxTare.Focus()
                SendKeys.Send(szChar)
            Case "ItemTare"
                txtItemTare.Focus()
                SendKeys.Send(szChar)
            Case "ItemCount"
                txtItemCount.Focus()
                SendKeys.Send(szChar)
        End Select

    End Sub


    Private Sub btnGrade0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade0.Click
        SendCharacter("0")
    End Sub
    Private Sub btnGrade1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade1.Click
        SendCharacter("1")
    End Sub
    Private Sub btnGrade2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade2.Click
        SendCharacter("2")
    End Sub
    Private Sub btnGrade3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade3.Click
        SendCharacter("3")
    End Sub
    Private Sub btnGrade4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade4.Click
        SendCharacter("4")
    End Sub
    Private Sub btnGrade5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade5.Click
        SendCharacter("5")
    End Sub
    Private Sub btnGrade6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade6.Click
        SendCharacter("6")
    End Sub
    Private Sub btnGrade7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade7.Click
        SendCharacter("7")
    End Sub
    Private Sub btnGrade8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade8.Click
        SendCharacter("8")
    End Sub
    Private Sub btnGrade9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrade9.Click
        SendCharacter("9")
    End Sub
    Private Sub btnGradePeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGradePeriod.Click
        SendCharacter(".")
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If Not IsNumeric(txtBoxTare.Text) Then
            MsgBox("Box Tare must be numeric")
            Exit Sub
        End If
        If Not IsNumeric(txtItemCount.Text) Then
            MsgBox("Item Count must be numeric")
            Exit Sub
        End If
        If Not IsNumeric(txtItemTare.Text) Then
            MsgBox("Item Tare must be numeric")
            Exit Sub
        End If

        CurrentTare = txtBoxTare.Text

        'Try
        '    cmd.CommandText = "UPDATE tblProduct SET Tare=" & txtBoxTare.Text & ", ItemCountPerBox=" & txtItemCount.Text & ", ItemTareEach=" & txtItemTare.Text & " WHERE ProductCode=" & CheckString(ProductCode)
        '    cmd.ExecuteNonQuery()

        '    MsgBox("Tare data updated.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Update Successful")
        '    Me.Close()

        'Catch ex As Exception
        '    MsgBox("Unable to update." & vbCrLf & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Database Error")
        'End Try

    End Sub
End Class