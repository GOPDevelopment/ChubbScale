Public Class frmKeyboard
    Public Event ProductSelected()
    Public Property SpecificProductList As List(Of ProductInfo)
    Public Property ChosenProductCode As String


    Private Sub frmKeyboard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.TopMost = True

        txtProductCode.Text = ""

        Me.Text = "Change Product"
        btnCancel.Enabled = True
        lblInput.Text = "Product Code:"

    End Sub

    Public Sub SetProductList(ByVal ProdList As List(Of ProductInfo))
        SpecificProductList = ProdList
    End Sub

    Private Sub keyboardcontrol1_UserKeyPressed(ByVal sender As Object, ByVal e As KeyboardClassLibrary.KeyboardEventArgs) Handles keyboardcontrol1.UserKeyPressed
        txtProductCode.Focus()
        SendKeys.Send(e.KeyboardKeyPressed)
    End Sub

    Private Sub txtProductCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProductCode.TextChanged
        LoadProductList(txtProductCode.Text)
    End Sub

    Public Sub LoadProductList(ByVal sValue As String)

        lstProducts.Items.Clear()
        If sValue.Trim <> String.Empty Then
            For Each item In SpecificProductList
                If item.ProductCode.ToUpper.StartsWith(sValue.ToUpper) Or item.ProductDescription.ToUpper.StartsWith(sValue) Then
                    lstProducts.Items.Add(item.ProductCode & ": " & item.ProductDescription)
                ElseIf item.ProductCode.ToUpper.Contains(sValue.ToUpper) Or item.ProductDescription.ToUpper.Contains(sValue.ToUpper) Then
                    lstProducts.Items.Add(item.ProductCode & ": " & item.ProductDescription)
                End If
            Next
        End If

    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtProductCode.Text = ""
        ChosenProductCode = ""
        Me.Close()
    End Sub
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        'ChosenProductCode = CheckString(txtProductCode.Text)
        ChosenProductCode = txtProductCode.Text
        Me.Close()
    End Sub
    Private Sub lstProducts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProducts.SelectedIndexChanged
        Try
            ' txtProductCode.Text = StripDescription(lstProducts.SelectedItem.ToString)
            ChosenProductCode = StripDescription(lstProducts.SelectedItem.ToString)
            Me.Close()
        Catch ex As Exception
            WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    'Private Sub frmKeyboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    '    ChosenProductCode = StripDescription(txtProductCode.Text)
    'End Sub

    Private Function StripDescription(sValue As String) As String
        Return sValue.Substring(0, sValue.IndexOf(":"))
    End Function

End Class