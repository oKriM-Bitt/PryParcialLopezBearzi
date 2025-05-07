using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; // Para validación
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryPueblox
{
    public partial class FrmPerfil : Form
    {
        // --- Instancias DAL ---
        private ClsUsuarioCRUD usuarioDal = new ClsUsuarioCRUD();
        private RolUsuarioDAL rolUsuarioDal = new RolUsuarioDAL();

        private int usuarioIdActual;

        // --- Constructor ---
        public FrmPerfil()
        {
            InitializeComponent();
            if (!SesionUsuario.IsUserLoggedIn) { MessageBox.Show("Debe iniciar sesión."); this.BeginInvoke(new MethodInvoker(this.Close)); return; }
            this.usuarioIdActual = SesionUsuario.IdUsuarioLogueado;
            // --- Añadido Evento KeyPress para Teléfono ---
            TxtTelefono.KeyPress += TxtTelefono_KeyPress; // Asocia el validador
        }

        // --- Carga Inicial ---
        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            if (this.usuarioIdActual <= 0) return;
            CargarComboRolesPerfil();
            CargarDatosUsuario();
        }

        // --- Cargar Datos del Usuario ---
        private void CargarDatosUsuario()
        {
            try
            {
                DataRow infoUsuario = usuarioDal.GetUsuarioPorId(this.usuarioIdActual);
                if (infoUsuario != null)
                {
                    TxtNombre.Text = infoUsuario["Nombre"].ToString();
                    TxtApellido.Text = infoUsuario["Apellido"].ToString();
                    TxtCorreo.Text = infoUsuario["Correo"].ToString();
                    // --- Añadido: Cargar Teléfono ---
                    object telefonoObj = infoUsuario["Telefono"];
                    TxtTelefono.Text = (telefonoObj != DBNull.Value) ? telefonoObj.ToString() : "";
                    TxtTelefono.Enabled = true; // Habilitarlo
                    // --- Fin Añadido ---
                    TxtNombUsuario.Text = infoUsuario["Nombre de Usuario"].ToString();
                    TxtNombUsuario.ReadOnly = true; TxtNombUsuario.BackColor = SystemColors.Info;
                    TxtContraseña.Clear(); // No mostrar contraseña
                    if (CmbCategoria.Items.Count > 0 && infoUsuario["IdCategoriaU"] != DBNull.Value) { CmbCategoria.SelectedValue = Convert.ToInt32(infoUsuario["IdCategoriaU"]); } else { CmbCategoria.SelectedIndex = -1; }
                }
                else { MessageBox.Show("No se cargaron datos."); this.Close(); }
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar perfil:\n{ex.Message}"); this.Close(); }
        }

        // --- Cargar Roles ---
        private void CargarComboRolesPerfil() { try { rolUsuarioDal.CargarRolesUsuarioDirectoEnCombo(CmbCategoria); } catch { /* DAL ya muestra error */ } }

        // --- Botón Modificar (UPDATE) ---
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposModificacion()) return; // Incluir Telefono en validación si es necesario

            string nombre = TxtNombre.Text.Trim();
            string apellido = TxtApellido.Text.Trim();
            string correo = TxtCorreo.Text.Trim();
            string telefono = TxtTelefono.Text.Trim(); // <-- Obtener Teléfono
            string nuevaContraPlana = TxtContraseña.Text; // Nombre con Ñ
            int nuevoRolId = (CmbCategoria.SelectedValue != null && CmbCategoria.SelectedIndex > -1) ? Convert.ToInt32(CmbCategoria.SelectedValue) : 0;
            if (nuevoRolId <= 0) { MessageBox.Show("Seleccione un rol."); CmbCategoria.Focus(); return; }

            DialogResult dr = MessageBox.Show("¿Guardar cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            try
            {
                // --- MODIFICADO: Añadido 'telefono' ---
                bool actualizado = usuarioDal.ActualizarUsuarioCompleto(
                                        this.usuarioIdActual, nombre, apellido, correo, telefono, // <-- Pasar teléfono
                                        nuevaContraPlana, nuevoRolId
                                        );

                if (actualizado) { MessageBox.Show("Perfil actualizado."); SesionUsuario.IniciarSesion(this.usuarioIdActual, TxtNombUsuario.Text, nombre, apellido, correo, nuevoRolId); this.Close(); }
                else { MessageBox.Show("No se pudo actualizar."); }
            }
            catch (Exception ex) { MessageBox.Show($"Error al guardar:\n{ex.Message}"); }
        }

        // --- Botón Eliminar (DELETE) ---
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿ELIMINAR CUENTA?\n\n¡ACCIÓN PERMANENTE!", "¡¡¡CONFIRMAR!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes) { try { bool eliminado = usuarioDal.EliminarUsuario(this.usuarioIdActual); if (eliminado) { MessageBox.Show("Cuenta eliminada."); SesionUsuario.CerrarSesion(); CerrarAplicacionYMostrarLogin(); } else { MessageBox.Show("No se pudo eliminar."); } } catch (Exception ex) { MessageBox.Show($"Error al eliminar:\n{ex.Message}"); } }
        }

        // --- Cerrar App y Mostrar Login ---
        private void CerrarAplicacionYMostrarLogin() { Form frmInicio = Application.OpenForms.OfType<FrmInicio>().FirstOrDefault(); FrmIncioDeSesion frmLogin = new FrmIncioDeSesion(); if (frmInicio != null && !frmInicio.IsDisposed) { frmInicio.BeginInvoke(new MethodInvoker(frmInicio.Close)); } this.BeginInvoke(new MethodInvoker(this.Close)); if (Application.OpenForms.Count > 0) { Application.OpenForms[0].BeginInvoke(new MethodInvoker(() => { if (!frmLogin.IsDisposed) frmLogin.Show(); })); } else { if (!frmLogin.IsDisposed) frmLogin.Show(); } }

        // --- Validación para Modificación ---
        private bool ValidarCamposModificacion()
        {
            TxtNombre.BackColor = SystemColors.Window; TxtApellido.BackColor = SystemColors.Window; TxtCorreo.BackColor = SystemColors.Window; TxtTelefono.BackColor = SystemColors.Window; TxtContraseña.BackColor = SystemColors.Window; CmbCategoria.BackColor = SystemColors.Window;
            bool valido = true; Control primerError = null;
            if (string.IsNullOrWhiteSpace(TxtNombre.Text)) { valido = false; TxtNombre.BackColor = Color.LightCoral; if (primerError == null) primerError = TxtNombre; }
            if (string.IsNullOrWhiteSpace(TxtApellido.Text)) { valido = false; TxtApellido.BackColor = Color.LightCoral; if (primerError == null) primerError = TxtApellido; }
            if (!EsCorreoValido(TxtCorreo.Text)) { valido = false; TxtCorreo.BackColor = Color.LightCoral; if (primerError == null) primerError = TxtCorreo; }
            // Teléfono opcional, no validar si está vacío
            // if (string.IsNullOrWhiteSpace(TxtTelefono.Text)) { valido = false; TxtTelefono.BackColor = Color.LightCoral; if(primerError == null) primerError = TxtTelefono; }
            if (CmbCategoria.SelectedIndex == -1) { valido = false; CmbCategoria.BackColor = Color.LightCoral; if (primerError == null) primerError = CmbCategoria; }
            if (!string.IsNullOrEmpty(TxtContraseña.Text) && TxtContraseña.Text.Length < 3) { valido = false; TxtContraseña.BackColor = Color.LightCoral; if (primerError == null) primerError = TxtContraseña; MessageBox.Show("Contraseña nueva muy corta (mín 3) o dejar vacío.", "Contraseña Inválida"); return false; }
            if (!valido) { MessageBox.Show("Corrija los campos marcados.", "Datos Inválidos"); primerError?.Focus(); }
            return valido;
        }
        private bool EsCorreoValido(string email) { try { return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)); } catch { return false; } }

        // --- NUEVO: Validador KeyPress para Teléfono ---
        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite números, símbolos + - ( ) espacio, y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '(' &&
                e.KeyChar != ')' && e.KeyChar != ' ')
            {
                e.Handled = true; // Ignora el carácter
            }
        }

        // --- Eventos vacíos ---
        private void TxtNombre_TextChanged(object sender, EventArgs e) { }
        private void TxtNombUsuario_TextChanged(object sender, EventArgs e) { }
        private void TxtApellido_TextChanged(object sender, EventArgs e) { }
        private void TxtContraseña_TextChanged(object sender, EventArgs e) { } // Nombre con Ñ
        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e) { }
        private void TxtTelefono_TextChanged(object sender, EventArgs e) { }
        private void TxtCorreo_TextChanged(object sender, EventArgs e) { }

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

    }
}