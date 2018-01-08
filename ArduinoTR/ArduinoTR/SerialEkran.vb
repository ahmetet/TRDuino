Imports System
Imports System.IO.Ports

Public Class SerialEkran
    Dim SecilenPort As String
    Dim AlinanVeri As String = ""
    Private Sub SerialEkran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = Form1.Size
        SecilenPort = Me.Text.Replace("Seri İletişim Penceresi", "").Trim

        If (ToolStripComboBox1.Text = "") Then
        Else
            Try
                Baudrate = Convert.ToInt32(ToolStripComboBox1.SelectedItem.ToString.Replace("baud", ""))
                SerialPort1.BaudRate = Baudrate
                baglan_ac()
            Catch ex As Exception

            End Try
        End If

    End Sub
    Sub baglan_ac()
        'Bağlan

        SerialPort1.PortName = SecilenPort

        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default
        SerialPort1.ReadTimeout = 10000
        SerialPort1.Open() ' Açıldı
        Timer1.Enabled = True

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If SerialPort1.IsOpen Then
                SerialPort1.Write(TextBox1.Text)
                TextBox1.Text = ""
            End If
        End If
    End Sub
    Dim Baudrate As Integer

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        Try
            Baudrate = Convert.ToInt32(ToolStripComboBox1.SelectedItem.ToString.Replace("baud", ""))
            SerialPort1.BaudRate = Baudrate

            baglan_ac()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        AlinanVeri = SerialDataAl()
        RichTextBox1.Text += AlinanVeri
    End Sub

    Private Sub SerialEkran_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Timer1.Enabled = False
        SerialPort1.Close()
    End Sub


    Function SerialDataAl() As String
        Dim Incoming As String
        Try
            Incoming = SerialPort1.ReadExisting()
            If Incoming Is Nothing Then
                Return "Hiçbir şey gelmiyor." & vbCrLf
            Else
                Return Incoming
            End If
        Catch ex As TimeoutException
            Return "HATA: İletişim zaman aşımına uğradı!"
        End Try

    End Function

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.SelectionStart = RichTextBox1.TextLength
        RichTextBox1.ScrollToCaret()
    End Sub
End Class