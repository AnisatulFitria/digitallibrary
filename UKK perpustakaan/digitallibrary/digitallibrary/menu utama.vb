Public Class menu_utama
    Public iduser, idbuku
    Dim id

    Sub awal()
        DataGridView1.DataSource = getData("select * from tbluser where namalengkap like '%" & TextBox1.Text & "%'")
        clearForm(GroupBox2)
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Username"
        DataGridView1.Columns(2).HeaderText = "Password"
        DataGridView1.Columns(3).HeaderText = "Email"
        DataGridView1.Columns(4).HeaderText = "Nama Lengkap"
        DataGridView1.Columns(5).HeaderText = "Alamat"
        DataGridView1.Columns(6).HeaderText = "Level"
    End Sub
    Private Sub LaporanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanToolStripMenuItem.Click
        ulasan.ShowDialog()
    End Sub

    

    Private Sub StatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusToolStripMenuItem.Click
        koleksi_pribadi.ShowDialog()
    End Sub

    Private Sub PustakawanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PustakawanToolStripMenuItem.Click
        buku.ShowDialog()
    End Sub

    Private Sub AnggotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnggotaToolStripMenuItem.Click
        user.ShowDialog()
    End Sub

    Private Sub menu_utama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        awal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GroupBox1.Enabled = True
        id = "0"
        idbuku = "0"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cari_buku.aksi = True
        cari_buku.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox1.Enabled = False
        id = "0"
        idbuku = "0"
        clearForm(GroupBox1)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql
        If getValue("select * from tbluser where iduser =" & iduser, "level") = "User" Then
            MsgBox("1")
        Else
            If id = "0" Or idbuku = "0" Then
                MsgBox("Data masih kosong")
            Else
                sql = "insert into peminjaman values ('" & id & "', '" & idbuku & "', '" & DateTimePicker1.Value.ToString("yyyy/MM/dd") & "','','" & ComboBox1.Text & "')"
                'MsgBox(sql)
                exc(sql)
                GroupBox1.Enabled = False
                MsgBox("Buku telah dipinjam")
                clearForm(GroupBox1)
            End If
        End If
    End Sub

    Private Sub PengembalianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PengembalianToolStripMenuItem.Click
        pengembalian.ShowDialog()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        laporan.ShowDialog()
    End Sub

    Private Sub LogoutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem1.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub BukuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BukuToolStripMenuItem.Click
        kategori.ShowDialog()
    End Sub
End Class