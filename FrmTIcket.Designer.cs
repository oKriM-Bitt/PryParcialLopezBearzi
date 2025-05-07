namespace PryPueblox
{
    partial class FrmTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTicket));
            this.BtnQuitar = new System.Windows.Forms.Button();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.BtnVolver = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.NumCantidad = new System.Windows.Forms.NumericUpDown();
            this.CmbMenu = new System.Windows.Forms.ComboBox();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.LblMesa = new System.Windows.Forms.Label();
            this.LblCant = new System.Windows.Forms.Label();
            this.Npersonas = new System.Windows.Forms.NumericUpDown();
            this.GbPa = new System.Windows.Forms.GroupBox();
            this.RdtDebito = new System.Windows.Forms.RadioButton();
            this.RdtTransfe = new System.Windows.Forms.RadioButton();
            this.RdtEfectivo = new System.Windows.Forms.RadioButton();
            this.BtnEspera = new System.Windows.Forms.Button();
            this.GrlMListar = new System.Windows.Forms.DataGridView();
            this.LblTotal = new System.Windows.Forms.Label();
            this.LblM = new System.Windows.Forms.Label();
            this.CmbMostrarSegun = new System.Windows.Forms.ComboBox();
            this.LblMos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Npersonas)).BeginInit();
            this.GbPa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrlMListar)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnQuitar
            // 
            this.BtnQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuitar.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuitar.Location = new System.Drawing.Point(665, 199);
            this.BtnQuitar.Margin = new System.Windows.Forms.Padding(6);
            this.BtnQuitar.Name = "BtnQuitar";
            this.BtnQuitar.Size = new System.Drawing.Size(160, 50);
            this.BtnQuitar.TabIndex = 198;
            this.BtnQuitar.Text = "Quitar";
            this.BtnQuitar.UseVisualStyleBackColor = false;
            this.BtnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click_1);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImprimir.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimir.Location = new System.Drawing.Point(978, 449);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(257, 50);
            this.BtnImprimir.TabIndex = 193;
            this.BtnImprimir.Text = "Imprimir y Cerrar";
            this.BtnImprimir.UseVisualStyleBackColor = false;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // BtnVolver
            // 
            this.BtnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVolver.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVolver.Location = new System.Drawing.Point(9, 631);
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(257, 50);
            this.BtnVolver.TabIndex = 192;
            this.BtnVolver.Text = "Volver al Menu";
            this.BtnVolver.UseVisualStyleBackColor = false;
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(467, 200);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(6);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(148, 49);
            this.BtnAgregar.TabIndex = 191;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click_1);
            // 
            // NumCantidad
            // 
            this.NumCantidad.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.NumCantidad.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumCantidad.Location = new System.Drawing.Point(913, 146);
            this.NumCantidad.Margin = new System.Windows.Forms.Padding(6);
            this.NumCantidad.Name = "NumCantidad";
            this.NumCantidad.Size = new System.Drawing.Size(59, 30);
            this.NumCantidad.TabIndex = 190;
            // 
            // CmbMenu
            // 
            this.CmbMenu.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMenu.FormattingEnabled = true;
            this.CmbMenu.Location = new System.Drawing.Point(467, 145);
            this.CmbMenu.Margin = new System.Windows.Forms.Padding(6);
            this.CmbMenu.Name = "CmbMenu";
            this.CmbMenu.Size = new System.Drawing.Size(423, 31);
            this.CmbMenu.TabIndex = 189;
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.LblCantidad.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCantidad.Location = new System.Drawing.Point(463, 109);
            this.LblCantidad.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(287, 19);
            this.LblCantidad.TabIndex = 188;
            this.LblCantidad.Text = "Cantidad de Productos consumidos";
            // 
            // LblMesa
            // 
            this.LblMesa.AutoSize = true;
            this.LblMesa.Font = new System.Drawing.Font("Rockwell", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMesa.Location = new System.Drawing.Point(82, 5);
            this.LblMesa.Name = "LblMesa";
            this.LblMesa.Size = new System.Drawing.Size(0, 36);
            this.LblMesa.TabIndex = 265;
            // 
            // LblCant
            // 
            this.LblCant.AutoSize = true;
            this.LblCant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.LblCant.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCant.Location = new System.Drawing.Point(15, 56);
            this.LblCant.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblCant.Name = "LblCant";
            this.LblCant.Size = new System.Drawing.Size(186, 19);
            this.LblCant.TabIndex = 266;
            this.LblCant.Text = "Cantidad de Personas:";
            // 
            // Npersonas
            // 
            this.Npersonas.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.Npersonas.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Npersonas.Location = new System.Drawing.Point(207, 51);
            this.Npersonas.Margin = new System.Windows.Forms.Padding(6);
            this.Npersonas.Name = "Npersonas";
            this.Npersonas.Size = new System.Drawing.Size(59, 30);
            this.Npersonas.TabIndex = 267;
            // 
            // GbPa
            // 
            this.GbPa.Controls.Add(this.RdtDebito);
            this.GbPa.Controls.Add(this.RdtTransfe);
            this.GbPa.Controls.Add(this.RdtEfectivo);
            this.GbPa.Location = new System.Drawing.Point(988, 199);
            this.GbPa.Name = "GbPa";
            this.GbPa.Size = new System.Drawing.Size(215, 152);
            this.GbPa.TabIndex = 268;
            this.GbPa.TabStop = false;
            this.GbPa.Text = "Paga con";
            // 
            // RdtDebito
            // 
            this.RdtDebito.AutoSize = true;
            this.RdtDebito.Location = new System.Drawing.Point(18, 110);
            this.RdtDebito.Name = "RdtDebito";
            this.RdtDebito.Size = new System.Drawing.Size(92, 27);
            this.RdtDebito.TabIndex = 109;
            this.RdtDebito.TabStop = true;
            this.RdtDebito.Text = "Debito";
            this.RdtDebito.UseVisualStyleBackColor = true;
            // 
            // RdtTransfe
            // 
            this.RdtTransfe.AutoSize = true;
            this.RdtTransfe.Location = new System.Drawing.Point(18, 44);
            this.RdtTransfe.Name = "RdtTransfe";
            this.RdtTransfe.Size = new System.Drawing.Size(173, 27);
            this.RdtTransfe.TabIndex = 108;
            this.RdtTransfe.TabStop = true;
            this.RdtTransfe.Text = "Transeferencia";
            this.RdtTransfe.UseVisualStyleBackColor = true;
            // 
            // RdtEfectivo
            // 
            this.RdtEfectivo.AutoSize = true;
            this.RdtEfectivo.Location = new System.Drawing.Point(18, 77);
            this.RdtEfectivo.Name = "RdtEfectivo";
            this.RdtEfectivo.Size = new System.Drawing.Size(105, 27);
            this.RdtEfectivo.TabIndex = 107;
            this.RdtEfectivo.TabStop = true;
            this.RdtEfectivo.Text = "Efectivo";
            this.RdtEfectivo.UseVisualStyleBackColor = true;
            // 
            // BtnEspera
            // 
            this.BtnEspera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnEspera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEspera.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEspera.Location = new System.Drawing.Point(978, 374);
            this.BtnEspera.Name = "BtnEspera";
            this.BtnEspera.Size = new System.Drawing.Size(257, 50);
            this.BtnEspera.TabIndex = 272;
            this.BtnEspera.Text = "Colocar en Espera";
            this.BtnEspera.UseVisualStyleBackColor = false;
            this.BtnEspera.Click += new System.EventHandler(this.BtnEspera_Click);
            // 
            // GrlMListar
            // 
            this.GrlMListar.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GrlMListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrlMListar.Location = new System.Drawing.Point(19, 274);
            this.GrlMListar.Name = "GrlMListar";
            this.GrlMListar.Size = new System.Drawing.Size(953, 327);
            this.GrlMListar.TabIndex = 273;
            // 
            // LblTotal
            // 
            this.LblTotal.BackColor = System.Drawing.Color.White;
            this.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LblTotal.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.Location = new System.Drawing.Point(697, 631);
            this.LblTotal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(275, 41);
            this.LblTotal.TabIndex = 274;
            // 
            // LblM
            // 
            this.LblM.AutoSize = true;
            this.LblM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.LblM.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblM.Location = new System.Drawing.Point(15, 18);
            this.LblM.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblM.Name = "LblM";
            this.LblM.Size = new System.Drawing.Size(58, 19);
            this.LblM.TabIndex = 275;
            this.LblM.Text = "Mesa:";
            // 
            // CmbMostrarSegun
            // 
            this.CmbMostrarSegun.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMostrarSegun.FormattingEnabled = true;
            this.CmbMostrarSegun.Location = new System.Drawing.Point(15, 145);
            this.CmbMostrarSegun.Margin = new System.Windows.Forms.Padding(6);
            this.CmbMostrarSegun.Name = "CmbMostrarSegun";
            this.CmbMostrarSegun.Size = new System.Drawing.Size(423, 31);
            this.CmbMostrarSegun.TabIndex = 276;
            this.CmbMostrarSegun.SelectedIndexChanged += new System.EventHandler(this.CmbMostrarSegun_SelectedIndexChanged);
            // 
            // LblMos
            // 
            this.LblMos.AutoSize = true;
            this.LblMos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.LblMos.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMos.Location = new System.Drawing.Point(15, 109);
            this.LblMos.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblMos.Name = "LblMos";
            this.LblMos.Size = new System.Drawing.Size(206, 19);
            this.LblMos.TabIndex = 277;
            this.LblMos.Text = "Mostrar Segun Categoria";
            // 
            // FrmTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.LblMos);
            this.Controls.Add(this.CmbMostrarSegun);
            this.Controls.Add(this.LblM);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.GrlMListar);
            this.Controls.Add(this.BtnEspera);
            this.Controls.Add(this.GbPa);
            this.Controls.Add(this.Npersonas);
            this.Controls.Add(this.LblCant);
            this.Controls.Add(this.LblMesa);
            this.Controls.Add(this.BtnQuitar);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.BtnVolver);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.NumCantidad);
            this.Controls.Add(this.CmbMenu);
            this.Controls.Add(this.LblCantidad);
            this.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmTicket";
            this.Text = "Ticket";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Npersonas)).EndInit();
            this.GbPa.ResumeLayout(false);
            this.GbPa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrlMListar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnQuitar;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.Button BtnVolver;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.NumericUpDown NumCantidad;
        private System.Windows.Forms.ComboBox CmbMenu;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.Label LblMesa;
        private System.Windows.Forms.Label LblCant;
        private System.Windows.Forms.NumericUpDown Npersonas;
        private System.Windows.Forms.GroupBox GbPa;
        private System.Windows.Forms.RadioButton RdtDebito;
        private System.Windows.Forms.RadioButton RdtTransfe;
        private System.Windows.Forms.RadioButton RdtEfectivo;
        private System.Windows.Forms.Button BtnEspera;
        private System.Windows.Forms.DataGridView GrlMListar;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Label LblM;
        private System.Windows.Forms.ComboBox CmbMostrarSegun;
        private System.Windows.Forms.Label LblMos;
    }
}