Imports System
Imports System.Collections
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Net
Imports Mf.Util

Public Class WebCrawler
    Private mStartUri As Uri
    Private mBaseUri As Uri
    Private mMaximumUrlAllowed As Integer
    Private mUrlCrawledCount As Integer
    Private mKeepWebContent As Boolean

    Private m_webPagesPending As Queue
    Private mWebPages As Hashtable
    Private mWebPageManager As WebPageManager

    'Private Shared mValidExtensions() As String = {"html", "aspx", "php", "asp", "htm", "jsp", "shtml"}
    Private Shared mValidExtensions() As String = {"html", "php", "asp", "htm", "jsp", "shtml", "php3", "aspx", "pl", "cfm"}
    '

    Public Property WebPageManager() As WebPageManager
        Get
            Return mWebPageManager
        End Get
        Set(ByVal Value As WebPageManager)
            mWebPageManager = Value
        End Set
    End Property

    Public Property StartUri() As Uri
        Get
            Return mStartUri
        End Get
        Set(ByVal Value As Uri)
            mStartUri = Value
        End Set
    End Property

    Public Property BaseUri() As Uri
        Get
            Return mBaseUri
        End Get
        Set(ByVal Value As Uri)
            mBaseUri = Value
        End Set
    End Property

    Private Property UrlCrawledCount() As Integer
        Get
            Return mUrlCrawledCount
        End Get
        Set(ByVal Value As Integer)
            mUrlCrawledCount = Value
        End Set
    End Property

    Public Property MaximumUrlAllowed() As Integer
        Get
            Return mMaximumUrlAllowed
        End Get
        Set(ByVal Value As Integer)
            mMaximumUrlAllowed = Value
        End Set
    End Property

    Public Property KeepWebContent() As Boolean
        Get
            Return mKeepWebContent
        End Get
        Set(ByVal Value As Boolean)
            mKeepWebContent = Value
        End Set
    End Property

    Public Property WebPages() As Hashtable
        Get
            Return mWebPages
        End Get
        Set(ByVal Value As Hashtable)
            mWebPages = Value
        End Set
    End Property

    Private Property WebPagesPending() As Queue
        Get
            Return m_webPagesPending
        End Get
        Set(ByVal Value As Queue)
            m_webPagesPending = Value
        End Set
    End Property


    Public Sub New(ByVal startUri As String)
        MyClass.New(startUri, -1)
    End Sub 'New

    Public Sub New(ByVal startUri As String, ByVal maximumUrlAllowed As Integer)
        MyClass.New(startUri, "", maximumUrlAllowed, False, New WebPageManager)
    End Sub 'New

    Public Sub New(ByVal startUri As String, ByVal baseUri As String, ByVal maximumUrlAllowed As Integer)
        MyClass.New(startUri, baseUri, maximumUrlAllowed, False, New WebPageManager)
    End Sub 'New

    Public Sub New(ByVal startUri As String, ByVal baseUri As String, ByVal maximumUrlAllowed As Integer, ByVal keepWebContent As Boolean, ByVal webPageManager As WebPageManager)

        Me.StartUri = New Uri(startUri)

        ' In future this could be null and will process cross-site, but for now must exist
        If (baseUri Is Nothing OrElse baseUri.Trim().Length() = 0) Then
            Me.BaseUri = New Uri(Me.StartUri.GetLeftPart(UriPartial.Authority))
        Else
            Me.BaseUri = New Uri(baseUri)
        End If

        Me.MaximumUrlAllowed = maximumUrlAllowed
        Me.KeepWebContent = keepWebContent

        m_webPagesPending = New Queue
        mWebPages = New Hashtable

        mWebPageManager = webPageManager

        webPageManager.WebPageContentHandler = [Delegate].Combine(webPageManager.WebPageContentHandler, New WebPageContentDelegate(AddressOf Me.HandleLinks))

    End Sub 'New

    Public Sub Execute()
        UrlCrawledCount = 0

        Dim startTime As DateTime = DateTime.Now

        AddWebPage(StartUri, StartUri.AbsoluteUri)

        Try
            While WebPagesPending.Count > 0 AndAlso (MaximumUrlAllowed = -1 OrElse UrlCrawledCount < MaximumUrlAllowed)
                Dim state As WebPageStatus = CType(m_webPagesPending.Dequeue(), WebPageStatus)
                mWebPageManager.Process(state)
                If Not KeepWebContent Then
                    state.Content = Nothing
                End If
                UrlCrawledCount += 1
            End While
        Catch ex As Exception
            MessageBox.Show("There was some error in crawling the website. Try again later." & vbCrLf & "Error:" & ex.ToString)
        End Try

        Dim endTime As DateTime = DateTime.Now
        Dim elasped As Single = (endTime.Ticks - startTime.Ticks) / 10000000
    End Sub


    Public Sub HandleLinks(ByVal state As WebPageStatus)
        If state.TaskInformation IsNot Nothing AndAlso Not state.TaskInformation.IndexOf("Handle Links") = -1 Then
            Dim counter As Integer = 0
            Dim m As Match = RegExUtil.GetMatchRegEx(RegularExpression.UrlExtractor, state.Content)
            While m.Success
                If AddWebPage(state.Uri, m.Groups("url").ToString()) Then
                    counter += 1
                End If
                m = m.NextMatch()
            End While

        End If
    End Sub


    Private Function AddWebPage(ByVal l_baseUri As Uri, ByVal newUri As String) As Boolean
        Dim url As String = StrUtil.LeftIndexOf(newUri, "#")

        Dim uri As New Uri(l_baseUri, url)

        If Not ValidPage(uri.LocalPath) OrElse mWebPages.Contains(uri) Then
            Return False
        End If
        Dim state As New WebPageStatus(uri)


        If (uri.AbsoluteUri.StartsWith(BaseUri.AbsoluteUri)) Then
            state.TaskInformation += "Handle Links"
        End If

        m_webPagesPending.Enqueue(state)
        mWebPages.Add(uri, state)

        Return True
    End Function


    Private Function ValidPage(ByVal path As String) As Boolean
        Dim pos As Integer = path.IndexOf(".")

        If pos = -1 OrElse path.Chars(path.Length - 1) = "/" Then   '.ToString( ).Equals( "/" )
            Return True
        End If

        Dim uriExt As String = StrUtil.RightOf(path, pos).ToLower()

        ' Uri ends in an extension
        Dim ext As String
        For Each ext In mValidExtensions
            If uriExt.Equals(ext) Then
                Return True
            End If
        Next ext

        Return False
    End Function



End Class

