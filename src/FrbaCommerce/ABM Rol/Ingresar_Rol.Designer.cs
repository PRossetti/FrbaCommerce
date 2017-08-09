namespace FrbaCommerce.ABM_Rol
{
    partial class Ingresar_Rol
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
            this.label_Rol = new System.Windows.Forms.Label();
            this.listBox_Rol = new System.Windows.Forms.ListBox();
            this.btn_Atras = new System.Windows.Forms.Button();
            this.btn_Siguiente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Rol
            // 
            this.label_Rol.AutoSize = true;
            this.label_Rol.Location = new System.Drawing.Point(12, 9);
            this.label_Rol.Name = "label_Rol";
            this.label_Rol.Size = new System.Drawing.Size(77, 13);
            this.label_Rol.TabIndex = 0;
            this.label_Rol.Text = "Seleccione rol:";
            // 
            // listBox_Rol
            // 
            this.listBox_Rol.FormattingEnabled = true;
            this.listBox_Rol.Location = new System.Drawing.Point(12, 44);
            this.listBox_Rol.Name = "listBox_Rol";
            this.listBox_Rol.Size = new System.Drawing.Size(156, 95);
            this.listBox_Rol.TabIndex = 1;
            // 
            // btn_Atras
            // 
            this.btn_Atras.Location = new System.Drawing.Point(12, 172);
            this.btn_Atras.Name = "btn_Atras";
            this.btn_Atras.Size = new System.Drawing.Size(75, 23);
            this.btn_Atras.TabIndex = 2;
            this.btn_Atras.Text = "Atrás";
            this.btn_Atras.UseVisualStyleBackColor = true;
            this.btn_Atras.Click += new System.EventHandler(this.btn_Atras_Click);
            // 
            // btn_Siguiente
            // 
            this.btn_Siguiente.Location = new System.Drawing.Point(93, 172);
            this.btn_Siguiente.Name = "btn_Siguiente";
            this.btn_Siguiente.Size = new System.Drawing.Size(75, 23);
            this.btn_Siguiente.TabIndex = 3;
            this.btn_Siguiente.Text = "Siguiente";
            this.btn_Siguiente.UseVisualStyleBackColor = true;
            this.btn_Siguiente.Click += new System.EventHandler(this.btn_Siguiente_Click);
            // 
            // Ingresar_Rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 207);
            this.Controls.Add(this.btn_Siguiente);
            this.Controls.Add(this.btn_Atras);
            this.Controls.Add(this.listBox_Rol);
            this.Controls.Add(this.label_Rol);
            this.Name = "Ingresar_Rol";
            this.Text = "Ingresar_Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Rol;
        private System.Windows.Forms.ListBox listBox_Rol;
        private System.Windows.Forms.Button btn_Atras;
        private System.Windows.Forms.Button btn_Siguiente;
    }
}