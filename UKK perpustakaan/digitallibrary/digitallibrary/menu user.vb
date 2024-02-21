Public Class menu_user
    Public iduser, idbuku
    Dim id
    Private Sub menu_user_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub KoleksiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KoleksiToolStripMenuItem.Click
        koleksi_pribadi.ShowDialog()
    End Sub

    Private Sub UlasanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UlasanToolStripMenuItem.Click
        ulasan.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cari_buku.aksi = True
        cari_buku.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql
        If iduser = "0" Or idbuku = "0" Then
            MsgBox("Data masih kosong")
        Else
            sql = "insert into peminjaman values ('" & iduser & "', '" & idbuku & "', '" & DateTimePicker1.Value.ToString("yyyy/MM/dd") & "','','" & ComboBox1.Text & "')"
            'MsgBox(sql)
            exc(sql)
            GroupBox1.Enabled = False
            MsgBox("Buku telah dipinjam")
            clearForm(GroupBox1)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox1.Enabled = False
        id = "0"
        idbuku = "0"
        clearForm(GroupBox1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GroupBox1.Enabled = True
        id = "0"
        idbuku = "0"
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Form1.Show()
        Me.Close()
    End Sub
End Class