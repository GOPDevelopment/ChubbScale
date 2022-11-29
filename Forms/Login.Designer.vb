<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblScaleDisplay = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblDayDisplay = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTimeDisplay = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDateDisplay = New System.Windows.Forms.Label()
        Me.lblPlant = New System.Windows.Forms.Label()
        Me.lblStationDisplay = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grpSupTechOptions = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblDayDescription = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdo2ndShift = New System.Windows.Forms.RadioButton()
        Me.rdo1stShift = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoUser = New System.Windows.Forms.RadioButton()
        Me.rdoSupervisor = New System.Windows.Forms.RadioButton()
        Me.rdoTech = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpSupTechOptions.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblScaleDisplay)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.lblDayDisplay)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblTimeDisplay)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblDateDisplay)
        Me.GroupBox1.Controls.Add(Me.lblPlant)
        Me.GroupBox1.Controls.Add(Me.lblStationDisplay)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 93)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(7)
        Me.GroupBox1.Size = New System.Drawing.Size(633, 217)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System Info"
        '
        'lblScaleDisplay
        '
        Me.lblScaleDisplay.AutoSize = True
        Me.lblScaleDisplay.Location = New System.Drawing.Point(129, 102)
        Me.lblScaleDisplay.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.lblScaleDisplay.Name = "lblScaleDisplay"
        Me.lblScaleDisplay.Size = New System.Drawing.Size(113, 33)
        Me.lblScaleDisplay.TabIndex = 15
        Me.lblScaleDisplay.Text = "<scale>"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(24, 158)
        Me.Label10.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 33)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Station:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(46, 102)
        Me.Label16.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 33)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Scale:"
        '
        'lblDayDisplay
        '
        Me.lblDayDisplay.AutoSize = True
        Me.lblDayDisplay.Location = New System.Drawing.Point(370, 158)
        Me.lblDayDisplay.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.lblDayDisplay.Name = "lblDayDisplay"
        Me.lblDayDisplay.Size = New System.Drawing.Size(117, 33)
        Me.lblDayDisplay.TabIndex = 8
        Me.lblDayDisplay.Text = "<day#>"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(285, 102)
        Me.Label8.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 33)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Time:"
        '
        'lblTimeDisplay
        '
        Me.lblTimeDisplay.AutoSize = True
        Me.lblTimeDisplay.Location = New System.Drawing.Point(370, 102)
        Me.lblTimeDisplay.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.lblTimeDisplay.Name = "lblTimeDisplay"
        Me.lblTimeDisplay.Size = New System.Drawing.Size(107, 33)
        Me.lblTimeDisplay.TabIndex = 6
        Me.lblTimeDisplay.Text = "<time>"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(281, 158)
        Me.Label5.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 33)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Day#:"
        '
        'lblDateDisplay
        '
        Me.lblDateDisplay.AutoSize = True
        Me.lblDateDisplay.Location = New System.Drawing.Point(370, 47)
        Me.lblDateDisplay.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.lblDateDisplay.Name = "lblDateDisplay"
        Me.lblDateDisplay.Size = New System.Drawing.Size(107, 33)
        Me.lblDateDisplay.TabIndex = 5
        Me.lblDateDisplay.Text = "<date>"
        '
        'lblPlant
        '
        Me.lblPlant.AutoSize = True
        Me.lblPlant.Location = New System.Drawing.Point(132, 47)
        Me.lblPlant.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.lblPlant.Name = "lblPlant"
        Me.lblPlant.Size = New System.Drawing.Size(114, 33)
        Me.lblPlant.TabIndex = 3
        Me.lblPlant.Text = "<plant>"
        '
        'lblStationDisplay
        '
        Me.lblStationDisplay.AutoSize = True
        Me.lblStationDisplay.Location = New System.Drawing.Point(130, 158)
        Me.lblStationDisplay.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.lblStationDisplay.Name = "lblStationDisplay"
        Me.lblStationDisplay.Size = New System.Drawing.Size(135, 33)
        Me.lblStationDisplay.TabIndex = 2
        Me.lblStationDisplay.Text = "<station>"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(289, 47)
        Me.Label2.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 33)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Date:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 47)
        Me.Label1.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Plant:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.grpSupTechOptions)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Location = New System.Drawing.Point(25, 313)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(7)
        Me.GroupBox2.Size = New System.Drawing.Size(633, 317)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Login"
        '
        'grpSupTechOptions
        '
        Me.grpSupTechOptions.Controls.Add(Me.DateTimePicker1)
        Me.grpSupTechOptions.Controls.Add(Me.Label14)
        Me.grpSupTechOptions.Controls.Add(Me.lblDayDescription)
        Me.grpSupTechOptions.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSupTechOptions.Location = New System.Drawing.Point(32, 187)
        Me.grpSupTechOptions.Name = "grpSupTechOptions"
        Me.grpSupTechOptions.Size = New System.Drawing.Size(543, 101)
        Me.grpSupTechOptions.TabIndex = 21
        Me.grpSupTechOptions.TabStop = False
        Me.grpSupTechOptions.Text = "Supervisor/Tech Options"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(153, 47)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(149, 30)
        Me.DateTimePicker1.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(30, 47)
        Me.Label14.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 23)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Change Day:"
        '
        'lblDayDescription
        '
        Me.lblDayDescription.AutoSize = True
        Me.lblDayDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDayDescription.Location = New System.Drawing.Point(327, 52)
        Me.lblDayDescription.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.lblDayDescription.Name = "lblDayDescription"
        Me.lblDayDescription.Size = New System.Drawing.Size(2, 25)
        Me.lblDayDescription.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdo2ndShift)
        Me.Panel2.Controls.Add(Me.rdo1stShift)
        Me.Panel2.Location = New System.Drawing.Point(181, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(390, 52)
        Me.Panel2.TabIndex = 19
        '
        'rdo2ndShift
        '
        Me.rdo2ndShift.AutoSize = True
        Me.rdo2ndShift.Location = New System.Drawing.Point(178, 3)
        Me.rdo2ndShift.Name = "rdo2ndShift"
        Me.rdo2ndShift.Size = New System.Drawing.Size(140, 37)
        Me.rdo2ndShift.TabIndex = 1
        Me.rdo2ndShift.TabStop = True
        Me.rdo2ndShift.Text = "2nd Shift"
        Me.rdo2ndShift.UseVisualStyleBackColor = True
        '
        'rdo1stShift
        '
        Me.rdo1stShift.AutoSize = True
        Me.rdo1stShift.Location = New System.Drawing.Point(3, 3)
        Me.rdo1stShift.Name = "rdo1stShift"
        Me.rdo1stShift.Size = New System.Drawing.Size(131, 37)
        Me.rdo1stShift.TabIndex = 0
        Me.rdo1stShift.TabStop = True
        Me.rdo1stShift.Text = "1st Shift"
        Me.rdo1stShift.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoUser)
        Me.Panel1.Controls.Add(Me.rdoSupervisor)
        Me.Panel1.Controls.Add(Me.rdoTech)
        Me.Panel1.Location = New System.Drawing.Point(182, 106)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(393, 55)
        Me.Panel1.TabIndex = 18
        '
        'rdoUser
        '
        Me.rdoUser.AutoSize = True
        Me.rdoUser.Location = New System.Drawing.Point(3, 12)
        Me.rdoUser.Name = "rdoUser"
        Me.rdoUser.Size = New System.Drawing.Size(87, 37)
        Me.rdoUser.TabIndex = 15
        Me.rdoUser.TabStop = True
        Me.rdoUser.Text = "User"
        Me.rdoUser.UseVisualStyleBackColor = True
        '
        'rdoSupervisor
        '
        Me.rdoSupervisor.AutoSize = True
        Me.rdoSupervisor.Location = New System.Drawing.Point(103, 12)
        Me.rdoSupervisor.Name = "rdoSupervisor"
        Me.rdoSupervisor.Size = New System.Drawing.Size(158, 37)
        Me.rdoSupervisor.TabIndex = 17
        Me.rdoSupervisor.TabStop = True
        Me.rdoSupervisor.Text = "Supervisor"
        Me.rdoSupervisor.UseVisualStyleBackColor = True
        '
        'rdoTech
        '
        Me.rdoTech.AutoSize = True
        Me.rdoTech.Location = New System.Drawing.Point(276, 12)
        Me.rdoTech.Name = "rdoTech"
        Me.rdoTech.Size = New System.Drawing.Size(90, 37)
        Me.rdoTech.TabIndex = 16
        Me.rdoTech.TabStop = True
        Me.rdoTech.Text = "Tech"
        Me.rdoTech.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(26, 118)
        Me.Label12.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(145, 33)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "User Type:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(92, 44)
        Me.Label11.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 33)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Shift:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(94, 656)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(201, 77)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(345, 657)
        Me.btnAccept.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(201, 77)
        Me.btnAccept.TabIndex = 3
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ChubbScale.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(108, 12)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(412, 77)
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(15.0!, 33.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 751)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.Text = "Login"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpSupTechOptions.ResumeLayout(False)
        Me.grpSupTechOptions.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents lblDayDisplay As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTimeDisplay As Label
    Friend WithEvents lblDateDisplay As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblPlant As Label
    Friend WithEvents lblStationDisplay As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lblScaleDisplay As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnAccept As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblDayDescription As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rdoUser As RadioButton
    Friend WithEvents rdoSupervisor As RadioButton
    Friend WithEvents rdoTech As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rdo2ndShift As RadioButton
    Friend WithEvents rdo1stShift As RadioButton
    Friend WithEvents grpSupTechOptions As GroupBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
