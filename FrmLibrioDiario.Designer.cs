namespace PryPueblox
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
            ((System.ComponentModel.ISupportInitialize)(this.Grlm)).BeginInit();
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
            this.Grlm.Size = new System.Drawing.Size(1123, 605);
            this.Grlm.TabIndex = 52;
            this.Grlm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grlm_CellContentClick);
            // 
            // BtnImprimirS
            // 
            this.BtnImprimirS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnImprimirS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImprimirS.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimirS.Location = new System.Drawing.Point(1156, 629);
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
            this.BtnVerSemana.Location = new System.Drawing.Point(1159, 86);
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
            this.BtnVerMes.Location = new System.Drawing.Point(1159, 156);
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
            this.BtnVerHoy.Location = new System.Drawing.Point(1159, 15);
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
            this.BtnLimpiar.Location = new System.Drawing.Point(1159, 231);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(182, 51);
            this.BtnLimpiar.TabIndex = 58;
            this.BtnLimpiar.Text = "Limpiar Todo";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // FrmLibrioDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
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
    }
}