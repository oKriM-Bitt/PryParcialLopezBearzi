using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;             // Para leer/escribir archivos
using System.Globalization;  // Para formato de números/fechas
using System.Drawing.Printing;
using System.Drawing;

namespace PuebloGrill
{
    public partial class FrmLibrioDiario : Form
    {
        private DataTable libroDiarioData; // DataTable original cargado desde CSV
        private DataTable datosFiltradosParaGrid; // DataTable para mostrar en el grid, después de aplicar filtros
        private string CsvFolderPath = Application.StartupPath; // Carpeta de los CSV

        public FrmLibrioDiario()
        {
            InitializeComponent();
            ConfigurarDataGridView(); // Configura el grid
            ConfigurarYPopularCmbFiltro(); // Configurar y poblar el NUEVO ComboBox CmbFiltro
        }
        private PrintDocument printDocument = new PrintDocument();
        private int currentRow = 0;
        private decimal totalVentas = 0;
        private void ConfigurarDataGridView()
        {
            if (Grlm == null) return;

            Grlm.Columns.Clear();
            Grlm.AutoGenerateColumns = false;

            Grlm.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaHora", HeaderText = "Fecha y Hora", DataPropertyName = "FechaHora", Width = 150 });
            Grlm.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdOrden", HeaderText = "ID Orden", DataPropertyName = "IdOrden", Width = 80 });
            Grlm.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdMesa", HeaderText = "Mesa", DataPropertyName = "IdMesa", Width = 50 });
            Grlm.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total", DataPropertyName = "Total", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            Grlm.Columns.Add(new DataGridViewTextBoxColumn { Name = "MetodoPago", HeaderText = "Método Pago", DataPropertyName = "MetodoPago", Width = 120, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            Grlm.ReadOnly = true;
            Grlm.AllowUserToAddRows = false;
            Grlm.AllowUserToDeleteRows = false;
            Grlm.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grlm.RowHeadersVisible = false;
        }

        private void FrmLibrioDiario_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Cargando FrmLibrioDiario...");
            datosFiltradosParaGrid = new DataTable();
            BtnVerHoy_Click(sender, e);
        }

        // ACTUALIZADO: Para usar CmbFiltro
        private void ConfigurarYPopularCmbFiltro()
        {
            if (CmbFiltro == null) // Asegúrate que el ComboBox se llame CmbFiltro en tu diseño
            {
                MessageBox.Show("Error: El control ComboBox llamado 'CmbFiltro' no se encontró en el diseño del formulario.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CmbFiltro.Items.Clear();
            CmbFiltro.Items.Add("Todos");
            CmbFiltro.Items.Add("Efectivo");
            CmbFiltro.Items.Add("Transferencia");
            CmbFiltro.Items.Add("Débito");

            CmbFiltro.SelectedIndex = 0;
            CmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;

            // Asegúrate que la suscripción coincida con el nombre del método que creaste
            CmbFiltro.SelectedIndexChanged -= CmbFiltro_SelectedIndexChanged;
            CmbFiltro.SelectedIndexChanged += CmbFiltro_SelectedIndexChanged;
        }

        private void CargarDatosCSV(DateTime fechaInicio, DateTime fechaFin)
        {
            Console.WriteLine($"Cargando datos CSV desde {fechaInicio:yyyy-MM-dd} hasta {fechaFin:yyyy-MM-dd}");
            libroDiarioData = new DataTable();
            libroDiarioData.Columns.Add("FechaHora", typeof(DateTime));
            libroDiarioData.Columns.Add("IdOrden", typeof(int));
            libroDiarioData.Columns.Add("IdMesa", typeof(int));
            libroDiarioData.Columns.Add("Total", typeof(decimal));
            libroDiarioData.Columns.Add("MetodoPago", typeof(string));

            try
            {
                for (DateTime fecha = fechaInicio.Date; fecha <= fechaFin.Date; fecha = fecha.AddDays(1))
                {
                    string nombreArchivo = $"LibroDiario_{fecha:yyyy-MM-dd}.csv";
                    string rutaCompleta = Path.Combine(CsvFolderPath, nombreArchivo);

                    if (File.Exists(rutaCompleta))
                    {
                        Console.WriteLine($"Leyendo archivo: {rutaCompleta}");
                        string[] lineas = File.ReadAllLines(rutaCompleta, Encoding.UTF8);

                        for (int i = 1; i < lineas.Length; i++)
                        {
                            string linea = lineas[i];
                            if (string.IsNullOrWhiteSpace(linea)) continue;

                            string[] campos = linea.Split(';');

                            if (campos.Length == 5)
                            {
                                try
                                {
                                    DateTime fechaHora = DateTime.Parse(campos[0].Trim('"'));
                                    int idOrden = int.Parse(campos[1]);
                                    int idMesa = int.Parse(campos[2]);
                                    decimal total = decimal.Parse(campos[3], CultureInfo.InvariantCulture);
                                    string metodoPago = campos[4].Trim('"');
                                    libroDiarioData.Rows.Add(fechaHora, idOrden, idMesa, total, metodoPago);
                                }
                                catch (Exception exParse) { Console.WriteLine($"Error parseando línea {i + 1} en {nombreArchivo}: '{linea}'. Error: {exParse.Message}"); }
                            }
                            else { Console.WriteLine($"Advertencia: Línea {i + 1} en {nombreArchivo} no tiene 5 campos: '{linea}'"); }
                        }
                    }
                }
                Console.WriteLine($"Carga desde CSV completada. {libroDiarioData.Rows.Count} registros en memoria antes de filtrar por pago.");
                AplicarFiltroMetodoPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del Libro Diario:\n{ex.Message}", "Error Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Grlm.DataSource = null;
                libroDiarioData?.Clear();
            }
        }

        // ACTUALIZADO: Para usar CmbFiltro
        private void AplicarFiltroMetodoPago()
        {
            if (libroDiarioData == null)
            {
                Grlm.DataSource = null;
                return;
            }

            // Leer del ComboBox CmbFiltro
            string filtroSeleccionado = CmbFiltro.SelectedItem?.ToString() ?? "Todos";
            Console.WriteLine($"Aplicando filtro de método de pago: '{filtroSeleccionado}'");

            if (filtroSeleccionado == "Todos" || string.IsNullOrEmpty(filtroSeleccionado))
            {
                datosFiltradosParaGrid = libroDiarioData.Copy();
            }
            else
            {
                DataRow[] filasFiltradas = libroDiarioData.Select($"MetodoPago = '{filtroSeleccionado}'");
                datosFiltradosParaGrid = libroDiarioData.Clone();
                foreach (DataRow fila in filasFiltradas)
                {
                    datosFiltradosParaGrid.ImportRow(fila);
                }
            }

            Grlm.DataSource = null;
            Grlm.DataSource = datosFiltradosParaGrid;
            Console.WriteLine($"{datosFiltradosParaGrid.Rows.Count} registros mostrados en la grilla después del filtro de pago.");

            CalcularYMostrarTotal(); // 
        }

        private void BtnVerHoy_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            CargarDatosCSV(hoy, hoy);
        }

        private void BtnVerSemana_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            DateTime inicioSemana = hoy.AddDays(-(int)hoy.DayOfWeek);
            CargarDatosCSV(inicioSemana, hoy);
        }

        private void BtnVerMes_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            DateTime inicioMes = new DateTime(hoy.Year, hoy.Month, 1);
            CargarDatosCSV(inicioMes, hoy);
        }

        // ACTUALIZADO: Este es tu manejador de eventos para CmbFiltro
        private void CmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Visible && (CmbFiltro.Focused || CmbFiltro.ContainsFocus || Form.ActiveForm == this))
            {
                AplicarFiltroMetodoPago();
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está SEGURO de borrar TODO el historial del Libro Diario?\nEsta acción NO se puede deshacer.",
                                  "Confirmar Limpieza Total", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Console.WriteLine("Iniciando limpieza...");
                int borrados = 0, errores = 0;
                try
                {
                    string[] archivosLog = Directory.GetFiles(CsvFolderPath, "LibroDiario_*.csv");
                    if (archivosLog.Length == 0) { MessageBox.Show("No hay archivos de log."); return; }

                    foreach (string archivo in archivosLog)
                    {
                        try { File.Delete(archivo); borrados++; Console.WriteLine($"Borrado: {archivo}"); }
                        catch (IOException ioEx) { errores++; Console.WriteLine($"Error borrando {archivo}: {ioEx.Message}"); }
                    }
                    MessageBox.Show($"{borrados} archivo(s) borrado(s).\n{errores} archivo(s) no pudieron borrarse.", "Limpieza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatosCSV(DateTime.Today, DateTime.Today);
                }
                catch (Exception ex) { MessageBox.Show($"Error inesperado durante limpieza:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 10);
            float lineHeight = font.GetHeight(e.Graphics) + 5;
            float yPosition = e.MarginBounds.Top;
            float xPosition = e.MarginBounds.Left;

            totalVentas = 0; // Reiniciar el total

            // Encabezado
            for (int i = 0; i < Grlm.Columns.Count; i++)
            {
                e.Graphics.DrawString(Grlm.Columns[i].HeaderText, font, Brushes.Black, xPosition, yPosition);
                xPosition += 150;
            }

            yPosition += lineHeight;
            xPosition = e.MarginBounds.Left;

            // Filas
            for (int rowIndex = 0; rowIndex < Grlm.Rows.Count; rowIndex++)
            {
                if (Grlm.Rows[rowIndex].IsNewRow) continue;

                for (int col = 0; col < Grlm.Columns.Count; col++)
                {
                    string value = Grlm.Rows[rowIndex].Cells[col].Value?.ToString() ?? "";
                    e.Graphics.DrawString(value, font, Brushes.Black, xPosition, yPosition);
                    xPosition += 150;
                }

                // Sumar correctamente la columna "Total"
                object cellValue = Grlm.Rows[rowIndex].Cells["Total"].Value;
                if (cellValue != null)
                {
                    string texto = cellValue.ToString().Replace("€", "").Replace("$", "").Replace(".", "").Replace(",", ".").Trim();
                    if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valorDecimal))
                    {
                        totalVentas += valorDecimal;
                    }
                }

                yPosition += lineHeight;
                xPosition = e.MarginBounds.Left;

                if (yPosition + lineHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            // Mostrar total al final
            yPosition += lineHeight;
            Font totalFont = new Font("Arial", 12, FontStyle.Bold);
            e.Graphics.DrawString($"TOTAL: ${totalVentas:N2}", totalFont, Brushes.Black, e.MarginBounds.Left, yPosition);
        }
        private void BtnImprimirS_Click(object sender, EventArgs e)
        {
            currentRow = 0;
            totalVentas = 0;
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            try
            {
                printDocument.Print(); // Imprime directamente
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message);
            }

            printDocument.PrintPage -= PrintDocument_PrintPage;
           
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio f = new FrmInicio();
            f.Show();
            this.Hide();
        }



        private void CalcularYMostrarTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow fila in Grlm.Rows)
            {
                if (fila.IsNewRow) continue;

                object cellValue = fila.Cells["Total"].Value;
                if (cellValue != null)
                {
                    string texto = cellValue.ToString().Replace("€", "").Replace("$", "").Replace(".", "").Replace(",", ".").Trim();
                    if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valorDecimal))
                    {
                        total += valorDecimal;
                    }
                }
            }

            LblTotal.Text = $"Total en pantalla: ${total:N2}";
        }
        private void Grlm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Código si necesitas hacer algo al hacer clic en una celda
        }

        private void LblTotal_Click(object sender, EventArgs e)
        {

        }
    } // Fin clase FrmLibrioDiario
}