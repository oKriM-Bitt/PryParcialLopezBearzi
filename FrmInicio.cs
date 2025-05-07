using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryPueblox
{
    public partial class FrmInicio: Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void revisarPlatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMostrarStock frmConsultarPlatos = new FrmMostrarStock();
            frmConsultarPlatos.Show();
            this.Hide();
        }

        private void cargarYSeleccionarMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbrirMesa frm = new FrmAbrirMesa();
            frm.Show();
            this.Hide();
        }

        private void cargarPlatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCargarProducto_Click(object sender, EventArgs e)
        {
            FrmCargarPlato frmCargarPlatos = new FrmCargarPlato();
            frmCargarPlatos.Show();
            this.Hide();
        }

        private void BtnLibro_Click(object sender, EventArgs e)
        {
            FrmLibrioDiario frmLibrioDiario = new FrmLibrioDiario();
            frmLibrioDiario.Show();
            this.Hide();
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            FrmAbrirMesa frm = new FrmAbrirMesa();
            frm.Show();
            this.Hide();
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {
            FrmMostrarStock frmConsultarPlatos = new FrmMostrarStock();
            frmConsultarPlatos.Show();
            this.Hide();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPerfil_Click(object sender, EventArgs e)
        {
            if (SesionUsuario.IsUserLoggedIn)
            {
                // Crear y mostrar el formulario de perfil
                // Ya no necesitamos pasar el ID, FrmPerfil lo obtiene de SesionUsuario
                FrmPerfil frmPerfil = new FrmPerfil();
                // Es mejor usar ShowDialog si quieres que el usuario termine
                // con el perfil antes de volver a FrmInicio.
                frmPerfil.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay sesión activa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            ClsConexion instancia = new ClsConexion();

            // este es el contenido que se guarda  \n ese saltea la linea
            string contenido = "Analista de Sistemas\n" +
                               "Laboratorio de Programación 2\n" +
                               "DNI Alumno: 46 510 718\n" +
                               "Nombre Alumno: Mirko Lopez Bearzi" +
                               "Descripción del Proyecto\r\n" +
                               "Control Visual de Mesas: Permite ver el estado (libre/ocupada) de las mesas del restaurante a través de una interfaz gráfica con botones.\r\nAdministración de Órdenes: Abre nuevas órdenes al seleccionar mesas libres o carga órdenes existentes para mesas ocupadas. Permite añadir o quitar productos del pedido.\r\nGestión de Menú: Carga productos desde la base de datos, muestra precios, permite filtrar por categoría y maneja (implícitamente) el stock.\r\nProceso de Pago y Ticket: Calcula el total de la orden, permite seleccionar el método de pago (con posible recargo) y genera un ticket detallado para imprimir.\r\nRegistro/Exportación: Guarda las órdenes finalizadas y exporta un resumen diario en formato CSV.\r\nArquitectura Refactorizada: El código está organizado en clases separadas para la lógica de acceso a datos (CRUD para Órdenes, Productos, Categorías) y la interfaz de usuario (Formularios)." +
                               ""

                               ;

            // intanciamos el metodo y lo grabamo
            instancia.Grabar(contenido);
        }
    }
}
