Imports System.Net

Class MainWindow

    Dim AgregarForm As New Agregar
    Private PreviousButton As Button = Nothing
    Private _lastButton As Button


    Public Sub New()
        InitializeComponent()

    End Sub
    Private Sub Window_MouseLeftButtonDown(sender As Object, e As System.Windows.Input.MouseButtonEventArgs)
        DragMove()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        If _lastButton IsNot Nothing Then
            _lastButton.Background = Brushes.Transparent
        End If

        ' Cambiar el fondo del botón actual a #ADD8E6 y hacer que sea el último botón seleccionado
        Dim button As Button = CType(sender, Button)
        button.Background = New SolidColorBrush(CType(ColorConverter.ConvertFromString("#ADD8E6"), Color))
        _lastButton = button
        ' Navega a la nueva página.
        MainContent.Navigate(New Agregar())


    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        If _lastButton IsNot Nothing Then
            _lastButton.Background = Brushes.Transparent
        End If

        ' Cambiar el fondo del botón actual a #ADD8E6 y hacer que sea el último botón seleccionado
        Dim button As Button = CType(sender, Button)
        button.Background = New SolidColorBrush(CType(ColorConverter.ConvertFromString("#ADD8E6"), Color))
        _lastButton = button
        MainContent.Navigate(New Editar())
        EditarButton.Background = New SolidColorBrush(CType(ColorConverter.ConvertFromString("#ADD8E6"), Color))
    End Sub

    Private Sub EliminarButton_Click(sender As Object, e As RoutedEventArgs)
        If _lastButton IsNot Nothing Then
            _lastButton.Background = Brushes.Transparent
        End If

        ' Cambiar el fondo del botón actual a #ADD8E6 y hacer que sea el último botón seleccionado
        Dim button As Button = CType(sender, Button)
        button.Background = New SolidColorBrush(CType(ColorConverter.ConvertFromString("#ADD8E6"), Color))
        _lastButton = button
        MainContent.Navigate(New Eliminar())
        EliminarButton.Background = New SolidColorBrush(CType(ColorConverter.ConvertFromString("#ADD8E6"), Color))
    End Sub

    Private Sub ExplorarButton_Click(sender As Object, e As RoutedEventArgs)
        If _lastButton IsNot Nothing Then
            _lastButton.Background = Brushes.Transparent
        End If

        ' Cambiar el fondo del botón actual a #ADD8E6 y hacer que sea el último botón seleccionado
        Dim button As Button = CType(sender, Button)
        button.Background = New SolidColorBrush(CType(ColorConverter.ConvertFromString("#ADD8E6"), Color))
        _lastButton = button
        MainContent.Navigate(New Explorar())
        ExplorarButton.Background = New SolidColorBrush(CType(ColorConverter.ConvertFromString("#ADD8E6"), Color))
    End Sub

    Private Sub ConfiguracionButton_Click(sender As Object, e As RoutedEventArgs)
        If _lastButton IsNot Nothing Then
            _lastButton.Background = Brushes.Transparent
        End If

        ' Cambiar el fondo del botón actual a #ADD8E6 y hacer que sea el último botón seleccionado
        Dim button As Button = CType(sender, Button)
        button.Background = New SolidColorBrush(CType(ColorConverter.ConvertFromString("#ADD8E6"), Color))
        _lastButton = button
        MainContent.Navigate(New Configuracion())
        ConfiguracionButton.Background = New SolidColorBrush(CType(ColorConverter.ConvertFromString("#ADD8E6"), Color))
    End Sub
    Private Sub Minimize_Click(sender As Object, e As RoutedEventArgs)
        Me.WindowState = WindowState.Minimized
    End Sub

    Private Sub Close_Click(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub
End Class
