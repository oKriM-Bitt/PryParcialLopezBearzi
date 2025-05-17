using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization; // Para CultureInfo en exportación CSV si se moviera aquí
using System.IO;            // Para StreamWriter en exportación CSV si se moviera aquí
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Para MessageBox

namespace PuebloGrill
{
    // Clase pública para acceder desde formularios
    public class ClsOrdenesCRUD
    {
        #region Variables y Conexión

        // ¡Asegúrate que sea la misma cadena que en las otras clases DAL!
        private string CadenaConexion = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=BdResto.mdb";

        #endregion
    
        #region Popularidad Productos (Consulta MesasOrden)

        /// <summary>
        /// Obtiene los N productos más vendidos basados en la cantidad total pedida.
        /// </summary>
        public DataTable GetProductosPopulares(int topN = 10)
        {
            DataTable dt = new DataTable();
            // Consulta CORREGIDA con TOP 10 fijo
            string query = @"SELECT TOP 10 P.Nombre, SUM(MO.Cantidad) AS TotalVendido
                             FROM (MesasOrden AS MO INNER JOIN Producto AS P ON MO.IdPlato = P.IdPlato)
                             GROUP BY P.Nombre ORDER BY SUM(MO.Cantidad) DESC, P.Nombre";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                // No necesitamos parámetro TOP N aquí
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error BD [GetProductosPopulares]:\n{ex.Message}"); return null; }
            return dt;
        }

        #endregion

    } 
}