Imports MySqlConnector

Public Class Form1


    Dim totalBayar As Integer = 0
    Dim hargaBarang As New Dictionary(Of String, Integer)

    Dim conn As New MySqlConnection(
        "server=localhost;user id=root;password=;database=kasir_laptop")


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBarang()

        txtTotal.Text = "Rp 0"

        lstBelanja.Columns.Clear()
        lstBelanja.Columns.Add("Item", "Item")
        lstBelanja.Columns.Add("Qty", "Qty")
        lstBelanja.Columns.Add("Harga", "Harga")
        lstBelanja.Columns.Add("Subtotal", "Subtotal")
        lstBelanja.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub


    Sub LoadBarang()
        Dim dt As DataTable = DatabaseHelper.GetBarang()

        cmbBarang.Items.Clear()
        hargaBarang.Clear()

        For Each row As DataRow In dt.Rows
            Dim nama As String = row("nama_barang").ToString()
            Dim harga As Integer = Convert.ToInt32(row("harga"))

            cmbBarang.Items.Add(nama)
            hargaBarang.Add(nama, harga)
        Next
    End Sub



    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If cmbBarang.SelectedIndex = -1 Or txtQty.Text = "" Then
            MessageBox.Show("Pilih barang dan isi quantity!")
            Return
        End If

        Dim qty As Integer
        If Not Integer.TryParse(txtQty.Text, qty) Or qty <= 0 Then
            MessageBox.Show("Quantity harus angka!")
            Return
        End If

        Dim namaBarang As String = cmbBarang.Text
        Dim harga As Integer = hargaBarang(namaBarang)
        Dim subtotal As Integer = harga * qty

        lstBelanja.Rows.Add(
            namaBarang,
            qty,
            "Rp " & harga.ToString("N0"),
            "Rp " & subtotal.ToString("N0")
        )

        totalBayar += subtotal
        txtTotal.Text = "Rp " & totalBayar.ToString("N0")

        txtQty.Clear()
        cmbBarang.SelectedIndex = -1
    End Sub


    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        If totalBayar = 0 Then
            MessageBox.Show("Belum ada transaksi!")
        Else
            MessageBox.Show("Total bayar: Rp " & totalBayar.ToString("N0"))
        End If
    End Sub


    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If lstBelanja.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk disimpan.")
            Return
        End If

        Try
            conn.Open()


            Dim cmdTrans As New MySqlCommand(
                "INSERT INTO transaksi (total) VALUES (@total)", conn)
            cmdTrans.Parameters.AddWithValue("@total", totalBayar)
            cmdTrans.ExecuteNonQuery()

            Dim idTransaksi As Integer =
    DatabaseHelper.InsertTransaksi(totalBayar)

            For Each row As DataGridViewRow In lstBelanja.Rows
                If row.Cells("Item").Value Is Nothing Then Continue For
                Dim namaBarang As String = row.Cells("Item").Value
                Dim qty As Integer = row.Cells("Qty").Value
                Dim harga As Integer = hargaBarang(namaBarang)

                DatabaseHelper.InsertDetailTransaksi(
        idTransaksi,
        namaBarang,
        qty,
        harga)
            Next


            conn.Close()

            MessageBox.Show("Transaksi berhasil disimpan!")

            lstBelanja.Rows.Clear()
            totalBayar = 0
            txtTotal.Text = "Rp 0"

        Catch ex As Exception
            MessageBox.Show("Gagal simpan: " & ex.Message)
            conn.Close()
        End Try
    End Sub


    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        If lstBelanja.SelectedRows.Count > 0 Then
            lstBelanja.Rows.RemoveAt(lstBelanja.SelectedRows(0).Index)
            HitungUlangTotal()
        End If
    End Sub

    Private Sub btnBatalkanSemua_Click(sender As Object, e As EventArgs) Handles btnBatalkanSemua.Click
        lstBelanja.Rows.Clear()
        totalBayar = 0
        txtTotal.Text = "Rp 0"
    End Sub

    Sub HitungUlangTotal()
        totalBayar = 0

        For Each row As DataGridViewRow In lstBelanja.Rows
            Dim teks As String = row.Cells("Subtotal").Value.ToString().
                Replace("Rp", "").Replace(".", "").Replace(",", "").Trim()

            Dim nilai As Integer
            If Integer.TryParse(teks, nilai) Then
                totalBayar += nilai
            End If
        Next

        txtTotal.Text = "Rp " & totalBayar.ToString("N0")
    End Sub

End Class