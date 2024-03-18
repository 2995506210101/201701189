Imports System.Globalization

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.Label1.Location = New System.Drawing.Point(263, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Calculo de Cuenta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(87, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ingrese el total de la cuenta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(87, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(228, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Ingrese el porcentaje de la propina"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(84, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Ingrese el total de personas"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(90, 127)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "Q"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(90, 204)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 5
        Me.TextBox2.Text = "%"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(90, 272)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 6
        Me.TextBox3.Text = "#"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(445, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Total: total + propina"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(445, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Total en letras"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(445, 224)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 15)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Total por persona: Q"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(445, 272)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(142, 15)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Fecha y hora de calculo: "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(151, 311)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Calcular"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim total As Decimal = Convert.ToDecimal(TextBox1.Text)
        Dim propina As Integer = Convert.ToInt32(TextBox2.Text)
        Dim personas As Integer = Convert.ToInt32(TextBox3.Text)
        Dim total2 As Decimal = total + (total * (propina / 100.0))
        Dim horario As New CultureInfo("es")
        Dim formato As New NumberFormatInfo()
        formato.CurrencySymbol = "Q"
        formato.CurrencyDecimalDigits = 2
        formato.CurrencyDecimalSeparator = "."
        formato.CurrencyGroupSeparator = ","
        formato.CurrencyGroupSizes = New Integer() {3}
        Dim totalLetras As String = total2.ToString("C", formato)
        totalLetras = totalLetras.ToUpper().Replace("QUETZALES", "Q")
        Dim costoPersona As Decimal = total2 / personas
        Label5.Text = $"Total: {total2:C}"
        Label6.Text = $"Total con letras: {totalLetras}"
        Label7.Text = $"Total persona: {costoPersona:C}"
        Label8.Text = $"Fecha-hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", horario)}"
    End Sub
End Class
