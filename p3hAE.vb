
'********************************************************************
'pin3hot Audio File Extractor                                       *
'copyright pin3hot 2009                                             *
'Mark Simon Willsher                                                *
'mark@pin3hot.com                                                   *
'                                                                   *
'Program to extract audio segments from a larger file based         *
'on an xml track listing - and convert them to a file format        *
'of the users choice.                                               *
'                                                                   *
'Version 1.0 December 2009                                          *
'Takes a merging technologies .pmi cd image file and extracts it to *
'individual .wav files for each track in the cd toc.                *
'Also allows user to edit track title infomation.                   *
'********************************************************************

Public Class p3hAE

    Dim destDir As String                   'location to save extracted tracks to
    Dim success As String
    Dim validTOC As Boolean = False
    Dim pmiExtract As New ExtractFromPMI    'Instantiate Object to extract tracks
    Public pmiData As New PmiData           'Instantiate Object to read xml data
    Public pmiImage As New ImageData        'Instantiate List of pqdata Object

    'Select PMI File
    Private Sub SelectPMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectPMI.Click
        pmiImage = New ImageData
        tocDataGrid.DataSource = pmiImage.pqData
        OpenFileDialog1.ShowDialog()
        pmiImage.pmiFileName = OpenFileDialog1.SafeFileName
        pmiImage.pmiFilePath = OpenFileDialog1.FileName
        ImagePath.Text = pmiImage.pmiFileName
        'Read xtoc xml chunk from pmi image
        Try
            success = pmiData.ExtractXML(pmiImage)
            Results.Text = success
            validTOC = True
        Catch ex As Exception
            validTOC = False
            Results.Text = "Failed to read TOC"
        End Try
    End Sub

    'Select Destination Directory
    Private Sub SelectDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectDestination.Click
        FolderBrowserDialog1.ShowDialog()
        destDir = FolderBrowserDialog1.SelectedPath
        ExtractPath.Text = destDir
    End Sub

    'Call ExtractFromPMI object to do just that
    Private Sub ExtractTracks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtractTracks.Click
        Results.Text = ""
        If validTOC Then
            ProgressBar.Value = 0
            ProgressBar.Maximum = pmiData.DataChunk
            ProgressBar.Show()
            Try
                success = pmiExtract.ExtractTracks(destDir, pmiImage, pmiData)
                Results.Text = success
            Catch ex As Exception
                Results.Text = "Failed to read Audio Data"
            End Try
            ProgressBar.Hide()
        Else
            Results.Text = "Invalid TOC"
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Navigate to pin3hot website
        System.Diagnostics.Process.Start("http://www.pin3hot.com")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAbout.Click
        p3hAEAbout.ShowDialog()
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        'Navigate to paypal
        System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=10339101")
    End Sub

    Private Sub p3hAE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

End Class
