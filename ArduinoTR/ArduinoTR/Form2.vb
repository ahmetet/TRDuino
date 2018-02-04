Public Class Form2
    Dim Izgara As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (Izgara = True) Then 'ayarlar
            Dim blok As New Button
            blok.Size = New Size(100, 50)
            blok.BackColor = Color.Transparent
            blok.FlatStyle = FlatStyle.Flat
            blok.Text = "Eğer x y"
            panel_ayarlar.Controls.Add(blok)

        Else
            Dim blok As New Button
            blok.Size = New Size(100, 50)
            blok.BackColor = Color.Transparent
            blok.FlatStyle = FlatStyle.Flat
            blok.Text = "Eğer x y"
            panel_tekrarlar.Controls.Add(blok)

        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AyarlarToolStripMenuItem.PerformClick()

    End Sub

    Private Sub AyarlarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyarlarToolStripMenuItem.Click

        If (Izgara = False) Then
            Izgara = True
            AyarlarToolStripMenuItem.BackColor = Color.CornflowerBlue
            panel_ayarlar.Visible = True
            panel_tekrarlar.Visible = False
            TekrarlarToolStripMenuItem.BackColor = Color.White
        End If

    End Sub

    Private Sub TekrarlarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TekrarlarToolStripMenuItem.Click

        If (Izgara = True) Then
            Izgara = False
            AyarlarToolStripMenuItem.BackColor = Color.White
            panel_ayarlar.Visible = False
            panel_tekrarlar.Visible = True
            TekrarlarToolStripMenuItem.BackColor = Color.CornflowerBlue

        End If


    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub
End Class