Public Class Laporan
    Public aksi

    Sub awalUtama()
        DataGridView1.DataSource = getData("select id_detail, id_penjualan, id_produk, jumlah_produk, subtotal, nama_pelanggan, alamat, no_telp, tgl_penjualan, total_harga, id_pelanggan, nama_produk, harga, stok from vdetail where nama_pelanggan like '%" & TextBox1.Text & "%'")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Id Penjualan"
        DataGridView1.Columns(2).HeaderText = "Id Produk"
        DataGridView1.Columns(3).HeaderText = "Jumlah Produk"
        DataGridView1.Columns(4).HeaderText = "Subtotal"
        DataGridView1.Columns(5).HeaderText = "Nama Pelanggan"
        DataGridView1.Columns(6).HeaderText = "Alamat"
        DataGridView1.Columns(7).HeaderText = "No Telp"
        DataGridView1.Columns(8).HeaderText = "Tanggal Penjualan"
        DataGridView1.Columns(9).HeaderText = "Total"
        DataGridView1.Columns(10).HeaderText = "Id Pelanggan"
        DataGridView1.Columns(11).HeaderText = "Nama Produk"
        DataGridView1.Columns(12).HeaderText = "Harga"
        DataGridView1.Columns(13).HeaderText = "Stok"
    End Sub

    Sub awalPelanggan()
        DataGridView1.DataSource = getData("select id_detail, id_penjualan, id_produk, jumlah_produk, subtotal, nama_pelanggan, alamat, no_telp, tgl_penjualan, total_harga, id_pelanggan, nama_produk, harga, stok from vdetail where nama_pelanggan like '%" & TextBox1.Text & "%' and id_pelanggan = '" & Menu_Pelanggan.id_pelanggan & "'")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Id Penjualan"
        DataGridView1.Columns(2).HeaderText = "Id Produk"
        DataGridView1.Columns(3).HeaderText = "Jumlah Produk"
        DataGridView1.Columns(4).HeaderText = "Subtotal"
        DataGridView1.Columns(5).HeaderText = "Nama Pelanggan"
        DataGridView1.Columns(6).HeaderText = "Alamat"
        DataGridView1.Columns(7).HeaderText = "No Telp"
        DataGridView1.Columns(8).HeaderText = "Tanggal Penjualan"
        DataGridView1.Columns(9).HeaderText = "Total"
        DataGridView1.Columns(10).HeaderText = "Id Pelanggan"
        DataGridView1.Columns(11).HeaderText = "Nama Produk"
        DataGridView1.Columns(12).HeaderText = "Harga"
        DataGridView1.Columns(13).HeaderText = "Stok"
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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awalUtama()
        awalPelanggan()
    End Sub

    Private Sub Laporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(aksi)
        If aksi = True Then
            awalPelanggan()
        Else
            awalUtama()
        End If
    End Sub
End Class