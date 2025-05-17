using System;
using System.Windows.Forms;

namespace PuebloGrill
{
    // Primero, define el enum que usaremos para las acciones.
    // Puede estar aquí o en un archivo separado de Enums si tienes más.
    public enum TipoAccionMesa
    {
        Modificar,
        Limpiar,
        Cobrada,
        Cancelar,
        Ninguna // Para el caso de que se cierre el diálogo sin presionar un botón de acción explícito
    }

    public partial class FrmAccionesMesaOcupada : Form
    {
        public TipoAccionMesa AccionSeleccionada { get; private set; }
        private int numeroDeMesa;

        // Constructor que acepta el número de mesa
        public FrmAccionesMesaOcupada(int numMesa)
        {
            InitializeComponent();
            this.numeroDeMesa = numMesa;
            this.AccionSeleccionada = TipoAccionMesa.Ninguna; // Valor por defecto
        }

        private void FrmAccionesMesaOcupada_Load(object sender, EventArgs e)
        {
            // Establecer el mensaje en el Label
            if (lblMensajeAccion != null) // Verifica que el Label exista
            {
                lblMensajeAccion.Text = $"Seleccione una acción para la Mesa {this.numeroDeMesa}:";
            }
            // Opcional: enfocar el primer botón o el de cancelar por defecto
            // btnModificar.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionada = TipoAccionMesa.Modificar;
            this.DialogResult = DialogResult.OK; // Indica que se tomó una acción
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionada = TipoAccionMesa.Limpiar;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCobrada_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionada = TipoAccionMesa.Cobrada;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionada = TipoAccionMesa.Cancelar; // O podría ser Ninguna si Cancelar es solo cerrar
            this.DialogResult = DialogResult.Cancel; // Indica que se canceló
            this.Close();
        }
    }
}