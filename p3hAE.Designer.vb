<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class p3hAE
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(p3hAE))
        Me.SelectPMI = New System.Windows.Forms.Button
        Me.SelectDestination = New System.Windows.Forms.Button
        Me.ExtractTracks = New System.Windows.Forms.Button
        Me.ImagePath = New System.Windows.Forms.TextBox
        Me.ExtractPath = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Results = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.tocDataGrid = New System.Windows.Forms.DataGridView
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StartMarkerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StopMarkerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PqInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ButtonAbout = New System.Windows.Forms.Button
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.CheckBoxUseEndMarkers = New System.Windows.Forms.CheckBox
        Me.xTOC = New System.Windows.Forms.Label
        Me.CheckBoxIncludeID = New System.Windows.Forms.CheckBox
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        CType(Me.tocDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PqInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SelectPMI
        '
        Me.SelectPMI.Location = New System.Drawing.Point(33, 27)
        Me.SelectPMI.Name = "SelectPMI"
        Me.SelectPMI.Size = New System.Drawing.Size(157, 23)
        Me.SelectPMI.TabIndex = 0
        Me.SelectPMI.Text = "Select PMI Image File"
        Me.SelectPMI.UseVisualStyleBackColor = True
        '
        'SelectDestination
        '
        Me.SelectDestination.Location = New System.Drawing.Point(33, 71)
        Me.SelectDestination.Name = "SelectDestination"
        Me.SelectDestination.Size = New System.Drawing.Size(157, 23)
        Me.SelectDestination.TabIndex = 1
        Me.SelectDestination.Text = "Select Destination Directory"
        Me.SelectDestination.UseVisualStyleBackColor = True
        '
        'ExtractTracks
        '
        Me.ExtractTracks.Location = New System.Drawing.Point(96, 693)
        Me.ExtractTracks.Name = "ExtractTracks"
        Me.ExtractTracks.Size = New System.Drawing.Size(157, 33)
        Me.ExtractTracks.TabIndex = 2
        Me.ExtractTracks.Text = "Extract Tracks!"
        Me.ExtractTracks.UseVisualStyleBackColor = True
        '
        'ImagePath
        '
        Me.ImagePath.Location = New System.Drawing.Point(219, 29)
        Me.ImagePath.Name = "ImagePath"
        Me.ImagePath.ReadOnly = True
        Me.ImagePath.Size = New System.Drawing.Size(264, 20)
        Me.ImagePath.TabIndex = 5
        '
        'ExtractPath
        '
        Me.ExtractPath.Location = New System.Drawing.Point(219, 73)
        Me.ExtractPath.Name = "ExtractPath"
        Me.ExtractPath.ReadOnly = True
        Me.ExtractPath.Size = New System.Drawing.Size(264, 20)
        Me.ExtractPath.TabIndex = 6
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "CD Image Files|*.pmi|All files|*.*"
        '
        'Results
        '
        Me.Results.Location = New System.Drawing.Point(33, 647)
        Me.Results.Name = "Results"
        Me.Results.ReadOnly = True
        Me.Results.Size = New System.Drawing.Size(450, 20)
        Me.Results.TabIndex = 7
        Me.Results.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(344, 682)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "pin3hot 2009"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(337, 713)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Mark S. Willsher"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(317, 697)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(123, 13)
        Me.LinkLabel1.TabIndex = 11
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "http://www.pin3hot.com"
        '
        'tocDataGrid
        '
        Me.tocDataGrid.AllowUserToAddRows = False
        Me.tocDataGrid.AllowUserToDeleteRows = False
        Me.tocDataGrid.AllowUserToResizeColumns = False
        Me.tocDataGrid.AllowUserToResizeRows = False
        Me.tocDataGrid.AutoGenerateColumns = False
        Me.tocDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tocDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.StartMarkerDataGridViewTextBoxColumn, Me.StopMarkerDataGridViewTextBoxColumn})
        Me.tocDataGrid.DataSource = Me.PqInfoBindingSource
        Me.tocDataGrid.Location = New System.Drawing.Point(33, 167)
        Me.tocDataGrid.Name = "tocDataGrid"
        Me.tocDataGrid.RowHeadersVisible = False
        Me.tocDataGrid.Size = New System.Drawing.Size(450, 447)
        Me.tocDataGrid.TabIndex = 12
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "Track"
        Me.IDDataGridViewTextBoxColumn.MinimumWidth = 50
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Width = 60
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Title (can be edited)"
        Me.NameDataGridViewTextBoxColumn.MinimumWidth = 236
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.Width = 236
        '
        'StartMarkerDataGridViewTextBoxColumn
        '
        Me.StartMarkerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.StartMarkerDataGridViewTextBoxColumn.DataPropertyName = "StartMarker"
        Me.StartMarkerDataGridViewTextBoxColumn.HeaderText = "Start"
        Me.StartMarkerDataGridViewTextBoxColumn.MinimumWidth = 75
        Me.StartMarkerDataGridViewTextBoxColumn.Name = "StartMarkerDataGridViewTextBoxColumn"
        Me.StartMarkerDataGridViewTextBoxColumn.ReadOnly = True
        Me.StartMarkerDataGridViewTextBoxColumn.Width = 75
        '
        'StopMarkerDataGridViewTextBoxColumn
        '
        Me.StopMarkerDataGridViewTextBoxColumn.DataPropertyName = "StopMarker"
        Me.StopMarkerDataGridViewTextBoxColumn.HeaderText = "Stop"
        Me.StopMarkerDataGridViewTextBoxColumn.MinimumWidth = 75
        Me.StopMarkerDataGridViewTextBoxColumn.Name = "StopMarkerDataGridViewTextBoxColumn"
        Me.StopMarkerDataGridViewTextBoxColumn.ReadOnly = True
        Me.StopMarkerDataGridViewTextBoxColumn.Width = 75
        '
        'PqInfoBindingSource
        '
        Me.PqInfoBindingSource.DataSource = GetType(pin3hot_Audio_File_Extractor.pqInfo)
        '
        'ButtonAbout
        '
        Me.ButtonAbout.Location = New System.Drawing.Point(339, 734)
        Me.ButtonAbout.Name = "ButtonAbout"
        Me.ButtonAbout.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAbout.TabIndex = 15
        Me.ButtonAbout.Text = "About"
        Me.ButtonAbout.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(150, 734)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(40, 13)
        Me.LinkLabel2.TabIndex = 16
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "donate"
        '
        'CheckBoxUseEndMarkers
        '
        Me.CheckBoxUseEndMarkers.AutoSize = True
        Me.CheckBoxUseEndMarkers.Location = New System.Drawing.Point(247, 109)
        Me.CheckBoxUseEndMarkers.Name = "CheckBoxUseEndMarkers"
        Me.CheckBoxUseEndMarkers.Size = New System.Drawing.Size(193, 17)
        Me.CheckBoxUseEndMarkers.TabIndex = 0
        Me.CheckBoxUseEndMarkers.Text = "Use Track End Markers If Present?"
        Me.CheckBoxUseEndMarkers.UseVisualStyleBackColor = True
        '
        'xTOC
        '
        Me.xTOC.AutoSize = True
        Me.xTOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xTOC.Location = New System.Drawing.Point(39, 133)
        Me.xTOC.Name = "xTOC"
        Me.xTOC.Size = New System.Drawing.Size(52, 20)
        Me.xTOC.TabIndex = 18
        Me.xTOC.Text = "xTOC"
        '
        'CheckBoxIncludeID
        '
        Me.CheckBoxIncludeID.AutoSize = True
        Me.CheckBoxIncludeID.Checked = True
        Me.CheckBoxIncludeID.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxIncludeID.Location = New System.Drawing.Point(247, 133)
        Me.CheckBoxIncludeID.Name = "CheckBoxIncludeID"
        Me.CheckBoxIncludeID.Size = New System.Drawing.Size(201, 17)
        Me.CheckBoxIncludeID.TabIndex = 19
        Me.CheckBoxIncludeID.Text = "Include Track # in Wave File Name?"
        Me.CheckBoxIncludeID.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ProgressBar.Location = New System.Drawing.Point(33, 624)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(450, 13)
        Me.ProgressBar.TabIndex = 20
        Me.ProgressBar.Visible = False
        '
        'p3hAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 769)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.CheckBoxIncludeID)
        Me.Controls.Add(Me.CheckBoxUseEndMarkers)
        Me.Controls.Add(Me.xTOC)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.ButtonAbout)
        Me.Controls.Add(Me.tocDataGrid)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Results)
        Me.Controls.Add(Me.ExtractPath)
        Me.Controls.Add(Me.ImagePath)
        Me.Controls.Add(Me.ExtractTracks)
        Me.Controls.Add(Me.SelectDestination)
        Me.Controls.Add(Me.SelectPMI)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "p3hAE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "pin3hot pmi tool v1.1"
        CType(Me.tocDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PqInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SelectPMI As System.Windows.Forms.Button
    Friend WithEvents SelectDestination As System.Windows.Forms.Button
    Friend WithEvents ExtractTracks As System.Windows.Forms.Button
    Friend WithEvents ImagePath As System.Windows.Forms.TextBox
    Friend WithEvents ExtractPath As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Results As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents tocDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonAbout As System.Windows.Forms.Button
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents CheckBoxUseEndMarkers As System.Windows.Forms.CheckBox
    Friend WithEvents xTOC As System.Windows.Forms.Label
    Friend WithEvents CheckBoxIncludeID As System.Windows.Forms.CheckBox
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartMarkerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StopMarkerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Private WithEvents PqInfoBindingSource As System.Windows.Forms.BindingSource

End Class
