Imports System.Threading


Public Class ProjectItemControl

    Dim mCrawlDetail As New CrawlDetail

    Public Property ProjectName As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = mCrawlDetail
        ResultDataGrid.AutoGenerateColumns = False
    End Sub

    Private Sub btnStartSearch_Click(sender As Object, e As RoutedEventArgs) Handles btnStartSearch.Click
        Try
            mCrawlDetail = New CrawlDetail
            Me.DataContext = mCrawlDetail

            Dim url As String = txtSearchUrl.Text
            tbkCurrentStatus.Text = "Running"
            Dim th As New Thread(New ThreadStart(Sub()
                                                     Dim spider As New WebCrawler(url, url, 100)
                                                     'spider.WebPageManager.WebPageContentHandler = [Delegate].Combine(spider.WebPageManager.WebPageContentHandler, New WebPageContentDelegate(AddressOf spider_WebPageContentHandler))
                                                     spider.WebPageManager.WebPageTaskCompleted = New WebPageContentDelegate(AddressOf spider_WebPageContentHandler)
                                                     spider.Execute()

                                                     Dim lst = spider.WebPages.Values
                                                     Me.Dispatcher.Invoke(New Action(Sub()
                                                                                         tbkCurrentStatus.Text = "Completed"

                                                                                         Dim result As New CrawlerDetail
                                                                                         result.ProjectName = ProjectName
                                                                                         result.CrawlDate = Now
                                                                                         result.WebsiteUrl = url
                                                                                         result.TotalCrawled = mCrawlDetail.TotalCrawled
                                                                                         result.BrokenLinks = mCrawlDetail.TotalBrokenLink
                                                                                         CrawlerQueries.SaveCrawlerDetail(result)

                                                                                     End Sub))
                                                 End Sub))

            th.Start()

        Catch ex As Exception
            MessageBox.Show("Error")
        End Try


    End Sub



    Private Sub spider_WebPageContentHandler(ByVal state As WebPageStatus)
        Me.Dispatcher.Invoke(New Action(Sub()
                                            Dim detail As New CrawlPageDetail
                                            detail.WebsiteUrl = state.Uri.ToString
                                            detail.SerialNumber = mCrawlDetail.Pages.Count + 1
                                            detail.Status = state.StatusCode
                                            mCrawlDetail.Pages.Add(detail)

                                            mCrawlDetail.TotalCrawled += 1
                                            If state.TaskCompleted = False AndAlso state.TaskStarted = True Then
                                                mCrawlDetail.TotalBrokenLink += 1
                                            End If
                                        End Sub))
    End Sub

    Private Sub GoToHome()
        Dim win As MainWindow = Application.Current.MainWindow
        win.OpenHomeControl()
    End Sub

    Private Sub btnGoToHome_Click(sender As Object, e As RoutedEventArgs) Handles btnGoToHome.Click
        GoToHome()
    End Sub
End Class
