namespace FrbaCommerce.Generar_Publicacion
{
    partial class Tipo_Publicacion
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_Atras = new System.Windows.Forms.Button();
            this.button_Siguiente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(126, 45);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.MaxDropDownItems = 2;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // button_Atras
            // 
            this.button_Atras.Location = new System.Drawing.Point(50, 96);
            this.button_Atras.Margin = new System.Windows.Forms.Padding(2);
            this.button_Atras.Name = "button_Atras";
            this.button_Atras.Size = new System.Drawing.Size(56, 25);
            this.button_Atras.TabIndex = 7;
            this.button_Atras.Text = "Atrás";
            this.button_Atras.UseVisualStyleBackColor = true;
            this.button_Atras.Click += new System.EventHandler(this.button_Atras_Click);
            // 
            // button_Siguiente
            // 
            this.button_Siguiente.Location = new System.Drawing.Point(175, 96);
            this.button_Siguiente.Margin = new System.Windows.Forms.Padding(2);
            this.button_Siguiente.Name = "button_Siguiente";
            this.button_Siguiente.Size = new System.Drawing.Size(65, 24);
            this.button_Siguiente.TabIndex = 6;
            this.button_Siguiente.Text = "Siguiente";
            this.button_Siguiente.UseVisualStyleBackColor = true;
            this.button_Siguiente.Click += new System.EventHandler(this.button_Siguiente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipo de Publicación:";
            // 
            // Tipo_Publicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 143);
            this.Controls.Add(this.button_Atras);
            this.Controls.Add(this.button_Siguiente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Tipo_Publicacion";
            this.Text = "Tipo_Publicacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Atras;
        private System.Windows.Forms.Button button_Siguiente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}