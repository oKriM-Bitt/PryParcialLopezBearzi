namespace PuebloGrill
{
    partial class FrmCargarPlato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCargarPlato));
            this.CmbCategoria = new System.Windows.Forms.ComboBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnVolver = new System.Windows.Forms.Button();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.GpCargar = new System.Windows.Forms.GroupBox();
            this.LblStock = new System.Windows.Forms.Label();
            this.TxtStock = new System.Windows.Forms.TextBox();
            this.LblCate = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.LblPrecio = new System.Windows.Forms.Label();
            this.Grlm = new System.Windows.Forms.DataGridView();
            this.GpModificarEliminar = new System.Windows.Forms.GroupBox();
            this.LblS = new System.Windows.Forms.Label();
            this.TxtStockModificar = new System.Windows.Forms.TextBox();
            this.TxtNombreModificar = new System.Windows.Forms.TextBox();
            this.LblN = new System.Windows.Forms.Label();
            this.LblCat = new System.Windows.Forms.Label();
            this.LblCod = new System.Windows.Forms.Label();
            this.LblPr = new System.Windows.Forms.Label();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.CmbCategoriaModificar = new System.Windows.Forms.ComboBox();
            this.TxtPrecioModificar = new System.Windows.Forms.TextBox();
            this.TxtCodigoModificar = new System.Windows.Forms.TextBox();
            this.GpCargar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grlm)).BeginInit();
            this.GpModificarEliminar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbCategoria
            // 
            this.CmbCategoria.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCategoria.FormattingEnabled = true;
            this.CmbCategoria.Location = new System.Drawing.Point(154, 151);
            this.CmbCategoria.Name = "CmbCategoria";
            this.CmbCategoria.Size = new System.Drawing.Size(331, 33);
            this.CmbCategoria.TabIndex = 45;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(388, 251);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(132, 53);
            this.BtnAgregar.TabIndex = 43;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnVolver
            // 
            this.BtnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVolver.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVolver.Location = new System.Drawing.Point(1139, 645);
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(199, 48);
            this.BtnVolver.TabIndex = 42;
            this.BtnVolver.Text = "Volver Menu";
            this.BtnVolver.UseVisualStyleBackColor = false;
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecio.Location = new System.Drawing.Point(154, 66);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(331, 32);
            this.TxtPrecio.TabIndex = 41;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(247, 25);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(238, 32);
            this.TxtNombre.TabIndex = 40;
            // 
            // GpCargar
            // 
            this.GpCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.GpCargar.Controls.Add(this.LblStock);
            this.GpCargar.Controls.Add(this.TxtStock);
            this.GpCargar.Controls.Add(this.LblCate);
            this.GpCargar.Controls.Add(this.CmbCategoria);
            this.GpCargar.Controls.Add(this.LblNombre);
            this.GpCargar.Controls.Add(this.LblPrecio);
            this.GpCargar.Controls.Add(this.BtnAgregar);
            this.GpCargar.Controls.Add(this.TxtNombre);
            this.GpCargar.Controls.Add(this.TxtPrecio);
            this.GpCargar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GpCargar.Location = new System.Drawing.Point(32, 12);
            this.GpCargar.Name = "GpCargar";
            this.GpCargar.Size = new System.Drawing.Size(526, 310);
            this.GpCargar.TabIndex = 50;
            this.GpCargar.TabStop = false;
            this.GpCargar.Text = "Cargar Producto";
            // 
            // LblStock
            // 
            this.LblStock.AutoSize = true;
            this.LblStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.LblStock.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStock.Location = new System.Drawing.Point(6, 111);
            this.LblStock.Name = "LblStock";
            this.LblStock.Size = new System.Drawing.Size(68, 25);
            this.LblStock.TabIndex = 46;
            this.LblStock.Text = "Stock";
            // 
            // TxtStock
            // 
            this.TxtStock.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStock.Location = new System.Drawing.Point(154, 104);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.Size = new System.Drawing.Size(345, 32);
            this.TxtStock.TabIndex = 47;
            // 
            // LblCate
            // 
            this.LblCate.AutoSize = true;
            this.LblCate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.LblCate.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCate.Location = new System.Drawing.Point(6, 154);
            this.LblCate.Name = "LblCate";
            this.LblCate.Size = new System.Drawing.Size(112, 25);
            this.LblCate.TabIndex = 44;
            this.LblCate.Text = "Categoria";
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.LblNombre.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre.Location = new System.Drawing.Point(6, 25);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(235, 25);
            this.LblNombre.TabIndex = 38;
            this.LblNombre.Text = " Nombre del Producto";
            // 
            // LblPrecio
            // 
            this.LblPrecio.AutoSize = true;
            this.LblPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.LblPrecio.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrecio.Location = new System.Drawing.Point(6, 62);
            this.LblPrecio.Name = "LblPrecio";
            this.LblPrecio.Size = new System.Drawing.Size(78, 25);
            this.LblPrecio.TabIndex = 39;
            this.LblPrecio.Text = "Precio";
            // 
            // Grlm
            // 
            this.Grlm.BackgroundColor = System.Drawing.Color.White;
            this.Grlm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grlm.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Grlm.Location = new System.Drawing.Point(23, 331);
            this.Grlm.Margin = new System.Windows.Forms.Padding(6);
            this.Grlm.Name = "Grlm";
            this.Grlm.Size = new System.Drawing.Size(1067, 383);
            this.Grlm.TabIndex = 51;
            this.Grlm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grlm_CellContentClick);
            // 
            // GpModificarEliminar
            // 
            this.GpModificarEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.GpModificarEliminar.Controls.Add(this.LblS);
            this.GpModificarEliminar.Controls.Add(this.TxtStockModificar);
            this.GpModificarEliminar.Controls.Add(this.TxtNombreModificar);
            this.GpModificarEliminar.Controls.Add(this.LblN);
            this.GpModificarEliminar.Controls.Add(this.LblCat);
            this.GpModificarEliminar.Controls.Add(this.LblCod);
            this.GpModificarEliminar.Controls.Add(this.LblPr);
            this.GpModificarEliminar.Controls.Add(this.BtnModificar);
            this.GpModificarEliminar.Controls.Add(this.BtnEliminar);
            this.GpModificarEliminar.Controls.Add(this.CmbCategoriaModificar);
            this.GpModificarEliminar.Controls.Add(this.TxtPrecioModificar);
            this.GpModificarEliminar.Controls.Add(this.TxtCodigoModificar);
            this.GpModificarEliminar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GpModificarEliminar.Location = new System.Drawing.Point(564, 12);
            this.GpModificarEliminar.Name = "GpModificarEliminar";
            this.GpModificarEliminar.Size = new System.Drawing.Size(526, 310);
            this.GpModificarEliminar.TabIndex = 52;
            this.GpModificarEliminar.TabStop = false;
            this.GpModificarEliminar.Text = "Modificar  o Eliminar";
            // 
            // LblS
            // 
            this.LblS.AutoSize = true;
            this.LblS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.LblS.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblS.Location = new System.Drawing.Point(6, 159);
            this.LblS.Name = "LblS";
            this.LblS.Size = new System.Drawing.Size(68, 25);
            this.LblS.TabIndex = 52;
            this.LblS.Text = "Stock";
            // 
            // TxtStockModificar
            // 
            this.TxtStockModificar.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStockModificar.Location = new System.Drawing.Point(160, 152);
            this.TxtStockModificar.Name = "TxtStockModificar";
            this.TxtStockModificar.Size = new System.Drawing.Size(345, 32);
            this.TxtStockModificar.TabIndex = 53;
            // 
            // TxtNombreModificar
            // 
            this.TxtNombreModificar.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreModificar.Location = new System.Drawing.Point(160, 73);
            this.TxtNombreModificar.Name = "TxtNombreModificar";
            this.TxtNombreModificar.Size = new System.Drawing.Size(345, 32);
            this.TxtNombreModificar.TabIndex = 51;
            // 
            // LblN
            // 
            this.LblN.AutoSize = true;
            this.LblN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.LblN.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblN.Location = new System.Drawing.Point(6, 76);
            this.LblN.Name = "LblN";
            this.LblN.Size = new System.Drawing.Size(96, 25);
            this.LblN.TabIndex = 50;
            this.LblN.Text = "Nombre";
            // 
            // LblCat
            // 
            this.LblCat.AutoSize = true;
            this.LblCat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.LblCat.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCat.Location = new System.Drawing.Point(6, 193);
            this.LblCat.Name = "LblCat";
            this.LblCat.Size = new System.Drawing.Size(112, 25);
            this.LblCat.TabIndex = 44;
            this.LblCat.Text = "Categoria";
            // 
            // LblCod
            // 
            this.LblCod.AutoSize = true;
            this.LblCod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.LblCod.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCod.Location = new System.Drawing.Point(6, 28);
            this.LblCod.Name = "LblCod";
            this.LblCod.Size = new System.Drawing.Size(85, 25);
            this.LblCod.TabIndex = 38;
            this.LblCod.Text = "Codigo";
            // 
            // LblPr
            // 
            this.LblPr.AutoSize = true;
            this.LblPr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.LblPr.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPr.Location = new System.Drawing.Point(6, 121);
            this.LblPr.Name = "LblPr";
            this.LblPr.Size = new System.Drawing.Size(78, 25);
            this.LblPr.TabIndex = 39;
            this.LblPr.Text = "Precio";
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificar.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.Location = new System.Drawing.Point(250, 251);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(132, 53);
            this.BtnModificar.TabIndex = 48;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(211)))), ((int)(((byte)(168)))));
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.Location = new System.Drawing.Point(388, 251);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(132, 53);
            this.BtnEliminar.TabIndex = 47;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // CmbCategoriaModificar
            // 
            this.CmbCategoriaModificar.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCategoriaModificar.FormattingEnabled = true;
            this.CmbCategoriaModificar.Location = new System.Drawing.Point(160, 190);
            this.CmbCategoriaModificar.Name = "CmbCategoriaModificar";
            this.CmbCategoriaModificar.Size = new System.Drawing.Size(345, 33);
            this.CmbCategoriaModificar.TabIndex = 45;
            // 
            // TxtPrecioModificar
            // 
            this.TxtPrecioModificar.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecioModificar.Location = new System.Drawing.Point(160, 114);
            this.TxtPrecioModificar.Name = "TxtPrecioModificar";
            this.TxtPrecioModificar.Size = new System.Drawing.Size(345, 32);
            this.TxtPrecioModificar.TabIndex = 40;
            // 
            // TxtCodigoModificar
            // 
            this.TxtCodigoModificar.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigoModificar.Location = new System.Drawing.Point(160, 25);
            this.TxtCodigoModificar.Name = "TxtCodigoModificar";
            this.TxtCodigoModificar.Size = new System.Drawing.Size(345, 32);
            this.TxtCodigoModificar.TabIndex = 41;
            // 
            // FrmCargarPlato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.GpModificarEliminar);
            this.Controls.Add(this.Grlm);
            this.Controls.Add(this.GpCargar);
            this.Controls.Add(this.BtnVolver);
            this.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmCargarPlato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cargar Plato";
            this.Load += new System.EventHandler(this.FrmCargarPlato_Load);
            this.GpCargar.ResumeLayout(false);
            this.GpCargar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grlm)).EndInit();
            this.GpModificarEliminar.ResumeLayout(false);
            this.GpModificarEliminar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbCategoria;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnVolver;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.GroupBox GpCargar;
        private System.Windows.Forms.Label LblCate;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Label LblPrecio;
        private System.Windows.Forms.DataGridView Grlm;
        private System.Windows.Forms.GroupBox GpModificarEliminar;
        private System.Windows.Forms.Label LblCat;
        private System.Windows.Forms.Label LblCod;
        private System.Windows.Forms.Label LblPr;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.ComboBox CmbCategoriaModificar;
        private System.Windows.Forms.TextBox TxtPrecioModificar;
        private System.Windows.Forms.TextBox TxtCodigoModificar;
        private System.Windows.Forms.TextBox TxtNombreModificar;
        private System.Windows.Forms.Label LblN;
        private System.Windows.Forms.Label LblStock;
        private System.Windows.Forms.TextBox TxtStock;
        private System.Windows.Forms.Label LblS;
        private System.Windows.Forms.TextBox TxtStockModificar;
    }
}