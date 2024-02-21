Public Class buku
    Dim id = "0"
    Dim aksi = False

    Sub getCombo()
        Dim sql = "select * from kategoribuku"
        ComboBox1.DataSource = getData(sql)
        ComboBox1.DisplayMember = "namakategori"
        ComboBox1.ValueMember = "idkategori"
    End Sub
    Sub awal()
        DataGridView1.DataSource = getData("select * from vbuku where judul like '%" & TextBox1.Text & "%'")
        clearForm(GroupBox2)
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "id buku"
        DataGridView1.Columns(2).HeaderText = "id kategori"
        DataGridView1.Columns(3).HeaderText = "Judul"
        DataGridView1.Columns(4).HeaderText = "Penulis"
        DataGridView1.Columns(5).HeaderText = "Penerbit"
        DataGridView1.Columns(6).HeaderText = "Tahun Terbit"
        DataGridView1.Columns(7).HeaderText = "Kategori"
        DataGridView1.Columns(8).HeaderText = "Stok"
        GroupBox1.Enabled = True
        GroupBox2.Enabled = False
        GroupBox3.Enabled = True
        id = "0"
        aksi = False
    End Sub

    Sub buka()
        GroupBox1.Enabled = False
        GroupBox2.Enabled = True
        GroupBox3.Enabled = False
    End Sub
    Private Sub buku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getCombo()
        awal()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'button simpan
        Dim idbuku = "0"
        If adaKosong(GroupBox2) Then
            MsgBox("Ada data kosong")
        Else
            Dim sql1, sql2
            If Not aksi Then
                sql1 = "insert into buku values('" & TextBox2.Text & "','" & TextBox3.Text & "', '" & TextBox4.Text & "','" & DateTimePicker1.Value.ToString("yyyy/MM/dd") & "','" & NumericUpDown1.Value & "')"
                'MsgBox(sql1)
                exc(sql1)

                idbuku = getValue("select * from buku order by idbuku desc", "idbuku")
                sql2 = "insert into kategoribuku_relasi values('" & idbuku & "', '" & ComboBox1.SelectedValue & "')"
                'MsgBox(sql1)
                exc(sql2)
                MsgBox("Data berhasil ditambah")
                awal()
            Else
                sql1 = "update buku set judul = '" & TextBox2.Text & "', penulis = '" & TextBox3.Text & "', penerbit = '" & TextBox4.Text & "', tahunterbit = '" & DateTimePicker1.Value.ToString("yyyy/MM/dd") & "' , stok = '" & NumericUpDown1.Value & "' where idbuku = " & id
                sql2 = "update kategoribuku_relasi set idkategori = '" & ComboBox1.SelectedValue & "' where idbuku =" & id
                exc(sql1)
                exc(sql2)
                'MsgBox(sql)
                MsgBox("Data berhasil diubah")
                awal()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        awal()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'button tambah
        clearForm(GroupBox2)
        buka()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'button ubah
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            aksi = True
            buka()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'button hapus
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            If dialog("Apakah anda yakin ingin menghapus?") Then
                Dim sql = "delete from buku where idbuku =" & id
                Dim sql1 = "delete from kategoribuku_relasi where idbuku =" & id
                'MsgBox(sql)
                exc(sql1)
                exc(sql)
                clearForm(GroupBox2)
                awal()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
            DateTimePicker1.Value = DataGridView1.Rows(e.RowIndex).Cells(6).Value
            ComboBox1.SelectedValue = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            NumericUpDown1.Value = DataGridView1.Rows(e.RowIndex).Cells(8).Value

            id = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class