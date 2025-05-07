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

namespace PryPueblox
{
    // Usando el nombre de tu clase con el typo "Librio"
    public partial class FrmLibrioDiario : Form
    {
        private DataTable libroDiarioData;
        private string CsvFolderPath = Application.StartupPath; // Carpeta de los CSV

        public FrmLibrioDiario()
        {
            InitializeComponent();
            ConfigurarDataGridView(); // Configura el grid
        }

        private void ConfigurarDataGridView()
        {
            // Usa tu nombre: Grlm
            if (Grlm == null) return;

            Grlm.Columns.Clear();
            Grlm.AutoGenerateColumns = false;

            // Definir Columnas para el grid (puedes ajustar títulos y anchos)
            Grlm.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaHora", HeaderText = "Fecha y Hora", DataPropertyName = "FechaHora", Width = 150 });
            Grlm.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdOrden", HeaderText = "ID Orden", DataPropertyName = "IdOrden", Width = 80 });
            Grlm.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdMesa", HeaderText = "Mesa", DataPropertyName = "IdMesa", Width = 50 });
            Grlm.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total", DataPropertyName = "Total", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            Grlm.Columns.Add(new DataGridViewTextBoxColumn { Name = "MetodoPago", HeaderText = "Método Pago", DataPropertyName = "MetodoPago", Width = 120, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }); // Rellena espacio

            Grlm.ReadOnly = true;
            Grlm.AllowUserToAddRows = false;
            Grlm.AllowUserToDeleteRows = false;
            Grlm.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grlm.RowHeadersVisible = false; // Ocultar cabecera de fila izquierda
        }

        // --- Carga Inicial ---
        private void FrmLibrioDiario_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Cargando FrmLibrioDiario...");
            // Cargar datos de "Hoy" al abrir
            BtnVerHoy_Click(sender, e);
        }

        // --- Lógica de Carga y Filtrado ---
        private void CargarDatosCSV(DateTime fechaInicio, DateTime fechaFin)
        {
            Console.WriteLine($"Cargando datos CSV desde {fechaInicio:yyyy-MM-dd} hasta {fechaFin:yyyy-MM-dd}");
            libroDiarioData = new DataTable();
            // Columnas del DataTable (deben coincidir con el grid y el CSV)
            libroDiarioData.Columns.Add("FechaHora", typeof(DateTime));
            libroDiarioData.Columns.Add("IdOrden", typeof(int));
            libroDiarioData.Columns.Add("IdMesa", typeof(int));
            libroDiarioData.Columns.Add("Total", typeof(decimal));
            libroDiarioData.Columns.Add("MetodoPago", typeof(string));

            // Usa tu nombre: Grlm
            Grlm.DataSource = null; // Limpiar grid

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

                        for (int i = 1; i < lineas.Length; i++) // Empezar en 1 para saltar cabecera
                        {
                            string linea = lineas[i];
                            if (string.IsNullOrWhiteSpace(linea)) continue;

                            string[] campos = linea.Split(';'); // Separador punto y coma

                            if (campos.Length == 5) // Esperamos 5 columnas
                            {
                                try
                                {
                                    // Parsear datos (quitar comillas de texto/fecha)
                                    DateTime fechaHora = DateTime.Parse(campos[0].Trim('"'));
                                    int idOrden = int.Parse(campos[1]);
                                    int idMesa = int.Parse(campos[2]);
                                    decimal total = decimal.Parse(campos[3], CultureInfo.InvariantCulture); // Decimal con punto
                                    string metodoPago = campos[4].Trim('"');

                                    libroDiarioData.Rows.Add(fechaHora, idOrden, idMesa, total, metodoPago);
                                }
                                catch (Exception exParse) { Console.WriteLine($"Error parseando línea {i + 1} en {nombreArchivo}: '{linea}'. Error: {exParse.Message}"); }
                            }
                            else { Console.WriteLine($"Advertencia: Línea {i + 1} en {nombreArchivo} no tiene 5 campos: '{linea}'"); }
                        }
                    } // Fin if File.Exists
                } // Fin for fechas

                // Asignar datos al grid (Usa tu nombre: Grlm)
                Grlm.DataSource = libroDiarioData;
                Console.WriteLine($"Carga completada. {libroDiarioData.Rows.Count} registros mostrados.");
                // Opcional: Ordenar por fecha descendente
                // Grlm.Sort(Grlm.Columns["FechaHora"], ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del Libro Diario:\n{ex.Message}", "Error Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Grlm.DataSource = null;
            }
        }

        // --- Eventos Botones Filtro ---
        private void BtnVerHoy_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            CargarDatosCSV(hoy, hoy);
        }

        private void BtnVerSemana_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            // Asume Domingo como inicio de semana
            DateTime inicioSemana = hoy.AddDays(-(int)hoy.DayOfWeek);
            CargarDatosCSV(inicioSemana, hoy);
        }

        private void BtnVerMes_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            DateTime inicioMes = new DateTime(hoy.Year, hoy.Month, 1);
            CargarDatosCSV(inicioMes, hoy);
        }
        // --- Fin Filtros ---

        // --- Botones Acción ---
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
                    CargarDatosCSV(DateTime.Today, DateTime.Today); // Recargar (estará vacío)
                }
                catch (Exception ex) { MessageBox.Show($"Error inesperado durante limpieza:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void BtnImprimirS_Click(object sender, EventArgs e)
        {
            // --- Lógica de Impresión del DataGridView (Grlm) - PENDIENTE ---
            MessageBox.Show("Funcionalidad de Imprimir Libro Diario PENDIENTE.", "Pendiente");

            // NO cerramos el formulario aquí necesariamente, el usuario podría querer seguir viendo
            // this.Close(); // Quitado de tu código original
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            // Preguntar al usuario si está seguro (con sintaxis corregida)
            DialogResult respuesta = MessageBox.Show(
                "¿Seguro que desea volver?\nLos cambios no guardados se perderán.", // Mensaje
                "Confirmar Salida",  // Título de la ventana
                MessageBoxButtons.YesNo, // Botones Sí y No
                MessageBoxIcon.Warning   // Ícono de advertencia
            );

            // Verificar la respuesta del usuario
            if (respuesta == DialogResult.Yes)
            {
                // Si el usuario hizo clic en "Sí":
                Console.WriteLine("Usuario confirmó volver. Abriendo FrmInicio y cerrando formulario actual."); // Log

                // 1. Crear una instancia del formulario principal
                FrmInicio frmInicio = new FrmInicio();

                // 2. Mostrar el formulario principal
                frmInicio.Show();

                // 3. Cerrar ESTE formulario actual
                this.Hide();
            }
        }

        // --- Fin Botones Acción ---

        // Evento vacío del DataGridView (puedes borrarlo si no le das uso)
        private void Grlm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Código si necesitas hacer algo al hacer clic en una celda
        }

    } // Fin clase FrmLibrioDiario
}