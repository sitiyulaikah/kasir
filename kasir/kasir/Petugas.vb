Public Class Petugas
    Dim id = "0"
    Dim aksi = False

    Sub awal()
        'untuk menampilkan data berdasarkan nama kolom & textbox = textbox yang digunakan cari
        DataGridView1.DataSource = getData("select * from petugas where nama_petugas like '%" & TextBox5.Text & "%'")
        'untuk mewnghapus berdasarkan groupbox yang ada didalam kurung
        clearForm(GroupBox2)
        '.visible untuk menghilangkan/hidden, headertext, untuk merubah nama kolom, false(menghilangkan) true(menampilkan)
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Nama Petugas"
        DataGridView1.Columns(2).HeaderText = "Username"
        DataGridView1.Columns(3).HeaderText = "Password"
        DataGridView1.Columns(4).HeaderText = "Telp"
        'enabled(apakah dia bisa diakses)
        GroupBox1.Enabled = True
        GroupBox2.Enabled = False
        GroupBox3.Enabled = True
        'untuk me-refresh
        id = "0"
        aksi = False
    End Sub

    Sub buka() 'digunakan untuk mengisi/menambah/mengubah
        GroupBox1.Enabled = False
        GroupBox2.Enabled = True
        GroupBox3.Enabled = False
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            
            id = DataGridView1.Rows(e.RowIndex).Cells(0).Value 'untuk menampilkan data petugas
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        awal()
    End Sub

    Private Sub Petugas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If adaKosong(GroupBox2) Then
            MsgBox("Ada data kosong")
        Else
            Dim sql
            If Not aksi Then
                sql = "insert into petugas values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "')"
                'MsgBox(sql)
                exc(sql)
                MsgBox("Data berhasil ditambah")
                awal()
            Else
                sql = "update petugas set nama_petugas = '" & TextBox1.Text & "', username = '" & TextBox2.Text & "', password = '" & TextBox3.Text & "', no_telp = '" & TextBox4.Text & "', level = '" & ComboBox1.Text & "' where id_petugas = " & id
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
        clearForm(GroupBox2)
        buka()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            'untuk ubah aksi=true & kalo ditidak ubah aksi=false
            aksi = True
            buka()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            If dialog("Apakah anda yakin ingin menghapus?") Then
                Dim sql = "delete from petugas where id_petugas =" & id
                'MsgBox(sql)
                exc(sql) 'eksekusi/execut
                clearForm(GroupBox2)
                awal()
            End If
        End If
    End Sub
End Class
