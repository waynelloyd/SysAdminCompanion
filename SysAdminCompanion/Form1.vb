Imports System.Net.NetworkInformation
Imports System.Text
'Namespace SysAdminCompanion

Public Class Form1

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.History = TextBox1.AutoCompleteCustomSource
        My.Settings.History = TextBox2.AutoCompleteCustomSource
        My.Settings.Save()
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.AutoCompleteCustomSource = My.Settings.History
        TextBox2.AutoCompleteCustomSource = My.Settings.History
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        'Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        'Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim strAddress As String = TextBox1.Text
        If strAddress = String.Empty Then
            MessageBox.Show("Enter the Host Name or IP address")
        ElseIf strAddress <> Text = True Then
            Try
                commandOpt()
            Catch ex As PingException
                MessageBox.Show(ex.InnerException.Message)
            End Try
        End If


    End Sub

    Public Sub commandOpt()
        Dim data As New AutoCompleteStringCollection()
        TextBox1.AutoCompleteCustomSource = data
        TextBox2.AutoCompleteCustomSource = data
        Dim crPrev As Cursor = Cursor.Current
        Cursor.Current = Cursors.WaitCursor
        Dim strAddress As String = TextBox1.Text
        If My.Computer.Network.Ping(strAddress, 1000) Then
            Cursor.Current = crPrev
            data.Add(strAddress)
            Try
                If RadioButton1.Checked = True Then
                    System.Diagnostics.Process.Start("compmgmt.msc", "/computer:" & strAddress)
                ElseIf RadioButton2.Checked = True Then
                    System.Diagnostics.Process.Start("eventvwr.msc", "/computer:" & strAddress)
                ElseIf RadioButton3.Checked = True Then
                    System.Diagnostics.Process.Start("msinfo32.exe", "/computer " & strAddress)
                ElseIf RadioButton4.Checked = True Then
                    System.Diagnostics.Process.Start("services.msc", "/computer:" & strAddress)
                ElseIf RadioButton5.Checked = True Then
                    System.Diagnostics.Process.Start("gpedit.msc", "/gpcomputer: " & strAddress)
                ElseIf RadioButton6.Checked = True Then
                    System.Diagnostics.Process.Start("shrpubw.exe", "/s " & strAddress)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Public Sub remoteOpt()
        Dim data As New AutoCompleteStringCollection()
        TextBox1.AutoCompleteCustomSource = data
        TextBox2.AutoCompleteCustomSource = data
        Dim crPrev As Cursor = Cursor.Current
        Cursor.Current = Cursors.WaitCursor
        Dim strAddress As String = TextBox2.Text
        Dim timeOutp As String = TextBox3.Text
        Dim dlgRes As DialogResult
        If My.Computer.Network.Ping(strAddress, 1000) Then
            Cursor.Current = crPrev
            data.Add(strAddress)
            Try
                If RadioButton7.Checked = True Then
                    If timeOutp = String.Empty Then
                        MessageBox.Show("Please enter a timeout value")
                    ElseIf timeOutp <> Text = True Then
                        dlgRes = MessageBox.Show("Are you sure you want to restart" & vbCrLf & "the remote system " & strAddress & " ?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If dlgRes = DialogResult.Yes Then
                            System.Diagnostics.Process.Start("shutdown.exe", " /r /m " & strAddress & " /t " & timeOutp & " /d p:0:2231369728 /c ""This system has been forced to restart" & vbCrLf & "and will occur in " & timeOutp & " seconds""")
                        End If
                    End If
                End If
                If RadioButton8.Checked = True Then
                    System.Diagnostics.Process.Start("msra.exe", "/offerRA " & strAddress)
                ElseIf RadioButton9.Checked = True Then
                    System.Diagnostics.Process.Start("mstsc.exe", "/V: " & strAddress)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim strAddress As String = TextBox2.Text
        If strAddress = String.Empty Then
            MessageBox.Show("Enter the Host Name or IP address")
        ElseIf strAddress <> Text = True Then
            Try
                remoteOpt()
            Catch ex As PingException
                MessageBox.Show(ex.InnerException.Message)
            End Try
        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        Dim fBold As New Font(RadioButton7.Font.FontFamily, RadioButton7.Font.Size, FontStyle.Bold)
        Dim fNorm As New Font(RadioButton7.Font.FontFamily, RadioButton7.Font.Size, FontStyle.Regular)
        If RadioButton7.Checked = True Then
            RadioButton7.Font = fBold
        ElseIf RadioButton7.Checked = False Then
            RadioButton7.Font = fNorm
        End If
        If RadioButton7.Checked = True Then
            Button3.Text = ("Restart")
        End If
    End Sub

    Private Sub RadioButton8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton8.CheckedChanged
        Dim fBold As New Font(RadioButton8.Font.FontFamily, RadioButton8.Font.Size, FontStyle.Bold)
        Dim fNorm As New Font(RadioButton8.Font.FontFamily, RadioButton8.Font.Size, FontStyle.Regular)
        If RadioButton8.Checked = True Then
            RadioButton8.Font = fBold
        ElseIf RadioButton8.Checked = False Then
            RadioButton8.Font = fNorm
        End If
        If RadioButton8.Checked = True Then
            Button3.Text = ("Connect")
        End If
    End Sub

    Private Sub RadioButton9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton9.CheckedChanged
        Dim fBold As New Font(RadioButton9.Font.FontFamily, RadioButton9.Font.Size, FontStyle.Bold)
        Dim fNorm As New Font(RadioButton9.Font.FontFamily, RadioButton9.Font.Size, FontStyle.Regular)
        If RadioButton9.Checked = True Then
            RadioButton9.Font = fBold
        ElseIf RadioButton9.Checked = False Then
            RadioButton9.Font = fNorm
        End If
        If RadioButton9.Checked = True Then
            Button3.Text = ("Connect")
        End If
    End Sub


    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False 'allow Backspace
        If e.KeyChar = Chr(13) Then TextBox3.Focus() 'Enter key moves to next control
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Dim fBold As New Font(RadioButton1.Font.FontFamily, RadioButton1.Font.Size, FontStyle.Bold)
        Dim fNorm As New Font(RadioButton1.Font.FontFamily, RadioButton1.Font.Size, FontStyle.Regular)
        If RadioButton1.Checked = True Then
            RadioButton1.Font = fBold
        ElseIf RadioButton1.Checked = False Then
            RadioButton1.Font = fNorm
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Dim fBold As New Font(RadioButton2.Font.FontFamily, RadioButton2.Font.Size, FontStyle.Bold)
        Dim fNorm As New Font(RadioButton2.Font.FontFamily, RadioButton2.Font.Size, FontStyle.Regular)
        If RadioButton2.Checked = True Then
            RadioButton2.Font = fBold
        ElseIf RadioButton2.Checked = False Then
            RadioButton2.Font = fNorm
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Dim fBold As New Font(RadioButton3.Font.FontFamily, RadioButton3.Font.Size, FontStyle.Bold)
        Dim fNorm As New Font(RadioButton3.Font.FontFamily, RadioButton3.Font.Size, FontStyle.Regular)
        If RadioButton3.Checked = True Then
            RadioButton3.Font = fBold
        ElseIf RadioButton3.Checked = False Then
            RadioButton3.Font = fNorm
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Dim fBold As New Font(RadioButton4.Font.FontFamily, RadioButton4.Font.Size, FontStyle.Bold)
        Dim fNorm As New Font(RadioButton4.Font.FontFamily, RadioButton4.Font.Size, FontStyle.Regular)
        If RadioButton4.Checked = True Then
            RadioButton4.Font = fBold
        ElseIf RadioButton4.Checked = False Then
            RadioButton4.Font = fNorm
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        Dim fBold As New Font(RadioButton5.Font.FontFamily, RadioButton5.Font.Size, FontStyle.Bold)
        Dim fNorm As New Font(RadioButton5.Font.FontFamily, RadioButton5.Font.Size, FontStyle.Regular)
        If RadioButton5.Checked = True Then
            RadioButton5.Font = fBold
        ElseIf RadioButton5.Checked = False Then
            RadioButton5.Font = fNorm
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        Dim fBold As New Font(RadioButton6.Font.FontFamily, RadioButton6.Font.Size, FontStyle.Bold)
        Dim fNorm As New Font(RadioButton6.Font.FontFamily, RadioButton6.Font.Size, FontStyle.Regular)
        If RadioButton6.Checked = True Then
            RadioButton6.Font = fBold
        ElseIf RadioButton6.Checked = False Then
            RadioButton6.Font = fNorm
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            TextBox2.Text = TextBox1.Text
        ElseIf TabControl1.SelectedIndex = 0 Then
            TextBox1.Text = TextBox2.Text
        End If

    End Sub

    Public Sub New()
        InitializeComponent()
        ' defaults
        TextBox5.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()"
        TextBox4.Text = "8"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim len As Integer = 0
            Try
                len = Int32.Parse(Me.TextBox4.Text.ToString())
            Catch e1 As FormatException
                MessageBox.Show("Invalid format specified in the ""Password Length"" field. Length must be an integer between 4 and 256.")
                Return
            Catch e2 As ArgumentNullException
                MessageBox.Show("Please enter a value in the ""Password Length"" field.")
                Return
            End Try
            Dim possibleChars() As Char = Me.TextBox5.Text.ToCharArray()
            If possibleChars.Length < 1 Then
                MessageBox.Show("You must enter one or more possible characters.")
                Return
            End If
            If len < 4 Then
                MessageBox.Show(String.Format("Please choose a password length. That length must be a value between {0} and {1}. Note: values above 1,000 might take a LONG TIME to process on some computers.", 4, Int32.MaxValue))
                Return
            End If

            TextBox6.Text = ""
            Dim builder As New StringBuilder()

            For i As Integer = 0 To len - 1
                ' Get our cryptographically random 32-bit integer & use as seed in Random class
                ' NOTE: random value generated PER ITERATION, meaning that the System.Random class
                ' is re-instantiated every iteration with a new, crytographically random numeric seed.
                Dim randInt32 As Integer = RandomInt32Value.GetRandomInt()
                Dim r As New Random(randInt32)

                Dim nextInt As Integer = r.Next(possibleChars.Length)
                Dim c As Char = possibleChars(nextInt)
                builder.Append(c)
            Next i
            ' Set the text box "Text" property using final, constructed string
            TextBox6.Text = builder.ToString()
        Catch ex As Exception
            MessageBox.Show(String.Format("An error has occurred while trying to generate random password! Technical description: {0}", ex.Message.ToString()))
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox5.ReadOnly = True
        ElseIf CheckBox1.Checked = False Then
            TextBox5.ReadOnly = False
        End If
    End Sub

End Class
'End Namespace
