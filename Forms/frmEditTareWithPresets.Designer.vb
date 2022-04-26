<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditTareWithPresets
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.txtBoxTare = New System.Windows.Forms.TextBox()
        Me.txtItemCount = New System.Windows.Forms.TextBox()
        Me.txtItemTare = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGrade8 = New System.Windows.Forms.Button()
        Me.btnGrade7 = New System.Windows.Forms.Button()
        Me.btnGrade6 = New System.Windows.Forms.Button()
        Me.btnGrade5 = New System.Windows.Forms.Button()
        Me.btnGrade4 = New System.Windows.Forms.Button()
        Me.btnGrade3 = New System.Windows.Forms.Button()
        Me.btnGrade2 = New System.Windows.Forms.Button()
        Me.btnGrade1 = New System.Windows.Forms.Button()
        Me.btnGrade0 = New System.Windows.Forms.Button()
        Me.btnGrade9 = New System.Windows.Forms.Button()
        Me.btnGradePeriod = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.grpPresetTares = New System.Windows.Forms.GroupBox()
        Me.lstContainer = New System.Windows.Forms.ListBox()
        Me.btnIceManual = New System.Windows.Forms.Button()
        Me.btnClearTare = New System.Windows.Forms.Button()
        Me.btnIce30 = New System.Windows.Forms.Button()
        Me.btnIce20 = New System.Windows.Forms.Button()
        Me.btnIce0 = New System.Windows.Forms.Button()
        Me.grpPresetTares.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 42)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Product:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduct.Location = New System.Drawing.Point(161, 4)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(234, 42)
        Me.lblProduct.TabIndex = 4
        Me.lblProduct.Text = "_PRODUCT_"
        Me.lblProduct.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtBoxTare
        '
        Me.txtBoxTare.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxTare.Location = New System.Drawing.Point(7, 86)
        Me.txtBoxTare.Name = "txtBoxTare"
        Me.txtBoxTare.Size = New System.Drawing.Size(119, 40)
        Me.txtBoxTare.TabIndex = 5
        Me.txtBoxTare.Text = "0.0000"
        '
        'txtItemCount
        '
        Me.txtItemCount.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCount.Location = New System.Drawing.Point(189, 86)
        Me.txtItemCount.Name = "txtItemCount"
        Me.txtItemCount.Size = New System.Drawing.Size(119, 40)
        Me.txtItemCount.TabIndex = 6
        Me.txtItemCount.Text = "0"
        '
        'txtItemTare
        '
        Me.txtItemTare.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemTare.Location = New System.Drawing.Point(368, 86)
        Me.txtItemTare.Name = "txtItemTare"
        Me.txtItemTare.Size = New System.Drawing.Size(119, 40)
        Me.txtItemTare.TabIndex = 7
        Me.txtItemTare.Text = "0.0000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 19)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Box/Pallet Tare"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(185, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 19)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Item Count"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(364, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Item Tare"
        '
        'btnGrade8
        '
        Me.btnGrade8.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrade8.Location = New System.Drawing.Point(575, 148)
        Me.btnGrade8.Name = "btnGrade8"
        Me.btnGrade8.Size = New System.Drawing.Size(65, 65)
        Me.btnGrade8.TabIndex = 32
        Me.btnGrade8.Text = "8"
        Me.btnGrade8.UseVisualStyleBackColor = True
        '
        'btnGrade7
        '
        Me.btnGrade7.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrade7.Location = New System.Drawing.Point(504, 148)
        Me.btnGrade7.Name = "btnGrade7"
        Me.btnGrade7.Size = New System.Drawing.Size(65, 65)
        Me.btnGrade7.TabIndex = 31
        Me.btnGrade7.Text = "7"
        Me.btnGrade7.UseVisualStyleBackColor = True
        '
        'btnGrade6
        '
        Me.btnGrade6.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrade6.Location = New System.Drawing.Point(433, 148)
        Me.btnGrade6.Name = "btnGrade6"
        Me.btnGrade6.Size = New System.Drawing.Size(65, 65)
        Me.btnGrade6.TabIndex = 30
        Me.btnGrade6.Text = "6"
        Me.btnGrade6.UseVisualStyleBackColor = True
        '
        'btnGrade5
        '
        Me.btnGrade5.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrade5.Location = New System.Drawing.Point(362, 148)
        Me.btnGrade5.Name = "btnGrade5"
        Me.btnGrade5.Size = New System.Drawing.Size(65, 65)
        Me.btnGrade5.TabIndex = 29
        Me.btnGrade5.Text = "5"
        Me.btnGrade5.UseVisualStyleBackColor = True
        '
        'btnGrade4
        '
        Me.btnGrade4.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrade4.Location = New System.Drawing.Point(291, 148)
        Me.btnGrade4.Name = "btnGrade4"
        Me.btnGrade4.Size = New System.Drawing.Size(65, 65)
        Me.btnGrade4.TabIndex = 28
        Me.btnGrade4.Text = "4"
        Me.btnGrade4.UseVisualStyleBackColor = True
        '
        'btnGrade3
        '
        Me.btnGrade3.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrade3.Location = New System.Drawing.Point(220, 148)
        Me.btnGrade3.Name = "btnGrade3"
        Me.btnGrade3.Size = New System.Drawing.Size(65, 65)
        Me.btnGrade3.TabIndex = 27
        Me.btnGrade3.Text = "3"
        Me.btnGrade3.UseVisualStyleBackColor = True
        '
        'btnGrade2
        '
        Me.btnGrade2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrade2.Location = New System.Drawing.Point(149, 148)
        Me.btnGrade2.Name = "btnGrade2"
        Me.btnGrade2.Size = New System.Drawing.Size(65, 65)
        Me.btnGrade2.TabIndex = 26
        Me.btnGrade2.Text = "2"
        Me.btnGrade2.UseVisualStyleBackColor = True
        '
        'btnGrade1
        '
        Me.btnGrade1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrade1.Location = New System.Drawing.Point(78, 148)
        Me.btnGrade1.Name = "btnGrade1"
        Me.btnGrade1.Size = New System.Drawing.Size(65, 65)
        Me.btnGrade1.TabIndex = 25
        Me.btnGrade1.Text = "1"
        Me.btnGrade1.UseVisualStyleBackColor = True
        '
        'btnGrade0
        '
        Me.btnGrade0.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrade0.Location = New System.Drawing.Point(7, 148)
        Me.btnGrade0.Name = "btnGrade0"
        Me.btnGrade0.Size = New System.Drawing.Size(65, 65)
        Me.btnGrade0.TabIndex = 33
        Me.btnGrade0.Text = "0"
        Me.btnGrade0.UseVisualStyleBackColor = True
        '
        'btnGrade9
        '
        Me.btnGrade9.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrade9.Location = New System.Drawing.Point(646, 148)
        Me.btnGrade9.Name = "btnGrade9"
        Me.btnGrade9.Size = New System.Drawing.Size(65, 65)
        Me.btnGrade9.TabIndex = 34
        Me.btnGrade9.Text = "9"
        Me.btnGrade9.UseVisualStyleBackColor = True
        '
        'btnGradePeriod
        '
        Me.btnGradePeriod.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGradePeriod.Location = New System.Drawing.Point(717, 148)
        Me.btnGradePeriod.Name = "btnGradePeriod"
        Me.btnGradePeriod.Size = New System.Drawing.Size(65, 65)
        Me.btnGradePeriod.TabIndex = 35
        Me.btnGradePeriod.Text = "."
        Me.btnGradePeriod.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.Location = New System.Drawing.Point(560, 86)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(108, 37)
        Me.btnApply.TabIndex = 36
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(674, 86)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(108, 37)
        Me.btnCancel.TabIndex = 37
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'grpPresetTares
        '
        Me.grpPresetTares.Controls.Add(Me.lstContainer)
        Me.grpPresetTares.Controls.Add(Me.btnIceManual)
        Me.grpPresetTares.Controls.Add(Me.btnClearTare)
        Me.grpPresetTares.Controls.Add(Me.btnIce30)
        Me.grpPresetTares.Controls.Add(Me.btnIce20)
        Me.grpPresetTares.Controls.Add(Me.btnIce0)
        Me.grpPresetTares.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPresetTares.Location = New System.Drawing.Point(12, 243)
        Me.grpPresetTares.Name = "grpPresetTares"
        Me.grpPresetTares.Size = New System.Drawing.Size(766, 208)
        Me.grpPresetTares.TabIndex = 38
        Me.grpPresetTares.TabStop = False
        Me.grpPresetTares.Text = "Preset Tares/Ice"
        '
        'lstContainer
        '
        Me.lstContainer.FormattingEnabled = True
        Me.lstContainer.ItemHeight = 25
        Me.lstContainer.Location = New System.Drawing.Point(526, 23)
        Me.lstContainer.Name = "lstContainer"
        Me.lstContainer.Size = New System.Drawing.Size(219, 154)
        Me.lstContainer.TabIndex = 71
        '
        'btnIceManual
        '
        Me.btnIceManual.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIceManual.Location = New System.Drawing.Point(331, 38)
        Me.btnIceManual.Name = "btnIceManual"
        Me.btnIceManual.Size = New System.Drawing.Size(83, 80)
        Me.btnIceManual.TabIndex = 70
        Me.btnIceManual.Text = "Manual Ice"
        Me.btnIceManual.UseVisualStyleBackColor = True
        '
        'btnClearTare
        '
        Me.btnClearTare.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearTare.Location = New System.Drawing.Point(433, 49)
        Me.btnClearTare.Name = "btnClearTare"
        Me.btnClearTare.Size = New System.Drawing.Size(63, 59)
        Me.btnClearTare.TabIndex = 69
        Me.btnClearTare.Text = "0 Tare"
        Me.btnClearTare.UseVisualStyleBackColor = True
        '
        'btnIce30
        '
        Me.btnIce30.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIce30.Location = New System.Drawing.Point(227, 38)
        Me.btnIce30.Name = "btnIce30"
        Me.btnIce30.Size = New System.Drawing.Size(83, 80)
        Me.btnIce30.TabIndex = 67
        Me.btnIce30.Text = "30 # ICE"
        Me.btnIce30.UseVisualStyleBackColor = True
        '
        'btnIce20
        '
        Me.btnIce20.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIce20.Location = New System.Drawing.Point(123, 38)
        Me.btnIce20.Name = "btnIce20"
        Me.btnIce20.Size = New System.Drawing.Size(83, 80)
        Me.btnIce20.TabIndex = 66
        Me.btnIce20.Text = "20 # ICE"
        Me.btnIce20.UseVisualStyleBackColor = True
        '
        'btnIce0
        '
        Me.btnIce0.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIce0.Location = New System.Drawing.Point(19, 38)
        Me.btnIce0.Name = "btnIce0"
        Me.btnIce0.Size = New System.Drawing.Size(83, 80)
        Me.btnIce0.TabIndex = 65
        Me.btnIce0.Text = "NO ICE"
        Me.btnIce0.UseVisualStyleBackColor = True
        '
        'frmEditTare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 463)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpPresetTares)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnGradePeriod)
        Me.Controls.Add(Me.btnGrade9)
        Me.Controls.Add(Me.btnGrade0)
        Me.Controls.Add(Me.btnGrade8)
        Me.Controls.Add(Me.btnGrade7)
        Me.Controls.Add(Me.btnGrade6)
        Me.Controls.Add(Me.btnGrade5)
        Me.Controls.Add(Me.btnGrade4)
        Me.Controls.Add(Me.btnGrade3)
        Me.Controls.Add(Me.btnGrade2)
        Me.Controls.Add(Me.btnGrade1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtItemTare)
        Me.Controls.Add(Me.txtItemCount)
        Me.Controls.Add(Me.txtBoxTare)
        Me.Controls.Add(Me.lblProduct)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmEditTare"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Product Tare Settings"
        Me.grpPresetTares.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents txtBoxTare As System.Windows.Forms.TextBox
    Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
    Friend WithEvents txtItemTare As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnGrade8 As System.Windows.Forms.Button
    Friend WithEvents btnGrade7 As System.Windows.Forms.Button
    Friend WithEvents btnGrade6 As System.Windows.Forms.Button
    Friend WithEvents btnGrade5 As System.Windows.Forms.Button
    Friend WithEvents btnGrade4 As System.Windows.Forms.Button
    Friend WithEvents btnGrade3 As System.Windows.Forms.Button
    Friend WithEvents btnGrade2 As System.Windows.Forms.Button
    Friend WithEvents btnGrade1 As System.Windows.Forms.Button
    Friend WithEvents btnGrade0 As System.Windows.Forms.Button
    Friend WithEvents btnGrade9 As System.Windows.Forms.Button
    Friend WithEvents btnGradePeriod As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpPresetTares As GroupBox
    Friend WithEvents lstContainer As ListBox
    Friend WithEvents btnIceManual As Button
    Friend WithEvents btnClearTare As Button
    Friend WithEvents btnIce30 As Button
    Friend WithEvents btnIce20 As Button
    Friend WithEvents btnIce0 As Button
End Class
