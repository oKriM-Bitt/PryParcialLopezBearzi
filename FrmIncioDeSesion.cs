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
    public partial class FrmIncioDeSesion : Form
    {
        // --- Instancia de la clase de acceso a datos de usuario ---
        private ClsUsuarioCRUD User = new ClsUsuarioCRUD();

        public FrmIncioDeSesion()
        {
            InitializeComponent();
            SetupEventosEnter();
        }

        // --- Evento para ir al formulario de Registro ---
        private void LblRegister_Click(object sender, EventArgs e)
        {
            FrmRegistro F = new FrmRegistro();
            F.Show();
            // Considera this.Close() si quieres cerrar login al ir a registro
            this.Hide();
        }

        // --- Evento Click del Botón "Iniciar Sesión" ---
        private void BtnIniciar_Click(object sender, EventArgs e)
        {
           
            string nombreUsuario = TxtUsuario.Text.Trim();
            string contrasena = TxtContraseña.Text; 

            // 2. Validación 
            if (string.IsNullOrWhiteSpace(nombreUsuario)) { MessageBox.Show("Ingrese usuario."); TxtUsuario.Focus(); return; }
            if (string.IsNullOrEmpty(contrasena)) { MessageBox.Show("Ingrese contraseña."); TxtContraseña.Focus(); return; }

            
            try
            {
                bool loginValido = User.VerificarLogin(nombreUsuario, contrasena);

                
                if (loginValido)
                {
                    
                    Console.WriteLine($"Login válido para {nombreUsuario}. Obteniendo datos..."); 
                    DataRow infoUsuario = User.GetUsuarioInfoCompleta(nombreUsuario);

                    // Verificar si pudimos obtener los datos
                    if (infoUsuario != null)
                    {
                        // Guardar los datos en la sesión estática para usarlos después
                        SesionUsuario.IniciarSesion(
                            Convert.ToInt32(infoUsuario["IdUsuario"]),
                            infoUsuario["Nombre de Usuario"].ToString(),
                            infoUsuario["Nombre"].ToString(),
                            infoUsuario["Apellido"].ToString(),
                            infoUsuario["Correo"].ToString(),
                            Convert.ToInt32(infoUsuario["IdCategoriaU"]) // ID del Rol
                        );

                        // Mostrar bienvenida personalizada
                        MessageBox.Show($"¡Inicio de sesión exitoso!\nBienvenido {SesionUsuario.NombreCompleto}", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Abrir el formulario principal
                        FrmInicio frmPrincipal = new FrmInicio();
                        frmPrincipal.Show();

                        // Cerrar este formulario de login (usar Close es mejor que Hide)
                        this.Hide();
                    }
                    else
                    {
                        // Error muy raro: El login fue válido, pero no pudimos obtener los datos del usuario.
                        MessageBox.Show("Login válido, pero ocurrió un error al recuperar la información del usuario.", "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine($"Error: GetUsuarioInfoCompleta devolvió null para el usuario válido {nombreUsuario}");
                    }
                  
                }
                else
                {
                    // Login Fallido
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtContraseña.Clear(); // Limpiar solo la contraseña
                    TxtUsuario.Focus();    // Poner foco en usuario
                    TxtUsuario.SelectAll(); // Seleccionar texto
                }
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados (ej. error de BD)
                MessageBox.Show($"Ocurrió un error al intentar iniciar sesión:\n{ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Evento Load ---
        private void FrmIncioDeSesion_Load(object sender, EventArgs e)
        {
            // Poner el foco en el campo de usuario al cargar
            TxtUsuario.Focus();
        }

        // --- Métodos para Permitir login con la tecla Enter ---
        private void SetupEventosEnter()
        {
            // ¡Verifica los nombres TxtUsuario y TxtContraseña!
            TxtUsuario.KeyDown += TextBox_KeyDown;
            TxtContraseña.KeyDown += TextBox_KeyDown; // Nombre con Ñ
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // ¡Verifica el nombre BtnIniciar!
                BtnIniciar.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

    } // Fin clase FrmIncioDeSesion
}