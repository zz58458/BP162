Public Class ClassIO

    Public StrInput As Input
    Public StrOutput As OutPut

    Public Structure Input
        ''错误代码 404051~404100
        Public InPiontNameID As String '对应卡的IO号
        Public InUseName As String 'IO口作用
        Public LowActivelevel As String '低电平
        Public HightActivelevel As String '高电平
        Public InCardNum As Byte '卡号
        Public InDisConfMode As Boolean '对应该点显示方式

        Public Sub SaveIn(ByVal FilePath As String, ByVal InputStr As String)
            Try
                WriteP(InputStr, "Name", InUseName, FilePath)
                WriteP(InputStr, "ValA", LowActivelevel, FilePath)
                WriteP(InputStr, "ValB", HightActivelevel, FilePath)
                WriteP(InputStr, "InPut", InPiontNameID, FilePath)
                WriteP(InputStr, "Card", InCardNum, FilePath)
            Catch ex As Exception
                Throw New Exception("404051;" & XX保存IO设置错误_请核对路径 & FilePath & Chr(13) & ex.Message)
            End Try

        End Sub

        'Public Sub ReadIn(ByVal FilePath As String, ByVal InputStr As String, ByVal ComNInput As Input)
        '    ReadInPut(FilePath, InputStr, ComNInput)
        'End Sub
    End Structure

    Public Structure OutPut
        Public OutUseName As String 'IO口作用
        Public OutCardNum As Byte '卡号
        Public OutActivelevel As String  '有效电平
        Public OutHightActivelevel As String '高电平
        Public OutPiontNameID As String '对应卡的IO号
        Public OutMotionChange As Boolean '操作写入

        Public Sub SaveOut(ByVal FilePath As String, ByVal InputStr As String)
            Try
                WriteP(InputStr, "Name", OutUseName, FilePath)
                WriteP(InputStr, "Card", OutCardNum, FilePath)
                WriteP(InputStr, "ValA", OutActivelevel, FilePath)
                WriteP(InputStr, "ValB", OutHightActivelevel, FilePath)
                WriteP(InputStr, "OutPut", OutPiontNameID, FilePath)
            Catch ex As Exception
                Throw New Exception("404052;" & XX保存IO设置错误_请核对路径 & FilePath & Chr(13) & ex.Message)
            End Try

        End Sub

        Public Sub ReadOut(ByVal FilePath As String, ByVal InputStr As String, ByVal ComNOutput As OutPut)
            Try
                ReadOutPut(FilePath, InputStr, ComNOutput)
            Catch ex As Exception
                Throw ex
            End Try

        End Sub
    End Structure


    'Private Shared Function ReadInPut(ByVal FilePath As String, ByVal name As String, ByVal ComInput As Input) As Boolean
    '    Dim str As String
    '    Dim bool As Boolean = False
    '    Dim StrR As New IO.StreamReader(FilePath)
    '    While True
    '        str = StrR.ReadLine
    '        If str = name Then
    '            bool = True
    '            ComInput.InActivelevel = StrR.ReadLine
    '            ComInput.InCardNum = StrR.ReadLine
    '            ComInput.InDisConfMode = StrR.ReadLine
    '            ComInput.InPiontNameID = StrR.ReadLine
    '            ComInput.InUseName = StrR.ReadLine
    '            Exit While
    '        End If
    '        If str Is Nothing Then
    '            bool = False
    '            Exit While
    '        End If
    '    End While
    '    Return bool
    '    StrR.Close()
    '    StrR.Dispose()
    'End Function

    Private Shared Function ReadOutPut(ByVal FilePath As String, ByVal name As String, ByVal ComInput As OutPut) As Boolean
        Try
            Dim str As String
            Dim bool As Boolean = False
            Dim StrR As New IO.StreamReader(FilePath)
            While True
                str = StrR.ReadLine
                If str = name Then
                    bool = True
                    ComInput.OutActivelevel = StrR.ReadLine
                    ComInput.OutCardNum = StrR.ReadLine
                    ComInput.OutPiontNameID = StrR.ReadLine
                    ComInput.OutUseName = StrR.ReadLine
                    ComInput.OutMotionChange = StrR.ReadLine
                    Exit While
                End If
                If str Is Nothing Then
                    bool = False
                    Exit While
                End If
            End While
            Return bool
            StrR.Close()
            StrR.Dispose()
        Catch ex As Exception
            Throw New Exception("404053;" & XX保存IO设置错误_请核对路径 & FilePath & Chr(13) & ex.Message)
        End Try
    End Function

    Private Sub SaveInIO(ByVal FilePath As String, ByVal InputStr As String)
        Try
            StrInput.SaveIn(FilePath, 0)
            StrInput.SaveIn(FilePath, 1)
            StrInput.SaveIn(FilePath, 2)
            StrInput.SaveIn(FilePath, 3)
            StrInput.SaveIn(FilePath, 4)
            StrInput.SaveIn(FilePath, 5)
            StrInput.SaveIn(FilePath, 6)
            StrInput.SaveIn(FilePath, 7)
            StrInput.SaveIn(FilePath, 8)
            StrInput.SaveIn(FilePath, 9)
            StrInput.SaveIn(FilePath, 10)
            StrInput.SaveIn(FilePath, 11)
            StrInput.SaveIn(FilePath, 12)
            StrInput.SaveIn(FilePath, 13)
            StrInput.SaveIn(FilePath, 14)
            StrInput.SaveIn(FilePath, 15)
            StrInput.SaveIn(FilePath, 16)
            StrInput.SaveIn(FilePath, 17)
            StrInput.SaveIn(FilePath, 18)
            StrInput.SaveIn(FilePath, 19)
            StrInput.SaveIn(FilePath, 20)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    'Private Sub ReadInIO(ByVal FilePath As String, ByVal InputStr As String, ByVal ComNInput As Input)
    '    StrInput.ReadIn(FilePath, 0, ComNInput)
    '    StrInput.ReadIn(FilePath, 1, ComNInput)
    '    StrInput.ReadIn(FilePath, 2, ComNInput)
    '    StrInput.ReadIn(FilePath, 3, ComNInput)
    '    StrInput.ReadIn(FilePath, 4, ComNInput)
    '    StrInput.ReadIn(FilePath, 5, ComNInput)
    '    StrInput.ReadIn(FilePath, 6, ComNInput)
    '    StrInput.ReadIn(FilePath, 7, ComNInput)
    '    StrInput.ReadIn(FilePath, 8, ComNInput)
    '    StrInput.ReadIn(FilePath, 9, ComNInput)
    '    StrInput.ReadIn(FilePath, 10, ComNInput)
    '    StrInput.ReadIn(FilePath, 11, ComNInput)
    '    StrInput.ReadIn(FilePath, 12, ComNInput)
    '    StrInput.ReadIn(FilePath, 13, ComNInput)
    '    StrInput.ReadIn(FilePath, 14, ComNInput)
    '    StrInput.ReadIn(FilePath, 15, ComNInput)
    '    StrInput.ReadIn(FilePath, 16, ComNInput)
    '    StrInput.ReadIn(FilePath, 17, ComNInput)
    '    StrInput.ReadIn(FilePath, 18, ComNInput)
    '    StrInput.ReadIn(FilePath, 19, ComNInput)
    '    StrInput.ReadIn(FilePath, 20, ComNInput)
    'End Sub

    Private Sub SaveOutIO(ByVal FilePath As String, ByVal InputStr As String)
        Try
            StrOutput.SaveOut(FilePath, 0)
            StrOutput.SaveOut(FilePath, 1)
            StrOutput.SaveOut(FilePath, 2)
            StrOutput.SaveOut(FilePath, 3)
            StrOutput.SaveOut(FilePath, 4)
            StrOutput.SaveOut(FilePath, 5)
            StrOutput.SaveOut(FilePath, 6)
            StrOutput.SaveOut(FilePath, 7)
            StrOutput.SaveOut(FilePath, 8)
            StrOutput.SaveOut(FilePath, 9)
            StrOutput.SaveOut(FilePath, 10)
            StrOutput.SaveOut(FilePath, 11)
            StrOutput.SaveOut(FilePath, 12)
            StrOutput.SaveOut(FilePath, 13)
            StrOutput.SaveOut(FilePath, 14)
            StrOutput.SaveOut(FilePath, 15)
            StrOutput.SaveOut(FilePath, 16)
            StrOutput.SaveOut(FilePath, 17)
            StrOutput.SaveOut(FilePath, 18)
            StrOutput.SaveOut(FilePath, 19)
            StrOutput.SaveOut(FilePath, 20)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub ReadOutIO(ByVal FilePath As String, ByVal InputStr As String, ByVal ComOutnput As OutPut)
        Try
            StrOutput.ReadOut(FilePath, 0, ComOutnput)
            StrOutput.ReadOut(FilePath, 1, ComOutnput)
            StrOutput.ReadOut(FilePath, 2, ComOutnput)
            StrOutput.ReadOut(FilePath, 3, ComOutnput)
            StrOutput.ReadOut(FilePath, 4, ComOutnput)
            StrOutput.ReadOut(FilePath, 5, ComOutnput)
            StrOutput.ReadOut(FilePath, 6, ComOutnput)
            StrOutput.ReadOut(FilePath, 7, ComOutnput)
            StrOutput.ReadOut(FilePath, 8, ComOutnput)
            StrOutput.ReadOut(FilePath, 9, ComOutnput)
            StrOutput.ReadOut(FilePath, 10, ComOutnput)
            StrOutput.ReadOut(FilePath, 11, ComOutnput)
            StrOutput.ReadOut(FilePath, 12, ComOutnput)
            StrOutput.ReadOut(FilePath, 13, ComOutnput)
            StrOutput.ReadOut(FilePath, 14, ComOutnput)
            StrOutput.ReadOut(FilePath, 15, ComOutnput)
            StrOutput.ReadOut(FilePath, 16, ComOutnput)
            StrOutput.ReadOut(FilePath, 17, ComOutnput)
            StrOutput.ReadOut(FilePath, 18, ComOutnput)
            StrOutput.ReadOut(FilePath, 19, ComOutnput)
            StrOutput.ReadOut(FilePath, 20, ComOutnput)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class