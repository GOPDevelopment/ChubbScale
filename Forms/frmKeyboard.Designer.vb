<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeyboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.keyboardcontrol1 = New KeyboardClassLibrary.Keyboardcontrol()
        Me.lblInput = New System.Windows.Forms.Label()
        Me.txtProductCode = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.lstProducts = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'keyboardcontrol1
        '
        Me.keyboardcontrol1.KeyboardType = KeyboardClassLibrary.BoW.Standard
        Me.keyboardcontrol1.Location = New System.Drawing.Point(5, 57)
        Me.keyboardcontrol1.Name = "keyboardcontrol1"
        Me.keyboardcontrol1.Size = New System.Drawing.Size(993, 282)
        Me.keyboardcontrol1.TabIndex = 1
        '
        'lblInput
        '
        Me.lblInput.AutoSize = True
        Me.lblInput.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInput.Location = New System.Drawing.Point(-2, 8)
        Me.lblInput.Name = "lblInput"
        Me.lblInput.Size = New System.Drawing.Size(243, 39)
        Me.lblInput.TabIndex = 3
        Me.lblInput.Text = "Product Code:"
        Me.lblInput.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtProductCode
        '
        Me.txtProductCode.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductCode.Location = New System.Drawing.Point(244, 5)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(456, 46)
        Me.txtProductCode.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(856, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(135, 47)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.Location = New System.Drawing.Point(716, 4)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(134, 47)
        Me.btnSelect.TabIndex = 9
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'lstProducts
        '
        Me.lstProducts.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstProducts.FormattingEnabled = True
        Me.lstProducts.ItemHeight = 29
        Me.lstProducts.Location = New System.Drawing.Point(149, 354)
        Me.lstProducts.Name = "lstProducts"
        Me.lstProducts.Size = New System.Drawing.Size(613, 294)
        Me.lstProducts.TabIndex = 10
        '
        'frmKeyboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 665)
        Me.ControlBox = False
        Me.Controls.Add(Me.lstProducts)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtProductCode)
        Me.Controls.Add(Me.lblInput)
        Me.Controls.Add(Me.keyboardcontrol1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmKeyboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Product"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents keyboardcontrol1 As KeyboardClassLibrary.Keyboardcontrol
    Friend WithEvents lblInput As System.Windows.Forms.Label
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents lstProducts As ListBox
End Class
