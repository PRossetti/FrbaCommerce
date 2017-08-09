namespace FrbaCommerce.Comprar_Ofertar
{
    partial class Preguntar
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
            this.txtBx_Pregunta = new System.Windows.Forms.TextBox();
            this.btn_Atras = new System.Windows.Forms.Button();
            this.btn_Preguntar = new System.Windows.Forms.Button();
            this.labelRemaining = new System.Windows.Forms.Label();
            this.labelRestantes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // txtBx_Pregunta
            // 
            this.txtBx_Pregunta.Location = new System.Drawing.Point(12, 27);
            this.txtBx_Pregunta.MaxLength = 255;
            this.txtBx_Pregunta.Multiline = true;
            this.txtBx_Pregunta.Name = "txtBx_Pregunta";
            this.txtBx_Pregunta.Size = new System.Drawing.Size(255, 114);
            this.txtBx_Pregunta.TabIndex = 1;
            this.txtBx_Pregunta.Text = "Escribe tu pregunta...";
            this.txtBx_Pregunta.TextChanged += new System.EventHandler(this.txtBx_Pregunta_TextChanged);
            // 
            // btn_Atras
            // 
            this.btn_Atras.Location = new System.Drawing.Point(12, 227);
            this.btn_Atras.Name = "btn_Atras";
            this.btn_Atras.Size = new System.Drawing.Size(75, 23);
            this.btn_Atras.TabIndex = 2;
            this.btn_Atras.Text = "Atrás";
            this.btn_Atras.UseVisualStyleBackColor = true;
            this.btn_Atras.Click += new System.EventHandler(this.btn_Atras_Click);
            // 
            // btn_Preguntar
            // 
            this.btn_Preguntar.Location = new System.Drawing.Point(192, 227);
            this.btn_Preguntar.Name = "btn_Preguntar";
            this.btn_Preguntar.Size = new System.Drawing.Size(75, 23);
            this.btn_Preguntar.TabIndex = 3;
            this.btn_Preguntar.Text = "Preguntar";
            this.btn_Preguntar.UseVisualStyleBackColor = true;
            this.btn_Preguntar.Click += new System.EventHandler(this.btn_Preguntar_Click);
            // 
            // labelRemaining
            // 
            this.labelRemaining.AutoSize = true;
            this.labelRemaining.Location = new System.Drawing.Point(232, 144);
            this.labelRemaining.Name = "labelRemaining";
            this.labelRemaining.Size = new System.Drawing.Size(35, 13);
            this.labelRemaining.TabIndex = 4;
            this.labelRemaining.Text = "label2";
            // 
            // labelRestantes
            // 
            this.labelRestantes.AutoSize = true;
            this.labelRestantes.Location = new System.Drawing.Point(119, 144);
            this.labelRestantes.Name = "labelRestantes";
            this.labelRestantes.Size = new System.Drawing.Size(107, 13);
            this.labelRestantes.TabIndex = 5;
            this.labelRestantes.Text = "Caracteres restantes:";
            // 
            // Preguntar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.labelRestantes);
            this.Controls.Add(this.labelRemaining);
            this.Controls.Add(this.btn_Preguntar);
            this.Controls.Add(this.btn_Atras);
            this.Controls.Add(this.txtBx_Pregunta);
            this.Controls.Add(this.label1);
            this.Name = "Preguntar";
            this.Text = "Preguntar";
            this.Load += new System.EventHandler(this.Preguntar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBx_Pregunta;
        private System.Windows.Forms.Button btn_Atras;
        private System.Windows.Forms.Button btn_Preguntar;
        private System.Windows.Forms.Label labelRemaining;
        private System.Windows.Forms.Label labelRestantes;
    }
}