<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScaleGrinding
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScaleGrinding))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblBoxesInLot = New System.Windows.Forms.Label()
        Me.lblBoxesInLotDisplay = New System.Windows.Forms.Label()
        Me.lblLot = New System.Windows.Forms.Label()
        Me.lblLotDisplay = New System.Windows.Forms.Label()
        Me.btnMakeFavorite = New System.Windows.Forms.Button()
        Me.lblSerial = New System.Windows.Forms.Label()
        Me.lblSerialNumberDisplay = New System.Windows.Forms.Label()
        Me.lblProductCode = New System.Windows.Forms.Label()
        Me.lblProductDesc = New System.Windows.Forms.Label()
        Me.btnProductLookup = New System.Windows.Forms.Button()
        Me.btnChangeLot = New System.Windows.Forms.Button()
        Me.txtTare = New System.Windows.Forms.TextBox()
        Me.txtNetWeight = New System.Windows.Forms.TextBox()
        Me.lblGrossWeight = New System.Windows.Forms.Label()
        Me.lblNetWeight = New System.Windows.Forms.Label()
        Me.lblTare = New System.Windows.Forms.Label()
        Me.lblMin = New System.Windows.Forms.Label()
        Me.lblSetWeight = New System.Windows.Forms.Label()
        Me.lblMax = New System.Windows.Forms.Label()
        Me.txtSetWeight = New System.Windows.Forms.TextBox()
        Me.txtMaxWeight = New System.Windows.Forms.TextBox()
        Me.txtMinWeight = New System.Windows.Forms.TextBox()
        Me.txtGrossWeight = New System.Windows.Forms.TextBox()
        Me.grpFavorites = New System.Windows.Forms.GroupBox()
        Me.btnF12Fave = New System.Windows.Forms.Button()
        Me.btnF11Fave = New System.Windows.Forms.Button()
        Me.btnF10Fave = New System.Windows.Forms.Button()
        Me.btnF9Fave = New System.Windows.Forms.Button()
        Me.btnF8Fave = New System.Windows.Forms.Button()
        Me.btnF7Fave = New System.Windows.Forms.Button()
        Me.btnF6Fave = New System.Windows.Forms.Button()
        Me.btnF1Fave = New System.Windows.Forms.Button()
        Me.btnF2Fave = New System.Windows.Forms.Button()
        Me.btnF3Fave = New System.Windows.Forms.Button()
        Me.btnF4Fave = New System.Windows.Forms.Button()
        Me.btnF5Fave = New System.Windows.Forms.Button()
        Me.btnProdActive = New System.Windows.Forms.Button()
        Me.lblShiftDisplay = New System.Windows.Forms.Label()
        Me.lblPlant = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblPlantDisplay = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.lblStationDisplay = New System.Windows.Forms.Label()
        Me.lblTimeDisplay = New System.Windows.Forms.Label()
        Me.lblDateDisplay = New System.Windows.Forms.Label()
        Me.lblDayDisplay = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtWarnings = New System.Windows.Forms.TextBox()
        Me.grpTotalsPerProduct = New System.Windows.Forms.GroupBox()
        Me.lblWeightTotal = New System.Windows.Forms.Label()
        Me.lblBoxesPerShift = New System.Windows.Forms.Label()
        Me.lblProductCount = New System.Windows.Forms.Label()
        Me.lblProductCountDaily = New System.Windows.Forms.Label()
        Me.lblWeightTotalShift = New System.Windows.Forms.Label()
        Me.lblBoxTotalShift = New System.Windows.Forms.Label()
        Me.lblCurrentShift = New System.Windows.Forms.Label()
        Me.lblBoxTotalDaily = New System.Windows.Forms.Label()
        Me.lblWeightTotalDaily = New System.Windows.Forms.Label()
        Me.lblProductCountShift = New System.Windows.Forms.Label()
        Me.lblDailyTotal = New System.Windows.Forms.Label()
        Me.btnToggleLanguage = New System.Windows.Forms.Button()
        Me.btnSetWeightPrint = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.grpFavorites.SuspendLayout()
        Me.grpTotalsPerProduct.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'lblBoxesInLot
        '
        Me.lblBoxesInLot.AutoSize = True
        Me.lblBoxesInLot.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxesInLot.Location = New System.Drawing.Point(625, 355)
        Me.lblBoxesInLot.Name = "lblBoxesInLot"
        Me.lblBoxesInLot.Size = New System.Drawing.Size(115, 19)
        Me.lblBoxesInLot.TabIndex = 139
        Me.lblBoxesInLot.Text = "Boxes in Lot:"
        Me.lblBoxesInLot.Visible = False
        '
        'lblBoxesInLotDisplay
        '
        Me.lblBoxesInLotDisplay.BackColor = System.Drawing.SystemColors.Control
        Me.lblBoxesInLotDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBoxesInLotDisplay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxesInLotDisplay.Location = New System.Drawing.Point(746, 354)
        Me.lblBoxesInLotDisplay.Name = "lblBoxesInLotDisplay"
        Me.lblBoxesInLotDisplay.Size = New System.Drawing.Size(90, 22)
        Me.lblBoxesInLotDisplay.TabIndex = 138
        Me.lblBoxesInLotDisplay.Visible = False
        '
        'lblLot
        '
        Me.lblLot.AutoSize = True
        Me.lblLot.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLot.Location = New System.Drawing.Point(482, 355)
        Me.lblLot.Name = "lblLot"
        Me.lblLot.Size = New System.Drawing.Size(41, 19)
        Me.lblLot.TabIndex = 136
        Me.lblLot.Text = "Lot:"
        '
        'lblLotDisplay
        '
        Me.lblLotDisplay.BackColor = System.Drawing.SystemColors.Control
        Me.lblLotDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLotDisplay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotDisplay.Location = New System.Drawing.Point(531, 354)
        Me.lblLotDisplay.Name = "lblLotDisplay"
        Me.lblLotDisplay.Size = New System.Drawing.Size(77, 22)
        Me.lblLotDisplay.TabIndex = 135
        '
        'btnMakeFavorite
        '
        Me.btnMakeFavorite.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMakeFavorite.Location = New System.Drawing.Point(643, 258)
        Me.btnMakeFavorite.Name = "btnMakeFavorite"
        Me.btnMakeFavorite.Size = New System.Drawing.Size(198, 32)
        Me.btnMakeFavorite.TabIndex = 134
        Me.btnMakeFavorite.Text = "Make Favorite"
        Me.btnMakeFavorite.UseVisualStyleBackColor = True
        '
        'lblSerial
        '
        Me.lblSerial.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerial.Location = New System.Drawing.Point(443, 325)
        Me.lblSerial.Name = "lblSerial"
        Me.lblSerial.Size = New System.Drawing.Size(82, 19)
        Me.lblSerial.TabIndex = 122
        Me.lblSerial.Text = "Serial:"
        Me.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSerialNumberDisplay
        '
        Me.lblSerialNumberDisplay.BackColor = System.Drawing.SystemColors.Control
        Me.lblSerialNumberDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSerialNumberDisplay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialNumberDisplay.Location = New System.Drawing.Point(531, 324)
        Me.lblSerialNumberDisplay.Name = "lblSerialNumberDisplay"
        Me.lblSerialNumberDisplay.Size = New System.Drawing.Size(305, 22)
        Me.lblSerialNumberDisplay.TabIndex = 113
        '
        'lblProductCode
        '
        Me.lblProductCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProductCode.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductCode.Location = New System.Drawing.Point(234, 262)
        Me.lblProductCode.Name = "lblProductCode"
        Me.lblProductCode.Size = New System.Drawing.Size(76, 27)
        Me.lblProductCode.TabIndex = 131
        '
        'lblProductDesc
        '
        Me.lblProductDesc.BackColor = System.Drawing.SystemColors.Control
        Me.lblProductDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProductDesc.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductDesc.Location = New System.Drawing.Point(322, 262)
        Me.lblProductDesc.Name = "lblProductDesc"
        Me.lblProductDesc.Size = New System.Drawing.Size(299, 27)
        Me.lblProductDesc.TabIndex = 130
        '
        'btnProductLookup
        '
        Me.btnProductLookup.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProductLookup.Location = New System.Drawing.Point(35, 258)
        Me.btnProductLookup.Name = "btnProductLookup"
        Me.btnProductLookup.Size = New System.Drawing.Size(186, 36)
        Me.btnProductLookup.TabIndex = 121
        Me.btnProductLookup.Text = "Product Lookup"
        Me.btnProductLookup.UseVisualStyleBackColor = True
        '
        'btnChangeLot
        '
        Me.btnChangeLot.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeLot.Location = New System.Drawing.Point(494, 422)
        Me.btnChangeLot.Name = "btnChangeLot"
        Me.btnChangeLot.Size = New System.Drawing.Size(160, 54)
        Me.btnChangeLot.TabIndex = 118
        Me.btnChangeLot.Text = "Change Lot"
        Me.btnChangeLot.UseVisualStyleBackColor = True
        '
        'txtTare
        '
        Me.txtTare.Cursor = System.Windows.Forms.Cursors.No
        Me.txtTare.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTare.Location = New System.Drawing.Point(320, 170)
        Me.txtTare.MaxLength = 300
        Me.txtTare.Name = "txtTare"
        Me.txtTare.ReadOnly = True
        Me.txtTare.Size = New System.Drawing.Size(93, 46)
        Me.txtTare.TabIndex = 169
        Me.txtTare.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNetWeight
        '
        Me.txtNetWeight.Cursor = System.Windows.Forms.Cursors.No
        Me.txtNetWeight.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetWeight.Location = New System.Drawing.Point(471, 170)
        Me.txtNetWeight.MaxLength = 300
        Me.txtNetWeight.Name = "txtNetWeight"
        Me.txtNetWeight.ReadOnly = True
        Me.txtNetWeight.Size = New System.Drawing.Size(93, 46)
        Me.txtNetWeight.TabIndex = 168
        Me.txtNetWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblGrossWeight
        '
        Me.lblGrossWeight.AutoSize = True
        Me.lblGrossWeight.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrossWeight.Location = New System.Drawing.Point(22, 137)
        Me.lblGrossWeight.Name = "lblGrossWeight"
        Me.lblGrossWeight.Size = New System.Drawing.Size(128, 23)
        Me.lblGrossWeight.TabIndex = 167
        Me.lblGrossWeight.Text = "Gross Weight:"
        '
        'lblNetWeight
        '
        Me.lblNetWeight.AutoSize = True
        Me.lblNetWeight.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNetWeight.Location = New System.Drawing.Point(465, 137)
        Me.lblNetWeight.Name = "lblNetWeight"
        Me.lblNetWeight.Size = New System.Drawing.Size(111, 23)
        Me.lblNetWeight.TabIndex = 166
        Me.lblNetWeight.Text = "Net Weight:"
        '
        'lblTare
        '
        Me.lblTare.AutoSize = True
        Me.lblTare.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTare.Location = New System.Drawing.Point(340, 137)
        Me.lblTare.Name = "lblTare"
        Me.lblTare.Size = New System.Drawing.Size(55, 23)
        Me.lblTare.TabIndex = 165
        Me.lblTare.Text = "Tare:"
        '
        'lblMin
        '
        Me.lblMin.AutoSize = True
        Me.lblMin.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMin.Location = New System.Drawing.Point(620, 137)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.Size = New System.Drawing.Size(94, 23)
        Me.lblMin.TabIndex = 164
        Me.lblMin.Text = "Minimum:"
        '
        'lblSetWeight
        '
        Me.lblSetWeight.AutoSize = True
        Me.lblSetWeight.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSetWeight.Location = New System.Drawing.Point(163, 137)
        Me.lblSetWeight.Name = "lblSetWeight"
        Me.lblSetWeight.Size = New System.Drawing.Size(109, 23)
        Me.lblSetWeight.TabIndex = 163
        Me.lblSetWeight.Text = "Set Weight:"
        '
        'lblMax
        '
        Me.lblMax.AutoSize = True
        Me.lblMax.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMax.Location = New System.Drawing.Point(748, 137)
        Me.lblMax.Name = "lblMax"
        Me.lblMax.Size = New System.Drawing.Size(98, 23)
        Me.lblMax.TabIndex = 162
        Me.lblMax.Text = "Maximum:"
        '
        'txtSetWeight
        '
        Me.txtSetWeight.Cursor = System.Windows.Forms.Cursors.No
        Me.txtSetWeight.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSetWeight.Location = New System.Drawing.Point(167, 170)
        Me.txtSetWeight.Name = "txtSetWeight"
        Me.txtSetWeight.ReadOnly = True
        Me.txtSetWeight.Size = New System.Drawing.Size(93, 46)
        Me.txtSetWeight.TabIndex = 161
        Me.txtSetWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMaxWeight
        '
        Me.txtMaxWeight.Cursor = System.Windows.Forms.Cursors.No
        Me.txtMaxWeight.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxWeight.Location = New System.Drawing.Point(748, 170)
        Me.txtMaxWeight.Name = "txtMaxWeight"
        Me.txtMaxWeight.ReadOnly = True
        Me.txtMaxWeight.Size = New System.Drawing.Size(93, 46)
        Me.txtMaxWeight.TabIndex = 160
        Me.txtMaxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMinWeight
        '
        Me.txtMinWeight.Cursor = System.Windows.Forms.Cursors.No
        Me.txtMinWeight.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinWeight.Location = New System.Drawing.Point(621, 170)
        Me.txtMinWeight.Name = "txtMinWeight"
        Me.txtMinWeight.ReadOnly = True
        Me.txtMinWeight.Size = New System.Drawing.Size(93, 46)
        Me.txtMinWeight.TabIndex = 147
        Me.txtMinWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGrossWeight
        '
        Me.txtGrossWeight.Cursor = System.Windows.Forms.Cursors.No
        Me.txtGrossWeight.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrossWeight.Location = New System.Drawing.Point(40, 170)
        Me.txtGrossWeight.MaxLength = 300
        Me.txtGrossWeight.Name = "txtGrossWeight"
        Me.txtGrossWeight.ReadOnly = True
        Me.txtGrossWeight.Size = New System.Drawing.Size(93, 46)
        Me.txtGrossWeight.TabIndex = 145
        Me.txtGrossWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grpFavorites
        '
        Me.grpFavorites.Controls.Add(Me.btnF12Fave)
        Me.grpFavorites.Controls.Add(Me.btnF11Fave)
        Me.grpFavorites.Controls.Add(Me.btnF10Fave)
        Me.grpFavorites.Controls.Add(Me.btnF9Fave)
        Me.grpFavorites.Controls.Add(Me.btnF8Fave)
        Me.grpFavorites.Controls.Add(Me.btnF7Fave)
        Me.grpFavorites.Controls.Add(Me.btnF6Fave)
        Me.grpFavorites.Controls.Add(Me.btnF1Fave)
        Me.grpFavorites.Controls.Add(Me.btnF2Fave)
        Me.grpFavorites.Controls.Add(Me.btnF3Fave)
        Me.grpFavorites.Controls.Add(Me.btnF4Fave)
        Me.grpFavorites.Controls.Add(Me.btnF5Fave)
        Me.grpFavorites.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFavorites.Location = New System.Drawing.Point(38, 492)
        Me.grpFavorites.Name = "grpFavorites"
        Me.grpFavorites.Size = New System.Drawing.Size(675, 240)
        Me.grpFavorites.TabIndex = 170
        Me.grpFavorites.TabStop = False
        Me.grpFavorites.Text = "Favorites"
        '
        'btnF12Fave
        '
        Me.btnF12Fave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnF12Fave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF12Fave.Location = New System.Drawing.Point(565, 134)
        Me.btnF12Fave.Name = "btnF12Fave"
        Me.btnF12Fave.Size = New System.Drawing.Size(90, 85)
        Me.btnF12Fave.TabIndex = 60
        Me.btnF12Fave.UseVisualStyleBackColor = True
        '
        'btnF11Fave
        '
        Me.btnF11Fave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnF11Fave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF11Fave.Location = New System.Drawing.Point(456, 134)
        Me.btnF11Fave.Name = "btnF11Fave"
        Me.btnF11Fave.Size = New System.Drawing.Size(90, 85)
        Me.btnF11Fave.TabIndex = 59
        Me.btnF11Fave.UseVisualStyleBackColor = True
        '
        'btnF10Fave
        '
        Me.btnF10Fave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnF10Fave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF10Fave.Location = New System.Drawing.Point(347, 134)
        Me.btnF10Fave.Name = "btnF10Fave"
        Me.btnF10Fave.Size = New System.Drawing.Size(90, 85)
        Me.btnF10Fave.TabIndex = 58
        Me.btnF10Fave.UseVisualStyleBackColor = True
        '
        'btnF9Fave
        '
        Me.btnF9Fave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnF9Fave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF9Fave.Location = New System.Drawing.Point(238, 134)
        Me.btnF9Fave.Name = "btnF9Fave"
        Me.btnF9Fave.Size = New System.Drawing.Size(90, 85)
        Me.btnF9Fave.TabIndex = 57
        Me.btnF9Fave.UseVisualStyleBackColor = True
        '
        'btnF8Fave
        '
        Me.btnF8Fave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnF8Fave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF8Fave.Location = New System.Drawing.Point(129, 134)
        Me.btnF8Fave.Name = "btnF8Fave"
        Me.btnF8Fave.Size = New System.Drawing.Size(90, 85)
        Me.btnF8Fave.TabIndex = 56
        Me.btnF8Fave.UseVisualStyleBackColor = True
        '
        'btnF7Fave
        '
        Me.btnF7Fave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnF7Fave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF7Fave.Location = New System.Drawing.Point(20, 134)
        Me.btnF7Fave.Name = "btnF7Fave"
        Me.btnF7Fave.Size = New System.Drawing.Size(90, 85)
        Me.btnF7Fave.TabIndex = 55
        Me.btnF7Fave.UseVisualStyleBackColor = True
        '
        'btnF6Fave
        '
        Me.btnF6Fave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnF6Fave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF6Fave.Location = New System.Drawing.Point(565, 30)
        Me.btnF6Fave.Name = "btnF6Fave"
        Me.btnF6Fave.Size = New System.Drawing.Size(90, 85)
        Me.btnF6Fave.TabIndex = 82
        Me.btnF6Fave.UseVisualStyleBackColor = True
        '
        'btnF1Fave
        '
        Me.btnF1Fave.BackColor = System.Drawing.SystemColors.Control
        Me.btnF1Fave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnF1Fave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF1Fave.Location = New System.Drawing.Point(20, 30)
        Me.btnF1Fave.Name = "btnF1Fave"
        Me.btnF1Fave.Size = New System.Drawing.Size(90, 85)
        Me.btnF1Fave.TabIndex = 77
        Me.btnF1Fave.UseVisualStyleBackColor = True
        '
        'btnF2Fave
        '
        Me.btnF2Fave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnF2Fave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF2Fave.Location = New System.Drawing.Point(129, 30)
        Me.btnF2Fave.Name = "btnF2Fave"
        Me.btnF2Fave.Size = New System.Drawing.Size(90, 85)
        Me.btnF2Fave.TabIndex = 78
        Me.btnF2Fave.UseVisualStyleBackColor = True
        '
        'btnF3Fave
        '
        Me.btnF3Fave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnF3Fave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF3Fave.Location = New System.Drawing.Point(238, 30)
        Me.btnF3Fave.Name = "btnF3Fave"
        Me.btnF3Fave.Size = New System.Drawing.Size(90, 85)
        Me.btnF3Fave.TabIndex = 79
        Me.btnF3Fave.UseVisualStyleBackColor = True
        '
        'btnF4Fave
        '
        Me.btnF4Fave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnF4Fave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF4Fave.Location = New System.Drawing.Point(347, 30)
        Me.btnF4Fave.Name = "btnF4Fave"
        Me.btnF4Fave.Size = New System.Drawing.Size(90, 85)
        Me.btnF4Fave.TabIndex = 80
        Me.btnF4Fave.UseVisualStyleBackColor = True
        '
        'btnF5Fave
        '
        Me.btnF5Fave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnF5Fave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF5Fave.Location = New System.Drawing.Point(456, 30)
        Me.btnF5Fave.Name = "btnF5Fave"
        Me.btnF5Fave.Size = New System.Drawing.Size(90, 85)
        Me.btnF5Fave.TabIndex = 81
        Me.btnF5Fave.UseVisualStyleBackColor = True
        '
        'btnProdActive
        '
        Me.btnProdActive.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnProdActive.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProdActive.Location = New System.Drawing.Point(682, 422)
        Me.btnProdActive.Name = "btnProdActive"
        Me.btnProdActive.Size = New System.Drawing.Size(160, 54)
        Me.btnProdActive.TabIndex = 172
        Me.btnProdActive.Text = "Production Active"
        Me.btnProdActive.UseVisualStyleBackColor = False
        '
        'lblShiftDisplay
        '
        Me.lblShiftDisplay.AutoSize = True
        Me.lblShiftDisplay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftDisplay.Location = New System.Drawing.Point(151, 75)
        Me.lblShiftDisplay.Name = "lblShiftDisplay"
        Me.lblShiftDisplay.Size = New System.Drawing.Size(121, 19)
        Me.lblShiftDisplay.TabIndex = 185
        Me.lblShiftDisplay.Text = "<Shift Display>"
        '
        'lblPlant
        '
        Me.lblPlant.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPlant.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlant.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPlant.Location = New System.Drawing.Point(35, 22)
        Me.lblPlant.Name = "lblPlant"
        Me.lblPlant.Size = New System.Drawing.Size(103, 19)
        Me.lblPlant.TabIndex = 196
        Me.lblPlant.Text = "Plant:"
        Me.lblPlant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblShift
        '
        Me.lblShift.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblShift.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblShift.Location = New System.Drawing.Point(39, 75)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(97, 19)
        Me.lblShift.TabIndex = 193
        Me.lblShift.Text = "Shift:"
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPlantDisplay
        '
        Me.lblPlantDisplay.AutoSize = True
        Me.lblPlantDisplay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlantDisplay.Location = New System.Drawing.Point(151, 23)
        Me.lblPlantDisplay.Name = "lblPlantDisplay"
        Me.lblPlantDisplay.Size = New System.Drawing.Size(124, 19)
        Me.lblPlantDisplay.TabIndex = 195
        Me.lblPlantDisplay.Text = "<Plant Display>"
        '
        'lblStation
        '
        Me.lblStation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStation.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStation.Location = New System.Drawing.Point(35, 48)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(103, 19)
        Me.lblStation.TabIndex = 194
        Me.lblStation.Text = "Station:"
        Me.lblStation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStationDisplay
        '
        Me.lblStationDisplay.AutoSize = True
        Me.lblStationDisplay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStationDisplay.Location = New System.Drawing.Point(152, 48)
        Me.lblStationDisplay.Name = "lblStationDisplay"
        Me.lblStationDisplay.Size = New System.Drawing.Size(138, 19)
        Me.lblStationDisplay.TabIndex = 192
        Me.lblStationDisplay.Text = "<Station Display>"
        '
        'lblTimeDisplay
        '
        Me.lblTimeDisplay.AutoSize = True
        Me.lblTimeDisplay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeDisplay.Location = New System.Drawing.Point(694, 73)
        Me.lblTimeDisplay.Name = "lblTimeDisplay"
        Me.lblTimeDisplay.Size = New System.Drawing.Size(125, 19)
        Me.lblTimeDisplay.TabIndex = 191
        Me.lblTimeDisplay.Text = "<Time Display>"
        '
        'lblDateDisplay
        '
        Me.lblDateDisplay.AutoSize = True
        Me.lblDateDisplay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateDisplay.Location = New System.Drawing.Point(694, 24)
        Me.lblDateDisplay.Name = "lblDateDisplay"
        Me.lblDateDisplay.Size = New System.Drawing.Size(121, 19)
        Me.lblDateDisplay.TabIndex = 190
        Me.lblDateDisplay.Text = "<Date Display>"
        '
        'lblDayDisplay
        '
        Me.lblDayDisplay.AutoSize = True
        Me.lblDayDisplay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDayDisplay.Location = New System.Drawing.Point(694, 48)
        Me.lblDayDisplay.Name = "lblDayDisplay"
        Me.lblDayDisplay.Size = New System.Drawing.Size(128, 19)
        Me.lblDayDisplay.TabIndex = 189
        Me.lblDayDisplay.Text = "<Day# Display>"
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTime.Location = New System.Drawing.Point(593, 72)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(84, 19)
        Me.lblTime.TabIndex = 188
        Me.lblTime.Text = "Time:"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDay
        '
        Me.lblDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDay.Location = New System.Drawing.Point(589, 46)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(88, 19)
        Me.lblDay.TabIndex = 187
        Me.lblDay.Text = "Day#:"
        Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDate.Location = New System.Drawing.Point(585, 21)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(92, 19)
        Me.lblDate.TabIndex = 186
        Me.lblDate.Text = "Date:"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWarnings
        '
        Me.txtWarnings.BackColor = System.Drawing.SystemColors.Control
        Me.txtWarnings.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtWarnings.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWarnings.ForeColor = System.Drawing.Color.Red
        Me.txtWarnings.Location = New System.Drawing.Point(333, 32)
        Me.txtWarnings.Multiline = True
        Me.txtWarnings.Name = "txtWarnings"
        Me.txtWarnings.Size = New System.Drawing.Size(214, 87)
        Me.txtWarnings.TabIndex = 184
        Me.txtWarnings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grpTotalsPerProduct
        '
        Me.grpTotalsPerProduct.Controls.Add(Me.lblWeightTotal)
        Me.grpTotalsPerProduct.Controls.Add(Me.lblBoxesPerShift)
        Me.grpTotalsPerProduct.Controls.Add(Me.lblProductCount)
        Me.grpTotalsPerProduct.Controls.Add(Me.lblProductCountDaily)
        Me.grpTotalsPerProduct.Controls.Add(Me.lblWeightTotalShift)
        Me.grpTotalsPerProduct.Controls.Add(Me.lblBoxTotalShift)
        Me.grpTotalsPerProduct.Controls.Add(Me.lblCurrentShift)
        Me.grpTotalsPerProduct.Controls.Add(Me.lblBoxTotalDaily)
        Me.grpTotalsPerProduct.Controls.Add(Me.lblWeightTotalDaily)
        Me.grpTotalsPerProduct.Controls.Add(Me.lblProductCountShift)
        Me.grpTotalsPerProduct.Controls.Add(Me.lblDailyTotal)
        Me.grpTotalsPerProduct.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTotalsPerProduct.Location = New System.Drawing.Point(35, 311)
        Me.grpTotalsPerProduct.Name = "grpTotalsPerProduct"
        Me.grpTotalsPerProduct.Size = New System.Drawing.Size(402, 165)
        Me.grpTotalsPerProduct.TabIndex = 197
        Me.grpTotalsPerProduct.TabStop = False
        Me.grpTotalsPerProduct.Text = "Totals Per Product:"
        '
        'lblWeightTotal
        '
        Me.lblWeightTotal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeightTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblWeightTotal.Location = New System.Drawing.Point(12, 116)
        Me.lblWeightTotal.Name = "lblWeightTotal"
        Me.lblWeightTotal.Size = New System.Drawing.Size(140, 19)
        Me.lblWeightTotal.TabIndex = 59
        Me.lblWeightTotal.Text = "Weight Total:"
        Me.lblWeightTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBoxesPerShift
        '
        Me.lblBoxesPerShift.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxesPerShift.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblBoxesPerShift.Location = New System.Drawing.Point(6, 85)
        Me.lblBoxesPerShift.Name = "lblBoxesPerShift"
        Me.lblBoxesPerShift.Size = New System.Drawing.Size(145, 19)
        Me.lblBoxesPerShift.TabIndex = 58
        Me.lblBoxesPerShift.Text = "Boxes Per Shift:"
        Me.lblBoxesPerShift.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProductCount
        '
        Me.lblProductCount.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblProductCount.Location = New System.Drawing.Point(9, 54)
        Me.lblProductCount.Name = "lblProductCount"
        Me.lblProductCount.Size = New System.Drawing.Size(145, 19)
        Me.lblProductCount.TabIndex = 56
        Me.lblProductCount.Text = "Product Count:"
        Me.lblProductCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProductCountDaily
        '
        Me.lblProductCountDaily.AutoSize = True
        Me.lblProductCountDaily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProductCountDaily.Location = New System.Drawing.Point(319, 54)
        Me.lblProductCountDaily.Name = "lblProductCountDaily"
        Me.lblProductCountDaily.Size = New System.Drawing.Size(20, 21)
        Me.lblProductCountDaily.TabIndex = 11
        Me.lblProductCountDaily.Text = "0"
        '
        'lblWeightTotalShift
        '
        Me.lblWeightTotalShift.AutoSize = True
        Me.lblWeightTotalShift.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWeightTotalShift.Location = New System.Drawing.Point(177, 114)
        Me.lblWeightTotalShift.Name = "lblWeightTotalShift"
        Me.lblWeightTotalShift.Size = New System.Drawing.Size(20, 21)
        Me.lblWeightTotalShift.TabIndex = 22
        Me.lblWeightTotalShift.Text = "0"
        '
        'lblBoxTotalShift
        '
        Me.lblBoxTotalShift.AutoSize = True
        Me.lblBoxTotalShift.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBoxTotalShift.Location = New System.Drawing.Point(177, 84)
        Me.lblBoxTotalShift.Name = "lblBoxTotalShift"
        Me.lblBoxTotalShift.Size = New System.Drawing.Size(20, 21)
        Me.lblBoxTotalShift.TabIndex = 23
        Me.lblBoxTotalShift.Text = "0"
        '
        'lblCurrentShift
        '
        Me.lblCurrentShift.AutoSize = True
        Me.lblCurrentShift.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentShift.Location = New System.Drawing.Point(138, 21)
        Me.lblCurrentShift.Name = "lblCurrentShift"
        Me.lblCurrentShift.Size = New System.Drawing.Size(114, 19)
        Me.lblCurrentShift.TabIndex = 55
        Me.lblCurrentShift.Text = "Current Shift"
        '
        'lblBoxTotalDaily
        '
        Me.lblBoxTotalDaily.AutoSize = True
        Me.lblBoxTotalDaily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBoxTotalDaily.Location = New System.Drawing.Point(319, 85)
        Me.lblBoxTotalDaily.Name = "lblBoxTotalDaily"
        Me.lblBoxTotalDaily.Size = New System.Drawing.Size(20, 21)
        Me.lblBoxTotalDaily.TabIndex = 12
        Me.lblBoxTotalDaily.Text = "0"
        '
        'lblWeightTotalDaily
        '
        Me.lblWeightTotalDaily.AutoSize = True
        Me.lblWeightTotalDaily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWeightTotalDaily.Location = New System.Drawing.Point(319, 116)
        Me.lblWeightTotalDaily.Name = "lblWeightTotalDaily"
        Me.lblWeightTotalDaily.Size = New System.Drawing.Size(20, 21)
        Me.lblWeightTotalDaily.TabIndex = 21
        Me.lblWeightTotalDaily.Text = "0"
        '
        'lblProductCountShift
        '
        Me.lblProductCountShift.AutoSize = True
        Me.lblProductCountShift.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProductCountShift.Location = New System.Drawing.Point(177, 54)
        Me.lblProductCountShift.Name = "lblProductCountShift"
        Me.lblProductCountShift.Size = New System.Drawing.Size(20, 21)
        Me.lblProductCountShift.TabIndex = 25
        Me.lblProductCountShift.Text = "0"
        '
        'lblDailyTotal
        '
        Me.lblDailyTotal.AutoSize = True
        Me.lblDailyTotal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDailyTotal.Location = New System.Drawing.Point(280, 19)
        Me.lblDailyTotal.Name = "lblDailyTotal"
        Me.lblDailyTotal.Size = New System.Drawing.Size(98, 19)
        Me.lblDailyTotal.TabIndex = 37
        Me.lblDailyTotal.Text = "Daily Total"
        '
        'btnToggleLanguage
        '
        Me.btnToggleLanguage.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToggleLanguage.Location = New System.Drawing.Point(733, 542)
        Me.btnToggleLanguage.Name = "btnToggleLanguage"
        Me.btnToggleLanguage.Size = New System.Drawing.Size(108, 65)
        Me.btnToggleLanguage.TabIndex = 200
        Me.btnToggleLanguage.Text = "Español"
        Me.btnToggleLanguage.UseVisualStyleBackColor = True
        '
        'btnSetWeightPrint
        '
        Me.btnSetWeightPrint.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetWeightPrint.Location = New System.Drawing.Point(733, 703)
        Me.btnSetWeightPrint.Name = "btnSetWeightPrint"
        Me.btnSetWeightPrint.Size = New System.Drawing.Size(108, 29)
        Me.btnSetWeightPrint.TabIndex = 199
        Me.btnSetWeightPrint.Text = "Test Print"
        Me.btnSetWeightPrint.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(733, 626)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(108, 61)
        Me.btnExit.TabIndex = 198
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmScaleGrinding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 756)
        Me.Controls.Add(Me.btnToggleLanguage)
        Me.Controls.Add(Me.btnSetWeightPrint)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.grpTotalsPerProduct)
        Me.Controls.Add(Me.lblShiftDisplay)
        Me.Controls.Add(Me.lblPlant)
        Me.Controls.Add(Me.lblShift)
        Me.Controls.Add(Me.lblPlantDisplay)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.lblStationDisplay)
        Me.Controls.Add(Me.lblTimeDisplay)
        Me.Controls.Add(Me.lblDateDisplay)
        Me.Controls.Add(Me.lblDayDisplay)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.txtWarnings)
        Me.Controls.Add(Me.btnProdActive)
        Me.Controls.Add(Me.grpFavorites)
        Me.Controls.Add(Me.txtTare)
        Me.Controls.Add(Me.txtNetWeight)
        Me.Controls.Add(Me.lblGrossWeight)
        Me.Controls.Add(Me.lblNetWeight)
        Me.Controls.Add(Me.lblTare)
        Me.Controls.Add(Me.lblMin)
        Me.Controls.Add(Me.lblSetWeight)
        Me.Controls.Add(Me.lblMax)
        Me.Controls.Add(Me.txtSetWeight)
        Me.Controls.Add(Me.txtMaxWeight)
        Me.Controls.Add(Me.txtMinWeight)
        Me.Controls.Add(Me.txtGrossWeight)
        Me.Controls.Add(Me.lblBoxesInLot)
        Me.Controls.Add(Me.lblBoxesInLotDisplay)
        Me.Controls.Add(Me.lblLot)
        Me.Controls.Add(Me.lblLotDisplay)
        Me.Controls.Add(Me.btnMakeFavorite)
        Me.Controls.Add(Me.lblSerial)
        Me.Controls.Add(Me.lblSerialNumberDisplay)
        Me.Controls.Add(Me.lblProductCode)
        Me.Controls.Add(Me.lblProductDesc)
        Me.Controls.Add(Me.btnProductLookup)
        Me.Controls.Add(Me.btnChangeLot)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmScaleGrinding"
        Me.Text = "GOP Scale Program - Grinding"
        Me.grpFavorites.ResumeLayout(False)
        Me.grpTotalsPerProduct.ResumeLayout(False)
        Me.grpTotalsPerProduct.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblBoxesInLot As Label
    Friend WithEvents lblBoxesInLotDisplay As Label
    Friend WithEvents lblLot As Label
    Friend WithEvents lblLotDisplay As Label
    Friend WithEvents btnMakeFavorite As Button
    Friend WithEvents lblSerial As Label
    Friend WithEvents lblSerialNumberDisplay As Label
    Friend WithEvents lblProductCode As Label
    Friend WithEvents lblProductDesc As Label
    Friend WithEvents btnProductLookup As Button
    Friend WithEvents btnChangeLot As Button
    Friend WithEvents txtTare As TextBox
    Friend WithEvents txtNetWeight As TextBox
    Friend WithEvents lblGrossWeight As Label
    Friend WithEvents lblNetWeight As Label
    Friend WithEvents lblTare As Label
    Friend WithEvents lblMin As Label
    Friend WithEvents lblSetWeight As Label
    Friend WithEvents lblMax As Label
    Friend WithEvents txtSetWeight As TextBox
    Friend WithEvents txtMaxWeight As TextBox
    Friend WithEvents txtMinWeight As TextBox
    Friend WithEvents txtGrossWeight As TextBox
    Friend WithEvents grpFavorites As GroupBox
    Friend WithEvents btnF12Fave As Button
    Friend WithEvents btnF11Fave As Button
    Friend WithEvents btnF10Fave As Button
    Friend WithEvents btnF9Fave As Button
    Friend WithEvents btnF8Fave As Button
    Friend WithEvents btnF7Fave As Button
    Friend WithEvents btnF6Fave As Button
    Friend WithEvents btnF1Fave As Button
    Friend WithEvents btnF2Fave As Button
    Friend WithEvents btnF3Fave As Button
    Friend WithEvents btnF4Fave As Button
    Friend WithEvents btnF5Fave As Button
    Friend WithEvents btnProdActive As Button
    Friend WithEvents lblShiftDisplay As Label
    Friend WithEvents lblPlant As Label
    Friend WithEvents lblShift As Label
    Friend WithEvents lblPlantDisplay As Label
    Friend WithEvents lblStation As Label
    Friend WithEvents lblStationDisplay As Label
    Friend WithEvents lblTimeDisplay As Label
    Friend WithEvents lblDateDisplay As Label
    Friend WithEvents lblDayDisplay As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents lblDay As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents txtWarnings As TextBox
    Friend WithEvents grpTotalsPerProduct As GroupBox
    Friend WithEvents lblWeightTotal As Label
    Friend WithEvents lblBoxesPerShift As Label
    Friend WithEvents lblProductCount As Label
    Friend WithEvents lblProductCountDaily As Label
    Friend WithEvents lblWeightTotalShift As Label
    Friend WithEvents lblBoxTotalShift As Label
    Friend WithEvents lblCurrentShift As Label
    Friend WithEvents lblBoxTotalDaily As Label
    Friend WithEvents lblWeightTotalDaily As Label
    Friend WithEvents lblProductCountShift As Label
    Friend WithEvents lblDailyTotal As Label
    Friend WithEvents btnToggleLanguage As Button
    Friend WithEvents btnSetWeightPrint As Button
    Friend WithEvents btnExit As Button
End Class
