Public Class Form1
    Private _decSong As Decimal = 2.99D
    Private _decHourlyRate As Decimal = 8.99D
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Threading.Thread.Sleep(3000)
        ClearForm()
    End Sub
    Private Sub ClearForm()
        cboOptions.SelectedIndex = -1
        lblTotalCost.Visible = False
        txtInput.Visible = False
        btnTotalCost.Visible = False
        btnClear.Visible = False
        lblDisplay.Visible = False
        txtInput.Clear()
    End Sub

    Private Function ComputeSongCost(ByVal intPass As Integer) As Decimal
        Dim decPassCost As Decimal
        decPassCost = intPass * _decSong
        Return decPassCost
    End Function

    Private Function ComputeRoomCost(ByVal intPass As Integer) As Decimal
        Dim decTicketCost As Decimal
        decTicketCost = intPass * _decHourlyRate

        Return decTicketCost
    End Function

    Private Function validateInput() As Boolean
        Dim intNumber As Integer
        Dim blnValid As Boolean = False
        Try
            intNumber = Convert.ToInt32(txtInput.Text)
            If intNumber > 0D Then
                blnValid = True
                Return blnValid
            Else
                MsgBox("Please enter a number greater than 0", , "Error")
            End If
        Catch Exception As FormatException
            MsgBox("please enter a valid amount", , "Error")
        Catch Exception As OverflowException
            MsgBox("Please enter a reasonable amount", , "Error")
        Catch
            MsgBox("Entry invalid. Please enter a valid number representing the number in your party", , "Error")
        End Try

        txtInput.Focus()
        txtInput.Clear()
        Return blnValid
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub btnTotalCost_Click(sender As Object, e As EventArgs) Handles btnTotalCost.Click
        Dim blnAmountIsValid As Boolean = False
        Dim intValue As Integer
        Dim decTotal As Decimal

        blnAmountIsValid = validateInput()
        If blnAmountIsValid = True Then
            intValue = Convert.ToInt32(txtInput.Text)
            If cboOptions.SelectedIndex = 0 Then
                decTotal = ComputeSongCost(intValue)
            Else
                decTotal = ComputeRoomCost(intValue)
            End If

            lblTotalCost.Visible = True
            lblTotalCost.Text = "Total Cost of Karaoke Night - " & decTotal.ToString("C")
        End If
    End Sub

    Private Sub cboOptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOptions.SelectedIndexChanged
        If cboOptions.SelectedIndex = 0 Then
            lblDisplay.Text = "Number of Karaoke Songs"
            lblDisplay.Visible = True
            txtInput.Visible = True
            btnClear.Visible = True
            btnTotalCost.Visible = True
            txtInput.Focus()
        End If
        If cboOptions.SelectedIndex = 1 Then
            lblDisplay.Text = "Hourly Rental of Karaoke Room"
            lblDisplay.Visible = True
            txtInput.Visible = True
            btnClear.Visible = True
            btnTotalCost.Visible = True
            txtInput.Focus()
        End If
    End Sub
End Class
