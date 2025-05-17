namespace PuebloGrill
{
    partial class FrmAccionesMesaOcupada
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
            this.lblMensajeAccion = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCobrada = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMensajeAccion
            // 
            this.lblMensajeAccion.AutoSize = true;
            this.lblMensajeAccion.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblMensajeAccion.Location = new System.Drawing.Point(26, 46);
            this.lblMensajeAccion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMensajeAccion.Name = "lblMensajeAccion";
            this.lblMensajeAccion.Size = new System.Drawing.Size(0, 25);
            this.lblMensajeAccion.TabIndex = 0;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(137)))), ((int)(((byte)(73)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificar.Location = new System.Drawing.Point(31, 95);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(247, 38);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar Orden";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(137)))), ((int)(((byte)(73)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiar.Location = new System.Drawing.Point(284, 96);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(252, 37);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar Mesa";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(137)))), ((int)(((byte)(73)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Location = new System.Drawing.Point(795, 96);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(247, 37);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCobrada
            // 
            this.btnCobrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(137)))), ((int)(((byte)(73)))));
            this.btnCobrada.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCobrada.Location = new System.Drawing.Point(542, 96);
            this.btnCobrada.Name = "btnCobrada";
            this.btnCobrada.Size = new System.Drawing.Size(247, 36);
            this.btnCobrada.TabIndex = 5;
            this.btnCobrada.Text = "Cobrar y Cerrar";
            this.btnCobrada.UseVisualStyleBackColor = false;
            this.btnCobrada.Click += new System.EventHandler(this.btnCobrada_Click);
            // 
            // FrmAccionesMesaOcupada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(181)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1180, 202);
            this.Controls.Add(this.btnCobrada);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.lblMensajeAccion);
            this.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmAccionesMesaOcupada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acciones ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensajeAccion;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCobrada;
    }
}