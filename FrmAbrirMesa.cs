using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Asegúrate de tener este using si usas CultureInfo en algún lado
// using System.Globalization;

namespace PuebloGrill
{
    public partial class FrmAbrirMesa : Form
    {
        // --- Variables y Constantes de Clase ---
        private ClsConexion miConexion = new ClsConexion();
        private const int ID_ESTADO_LIBRE = 1;
        private const int ID_ESTADO_OCUPADO = 3;
        private const int ID_ESTADO_CERRADA = 2;
        // -------------------------------------

        // --- Constructor ---
        public FrmAbrirMesa()
        {
            InitializeComponent();
            AsociarEventosBotonesMesa(); // Asocia el handler único a los botones
            LoadInitialTableStates();    // Carga colores iniciales
        }
        // ------------------

        // --- Métodos Auxiliares ---
        private void AsociarEventosBotonesMesa()
        {
            // Recorre TODOS los controles directamente en el Formulario.
            // --- ¡OJO! Si tus botones están DENTRO de un GroupBox o Panel ---
            // --- tendrás que hacer esto para CADA contenedor, por ejemplo: ---
            // AsociarRecursivo(this.Controls); // Llama a una función recursiva (más avanzado)
            // O si solo tienes un Panel llamado, por ejemplo, 'panelMesas':
            // foreach (Control control in panelMesas.Controls) { ... }

            // Asumiendo que los botones están directamente en el Form:
            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Name.StartsWith("BtnMesa"))
                {
                    // A CADA botón que empieza con "BtnMesa", le asigna el MISMO manejador de eventos
                    btn.Click -= BtnMesa_Click; // Quitar por si acaso se añade múltiples veces (raro)
                    btn.Click += BtnMesa_Click;
                }
            }
            // Si tienes botones en GroupBox (ej: gbMesasAfuera, gbMesasAdentro):
            if (GpAfuera != null)
            {
                foreach (Control control in GpAfuera.Controls)
                {
                    if (control is Button btn && btn.Name.StartsWith("BtnMesa"))
                    {
                        btn.Click -= BtnMesa_Click; btn.Click += BtnMesa_Click;
                    }
                }
            }
            if (GpAdentro != null)
            {
                foreach (Control control in GpAdentro.Controls)
                {
                    if (control is Button btn && btn.Name.StartsWith("BtnMesa"))
                    {
                        btn.Click -= BtnMesa_Click; btn.Click += BtnMesa_Click;
                    }
                }
            }


        }

        private void UpdateButtonColor(Button btn, int idEstado)
        {
            if (idEstado == ID_ESTADO_OCUPADO) { btn.BackColor = Color.Red; }
            else { btn.BackColor = Color.Green; } // Libre o Cerrada = Verde
            btn.Enabled = true; // Asegurar que esté habilitado
        }

        private void LoadInitialTableStates()
        {
            try
            {
                Dictionary<int, int> todosLosEstados = miConexion.GetAllTableStatuses();

                // Función local para procesar controles (evita repetir código para Form/Panels)
                Action<Control.ControlCollection> procesarControles = null;
                procesarControles = (controles) =>
                {
                    foreach (Control control in controles)
                    {
                        if (control is Button btn && btn.Name.StartsWith("BtnMesa"))
                        {
                            if (int.TryParse(btn.Name.Replace("BtnMesa", ""), out int numMesa))
                            {
                                if (todosLosEstados.TryGetValue(numMesa, out int estado)) { UpdateButtonColor(btn, estado); }
                                else { btn.BackColor = Color.LightGray; btn.Enabled = false; Console.WriteLine($"Advertencia: Mesa {numMesa} sin estado en BD."); }
                            }
                            else { btn.BackColor = Color.Orange; btn.Text = "Err"; btn.Enabled = false; }
                        }
                        else if (control.HasChildren) // Procesar controles dentro de contenedores (Panels, GroupBoxes)
                        {
                            procesarControles(control.Controls);
                        }
                    }
                };

                // Procesar controles directamente en el formulario y dentro de contenedores comunes
                procesarControles(this.Controls);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al cargar estados iniciales:\n{ex.Message}", "Error Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshabilitar botones si falla
                Action<Control.ControlCollection> deshabilitarBotones = null;
                deshabilitarBotones = (controles) => {
                    foreach (Control control in controles)
                    {
                        if (control is Button btn && btn.Name.StartsWith("BtnMesa")) { btn.Enabled = false; }
                        else if (control.HasChildren) { deshabilitarBotones(control.Controls); }
                    }
                };
                deshabilitarBotones(this.Controls);
            }
        }
        // --------------------------

        // --- Evento Click ÚNICO ---
        // Este método AHORA manejará el clic de CUALQUIER botón BtnMesaX
        // --- Evento Click ÚNICO para TODOS los botones de mesa ---
        private void BtnMesa_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            string mesaStr = clickedButton.Name.Replace("BtnMesa", "");
            if (int.TryParse(mesaStr, out int numeroMesa))
            {
                Console.WriteLine($"Click en Mesa {numeroMesa}");
                try
                {
                    int estadoActual = miConexion.GetTableStatus(numeroMesa);
                    Console.WriteLine($"Estado actual leído de BD para Mesa {numeroMesa}: {estadoActual}");

                    switch (estadoActual)
                    {
                        case ID_ESTADO_LIBRE: // --- Si está Libre (1) ---
                            Console.WriteLine($"Mesa {numeroMesa} está Libre. Intentando ocupar...");
                            if (miConexion.UpdateTableStatus(numeroMesa, ID_ESTADO_OCUPADO)) // Ponerla Ocupada (3)
                            {
                                UpdateButtonColor(clickedButton, ID_ESTADO_OCUPADO); // Poner en Rojo
                                FrmTicket ticketForm = new FrmTicket();
                                ticketForm.CargarInformacionMesa(numeroMesa, true); // true = nueva orden
                                ticketForm.ShowDialog();
                                LoadInitialTableStates();
                                Console.WriteLine($"FrmTicket (Nueva) cerrada para mesa {numeroMesa}. Estados refrescados.");
                            }
                            else { MessageBox.Show($"No se pudo ocupar la mesa {numeroMesa}.", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                            break;

                        case ID_ESTADO_OCUPADO: // --- Si está Ocupada (3) ---
                            Console.WriteLine($"Mesa {numeroMesa} está Ocupada. Abriendo diálogo de acciones...");

                            using (FrmAccionesMesaOcupada DlgAcciones = new FrmAccionesMesaOcupada(numeroMesa))
                            {
                                DialogResult resultadoDialogo = DlgAcciones.ShowDialog(this); // Mostrar como diálogo modal

                                if (resultadoDialogo == DialogResult.OK) // El usuario presionó Modificar, Limpiar o Cobrada
                                {
                                    switch (DlgAcciones.AccionSeleccionada)
                                    {
                                        case TipoAccionMesa.Modificar:
                                            Console.WriteLine($"Usuario eligió: Modificar Orden para mesa {numeroMesa}.");
                                            FrmTicket ticketFormMod = new FrmTicket();
                                            ticketFormMod.CargarInformacionMesa(numeroMesa, false); // false = orden existente
                                            ticketFormMod.ShowDialog();
                                            LoadInitialTableStates(); // Refrescar estados
                                            Console.WriteLine($"FrmTicket (Modificar) cerrada para mesa {numeroMesa}. Estados refrescados.");
                                            break;

                                        case TipoAccionMesa.Limpiar:
                                            Console.WriteLine($"Usuario eligió: Limpiar Mesa {numeroMesa}.");
                                            DialogResult confirmLimpiar = MessageBox.Show($"¿Está seguro que desea LIMPIAR la mesa {numeroMesa}?\nEsto ANULARÁ la orden actual y liberará la mesa.",
                                                                                         "Confirmar Limpieza de Mesa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                            if (confirmLimpiar == DialogResult.Yes)
                                            {
                                                int idOrdenActivaLimpiar = miConexion.GetActiveOrderIdForMesa(numeroMesa);
                                                bool ordenAnuladaOk = true; // Asumir éxito si no hay orden

                                                if (idOrdenActivaLimpiar > 0)
                                                {
                                                    Console.WriteLine($"Intentando anular/limpiar orden ID: {idOrdenActivaLimpiar} para mesa {numeroMesa}.");
                                                    // AQUÍ VA TU LÓGICA PARA ANULAR LA ORDEN EN LA BD Y DEVOLVER STOCK
                                                    // Ejemplo: ordenAnuladaOk = miConexion.AnularOrdenYDevolverStock(idOrdenActivaLimpiar);
                                                    // Por ahora, solo un mensaje:
                                                    MessageBox.Show($"Simulación: Orden ID {idOrdenActivaLimpiar} ANULADA y stock devuelto.", "Limpieza (Simulación)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }

                                                if (ordenAnuladaOk)
                                                {
                                                    if (miConexion.UpdateTableStatus(numeroMesa, ID_ESTADO_LIBRE))
                                                    {
                                                        UpdateButtonColor(clickedButton, ID_ESTADO_LIBRE); // Poner en Verde
                                                        MessageBox.Show($"Mesa {numeroMesa} LIMPIADA y marcada como libre.", "Mesa Liberada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show($"Se anuló la orden (si existía), pero no se pudo liberar la mesa {numeroMesa}.", "Error DB Parcial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show($"No se pudo anular la orden ID {idOrdenActivaLimpiar}. La mesa {numeroMesa} no fue liberada.", "Error Anulación Orden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else { Console.WriteLine($"Limpieza de mesa {numeroMesa} cancelada por el usuario."); }
                                            break;

                                        case TipoAccionMesa.Cobrada:
                                            Console.WriteLine($"Usuario eligió: Cobrada y Cerrar para mesa {numeroMesa}.");
                                            DialogResult confirmCobrado = MessageBox.Show($"¿Confirma que la orden de la mesa {numeroMesa} ha sido COBRADA y desea liberarla?",
                                                                                         "Confirmar Cobro y Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (confirmCobrado == DialogResult.Yes)
                                            {
                                                // Se asume que el FrmTicket ya guardó la orden como cobrada, imprimió, etc.
                                                // Aquí solo liberamos la mesa.
                                                if (miConexion.UpdateTableStatus(numeroMesa, ID_ESTADO_LIBRE))
                                                {
                                                    UpdateButtonColor(clickedButton, ID_ESTADO_LIBRE); // Poner en Verde
                                                    MessageBox.Show($"Mesa {numeroMesa} marcada como COBRADA y LIBRE.", "Mesa Liberada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else
                                                {
                                                    MessageBox.Show($"No se pudo liberar la mesa {numeroMesa} después del cobro.", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                            }
                                            else { Console.WriteLine($"Cobro y cierre de mesa {numeroMesa} cancelado por el usuario."); }
                                            break;
                                    }
                                }
                                else // El usuario presionó Cancelar en el diálogo de acciones o cerró la ventana
                                {
                                    Console.WriteLine($"Acción para mesa {numeroMesa} cancelada por el usuario desde el diálogo.");
                                }
                            }
                            break;

                        case ID_ESTADO_CERRADA:
                            Console.WriteLine($"Mesa {numeroMesa} está en estado 'Cerrada'.");
                            DialogResult reabrirResult = MessageBox.Show($"La mesa {numeroMesa} figura como 'Cerrada'.\n\n¿Desea marcarla como 'Libre' para una nueva orden?",
                                                                        "Mesa Cerrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (reabrirResult == DialogResult.Yes)
                            {
                                if (miConexion.UpdateTableStatus(numeroMesa, ID_ESTADO_LIBRE))
                                {
                                    UpdateButtonColor(clickedButton, ID_ESTADO_LIBRE);
                                    MessageBox.Show($"Mesa {numeroMesa} marcada como Libre.", "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show($"No se pudo actualizar el estado de la mesa {numeroMesa}.", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            break;

                        default:
                            Console.WriteLine($"Estado desconocido ({estadoActual}) para Mesa {numeroMesa}.");
                            MessageBox.Show($"No se pudo procesar la mesa {numeroMesa}. Estado desconocido o error al leer (Estado devuelto: {estadoActual}).", "Error de Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clickedButton.BackColor = Color.Orange;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al procesar acción para mesa {numeroMesa}:\n{ex.InnerException?.Message ?? ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Error: Nombre de botón no válido '{clickedButton.Name}'.", "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // --- Otros Eventos (Ej: Volver) ---
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

        // !!! IMPORTANTE: BORRA todos los otros métodos BtnMesaX_Click !!!
        // (BtnMesa2_Click, BtnMesa3_Click, ..., BtnMesa50_Click)
        // Ya no los necesitas porque todos los botones usarán BtnMesa_Click

        // Borra también FrmAbrirMesa_Load si está vacío
        private void FrmAbrirMesa_Load(object sender, EventArgs e) { }

        // Borra otros handlers vacíos si no los usas
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void BtnActualizar_Click(object sender, EventArgs e) { }

        private void BtnMesa1_Click(object sender, EventArgs e)
        {

        }
    } // Fin de la clase FrmAbrirMesa
}