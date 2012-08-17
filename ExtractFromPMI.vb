Imports System
Imports System.IO
Imports System.Xml
Imports pin3hot_Audio_File_Extractor.PmiData
Imports System.Threading

'********************************************************************
'Public Class ExtractFromPMI                                        *
'Code to read xml data chunk in pyramix pmi files and then          *
'copy all audio to individual wave files for each track             *
'********************************************************************

Public Class ExtractFromPMI

    Dim NewFile As String
    Dim fileExists As Boolean
    Dim success As String
    Public Count As Integer
    Dim SampleRate As Double = 44100    'Fixed Sample Rate of 44100 samples/second (to be made user definable)

    Public Function ExtractTracks(ByVal destDir As String, ByRef Image As ImageData, ByRef Audio As PmiData) As String

        fileExists = False
        Count = 0
        Audio.fs = New FileStream(Image.pmiFilePath, FileMode.Open)     'open specified file for reading
        Audio.sr = New BinaryReader(Audio.fs)                           'instantiate stream reader

        'Loop through pqinfo and send data to SaveTracks Function to write wave files to disk
        While Count < Image.pqData.Count - 1
            NewFile = destDir             'set base newfile value to user specified directory
            If p3hAE.CheckBoxIncludeID.Checked Then
                If Count > 8 Then
                    NewFile += "\" + (Count + 1).ToString + " "
                Else
                    NewFile += "\0" + (Count + 1).ToString + " "
                End If
            Else
                NewFile += "\"
            End If
            NewFile += Image.pqData(Count).Name
            NewFile += ".wav"
            p3hAE.Results.Text = "Writing...  " + Image.pqData(Count).Name + ".wav"
            p3hAE.Results.Refresh()
            Application.DoEvents()
            SaveTracks(Image, Audio)
            Count += 1
        End While

        'Close pmi file io
        Audio.sr.Close()
        Audio.fs.Close()

        'Check to see if there was a problem writing any tracks
        If fileExists Then
            success = "File Exists - Check Destination Directory!"
        Else
            success = "Tracks Extracted Successfully!"
        End If

        Return success

    End Function

    '****************************************************************
    'Private Function SaveTracks()                                  *
    'Function to copy audio data from pmi file to new wave files    *
    '****************************************************************
    Private Sub SaveTracks(ByRef Image As ImageData, ByRef Audio As PmiData)

        'Initialize io
        Dim writeWave As FileStream
        Dim WaveWriter As BinaryWriter

        Try
            'Create New File and Prepare for Writing Data
            writeWave = New FileStream(NewFile, FileMode.CreateNew, FileAccess.Write)
        Catch ex As Exception
            fileExists = True
            Exit Sub
        End Try

        WaveWriter = New BinaryWriter(writeWave)                'Instantiate Binary Writer to write data
        Dim CurrentByte As Byte                                 'Index Variable
        Dim WriteCounter As Integer = 0                         'Index Variable
        Dim TrackLength As Double                               'Length in seconds of currenttrack
        Dim TrackBytes As Int32                                 'Length in bytes of currenttrack
        Dim FileBytes As Int32 = 0                              'Length in bytes of current file

        'Set stream to start of file
        Audio.fs.Seek(0, SeekOrigin.Begin)
        'Step through pmi header data and copy relevant data to new file
        'Writing riff, size, and wave
        While Audio.fs.Position < 12
            CurrentByte = Audio.sr.ReadByte()
            WaveWriter.Write(CurrentByte)
        End While
        'Writing fmt chunk
        Audio.fs.Position = Audio.fmtStart
        While Audio.fs.Position < p3hAE.pmiData.AudioStart - 4
            CurrentByte = Audio.sr.ReadByte()
            WaveWriter.Write(CurrentByte)
        End While

        'Calculate length of Current Track 
        If p3hAE.CheckBoxUseEndMarkers.Checked = False Then
            TrackLength = durationCalc(Image.pqData(Count + 1).StartMarker)
        Else
            TrackLength = durationCalc(Image.pqData(Count).StopMarker)
        End If

        TrackLength -= durationCalc(Image.pqData(Count).StartMarker)
        If Count = 0 Then
            Audio.CurrentTrackStart = Audio.AudioStart
        End If
        TrackBytes = TrackLength * SampleRate * 4.0

        'Write size of data to be written to data chunk in wave file header
        WaveWriter.Write(TrackBytes)
        'Set pmi reading stream to the start of audio for current track
        Audio.fs.Position = Audio.CurrentTrackStart
        p3hAE.ProgressBar.Value = Audio.CurrentTrackStart
        p3hAE.ProgressBar.Refresh()
        Application.DoEvents()
        'Copy Data from pmi file to new wave file
        Try
            While WriteCounter < TrackBytes
                CurrentByte = Audio.sr.ReadByte()
                WaveWriter.Write(CurrentByte)
                WriteCounter += 1
            End While
        Catch ex As Exception
        End Try

        'Set CurrentTrackSTart for next Track
        If p3hAE.CheckBoxUseEndMarkers.Checked = False Then
            Audio.CurrentTrackStart = Audio.fs.Position
        Else
            Audio.CurrentTrackStart = Audio.fs.Position + ((durationCalc(Image.pqData(Count + 1).StartMarker) - _
                                                          durationCalc(Image.pqData(Count).StopMarker)) * SampleRate * 4.0)
        End If

        'Enter correct file size into file header
        FileBytes = writeWave.Length
        writeWave.Position = 4
        WaveWriter.Write(FileBytes - 8)
        'Close New Wave File IO
        WaveWriter.Close()
        writeWave.Close()

    End Sub

    Private Function durationCalc(ByVal timeCode As String) As Double
        Dim duration As Double
        Dim longDisc As Boolean = False
        Dim Minutes As String
        Dim Seconds As String
        Dim Frames As String

        'Check for values over 99 minutes and format/calculate accordingly.
        If timeCode.Substring(3, 1) = ":" Then
            Minutes = timeCode.Substring(0, 3)
            longDisc = True
        Else
            Minutes = timeCode.Substring(0, 2)
        End If

        If longDisc Then
            Seconds = timeCode.Substring(4, 2)
            Frames = timeCode.Substring(7, 2)
        Else
            Seconds = timeCode.Substring(3, 2)
            Frames = timeCode.Substring(6, 2) '75 CD Frames in a second
        End If
        duration = (Minutes * 60) + Seconds + (Frames / 75)

        Return duration
    End Function

End Class
