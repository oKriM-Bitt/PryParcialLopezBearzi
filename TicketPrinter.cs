using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;      
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.IO;         
using System.Drawing;       
using System.Drawing.Printing; 

namespace PryPueblox
{
    class TicketPrinter
    {

        // --- Variables y Configuración ---
        private string ticketContent; 
        private static int numeroTicket = 1;
        // Instancia para acceder a la base de datos
        private ClsConexion miConexion;
       

        // --- Constructor ---
        public TicketPrinter()
        {
            // Crear la instancia de ClsConexion al crear el TicketPrinter
            miConexion = new ClsConexion();
        }
      

       
        /// Genera e imprime un ticket obteniendo los datos desde la BD usando el IdOrdenes.
        
        public void GenerarTicketDesdeBD(int idOrden, string metodoPago)
        {
            Console.WriteLine($"Generando ticket desde BD para Orden ID: {idOrden}");
            try
            {
                // 1. Obtener datos de cabecera (Mesa, Fecha, Total)
                // Llama al método que añadimos en ClsConexion
               OrderHeaderInfo header = miConexion.GetOrderHeaderInfo(idOrden);
                if (header == null)
                {
                    // Error si no se pudo obtener la información básica
                    MessageBox.Show($"Error crítico: No se pudieron obtener los datos de cabecera para la orden ID {idOrden}.", "Error Datos Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método
                }

                // 2. Obtener los items detallados (Cantidad, Nombre, Precio)
                // Llama al método GetOrderItems (que ahora incluye Nombre y Precio gracias al JOIN)
                DataTable items = miConexion.GetOrderItems(idOrden);
                if (items == null) // Aunque GetOrderItems devuelve tabla vacía, verificamos
                {
                    MessageBox.Show($"Error: No se pudieron obtener los items para la orden ID {idOrden}.", "Error Datos Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir si no hay items
                }

                // 3. Construir el string del Ticket usando StringWriter
                using (StringWriter sw = new StringWriter())
                {
                    // --- Encabezado del Ticket ---
                    sw.WriteLine("********** RESTAURANTE PUEBLO GRILL **********");
                    sw.WriteLine("             *** TICKET *** ");
                    // Considera usar header.IdNumeroTicket si lo implementas en GetOrderHeaderInfo
                    sw.WriteLine($"Número de Ticket: {numeroTicket}");
                    sw.WriteLine($"Fecha: {header.Fecha:dd/MM/yyyy}   Hora: {header.Fecha:HH:mm:ss}"); // Usa fecha/hora de la BD
                    sw.WriteLine("-------------------------------------------------");
                    sw.WriteLine($"MESA: {header.NumeroMesa}"); // Usa número de mesa de la BD
                    sw.WriteLine("-------------------------------------------------");
                    sw.WriteLine($"{"CANT",-5} | {"PLATO",-20} | {"PRECIO",8} | {"SUBTOTAL",8}");
                    sw.WriteLine("-------------------------------------------------");

                    // --- Detalle de Items (Iterando el DataTable) ---
                    foreach (DataRow row in items.Rows)
                    {
                        // Leer datos de la fila actual
                        // Añadir validación por si acaso vienen nulos de la BD
                        int cantidad = row["Cantidad"] != DBNull.Value ? Convert.ToInt32(row["Cantidad"]) : 0;
                        string nombrePlato = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : "N/A";
                        decimal precioUnitario = row["Precio"] != DBNull.Value ? Convert.ToDecimal(row["Precio"]) : 0m;

                        // Calcular subtotal para esta línea
                        decimal subtotal = cantidad * precioUnitario;

                        // Formatear valores para el ticket
                        string precioFormateado = $"${precioUnitario,8:F2}";
                        string subtotalFormateado = $"${subtotal,8:F2}";

                        // Escribir la línea del item
                        sw.WriteLine($"{cantidad,-5} | {Truncate(nombrePlato, 20),-20} | {precioFormateado} | {subtotalFormateado}");
                    }

                    // --- Pie del Ticket ---
                    sw.WriteLine("-------------------------------------------------");

                    // Lógica para mostrar desglose de recargo si aplica
                    // Usamos el TOTAL FINAL guardado en la BD (header.Total)
                    if (metodoPago == "Débito" && items.Rows.Count > 0 && header.Total > 0)
                    {
                        // Recalcular subtotal sin recargo para mostrar desglose
                        // ASUME un recargo del 10%. Ajusta si es diferente.
                        decimal subTotalSinRecargo = header.Total / 1.10m;
                        decimal aumentoCalculado = header.Total - subTotalSinRecargo;
                        // Mostrar desglose
                        sw.WriteLine($"Subtotal: ${subTotalSinRecargo,37:F2}");
                        sw.WriteLine($"Aumento por débito (10%): ${aumentoCalculado,20:F2}");
                        sw.WriteLine("-------------------------------------------------");
                    }

                    // Escribir el TOTAL FINAL (leído de la BD)
                    sw.WriteLine($"TOTAL A PAGAR: ${header.Total,29:F2}");
                    sw.WriteLine("-------------------------------------------------");
                    sw.WriteLine($"Método de pago: {metodoPago}"); // Usa el método pasado como argumento
                    sw.WriteLine("           ¡Gracias por su compra!");
                    sw.WriteLine(""); // Línea extra al final

                    // Guardar todo el texto generado en la variable de clase
                    ticketContent = sw.ToString();

                } // Fin del using StringWriter

                // Incrementar número de ticket (solución simple, no persistente)
                numeroTicket++;

                // 4. Llamar al método que imprime el contenido guardado en ticketContent
                PrintTicket();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el ticket (ID Orden: {idOrden}):\n{ex.Message}", "Error Generar Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Puedes decidir si quieres relanzar la excepción para que FrmTicket la capture
                // throw;
            }
        }

       


        // MÉTODOS AUXILIARES DE IMPRESIÓN 
        private void PrintTicket()
        {
            if (string.IsNullOrEmpty(ticketContent)) { MessageBox.Show("No hay contenido para imprimir."); return; }
            PrintDocument printDoc = new PrintDocument();
            
            printDoc.PrintPage += PrintPageHandler;
            try { printDoc.Print(); }
            catch (Exception ex) { MessageBox.Show($"Error al imprimir: {ex.Message}"); }
            finally { printDoc.PrintPage -= PrintPageHandler; }
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            using (Font font = new Font("Courier New", 9)) //  fuente/tamaño
            {
                float yPos = 10; float leftMargin = 10;
                float lineHeight = font.GetHeight(e.Graphics) + 2;
                using (StringReader sr = new StringReader(ticketContent))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    { e.Graphics.DrawString(line, font, Brushes.Black, leftMargin, yPos); yPos += lineHeight; }
                }
            }
            e.HasMorePages = false;
        }

        private string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
      

    } 
}