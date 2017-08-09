namespace FrbaCommerce.Abm_Visibilidad
{
    partial class Abm_Visibilidad
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
            this.Crear_Visib = new System.Windows.Forms.Button();
            this.Modificar_Visib = new System.Windows.Forms.Button();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Crear_Visib
            // 
            this.Crear_Visib.Location = new System.Drawing.Point(22, 12);
            this.Crear_Visib.Name = "Crear_Visib";
            this.Crear_Visib.Size = new System.Drawing.Size(115, 26);
            this.Crear_Visib.TabIndex = 0;
            this.Crear_Visib.Text = "Crear Visibilidad";
            this.Crear_Visib.UseVisualStyleBackColor = true;
            this.Crear_Visib.Click += new System.EventHandler(this.Crear_Visib_Click);
            // 
            // Modificar_Visib
            // 
            this.Modificar_Visib.Location = new System.Drawing.Point(22, 44);
            this.Modificar_Visib.Name = "Modificar_Visib";
            this.Modificar_Visib.Size = new System.Drawing.Size(115, 34);
            this.Modificar_Visib.TabIndex = 1;
            this.Modificar_Visib.Text = "Modificar/Eliminar Visibilidad";
            this.Modificar_Visib.UseVisualStyleBackColor = true;
            this.Modificar_Visib.Click += new System.EventHandler(this.Modificar_Visib_Click);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Location = new System.Drawing.Point(22, 107);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(115, 23);
            this.btn_Cerrar.TabIndex = 2;
            this.btn_Cerrar.Text = "Cerrar";
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // Abm_Visibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(161, 144);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.Modificar_Visib);
            this.Controls.Add(this.Crear_Visib);
            this.Name = "Abm_Visibilidad";
            this.Text = "Abm_Visibilidad";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Crear_Visib;
        private System.Windows.Forms.Button Modificar_Visib;
        private System.Windows.Forms.Button btn_Cerrar;
    }
}