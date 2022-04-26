Public Class DataCustom




End Class

Public Class ProgramUser
    Public Property LDAPVerified As Boolean = False
    Public Property isTech As Boolean = False
    Public Property isSupervisor As Boolean = False
    Public Property isBasicUser As Boolean = False
    Public Property userName As String = ""
End Class
Public Class ProductInfo

    Public Property ProductDescription As String
    Public Property ProductCode As String
    Public Property SetWeight As Single
    Public Property ProductGrade As Integer
    Public Property Tare As Single
    Public Property Tare2 As Single
    Public Property KickoutCount As Integer
    Public Property MinWeight As Single
    Public Property MaxWeight As Single
    Public Property ItemCountPerBox As Integer
    Public Property ItemTareEach As Single
    Public Property Lot As Integer
    Public Property Type As String
    Public Property AlphaDescription As String
    Public Property ProductDescription2 As String
    Public Property TestingDescription As String

    Public Property LabelTemplate As String
    'Public Property PricePerLb As String
    'Public Property SellByDate As Nullable(Of Date)
    'Public Property KillDate As Nullable(Of Date)
    'Public Property DiscPerLb As String
    Public Property NormalWeight As String
    Public Property IsRigid As Boolean
    Public Property IsFlexible As Boolean


End Class

Public Class MachineInfo
    Public Property ScaleName As String
    Public Property ScaleNumber As String
    Public Property PlantCode As String
    Public Property PrinterPort As String
    Public Property PrinterName As String
    Public Property TemplateName As String
End Class

