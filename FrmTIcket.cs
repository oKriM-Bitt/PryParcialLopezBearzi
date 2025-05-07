using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization; // Para formato de moneda
using System.IO;             // Para Path y StreamWriter/File
using System.Data.OleDb;    // Para CargarCategoriasFiltro temporalmente

namespace PryPueblox
{
    public partial class FrmTicket : Form
    {
        // --- Variables de Clase ---
        private ClsConexion miConexion;
        private int currentIdMesa = -1;
        private int currentIdOrden = -1;
        private bool isNewOrder = true;
        private List<ClsProdProp> listaProductosDisponibles; // Lista COMPLETA

        // Constantes para nombres de columna del DataGridView
        private const string COL_ID_PLATO = "IdPlato";
        private const string COL_NOMBRE = "NombrePlato";
        private const string COL_CANTIDAD = "Cantidad";
        private const string COL_PRECIO_UNIT = "PrecioUnitario";
        private const string COL_SUBTOTAL = "Subtotal";
        // --------------------------

        // --- Constructor ---
        public FrmTicket()
        {
            InitializeComponent();
            miConexion = new ClsConexion();
            listaProductosDisponibles = new List<ClsProdProp>();
            ConfigurarDataGridView();
            // Asume que tu Label se llama LblTotal
            if (LblTotal != null) LblTotal.Text = (0m).ToString("C");
        }
        // --------------------------

        // --- Configuración Inicial y Carga ---
        private void ConfigurarDataGridView()
        {
            // Asume que tu DataGridView se llama GrlMListar
            if (GrlMListar == null) { MessageBox.Show("Error: DGV 'GrlMListar' no encontrado."); return; }
            GrlMListar.Columns.Clear(); GrlMListar.AutoGenerateColumns = false;
            GrlMListar.Columns.Add(new DataGridViewTextBoxColumn { Name = COL_ID_PLATO, DataPropertyName = COL_ID_PLATO, Visible = false });
            GrlMListar.Columns.Add(new DataGridViewTextBoxColumn { Name = COL_NOMBRE, HeaderText = "Producto", DataPropertyName = COL_NOMBRE, Width = 200, ReadOnly = true });
            GrlMListar.Columns.Add(new DataGridViewTextBoxColumn { Name = COL_CANTIDAD, HeaderText = "Cant.", DataPropertyName = COL_CANTIDAD, Width = 50, ReadOnly = true, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            GrlMListar.Columns.Add(new DataGridViewTextBoxColumn { Name = COL_PRECIO_UNIT, HeaderText = "P. Unit.", DataPropertyName = COL_PRECIO_UNIT, Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }, ReadOnly = true });
            GrlMListar.Columns.Add(new DataGridViewTextBoxColumn { Name = COL_SUBTOTAL, HeaderText = "Subtotal", DataPropertyName = COL_SUBTOTAL, Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }, ReadOnly = true });
            GrlMListar.Columns[COL_NOMBRE].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GrlMListar.SelectionMode = DataGridViewSelectionMode.FullRowSelect; GrlMListar.MultiSelect = false;
            GrlMListar.AllowUserToAddRows = false; GrlMListar.AllowUserToDeleteRows = false;
            GrlMListar.RowHeadersVisible = false; GrlMListar.AllowUserToResizeRows = false;
        }

        // MÉTODO PRINCIPAL DE CARGA (Llamado desde FrmAbrirMesa)
        public void CargarInformacionMesa(int numeroMesa, bool esNuevaOrden)
        {
            currentIdMesa = numeroMesa; isNewOrder = esNuevaOrden;
            // Asume que tu Label (invisible?) se llama LblMesa
            if (LblMesa != null) LblMesa.Text = numeroMesa.ToString();
            this.Text = $"Ticket - Mesa {numeroMesa}";

            // Carga inicial con filtro
            CargarCategoriasFiltro();           // Carga CmbMostrarSegun
            CargarListaCompletaProductos();     // Carga productos en memoria
            ActualizarComboProductosFiltrados();// Carga inicial de CmbMenu filtrado

            try
            { // Lógica para crear/cargar orden
                if (isNewOrder)
                {
                    this.Text += " (Nueva Orden)"; GrlMListar.Rows.Clear(); // Asume GrlMListar
                    // Usa el nombre de parámetro correcto de tu ClsConexion.CrearNuevaOrden
                    currentIdOrden = miConexion.CrearNuevaOrden(currentIdMesa); // Ojo si renombraste a idNumeroView
                    if (currentIdOrden <= 0) throw new Exception("No se pudo crear ID de orden.");
                }
                else
                {
                    this.Text += " (Modificando Orden)";
                    currentIdOrden = miConexion.GetActiveOrderIdForMesa(currentIdMesa);
                    if (currentIdOrden <= 0)
                    { // Fallback
                        currentIdOrden = miConexion.CrearNuevaOrden(currentIdMesa); // Ojo si renombraste a idNumeroView
                        if (currentIdOrden <= 0) throw new Exception("No se pudo crear ID de orden (fallback).");
                        GrlMListar.Rows.Clear(); // Asume GrlMListar
                    }
                    else { CargarItemsOrdenExistente(); }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al inicializar orden:\n{ex.Message}"); this.Close(); return; }
            CalcularTotalGrid(); // Llama al método para calcular total
        }

        // Carga el ComboBox de FILTRO de categorías (CmbMostrarSegun)
        private void CargarCategoriasFiltro()
        {
            // Asume que tu ComboBox de filtro se llama CmbMostrarSegun
            if (CmbMostrarSegun == null) return;
            try
            {
                DataTable dtCategorias = miConexion.GetCategoriasDataTable(); // Usa el método nuevo de ClsConexion

                DataRow dr = dtCategorias.NewRow();
                dr["IdCategoria"] = 0; dr["Nombre"] = "(Todas las Categorías)";
                dtCategorias.Rows.InsertAt(dr, 0);

                CmbMostrarSegun.DataSource = dtCategorias;
                CmbMostrarSegun.DisplayMember = "Nombre"; CmbMostrarSegun.ValueMember = "IdCategoria";
                CmbMostrarSegun.SelectedValue = 0; CmbMostrarSegun.DropDownStyle = ComboBoxStyle.DropDownList;

                // Conectar evento al handler
                CmbMostrarSegun.SelectedIndexChanged -= CmbMostrarSegun_SelectedIndexChanged;
                CmbMostrarSegun.SelectedIndexChanged += CmbMostrarSegun_SelectedIndexChanged;
            }
            catch (Exception ex) { MessageBox.Show($"Error cargando filtro categorías: {ex.Message}"); }
        }

        // Carga TODOS los productos en la lista de memoria
        private void CargarListaCompletaProductos()
        {
            try
            {
                listaProductosDisponibles = miConexion.GetAllProducts();
                // Habilitar controles (Usa tus nombres: CmbMenu, NumCantidad, BtnAgregar)
                if (CmbMenu != null) CmbMenu.Enabled = true;
                if (NumCantidad != null) NumCantidad.Enabled = true;
                if (BtnAgregar != null) BtnAgregar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar lista productos:\n{ex.Message}");
                if (CmbMenu != null) CmbMenu.Enabled = false;
                if (NumCantidad != null) NumCantidad.Enabled = false;
                if (BtnAgregar != null) BtnAgregar.Enabled = false;
            }
        }

        // Filtra la lista en memoria y actualiza CmbMenu
        private void ActualizarComboProductosFiltrados()
        {
            // Asume CmbMostrarSegun y CmbMenu
            if (CmbMostrarSegun == null || CmbMenu == null || listaProductosDisponibles == null) return;
            try
            {
                int idCatSel = 0;
                if (CmbMostrarSegun.SelectedValue != null) int.TryParse(CmbMostrarSegun.SelectedValue.ToString(), out idCatSel);
                List<ClsProdProp> prodFiltrados = (idCatSel <= 0) ? listaProductosDisponibles : listaProductosDisponibles.Where(p => p.IdCategoria == idCatSel).ToList();

                CmbMenu.DataSource = null; CmbMenu.DataSource = prodFiltrados;
                CmbMenu.DisplayMember = "Nombre"; CmbMenu.ValueMember = "IdPlato";
                CmbMenu.SelectedIndex = -1;

                bool hayProd = (prodFiltrados.Count > 0);
                CmbMenu.Enabled = hayProd;
                if (NumCantidad != null) NumCantidad.Enabled = hayProd;
                if (BtnAgregar != null) BtnAgregar.Enabled = hayProd; // Asume BtnAgregar
            }
            catch (Exception ex) { MessageBox.Show($"Error al filtrar productos: {ex.Message}"); }
        }

        // Evento que se dispara cuando cambia la categoría en CmbMostrarSegun
        private void CmbMostrarSegun_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Condición para evitar que se dispare durante la carga inicial
            if (this.Visible && (CmbMostrarSegun.Focused || CmbMostrarSegun.ContainsFocus || Form.ActiveForm == this))
            {
                ActualizarComboProductosFiltrados();
            }
        }

        // Carga los items de una orden existente en el grid (GrlMListar)
        private void CargarItemsOrdenExistente()
        {
            GrlMListar.Rows.Clear(); try
            {
                DataTable items = miConexion.GetOrderItems(currentIdOrden);
                if (items != null && items.Rows.Count > 0)
                {
                    foreach (DataRow row in items.Rows)
                    {
                        int idPlato = Convert.ToInt32(row["IdPlato"]); int cantidad = Convert.ToInt32(row["Cantidad"]);
                        // Usa la lista en memoria para obtener nombre/precio
                        ClsProdProp pInfo = listaProductosDisponibles?.FirstOrDefault(p => p.IdPlato == idPlato);
                        string nombre = pInfo?.Nombre ?? "Err: Producto?"; decimal precio = pInfo?.Precio ?? 0m;
                        GrlMListar.Rows.Add(idPlato, nombre, cantidad, precio, cantidad * precio);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error cargando items orden (ID: {currentIdOrden}):\n{ex.Message}"); GrlMListar.Rows.Clear(); }
        }
        // ------------------------------------------

        // --- Lógica Añadir/Quitar Items ---
        // Asume Botón BtnAgregar y handler BtnAgregar_Click o BtnAgregar_Click_1
        private void BtnAgregar_Click_1(object sender, EventArgs e) // O _Click si se llama así
        {
            // 1. Validar selección y cantidad
            if (CmbMenu.SelectedItem == null || NumCantidad.Value <= 0) { /*...*/ return; }

            // 2. Obtener producto y cantidad a agregar
            ClsProdProp prodSel = (ClsProdProp)CmbMenu.SelectedItem;
            int idPlatoAAgregar = prodSel.IdPlato;
            int cantidadAAgregar = (int)NumCantidad.Value;

            // 3. Verificar Stock (como lo teníamos antes)
            try
            {
                int stockActual = miConexion.GetProductStock(idPlatoAAgregar);
                if (stockActual < 0) { MessageBox.Show($"No se pudo verificar stock para '{prodSel.Nombre}'.", "Error Stock"); return; }

                int cantidadYaEnGrid = 0;
                foreach (DataGridViewRow row in GrlMListar.Rows) { if (!row.IsNewRow && Convert.ToInt32(row.Cells[COL_ID_PLATO].Value) == idPlatoAAgregar) { cantidadYaEnGrid = Convert.ToInt32(row.Cells[COL_CANTIDAD].Value); break; } }
                int cantidadTotalNecesaria = cantidadYaEnGrid + cantidadAAgregar;

                if (stockActual < cantidadTotalNecesaria) { MessageBox.Show($"Stock insuficiente para '{prodSel.Nombre}'.\nNecesita: {cantidadTotalNecesaria}\nDisponible: {stockActual}", "Stock Insuficiente"); return; }

                // 4. SI HAY STOCK, restar de BD y luego actualizar grilla

                bool stockRestado = miConexion.UpdateProductStock(idPlatoAAgregar, -cantidadAAgregar);

                if (!stockRestado) { MessageBox.Show($"Error al actualizar stock BD para '{prodSel.Nombre}'.", "Error BD Stock"); return; }

                Console.WriteLine($"Stock para '{prodSel.Nombre}' restado en {cantidadAAgregar}. Actualizando grid.");

                // Actualizar Grilla (añadir/incrementar fila - como antes)
                bool found = false;
                foreach (DataGridViewRow row in GrlMListar.Rows) { if (!row.IsNewRow && Convert.ToInt32(row.Cells[COL_ID_PLATO].Value) == idPlatoAAgregar) { int cantActual = Convert.ToInt32(row.Cells[COL_CANTIDAD].Value); row.Cells[COL_CANTIDAD].Value = cantActual + cantidadAAgregar; row.Cells[COL_SUBTOTAL].Value = Convert.ToInt32(row.Cells[COL_CANTIDAD].Value) * Convert.ToDecimal(row.Cells[COL_PRECIO_UNIT].Value); found = true; break; } }
                if (!found) { GrlMListar.Rows.Add(prodSel.IdPlato, prodSel.Nombre, cantidadAAgregar, prodSel.Precio, cantidadAAgregar * prodSel.Precio); }

                // 5. Actualizar total y limpiar controles
                CalcularTotalGrid();
                CmbMenu.SelectedIndex = -1; NumCantidad.Value = 1; CmbMenu.Focus();

                // --- === INICIO: Aviso de Stock Bajo === ---
                // Después de restar y actualizar la grilla, volvemos a consultar el stock actual
                try
                {
                    int stockDespuesDeRestar = miConexion.GetProductStock(idPlatoAAgregar);
                    Console.WriteLine($"Stock actual para '{prodSel.Nombre}' después de restar: {stockDespuesDeRestar}"); // Log

                    // Comparamos con el umbral (ej. 10)
                    const int UMBRAL_STOCK_BAJO = 10;
                    if (stockDespuesDeRestar >= 0 && stockDespuesDeRestar < UMBRAL_STOCK_BAJO)
                    {
                        // Mostramos un aviso no bloqueante (Information o Warning)
                        MessageBox.Show($"¡Atención! Stock bajo para '{prodSel.Nombre}'. \nQuedan sólo: {stockDespuesDeRestar} unidades.",
                                        "Stock Bajo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception exStockCheck)
                {
                    // Si falla la comprobación final, solo lo anotamos, no detenemos la operación principal
                    Console.WriteLine($"Advertencia: No se pudo comprobar el stock bajo para {prodSel.Nombre} después de agregarlo. Error: {exStockCheck.Message}");
                }
                // --- === FIN: Aviso de Stock Bajo === ---

            }
            catch (Exception ex) { MessageBox.Show($"Error al agregar o verificar stock:\n{ex.Message}"); }
        }

        // Asume Botón BtnQuitar y handler BtnQuitar_Click o BtnQuitar_Click_1
        private void BtnQuitar_Click_1(object sender, EventArgs e) // O _Click si se llama así
        {
            if (GrlMListar.SelectedRows.Count > 0)
            {
                DataGridViewRow rowSel = GrlMListar.SelectedRows[0];
                if (!rowSel.IsNewRow)
                {
                    // --- NUEVO: Devolver Stock a la BD ANTES de quitar la fila ---
                    try
                    {
                        int idPlatoADevolver = Convert.ToInt32(rowSel.Cells[COL_ID_PLATO].Value);
                        int cantidadADevolver = Convert.ToInt32(rowSel.Cells[COL_CANTIDAD].Value);

                        // Llamamos a UpdateProductStock con cantidad POSITIVA para sumar
                        bool stockDevuelto = miConexion.UpdateProductStock(idPlatoADevolver, cantidadADevolver);

                        if (stockDevuelto)
                        {
                            Console.WriteLine($"Stock para ID={idPlatoADevolver} devuelto en {cantidadADevolver}. Procediendo a quitar fila.");
                            // Si se devolvió el stock correctamente, quitar la fila de la grilla
                            GrlMListar.Rows.Remove(rowSel);
                            CalcularTotalGrid(); // Recalcular total
                        }
                        else
                        {
                            // Si falló la devolución del stock, NO quitar la fila y avisar
                            MessageBox.Show("Error al intentar devolver el stock a la base de datos. No se quitó el ítem.", "Error BD Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al intentar devolver stock o quitar fila:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // --- FIN DEVOLUCIÓN STOCK ---
                }
            }
            else { MessageBox.Show("Seleccione la fila que desea quitar de la orden.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        // Calcula y muestra el total del grid
        private void CalcularTotalGrid()
        {
            decimal total = 0; // Asume GrlMListar
            foreach (DataGridViewRow row in GrlMListar.Rows)
            {
                if (!row.IsNewRow && row.Cells[COL_SUBTOTAL].Value != null) { try { total += Convert.ToDecimal(row.Cells[COL_SUBTOTAL].Value); } catch { } }
            } // Asume LblTotal
            if (LblTotal != null) LblTotal.Text = total.ToString("C");
        }
        // ------------------------------------------

        // --- Lógica de Guardado y Cierre ---
        // Método auxiliar para guardar la orden en BD
        private bool GuardarOrden()
        {
            if (currentIdOrden <= 0) { MessageBox.Show("Error interno: ID Orden inválido."); return false; }
            DataTable dtItems = new DataTable(); dtItems.Columns.Add("IdPlato", typeof(int)); dtItems.Columns.Add("Cantidad", typeof(int));
            decimal subTotalItems = 0; // Asume GrlMListar
            foreach (DataGridViewRow row in GrlMListar.Rows)
            {
                if (!row.IsNewRow && row.Cells[COL_ID_PLATO].Value != null /* ... etc */)
                {
                    try
                    {
                        int idPlato = Convert.ToInt32(row.Cells[COL_ID_PLATO].Value); int cantidad = Convert.ToInt32(row.Cells[COL_CANTIDAD].Value);
                        if (cantidad > 0) dtItems.Rows.Add(idPlato, cantidad);
                        subTotalItems += Convert.ToDecimal(row.Cells[COL_SUBTOTAL].Value);
                    }
                    catch { MessageBox.Show($"Error datos fila {row.Index + 1}."); return false; }
                }
            }
            decimal totalFinal = subTotalItems; string metodoPago = ObtenerMetodoPago();
            if (metodoPago == "Débito" && totalFinal > 0) { totalFinal = Math.Round(totalFinal * 1.10m, 2); } // Recargo
            try { return miConexion.SaveOrder(currentIdOrden, dtItems, totalFinal); } // Llama a ClsConexion
            catch (Exception ex) { MessageBox.Show($"Error al guardar orden BD:\n{ex.Message}"); return false; }
        }

        // Botón "Colocar en Espera" (Asume BtnEspera)
        private void BtnEspera_Click(object sender, EventArgs e)
        {
            if (GuardarOrden()) { this.DialogResult = DialogResult.OK; this.Close(); }
        }

        // Botón "Imprimir y Cerrar" (Asume BtnImprimir)
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            string metodoPago = ObtenerMetodoPago();
            if (metodoPago == "Sin especificar" || GrlMListar.Rows.Count == 0) { MessageBox.Show("Seleccione pago y/o agregue items."); return; }
            if (!GuardarOrden()) { MessageBox.Show("Error al guardar estado final."); return; }

            // --- EXPORTAR A CSV (Llamada INCLUIDA) ---
            try { ExportarOrdenACSV(currentIdOrden, metodoPago); }
            catch (Exception exCsv) { MessageBox.Show($"Error exportando a CSV:\n{exCsv.Message}"); /* Continuar? */ }
            // -----------------------------------------

            // Imprimir Ticket
            try { TicketPrinter printer = new TicketPrinter(); printer.GenerarTicketDesdeBD(currentIdOrden, metodoPago); }
            catch (Exception exPrint) { MessageBox.Show($"Error durante impresión:\n{exPrint.Message}"); }

            // Liberar Mesa
            const int ID_ESTADO_LIBRE = 1;
            try { if (!miConexion.UpdateTableStatus(currentIdMesa, ID_ESTADO_LIBRE)) { /* Adv */ } }
            catch (Exception exLiberar) { /* MsgBox Error */ }

            // Cerrar Form
            this.DialogResult = DialogResult.OK; this.Close();
        }

        // Obtiene método de pago seleccionado
        private string ObtenerMetodoPago()
        {   // Asume RdtEfectivo, RdtTransfe, RdtDebito
            if (RdtEfectivo.Checked) return "Efectivo"; if (RdtTransfe.Checked) return "Transferencia"; if (RdtDebito.Checked) return "Débito"; return "Sin especificar";
        }

        // Escribe la orden en el archivo CSV del día
        private void ExportarOrdenACSV(int idOrden, string metodoPago)
        {
            string fechaHoy = DateTime.Now.ToString("yyyy-MM-dd"); string nombreArchivo = $"LibroDiario_{fechaHoy}.csv";
            string rutaCompleta = Path.Combine(Application.StartupPath, nombreArchivo); // Guarda junto al .exe
            try
            {
                OrderHeaderInfo header = miConexion.GetOrderHeaderInfo(idOrden);
                if (header == null) throw new Exception($"No se pudieron obtener datos para Orden {idOrden}.");
                // Usa InvariantCulture para punto decimal, formato fecha/hora ISO, separador ;
                string lineaCsv = string.Format(CultureInfo.InvariantCulture, "\"{0:yyyy-MM-dd HH:mm:ss}\";{1};{2};{3:F2};\"{4}\"", header.Fecha, idOrden, header.NumeroMesa, header.Total, metodoPago);
                bool archivoNuevo = !File.Exists(rutaCompleta);
                using (StreamWriter sw = new StreamWriter(rutaCompleta, true, Encoding.UTF8))
                { // UTF8 para caracteres
                    if (archivoNuevo) { sw.WriteLine("\"FechaHora\";\"IdOrden\";\"IdMesa\";\"Total\";\"MetodoPago\""); } // Cabecera
                    sw.WriteLine(lineaCsv);
                }
                Console.WriteLine($"Línea escrita en {nombreArchivo}");
            }
            catch (Exception ex) { Console.WriteLine($"ERROR al exportar orden {idOrden} a CSV: {ex.Message}"); throw new Exception($"Error al escribir CSV.", ex); }
        }

        // Botón Volver
        private void BtnVolver_Click(object sender, EventArgs e) // Asume BtnVolver
        {
            if (MessageBox.Show("¿Seguro? Cambios no guardados se perderán.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { this.DialogResult = DialogResult.Cancel; this.Close(); }
        }

        // Evento Load (ya no hace casi nada)
        private void FrmTicket_Load(object sender, EventArgs e) { Console.WriteLine("FrmTicket_Load ejecutado."); }

        

    } // Fin clase FrmTicket
}