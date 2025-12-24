Partial Public Class Form1

    Dim totalBayar As Integer = 0
    Dim hargaBarang As New Dictionary(Of String, Integer)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hargaBarang.Add("Laptop Asus", 7000000)
        hargaBarang.Add("Laptop Acer", 7500000)
        hargaBarang.Add("Laptop Lenovo", 8500000)
        hargaBarang.Add("Laptop HP", 7800000)

        cmbBarang.Items.Clear()
        cmbBarang.Items.AddRange(hargaBarang.Keys.ToArray())

        txtTotal.Text = "Rp 0"

        ' Setup DataGridView columns
        lstBelanja.Columns.Clear()
        lstBelanja.Columns.Add("Item", "Item")
        lstBelanja.Columns.Add("Qty", "Qty")
        lstBelanja.Columns.Add("Harga", "Harga")
        lstBelanja.Columns.Add("Subtotal", "Subtotal")
        lstBelanja.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If String.IsNullOrWhiteSpace(cmbBarang.Text) Or String.IsNullOrWhiteSpace(txtQty.Text) Then
            MessageBox.Show("Pilih barang dan masukkan quantity!")
            Return
        End If

        Dim qty As Integer
        If Not Integer.TryParse(txtQty.Text, qty) OrElse qty <= 0 Then
            MessageBox.Show("Quantity harus angka positif!")
            Return
        End If

        If Not hargaBarang.ContainsKey(cmbBarang.Text) Then
            MessageBox.Show("Barang tidak dikenal.")
            Return
        End If

        Dim harga = hargaBarang(cmbBarang.Text)
        Dim subTotal = harga * qty

        lstBelanja.Rows.Add(cmbBarang.Text, qty.ToString(), "Rp " & harga.ToString("N0"), "Rp " & subTotal.ToString("N0"))

        totalBayar += subTotal
        txtTotal.Text = "Rp " & totalBayar.ToString("N0")

        txtQty.Clear()
        cmbBarang.SelectedIndex = -1
    End Sub

    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        If totalBayar = 0 Then
            MessageBox.Show("Belum ada transaksi!")
        Else
            MessageBox.Show("Total yang harus dibayar: Rp " & totalBayar.ToString("N0"))
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If lstBelanja.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada transaksi untuk disimpan.")
            Return
        End If

        Dim transaksiDetails = String.Join(Environment.NewLine, lstBelanja.Rows.Cast(Of DataGridViewRow)().
            Select(Function(r) String.Format("{0} x{1} = {2}", r.Cells("Item").Value, r.Cells("Qty").Value, r.Cells("Subtotal").Value)))
        MessageBox.Show("Data transaksi berhasil disimpan" & Environment.NewLine & transaksiDetails)
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

    Private Sub HitungUlangTotal()
        totalBayar = 0
        For Each row As DataGridViewRow In lstBelanja.Rows
            Dim cell = row.Cells("Subtotal").Value
            If cell IsNot Nothing Then
                Dim text = cell.ToString().Replace("Rp", "").Replace(" ", "").Replace(",", "")
                Dim val As Integer
                If Integer.TryParse(text, val) Then
                    totalBayar += val
                End If
            End If
        Next
        txtTotal.Text = "Rp " & totalBayar.ToString("N0")
    End Sub

End Class