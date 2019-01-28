Imports System.Runtime.InteropServices

Public Module MdlFunction

    Public mReadParam As New ReadParam

    'Public ProgramName As String = "ProgramA"
    'Public AppPath As String = My.Application.Info.DirectoryPath
    'Public ProgramPath As String = AppPath.Substring(0, AppPath.LastIndexOf("\")) & "\Data\Program"

    Public ProgramName As String = "ProgramA"
    Public AppPath As String = My.Application.Info.DirectoryPath
    Public ProgramPath As String = AppPath.Substring(0, AppPath.LastIndexOf("\")) & "\Data\Program" '制程参数路径

    Public Language As String = "zh-CHS"
    ' Public Wr As New clsErrorInd
    Public BaseParamPath As String = AppPath.Substring(0, AppPath.LastIndexOf("\")) & "\Config" '基本参数路径


#Region "INI File Operation"
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" _
         (ByVal lpSectionName As String, ByVal lpKeyName As String, ByVal lpDefault As String, _
         ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    <DllImport("kernel32.dll", EntryPoint:="WritePrivateProfileStringA")> _
    Public Function WritePrivateProfileString(ByVal lpSectionName As String, _
        ByVal lpKeyName As String, ByVal lpString As String, _
        ByVal lpFileName As String) As Int32

    End Function

    Public Function ReadIni(ByVal lpKeyName As String, ByVal lpDefault As String, ByVal nSize As Integer, ByVal lpFilePath As String) As String
        Try
            Dim lpSectionName As String = "Motion"
            Dim strReturn As String = ""
            strReturn = LSet(strReturn, nSize)
            Dim intReturned As Integer
            intReturned = GetPrivateProfileString(lpSectionName, lpKeyName, lpDefault, strReturn, Len(strReturn), lpFilePath)
            strReturn = Microsoft.VisualBasic.Left(strReturn, InStr(strReturn, Chr(0)) - 1)
            If intReturned <> strReturn.Length Then
                'Throw New AppException("00201", My.Resources.读配置文件错误)
            End If
            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReadIni(ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpFilePath As String) As String
        Return ReadIni(lpKeyName, lpDefault, 256, lpFilePath)
    End Function

    Public Sub WriteIni(ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFilePath As String)
        Try
            Dim lpSectionName As String = "Motion"
            Dim intReturned As Integer
            intReturned = WritePrivateProfileString(lpSectionName, lpKeyName, lpString, lpFilePath)
            If intReturned = 0 Then
                Throw New Exception(XX写文件配置错误)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub WriteP(ByVal lpSectionName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFilePath As String)
        Try
            Dim intReturned As Integer
            intReturned = WritePrivateProfileString(lpSectionName, lpKeyName, lpString, lpFilePath)
            If intReturned = 0 Then
                Throw New Exception(XX写文件配置错误)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ReadP(ByVal lpKeyName As String, ByVal lpDefault As String, ByVal nSize As Integer, ByVal lpFilePath As String, ByVal lpSectionName As String) As String
        Try
            Dim strReturn As String = ""
            strReturn = LSet(strReturn, nSize)
            Dim intReturned As Integer
            intReturned = GetPrivateProfileString(lpSectionName, lpKeyName, lpDefault, strReturn, Len(strReturn), lpFilePath)
            strReturn = Microsoft.VisualBasic.Left(strReturn, InStr(strReturn, Chr(0)) - 1)
            If intReturned <> strReturn.Length Then
                'Throw New AppException("00201", My.Resources.读配置文件错误)
            End If
            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ReadP(ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpFilePath As String, ByVal lpSectionName As String) As String
        Return ReadP(lpKeyName, lpDefault, 256, lpFilePath, lpSectionName)
    End Function

    Public Function ReadIni(ByVal ipsectionname As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal nSize As Integer, ByVal lpFilePath As String) As String
        Try
            Dim lpSectionName As String = "Motion" + ipsectionname
            Dim strReturn As String = ""
            strReturn = LSet(strReturn, nSize)
            Dim intReturned As Integer
            intReturned = GetPrivateProfileString(lpSectionName, lpKeyName, lpDefault, strReturn, Len(strReturn), lpFilePath)
            strReturn = Microsoft.VisualBasic.Left(strReturn, InStr(strReturn, Chr(0)) - 1)
            If intReturned <> strReturn.Length Then
                'Throw New AppException("00201", My.Resources.读配置文件错误)
            End If
            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReadI(ByVal ipsectionname As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpFilePath As String) As String
        Return ReadIni(ipsectionname, lpKeyName, lpDefault, 256, lpFilePath)
    End Function
#End Region

End Module
