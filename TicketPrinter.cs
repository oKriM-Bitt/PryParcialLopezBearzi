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
using System.Globalization; // Para CultureInfo

namespace PuebloGrill
{
    class TicketPrinter
    {
        private string ticketContent;
        private static int numeroTicket = 1; // Considera una forma más robusta para producción
        private ClsConexion miConexion;

        // Constantes para recargo/descuento
        private const decimal PORCENTAJE_RECARGO_DEBITO = 0.10m; // 10% de aumento
        private const decimal PORCENTAJE_DESCUENTO_EFECTIVO_TRANSFER = 0.10m; // 10% de descuento

        public TicketPrinter()
        {
            miConexion = new ClsConexion();
        }

        public void GenerarTicketDesdeBD(int idOrden, string metodoPago)
        {
            Console.WriteLine($"TicketPrinter: Generando ticket para Orden ID: {idOrden}, Método Pago: {metodoPago}");
            try
            {
                OrderHeaderInfo header = miConexion.GetOrderHeaderInfo(idOrden);
                if (header == null)
                {
                    MessageBox.Show($"Error crítico: No se pudieron obtener los datos de cabecera para la orden ID {idOrden}.", "Error Datos Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable items = miConexion.GetOrderItems(idOrden);
                if (items == null)
                {
                    MessageBox.Show($"Advertencia: No se encontraron ítems para la orden ID {idOrden}, pero se imprimirá cabecera.", "Datos Ticket", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    items = new DataTable(); // Evitar null ref
                }

                // header.Total de la BD es el subtotal bruto
                decimal subTotalBruto = header.Total;
                decimal totalFinalAPagar = subTotalBruto; // Iniciar con el subtotal bruto

                // Aplicar recargo o descuento según el método de pago
                if (metodoPago == "Débito" && subTotalBruto > 0)
                {
                    decimal montoRecargo = Math.Round(subTotalBruto * PORCENTAJE_RECARGO_DEBITO, 2);
                    totalFinalAPagar = subTotalBruto + montoRecargo;
                    Console.WriteLine($"Recargo por débito aplicado: {montoRecargo:C} sobre subtotal {subTotalBruto:C}. Total final: {totalFinalAPagar:C}");
                }
                else if ((metodoPago == "Efectivo" || metodoPago == "Transferencia") && subTotalBruto > 0)
                {
                    decimal montoDescuento = Math.Round(subTotalBruto * PORCENTAJE_DESCUENTO_EFECTIVO_TRANSFER, 2);
                    totalFinalAPagar = subTotalBruto - montoDescuento;
                    Console.WriteLine($"Descuento por {metodoPago} aplicado: {montoDescuento:C} sobre subtotal {subTotalBruto:C}. Total final: {totalFinalAPagar:C}");
                }
                else
                {
                    Console.WriteLine($"No se aplica recargo ni descuento. Subtotal y Total final: {totalFinalAPagar:C}");
                }

                using (StringWriter sw = new StringWriter())
                {
                    sw.WriteLine("********** RESTAURANTE PUEBLO GRILL **********");
                    sw.WriteLine("             *** TICKET *** ");
                    sw.WriteLine($"Número de Ticket: {numeroTicket}"); // Idealmente, este ID vendría de la orden
                    sw.WriteLine($"Fecha: {header.Fecha:dd/MM/yyyy}   Hora: {header.Fecha:HH:mm:ss}");
                    sw.WriteLine("-------------------------------------------------");
                    sw.WriteLine($"MESA: {header.NumeroMesa}");
                    sw.WriteLine("-------------------------------------------------");
                    sw.WriteLine($"{"CANT",-5} | {"PLATO",-20} | {"PRECIO",8} | {"SUBTOTAL",8}");
                    sw.WriteLine("-------------------------------------------------");

                    if (items.Rows.Count > 0)
                    {
                        foreach (DataRow row in items.Rows)
                        {
                            int cantidad = row["Cantidad"] != DBNull.Value ? Convert.ToInt32(row["Cantidad"]) : 0;
                            string nombrePlato = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : "N/A";
                            decimal precioUnitario = row["Precio"] != DBNull.Value ? Convert.ToDecimal(row["Precio"]) : 0m;
                            decimal subtotalItem = cantidad * precioUnitario;
                            sw.WriteLine($"{cantidad,-5} | {Truncate(nombrePlato, 20),-20} | {precioUnitario,8:C2} | {subtotalItem,8:C2}");
                        }
                    }
                    else
                    {
                        sw.WriteLine("           (Orden sin ítems detallados)");
                    }

                    sw.WriteLine("-------------------------------------------------");
                    // NO SE MUESTRA DESGLOSE DE SUBTOTAL, RECARGO NI DESCUENTO
                    sw.WriteLine($"TOTAL A PAGAR: {totalFinalAPagar,29:C2}"); // Muestra el total ya ajustado
                    sw.WriteLine("-------------------------------------------------");
                    sw.WriteLine($"Método de pago: {metodoPago}");
                    sw.WriteLine("           ¡Gracias por su compra!");
                    sw.WriteLine("");

                    ticketContent = sw.ToString();
                }

                numeroTicket++;
                PrintTicket();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el ticket (ID Orden: {idOrden}):\n{ex.Message}", "Error Generar Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
            using (Font font = new Font("Courier New", 9))
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