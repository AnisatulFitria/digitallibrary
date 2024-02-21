Public Class regristasi

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If adaKosong(GroupBox1) Then 'untuk mengecek textbox
            MsgBox("Ada data kosong")
        Else
            Dim sql 'untuk mempermudah
            sql = "insert into tbluser values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','User')"
            'MsgBox(sql) 'untuk mengecek syntax sudah benar atau kurang/salah
            exc(sql)
            MsgBox("Data berhasil ditambah")
            Me.Close()
        End If
    End Sub

    Private Sub regristasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clearForm(GroupBox1)
        Me.Close()
    End Sub
End Class