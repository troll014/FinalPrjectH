Imports System.Globalization
Imports Microsoft.Win32
Imports MySql.Data.MySqlClient

Public Class Agregar
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

    Private Sub nombreTextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        If String.IsNullOrEmpty(nombreTextBox.Text) Then
            nombreTextBox.BorderBrush = Brushes.Red
        Else
            nombreTextBox.ClearValue(Border.BorderBrushProperty)
        End If
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        'If ValidarCampos() Then
        '    ' Código para agregar el item
        'End If
        ' Recoger datos del formulario







        ' Primero, verifica si los campos son válidos
        If ValidarCampos() Then
            ' Crear la conexión
            Try
                Using conn As New MySqlConnection("Server=localhost;Database=modelo_captacion_datos_fauna;Uid=root;Pwd=123789;")
                    conn.Open()

                    ' Comando SQL
                    Dim cmd As New MySqlCommand()
                    cmd.Connection = conn

                    ' Configurar el CommandText con tu consulta SQL
                    cmd.CommandText = "INSERT INTO mi_tabla (nombre, descripcion, fecha, imagen) VALUES (@nombre, @descripcion, @fecha, @imagen)"
                    cmd.Parameters.AddWithValue("@nombre", nombreTextBox.Text)
                    cmd.Parameters.AddWithValue("@descripcion", descripcionTextBox.Text)
                    cmd.Parameters.AddWithValue("@fecha", FechaPicker.SelectedDate.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@imagen", imagenTextBox.Text)

                    ' Ejecuta el comando
                    cmd.ExecuteNonQuery()
                    ' Notificar al usuario que los datos se guardaron correctamente
                    MessageBox.Show("Los datos se han guardado correctamente en la base de datos.")
                    nombreTextBox.Text = String.Empty
                    descripcionTextBox.Text = String.Empty
                    FechaPicker.SelectedDate = Nothing
                    imagenTextBox.Text = String.Empty
                End Using
            Catch ex As Exception
                ' Si algo sale mal, muestra un mensaje de error
                MessageBox.Show("Ocurrió un error al guardar los datos: " & ex.Message)
            End Try


        End If
    End Sub
    Private Function ValidarCampos() As Boolean
        Dim valido As Boolean = True
        'Dim fecha As DateTime = FechaPicker.SelectedDate.Value

        'Dim fecha As DateTime
        ' Verificar el campo nombre

        If String.IsNullOrEmpty(IdTextBox.Text) Then
            IdTextBox.BorderBrush = Brushes.Red
            MessageBox.Show("El campo Nombre está vacío.")
            valido = False
        End If

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

    'Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
    '    'If ValidarCampos() Then
    '    '    ' Código para agregar el item
    '    'End If
    '    ' Recoger datos del formulario
    '    ' Primero, verifica si los campos son válidos
    '    If ValidarCampos() Then
    '        ' Crear la conexión
    '        Try
    '            Using conn As New MySqlConnection("Server=localhost;Database=modelo_captacion_datos_fauna;Uid=root;Pwd=123789;")
    '                conn.Open()

    '                ' Comando SQL
    '                Dim cmd As New MySqlCommand()
    '                cmd.Connection = conn

    '                ' Configurar el CommandText con tu consulta SQL
    '                cmd.CommandText = "INSERT INTO mi_tabla (id, nombre, descripcion, fecha, imagen) VALUES (@id, @nombre, @descripcion, @fecha, @imagen)"
    '                cmd.Parameters.AddWithValue("@id", IdTextBox.Text)
    '                cmd.Parameters.AddWithValue("@nombre", nombreTextBox.Text)
    '                cmd.Parameters.AddWithValue("@descripcion", descripcionTextBox.Text)
    '                cmd.Parameters.AddWithValue("@fecha", FechaPicker.SelectedDate.Value.ToString("yyyy-MM-dd"))
    '                cmd.Parameters.AddWithValue("@imagen", imagenTextBox.Text)
    '                System.Diagnostics.Debug.WriteLine(cmd.CommandText)


    '                ' Ejecuta el comando
    '                cmd.ExecuteNonQuery()
    '                ' Notificar al usuario que los datos se guardaron correctamente
    '                MessageBox.Show("Los datos se han guardado correctamente en la base de datos.")
    '                IdTextBox.Text = String.Empty
    '                nombreTextBox.Text = String.Empty
    '                descripcionTextBox.Text = String.Empty
    '                FechaPicker.SelectedDate = Nothing
    '                imagenTextBox.Text = String.Empty
    '            End Using
    '        Catch ex As Exception
    '            ' Si algo sale mal, muestra un mensaje de error
    '            MessageBox.Show("Ocurrió un error al guardar los datos: " & ex.Message)
    '        End Try


    '    End If
    'End Sub
    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        ' Verifica si los campos son válidos
        If ValidarCampos() Then
            Try
                Using conn As New MySqlConnection("Server=localhost;Database=modelo_captacion_datos_fauna;Uid=root;Pwd=123789;")
                    conn.Open()
                    Dim cmd As New MySqlCommand()
                    cmd.Connection = conn
                    Dim tableName As String = ""

                    If ExistingTableRadioButton.IsChecked Then
                        ' Obtén el nombre de la tabla del ComboBox
                        tableName = ExistingTableComboBox.SelectedItem.ToString()
                    ElseIf NewTableRadioButton.IsChecked Then
                        ' Obtén el nombre de la nueva tabla del TextBox
                        tableName = NewTableTextBox.Text
                        ' Configura el CommandText con tu consulta SQL para crear la nueva tabla
                        cmd.CommandText = $"CREATE TABLE {tableName} (id INT, nombre VARCHAR(255), descripcion VARCHAR(255), fecha DATE, imagen VARCHAR(255))"
                        cmd.ExecuteNonQuery()
                    End If

                    ' Configurar el CommandText con tu consulta SQL
                    cmd.CommandText = $"INSERT INTO {tableName} (id, nombre, descripcion, fecha, imagen) VALUES (@id, @nombre, @descripcion, @fecha, @imagen)"
                    cmd.Parameters.AddWithValue("@id", IdTextBox.Text)
                    cmd.Parameters.AddWithValue("@nombre", nombreTextBox.Text)
                    cmd.Parameters.AddWithValue("@descripcion", descripcionTextBox.Text)
                    cmd.Parameters.AddWithValue("@fecha", FechaPicker.SelectedDate.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@imagen", imagenTextBox.Text)

                    ' Ejecuta el comando
                    cmd.ExecuteNonQuery()

                    ' Notificar al usuario que los datos se guardaron correctamente
                    MessageBox.Show("Los datos se han guardado correctamente en la base de datos.")
                    IdTextBox.Text = String.Empty
                    nombreTextBox.Text = String.Empty
                    descripcionTextBox.Text = String.Empty
                    FechaPicker.SelectedDate = Nothing
                    imagenTextBox.Text = String.Empty
                End Using
            Catch ex As Exception
                ' Si algo sale mal, muestra un mensaje de error
                MessageBox.Show("Ocurrió un error al guardar los datos: " & ex.Message)
            End Try
        End If
    End Sub





    Private Sub ExistingTableRadioButton_Checked(sender As Object, e As RoutedEventArgs)
        ' Deshabilitar el TextBox para la nueva tabla y habilitar el ComboBox para la tabla existente
        NewTableTextBox.IsEnabled = False
        ExistingTableComboBox.IsEnabled = True
    End Sub

    Private Sub NewTableRadioButton_Checked(sender As Object, e As RoutedEventArgs)
        ' Habilita el TextBox para el nombre de la nueva tabla
        NewTableTextBox.IsEnabled = True
        ExistingTableComboBox.IsEnabled = False
    End Sub

    Private Sub ExistingTableComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ExistingTableComboBox.SelectionChanged
        Dim conn As New MySqlConnection("Server=localhost;Database=modelo_captacion_datos_fauna;Uid=root;Pwd=123789;")
        conn.Open()

        Dim cmd As New MySqlCommand("SHOW TABLES", conn)

        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()
            ExistingTableComboBox.Items.Add(reader(0).ToString())
        End While

        conn.Close()

    End Sub
    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        Dim conn As New MySqlConnection("Server=localhost;Database=modelo_captacion_datos_fauna;Uid=root;Pwd=123789;")
        conn.Open()

        Dim cmd As New MySqlCommand("SHOW TABLES", conn)

        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        ExistingTableComboBox.Items.Clear()  ' Limpiar los items antes de llenar el ComboBox

        While reader.Read()
            ExistingTableComboBox.Items.Add(reader(0).ToString())
        End While

        conn.Close()
    End Sub

End Class
