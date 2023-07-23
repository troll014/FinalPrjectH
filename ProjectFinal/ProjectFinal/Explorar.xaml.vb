Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Explorar
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

        Try
            Using conn As New MySqlConnection("Server=localhost;Database=modelo_captacion_datos_fauna;Uid=root;Pwd=123789;")
                conn.Open()

                ' Comando SQL
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn

                ' Configurar el CommandText con tu consulta SQL
                cmd.CommandText = "SELECT * FROM mi_tabla WHERE nombre LIKE @nombre"
                cmd.Parameters.AddWithValue("@nombre", "%" & searchTextBox.Text & "%")

                ' Ejecuta el comando
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)

                ' Asignar los resultados a tu DataGrid
                faunaDataGrid.ItemsSource = table.DefaultView
            End Using
        Catch ex As Exception
            ' Si algo sale mal, muestra un mensaje de error
            MessageBox.Show("Ocurrió un error al buscar los datos: " & ex.Message)
        End Try
    End Sub

    Private Sub SearchTextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        ' Aquí puedes usar `searchTextBox` directamente. Por ejemplo:
        Dim text As String = searchTextBox.Text
        ' Haz algo con `text`...
    End Sub

End Class
