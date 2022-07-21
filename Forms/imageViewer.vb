Public Class imageViewer
    Inherits System.Windows.Forms.Form

    Public opener As Form
    Public imageToDisplay As Image

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents bigImage As System.Windows.Forms.PictureBox
    Friend WithEvents b_close As System.Windows.Forms.Button
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.bigImage = New System.Windows.Forms.PictureBox
        Me.b_close = New System.Windows.Forms.Button
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar
        Me.SuspendLayout()
        '
        'bigImage
        '
        Me.bigImage.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar
        Me.bigImage.Location = New System.Drawing.Point(0, 0)
        Me.bigImage.Name = "bigImage"
        Me.bigImage.Size = New System.Drawing.Size(568, 576)
        Me.bigImage.TabIndex = 1
        Me.bigImage.TabStop = False
        '
        'b_close
        '
        Me.b_close.Location = New System.Drawing.Point(128, 296)
        Me.b_close.Name = "b_close"
        Me.b_close.Size = New System.Drawing.Size(88, 24)
        Me.b_close.TabIndex = 5
        Me.b_close.Text = "Close Preview"
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Location = New System.Drawing.Point(0, 576)
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(568, 16)
        Me.HScrollBar1.TabIndex = 6
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Location = New System.Drawing.Point(568, 0)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(16, 576)
        Me.VScrollBar1.TabIndex = 7
        '
        'imageViewer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(354, 330)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.b_close)
        Me.Controls.Add(Me.bigImage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "imageViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "imageViewer"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub imageViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dealing with control placement
        Me.Left = 0
        Me.Top = 0
        Me.Width = Screen.GetBounds(Me).Width - 5
        Me.Height = Screen.GetBounds(Me).Height - 80
        Me.bigImage.Width = Me.Width - Me.VScrollBar1.Width
        Me.bigImage.Height = Me.Height - Me.HScrollBar1.Height
        Me.VScrollBar1.Left = Me.bigImage.Width
        Me.HScrollBar1.Top = Me.bigImage.Height
        Me.VScrollBar1.Height = Me.bigImage.Height
        Me.HScrollBar1.Width = Me.bigImage.Width
        Dim hScrollDisabled As Boolean = False
        Dim vScrollDisabled As Boolean = False

        If (Me.imageToDisplay.Width < Me.bigImage.Width) Then
            Me.bigImage.Width = Me.imageToDisplay.Width
            Me.HScrollBar1.Width = Me.bigImage.Width
            Me.VScrollBar1.Left = Me.bigImage.Width
            Me.Width = Me.bigImage.Width + Me.VScrollBar1.Width
            hScrollDisabled = True
        End If
        If (Me.imageToDisplay.Height < Me.bigImage.Height) Then
            Me.bigImage.Height = Me.imageToDisplay.Height
            Me.VScrollBar1.Height = Me.bigImage.Height
            Me.HScrollBar1.Top = Me.bigImage.Height
            Me.Height = Me.bigImage.Height + Me.HScrollBar1.Height
            vScrollDisabled = True
        End If
        bigImage.Image = Me.imageToDisplay
        Me.HScrollBar1.Minimum = 0
        Me.VScrollBar1.Minimum = 0
        If (hScrollDisabled) Then
            Me.HScrollBar1.Enabled = False
        Else
            Me.HScrollBar1.Maximum = Me.imageToDisplay.Width - Me.bigImage.Width
        End If
        If (vScrollDisabled) Then
            Me.VScrollBar1.Enabled = False
        Else
            Me.VScrollBar1.Maximum = Me.imageToDisplay.Height - Me.bigImage.Height
        End If

        Me.b_close.Top = Me.Height + 2
        Me.Height += 46
        Me.Width += 5
        Me.b_close.Left = (Me.Width - Me.b_close.Width) / 2
        Me.Left = (Screen.GetBounds(Me).Width - Me.Width) / 2
        Me.Top = (Screen.GetBounds(Me).Height - Me.Height) / 2
    End Sub

    Private Sub ScrollBar1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) _
    Handles VScrollBar1.Scroll, HScrollBar1.Scroll
        Dim g As Graphics = bigImage.CreateGraphics()
        Dim dest As Rectangle = New Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Size(bigImage.Width, bigImage.Height))
        Dim src As Rectangle = New Rectangle(New System.Drawing.Point(Me.HScrollBar1.Value, Me.VScrollBar1.Value), New System.Drawing.Size(bigImage.Width, bigImage.Height))
        g.DrawImage(Me.imageToDisplay, dest, src, GraphicsUnit.Pixel)
        bigImage.Update()
    End Sub

    Private Sub imageViewer_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        opener.Show()
    End Sub

    Private Sub bigImage_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles bigImage.MouseDown
        Me.Close()
    End Sub

    Private Sub b_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_close.Click
        Me.Close()
    End Sub
End Class
