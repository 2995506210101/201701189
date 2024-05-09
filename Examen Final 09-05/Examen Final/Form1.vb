Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class Form1
    Dim connectionString As String = "Data Source=DESKTOP-LOGOIN2\SQLEXPRESS01;Initial Catalog=TuBaseDeDatos;Integrated Security=True"

    Private Sub btnRegistrarse_Click(sender As Object, e As EventArgs) Handles btnRegistrarse.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        ' Redirigir al Form8
        Dim form8 As New Form8()
        form8.Show()
        Me.Hide()
    End Sub


    Private Sub btnOlvideContraseña_Click(sender As Object, e As EventArgs) Handles btnOlvideContraseña.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        ' Cerrar el programa
        Application.Exit()
    End Sub
End Class

Public Class Form2
        Dim connectionString As String = "Data Source=DESKTOP-LOGOIN2\SQLEXPRESS01;Initial Catalog=TuBaseDeDatos;Integrated Security=True"

        Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
            ' Validar que los datos ingresados cumplan con los requisitos
            Dim validacion = ValidarDatos()
            If validacion = "" Then
                ' Guardar los datos en la base de datos
                GuardarDatosEnBaseDeDatos()
                MessageBox.Show("Usuario creado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Form1.Show()
                Me.Close()
            Else
                MessageBox.Show(validacion, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Function ValidarDatos() As String
            Dim msg = ""
            ' Validación de datos
            If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse Not txtNombre.Text.All(Function(c) Char.IsLetter(c)) Then
                msg += "Nombre faltante o incorrecto."
            End If

            If String.IsNullOrWhiteSpace(txtApellido.Text) OrElse Not txtApellido.Text.All(Function(c) Char.IsLetter(c)) Then
                msg += $"{If(msg <> "", Chr(10), "")}Apellido faltante o incorrecto."
            End If

            If String.IsNullOrWhiteSpace(txtDPI.Text) OrElse Not IsNumeric(txtDPI.Text) OrElse txtDPI.Text.Length <> 13 Then
                msg += $"{If(msg <> "", Chr(10), "")}DPI faltante o incorrecto."
            End If

            If String.IsNullOrWhiteSpace(txtTelefono.Text) OrElse Not IsNumeric(txtTelefono.Text) OrElse txtTelefono.Text.Length <> 8 Then
                msg += $"{If(msg <> "", Chr(10), "")}Teléfono faltante o incorreto."
            End If

            If String.IsNullOrWhiteSpace(txtUsuario.Text) Then
                msg += $"{If(msg <> "", Chr(10), "")}Usuario faltante o incorreto."
            End If

            If String.IsNullOrWhiteSpace(txtContraseña.Text) OrElse txtContraseña.Text.Length < 12 OrElse txtContraseña.Text.Length > 15 Then
                msg += $"{If(msg <> "", Chr(10), "")}Contraseña faltante o incorreto. (12-15 caracteres)"
            End If

            If Not txtContraseña.Text.Any(Function(c) Char.IsUpper(c)) Then
                msg += $"{If(msg <> "", Chr(10), "")}Contraseña debe contener al menos una letra mayúscula."
            End If

            If Not txtContraseña.Text.Any(Function(c) Char.IsDigit(c)) Then
                msg += $"{If(msg <> "", Chr(10), "")}Contraseña debe contener al menos un número."
            End If

            If Not txtContraseña.Text.Any(Function(c) Not Char.IsLetterOrDigit(c)) Then
                msg += $"{If(msg <> "", Chr(10), "")}Contraseña debe contener al menos un símbolo."
            End If

            If txtContraseña.Text <> txtConfirmarContraseña.Text Then
                msg += $"{If(msg <> "", Chr(10), "")}Contraseñas no coinciden."
            End If

            If String.IsNullOrWhiteSpace(txtCorreoElectronico.Text) Then
                msg += $"{If(msg <> "", Chr(10), "")}Correo electrónico es obligatorio."
            End If

            Return msg
        End Function

        Private Function EncryptString(ByVal plainText As String, ByVal key As String, ByVal IV As String) As String
            Dim aesAlg As New AesManaged()
            aesAlg.Key = Encoding.ASCII.GetBytes(key)
            aesAlg.IV = Encoding.ASCII.GetBytes(IV)

            Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)
            Dim msEncrypt As New MemoryStream()

            Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                Using swEncrypt As New StreamWriter(csEncrypt)
                    swEncrypt.Write(plainText)
                End Using
            End Using

            Return Convert.ToBase64String(msEncrypt.ToArray())
        End Function

        Private Sub GuardarDatosEnBaseDeDatos()
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim command As New SqlCommand("INSERT INTO Usuarios (Nombre, Apellido, DPI, FechaNacimiento, Telefono, NombreUsuario, Contraseña, Email) VALUES (@Nombre, @Apellido, @DPI, @FechaNacimiento, @Telefono, @NombreUsuario, @Contraseña, @Email)", connection)
                command.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                command.Parameters.AddWithValue("@Apellido", txtApellido.Text)
                command.Parameters.AddWithValue("@DPI", txtDPI.Text)
                command.Parameters.AddWithValue("@FechaNacimiento", dtpFechaNacimiento.Value)
                command.Parameters.AddWithValue("@Telefono", txtTelefono.Text)
                command.Parameters.AddWithValue("@NombreUsuario", txtUsuario.Text)
                command.Parameters.AddWithValue("@Contraseña", EncryptString(txtContraseña.Text, "SiSaleProgra092_SiSaleProgra092_", "1S2024_1S2024_1S"))
                command.Parameters.AddWithValue("@Email", txtCorreoElectronico.Text)
                command.ExecuteNonQuery()
            End Using
        End Sub

        Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
            ' Regresar al Form1
            Form1.Show()
            Me.Hide()
        End Sub

    End Class

    Public Class Form3
    Private Sub btnCitas_Click(sender As Object, e As EventArgs) Handles btnCitas.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub btnSuministros_Click(sender As Object, e As EventArgs) Handles btnSuministros.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub btnContabilidad_Click(sender As Object, e As EventArgs) Handles btnContabilidad.Click
        ' Lógica para abrir el formulario de contabilidad
        Form9.Show()
        Me.Hide()
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        ' Regresar al Form1
        Form1.Show()
        Me.Hide()
    End Sub

End Class

Public Class Form4
    Dim connectionString As String = "Data Source=DESKTOP-LOGOIN2\SQLEXPRESS01;Initial Catalog=TuBaseDeDatos;Integrated Security=True"

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        ' Validar que los datos ingresados cumplan con los requisitos
        If ValidarDatos() Then
            ' Guardar los datos en la base de datos
            GuardarDatosEnBaseDeDatos()
            MessageBox.Show("Cita ingresada correctamente", "Ingreso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ActualizarDataGridView()
        Else
            MessageBox.Show("Por favor, ingrese los datos correctamente", "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function ValidarDatos() As Boolean
        ' Validación de datos
        If String.IsNullOrWhiteSpace(txtNombreCompleto.Text) OrElse Not txtNombreCompleto.Text.All(Function(c) Char.IsLetter(c)) Then
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtTelefono.Text) OrElse Not IsNumeric(txtTelefono.Text) OrElse txtTelefono.Text.Length <> 8 Then
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtMotivoCita.Text) Then
            Return False
        End If

        Return True
    End Function

    Private Sub GuardarDatosEnBaseDeDatos()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("INSERT INTO Citas (NombreCompleto, Telefono, MotivoCita, FechaHoraCita, TieneSeguroMedico) VALUES (@NombreCompleto, @Telefono, @MotivoCita, @FechaHoraCita, @TieneSeguroMedico)", connection)
            command.Parameters.AddWithValue("@NombreCompleto", txtNombreCompleto.Text)
            command.Parameters.AddWithValue("@Telefono", txtTelefono.Text)
            command.Parameters.AddWithValue("@MotivoCita", txtMotivoCita.Text)
            command.Parameters.AddWithValue("@FechaHoraCita", dtpFechaHoraCita.Value)
            command.Parameters.AddWithValue("@TieneSeguroMedico", If(rbSi.Checked, "Si", "No"))
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub ActualizarDataGridView()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("SELECT * FROM Citas", connection)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End Using
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        ' Validar que se haya seleccionado un registro para editar
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Validar que los datos ingresados cumplan con los requisitos
            If ValidarDatos() Then
                ' Editar los datos en la base de datos
                EditarDatosEnBaseDeDatos()
                MessageBox.Show("Cita editada correctamente", "Edición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ActualizarDataGridView()
            Else
                MessageBox.Show("Por favor, ingrese los datos correctamente", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Por favor, seleccione una cita para editar", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EditarDatosEnBaseDeDatos()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("UPDATE Citas SET NombreCompleto = @NombreCompleto, Telefono = @Telefono, MotivoCita = @MotivoCita, FechaHoraCita = @FechaHoraCita, TieneSeguroMedico = @TieneSeguroMedico WHERE Id = @Id", connection)
            command.Parameters.AddWithValue("@Id", DataGridView1.SelectedRows(0).Cells("Id").Value)
            command.Parameters.AddWithValue("@NombreCompleto", txtNombreCompleto.Text)
            command.Parameters.AddWithValue("@Telefono", txtTelefono.Text)
            command.Parameters.AddWithValue("@MotivoCita", txtMotivoCita.Text)
            command.Parameters.AddWithValue("@FechaHoraCita", dtpFechaHoraCita.Value)
            command.Parameters.AddWithValue("@TieneSeguroMedico", If(rbSi.Checked, "Si", "No"))
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        ' Validar que se haya seleccionado un registro para eliminar
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Eliminar el registro de la base de datos
            EliminarDatosDeBaseDeDatos()
            MessageBox.Show("Cita eliminada correctamente", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ActualizarDataGridView()
        Else
            MessageBox.Show("Por favor, seleccione una cita para eliminar", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EliminarDatosDeBaseDeDatos()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("DELETE FROM Citas WHERE Id = @Id", connection)
            command.Parameters.AddWithValue("@Id", DataGridView1.SelectedRows(0).Cells("Id").Value)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarCampos()
    End Sub

    Private Sub LimpiarCampos()
        txtNombreCompleto.Clear()
        txtTelefono.Clear()
        txtMotivoCita.Clear()
        dtpFechaHoraCita.Value = DateTime.Now
        rbSi.Checked = False
        rbNo.Checked = False
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar los datos en el DataGridView al cargar el formulario
        ActualizarDataGridView()
    End Sub
End Class

Public Class Form5
    Dim connectionString As String = "Data Source=DESKTOP-LOGOIN2\SQLEXPRESS01;Initial Catalog=TuBaseDeDatos;Integrated Security=True"

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        ' Validar que los datos ingresados cumplan con los requisitos
        If ValidarDatos() Then
            ' Guardar los datos en la base de datos
            GuardarDatosEnBaseDeDatos()
            MessageBox.Show("Suministro ingresado correctamente", "Ingreso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ActualizarDataGridView()
        Else
            MessageBox.Show("Por favor, ingrese los datos correctamente", "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function ValidarDatos() As Boolean
        ' Validación de datos
        If String.IsNullOrWhiteSpace(txtNombreCompleto.Text) OrElse Not txtNombreCompleto.Text.All(Function(c) Char.IsLetter(c)) Then
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtTelefono.Text) OrElse Not IsNumeric(txtTelefono.Text) OrElse txtTelefono.Text.Length <> 8 Then
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtMedicamento.Text) Then
            Return False
        End If

        Return True
    End Function

    Private Sub GuardarDatosEnBaseDeDatos()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("INSERT INTO Suministros (NombreCompleto, Telefono, Medicamento, FechaPrescripcion, Direccion, MetodoPago) VALUES (@NombreCompleto, @Telefono, @Medicamento, @FechaPrescripcion, @Direccion, @MetodoPago)", connection)
            command.Parameters.AddWithValue("@NombreCompleto", txtNombreCompleto.Text)
            command.Parameters.AddWithValue("@Telefono", txtTelefono.Text)
            command.Parameters.AddWithValue("@Medicamento", txtMedicamento.Text)
            command.Parameters.AddWithValue("@FechaPrescripcion", dtpFechaPrescripcion.Value)
            command.Parameters.AddWithValue("@Direccion", txtDireccion.Text)
            command.Parameters.AddWithValue("@MetodoPago", If(rbEfectivo.Checked, "Efectivo", "Tarjeta"))
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub ActualizarDataGridView()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("SELECT * FROM Suministros", connection)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End Using
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        ' Validar que se haya seleccionado un registro para editar
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Validar que los datos ingresados cumplan con los requisitos
            If ValidarDatos() Then
                ' Editar los datos en la base de datos
                EditarDatosEnBaseDeDatos()
                MessageBox.Show("Suministro editado correctamente", "Edición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ActualizarDataGridView()
            Else
                MessageBox.Show("Por favor, ingrese los datos correctamente", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Por favor, seleccione un suministro para editar", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EditarDatosEnBaseDeDatos()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("UPDATE Suministros SET NombreCompleto = @NombreCompleto, Telefono = @Telefono, Medicamento = @Medicamento, FechaPrescripcion = @FechaPrescripcion, Direccion = @Direccion, MetodoPago = @MetodoPago WHERE Id = @Id", connection)
            command.Parameters.AddWithValue("@Id", DataGridView1.SelectedRows(0).Cells("Id").Value)
            command.Parameters.AddWithValue("@NombreCompleto", txtNombreCompleto.Text)
            command.Parameters.AddWithValue("@Telefono", txtTelefono.Text)
            command.Parameters.AddWithValue("@Medicamento", txtMedicamento.Text)
            command.Parameters.AddWithValue("@FechaPrescripcion", dtpFechaPrescripcion.Value)
            command.Parameters.AddWithValue("@Direccion", txtDireccion.Text)
            command.Parameters.AddWithValue("@MetodoPago", If(rbEfectivo.Checked, "Efectivo", "Tarjeta"))
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        ' Validar que se haya seleccionado un registro para eliminar
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Eliminar el registro de la base de datos
            EliminarDatosDeBaseDeDatos()
            MessageBox.Show("Suministro eliminado correctamente", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ActualizarDataGridView()
        Else
            MessageBox.Show("Por favor, seleccione un suministro para eliminar", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EliminarDatosDeBaseDeDatos()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("DELETE FROM Suministros WHERE Id = @Id", connection)
            command.Parameters.AddWithValue("@Id", DataGridView1.SelectedRows(0).Cells("Id").Value)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarCampos()
    End Sub

    Private Sub LimpiarCampos()
        txtNombreCompleto.Clear()
        txtTelefono.Clear()
        txtMedicamento.Clear()
        dtpFechaPrescripcion.Value = DateTime.Now
        txtDireccion.Clear()
        rbEfectivo.Checked = False
        rbTarjeta.Checked = False
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar los datos en el DataGridView al cargar el formulario
        ActualizarDataGridView()
    End Sub
End Class

Public Class Form6
    Dim connectionString As String = "Data Source=DESKTOP-LOGOIN2\SQLEXPRESS01;Initial Catalog=TuBaseDeDatos;Integrated Security=True"

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        ' Verificar si los datos ingresados son válidos
        If ValidarDatos() Then
            ' Verificar si los datos ingresados coinciden con los registrados en la base de datos
            If VerificarDatos() Then
                ' Mostrar Form7 para cambiar la contraseña
                Dim form7 As New Form7(txtUsuario.Text)
                form7.Show()
                Me.Hide()
            Else
                MessageBox.Show("Los datos ingresados no coinciden con nuestros registros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Por favor, ingrese los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function ValidarDatos() As Boolean
        ' Validar que los datos ingresados no estén vacíos
        If String.IsNullOrWhiteSpace(txtUsuario.Text) OrElse String.IsNullOrWhiteSpace(txtDPI.Text) OrElse String.IsNullOrWhiteSpace(txtCorreoElectronico.Text) Then
            Return False
        End If
        Return True
    End Function

    Private Function VerificarDatos() As Boolean
        ' Verificar que los datos ingresados coincidan con los registrados en la base de datos
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND DPI = @DPI AND Email = @Email", connection)
            command.Parameters.AddWithValue("@NombreUsuario", txtUsuario.Text)
            command.Parameters.AddWithValue("@DPI", txtDPI.Text)
            command.Parameters.AddWithValue("@Email", txtCorreoElectronico.Text)
            Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
            If count > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        ' Regresar al Form1
        Form1.Show()
        Me.Hide()
    End Sub

End Class

Public Class Form7
    Dim connectionString As String = "Data Source=DESKTOP-LOGOIN2\SQLEXPRESS01;Initial Catalog=TuBaseDeDatos;Integrated Security=True"
    Dim usuario As String

    Public Sub New(usuario As String)
        InitializeComponent()
        Me.usuario = usuario
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        ' Verificar si la nueva contraseña cumple con los requisitos
        If ValidarContraseña() Then
            ' Actualizar la contraseña en la base de datos
            ActualizarContraseña()
            MessageBox.Show("Contraseña actualizada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim form8 As New Form8()
            form8.Show()
            Me.Hide()
        Else
            MessageBox.Show("Por favor, ingrese una contraseña válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function ValidarContraseña() As Boolean
        ' Validar que la contraseña cumpla con los requisitos
        If String.IsNullOrWhiteSpace(txtNuevaContraseña.Text) OrElse String.IsNullOrWhiteSpace(txtConfirmarContraseña.Text) Then
            Return False
        End If

        If txtNuevaContraseña.Text.Length < 12 OrElse txtNuevaContraseña.Text.Length > 15 Then
            Return False
        End If

        If Not txtNuevaContraseña.Text.Any(Function(c) Char.IsUpper(c)) Then
            Return False
        End If

        If Not txtNuevaContraseña.Text.Any(Function(c) Char.IsDigit(c)) Then
            Return False
        End If

        If Not txtNuevaContraseña.Text.Any(Function(c) Not Char.IsLetterOrDigit(c)) Then
            Return False
        End If

        If txtNuevaContraseña.Text <> txtConfirmarContraseña.Text Then
            Return False
        End If

        Return True
    End Function

    Private Function EncryptString(ByVal plainText As String, ByVal key As String, ByVal IV As String) As String
        Dim aesAlg As New AesManaged()
        aesAlg.Key = Encoding.ASCII.GetBytes(key)
        aesAlg.IV = Encoding.ASCII.GetBytes(IV)

        Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)
        Dim msEncrypt As New MemoryStream()

        Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
            Using swEncrypt As New StreamWriter(csEncrypt)
                swEncrypt.Write(plainText)
            End Using
        End Using

        Return Convert.ToBase64String(msEncrypt.ToArray())
    End Function

    Private Sub ActualizarContraseña()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("UPDATE Usuarios SET Contraseña = @Contraseña WHERE NombreUsuario = @NombreUsuario", connection)
            command.Parameters.AddWithValue("@Contraseña", EncryptString(txtNuevaContraseña.Text, "SiSaleProgra092_SiSaleProgra092_", "1S2024_1S2024_1S"))
            command.Parameters.AddWithValue("@NombreUsuario", usuario)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Class

Public Class Form8
    Dim intentos As Integer = 0
    Dim connectionString As String = "Data Source=DESKTOP-LOGOIN2\SQLEXPRESS01;Initial Catalog=TuBaseDeDatos;Integrated Security=True"

    Private Function EncryptString(ByVal plainText As String, ByVal key As String, ByVal IV As String) As String
        Dim aesAlg As New AesManaged()
        aesAlg.Key = Encoding.ASCII.GetBytes(key)
        aesAlg.IV = Encoding.ASCII.GetBytes(IV)

        Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)
        Dim msEncrypt As New MemoryStream()

        Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
            Using swEncrypt As New StreamWriter(csEncrypt)
                swEncrypt.Write(plainText)
            End Using
        End Using

        Return Convert.ToBase64String(msEncrypt.ToArray())
    End Function

    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        ' Verificar usuario y contraseña en la base de datos
        If VerificarUsuario(txtUsuario.Text, txtContraseña.Text) Then
            ' Redirigir al Form3 si el usuario es válido
            Form3.Show()
            Me.Hide()
        Else
            ' Incrementar el contador de intentos
            intentos += 1

            ' Mostrar mensaje de error si se exceden los 3 intentos
            If intentos >= 3 Then
                MessageBox.Show("Ha excedido el número máximo de intentos. Por favor, reinicie su contraseña.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' Redirigir al Form1
                Form1.Show()
                Me.Hide()
            Else
                MessageBox.Show("Usuario o contraseña incorrectos. Intento " & intentos & "/3", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Function VerificarUsuario(usuario As String, contraseña As String) As Boolean
        Dim usuarioValido As Boolean = False

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@NombreUsuario", usuario)
            command.Parameters.AddWithValue("@Contraseña", EncryptString(contraseña, "SiSaleProgra092_SiSaleProgra092_", "1S2024_1S2024_1S"))

            ' Verificar usuario y contraseña en la base de datos
            If Convert.ToInt32(command.ExecuteScalar()) > 0 Then
                usuarioValido = True
            End If
        End Using

        Return usuarioValido
    End Function

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        ' Regresar al Form1
        Form1.Show()
        Me.Hide()
    End Sub

End Class

Public Class Form9
    Dim connectionString As String = "Data Source=DESKTOP-LOGOIN2\SQLEXPRESS01;Initial Catalog=TuBaseDeDatos;Integrated Security=True"

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim dataTable As New DataTable()
                Dim query As String = "SELECT Id, NombreCompleto AS 'Nombre Completo', Telefono, Medicamento, FechaPrescripcion AS 'Fecha Prescripción', Direccion, MetodoPago AS 'Método De Pago' FROM Suministros"
                Dim adapter As New SqlDataAdapter(query, connection)
                adapter.Fill(dataTable)
                DataGridView1.DataSource = dataTable
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Form3.Show()
        Me.Hide()
    End Sub
End Class
