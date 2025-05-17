using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms; 

namespace PuebloGrill
{
   
    public class ClsProductosCRUD
    {
        #region Variables y Conexión

        // Cadena de Conexión
        private string CadenaConexion = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=BdResto.mdb";

        #endregion

        #region Métodos CRUD (Create, Read, Update, Delete)

        
        ///  Agrega un nuevo producto a la tabla Producto.
        public bool AgregarProducto(string nombre, decimal precio, int idCategoria, int stock)
        {
            bool exito = false;
            string query = "INSERT INTO Producto ([Nombre], [Precio], [IdCategoria], [Stock]) VALUES (?, ?, ?, ?)";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("pNombre", nombre); 
                    cmd.Parameters.AddWithValue("pPrecio", precio);
                    cmd.Parameters.AddWithValue("pCategoria", idCategoria);
                    cmd.Parameters.AddWithValue("pStock", stock);
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = (filasAfectadas > 0);
                }
                if (exito) Console.WriteLine($"PRODUCTOS CRUD: Producto '{nombre}' agregado.");
            }
            catch (Exception ex) { MessageBox.Show($"Error BD [AgregarProducto]:\n{ex.Message}"); exito = false; }
            return exito;
        }

      
        ///  Actualiza datos de un producto existente.
        public bool ActualizarProducto(int idPlato, string nuevoNombre, decimal nuevoPrecio, int nuevoIdCategoria, int nuevoStock)
        {
            bool exito = false;
            string query = "UPDATE Producto SET [Nombre] = ?, [Precio] = ?, [IdCategoria] = ?, [Stock] = ? WHERE [IdPlato] = ?";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("pNombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("pPrecio", nuevoPrecio);
                    cmd.Parameters.AddWithValue("pCategoria", nuevoIdCategoria);
                    cmd.Parameters.AddWithValue("pStock", nuevoStock);
                    cmd.Parameters.AddWithValue("pIdPlato", idPlato);
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = (filasAfectadas > 0);
                }
                if (exito) Console.WriteLine($"PRODUCTOS CRUD: ID={idPlato} actualizado.");
            }
            catch (Exception ex) { MessageBox.Show($"Error BD [ActualizarProducto ID={idPlato}]:\n{ex.Message}"); exito = false; }
            return exito;
        }

        
        ///  Elimina un producto de la tabla Producto.
        public bool EliminarProducto(int idPlato)
        {
            bool exito = false;
            string query = "DELETE FROM Producto WHERE [IdPlato] = ?";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("pIdPlato", idPlato);
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = (filasAfectadas > 0);
                }
                if (exito) Console.WriteLine($"PRODUCTOS CRUD: ID={idPlato} eliminado.");
            }
            catch (OleDbException dbEx) { if (dbEx.ErrorCode == -2147467259 || dbEx.Message.Contains("referential integrity")) { MessageBox.Show($"No se pudo eliminar producto (ID={idPlato}) porque está en uso.", "Error FK"); } else { MessageBox.Show($"Error BD [EliminarProducto ID={idPlato}]:\n{dbEx.Message}"); } exito = false; }
            catch (Exception ex) { MessageBox.Show($"Error General [EliminarProducto ID={idPlato}]:\n{ex.Message}"); exito = false; }
            return exito;
        }

        #endregion

        #region Métodos de Lectura (Read)

      
        /// Obtiene una lista de TODOS los productos.
        public List<ClsProdProp> GetAllProducts()
        {
            List<ClsProdProp> productos = new List<ClsProdProp>();
            string query = "SELECT IdPlato, Nombre, Precio, IdCategoria, Stock FROM Producto ORDER BY Nombre";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new ClsProdProp
                            {
                                IdPlato = Convert.ToInt32(reader["IdPlato"]),
                                Nombre = reader["Nombre"].ToString(),
                                Precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0m,
                                IdCategoria = reader["IdCategoria"] != DBNull.Value ? Convert.ToInt32(reader["IdCategoria"]) : 0,
                                Stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error en GetAllProducts (CRUD): {ex.Message}"); throw; } // Re-lanzar excepción
            return productos;
        }


        /// Obtiene todos los productos como un DataTable/Tabla virtual.
        public DataTable GetAllProductosTable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT IdPlato, Nombre, Precio, IdCategoria, Stock FROM Producto ORDER BY Nombre";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al listar productos:\n{ex.Message}"); dt = new DataTable(); }
            return dt;
        }

        
        /// Busca y llena una grilla con productos filtrados por categoría.
        public DataTable GetProductosPorCategoria(int idCategoria)
        {
            DataTable dt = new DataTable();
            string query = "SELECT IdPlato, Nombre, Precio FROM Producto WHERE IdCategoria = ?";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("pCat", idCategoria);
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt); // Llenar el DataTable directamente
                    }
                }
                Console.WriteLine($"PRODUCTOS CRUD: Obtenidos {dt.Rows.Count} productos para Cat ID={idCategoria}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error buscar por categoría ID={idCategoria}:\n{ex.Message}", "Error DAL Producto");
                dt = new DataTable(); // Devolver tabla vacía en error
            }
            return dt;
        }

        #endregion

        #region Métodos de Stock

       //TERMINAR AGREGAR AL TICKET ABRIR MESA ETC
        /// Obtiene el stock actual de un producto específico.
        public int GetProductStock(int idPlato)
        {
            int stockActual = -1;
            string query = "SELECT Stock FROM Producto WHERE IdPlato = ?";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("pID", idPlato);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value) { stockActual = Convert.ToInt32(result); }
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error GetProductStock ID={idPlato}: {ex.Message}"); stockActual = -1; }
            return stockActual;
        }

        /// <summary>
        /// Modifica el stock de un producto sumando o restando una cantidad.
        /// </summary>
        public bool UpdateProductStock(int idPlato, int cantidadCambio)
        {
            bool exito = false;
            // Usar IIF para manejar nulos
            string query = "UPDATE Producto SET Stock = IIF(Stock IS NULL, 0, Stock) + ? WHERE IdPlato = ?";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("pCambio", cantidadCambio);
                    cmd.Parameters.AddWithValue("pID", idPlato);
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = (filasAfectadas > 0);
                }
                if (!exito) Console.WriteLine($"PRODUCTOS CRUD: Warn - No se actualizó stock ID={idPlato}.");
            }
            catch (Exception ex) { MessageBox.Show($"Error BD [UpdateProductStock ID={idPlato}]:\n{ex.Message}"); exito = false; }
            return exito;
        }

        #endregion

    } 
}