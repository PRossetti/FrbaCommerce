namespace FrbaCommerce.Abm_Cliente
{
    partial class Ingresar_Cliente
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
            this.textBox_Usuario = new System.Windows.Forms.TextBox();
            this.button_Siguiente = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario:";
            // 
            // textBox_Usuario
            // 
            this.textBox_Usuario.Location = new System.Drawing.Point(150, 28);
            this.textBox_Usuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Usuario.Name = "textBox_Usuario";
            this.textBox_Usuario.Size = new System.Drawing.Size(128, 20);
            this.textBox_Usuario.TabIndex = 1;
            // 
            // button_Siguiente
            // 
            this.button_Siguiente.Location = new System.Drawing.Point(221, 68);
            this.button_Siguiente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Siguiente.Name = "button_Siguiente";
            this.button_Siguiente.Size = new System.Drawing.Size(67, 21);
            this.button_Siguiente.TabIndex = 2;
            this.button_Siguiente.Text = "Siguiente";
            this.button_Siguiente.UseVisualStyleBackColor = true;
            this.button_Siguiente.Click += new System.EventHandler(this.button_Siguiente_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(29, 68);
            this.button_Cancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(56, 21);
            this.button_Cancelar.TabIndex = 3;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // Ingresar_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 102);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Siguiente);
            this.Controls.Add(this.textBox_Usuario);
            this.Controls.Add(this.label1);
            this.Name = "Ingresar_Cliente";
            this.Text = "Ingresar_Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Usuario;
        private System.Windows.Forms.Button button_Siguiente;
        private System.Windows.Forms.Button button_Cancelar;
    }
}