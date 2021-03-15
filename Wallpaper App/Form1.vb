Public Class frmWallpaper

    'Declaring variables
    Dim dblRoll As Double
    Dim intArea As Integer

    'declaration and initializing arrayA for length, width and height
    Dim arrayA As Integer() = New Integer() {10, 11, 12, 13, 14, 15, 16, 17, 18,
                                             19, 20, 21, 22, 23, 24, 25, 26, 27,
                                             28, 29, 30, 31, 32, 33, 34, 35}

    'declaration and initializing arrayB for roll coverage
    Dim arrayB As Double() = New Double() {40, 40.5, 41, 41.5, 42, 42.5, 43,
                                           43.5, 44, 44.5, 45, 45.5, 46, 46.5,
                                           47, 47.5, 48, 48.5, 49, 49.5, 50}

    Private Sub frmWallpaper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'adding items to the comboboxes of length, width and height
        For i = 0 To 25
            cboLength.Items.Add(arrayA(i))
            cboWidth.Items.Add(arrayA(i))
            cboHeight.Items.Add(arrayA(i))
        Next

        'adding items to the combobox of roll coverage
        For j = 0 To 20
            cboRollCov.Items.Add(arrayB(j))
        Next
    End Sub

    Sub Calculate()
        lstDisplay.Items.Clear() 'delete all the items in the lstDisplay box
        If (String.IsNullOrWhiteSpace(cboLength.SelectedItem) Or
            String.IsNullOrWhiteSpace(cboWidth.SelectedItem) Or
            String.IsNullOrWhiteSpace(cboWidth.SelectedItem) Or
            String.IsNullOrWhiteSpace(cboRollCov.SelectedItem)) Then

            MsgBox("Invalid! Make all selections.", MsgBoxStyle.Critical)
        Else
            intArea = (cboLength.SelectedItem * 2 + cboWidth.SelectedItem * 2) *
                        cboHeight.SelectedItem 'calculate the area
            dblRoll = intArea / cboRollCov.SelectedItem 'calculate single roll
            lstDisplay.Items.Add(Math.Ceiling(dblRoll)) 'display the results
        End If
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Calculate() 'when the button is clicked, display the results
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        'Close the windows form
        Dim ExitYN As System.Windows.Forms.DialogResult
        ExitYN = MsgBox("Do you really want to exit?", MsgBoxStyle.YesNo)

        If ExitYN = MsgBoxResult.Yes Then
            Application.ExitThread()
        End If
    End Sub

    Private Sub frmWallpaper_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'close the form using (x) button
        Dim dialog As System.Windows.Forms.DialogResult
        dialog = MsgBox("Do you really want to close?", MsgBoxStyle.YesNo)

        If dialog = MsgBoxResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub
End Class
