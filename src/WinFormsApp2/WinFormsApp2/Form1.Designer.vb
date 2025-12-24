<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1


    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtProduk = New Label()
        btnTambah = New Button()
        txtQty = New TextBox()
        lstBelanja = New DataGridView()
        Label2 = New Label()
        btnBatal = New Button()
        btnSimpan = New Button()
        btnBayar = New Button()
        btnBatalkanSemua = New Button()
        txtTotal = New TextBox()
        cmbBarang = New ComboBox()
        Quantity = New Label()
        Label3 = New Label()
        CType(lstBelanja, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtProduk
        ' 
        txtProduk.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtProduk.Location = New Point(241, 50)
        txtProduk.Name = "txtProduk"
        txtProduk.Size = New Size(118, 32)
        txtProduk.TabIndex = 0
        txtProduk.Text = "Pilih Barang"
        ' 
        ' btnTambah
        ' 
        btnTambah.Location = New Point(580, 81)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(107, 35)
        btnTambah.TabIndex = 1
        btnTambah.Text = "Tambah"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' txtQty
        ' 
        txtQty.Location = New Point(429, 81)
        txtQty.Multiline = True
        txtQty.Name = "txtQty"
        txtQty.Size = New Size(116, 35)
        txtQty.TabIndex = 2
        ' 
        ' lstBelanja
        ' 
        lstBelanja.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        lstBelanja.Location = New Point(183, 161)
        lstBelanja.Name = "lstBelanja"
        lstBelanja.RowHeadersWidth = 51
        lstBelanja.Size = New Size(377, 188)
        lstBelanja.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(183, 135)
        Label2.Name = "Label2"
        Label2.Size = New Size(125, 23)
        Label2.TabIndex = 4
        Label2.Text = "Daftar Belanja"
        ' 
        ' btnBatal
        ' 
        btnBatal.Location = New Point(183, 423)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New Size(187, 51)
        btnBatal.TabIndex = 6
        btnBatal.Text = "Batalkan"
        btnBatal.UseVisualStyleBackColor = True
        ' 
        ' btnSimpan
        ' 
        btnSimpan.Location = New Point(580, 304)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(164, 47)
        btnSimpan.TabIndex = 7
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = True
        ' 
        ' btnBayar
        ' 
        btnBayar.Location = New Point(183, 371)
        btnBayar.Name = "btnBayar"
        btnBayar.Size = New Size(377, 46)
        btnBayar.TabIndex = 9
        btnBayar.Text = "Bayar"
        btnBayar.UseVisualStyleBackColor = True
        ' 
        ' btnBatalkanSemua
        ' 
        btnBatalkanSemua.Location = New Point(376, 423)
        btnBatalkanSemua.Name = "btnBatalkanSemua"
        btnBatalkanSemua.Size = New Size(184, 51)
        btnBatalkanSemua.TabIndex = 10
        btnBatalkanSemua.Text = "Batalkan Semua"
        btnBatalkanSemua.UseVisualStyleBackColor = True
        ' 
        ' txtTotal
        ' 
        txtTotal.Location = New Point(580, 243)
        txtTotal.Multiline = True
        txtTotal.Name = "txtTotal"
        txtTotal.Size = New Size(164, 45)
        txtTotal.TabIndex = 11
        ' 
        ' cmbBarang
        ' 
        cmbBarang.AutoCompleteMode = AutoCompleteMode.Suggest
        cmbBarang.FormattingEnabled = True
        cmbBarang.Items.AddRange(New Object() {"Option 1", "Option 2", "Option 3"})
        cmbBarang.Location = New Point(209, 85)
        cmbBarang.Name = "cmbBarang"
        cmbBarang.Size = New Size(177, 28)
        cmbBarang.TabIndex = 12
        ' 
        ' Quantity
        ' 
        Quantity.AutoSize = True
        Quantity.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Quantity.Location = New Point(447, 52)
        Quantity.Name = "Quantity"
        Quantity.Size = New Size(80, 23)
        Quantity.TabIndex = 13
        Quantity.Text = "Quantity"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(580, 215)
        Label3.Name = "Label3"
        Label3.Size = New Size(59, 25)
        Label3.TabIndex = 14
        Label3.Text = "Total:"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 500)
        Controls.Add(Label3)
        Controls.Add(Quantity)
        Controls.Add(cmbBarang)
        Controls.Add(txtTotal)
        Controls.Add(btnBatalkanSemua)
        Controls.Add(btnBayar)
        Controls.Add(btnSimpan)
        Controls.Add(btnBatal)
        Controls.Add(Label2)
        Controls.Add(lstBelanja)
        Controls.Add(txtQty)
        Controls.Add(btnTambah)
        Controls.Add(txtProduk)
        Name = "Form1"
        Text = "Kasir Laptop"
        CType(lstBelanja, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtProduk As Label
    Friend WithEvents btnTambah As Button
    Friend WithEvents txtQty As TextBox
    Friend WithEvents lstBelanja As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnBayar As Button
    Friend WithEvents btnBatalkanSemua As Button
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents cmbBarang As ComboBox
    Friend WithEvents Quantity As Label
    Friend WithEvents Label3 As Label
End Class

