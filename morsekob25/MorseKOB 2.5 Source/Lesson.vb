Imports System.Windows.Forms
Imports VB = Microsoft.VisualBasic

Public Class Lesson
    Private Const maxWords = 30000
    Private alphabet As String = "etainshdumgwbvkorlcyzfpxjq"

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles OK_Button.Click
        Me.Cursor = Cursors.WaitCursor
        Dim wordList(maxWords) As String
        Dim nWords As Integer = 0
        Try
            Dim sr As New System.IO.StreamReader(Application.UserAppDataPath & "\Text Files\Word list.txt")
            Dim wrd As String
            Do
                wrd = sr.ReadLine
                If IsNothing(wrd) Then Exit Do
                If Len(wrd) <= nudMaxWordLength.Value Then
                    Dim possibleOK As Boolean = True
                    Dim requiredOK As Boolean = txtRequiredLetters.Text = ""
                    For Each c As Char In wrd
                        If InStr(txtPossibleLetters.Text, c) = 0 Then
                            If InStr(txtRequiredLetters.Text, c) = 0 Then
                                possibleOK = False
                                Exit For
                            End If
                        End If
                        If InStr(txtRequiredLetters.Text, c) <> 0 Then
                            requiredOK = True
                        End If
                    Next
                    If possibleOK And requiredOK Then
                        If nWords >= maxWords Then
                            MsgBox("Word list has more than " & maxWords & " valid words.")
                            Exit Do
                        End If
                        nWords += 1
                        wordList(nWords) = wrd
                    End If
                End If
            Loop
            sr.Close()
        Catch ex As Exception
            MsgBox("Can't read word list file. " & ex.Message)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Hide()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Randomize()
        Main.senderActive = False
        Main.txtKeyboard.Text = ""
        Dim wl As String = ""
        For i As Integer = 1 To nudNGroups.Value
            For j As Integer = 1 To nudWordsPerGroup.Value
                wl &= wordList(Int(Rnd() * nWords) + 1) & " "
            Next
            wl &= " "
        Next
        Main.txtKeyboard.Text = wl
        Main.txtKeyboard.SelectionStart = 0
        Main.txtKeyboard.SelectionLength = 0
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
        Main.txtKeyboard.Focus()
    End Sub

    Private Sub nudLevel_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles nudLevel.ValueChanged
        txtPossibleLetters.Text = VB.Left(alphabet, nudLevel.Value)
    End Sub
End Class
