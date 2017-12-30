<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lbl_status_name = New System.Windows.Forms.Label()
        Me.lbl_status_response = New System.Windows.Forms.Label()
        Me.btn_miner_start = New System.Windows.Forms.Button()
        Me.btn_miner_stop = New System.Windows.Forms.Button()
        Me.lbl_cores_name = New System.Windows.Forms.Label()
        Me.cmb_cores = New System.Windows.Forms.ComboBox()
        Me.lbl_pool_name = New System.Windows.Forms.Label()
        Me.cmb_pool = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lbl_status_name
        '
        Me.lbl_status_name.AutoSize = True
        Me.lbl_status_name.Location = New System.Drawing.Point(13, 13)
        Me.lbl_status_name.Name = "lbl_status_name"
        Me.lbl_status_name.Size = New System.Drawing.Size(116, 13)
        Me.lbl_status_name.TabIndex = 0
        Me.lbl_status_name.Text = "Status of Monero miner"
        '
        'lbl_status_response
        '
        Me.lbl_status_response.AutoSize = True
        Me.lbl_status_response.Location = New System.Drawing.Point(232, 13)
        Me.lbl_status_response.Name = "lbl_status_response"
        Me.lbl_status_response.Size = New System.Drawing.Size(53, 13)
        Me.lbl_status_response.TabIndex = 1
        Me.lbl_status_response.Text = "Unknown"
        '
        'btn_miner_start
        '
        Me.btn_miner_start.Location = New System.Drawing.Point(417, 8)
        Me.btn_miner_start.Name = "btn_miner_start"
        Me.btn_miner_start.Size = New System.Drawing.Size(129, 23)
        Me.btn_miner_start.TabIndex = 2
        Me.btn_miner_start.Text = "Start Funding"
        Me.btn_miner_start.UseVisualStyleBackColor = True
        '
        'btn_miner_stop
        '
        Me.btn_miner_stop.Location = New System.Drawing.Point(552, 8)
        Me.btn_miner_stop.Name = "btn_miner_stop"
        Me.btn_miner_stop.Size = New System.Drawing.Size(129, 23)
        Me.btn_miner_stop.TabIndex = 3
        Me.btn_miner_stop.Text = "Stop Funding"
        Me.btn_miner_stop.UseVisualStyleBackColor = True
        '
        'lbl_cores_name
        '
        Me.lbl_cores_name.AutoSize = True
        Me.lbl_cores_name.Location = New System.Drawing.Point(13, 49)
        Me.lbl_cores_name.Name = "lbl_cores_name"
        Me.lbl_cores_name.Size = New System.Drawing.Size(143, 13)
        Me.lbl_cores_name.TabIndex = 4
        Me.lbl_cores_name.Text = "Number of CPU Cores to use"
        '
        'cmb_cores
        '
        Me.cmb_cores.FormattingEnabled = True
        Me.cmb_cores.Location = New System.Drawing.Point(235, 46)
        Me.cmb_cores.Name = "cmb_cores"
        Me.cmb_cores.Size = New System.Drawing.Size(170, 21)
        Me.cmb_cores.TabIndex = 5
        '
        'lbl_pool_name
        '
        Me.lbl_pool_name.AutoSize = True
        Me.lbl_pool_name.Location = New System.Drawing.Point(13, 86)
        Me.lbl_pool_name.Name = "lbl_pool_name"
        Me.lbl_pool_name.Size = New System.Drawing.Size(93, 13)
        Me.lbl_pool_name.TabIndex = 6
        Me.lbl_pool_name.Text = "Mining pool to use"
        '
        'cmb_pool
        '
        Me.cmb_pool.FormattingEnabled = True
        Me.cmb_pool.Location = New System.Drawing.Point(235, 83)
        Me.cmb_pool.Name = "cmb_pool"
        Me.cmb_pool.Size = New System.Drawing.Size(170, 21)
        Me.cmb_pool.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 577)
        Me.Controls.Add(Me.cmb_pool)
        Me.Controls.Add(Me.lbl_pool_name)
        Me.Controls.Add(Me.cmb_cores)
        Me.Controls.Add(Me.lbl_cores_name)
        Me.Controls.Add(Me.btn_miner_stop)
        Me.Controls.Add(Me.btn_miner_start)
        Me.Controls.Add(Me.lbl_status_response)
        Me.Controls.Add(Me.lbl_status_name)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Snowden Angels Support"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_status_name As Label
    Friend WithEvents lbl_status_response As Label
    Friend WithEvents btn_miner_start As Button
    Friend WithEvents btn_miner_stop As Button
    Friend WithEvents lbl_cores_name As Label
    Friend WithEvents cmb_cores As ComboBox
    Friend WithEvents lbl_pool_name As Label
    Friend WithEvents cmb_pool As ComboBox
    Friend WithEvents Timer1 As Timer
End Class
