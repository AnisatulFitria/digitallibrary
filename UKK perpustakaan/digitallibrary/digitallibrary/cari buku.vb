Public Class cari_buku
    Dim id, buku
    Public aksi = False
    Sub awal()
        DataGridView1.DataSource = getData("select * from vbuku where judul like '%" & TextBox1.Text & "%'")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).HeaderText = "Judul"
        DataGridView1.Columns(4).HeaderText = "Penulis"
        DataGridView1.Columns(5).HeaderText = "Penerbit"
        DataGridView1.Columns(6).HeaderText = "Tahun Terbit"
        DataGridView1.Columns(7).HeaderText = "Kategori"

        id = "0"
    End Sub
    Private Sub cari_buku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not aksi Then
            If id = "0" Then
                MsgBox("Pilih buku dulu")
            Else
                Dim sql = "insert into koleksipribadi values ('" & koleksi_pribadi.id & "','" & id & "')"
                'MsgBox(sql)
                exc(sql)
                koleksi_pribadi.awal()
                Me.Close()
            End If
        Else
            If id = "0" Then
                MsgBox("Pilih buku dulu")
            Else
                menu_utama.idbuku = id
                menu_utama.TextBox3.Text = buku
                menu_user.idbuku = id
                menu_user.TextBox2.Text = buku
                Me.Close()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            id = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            buku = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class