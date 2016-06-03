Imports System.IO
Imports System.Reflection

Public Class CommonFunctions
    ''' <summary> Class cannot be instantiated</summary>
    Private Sub New()
    End Sub

    ''' <summary> Empty String tests a String to see if it is null or empty.
    ''' </summary>
    ''' <param name="value">String to be tested.
    ''' </param>
    ''' <returns> boolean true if empty.
    ''' </returns>
    Public Shared Function EmptyString(value As String) As Boolean
        Return (value Is Nothing OrElse value.Trim().Length = 0)
    End Function

    ''' <summary> Empty HttpCookie tests a HttpCookie to see if it is null or empty.
    ''' </summary>
    ''' <param name="value">HttpCookie to be tested.
    ''' </param>
    ''' <returns> boolean true if empty.
    ''' </returns>
    Public Shared Function EmptyHttpCookie(value As System.Web.HttpCookie) As Boolean
        Return (value Is Nothing OrElse value.Value Is Nothing OrElse value.Value.Trim().Length = 0)
    End Function

    Public Shared Sub CreateDatabase()
        Dim folderPath As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData
        If System.IO.Directory.Exists(folderPath) = False Then
            System.IO.Directory.CreateDirectory(folderPath)
        End If
        Dim filePath As String = System.IO.Path.Combine(folderPath, "crawl.dat")
        If File.Exists(filePath) = False Then
            Dim strm As Stream = Application.GetResourceStream(New Uri("pack://application:,,,/" & My.Application.Info.AssemblyName & ";component/crawl.dat")).Stream
            If strm IsNot Nothing Then
                Dim br As New BinaryReader(strm)
                Dim bytes() As Byte = br.ReadBytes(strm.Length)
                strm.Close()
                My.Computer.FileSystem.WriteAllBytes(filePath, bytes, False)
            End If
        End If
    End Sub

End Class