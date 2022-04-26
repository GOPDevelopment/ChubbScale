Imports System.IO
Imports System.IO.Ports

Public Class ScalePortInfo

    Public WithEvents ScalePort As New SerialPort
    Public EntireScaleMessage As String = ""
    Public ScaleWeightEndText As String = "lb GROSS"
    Public Property CurrentScaleRead As String = "0"

    Public Sub New()
        ScalePort = InitializePortOpening()
    End Sub


    Private Function InitializePortOpening() As SerialPort

        '    <add key="ScalePort" value="COM1"/>

        If Not ScalePort.IsOpen Then
            Try

                With ScalePort
                    .BaudRate = 9600
                    .StopBits = 1
                    .Parity = Parity.None
                    .DataBits = 8
                    .PortName = System.Configuration.ConfigurationManager.AppSettings("ScalePort")
                    .Open()
                End With

            Catch ex As Exception
                WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                'MsgBox("Unable to open the data port for the Scale.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Can't open " & System.Configuration.ConfigurationManager.AppSettings("ScalePort"))
            End Try
        End If

        Return ScalePort

    End Function

    'Public Sub ScalePort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles ScalePort.DataReceived
    '    'this is triggered by user hitting PRINT on the scale

    '    Dim scaleMessage As String = ScalePort.ReadExisting()

    '    ' Message may come in pieces... append to master message until we get the final lb NET message
    '    EntireScaleMessage &= scaleMessage

    '    If EntireScaleMessage.Contains(ScaleWeightEndText) Then
    '        ' Find the line that says "xxxx lb NET" and extract the weight
    '        For Each ThisLine As String In EntireScaleMessage.Split(vbCr)
    '            If ThisLine.EndsWith(ScaleWeightEndText) Then
    '                Try
    '                    Dim NetWeight As Single = CSng(ThisLine.Replace(ScaleWeightEndText, "").Replace(" ", ""))
    '                    'BuildFileAndPrint(NetWeight)
    '                Catch ex As Exception
    '                    MsgBox("Exception: " & ex.Message)
    '                End Try
    '            End If
    '        Next

    '        ' Reset for next message.
    '        EntireScaleMessage = ""
    '    End If

    '    'strip just weight to show in txt box
    '    CurrentScaleRead = CStr(scaleMessage.Replace(" ", "").Replace(vbCrLf, "").Replace(vbCr, ""))

    'End Sub

    'Public Sub ScalePort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs)
    '    'this is triggered by user hitting PRINT on the scale

    '    Dim scaleMessage As String = ScalePort.ReadExisting()

    '    ' Message may come in pieces... append to master message until we get the final lb NET message
    '    EntireScaleMessage &= scaleMessage

    '    If EntireScaleMessage.Contains(ScaleWeightEndText) Then
    '        ' Find the line that says "xxxx lb NET" and extract the weight
    '        For Each ThisLine As String In EntireScaleMessage.Split(vbCr)
    '            If ThisLine.EndsWith(ScaleWeightEndText) Then
    '                Try
    '                    Dim NetWeight As Single = CSng(ThisLine.Replace(ScaleWeightEndText, "").Replace(" ", ""))
    '                    'BuildFileAndPrint(NetWeight)
    '                Catch ex As Exception
    '                    MsgBox("Exception: " & ex.Message)
    '                End Try
    '            End If
    '        Next

    '        ' Reset for next message.
    '        EntireScaleMessage = ""
    '    End If

    '    'strip just weight to show in txt box
    '    CurrentScaleRead = CStr(scaleMessage.Replace(" ", "").Replace(vbCrLf, "").Replace(vbCr, ""))

    'End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub





    'Private Sub InitializePortOpening(scale As String)


    '    'trim line
    '    '    <add key="PrintTemplateLocation" value="\\192.168.20.106\Prod data\Trim Line\scale8a.prn"/>

    '    If Not ScalePort.IsOpen Then
    '        Try
    '            '    <add key="ScalePort" value="COM1"/>

    '            With ScalePort
    '                .BaudRate = 9600
    '                .StopBits = 1
    '                .Parity = Parity.None
    '                .DataBits = 8
    '                .PortName = System.Configuration.ConfigurationManager.AppSettings("ScalePort")
    '                .Open()
    '            End With

    '        Catch ex As Exception
    '            MsgBox("Unable to open the data port for the Scale.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Can't open " & System.Configuration.ConfigurationManager.AppSettings("ScalePort"))

    '        End Try
    '    End If




    '    'offal
    '    '    <add key="PrintTemplateLocation" value="\\192.168.20.106\Prod data\Offal\offall-a.prn"/>

    '    If Not ScalePort.IsOpen Then
    '        Try
    '            '    <add key="ScalePort" value="COM1"/>

    '            With ScalePort
    '                .BaudRate = 9600
    '                .StopBits = 1
    '                .Parity = Parity.None
    '                .DataBits = 8
    '                .PortName = System.Configuration.ConfigurationManager.AppSettings("ScalePort")
    '                .Open()
    '            End With

    '        Catch ex As Exception
    '            MsgBox("Unable to open the data port for the Scale.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Can't open " & System.Configuration.ConfigurationManager.AppSettings("ScalePort"))

    '        End Try
    '    End If


    '    'tongues
    '    '    <add key="PrintTemplateLocation" value="\\192.168.20.106\Prod data\Tongues\scale8a.prn"/>

    '    If Not ScalePort.IsOpen Then
    '        Try
    '            '    <add key="ScalePort" value="COM1"/>

    '            With ScalePort
    '                .BaudRate = 9600
    '                .StopBits = 1
    '                .Parity = Parity.None
    '                .DataBits = 8
    '                .PortName = System.Configuration.ConfigurationManager.AppSettings("ScalePort")
    '                .Open()
    '            End With

    '        Catch ex As Exception
    '            MsgBox("Unable to open the data port for the Scale.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Can't open " & System.Configuration.ConfigurationManager.AppSettings("ScalePort"))

    '        End Try
    '    End If

    '    'combo
    '    '<add key = "PrintTemplateLocation" value="C:\Users\Tom Kelley\Desktop\Source Code Steak scale\Combo\GOWeighAndPrint\combo1.prn"/>

    '    If Not ScalePort.IsOpen Then
    '        Try
    '            '    <add key="ScalePort" value="COM8"/>

    '            With ScalePort
    '                .BaudRate = 9600
    '                .StopBits = 1
    '                .Parity = Parity.None
    '                .DataBits = 8
    '                .PortName = System.Configuration.ConfigurationManager.AppSettings("ScalePort")
    '                .Open()
    '            End With

    '        Catch ex As Exception
    '            MsgBox("Unable to open the data port for the Scale.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Can't open " & System.Configuration.ConfigurationManager.AppSettings("ScalePort"))

    '        End Try
    '    End If


    '    'steak
    '    '    <add key="PrintTemplateLocation" value="C:\Users\Tom Kelley\Desktop\Source Code Steak scale\Current -6 digit\GOWeighAndPrint\scale8a.prn"/>

    '    If Not ScalePort.IsOpen Then
    '        Try
    '            '    <add key="ScalePort" value="COM1"/>

    '            With ScalePort
    '                .BaudRate = 9600
    '                .StopBits = 1
    '                .Parity = Parity.None
    '                .DataBits = 8
    '                .PortName = System.Configuration.ConfigurationManager.AppSettings("ScalePort")
    '                .Open()
    '            End With

    '        Catch ex As Exception
    '            MsgBox("Unable to open the data port for the Scale.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Can't open " & System.Configuration.ConfigurationManager.AppSettings("ScalePort"))

    '        End Try
    '    End If



    '    'chubb/grinding/patty 12
    '    '<add key = "PrintTemplateLocation" value="\\192.168.20.106\Prod data\PATTYLINE\scale8a.prn"/>
    '    '<add key = "PrintTemplateLocation2" value="\\192.168.20.106\Prod data\PATTYLINE\scale8a18m.prn"/>
    '    '<add key = "PrintTemplateLocation3" value="\\192.168.20.106\Prod data\PATTYLINE\scale8a12m.prn"/>

    '    If Not ScalePort.IsOpen Then
    '        Try
    '            '    <add key="ScalePort" value="COM1"/>

    '            With ScalePort
    '                .BaudRate = 9600
    '                .StopBits = 1
    '                .Parity = Parity.None
    '                .DataBits = 8
    '                .PortName = System.Configuration.ConfigurationManager.AppSettings("ScalePort")
    '                .Open()
    '            End With

    '        Catch ex As Exception
    '            MsgBox("Unable to open the data port for the Scale.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Can't open " & System.Configuration.ConfigurationManager.AppSettings("ScalePort"))

    '        End Try
    '    End If





    'End Sub


End Class
