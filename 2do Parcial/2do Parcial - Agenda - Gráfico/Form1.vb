Imports System.Data.SqlClient

Public Class Form1
    Dim connectionString As String = "Data Source=DESKTOP-LOGOIN2\SQLEXPRESS01;Initial Catalog=BaseDatosAgenda;Integrated Security=True"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarContactos()
    End Sub

    Private Sub CargarContactos()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT Nombre, Telefono FROM Contactos"
                Dim command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)

                dgvContactos.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los contactos: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim nombre As String = txtNombre.Text
        Dim telefono As String = txtTelefono.Text

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "INSERT INTO Contactos (Nombre, Telefono) VALUES (@Nombre, @Telefono)"
                Dim command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Nombre", nombre)
                command.Parameters.AddWithValue("@Telefono", telefono)
                command.ExecuteNonQuery()

                MessageBox.Show("Contacto agregado correctamente.")
                CargarContactos()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al agregar contacto: " & ex.Message)
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvContactos.SelectedRows.Count > 0 Then
            Dim nombreActual As String = dgvContactos.SelectedRows(0).Cells("Nombre").Value.ToString()
            Dim telefonoActual As String = dgvContactos.SelectedRows(0).Cells("Telefono").Value.ToString()

            Dim nuevoNombre As String = InputBox("Ingrese el nuevo nombre:", "Editar Nombre", nombreActual)
            Dim nuevoTelefono As String = InputBox("Ingrese el nuevo teléfono:", "Editar Teléfono", telefonoActual)

            Try
                Using connection As New SqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "UPDATE Contactos SET Nombre = @NuevoNombre, Telefono = @NuevoTelefono WHERE 
                    Nombre = @NombreActual AND Telefono = @TelefonoActual"
                    Dim command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@NuevoNombre", nuevoNombre)
                    command.Parameters.AddWithValue("@NuevoTelefono", nuevoTelefono)
                    command.Parameters.AddWithValue("@NombreActual", nombreActual)
                    command.Parameters.AddWithValue("@TelefonoActual", telefonoActual)
                    command.ExecuteNonQuery()

                    MessageBox.Show("Contacto editado correctamente.")
                    CargarContactos()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al editar contacto: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Seleccione un contacto para editar.")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvContactos.SelectedRows.Count > 0 Then
            Dim nombre As String = dgvContactos.SelectedRows(0).Cells("Nombre").Value.ToString()
            Dim telefono As String = dgvContactos.SelectedRows(0).Cells("Telefono").Value.ToString()

            If MessageBox.Show("¿Está seguro que desea eliminar el contacto seleccionado?", "Eliminar Contacto",
                               MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Try
                    Using connection As New SqlConnection(connectionString)
                        connection.Open()
                        Dim query As String = "DELETE FROM Contactos WHERE Nombre = @Nombre AND Telefono = @Telefono"
                        Dim command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@Nombre", nombre)
                        command.Parameters.AddWithValue("@Telefono", telefono)
                        command.ExecuteNonQuery()

                        MessageBox.Show("Contacto eliminado correctamente.")
                        CargarContactos()
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error al eliminar contacto: " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Seleccione un contacto para eliminar.")
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim textoBusqueda As String = txtBuscar.Text.Trim()

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT Nombre, Telefono FROM Contactos WHERE Nombre LIKE @TextoBusqueda OR Telefono 
                LIKE @TextoBusqueda"
                Dim command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@TextoBusqueda", "%" & textoBusqueda & "%")
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)

                dgvContactos.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al buscar contactos: " & ex.Message)
        End Try
    End Sub
End Class
