Imports MySql.Data.MySqlClient

Class Eliminar

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim id As Integer

        If Not Integer.TryParse(IdTextBox.Text, id) Then
            MessageBox.Show("Por favor ingresa una ID válida.")
            Return
        End If

        If MessageBox.Show("¿Está seguro de que desea eliminar este registro?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) = MessageBoxResult.Yes Then
            ' Crear la conexión
            Try
                Using conn As New MySqlConnection("Server=localhost;Database=modelo_captacion_datos_fauna;Uid=root;Pwd=123789;")
                    conn.Open()

                    ' Comando SQL
                    Dim cmd As New MySqlCommand()
                    cmd.Connection = conn

                    ' Configurar el CommandText con tu consulta SQL
                    cmd.CommandText = "DELETE FROM mi_tabla WHERE id = @id"
                    cmd.Parameters.AddWithValue("@id", id)

                    ' Ejecuta el comando
                    cmd.ExecuteNonQuery()

                    ' Notificar al usuario que los datos se han eliminado correctamente
                    MessageBox.Show("Los datos se han eliminado correctamente de la base de datos.")

                End Using
            Catch ex As Exception
                ' Si algo sale mal, muestra un mensaje de error
                MessageBox.Show("Ocurrió un error al eliminar los datos: " & ex.Message)
            End Try
        End If
    End Sub
    'Private Function ValidarEliminar() As Boolean
    '    Dim valido As Boolean = True

    '' Verificar que un registro está seleccionado
    'If dataGridRegistros.SelectedItem Is Nothing Then
    '    MessageBox.Show("Por favor, seleccione un registro para eliminar.")
    '    valido = False
    'End If

    '' Verificar que el nombre ingresado es el mismo que el del registro seleccionado
    'Dim registroSeleccionado = CType(dataGridRegistros.SelectedItem, TuTipoDeRegistro) ' Reemplaza "TuTipoDeRegistro" con el tipo de los registros en tu data grid
    'If nombreTextBox.Text <> registroSeleccionado.Nombre Then ' Reemplaza "Nombre" con el nombre de la propiedad del registro que contiene el nombre
    '    MessageBox.Show("El nombre ingresado no coincide con el del registro seleccionado.")
    '    valido = False
    'End If

    'Return valido
    'End Function

    'Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
    '    If ValidarEliminar() Then
    '        ' Código para eliminar el registro
    '    End If
    'End Sub
    Private Sub LoadTablesIntoComboBox()
        ' Crea una nueva conexión con la base de datos
        Using conn As New MySqlConnection("Server=localhost;Database=modelo_captacion_datos_fauna;Uid=root;Pwd=123789;")
            conn.Open()

            ' Comando SQL para obtener todos los nombres de tabla
            Dim cmd As New MySqlCommand("SHOW TABLES", conn)

            ' Ejecuta el comando y obtén los resultados
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            ' Limpia el ComboBox antes de llenarlo
            ExistingTableComboBox.Items.Clear()

            ' Agrega cada nombre de tabla al ComboBox
            While reader.Read()
                ExistingTableComboBox.Items.Add(reader(0).ToString())
            End While
        End Using
    End Sub

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        ' Cargar todas las tablas en el ComboBox al cargar la página
        LoadTablesIntoComboBox()
    End Sub

End Class
