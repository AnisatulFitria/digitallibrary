Public Class laporan

    Sub awal()
        DataGridView1.DataSource = getData("select * from vpeminjaman where namalengkap like '%" & TextBox1.Text & "%'")
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveFileDialog1.Filter = "Excel Files(*.xlsx)|*.xlsx"

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim xlaapp As Microsoft.Office.Interop.Excel.Application
            Dim xlworkbook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlworksheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim missvalue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlaapp = New Microsoft.Office.Interop.Excel.Application
            xlworkbook = xlaapp.Workbooks.Add(missvalue)
            xlworksheet = xlworkbook.Sheets("sheet1")

            For i = 0 To DataGridView1.RowCount - 1
                For j = 0 To DataGridView1.ColumnCount - 1
                    For k As Integer = 1 To DataGridView1.Columns.Count
                        xlworksheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
                        xlworksheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString
                    Next
                Next
            Next

            xlworksheet.SaveAs(SaveFileDialog1.FileName)
            xlworkbook.Close()
            xlaapp.Quit()

            relaseobject(xlaapp)
            relaseobject(xlworkbook)
            relaseobject(xlworksheet)

            MsgBox("Ekspor Berhasil")

        End If
    End Sub

    Private Sub relaseobject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub laporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub
End Class