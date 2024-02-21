Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.UseSystemPasswordChar = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql = "select * from tbluser where username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'"
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Username atau Password salah")
        Else
            If getCount(sql) = 0 Then
                MsgBox("Username atau Password salah")
            Else
                If getValue(sql, "level") = "Admin" Then
                    'MsgBox(getValue(sql, "namapetugas"))
                    menu_utama.Luser.Text = getValue(sql, "namalengkap")
                    menu_utama.iduser = getValue(sql, "iduser")
                    koleksi_pribadi.id = getValue(sql, "iduser")
                    menu_utama.PustakawanToolStripMenuItem.Visible = True
                    menu_utama.BukuToolStripMenuItem.Visible = True
                    menu_utama.AnggotaToolStripMenuItem.Visible = True
                    menu_utama.StatusToolStripMenuItem.Visible = True
                    menu_utama.LaporanToolStripMenuItem.Visible = False
                    menu_utama.GroupBox1.Visible = False
                    menu_utama.Button2.Visible = False
                    menu_utama.PengembalianToolStripMenuItem.Visible = False
                    menu_utama.Show()
                    Me.Hide()
                    TextBox1.Clear()
                    TextBox2.Clear()
                ElseIf getValue(sql, "level") = "Petugas" Then
                    'MsgBox(getValue(sql, "namapetugas"))
                    menu_utama.Luser.Text = getValue(sql, "namalengkap")
                    menu_utama.iduser = getValue(sql, "iduser")
                    koleksi_pribadi.id = getValue(sql, "iduser")
                    menu_utama.PustakawanToolStripMenuItem.Visible = True
                    menu_utama.BukuToolStripMenuItem.Visible = True
                    menu_utama.AnggotaToolStripMenuItem.Visible = False
                    menu_utama.StatusToolStripMenuItem.Visible = True
                    menu_utama.LaporanToolStripMenuItem.Visible = False
                    menu_utama.Show()
                    Me.Hide()
                    TextBox1.Clear()
                    TextBox2.Clear()
                ElseIf getValue(sql, "level") = "User" Then
                    'MsgBox(getValue(sql, "namapetugas"))
                    menu_user.Luser.Text = getValue(sql, "namalengkap")
                    menu_user.iduser = getValue(sql, "iduser")
                    koleksi_pribadi.id = getValue(sql, "iduser")
                    menu_user.Show()
                    Me.Hide()
                    TextBox1.Clear()
                    TextBox2.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        regristasi.ShowDialog()
    End Sub
End Class
