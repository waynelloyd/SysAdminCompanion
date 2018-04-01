Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Security.Cryptography
Imports System.Windows.Forms

'Namespace RandPasswordGen
Friend Class PassGen
    Shared Sub Main(ByVal args() As String)
        Using mainForm As New Form1
            Application.Run(mainForm)
        End Using
    End Sub
End Class
Public NotInheritable Class RandomInt32Value
    Private Sub New()
    End Sub
    Public Shared Function GetRandomInt() As Int32
        Dim randomBytes(3) As Byte
        Dim rng As New RNGCryptoServiceProvider()
        rng.GetBytes(randomBytes)
        Dim randomInt As Int32 = BitConverter.ToInt32(randomBytes, 0)
        Return randomInt
    End Function
End Class
Public NotInheritable Class PasswordGenProfiler
    Private Sub New()
    End Sub
    Public Shared Function GetFrequencyDistributionOfChars(ByVal allowableChars As String, ByVal generatedPass As String) As Dictionary(Of Char, Integer)
        Dim distrib As Dictionary(Of Char, Integer) = New Dictionary(Of Char, Integer)()
        ' initialize all values to 0
        For Each c As Char In allowableChars
            ' If character is listed more than once, don't re-add it to our list.
            If (Not distrib.ContainsKey(c)) Then
                distrib.Add(c, 0)
            End If
        Next c
        Dim val As Integer = 0
        For Each passChar As Char In generatedPass
            If distrib.TryGetValue(passChar, val) Then
                val += 1
                distrib(passChar) = val
            End If
        Next passChar

        Return distrib
    End Function
End Class
'End Namespace
