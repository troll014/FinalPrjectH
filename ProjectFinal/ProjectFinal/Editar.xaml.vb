Imports Microsoft.Win32
Imports MySql.Data.MySqlClient

Public Class Editar
    ' Aquí puedes hacer lo que necesites con los datos.
    ' Por ejemplo, podrías actualizar los datos en la base de datos.

    'Dim nombre As String = nombreTextBox.Text
    'Dim descripcion As String = descripcionTextBox.Text
    'Dim fecha As String = FechaTextBox.Text
    'Dim imagen As String = imagenTextBox.Text

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)

    End Sub

    ' Aquí debes agregar tu código para actualizar los datos.

    ' Luego, puedes mostrar un mensaje al usuario para confirmar que los cambios se han guardado.
    'MessageBox.Show("Los cambios han sido guardados.")
    Private Function ValidarCamposEditar() As Boolean
        Dim valido As Boolean = True

        ' Verificar si se seleccionó un registro
        'If Not listaDeRegistros.SelectedItem Then
        '    MessageBox.Show("Por favor, seleccione un registro para editar.")
        '    valido = False
        'End If

        ' Verificar el campo nombre
        If String.IsNullOrEmpty(nombreTextBox.Text) Then
            nombreTextBox.BorderBrush = Brushes.Red
            MessageBox.Show("El campo Nombre está vacío.")
            valido = False
        End If

        ' Verificar el campo descripción
        If String.IsNullOrEmpty(descripcionTextBox.Text) Then
            descripcionTextBox.BorderBrush = Brushes.Red
            MessageBox.Show("El campo Descripción está vacío.")
            valido = False
        End If

        ' Verificar el campo fecha
        If String.IsNullOrEmpty(FechaPicker.Text) Then
            FechaPicker.BorderBrush = Brushes.Red
            MessageBox.Show("El campo Fecha está vacío.")
            valido = False
        End If

        ' Verificar el campo imagen
        If String.IsNullOrEmpty(imagenTextBox.Text) Then
            imagenTextBox.BorderBrush = Brushes.Red
            MessageBox.Show("El campo Imagen está vacío.")
            valido = False
        End If

        Return valido
    End Function

    Private Sub nombreTextBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles nombreTextBox.TextChanged

    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

    End Sub
    Private Function ValidarCampos() As Boolean
        Dim valido As Boolean = True
        'Dim fecha As DateTime = FechaPicker.SelectedDate.Value

        'Dim fecha As DateTime
        ' Verificar el campo nombre
        If String.IsNullOrEmpty(nombreTextBox.Text) Then
            nombreTextBox.BorderBrush = Brushes.Red
            MessageBox.Show("El campo Nombre está vacío.")
            valido = False
        End If

        ' Verificar el campo descripción
        If String.IsNullOrEmpty(descripcionTextBox.Text) Then
            descripcionTextBox.BorderBrush = Brushes.Red
            MessageBox.Show("El campo Descripción está vacío.")
            valido = False
        End If

        ' Verificar el campo fecha
        'If Not DateTime.TryParseExact(FechaTextBox.Text, "dd-MM-yyyy",
        '                       System.Globalization.CultureInfo.InvariantCulture,
        '                       System.Globalization.DateTimeStyles.None,
        '                       fecha) Then
        '    FechaTextBox.BorderBrush = Brushes.Red
        '    MessageBox.Show("Por favor, introduce la fecha en el formato DD-MM-YYYY.")
        '    valido = False
        'Else
        ' Transformar la fecha al formato esperado por MySQL
        'Dim fechaMySQL = fecha.ToString("yyyy-MM-dd")
        'End If
        If FechaPicker.SelectedDate.HasValue Then
            Dim fecha As String = FechaPicker.SelectedDate.Value.ToString("yyyy-MM-dd")
            ' Usar 'fecha' para agregarla a la base de datos
        Else
            MessageBox.Show("Por favor, selecciona una fecha.")
        End If


        ' Verificar el campo imagen
        If String.IsNullOrEmpty(imagenTextBox.Text) Then
            imagenTextBox.BorderBrush = Brushes.Red
            MessageBox.Show("El campo Imagen está vacío.")
            valido = False
        End If

        Return valido
    End Function

    Private Sub CargarImagen_Click(sender As Object, e As RoutedEventArgs)
        Dim openFileDialog = New OpenFileDialog()
        openFileDialog.Filter = "Imágenes (*.jpg, *.png)|*.jpg;*.png"
        If openFileDialog.ShowDialog() = True Then
            imagenTextBox.Text = openFileDialog.FileName
            Try
                Dim bitmap = New BitmapImage(New Uri(imagenTextBox.Text, UriKind.Absolute))
                previewImage.Source = bitmap
            Catch ex As Exception
                ' Manejar el error (por ejemplo, la imagen no se pudo cargar)
                MessageBox.Show("No se pudo cargar la imagen. Asegúrate de que la ruta o URL es correcta.")
            End Try
        End If
    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        ' Verificar si los campos están vacíos
        If String.IsNullOrEmpty(nombreTextBox.Text) OrElse String.IsNullOrEmpty(descripcionTextBox.Text) OrElse FechaPicker.SelectedDate Is Nothing OrElse String.IsNullOrEmpty(imagenTextBox.Text) Then
            MessageBox.Show("Por favor, completa todos los campos.")
            Return
        End If

        Try
            ' Crear la conexión
            Using conn As New MySqlConnection("Server=localhost;Database=modelo_captacion_datos_fauna;Uid=root;Pwd=123789;")
                conn.Open()

                ' Comando SQL
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn

                ' Configurar el CommandText con tu consulta SQL
                Dim query As String = "UPDATE mi_tabla SET nombre = '" & nombreTextBox.Text & "', descripcion = '" & descripcionTextBox.Text & "', fecha = '" & FechaPicker.SelectedDate.Value.ToString("yyyy-MM-dd") & "', imagen = '" & imagenTextBox.Text & "' WHERE id = @id"
                Debug.WriteLine(query)

                cmd.CommandText = query
                'cmd.Parameters.AddWithValue("@id", idTextBox.Text)

                ' Ejecuta el comando
                cmd.ExecuteNonQuery()

                ' Borrar los campos
                nombreTextBox.Text = ""
                descripcionTextBox.Text = ""
                FechaPicker.SelectedDate = Nothing
                imagenTextBox.Text = ""
                previewImage.Source = Nothing

                ' Mostrar mensaje de éxito
                MessageBox.Show("Los datos se han actualizado correctamente.")
            End Using
        Catch ex As Exception
            ' Si algo sale mal, muestra un mensaje de error
            MessageBox.Show("Ocurrió un error al actualizar los datos: " & ex.Message)
        End Try
    End Sub
End Class
