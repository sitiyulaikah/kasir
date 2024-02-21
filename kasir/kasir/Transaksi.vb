Public Class Transaksi

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id_penjualan = getValue("select top(1) * from penjualan order by id_penjualan desc", "id_penjualan")
        If adaKosong(GroupBox1) Then
            MsgBox("Data kosong")
        Else
            Dim sql = "update penjualan set total_harga = '" & TextBox2.Text & "', status = 1 where id_penjualan=" & id_penjualan
            Dim sql1 = "select top(0) * from vdetail"
            'MsgBox(sql)
            exc(sql)
            MsgBox("Pembayaran berhasil")
            Menu_Utama.getDetail_Penjualan()
            Menu_Pelanggan.getDetail_Penjualan()
            Menu_Utama.Label6.Text = 0
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            TextBox1.Text = "0"
        Else
            TextBox3.Text = Double.Parse(TextBox1.Text) - Double.Parse(TextBox2.Text)
        End If
    End Sub

    Private Sub Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TextBox2.Text = Menu_Utama.Label6.Text
        'TextBox2.Text = Menu_Pelanggan.Label6.Text
    End Sub
End Class