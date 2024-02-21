Public Class Cari_Produk

    Sub awal()
        'untuk menampilkan data berdasarkan nama kolom & textbox = textbox yang digunakan cari
        DataGridView1.DataSource = getData("select * from produk where nama_produk like '%" & TextBox1.Text & "%'")
        '.visible untuk menghilangkan/hidden, headertext, untuk merubah nama kolom, false(menghilangkan) true(menampilkan)
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Nama Produk"
        DataGridView1.Columns(2).HeaderText = "Harga"
        DataGridView1.Columns(3).HeaderText = "Stok"
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Menu_Utama.TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            Menu_Utama.TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            Menu_Pelanggan.TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            Menu_Pelanggan.TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            Lproduk.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value

            Menu_Utama.id_produk = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            Menu_Pelanggan.id_produk = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub

    Private Sub Cari_Produk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
4:      awal()
    End Sub
End Class