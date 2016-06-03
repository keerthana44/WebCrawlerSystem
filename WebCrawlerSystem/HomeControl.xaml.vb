Public Class HomeControl
    Private Sub btnBrokenLinkChecker_Click(sender As Object, e As RoutedEventArgs) Handles btnBrokenLinkChecker.Click
        Dim win As MainWindow = Application.Current.MainWindow
        win.OpenProjectControl()
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As RoutedEventArgs) Handles btnHistory.Click
        Dim win As MainWindow = Application.Current.MainWindow
        win.OpenHistoryControl()
    End Sub
End Class
