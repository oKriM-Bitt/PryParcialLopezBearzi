namespace PuebloGrill
{
    partial class FrmLibrioDiario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLibrioDiario));
            this.Grlm = new System.Windows.Forms.DataGridView();
            this.BtnImprimirS = new System.Windows.Forms.Button();
            this.BtnVerSemana = new System.Windows.Forms.Button();
            this.BtnVerMes = new System.Windows.Forms.Button();
            this.BtnVolver = new System.Windows.Forms.Button();
            this.BtnVerHoy = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbFiltro = new System.Windows.Forms.ComboBox();
            this.LblFiltra = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grlm)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grlm
            // 
            this.Grlm.BackgroundColor = System.Drawing.Color.White;
            this.Grlm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grlm.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Grlm.Location = new System.Drawing.Point(27, 15);
            this.Grlm.Margin = new System.Windows.Forms.Padding(6);
            this.Grlm.Name = "Grlm";
            this.Grlm.Size = new System.Drawing.Size(1003, 605);
            this.Grlm.TabIndex = 52;
            this.Grlm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grlm_CellContentClick);
            // 
            // BtnImprimirS
            // 
            this.BtnImprimirS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnImprimirS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImprimirS.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimirS.Location = new System.Drawing.Point(1102, 629);
            this.BtnImprimirS.Name = "BtnImprimirS";
            this.BtnImprimirS.Size = new System.Drawing.Size(182, 51);
            this.BtnImprimirS.TabIndex = 53;
            this.BtnImprimirS.Text = "Imprimir y Salir";
            this.BtnImprimirS.UseVisualStyleBackColor = false;
            this.BtnImprimirS.Click += new System.EventHandler(this.BtnImprimirS_Click);
            // 
            // BtnVerSemana
            // 
            this.BtnVerSemana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnVerSemana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVerSemana.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVerSemana.Location = new System.Drawing.Point(1102, 225);
            this.BtnVerSemana.Name = "BtnVerSemana";
            this.BtnVerSemana.Size = new System.Drawing.Size(182, 51);
            this.BtnVerSemana.TabIndex = 54;
            this.BtnVerSemana.Text = "Ver Semana";
            this.BtnVerSemana.UseVisualStyleBackColor = false;
            this.BtnVerSemana.Click += new System.EventHandler(this.BtnVerSemana_Click);
            // 
            // BtnVerMes
            // 
            this.BtnVerMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnVerMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVerMes.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVerMes.Location = new System.Drawing.Point(1102, 295);
            this.BtnVerMes.Name = "BtnVerMes";
            this.BtnVerMes.Size = new System.Drawing.Size(182, 51);
            this.BtnVerMes.TabIndex = 55;
            this.BtnVerMes.Text = "Ver Mes";
            this.BtnVerMes.UseVisualStyleBackColor = false;
            this.BtnVerMes.Click += new System.EventHandler(this.BtnVerMes_Click);
            // 
            // BtnVolver
            // 
            this.BtnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVolver.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVolver.Location = new System.Drawing.Point(27, 629);
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(182, 51);
            this.BtnVolver.TabIndex = 56;
            this.BtnVolver.Text = "Volver";
            this.BtnVolver.UseVisualStyleBackColor = false;
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // BtnVerHoy
            // 
            this.BtnVerHoy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnVerHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVerHoy.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVerHoy.Location = new System.Drawing.Point(1102, 154);
            this.BtnVerHoy.Name = "BtnVerHoy";
            this.BtnVerHoy.Size = new System.Drawing.Size(182, 51);
            this.BtnVerHoy.TabIndex = 57;
            this.BtnVerHoy.Text = "Ver Hoy";
            this.BtnVerHoy.UseVisualStyleBackColor = false;
            this.BtnVerHoy.Click += new System.EventHandler(this.BtnVerHoy_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Location = new System.Drawing.Point(1102, 370);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(182, 51);
            this.BtnLimpiar.TabIndex = 58;
            this.BtnLimpiar.Text = "Limpiar Todo";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CmbFiltro);
            this.panel1.Controls.Add(this.LblFiltra);
            this.panel1.Location = new System.Drawing.Point(1052, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 104);
            this.panel1.TabIndex = 59;
            // 
            // CmbFiltro
            // 
            this.CmbFiltro.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.CmbFiltro.FormattingEnabled = true;
            this.CmbFiltro.Location = new System.Drawing.Point(7, 50);
            this.CmbFiltro.Name = "CmbFiltro";
            this.CmbFiltro.Size = new System.Drawing.Size(276, 27);
            this.CmbFiltro.TabIndex = 1;
            this.CmbFiltro.SelectedIndexChanged += new System.EventHandler(this.CmbFiltro_SelectedIndexChanged);
            // 
            // LblFiltra
            // 
            this.LblFiltra.AutoSize = true;
            this.LblFiltra.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.LblFiltra.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblFiltra.Location = new System.Drawing.Point(3, 14);
            this.LblFiltra.Name = "LblFiltra";
            this.LblFiltra.Size = new System.Drawing.Size(209, 19);
            this.LblFiltra.TabIndex = 0;
            this.LblFiltra.Text = "Filtrar por medio de pago";
            // 
            // LblTotal
            // 
            this.LblTotal.BackColor = System.Drawing.Color.White;
            this.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LblTotal.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.Location = new System.Drawing.Point(712, 644);
            this.LblTotal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(275, 41);
            this.LblTotal.TabIndex = 275;
            this.LblTotal.Click += new System.EventHandler(this.LblTotal_Click);
            // 
            // FrmLibrioDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnVerHoy);
            this.Controls.Add(this.BtnVolver);
            this.Controls.Add(this.BtnVerMes);
            this.Controls.Add(this.BtnVerSemana);
            this.Controls.Add(this.BtnImprimirS);
            this.Controls.Add(this.Grlm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLibrioDiario";
            this.Text = "Libro Diario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmLibrioDiario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grlm)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grlm;
        private System.Windows.Forms.Button BtnImprimirS;
        private System.Windows.Forms.Button BtnVerSemana;
        private System.Windows.Forms.Button BtnVerMes;
        private System.Windows.Forms.Button BtnVolver;
        private System.Windows.Forms.Button BtnVerHoy;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblFiltra;
        private System.Windows.Forms.ComboBox CmbFiltro;
        private System.Windows.Forms.Label LblTotal;
    }
}