namespace FrbaCommerce.Historial_Cliente
{
    partial class Historial_Cliente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_HistorialCompras = new System.Windows.Forms.Button();
            this.button_HistorialOfertas = new System.Windows.Forms.Button();
            this.button_HistorialCalificaciones = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Cancelar);
            this.groupBox1.Controls.Add(this.button_HistorialCalificaciones);
            this.groupBox1.Controls.Add(this.button_HistorialOfertas);
            this.groupBox1.Controls.Add(this.button_HistorialCompras);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // button_HistorialCompras
            // 
            this.button_HistorialCompras.Location = new System.Drawing.Point(12, 23);
            this.button_HistorialCompras.Name = "button_HistorialCompras";
            this.button_HistorialCompras.Size = new System.Drawing.Size(128, 23);
            this.button_HistorialCompras.TabIndex = 0;
            this.button_HistorialCompras.Text = "Historial Compras";
            this.button_HistorialCompras.UseVisualStyleBackColor = true;
            this.button_HistorialCompras.Click += new System.EventHandler(this.button_HistorialCompras_Click);
            // 
            // button_HistorialOfertas
            // 
            this.button_HistorialOfertas.Location = new System.Drawing.Point(12, 58);
            this.button_HistorialOfertas.Name = "button_HistorialOfertas";
            this.button_HistorialOfertas.Size = new System.Drawing.Size(128, 23);
            this.button_HistorialOfertas.TabIndex = 1;
            this.button_HistorialOfertas.Text = "Historial Ofertas";
            this.button_HistorialOfertas.UseVisualStyleBackColor = true;
            this.button_HistorialOfertas.Click += new System.EventHandler(this.button_HistorialOfertas_Click);
            // 
            // button_HistorialCalificaciones
            // 
            this.button_HistorialCalificaciones.Location = new System.Drawing.Point(12, 93);
            this.button_HistorialCalificaciones.Name = "button_HistorialCalificaciones";
            this.button_HistorialCalificaciones.Size = new System.Drawing.Size(128, 23);
            this.button_HistorialCalificaciones.TabIndex = 2;
            this.button_HistorialCalificaciones.Text = "Historial Calificaciones";
            this.button_HistorialCalificaciones.UseVisualStyleBackColor = true;
            this.button_HistorialCalificaciones.Click += new System.EventHandler(this.button_HistorialCalificaciones_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(12, 128);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(128, 23);
            this.button_Cancelar.TabIndex = 3;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // Historial_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 185);
            this.Controls.Add(this.groupBox1);
            this.Name = "Historial_Cliente";
            this.Text = "Historial_Cliente";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_HistorialCalificaciones;
        private System.Windows.Forms.Button button_HistorialOfertas;
        private System.Windows.Forms.Button button_HistorialCompras;
    }
}