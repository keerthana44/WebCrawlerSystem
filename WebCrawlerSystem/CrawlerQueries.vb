Imports System.Collections.ObjectModel
Imports System.Text
Imports System.Data.SQLite
Imports System.Data

Public Class CrawlerDetail

    Public Property ProjectName As String
    Public Property WebsiteUrl As String
    Public Property BrokenLinks As Integer
    Public Property TotalCrawled As Integer
    Public Property CrawlDate As Date
    Public Property CrawlID As Integer

End Class

Public Class CrawlerQueries
    Shared str As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData
    Private Shared ConnectionString As String = "Data Source=" & str & "\crawl.dat;Version=3;password=aysaj;"

    Public Shared Sub SaveCrawlerDetail(ByVal detail As CrawlerDetail)
        Dim query As New StringBuilder
        query.AppendLine("INSERT INTO CrawlerDetail (WebsiteUrl, ProjectName, BrokenLinks, TotalCrawled, CrawlDate) VALUES (@WebsiteUrl, @ProjectName, @BrokenLinks, @TotalCrawled, @CrawlDate)")

        Using conn As New SQLiteConnection(ConnectionString)
            conn.Open()
            Using cmd As New SQLiteCommand(query.ToString(), conn)
                cmd.Parameters.Add(New SQLiteParameter("@WebsiteUrl", detail.WebsiteUrl))
                cmd.Parameters.Add(New SQLiteParameter("@ProjectName", detail.ProjectName))
                cmd.Parameters.Add(New SQLiteParameter("@BrokenLinks", detail.BrokenLinks))
                cmd.Parameters.Add(New SQLiteParameter("@TotalCrawled", detail.TotalCrawled))
                cmd.Parameters.Add(New SQLiteParameter("@CrawlDate", detail.CrawlDate))

                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Function GetCrawlerDetails(ByVal websiteUrl As String) As Collection(Of CrawlerDetail)
        Dim query As New StringBuilder
        query.AppendLine("SELECT RowID, CrawlDate FROM CrawlerDetail WHERE WebsiteUrl=@WebsiteUrl")
        Dim dt As New DataTable

        Using conn As New SQLiteConnection(ConnectionString)
            Dim dap As New SQLiteDataAdapter(query.ToString, conn)
            dap.SelectCommand.Parameters.Add(New SQLiteParameter("@WebsiteUrl", websiteUrl))
            dap.Fill(dt)
        End Using

        Dim details As New Collection(Of CrawlerDetail)
        For Each row As DataRow In dt.Rows
            Dim item As New CrawlerDetail
            Dim dat As Date
            If Date.TryParse(row("CrawlDate") & "", dat) = True Then
                item.CrawlDate = dat
            End If
            item.CrawlID = Integer.Parse(row("RowID") & "")
        Next

        Return details
    End Function

    Public Shared Function GetCrawlerDetails() As Collection(Of CrawlerDetail)
        Dim query As New StringBuilder
        query.AppendLine("SELECT RowID, * FROM CrawlerDetail ORDER BY CrawlDate DESC")
        Dim dt As New DataTable

        Using conn As New SQLiteConnection(ConnectionString)
            Dim dap As New SQLiteDataAdapter(query.ToString, conn)
            dap.Fill(dt)
        End Using

        Dim details As New Collection(Of CrawlerDetail)
        For Each row As DataRow In dt.Rows
            Dim item As New CrawlerDetail
            Dim dat As Date
            If Date.TryParse(row("CrawlDate") & "", dat) = True Then
                item.CrawlDate = dat
            End If
            item.CrawlID = Integer.Parse(row("RowID") & "")
            Dim d As Double
            If Double.TryParse(row("TotalCrawled") & "", d) = True Then
                item.TotalCrawled = d
            End If
            If Double.TryParse(row("BrokenLinks") & "", d) = True Then
                item.BrokenLinks = d
            End If

            item.WebsiteUrl = row("WebsiteUrl") & ""
            item.ProjectName = row("ProjectName") & ""
            details.Add(item)
        Next

        Return details
    End Function

End Class