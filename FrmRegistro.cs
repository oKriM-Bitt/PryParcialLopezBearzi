using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; // Para validación de correo
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryPueblox
{
    public partial class FrmRegistro : Form
    {
        // --- Instancias DAL ---
        private ClsUsuarioCRUD usuarioDal = new ClsUsuarioCRUD();
        private RolUsuarioDAL rolUsuarioDal = new RolUsuarioDAL();

        // --- Constructor ---
        public FrmRegistro()
        {
            InitializeComponent();
            // Configuramos todos los eventos necesarios al iniciar
            SetupValidationEvents();
        }

        // --- Evento Load del Formulario ---
        private void FrmRegistro_Load_1(object sender, EventArgs e) // Nombre estándar del evento Load
        {
            Console.WriteLine("Cargando FrmRegistro...");
            CargarComboRoles(); // Cargar roles al iniciar
            TxtNombre.Focus();  // Poner foco en el primer campo
            LimpiarColoresValidacion(); // Empezar con colores limpios
        }

        // --- Cargar Datos ---
        private void CargarComboRoles()
        {
            try
            {
                rolUsuarioDal.CargarRolesUsuarioDirectoEnCombo(CmbCategoria);
                if (CmbCategoria.Items.Count == 0 && CmbCategoria.DataSource == null)
                { Console.WriteLine($"Advertencia: ComboBox '{CmbCategoria.Name}' vacío."); }
                else { Console.WriteLine($"ComboBox '{CmbCategoria.Name}' cargado."); }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar roles:\n" + ex.Message); }
        }

        // --- Configuración de Eventos de UI ---
        private void SetupValidationEvents()
        {
            // Eventos Leave para cambiar color al salir del control
            TxtNombre.Leave += Control_Leave;
            TxtApellido.Leave += Control_Leave;
            TxtTelefono.Leave += Control_Leave; // <-- Añadido Telefono
            TxtCorreo.Leave += Control_Leave;
            CmbCategoria.Leave += Control_Leave;
            TxtNombUsuario.Leave += Control_Leave;
            TxtContraseña.Leave += Control_Leave;

            // Eventos KeyDown para usar Enter para navegar/aceptar
            TxtNombre.KeyDown += Control_KeyDown;
            TxtApellido.KeyDown += Control_KeyDown;
            TxtTelefono.KeyDown += Control_KeyDown; // <-- Añadido Telefono
            TxtCorreo.KeyDown += Control_KeyDown;
            // CmbCategoria no necesita KeyDown usualmente
            TxtNombUsuario.KeyDown += Control_KeyDown;
            TxtContraseña.KeyDown += Control_KeyDown; // Último control, llama a Agregar

            // --- Añadido Evento KeyPress para validación de Teléfono ---
            TxtTelefono.KeyPress += TxtTelefono_KeyPress;
        }

        // --- Manejadores de Eventos de UI ---
        private void Control_Leave(object sender, EventArgs e)
        {
            Control ctrl = sender as Control; if (ctrl == null) return;
            bool valido = EsControlValido(ctrl); // Revisa si el control es válido
            if (ctrl is ComboBox && (ctrl as ComboBox).SelectedIndex == -1) { ctrl.BackColor = SystemColors.Window; }
            else if (ctrl == TxtTelefono && string.IsNullOrWhiteSpace(ctrl.Text)) { ctrl.BackColor = SystemColors.Window; } // Teléfono opcional, no marcar rojo si vacío
            else if (valido) { ctrl.BackColor = Color.LightGreen; } // Válido = Verde
            else { ctrl.BackColor = Color.LightCoral; } // Inválido = Rojo (excepto Teléfono vacío)
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar sonido "ding"
                if (sender == TxtContraseña) { BtnAgregar.PerformClick(); } // Enter en contraseña = clic en Agregar
                else { this.SelectNextControl((Control)sender, true, true, true, true); } // Enter en otros = ir al siguiente control
            }
        }

        // --- NUEVO: Validador KeyPress para Teléfono ---
        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite números, símbolos + - ( ) espacio, y teclas de control (Borrar, etc.)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '(' &&
                e.KeyChar != ')' && e.KeyChar != ' ')
            {
                e.Handled = true; // Ignora el carácter no permitido
            }
        }

        // --- Lógica de Validación ---
        private void LimpiarColoresValidacion()
        {
            TxtNombre.BackColor = SystemColors.Window;
            TxtApellido.BackColor = SystemColors.Window;
            TxtTelefono.BackColor = SystemColors.Window; // <-- Añadido Telefono
            TxtCorreo.BackColor = SystemColors.Window;
            CmbCategoria.BackColor = SystemColors.Window;
            TxtNombUsuario.BackColor = SystemColors.Window;
            TxtContraseña.BackColor = SystemColors.Window;
        }

        private bool EsControlValido(Control ctrl)
        {
            if (ctrl == TxtNombre) return !string.IsNullOrWhiteSpace(ctrl.Text);
            if (ctrl == TxtApellido) return !string.IsNullOrWhiteSpace(ctrl.Text);
            if (ctrl == TxtTelefono) return true; // --- Teléfono es Opcional --- (Si quieres que sea obligatorio, cambia a: !string.IsNullOrWhiteSpace(ctrl.Text))
            if (ctrl == TxtCorreo) return EsCorreoValido(ctrl.Text);
            if (ctrl == CmbCategoria) return (ctrl as ComboBox).SelectedIndex > -1;
            if (ctrl == TxtNombUsuario) return !string.IsNullOrWhiteSpace(ctrl.Text);
            if (ctrl == TxtContraseña) return !string.IsNullOrWhiteSpace(ctrl.Text); // Considera validar longitud mínima
            return true; // Otros controles se asumen válidos
        }

        private bool ValidarFormularioCompleto(out Control primerControlInvalido)
        {
            primerControlInvalido = null;
            bool todoValido = true;
            LimpiarColoresValidacion();
            // --- Añadido TxtTelefono a la lista ---
            Control[] controlesAValidar = {
                TxtNombre, TxtApellido, TxtTelefono, TxtCorreo, CmbCategoria, TxtNombUsuario, TxtContraseña
            };
            foreach (Control ctrl in controlesAValidar)
            {
                bool valido = EsControlValido(ctrl);
                if (!valido)
                {
                    // Marcar rojo solo si es inválido (no si es Teléfono opcional vacío)
                    if (!(ctrl == TxtTelefono && string.IsNullOrWhiteSpace(ctrl.Text)))
                    {
                        ctrl.BackColor = Color.LightCoral;
                        if (primerControlInvalido == null) primerControlInvalido = ctrl;
                        todoValido = false;
                    }
                }
                else
                { // Si es válido o es teléfono vacío
                    if (!(ctrl is ComboBox && (ctrl as ComboBox).SelectedIndex == -1))
                    { // No marcar verde ComboBox vacío
                        ctrl.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        ctrl.BackColor = SystemColors.Window;
                    }
                }
            }
            if (!todoValido) MessageBox.Show("Corrija los campos marcados en rojo.", "Datos Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return todoValido;
        }

        private bool EsCorreoValido(string email) { try { return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)); } catch { return false; } }

        // --- Acción Principal: Botón Agregar ---
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Control primerError;
            if (!ValidarFormularioCompleto(out primerError)) { primerError?.Focus(); return; }

            // --- Obtener datos ---
            string nombre = TxtNombre.Text.Trim();
            string apellido = TxtApellido.Text.Trim();
            string correo = TxtCorreo.Text.Trim();
            string telefono = TxtTelefono.Text.Trim(); // <-- Obtener Teléfono
            int idCategoriaU = Convert.ToInt32(CmbCategoria.SelectedValue);
            string nombreUsuario = TxtNombUsuario.Text.Trim();
            string contraseñaPlana = TxtContraseña.Text; // Nombre con Ñ

            // Verificar si usuario existe...
            try { if (usuarioDal.UsuarioExiste(nombreUsuario)) { MessageBox.Show($"Usuario '{nombreUsuario}' ya existe."); TxtNombUsuario.Focus(); return; } } catch (Exception exDbCheck) { MessageBox.Show("Error al verificar usuario:\n" + exDbCheck.Message); return; }

            // Hashear contraseña...
            string contraseñaHasheada = usuarioDal.HashPassword(contraseñaPlana);

            // Intentar registrar (Pasando también el teléfono)...
            try
            {
                // --- Llamada al método MODIFICADO de UsuarioDAL ---
                bool registroExitoso = usuarioDal.RegistrarUsuario(
                    nombre, apellido, correo, idCategoriaU,
                    nombreUsuario, contraseñaHasheada, telefono // <-- Pasamos teléfono
                );

                if (registroExitoso) { MessageBox.Show("¡Usuario registrado!"); LimpiarFormulario(); }
                else { MessageBox.Show("No se pudo registrar el usuario."); }
            }
            catch (Exception exDbRegister) { MessageBox.Show("Error al registrar en BD:\n" + exDbRegister.Message); }
        }

        // --- Métodos Auxiliares ---
        private void LimpiarFormulario()
        {
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtTelefono.Clear(); // <-- Añadido Telefono
            TxtCorreo.Clear();
            CmbCategoria.SelectedIndex = -1;
            TxtNombUsuario.Clear();
            TxtContraseña.Clear(); // Nombre con Ñ
            LimpiarColoresValidacion();
            TxtNombre.Focus();
        }

        // --- Botón para ir a Iniciar Sesión (Limpiado) ---
        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Botón Iniciar Sesión (desde Registro) presionado."); // Mensaje para depurar

          FrmIncioDeSesion f = new FrmIncioDeSesion();
            f.Show();
            this.Hide();
        }

    } // Fin Clase FrmRegistro
} // Fin Namespace