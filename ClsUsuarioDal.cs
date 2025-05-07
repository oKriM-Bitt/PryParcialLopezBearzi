using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PryPueblox
{
    class ClsUsuarioCRUD
    {
       

        #region Variables y Conexión
        // --- Cadena de Conexión  ---
        private string CadenaConexion = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=BdResto.mdb";
        #endregion

        #region CRUD Crear

        
        // Registra un nuevo usuario en la base de datos con la contraseña ya hasheada.
     
        public bool RegistrarUsuario(string nombre, string apellido, string correo, int idCategoriaU, string nombreUsuario, string contraseñaHasheada, string telefono)
        {
            bool exito = false;
            // Consulta SQL para insertar un nuevo usuario. Los nombres de campo con espacios deben ir entre corchetes [].
            string query = "INSERT INTO Usuario ([Nombre], [Apellido], [Correo], [IdCategoriaU], [Nombre de Usuario], [Contraseña], [Telefono]) VALUES (?, ?, ?, ?, ?, ?, ?)";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    // Añadir parámetros en el orden en que aparecen los '?' en la consulta.
                    cmd.Parameters.Add("pNombre", OleDbType.VarWChar).Value = nombre;
                    cmd.Parameters.Add("pApellido", OleDbType.VarWChar).Value = apellido;
                    cmd.Parameters.Add("pCorreo", OleDbType.VarWChar).Value = correo;
                    cmd.Parameters.Add("pIdCategoriaU", OleDbType.Integer).Value = idCategoriaU;
                    cmd.Parameters.Add("pNombreUsuario", OleDbType.VarWChar).Value = nombreUsuario;
                    cmd.Parameters.Add("pContraseña", OleDbType.VarWChar).Value = contraseñaHasheada; // Se asume que esta ya es el hash.
                    // Si el teléfono es nulo o solo espacios en blanco, se inserta DBNull.Value para representar un valor nulo en la BD.
                    cmd.Parameters.Add("pTelefono", OleDbType.VarWChar).Value = string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono;

                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery(); // ExecuteNonQuery devuelve el número de filas afectadas por la operación.
                    exito = (filasAfectadas > 0); // Si se afectó al menos una fila, el registro fue exitoso.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar usuario:\n{ex.Message}", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                exito = false;
            }
            return exito;
        }

        #endregion

        #region CRUD Leer

      
        // Verifica si un nombre de usuario ya existe en la base de datos.
    
        public bool UsuarioExiste(string nombreUsuario)
        {
            bool existe = false;
            // Consulta para contar cuántos usuarios existen con el nombre de usuario proporcionado.
            string query = "SELECT COUNT(*) FROM Usuario WHERE [Nombre de Usuario] = ?";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("pUsuario", OleDbType.VarWChar).Value = nombreUsuario;
                    conn.Open();
                    // ExecuteScalar se usa cuando la consulta devuelve un único valor (en este caso, el conteo).
                    int count = (int)cmd.ExecuteScalar();
                    existe = (count > 0); // Si el conteo es mayor a 0, el usuario existe.
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar si usuario existe: {ex.Message}"); // Útil para debugging en consola.
                MessageBox.Show($"Error al verificar existencia de usuario:\n{ex.Message}", "Error de Verificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                existe = false; // En caso de error, se asume que no existe o no se pudo verificar.
            }
            return existe;
        }

        
        // Verifica las credenciales de login comparando la contraseña ingresada (hasheada) con la almacenada en la BD.
        
        public bool VerificarLogin(string nombreUsuario, string contraseñaIngresada)
        {
            string passDb = ""; // Variable para almacenar la contraseña hasheada obtenida de la BD.
            // Consulta para obtener la contraseña del usuario especificado.
            string query = "SELECT [Contraseña] FROM Usuario WHERE [Nombre de Usuario] = ?";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("pUsuario", OleDbType.VarWChar).Value = nombreUsuario;
                    conn.Open();
                    object result = cmd.ExecuteScalar(); // Obtiene el valor de la contraseña.

                    if (result != null && result != DBNull.Value) // Verifica que se haya obtenido un valor.
                    {
                        passDb = result.ToString();
                    }
                    else
                    {
                        return false; // Usuario no encontrado o sin contraseña (no debería pasar si está bien diseñado).
                    }
                }
                // Hashea la contraseña ingresada por el usuario para compararla con la almacenada.
                string passIngresadaHash = HashPassword(contraseñaIngresada);
                return passDb.Equals(passIngresadaHash); // Compara los hashes.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar login:\n{ex.Message}", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        
        // Obtiene toda la información de un usuario específico buscándolo por su nombre de usuario.
      
        public DataRow GetUsuarioInfoCompleta(string nombreUsuario)
        {
            DataTable dt = new DataTable();
            string query = "SELECT IdUsuario, Nombre, Apellido, Correo, IdCategoriaU, [Nombre de Usuario], Telefono FROM Usuario WHERE [Nombre de Usuario] = ?";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("pUsuario", OleDbType.VarWChar).Value = nombreUsuario;
                    // OleDbDataAdapter se usa para llenar un DataSet o DataTable con los resultados de una consulta.
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt); // Llena el DataTable con los datos.
                    }
                }
                if (dt.Rows.Count > 0) // Si se encontró al menos una fila.
                {
                    return dt.Rows[0]; // Devuelve la primera fila (debería ser única).
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos completos del usuario:\n{ex.Message}", "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null; // Devuelve null si no se encuentra o hay error.
        }

      
        // Obtiene toda la información de un usuario específico buscándolo por su ID.
    
        public DataRow GetUsuarioPorId(int idUsuario)
        {
            DataTable dt = new DataTable();
            string query = "SELECT IdUsuario, Nombre, Apellido, Correo, IdCategoriaU, [Nombre de Usuario], Telefono FROM Usuario WHERE IdUsuario = ?";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("pID", OleDbType.Integer).Value = idUsuario;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener usuario por ID:\n{ex.Message}", "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        #endregion

        #region CRUD Actualizar

      
        // Actualiza la información completa de un usuario en la base de datos.
        // Permite actualizar nombre, apellido, correo, teléfono y opcionalmente la contraseña y/o el ID de categoría.
      
        public bool ActualizarUsuarioCompleto(int idUsuario, string nuevoNombre, string nuevoApellido, string nuevoCorreo, string nuevoTelefono,
                                              string nuevaContrasenaPlana = null, int nuevoIdCategoriaU = 0)
        {
            bool exito = false;
            List<OleDbParameter> parameters = new List<OleDbParameter>(); // Lista para manejar los parámetros dinámicamente.

            // Construcción dinámica de la cláusula SET de la consulta UPDATE.
            string setClause = "SET [Nombre] = ?, [Apellido] = ?, [Correo] = ?, [Telefono] = ?";
            parameters.Add(new OleDbParameter("pNombre", OleDbType.VarWChar) { Value = nuevoNombre });
            parameters.Add(new OleDbParameter("pApellido", OleDbType.VarWChar) { Value = nuevoApellido });
            parameters.Add(new OleDbParameter("pCorreo", OleDbType.VarWChar) { Value = nuevoCorreo });
            parameters.Add(new OleDbParameter("pTelefono", OleDbType.VarWChar) { Value = string.IsNullOrWhiteSpace(nuevoTelefono) ? (object)DBNull.Value : nuevoTelefono });

            if (!string.IsNullOrEmpty(nuevaContrasenaPlana)) // Si se provee una nueva contraseña.
            {
                string contraHasheada = HashPassword(nuevaContrasenaPlana);
                setClause += ", [Contraseña] = ?"; // Se añade la actualización de contraseña al SET.
                parameters.Add(new OleDbParameter("pContra", OleDbType.VarWChar) { Value = contraHasheada });
            }

            if (nuevoIdCategoriaU > 0) // Si se provee un nuevo ID de categoría.
            {
                setClause += ", [IdCategoriaU] = ?"; // Se añade la actualización de categoría al SET.
                parameters.Add(new OleDbParameter("pRol", OleDbType.Integer) { Value = nuevoIdCategoriaU });
            }

            // El parámetro para la cláusula WHERE (IdUsuario) debe ser el último en la lista si los otros son opcionales
            // y se añaden antes, ya que OleDb empareja los '?' por orden.
            string query = $"UPDATE Usuario {setClause} WHERE IdUsuario = ?";
            parameters.Add(new OleDbParameter("pIDWhere", OleDbType.Integer) { Value = idUsuario }); // El parámetro para el WHERE.

            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray()); // Añade todos los parámetros a la colección del comando.
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = (filasAfectadas > 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar usuario:\n{ex.Message}", "Error de Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                exito = false;
            }
            return exito;
        }

        #endregion

        #region CRUD Eliminar

      
        // Elimina un usuario de la base de datos utilizando su ID.
        public bool EliminarUsuario(int idUsuario)
        {
            bool exito = false;
            string query = "DELETE FROM Usuario WHERE IdUsuario = ?";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("pID", OleDbType.Integer).Value = idUsuario;
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = (filasAfectadas > 0);
                }
            }
            catch (OleDbException dbEx) // Captura excepciones específicas de OleDb para más detalle.
            {
                // Comprueba si el error es por violación de integridad referencial (ForeignKey).
                // El código -2147467259 es común para esto en Access.
                if (dbEx.ErrorCode == -2147467259 || (dbEx.Message != null && (dbEx.Message.Contains("referential integrity") || dbEx.Message.Contains("constraint violation"))))
                {
                    MessageBox.Show($"No se pudo eliminar el usuario: tiene registros relacionados en otras tablas.", "Error de Integridad Referencial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error de base de datos al eliminar:\n{dbEx.Message}", "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                exito = false;
            }
            catch (Exception ex) // Captura cualquier otra excepción general.
            {
                MessageBox.Show($"Error general al eliminar usuario:\n{ex.Message}", "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                exito = false;
            }
            return exito;
        }

        #endregion

        #region Métodos Auxiliares (Hash)


        /// Genera un hash SHA256 de una contraseña proporcionada. 
        public string HashPassword(string password)
        {
            // Se utiliza SHA256 para crear el hash.
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convierte la contraseña (string) a un array de bytes usando codificación UTF-8.
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Convierte el array de bytes (el hash) a una representación en string usando Base64.
                // Base64 es útil para almacenar/transmitir datos binarios como texto.
                return Convert.ToBase64String(bytes);
            }
        }

        #endregion
    }
}