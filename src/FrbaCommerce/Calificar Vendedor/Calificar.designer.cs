namespace FrbaCommerce.Calificar_Vendedor
{
    partial class Calificar
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
            this.lbl_Calificaciones = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Atras = new System.Windows.Forms.Button();
            this.btb_Calificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Calificaciones
            // 
            this.lbl_Calificaciones.AutoSize = true;
            this.lbl_Calificaciones.Location = new System.Drawing.Point(13, 13);
            this.lbl_Calificaciones.Name = "lbl_Calificaciones";
            this.lbl_Calificaciones.Size = new System.Drawing.Size(106, 13);
            this.lbl_Calificaciones.TabIndex = 0;
            this.lbl_Calificaciones.Text = "Compras sin calificar:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(508, 150);
            this.dataGridView1.TabIndex = 1;
            
            // 
            // btn_Atras
            // 
            this.btn_Atras.Location = new System.Drawing.Point(16, 227);
            this.btn_Atras.Name = "btn_Atras";
            this.btn_Atras.Size = new System.Drawing.Size(75, 23);
            this.btn_Atras.TabIndex = 2;
            this.btn_Atras.Text = "Atrás";
            this.btn_Atras.UseVisualStyleBackColor = true;
            this.btn_Atras.Click += new System.EventHandler(this.btn_Atras_Click);
            // 
            // btb_Calificar
            // 
            this.btb_Calificar.Location = new System.Drawing.Point(445, 227);
            this.btb_Calificar.Name = "btb_Calificar";
            this.btb_Calificar.Size = new System.Drawing.Size(75, 23);
            this.btb_Calificar.TabIndex = 3;
            this.btb_Calificar.Text = "Calificar";
            this.btb_Calificar.UseVisualStyleBackColor = true;
            this.btb_Calificar.Click += new System.EventHandler(this.btb_Calificar_Click);
            // 
            // Calificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 262);
            this.Controls.Add(this.btb_Calificar);
            this.Controls.Add(this.btn_Atras);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbl_Calificaciones);
            this.Name = "Calificar";
            this.Text = "Calificar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Calificaciones;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Atras;
        private System.Windows.Forms.Button btb_Calificar;
    }
}