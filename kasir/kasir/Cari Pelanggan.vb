Public Class Cari_Pelanggan
    Dim id_pelanggan

    Sub awal()
        'untuk menampilkan data berdasarkan nama kolom & textbox = textbox yang digunakan cari
        DataGridView1.DataSource = getData("select * from pelanggan where nama_pelanggan like '%" & TextBox1.Text & "%'")
        '.visible untuk menghilangkan/hidden, headertext, untuk merubah nama kolom, false(menghilangkan) true(menampilkan)
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Nama Pelanggan"
        DataGridView1.Columns(2).HeaderText = "Alamat"
        DataGridView1.Columns(3).HeaderText = "No Telp"
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Menu_Utama.TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            LPelanggan.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value

            id_pelanggan = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Cari_Pelanggan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If LPelanggan.Text = "" Then
            MsgBox("Pelanggan Kosong")
        Else
            Dim sql = "insert into penjualan values ('" & Date.Now.ToString("yyyy/MM/dd") & "',0,'" & id_pelanggan & "',0)"
            'MsgBox(sql)
            exc(sql)
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub
End Class