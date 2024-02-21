Public Class beri_ulasan
    Dim id
    Dim sql
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sql = "insert into ulasanbuku values ('" & pengembalian.iduser & "','" & pengembalian.idbuku & "','" & TextBox2.Text & "', '" & TextBox3.Text & "')"
        'MsgBox(sql)
        exc(sql)
        MsgBox("Buku telah diberi ulasan")
        Me.Close()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        onlyNumber(e)
    End Sub
End Class