using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PryPueblox
{
    class ClsConexion
    {
        #region Conexion

     
        private string CadenaConexion = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=BdResto.mdb";
      
        #endregion

        #region Todo Abrirmesa/ticket/etc


        //Genera una lista con los prod
        public List<ClsProdProp> GetAllProducts()
        {
            
            List<ClsProdProp> productos = new List<ClsProdProp>();
         
            string query = "SELECT IdPlato, Nombre, Precio, IdCategoria, Stock FROM Producto ORDER BY Nombre";
            // --- Intenta conectarse --- 
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                {
                    conn.Open();
                    //declara comando y lector
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClsProdProp p = new ClsProdProp
                            {
                                IdPlato = Convert.ToInt32(reader["IdPlato"]),
                                Nombre = reader["Nombre"].ToString(),
                                // los 3 asumen 0 si es nulo    si no lo convierte el valor al tipo de dato correcto
                                Precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0m,
                                IdCategoria = reader["IdCategoria"] != DBNull.Value ? Convert.ToInt32(reader["IdCategoria"]) : 0,
                                Stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0 
                             
                            };
                            productos.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Error en GetAllProducts: " + ex.Message); throw; }
            return productos;
        }


        // Método para actualizar el estado de una mesa específica
        // Devuelve 'true' si la actualización fue exitosa, 'false' si no.
        public bool UpdateTableStatus(int idNumeroMesa, int nuevoIdEstado)
        {
            bool exito = false;
            // para actualizar el campo IdEstado en la tabla Mesas
            // para un IdNumeroDeMesa específico.
            string query = "UPDATE Mesas SET IdEstado = ? WHERE IdNumeroDeMesa = ?";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Añadir parámetros en el orden correcto (?)
                        // Parámetro 1: nuevoIdEstado (para SET IdEstado = ?  (estan arriba las 2)
                        cmd.Parameters.AddWithValue("?", nuevoIdEstado);
                        // Parámetro 2: idNumeroMesa (para WHERE IdNumeroDeMesa = ?)
                        cmd.Parameters.AddWithValue("?", idNumeroMesa);

                        // ExecuteNonQuery devuelve el número de filas afectadas.
                        // Si es > 0, la actualización funcionó.
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        exito = (filasAfectadas > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateTableStatus para Mesa {idNumeroMesa}: {ex.Message}");
                // Lanza la excepción para que el código que llama sepa del error
                throw new Exception($"Error al actualizar estado de la mesa {idNumeroMesa}.", ex);
               
            }
            return exito;
        }


        public int GetTableStatus(int idNumeroMesa)
        {
            int estadoActual = -1; // Valor por defecto si no se encuentra o hay error
                                   // Consulta para obtener solo el IdEstado de una mesa específica
            string query = "SELECT IdEstado FROM Mesas WHERE IdNumeroDeMesa = ?";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Añadir el parámetro para IdNumeroDeMesa
                        cmd.Parameters.AddWithValue("?", idNumeroMesa);

                        // ExecuteScalar es eficiente para obtener un solo valor
                        object resultado = cmd.ExecuteScalar();

                        // Verificar si se obtuvo un resultado y no es nulo
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            estadoActual = Convert.ToInt32(resultado);
                        }
                        // Si resultado es null o DBNull, significa que la mesa no existe
                        // o no tiene estado asignado. Devolvemos -1.
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetTableStatus para Mesa {idNumeroMesa}: {ex.Message}");
                // En caso de error de BD, también devolvemos -1 (o podríamos lanzar excepción)
                estadoActual = -1;
                // Opcional: Lanzar excepción si prefieres que el error se maneje arriba
                // throw new Exception($"Error al obtener estado de la mesa {idNumeroMesa}.", ex);
            }
            return estadoActual;
        }
        public int GetProductStock(int idPlato)
        {
            int stockActual = -1;
            string query = "SELECT Stock FROM Producto WHERE IdPlato = ?";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("pID", OleDbType.Integer).Value = idPlato;
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        stockActual = Convert.ToInt32(result);
                    }
                    // Si es null o DBNull, se queda en -1 (producto no encontrado o sin stock asignado)
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetProductStock para ID={idPlato}: {ex.Message}");
                stockActual = -1; // Indicar error
            }
            return stockActual;
        }

        public bool UpdateProductStock(int idPlato, int cantidadCambio)
        {
            bool exito = false;
            // --- MODIFICADO: Reemplazar Nz con IIF ---
            // IIF(Stock IS NULL, 0, Stock) devuelve 0 si Stock es NULL, o el valor de Stock si no lo es.
            string query = "UPDATE Producto SET Stock = IIF(Stock IS NULL, 0, Stock) + ? WHERE IdPlato = ?";
            // -------------------------------------------
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.Add("pCambio", OleDbType.Integer).Value = cantidadCambio;
                    cmd.Parameters.Add("pID", OleDbType.Integer).Value = idPlato;
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = (filasAfectadas > 0);
                }
                if (exito) Console.WriteLine($"Stock actualizado para ID={idPlato}, cambio={cantidadCambio}.");
                else Console.WriteLine($"Advertencia: No se actualizó stock para ID={idPlato}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateProductStock para ID={idPlato}: {ex.Message}");
                // Ponemos el ID específico en el mensaje de error para identificar el producto
                MessageBox.Show($"Error al actualizar stock para producto ID={idPlato}:\n{ex.Message}", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                exito = false;
            }
            return exito;
        }
        public Dictionary<int, int> GetAllTableStatuses()
        {
            Dictionary<int, int> statuses = new Dictionary<int, int>();
            string query = "SELECT IdNumeroDeMesa, IdEstado FROM Mesas";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["IdNumeroDeMesa"] != DBNull.Value && reader["IdEstado"] != DBNull.Value)
                                {
                                    int numeroMesa = Convert.ToInt32(reader["IdNumeroDeMesa"]);
                                    int idEstado = Convert.ToInt32(reader["IdEstado"]);
                                    statuses[numeroMesa] = idEstado;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllTableStatuses: {ex.Message}");
                throw new Exception("Error al obtener los estados de todas las mesas.", ex);
            }
            return statuses;
        }


        public DataTable GetCategoriasDataTable()
        {
            DataTable dt = new DataTable();
            // Asegúrate que tu tabla se llame Categoria y las columnas IdCategoria, Nombre
            string query = "SELECT IdCategoria, Nombre FROM Categoria ORDER BY Nombre";
            try
            {
                // Usa la CadenaConexion privada de esta clase
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    // Fill se encarga de abrir/cerrar conexión
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetCategoriasDataTable: {ex.Message}");
                // Lanzar excepción para que el formulario que llama sepa del error
                throw new Exception("Error al obtener las categorías desde la base de datos.", ex);
                // O devolver tabla vacía: return new DataTable();
            }
            return dt;
        }

        public int CrearNuevaOrden(int idNumeroView) // <--- Nombre del parámetro
        {
            int nuevoIdOrden = -1;
            string queryInsert = "INSERT INTO Ordenes ([IdNumeroDeMesa], [Fecha], [Total], [IdNumeroTicket]) VALUES (?, ?, ?, ?)";
            string queryGetId = "SELECT @@IDENTITY";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                {
                    conn.Open();
                    using (OleDbCommand cmdInsert = new OleDbCommand(queryInsert, conn))
                    {
                        // Usar 'idNumeroView' aquí
                        cmdInsert.Parameters.Add("pMesa", OleDbType.Integer).Value = idNumeroView;
                        cmdInsert.Parameters.Add("pFecha", OleDbType.Date).Value = DateTime.Now;
                        cmdInsert.Parameters.Add("pTotal", OleDbType.Currency).Value = 0m;
                        cmdInsert.Parameters.Add("pTicket", OleDbType.Integer).Value = DBNull.Value;

                        cmdInsert.ExecuteNonQuery();

                        using (OleDbCommand cmdGetId = new OleDbCommand(queryGetId, conn))
                        {
                            object resultadoId = cmdGetId.ExecuteScalar();
                            if (resultadoId != null && resultadoId != DBNull.Value)
                            {
                                nuevoIdOrden = Convert.ToInt32(resultadoId);
                            }
                            else { throw new Exception("El INSERT pareció funcionar, pero @@IDENTITY no devolvió un ID."); }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Usar 'idNumeroView' aquí también
                Console.WriteLine($"Error en CrearNuevaOrden para Mesa {idNumeroView}: Tipo={ex.GetType().Name}, Mensaje={ex.Message}");
                // Usar 'idNumeroView' aquí también
                MessageBox.Show($"Error DETALLADO al crear orden BD:\n\nTipo: {ex.GetType().Name}\nError: {ex.Message}\n\nMesa: {idNumeroView}\nOrigen: {ex.Source}\nStackTrace:\n{ex.StackTrace}",
                                "Error DB - CrearNuevaOrden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nuevoIdOrden = -1;
                // Usar 'idNumeroView' aquí también
                throw new Exception($"Error al crear una nueva orden para la mesa {idNumeroView}.", ex);
            }
            return nuevoIdOrden;
        }
        public int GetActiveOrderIdForMesa(int idNumeroMesa)
        {
            int idOrdenActiva = 0; // Valor por defecto si no se encuentra
                                   // Consulta para obtener el IdOrdenes más alto (más reciente) para la mesa dada
                                   // TOP 1 es sintaxis de Access para limitar a 1 resultado
            string query = "SELECT TOP 1 IdOrdenes FROM Ordenes WHERE IdNumeroDeMesa = ? ORDER BY IdOrdenes DESC";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Añadir el parámetro para IdNumeroDeMesa
                        cmd.Parameters.AddWithValue("?", idNumeroMesa);

                        // ExecuteScalar es bueno para obtener un solo valor
                        object resultado = cmd.ExecuteScalar();

                        // Verificar si se obtuvo un resultado (un IdOrdenes)
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            idOrdenActiva = Convert.ToInt32(resultado);
                        }
                        // Si no se encontró ninguna orden para esa mesa, resultado será null,
                        // y devolveremos 0 (nuestro valor por defecto).
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetActiveOrderIdForMesa para Mesa {idNumeroMesa}: {ex.Message}");
                idOrdenActiva = -1; // Devolvemos -1 para indicar un error de BD
                                    // Opcional: Lanzar excepción
                                    // throw new Exception($"Error al obtener la orden activa para la mesa {idNumeroMesa}.", ex);
            }
            return idOrdenActiva;
        }

        public OrderHeaderInfo GetOrderHeaderInfo(int idOrden) // Usaremos una clase auxiliar OrderHeaderInfo
        {
            OrderHeaderInfo headerInfo = null;
            // Seleccionar las columnas necesarias de la tabla Ordenes
            string query = "SELECT IdNumeroDeMesa, Fecha, Total FROM Ordenes WHERE IdOrdenes = ?";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", idOrden);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Si se encontró la orden
                            {
                                headerInfo = new OrderHeaderInfo(); // Crear instancia de la clase auxiliar

                                // Leer valores (con cuidado por posibles nulos, aunque no deberían serlo aquí)
                                headerInfo.NumeroMesa = reader["IdNumeroDeMesa"] != DBNull.Value ? Convert.ToInt32(reader["IdNumeroDeMesa"]) : -1;
                                headerInfo.Fecha = reader["Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha"]) : DateTime.MinValue;
                                headerInfo.Total = reader["Total"] != DBNull.Value ? Convert.ToDecimal(reader["Total"]) : 0m;
                            }
                            // Si no entra al reader.Read(), headerInfo seguirá siendo null
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetOrderHeaderInfo para Orden {idOrden}: {ex.Message}");
                headerInfo = null; // Asegurar null en caso de error
                                   // Opcional: Lanzar excepción
                                   // throw new Exception($"Error al obtener la cabecera para la orden {idOrden}.", ex);
            }
            return headerInfo;
        }


        public DataTable GetOrderItems(int idOrdenes)
        {
            DataTable dtItems = new DataTable();
            // --- Consulta SQL con JOIN ---
            // Seleccionamos campos de MesasOrden (mo) y Producto (p) uniendo por IdPlato
            string query = @"SELECT mo.IdPlato, mo.Cantidad, p.Nombre, p.Precio
                         FROM (MesasOrden AS mo
                         INNER JOIN Producto AS p ON mo.IdPlato = p.IdPlato)
                         WHERE mo.IdOrdenes = ?";
            // El @ al inicio permite escribir la consulta en varias líneas.
            // Los paréntesis alrededor del JOIN son importantes en la sintaxis de Access.

            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", idOrdenes);
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dtItems); // Llenar el DataTable
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetOrderItems (JOIN) para Orden {idOrdenes}: {ex.Message}");
                // Devolver tabla vacía en caso de error
                dtItems = new DataTable(); // Asegurar que esté vacía
                                           // Opcional: Lanzar excepción
                                           // throw new Exception($"Error al obtener los items detallados para la orden {idOrdenes}.", ex);
            }
            return dtItems;
        }

        public bool SaveOrder(int idOrdenes, DataTable items, decimal total)
        {
            bool success = false;
            OleDbConnection conn = null; // Necesitamos la conexión fuera del try para el finally
            OleDbTransaction transaction = null; // La transacción

            // Verifica que el DataTable de items no sea nulo
            if (items == null)
            {
                Console.WriteLine($"Error en SaveOrder para Orden {idOrdenes}: El DataTable de items es null.");
                return false; // No se puede guardar sin items
            }


            try
            {
                // 1. Abrir conexión e iniciar transacción
                conn = new OleDbConnection(CadenaConexion);
                conn.Open();
                transaction = conn.BeginTransaction();
                Console.WriteLine($"Iniciando transacción para guardar Orden {idOrdenes}"); // Log

                // 2. Borrar los items ANTIGUOS de esta orden en MesasOrden
                //    Esto simplifica la lógica: siempre borramos e insertamos lo actual.
                string queryDelete = "DELETE FROM MesasOrden WHERE IdOrdenes = ?";
                using (OleDbCommand cmdDelete = new OleDbCommand(queryDelete, conn, transaction)) // IMPORTANTE: Asociar comando a la transacción
                {
                    cmdDelete.Parameters.AddWithValue("?", idOrdenes);
                    cmdDelete.ExecuteNonQuery();
                    Console.WriteLine($"Items antiguos de Orden {idOrdenes} borrados."); // Log
                }

                // 3. Insertar los items NUEVOS (del DataTable) en MesasOrden
                string queryInsert = "INSERT INTO MesasOrden (IdOrdenes, IdPlato, Cantidad) VALUES (?, ?, ?)";
                using (OleDbCommand cmdInsert = new OleDbCommand(queryInsert, conn, transaction)) // IMPORTANTE: Asociar comando a la transacción
                {
                    // Definir los parámetros una sola vez fuera del bucle por eficiencia
                    cmdInsert.Parameters.Add("pIdOrden", OleDbType.Integer);  // Parámetro para IdOrdenes
                    cmdInsert.Parameters.Add("pIdPlato", OleDbType.Integer);  // Parámetro para IdPlato
                    cmdInsert.Parameters.Add("pCantidad", OleDbType.Integer); // Parámetro para Cantidad

                    // Recorrer cada fila del DataTable de items
                    foreach (DataRow row in items.Rows)
                    {
                        // Asignar los valores de la fila actual a los parámetros
                        // Asegúrate que los nombres "IdPlato" y "Cantidad" coincidan con tu DataTable
                        cmdInsert.Parameters["pIdOrden"].Value = idOrdenes;
                        cmdInsert.Parameters["pIdPlato"].Value = Convert.ToInt32(row["IdPlato"]);
                        cmdInsert.Parameters["pCantidad"].Value = Convert.ToInt32(row["Cantidad"]);

                        // Ejecutar la inserción para este item
                        cmdInsert.ExecuteNonQuery();
                    }
                    Console.WriteLine($"Items nuevos de Orden {idOrdenes} insertados ({items.Rows.Count} items)."); // Log
                }

                // 4. Actualizar el campo Total en la tabla Ordenes
                string queryUpdateTotal = "UPDATE Ordenes SET Total = ? WHERE IdOrdenes = ?";
                using (OleDbCommand cmdUpdateTotal = new OleDbCommand(queryUpdateTotal, conn, transaction)) // IMPORTANTE: Asociar comando a la transacción
                {
                    cmdUpdateTotal.Parameters.AddWithValue("?", total);      // Parámetro para Total
                    cmdUpdateTotal.Parameters.AddWithValue("?", idOrdenes); // Parámetro para IdOrdenes
                    cmdUpdateTotal.ExecuteNonQuery();
                    Console.WriteLine($"Total de Orden {idOrdenes} actualizado a {total:C}."); // Log
                }

                // 5. Si TODO fue bien hasta aquí, confirmar la transacción (guardar cambios permanentemente)
                transaction.Commit();
                success = true;
                Console.WriteLine($"Transacción para Orden {idOrdenes} confirmada (Commit). Orden guardada."); // Log

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR en SaveOrder para Orden {idOrdenes}: {ex.Message}");
                success = false; // Marcar como fallido

                // Si ocurrió un error, DESHACER todos los cambios hechos dentro de la transacción
                try
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Transacción para Orden {idOrdenes} revertida (Rollback) debido a error."); // Log
                    }
                }
                catch (Exception exRollback)
                {
                    // Anotar si incluso el rollback falla (raro, pero posible)
                    Console.WriteLine($"Error CRÍTICO durante Rollback para Orden {idOrdenes}: {exRollback.Message}");
                }

                // Lanzar la excepción original para que el formulario sepa que algo falló
                throw new Exception($"Error al guardar la orden {idOrdenes}. Los cambios fueron revertidos.", ex);
            }
            finally
            {
                // Asegurarse SIEMPRE de cerrar la conexión, haya funcionado o no
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine($"Conexión cerrada para Orden {idOrdenes}."); // Log
                }
            }

            return success; // Devuelve true solo si se hizo Commit
        }


        #endregion
        public string Alumno = "Alumnos.txt";

        #region Alumno 
        public void Grabar(string contenido)
        {
            // Crear y escribir en el archivo
            File.WriteAllText(Alumno, contenido);

            // Abrir el archivo en el Bloc de notas
            Process.Start(new ProcessStartInfo
            {
                FileName = Alumno,
                UseShellExecute = true
            });

        }
    }
}
#endregion






