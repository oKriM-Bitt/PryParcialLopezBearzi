namespace PuebloGrill
{
    partial class FrmInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnPerfil = new System.Windows.Forms.Button();
            this.BtnInfo = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnLibro = new System.Windows.Forms.Button();
            this.BtnAbrir = new System.Windows.Forms.Button();
            this.BtnVer = new System.Windows.Forms.Button();
            this.BtnCargarProducto = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(195)))), ((int)(((byte)(155)))));
            this.panel1.Controls.Add(this.BtnPerfil);
            this.panel1.Controls.Add(this.BtnInfo);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.BtnLibro);
            this.panel1.Controls.Add(this.BtnAbrir);
            this.panel1.Controls.Add(this.BtnVer);
            this.panel1.Controls.Add(this.BtnCargarProducto);
            this.panel1.Location = new System.Drawing.Point(-5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 1043);
            this.panel1.TabIndex = 26;
            // 
            // BtnPerfil
            // 
            this.BtnPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(137)))), ((int)(((byte)(73)))));
            this.BtnPerfil.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPerfil.Location = new System.Drawing.Point(7, 325);
            this.BtnPerfil.Name = "BtnPerfil";
            this.BtnPerfil.Size = new System.Drawing.Size(223, 62);
            this.BtnPerfil.TabIndex = 6;
            this.BtnPerfil.Text = "Perfil";
            this.BtnPerfil.UseVisualStyleBackColor = false;
            this.BtnPerfil.Click += new System.EventHandler(this.BtnPerfil_Click);
            // 
            // BtnInfo
            // 
            this.BtnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(137)))), ((int)(((byte)(73)))));
            this.BtnInfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnInfo.Location = new System.Drawing.Point(7, 393);
            this.BtnInfo.Name = "BtnInfo";
            this.BtnInfo.Size = new System.Drawing.Size(223, 62);
            this.BtnInfo.TabIndex = 5;
            this.BtnInfo.Text = "Informacion del Programador";
            this.BtnInfo.UseVisualStyleBackColor = false;
            this.BtnInfo.Click += new System.EventHandler(this.BtnInfo_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(137)))), ((int)(((byte)(73)))));
            this.BtnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.Location = new System.Drawing.Point(7, 461);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(223, 62);
            this.BtnSalir.TabIndex = 4;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnLibro
            // 
            this.BtnLibro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(137)))), ((int)(((byte)(73)))));
            this.BtnLibro.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnLibro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLibro.Location = new System.Drawing.Point(7, 257);
            this.BtnLibro.Name = "BtnLibro";
            this.BtnLibro.Size = new System.Drawing.Size(223, 62);
            this.BtnLibro.TabIndex = 3;
            this.BtnLibro.Text = "Generar Libro Diario ";
            this.BtnLibro.UseVisualStyleBackColor = false;
            this.BtnLibro.Click += new System.EventHandler(this.BtnLibro_Click);
            // 
            // BtnAbrir
            // 
            this.BtnAbrir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(137)))), ((int)(((byte)(73)))));
            this.BtnAbrir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAbrir.Location = new System.Drawing.Point(7, 189);
            this.BtnAbrir.Name = "BtnAbrir";
            this.BtnAbrir.Size = new System.Drawing.Size(223, 62);
            this.BtnAbrir.TabIndex = 2;
            this.BtnAbrir.Text = "Abrir Mesa";
            this.BtnAbrir.UseVisualStyleBackColor = false;
            this.BtnAbrir.Click += new System.EventHandler(this.BtnAbrir_Click);
            // 
            // BtnVer
            // 
            this.BtnVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(137)))), ((int)(((byte)(73)))));
            this.BtnVer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnVer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnVer.Location = new System.Drawing.Point(7, 121);
            this.BtnVer.Name = "BtnVer";
            this.BtnVer.Size = new System.Drawing.Size(223, 62);
            this.BtnVer.TabIndex = 1;
            this.BtnVer.Text = "Mostrar Productos y Controlar Stock";
            this.BtnVer.UseVisualStyleBackColor = false;
            this.BtnVer.Click += new System.EventHandler(this.BtnVer_Click);
            // 
            // BtnCargarProducto
            // 
            this.BtnCargarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(137)))), ((int)(((byte)(73)))));
            this.BtnCargarProducto.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnCargarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCargarProducto.Location = new System.Drawing.Point(7, 53);
            this.BtnCargarProducto.Name = "BtnCargarProducto";
            this.BtnCargarProducto.Size = new System.Drawing.Size(223, 62);
            this.BtnCargarProducto.TabIndex = 0;
            this.BtnCargarProducto.Text = "Cargar  Producto";
            this.BtnCargarProducto.UseVisualStyleBackColor = false;
            this.BtnCargarProducto.Click += new System.EventHandler(this.BtnCargarProducto_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PuebloGrill.Properties.Resources.f861b851_0d67_4392_bb42_a3bf670a6ecf;
            this.pictureBox1.Location = new System.Drawing.Point(198, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1165, 765);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnLibro;
        private System.Windows.Forms.Button BtnAbrir;
        private System.Windows.Forms.Button BtnVer;
        private System.Windows.Forms.Button BtnCargarProducto;
        private System.Windows.Forms.Button BtnPerfil;
        private System.Windows.Forms.Button BtnInfo;
    }
}

