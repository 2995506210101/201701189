Imports System.Data.SqlClient

Public Class Form1
    Dim connectionString As String = "Data Source=DESKTOP-LOGOIN2\SQLEXPRESS01;Initial Catalog=BaseGestor;Integrated Security=True"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Mostrar tareas pendientes al cargar el formulario
        MostrarTareasPendientes()
    End Sub

    Private Sub MostrarTareasPendientes()
        Dim dataTable As New DataTable()

        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT Curso, Tarea, Fecha, Estado FROM TareasGestor WHERE Estado = 'Pendiente'"
            Dim adapter As New SqlDataAdapter(query, connection)

            Try
                connection.Open()
                adapter.Fill(dataTable)
                DataGridViewTareas.DataSource = dataTable
            Catch ex As Exception
                MessageBox.Show("Error al mostrar las tareas pendientes: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub ButtonAgregar_Click(sender As Object, e As EventArgs) Handles ButtonAgregar.Click
        AgregarTarea()
    End Sub

    Private Sub ButtonEditar_Click(sender As Object, e As EventArgs) Handles ButtonEditar.Click
        EditarTarea()
    End Sub

    Private Sub ButtonEliminar_Click(sender As Object, e As EventArgs) Handles ButtonEliminar.Click
        EliminarTarea()
    End Sub

    Private Sub ButtonMarcar_Click(sender As Object, e As EventArgs) Handles ButtonMarcar.Click
        MarcarComoCompletada()
    End Sub

    Private Sub AgregarTarea()
        Dim curso As String = TextBoxCurso.Text
        Dim tarea As String = TextBoxTarea.Text
        Dim fecha As String = TextBoxFecha.Text
        Dim estado As String = "Pendiente"

        Using connection As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO TareasGestor (Curso, Tarea, Fecha, Estado) VALUES (@Curso, @Tarea, @Fecha, @Estado)"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Curso", curso)
            command.Parameters.AddWithValue("@Tarea", tarea)
            command.Parameters.AddWithValue("@Fecha", fecha)
            command.Parameters.AddWithValue("@Estado", estado)

            Try
                connection.Open()
                command.ExecuteNonQuery()
                MessageBox.Show("Tarea agregada correctamente.")
                MostrarTareasPendientes() ' Actualizamos el DataGridView después de agregar la tarea
            Catch ex As Exception
                MessageBox.Show("Error al agregar la tarea: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub EditarTarea()
        If DataGridViewTareas.SelectedRows.Count > 0 Then
            Dim curso As String = DataGridViewTareas.SelectedRows(0).Cells("Curso").Value.ToString()
            Dim tarea As String = DataGridViewTareas.SelectedRows(0).Cells("Tarea").Value.ToString()
            Dim fecha As String = DataGridViewTareas.SelectedRows(0).Cells("Fecha").Value.ToString()

            Dim nuevoCurso As String = InputBox("Ingrese el nuevo curso:", "Editar Curso", curso)
            Dim nuevaTarea As String = InputBox("Ingrese la nueva tarea:", "Editar Tarea", tarea)
            Dim nuevaFecha As String = InputBox("Ingrese la nueva fecha:", "Editar Fecha", fecha)

            If Not String.IsNullOrEmpty(nuevoCurso) AndAlso Not String.IsNullOrEmpty(nuevaTarea) AndAlso Not String.IsNullOrEmpty(nuevaFecha) Then
                Using connection As New SqlConnection(connectionString)
                    Dim query As String = "UPDATE TareasGestor SET Curso = @NuevoCurso, Tarea = @NuevaTarea, Fecha = @NuevaFecha WHERE Curso = @Curso AND Tarea = @Tarea AND Fecha = @Fecha"
                    Dim command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@NuevoCurso", nuevoCurso)
                    command.Parameters.AddWithValue("@NuevaTarea", nuevaTarea)
                    command.Parameters.AddWithValue("@NuevaFecha", nuevaFecha)
                    command.Parameters.AddWithValue("@Curso", curso)
                    command.Parameters.AddWithValue("@Tarea", tarea)
                    command.Parameters.AddWithValue("@Fecha", fecha)

                    Try
                        connection.Open()
                        command.ExecuteNonQuery()
                        MessageBox.Show("Tarea editada correctamente.")
                        MostrarTareasPendientes() ' Actualizamos el DataGridView después de editar la tarea
                    Catch ex As Exception
                        MessageBox.Show("Error al editar la tarea: " & ex.Message)
                    End Try
                End Using
            End If
        Else
            MessageBox.Show("Seleccione una tarea para editar.")
        End If
    End Sub

    Private Sub EliminarTarea()
        If DataGridViewTareas.SelectedRows.Count > 0 Then
            Dim curso As String = DataGridViewTareas.SelectedRows(0).Cells("Curso").Value.ToString()
            Dim tarea As String = DataGridViewTareas.SelectedRows(0).Cells("Tarea").Value.ToString()
            Dim fecha As String = DataGridViewTareas.SelectedRows(0).Cells("Fecha").Value.ToString()

            Dim resultado As DialogResult = MessageBox.Show("¿Está seguro de eliminar esta tarea?", "Confirmar eliminación", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then
                Using connection As New SqlConnection(connectionString)
                    Dim query As String = "DELETE FROM TareasGestor WHERE Curso = @Curso AND Tarea = @Tarea AND Fecha = @Fecha"
                    Dim command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Curso", curso)
                    command.Parameters.AddWithValue("@Tarea", tarea)
                    command.Parameters.AddWithValue("@Fecha", fecha)

                    Try
                        connection.Open()
                        command.ExecuteNonQuery()
                        MessageBox.Show("Tarea eliminada correctamente.")
                        MostrarTareasPendientes() ' Actualizamos el DataGridView después de eliminar la tarea
                    Catch ex As Exception
                        MessageBox.Show("Error al eliminar la tarea: " & ex.Message)
                    End Try
                End Using
            End If
        Else
            MessageBox.Show("Seleccione una tarea para eliminar.")
        End If
    End Sub

    Private Sub MarcarComoCompletada()
        If DataGridViewTareas.SelectedRows.Count > 0 Then
            Dim curso As String = DataGridViewTareas.SelectedRows(0).Cells("Curso").Value.ToString()
            Dim tarea As String = DataGridViewTareas.SelectedRows(0).Cells("Tarea").Value.ToString()
            Dim fecha As String = DataGridViewTareas.SelectedRows(0).Cells("Fecha").Value.ToString()

            Dim resultado As DialogResult = MessageBox.Show("¿Está seguro de marcar esta tarea como completada?", "Confirmar acción", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then
                Dim estado As String = "Completada"
                Using connection As New SqlConnection(connectionString)
                    Dim query As String = "UPDATE TareasGestor SET Estado = @Estado WHERE Curso = @Curso AND Tarea = @Tarea AND Fecha = @Fecha AND Estado = 'Pendiente'"
                    Dim command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Estado", estado)
                    command.Parameters.AddWithValue("@Curso", curso)
                    command.Parameters.AddWithValue("@Tarea", tarea)
                    command.Parameters.AddWithValue("@Fecha", fecha)

                    Try
                        connection.Open()
                        command.ExecuteNonQuery()
                        MessageBox.Show("Tarea marcada como completada correctamente.")
                        MostrarTareasPendientes() ' Actualizamos el DataGridView después de marcar como completada
                    Catch ex As Exception
                        MessageBox.Show("Error al marcar la tarea como completada: " & ex.Message)
                    End Try
                End Using
            End If
        Else
            MessageBox.Show("Seleccione una tarea para marcar como completada.")
        End If
    End Sub
End Class
