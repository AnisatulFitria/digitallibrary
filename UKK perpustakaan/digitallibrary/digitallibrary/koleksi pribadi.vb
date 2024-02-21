Public Class koleksi_pribadi
    Public id
    Sub awal()
        DataGridView1.DataSource = getData("select * from vkoleksi where judul like '%" & TextBox1.Text & "%'")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).HeaderText = "Judul"
        DataGridView1.Columns(4).HeaderText = "Penulis"
        DataGridView1.Columns(5).HeaderText = "Penerbit"
        DataGridView1.Columns(6).HeaderText = "Tahun Terbit"
        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).Visible = False
        DataGridView1.Columns(9).Visible = False
        DataGridView1.Columns(10).Visible = False
        DataGridView1.Columns(11).Visible = False
        DataGridView1.Columns(12).Visible = False
        DataGridView1.Columns(13).Visible = False
        DataGridView1.Columns(14).HeaderText = "Kategori"
        GroupBox1.Enabled = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cari_buku.ShowDialog()
        cari_buku.aksi = False
    End Sub

    Private Sub koleksi_pribadi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub
End Class