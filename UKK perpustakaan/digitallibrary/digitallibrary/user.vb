Public Class user
    Dim id = "0"
    Dim aksi = False

    Sub awal()
        DataGridView1.DataSource = getData("select * from tbluser where username like '%" & TextBox1.Text & "%'")
        clearForm(GroupBox2)
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Username"
        DataGridView1.Columns(2).HeaderText = "Password"
        DataGridView1.Columns(3).HeaderText = "Email"
        DataGridView1.Columns(4).HeaderText = "Nama Lengkap"
        DataGridView1.Columns(5).HeaderText = "Alamat"
        DataGridView1.Columns(6).HeaderText = "Level"
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
    Private Sub user_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedValue = 0
        awal()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'button simpan
        If adaKosong(GroupBox2) Then
            MsgBox("Ada data kosong")
        Else
            Dim sql
            If Not aksi Then
                sql = "insert into tbluser values('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & ComboBox1.Text & "')"
                'MsgBox(sql)
                exc(sql)
                MsgBox("Data berhasil ditambah")
                awal()
            Else
                sql = "update tbluser set username = '" & TextBox2.Text & "', password = '" & TextBox3.Text & "', email = '" & TextBox4.Text & "', namalengkap = '" & TextBox5.Text & "', alamat= '" & TextBox6.Text & "', level= '" & ComboBox1.Text & "' where iduser = " & id
                'MsgBox(sql)
                exc(sql)
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
                Dim sql = "delete from tbluser where iduser =" & id
                'MsgBox(sql)
                exc(sql)
                clearForm(GroupBox2)
                awal()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
            ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value

            id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class