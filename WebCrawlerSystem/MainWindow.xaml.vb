Class MainWindow

    Dim SelectedProjectControl As New ProjectControl
    Dim SelectedHistoryControl As New ReportUserControl


    Public Sub OpenProjectControl()
        MainBorder.Child = SelectedProjectControl
    End Sub

    Public Sub OpenHistoryControl()
        MainBorder.Child = SelectedHistoryControl
    End Sub

    Public Sub OpenHomeControl()
        MainBorder.Child = New HomeControl
    End Sub
End Class
