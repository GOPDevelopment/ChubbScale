Imports System.IO
Imports System.IO.Ports


Public Class ScalePortInfo

    Public WithEvents ScalePort As New SerialPort
    Public EntireScaleMessage As String = ""
    'Public ScaleWeightEndText As String = "lb GROSS"
    Public Property CurrentScaleRead As String = "0"

    Public Sub New(comPort As String)
        ScalePort = InitializePortOpening(comPort)
    End Sub


    Private Function InitializePortOpening(comPort As String) As SerialPort

        If Not ScalePort.IsOpen Then
            Try
                With ScalePort
                    .BaudRate = 9600
                    .StopBits = 1
                    .Parity = Parity.None
                    .DataBits = 8
                    .PortName = comPort
                    .Open()
                End With

            Catch ex As Exception
                'WriteToErrorLog("ERROR", ex.Message, ex.StackTrace, MachineInstance.ScaleNumber)
                'MsgBox("Unable to open the data port for the Scale.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Can't open " & System.Configuration.ConfigurationManager.AppSettings("ScalePort"))
            End Try
        End If

        Return ScalePort

    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub



End Class
