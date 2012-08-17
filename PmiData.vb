Imports System.Xml
Imports System.IO
Imports System.ComponentModel

'************************************************************
'Public Class pqinfo                                        *
'Holds pqinfo for a cd master image                         *
'************************************************************
Public Class pqInfo

    Dim itsTrackID As String                'Track Number *NOTE AA is END OF PROGRAM
    Dim itsTrackName As String              'Name of Track
    Dim itsTrackStart As String             'Track Start Time in CD Timecode (75 frames / second)
    Dim itsTrackEnd As String               'Track End Time (only if end markers used - otherwise 1 sample before next track start)

    'Bare Constructor
    Public Sub New()
    End Sub

    'Public Properties
    Public Property ID() As String
        Get
            Return itsTrackID
        End Get
        Set(ByVal value As String)
            itsTrackID = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return itsTrackName
        End Get
        Set(ByVal value As String)
            itsTrackName = value
        End Set
    End Property

    Public Property StartMarker() As String
        Get
            Return itsTrackStart
        End Get
        Set(ByVal value As String)
            itsTrackStart = value
        End Set
    End Property

    Public Property StopMarker() As String
        Get
            Return itsTrackEnd
        End Get
        Set(ByVal value As String)
            itsTrackEnd = value
        End Set
    End Property

End Class

Public Class ImageData

    Public pmiFileName As String
    Public pmiFilePath As String
    Public pqData As New BindingList(Of pqInfo)

End Class

Public Class PmiData

    Private success As String               'Variable to return reporting success or failure of extraction
    Private InvalidCharacters As String = "/\?%*:|""<>" 'illegal filename characters
    Private Invalid() As Char               'Char array of invalid characters for loop
    Private xTOC() As Char                  'CD TOC read from XTOC xml chunk
    Private XML As New XmlDocument          'XML Document to store extracted xmldata before parsing
    Private XMLTracks As XmlNodeList        'XML node List of Tracks in image file
    Public fs As FileStream                'FileStream Reader
    Public sr As BinaryReader              'Binary Stream Reader - to read data from pmi file
    Private reader As String                'Temporary Storage variable for elements read from pmi file
    Private Count As Integer = 0            'multi-use counter variable                       
    Private dataLength As Integer           'Variable to hold length of audio data chunks
    Private CurrentChunkLength As Int32     'Variable to hold length of chunk currrently being inspected
    Public AudioStart As Int32             'Variable to hold address in filestream of start of Raw Audio Data
    Public fmtStart As Int32               'Start of fmt Chunk
    Public DataChunk As Int32              'Size in bytes of the data chunk excluding header
    Public CurrentTrackStart As Int32 = 0  'Variable to hold address of start of current track
    Private numTracks As Integer

    '****************************************************************
    'Public Entry Point                                             *
    '****************************************************************
    Public Function ExtractXML(ByRef Image As ImageData) As String

        fs = New FileStream(Image.pmiFilePath, FileMode.Open)         'open specified file for reading
        sr = New BinaryReader(fs)                           'instantiate stream reader

        'set starting seek point in filestream to start of file
        fs.Seek(0, SeekOrigin.Begin)
        'Read the first 4 bytes as ansi characters
        reader = sr.ReadChars(4)
        'Check that file is in RIFF format and if it isn't exit function and inform user file is invalid
        If reader.ToUpper <> "RIFF" Then
            success = "Invalid Source File!"
            Return success
            Exit Function
        End If

        'Jump to File Format and verify it's wave
        fs.Position += 4
        reader = sr.ReadChars(4)
        If reader.ToUpper <> "WAVE" Then
            success = "Invalid audio format!"
            Return success
            Exit Function
        End If

        'Find FMT Chunk and Jump to Data Chunk
        reader = sr.ReadChars(4)
        If reader.ToLower = "fmt " Then
            fmtStart = fs.Position - 4
            CurrentChunkLength = sr.ReadInt32
            fs.Position += CurrentChunkLength
        Else
            CurrentChunkLength = sr.ReadInt32
            fs.Position += CurrentChunkLength
            reader = sr.ReadChars(4)
            If reader.ToLower <> "fmt " Then
                success = "Failed fo find fmt Chunk!"
                Return success
                Exit Function
            End If
            fmtStart = fs.Position - 4
            CurrentChunkLength = sr.ReadInt32
            fs.Position += CurrentChunkLength
        End If

        'Verify we are at Data Chunk
        reader = sr.ReadChars(4)
        If reader.ToLower <> "data" Then
            success = "Failed to find Data Chunk"
            Return success
            Exit Function
        End If

        'Set Length to the size of the data chunk
        DataChunk = sr.ReadInt32
        'Set AudioStart to the current position which is equal to the start of raw audio data
        AudioStart = fs.Position
        'Set the filestream position to the byte immediately following the data chunk
        fs.Position += DataChunk

        'Read the 4 bytes immediately following the data chunk and verify that they represent the start of XML Data
        reader = sr.ReadChars(4)
        If reader.ToLower = "xtoc" Then
            success = "Found XML Data"
        Else
            success = "Failed to find XML Data Chunk!"
            Return success
            Exit Function
        End If

        'Start reading xml data and store temporarily in character array
        dataLength = sr.ReadInt32
        Count = 0

        While Count < (dataLength / 2)
            reader = Convert.ToChar(sr.ReadUInt16)
            ReDim Preserve xTOC(Count)
            xTOC(Count) = reader
            Count += 1
        End While

        'Move Character Array to single String containing complete xml chunk data
        reader = Nothing
        Count = 0
        Dim TempCounter As Integer = 0
        While Count < xTOC.Length
            reader += xTOC(Count)
            Count += 1
        End While

        'Load string of xml data as an xml document for parsing
        Try
            XML.LoadXml(reader)
        Catch ex As Exception
            success = "Invalid XML Data"
        End Try

        'Get number of audio tracks in cd image and dimension pq structure array accordingly
        numTracks = XML.GetElementsByTagName("Track").Count

        'Prepare to parse XML Data
        XMLTracks = XML.GetElementsByTagName("Track")
        Dim xmlIndex As XmlNodeList = XML.GetElementsByTagName("Index")
        Dim Track As XmlNode
        Dim Index As XmlNode

        Count = 0

        'Parse Track Titles
        For Each Track In XMLTracks
            Image.pqData.AddNew()
            Try
                Image.pqData(Count).ID = Track.Attributes.GetNamedItem("ID").Value
            Catch ex As Exception
            End Try
            If Image.pqData(Count).ID.ToLower = "aa" Then
                Image.pqData(Count).Name = "End of Program"
            Else
                Try
                    Image.pqData(Count).Name = Track.SelectSingleNode("Name").InnerText
                Catch ex As Exception
                End Try
            End If
            Count += 1
        Next
        Count = 0

        'Parse Track Start Times
        For Each Index In xmlIndex
            Try
                If Index.Attributes("ID").Value = "0" Then
                    Image.pqData(Count - 1).StopMarker = Index.SelectSingleNode("Time").InnerText
                ElseIf Index.Attributes("ID").Value = "1" Then
                    Image.pqData(Count).StartMarker = Index.SelectSingleNode("Time").InnerText
                    Count += 1
                End If
            Catch ex As Exception
            End Try
        Next
        'Set end value for final Track
        Image.pqData(Count - 2).StopMarker = Image.pqData(Count - 1).StartMarker
        Count = 0

        'Verify Track Names are allowed as file names
        Dim TrackNameVerify As String
        Dim invalidCount As Integer
        Invalid = InvalidCharacters.ToCharArray

        'Loop through Track Names and remove invalid filename characters
        While Count < numTracks - 1
            invalidCount = 0
            TrackNameVerify = Image.pqData(Count).Name
            While invalidCount < Invalid.Length
                TrackNameVerify = Image.pqData(Count).Name.Replace(Invalid(invalidCount), "")
                Image.pqData(Count).Name = TrackNameVerify
                invalidCount += 1
            End While
            Count += 1
        End While

        sr.Close()
        fs.Close()

        Return "TOC read successfully!"

    End Function

End Class
