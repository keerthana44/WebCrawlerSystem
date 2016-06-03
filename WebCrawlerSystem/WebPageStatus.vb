Imports System
Imports System.Net


Public Class WebPageStatus

    Private Sub New()
    End Sub

    Public Sub New(ByVal uri As Uri)
        Me.Uri = uri
    End Sub

    Public Sub New(ByVal uri As String)
        MyClass.New(New Uri(uri))
    End Sub

    Public Property Uri As Uri
    Public Property TaskStarted As Boolean
    Public Property TaskCompleted As Boolean
    Public Property TaskInformation As String
    Public Property Content As String
    Public Property StatusCode As String
    Public Property StatusDescription As String

End Class

