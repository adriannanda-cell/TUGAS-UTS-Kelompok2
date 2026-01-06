Imports MySqlConnector
Imports System.Data


Public Class DatabaseHelper

    Private Shared ReadOnly connectionString As String =
        "Server=localhost;" &
        "Database=kasir_laptop;" &
        "User Id=root;" &
        "Password=;" &
        "Port=3306;"

    Public Shared Function GetConnection() As MySqlConnection
        Return New MySqlConnection(connectionString)
    End Function

    Public Shared Sub OpenConnection(conn As MySqlConnection)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

    Public Shared Sub CloseConnection(conn As MySqlConnection)
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Public Shared Function GetBarang() As DataTable
        Dim dt As New DataTable()

        Using conn As MySqlConnection = GetConnection()
            OpenConnection(conn)

            Dim query As String = "SELECT nama_barang, harga FROM barang"
            Using cmd As New MySqlCommand(query, conn)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    Public Shared Function InsertTransaksi(total As Integer) As Integer
        Using conn As MySqlConnection = GetConnection()
            OpenConnection(conn)

            Dim query As String =
                "INSERT INTO transaksi (total) VALUES (@total);
                 SELECT LAST_INSERT_ID();"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@total", total)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    ' =========================
    ' SIMPAN DETAIL TRANSAKSI
    ' =========================
    Public Shared Sub InsertDetailTransaksi(
        idTransaksi As Integer,
        namaBarang As String,
        qty As Integer,
        harga As Integer)

        Using conn As MySqlConnection = GetConnection()
            OpenConnection(conn)

            Dim query As String =
                "INSERT INTO detail_transaksi
                (id_transaksi, id_barang, qty, harga, subtotal)
                VALUES (
                    @idtrans,
                    (SELECT id_barang FROM barang WHERE nama_barang=@barang),
                    @qty, @harga, @subtotal)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@idtrans", idTransaksi)
                cmd.Parameters.AddWithValue("@barang", namaBarang)
                cmd.Parameters.AddWithValue("@qty", qty)
                cmd.Parameters.AddWithValue("@harga", harga)
                cmd.Parameters.AddWithValue("@subtotal", qty * harga)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class