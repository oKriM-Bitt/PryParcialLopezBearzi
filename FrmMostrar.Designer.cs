namespace PuebloGrill
{
    partial class FrmMostrarStock
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMostrarStock));
            this.GrlmAdelante = new System.Windows.Forms.DataGridView();
            this.BtnMostrarSegun = new System.Windows.Forms.Button();
            this.LblMostrar = new System.Windows.Forms.Label();
            this.CmbCategoria = new System.Windows.Forms.ComboBox();
            this.GrlmAtras = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnVolver = new System.Windows.Forms.Button();
            this.ChtPopularidad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.GrlmAdelante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrlmAtras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChtPopularidad)).BeginInit();
            this.SuspendLayout();
            // 
            // GrlmAdelante
            // 
            this.GrlmAdelante.BackgroundColor = System.Drawing.Color.White;
            this.GrlmAdelante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrlmAdelante.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GrlmAdelante.Location = new System.Drawing.Point(19, 193);
            this.GrlmAdelante.Margin = new System.Windows.Forms.Padding(6);
            this.GrlmAdelante.Name = "GrlmAdelante";
            this.GrlmAdelante.Size = new System.Drawing.Size(592, 296);
            this.GrlmAdelante.TabIndex = 44;
            this.GrlmAdelante.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrlmAdelante_CellContentClick);
            // 
            // BtnMostrarSegun
            // 
            this.BtnMostrarSegun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnMostrarSegun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMostrarSegun.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMostrarSegun.Location = new System.Drawing.Point(449, 76);
            this.BtnMostrarSegun.Margin = new System.Windows.Forms.Padding(6);
            this.BtnMostrarSegun.Name = "BtnMostrarSegun";
            this.BtnMostrarSegun.Size = new System.Drawing.Size(162, 52);
            this.BtnMostrarSegun.TabIndex = 43;
            this.BtnMostrarSegun.Text = "Mostrar Todo";
            this.BtnMostrarSegun.UseVisualStyleBackColor = false;
            this.BtnMostrarSegun.Click += new System.EventHandler(this.BtnMostrarSegun_Click);
            // 
            // LblMostrar
            // 
            this.LblMostrar.AutoSize = true;
            this.LblMostrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.LblMostrar.Font = new System.Drawing.Font("Rockwell", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMostrar.Location = new System.Drawing.Point(13, 28);
            this.LblMostrar.Name = "LblMostrar";
            this.LblMostrar.Size = new System.Drawing.Size(223, 36);
            this.LblMostrar.TabIndex = 42;
            this.LblMostrar.Text = "Mostrar Según";
            // 
            // CmbCategoria
            // 
            this.CmbCategoria.Font = new System.Drawing.Font("Rockwell", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCategoria.FormattingEnabled = true;
            this.CmbCategoria.Location = new System.Drawing.Point(19, 81);
            this.CmbCategoria.Name = "CmbCategoria";
            this.CmbCategoria.Size = new System.Drawing.Size(401, 47);
            this.CmbCategoria.TabIndex = 41;
            this.CmbCategoria.SelectedIndexChanged += new System.EventHandler(this.CmbCategoria_SelectedIndexChanged);
            // 
            // GrlmAtras
            // 
            this.GrlmAtras.BackgroundColor = System.Drawing.Color.White;
            this.GrlmAtras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrlmAtras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.GrlmAtras.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GrlmAtras.Location = new System.Drawing.Point(19, 193);
            this.GrlmAtras.Margin = new System.Windows.Forms.Padding(6);
            this.GrlmAtras.Name = "GrlmAtras";
            this.GrlmAtras.Size = new System.Drawing.Size(592, 296);
            this.GrlmAtras.TabIndex = 40;
            this.GrlmAtras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrlmAtras_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IdCategoria";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.Width = 170;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Precio";
            this.Column3.Name = "Column3";
            // 
            // BtnVolver
            // 
            this.BtnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVolver.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVolver.Location = new System.Drawing.Point(27, 519);
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(143, 50);
            this.BtnVolver.TabIndex = 39;
            this.BtnVolver.Text = "Volver";
            this.BtnVolver.UseVisualStyleBackColor = false;
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // ChtPopularidad
            // 
            chartArea1.Name = "ChartArea1";
            this.ChtPopularidad.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChtPopularidad.Legends.Add(legend1);
            this.ChtPopularidad.Location = new System.Drawing.Point(651, 193);
            this.ChtPopularidad.Name = "ChtPopularidad";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ChtPopularidad.Series.Add(series1);
            this.ChtPopularidad.Size = new System.Drawing.Size(687, 296);
            this.ChtPopularidad.TabIndex = 45;
            this.ChtPopularidad.Text = "chart1";
            // 
            // FrmMostrarStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.ChtPopularidad);
            this.Controls.Add(this.GrlmAdelante);
            this.Controls.Add(this.BtnMostrarSegun);
            this.Controls.Add(this.LblMostrar);
            this.Controls.Add(this.CmbCategoria);
            this.Controls.Add(this.GrlmAtras);
            this.Controls.Add(this.BtnVolver);
            this.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmMostrarStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mostrar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMostrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrlmAdelante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrlmAtras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChtPopularidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GrlmAdelante;
        private System.Windows.Forms.Button BtnMostrarSegun;
        private System.Windows.Forms.Label LblMostrar;
        private System.Windows.Forms.ComboBox CmbCategoria;
        private System.Windows.Forms.DataGridView GrlmAtras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button BtnVolver;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChtPopularidad;
    }
}