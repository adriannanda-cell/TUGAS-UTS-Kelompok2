<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBayar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        Label3 = New Label()
        Button6 = New Button()
        Label4 = New Label()
        Label5 = New Label()
        Button7 = New Button()
        Button8 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(24, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(199, 37)
        Label1.TabIndex = 0
        Label1.Text = "PEMBAYARAN"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(31, 60)
        Label2.Name = "Label2"
        Label2.Size = New Size(78, 25)
        Label2.TabIndex = 1
        Label2.Text = "TOTAL :"
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.ControlDark
        Button1.FlatStyle = FlatStyle.Popup
        Button1.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(105, 397)
        Button1.Name = "Button1"
        Button1.Size = New Size(218, 38)
        Button1.TabIndex = 2
        Button1.Text = "BAYAR & CETAK STRUK"
        Button1.TextImageRelation = TextImageRelation.ImageAboveText
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(105, 156)
        Button2.Name = "Button2"
        Button2.Size = New Size(81, 38)
        Button2.TabIndex = 3
        Button2.Text = "TUNAI"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(224, 156)
        Button3.Name = "Button3"
        Button3.Size = New Size(80, 38)
        Button3.TabIndex = 4
        Button3.Text = "FERMI"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(106, 200)
        Button4.Name = "Button4"
        Button4.Size = New Size(205, 41)
        Button4.TabIndex = 5
        Button4.Text = "Kartu (DEBIT/KREDIT)"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(106, 247)
        Button5.Name = "Button5"
        Button5.Size = New Size(205, 41)
        Button5.TabIndex = 6
        Button5.Text = "QRIS/ E WALLET"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(106, 301)
        Label3.Name = "Label3"
        Label3.Size = New Size(105, 15)
        Label3.TabIndex = 7
        Label3.Text = "Pembayaran Tunai"
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(107, 330)
        Button6.Name = "Button6"
        Button6.Size = New Size(204, 23)
        Button6.TabIndex = 8
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(107, 366)
        Label4.Name = "Label4"
        Label4.Size = New Size(95, 15)
        Label4.TabIndex = 9
        Label4.Text = "KEMBALIAN: Rp "
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(31, 103)
        Label5.Name = "Label5"
        Label5.Size = New Size(41, 25)
        Label5.TabIndex = 10
        Label5.Text = "RP "
        ' 
        ' Button7
        ' 
        Button7.FlatStyle = FlatStyle.System
        Button7.Location = New Point(107, 103)
        Button7.Name = "Button7"
        Button7.Size = New Size(204, 23)
        Button7.TabIndex = 11
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Button8
        ' 
        Button8.Location = New Point(208, 366)
        Button8.Name = "Button8"
        Button8.Size = New Size(103, 23)
        Button8.TabIndex = 12
        Button8.UseVisualStyleBackColor = True
        ' 
        ' FormBayar
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(386, 513)
        Controls.Add(Button8)
        Controls.Add(Button7)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Button6)
        Controls.Add(Label3)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "FormBayar"
        StartPosition = FormStartPosition.CenterScreen
        Text = "PEMBAYARAN"
        TransparencyKey = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button

End Class
