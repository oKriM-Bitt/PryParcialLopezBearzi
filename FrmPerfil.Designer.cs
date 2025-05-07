namespace PryPueblox
{
    partial class FrmPerfil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPerfil));
            this.label1 = new System.Windows.Forms.Label();
            this.TxtContraseña = new System.Windows.Forms.TextBox();
            this.TxtNombUsuario = new System.Windows.Forms.TextBox();
            this.LblNoU = new System.Windows.Forms.Label();
            this.CmbCategoria = new System.Windows.Forms.ComboBox();
            this.TxtCorreo = new System.Windows.Forms.TextBox();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtApellido = new System.Windows.Forms.TextBox();
            this.LblCa = new System.Windows.Forms.Label();
            this.LblCo = new System.Windows.Forms.Label();
            this.LblTele = new System.Windows.Forms.Label();
            this.LblApellido = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.GBT = new System.Windows.Forms.GroupBox();
            this.BtnVolver = new System.Windows.Forms.Button();
            this.GBT.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(30, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 39;
            this.label1.Text = "Contraseña";
            // 
            // TxtContraseña
            // 
            this.TxtContraseña.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.TxtContraseña.Location = new System.Drawing.Point(180, 295);
            this.TxtContraseña.Name = "TxtContraseña";
            this.TxtContraseña.Size = new System.Drawing.Size(312, 32);
            this.TxtContraseña.TabIndex = 38;
            this.TxtContraseña.TextChanged += new System.EventHandler(this.TxtContraseña_TextChanged);
            // 
            // TxtNombUsuario
            // 
            this.TxtNombUsuario.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.TxtNombUsuario.Location = new System.Drawing.Point(180, 241);
            this.TxtNombUsuario.Name = "TxtNombUsuario";
            this.TxtNombUsuario.Size = new System.Drawing.Size(312, 32);
            this.TxtNombUsuario.TabIndex = 37;
            this.TxtNombUsuario.TextChanged += new System.EventHandler(this.TxtNombUsuario_TextChanged);
            // 
            // LblNoU
            // 
            this.LblNoU.AutoSize = true;
            this.LblNoU.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.LblNoU.Location = new System.Drawing.Point(30, 211);
            this.LblNoU.Name = "LblNoU";
            this.LblNoU.Size = new System.Drawing.Size(101, 75);
            this.LblNoU.TabIndex = 36;
            this.LblNoU.Text = "Nombre \r\n    de \r\nUsuario";
            // 
            // CmbCategoria
            // 
            this.CmbCategoria.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.CmbCategoria.FormattingEnabled = true;
            this.CmbCategoria.Location = new System.Drawing.Point(180, 173);
            this.CmbCategoria.Name = "CmbCategoria";
            this.CmbCategoria.Size = new System.Drawing.Size(312, 33);
            this.CmbCategoria.TabIndex = 35;
            this.CmbCategoria.SelectedIndexChanged += new System.EventHandler(this.CmbCategoria_SelectedIndexChanged);
            // 
            // TxtCorreo
            // 
            this.TxtCorreo.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.TxtCorreo.Location = new System.Drawing.Point(180, 141);
            this.TxtCorreo.Name = "TxtCorreo";
            this.TxtCorreo.Size = new System.Drawing.Size(312, 32);
            this.TxtCorreo.TabIndex = 34;
            this.TxtCorreo.TextChanged += new System.EventHandler(this.TxtCorreo_TextChanged);
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.TxtTelefono.Location = new System.Drawing.Point(180, 108);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(312, 32);
            this.TxtTelefono.TabIndex = 33;
            this.TxtTelefono.TextChanged += new System.EventHandler(this.TxtTelefono_TextChanged);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.TxtNombre.Location = new System.Drawing.Point(180, 38);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(312, 32);
            this.TxtNombre.TabIndex = 31;
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            // 
            // TxtApellido
            // 
            this.TxtApellido.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.TxtApellido.Location = new System.Drawing.Point(180, 72);
            this.TxtApellido.Name = "TxtApellido";
            this.TxtApellido.Size = new System.Drawing.Size(312, 32);
            this.TxtApellido.TabIndex = 32;
            this.TxtApellido.TextChanged += new System.EventHandler(this.TxtApellido_TextChanged);
            // 
            // LblCa
            // 
            this.LblCa.AutoSize = true;
            this.LblCa.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.LblCa.Location = new System.Drawing.Point(30, 176);
            this.LblCa.Name = "LblCa";
            this.LblCa.Size = new System.Drawing.Size(112, 25);
            this.LblCa.TabIndex = 30;
            this.LblCa.Text = "Categoria";
            // 
            // LblCo
            // 
            this.LblCo.AutoSize = true;
            this.LblCo.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.LblCo.Location = new System.Drawing.Point(30, 144);
            this.LblCo.Name = "LblCo";
            this.LblCo.Size = new System.Drawing.Size(82, 25);
            this.LblCo.TabIndex = 29;
            this.LblCo.Text = "Correo";
            // 
            // LblTele
            // 
            this.LblTele.AutoSize = true;
            this.LblTele.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.LblTele.Location = new System.Drawing.Point(30, 108);
            this.LblTele.Name = "LblTele";
            this.LblTele.Size = new System.Drawing.Size(101, 25);
            this.LblTele.TabIndex = 28;
            this.LblTele.Text = "Teléfono";
            // 
            // LblApellido
            // 
            this.LblApellido.AutoSize = true;
            this.LblApellido.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.LblApellido.Location = new System.Drawing.Point(30, 75);
            this.LblApellido.Name = "LblApellido";
            this.LblApellido.Size = new System.Drawing.Size(98, 25);
            this.LblApellido.TabIndex = 27;
            this.LblApellido.Text = "Apellido";
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.LblNombre.Location = new System.Drawing.Point(30, 41);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(96, 25);
            this.LblNombre.TabIndex = 26;
            this.LblNombre.Text = "Nombre";
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificar.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.Location = new System.Drawing.Point(529, 99);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(132, 53);
            this.BtnModificar.TabIndex = 50;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.Location = new System.Drawing.Point(667, 99);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(132, 53);
            this.BtnEliminar.TabIndex = 49;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // GBT
            // 
            this.GBT.Controls.Add(this.LblNombre);
            this.GBT.Controls.Add(this.BtnModificar);
            this.GBT.Controls.Add(this.LblApellido);
            this.GBT.Controls.Add(this.BtnEliminar);
            this.GBT.Controls.Add(this.LblTele);
            this.GBT.Controls.Add(this.label1);
            this.GBT.Controls.Add(this.LblCo);
            this.GBT.Controls.Add(this.TxtContraseña);
            this.GBT.Controls.Add(this.LblCa);
            this.GBT.Controls.Add(this.TxtNombUsuario);
            this.GBT.Controls.Add(this.TxtApellido);
            this.GBT.Controls.Add(this.LblNoU);
            this.GBT.Controls.Add(this.TxtNombre);
            this.GBT.Controls.Add(this.CmbCategoria);
            this.GBT.Controls.Add(this.TxtTelefono);
            this.GBT.Controls.Add(this.TxtCorreo);
            this.GBT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GBT.Location = new System.Drawing.Point(12, 12);
            this.GBT.Name = "GBT";
            this.GBT.Size = new System.Drawing.Size(838, 415);
            this.GBT.TabIndex = 51;
            this.GBT.TabStop = false;
            this.GBT.Text = "Perfil";
            // 
            // BtnVolver
            // 
            this.BtnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVolver.Location = new System.Drawing.Point(12, 451);
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(132, 53);
            this.BtnVolver.TabIndex = 51;
            this.BtnVolver.Text = "Volver";
            this.BtnVolver.UseVisualStyleBackColor = false;
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // FrmPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.BtnVolver);
            this.Controls.Add(this.GBT);
            this.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmPerfil";
            this.Text = "Iniciar Sesion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPerfil_Load);
            this.GBT.ResumeLayout(false);
            this.GBT.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtContraseña;
        private System.Windows.Forms.TextBox TxtNombUsuario;
        private System.Windows.Forms.Label LblNoU;
        private System.Windows.Forms.ComboBox CmbCategoria;
        private System.Windows.Forms.TextBox TxtCorreo;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtApellido;
        private System.Windows.Forms.Label LblCa;
        private System.Windows.Forms.Label LblCo;
        private System.Windows.Forms.Label LblTele;
        private System.Windows.Forms.Label LblApellido;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.GroupBox GBT;
        private System.Windows.Forms.Button BtnVolver;
    }
}