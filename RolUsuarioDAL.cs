using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PryPueblox
{
    class RolUsuarioDAL
    {
        // --- Cadena de Conexión ---
        private string CadenaConexion = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=BdResto.mdb";

        // Tabla virtual sin uso 
        public DataTable GetRolesUsuarioDataTable()
        {
            // ... (El código que teníamos antes para devolver DataTable) ...
            // Si no lo necesitas más, puedes borrarlo, pero no molesta dejarlo.
            DataTable dt = new DataTable();
            string query = "SELECT IdCategoriaU, Categoria FROM CategoriaU ORDER BY Categoria";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error BD en RolUsuarioDAL.GetRolesUsuarioDataTable: {ex.Message}");
                // Considera no mostrar MessageBox aquí si el método que llama lo hace
                dt = new DataTable();
            }
            return dt;
        }



       
        /// Carga los roles de usuario (desde CategoriaU) directamente en un ComboBox.
  
        public void CargarRolesUsuarioDirectoEnCombo(ComboBox cmb) // Nombre descriptivo
        {
            try
            {
                // Usar 'using' para asegurar que la conexión se cierre
                using (OleDbConnection connLocal = new OleDbConnection(CadenaConexion))
                {
                    connLocal.Open(); // Abrir conexión

                    // *** Consulta SQL adaptada para ROLES ***
                    // Verifica Tabla=CategoriaU, ID=IdCategoriaU, Texto=Categoria
                    string query = "SELECT IdCategoriaU, Categoria FROM CategoriaU ORDER BY Categoria";

                    using (OleDbDataAdapter da = new OleDbDataAdapter(query, connLocal))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt); // Llenar la tabla

                        // --- Configuración directa del ComboBox ---
                        cmb.DataSource = dt;             // Asignar datos
                        cmb.DisplayMember = "Categoria"; // Columna de Texto (Nombre del Rol)
                        cmb.ValueMember = "IdCategoriaU";  // Columna de Valor (ID del Rol)
                        cmb.DropDownStyle = ComboBoxStyle.DropDownList; // Estilo
                        cmb.SelectedIndex = -1;          // Sin selección inicial

                        Console.WriteLine($"ComboBox '{cmb.Name}' cargado directamente con {dt.Rows.Count} roles desde RolUsuarioDAL.");
                    }
                } // La conexión se cierra aquí automáticamente
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al cargar roles de usuario directamente en ComboBox '{cmb.Name}':\n{ex.Message}",
                                "Error Carga Roles (DAL)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Limpiar el ComboBox si hubo error
                cmb.DataSource = null;
                cmb.Items.Clear();
            }
        }
       

    } 
}