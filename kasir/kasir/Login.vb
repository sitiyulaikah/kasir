Public Class Login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Username atau Password Kosong")
        Else

            Dim sql = "select * from petugas where username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'"
            Dim sql1 = "select * from pelanggan where username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'"

            If getCount(sql) > 0 Then
                If getValue(sql, "level") = "Admin" Then
                    'MsgBox(getValue(sql, "nama_petugas"))
                    Menu_Utama.Lpetugas.Text = getValue(sql, "nama_petugas")
                    Menu_Utama.id_petugas = getValue(sql, "id_petugas")
                    Menu_Utama.MasterToolStripMenuItem.Visible = True
                    Menu_Utama.PetugasToolStripMenuItem.Visible = True
                    Menu_Utama.ProdukToolStripMenuItem.Visible = True
                    Menu_Utama.PelangganToolStripMenuItem.Visible = False
                    Menu_Utama.Show()
                    Me.Hide()
                    TextBox1.Clear()
                    TextBox2.Clear()
                ElseIf getValue(sql, "level") = "Petugas" Then
                    'MsgBox(getValue(sql, "namapetugas"))
                    Menu_Utama.Lpetugas.Text = getValue(sql, "nama_petugas")
                    Menu_Utama.id_petugas = getValue(sql, "id_petugas")
                    Menu_Utama.MasterToolStripMenuItem.Visible = True
                    Menu_Utama.PetugasToolStripMenuItem.Visible = False
                    Menu_Utama.ProdukToolStripMenuItem.Visible = False
                    Menu_Utama.PelangganToolStripMenuItem.Visible = True
                    Menu_Utama.Show()
                    Me.Hide()
                    TextBox1.Clear()
                    TextBox2.Clear()
                End If

            ElseIf getCount(sql1) > 0 Then
                'MsgBox(getValue(sql1, "namapelanggan"))
                Menu_Pelanggan.Lpetugas.Text = getValue(sql1, "nama_pelanggan")
                Menu_Pelanggan.id_pelanggan = getValue(sql1, "id_pelanggan")
                Menu_Pelanggan.Show()
                Me.Hide()
                TextBox1.Clear()
                TextBox2.Clear()
            Else
                MsgBox("Username atau Password Salah")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        Me.Close()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.UseSystemPasswordChar = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
End Class