<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.IzgaraAyarlarıToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyarlarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TekrarlarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlokAyarlarıToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.panel_ayarlar = New System.Windows.Forms.Panel()
        Me.panel_tekrarlar = New System.Windows.Forms.Panel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.panel_ayarlar.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.PowderBlue
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1MinSize = 100
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.MidnightBlue
        Me.SplitContainer1.Panel2.Controls.Add(Me.panel_ayarlar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MenuStrip1)
        Me.SplitContainer1.Panel2MinSize = 100
        Me.SplitContainer1.Size = New System.Drawing.Size(1207, 606)
        Me.SplitContainer1.SplitterDistance = 100
        Me.SplitContainer1.SplitterWidth = 25
        Me.SplitContainer1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 39)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Eğer"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IzgaraAyarlarıToolStripMenuItem, Me.BlokAyarlarıToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1082, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'IzgaraAyarlarıToolStripMenuItem
        '
        Me.IzgaraAyarlarıToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyarlarToolStripMenuItem, Me.TekrarlarToolStripMenuItem})
        Me.IzgaraAyarlarıToolStripMenuItem.Name = "IzgaraAyarlarıToolStripMenuItem"
        Me.IzgaraAyarlarıToolStripMenuItem.Size = New System.Drawing.Size(117, 24)
        Me.IzgaraAyarlarıToolStripMenuItem.Text = "Izgara Ayarları"
        '
        'AyarlarToolStripMenuItem
        '
        Me.AyarlarToolStripMenuItem.Name = "AyarlarToolStripMenuItem"
        Me.AyarlarToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.AyarlarToolStripMenuItem.Text = "Ayarlar"
        '
        'TekrarlarToolStripMenuItem
        '
        Me.TekrarlarToolStripMenuItem.Name = "TekrarlarToolStripMenuItem"
        Me.TekrarlarToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.TekrarlarToolStripMenuItem.Text = "Tekrarlar"
        '
        'BlokAyarlarıToolStripMenuItem
        '
        Me.BlokAyarlarıToolStripMenuItem.Name = "BlokAyarlarıToolStripMenuItem"
        Me.BlokAyarlarıToolStripMenuItem.Size = New System.Drawing.Size(105, 24)
        Me.BlokAyarlarıToolStripMenuItem.Text = "Blok Ayarları"
        '
        'panel_ayarlar
        '
        Me.panel_ayarlar.Controls.Add(Me.panel_tekrarlar)
        Me.panel_ayarlar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_ayarlar.Location = New System.Drawing.Point(0, 28)
        Me.panel_ayarlar.Name = "panel_ayarlar"
        Me.panel_ayarlar.Size = New System.Drawing.Size(1082, 578)
        Me.panel_ayarlar.TabIndex = 1
        Me.panel_ayarlar.Visible = False
        '
        'panel_tekrarlar
        '
        Me.panel_tekrarlar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_tekrarlar.Location = New System.Drawing.Point(0, 0)
        Me.panel_tekrarlar.Name = "panel_tekrarlar"
        Me.panel_tekrarlar.Size = New System.Drawing.Size(1082, 578)
        Me.panel_tekrarlar.TabIndex = 2
        Me.panel_tekrarlar.Visible = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1207, 606)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form2"
        Me.ShowIcon = False
        Me.Text = "TRduino - Bloklar"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.panel_ayarlar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Button1 As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents IzgaraAyarlarıToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyarlarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TekrarlarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BlokAyarlarıToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents panel_ayarlar As Panel
    Friend WithEvents panel_tekrarlar As Panel
End Class
