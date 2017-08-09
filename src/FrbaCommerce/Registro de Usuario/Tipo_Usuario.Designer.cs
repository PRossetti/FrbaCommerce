namespace FrbaCommerce.Registro_de_Usuario
{
    partial class Tipo_Usuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_Siguiente = new System.Windows.Forms.Button();
            this.button_Atras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cliente",
            "Empresa"});
            this.comboBox1.Location = new System.Drawing.Point(122, 37);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.MaxDropDownItems = 2;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de Usuario:";
            // 
            // button_Siguiente
            // 
            this.button_Siguiente.Location = new System.Drawing.Point(173, 96);
            this.button_Siguiente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Siguiente.Name = "button_Siguiente";
            this.button_Siguiente.Size = new System.Drawing.Size(64, 24);
            this.button_Siguiente.TabIndex = 2;
            this.button_Siguiente.Text = "Siguiente";
            this.button_Siguiente.UseVisualStyleBackColor = true;
            this.button_Siguiente.Click += new System.EventHandler(this.button_Siguiente_Click);
            // 
            // button_Atras
            // 
            this.button_Atras.Location = new System.Drawing.Point(48, 96);
            this.button_Atras.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Atras.Name = "button_Atras";
            this.button_Atras.Size = new System.Drawing.Size(56, 25);
            this.button_Atras.TabIndex = 3;
            this.button_Atras.Text = "Atrás";
            this.button_Atras.UseVisualStyleBackColor = true;
            this.button_Atras.Click += new System.EventHandler(this.button_Atras_Click);
            // 
            // Tipo_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 139);
            this.Controls.Add(this.button_Atras);
            this.Controls.Add(this.button_Siguiente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Tipo_Usuario";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Siguiente;
        private System.Windows.Forms.Button button_Atras;
    }
}