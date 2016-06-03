Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class CrawlDetail
    Implements INotifyPropertyChanged

    Private mWebsiteUrl As String
    Private mTotalCrawled As Integer
    Private mTotalBrokenLink As Integer
    Private mPages As New ObservableCollection(Of CrawlPageDetail)


    Public Property Pages As ObservableCollection(Of CrawlPageDetail)
        Get
            Return mPages
        End Get
        Set(value As ObservableCollection(Of CrawlPageDetail))
            mPages = value
            OnPropertyChanged("Pages")
        End Set
    End Property



    Public Property WebsiteUrl As String
        Get
            Return mWebsiteUrl
        End Get
        Set(value As String)
            mWebsiteUrl = value
            OnPropertyChanged("WebsiteUrl")
        End Set
    End Property

    Public Property TotalCrawled As Integer
        Get
            Return mTotalCrawled
        End Get
        Set(value As Integer)
            mTotalCrawled = value
            OnPropertyChanged("TotalCrawled")
        End Set
    End Property

    Public Property TotalBrokenLink As Integer
        Get
            Return mTotalBrokenLink
        End Get
        Set(value As Integer)
            mTotalBrokenLink = value
            OnPropertyChanged("TotalBrokenLink")
        End Set
    End Property

    Public Sub OnPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub


    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class

Public Class CrawlPageDetail
    Implements INotifyPropertyChanged

    Private mWebsiteUrl As String
    Private mSerialNumber As Integer
    Private mStatus As String

    Public Property WebsiteUrl As String
        Get
            Return mWebsiteUrl
        End Get
        Set(value As String)
            mWebsiteUrl = value
            OnPropertyChanged("WebsiteUrl")
        End Set
    End Property


    Public Property SerialNumber As Integer
        Get
            Return mSerialNumber
        End Get
        Set(value As Integer)
            mSerialNumber = value
            OnPropertyChanged("SerialNumber")
        End Set
    End Property

    Public Property Status As String
        Get
            Return mStatus
        End Get
        Set(value As String)
            mStatus = value
            OnPropertyChanged("Status")
        End Set
    End Property

    Public Sub OnPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub


    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class

