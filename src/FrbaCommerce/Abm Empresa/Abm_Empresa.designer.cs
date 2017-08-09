namespace FrbaCommerce.Abm_Empresa
{
    partial class Abm_Empresa
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
            this.button_Listar_Emp = new System.Windows.Forms.Button();
            this.button_Dar_Baja_Emp = new System.Windows.Forms.Button();
            this.button_Modificar_Emp = new System.Windows.Forms.Button();
            this.button_Crear_Emp = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Listar_Emp);
            this.groupBox1.Controls.Add(this.button_Dar_Baja_Emp);
            this.groupBox1.Controls.Add(this.button_Modificar_Emp);
            this.groupBox1.Controls.Add(this.button_Crear_Emp);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(136, 181);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // button_Listar_Emp
            // 
            this.button_Listar_Emp.Location = new System.Drawing.Point(4, 146);
            this.button_Listar_Emp.Margin = new System.Windows.Forms.Padding(2);
            this.button_Listar_Emp.Name = "button_Listar_Emp";
            this.button_Listar_Emp.Size = new System.Drawing.Size(127, 27);
            this.button_Listar_Emp.TabIndex = 4;
            this.button_Listar_Emp.Text = "Listar empresas";
            this.button_Listar_Emp.UseVisualStyleBackColor = true;
            this.button_Listar_Emp.Click += new System.EventHandler(this.button_Listar_Emp_Click);
            // 
            // button_Dar_Baja_Emp
            // 
            this.button_Dar_Baja_Emp.Location = new System.Drawing.Point(4, 104);
            this.button_Dar_Baja_Emp.Margin = new System.Windows.Forms.Padding(2);
            this.button_Dar_Baja_Emp.Name = "button_Dar_Baja_Emp";
            this.button_Dar_Baja_Emp.Size = new System.Drawing.Size(127, 27);
            this.button_Dar_Baja_Emp.TabIndex = 3;
            this.button_Dar_Baja_Emp.Text = "Dar de baja empresa";
            this.button_Dar_Baja_Emp.UseVisualStyleBackColor = true;
            this.button_Dar_Baja_Emp.Click += new System.EventHandler(this.button_Dar_Baja_Emp_Click);
            // 
            // button_Modificar_Emp
            // 
            this.button_Modificar_Emp.Location = new System.Drawing.Point(4, 62);
            this.button_Modificar_Emp.Margin = new System.Windows.Forms.Padding(2);
            this.button_Modificar_Emp.Name = "button_Modificar_Emp";
            this.button_Modificar_Emp.Size = new System.Drawing.Size(127, 27);
            this.button_Modificar_Emp.TabIndex = 2;
            this.button_Modificar_Emp.Text = "Modificar empresa";
            this.button_Modificar_Emp.UseVisualStyleBackColor = true;
            this.button_Modificar_Emp.Click += new System.EventHandler(this.button_Modificar_Emp_Click);
            // 
            // button_Crear_Emp
            // 
            this.button_Crear_Emp.Location = new System.Drawing.Point(4, 17);
            this.button_Crear_Emp.Margin = new System.Windows.Forms.Padding(2);
            this.button_Crear_Emp.Name = "button_Crear_Emp";
            this.button_Crear_Emp.Size = new System.Drawing.Size(127, 27);
            this.button_Crear_Emp.TabIndex = 1;
            this.button_Crear_Emp.Text = "Crear empresa";
            this.button_Crear_Emp.UseVisualStyleBackColor = true;
            this.button_Crear_Emp.Click += new System.EventHandler(this.button_Crear_Emp_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(13, 214);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(127, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // Abm_Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 249);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Abm_Empresa";
            this.Text = "Abm_Empresa";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Listar_Emp;
        private System.Windows.Forms.Button button_Dar_Baja_Emp;
        private System.Windows.Forms.Button button_Modificar_Emp;
        private System.Windows.Forms.Button button_Crear_Emp;
        private System.Windows.Forms.Button btnCerrar;
    }
}