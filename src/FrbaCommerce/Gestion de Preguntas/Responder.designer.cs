namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class Responder
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
            this.txtBx_Respuesta = new System.Windows.Forms.TextBox();
            this.lbl_Restantes = new System.Windows.Forms.Label();
            this.labelRemaining = new System.Windows.Forms.Label();
            this.btn_Atras = new System.Windows.Forms.Button();
            this.btn_Responder = new System.Windows.Forms.Button();
            this.lbl_Pregunta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBx_Respuesta
            // 
            this.txtBx_Respuesta.Location = new System.Drawing.Point(13, 104);
            this.txtBx_Respuesta.MaxLength = 255;
            this.txtBx_Respuesta.Multiline = true;
            this.txtBx_Respuesta.Name = "txtBx_Respuesta";
            this.txtBx_Respuesta.Size = new System.Drawing.Size(274, 101);
            this.txtBx_Respuesta.TabIndex = 0;
            this.txtBx_Respuesta.Text = "Escribe tu respuesta...";
            this.txtBx_Respuesta.TextChanged += new System.EventHandler(this.txtBx_Respuesta_TextChanged);
            // 
            // lbl_Restantes
            // 
            this.lbl_Restantes.AutoSize = true;
            this.lbl_Restantes.Location = new System.Drawing.Point(127, 208);
            this.lbl_Restantes.Name = "lbl_Restantes";
            this.lbl_Restantes.Size = new System.Drawing.Size(107, 13);
            this.lbl_Restantes.TabIndex = 1;
            this.lbl_Restantes.Text = "Caracteres restantes:";
            // 
            // labelRemaining
            // 
            this.labelRemaining.AutoSize = true;
            this.labelRemaining.Location = new System.Drawing.Point(251, 208);
            this.labelRemaining.Name = "labelRemaining";
            this.labelRemaining.Size = new System.Drawing.Size(35, 13);
            this.labelRemaining.TabIndex = 2;
            this.labelRemaining.Text = "label2";
            // 
            // btn_Atras
            // 
            this.btn_Atras.Location = new System.Drawing.Point(13, 235);
            this.btn_Atras.Name = "btn_Atras";
            this.btn_Atras.Size = new System.Drawing.Size(75, 23);
            this.btn_Atras.TabIndex = 3;
            this.btn_Atras.Text = "Atrás";
            this.btn_Atras.UseVisualStyleBackColor = true;
            this.btn_Atras.Click += new System.EventHandler(this.btn_Atras_Click);
            // 
            // btn_Responder
            // 
            this.btn_Responder.Location = new System.Drawing.Point(239, 235);
            this.btn_Responder.Name = "btn_Responder";
            this.btn_Responder.Size = new System.Drawing.Size(75, 23);
            this.btn_Responder.TabIndex = 4;
            this.btn_Responder.Text = "Responder";
            this.btn_Responder.UseVisualStyleBackColor = true;
            this.btn_Responder.Click += new System.EventHandler(this.btn_Responder_Click);
            // 
            // lbl_Pregunta
            // 
            this.lbl_Pregunta.AutoSize = true;
            this.lbl_Pregunta.Location = new System.Drawing.Point(10, 20);
            this.lbl_Pregunta.Name = "lbl_Pregunta";
            this.lbl_Pregunta.Size = new System.Drawing.Size(35, 13);
            this.lbl_Pregunta.TabIndex = 5;
            this.lbl_Pregunta.Text = "label1";
            // 
            // Responder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 270);
            this.Controls.Add(this.lbl_Pregunta);
            this.Controls.Add(this.btn_Responder);
            this.Controls.Add(this.btn_Atras);
            this.Controls.Add(this.labelRemaining);
            this.Controls.Add(this.lbl_Restantes);
            this.Controls.Add(this.txtBx_Respuesta);
            this.Name = "Responder";
            this.Text = "Responder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBx_Respuesta;
        private System.Windows.Forms.Label lbl_Restantes;
        private System.Windows.Forms.Label labelRemaining;
        private System.Windows.Forms.Button btn_Atras;
        private System.Windows.Forms.Button btn_Responder;
        private System.Windows.Forms.Label lbl_Pregunta;
    }
}