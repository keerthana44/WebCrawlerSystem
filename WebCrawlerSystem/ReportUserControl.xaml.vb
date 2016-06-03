Public Class ReportUserControl
    Private Sub btnGoToHome_Click(sender As Object, e As RoutedEventArgs) Handles btnGoToHome.Click
        GoToHome()
    End Sub

    Private Sub ReportUserControl_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If IsVisible = True Then
            ReportDataGrid.ItemsSource = CrawlerQueries.GetCrawlerDetails
        End If
    End Sub

    Private Sub GoToHome()
        Dim win As MainWindow = Application.Current.MainWindow
        win.OpenHomeControl()
    End Sub
End Class
