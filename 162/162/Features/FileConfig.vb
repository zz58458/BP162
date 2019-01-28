Imports System
Imports System.Math
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Text
Public Class FileConfig

    Public Sub New()

    End Sub
    Public Function LoadFile(ByVal FilePath As String) As DataTable
        Dim i As Integer = 0
        Dim pattern = "(\d+)"
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Name")
        dt.Columns.Add("Value")
        Dim myfile As StreamReader = New StreamReader(FilePath, Encoding.Default)
        Dim strLine As String = myfile.ReadLine()
        While (String.IsNullOrEmpty(strLine) <> True)
            Dim strLists() As String = strLine.Split(" ")
            Dim dr As DataRow = dt.NewRow()
            dr("Name") = strLists(0)
            dr("Value") = strLists(2)
            dt.Rows.Add(dr)
            strLine = myfile.ReadLine()
        End While
        myfile.Close()

        Return dt
    End Function
    Public Sub GetConfig_File(ByRef Axis As Features_Moudle.AXIS, ByVal Value As Int16)
        Static j As Integer
        j = 35 * Value + 1
        Axis.Axis = Features_Moudle.DataGridV(1, j).Value
        Axis.OutMode = Features_Moudle.DataGridV(1, j + 1).Value
        Axis.RadEMGAllow_Prohibit_Value = Features_Moudle.DataGridV(1, j + 2).Value
        Axis.RadEMGLow_High_Value = Features_Moudle.DataGridV(1, j + 3).Value
        Axis.RadINPAllow_Prohibit_Value = Features_Moudle.DataGridV(1, j + 4).Value
        Axis.RadINPLow_High_Value = Features_Moudle.DataGridV(1, j + 5).Value
        Axis.RadALMAllow_Prohibit_Value = Features_Moudle.DataGridV(1, j + 6).Value
        Axis.RadALMLow_High_Value = Features_Moudle.DataGridV(1, j + 7).Value
        Axis.RadERCLow_High_Value = Features_Moudle.DataGridV(1, j + 8).Value
        Axis.RadEZLow_High_Value = Features_Moudle.DataGridV(1, j + 9).Value
        Axis.RadELProhibit_High = Features_Moudle.DataGridV(1, j + 10).Value
        Axis.RadELLow_High = Features_Moudle.DataGridV(1, j + 11).Value
        Axis.RadELStop_Zimm_Fde = Features_Moudle.DataGridV(1, j + 12).Value
        Axis.RadServoLow_High = Features_Moudle.DataGridV(1, j + 13).Value
        Axis.RadOriginLow_High = Features_Moudle.DataGridV(1, j + 14).Value
        Axis.RadOriginSpeed_HighLow = Features_Moudle.DataGridV(1, j + 15).Value
        Axis.RadORGZeroReturn = Features_Moudle.DataGridV(1, j + 16).Value
        Axis.RadLatchValue = Features_Moudle.DataGridV(1, j + 17).Value
        'Axis.CurrentPosition = Features_Control.DataGridV(1, j + 17).Value
        'Axis.CurrentSpeed = Features_Control.DataGridV(1, j + 18).Value
        'Axis.TexAxisStartSpeed = Features_Control.DataGridV(1, j + 19).Value
        'Axis.TexAxisRunSpeed = Features_Control.DataGridV(1, j + 20).Value
        'Axis.TexAxisUpSpeedTime = Features_Control.DataGridV(1, j + 21).Value
        'Axis.TexAxisDownSpeedTime = Features_Control.DataGridV(1, j + 22).Value
        'Axis.TexAxisDisplacement = Features_Control.DataGridV(1, j + 23).Value
        'Axis.TexAxisStopSpeed = Features_Control.DataGridV(1, j + 24).Value
        'Axis.TexAxisTime = Features_Control.DataGridV(1, j + 25).Value
        'Axis.TexAxisSTime = Features_Control.DataGridV(1, j + 26).Value
        'Axis.TexAxisRunDirection = Features_Control.DataGridV(1, j + 27).Value
        'Axis.TexAxisRecycle = Features_Control.DataGridV(1, j + 28).Value
        Axis.RadAxisMove = Features_Moudle.DataGridV(1, j + 30).Value
        Axis.RadAxisAbPositionMode = Features_Moudle.DataGridV(1, j + 31).Value
        Axis.RadAxisCurve = Features_Moudle.DataGridV(1, j + 32).Value
        Axis.RadIsSymmetry = Features_Moudle.DataGridV(1, j + 33).Value
        Axis.RadStopMode = Features_Moudle.DataGridV(1, j + 34).Value
       
    End Sub
    Public Sub GetConfig_File(ByRef Port As Debug_Module.Port)
        Port.PortName = Features_Moudle.DataGridV(1, 281).Value
        Port.PortBaundRate = Features_Moudle.DataGridV(1, 282).Value
        Port.PortOpenLight = Features_Moudle.DataGridV(1, 283).Value
        Port.PortCloseLight = Features_Moudle.DataGridV(1, 284).Value
    End Sub
    Public Sub ReConfig_File(ByRef Axis As Features_Moudle.AXIS, ByVal Value As Int16)
        Static j As Integer = 1
        j = 35 * Value + 1
        Features_Moudle.DataGridV(1, j).Value = Axis.Axis
        Features_Moudle.DataGridV(1, j + 1).Value = Axis.OutMode
        Features_Moudle.DataGridV(1, j + 2).Value = Axis.RadEMGAllow_Prohibit_Value
        Features_Moudle.DataGridV(1, j + 3).Value = Axis.RadEMGLow_High_Value
        Features_Moudle.DataGridV(1, j + 4).Value = Axis.RadINPAllow_Prohibit_Value
        Features_Moudle.DataGridV(1, j + 5).Value = Axis.RadINPLow_High_Value
        Features_Moudle.DataGridV(1, j + 6).Value = Axis.RadALMAllow_Prohibit_Value
        Features_Moudle.DataGridV(1, j + 7).Value = Axis.RadALMLow_High_Value
        Features_Moudle.DataGridV(1, j + 8).Value = Axis.RadERCLow_High_Value
        Features_Moudle.DataGridV(1, j + 9).Value = Axis.RadEZLow_High_Value
        Features_Moudle.DataGridV(1, j + 10).Value = Axis.RadELProhibit_High
        Features_Moudle.DataGridV(1, j + 11).Value = Axis.RadELLow_High
        Features_Moudle.DataGridV(1, j + 12).Value = Axis.RadELStop_Zimm_Fde
        Features_Moudle.DataGridV(1, j + 13).Value = Axis.RadServoLow_High
        Features_Moudle.DataGridV(1, j + 14).Value = Axis.RadOriginLow_High
        Features_Moudle.DataGridV(1, j + 15).Value = Axis.RadOriginSpeed_HighLow
        Features_Moudle.DataGridV(1, j + 16).Value = Axis.RadORGZeroReturn
        Features_Moudle.DataGridV(1, j + 17).Value = Axis.RadLatchValue
        'Features_Control.DataGridV(1, j + 17).Value = Axis.CurrentPosition
        'Features_Control.DataGridV(1, j + 18).Value = Axis.CurrentSpeed
        'Features_Control.DataGridV(1, j + 19).Value = Axis.TexAxisStartSpeed
        'Features_Control.DataGridV(1, j + 20).Value = Axis.TexAxisRunSpeed
        'Features_Control.DataGridV(1, j + 21).Value = Axis.TexAxisUpSpeedTime
        'Features_Control.DataGridV(1, j + 22).Value = Axis.TexAxisDownSpeedTime
        'Features_Control.DataGridV(1, j + 23).Value = Axis.TexAxisDisplacement
        'Features_Control.DataGridV(1, j + 24).Value = Axis.TexAxisStopSpeed
        'Features_Control.DataGridV(1, j + 25).Value = Axis.TexAxisTime
        'Features_Control.DataGridV(1, j + 26).Value = Axis.TexAxisSTime
        'Features_Control.DataGridV(1, j + 27).Value = Axis.TexAxisRunDirection
        'Features_Control.DataGridV(1, j + 28).Value = Axis.TexAxisRecycle
        Features_Moudle.DataGridV(1, j + 30).Value = Axis.RadAxisMove
        Features_Moudle.DataGridV(1, j + 31).Value = Axis.RadAxisAbPositionMode
        Features_Moudle.DataGridV(1, j + 32).Value = Axis.RadAxisCurve
        Features_Moudle.DataGridV(1, j + 33).Value = Axis.RadIsSymmetry
        Features_Moudle.DataGridV(1, j + 34).Value = Axis.RadStopMode
        

        Dim myfile As New System.IO.StreamWriter("./Config/text1.txt")
        Dim strTemp As String = ""
        Dim i, k As Integer
        For i = 0 To Features_Moudle.DataGridV.RowCount - 2
            strTemp = ""
            For k = 0 To Features_Moudle.DataGridV.Columns.Count - 2
                strTemp &= Features_Moudle.DataGridV(k, i).Value & " = "
            Next
            strTemp &= Features_Moudle.DataGridV(k, i).Value
            myfile.WriteLine(strTemp)
        Next
        myfile.Close()

    End Sub
    Public Sub ReConfig_File(ByRef Port As Debug_Module.Port, ByVal Value As Int16)
        Features_Moudle.DataGridV(1, 281).Value = Port.PortName
        Features_Moudle.DataGridV(1, 282).Value = Port.PortBaundRate
        Features_Moudle.DataGridV(1, 283).Value = Port.PortOpenLight
        Features_Moudle.DataGridV(1, 284).Value = Port.PortCloseLight
        Dim myfile As New System.IO.StreamWriter("./Config/text1.txt")
        Dim strTemp As String = ""
        Dim i, k As Integer
        For i = 0 To Features_Moudle.DataGridV.RowCount - 2
            strTemp = ""
            For k = 0 To Features_Moudle.DataGridV.Columns.Count - 2
                strTemp &= Features_Moudle.DataGridV(k, i).Value & " = "
            Next
            strTemp &= Features_Moudle.DataGridV(k, i).Value
            myfile.WriteLine(strTemp)
        Next
        myfile.Close()
    End Sub
End Class
