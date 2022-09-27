Imports System.IO
Imports System.Runtime.InteropServices
Imports LabelManager2

Public Class Lppx2
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Call Me.CreateLppx2Manager()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents listBoxEvents As System.Windows.Forms.ListBox
    Friend WithEvents chkEvents As System.Windows.Forms.CheckBox
    Friend WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFormFeed As System.Windows.Forms.Button
    Friend WithEvents btnPrintLabel As System.Windows.Forms.Button
    Friend WithEvents lblPrinterName As System.Windows.Forms.Label
    Friend WithEvents btnPrinter As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnPageSetup As System.Windows.Forms.Button
    Friend WithEvents txtLabelQty As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPattern As System.Windows.Forms.ComboBox
    Friend WithEvents btnRealSize As System.Windows.Forms.Button
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents lstboxLabels As System.Windows.Forms.ListBox
    Friend WithEvents pictboxDocPreview As System.Windows.Forms.PictureBox
    Friend WithEvents btnAddDir As System.Windows.Forms.Button
    Friend WithEvents cmbDirectory As System.Windows.Forms.ComboBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpdateVars As System.Windows.Forms.Button
    Friend WithEvents lblVarValue As System.Windows.Forms.TextBox
    Friend WithEvents listboxVariables As System.Windows.Forms.ListBox
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Lppx2))
        Me.groupBox4 = New System.Windows.Forms.GroupBox
        Me.listBoxEvents = New System.Windows.Forms.ListBox
        Me.chkEvents = New System.Windows.Forms.CheckBox
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.btnFormFeed = New System.Windows.Forms.Button
        Me.btnPrintLabel = New System.Windows.Forms.Button
        Me.lblPrinterName = New System.Windows.Forms.Label
        Me.btnPrinter = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnPageSetup = New System.Windows.Forms.Button
        Me.txtLabelQty = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbPattern = New System.Windows.Forms.ComboBox
        Me.btnRealSize = New System.Windows.Forms.Button
        Me.lblLoading = New System.Windows.Forms.Label
        Me.lstboxLabels = New System.Windows.Forms.ListBox
        Me.pictboxDocPreview = New System.Windows.Forms.PictureBox
        Me.btnAddDir = New System.Windows.Forms.Button
        Me.cmbDirectory = New System.Windows.Forms.ComboBox
        Me.label1 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.btnUpdateVars = New System.Windows.Forms.Button
        Me.listboxVariables = New System.Windows.Forms.ListBox
        Me.lblVarValue = New System.Windows.Forms.TextBox
        Me.groupBox4.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.pictboxDocPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.listBoxEvents)
        Me.groupBox4.Controls.Add(Me.chkEvents)
        Me.groupBox4.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.groupBox4.Location = New System.Drawing.Point(13, 448)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(465, 120)
        Me.groupBox4.TabIndex = 23
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Events"
        '
        'listBoxEvents
        '
        Me.listBoxEvents.BackColor = System.Drawing.Color.GhostWhite
        Me.listBoxEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listBoxEvents.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.listBoxEvents.Location = New System.Drawing.Point(6, 45)
        Me.listBoxEvents.Name = "listBoxEvents"
        Me.listBoxEvents.Size = New System.Drawing.Size(453, 67)
        Me.listBoxEvents.TabIndex = 20
        '
        'chkEvents
        '
        Me.chkEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkEvents.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.chkEvents.Location = New System.Drawing.Point(8, 16)
        Me.chkEvents.Name = "chkEvents"
        Me.chkEvents.Size = New System.Drawing.Size(168, 24)
        Me.chkEvents.TabIndex = 19
        Me.chkEvents.Text = "Catch events"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.btnFormFeed)
        Me.groupBox3.Controls.Add(Me.btnPrintLabel)
        Me.groupBox3.Controls.Add(Me.lblPrinterName)
        Me.groupBox3.Controls.Add(Me.btnPrinter)
        Me.groupBox3.Controls.Add(Me.btnPrint)
        Me.groupBox3.Controls.Add(Me.btnPageSetup)
        Me.groupBox3.Controls.Add(Me.txtLabelQty)
        Me.groupBox3.Controls.Add(Me.label2)
        Me.groupBox3.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.groupBox3.Location = New System.Drawing.Point(262, 274)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(216, 158)
        Me.groupBox3.TabIndex = 22
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Printing settings"
        '
        'btnFormFeed
        '
        Me.btnFormFeed.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnFormFeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFormFeed.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.btnFormFeed.Location = New System.Drawing.Point(111, 67)
        Me.btnFormFeed.Name = "btnFormFeed"
        Me.btnFormFeed.Size = New System.Drawing.Size(99, 24)
        Me.btnFormFeed.TabIndex = 14
        Me.btnFormFeed.Text = "Form Feed"
        Me.btnFormFeed.UseVisualStyleBackColor = False
        '
        'btnPrintLabel
        '
        Me.btnPrintLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnPrintLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintLabel.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.btnPrintLabel.Location = New System.Drawing.Point(6, 67)
        Me.btnPrintLabel.Name = "btnPrintLabel"
        Me.btnPrintLabel.Size = New System.Drawing.Size(96, 24)
        Me.btnPrintLabel.TabIndex = 13
        Me.btnPrintLabel.Text = "Print Label"
        Me.btnPrintLabel.UseVisualStyleBackColor = False
        '
        'lblPrinterName
        '
        Me.lblPrinterName.ForeColor = System.Drawing.Color.Black
        Me.lblPrinterName.Location = New System.Drawing.Point(352, 56)
        Me.lblPrinterName.Name = "lblPrinterName"
        Me.lblPrinterName.Size = New System.Drawing.Size(264, 16)
        Me.lblPrinterName.TabIndex = 12
        '
        'btnPrinter
        '
        Me.btnPrinter.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrinter.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.btnPrinter.Location = New System.Drawing.Point(111, 115)
        Me.btnPrinter.Name = "btnPrinter"
        Me.btnPrinter.Size = New System.Drawing.Size(99, 24)
        Me.btnPrinter.TabIndex = 11
        Me.btnPrinter.Text = "Select Printer"
        Me.btnPrinter.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.btnPrint.Location = New System.Drawing.Point(111, 24)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(99, 24)
        Me.btnPrint.TabIndex = 10
        Me.btnPrint.Text = "Print Document"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnPageSetup
        '
        Me.btnPageSetup.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnPageSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPageSetup.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.btnPageSetup.Location = New System.Drawing.Point(6, 115)
        Me.btnPageSetup.Name = "btnPageSetup"
        Me.btnPageSetup.Size = New System.Drawing.Size(96, 24)
        Me.btnPageSetup.TabIndex = 9
        Me.btnPageSetup.Text = "Page setup"
        Me.btnPageSetup.UseVisualStyleBackColor = False
        '
        'txtLabelQty
        '
        Me.txtLabelQty.BackColor = System.Drawing.Color.GhostWhite
        Me.txtLabelQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLabelQty.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.txtLabelQty.Location = New System.Drawing.Point(70, 24)
        Me.txtLabelQty.Name = "txtLabelQty"
        Me.txtLabelQty.Size = New System.Drawing.Size(32, 20)
        Me.txtLabelQty.TabIndex = 8
        Me.txtLabelQty.Text = "1"
        '
        'label2
        '
        Me.label2.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.label2.Location = New System.Drawing.Point(11, 29)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(56, 15)
        Me.label2.TabIndex = 7
        Me.label2.Text = "Label qty :"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.Label5)
        Me.groupBox1.Controls.Add(Me.cmbPattern)
        Me.groupBox1.Controls.Add(Me.btnRealSize)
        Me.groupBox1.Controls.Add(Me.lblLoading)
        Me.groupBox1.Controls.Add(Me.lstboxLabels)
        Me.groupBox1.Controls.Add(Me.pictboxDocPreview)
        Me.groupBox1.Controls.Add(Me.btnAddDir)
        Me.groupBox1.Controls.Add(Me.cmbDirectory)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.groupBox1.Location = New System.Drawing.Point(12, 5)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(466, 256)
        Me.groupBox1.TabIndex = 20
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "File preview"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Extension"
        '
        'cmbPattern
        '
        Me.cmbPattern.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbPattern.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPattern.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.cmbPattern.Items.AddRange(New Object() {"*.lab", "*.*"})
        Me.cmbPattern.Location = New System.Drawing.Point(112, 49)
        Me.cmbPattern.Name = "cmbPattern"
        Me.cmbPattern.Size = New System.Drawing.Size(247, 21)
        Me.cmbPattern.TabIndex = 12
        '
        'btnRealSize
        '
        Me.btnRealSize.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnRealSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRealSize.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.btnRealSize.Location = New System.Drawing.Point(231, 222)
        Me.btnRealSize.Name = "btnRealSize"
        Me.btnRealSize.Size = New System.Drawing.Size(229, 21)
        Me.btnRealSize.TabIndex = 10
        Me.btnRealSize.Text = "Real Size"
        Me.btnRealSize.UseVisualStyleBackColor = False
        Me.btnRealSize.Visible = False
        '
        'lblLoading
        '
        Me.lblLoading.Location = New System.Drawing.Point(275, 95)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(141, 110)
        Me.lblLoading.TabIndex = 8
        Me.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLoading.Visible = False
        '
        'lstboxLabels
        '
        Me.lstboxLabels.BackColor = System.Drawing.Color.GhostWhite
        Me.lstboxLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstboxLabels.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lstboxLabels.Location = New System.Drawing.Point(9, 84)
        Me.lstboxLabels.Name = "lstboxLabels"
        Me.lstboxLabels.Size = New System.Drawing.Size(216, 158)
        Me.lstboxLabels.Sorted = True
        Me.lstboxLabels.TabIndex = 11
        '
        'pictboxDocPreview
        '
        Me.pictboxDocPreview.Location = New System.Drawing.Point(231, 84)
        Me.pictboxDocPreview.Name = "pictboxDocPreview"
        Me.pictboxDocPreview.Size = New System.Drawing.Size(229, 132)
        Me.pictboxDocPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pictboxDocPreview.TabIndex = 5
        Me.pictboxDocPreview.TabStop = False
        '
        'btnAddDir
        '
        Me.btnAddDir.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnAddDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddDir.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.btnAddDir.Location = New System.Drawing.Point(365, 19)
        Me.btnAddDir.Name = "btnAddDir"
        Me.btnAddDir.Size = New System.Drawing.Size(95, 24)
        Me.btnAddDir.TabIndex = 9
        Me.btnAddDir.Text = "Add Folder"
        Me.btnAddDir.UseVisualStyleBackColor = False
        '
        'cmbDirectory
        '
        Me.cmbDirectory.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbDirectory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDirectory.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.cmbDirectory.Location = New System.Drawing.Point(112, 22)
        Me.cmbDirectory.Name = "cmbDirectory"
        Me.cmbDirectory.Size = New System.Drawing.Size(247, 21)
        Me.cmbDirectory.Sorted = True
        Me.cmbDirectory.TabIndex = 7
        '
        'label1
        '
        Me.label1.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.label1.Location = New System.Drawing.Point(6, 22)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(82, 19)
        Me.label1.TabIndex = 6
        Me.label1.Text = "Labels Folder"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.groupBox2)
        Me.GroupBox5.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.GroupBox5.Location = New System.Drawing.Point(13, 274)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(243, 158)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Variables settings"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.btnUpdateVars)
        Me.groupBox2.Controls.Add(Me.listboxVariables)
        Me.groupBox2.Controls.Add(Me.lblVarValue)
        Me.groupBox2.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.groupBox2.Location = New System.Drawing.Point(0, 0)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(233, 158)
        Me.groupBox2.TabIndex = 21
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Variables settings"
        '
        'btnUpdateVars
        '
        Me.btnUpdateVars.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnUpdateVars.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateVars.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.btnUpdateVars.Location = New System.Drawing.Point(155, 114)
        Me.btnUpdateVars.Name = "btnUpdateVars"
        Me.btnUpdateVars.Size = New System.Drawing.Size(69, 24)
        Me.btnUpdateVars.TabIndex = 19
        Me.btnUpdateVars.Text = "Update"
        Me.btnUpdateVars.UseVisualStyleBackColor = False
        '
        'listboxVariables
        '
        Me.listboxVariables.BackColor = System.Drawing.Color.GhostWhite
        Me.listboxVariables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listboxVariables.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.listboxVariables.Location = New System.Drawing.Point(8, 19)
        Me.listboxVariables.Name = "listboxVariables"
        Me.listboxVariables.Size = New System.Drawing.Size(216, 80)
        Me.listboxVariables.TabIndex = 16
        '
        'lblVarValue
        '
        Me.lblVarValue.BackColor = System.Drawing.Color.GhostWhite
        Me.lblVarValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVarValue.Location = New System.Drawing.Point(8, 118)
        Me.lblVarValue.Name = "lblVarValue"
        Me.lblVarValue.Size = New System.Drawing.Size(144, 20)
        Me.lblVarValue.TabIndex = 18
        '
        'Lppx2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(481, 575)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Lppx2"
        Me.Text = "VB.NET_Lppx2.Application"
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.pictboxDocPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private and public Members"

    'Private noDocOpened As Boolean = True
    Private m_Lppx2Manager As Lppx2Manager = Nothing
    Private WithEvents MyCsApp As LabelManager2.Application = Nothing

    ' Need to have a WithEvents object to manage events at the ActiveDocument level
    Private WithEvents MyActiveDocument As LabelManager2.Document = Nothing
    Private _IsPrinting As Boolean = False

    Private picDefW As System.Int32
    Private picDefH As System.Int32
    Private currentImage As Drawing.Image

    Private myCallback As Drawing.Image.GetThumbnailImageAbort

    Dim varTab As String()() = New String(2)() {}

    Public realSizeImage As Drawing.Image

    Private csPath As System.String

    'Used by Invoke call to update the UI from the Events thread
    'Necessary to avoid an inter-thread invalid operation exception
    Private Delegate Sub UpdateMessagesListEvent(ByVal strMessage As String)
    Private _UpdateMessagesList As UpdateMessagesListEvent

    'Need to use BeginInvoke instead of Invoke for Printing events
    'or the Printing thread is blocked by Invoke (synchronous call)
    Private _BeginPrintingEventRes As IAsyncResult
    Private _PausedPrintingEventRes As IAsyncResult
    Private _EndPrintingEventRes As IAsyncResult

#End Region

#Region "Initialization"
    Private Sub CreateLppx2Manager()
        'Create an instance of Lppx2Manager
        m_Lppx2Manager = New Lppx2Manager
        MyCsApp = DirectCast(m_Lppx2Manager.GetApplication(), LabelManager2.Application)
        lblLoading.Text = "Please Wait. " & vbCr & "Loading in progress... "
        MyCsApp.PreloadUI

        _UpdateMessagesList = New UpdateMessagesListEvent(AddressOf UpdateMessagesList)
        chkEvents.CheckState = CheckState.Unchecked

    End Sub
#End Region

#Region "Update Files List"
    Private Sub getFileList()
        lstboxLabels.Items.Clear()
        If ((cmbDirectory.Text <> "") And (cmbPattern.Text <> "")) Then
            Dim fileList As String() = Directory.GetFiles(cmbDirectory.Text, cmbPattern.Text)
            For Each currentFile As String In fileList
                lstboxLabels.Items.Add(currentFile.Substring(currentFile.LastIndexOf("\") + 1))
            Next
        End If
    End Sub

#End Region

#Region "Image"
    Private Sub resizeIfNeeded()
        ' If image width is greater than the pictureBox width 
        ' OR
        ' image height is greater than the pictureBox height
        ' then it must be resized...
        If Not (currentImage Is Nothing) Then
            If ((currentImage.Width > picDefW) Or (currentImage.Height > picDefH)) Then
                'which one (width or height) must be used to resize ?
                If ((currentImage.Width / picDefW) > (currentImage.Height / picDefH)) Then
                    'Must use width to resize
                    Dim a As Double = (Convert.ToDouble(picDefW)) / (Convert.ToDouble(currentImage.Width))
                    currentImage = currentImage.GetThumbnailImage(picDefW, Convert.ToInt32(Convert.ToDouble(currentImage.Height) * a), myCallback, IntPtr.Zero)
                Else
                    ' Must use Height to resize
                    Dim a As Double = (Convert.ToDouble(picDefH)) / (Convert.ToDouble(currentImage.Height))
                    currentImage = currentImage.GetThumbnailImage(Convert.ToInt32(Convert.ToDouble(currentImage.Width) * a), picDefH, myCallback, IntPtr.Zero)

                    '	currentImage = currentImage.GetThumbnailImage((int)(currentImage.Width/(currentImage.Height / picDefH)),picDefH, myCallback, IntPtr.Zero);
                End If
            End If
        End If
    End Sub

    Private Sub refreshDoc()
        If Not (MyActiveDocument Is Nothing) Then

            Me.Text = MyCsApp.ActivePrinterName

            pictboxDocPreview.Visible = False
            lblLoading.Visible = True
            DisposeImages()

            Try

                'this method use Clipboard
                'MyCsApp.ActiveDocument.CopyToClipboardEx(False, 0, 256, 0, 100)
                'currentImage = DirectCast(Clipboard.GetDataObject().GetData(System.Windows.Forms.DataFormats.Bitmap, True), Image)


                'This method use a stream instead of writing to clipboard or file.
                Dim obj As Object
                obj = MyActiveDocument.GetPreview(True, True, 100)
                If Not (obj Is Nothing) Then
                    Dim data() As Byte
                    data = obj

                    Dim pStream As System.IO.MemoryStream

                    pStream = New System.IO.MemoryStream(data)
                    currentImage = New Bitmap(pStream)
                End If

                realSizeImage = currentImage
                resizeIfNeeded()
                pictboxDocPreview.Image = currentImage

            Catch ex As Exception
                'placholder
            End Try

            pictboxDocPreview.Visible = True
            lblLoading.Visible = False
            Refresh()
            fillVarTab()
            fillListBox()

            If (listboxVariables.Items.Count > 0) Then
                listboxVariables.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub DisposeImages()

        If Not (realSizeImage Is Nothing) Then
            realSizeImage.Dispose()
        End If

        If Not (currentImage Is Nothing) Then
            currentImage.Dispose()
        End If

        If Not (pictboxDocPreview.Image Is Nothing) Then
            pictboxDocPreview.Image.Dispose()
        End If

    End Sub



    Public Function ThumbnailCallback() As Boolean
        ThumbnailCallback = False
    End Function

#End Region

#Region "Label Variables Management"
    'Fill varTab with variable name and value
    Private Sub fillVarTab()
        Dim sLabelStuff As String = ""
        listboxVariables.Items.Clear()
        Dim variables As Variables = MyActiveDocument.Variables
        varTab(0) = New String(variables.Count) {}
        varTab(1) = New String(variables.Count) {}
        For i As Integer = 1 To variables.Count
            Dim item As Variable = MyActiveDocument.Variables.Item(i)
            varTab(0)(i - 1) = (item.Name)
            varTab(1)(i - 1) = (item.Value)

            sLabelStuff = sLabelStuff & item.Name & "," & item.Value & vbCrLf

            Marshal.ReleaseComObject(item)
        Next i

        WriteToLog("LabelVariables", sLabelStuff, "", "Chub")

        Marshal.ReleaseComObject(variables)
    End Sub

    'Inject variables Name in the listBox
    Private Sub fillListBox()

        listboxVariables.Items.Clear()
        For i As Integer = 0 To varTab(0).Length - 2
            listboxVariables.Items.Add(varTab(0)(i))
        Next i
    End Sub

    Private Sub updateVarInLabFile()
        Dim variables As Variables = MyActiveDocument.Variables

        For i As Integer = 0 To varTab(0).Length - 2
            Dim item As Variable = variables.Item(i + 1)
            item.Name = varTab(0)(i)
            item.Value = varTab(1)(i)
            Marshal.ReleaseComObject(item)
        Next i

        Marshal.ReleaseComObject(variables)
        Call Me.refreshDoc()
    End Sub
#End Region

#Region "Windows Form Events handlers"
    Private Sub OnFormLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Reading codeSoft directory from register
        csPath = MyCsApp.DefaultFilePath
        cmbDirectory.Items.Add(csPath)
        cmbDirectory.Items.Add("C:\Code\ChubScale\ChubScale\Labels")

        'Displaying variables list for the current Doc
        cmbPattern.SelectedIndex = 0
        cmbDirectory.SelectedIndex = 0
        picDefW = pictboxDocPreview.Width
        picDefH = pictboxDocPreview.Height
        myCallback = New Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)

        Me.Text = MyCsApp.ActivePrinterName
    End Sub

    Private Sub OnFormExit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Remove Events Handlers
        chkEvents.CheckState = CheckState.Unchecked
        DisposeImages()

        If MyActiveDocument IsNot Nothing Then
            Try
                MyActiveDocument.Close(False)
            Catch ex As Exception
            End Try

            Marshal.ReleaseComObject(MyActiveDocument)
        End If

        m_Lppx2Manager.QuitLppx2()
    End Sub
#End Region

#Region "Labels management"
    Private Sub OnSelectFolder(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cmbDirectory.SelectedIndexChanged
        Call Me.getFileList()
    End Sub

    Private Sub OnAddFolder(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnAddDir.Click
        Dim FBD As FolderBrowserDialog = New FolderBrowserDialog
        FBD.SelectedPath = csPath

        If (FBD.ShowDialog() = DialogResult.OK) Then
            Dim dirName As String = FBD.SelectedPath
            cmbDirectory.SelectedIndex = cmbDirectory.Items.Add(dirName)
        End If

    End Sub

    Private Sub OnSelectExtension(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cmbPattern.SelectedIndexChanged
        Call Me.getFileList()
    End Sub

    Private Sub OnDisplayRealSize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRealSize.Click

        Dim imViewForm As imageViewer = New imageViewer
        imViewForm.TopMost = True
        imViewForm.imageToDisplay = realSizeImage

        Me.Hide()

        imViewForm.opener = Me
        imViewForm.Show()

    End Sub
#End Region

#Region "Open selected label file"
    Private Sub OnSelectLabel(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstboxLabels.SelectedIndexChanged

        ' Modifying UI mode
        Me.btnRealSize.Visible = True
        pictboxDocPreview.Visible = False
        lblLoading.Visible = True

        Form.ActiveForm.Refresh()

        If (Not (MyCsApp Is Nothing) And (lstboxLabels.Text.Length > 0)) Then

            Try

                Me.lblLoading.Visible = True

                If (Not (MyActiveDocument Is Nothing)) Then
                    MyActiveDocument.Close(False)
                    Marshal.ReleaseComObject(MyActiveDocument)
                    MyActiveDocument = Nothing
                End If

                Dim csDocuments As Documents = MyCsApp.Documents
                MyActiveDocument = csDocuments.Open(cmbDirectory.Text + "\" + lstboxLabels.Text, False)
                Marshal.ReleaseComObject(csDocuments)

            Catch ex As Exception
                MessageBox.Show("OnSelectLabel: " + ex.Message)
                If MyActiveDocument IsNot Nothing Then
                    Marshal.ReleaseComObject(MyActiveDocument)
                    MyActiveDocument = Nothing
                End If
            End Try

            Me.lblLoading.Visible = False

        End If

        Call Me.refreshDoc()

    End Sub
#End Region

#Region "Variables management"
    Private Sub OnUpdateVariable(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateVars.Click

        varTab(1)(listboxVariables.SelectedIndex) = lblVarValue.Text
        updateVarInLabFile()
    End Sub

    Private Sub OnSelectVariable(ByVal sender As Object, ByVal e As System.EventArgs) Handles listboxVariables.SelectedIndexChanged

        lblVarValue.Text = varTab(1)(listboxVariables.SelectedIndex)
    End Sub
#End Region

#Region "Page Setup Dialog Box"
    Private Sub OnPageSetup(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPageSetup.Click
        If (MyActiveDocument Is Nothing) Then
            MessageBox.Show("A document must be opened to perform this action...")
        Else
            Dim csDialogs As Dialogs = MyCsApp.Dialogs
            Dim csDialog As Dialog = csDialogs.Item(LabelManager2.enumDialogType.lppxPageSetupDialog)
            csDialog.Show(Me.Handle)
            Marshal.ReleaseComObject(csDialog)
            Marshal.ReleaseComObject(csDialogs)
        End If
    End Sub
#End Region

#Region "Printers management"
    Private Sub OnSelectPrinter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrinter.Click
        Dim csDialogs As Dialogs = MyCsApp.Dialogs
        Dim csDialog As Dialog = csDialogs.Item(LabelManager2.enumDialogType.lppxPrinterSelectDialog)
        csDialog.Show(Me.Handle)
        Me.Text = MyCsApp.ActivePrinterName
        Marshal.ReleaseComObject(csDialogs)
        Marshal.ReleaseComObject(csDialog)
    End Sub
#End Region

#Region "Printing management"
    Private Sub OnPrintDocument(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        If (MyActiveDocument Is Nothing) Then
            MessageBox.Show("A document must be opened to print !")
            Exit Sub
        End If

        Try

            AddPrintingHandlers()

            MyActiveDocument.PrintDocument(Integer.Parse(txtLabelQty.Text))

            If Not (_BeginPrintingEventRes Is Nothing) Then
                listBoxEvents.EndInvoke(_BeginPrintingEventRes)
                _BeginPrintingEventRes = Nothing
            End If

            If Not (_EndPrintingEventRes Is Nothing) Then
                listBoxEvents.EndInvoke(_EndPrintingEventRes)
                _EndPrintingEventRes = Nothing
            End If

            RemovePrintingHandlers()

        Catch aError As System.FormatException
            MessageBox.Show("Label qty must be an integer...\n\n\n" + aError.Message)
        End Try
    End Sub

    Private Sub OnPrintLabel(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintLabel.Click

        If (MyActiveDocument Is Nothing) Then
            MessageBox.Show("A document must be opened to print !")
            Exit Sub
        End If

        Try

            _IsPrinting = True
            MyActiveDocument.PrintLabel(Integer.Parse(txtLabelQty.Text), 1, 1, 1, 1, "")

        Catch aError As System.FormatException
            MessageBox.Show("Label qty must be an integer..." & vbCr & aError.Message)
        End Try

    End Sub

    Private Sub OnFormFeed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormFeed.Click
        If (MyActiveDocument Is Nothing) Then
            MessageBox.Show("A document must be opened to print !")
            Exit Sub
        End If

        MyActiveDocument.FormFeed()
        _IsPrinting = False
    End Sub
#End Region

#Region "Events management"
    Private Sub OnCheckEvents(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEvents.CheckedChanged

        If (chkEvents.CheckState = CheckState.Checked) Then

            MyCsApp.EnableEvents = True

            AddHandler MyCsApp.DocumentClosed, AddressOf CsApp_DocumentClosed

        End If

        If (chkEvents.CheckState = CheckState.Unchecked) Then

            MyCsApp.EnableEvents = False

            RemoveHandler MyCsApp.DocumentClosed, AddressOf CsApp_DocumentClosed

        End If

    End Sub

    Private Sub listBoxEvents_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listBoxEvents.DoubleClick
        listBoxEvents.Items.Clear()
    End Sub

    Private Sub AddPrintingHandlers()

        If Not MyActiveDocument Is Nothing Then
            If (chkEvents.CheckState = CheckState.Checked) Then
                AddHandler MyActiveDocument.BeginPrinting, AddressOf ActiveDocument_BeginPrinting
                AddHandler MyActiveDocument.PausedPrinting, AddressOf ActiveDocument_PausedPrinting
                AddHandler MyActiveDocument.EndPrinting, AddressOf ActiveDocument_EndPrinting
            End If
        End If
    End Sub

    Private Sub RemovePrintingHandlers()

        If Not MyActiveDocument Is Nothing Then
            If (chkEvents.CheckState = CheckState.Checked) Then
                RemoveHandler MyActiveDocument.BeginPrinting, AddressOf ActiveDocument_BeginPrinting
                RemoveHandler MyActiveDocument.PausedPrinting, AddressOf ActiveDocument_PausedPrinting
                RemoveHandler MyActiveDocument.EndPrinting, AddressOf ActiveDocument_EndPrinting
            End If
        End If

    End Sub

    Private Sub CsApp_DocumentClosed(ByVal strDocTitle As String)

        Dim Message As String = "The label """ + strDocTitle + """ has been closed"

        Try
            Me.Invoke(_UpdateMessagesList, New Object() {Message})
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ActiveDocument_BeginPrinting(ByVal strDocName As String) ' Handles MyActiveDocument.BeginPrinting
        Dim Message As String = "The label """ + strDocName + """ begins to print"
        Try
            _BeginPrintingEventRes = listBoxEvents.BeginInvoke(_UpdateMessagesList, New Object() {Message})
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ActiveDocument_PausedPrinting(ByVal Reason As LabelManager2.enumPausedReasonPrinting, ByRef Cancel As Short) ' Handles MyActiveDocument.BeginPrinting
        Dim Message As String = "Printing has been paused for the following reason: " + Reason.ToString() + "."
        Try
            If MsgBox(Message, MsgBoxStyle.Critical + MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                Message = "Printing has been cancelled for the following reason: " + Reason.ToString() + "."
                _PausedPrintingEventRes = listBoxEvents.BeginInvoke(_UpdateMessagesList, New Object() {Message})
                Cancel = -1
            Else
                Cancel = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ActiveDocument_EndPrinting(ByVal Reason As LabelManager2.enumEndPrinting) ' Handles MyActiveDocument.EndPrinting
        Dim Message As String = "The label """ + MyActiveDocument.Name + """ has finished printing"

        Select Case Reason
            Case LabelManager2.enumEndPrinting.lppxEndOfJob
                Message += " successfully"
            Case LabelManager2.enumEndPrinting.lppxCancelled
                Message += " due to cancellation"
            Case LabelManager2.enumEndPrinting.lppxSystemFailure
                Message += " with system failure"
        End Select

        Try
            _EndPrintingEventRes = listBoxEvents.BeginInvoke(_UpdateMessagesList, New Object() {Message})
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ' UI Update
    Private Sub UpdateMessagesList(ByVal strMessage As String)

        Try

            listBoxEvents.Items.Add(strMessage)

        Catch e As System.Exception
            System.Diagnostics.Debug.Assert(False, e.Message)
        End Try

    End Sub
#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
