using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization; // Para formato moneda y TryParse
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuebloGrill
{
    public partial class FrmCargarPlato : Form
    {
        // ---      Clases CRUD específicas ---
        private ClsProductosCRUD Produc = new ClsProductosCRUD();
        private ClsCategoriasCRUD Cate = new ClsCategoriasCRUD();

        public FrmCargarPlato()
        {
            InitializeComponent();
            
        }

        
        #region CARGA
        // --- Configuración y Carga ---
        private void ConfigurarGridProductos()
        {
            if (Grlm == null) return;
            Grlm.Columns.Clear(); Grlm.AutoGenerateColumns = false;

            // Configuracion de grillita
            Grlm.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "IdPlato", HeaderText = "ID", DataPropertyName = "IdPlato", Width = 50 
            });
            Grlm.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Nombre", HeaderText = "Nombre Producto", DataPropertyName = "Nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill 
            });
            Grlm.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Precio", HeaderText = "Precio", DataPropertyName = "Precio", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight } 
            });
            Grlm.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Stock", HeaderText = "Stock", DataPropertyName = "Stock", Width = 60, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } 
            });
            Grlm.Columns.Add(new DataGridViewTextBoxColumn 
            {
                Name = "IdCategoria", HeaderText = "ID Cat.", DataPropertyName = "IdCategoria", Visible = false 
            }); 

           //para seleccionarlo y mandarlo a los txt 
            Grlm.SelectionMode = DataGridViewSelectionMode.FullRowSelect; Grlm.MultiSelect = false; Grlm.AllowUserToAddRows = false; Grlm.AllowUserToDeleteRows = false; Grlm.RowHeadersVisible = false; Grlm.ReadOnly = true;
            Grlm.SelectionChanged -= Grlm_SelectionChanged; Grlm.SelectionChanged += Grlm_SelectionChanged;
        }

        private void CargarCategoriasCombos()
        {
            try
            {
                Console.WriteLine("Cargando categorías en ComboBoxes...");
                //Carga la categoria
                Cate.CargarCategoriasDirectoEnCombo(CmbCategoria);
                
                if (CmbCategoriaModificar != null)
                {
                    Cate.CargarCategoriasDirectoEnCombo(CmbCategoriaModificar);
                }
                
            }
            catch (Exception ex) { MessageBox.Show($"Error cargando categorías:\n{ex.Message}"); }
        }


        // Refresca la tabla da productos
        private void CargarGridProductos()
        {
            Console.WriteLine("Recargando grid de productos...");
            if (Grlm == null) return;
            try
            {
                //carga la lista de producto
                List<ClsProdProp> productos = Produc.GetAllProducts();
                
                // guardar seleccion
                int indiceSeleccionado = Grlm.SelectedRows.Count > 0 ? Grlm.SelectedRows[0].Index : -1;
                int primerFilaVisible = Grlm.FirstDisplayedScrollingRowIndex >= 0 ? Grlm.FirstDisplayedScrollingRowIndex : 0;

                Grlm.DataSource = null; // actualiza si existe nuevos datos
                if (productos != null && productos.Count > 0) { Grlm.DataSource = productos; }
                else { Grlm.DataSource = null; Console.WriteLine("No se cargaron productos en la grilla."); }

                // Restaurar selección 
                if (Grlm.Rows.Count > 0)
                {
                    if (indiceSeleccionado >= 0 && indiceSeleccionado < Grlm.Rows.Count) { Grlm.Rows[indiceSeleccionado].Selected = true; }
                    if (primerFilaVisible >= 0 && primerFilaVisible < Grlm.Rows.Count) { Grlm.FirstDisplayedScrollingRowIndex = primerFilaVisible; }
                    else if (Grlm.Rows.Count > 0) { Grlm.FirstDisplayedScrollingRowIndex = 0; } // Ir al inicio si no hay scroll previo
                }
                else { LimpiarCamposModificar(); } // Limpiar si la grilla queda vacía

            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar productos en grilla:\n{ex.Message}"); Grlm.DataSource = null; }
            if (Grlm.SelectedRows.Count == 0) LimpiarCamposModificar(); // Asegurar limpieza si no hay selección
        }

        #endregion carga


        #region Limpiar campos
        // --- Limpieza de Campos ---
        private void LimpiarCamposCarga()
        {
            TxtNombre.Clear(); TxtPrecio.Clear(); TxtStock.Clear(); 
            CmbCategoria.SelectedIndex = -1; TxtNombre.Focus();
        }

        private void LimpiarCamposModificar()
        {
            TxtCodigoModificar.Clear(); TxtCodigoModificar.ReadOnly = true;
            TxtNombreModificar.Clear(); TxtNombreModificar.Enabled = false;
            TxtPrecioModificar.Clear(); TxtPrecioModificar.Enabled = false;
            TxtStockModificar.Clear(); TxtStockModificar.Enabled = false; // Añadido Stock
            CmbCategoriaModificar.SelectedIndex = -1; CmbCategoriaModificar.Enabled = false;
            BtnModificar.Enabled = false; BtnEliminar.Enabled = false;
            if (Grlm.SelectedRows.Count > 0) Grlm.ClearSelection(); // Quitar selección del grid
        }
        #endregion

        #region botones
        // --- Eventos de Botones ---
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(TxtNombre.Text))
            { 
                MessageBox.Show("Ingrese nombre."); TxtNombre.Focus(); return; 
            }
            if (CmbCategoria.SelectedValue == null) 
            { 
                MessageBox.Show("Seleccione categoría."); CmbCategoria.Focus(); return; 
            }
            if (!decimal.TryParse(TxtPrecio.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal precio) || precio < 0)
            { 
                MessageBox.Show("Precio inválido (número positivo)."); TxtPrecio.Focus(); return;
            }
            if (!int.TryParse(TxtStock.Text, out int stock) || stock < 0)
            { 
                MessageBox.Show("Stock inválido (entero >= 0)."); TxtStock.Focus(); return; 
            }

            try
            {
                string nombre = TxtNombre.Text.Trim();
                int idCategoria = Convert.ToInt32(CmbCategoria.SelectedValue);

                
                if (Produc.AgregarProducto(nombre, precio, idCategoria, stock))
                {
                    MessageBox.Show("Producto agregado.", "Éxito"); LimpiarCamposCarga(); CargarGridProductos();
                }
             
            }
            catch (Exception ex) { MessageBox.Show($"Error al agregar:\n{ex.Message}"); }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(TxtCodigoModificar.Text)) { MessageBox.Show("Seleccione producto."); return; }
            if (string.IsNullOrWhiteSpace(TxtNombreModificar.Text)) { MessageBox.Show("Ingrese nombre."); TxtNombreModificar.Focus(); return; }
            if (CmbCategoriaModificar.SelectedValue == null) { MessageBox.Show("Seleccione categoría."); CmbCategoriaModificar.Focus(); return; }
            if (!decimal.TryParse(TxtPrecioModificar.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal nuevoPrecio) || nuevoPrecio < 0) { MessageBox.Show("Precio inválido."); TxtPrecioModificar.Focus(); return; }
            if (!int.TryParse(TxtStockModificar.Text, out int nuevoStock) || nuevoStock < 0) { MessageBox.Show("Stock inválido."); TxtStockModificar.Focus(); return; }

            try
            {
                int idPlato = int.Parse(TxtCodigoModificar.Text);
                string nuevoNombre = TxtNombreModificar.Text.Trim();
                int nuevoIdCategoria = Convert.ToInt32(CmbCategoriaModificar.SelectedValue);

               
                if (Produc.ActualizarProducto(idPlato, nuevoNombre, nuevoPrecio, nuevoIdCategoria, nuevoStock))
                {
                    MessageBox.Show("Producto actualizado.", "Éxito"); CargarGridProductos(); LimpiarCamposModificar();
                }
              
            }
            catch (Exception ex) { MessageBox.Show($"Error al actualizar:\n{ex.Message}"); }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (Grlm.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace(TxtCodigoModificar.Text)) { MessageBox.Show("Seleccione producto a eliminar."); return; }

            try
            {
                int idPlato = int.Parse(TxtCodigoModificar.Text);
                string nombreProd = TxtNombreModificar.Text; // Ya lo tenemos en el textbox

                DialogResult dr = MessageBox.Show($"¿Seguro de eliminar '{nombreProd}' (ID: {idPlato})?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    // --- MODIFICADO: Usar productoDal y método renombrado ---
                    if (Produc.EliminarProducto(idPlato))
                    {
                        MessageBox.Show("Producto eliminado.", "Éxito"); CargarGridProductos(); LimpiarCamposModificar();
                    }
                    // else { DAL ya muestra error/advertencia }
                    // -------------------------------------------------------
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al eliminar:\n{ex.Message}"); }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            // Preguntar al usuario si está seguro (con sintaxis corregida)
            DialogResult respuesta = MessageBox.Show(
                "¿Seguro que desea volver?", // Mensaje
                "Confirmar Salida",  // Título de la ventana
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning   
            );

            // Verificar la respuesta del usuario
            if (respuesta == DialogResult.Yes)
            {
               
                Console.WriteLine("Usuario confirmó volver. Abriendo FrmInicio y cerrando formulario actual."); 

             
                FrmInicio frmInicio = new FrmInicio();

                frmInicio.Show();

               
                this.Hide();
            }
        }

        #endregion

        #region Selleciongrilla
        // GrlmSeleccion

        private void Grlm_SelectionChanged(object sender, EventArgs e)
        {
            if (Grlm.SelectedRows.Count == 1)
            {
                DataGridViewRow fila = Grlm.SelectedRows[0];
                // Usar DataBoundItem es más seguro si el DataSource es una List<ClsProducto>
                if (fila.DataBoundItem is ClsProdProp prodSeleccionado)
                {
                    TxtCodigoModificar.Text = prodSeleccionado.IdPlato.ToString(); TxtCodigoModificar.ReadOnly = true;
                    TxtNombreModificar.Text = prodSeleccionado.Nombre; TxtNombreModificar.Enabled = true;
                    TxtPrecioModificar.Text = prodSeleccionado.Precio.ToString("N2"); TxtPrecioModificar.Enabled = true;
                    TxtStockModificar.Text = prodSeleccionado.Stock.ToString(); TxtStockModificar.Enabled = true; // Añadido Stock
                    CmbCategoriaModificar.SelectedValue = prodSeleccionado.IdCategoria; CmbCategoriaModificar.Enabled = true; // Intentar seleccionar
                    if (CmbCategoriaModificar.SelectedValue == null) CmbCategoriaModificar.SelectedIndex = -1; // Fallback si ID no existe en combo

                    BtnModificar.Enabled = true; BtnEliminar.Enabled = true;
                }
                else
                { // Si no se pudo obtener el objeto (ej. DataSource no es List<>) , intentar por celdas
                    TxtCodigoModificar.Text = fila.Cells["IdPlato"]?.Value?.ToString() ?? ""; TxtCodigoModificar.ReadOnly = true;
                    TxtNombreModificar.Text = fila.Cells["Nombre"]?.Value?.ToString() ?? ""; TxtNombreModificar.Enabled = true;
                    object precioObj = fila.Cells["Precio"]?.Value; TxtPrecioModificar.Text = precioObj != null ? Convert.ToDecimal(precioObj).ToString("N2") : ""; TxtPrecioModificar.Enabled = true;
                    object stockObj = fila.Cells["Stock"]?.Value; TxtStockModificar.Text = stockObj != null ? stockObj.ToString() : "0"; TxtStockModificar.Enabled = true; // Añadido Stock
                    object idCatObj = fila.Cells["IdCategoria"]?.Value; CmbCategoriaModificar.Enabled = true;
                    if (idCatObj != null) CmbCategoriaModificar.SelectedValue = idCatObj; else CmbCategoriaModificar.SelectedIndex = -1;
                    if (CmbCategoriaModificar.SelectedValue == null) CmbCategoriaModificar.SelectedIndex = -1; // Fallback

                    BtnModificar.Enabled = !string.IsNullOrEmpty(TxtCodigoModificar.Text); BtnEliminar.Enabled = !string.IsNullOrEmpty(TxtCodigoModificar.Text);
                }
            }
            else { LimpiarCamposModificar(); }
        }
        #endregion
        // --- Validadores KeyPress ---
        private void ValidarNumeroEntero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }
        private void ValidarDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            string separadorDecimal = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar.ToString() != separadorDecimal)) { e.Handled = true; }
           
            if ((e.KeyChar.ToString() == separadorDecimal) && ((sender as TextBox).Text.Contains(separadorDecimal))) { e.Handled = true; }
        }

       
        private void Grlm_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void FrmCargarPlato_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Cargando FrmCargarPlato...");
            ConfigurarGridProductos(); // Configura columnas, incluyendo Stock
            CargarCategoriasCombos();  // Carga ambos ComboBox de categorías
            CargarGridProductos();     // Carga los productos en la grilla
            LimpiarCamposCarga();      // Limpia campos de la izquierda
            LimpiarCamposModificar();  // Limpia y deshabilita campos de la derecha/
            Console.WriteLine("FrmCargarPlato cargado.");

            // Añadir validadores KeyPress para campos numéricos
            TxtPrecio.KeyPress += ValidarDecimal_KeyPress;
            TxtStock.KeyPress += ValidarNumeroEntero_KeyPress;
            TxtPrecioModificar.KeyPress += ValidarDecimal_KeyPress;
            TxtStockModificar.KeyPress += ValidarNumeroEntero_KeyPress;
        }
    } 
}