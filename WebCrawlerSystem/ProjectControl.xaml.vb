Public Class ProjectControl


    Private Sub MainTabControl_TabItemAdded(sender As Object, e As Wpf.Controls.TabItemEventArgs)
        RequestProjectName(e)
    End Sub

    Private Sub ProjectControl_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        MainTabControl.AddTabItem()
        If MainTabControl.Items.Count = 0 Then
            GoToHome()
        End If
    End Sub

    Private Sub GoToHome()
        Dim win As MainWindow = Application.Current.MainWindow
        win.OpenHomeControl()
    End Sub

    Private Sub RequestProjectName(e As Wpf.Controls.TabItemEventArgs)
        Dim projectName As String = InputBox("Please Enter Project Name")
        If String.IsNullOrWhiteSpace(projectName) = False Then
            Dim item As TabItem = e.TabItem
            Dim project As New ProjectItemControl
            project.ProjectName = projectName
            item.Content = project
            item.Header = projectName
        Else
            MainTabControl.RemoveTabItem(e.TabItem)
        End If

    End Sub

End Class
