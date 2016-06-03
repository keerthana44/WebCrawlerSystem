Imports System
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions

Public Delegate Sub WebPageContentDelegate(ByVal state As WebPageStatus)

Public Class WebPageManager


    Public Function Process(ByVal state As WebPageStatus) As Boolean
        state.TaskStarted = True
        state.TaskCompleted = False

        Try
            Console.WriteLine("Process Uri: {0}", state.Uri.AbsoluteUri)

            Dim req As WebRequest = WebRequest.Create(state.Uri)
            Dim res As WebResponse = Nothing

            Try
                res = req.GetResponse()

                If TypeOf res Is HttpWebResponse Then
                    state.StatusCode = CType(res, HttpWebResponse).StatusCode.ToString()
                    state.StatusDescription = CType(res, HttpWebResponse).StatusDescription
                End If

                If TypeOf res Is FileWebResponse Then
                    state.StatusCode = "OK"
                    state.StatusDescription = "OK"
                End If

                If state.StatusCode.Equals("OK") Then
                    Dim sr As New StreamReader(res.GetResponseStream())

                    state.Content = sr.ReadToEnd()

                    If Not (WebPageContentHandler Is Nothing) Then
                        Dim handler As WebPageContentDelegate = WebPageContentHandler
                        handler(state)
                    End If
                End If

                state.TaskCompleted = True
            Catch ex As Exception
                HandleException(ex, state)
            Finally
                If Not (res Is Nothing) Then
                    res.Close()
                End If
            End Try
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        End Try

        Console.WriteLine("Completed: {0}", state.TaskCompleted)

        If WebPageTaskCompleted IsNot Nothing Then
            Dim taskHandler As WebPageContentDelegate = WebPageTaskCompleted
            taskHandler(state)
        End If


        Return state.TaskCompleted
    End Function 'Process

#Region "local interface"

    Private Sub HandleException(ByVal ex As Exception, ByRef state As WebPageStatus) '
        If ex.ToString().IndexOf("(404)") <> -1 Then
            state.StatusCode = "404"
            state.StatusDescription = "(404) Not Found"
        ElseIf ex.ToString().IndexOf("(403)") <> -1 Then
            state.StatusDescription = "(403) Forbidden"

        ElseIf ex.ToString().IndexOf("(502)") <> -1 Then
            state.StatusCode = "502"
            state.StatusDescription = "(502) Bad Gateway"
        ElseIf ex.ToString().IndexOf("(503)") <> -1 Then
            state.StatusCode = "503"
            state.StatusDescription = "(503) Server Unavailable"
        ElseIf ex.ToString().IndexOf("(504)") <> -1 Then
            state.StatusCode = "504"
            state.StatusDescription = "(504) Gateway Timeout"
        ElseIf Not (ex.InnerException Is Nothing) AndAlso TypeOf ex.InnerException Is FileNotFoundException Then
            state.StatusCode = "FileNotFound"
            state.StatusDescription = ex.InnerException.Message
        Else
            state.StatusDescription = ex.ToString()
        End If
    End Sub 'HandleException
#End Region

#Region "properties"
    Private mWebPageContentHandler As WebPageContentDelegate = Nothing
    Private mWebPageTaskCompleted As WebPageContentDelegate = Nothing

    Public Property WebPageContentHandler() As WebPageContentDelegate
        Get
            Return mWebPageContentHandler
        End Get
        Set(ByVal Value As WebPageContentDelegate)
            mWebPageContentHandler = Value
        End Set
    End Property

    Public Property WebPageTaskCompleted() As WebPageContentDelegate
        Get
            Return mWebPageTaskCompleted
        End Get
        Set(ByVal Value As WebPageContentDelegate)
            mWebPageTaskCompleted = Value
        End Set
    End Property

#End Region

End Class


