Public Class pengembalian
    Public iduser, idbuku
    Dim sql
    Dim id
    Sub awal()
        DataGridView1.DataSource = getData("select * from vpeminjaman where namalengkap like '%" & TextBox1.Text & "%' and statuspeminjaman = 'Dipinjam'")
        clearForm(GroupBox2)
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).HeaderText = "Idbuku"
        DataGridView1.Columns(3).HeaderText = "Tanggal Peminjaman"
        DataGridView1.Columns(4).HeaderText = "Tanggal Pengembalian"
        DataGridView1.Columns(5).HeaderText = "Status Peminjaman"
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).HeaderText = "Email"
        DataGridView1.Columns(9).HeaderText = "Nama Lengkap"
        DataGridView1.Columns(10).HeaderText = "Alamat"
        DataGridView1.Columns(11).Visible = False
        DataGridView1.Columns(12).HeaderText = "Judul"
        DataGridView1.Columns(13).HeaderText = "Penulis"
        DataGridView1.Columns(14).HeaderText = "Penerbit"
        DataGridView1.Columns(15).HeaderText = "Tahun Terbit"
        DataGridView1.Columns(16).HeaderText = "Stok"
        DataGridView1.Columns(17).Visible = False
        DataGridView1.Columns(18).Visible = False
        DataGridView1.Columns(19).HeaderText = "Nama Kategori"

    End Sub
    Private Sub pengembalian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 1
        awal()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql
        If id = "0" Then
            MsgBox("Data masih kosong")
        Else
            sql = "update peminjaman set tglpengembalian = '" & DateTimePicker1.Value.ToString("yyyy/MM/dd") & "', statuspeminjaman = '" & ComboBox1.Text & "' where idpeminjaman = " & id
            'MsgBox(sql)
            exc(sql)
            MsgBox("Buku telah dikembalikan")
            sql = "insert into ulasanbuku values ('" & iduser & "','" & idbuku & "','', '')"
            'MsgBox(sql)
            exc(sql)
            clearForm(GroupBox1)
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value
            TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(12).Value
            beri_ulasan.TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(12).Value
            iduser = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            idbuku = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox1.Enabled = False
        id = "0"
        clearForm(GroupBox1)
    End Sub
End Class