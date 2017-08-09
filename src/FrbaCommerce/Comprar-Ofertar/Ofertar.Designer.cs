namespace FrbaCommerce.Comprar_Ofertar
{
    partial class Ofertar
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBx_PujaActual = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBx_Puja = new System.Windows.Forms.TextBox();
            this.label_MsjRevisar = new System.Windows.Forms.Label();
            this.btn_Pujar = new System.Windows.Forms.Button();
            this.label_Error = new System.Windows.Forms.Label();
            this.label_MensajeOK = new System.Windows.Forms.Label();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puja actual:";
            // 
            // txtBx_PujaActual
            // 
            this.txtBx_PujaActual.Location = new System.Drawing.Point(78, 42);
            this.txtBx_PujaActual.Name = "txtBx_PujaActual";
            this.txtBx_PujaActual.ReadOnly = true;
            this.txtBx_PujaActual.Size = new System.Drawing.Size(100, 20);
            this.txtBx_PujaActual.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Su puja:";
            // 
            // txtBx_Puja
            // 
            this.txtBx_Puja.Location = new System.Drawing.Point(78, 77);
            this.txtBx_Puja.Name = "txtBx_Puja";
            this.txtBx_Puja.Size = new System.Drawing.Size(100, 20);
            this.txtBx_Puja.TabIndex = 3;
            // 
            // label_MsjRevisar
            // 
            this.label_MsjRevisar.AutoSize = true;
            this.label_MsjRevisar.ForeColor = System.Drawing.Color.Red;
            this.label_MsjRevisar.Location = new System.Drawing.Point(12, 136);
            this.label_MsjRevisar.Name = "label_MsjRevisar";
            this.label_MsjRevisar.Size = new System.Drawing.Size(35, 13);
            this.label_MsjRevisar.TabIndex = 4;
            this.label_MsjRevisar.Text = "label3";
            // 
            // btn_Pujar
            // 
            this.btn_Pujar.Location = new System.Drawing.Point(240, 74);
            this.btn_Pujar.Name = "btn_Pujar";
            this.btn_Pujar.Size = new System.Drawing.Size(75, 23);
            this.btn_Pujar.TabIndex = 5;
            this.btn_Pujar.Text = "Ofertar";
            this.btn_Pujar.UseVisualStyleBackColor = true;
            this.btn_Pujar.Click += new System.EventHandler(this.btn_Pujar_Click);
            // 
            // label_Error
            // 
            this.label_Error.AutoSize = true;
            this.label_Error.ForeColor = System.Drawing.Color.Red;
            this.label_Error.Location = new System.Drawing.Point(184, 84);
            this.label_Error.Name = "label_Error";
            this.label_Error.Size = new System.Drawing.Size(35, 13);
            this.label_Error.TabIndex = 6;
            this.label_Error.Text = "label3";
            // 
            // label_MensajeOK
            // 
            this.label_MensajeOK.AutoSize = true;
            this.label_MensajeOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_MensajeOK.Location = new System.Drawing.Point(12, 163);
            this.label_MensajeOK.Name = "label_MensajeOK";
            this.label_MensajeOK.Size = new System.Drawing.Size(35, 13);
            this.label_MensajeOK.TabIndex = 7;
            this.label_MensajeOK.Text = "label3";
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Location = new System.Drawing.Point(240, 153);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cerrar.TabIndex = 8;
            this.btn_Cerrar.Text = "Cerrar";
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // Ofertar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 197);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.label_MensajeOK);
            this.Controls.Add(this.label_Error);
            this.Controls.Add(this.btn_Pujar);
            this.Controls.Add(this.label_MsjRevisar);
            this.Controls.Add(this.txtBx_Puja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBx_PujaActual);
            this.Controls.Add(this.label1);
            this.Name = "Ofertar";
            this.Text = "Ofertar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBx_PujaActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBx_Puja;
        private System.Windows.Forms.Label label_MsjRevisar;
        private System.Windows.Forms.Button btn_Pujar;
        private System.Windows.Forms.Label label_Error;
        private System.Windows.Forms.Label label_MensajeOK;
        private System.Windows.Forms.Button btn_Cerrar;
    }
}