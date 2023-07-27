Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Data

Public Class Explorar
    'Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

    '    Try
    '        Using conn As New MySqlConnection("Server=localhost;Database=modelo_captacion_datos_fauna;Uid=root;Pwd=123789;")
    '            conn.Open()

    '            ' Comando SQL
    '            Dim cmd As New MySqlCommand()
    '            cmd.Connection = conn

    '            cmd.CommandText = "SELECT * FROM mi_tabla WHERE nombre LIKE @nombre"
    '            cmd.Parameters.AddWithValue("@nombre", "%" & searchTextBox.Text & "%")


    '            ' Ejecuta el comando
    '            Dim adapter As New MySqlDataAdapter(cmd)
    '            Dim table As New DataTable()
    '            adapter.Fill(table)

    '            ' Asignar los resultados a tu DataGrid
    '            faunaDataGrid.ItemsSource = table.DefaultView
    '        End Using
    '    Catch ex As Exception
    '        ' Si algo sale mal, muestra un mensaje de error
    '        MessageBox.Show("Ocurrió un error al buscar los datos: " & ex.Message)
    '    End Try
    'End Sub
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Try
            Using conn As New MySqlConnection("Server=localhost;Database=modelo_captacion_datos_fauna;Uid=root;Pwd=123789;")
                conn.Open()

                ' Comando SQL
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn

                ' Configurar el CommandText con tu consulta SQL
                Dim id As Integer
                If Integer.TryParse(searchTextBox.Text, id) Then
                    ' si el contenido de searchTextBox puede convertirse en entero, busca por id
                    cmd.CommandText = "SELECT * FROM mi_tabla WHERE id = @id"
                    cmd.Parameters.AddWithValue("@id", id)
                Else
                    ' de lo contrario, busca por nombre
                    cmd.CommandText = "SELECT * FROM mi_tabla WHERE nombre LIKE @nombre"
                    cmd.Parameters.AddWithValue("@nombre", "%" & searchTextBox.Text & "%")
                End If

                ' Ejecuta el comando
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)

                ' Verificar si la consulta devolvió algún resultado
                If table.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron resultados con el ID o nombre proporcionado.")
                    Return
                End If

                ' Asignar los resultados a tu DataGrid
                faunaDataGrid.ItemsSource = table.DefaultView
            End Using
        Catch ex As Exception
            ' Si algo sale mal, muestra un mensaje de error
            MessageBox.Show("Ocurrió un error al buscar los datos: " & ex.Message)
        End Try
    End Sub







    Private Sub SearchTextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        Try
            Dim selectedFilter = DirectCast(FilterComboBox.SelectedItem, ComboBoxItem).Content.ToString()
            Dim viewSource = DirectCast(FindResource("itemCollectionViewSource"), CollectionViewSource)
            Dim view = CType(viewSource.View, ICollectionView)
            view.Filter = Function(item)
                              Dim row = DirectCast(item, DataRowView)
                              Select Case selectedFilter
                                  Case "Por ID"
                                      Dim id As Integer
                                      If Integer.TryParse(searchTextBox.Text, id) Then
                                          Return row("id") = id
                                      End If
                                      Return False
                                  Case "Por Nombre"
                                      Return row("nombre").ToString().Contains(searchTextBox.Text)
                                  Case "Alfabéticamente"
                                      ' Como no estamos filtrando en este caso, devolvemos `True` 
                                      ' para que todos los elementos pasen el filtro
                                      Return True
                                  Case Else
                                      Return True
                              End Select
                          End Function

            view.Refresh()

            ' Solo si seleccionaste "Alfabéticamente"
            If selectedFilter = "Alfabéticamente" Then
                CType(view, ListCollectionView).SortDescriptions.Clear()
                CType(view, ListCollectionView).SortDescriptions.Add(New SortDescription("nombre", ListSortDirection.Ascending))
            End If
        Catch ex As Exception
            MessageBox.Show("Error al filtrar los datos: " & ex.Message)
        End Try
    End Sub

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

    Private Sub faunaDataGrid_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles faunaDataGrid.SelectionChanged

    End Sub

    Private Sub FilterComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim selectedFilter = DirectCast(FilterComboBox.SelectedItem, ComboBoxItem).Content.ToString()
        Dim viewSource = DirectCast(FindResource("itemCollectionViewSource"), CollectionViewSource)
        Dim view = CType(viewSource.View, ListCollectionView) ' Asegúrate de usar ListCollectionView si quieres ordenar

        Select Case selectedFilter
            Case "Alfabéticamente"
                view.SortDescriptions.Clear()
                view.SortDescriptions.Add(New SortDescription("nombre", ListSortDirection.Ascending))
            Case Else
                view.SortDescriptions.Clear()
        End Select
    End Sub
End Class
