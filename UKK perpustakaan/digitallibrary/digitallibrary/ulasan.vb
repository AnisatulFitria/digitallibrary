Public Class ulasan
    Dim id
    Dim sql
    Sub awal()
        DataGridView1.DataSource = getData("select * from vulasan where iduser = " & koleksi_pribadi.id)
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).HeaderText = "Ulasan"
        DataGridView1.Columns(4).HeaderText = "Rating"
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).HeaderText = "Nama Lengkap"
        DataGridView1.Columns(9).HeaderText = "Alamat"
        DataGridView1.Columns(10).Visible = False
        DataGridView1.Columns(11).HeaderText = "Judul"
        DataGridView1.Columns(12).HeaderText = "Penulis"
        DataGridView1.Columns(13).HeaderText = "Penerbit"
        DataGridView1.Columns(14).HeaderText = "Tahun Terbit"
        DataGridView1.Columns(15).HeaderText = "Stok"
        DataGridView1.Columns(16).Visible = False
        DataGridView1.Columns(17).Visible = False
        DataGridView1.Columns(18).HeaderText = "Nama Kategori"

    End Sub
    Private Sub ulasan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(11).Value
            id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            sql = "update ulasanbuku set ulasan = '" & TextBox1.Text & "', rating = '" & TextBox2.Text & "' where idulasan = " & id
            'MsgBox(sql)
            exc(sql)
            clearForm(GroupBox1)
            id = "0"
            awal()
            MsgBox("Buku telah diberi ulasan")

        End If
    End Sub
End Class