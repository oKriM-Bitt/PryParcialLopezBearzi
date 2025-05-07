using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Using para Chart

namespace PryPueblox
{
    public partial class FrmMostrarStock : Form
    {
        // Instancias de las clases CRUD
        private ClsCategoriasCRUD categoriaDal = new ClsCategoriasCRUD();
        private ClsProductosCRUD productoDal = new ClsProductosCRUD();
        private ClsOrdenesCRUD ordenDal = new ClsOrdenesCRUD();

        public FrmMostrarStock()
        {
            InitializeComponent();
            // Opcional: Configurar columnas de las grillas aquí si no lo haces en el diseñador
            ConfigurarGrids();
        }

        // Opcional: Método para configurar columnas de ambas grillas
        private void ConfigurarGrids()
        {
            ConfigurarGrid(GrlmAtras);  // Configura GrlmAtras
            ConfigurarGrid(GrlmAdelante); // Configura GrlmAdelante
        }

        private void ConfigurarGrid(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = null; // Empezar sin DataSource

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = $"ColIdPlato_{dgv.Name}", HeaderText = "ID", DataPropertyName = "IdPlato", Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = $"ColNombre_{dgv.Name}", HeaderText = "Producto", DataPropertyName = "Nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = $"ColPrecio_{dgv.Name}", HeaderText = "Precio", DataPropertyName = "Precio", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            // Asegúrate que tu método GetAllProductosTable/GetProductosPorCategoria devuelva Stock
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = $"ColStock_{dgv.Name}", HeaderText = "Stock", DataPropertyName = "Stock", Width = 60, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.ReadOnly = true;
        }


        // --- Evento Load: Cargar todo ---
        private void FrmMostrar_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Cargando FrmMostrarStock...");
            try
            {
                // Cargar ComboBox
                categoriaDal.CargarCategoriasDirectoEnCombo(CmbCategoria);
                if (CmbCategoria.DataSource is DataTable dtCat && dtCat.Columns.Contains("IdCategoria")) { /* ... añadir "(Todas)" ... */ DataRow dr = dtCat.NewRow(); dr["IdCategoria"] = 0; dr["Nombre"] = "(Todas)"; dtCat.Rows.InsertAt(dr, 0); CmbCategoria.SelectedIndex = 0; }

                // Cargar Gráfico
                CargarGraficoPopularidad();
                if (ChtPopularidad != null) ChtPopularidad.Visible = true;

                // Cargar Grilla "Atrás" con todos los productos
                Console.WriteLine("Cargando GrlmAtras (Todos)...");
                // --- MODIFICADO: Usar DataSource ---
                GrlmAtras.DataSource = productoDal.GetAllProductosTable();
                // ------------------------------------

                // Visibilidad Inicial
                GrlmAtras.Visible = true;
                GrlmAdelante.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show($"Error carga inicial:\n{ex.Message}"); }
        }

        // --- Carga Gráfico (Sin cambios internos, solo usa ordenDal y ChtStock) ---
        private void CargarGraficoPopularidad()
        {
            if (ChtPopularidad == null) return;
            Console.WriteLine("Cargando gráfico...");
            try { /* ... código para limpiar y llenar ChtStock usando ordenDal.GetProductosPopulares() ... */ } catch (Exception ex) { /* ... manejo error ... */ }
            // --- Copia el contenido de este método de la respuesta anterior ---
            try { DataTable dtPopulares = ordenDal.GetProductosPopulares(10); ChtPopularidad.Series.Clear(); ChtPopularidad.Titles.Clear(); ChtPopularidad.ChartAreas[0].AxisX.CustomLabels.Clear(); ChtPopularidad.Titles.Add("Top 10 Vendidos"); /*...*/ if (dtPopulares != null && dtPopulares.Rows.Count > 0) { Series seriesPop = new Series("P") { ChartType = SeriesChartType.Column, IsValueShownAsLabel = true }; foreach (DataRow row in dtPopulares.Rows) { seriesPop.Points.AddXY(row["Nombre"].ToString(), Convert.ToInt32(row["TotalVendido"])); } ChtPopularidad.Series.Add(seriesPop); /*...*/ } else { ChtPopularidad.Titles[0].Text = "No hay datos"; } ChtPopularidad.Visible = true; } catch (Exception ex) { MessageBox.Show($"Error gráfico:\n{ex.Message}"); if (ChtPopularidad != null) ChtPopularidad.Visible = false; }
        }

        // --- Evento ComboBox: Mostrar/Ocultar Grillas y Cambiar DataSource ---
        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Visible || !CmbCategoria.ContainsFocus || CmbCategoria.SelectedValue == null) return;

            int idCategoria;
            if (CmbCategoria.SelectedIndex > 0 && int.TryParse(CmbCategoria.SelectedValue.ToString(), out idCategoria))
            {
                // Categoría Específica -> Mostrar Grilla "Adelante" con datos filtrados
                Console.WriteLine($"Filtrando por Cat ID: {idCategoria}");
                GrlmAdelante.Visible = true;
                GrlmAtras.Visible = false;
                // --- MODIFICADO: Usar DataSource con método que devuelve DataTable ---
                GrlmAdelante.DataSource = productoDal.GetProductosPorCategoria(idCategoria);
                // --------------------------------------------------------------------
            }
            else
            {
                // "Todas" -> Mostrar Grilla "Atrás" con todos los datos
                Console.WriteLine("Mostrando todos (ComboBox).");
                GrlmAtras.Visible = true;
                GrlmAdelante.Visible = false;
                // --- MODIFICADO: Usar DataSource ---
                // Opcional refrescar, podría no ser necesario si el botón lo hace
                // GrlmAtras.DataSource = productoDal.GetAllProductosTable();
                // ------------------------------------
            }
            // Gráfico siempre visible
            if (ChtPopularidad != null) ChtPopularidad.Visible = true;
        }

        // --- Botón Mostrar Todo: Mostrar Grilla "Atrás" con Todos ---
        private void BtnMostrarSegun_Click(object sender, EventArgs e) // ¡Verifica nombre botón!
        {
            Console.WriteLine("Botón Mostrar Todo presionado.");
            GrlmAtras.Visible = true;
            GrlmAdelante.Visible = false;
            if (ChtPopularidad != null) ChtPopularidad.Visible = true;

            // --- MODIFICADO: Usar DataSource ---
            GrlmAtras.DataSource = productoDal.GetAllProductosTable();
            // ------------------------------------

            if (CmbCategoria.Items.Count > 0) CmbCategoria.SelectedIndex = 0;
        }

        // --- Botón Volver ---
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


        // --- Eventos No Utilizados ---
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void GrlmAtras_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void GrlmAdelante_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

    } // Fin clase FrmMostrarStock
}