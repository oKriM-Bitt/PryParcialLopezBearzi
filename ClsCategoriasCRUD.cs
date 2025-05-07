using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace PryPueblox
{
   
    public class ClsCategoriasCRUD
    {
        #region Variables y Conexión

        // conexion BD
        private string CadenaConexion = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=BdResto.mdb";

        #endregion

        #region Métodos para Categorías de Productos

     
       
        
       /// Carga las categorías de productos (Tabla Categoria) directamente en un ComboBox.
        public void CargarCategoriasDirectoEnCombo(ComboBox cmb) 
        {
      
            try
            {
                // --- Llama la cadena de conexion ---
                using (OleDbConnection connLocal = new OleDbConnection(CadenaConexion))
                {
                    connLocal.Open();
                    // Consulta a la tabla Categoria (para productos)
                    string query = "SELECT IdCategoria, Nombre FROM Categoria ORDER BY Nombre";
                    using (OleDbDataAdapter da = new OleDbDataAdapter(query, connLocal))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Configurar el ComboBox
                        cmb.DataSource = null; // Limpiar DataSource anterior por si acaso
                        cmb.DisplayMember = "Nombre";      // Columna de texto a mostrar
                        cmb.ValueMember = "IdCategoria";   // Columna de ID a guardar
                        cmb.DataSource = dt;               // Asignar nuevo origen de datos
                        cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                        cmb.SelectedIndex = -1;          // Sin selección inicial
                    }
                }
                //Para  saber si anda, y si da error fijarme en la consola
                Console.WriteLine($"CATEGORIAS CRUD: ComboBox '{cmb.Name}' cargado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías de producto:\n{ex.Message}", "Error DAL Categorías", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb.DataSource = null; cmb.Items.Clear(); // Limpiar combo en error
            }
        }

   

      
        #endregion

    } // Fin clase ClsCategoriasCRUD
}