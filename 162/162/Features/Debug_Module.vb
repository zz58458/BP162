Public Module Debug_Module
    Public Port0 As Port = New Port()
    Public Structure Port
        '串口配置参数
        Public PortName As String '串口端口
        Public PortBaundRate As String '串口波特率
        Public PortOpenLight As String '打开光源指令
        Public PortCloseLight As String '关闭光源指令
    End Structure
End Module
