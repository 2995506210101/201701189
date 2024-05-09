<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCitas = New System.Windows.Forms.Button()
        Me.btnSuministros = New System.Windows.Forms.Button()
        Me.btnContabilidad = New System.Windows.Forms.Button()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCitas
        '
        Me.btnCitas.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCitas.Location = New System.Drawing.Point(301, 197)
        Me.btnCitas.Name = "btnCitas"
        Me.btnCitas.Size = New System.Drawing.Size(216, 23)
        Me.btnCitas.TabIndex = 0
        Me.btnCitas.Text = "Citas"
        Me.btnCitas.UseVisualStyleBackColor = False
        '
        'btnSuministros
        '
        Me.btnSuministros.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSuministros.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSuministros.Location = New System.Drawing.Point(301, 226)
        Me.btnSuministros.Name = "btnSuministros"
        Me.btnSuministros.Size = New System.Drawing.Size(216, 23)
        Me.btnSuministros.TabIndex = 1
        Me.btnSuministros.Text = "Suministros"
        Me.btnSuministros.UseVisualStyleBackColor = False
        '
        'btnContabilidad
        '
        Me.btnContabilidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContabilidad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnContabilidad.Location = New System.Drawing.Point(301, 255)
        Me.btnContabilidad.Name = "btnContabilidad"
        Me.btnContabilidad.Size = New System.Drawing.Size(216, 23)
        Me.btnContabilidad.TabIndex = 2
        Me.btnContabilidad.Text = "Contabilidad"
        Me.btnContabilidad.UseVisualStyleBackColor = False
        '
        'btnRegresar
        '
        Me.btnRegresar.BackColor = System.Drawing.Color.Orange
        Me.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRegresar.Location = New System.Drawing.Point(521, 387)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(236, 23)
        Me.btnRegresar.TabIndex = 3
        Me.btnRegresar.Text = "Regresar"
        Me.btnRegresar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(-6, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(812, 60)
        Me.Panel1.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(295, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(242, 37)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Menú Principal"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.btnContabilidad)
        Me.Controls.Add(Me.btnSuministros)
        Me.Controls.Add(Me.btnCitas)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "Form3"
        Me.Text = "Menú"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCitas As Button
    Friend WithEvents btnSuministros As Button
    Friend WithEvents btnContabilidad As Button
    Friend WithEvents btnRegresar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label10 As Label
End Class
